// MFCø�s��u�Ͻd��.cpp : �w�q���ε{�������O�欰�C
//

#include "stdafx.h"
#include "MFCø�s��u�Ͻd��.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCø�s��u�Ͻd��App

BEGIN_MESSAGE_MAP(CMFCø�s��u�Ͻd��App, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, &CMFCø�s��u�Ͻd��App::OnAppAbout)
	ON_COMMAND(ID_32771, &CMFCø�s��u�Ͻd��App::On32771)
END_MESSAGE_MAP()


// CMFCø�s��u�Ͻd��App �غc

CMFCø�s��u�Ͻd��App::CMFCø�s��u�Ͻd��App()
{
	// TODO: �b���[�J�غc�{���X�A
	// �N�Ҧ����n����l�]�w�[�J InitInstance ��
}


// �Ȧ����@�� CMFCø�s��u�Ͻd��App ����

CMFCø�s��u�Ͻd��App theApp;


// CMFCø�s��u�Ͻd��App ��l�]�w

BOOL CMFCø�s��u�Ͻd��App::InitInstance()
{
	CWinApp::InitInstance();

	// �зǪ�l�]�w
	// �p�G�z���ϥγo�ǥ\��åB�Q���
	// �̫᧹�����i�����ɤj�p�A�z�i�H
	// �q�U�C�{���X�������ݭn����l�Ʊ`���A
	// �ܧ��x�s�]�w�Ȫ��n�����X
	// TODO: �z���ӾA�׭ק惡�r��
	// (�Ҧp�A���q�W�٩β�´�W��)
	SetRegistryKey(_T("���� AppWizard �Ҳ��ͪ����ε{��"));
	// �Y�n�إߥD�����A���{���X�إ߷s���ج[��������A�B�N��]�w��
	// ���ε{�����D��������
	CMainFrame* pFrame = new CMainFrame;
	if (!pFrame)
		return FALSE;
	m_pMainWnd = pFrame;
	// �ϥΨ�귽�إߨø��J�ج[
	pFrame->LoadFrame(IDR_MAINFRAME,
		WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, NULL,
		NULL);






	// �Ȫ�l�Ƥ@�ӵ����A�ҥH��ܨç�s�ӵ���
	pFrame->ShowWindow(SW_SHOW);
	pFrame->UpdateWindow();
	// �u���b SDI ���ε{��������m�r���ɡA�~�I�s DragAcceptFiles
	// �o�|�o�ͩ� ProcessShellCommand ����
	return TRUE;
}


// CMFCø�s��u�Ͻd��App �T���B�z�`��




// �� App About �ϥ� CAboutDlg ��ܤ��

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// ��ܤ�����
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �䴩

// �{���X��@
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()

// �����ܤ�������ε{���R�O
void CMFCø�s��u�Ͻd��App::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}


// CMFCø�s��u�Ͻd��App �T���B�z�`��


void CMFCø�s��u�Ͻd��App::On32771()
{

}
