#pragma once

#include "ChartCtrl\ChartCtrl.h"
// ChartCtrl ��ܤ��

class ChartCtrl : public CDialog
{
	DECLARE_DYNAMIC(ChartCtrl);

public:
	ChartCtrl(CWnd* pParent = NULL);   // �зǫغc�禡
	virtual ~ChartCtrl();

// ��ܤ�����
	enum { IDD = IDD_DIALOG1 };

	//{{AFX_DATA(CChartDemoDlg)
    //}}AFX_DATA
    CChartCtrl m_ChartCtrl;

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �䴩

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
};
