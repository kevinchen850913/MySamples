// MFCø�s��u�Ͻd��.h : MFCø�s��u�Ͻd�� ���ε{�����D���Y��
//
#pragma once

#ifndef __AFXWIN_H__
	#error "�� PCH �]�t���ɮ׫e���]�t 'stdafx.h'"
#endif

#include "resource.h"       // �D�n�Ÿ�


// CMFCø�s��u�Ͻd��App:
// �аѾ\��@�����O�� MFCø�s��u�Ͻd��.cpp
//

class CMFCø�s��u�Ͻd��App : public CWinApp
{
public:
	CMFCø�s��u�Ͻd��App();


// �мg
public:
	virtual BOOL InitInstance();

// �{���X��@

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void On32771();

};

extern CMFCø�s��u�Ͻd��App theApp;