#pragma once

#include "ChartCtrl\ChartCtrl.h"
// ChartCtrl 對話方塊

class ChartCtrl : public CDialog
{
	DECLARE_DYNAMIC(ChartCtrl);

public:
	ChartCtrl(CWnd* pParent = NULL);   // 標準建構函式
	virtual ~ChartCtrl();

// 對話方塊資料
	enum { IDD = IDD_DIALOG1 };

	//{{AFX_DATA(CChartDemoDlg)
    //}}AFX_DATA
    CChartCtrl m_ChartCtrl;
	CChartLineSerie* pSeries1;
	CChartLineSerie* pSeries2;
	CChartLineSerie* pSeries3;
	CChartLineSerie* pSeries4;

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支援

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
};
