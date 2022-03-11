using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using SOEM;

namespace MCT2132_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 32; i++)
            {
                Control[] p = this.Controls.Find("pictureBox" + i.ToString(), true);
                p[0].BackColor = Color.Gray;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {            
            timer1.Enabled = !timer1.Enabled;
            timer1.Interval = 1000;
            seq = "INIT";
        }

        EthCATDevice slave;
        private void btn_Interface_Click(object sender, EventArgs e)
        {
            List<Tuple<String, String, String>> interfaces = GetAvailableInterfaces();

            var Input =
                  new GenericInputBox<ComboBox>("Local Interface", "Interfaces",
                       (o) =>
                       {
                           foreach (Tuple<String, String, String> it in interfaces)
                               o.Items.Add(it.Item1);

                           o.Text = o.Items[0].ToString();
                       }, 1.7);

            DialogResult res = Input.ShowDialog();

            if (res != DialogResult.OK) return;
            String userinput = Input.genericInput.Text;

            Cursor Memcurs = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            Trace.WriteLine("Openning interface " + userinput);
            Application.DoEvents();

            foreach (Tuple<String, String, String> it in interfaces)
            {
                if (it.Item1 == userinput)
                {
                    String PcapInterfaceName = "\\Device\\NPF_" + it.Item3;
                    int NbSlaves = SoemInterrop.StartActivity(PcapInterfaceName, Properties.Settings.Default.DelayUpMs);

                    if (NbSlaves > 0)
                    {
                        slave = new EthCATDevice(1);
                        textBox_Type.Text = slave.TypeId;
                        if (tmrRefreshState.Interval >= 1000)
                            tmrRefreshState.Enabled = true;

                        SoemInterrop.Run();

                        tmrStart.Enabled = true;
                        tmrInputFlow.Enabled = true;
                    }
                    else
                       Trace.WriteLine("No slave behind this Interface");
                }
            }
            btn_Start.Enabled = true;
            this.Cursor = Memcurs;
        }
        string seq;
        bool b_Output;
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (seq)
            {
                case "INIT":
                    b_Output = true;
                    switch (textBox_Type.Text)
                    {
                        case "0x00021322":
                            textBox_Type.Text = "MCT-2132I";
                            break;

                        case "0x00021323":
                            textBox_Type.Text = "MCT-2132O";
                            break;

                        case "0x00021321":
                            textBox_Type.Text = "MCT-2132B";
                            break;

                        default:
                            textBox_Type.Text = "FINAL";
                            textBox_Message.Text = "Failed to check Type(" + textBox_Type.Text + ")";
                            break;
                    }
                    seq = textBox_Type.Text;
                    break;

                case "MCT-2132B":
                    
                    if(b_Output)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            slave.OutputData[i] = 0;
                            slave.WriteOutput();
                        }
                        for (int j = 17; j <= 32; j++)
                        {
                            Control[] p = this.Controls.Find("pictureBox" + j.ToString(), true);
                            p[0].BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            slave.OutputData[i] = 255;
                            slave.WriteOutput();
                        }
                        for (int j = 17; j <= 32; j++)
                        {
                            Control[] p = this.Controls.Find("pictureBox" + j.ToString(), true);
                            p[0].BackColor = Color.Green;
                        }
                    }

                    slave.ReadInput();
                    for (int i = 1; i <= 16; i++)
                    {
                        Control[] p = this.Controls.Find("pictureBox" + i.ToString(), true);
                        p[0].BackColor = (slave.InputData[(i - 1) / 8] >> (i % 8) - 1) % 2 == 1 ? Color.Green : Color.Gray;
                    }

                    b_Output =! b_Output;
                    break;

                case "MCT-2132I":
                    slave.ReadInput();
                    for (int i = 1; i <= 32; i++)
                    {
                        Control[] p = this.Controls.Find("pictureBox" + i.ToString(), true);
                        p[0].BackColor = (slave.InputData[(i - 1) / 8] >> (i % 8) - 1) % 2 == 1 ? Color.Green : Color.Gray;
                    }
                    break;

                case "MCT-2132O":
                    if (b_Output)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            slave.OutputData[i] = 0;
                            slave.WriteOutput();
                        }
                        for (int j = 1; j <= 32; j++)
                        {
                            Control[] p = this.Controls.Find("pictureBox" + j.ToString(), true);
                            p[0].BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            slave.OutputData[i] = 255;
                            slave.WriteOutput();
                        }
                        for (int j = 1; j <= 32; j++)
                        {
                            Control[] p = this.Controls.Find("pictureBox" + j.ToString(), true);
                            p[0].BackColor = Color.Green;
                        }
                    }
                    b_Output = !b_Output;
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public static List<Tuple<String, String, String>> GetAvailableInterfaces()
        {
            List<Tuple<String, String, String>> ips = new List<Tuple<String, String, String>>();
            System.Net.NetworkInformation.NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (System.Net.NetworkInformation.NetworkInterface inf in interfaces)
            {
                if (!inf.IsReceiveOnly && inf.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && inf.SupportsMulticast && inf.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                {
                    ips.Add(new Tuple<string, string, string>(inf.Description, inf.Name, inf.Id));
                }
            }
            return ips;
        }

        private void tmrRefreshState_Tick(object sender, EventArgs e)
        {
            tmrStart.Enabled = false;
        }

        private void tmrStart_Tick(object sender, EventArgs e)
        {
        }

        private void tmrInputFlow_Tick(object sender, EventArgs e)
        {
            EthCATDevice slave = new EthCATDevice(1);
            slave.ReadInput();
        }
    }
}