// MCT81XX_DLL_dynaLoad.cpp : 定義主控台應用程式的進入點。
//

#include "stdafx.h"
typedef short(*voidFun)(short BoardNo);
typedef short(*voidFun2)(short BoardNo, short UnitNo);

int _tmain(int argc, _TCHAR* argv[])
{
	HMODULE hModule = LoadLibrary(_T("MCT81XX.dll"));
//	HMODULE hModule = LoadLibrary(_T("wdapi1040.dll"));

	if(!hModule)
	{
		_tprintf(_T("LoadLibray error!\n"));
		return -1;
	}
	FARPROC fp = GetProcAddress(hModule, "MCT81XX_Open");
//	FARPROC fp = GetProcAddress(hModule, "WDC_Version");
	voidFun MCT81XX_Open = (short(*)(short BoardNo))fp;
	MCT81XX_Open(0);

	fp = GetProcAddress(hModule, "MCT81XX_ServoOn");
	voidFun2 MCT81XX_ServoOn = (short(*)(short BoardNo, short UnitNo))fp;
	MCT81XX_ServoOn(0,1);

	if(!fp)
	{
		DWORD err = GetLastError();
		_tprintf(_T("%x\n"), err);
	}

	FreeLibrary(hModule);

	return 0;
}

