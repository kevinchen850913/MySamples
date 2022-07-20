// MFC繪製折線圖範例.h : MFC繪製折線圖範例 應用程式的主標頭檔
//
#pragma once

#ifndef __AFXWIN_H__
	#error "對 PCH 包含此檔案前先包含 'stdafx.h'"
#endif

#include "resource.h"       // 主要符號


// CMFC繪製折線圖範例App:
// 請參閱實作此類別的 MFC繪製折線圖範例.cpp
//

class CMFC繪製折線圖範例App : public CWinApp
{
public:
	CMFC繪製折線圖範例App();


// 覆寫
public:
	virtual BOOL InitInstance();

// 程式碼實作

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void On32771();

};

extern CMFC繪製折線圖範例App theApp;