namespace AVNC
{
    partial class MainFrm
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.viewOnlyCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnIPv4 = new System.Windows.Forms.RadioButton();
            this.radioBtnIPv6 = new System.Windows.Forms.RadioButton();
            this.minimizeWindowCB = new System.Windows.Forms.CheckBox();
            this.startListeningCB = new System.Windows.Forms.CheckBox();
            this.windowsStartupCB = new System.Windows.Forms.CheckBox();
            this.loginPasswordTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listenPortTB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.errorCB = new System.Windows.Forms.CheckBox();
            this.keystrokeCB = new System.Windows.Forms.CheckBox();
            this.mouseActionCB = new System.Windows.Forms.CheckBox();
            this.imageReqCB = new System.Windows.Forms.CheckBox();
            this.updateCB = new System.Windows.Forms.CheckBox();
            this.indexReqCB = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.logLV = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.LogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listenPortTB)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.LogMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 291);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.viewOnlyCB);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.minimizeWindowCB);
            this.tabPage1.Controls.Add(this.startListeningCB);
            this.tabPage1.Controls.Add(this.windowsStartupCB);
            this.tabPage1.Controls.Add(this.loginPasswordTB);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listenPortTB);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // viewOnlyCB
            // 
            this.viewOnlyCB.AutoSize = true;
            this.viewOnlyCB.Checked = true;
            this.viewOnlyCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewOnlyCB.Location = new System.Drawing.Point(9, 150);
            this.viewOnlyCB.Name = "viewOnlyCB";
            this.viewOnlyCB.Size = new System.Drawing.Size(71, 17);
            this.viewOnlyCB.TabIndex = 11;
            this.viewOnlyCB.Text = "View only";
            this.viewOnlyCB.UseVisualStyleBackColor = true;
            this.viewOnlyCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnIPv4);
            this.groupBox1.Controls.Add(this.radioBtnIPv6);
            this.groupBox1.Location = new System.Drawing.Point(196, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Version";
            // 
            // radioBtnIPv4
            // 
            this.radioBtnIPv4.AutoSize = true;
            this.radioBtnIPv4.Checked = true;
            this.radioBtnIPv4.Location = new System.Drawing.Point(11, 23);
            this.radioBtnIPv4.Name = "radioBtnIPv4";
            this.radioBtnIPv4.Size = new System.Drawing.Size(47, 17);
            this.radioBtnIPv4.TabIndex = 8;
            this.radioBtnIPv4.TabStop = true;
            this.radioBtnIPv4.Text = "IPv4";
            this.radioBtnIPv4.UseVisualStyleBackColor = true;
            this.radioBtnIPv4.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // radioBtnIPv6
            // 
            this.radioBtnIPv6.AutoSize = true;
            this.radioBtnIPv6.Location = new System.Drawing.Point(64, 23);
            this.radioBtnIPv6.Name = "radioBtnIPv6";
            this.radioBtnIPv6.Size = new System.Drawing.Size(47, 17);
            this.radioBtnIPv6.TabIndex = 9;
            this.radioBtnIPv6.Text = "IPv6";
            this.radioBtnIPv6.UseVisualStyleBackColor = true;
            this.radioBtnIPv6.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // minimizeWindowCB
            // 
            this.minimizeWindowCB.AutoSize = true;
            this.minimizeWindowCB.Checked = true;
            this.minimizeWindowCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeWindowCB.Location = new System.Drawing.Point(9, 127);
            this.minimizeWindowCB.Name = "minimizeWindowCB";
            this.minimizeWindowCB.Size = new System.Drawing.Size(169, 17);
            this.minimizeWindowCB.TabIndex = 7;
            this.minimizeWindowCB.Text = "Minimize window when started";
            this.minimizeWindowCB.UseVisualStyleBackColor = true;
            this.minimizeWindowCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // startListeningCB
            // 
            this.startListeningCB.AutoSize = true;
            this.startListeningCB.Checked = true;
            this.startListeningCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startListeningCB.Location = new System.Drawing.Point(9, 104);
            this.startListeningCB.Name = "startListeningCB";
            this.startListeningCB.Size = new System.Drawing.Size(153, 17);
            this.startListeningCB.TabIndex = 6;
            this.startListeningCB.Text = "Start listening when started";
            this.startListeningCB.UseVisualStyleBackColor = true;
            this.startListeningCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // windowsStartupCB
            // 
            this.windowsStartupCB.AutoSize = true;
            this.windowsStartupCB.Checked = true;
            this.windowsStartupCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.windowsStartupCB.Location = new System.Drawing.Point(9, 81);
            this.windowsStartupCB.Name = "windowsStartupCB";
            this.windowsStartupCB.Size = new System.Drawing.Size(139, 17);
            this.windowsStartupCB.TabIndex = 5;
            this.windowsStartupCB.Text = "Add to Windows startup";
            this.windowsStartupCB.UseVisualStyleBackColor = true;
            this.windowsStartupCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // loginPasswordTB
            // 
            this.loginPasswordTB.Location = new System.Drawing.Point(122, 38);
            this.loginPasswordTB.Name = "loginPasswordTB";
            this.loginPasswordTB.Size = new System.Drawing.Size(228, 20);
            this.loginPasswordTB.TabIndex = 4;
            this.loginPasswordTB.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "By default, this should be 80";
            // 
            // listenPortTB
            // 
            this.listenPortTB.Location = new System.Drawing.Point(123, 12);
            this.listenPortTB.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.listenPortTB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.listenPortTB.Name = "listenPortTB";
            this.listenPortTB.Size = new System.Drawing.Size(82, 20);
            this.listenPortTB.TabIndex = 1;
            this.listenPortTB.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listening Port:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.errorCB);
            this.tabPage2.Controls.Add(this.keystrokeCB);
            this.tabPage2.Controls.Add(this.mouseActionCB);
            this.tabPage2.Controls.Add(this.imageReqCB);
            this.tabPage2.Controls.Add(this.updateCB);
            this.tabPage2.Controls.Add(this.indexReqCB);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.logLV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 265);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // errorCB
            // 
            this.errorCB.AutoSize = true;
            this.errorCB.Checked = true;
            this.errorCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorCB.Location = new System.Drawing.Point(265, 236);
            this.errorCB.Name = "errorCB";
            this.errorCB.Size = new System.Drawing.Size(48, 17);
            this.errorCB.TabIndex = 8;
            this.errorCB.Text = "Error";
            this.errorCB.UseVisualStyleBackColor = true;
            this.errorCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // keystrokeCB
            // 
            this.keystrokeCB.AutoSize = true;
            this.keystrokeCB.Location = new System.Drawing.Point(156, 236);
            this.keystrokeCB.Name = "keystrokeCB";
            this.keystrokeCB.Size = new System.Drawing.Size(73, 17);
            this.keystrokeCB.TabIndex = 7;
            this.keystrokeCB.Text = "Keystroke";
            this.keystrokeCB.UseVisualStyleBackColor = true;
            this.keystrokeCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // mouseActionCB
            // 
            this.mouseActionCB.AutoSize = true;
            this.mouseActionCB.Location = new System.Drawing.Point(53, 236);
            this.mouseActionCB.Name = "mouseActionCB";
            this.mouseActionCB.Size = new System.Drawing.Size(91, 17);
            this.mouseActionCB.TabIndex = 6;
            this.mouseActionCB.Text = "Mouse Action";
            this.mouseActionCB.UseVisualStyleBackColor = true;
            this.mouseActionCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // imageReqCB
            // 
            this.imageReqCB.AutoSize = true;
            this.imageReqCB.Location = new System.Drawing.Point(265, 213);
            this.imageReqCB.Name = "imageReqCB";
            this.imageReqCB.Size = new System.Drawing.Size(81, 17);
            this.imageReqCB.TabIndex = 5;
            this.imageReqCB.Text = "Image Req.";
            this.imageReqCB.UseVisualStyleBackColor = true;
            this.imageReqCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // updateCB
            // 
            this.updateCB.AutoSize = true;
            this.updateCB.Location = new System.Drawing.Point(156, 213);
            this.updateCB.Name = "updateCB";
            this.updateCB.Size = new System.Drawing.Size(61, 17);
            this.updateCB.TabIndex = 4;
            this.updateCB.Text = "Update";
            this.updateCB.UseVisualStyleBackColor = true;
            this.updateCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // indexReqCB
            // 
            this.indexReqCB.AutoSize = true;
            this.indexReqCB.Checked = true;
            this.indexReqCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.indexReqCB.Location = new System.Drawing.Point(53, 213);
            this.indexReqCB.Name = "indexReqCB";
            this.indexReqCB.Size = new System.Drawing.Size(78, 17);
            this.indexReqCB.TabIndex = 3;
            this.indexReqCB.Text = "Index Req.";
            this.indexReqCB.UseVisualStyleBackColor = true;
            this.indexReqCB.CheckedChanged += new System.EventHandler(this.CBSettings_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Filter:";
            // 
            // logLV
            // 
            this.logLV.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.logLV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.logLV.ContextMenuStrip = this.LogMenu;
            this.logLV.Dock = System.Windows.Forms.DockStyle.Top;
            this.logLV.FullRowSelect = true;
            this.logLV.GridLines = true;
            this.logLV.Location = new System.Drawing.Point(3, 3);
            this.logLV.MultiSelect = false;
            this.logLV.Name = "logLV";
            this.logLV.Size = new System.Drawing.Size(370, 204);
            this.logLV.TabIndex = 1;
            this.logLV.UseCompatibleStateImageBehavior = false;
            this.logLV.View = System.Windows.Forms.View.Details;
            this.logLV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logLV_DClicked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Client IP";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time Stamp";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 112;
            // 
            // LogMenu
            // 
            this.LogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.LogMenu.Name = "LogMenu";
            this.LogMenu.Size = new System.Drawing.Size(100, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.linkLabel3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(376, 265);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(17, 73);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(98, 13);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "A-VNC Home Page";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "A-VNC v1.5.3.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AVNC.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(20, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nIcon
            // 
            this.nIcon.ContextMenuStrip = this.trayIconMenu;
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "A-VNC";
            this.nIcon.Visible = true;
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.trayIconMenu.Name = "contextMenuStrip1";
            this.trayIconMenu.Size = new System.Drawing.Size(99, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem1.Text = "Start";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(95, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem2.Text = "Exit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(283, 73);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "MIT License";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 334);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A-VNC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listenPortTB)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.LogMenu.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown listenPortTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginPasswordTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView logLV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox errorCB;
        private System.Windows.Forms.CheckBox keystrokeCB;
        private System.Windows.Forms.CheckBox mouseActionCB;
        private System.Windows.Forms.CheckBox imageReqCB;
        private System.Windows.Forms.CheckBox updateCB;
		private System.Windows.Forms.CheckBox indexReqCB;
        private System.Windows.Forms.ContextMenuStrip LogMenu;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.CheckBox startListeningCB;
        private System.Windows.Forms.CheckBox windowsStartupCB;
        private System.Windows.Forms.CheckBox minimizeWindowCB;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.RadioButton radioBtnIPv6;
        private System.Windows.Forms.RadioButton radioBtnIPv4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox viewOnlyCB;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

