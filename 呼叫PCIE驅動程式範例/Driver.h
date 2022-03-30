#pragma once

#include "windows.h"

HANDLE CreateHandle(WORD vid, WORD did);
void WDC_ReadAddr32(HANDLE hDevice, DWORD dwAddrSpace, DWORD dwOffset, UINT32 *val);
void WDC_WriteAddr32(HANDLE hDevice, DWORD dwAddrSpace, DWORD dwOffset, UINT32 val);