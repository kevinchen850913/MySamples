using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 感測器資料庫
{
    public partial class Form1 : Form
    {
        public Form1()
        {
                InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (true)//PingTest() && System.IO.File.Exists(@"\\192.168.1.250\fae課\FAE資料庫更新管理\感測器資料庫\Database1.mdf"))
            {
                string str =
                "SELECT * " +
                "FROM 單一型號對應表";
                Update_dataGridView(str);
                comboBox1.Items.Add("");
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (dr.Cells[0].Value != null && !comboBox1.Items.Contains(dr.Cells[0].Value.ToString()))
                    {
                        comboBox1.Items.Add(dr.Cells[0].Value.ToString());
                        comboBox4.Items.Add(dr.Cells[0].Value.ToString());
                    }
                }
                comboBox1.Items.Remove("");
            }
            else 
            {
                MessageBox.Show("資料庫不存在");
                this.Close();              
            }           
        }

        public bool PingTest()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.250"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Update_dataGridView(string str)
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(str, db);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                        if (dataGridViewFill)
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        else
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }                       
                    }                  
            }
        }

        List<string> myList = new List<string>();
        private bool plist(string str)
        {
            myList.Clear();
            switch (str)
            {
                case "光纖感測器":
                    myList.Add("FT/FD/FR");
                    myList.Add ("FX-500");
                    myList.Add ("FX-550");
                    myList.Add ("FX-100");
                    myList.Add ("FX-300");
                    myList.Add ("FX-410");
                    myList.Add ("FX-311");
                    myList.Add ("FX-301");
                    break;
                case "雷射感測器":
                    myList.Add ("EX-L200");
                    myList.Add ("LS-500");
                    myList.Add ("LS-400");
                    break;
                case "光電感測器":
                    myList.Add ("EX-Z");
                    myList.Add ("CX-400");
                    myList.Add ("CY-100");
                    myList.Add ("EX-10");
                    myList.Add ("EX-20");
                    myList.Add ("EX-30");
                    myList.Add ("EX-40");
                    myList.Add ("EQ-30");
                    myList.Add ("EQ-500");
                    break;
                case "微型光電感測器":
                    myList.Add ("PM-25");
                    myList.Add ("PM-45");
                    myList.Add ("PM-65");
                    myList.Add ("PM2");
                    break;
                case "區域感測器":
                    myList.Add ("NA2-N");
                    myList.Add ("NA1-PK5");
                    myList.Add ("NA1-PK3");
                    break;
                case "安全光柵":
                    myList.Add ("SF4C");
                    myList.Add ("SF4B");
                    myList.Add ("SF4B-G");
                    myList.Add ("SF4B-C");
                    myList.Add ("SF4D");
                    myList.Add ("SF2C");
                    myList.Add ("SF2B");
                    myList.Add ("SF-C21");
                    myList.Add ("SF-C10");
                    myList.Add ("SW-200");
                    myList.Add ("ST4");
                    break;
                case "壓力感測器":
                    myList.Add ("DP-0");
                    myList.Add ("DP-100");
                    break;
                case "近接感測器":
                    myList.Add ("GX-100");
                    myList.Add ("GX-F/H");
                    myList.Add ("GXL");
                    myList.Add ("GL");
                    myList.Add ("GX-U/FU/N");
                    myList.Add ("GX");
                    myList.Add ("GA-311/GH");
                    break;
                case "特殊用途感測器":
                    myList.Add ("TP-100");
                    myList.Add ("M-DW1");
                    myList.Add ("HD-T1");
                    myList.Add ("SQ4");
                    myList.Add ("EX-F70/F60");
                    myList.Add ("EX-F1");
                    myList.Add ("EZ-10");
                    myList.Add ("LX-100");
                    myList.Add ("FZ-10");
                    myList.Add ("US-N300");
                    myList.Add ("NA1-11");
                    myList.Add ("NB");
                    myList.Add ("PX-2");
                    break;
                case "檢查、判別、測量用感測器":
                    myList.Add ("HG-C");
                    myList.Add ("HL-G1");
                    myList.Add ("HL-C2");
                    myList.Add ("HL-D3");
                    myList.Add ("GP-X");
                    myList.Add ("GP-A");
                    myList.Add("HG-S");
                    myList.Add("HL-T1");
                    myList.Add("LD");
                    myList.Add("GD");
                    myList.Add("CA2");
                    break;
                default:
                    return false;
            };
            return true;
        }

        private void reLoad_Click(object sender, EventArgs e)
        {
            string str =
                "SELECT * " +
                "FROM 單一型號對應表";
            Update_dataGridView(str);
        }

        private void rePana_Click(object sender, EventArgs e)
        {
            string str =
                "SELECT * " +
                "FROM 松下型號表";
            Update_dataGridView(str);
        }

        private void reAll_Click(object sender, EventArgs e)
        {
            string str =
                    "SELECT * " +
                    "FROM 單一型號對應表 " +
                    "INNER JOIN 松下型號表 " +
                    "ON 松下型號=型號 ";
            Update_dataGridView(str);
        }

        private void dataGridViewAutoSize_Click(object sender, EventArgs e)
        {
            dataGridViewFill = !dataGridViewFill;
        }

        private void dbClose_Click(object sender, EventArgs e)
        {
            textSelectID.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textSelectPID.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textID.Text = "";
            textPID.Text = "";
            textpNo.Text = "";

            string str =
                "SELECT * " +
                "FROM 單一型號對應表";
            Update_dataGridView(str);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 單一型號對應表 " +
                    "Where 廠牌名稱=N'" + comboBox4.Text + "'";
            Update_dataGridView(str);   
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str =
                    "SELECT * " +
                    "FROM 單一型號對應表 " +
                    "INNER JOIN 松下型號表 " +
                    "ON 松下型號=型號 " +
                    "WHERE 分類=N'" + comboBox5.Text + "'";
            Update_dataGridView(str);
        }     

        private void SelectID_Click(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 單一型號對應表 " +
                    "Where 它牌型號='" + textSelectID.Text + "'";
            Update_dataGridView(str);            
        }

        private void textSelectID_TextChanged(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 單一型號對應表 " +
                    "Where 它牌型號 Like'%" + textSelectID.Text + "%'";
            Update_dataGridView(str);
        }

        private void textSelectID_Validated(object sender, EventArgs e)
        {
            textSelectID.Text = textSelectID.Text.Trim();
            textSelectID.Text = textSelectID.Text.ToUpper();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            if (plist(comboBox6.SelectedItem.ToString()))
            {
                foreach (string strl in myList)
                {
                    comboBox7.Items.Add(strl);
                }
            };
            string str =
                    "SELECT * " +
                    "FROM  松下型號表 " +
                    "WHERE 分類=N'" + comboBox6.Text + "'";
            Update_dataGridView(str);

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str =
                    "SELECT * " +
                    "FROM  松下型號表 " +
                    "WHERE 系列=N'" + comboBox7.Text + "'";
            Update_dataGridView(str);
        }

        private void SelectPID_Click(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 單一型號對應表 " +
                    "Where 松下型號='" + textSelectPID.Text + "'";
            Update_dataGridView(str);
        }

        private void textSelectPID_TextChanged(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 松下型號表 " +
                    "Where 型號 Like'%" + textSelectPID.Text + "%'";
            Update_dataGridView(str);
        }

        private void textSelectPID_Validated(object sender, EventArgs e)
        {
            textSelectPID.Text = textSelectPID.Text.Trim();
            textSelectPID.Text = textSelectPID.Text.ToUpper();
        }

        private void SelectIDjoin_Click(object sender, EventArgs e)
        {
            string str =
                    "SELECT * " +
                    "FROM 單一型號對應表 " +
                    "INNER JOIN 松下型號表 " +
                    "ON 松下型號=型號 " +
                    "WHERE 它牌型號='" + textSelectID.Text + "'";
            Update_dataGridView(str);
        }

        private void SelectPtable_Click(object sender, EventArgs e)
        {
            string str =
                    "Select  * " +
                    "From 松下型號表 " +
                    "Where 型號 LIKE '%" + textSelectPID.Text + "%'";
            Update_dataGridView(str);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string str =
                    "SELECT * " +
                    "FROM  松下型號表 " +
                    "WHERE 分類=N'" + comboBox8.Text + "'";
            Update_dataGridView(str);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            Match m = RegNumber.Match(textBox4.Text);
            if (!m.Success)
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            Match m = RegNumber.Match(textBox5.Text);
            if (!m.Success)
            {
                textBox5.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            int.TryParse(textBox4.Text.ToString(), out a);
            int.TryParse(textBox5.Text.ToString(), out b);
                string str =
                        "SELECT * " +
                        "FROM  松下型號表 " +
                        "WHERE 分類=N'" + comboBox8.Text + "' AND " +
                        "最大檢測距離 >= " + a + " AND " +
                        "最小檢測距離 <= " + b ;
                Update_dataGridView(str);          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b;
            int.TryParse(textBox4.ToString(), out a);
            int.TryParse(textBox5.ToString(), out b);
            a -= 50;
            b += 50;
            string str =
                        "SELECT * " +
                        "FROM  松下型號表 " +
                        "WHERE 分類=N'" + comboBox8.Text + "' AND " +
                        "最大檢測距離 >= " + a + " AND " +
                        "最小檢測距離 <= " + b;
            Update_dataGridView(str);   
        }

        private void textPID_TextChanged(object sender, EventArgs e)
        {
            string str =
                    "Select  * " +
                    "From 松下型號表 " +
                    "WHERE 型號 LIKE '%" + textPID.Text + "%'";
            Update_dataGridView(str);
            if (ds.Tables[0].Rows.Count != 0 && Convert.ToString(ds.Tables[0].Rows[0]["型號"]) == textPID.Text.ToUpper())
            {
                groupBox5.Enabled = true;
                textID_TextChanged(sender, e);
            }
            else
            {
                groupBox5.Enabled = false;
            }
        }

        private void textPID_Validated(object sender, EventArgs e)
        {
            textPID.Text = textPID.Text.Trim();
            textPID.Text = textPID.Text.ToUpper();
        }

        private void textID_TextChanged(object sender, EventArgs e)
        {
            string str =
                    "Select * " +
                    "From 單一型號對應表 " +
                    "Where 松下型號='" + textPID.Text + "'And 它牌型號 ='" + textID.Text + "'";
            Update_dataGridView(str);
            if (ds.Tables[0].Rows.Count != 0 && Convert.ToString(ds.Tables[0].Rows[0]["它牌型號"]) == textID.Text.ToUpper())
            {
                textN.Text = Convert.ToString(ds.Tables[0].Rows[0]["對應分數"]);
                textPS.Text = Convert.ToString(ds.Tables[0].Rows[0]["備註"]);
                comboBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["廠牌名稱"]);
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                textN.Text = "";
                textPS.Text = "";
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void textID_Validated(object sender, EventArgs e)
        {
            textID.Text = textID.Text.Trim();
            textID.Text = textID.Text.ToUpper();
        }

        private void textN_TextChanged(object sender, EventArgs e)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            Match m =RegNumber.Match(textN.Text);
            if(!m.Success)
            {
                textN.Text = "";
            }
        }

        private void textpNo_TextChanged(object sender, EventArgs e)
        {
            string str =
                    "Select  * " +
                    "From 松下型號表 " +
                    "WHERE 型號 LIKE '%" + textpNo.Text + "%'";
            Update_dataGridView(str);
            if (ds.Tables[0].Rows.Count != 0 && Convert.ToString(ds.Tables[0].Rows[0]["型號"]) == textpNo.Text.ToUpper())
            {
                comboBox2.Text = Convert.ToString(ds.Tables[0].Rows[0]["分類"]);
                comboBox3.Text = Convert.ToString(ds.Tables[0].Rows[0]["系列"]);
                textpType.Text = Convert.ToString(ds.Tables[0].Rows[0]["名稱"]);
                textpMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["最小檢測距離"]);
                textpMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["最大檢測距離"]);
                textpOutput.Text = Convert.ToString(ds.Tables[0].Rows[0]["輸出類型"]);
                textpSize.Text = Convert.ToString(ds.Tables[0].Rows[0]["外型描述"]);
                textBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["光點尺寸"]);
                textBox2.Text = Convert.ToString(ds.Tables[0].Rows[0]["重複精度"]);
                textBox3.Text = Convert.ToString(ds.Tables[0].Rows[0]["特殊功能"]);
                textpPS.Text = Convert.ToString(ds.Tables[0].Rows[0]["產品備註"]); 
                btnpAdd.Enabled = false;
                btnpUpdate.Enabled = true;
                btnpDel.Enabled = true;
            }
            else if (textpNo.Text != "")
            {
                comboBox2.Text = "";
                comboBox3.Text = "";
                textpType.Text = "";
                textpMin.Text = "";
                textpMax.Text = "";
                textpOutput.Text = "";
                textpSize.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textpPS.Text = "";
                btnpAdd.Enabled = true;
                btnpUpdate.Enabled = false;
                btnpDel.Enabled = false;
            }
            else
            {
                comboBox2.Text = "";
                comboBox3.Text = "";
                textpType.Text = "";
                textpMin.Text = "";
                textpMax.Text = "";
                textpOutput.Text = "";
                textpSize.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textpPS.Text = "";
                btnpAdd.Enabled = false;
                btnpUpdate.Enabled = false;
                btnpDel.Enabled = false;
            }
        }

        private void textpNo_Validated(object sender, EventArgs e)
        {
            textpNo.Text = textpNo.Text.Trim();
            textpNo.Text = textpNo.Text.ToUpper();
        }

        private void textpMin_TextChanged(object sender, EventArgs e)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            Match m = RegNumber.Match(textpMin.Text);
            if (!m.Success)
            {
                textpMin.Text = "";
            }
        }

        private void textpMax_TextChanged(object sender, EventArgs e)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            Match m = RegNumber.Match(textpMax.Text);
            if (!m.Success)
            {
                textpMax.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (plist(comboBox2.SelectedItem.ToString()))
            {
                foreach(string str in myList)
                {
                    comboBox3.Items.Add(str);
                }
            };
             
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string str =
                    "INSERT INTO 單一型號對應表([廠牌名稱],[它牌型號],[松下型號],[對應分數],[備註])VALUES(N'" +
                    comboBox1.Text + "','" + 
                    textID.Text.ToUpper() + "','" + 
                    textPID.Text.ToUpper() + "','"+ 
                    textN.Text + "',N'" + 
                    textPS.Text + "')";
            Update_dataGridView(str);
            textID_TextChanged(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string str =
                    "UPDATE 單一型號對應表 " +
                    "SET 對應分數='" + textN.Text + "', " +
                    "廠牌名稱 = N'" + comboBox1.Text + "', " +
                    "備註 = N'" + textPS.Text + "' " +
                    "WHERE 它牌型號 ='" + textID.Text.ToUpper() + "' " +
                    "AND 松下型號 ='" + textPID.Text.ToUpper() + "'";
            Update_dataGridView(str);
            textID_TextChanged(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string str =
                    "DELETE FROM 單一型號對應表 " +
                    "WHERE 它牌型號='" + textID.Text + "' " +
                    "AND 松下型號='" + textPID.Text + "'";
            Update_dataGridView(str);
            textID_TextChanged(sender, e);
        }

        private void btnpAdd_Click(object sender, EventArgs e)
        {
            int a, b;
            int.TryParse(textpMin.Text, out a);
            int.TryParse(textpMax.Text, out b);
            string str =
                    "INSERT INTO 松下型號表([型號],[分類],[系列],"+
                    "[名稱],[最小檢測距離],[最大檢測距離],"+
                    "[輸出類型],[外型描述],[光點尺寸],"+
                    "[重複精度],[特殊功能],[產品備註])VALUES('" +
                    textpNo.Text.ToUpper() + "',N'" +
                    comboBox2.Text + "',N'" +
                    comboBox3.Text + "',N'" +
                    textpType.Text + "','" +
                    a + "','" +
                    b + "',N'" +
                    textpOutput.Text + "',N'" +
                    textpSize.Text + "',N'" +
                    textBox1.Text + "',N'" +
                    textBox2.Text + "',N'" +
                    textBox3.Text + "',N'" +
                    textpPS.Text + "')";

            Update_dataGridView(str);
            textpNo_TextChanged(sender, e);
        }

        private void btnpUpdate_Click(object sender, EventArgs e)
        {
            int a, b;
            int.TryParse(textpMin.Text, out a);
            int.TryParse(textpMax.Text, out b);

            string str =
                    "UPDATE 松下型號表 " +
                    "SET 分類=N'" + comboBox2.Text + "', " +
                    "系列=N'" + comboBox3.Text + "', " +
                    "名稱=N'" + textpType.Text + "', " +
                    "最小檢測距離='" + a + "', " +
                    "最大檢測距離='" + b + "', " +
                    "輸出類型=N'" + textpOutput.Text + "', " +
                    "外型描述=N'" + textpSize.Text + "', " +
                    "光點尺寸=N'" + textBox1.Text + "', " +
                    "重複精度=N'" + textBox2.Text + "', " +
                    "特殊功能=N'" + textBox3.Text + "', " +
                    "產品備註=N'" + textpPS.Text + "' " +
                    "WHERE 型號='" + textpNo.Text.ToUpper() + "'";
            Update_dataGridView(str);
            textpNo_TextChanged(sender, e);
        }

        private void btnpDel_Click(object sender, EventArgs e)
        {
            string str =
                "DELETE FROM 松下型號表 " +
                "WHERE 型號='" + textpNo.Text + "'";
            Update_dataGridView(str);
            textpNo_TextChanged(sender, e);
        }
    }
}
