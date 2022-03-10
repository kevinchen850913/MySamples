using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//記得加入 System.IO
using System.IO;

namespace CSV_繪圖
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //strFileName 輸入檔案位置
            string strFileName = @"D:\\u2260_Project\\Excel繪圖\\spd_3.csv";
            var reader = new StreamReader(File.OpenRead(strFileName));
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                //把資料塞到chart1，可從values確認要哪行
                chart1.Series[0].Points.AddY(values[2]);
            }
            //開啟X軸縮放功能
            chart1.ChartAreas[0].CursorX.Interval = 0;
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            //點擊時還原X軸縮放狀態
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
        }
    }
}
