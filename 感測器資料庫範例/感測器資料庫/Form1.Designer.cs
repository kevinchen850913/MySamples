using System;
using System.Data;
using System.Data.SqlClient;
namespace 感測器資料庫
{
    partial class Form1
    {
        DataSet ds = new DataSet();
        //提醒:若有移動位置或更新版本，請修改下面這一行。
        /*
        string ConnectionString =
            @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" +
            @"\\192.168.1.250\fae課\FAE資料庫更新管理\感測器資料庫\Database1.mdf" + 
            ";Integrated Security=True";
        */
        string ConnectionString =
            @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" +
            @"D:\陳科文\個人資料\軟體撰寫\20210113_感測器資料庫\Database1.mdf" +
            ";Integrated Security=True";
        bool dataGridViewFill = true;
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.SelectPtable = new System.Windows.Forms.Button();
            this.textSelectPID = new System.Windows.Forms.TextBox();
            this.SelectPID = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.textSelectID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SelectID = new System.Windows.Forms.Button();
            this.SelectIDjoin = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textPS = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPID = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textpSize = new System.Windows.Forms.TextBox();
            this.textpOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textpType = new System.Windows.Forms.TextBox();
            this.textpMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textpMin = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.textpNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.textpPS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.btnpAdd = new System.Windows.Forms.Button();
            this.btnpUpdate = new System.Windows.Forms.Button();
            this.btnpDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.reLoad = new System.Windows.Forms.Button();
            this.rePana = new System.Windows.Forms.Button();
            this.dbClose = new System.Windows.Forms.Button();
            this.reAll = new System.Windows.Forms.Button();
            this.dataGridViewAutoSize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(13, 268);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1238, 401);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 682);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel12.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(1238, 244);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1083, 238);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel17);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1075, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "資料庫查詢";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.Controls.Add(this.groupBox7, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.groupBox8, 2, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(1069, 197);
            this.tableLayoutPanel17.TabIndex = 7;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel18);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(359, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(350, 191);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "松下資料查詢";
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.SelectPtable, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.textSelectPID, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.SelectPID, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.comboBox6, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.comboBox7, 1, 2);
            this.tableLayoutPanel18.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 4;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(344, 159);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 39);
            this.label13.TabIndex = 7;
            this.label13.Text = "輸入松下型號";
            // 
            // SelectPtable
            // 
            this.SelectPtable.Location = new System.Drawing.Point(175, 120);
            this.SelectPtable.Name = "SelectPtable";
            this.SelectPtable.Size = new System.Drawing.Size(166, 34);
            this.SelectPtable.TabIndex = 5;
            this.SelectPtable.Text = "松下型號資料";
            this.SelectPtable.UseVisualStyleBackColor = true;
            this.SelectPtable.Click += new System.EventHandler(this.SelectPtable_Click);
            // 
            // textSelectPID
            // 
            this.textSelectPID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSelectPID.Location = new System.Drawing.Point(175, 3);
            this.textSelectPID.Name = "textSelectPID";
            this.textSelectPID.Size = new System.Drawing.Size(166, 33);
            this.textSelectPID.TabIndex = 3;
            this.textSelectPID.TextChanged += new System.EventHandler(this.textSelectPID_TextChanged);
            this.textSelectPID.Validated += new System.EventHandler(this.textSelectPID_Validated);
            // 
            // SelectPID
            // 
            this.SelectPID.Location = new System.Drawing.Point(3, 120);
            this.SelectPID.Name = "SelectPID";
            this.SelectPID.Size = new System.Drawing.Size(166, 34);
            this.SelectPID.TabIndex = 2;
            this.SelectPID.Text = "松下對應查詢";
            this.SelectPID.UseVisualStyleBackColor = true;
            this.SelectPID.Click += new System.EventHandler(this.SelectPID_Click);
            // 
            // comboBox6
            // 
            this.comboBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "光纖感測器",
            "雷射感測器",
            "光電感測器",
            "微型光電感測器",
            "區域感測器",
            "安全光柵",
            "壓力感測器",
            "近接感測器",
            "特殊用途感測器",
            "檢查、判別、測量用感測器"});
            this.comboBox6.Location = new System.Drawing.Point(175, 42);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(166, 29);
            this.comboBox6.TabIndex = 8;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(175, 81);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(166, 29);
            this.comboBox7.TabIndex = 9;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(142, 21);
            this.label22.TabIndex = 10;
            this.label22.Text = "選擇產品類型";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(142, 21);
            this.label23.TabIndex = 11;
            this.label23.Text = "選擇產品系列";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel8);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 191);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "它牌找松下";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.textSelectID, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.SelectID, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.SelectIDjoin, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.comboBox4, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.comboBox5, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(344, 159);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // textSelectID
            // 
            this.textSelectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSelectID.Location = new System.Drawing.Point(175, 3);
            this.textSelectID.Name = "textSelectID";
            this.textSelectID.Size = new System.Drawing.Size(166, 33);
            this.textSelectID.TabIndex = 0;
            this.textSelectID.TextChanged += new System.EventHandler(this.textSelectID_TextChanged);
            this.textSelectID.Validated += new System.EventHandler(this.textSelectID_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 39);
            this.label12.TabIndex = 6;
            this.label12.Text = "輸入它牌型號";
            // 
            // SelectID
            // 
            this.SelectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectID.Location = new System.Drawing.Point(3, 120);
            this.SelectID.Name = "SelectID";
            this.SelectID.Size = new System.Drawing.Size(166, 36);
            this.SelectID.TabIndex = 1;
            this.SelectID.Text = "它牌對應查詢";
            this.SelectID.UseVisualStyleBackColor = true;
            this.SelectID.Click += new System.EventHandler(this.SelectID_Click);
            // 
            // SelectIDjoin
            // 
            this.SelectIDjoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectIDjoin.Location = new System.Drawing.Point(175, 120);
            this.SelectIDjoin.Name = "SelectIDjoin";
            this.SelectIDjoin.Size = new System.Drawing.Size(166, 36);
            this.SelectIDjoin.TabIndex = 4;
            this.SelectIDjoin.Text = "詳細比較資料";
            this.SelectIDjoin.UseVisualStyleBackColor = true;
            this.SelectIDjoin.Click += new System.EventHandler(this.SelectIDjoin_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(175, 42);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(166, 29);
            this.comboBox4.TabIndex = 7;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "光纖感測器",
            "雷射感測器",
            "光電感測器",
            "微型光電感測器",
            "區域感測器",
            "安全光柵",
            "壓力感測器",
            "近接感測器",
            "特殊用途感測器",
            "檢查、判別、測量用感測器"});
            this.comboBox5.Location = new System.Drawing.Point(175, 81);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(166, 29);
            this.comboBox5.TabIndex = 8;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(3, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(166, 39);
            this.label20.TabIndex = 9;
            this.label20.Text = "選擇廠牌名稱";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(142, 21);
            this.label21.TabIndex = 10;
            this.label21.Text = "選擇產品類型";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanel19);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(715, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(351, 191);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "條件找松下";
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Controls.Add(this.comboBox8, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.textBox4, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.textBox5, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.label25, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.label26, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.button2, 1, 3);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 4;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(345, 159);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // comboBox8
            // 
            this.comboBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "光纖感測器",
            "雷射感測器",
            "光電感測器",
            "微型光電感測器",
            "區域感測器",
            "安全光柵",
            "壓力感測器",
            "近接感測器",
            "特殊用途感測器",
            "檢查、判別、測量用感測器"});
            this.comboBox8.Location = new System.Drawing.Point(175, 3);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(167, 29);
            this.comboBox8.TabIndex = 0;
            this.comboBox8.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(175, 42);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(167, 33);
            this.textBox4.TabIndex = 1;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(175, 81);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(167, 33);
            this.textBox5.TabIndex = 2;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(142, 21);
            this.label24.TabIndex = 3;
            this.label24.Text = "選擇產品類型";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 39);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(142, 21);
            this.label25.TabIndex = 4;
            this.label25.Text = "最大檢測距離";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(142, 21);
            this.label26.TabIndex = 5;
            this.label26.Text = "最小檢測距離";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "符合條件查詢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(175, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "接近條件查詢";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel11);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1075, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "型號對應表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel11.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1069, 197);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel14);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(943, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(123, 191);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "選擇操作";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.btnUpdate, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.btnDel, 0, 2);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 3;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(117, 159);
            this.tableLayoutPanel14.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 47);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(3, 56);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 47);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(3, 109);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(111, 47);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 191);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "輸入欄位";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(928, 159);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel9.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.textPS, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 82);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(922, 74);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 74);
            this.label4.TabIndex = 11;
            this.label4.Text = "備註";
            // 
            // textPS
            // 
            this.textPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPS.Location = new System.Drawing.Point(95, 3);
            this.textPS.Multiline = true;
            this.textPS.Name = "textPS";
            this.textPS.Size = new System.Drawing.Size(824, 68);
            this.textPS.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.textN, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textPID, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.textID, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(922, 73);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(776, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "對應次數";
            // 
            // textN
            // 
            this.textN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textN.Location = new System.Drawing.Point(776, 39);
            this.textN.Name = "textN";
            this.textN.Size = new System.Drawing.Size(143, 33);
            this.textN.TabIndex = 6;
            this.textN.TextChanged += new System.EventHandler(this.textN_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 21);
            this.label14.TabIndex = 11;
            this.label14.Text = "廠牌名稱";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(251, 29);
            this.comboBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "松下型號(必須表內)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "它牌型號(必填欄位)";
            // 
            // textPID
            // 
            this.textPID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPID.Location = new System.Drawing.Point(518, 39);
            this.textPID.Name = "textPID";
            this.textPID.Size = new System.Drawing.Size(252, 33);
            this.textPID.TabIndex = 5;
            this.textPID.TextChanged += new System.EventHandler(this.textPID_TextChanged);
            this.textPID.Validated += new System.EventHandler(this.textPID_Validated);
            // 
            // textID
            // 
            this.textID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textID.Location = new System.Drawing.Point(260, 39);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(252, 33);
            this.textID.TabIndex = 4;
            this.textID.TextChanged += new System.EventHandler(this.textID_TextChanged);
            this.textID.Validated += new System.EventHandler(this.textID_Validated);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel15);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1075, 203);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "松下型號表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel15.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.groupBox6, 1, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(1075, 203);
            this.tableLayoutPanel15.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(940, 197);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "輸入欄位";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel10, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(934, 165);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 6;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.textpSize, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.textpOutput, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label17, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBox1, 5, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 85);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(928, 35);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // textpSize
            // 
            this.textpSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpSize.Location = new System.Drawing.Point(434, 3);
            this.textpSize.Name = "textpSize";
            this.textpSize.Size = new System.Drawing.Size(179, 33);
            this.textpSize.TabIndex = 7;
            // 
            // textpOutput
            // 
            this.textpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpOutput.Location = new System.Drawing.Point(126, 3);
            this.textpOutput.Name = "textpOutput";
            this.textpOutput.Size = new System.Drawing.Size(179, 33);
            this.textpOutput.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "輸出類型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "外型描述";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(619, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 21);
            this.label17.TabIndex = 8;
            this.label17.Text = "光點尺寸";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(742, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 33);
            this.textBox1.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.textpType, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textpMax, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.textpMin, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(928, 35);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // textpType
            // 
            this.textpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpType.Location = new System.Drawing.Point(126, 3);
            this.textpType.Name = "textpType";
            this.textpType.Size = new System.Drawing.Size(179, 33);
            this.textpType.TabIndex = 3;
            // 
            // textpMax
            // 
            this.textpMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpMax.Location = new System.Drawing.Point(742, 3);
            this.textpMax.Name = "textpMax";
            this.textpMax.Size = new System.Drawing.Size(183, 33);
            this.textpMax.TabIndex = 5;
            this.textpMax.TextChanged += new System.EventHandler(this.textpMax_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "最大距離";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "產品名稱";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "最小距離";
            // 
            // textpMin
            // 
            this.textpMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpMin.Location = new System.Drawing.Point(434, 3);
            this.textpMin.Name = "textpMin";
            this.textpMin.Size = new System.Drawing.Size(179, 33);
            this.textpMin.TabIndex = 4;
            this.textpMin.TextChanged += new System.EventHandler(this.textpMin_TextChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 6;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.textpNo, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label15, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.label16, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.comboBox2, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.comboBox3, 5, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(928, 35);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "型號";
            // 
            // textpNo
            // 
            this.textpNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpNo.Location = new System.Drawing.Point(126, 3);
            this.textpNo.Name = "textpNo";
            this.textpNo.Size = new System.Drawing.Size(179, 33);
            this.textpNo.TabIndex = 2;
            this.textpNo.TextChanged += new System.EventHandler(this.textpNo_TextChanged);
            this.textpNo.Validated += new System.EventHandler(this.textpNo_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(311, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 21);
            this.label15.TabIndex = 3;
            this.label15.Text = "分類";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(619, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 21);
            this.label16.TabIndex = 4;
            this.label16.Text = "系列";
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "光纖感測器",
            "雷射感測器",
            "光電感測器",
            "微型光電感測器",
            "區域感測器",
            "安全光柵",
            "壓力感測器",
            "近接感測器",
            "特殊用途感測器",
            "檢查、判別、測量用感測器"});
            this.comboBox2.Location = new System.Drawing.Point(434, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 29);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(742, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(183, 29);
            this.comboBox3.TabIndex = 6;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 6;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.Controls.Add(this.textpPS, 5, 0);
            this.tableLayoutPanel10.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel10.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.textBox3, 3, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 126);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(928, 36);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // textpPS
            // 
            this.textpPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textpPS.Location = new System.Drawing.Point(742, 3);
            this.textpPS.Name = "textpPS";
            this.textpPS.Size = new System.Drawing.Size(183, 33);
            this.textpPS.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(619, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 21);
            this.label11.TabIndex = 6;
            this.label11.Text = "產品備註";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "重複精度";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(311, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 21);
            this.label19.TabIndex = 9;
            this.label19.Text = "特殊功能";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(126, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 33);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(434, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(179, 33);
            this.textBox3.TabIndex = 11;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel16);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(949, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(123, 197);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "選擇操作";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 1;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.btnpAdd, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.btnpUpdate, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.btnpDel, 0, 2);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(117, 165);
            this.tableLayoutPanel16.TabIndex = 4;
            // 
            // btnpAdd
            // 
            this.btnpAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnpAdd.Enabled = false;
            this.btnpAdd.Location = new System.Drawing.Point(3, 3);
            this.btnpAdd.Name = "btnpAdd";
            this.btnpAdd.Size = new System.Drawing.Size(111, 49);
            this.btnpAdd.TabIndex = 1;
            this.btnpAdd.Text = "新增";
            this.btnpAdd.UseVisualStyleBackColor = true;
            this.btnpAdd.Click += new System.EventHandler(this.btnpAdd_Click);
            // 
            // btnpUpdate
            // 
            this.btnpUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnpUpdate.Enabled = false;
            this.btnpUpdate.Location = new System.Drawing.Point(3, 58);
            this.btnpUpdate.Name = "btnpUpdate";
            this.btnpUpdate.Size = new System.Drawing.Size(111, 49);
            this.btnpUpdate.TabIndex = 2;
            this.btnpUpdate.Text = "修改";
            this.btnpUpdate.UseVisualStyleBackColor = true;
            this.btnpUpdate.Click += new System.EventHandler(this.btnpUpdate_Click);
            // 
            // btnpDel
            // 
            this.btnpDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnpDel.Enabled = false;
            this.btnpDel.Location = new System.Drawing.Point(3, 113);
            this.btnpDel.Name = "btnpDel";
            this.btnpDel.Size = new System.Drawing.Size(111, 49);
            this.btnpDel.TabIndex = 3;
            this.btnpDel.Text = "刪除";
            this.btnpDel.UseVisualStyleBackColor = true;
            this.btnpDel.Click += new System.EventHandler(this.btnpDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel13);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1092, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 238);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表單功能";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.reLoad, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.rePana, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.dbClose, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.reAll, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.dataGridViewAutoSize, 0, 3);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 5;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(137, 206);
            this.tableLayoutPanel13.TabIndex = 3;
            // 
            // reLoad
            // 
            this.reLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reLoad.Location = new System.Drawing.Point(3, 3);
            this.reLoad.Name = "reLoad";
            this.reLoad.Size = new System.Drawing.Size(131, 35);
            this.reLoad.TabIndex = 0;
            this.reLoad.Text = "型號對應";
            this.reLoad.UseVisualStyleBackColor = true;
            this.reLoad.Click += new System.EventHandler(this.reLoad_Click);
            // 
            // rePana
            // 
            this.rePana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rePana.Location = new System.Drawing.Point(3, 44);
            this.rePana.Name = "rePana";
            this.rePana.Size = new System.Drawing.Size(131, 35);
            this.rePana.TabIndex = 2;
            this.rePana.Text = "松下型號";
            this.rePana.UseVisualStyleBackColor = true;
            this.rePana.Click += new System.EventHandler(this.rePana_Click);
            // 
            // dbClose
            // 
            this.dbClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbClose.Location = new System.Drawing.Point(3, 167);
            this.dbClose.Name = "dbClose";
            this.dbClose.Size = new System.Drawing.Size(131, 36);
            this.dbClose.TabIndex = 1;
            this.dbClose.Text = "清空欄位";
            this.dbClose.UseVisualStyleBackColor = true;
            this.dbClose.Click += new System.EventHandler(this.dbClose_Click);
            // 
            // reAll
            // 
            this.reAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reAll.Location = new System.Drawing.Point(3, 85);
            this.reAll.Name = "reAll";
            this.reAll.Size = new System.Drawing.Size(131, 35);
            this.reAll.TabIndex = 3;
            this.reAll.Text = "詳細資料";
            this.reAll.UseVisualStyleBackColor = true;
            this.reAll.Click += new System.EventHandler(this.reAll_Click);
            // 
            // dataGridViewAutoSize
            // 
            this.dataGridViewAutoSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAutoSize.Location = new System.Drawing.Point(3, 126);
            this.dataGridViewAutoSize.Name = "dataGridViewAutoSize";
            this.dataGridViewAutoSize.Size = new System.Drawing.Size(131, 35);
            this.dataGridViewAutoSize.TabIndex = 4;
            this.dataGridViewAutoSize.Text = "自動填滿";
            this.dataGridViewAutoSize.UseVisualStyleBackColor = true;
            this.dataGridViewAutoSize.Click += new System.EventHandler(this.dataGridViewAutoSize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("DFKai-SB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "感測器資料庫";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button SelectIDjoin;
        private System.Windows.Forms.TextBox textSelectPID;
        private System.Windows.Forms.Button SelectPtable;
        private System.Windows.Forms.Button SelectPID;
        private System.Windows.Forms.Button SelectID;
        private System.Windows.Forms.TextBox textSelectID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPID;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Button btnpAdd;
        private System.Windows.Forms.Button btnpUpdate;
        private System.Windows.Forms.Button btnpDel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox textpSize;
        private System.Windows.Forms.TextBox textpOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox textpMax;
        private System.Windows.Forms.TextBox textpMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TextBox textpType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textpNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox textpPS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Button reLoad;
        private System.Windows.Forms.Button rePana;
        private System.Windows.Forms.Button dbClose;
        private System.Windows.Forms.Button reAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button dataGridViewAutoSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

