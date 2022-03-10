/*++

Copyright (c) Microsoft Corporation.  All rights reserved.

    THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    PURPOSE.

Module Name:

    Write.c

Abstract:


Environment:

    Kernel mode

--*/

#include "precomp.h"

#include "Write.tmh"


//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
VOID
PLxEvtIoWrite(
    IN WDFQUEUE         Queue,
    IN WDFREQUEST       Request,
    IN size_t            Length
    )
/*++

Routine Description:

    Called by the framework as soon as it receives a write request.
    If the device is not ready, fail the request.
    Otherwise get scatter-gather list for this request and send the
    packet to the hardware for DMA.

Arguments:

    Queue - Handle to the framework queue object that is associated
            with the I/O request.
    Request - Handle to a framework request object.

    Length - Length of the IO operation
                 The default property of the queue is to not dispatch
                 zero lenght read & write requests to the driver and
                 complete is with status success. So we will never get
                 a zero length request.

Return Value:

--*/
{
    NTSTATUS          status = STATUS_UNSUCCESSFUL;
    PDEVICE_EXTENSION devExt = NULL;

	UNREFERENCED_PARAMETER(Length);

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_WRITE,
                "--> PLxEvtIoWrite: Request %p", Request);

    //
    // Get the DevExt from the Queue handle
    //
    devExt = PLxGetDeviceContext(WdfIoQueueGetDevice(Queue));

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_WRITE,
                "<-- PLxEvtIoWrite: %!STATUS!", status);

    return;
}


