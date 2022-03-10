/*++

Module Name:

    public.h

Abstract:

    This module contains the common declarations shared by driver
    and user applications.

Environment:

    user and kernel

--*/

//
// Define an Interface Guid so that apps can find the device and talk to it.
//

DEFINE_GUID (GUID_DEVICE_INTERFACE,
    0x8e88966e,0x873f,0x412a,0x93,0x90,0x50,0xe3,0x40,0x8c,0x36,0x30);
// {8e88966e-873f-412a-9390-50e3408c3630}

#define IOCTL_READ   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xA00, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define IOCTL_WRITE   \
            CTL_CODE(FILE_DEVICE_UNKNOWN, 0xB00, METHOD_BUFFERED, FILE_ANY_ACCESS)

typedef struct
{
	UINT32	type;
	UINT32	offset;
} IOR_COMMAND;

typedef struct
{
	IOR_COMMAND	cmd;
	union
	{
		UINT32	dword;
		UINT16	word[2];
		UINT8	byte[4];
	} value;
} IOW_COMMAND;
