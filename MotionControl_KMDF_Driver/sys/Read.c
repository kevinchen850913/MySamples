/*++

Copyright (c) Microsoft Corporation.  All rights reserved.

    THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    PURPOSE.

Module Name:

    Read.c

Abstract:


Environment:

    Kernel mode

--*/

#include "precomp.h"

#include "Read.tmh"


//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
VOID
PLxEvtIoRead(
    IN WDFQUEUE         Queue,
    IN WDFREQUEST       Request,
    IN size_t            Length
    )
/*++

Routine Description:

    Called by the framework as soon as it receives a read request.
    If the device is not ready, fail the request.
    Otherwise get scatter-gather list for this request and send the
    packet to the hardware for DMA.

Arguments:

    Queue      - Default queue handle
    Request    - Handle to the write request
    Lenght - Length of the data buffer associated with the request.
                     The default property of the queue is to not dispatch
                 zero lenght read & write requests to the driver and
                 complete is with status success. So we will never get
                 a zero length request.

Return Value:

--*/
{
    NTSTATUS                status = STATUS_UNSUCCESSFUL;
    PDEVICE_EXTENSION       devExt;

	UNREFERENCED_PARAMETER(Length);

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_READ,
                "--> PLxEvtIoRead: Request %p", Request);

    //
    // Get the DevExt from the Queue handle
    //
    devExt = PLxGetDeviceContext(WdfIoQueueGetDevice(Queue));

    TraceEvents(TRACE_LEVEL_INFORMATION, DBG_READ,
                "<-- PLxEvtIoRead: status %!STATUS!", status);

    return;
}


