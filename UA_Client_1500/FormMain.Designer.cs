using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace UA_Client_1500
//namespace MPS_DT_2020_V00
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Versteckt den Close-Button (X) rechts oben
       /* private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }*/

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbl_ConnectInfo = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_StartTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_StopTest = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.btn_Fortsetzen = new System.Windows.Forms.Button();
            this.btn_IM_ON = new System.Windows.Forms.Button();
            this.btn_IM_OFF = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RG_Kühlung = new System.Windows.Forms.CheckBox();
            this.Druckluft_Kuhlung = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Projektnummer = new System.Windows.Forms.TextBox();
            this.PVpv = new System.Windows.Forms.TextBox();
            this.BA = new System.Windows.Forms.TextBox();
            this.bearbeiter = new System.Windows.Forms.TextBox();
            this.MF_AN = new System.Windows.Forms.TextBox();
            this.MF_SN = new System.Windows.Forms.TextBox();
            this.IM_AN = new System.Windows.Forms.TextBox();
            this.IM_SN = new System.Windows.Forms.TextBox();
            this.U_IM = new System.Windows.Forms.TextBox();
            this.I_MAG = new System.Windows.Forms.TextBox();
            this.energie = new System.Windows.Forms.TextBox();
            this.P_Dauer = new System.Windows.Forms.TextBox();
            this.sonstBemerkungen = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.T1_Name = new System.Windows.Forms.TextBox();
            this.Testzeitvorgabe = new System.Windows.Forms.TextBox();
            this.Taktzeitvorgabe = new System.Windows.Forms.TextBox();
            this.kuhlungsart = new System.Windows.Forms.ComboBox();
            this.MF_AName = new System.Windows.Forms.ComboBox();
            this.IM_AName = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.T4_checkBox = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.T5_checkBox = new System.Windows.Forms.CheckBox();
            this.T2_Name = new System.Windows.Forms.TextBox();
            this.T3_Name = new System.Windows.Forms.TextBox();
            this.T4_Name = new System.Windows.Forms.TextBox();
            this.T5_Name = new System.Windows.Forms.TextBox();
            this.T6_checkBox = new System.Windows.Forms.CheckBox();
            this.T7_checkBox = new System.Windows.Forms.CheckBox();
            this.T8_checkBox = new System.Windows.Forms.CheckBox();
            this.T6_Name = new System.Windows.Forms.TextBox();
            this.T7_Name = new System.Windows.Forms.TextBox();
            this.T8_Name = new System.Windows.Forms.TextBox();
            this.T1_MAX = new System.Windows.Forms.TextBox();
            this.T2_MAX = new System.Windows.Forms.TextBox();
            this.T3_MAX = new System.Windows.Forms.TextBox();
            this.T4_MAX = new System.Windows.Forms.TextBox();
            this.T5_MAX = new System.Windows.Forms.TextBox();
            this.T6_MAX = new System.Windows.Forms.TextBox();
            this.T7_MAX = new System.Windows.Forms.TextBox();
            this.T8_MAX = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.Statusbox = new System.Windows.Forms.Label();
            this.IMon_Override = new System.Windows.Forms.CheckBox();
            this.Testobjekt = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.Datumslabel = new System.Windows.Forms.Label();
            this.Testdauerlabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel_testinfos = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.panel_vorgabepar = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.T3_checkBox = new System.Windows.Forms.CheckBox();
            this.T2_checkBox = new System.Windows.Forms.CheckBox();
            this.T1_checkBox = new System.Windows.Forms.CheckBox();
            this.lb_T8 = new System.Windows.Forms.Label();
            this.lb_T7 = new System.Windows.Forms.Label();
            this.lb_T6 = new System.Windows.Forms.Label();
            this.lb_T5 = new System.Windows.Forms.Label();
            this.lb_T4 = new System.Windows.Forms.Label();
            this.lb_T3 = new System.Windows.Forms.Label();
            this.lb_T2 = new System.Windows.Forms.Label();
            this.lb_T1 = new System.Windows.Forms.Label();
            this.panel_steuerdt = new System.Windows.Forms.Panel();
            this.btn_Entw = new System.Windows.Forms.Button();
            this.btn_TempQuit = new System.Windows.Forms.Button();
            this.panel_gemtestdaten = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.panel_status = new System.Windows.Forms.Panel();
            this.pnl_StatusFarbe = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opendataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.savedataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationenZuMPSDT2020ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_testinfos.SuspendLayout();
            this.panel_vorgabepar.SuspendLayout();
            this.panel_steuerdt.SuspendLayout();
            this.panel_gemtestdaten.SuspendLayout();
            this.panel_status.SuspendLayout();
            this.pnl_StatusFarbe.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ConnectInfo
            // 
            this.lbl_ConnectInfo.AutoSize = true;
            this.lbl_ConnectInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ConnectInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_ConnectInfo.Location = new System.Drawing.Point(6, 6);
            this.lbl_ConnectInfo.Name = "lbl_ConnectInfo";
            this.lbl_ConnectInfo.Size = new System.Drawing.Size(105, 21);
            this.lbl_ConnectInfo.TabIndex = 3;
            this.lbl_ConnectInfo.Text = "ConnectInfo";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Close.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(428, 247);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(148, 40);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Herunterfahren";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_StartTest
            // 
            this.btn_StartTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_StartTest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_StartTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StartTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_StartTest.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartTest.Location = new System.Drawing.Point(4, 63);
            this.btn_StartTest.Name = "btn_StartTest";
            this.btn_StartTest.Size = new System.Drawing.Size(115, 40);
            this.btn_StartTest.TabIndex = 5;
            this.btn_StartTest.Text = "Start ";
            this.btn_StartTest.UseVisualStyleBackColor = false;
            this.btn_StartTest.Click += new System.EventHandler(this.btn_StartTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anzahl Messungen";
            // 
            // chart1
            // 
            this.chart1.BackSecondaryColor = System.Drawing.Color.DarkGray;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(436, 374);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.Size = new System.Drawing.Size(1172, 543);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "TEMPERATUREN";
            // 
            // btn_StopTest
            // 
            this.btn_StopTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_StopTest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_StopTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StopTest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_StopTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_StopTest.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopTest.Location = new System.Drawing.Point(367, 63);
            this.btn_StopTest.Name = "btn_StopTest";
            this.btn_StopTest.Size = new System.Drawing.Size(201, 40);
            this.btn_StopTest.TabIndex = 11;
            this.btn_StopTest.Text = "Test beenden";
            this.btn_StopTest.UseVisualStyleBackColor = false;
            this.btn_StopTest.Click += new System.EventHandler(this.btn_StopTest_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Pause.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pause.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Pause.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pause.Location = new System.Drawing.Point(246, 63);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(115, 40);
            this.btn_Pause.TabIndex = 12;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = false;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_Fortsetzen
            // 
            this.btn_Fortsetzen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Fortsetzen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Fortsetzen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Fortsetzen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Fortsetzen.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fortsetzen.Location = new System.Drawing.Point(125, 63);
            this.btn_Fortsetzen.Name = "btn_Fortsetzen";
            this.btn_Fortsetzen.Size = new System.Drawing.Size(115, 40);
            this.btn_Fortsetzen.TabIndex = 13;
            this.btn_Fortsetzen.Text = "Fortsetzen";
            this.btn_Fortsetzen.UseVisualStyleBackColor = false;
            this.btn_Fortsetzen.Click += new System.EventHandler(this.btn_Fortsetzen_Click);
            // 
            // btn_IM_ON
            // 
            this.btn_IM_ON.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_IM_ON.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_IM_ON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_IM_ON.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_IM_ON.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IM_ON.Location = new System.Drawing.Point(4, 11);
            this.btn_IM_ON.Name = "btn_IM_ON";
            this.btn_IM_ON.Size = new System.Drawing.Size(115, 35);
            this.btn_IM_ON.TabIndex = 16;
            this.btn_IM_ON.Text = "IM ON";
            this.btn_IM_ON.UseVisualStyleBackColor = false;
            this.btn_IM_ON.Click += new System.EventHandler(this.btn_IM_ON_Click);
            // 
            // btn_IM_OFF
            // 
            this.btn_IM_OFF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_IM_OFF.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_IM_OFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_IM_OFF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_IM_OFF.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IM_OFF.Location = new System.Drawing.Point(125, 11);
            this.btn_IM_OFF.Name = "btn_IM_OFF";
            this.btn_IM_OFF.Size = new System.Drawing.Size(115, 35);
            this.btn_IM_OFF.TabIndex = 17;
            this.btn_IM_OFF.Text = "IM OFF";
            this.btn_IM_OFF.UseVisualStyleBackColor = false;
            this.btn_IM_OFF.Click += new System.EventHandler(this.btn_IM_OFF_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Anzahl Impulse";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(279, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // RG_Kühlung
            // 
            this.RG_Kühlung.AutoSize = true;
            this.RG_Kühlung.Enabled = false;
            this.RG_Kühlung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RG_Kühlung.Location = new System.Drawing.Point(3, 123);
            this.RG_Kühlung.Name = "RG_Kühlung";
            this.RG_Kühlung.Size = new System.Drawing.Size(252, 22);
            this.RG_Kühlung.TabIndex = 23;
            this.RG_Kühlung.Text = "K2 - MF RG-Kühlung einschalten";
            this.RG_Kühlung.UseVisualStyleBackColor = true;
            this.RG_Kühlung.CheckedChanged += new System.EventHandler(this.RG_Kühlung_CheckedChanged);
            // 
            // Druckluft_Kuhlung
            // 
            this.Druckluft_Kuhlung.AutoSize = true;
            this.Druckluft_Kuhlung.Enabled = false;
            this.Druckluft_Kuhlung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Druckluft_Kuhlung.Location = new System.Drawing.Point(3, 151);
            this.Druckluft_Kuhlung.Name = "Druckluft_Kuhlung";
            this.Druckluft_Kuhlung.Size = new System.Drawing.Size(281, 22);
            this.Druckluft_Kuhlung.TabIndex = 24;
            this.Druckluft_Kuhlung.Text = "K4 - MF Druckluftkühlung einschalten";
            this.Druckluft_Kuhlung.UseVisualStyleBackColor = true;
            this.Druckluft_Kuhlung.CheckedChanged += new System.EventHandler(this.Druckluft_Kuhlung_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Projektnummer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "PV/pv:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 22);
            this.label5.TabIndex = 27;
            this.label5.Text = "Test Informationen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Betriebsauftrag:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Bearbeiter:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "MF Artikelname:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "MF Artikel-Nr.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "MF Serien-Nr.:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "IM Artikelname:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "IM Artikel-Nr.:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 35;
            this.label13.Text = "IM Serien-Nr.:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 301);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 16);
            this.label14.TabIndex = 36;
            this.label14.Text = "Ladespannung U [VDC]:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 327);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "Magnetisierstrom I [kA]:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 353);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 16);
            this.label16.TabIndex = 38;
            this.label16.Text = "Energie E [Ws]:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 379);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 16);
            this.label17.TabIndex = 39;
            this.label17.Text = "Dauerleistung P [W]:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 405);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 16);
            this.label18.TabIndex = 40;
            this.label18.Text = "Verwandte Kühlung:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 431);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 16);
            this.label19.TabIndex = 41;
            this.label19.Text = "Sonstige Bemerkungen:";
            // 
            // Projektnummer
            // 
            this.Projektnummer.Location = new System.Drawing.Point(165, 37);
            this.Projektnummer.Name = "Projektnummer";
            this.Projektnummer.Size = new System.Drawing.Size(221, 20);
            this.Projektnummer.TabIndex = 42;
            // 
            // PVpv
            // 
            this.PVpv.Location = new System.Drawing.Point(165, 63);
            this.PVpv.Name = "PVpv";
            this.PVpv.Size = new System.Drawing.Size(221, 20);
            this.PVpv.TabIndex = 43;
            // 
            // BA
            // 
            this.BA.Location = new System.Drawing.Point(165, 89);
            this.BA.Name = "BA";
            this.BA.Size = new System.Drawing.Size(221, 20);
            this.BA.TabIndex = 44;
            // 
            // bearbeiter
            // 
            this.bearbeiter.Location = new System.Drawing.Point(165, 115);
            this.bearbeiter.Name = "bearbeiter";
            this.bearbeiter.Size = new System.Drawing.Size(221, 20);
            this.bearbeiter.TabIndex = 45;
            // 
            // MF_AN
            // 
            this.MF_AN.Location = new System.Drawing.Point(165, 248);
            this.MF_AN.Name = "MF_AN";
            this.MF_AN.Size = new System.Drawing.Size(221, 20);
            this.MF_AN.TabIndex = 47;
            this.MF_AN.Text = "Auto-Ergänzung bei Labor-MF\'s";
            // 
            // MF_SN
            // 
            this.MF_SN.Location = new System.Drawing.Point(166, 274);
            this.MF_SN.Name = "MF_SN";
            this.MF_SN.Size = new System.Drawing.Size(221, 20);
            this.MF_SN.TabIndex = 48;
            this.MF_SN.Text = "Auto-Ergänzung bei Labor-MF\'s";
            // 
            // IM_AN
            // 
            this.IM_AN.Location = new System.Drawing.Point(165, 169);
            this.IM_AN.Name = "IM_AN";
            this.IM_AN.Size = new System.Drawing.Size(221, 20);
            this.IM_AN.TabIndex = 50;
            this.IM_AN.Text = "Auto-Ergänzung bei Labor-IM\'s";
            // 
            // IM_SN
            // 
            this.IM_SN.Location = new System.Drawing.Point(165, 195);
            this.IM_SN.Name = "IM_SN";
            this.IM_SN.Size = new System.Drawing.Size(221, 20);
            this.IM_SN.TabIndex = 51;
            this.IM_SN.Text = "Auto-Ergänzung bei Labor-IM\'s";
            // 
            // U_IM
            // 
            this.U_IM.Location = new System.Drawing.Point(165, 300);
            this.U_IM.Name = "U_IM";
            this.U_IM.Size = new System.Drawing.Size(221, 20);
            this.U_IM.TabIndex = 52;
            // 
            // I_MAG
            // 
            this.I_MAG.Location = new System.Drawing.Point(165, 326);
            this.I_MAG.Name = "I_MAG";
            this.I_MAG.Size = new System.Drawing.Size(221, 20);
            this.I_MAG.TabIndex = 53;
            // 
            // energie
            // 
            this.energie.Location = new System.Drawing.Point(165, 352);
            this.energie.Name = "energie";
            this.energie.Size = new System.Drawing.Size(221, 20);
            this.energie.TabIndex = 54;
            // 
            // P_Dauer
            // 
            this.P_Dauer.Location = new System.Drawing.Point(165, 378);
            this.P_Dauer.Name = "P_Dauer";
            this.P_Dauer.Size = new System.Drawing.Size(221, 20);
            this.P_Dauer.TabIndex = 55;
            // 
            // sonstBemerkungen
            // 
            this.sonstBemerkungen.Location = new System.Drawing.Point(166, 431);
            this.sonstBemerkungen.Multiline = true;
            this.sonstBemerkungen.Name = "sonstBemerkungen";
            this.sonstBemerkungen.Size = new System.Drawing.Size(221, 61);
            this.sonstBemerkungen.TabIndex = 57;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(12, 583);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(173, 18);
            this.label20.TabIndex = 58;
            this.label20.Text = "Test Vorgabeparameter";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 16);
            this.label21.TabIndex = 59;
            this.label21.Text = "IM Taktzeit [s]:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 16);
            this.label22.TabIndex = 60;
            this.label22.Text = "Testdauer [min]:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(9, 89);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 16);
            this.label23.TabIndex = 61;
            this.label23.Text = "T1 [°C]:";
            // 
            // T1_Name
            // 
            this.T1_Name.Location = new System.Drawing.Point(118, 88);
            this.T1_Name.Name = "T1_Name";
            this.T1_Name.Size = new System.Drawing.Size(185, 20);
            this.T1_Name.TabIndex = 63;
            this.T1_Name.Text = "Umgebungstemperatur";
            // 
            // Testzeitvorgabe
            // 
            this.Testzeitvorgabe.Location = new System.Drawing.Point(109, 37);
            this.Testzeitvorgabe.Name = "Testzeitvorgabe";
            this.Testzeitvorgabe.Size = new System.Drawing.Size(61, 20);
            this.Testzeitvorgabe.TabIndex = 64;
            this.Testzeitvorgabe.Text = "8";
            // 
            // Taktzeitvorgabe
            // 
            this.Taktzeitvorgabe.Location = new System.Drawing.Point(109, 8);
            this.Taktzeitvorgabe.Name = "Taktzeitvorgabe";
            this.Taktzeitvorgabe.Size = new System.Drawing.Size(60, 20);
            this.Taktzeitvorgabe.TabIndex = 65;
            this.Taktzeitvorgabe.Text = "5";
            // 
            // kuhlungsart
            // 
            this.kuhlungsart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kuhlungsart.FormattingEnabled = true;
            this.kuhlungsart.Items.AddRange(new object[] {
            "Wasser",
            "Druckluft",
            "RG140",
            "Keine"});
            this.kuhlungsart.Location = new System.Drawing.Point(166, 404);
            this.kuhlungsart.Name = "kuhlungsart";
            this.kuhlungsart.Size = new System.Drawing.Size(221, 21);
            this.kuhlungsart.TabIndex = 70;
            // 
            // MF_AName
            // 
            this.MF_AName.FormattingEnabled = true;
            this.MF_AName.Items.AddRange(new object[] {
            "Kurzschluss",
            "MV-3\" F-TC Labor",
            "MF-Al-d152,0x120,0mm-3654-Labor",
            "MV-4\" F-TC-Labor",
            "MF-Al-d260,0x120,0mm-5172-Labor",
            "MF-AlD-d102,0x60,0mm-3048-Labor",
            "MF-Am-d78,0x90,0mm-2436-Labor",
            "MV-2\" F-TC-Labor",
            "MF-Am-d60,0x60mm-2430-Labor",
            "MV-d130x140mm L-TC/R-Labor",
            "MV-1\" F-TC-Labor",
            "MV-2\" F-TC-Labor",
            "MF-Ks-108/d75xd64-6/d54xd44mm-Labor",
            "MV-1\" F-TC Labor",
            "MV-90,0x60,0mm-Labor",
            "MV-5\"-L-TC-Labor",
            "MV-2\"-F-TC-Labor",
            "MV-5\"-L-TC-Labor"});
            this.MF_AName.Location = new System.Drawing.Point(165, 221);
            this.MF_AName.Name = "MF_AName";
            this.MF_AName.Size = new System.Drawing.Size(221, 21);
            this.MF_AName.TabIndex = 71;
            this.MF_AName.SelectedIndexChanged += new System.EventHandler(this.MF_AName_SelectedIndexChanged);
            // 
            // IM_AName
            // 
            this.IM_AName.FormattingEnabled = true;
            this.IM_AName.Items.AddRange(new object[] {
            "IM-U-0310-A----KP--081A1F3G2A1-Labor",
            "IM-U-0310-AD---KP--081A1F3G2A1-Labor",
            "IM-U-1420-A-HC-Labor",
            "IM-U-1420-AK---KP--081A1F3A2A1-Labor",
            "IM-U-2820-A----DT--121A1F3H2A1-Labor",
            "IM-M-004020-SD--TP-C13G3H3A2A2-Labor",
            "IM-X-051030-ADK+TN-C23B5B3F2L2-Labor"});
            this.IM_AName.Location = new System.Drawing.Point(165, 142);
            this.IM_AName.Name = "IM_AName";
            this.IM_AName.Size = new System.Drawing.Size(221, 21);
            this.IM_AName.TabIndex = 72;
            this.IM_AName.SelectedIndexChanged += new System.EventHandler(this.IM_AName_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(346, 5);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(182, 16);
            this.label28.TabIndex = 73;
            this.label28.Text = "Reale Taktzeit (berechnet) [s]:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(4, 5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(196, 16);
            this.label29.TabIndex = 74;
            this.label29.Text = "Bisherige Testdauer [hh:mm:ss]:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(3, 268);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(345, 16);
            this.label30.TabIndex = 75;
            this.label30.Text = "Pfad der .CSV-Datei: C\\MPS-Dauertest\\ArtikeNr.\\SerienNr.";
            // 
            // T4_checkBox
            // 
            this.T4_checkBox.AutoSize = true;
            this.T4_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T4_checkBox.Location = new System.Drawing.Point(67, 170);
            this.T4_checkBox.Name = "T4_checkBox";
            this.T4_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T4_checkBox.TabIndex = 81;
            this.T4_checkBox.UseVisualStyleBackColor = true;
            this.T4_checkBox.CheckedChanged += new System.EventHandler(this.T4_checkBox_CheckedChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(9, 115);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(52, 16);
            this.label33.TabIndex = 82;
            this.label33.Text = "T2 [°C]:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(9, 141);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(52, 16);
            this.label34.TabIndex = 83;
            this.label34.Text = "T3 [°C]:";
            // 
            // T5_checkBox
            // 
            this.T5_checkBox.AutoSize = true;
            this.T5_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T5_checkBox.Location = new System.Drawing.Point(67, 195);
            this.T5_checkBox.Name = "T5_checkBox";
            this.T5_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T5_checkBox.TabIndex = 84;
            this.T5_checkBox.UseVisualStyleBackColor = true;
            // 
            // T2_Name
            // 
            this.T2_Name.Location = new System.Drawing.Point(118, 114);
            this.T2_Name.Name = "T2_Name";
            this.T2_Name.Size = new System.Drawing.Size(185, 20);
            this.T2_Name.TabIndex = 85;
            this.T2_Name.Text = "MF PT100";
            // 
            // T3_Name
            // 
            this.T3_Name.Location = new System.Drawing.Point(118, 140);
            this.T3_Name.Name = "T3_Name";
            this.T3_Name.Size = new System.Drawing.Size(185, 20);
            this.T3_Name.TabIndex = 86;
            this.T3_Name.Text = "MF Luftkühlung Abluft";
            // 
            // T4_Name
            // 
            this.T4_Name.Location = new System.Drawing.Point(118, 166);
            this.T4_Name.Name = "T4_Name";
            this.T4_Name.Size = new System.Drawing.Size(185, 20);
            this.T4_Name.TabIndex = 87;
            this.T4_Name.Text = "T4";
            // 
            // T5_Name
            // 
            this.T5_Name.Location = new System.Drawing.Point(118, 192);
            this.T5_Name.Name = "T5_Name";
            this.T5_Name.Size = new System.Drawing.Size(185, 20);
            this.T5_Name.TabIndex = 88;
            this.T5_Name.Text = "T5";
            // 
            // T6_checkBox
            // 
            this.T6_checkBox.AutoSize = true;
            this.T6_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T6_checkBox.Location = new System.Drawing.Point(67, 221);
            this.T6_checkBox.Name = "T6_checkBox";
            this.T6_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T6_checkBox.TabIndex = 89;
            this.T6_checkBox.UseVisualStyleBackColor = true;
            // 
            // T7_checkBox
            // 
            this.T7_checkBox.AutoSize = true;
            this.T7_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T7_checkBox.Location = new System.Drawing.Point(67, 248);
            this.T7_checkBox.Name = "T7_checkBox";
            this.T7_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T7_checkBox.TabIndex = 90;
            this.T7_checkBox.UseVisualStyleBackColor = true;
            // 
            // T8_checkBox
            // 
            this.T8_checkBox.AutoSize = true;
            this.T8_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T8_checkBox.Location = new System.Drawing.Point(67, 274);
            this.T8_checkBox.Name = "T8_checkBox";
            this.T8_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T8_checkBox.TabIndex = 91;
            this.T8_checkBox.UseVisualStyleBackColor = true;
            // 
            // T6_Name
            // 
            this.T6_Name.Location = new System.Drawing.Point(118, 218);
            this.T6_Name.Name = "T6_Name";
            this.T6_Name.Size = new System.Drawing.Size(185, 20);
            this.T6_Name.TabIndex = 92;
            this.T6_Name.Text = "T6";
            // 
            // T7_Name
            // 
            this.T7_Name.Location = new System.Drawing.Point(118, 244);
            this.T7_Name.Name = "T7_Name";
            this.T7_Name.Size = new System.Drawing.Size(185, 20);
            this.T7_Name.TabIndex = 93;
            this.T7_Name.Text = "T7";
            // 
            // T8_Name
            // 
            this.T8_Name.Location = new System.Drawing.Point(118, 270);
            this.T8_Name.Name = "T8_Name";
            this.T8_Name.Size = new System.Drawing.Size(185, 20);
            this.T8_Name.TabIndex = 94;
            this.T8_Name.Text = "T8";
            // 
            // T1_MAX
            // 
            this.T1_MAX.Location = new System.Drawing.Point(309, 88);
            this.T1_MAX.Name = "T1_MAX";
            this.T1_MAX.Size = new System.Drawing.Size(35, 20);
            this.T1_MAX.TabIndex = 96;
            this.T1_MAX.Text = "35";
            this.T1_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T2_MAX
            // 
            this.T2_MAX.Location = new System.Drawing.Point(309, 114);
            this.T2_MAX.Name = "T2_MAX";
            this.T2_MAX.Size = new System.Drawing.Size(35, 20);
            this.T2_MAX.TabIndex = 97;
            this.T2_MAX.Text = "60";
            this.T2_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T3_MAX
            // 
            this.T3_MAX.Location = new System.Drawing.Point(309, 140);
            this.T3_MAX.Name = "T3_MAX";
            this.T3_MAX.Size = new System.Drawing.Size(35, 20);
            this.T3_MAX.TabIndex = 98;
            this.T3_MAX.Text = "60";
            this.T3_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T4_MAX
            // 
            this.T4_MAX.Location = new System.Drawing.Point(309, 166);
            this.T4_MAX.Name = "T4_MAX";
            this.T4_MAX.Size = new System.Drawing.Size(35, 20);
            this.T4_MAX.TabIndex = 99;
            this.T4_MAX.Text = "60";
            this.T4_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T5_MAX
            // 
            this.T5_MAX.Location = new System.Drawing.Point(309, 193);
            this.T5_MAX.Name = "T5_MAX";
            this.T5_MAX.Size = new System.Drawing.Size(35, 20);
            this.T5_MAX.TabIndex = 100;
            this.T5_MAX.Text = "60";
            this.T5_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T6_MAX
            // 
            this.T6_MAX.Location = new System.Drawing.Point(309, 218);
            this.T6_MAX.Name = "T6_MAX";
            this.T6_MAX.Size = new System.Drawing.Size(35, 20);
            this.T6_MAX.TabIndex = 101;
            this.T6_MAX.Text = "60";
            this.T6_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T7_MAX
            // 
            this.T7_MAX.Location = new System.Drawing.Point(309, 244);
            this.T7_MAX.Name = "T7_MAX";
            this.T7_MAX.Size = new System.Drawing.Size(35, 20);
            this.T7_MAX.TabIndex = 102;
            this.T7_MAX.Text = "60";
            this.T7_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // T8_MAX
            // 
            this.T8_MAX.Location = new System.Drawing.Point(309, 270);
            this.T8_MAX.Name = "T8_MAX";
            this.T8_MAX.Size = new System.Drawing.Size(35, 20);
            this.T8_MAX.TabIndex = 103;
            this.T8_MAX.Text = "60";
            this.T8_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(306, 66);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(39, 16);
            this.label43.TabIndex = 111;
            this.label43.Text = "MAX.";
            // 
            // Statusbox
            // 
            this.Statusbox.BackColor = System.Drawing.Color.Transparent;
            this.Statusbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Statusbox.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Bold);
            this.Statusbox.Location = new System.Drawing.Point(0, 0);
            this.Statusbox.Name = "Statusbox";
            this.Statusbox.Size = new System.Drawing.Size(540, 164);
            this.Statusbox.TabIndex = 112;
            this.Statusbox.Text = "STATUS";
            this.Statusbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Statusbox.Click += new System.EventHandler(this.Statusbox_Click);
            // 
            // IMon_Override
            // 
            this.IMon_Override.AutoSize = true;
            this.IMon_Override.Enabled = false;
            this.IMon_Override.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMon_Override.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.IMon_Override.Location = new System.Drawing.Point(258, 15);
            this.IMon_Override.Name = "IMon_Override";
            this.IMon_Override.Size = new System.Drawing.Size(169, 27);
            this.IMon_Override.TabIndex = 113;
            this.IMon_Override.Text = "\"IM On\" Override";
            this.IMon_Override.UseVisualStyleBackColor = true;
            // 
            // Testobjekt
            // 
            this.Testobjekt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Testobjekt.FormattingEnabled = true;
            this.Testobjekt.Items.AddRange(new object[] {
            "IM",
            "MF",
            "Entwicklung"});
            this.Testobjekt.Location = new System.Drawing.Point(166, 10);
            this.Testobjekt.Name = "Testobjekt";
            this.Testobjekt.Size = new System.Drawing.Size(221, 21);
            this.Testobjekt.TabIndex = 114;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(7, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 115;
            this.label25.Text = "Testobjekt:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(433, 35);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(204, 18);
            this.label35.TabIndex = 117;
            this.label35.Text = "Steuerung Dauertestanlage";
            // 
            // Datumslabel
            // 
            this.Datumslabel.AutoSize = true;
            this.Datumslabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Datumslabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Datumslabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Datumslabel.Location = new System.Drawing.Point(6, 33);
            this.Datumslabel.Name = "Datumslabel";
            this.Datumslabel.Size = new System.Drawing.Size(67, 21);
            this.Datumslabel.TabIndex = 121;
            this.Datumslabel.Text = "Datum:";
            // 
            // Testdauerlabel
            // 
            this.Testdauerlabel.AutoSize = true;
            this.Testdauerlabel.BackColor = System.Drawing.Color.LightGray;
            this.Testdauerlabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Testdauerlabel.ForeColor = System.Drawing.Color.Black;
            this.Testdauerlabel.Location = new System.Drawing.Point(206, 5);
            this.Testdauerlabel.Name = "Testdauerlabel";
            this.Testdauerlabel.Size = new System.Drawing.Size(64, 16);
            this.Testdauerlabel.TabIndex = 122;
            this.Testdauerlabel.Text = "Testdauer";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 16);
            this.label26.TabIndex = 123;
            this.label26.Text = "T4 [°C]:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(9, 272);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 16);
            this.label27.TabIndex = 127;
            this.label27.Text = "T8 [°C]:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(9, 245);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 16);
            this.label31.TabIndex = 126;
            this.label31.Text = "T7 [°C]:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(9, 219);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(52, 16);
            this.label32.TabIndex = 125;
            this.label32.Text = "T6 [°C]:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(9, 193);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 16);
            this.label36.TabIndex = 124;
            this.label36.Text = "T5 [°C]:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(115, 66);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(83, 16);
            this.label37.TabIndex = 128;
            this.label37.Text = "Bezeichnung";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(351, 66);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 16);
            this.label38.TabIndex = 129;
            this.label38.Text = "Aktuell";
            // 
            // panel_testinfos
            // 
            this.panel_testinfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_testinfos.Controls.Add(this.label25);
            this.panel_testinfos.Controls.Add(this.label3);
            this.panel_testinfos.Controls.Add(this.label4);
            this.panel_testinfos.Controls.Add(this.label6);
            this.panel_testinfos.Controls.Add(this.label7);
            this.panel_testinfos.Controls.Add(this.label11);
            this.panel_testinfos.Controls.Add(this.label12);
            this.panel_testinfos.Controls.Add(this.label13);
            this.panel_testinfos.Controls.Add(this.label8);
            this.panel_testinfos.Controls.Add(this.label9);
            this.panel_testinfos.Controls.Add(this.label10);
            this.panel_testinfos.Controls.Add(this.label14);
            this.panel_testinfos.Controls.Add(this.label15);
            this.panel_testinfos.Controls.Add(this.label16);
            this.panel_testinfos.Controls.Add(this.label17);
            this.panel_testinfos.Controls.Add(this.label18);
            this.panel_testinfos.Controls.Add(this.label19);
            this.panel_testinfos.Controls.Add(this.Testobjekt);
            this.panel_testinfos.Controls.Add(this.bearbeiter);
            this.panel_testinfos.Controls.Add(this.IM_AName);
            this.panel_testinfos.Controls.Add(this.MF_AName);
            this.panel_testinfos.Controls.Add(this.BA);
            this.panel_testinfos.Controls.Add(this.PVpv);
            this.panel_testinfos.Controls.Add(this.Projektnummer);
            this.panel_testinfos.Controls.Add(this.IM_SN);
            this.panel_testinfos.Controls.Add(this.IM_AN);
            this.panel_testinfos.Controls.Add(this.MF_SN);
            this.panel_testinfos.Controls.Add(this.MF_AN);
            this.panel_testinfos.Controls.Add(this.kuhlungsart);
            this.panel_testinfos.Controls.Add(this.sonstBemerkungen);
            this.panel_testinfos.Controls.Add(this.P_Dauer);
            this.panel_testinfos.Controls.Add(this.energie);
            this.panel_testinfos.Controls.Add(this.I_MAG);
            this.panel_testinfos.Controls.Add(this.U_IM);
            this.panel_testinfos.Location = new System.Drawing.Point(12, 56);
            this.panel_testinfos.Name = "panel_testinfos";
            this.panel_testinfos.Size = new System.Drawing.Size(404, 508);
            this.panel_testinfos.TabIndex = 130;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(12, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(188, 18);
            this.label24.TabIndex = 131;
            this.label24.Text = "Allgemeine Informationen";
            // 
            // panel_vorgabepar
            // 
            this.panel_vorgabepar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_vorgabepar.Controls.Add(this.label41);
            this.panel_vorgabepar.Controls.Add(this.T3_checkBox);
            this.panel_vorgabepar.Controls.Add(this.T2_checkBox);
            this.panel_vorgabepar.Controls.Add(this.T1_checkBox);
            this.panel_vorgabepar.Controls.Add(this.lb_T8);
            this.panel_vorgabepar.Controls.Add(this.lb_T7);
            this.panel_vorgabepar.Controls.Add(this.lb_T6);
            this.panel_vorgabepar.Controls.Add(this.lb_T5);
            this.panel_vorgabepar.Controls.Add(this.lb_T4);
            this.panel_vorgabepar.Controls.Add(this.lb_T3);
            this.panel_vorgabepar.Controls.Add(this.lb_T2);
            this.panel_vorgabepar.Controls.Add(this.lb_T1);
            this.panel_vorgabepar.Controls.Add(this.T8_MAX);
            this.panel_vorgabepar.Controls.Add(this.Taktzeitvorgabe);
            this.panel_vorgabepar.Controls.Add(this.label37);
            this.panel_vorgabepar.Controls.Add(this.Testzeitvorgabe);
            this.panel_vorgabepar.Controls.Add(this.label27);
            this.panel_vorgabepar.Controls.Add(this.label38);
            this.panel_vorgabepar.Controls.Add(this.label31);
            this.panel_vorgabepar.Controls.Add(this.T1_MAX);
            this.panel_vorgabepar.Controls.Add(this.label32);
            this.panel_vorgabepar.Controls.Add(this.label43);
            this.panel_vorgabepar.Controls.Add(this.label36);
            this.panel_vorgabepar.Controls.Add(this.T7_MAX);
            this.panel_vorgabepar.Controls.Add(this.label26);
            this.panel_vorgabepar.Controls.Add(this.T2_MAX);
            this.panel_vorgabepar.Controls.Add(this.T6_MAX);
            this.panel_vorgabepar.Controls.Add(this.T5_MAX);
            this.panel_vorgabepar.Controls.Add(this.T3_MAX);
            this.panel_vorgabepar.Controls.Add(this.T8_Name);
            this.panel_vorgabepar.Controls.Add(this.T4_MAX);
            this.panel_vorgabepar.Controls.Add(this.T7_Name);
            this.panel_vorgabepar.Controls.Add(this.T1_Name);
            this.panel_vorgabepar.Controls.Add(this.T6_Name);
            this.panel_vorgabepar.Controls.Add(this.label21);
            this.panel_vorgabepar.Controls.Add(this.T8_checkBox);
            this.panel_vorgabepar.Controls.Add(this.label22);
            this.panel_vorgabepar.Controls.Add(this.T7_checkBox);
            this.panel_vorgabepar.Controls.Add(this.label23);
            this.panel_vorgabepar.Controls.Add(this.T6_checkBox);
            this.panel_vorgabepar.Controls.Add(this.T4_checkBox);
            this.panel_vorgabepar.Controls.Add(this.T5_Name);
            this.panel_vorgabepar.Controls.Add(this.label33);
            this.panel_vorgabepar.Controls.Add(this.T4_Name);
            this.panel_vorgabepar.Controls.Add(this.label34);
            this.panel_vorgabepar.Controls.Add(this.T3_Name);
            this.panel_vorgabepar.Controls.Add(this.T5_checkBox);
            this.panel_vorgabepar.Controls.Add(this.T2_Name);
            this.panel_vorgabepar.Location = new System.Drawing.Point(12, 604);
            this.panel_vorgabepar.Name = "panel_vorgabepar";
            this.panel_vorgabepar.Size = new System.Drawing.Size(404, 313);
            this.panel_vorgabepar.TabIndex = 132;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(181, 9);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(164, 16);
            this.label41.TabIndex = 141;
            this.label41.Text = "(Zeit mit Komma eingeben)";
            // 
            // T3_checkBox
            // 
            this.T3_checkBox.AutoSize = true;
            this.T3_checkBox.Checked = true;
            this.T3_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.T3_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T3_checkBox.Location = new System.Drawing.Point(67, 142);
            this.T3_checkBox.Name = "T3_checkBox";
            this.T3_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T3_checkBox.TabIndex = 140;
            this.T3_checkBox.UseVisualStyleBackColor = true;
            // 
            // T2_checkBox
            // 
            this.T2_checkBox.AutoSize = true;
            this.T2_checkBox.Checked = true;
            this.T2_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.T2_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T2_checkBox.Location = new System.Drawing.Point(67, 117);
            this.T2_checkBox.Name = "T2_checkBox";
            this.T2_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T2_checkBox.TabIndex = 139;
            this.T2_checkBox.UseVisualStyleBackColor = true;
            // 
            // T1_checkBox
            // 
            this.T1_checkBox.AutoSize = true;
            this.T1_checkBox.Checked = true;
            this.T1_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.T1_checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1_checkBox.Location = new System.Drawing.Point(67, 91);
            this.T1_checkBox.Name = "T1_checkBox";
            this.T1_checkBox.Size = new System.Drawing.Size(15, 14);
            this.T1_checkBox.TabIndex = 138;
            this.T1_checkBox.UseVisualStyleBackColor = true;
            // 
            // lb_T8
            // 
            this.lb_T8.AutoSize = true;
            this.lb_T8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T8.Location = new System.Drawing.Point(357, 273);
            this.lb_T8.Name = "lb_T8";
            this.lb_T8.Size = new System.Drawing.Size(24, 15);
            this.lb_T8.TabIndex = 137;
            this.lb_T8.Text = "T8";
            // 
            // lb_T7
            // 
            this.lb_T7.AutoSize = true;
            this.lb_T7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T7.Location = new System.Drawing.Point(357, 246);
            this.lb_T7.Name = "lb_T7";
            this.lb_T7.Size = new System.Drawing.Size(24, 15);
            this.lb_T7.TabIndex = 136;
            this.lb_T7.Text = "T7";
            // 
            // lb_T6
            // 
            this.lb_T6.AutoSize = true;
            this.lb_T6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T6.Location = new System.Drawing.Point(357, 220);
            this.lb_T6.Name = "lb_T6";
            this.lb_T6.Size = new System.Drawing.Size(24, 15);
            this.lb_T6.TabIndex = 135;
            this.lb_T6.Text = "T6";
            // 
            // lb_T5
            // 
            this.lb_T5.AutoSize = true;
            this.lb_T5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T5.Location = new System.Drawing.Point(357, 195);
            this.lb_T5.Name = "lb_T5";
            this.lb_T5.Size = new System.Drawing.Size(24, 15);
            this.lb_T5.TabIndex = 134;
            this.lb_T5.Text = "T5";
            // 
            // lb_T4
            // 
            this.lb_T4.AutoSize = true;
            this.lb_T4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T4.Location = new System.Drawing.Point(357, 168);
            this.lb_T4.Name = "lb_T4";
            this.lb_T4.Size = new System.Drawing.Size(24, 15);
            this.lb_T4.TabIndex = 133;
            this.lb_T4.Text = "T4";
            // 
            // lb_T3
            // 
            this.lb_T3.AutoSize = true;
            this.lb_T3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T3.Location = new System.Drawing.Point(357, 142);
            this.lb_T3.Name = "lb_T3";
            this.lb_T3.Size = new System.Drawing.Size(24, 15);
            this.lb_T3.TabIndex = 132;
            this.lb_T3.Text = "T3";
            // 
            // lb_T2
            // 
            this.lb_T2.AutoSize = true;
            this.lb_T2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T2.Location = new System.Drawing.Point(357, 117);
            this.lb_T2.Name = "lb_T2";
            this.lb_T2.Size = new System.Drawing.Size(24, 15);
            this.lb_T2.TabIndex = 131;
            this.lb_T2.Text = "T2";
            // 
            // lb_T1
            // 
            this.lb_T1.AutoSize = true;
            this.lb_T1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_T1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T1.Location = new System.Drawing.Point(357, 90);
            this.lb_T1.Name = "lb_T1";
            this.lb_T1.Size = new System.Drawing.Size(24, 15);
            this.lb_T1.TabIndex = 130;
            this.lb_T1.Text = "T1";
            // 
            // panel_steuerdt
            // 
            this.panel_steuerdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_steuerdt.Controls.Add(this.btn_Entw);
            this.panel_steuerdt.Controls.Add(this.btn_TempQuit);
            this.panel_steuerdt.Controls.Add(this.btn_IM_OFF);
            this.panel_steuerdt.Controls.Add(this.btn_IM_ON);
            this.panel_steuerdt.Controls.Add(this.IMon_Override);
            this.panel_steuerdt.Controls.Add(this.RG_Kühlung);
            this.panel_steuerdt.Controls.Add(this.Druckluft_Kuhlung);
            this.panel_steuerdt.Controls.Add(this.btn_Fortsetzen);
            this.panel_steuerdt.Controls.Add(this.btn_StartTest);
            this.panel_steuerdt.Controls.Add(this.btn_StopTest);
            this.panel_steuerdt.Controls.Add(this.btn_Pause);
            this.panel_steuerdt.Location = new System.Drawing.Point(436, 56);
            this.panel_steuerdt.Name = "panel_steuerdt";
            this.panel_steuerdt.Size = new System.Drawing.Size(582, 187);
            this.panel_steuerdt.TabIndex = 133;
            // 
            // btn_Entw
            // 
            this.btn_Entw.Location = new System.Drawing.Point(456, 11);
            this.btn_Entw.Name = "btn_Entw";
            this.btn_Entw.Size = new System.Drawing.Size(112, 20);
            this.btn_Entw.TabIndex = 115;
            this.btn_Entw.UseVisualStyleBackColor = true;
            this.btn_Entw.Click += new System.EventHandler(this.btn_Entw_Click);
            // 
            // btn_TempQuit
            // 
            this.btn_TempQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_TempQuit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_TempQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TempQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_TempQuit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TempQuit.Location = new System.Drawing.Point(367, 133);
            this.btn_TempQuit.Name = "btn_TempQuit";
            this.btn_TempQuit.Size = new System.Drawing.Size(201, 40);
            this.btn_TempQuit.TabIndex = 114;
            this.btn_TempQuit.Text = "Temperatur quittieren";
            this.btn_TempQuit.UseVisualStyleBackColor = false;
            this.btn_TempQuit.Click += new System.EventHandler(this.btn_TempQuit_Click);
            // 
            // panel_gemtestdaten
            // 
            this.panel_gemtestdaten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_gemtestdaten.Controls.Add(this.Testdauerlabel);
            this.panel_gemtestdaten.Controls.Add(this.label28);
            this.panel_gemtestdaten.Controls.Add(this.label29);
            this.panel_gemtestdaten.Controls.Add(this.label1);
            this.panel_gemtestdaten.Controls.Add(this.label2);
            this.panel_gemtestdaten.Location = new System.Drawing.Point(436, 275);
            this.panel_gemtestdaten.Name = "panel_gemtestdaten";
            this.panel_gemtestdaten.Size = new System.Drawing.Size(582, 73);
            this.panel_gemtestdaten.TabIndex = 134;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(433, 254);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(168, 18);
            this.label39.TabIndex = 135;
            this.label39.Text = "Gemessene Testdaten";
            // 
            // panel_status
            // 
            this.panel_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_status.Controls.Add(this.pnl_StatusFarbe);
            this.panel_status.Controls.Add(this.label30);
            this.panel_status.Controls.Add(this.Datumslabel);
            this.panel_status.Controls.Add(this.lbl_ConnectInfo);
            this.panel_status.Controls.Add(this.btn_Close);
            this.panel_status.Controls.Add(this.pictureBox1);
            this.panel_status.Location = new System.Drawing.Point(1027, 56);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(581, 292);
            this.panel_status.TabIndex = 136;
            // 
            // pnl_StatusFarbe
            // 
            this.pnl_StatusFarbe.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnl_StatusFarbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_StatusFarbe.Controls.Add(this.Statusbox);
            this.pnl_StatusFarbe.Location = new System.Drawing.Point(17, 63);
            this.pnl_StatusFarbe.Name = "pnl_StatusFarbe";
            this.pnl_StatusFarbe.Size = new System.Drawing.Size(542, 166);
            this.pnl_StatusFarbe.TabIndex = 122;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(1024, 35);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 18);
            this.label40.TabIndex = 137;
            this.label40.Text = "Status";
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1608, 24);
            this.menuStrip1.TabIndex = 138;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opendataMenu,
            this.savedataMenu});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            this.dateiToolStripMenuItem.Click += new System.EventHandler(this.dateiToolStripMenuItem_Click);
            // 
            // opendataMenu
            // 
            this.opendataMenu.Name = "opendataMenu";
            this.opendataMenu.Size = new System.Drawing.Size(210, 22);
            this.opendataMenu.Text = "Datensatz öffnen";
            this.opendataMenu.Click += new System.EventHandler(this.opendataMenu_Click);
            // 
            // savedataMenu
            // 
            this.savedataMenu.Name = "savedataMenu";
            this.savedataMenu.Size = new System.Drawing.Size(210, 22);
            this.savedataMenu.Text = "Datensatz speichern unter";
            this.savedataMenu.Click += new System.EventHandler(this.savedataMenu_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationenZuMPSDT2020ToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // informationenZuMPSDT2020ToolStripMenuItem
            // 
            this.informationenZuMPSDT2020ToolStripMenuItem.Name = "informationenZuMPSDT2020ToolStripMenuItem";
            this.informationenZuMPSDT2020ToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.informationenZuMPSDT2020ToolStripMenuItem.Text = "Informationen zu MPS-DT-2020";
            this.informationenZuMPSDT2020ToolStripMenuItem.Click += new System.EventHandler(this.informationenZuMPSDT2020ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1604, 881);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel_testinfos);
            this.Controls.Add(this.panel_vorgabepar);
            this.Controls.Add(this.panel_steuerdt);
            this.Controls.Add(this.panel_gemtestdaten);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "MPS-DT-2020_V02j";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_testinfos.ResumeLayout(false);
            this.panel_testinfos.PerformLayout();
            this.panel_vorgabepar.ResumeLayout(false);
            this.panel_vorgabepar.PerformLayout();
            this.panel_steuerdt.ResumeLayout(false);
            this.panel_steuerdt.PerformLayout();
            this.panel_gemtestdaten.ResumeLayout(false);
            this.panel_gemtestdaten.PerformLayout();
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.pnl_StatusFarbe.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_ConnectInfo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_StartTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_StopTest;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Button btn_Fortsetzen;
        private System.Windows.Forms.Button btn_IM_ON;
        private System.Windows.Forms.Button btn_IM_OFF;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private PictureBox pictureBox1;
        private CheckBox RG_Kühlung;
        private CheckBox Druckluft_Kuhlung;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox Projektnummer;
        private TextBox PVpv;
        private TextBox BA;
        private TextBox bearbeiter;
        private TextBox MF_AN;
        private TextBox MF_SN;
        private TextBox IM_AN;
        private TextBox IM_SN;
        private TextBox U_IM;
        private TextBox I_MAG;
        private TextBox energie;
        private TextBox P_Dauer;
        private TextBox sonstBemerkungen;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox T1_Name;
        private TextBox Testzeitvorgabe;
        private TextBox Taktzeitvorgabe;
        private ComboBox kuhlungsart;
        private ComboBox MF_AName;
        private ComboBox IM_AName;
        private Label label28;
        private Label label29;
        private Label label30;
        private CheckBox T4_checkBox;
        private Label label33;
        private Label label34;
        private CheckBox T5_checkBox;
        private TextBox T2_Name;
        private TextBox T3_Name;
        private TextBox T4_Name;
        private TextBox T5_Name;
        private CheckBox T6_checkBox;
        private CheckBox T7_checkBox;
        private CheckBox T8_checkBox;
        private TextBox T6_Name;
        private TextBox T7_Name;
        private TextBox T8_Name;
        private TextBox T1_MAX;
        private TextBox T2_MAX;
        private TextBox T3_MAX;
        private TextBox T4_MAX;
        private TextBox T5_MAX;
        private TextBox T6_MAX;
        private TextBox T7_MAX;
        private TextBox T8_MAX;
        private Label label43;
        private Label Statusbox;
        private CheckBox IMon_Override;
        private ComboBox Testobjekt;
        private Label label25;
        private Label label35;
        private Label Datumslabel;
        private Label Testdauerlabel;
        private Label label26;
        private Label label27;
        private Label label31;
        private Label label32;
        private Label label36;
        private Label label37;
        private Label label38;
        private Panel panel_testinfos;
        private Label label24;
        private Panel panel_vorgabepar;
        private Panel panel_steuerdt;
        private Panel panel_gemtestdaten;
        private Label label39;
        private Panel panel_status;
        private Label label40;
        private Timer timer2;
        private Panel pnl_StatusFarbe;
        private Timer timer3;
        private Label lb_T8;
        private Label lb_T7;
        private Label lb_T6;
        private Label lb_T5;
        private Label lb_T4;
        private Label lb_T3;
        private Label lb_T2;
        private Label lb_T1;
        private Timer timer4;
        private Button btn_TempQuit;
        private CheckBox T1_checkBox;
        private CheckBox T3_checkBox;
        private CheckBox T2_checkBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem opendataMenu;
        private ToolStripMenuItem savedataMenu;
        private ToolStripMenuItem hilfeToolStripMenuItem;
        private ToolStripMenuItem informationenZuMPSDT2020ToolStripMenuItem;
        private Label label41;
        private Button btn_Entw;
    }
}




//using System.Windows.Forms.DataVisualization.Charting;
//using System.Windows.Forms;
//namespace MPS_DT_2020_V00
//{
//    partial class FormMain
//    {
//        /// <summary>
//        /// Erforderliche Designervariable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Verwendete Ressourcen bereinigen.
//        /// </summary>
//        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Vom Windows Form-Designer generierter Code

//        /// <summary>
//        /// Erforderliche Methode für die Designerunterstützung.
//        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
//            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
//            this.lbl_ConnectInfo = new System.Windows.Forms.Label();
//            this.btn_Close = new System.Windows.Forms.Button();
//            this.btn_StartTest = new System.Windows.Forms.Button();
//            this.label1 = new System.Windows.Forms.Label();
//            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
//            this.btn_StopTest = new System.Windows.Forms.Button();
//            this.btn_Pause = new System.Windows.Forms.Button();
//            this.btn_Fortsetzen = new System.Windows.Forms.Button();
//            this.btn_IM_ON = new System.Windows.Forms.Button();
//            this.btn_IM_OFF = new System.Windows.Forms.Button();
//            this.timer1 = new System.Windows.Forms.Timer(this.components);
//            this.label2 = new System.Windows.Forms.Label();
//            this.pictureBox1 = new System.Windows.Forms.PictureBox();

//            this.label3 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.label12 = new System.Windows.Forms.Label();
//            this.label13 = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.label15 = new System.Windows.Forms.Label();
//            this.label16 = new System.Windows.Forms.Label();
//            this.label17 = new System.Windows.Forms.Label();
//            this.label18 = new System.Windows.Forms.Label();
//            this.label19 = new System.Windows.Forms.Label();
//            this.label20 = new System.Windows.Forms.Label();
//            this.label21 = new System.Windows.Forms.Label();
//            this.label22 = new System.Windows.Forms.Label();
//            this.label23 = new System.Windows.Forms.Label();
//            this.label24 = new System.Windows.Forms.Label();
//            this.label25 = new System.Windows.Forms.Label();

//            this.label28 = new System.Windows.Forms.Label();
//            this.label29 = new System.Windows.Forms.Label();
//            this.label30 = new System.Windows.Forms.Label();
//            this.label35 = new System.Windows.Forms.Label();
//            this.label43 = new System.Windows.Forms.Label();



//            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // lbl_ConnectInfo
//            // 
//            this.lbl_ConnectInfo.AutoSize = true;
//            this.lbl_ConnectInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lbl_ConnectInfo.Location = new System.Drawing.Point(806, 139);
//            this.lbl_ConnectInfo.Name = "lbl_ConnectInfo";
//            this.lbl_ConnectInfo.Size = new System.Drawing.Size(92, 19);
//            this.lbl_ConnectInfo.TabIndex = 3;
//            this.lbl_ConnectInfo.Text = "ConnectInfo";
//            // 
//            // btn_Close
//            // 
//            this.btn_Close.Location = new System.Drawing.Point(1573, 12);
//            this.btn_Close.Name = "btn_Close";
//            this.btn_Close.Size = new System.Drawing.Size(75, 23);
//            this.btn_Close.TabIndex = 4;
//            this.btn_Close.Text = "Schließen";
//            this.btn_Close.UseVisualStyleBackColor = true;
//            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
//            // 
//            // btn_StartTest
//            // 
//            this.btn_StartTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_StartTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_StartTest.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_StartTest.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_StartTest.Location = new System.Drawing.Point(522, 197);
//            this.btn_StartTest.Name = "btn_StartTest";
//            this.btn_StartTest.Size = new System.Drawing.Size(115, 73);
//            this.btn_StartTest.TabIndex = 5;
//            this.btn_StartTest.Text = "Start ";
//            this.btn_StartTest.UseVisualStyleBackColor = false;
//            this.btn_StartTest.Click += new System.EventHandler(this.btn_StartTest_Click);
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(975, 325);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(131, 19);
//            this.label1.TabIndex = 7;
//            this.label1.Text = "Anzahl Messungen";
//            // 
//            // chart1
//            // 
//            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this.chart1.BackColor = System.Drawing.Color.Transparent;
//            this.chart1.BackSecondaryColor = System.Drawing.Color.LightSkyBlue;
//            this.chart1.BorderlineColor = System.Drawing.Color.LightSkyBlue;
//            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
//            this.chart1.BorderlineWidth = 2;
//            chartArea2.Name = "ChartArea1";
//            this.chart1.ChartAreas.Add(chartArea2);
//            legend2.Name = "Legend1";
//            this.chart1.Legends.Add(legend2);
//            this.chart1.Location = new System.Drawing.Point(508, 379);
//            this.chart1.Name = "chart1";
//            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
//            this.chart1.Size = new System.Drawing.Size(1148, 624);
//            this.chart1.TabIndex = 8;
//            this.chart1.Text = "TEMPERATUREN";
//            // 
//            // btn_StopTest
//            // 
//            this.btn_StopTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_StopTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_StopTest.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_StopTest.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_StopTest.Location = new System.Drawing.Point(764, 197);
//            this.btn_StopTest.Name = "btn_StopTest";
//            this.btn_StopTest.Size = new System.Drawing.Size(115, 73);
//            this.btn_StopTest.TabIndex = 11;
//            this.btn_StopTest.Text = "Stop";
//            this.btn_StopTest.UseVisualStyleBackColor = false;
//            this.btn_StopTest.Click += new System.EventHandler(this.btn_StopTest_Click);
//            // 
//            // btn_Pause
//            // 
//            this.btn_Pause.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_Pause.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_Pause.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_Pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_Pause.Location = new System.Drawing.Point(643, 197);
//            this.btn_Pause.Name = "btn_Pause";
//            this.btn_Pause.Size = new System.Drawing.Size(115, 73);
//            this.btn_Pause.TabIndex = 12;
//            this.btn_Pause.Text = "Pause";
//            this.btn_Pause.UseVisualStyleBackColor = false;
//            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
//            // 
//            // btn_Fortsetzen
//            // 
//            this.btn_Fortsetzen.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_Fortsetzen.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_Fortsetzen.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_Fortsetzen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_Fortsetzen.Location = new System.Drawing.Point(885, 197);
//            this.btn_Fortsetzen.Name = "btn_Fortsetzen";
//            this.btn_Fortsetzen.Size = new System.Drawing.Size(115, 73);
//            this.btn_Fortsetzen.TabIndex = 13;
//            this.btn_Fortsetzen.Text = "Fortsetzen";
//            this.btn_Fortsetzen.UseVisualStyleBackColor = false;
//            this.btn_Fortsetzen.Click += new System.EventHandler(this.btn_Fortsetzen_Click);
//            // 
//            // btn_IM_ON
//            // 
//            this.btn_IM_ON.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_IM_ON.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_IM_ON.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_IM_ON.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_IM_ON.Location = new System.Drawing.Point(522, 139);
//            this.btn_IM_ON.Name = "btn_IM_ON";
//            this.btn_IM_ON.Size = new System.Drawing.Size(115, 35);
//            this.btn_IM_ON.TabIndex = 16;
//            this.btn_IM_ON.Text = "IM On";
//            this.btn_IM_ON.UseVisualStyleBackColor = false;
//            this.btn_IM_ON.Click += new System.EventHandler(this.btn_IM_ON_Click);
//            // 
//            // btn_IM_OFF
//            // 
//            this.btn_IM_OFF.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.btn_IM_OFF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
//            this.btn_IM_OFF.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btn_IM_OFF.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btn_IM_OFF.Location = new System.Drawing.Point(643, 139);
//            this.btn_IM_OFF.Name = "btn_IM_OFF";
//            this.btn_IM_OFF.Size = new System.Drawing.Size(115, 35);
//            this.btn_IM_OFF.TabIndex = 17;
//            this.btn_IM_OFF.Text = "IM Off";
//            this.btn_IM_OFF.UseVisualStyleBackColor = false;
//            this.btn_IM_OFF.Click += new System.EventHandler(this.btn_IM_OFF_Click);
//            // 
//            // timer1
//            // 
//            this.timer1.Interval = 5000;
//            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(1170, 325);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(107, 19);
//            this.label2.TabIndex = 18;
//            this.label2.Text = "Anzahl Impulse";
//            // 
//            // pictureBox1
//            // 
//            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
//            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
//            this.pictureBox1.Location = new System.Drawing.Point(1062, 3);
//            this.pictureBox1.Name = "pictureBox1";
//            this.pictureBox1.Size = new System.Drawing.Size(505, 102);
//            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
//            this.pictureBox1.TabIndex = 19;
//            this.pictureBox1.TabStop = false;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.Location = new System.Drawing.Point(65, 64);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(111, 19);
//            this.label3.TabIndex = 25;
//            this.label3.Text = "Projektnummer:";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.Location = new System.Drawing.Point(126, 89);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(50, 19);
//            this.label4.TabIndex = 26;
//            this.label4.Text = "PV/pv:";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
//            this.label5.Location = new System.Drawing.Point(125, 27);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(276, 29);
//            this.label5.TabIndex = 27;
//            this.label5.Text = "Dauertest-Dokumentation";
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.Location = new System.Drawing.Point(62, 115);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(114, 19);
//            this.label6.TabIndex = 28;
//            this.label6.Text = "Betriebsauftrag:";
//            // 
//            // label7
//            // 
//            this.label7.AutoSize = true;
//            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label7.Location = new System.Drawing.Point(93, 141);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(81, 19);
//            this.label7.TabIndex = 29;
//            this.label7.Text = "Bearbeiter:";
//            // 
//            // label8
//            // 
//            this.label8.AutoSize = true;
//            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label8.Location = new System.Drawing.Point(62, 193);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(114, 19);
//            this.label8.TabIndex = 30;
//            this.label8.Text = "MF Artikelname:";
//            // 
//            // label9
//            // 
//            this.label9.AutoSize = true;
//            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label9.Location = new System.Drawing.Point(74, 220);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(100, 19);
//            this.label9.TabIndex = 31;
//            this.label9.Text = "MF Artikel-Nr.:";
//            // 
//            // label10
//            // 
//            this.label10.AutoSize = true;
//            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label10.Location = new System.Drawing.Point(75, 248);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(99, 19);
//            this.label10.TabIndex = 32;
//            this.label10.Text = "MF Serien-Nr.:";
//            // 
//            // label11
//            // 
//            this.label11.AutoSize = true;
//            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label11.Location = new System.Drawing.Point(62, 272);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(111, 19);
//            this.label11.TabIndex = 33;
//            this.label11.Text = "IM Artikelname:";
//            // 
//            // label12
//            // 
//            this.label12.AutoSize = true;
//            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label12.Location = new System.Drawing.Point(76, 299);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(97, 19);
//            this.label12.TabIndex = 34;
//            this.label12.Text = "IM Artikel-Nr.:";
//            // 
//            // label13
//            // 
//            this.label13.AutoSize = true;
//            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label13.Location = new System.Drawing.Point(77, 325);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(96, 19);
//            this.label13.TabIndex = 35;
//            this.label13.Text = "IM Serien-Nr.:";
//            // 
//            // label14
//            // 
//            this.label14.AutoSize = true;
//            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label14.Location = new System.Drawing.Point(13, 351);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(163, 19);
//            this.label14.TabIndex = 36;
//            this.label14.Text = "Ladespannung U [VDC]:";
//            // 
//            // label15
//            // 
//            this.label15.AutoSize = true;
//            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label15.Location = new System.Drawing.Point(10, 379);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(166, 19);
//            this.label15.TabIndex = 37;
//            this.label15.Text = "Magnetisierstrom I [kA]:";
//            // 
//            // label16
//            // 
//            this.label16.AutoSize = true;
//            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label16.Location = new System.Drawing.Point(68, 403);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(108, 19);
//            this.label16.TabIndex = 38;
//            this.label16.Text = "Energie E [Ws]:";
//            // 
//            // label17
//            // 
//            this.label17.AutoSize = true;
//            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label17.Location = new System.Drawing.Point(32, 429);
//            this.label17.Name = "label17";
//            this.label17.Size = new System.Drawing.Size(144, 19);
//            this.label17.TabIndex = 39;
//            this.label17.Text = "Dauerleistung P [W]:";
//            // 
//            // label18
//            // 
//            this.label18.AutoSize = true;
//            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label18.Location = new System.Drawing.Point(36, 456);
//            this.label18.Name = "label18";
//            this.label18.Size = new System.Drawing.Size(138, 19);
//            this.label18.TabIndex = 40;
//            this.label18.Text = "Verwandte Kühlung:";
//            // 
//            // label19
//            // 
//            this.label19.AutoSize = true;
//            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label19.Location = new System.Drawing.Point(13, 482);
//            this.label19.Name = "label19";
//            this.label19.Size = new System.Drawing.Size(161, 19);
//            this.label19.TabIndex = 41;
//            this.label19.Text = "Sonstige Bemerkungen:";
//            // 
//            // label20
//            // 
//            this.label20.AutoSize = true;
//            this.label20.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label20.ForeColor = System.Drawing.Color.SteelBlue;
//            this.label20.Location = new System.Drawing.Point(137, 591);
//            this.label20.Name = "label20";
//            this.label20.Size = new System.Drawing.Size(307, 29);
//            this.label20.TabIndex = 58;
//            this.label20.Text = "Dauertest-Vorgabeparameter";
//            // 
//            // label21
//            // 
//            this.label21.AutoSize = true;
//            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label21.Location = new System.Drawing.Point(87, 628);
//            this.label21.Name = "label21";
//            this.label21.Size = new System.Drawing.Size(84, 19);
//            this.label21.TabIndex = 59;
//            this.label21.Text = "Taktzeit [s]:";
//            // 
//            // label22
//            // 
//            this.label22.AutoSize = true;
//            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label22.Location = new System.Drawing.Point(85, 654);
//            this.label22.Name = "label22";
//            this.label22.Size = new System.Drawing.Size(85, 19);
//            this.label22.TabIndex = 60;
//            this.label22.Text = "Testzeit [h]:";
//            // 
//            // label23
//            // 
//            this.label23.AutoSize = true;
//            this.label23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label23.Location = new System.Drawing.Point(110, 766);
//            this.label23.Name = "label23";
//            this.label23.Size = new System.Drawing.Size(57, 19);
//            this.label23.TabIndex = 61;
//            this.label23.Text = "T1 [°C]:";
//            // 
//            // label25
//            // 
//            this.label25.AutoSize = true;
//            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label25.Location = new System.Drawing.Point(94, 167);
//            this.label25.Name = "label25";
//            this.label25.Size = new System.Drawing.Size(80, 19);
//            this.label25.TabIndex = 115;
//            this.label25.Text = "Testobjekt:";
//            //this.label25.Click += new System.EventHandler(this.label25_Click);
//            // 
//            // label28
//            // 
//            this.label28.AutoSize = true;
//            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label28.Location = new System.Drawing.Point(1340, 326);
//            this.label28.Name = "label28";
//            this.label28.Size = new System.Drawing.Size(125, 19);
//            this.label28.TabIndex = 73;
//            this.label28.Text = "Reale Taktzeit [s]:";
//            //this.label28.Click += new System.EventHandler(this.label28_Click);
//            // 
//            // label29
//            // 
//            this.label29.AutoSize = true;
//            this.label29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label29.Location = new System.Drawing.Point(639, 326);
//            this.label29.Name = "label29";
//            this.label29.Size = new System.Drawing.Size(200, 19);
//            this.label29.TabIndex = 74;
//            this.label29.Text = "Bisherige Testdauer [hh:mm]:";
//            // 
//            // label30
//            // 
//            this.label30.AutoSize = true;
//            this.label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label30.Location = new System.Drawing.Point(91, 990);
//            this.label30.Name = "label30";
//            this.label30.Size = new System.Drawing.Size(378, 19);
//            this.label30.TabIndex = 75;
//            this.label30.Text = "Pfad der .CSV-Datei: C\\MPS-Dauertest\\ArtikeNr.\\SerienNr.";
//            // 
//            // label35
//            // 
//            this.label35.AutoSize = true;
//            this.label35.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label35.ForeColor = System.Drawing.Color.SteelBlue;
//            this.label35.Location = new System.Drawing.Point(613, 77);
//            this.label35.Name = "label35";
//            this.label35.Size = new System.Drawing.Size(285, 29);
//            this.label35.TabIndex = 117;
//            this.label35.Text = "Steuerung Dauertestanlage";
//            // 
//            // label43
//            // 
//            this.label43.AutoSize = true;
//            this.label43.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label43.Location = new System.Drawing.Point(412, 745);
//            this.label43.Name = "label43";
//            this.label43.Size = new System.Drawing.Size(43, 19);
//            this.label43.TabIndex = 111;
//            this.label43.Text = "MAX.";
//            //this.label43.Click += new System.EventHandler(this.label43_Click);
//            // 
//            // FormMain
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
//            this.ClientSize = new System.Drawing.Size(1664, 1011);
//            this.Controls.Add(this.pictureBox1);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.btn_IM_OFF);
//            this.Controls.Add(this.btn_IM_ON);
//            this.Controls.Add(this.btn_Fortsetzen);
//            this.Controls.Add(this.btn_Pause);
//            this.Controls.Add(this.btn_StopTest);
//            this.Controls.Add(this.chart1);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.btn_StartTest);
//            this.Controls.Add(this.btn_Close);
//            this.Controls.Add(this.lbl_ConnectInfo);
//            // Dauertestdokumentation
//            this.Controls.Add(this.label24);
//            this.Controls.Add(this.label23);
//            this.Controls.Add(this.label22);
//            this.Controls.Add(this.label21);
//            this.Controls.Add(this.label20);
//            this.Controls.Add(this.label19);
//            this.Controls.Add(this.label18);
//            this.Controls.Add(this.label17);
//            this.Controls.Add(this.label16);
//            this.Controls.Add(this.label15);
//            this.Controls.Add(this.label14);
//            this.Controls.Add(this.label13);
//            this.Controls.Add(this.label12);
//            this.Controls.Add(this.label11);
//            this.Controls.Add(this.label10);
//            this.Controls.Add(this.label9);
//            this.Controls.Add(this.label8);
//            this.Controls.Add(this.label7);
//            this.Controls.Add(this.label6);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.label4);
//            this.Controls.Add(this.label3);

//            this.Controls.Add(this.label28);
//            this.Controls.Add(this.label29);
//            this.Controls.Add(this.label30);
//            this.Controls.Add(this.label43);

//            this.Name = "FormMain";
//            this.Text = "MPS-DT-2020_V00";
//            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion
//        private System.Windows.Forms.Label lbl_ConnectInfo;
//        private System.Windows.Forms.Button btn_Close;
//        private System.Windows.Forms.Button btn_StartTest;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
//        private System.Windows.Forms.Button btn_StopTest;
//        private System.Windows.Forms.Button btn_Pause;
//        private System.Windows.Forms.Button btn_Fortsetzen;
//        private System.Windows.Forms.Button btn_IM_ON;
//        private System.Windows.Forms.Button btn_IM_OFF;
//        private System.Windows.Forms.Timer timer1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.PictureBox pictureBox1;

//        private Label label3;
//        private Label label4;
//        private Label label5;
//        private Label label6;
//        private Label label7;
//        private Label label8;
//        private Label label9;
//        private Label label10;
//        private Label label11;
//        private Label label12;
//        private Label label13;
//        private Label label14;
//        private Label label15;
//        private Label label16;
//        private Label label17;
//        private Label label18;
//        private Label label19;
//        private Label label20;
//        private Label label21;
//        private Label label22;
//        private Label label23;
//        private Label label24;
//        private Label label25;
//        private Label label28;
//        private Label label29;
//        private Label label30;
//        private Label label35;
//        private Label label43;
//    }
//}

