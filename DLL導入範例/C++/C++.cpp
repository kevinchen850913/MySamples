// C++.cpp : 定義主控台應用程式的進入點。
//

#include "stdafx.h"
#include "windows.h"
#include "MCT81XX.h"


int _tmain(int argc, _TCHAR* argv[])
{
	MCT81XX_Open(0);
	return 0;
}

