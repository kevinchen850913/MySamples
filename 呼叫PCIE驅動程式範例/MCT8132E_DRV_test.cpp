// MCT8132E_DRV_test.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include "stdafx.h"
#include "Driver.h"

int main()
{
	UINT32 value;
	HANDLE hDevice;

	hDevice = CreateHandle(0x10EE, 0x7011);

	if (INVALID_HANDLE_VALUE == hDevice)
	{
		printf("Create driver handle error!\n");
		system("pause");
	}
	else
	{
		WDC_WriteAddr32(hDevice, 0, 0, 0x0);

		WDC_ReadAddr32(hDevice, 0, 0, &value);
		printf("0x%08x\n", value);

		WDC_WriteAddr32(hDevice, 0, 0, 0x5555);

		WDC_ReadAddr32(hDevice, 0, 0, &value);
		printf("0x%08x\n", value);

		WDC_WriteAddr32(hDevice, 0, 0, 0xaaaa);

		WDC_ReadAddr32(hDevice, 0, 0, &value);
		printf("0x%08x\n", value);

		WDC_WriteAddr32(hDevice, 0, 0, 0xffff);

		WDC_ReadAddr32(hDevice, 0, 0, &value);
		printf("0x%08x\n", value);
		CloseHandle(hDevice);
		system("pause");
	}
}
