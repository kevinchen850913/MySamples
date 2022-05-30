using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MCT8132P_Gantry
{
    public partial class Form1 : Form
    {
        MotionModel MC = new MotionModel();
        Stack<string> myState = new Stack<string>();
        IOModel LM = new IOModel();
        bool LedEnable = false;

        bool b_Home = false;
        bool b_Homing = false;
        bool b_Loop = false;

        int HighSpeed2 = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "請確認機台已正確架設，此動作有毀壞風險，若有疑慮參考使用流程文件。";
            DialogResult dr = MessageBox.Show(str, "使用者警告確認", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                myState.Push("初始化主站");
                timer1.Enabled = true;
            }
            else
            {
                this.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MC.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusManager();
        }

        private void StatusManager()
        {
            timer1.Enabled = false;
            switch (myState.Pop())
            {

                #region 設備初始化狀態流程
                case "初始化主站":
                    MC.InitBoard();
                    myState.Push("待命");
                    myState.Push("開啟Led");
                    myState.Push("等待連線成功");
                    break;

                case "開啟Led":
                    LedEnable = true;
                    break;

                case "初始化從站":
                    MC.ServoInit();
                    if (!b_Home)
                    {
                        myState.Push("確認初始化完成");
                        myState.Push("轉盤歸原點");
                        myState.Push("龍門歸原點");
                    }
                    else
                    {
                        myState.Push("待命");
                    }
                    myState.Push("等待步進運動完成");
                    myState.Push("等待伺服運動完成");
                    break;
               
                case "確認初始化完成":
                    if (MC.CheckIOSensor())
                    {
                        myState.Push("轉盤歸原點");

                    }
                    else
                    {
                        b_Homing = false;
                        if (b_Loop)
                        {
                            MC.ServoInit();
                            HighSpeed2 = 0;
                            myState.Push("龍門同動A");
                        }
                        else
                        {
                            b_Home = true;
                            myState.Push("待命");
                        }
                    }
                    myState.Push("等待指定時間");
                    break; 
                #endregion

                #region 運動狀態迴圈
                case "龍門同動A":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.ServoB))
                        {
                            myState.Push("龍門同動A");
                        }
                        else
                        {
                            MC.ServoGantryA();
                            myState.Push("圓盤同動A");
                        }
                    }
                    break;

                case "圓盤同動A":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.StepB))
                        {
                            myState.Push("圓盤同動A");
                        }
                        else
                        {
                            MC.StepGantryA();
                            myState.Push("龍門同動B");
                        }
                    }
                    break;

                case "龍門同動B":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.ServoB))
                        {
                            myState.Push("龍門同動B");
                        }
                        else
                        {
                            MC.ServoGantryB();
                            myState.Push("圓盤同動B");
                        }
                    }
                    break;

                case "圓盤同動B":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.StepB))
                        {
                            myState.Push("圓盤同動B");
                        }
                        else
                        {
                            MC.StepGantryB();
                            myState.Push("龍門同動A");
                            if (HighSpeed2 > 9)
                            {
                                HighSpeed2 = 0;
                            }
                            else if (HighSpeed2 > 4)
                            {
                                MC.SetHighSpeed2();
                            }
                            else
                            {
                                MC.SetHighSpeed();
                            }
                            HighSpeed2++;
                        }
                    }
                    break; 
                #endregion

                #region 從站初始化回原點狀態

                case "龍門歸原點":
                    MC.ServoHoming();
                    myState.Push("確認龍門歸原點");
                    myState.Push("等待龍門歸原點");
                    break;                 

                case "確認龍門歸原點":
                    MC.Stop();
                    myState.Push("龍門同動初始化");
                    myState.Push("等待伺服運動完成");
                    break;

                case "龍門同動初始化":
                    MC.ServoGantryInit();
                    myState.Push("確認龍門同動初始化");
                    myState.Push("等待伺服運動完成");
                    break;

                case "確認龍門同動初始化":               
                    myState.Push("等待伺服運動完成");
                    break;

                case "轉盤歸原點":
                    MC.StepBInitPTP();
                    myState.Push("轉盤反轉");
                    myState.Push("等待步進運動完成");
                    break;

                case "轉盤反轉":
                    MC.StepAPTP(-MC.StepLimitPos / 2 - 100);
                    myState.Push("轉盤歸原點對齊");
                    myState.Push("等待步進運動完成");
                    break;

                case "轉盤歸原點對齊":
                    MC.StepHoming();
                    myState.Push("確認轉盤歸原點");
                    myState.Push("等待轉盤感測器對齊");
                    break;

                case "確認轉盤歸原點":
                    MC.StepHomingStop();
                    myState.Push("轉盤歸原點補償");
                    myState.Push("等待步進運動完成");
                    break;

                case "轉盤歸原點補償":
                    MC.StepHomingOffset();
                    myState.Push("確認轉盤歸原點補償");
                    myState.Push("等待轉盤感測器離開對齊");
                    break;

                case "確認轉盤歸原點補償":
                    MC.StepHomingStopOffset();                 
                    myState.Push("等待步進運動完成");
                    break;
                #endregion

                #region 共用等待狀態
                case "等待連線成功":
                    if (!MC.LinkCheck())
                    {
                        myState.Push("等待連線成功");
                        myState.Push("等待指定時間");
                    }
                    break;

                case "等待伺服運動完成":
                    if (MC.CheckDriveEnd(MC.ServoA) || MC.CheckDriveEnd(MC.ServoB))
                    {
                        myState.Push("等待伺服運動完成");
                        myState.Push("等待指定時間");
                    }
                    break;

                case "等待步進運動完成":
                    if (MC.CheckDriveEnd(MC.StepA) || MC.CheckDriveEnd(MC.StepB))
                    {
                        myState.Push("等待步進運動完成");
                        myState.Push("等待指定時間");
                    }
                    break;

                case "等待龍門歸原點":
                    if (!MC.ServoHomingCheck())
                    {
                        myState.Push("等待龍門歸原點");
                    }
                    break;

                case "等待轉盤感測器對齊":
                    if (MC.CheckIOSensor())
                    {
                        if (MC.StepHomingCheck())
                        {
                            myState.Push("等待轉盤感測器對齊");
                        }
                        else
                        {
                            myState.Push("結束動作");
                        }
                    }
                    break;

                case "等待轉盤感測器離開對齊":
                    if (!MC.CheckIOSensor())
                    {
                        if (MC.StepHomingCheck())
                        {
                            myState.Push("等待轉盤感測器離開對齊");
                        }
                        else
                        {
                            myState.Push("結束動作");
                        }
                    }
                    break;

                case "等待伺服同動初始化完成":
                    myState.Push("等待伺服同動完成");
                    break;

                case "等待步進同動初始化完成":
                    myState.Push("等待步進同動完成");
                    break;

                case "等待指定時間":
                    break; 
                #endregion

                #region 例外處理狀態
                
                case "結束動作":
                    MC.Stop();
                    myState.Clear();
                    myState.Push("待命");
                    break;

                case "待命":
                    if (myState.Count == 0)
                    {
                        myState.Push("待命");
                    }
                    break;

                default:
                    this.Close();
                    break; 
                #endregion
            }

            if (!MC.FreeGantry && MC.CheckIOSensor())
            {
                myState.Push("初始化從站");
            }

            if (LedEnable)
            {
                LM.Run();
            }
            timer1.Enabled = true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!b_Loop && !b_Homing)
            {
                b_Loop = true;
                b_Homing = true;
                myState.Push("確認初始化完成");
                if (!b_Home)
                {
                    myState.Push("初始化從站");
                }
            }
            
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            if (!b_Homing)
            {
                b_Loop = false;
                b_Homing = true;
                myState.Push("初始化從站");
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            b_Home = false;
            b_Homing = false;
            b_Loop = false;
            myState.Push("結束動作");
        }

        private void btn_Start_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btn_Start_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btn_Home_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btn_Home_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btn_Stop_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btn_Stop_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}