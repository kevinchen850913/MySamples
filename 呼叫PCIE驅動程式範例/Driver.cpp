#include "stdafx.h"
#include "Public.h"
#include "Driver.h"

typedef union {
	struct {
		unsigned long	regIndexNumber : 8;
		unsigned long	functionNumber : 3;
		unsigned long	deviceNumber : 5;
		unsigned long	busNumber : 8;
		unsigned long : 7;
		unsigned long	enableConfigSpaceMapping : 1;
	} bit;
	unsigned long dword;
} INDEX_PORT;

void IndexPort_init(INDEX_PORT *indexPort)
{
	memset(indexPort, 0, sizeof(INDEX_PORT));
	indexPort->bit.enableConfigSpaceMapping = 1;
	indexPort->bit.busNumber = 7;
	indexPort->bit.deviceNumber = 0;
	indexPort->bit.functionNumber = 0;
}

class TraitMemory {
public:
	typedef void* T;
	static void Free(void *buf)
	{
		free(buf);
	}
};

class TraitDeviceInfoList {
public:
	typedef HDEVINFO T;
	static void Free(HDEVINFO hDevInfo)
	{
		SetupDiDestroyDeviceInfoList(hDevInfo);
	}
};

template<class Trait> class AutoFree {
public:
	AutoFree(typename Trait::T handle)
	{
		this->handle = handle;
	}
	~AutoFree()
	{
		if (handle)
		{
			Trait::Free(handle);
		}
	}
private:
	typename Trait::T handle;
};

template<bool> class StaticAssert;
template<> class StaticAssert<true>{};

void InpDword(HANDLE hDevice, DWORD offset, UINT32 *value)
{
	BOOL		status;
	DWORD		byteReceived;
	PCI_COMMAND	iorCmd = { 1, 2,0,0};
	DWORD		ret;

	status = DeviceIoControl(
		hDevice,
		IOCTL_READ,
		&iorCmd,
		sizeof(iorCmd),
		&ret,
		sizeof(ret),
		&byteReceived,
		NULL
	);
	*value = ret;
}

void OutpDword(HANDLE hDevice, DWORD offset, DWORD value)
{
	BOOL		status;
	DWORD		byteReceived;
	PCI_COMMAND	iorCmd = { 1, 2,0,value };
}

HANDLE CreateHandle(WORD vid, WORD did)
{
	HDEVINFO hDevInfo = INVALID_HANDLE_VALUE;

	hDevInfo = SetupDiGetClassDevs(&GUID_DEVICE_INTERFACE, NULL, NULL, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
	if (hDevInfo == INVALID_HANDLE_VALUE)
	{
		printf("SetupDiGetClassDevs error!\n");
		return (FALSE);
	}
	AutoFree<TraitDeviceInfoList> afd(hDevInfo);

	SP_DEVICE_INTERFACE_DATA deviceInterfaceData;

	deviceInterfaceData.cbSize = sizeof(deviceInterfaceData);

	for (unsigned int idx = 0; SetupDiEnumDeviceInterfaces(hDevInfo, NULL, &GUID_DEVICE_INTERFACE, idx, &deviceInterfaceData); ++idx)
	{
		DWORD	dwSize;
		BOOL	nStatus = SetupDiGetDeviceInterfaceDetail(hDevInfo, &deviceInterfaceData, NULL, 0, &dwSize, NULL);
		if (0 == dwSize)
		{
			printf("SetupDiGetDeviceInterfaceDetail error!\n");
			break;
		}

		PSP_DEVICE_INTERFACE_DETAIL_DATA pDeviceInterfaceDetail = (PSP_DEVICE_INTERFACE_DETAIL_DATA)malloc(dwSize);
		if (!pDeviceInterfaceDetail)
		{
			break;
		}
		AutoFree<TraitMemory> afm(pDeviceInterfaceDetail);

		ZeroMemory(pDeviceInterfaceDetail, sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA));

		pDeviceInterfaceDetail->cbSize = sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA);

		SP_DEVINFO_DATA	deviceInfoData = { sizeof(SP_DEVINFO_DATA) };

		nStatus = SetupDiGetDeviceInterfaceDetail(hDevInfo, &deviceInterfaceData, pDeviceInterfaceDetail, dwSize, &dwSize, &deviceInfoData);

		if (!nStatus)
		{
			printf("SetupDiGetDeviceInterfaceDetail error!\n");
			break;
		}

		TCHAR hwid[32];

		_stprintf_s(hwid, _T("ven_%04x&dev_%04x"), vid, did);
		if (NULL != _tcsstr(pDeviceInterfaceDetail->DevicePath, hwid))
		{
			HANDLE hDevice = CreateFile(
				pDeviceInterfaceDetail->DevicePath,
				GENERIC_READ | GENERIC_WRITE,
				FILE_SHARE_READ | FILE_SHARE_WRITE,
				NULL,
				OPEN_EXISTING,
				FILE_ATTRIBUTE_NORMAL,
				NULL
			);
			if (hDevice == INVALID_HANDLE_VALUE)
			{
				printf("Open driver error!\n");
				break;
			}
			return hDevice;
		}
	}
	return INVALID_HANDLE_VALUE;
}

void WDC_ReadAddr32(HANDLE hDevice, DWORD dwAddrSpace, DWORD dwOffset, UINT32 *val)
{
	BOOL status = TRUE;
	DWORD bytesReceived = 0;
	PCI_COMMAND inBuffer = { (BYTE)dwAddrSpace, 4, (WORD)dwOffset, 0 };
	DWORD outBuffer = 0;

	status = DeviceIoControl(hDevice,
		IOCTL_READ,
		&inBuffer,
		sizeof(DWORD),
		&outBuffer,
		sizeof(outBuffer),
		&bytesReceived,
		NULL);

	*val = outBuffer;
}

void WDC_WriteAddr32(HANDLE hDevice, DWORD dwAddrSpace, DWORD dwOffset, UINT32 val)
{
	BOOL status = TRUE;
	DWORD bytesReceived = 0;
	PCI_COMMAND inBuffer = { (BYTE)dwAddrSpace, 4, (WORD)dwOffset, val };

	status = DeviceIoControl(hDevice,
		IOCTL_WRITE,
		&inBuffer,
		sizeof(DWORD) * 2,
		NULL,
		0,
		&bytesReceived,
		NULL);
}
