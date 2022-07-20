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
END_MESSAGE_MAP()


// ChartCtrl 訊息處理常式
