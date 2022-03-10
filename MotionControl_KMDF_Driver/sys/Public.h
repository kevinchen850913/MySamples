/*++
    Copyright (c) Microsoft Corporation.  All rights reserved.

    THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    PURPOSE.

Module Name:

    Public.h

Abstract:

    This module contains the common declarations shared by driver
    and user applications.

Environment:

    user and kernel

--*/
  
//
// The following value is arbitrarily chosen from the space defined 
// by Microsoft as being "for non-Microsoft use"
//

// {8502683C-E3CF-4A7F-9513-64E3799771B2}
DEFINE_GUID(GUID_DEVICE_INTERFACE,
	0x8502683c, 0xe3cf, 0x4a7f, 0x95, 0x13, 0x64, 0xe3, 0x79, 0x97, 0x71, 0xb2);

#define IOCTL_READ_CFG   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0x800, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define IOCTL_WRITE_CFG   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0x900, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define IOCTL_READ   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xA00, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define IOCTL_WRITE   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xB00, METHOD_BUFFERED, FILE_ANY_ACCESS)

//#define IOCTL_SET_INT_CB   \
//            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xC00, METHOD_BUFFERED, FILE_ANY_ACCESS)
//#define IOCTL_EXEC_INT_CB   \
//            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xD00, METHOD_BUFFERED, FILE_ANY_ACCESS)

typedef struct _PCI_COMMAND
{
	UCHAR  BarNum;
	UCHAR  Type;
	USHORT Offset;
	ULONG  Value;//write only
} PCI_COMMAND;
