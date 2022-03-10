// IT8888_DRV_test.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//
#include "stdafx.h"
#include "Driver.h"

int main()
{
	UINT32 value;
	HANDLE hDevice;

	hDevice = CreateHandle(0x1283, 0x8888);

	if (INVALID_HANDLE_VALUE == hDevice)
	{
		printf("Create driver handle error!\n");
	}
	else
	{
		WDC_PciReadCfg(hDevice, 0, &value);
		printf("0x%08x\n", value);
		WDC_PciWriteCfg(hDevice, 0x58, 0xa600c000);
		WDC_PciReadCfg(hDevice, 0x58, &value);
		printf("0x%08x\n", value);
		WDC_ReadAddr32(hDevice, 0xd000, &value);
		printf("0x%08x\n", value);

		CloseHandle(hDevice);
	}
	return 0;
}
