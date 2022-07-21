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
  CChartStandardAxis* pLeftAxis =
  m_ChartCtrl.CreateStandardAxis(CChartCtrl::LeftAxis);

  pBottomAxis->SetAutomaticMode(CChartAxis::FullAutomatic);
  pLeftAxis->SetAutomaticMode(CChartAxis::FullAutomatic);

  CChartGrid* pChartGrid = pBottomAxis->GetGrid();
  pChartGrid -> SetVisible(false);

  pSeries1 = m_ChartCtrl.CreateLineSerie();
  pSeries2 = m_ChartCtrl.CreateLineSerie();
  pSeries3 = m_ChartCtrl.CreateLineSerie();
  pSeries4 = m_ChartCtrl.CreateLineSerie();
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
	CString str;
	int index;
	double XVal[4000];
    double Y1Val[4000];
	double Y2Val[4000];
	double Y3Val[4000];
	double Y4Val[4000];

	file.Open(_T("files.csv"),CFile::modeRead);
	file.ReadString(str);
	pSeries1->ClearSerie();
	pSeries2->ClearSerie();
	pSeries3->ClearSerie();
	pSeries4->ClearSerie();
    
	int i = 0; 
	while(file.ReadString(str) && i<4000)
	{		
		str = str.Trim(_T(" "));
		index = str.Find(_T(","));

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

		_AtlSimpleFloatParse(str,Y4Val[i]);
		i++;
	}
	pSeries1->SetPoints(XVal,Y1Val,i);
	pSeries2->SetPoints(XVal,Y2Val,i);
	pSeries3->SetPoints(XVal,Y3Val,i);
	pSeries4->SetPoints(XVal,Y4Val,i);
	file.Close();
}
