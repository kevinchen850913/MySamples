// hartCtrl.cpp : 實作檔
//

#include "stdafx.h"
#include "MFC繪製折線圖範例.h"
#include "hartCtrl.h"
#include "ChartCtrl\ChartLineSerie.h"

// ChartCtrl 對話方塊

IMPLEMENT_DYNAMIC(ChartCtrl, CDialog)

ChartCtrl::ChartCtrl(CWnd* pParent /*=NULL*/)
	: CDialog(ChartCtrl::IDD, pParent)
{
}

ChartCtrl::~ChartCtrl()
{
}

void ChartCtrl::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX,IDC_ChartCtrl1,m_ChartCtrl);

  CChartStandardAxis* pBottomAxis =
    m_ChartCtrl.CreateStandardAxis(CChartCtrl::BottomAxis);
  pBottomAxis->SetMinMax(0, 10);
  CChartStandardAxis* pLeftAxis =
    m_ChartCtrl.CreateStandardAxis(CChartCtrl::LeftAxis);
  pLeftAxis->SetMinMax(0, 10);

  pBottomAxis->SetTickIncrement(false, 1.0);
  pBottomAxis->SetDiscrete(true);
  CChartLineSerie* pSeries = m_ChartCtrl.CreateLineSerie();
  double XVal[20];
  double YVal[20];
  for (int i=0; i<20; i++)
  {
    XVal[i] = YVal[i] = i/2.0;
  }
  pSeries->SetPoints(XVal,YVal,20);

}


BEGIN_MESSAGE_MAP(ChartCtrl, CDialog)
	ON_BN_CLICKED(IDOK, &ChartCtrl::OnBnClickedOk)
END_MESSAGE_MAP()

//Convert CString to double
static BOOL _AtlSimpleFloatParse(LPCTSTR lpszText, double& d)  
{  
    ATLASSERT(lpszText != NULL);  
    while (*lpszText == ' '|| *lpszText == '/t') 
    {
        lpszText++;  
    }

    TCHAR chFirst = lpszText[0];  
    d = _tcstod(lpszText,(LPTSTR*)&lpszText);  
    if (d == 0.0 && chFirst != '0') 
    {
        return FALSE;    //could not convert  
    }
    while (*lpszText == ' '|| *lpszText == '/t')
    {
        lpszText++;  
    }

    if (*lpszText != '/0') 
    {
        return FALSE;    //not terminated properly  
    }

    return TRUE;  
}

// ChartCtrl 訊息處理常式

void ChartCtrl::OnBnClickedOk()
{
	// TODO: 在此加入控制項告知處理常式程式碼
    CStdioFile file;
	file.Open(_T("files.csv"),CFile::modeRead);
	CString str;
	file.ReadString(str);
	
    CChartLineSerie* pSeries1 = m_ChartCtrl.CreateLineSerie();
	CChartLineSerie* pSeries2 = m_ChartCtrl.CreateLineSerie();
	CChartLineSerie* pSeries3 = m_ChartCtrl.CreateLineSerie();
	CChartLineSerie* pSeries4 = m_ChartCtrl.CreateLineSerie();
    double XVal[10000];
    double Y1Val[10000];
	double Y2Val[10000];
	double Y3Val[10000];
	double Y4Val[10000];
    
	int i = 0; 
	while(file.ReadString(str) && i<10000)
	{		
		str = str.Trim(_T(" "));
		int index = str.Find(_T(","));

		_AtlSimpleFloatParse(str.Left(index),XVal[i]);
		str=str.Right(str.GetLength()-index-1);
		index = str.Find(_T(","));
			
		_AtlSimpleFloatParse(str.Left(index),Y1Val[i]);
		str=str.Right(str.GetLength()-index-1);
		index = str.Find(_T(","));
			
		_AtlSimpleFloatParse(str.Left(index),Y2Val[i]);
		str=str.Right(str.GetLength()-index-1);
		index = str.Find(_T(","));
		
		_AtlSimpleFloatParse(str.Left(index),Y3Val[i]);
		str=str.Right(str.GetLength()-index-1);
		index = str.Find(_T(","));

		_AtlSimpleFloatParse(str.Left(index),Y4Val[i]);
		str.Left(index);
		i++;
	}
	//pSeries->SetPoints(XVal,XVal,100);
	pSeries1->SetPoints(XVal,Y1Val,i);
	pSeries2->SetPoints(XVal,Y2Val,i);
	pSeries3->SetPoints(XVal,Y3Val,i);
	pSeries4->SetPoints(XVal,Y4Val,i);
	file.Close();
}
