/*++

Copyright (c) Microsoft Corporation.  All rights reserved.

    THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    PURPOSE.

Module Name:

    Init.c

Abstract:

    Contains most of initialization functions

Environment:

    Kernel mode

--*/

#include "precomp.h"

#include "Init.tmh"

#ifdef ALLOC_PRAGMA
#pragma alloc_text (PAGE, PLxInitializeDeviceExtension)
#pragma alloc_text (PAGE, PLxPrepareHardware)
//#pragma alloc_text (PAGE, PLxInitializeDMA)
#pragma alloc_text (PAGE, PLxGetDeviceInformation)
#endif

PVOID LocalMmMapIoSpace(
    _In_ PHYSICAL_ADDRESS PhysicalAddress,
    _In_ SIZE_T NumberOfBytes
    )
{
    typedef
    PVOID
    (*PFN_MM_MAP_IO_SPACE_EX) (
        _In_ PHYSICAL_ADDRESS PhysicalAddress,
        _In_ SIZE_T NumberOfBytes,
        _In_ ULONG Protect
        );

    UNICODE_STRING         name;
    PFN_MM_MAP_IO_SPACE_EX pMmMapIoSpaceEx;

    RtlInitUnicodeString(&name, L"MmMapIoSpaceEx");
    pMmMapIoSpaceEx = (PFN_MM_MAP_IO_SPACE_EX) (ULONG_PTR)MmGetSystemRoutineAddress(&name);

    if (pMmMapIoSpaceEx != NULL){
        //
        // Call WIN10 API if available
        //        
        return pMmMapIoSpaceEx(PhysicalAddress,
                               NumberOfBytes,
                               PAGE_READWRITE | PAGE_NOCACHE); 
    }

    //
    // Supress warning that MmMapIoSpace allocates executable memory.
    // This function is only used if the preferred API, MmMapIoSpaceEx
    // is not present. MmMapIoSpaceEx is available starting in WIN10.
    //
    #pragma warning(suppress: 30029)
    return MmMapIoSpace(PhysicalAddress, NumberOfBytes, MmNonCached); 
}

UCHAR GetBarIndex(
	IN PHYSICAL_ADDRESS   PhysicalAddress,
	IN PPCI_COMMON_CONFIG PciRegs
)
{
	UCHAR  i;
	ULONG CompareAddress;

	// Compare the physical address with each BAR  
	for (i = 0; i < PCI_TYPE0_ADDRESSES; i++)
	{
		if (PciRegs->u.type0.BaseAddresses[i] & 0x1)
			CompareAddress = PciRegs->u.type0.BaseAddresses[i] & 0xFFFFFFFC;
		else
			CompareAddress = PciRegs->u.type0.BaseAddresses[i] & 0xFFFFFFF0;

		if (PhysicalAddress.u.LowPart == CompareAddress)
			return i;
	}

	// Unable to find the BAR index  
	TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "ERROR - GetBarIndex() unable to match BAR value (0x%08lx)\n",
		PhysicalAddress.LowPart
	);

	return (UCHAR)-1;
}


NTSTATUS
PLxInitializeDeviceExtension(
    IN PDEVICE_EXTENSION DevExt
    )
/*++
Routine Description:

    This routine is called by EvtDeviceAdd. Here the device context is
    initialized and all the software resources required by the device is
    allocated.

Arguments:

    DevExt     Pointer to the Device Extension

Return Value:

     NTSTATUS

--*/
{
    NTSTATUS    status;
    //ULONG       dteCount;
    WDF_IO_QUEUE_CONFIG  queueConfig;
	//PNP_BUS_INFORMATION busInfo;

    PAGED_CODE();

    //
    // Setup a queue to handle only IRP_MJ_WRITE requests in Sequential
    // dispatch mode. This mode ensures there is only one write request
    // outstanding in the driver at any time. Framework will present the next
    // request only if the current request is completed.
    // Since we have configured the queue to dispatch all the specific requests
    // we care about, we don't need a default queue.  A default queue is
    // used to receive requests that are not preconfigured to goto
    // a specific queue.
    //
    WDF_IO_QUEUE_CONFIG_INIT ( &queueConfig,
                              WdfIoQueueDispatchSequential);

    queueConfig.EvtIoWrite = PLxEvtIoWrite;

    //
    // Static Driver Verifier (SDV) displays a warning if it doesn't find the 
    // EvtIoStop callback on a power-managed queue. The 'assume' below lets 
    // SDV know not to worry about the EvtIoStop.
    // If not explicitly set, the framework creates power-managed queues when 
    // the device is not a filter driver.  Normally the EvtIoStop is required
    // for power-managed queues, but for this driver it is not need b/c the 
    // driver doesn't hold on to the requests for long time or forward them to
    // other drivers. 
    // If the EvtIoStop callback is not implemented, the framework 
    // waits for all in-flight (driver owned) requests to be done before 
    // moving the device in the Dx/sleep states or before removing the device,
    // which is the correct behavior for this type of driver.
    // If the requests were taking an undetermined amount of time to complete,
    // or the requests were forwarded to a lower driver/another stack, the 
    // queue should have an EvtIoStop/EvtIoResume.
    //
    __analysis_assume(queueConfig.EvtIoStop != 0);
    status = WdfIoQueueCreate( DevExt->Device,
                               &queueConfig,
                               WDF_NO_OBJECT_ATTRIBUTES,
                               &DevExt->WriteQueue );
    __analysis_assume(queueConfig.EvtIoStop == 0);
    
    if(!NT_SUCCESS(status)) {
        TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
                    "WdfIoQueueCreate failed: %!STATUS!", status);
        return status;
    }

    //
    // Set the Write Queue forwarding for IRP_MJ_WRITE requests.
    //
    status = WdfDeviceConfigureRequestDispatching( DevExt->Device,
                                       DevExt->WriteQueue,
                                       WdfRequestTypeWrite);

    if(!NT_SUCCESS(status)) {
        TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
                    "DeviceConfigureRequestDispatching failed: %!STATUS!", status);
        return status;
    }


    //
    // Create a new IO Queue for IRP_MJ_READ requests in sequential mode.
    //
    WDF_IO_QUEUE_CONFIG_INIT( &queueConfig,
                              WdfIoQueueDispatchSequential);

    queueConfig.EvtIoRead = PLxEvtIoRead;

    //
    // By default, Static Driver Verifier (SDV) displays a warning if it 
    // doesn't find the EvtIoStop callback on a power-managed queue. 
    // The 'assume' below causes SDV to suppress this warning. If the driver 
    // has not explicitly set PowerManaged to WdfFalse, the framework creates
    // power-managed queues when the device is not a filter driver.  Normally 
    // the EvtIoStop is required for power-managed queues, but for this driver
    // it is not needed b/c the driver doesn't hold on to the requests for 
    // long time or forward them to other drivers. 
    // If the EvtIoStop callback is not implemented, the framework waits for
    // all driver-owned requests to be done before moving in the Dx/sleep 
    // states or before removing the device, which is the correct behavior 
    // for this type of driver. If the requests were taking an indeterminate
    // amount of time to complete, or if the driver forwarded the requests
    // to a lower driver/another stack, the queue should have an 
    // EvtIoStop/EvtIoResume.
    //
    __analysis_assume(queueConfig.EvtIoStop != 0);
    status = WdfIoQueueCreate( DevExt->Device,
                               &queueConfig,
                               WDF_NO_OBJECT_ATTRIBUTES,
                               &DevExt->ReadQueue );
    __analysis_assume(queueConfig.EvtIoStop == 0);
    
    if(!NT_SUCCESS(status)) {
        TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
                    "WdfIoQueueCreate failed: %!STATUS!", status);
        return status;
    }

    //
    // Set the Read Queue forwarding for IRP_MJ_READ requests.
    //
    status = WdfDeviceConfigureRequestDispatching( DevExt->Device,
                                       DevExt->ReadQueue,
                                       WdfRequestTypeRead);

    if(!NT_SUCCESS(status)) {
        TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
                    "DeviceConfigureRequestDispatching failed: %!STATUS!", status);
        return status;
    }


    //
    // Create a new IO Queue for IOCTLs in sequential mode.
    //
    WDF_IO_QUEUE_CONFIG_INIT( &queueConfig,
                              WdfIoQueueDispatchSequential);

    queueConfig.EvtIoDeviceControl = PLxEvtIoDeviceControl;

    status = WdfIoQueueCreate(DevExt->Device,
                              &queueConfig,
                              WDF_NO_OBJECT_ATTRIBUTES,
                              &DevExt->ControlQueue);
    if(!NT_SUCCESS(status)) {
		TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
			"WdfIoQueueCreate failed: %!STATUS!", status);
        return status;
    }

    //
    // Set the Control Queue forwarding for IOCTL requests.
    //
    status = WdfDeviceConfigureRequestDispatching(DevExt->Device,
                                                  DevExt->ControlQueue,
                                                  WdfRequestTypeDeviceControl);

    if(!NT_SUCCESS(status)) {
		TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
			"WdfDeviceConfigureRequestDispatching failed: %!STATUS!", status);
        return status;
    }


    //
    // Create a WDFINTERRUPT object.
    //
    //status = PLxInterruptCreate(DevExt);

    //if (!NT_SUCCESS(status)) {
    //    return status;
    //}

	//
	// Get the BUS_INTERFACE_STANDARD for our device so that we can
	// read & write to PCI config space.
	//
	status = WdfFdoQueryForInterface(DevExt->Device,
		&GUID_BUS_INTERFACE_STANDARD,
		(PINTERFACE)&DevExt->BusInterface,
		sizeof(BUS_INTERFACE_STANDARD),
		1,     // Version
		NULL); //InterfaceSpecificData

	if (!NT_SUCCESS(status)) {
		return status;
	}

	//
	// First make sure this is our device before doing whole lot
	// of other things.
	//
	status = PLxGetDeviceInformation(DevExt);
	if (!NT_SUCCESS(status)) {
		return status;
	}

    return status;
}


VOID
PlxCleanupDeviceExtension(
    _In_ PDEVICE_EXTENSION DevExt
    )
/*++

Routine Description:

    Frees allocated memory that was saved in the
    WDFDEVICE's context, before the device object
    is deleted.

Arguments:

    DevExt - Pointer to our DEVICE_EXTENSION

Return Value:

     None

--*/
{
#ifdef SIMULATE_MEMORY_FRAGMENTATION
    if (DevExt->WriteMdlChain) {
        DestroyMdlChain(DevExt->WriteMdlChain);
        DevExt->WriteMdlChain = NULL;
    }

    if (DevExt->ReadMdlChain) {
        DestroyMdlChain(DevExt->ReadMdlChain);
        DevExt->ReadMdlChain = NULL;
    }
#else
    UNREFERENCED_PARAMETER(DevExt);
#endif
}


NTSTATUS
PLxPrepareHardware(
    IN PDEVICE_EXTENSION DevExt,
    IN WDFCMRESLIST     ResourcesTranslated
    )
/*++
Routine Description:

    Gets the HW resources assigned by the bus driver from the start-irp
    and maps it to system address space.

Arguments:

    DevExt      Pointer to our DEVICE_EXTENSION

Return Value:

     None

--*/
{
 //   ULONG               i;
 //   NTSTATUS            status = STATUS_SUCCESS;
 //   CHAR              * bar;

 //   BOOLEAN             foundRegs      = FALSE;
 //   PHYSICAL_ADDRESS    regsBasePA     = { 0 };
 //   ULONG               regsLength     = 0;

 //   BOOLEAN             foundPort      = FALSE;
	//PHYSICAL_ADDRESS    portBasePA     = { 0 };
	//ULONG               portLength     = 0;

	//BOOLEAN             foundSRAM      = FALSE;
	//PHYSICAL_ADDRESS    SRAMBasePA     = { 0 };
	//ULONG               SRAMLength     = 0;

	//BOOLEAN             foundIO        = FALSE;
	//PHYSICAL_ADDRESS    IOBasePA       = { 0 };
	//ULONG               IOLength       = 0;

	ULONG               i;
	NTSTATUS            status = STATUS_SUCCESS;
	UCHAR				barNum = 0;
	PHYSICAL_ADDRESS    barBasePA = { 0 };
	ULONG               barLength = 0;

    PCM_PARTIAL_RESOURCE_DESCRIPTOR  desc;

    PAGED_CODE();

    //
    // Parse the resource list and save the resource information.
    //
	for (i = 0; i < WdfCmResourceListGetCount(ResourcesTranslated); i++) {

		desc = WdfCmResourceListGetDescriptor(ResourcesTranslated, i);

		if (!desc) {
			TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
				"WdfResourceCmGetDescriptor failed");
			return STATUS_DEVICE_CONFIGURATION_ERROR;
		}

		switch (desc->Type) {

		case CmResourceTypeMemory:
			barBasePA = desc->u.Memory.Start;
			barLength = desc->u.Memory.Length;
			barNum = GetBarIndex(barBasePA, &DevExt->PciCommonConfig);

			if (barNum < PCI_TYPE0_ADDRESSES)
			{
				DevExt->Bar[barNum].Base = (PUCHAR)LocalMmMapIoSpace(barBasePA, barLength);
				DevExt->Bar[barNum].Length = barLength;
				DevExt->Bar[barNum].WasMapped = TRUE;
			}

			TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP,
				"BAR%d - Memory Resource 0x%I64X-0x%I64X[%d]",
				barNum,
				desc->u.Memory.Start.QuadPart,
				desc->u.Memory.Start.QuadPart + desc->u.Memory.Length,
				desc->u.Memory.Length);
			break;

		case CmResourceTypePort:
			barBasePA = desc->u.Port.Start;
			barLength = desc->u.Port.Length;
			barNum = GetBarIndex(barBasePA, &DevExt->PciCommonConfig);

			if (barNum < PCI_TYPE0_ADDRESSES)
			{
				DevExt->Bar[barNum].Base = ULongToPtr(desc->u.Port.Start.LowPart);
				DevExt->Bar[barNum].Length = barLength;
				DevExt->Bar[barNum].WasMapped = FALSE;
			}

			TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP,
				"BAR%d - Port Resource 0x%I64X-0x%I64X[%d]",
				barNum,
				desc->u.Port.Start.QuadPart,
				desc->u.Port.Start.QuadPart + desc->u.Port.Length,
				desc->u.Port.Length);
			break;

		case CmResourceTypeInterrupt:

			if (desc->Flags & CM_RESOURCE_INTERRUPT_MESSAGE) {
				TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP,
					"EvtDevicePrepareHardware: Resource %d: Interrupt level: 0x%0x, Vector: 0x%0x, MessageCount: %d",
					i,
					desc->u.MessageInterrupt.Translated.Level,
					desc->u.MessageInterrupt.Translated.Vector,
					desc->u.MessageInterrupt.Raw.MessageCount);
			}
			else {
				TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP,
					"EvtDevicePrepareHardware: Resource %d: Interrupt level: 0x%0x, Vector: 0x%0x",
					i,
					desc->u.Interrupt.Level,
					desc->u.Interrupt.Vector);
			}
			break;

		default:
			// Ignore all other descriptors
			break;
		}
	}

	if (!DevExt->Bar[barNum].Base) {
		TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
			" - Unable to map BAR0 memory %p, length %d",
			DevExt->Bar[barNum].Base, DevExt->Bar[barNum].Length);
		return STATUS_INSUFFICIENT_RESOURCES;
	}

	//if (!DevExt->PortBase) {
	//	TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
	//		" - Unable to map Port memory %08I64X, length %d",
	//		portBasePA.QuadPart, portLength);
	//	return STATUS_INSUFFICIENT_RESOURCES;
	//}

	//if (!DevExt->SRAMBase) {
	//	TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
	//		" - Unable to map SRAM memory %08I64X, length %d",
	//		SRAMBasePA.QuadPart, SRAMLength);
	//	return STATUS_INSUFFICIENT_RESOURCES;
	//}

    //if (!(foundRegs && foundPort)) {
    //    TraceEvents(TRACE_LEVEL_ERROR, DBG_PNP,
    //                "MapResources: Missing resources");
    //    return STATUS_DEVICE_CONFIGURATION_ERROR;
    //}

    return status;
}



NTSTATUS
PLxInitWrite(
    IN PDEVICE_EXTENSION DevExt
    )
/*++
Routine Description:

    Initialize write data structures

Arguments:

    DevExt     Pointer to Device Extension

Return Value:

    None

--*/
{
	UNREFERENCED_PARAMETER(DevExt);

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "--> PLxInitWrite");

	//WRITE_PORT_USHORT((PUSHORT)(DevExt->RegsBase + 0x50), (USHORT)0x8000);//Set IOCS0 Decode Range
	//WRITE_PORT_USHORT((PUSHORT)(DevExt->RegsBase + 0x52), (USHORT)0x8080);//Set IOCS1 Decode Range
	//WRITE_PORT_USHORT((PUSHORT)(DevExt->RegsBase + 0x70), (USHORT)0x000F);//Set IOCS0 IOCS1 Address Timing

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "<-- PLxInitWrite");

    return STATUS_SUCCESS;
}


NTSTATUS
PLxInitRead(
    IN PDEVICE_EXTENSION DevExt
    )
/*++
Routine Description:

    Initialize read data structures

Arguments:

    DevExt     Pointer to Device Extension

Return Value:

--*/
{
	UNREFERENCED_PARAMETER(DevExt);

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "--> PLxInitRead");





    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "<-- PLxInitRead");

    return STATUS_SUCCESS;
}

VOID
PLxShutdown(
    IN PDEVICE_EXTENSION DevExt
    )
/*++

Routine Description:

    Reset the device to put the device in a known initial state.
    This is called from D0Exit when the device is torn down or
    when the system is shutdown. Note that Wdf has already
    called out EvtDisable callback to disable the interrupt.

Arguments:

    DevExt -  Pointer to our adapter

Return Value:

    None

--*/
{
	UNREFERENCED_PARAMETER(DevExt);

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "---> PLxShutdown");

    //
    // WdfInterrupt is already disabled so issue a full reset
    //
    //if (DevExt->Regs) {

    //    //PLxHardwareReset(DevExt);
    //}

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "<--- PLxShutdown");
}

VOID
PLxHardwareReset(
    IN PDEVICE_EXTENSION DevExt
    )
/*++
Routine Description:

    Called by D0Exit when the device is being disabled or when the system is shutdown to
    put the device in a known initial state.

Arguments:

    DevExt     Pointer to Device Extension

Return Value:

--*/
{
	UNREFERENCED_PARAMETER(DevExt);

	/*
    LARGE_INTEGER delay;

    union {
		ADAPTER_CONTROL bits;
        UCHAR           uchar;
    } adapterControl;

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "--> PLxIssueFullReset");

    //
    // Drive the 9656 into soft reset.
    //
	adapterControl.uchar = READ_PORT_UCHAR((PUCHAR)&DevExt->Regs->Adapter_Control);

	adapterControl.bits.AdapterSoftwareReset = TRUE;

    WRITE_PORT_UCHAR( (PUCHAR)&DevExt->Regs->Adapter_Control, adapterControl.uchar);

    //
    // Wait 100 msec.
    //
    delay.QuadPart =  WDF_REL_TIMEOUT_IN_MS(100);

    KeDelayExecutionThread( KernelMode, TRUE, &delay );

    //
    // Finally pull the apic21 out of reset.
    //
	adapterControl.bits.AdapterSoftwareReset = FALSE;

    WRITE_PORT_UCHAR( (PUCHAR)&DevExt->Regs->Adapter_Control, adapterControl.uchar);
	*/

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_PNP, "<-- PLxIssueFullReset");
}

NTSTATUS
PLxGetDeviceInformation(
	IN PDEVICE_EXTENSION DevExt
)
/*++
Routine Description:

This function reads the PCI config space and make sure that it's our
device and stores the device IDs and power information in the device
extension. Should be done in the StartDevice.

Arguments:

FdoData     Pointer to our FdoData

Return Value:

None

--*/
{
	NTSTATUS            status = STATUS_SUCCESS;
	//DECLSPEC_ALIGN(MEMORY_ALLOCATION_ALIGNMENT) UCHAR buffer[APIC22_PCI_HDR_LENGTH];
	//PPCI_COMMON_CONFIG  pPciConfig = (PPCI_COMMON_CONFIG)buffer;
	//PPCI_COMMON_CONFIG  pPciConfig = &DevExt->PciCommonConfig;
	//USHORT              usPciCommand;
	ULONG               bytesRead = 0;

	TraceEvents(TRACE_LEVEL_VERBOSE, DBG_INIT, "---> PLxGetDeviceInformation\n");

	PAGED_CODE();

	RtlZeroMemory(&DevExt->PciCommonConfig, sizeof(PCI_COMMON_CONFIG));

	bytesRead = DevExt->BusInterface.GetBusData(//READ
		DevExt->BusInterface.Context,
		PCI_WHICHSPACE_CONFIG, 
		(UCHAR *)&DevExt->PciCommonConfig,
		FIELD_OFFSET(PCI_COMMON_CONFIG, VendorID),
		sizeof(PCI_COMMON_CONFIG));

	if (bytesRead != sizeof(PCI_COMMON_CONFIG)) {
		TraceEvents(TRACE_LEVEL_ERROR, DBG_INIT,
			"GetBusData (PLX_PCI_HDR_LENGTH) failed =%d\n",
			bytesRead);
		return STATUS_INVALID_DEVICE_REQUEST;
	}

	//
	// Is this our device?
	//
	//DevExt->VendorID = DevExt->PciCommonConfig.VendorID;
	//DevExt->DeviceID = DevExt->PciCommonConfig.DeviceID;

	TraceEvents(TRACE_LEVEL_INFORMATION, DBG_INIT,
		"VendorID/DeviceID - 0x%x/0x%x\n",
		DevExt->PciCommonConfig.VendorID, DevExt->PciCommonConfig.DeviceID);

	TraceEvents(TRACE_LEVEL_INFORMATION, DBG_INIT,
		"Command/Status - 0x%x/0x%x\n",
		DevExt->PciCommonConfig.Command, DevExt->PciCommonConfig.Status);

	TraceEvents(TRACE_LEVEL_INFORMATION, DBG_INIT,
		"InterruptLine/InterruptPin - 0x%x/0x%x\n",
		DevExt->PciCommonConfig.u.type0.InterruptLine, DevExt->PciCommonConfig.u.type0.InterruptPin);

	TraceEvents(TRACE_LEVEL_VERBOSE, DBG_INIT, "<-- PLxGetDeviceInformation\n");

	return status;
}



