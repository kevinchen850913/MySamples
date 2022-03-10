#pragma once

#include "windows.h"

HANDLE CreateHandle(WORD vid, WORD did);
void WDC_PciReadCfg(HANDLE hDevice, DWORD offset, UINT32 *value);
void WDC_PciWriteCfg(HANDLE hDevice, DWORD offset, UINT32 value);
void WDC_ReadAddr32(HANDLE hDevice, DWORD offset, UINT32 *value);
void WDC_WriteAddr32(HANDLE hDevice, DWORD offset, UINT32 value);
