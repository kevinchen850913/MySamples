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
            string str = "�нT�{���x�w���T�[�]�A���ʧ@�����a���I�A�Y���ü{�ѦҨϥάy�{���C";
            DialogResult dr = MessageBox.Show(str, "�ϥΪ�ĵ�i�T�{", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                myState.Push("��l�ƥD��");
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

                #region �]�ƪ�l�ƪ��A�y�{
                case "��l�ƥD��":
                    MC.InitBoard();
                    myState.Push("�ݩR");
                    myState.Push("�}��Led");
                    myState.Push("���ݳs�u���\");
                    break;

                case "�}��Led":
                    LedEnable = true;
                    break;

                case "��l�Ʊq��":
                    MC.ServoInit();
                    if (!b_Home)
                    {
                        myState.Push("�T�{��l�Ƨ���");
                        myState.Push("��L�k���I");
                        myState.Push("�s���k���I");
                    }
                    else
                    {
                        myState.Push("�ݩR");
                    }
                    myState.Push("���ݨB�i�B�ʧ���");
                    myState.Push("���ݦ��A�B�ʧ���");
                    break;
               
                case "�T�{��l�Ƨ���":
                    if (MC.CheckIOSensor())
                    {
                        myState.Push("��L�k���I");

                    }
                    else
                    {
                        b_Homing = false;
                        if (b_Loop)
                        {
                            MC.ServoInit();
                            HighSpeed2 = 0;
                            myState.Push("�s���P��A");
                        }
                        else
                        {
                            b_Home = true;
                            myState.Push("�ݩR");
                        }
                    }
                    myState.Push("���ݫ��w�ɶ�");
                    break; 
                #endregion

                #region �B�ʪ��A�j��
                case "�s���P��A":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.ServoB))
                        {
                            myState.Push("�s���P��A");
                        }
                        else
                        {
                            MC.ServoGantryA();
                            myState.Push("��L�P��A");
                        }
                    }
                    break;

                case "��L�P��A":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.StepB))
                        {
                            myState.Push("��L�P��A");
                        }
                        else
                        {
                            MC.StepGantryA();
                            myState.Push("�s���P��B");
                        }
                    }
                    break;

                case "�s���P��B":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.ServoB))
                        {
                            myState.Push("�s���P��B");
                        }
                        else
                        {
                            MC.ServoGantryB();
                            myState.Push("��L�P��B");
                        }
                    }
                    break;

                case "��L�P��B":
                    if (b_Loop)
                    {
                        if (MC.CheckDriveEnd(MC.StepB))
                        {
                            myState.Push("��L�P��B");
                        }
                        else
                        {
                            MC.StepGantryB();
                            myState.Push("�s���P��A");
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

                #region �q����l�Ʀ^���I���A

                case "�s���k���I":
                    MC.ServoHoming();
                    myState.Push("�T�{�s���k���I");
                    myState.Push("�����s���k���I");
                    break;                 

                case "�T�{�s���k���I":
                    MC.Stop();
                    myState.Push("�s���P�ʪ�l��");
                    myState.Push("���ݦ��A�B�ʧ���");
                    break;

                case "�s���P�ʪ�l��":
                    MC.ServoGantryInit();
                    myState.Push("�T�{�s���P�ʪ�l��");
                    myState.Push("���ݦ��A�B�ʧ���");
                    break;

                case "�T�{�s���P�ʪ�l��":               
                    myState.Push("���ݦ��A�B�ʧ���");
                    break;

                case "��L�k���I":
                    MC.StepBInitPTP();
                    myState.Push("��L����");
                    myState.Push("���ݨB�i�B�ʧ���");
                    break;

                case "��L����":
                    MC.StepAPTP(-MC.StepLimitPos / 2 - 100);
                    myState.Push("��L�k���I���");
                    myState.Push("���ݨB�i�B�ʧ���");
                    break;

                case "��L�k���I���":
                    MC.StepHoming();
                    myState.Push("�T�{��L�k���I");
                    myState.Push("������L�P�������");
                    break;

                case "�T�{��L�k���I":
                    MC.StepHomingStop();
                    myState.Push("��L�k���I���v");
                    myState.Push("���ݨB�i�B�ʧ���");
                    break;

                case "��L�k���I���v":
                    MC.StepHomingOffset();
                    myState.Push("�T�{��L�k���I���v");
                    myState.Push("������L�P�������}���");
                    break;

                case "�T�{��L�k���I���v":
                    MC.StepHomingStopOffset();                 
                    myState.Push("���ݨB�i�B�ʧ���");
                    break;
                #endregion

                #region �@�ε��ݪ��A
                case "���ݳs�u���\":
                    if (!MC.LinkCheck())
                    {
                        myState.Push("���ݳs�u���\");
                        myState.Push("���ݫ��w�ɶ�");
                    }
                    break;

                case "���ݦ��A�B�ʧ���":
                    if (MC.CheckDriveEnd(MC.ServoA) || MC.CheckDriveEnd(MC.ServoB))
                    {
                        myState.Push("���ݦ��A�B�ʧ���");
                        myState.Push("���ݫ��w�ɶ�");
                    }
                    break;

                case "���ݨB�i�B�ʧ���":
                    if (MC.CheckDriveEnd(MC.StepA) || MC.CheckDriveEnd(MC.StepB))
                    {
                        myState.Push("���ݨB�i�B�ʧ���");
                        myState.Push("���ݫ��w�ɶ�");
                    }
                    break;

                case "�����s���k���I":
                    if (!MC.ServoHomingCheck())
                    {
                        myState.Push("�����s���k���I");
                    }
                    break;

                case "������L�P�������":
                    if (MC.CheckIOSensor())
                    {
                        if (MC.StepHomingCheck())
                        {
                            myState.Push("������L�P�������");
                        }
                        else
                        {
                            myState.Push("�����ʧ@");
                        }
                    }
                    break;

                case "������L�P�������}���":
                    if (!MC.CheckIOSensor())
                    {
                        if (MC.StepHomingCheck())
                        {
                            myState.Push("������L�P�������}���");
                        }
                        else
                        {
                            myState.Push("�����ʧ@");
                        }
                    }
                    break;

                case "���ݦ��A�P�ʪ�l�Ƨ���":
                    myState.Push("���ݦ��A�P�ʧ���");
                    break;

                case "���ݨB�i�P�ʪ�l�Ƨ���":
                    myState.Push("���ݨB�i�P�ʧ���");
                    break;

                case "���ݫ��w�ɶ�":
                    break; 
                #endregion

                #region �ҥ~�B�z���A
                
                case "�����ʧ@":
                    MC.Stop();
                    myState.Clear();
                    myState.Push("�ݩR");
                    break;

                case "�ݩR":
                    if (myState.Count == 0)
                    {
                        myState.Push("�ݩR");
                    }
                    break;

                default:
                    this.Close();
                    break; 
                #endregion
            }

            if (!MC.FreeGantry && MC.CheckIOSensor())
            {
                myState.Push("��l�Ʊq��");
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
                myState.Push("�T�{��l�Ƨ���");
                if (!b_Home)
                {
                    myState.Push("��l�Ʊq��");
                }
            }
            
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            if (!b_Homing)
            {
                b_Loop = false;
                b_Homing = true;
                myState.Push("��l�Ʊq��");
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            b_Home = false;
            b_Homing = false;
            b_Loop = false;
            myState.Push("�����ʧ@");
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