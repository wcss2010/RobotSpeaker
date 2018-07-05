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
            this.tbImageListPlayerSleepSeconds = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.clbGoTypes = new System.Windows.Forms.CheckedListBox();
            this.cbGoPort = new System.Windows.Forms.ComboBox();
            this.cbVoicePort = new System.Windows.Forms.ComboBox();
            this.tbGoAppPath = new System.Windows.Forms.TextBox();
            this.tbVoiceWelcomeText = new System.Windows.Forms.TextBox();
            this.tbWebSiteUrl = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpVoice = new System.Windows.Forms.TabPage();
            this.tpGo = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCameraDir = new System.Windows.Forms.Button();
            this.btnReadmeDir = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofdApp = new System.Windows.Forms.OpenFileDialog();
            this.tcPage.SuspendLayout();
            this.tpNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbImageListPlayerSleepSeconds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPage
            // 
            this.tcPage.Controls.Add(this.tpNormal);
            this.tcPage.Controls.Add(this.tpVoice);
            this.tcPage.Controls.Add(this.tpGo);
            this.tcPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPage.Location = new System.Drawing.Point(0, 0);
            this.tcPage.Name = "tcPage";
            this.tcPage.SelectedIndex = 0;
            this.tcPage.Size = new System.Drawing.Size(807, 392);
            this.tcPage.TabIndex = 0;
            // 
            // tpNormal
            // 
            this.tpNormal.Controls.Add(this.tbImageListPlayerSleepSeconds);
            this.tpNormal.Controls.Add(this.label8);
            this.tpNormal.Controls.Add(this.btnSelect);
            this.tpNormal.Controls.Add(this.clbGoTypes);
            this.tpNormal.Controls.Add(this.cbGoPort);
            this.tpNormal.Controls.Add(this.cbVoicePort);
            this.tpNormal.Controls.Add(this.tbGoAppPath);
            this.tpNormal.Controls.Add(this.tbVoiceWelcomeText);
            this.tpNormal.Controls.Add(this.tbWebSiteUrl);
            this.tpNormal.Controls.Add(this.tbPassword);
            this.tpNormal.Controls.Add(this.label6);
            this.tpNormal.Controls.Add(this.label5);
            this.tpNormal.Controls.Add(this.label4);
            this.tpNormal.Controls.Add(this.label7);
            this.tpNormal.Controls.Add(this.label3);
            this.tpNormal.Controls.Add(this.label2);
            this.tpNormal.Controls.Add(this.label1);
            this.tpNormal.Location = new System.Drawing.Point(4, 22);
            this.tpNormal.Name = "tpNormal";
            this.tpNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tpNormal.Size = new System.Drawing.Size(799, 366);
            this.tpNormal.TabIndex = 0;
            this.tpNormal.Text = "基础配置";
            this.tpNormal.UseVisualStyleBackColor = true;
            // 
            // tbImageListPlayerSleepSeconds
            // 
            this.tbImageListPlayerSleepSeconds.Location = new System.Drawing.Point(172, 283);
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
            this.label8.Location = new System.Drawing.Point(14, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "图片展示每张图的停留时间：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(586, 109);
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
            this.clbGoTypes.Location = new System.Drawing.Point(141, 204);
            this.clbGoTypes.Name = "clbGoTypes";
            this.clbGoTypes.Size = new System.Drawing.Size(208, 67);
            this.clbGoTypes.TabIndex = 3;
            this.clbGoTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbGoTypes_ItemCheck);
            // 
            // cbGoPort
            // 
            this.cbGoPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGoPort.FormattingEnabled = true;
            this.cbGoPort.Location = new System.Drawing.Point(141, 173);
            this.cbGoPort.Name = "cbGoPort";
            this.cbGoPort.Size = new System.Drawing.Size(114, 20);
            this.cbGoPort.TabIndex = 2;
            // 
            // cbVoicePort
            // 
            this.cbVoicePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoicePort.FormattingEnabled = true;
            this.cbVoicePort.Location = new System.Drawing.Point(141, 143);
            this.cbVoicePort.Name = "cbVoicePort";
            this.cbVoicePort.Size = new System.Drawing.Size(114, 20);
            this.cbVoicePort.TabIndex = 2;
            // 
            // tbGoAppPath
            // 
            this.tbGoAppPath.Location = new System.Drawing.Point(141, 111);
            this.tbGoAppPath.Name = "tbGoAppPath";
            this.tbGoAppPath.Size = new System.Drawing.Size(439, 21);
            this.tbGoAppPath.TabIndex = 1;
            // 
            // tbVoiceWelcomeText
            // 
            this.tbVoiceWelcomeText.Location = new System.Drawing.Point(141, 16);
            this.tbVoiceWelcomeText.Name = "tbVoiceWelcomeText";
            this.tbVoiceWelcomeText.Size = new System.Drawing.Size(439, 21);
            this.tbVoiceWelcomeText.TabIndex = 1;
            // 
            // tbWebSiteUrl
            // 
            this.tbWebSiteUrl.Location = new System.Drawing.Point(141, 80);
            this.tbWebSiteUrl.Name = "tbWebSiteUrl";
            this.tbWebSiteUrl.Size = new System.Drawing.Size(439, 21);
            this.tbWebSiteUrl.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(141, 49);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(208, 21);
            this.tbPassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "当前运动状态：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "运动控制卡串口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "语音卡串口：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "欢迎词：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "RobotStudio启动路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "默认首页：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "管理员密码：";
            // 
            // tpVoice
            // 
            this.tpVoice.Location = new System.Drawing.Point(4, 22);
            this.tpVoice.Name = "tpVoice";
            this.tpVoice.Padding = new System.Windows.Forms.Padding(3);
            this.tpVoice.Size = new System.Drawing.Size(799, 366);
            this.tpVoice.TabIndex = 1;
            this.tpVoice.Text = "语音问答题库";
            this.tpVoice.UseVisualStyleBackColor = true;
            // 
            // tpGo
            // 
            this.tpGo.Location = new System.Drawing.Point(4, 22);
            this.tpGo.Name = "tpGo";
            this.tpGo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGo.Size = new System.Drawing.Size(799, 366);
            this.tpGo.TabIndex = 2;
            this.tpGo.Text = "运动指令库";
            this.tpGo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCameraDir);
            this.panel1.Controls.Add(this.btnReadmeDir);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 46);
            this.panel1.TabIndex = 1;
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
            // ofdApp
            // 
            this.ofdApp.Filter = "*.Exe|*.exe";
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 438);
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
            ((System.ComponentModel.ISupportInitialize)(this.tbImageListPlayerSleepSeconds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPage;
        private System.Windows.Forms.TabPage tpNormal;
        private System.Windows.Forms.TabPage tpVoice;
        private System.Windows.Forms.TabPage tpGo;
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
        private System.Windows.Forms.ComboBox cbVoicePort;
        private System.Windows.Forms.CheckedListBox clbGoTypes;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog ofdApp;
        private System.Windows.Forms.TextBox tbVoiceWelcomeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tbImageListPlayerSleepSeconds;
        private System.Windows.Forms.Label label8;
    }
}