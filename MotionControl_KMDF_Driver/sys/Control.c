/*++

Copyright (c) Microsoft Corporation.  All rights reserved.

    THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    PURPOSE.

Module Name:

    Control.c

Abstract:

    This module implements the driver's IOCTL handler.

Environment:

    Kernel mode

--*/

#include "precomp.h"

#include "Control.tmh"

PKEVENT  __KernelEvent[20] = { 0 };
ULONG_PTR __KernelEventCount = 0;

NTSTATUS Ring3EventHandleToRing0KernelEvent(HANDLE* EventHandle, ULONG_PTR EventHandleCount)
{
	NTSTATUS   Status = STATUS_SUCCESS;
	//PULONG_PTR HandleArray = NULL;
	ULONG i = 0;

	if (EventHandle == NULL)
	{
		return STATUS_UNSUCCESSFUL;
	}
	__KernelEventCount = EventHandleCount;
	for (i = 0; i < EventHandleCount; i++)
	{
		Status = ObReferenceObjectByHandle(
			(HANDLE)EventHandle[i],           //Irp->AssociatedIrp.SystemBuffer
			SYNCHRONIZE,                      //
			*ExEventObjectType,               //
			KernelMode,                       //KernelMode
			&__KernelEvent[i],                //
			NULL);
		if (!NT_SUCCESS(Status))
		{
			break;
		}
	}

	if (Status != STATUS_SUCCESS)
	{
		for (i = 0; i < EventHandleCount; i++)
		{
			if (__KernelEvent[i] != NULL)
			{
				ObDereferenceObject(__KernelEvent[i]);

				__KernelEvent[i] = NULL;
			}
		}
	}
	return Status;
}
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
VOID
PLxEvtIoDeviceControl(
    _In_ WDFQUEUE   Queue,
    _In_ WDFREQUEST Request,
    _In_ size_t     OutputBufferLength,
    _In_ size_t     InputBufferLength,
    _In_ ULONG      IoControlCode
    )
/*++

Routine Description:

    Called by the framework as soon as it receives a Device I/O request.

    Note that this callback may run concurrently to the read and write
    queues' callbacks. This is acceptable in the context of this sample,
    because the companion application runs Read/Write requests and IOCTL
    requests sequentially, but your project might require some form of
    synchronization.

Arguments:

    Queue              - Handle to the IOCTL Queue
    Request            - Handle to the IOCTL request
    OutputBufferLength - Length of request's output buffer
    InputBufferLength  - Length of request's input buffer
    IoControlCode      - The IOCTL associated with the request

Return Value:

--*/
{
	NTSTATUS status;
	WDFDEVICE device;
	PDEVICE_EXTENSION devExt;

	PULONG outBuffer;
	PULONG inBuffer;

	UCHAR   barNum;
	UCHAR   type;
	USHORT  offset;
	ULONG   value = 0;

	UNREFERENCED_PARAMETER(InputBufferLength);
	UNREFERENCED_PARAMETER(OutputBufferLength);

	device = WdfIoQueueGetDevice(Queue);
	devExt = PLxGetDeviceContext(device);

	//RtlCopyMemory(Destination, Source, Length);
	//RtlZeroMemory(Destination, Length);

	switch (IoControlCode) {

	case IOCTL_READ_CFG:
		//ULONG uPciConPort = 0xCF8;
		//ULONG uPcIDataPort = 0xCFC;

		status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG), &inBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
			break;
		}

		status = WdfRequestRetrieveOutputBuffer(Request, sizeof(ULONG), &outBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveOutputBuffer failed %!STATUS!", status);
			break;
		}

		type = ((PCI_COMMAND *)inBuffer)->Type;
		offset = ((PCI_COMMAND *)inBuffer)->Offset;

		if (offset < sizeof(PCI_COMMON_CONFIG))//192)//APIC22 MAX 192
		{
			if (type == 1)
			{
				devExt->BusInterface.GetBusData(//Read
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(UCHAR));

				*outBuffer = value;

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}
			if (type == 2)
			{
				devExt->BusInterface.GetBusData(//Read
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(USHORT));

				*outBuffer = value;

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}
			if (type == 4)
			{
				devExt->BusInterface.GetBusData(//Read
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(ULONG));

				*outBuffer = value;

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}

			TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "Read ConfigRegs[0x%x] = 0x%08x", offset, *outBuffer);
		}
		break;

	case IOCTL_WRITE_CFG:
		status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG) * 2, &inBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
			break;
		}

		type = ((PCI_COMMAND *)inBuffer)->Type;
		offset = ((PCI_COMMAND *)inBuffer)->Offset;
		value = ((PCI_COMMAND *)inBuffer)->Value;

		if (offset < sizeof(PCI_COMMON_CONFIG))//APIC22 MAX 192
		{
			if (type == 1)
			{
				devExt->BusInterface.SetBusData(//Write
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(UCHAR));
			}
			else if (type == 2)
			{
				devExt->BusInterface.SetBusData(//Write
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(USHORT));
			}
			else if (type == 4)
			{
				devExt->BusInterface.SetBusData(//Write
					devExt->BusInterface.Context,
					PCI_WHICHSPACE_CONFIG,
					&value,
					offset,
					sizeof(ULONG));
			}

			TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "Write ConfigRegs[0x%x] = 0x%08x", offset, value);
		}
		break;


	case IOCTL_READ:
		status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG), &inBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
			break;
		}
		status = WdfRequestRetrieveOutputBuffer(Request, sizeof(ULONG), &outBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveOutputBuffer failed %!STATUS!", status);
			break;
		}

		barNum = ((PCI_COMMAND *)inBuffer)->BarNum;
		type = ((PCI_COMMAND *)inBuffer)->Type;
		offset = ((PCI_COMMAND *)inBuffer)->Offset;

		if (barNum > 4)
			break;

		if (offset < devExt->Bar[barNum].Length)
		{
			if (type == 1)//UCHAR Type
			{
				if (devExt->Bar[barNum].WasMapped)
					*outBuffer = READ_REGISTER_UCHAR((PUCHAR)(devExt->Bar[barNum].Base + offset));
				else
					*outBuffer = READ_PORT_UCHAR((PUCHAR)(devExt->Bar[barNum].Base + offset));

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}
			else if (type == 2)//USHORT Type
			{
				if (devExt->Bar[barNum].WasMapped)
					*outBuffer = READ_REGISTER_USHORT((PUSHORT)(devExt->Bar[barNum].Base + offset));
				else
					*outBuffer = READ_PORT_USHORT((PUSHORT)(devExt->Bar[barNum].Base + offset));

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}
			else if (type == 4)//ULONG Type
			{
				if (devExt->Bar[barNum].WasMapped)
					*outBuffer = READ_REGISTER_ULONG((PULONG)(devExt->Bar[barNum].Base + offset));
				else
					*outBuffer = READ_PORT_ULONG((PULONG)(devExt->Bar[barNum].Base + offset));

				WdfRequestSetInformation(Request, (ULONG_PTR)sizeof(*outBuffer));
			}

			TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "Read Bar%d[0x%x] = 0x%08x", barNum, offset, *outBuffer);
		}
		break;

	case IOCTL_WRITE:
		status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG) * 2, &inBuffer, NULL);

		if (!NT_SUCCESS(status)) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
			break;
		}

		barNum = ((PCI_COMMAND *)inBuffer)->BarNum;
		type = ((PCI_COMMAND *)inBuffer)->Type;
		offset = ((PCI_COMMAND *)inBuffer)->Offset;
		value = ((PCI_COMMAND *)inBuffer)->Value;

		if (offset < devExt->Bar[barNum].Length)
		{
			if (type == 1)//UCHAR Type
			{
				if (devExt->Bar[barNum].WasMapped)
					WRITE_REGISTER_UCHAR((PUCHAR)(devExt->Bar[barNum].Base + offset), (UCHAR)value);
				else
					WRITE_PORT_UCHAR((PUCHAR)(devExt->Bar[barNum].Base + offset), (UCHAR)value);
			}
			else if (type == 2)//USHORT Type
			{
				if (devExt->Bar[barNum].WasMapped)
					WRITE_REGISTER_USHORT((PUSHORT)(devExt->Bar[barNum].Base + offset), (USHORT)value);
				else
					WRITE_PORT_USHORT((PUSHORT)(devExt->Bar[barNum].Base + offset), (USHORT)value);
			}
			else if (type == 4)//ULONG Type
			{
				if (devExt->Bar[barNum].WasMapped)
					WRITE_REGISTER_ULONG((PULONG)(devExt->Bar[barNum].Base + offset), (ULONG)value);
				else
					WRITE_PORT_ULONG((PULONG)(devExt->Bar[barNum].Base + offset), (ULONG)value);
			}

			TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "Write Bar%d[0x%x] = 0x%08x", barNum, offset, value);
		}
		break;

	//case IOCTL_SET_INT_CB:
	//	//status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG) * 2, &inBuffer, NULL);

	//	//if (!NT_SUCCESS(status)) {
	//	//	TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
	//	//	break;
	//	//}

	//	//devExt->IntCallback = *((INT_CALLBACK *)inBuffer);

	//	//(*devExt->IntCallback)();

	//	//TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "CB 0x%08d", devExt->IntCallback);

	//	break;

	//case IOCTL_EXEC_INT_CB:
	//	//status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG) * 2, &inBuffer, NULL);

	//	//if (!NT_SUCCESS(status)) {
	//	//	TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
	//	//	break;
	//	//}

	//	//(*devExt->IntCallback)();

	//	//TraceEvents(TRACE_LEVEL_VERBOSE, DBG_IOCTL, "CB 0x%08x", devExt->IntCallback);

	//	break;

	//case IOCTL_REGISTER_EVENT:
	//	status = WdfRequestRetrieveInputBuffer(Request, sizeof(ULONG), &inBuffer, NULL);

	//	if (!NT_SUCCESS(status)) {
	//		TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "WdfRequestRetrieveInputBuffer failed %!STATUS!", status);
	//		break;
	//	}
	//	status = Ring3EventHandleToRing0KernelEvent((HANDLE*)inBuffer, InputBufferLength / sizeof(HANDLE));
	//	break;

	default:
		status = STATUS_INVALID_DEVICE_REQUEST;
		TraceEvents(TRACE_LEVEL_ERROR, DBG_IOCTL, "Unknown IOCTL 0x%x %!STATUS!", IoControlCode, status);

		break;
	}

	WdfRequestComplete(Request, status);
}


