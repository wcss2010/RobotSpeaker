namespace RobotSpeaker.Forms
{
    partial class ConfigUI
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
            this.tcPage = new System.Windows.Forms.TabControl();
            this.tpNormal = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbOfflineVoicePort = new System.Windows.Forms.NumericUpDown();
            this.tbOfflineVoiceIP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbOfflineVoiceYuanYuan = new System.Windows.Forms.RadioButton();
            this.rbOfflineVoiceFeiFei = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbOfflineVoiceWebSocketUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEnabledOfflineVoice = new System.Windows.Forms.CheckBox();
            this.cbEnabledCloseVideoPlayerWithVoice = new System.Windows.Forms.CheckBox();
            this.cbEnabledOnlineVoice = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbImageListPlayerSleepSeconds = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.clbGoTypes = new System.Windows.Forms.CheckedListBox();
            this.cbGoPort = new System.Windows.Forms.ComboBox();
            this.cbOfflineVoicePort = new System.Windows.Forms.ComboBox();
            this.cbOnlineVoicePort = new System.Windows.Forms.ComboBox();
            this.tbGoAppPath = new System.Windows.Forms.TextBox();
            this.tbVoiceWelcomeText = new System.Windows.Forms.TextBox();
            this.tbWebSiteUrl = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.btnInitAIUI = new System.Windows.Forms.Button();
            this.btnRestartService = new System.Windows.Forms.Button();
            this.btnCameraDir = new System.Windows.Forms.Button();
            this.btnReadmeDir = new System.Windows.Forms.Button();
            this.ofdApp = new System.Windows.Forms.OpenFileDialog();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.tbDebugHintText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.jsijoystickInfo = new RobotSpeaker.Forms.JoyAPI.JoystickStateInfo();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDebug1 = new System.Windows.Forms.Label();
            this.lblDebug2 = new System.Windows.Forms.Label();
            this.lblDebug3 = new System.Windows.Forms.Label();
            this.tcPage.SuspendLayout();
            this.tpNormal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOfflineVoicePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageListPlayerSleepSeconds)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpDebug.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPage
            // 
            this.tcPage.Controls.Add(this.tpNormal);
            this.tcPage.Controls.Add(this.tpDebug);
            this.tcPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPage.Location = new System.Drawing.Point(0, 0);
            this.tcPage.Name = "tcPage";
            this.tcPage.SelectedIndex = 0;
            this.tcPage.Size = new System.Drawing.Size(807, 678);
            this.tcPage.TabIndex = 0;
            // 
            // tpNormal
            // 
            this.tpNormal.Controls.Add(this.tbDebugHintText);
            this.tpNormal.Controls.Add(this.label15);
            this.tpNormal.Controls.Add(this.groupBox1);
            this.tpNormal.Controls.Add(this.cbEnabledOfflineVoice);
            this.tpNormal.Controls.Add(this.cbEnabledCloseVideoPlayerWithVoice);
            this.tpNormal.Controls.Add(this.cbEnabledOnlineVoice);
            this.tpNormal.Controls.Add(this.jsijoystickInfo);
            this.tpNormal.Controls.Add(this.label10);
            this.tpNormal.Controls.Add(this.tbImageListPlayerSleepSeconds);
            this.tpNormal.Controls.Add(this.label8);
            this.tpNormal.Controls.Add(this.btnSelect);
            this.tpNormal.Controls.Add(this.clbGoTypes);
            this.tpNormal.Controls.Add(this.cbGoPort);
            this.tpNormal.Controls.Add(this.cbOfflineVoicePort);
            this.tpNormal.Controls.Add(this.cbOnlineVoicePort);
            this.tpNormal.Controls.Add(this.tbGoAppPath);
            this.tpNormal.Controls.Add(this.tbVoiceWelcomeText);
            this.tpNormal.Controls.Add(this.tbWebSiteUrl);
            this.tpNormal.Controls.Add(this.tbPassword);
            this.tpNormal.Controls.Add(this.label6);
            this.tpNormal.Controls.Add(this.label9);
            this.tpNormal.Controls.Add(this.label5);
            this.tpNormal.Controls.Add(this.label4);
            this.tpNormal.Controls.Add(this.label7);
            this.tpNormal.Controls.Add(this.label3);
            this.tpNormal.Controls.Add(this.label2);
            this.tpNormal.Controls.Add(this.label1);
            this.tpNormal.Location = new System.Drawing.Point(4, 22);
            this.tpNormal.Name = "tpNormal";
            this.tpNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tpNormal.Size = new System.Drawing.Size(799, 652);
            this.tpNormal.TabIndex = 0;
            this.tpNormal.Text = "基础配置";
            this.tpNormal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbOfflineVoicePort);
            this.groupBox1.Controls.Add(this.tbOfflineVoiceIP);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.rbOfflineVoiceYuanYuan);
            this.groupBox1.Controls.Add(this.rbOfflineVoiceFeiFei);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbOfflineVoiceWebSocketUrl);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(172, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "离线服务器配置";
            // 
            // tbOfflineVoicePort
            // 
            this.tbOfflineVoicePort.Location = new System.Drawing.Point(231, 60);
            this.tbOfflineVoicePort.Maximum = new decimal(new int[] {
            65539,
            0,
            0,
            0});
            this.tbOfflineVoicePort.Name = "tbOfflineVoicePort";
            this.tbOfflineVoicePort.Size = new System.Drawing.Size(68, 21);
            this.tbOfflineVoicePort.TabIndex = 18;
            this.tbOfflineVoicePort.ValueChanged += new System.EventHandler(this.tbOfflineVoicePort_ValueChanged);
            // 
            // tbOfflineVoiceIP
            // 
            this.tbOfflineVoiceIP.Location = new System.Drawing.Point(108, 60);
            this.tbOfflineVoiceIP.Name = "tbOfflineVoiceIP";
            this.tbOfflineVoiceIP.Size = new System.Drawing.Size(111, 21);
            this.tbOfflineVoiceIP.TabIndex = 14;
            this.tbOfflineVoiceIP.TextChanged += new System.EventHandler(this.tbOfflineVoiceIP_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(219, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "：";
            // 
            // rbOfflineVoiceYuanYuan
            // 
            this.rbOfflineVoiceYuanYuan.AutoSize = true;
            this.rbOfflineVoiceYuanYuan.Location = new System.Drawing.Point(376, 72);
            this.rbOfflineVoiceYuanYuan.Name = "rbOfflineVoiceYuanYuan";
            this.rbOfflineVoiceYuanYuan.Size = new System.Drawing.Size(47, 16);
            this.rbOfflineVoiceYuanYuan.TabIndex = 16;
            this.rbOfflineVoiceYuanYuan.Text = "圆圆";
            this.rbOfflineVoiceYuanYuan.UseVisualStyleBackColor = true;
            this.rbOfflineVoiceYuanYuan.CheckedChanged += new System.EventHandler(this.rbOfflineVoiceFeiFei_CheckedChanged);
            // 
            // rbOfflineVoiceFeiFei
            // 
            this.rbOfflineVoiceFeiFei.AutoSize = true;
            this.rbOfflineVoiceFeiFei.Checked = true;
            this.rbOfflineVoiceFeiFei.Location = new System.Drawing.Point(376, 50);
            this.rbOfflineVoiceFeiFei.Name = "rbOfflineVoiceFeiFei";
            this.rbOfflineVoiceFeiFei.Size = new System.Drawing.Size(47, 16);
            this.rbOfflineVoiceFeiFei.TabIndex = 16;
            this.rbOfflineVoiceFeiFei.TabStop = true;
            this.rbOfflineVoiceFeiFei.Text = "飞飞";
            this.rbOfflineVoiceFeiFei.UseVisualStyleBackColor = true;
            this.rbOfflineVoiceFeiFei.CheckedChanged += new System.EventHandler(this.rbOfflineVoiceFeiFei_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(305, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "角色名称：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "离线服务器IP：";
            // 
            // tbOfflineVoiceWebSocketUrl
            // 
            this.tbOfflineVoiceWebSocketUrl.Location = new System.Drawing.Point(109, 20);
            this.tbOfflineVoiceWebSocketUrl.Name = "tbOfflineVoiceWebSocketUrl";
            this.tbOfflineVoiceWebSocketUrl.ReadOnly = true;
            this.tbOfflineVoiceWebSocketUrl.Size = new System.Drawing.Size(492, 21);
            this.tbOfflineVoiceWebSocketUrl.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "离线服务器地址：";
            // 
            // cbEnabledOfflineVoice
            // 
            this.cbEnabledOfflineVoice.Location = new System.Drawing.Point(294, 202);
            this.cbEnabledOfflineVoice.Name = "cbEnabledOfflineVoice";
            this.cbEnabledOfflineVoice.Size = new System.Drawing.Size(48, 16);
            this.cbEnabledOfflineVoice.TabIndex = 13;
            this.cbEnabledOfflineVoice.Text = "启用";
            this.cbEnabledOfflineVoice.UseVisualStyleBackColor = true;
            this.cbEnabledOfflineVoice.CheckedChanged += new System.EventHandler(this.cbEnabledOfflineVoice_CheckedChanged);
            // 
            // cbEnabledCloseVideoPlayerWithVoice
            // 
            this.cbEnabledCloseVideoPlayerWithVoice.AutoSize = true;
            this.cbEnabledCloseVideoPlayerWithVoice.Checked = true;
            this.cbEnabledCloseVideoPlayerWithVoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabledCloseVideoPlayerWithVoice.Location = new System.Drawing.Point(360, 173);
            this.cbEnabledCloseVideoPlayerWithVoice.Name = "cbEnabledCloseVideoPlayerWithVoice";
            this.cbEnabledCloseVideoPlayerWithVoice.Size = new System.Drawing.Size(252, 16);
            this.cbEnabledCloseVideoPlayerWithVoice.TabIndex = 10;
            this.cbEnabledCloseVideoPlayerWithVoice.Text = "是否允许关闭视频播放器在进行语音对话时";
            this.cbEnabledCloseVideoPlayerWithVoice.UseVisualStyleBackColor = true;
            // 
            // cbEnabledOnlineVoice
            // 
            this.cbEnabledOnlineVoice.AutoSize = true;
            this.cbEnabledOnlineVoice.Checked = true;
            this.cbEnabledOnlineVoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabledOnlineVoice.Location = new System.Drawing.Point(294, 173);
            this.cbEnabledOnlineVoice.Name = "cbEnabledOnlineVoice";
            this.cbEnabledOnlineVoice.Size = new System.Drawing.Size(48, 16);
            this.cbEnabledOnlineVoice.TabIndex = 9;
            this.cbEnabledOnlineVoice.Text = "启用";
            this.cbEnabledOnlineVoice.UseVisualStyleBackColor = true;
            this.cbEnabledOnlineVoice.CheckedChanged += new System.EventHandler(this.cbEnabledOnlineVoice_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 529);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "手柄状态查看：";
            // 
            // tbImageListPlayerSleepSeconds
            // 
            this.tbImageListPlayerSleepSeconds.Location = new System.Drawing.Point(172, 439);
            this.tbImageListPlayerSleepSeconds.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.tbImageListPlayerSleepSeconds.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.tbImageListPlayerSleepSeconds.Name = "tbImageListPlayerSleepSeconds";
            this.tbImageListPlayerSleepSeconds.Size = new System.Drawing.Size(50, 21);
            this.tbImageListPlayerSleepSeconds.TabIndex = 6;
            this.tbImageListPlayerSleepSeconds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "图片展示每张图的停留时间：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(617, 136);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(48, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // clbGoTypes
            // 
            this.clbGoTypes.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clbGoTypes.FormattingEnabled = true;
            this.clbGoTypes.Items.AddRange(new object[] {
            "静止模式",
            "遥控模式",
            "自由导航模式"});
            this.clbGoTypes.Location = new System.Drawing.Point(172, 362);
            this.clbGoTypes.Name = "clbGoTypes";
            this.clbGoTypes.Size = new System.Drawing.Size(208, 67);
            this.clbGoTypes.TabIndex = 3;
            this.clbGoTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbGoTypes_ItemCheck);
            // 
            // cbGoPort
            // 
            this.cbGoPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGoPort.FormattingEnabled = true;
            this.cbGoPort.Location = new System.Drawing.Point(172, 331);
            this.cbGoPort.Name = "cbGoPort";
            this.cbGoPort.Size = new System.Drawing.Size(114, 20);
            this.cbGoPort.TabIndex = 2;
            // 
            // cbOfflineVoicePort
            // 
            this.cbOfflineVoicePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOfflineVoicePort.FormattingEnabled = true;
            this.cbOfflineVoicePort.Location = new System.Drawing.Point(172, 200);
            this.cbOfflineVoicePort.Name = "cbOfflineVoicePort";
            this.cbOfflineVoicePort.Size = new System.Drawing.Size(114, 20);
            this.cbOfflineVoicePort.TabIndex = 2;
            // 
            // cbOnlineVoicePort
            // 
            this.cbOnlineVoicePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOnlineVoicePort.FormattingEnabled = true;
            this.cbOnlineVoicePort.Location = new System.Drawing.Point(172, 170);
            this.cbOnlineVoicePort.Name = "cbOnlineVoicePort";
            this.cbOnlineVoicePort.Size = new System.Drawing.Size(114, 20);
            this.cbOnlineVoicePort.TabIndex = 2;
            // 
            // tbGoAppPath
            // 
            this.tbGoAppPath.Location = new System.Drawing.Point(172, 138);
            this.tbGoAppPath.Name = "tbGoAppPath";
            this.tbGoAppPath.Size = new System.Drawing.Size(439, 21);
            this.tbGoAppPath.TabIndex = 1;
            // 
            // tbVoiceWelcomeText
            // 
            this.tbVoiceWelcomeText.Location = new System.Drawing.Point(172, 43);
            this.tbVoiceWelcomeText.Name = "tbVoiceWelcomeText";
            this.tbVoiceWelcomeText.Size = new System.Drawing.Size(439, 21);
            this.tbVoiceWelcomeText.TabIndex = 1;
            // 
            // tbWebSiteUrl
            // 
            this.tbWebSiteUrl.Location = new System.Drawing.Point(172, 107);
            this.tbWebSiteUrl.Name = "tbWebSiteUrl";
            this.tbWebSiteUrl.Size = new System.Drawing.Size(439, 21);
            this.tbWebSiteUrl.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(172, 76);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(208, 21);
            this.tbPassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "当前运动状态：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "讯飞语音卡串口（离线）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "运动控制器串口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "讯飞语音卡串口（在线）：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = " 聊天界面欢迎文本：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "RobotStudio启动路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "默认首页：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "管理员密码：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExitApp);
            this.panel1.Controls.Add(this.btnInitAIUI);
            this.panel1.Controls.Add(this.btnRestartService);
            this.panel1.Controls.Add(this.btnCameraDir);
            this.panel1.Controls.Add(this.btnReadmeDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 678);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 46);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(732, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 46);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExitApp.Location = new System.Drawing.Point(320, 0);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(75, 46);
            this.btnExitApp.TabIndex = 3;
            this.btnExitApp.Text = "退出软件";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // btnInitAIUI
            // 
            this.btnInitAIUI.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInitAIUI.Location = new System.Drawing.Point(245, 0);
            this.btnInitAIUI.Name = "btnInitAIUI";
            this.btnInitAIUI.Size = new System.Drawing.Size(75, 46);
            this.btnInitAIUI.TabIndex = 4;
            this.btnInitAIUI.Text = "设备调试";
            this.btnInitAIUI.UseVisualStyleBackColor = true;
            this.btnInitAIUI.Click += new System.EventHandler(this.btnInitAIUI_Click);
            // 
            // btnRestartService
            // 
            this.btnRestartService.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRestartService.Location = new System.Drawing.Point(150, 0);
            this.btnRestartService.Name = "btnRestartService";
            this.btnRestartService.Size = new System.Drawing.Size(95, 46);
            this.btnRestartService.TabIndex = 5;
            this.btnRestartService.Text = "重启本地服务";
            this.btnRestartService.UseVisualStyleBackColor = true;
            this.btnRestartService.Click += new System.EventHandler(this.btnRestartService_Click);
            // 
            // btnCameraDir
            // 
            this.btnCameraDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCameraDir.Location = new System.Drawing.Point(75, 0);
            this.btnCameraDir.Name = "btnCameraDir";
            this.btnCameraDir.Size = new System.Drawing.Size(75, 46);
            this.btnCameraDir.TabIndex = 2;
            this.btnCameraDir.Text = "相机目录";
            this.btnCameraDir.UseVisualStyleBackColor = true;
            this.btnCameraDir.Click += new System.EventHandler(this.btnCameraDir_Click);
            // 
            // btnReadmeDir
            // 
            this.btnReadmeDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReadmeDir.Location = new System.Drawing.Point(0, 0);
            this.btnReadmeDir.Name = "btnReadmeDir";
            this.btnReadmeDir.Size = new System.Drawing.Size(75, 46);
            this.btnReadmeDir.TabIndex = 1;
            this.btnReadmeDir.Text = "简介目录";
            this.btnReadmeDir.UseVisualStyleBackColor = true;
            this.btnReadmeDir.Click += new System.EventHandler(this.btnReadmeDir_Click);
            // 
            // ofdApp
            // 
            this.ofdApp.Filter = "*.Exe|*.exe";
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.groupBox2);
            this.tpDebug.Location = new System.Drawing.Point(4, 22);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tpDebug.Size = new System.Drawing.Size(799, 652);
            this.tpDebug.TabIndex = 1;
            this.tpDebug.Text = "状态与调试";
            this.tpDebug.UseVisualStyleBackColor = true;
            // 
            // tbDebugHintText
            // 
            this.tbDebugHintText.Location = new System.Drawing.Point(172, 10);
            this.tbDebugHintText.Name = "tbDebugHintText";
            this.tbDebugHintText.Size = new System.Drawing.Size(439, 21);
            this.tbDebugHintText.TabIndex = 16;
            this.tbDebugHintText.Text = "对不起，当前处在调试模式！";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(63, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "调试模式提示文本：";
            // 
            // jsijoystickInfo
            // 
            this.jsijoystickInfo.Location = new System.Drawing.Point(166, 460);
            this.jsijoystickInfo.Name = "jsijoystickInfo";
            this.jsijoystickInfo.Size = new System.Drawing.Size(416, 167);
            this.jsijoystickInfo.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDebug2);
            this.groupBox2.Controls.Add(this.lblDebug3);
            this.groupBox2.Controls.Add(this.lblDebug1);
            this.groupBox2.Location = new System.Drawing.Point(17, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 128);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "调试服务信息";
            // 
            // lblDebug1
            // 
            this.lblDebug1.Location = new System.Drawing.Point(19, 24);
            this.lblDebug1.Name = "lblDebug1";
            this.lblDebug1.Size = new System.Drawing.Size(433, 23);
            this.lblDebug1.TabIndex = 0;
            this.lblDebug1.Text = "0";
            this.lblDebug1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebug2
            // 
            this.lblDebug2.Location = new System.Drawing.Point(19, 60);
            this.lblDebug2.Name = "lblDebug2";
            this.lblDebug2.Size = new System.Drawing.Size(433, 23);
            this.lblDebug2.TabIndex = 0;
            this.lblDebug2.Text = "0";
            this.lblDebug2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebug3
            // 
            this.lblDebug3.Location = new System.Drawing.Point(19, 95);
            this.lblDebug3.Name = "lblDebug3";
            this.lblDebug3.Size = new System.Drawing.Size(433, 23);
            this.lblDebug3.TabIndex = 0;
            this.lblDebug3.Text = "0";
            this.lblDebug3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 724);
            this.Controls.Add(this.tcPage);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.tcPage.ResumeLayout(false);
            this.tpNormal.ResumeLayout(false);
            this.tpNormal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOfflineVoicePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageListPlayerSleepSeconds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tpDebug.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPage;
        private System.Windows.Forms.TabPage tpNormal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCameraDir;
        private System.Windows.Forms.Button btnReadmeDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbWebSiteUrl;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbGoAppPath;
        private System.Windows.Forms.ComboBox cbGoPort;
        private System.Windows.Forms.ComboBox cbOnlineVoicePort;
        private System.Windows.Forms.CheckedListBox clbGoTypes;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog ofdApp;
        private System.Windows.Forms.TextBox tbVoiceWelcomeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tbImageListPlayerSleepSeconds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbOfflineVoicePort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExitApp;
        private JoyAPI.JoystickStateInfo jsijoystickInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnInitAIUI;
        private System.Windows.Forms.Button btnRestartService;
        private System.Windows.Forms.CheckBox cbEnabledOnlineVoice;
        private System.Windows.Forms.CheckBox cbEnabledCloseVideoPlayerWithVoice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbOfflineVoiceWebSocketUrl;
        private System.Windows.Forms.CheckBox cbEnabledOfflineVoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbOfflineVoiceIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rbOfflineVoiceYuanYuan;
        private System.Windows.Forms.RadioButton rbOfflineVoiceFeiFei;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown tbOfflineVoicePort;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.TextBox tbDebugHintText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDebug1;
        private System.Windows.Forms.Label lblDebug2;
        private System.Windows.Forms.Label lblDebug3;
    }
}