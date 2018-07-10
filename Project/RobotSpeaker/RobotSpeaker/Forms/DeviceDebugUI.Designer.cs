namespace RobotSpeaker.Forms
{
    partial class DeviceDebugUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCurrentWifiName = new System.Windows.Forms.Label();
            this.btnRefreshWifiList = new System.Windows.Forms.Button();
            this.lvWifiList = new System.Windows.Forms.ListView();
            this.btnGetAIUIWifi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAIUIConfig = new System.Windows.Forms.Button();
            this.cbIsEnabledUseAIUIAfter = new System.Windows.Forms.CheckBox();
            this.tbScene = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAppId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAppKey = new System.Windows.Forms.TextBox();
            this.tbDebugLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAIUI = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnWakeup = new System.Windows.Forms.Button();
            this.btnTTSRead = new System.Windows.Forms.Button();
            this.btnGetWakeupState = new System.Windows.Forms.Button();
            this.btnResetWakeup = new System.Windows.Forms.Button();
            this.btnStopVoice = new System.Windows.Forms.Button();
            this.btnStartVoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpAIUI.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentWifiName);
            this.groupBox1.Controls.Add(this.btnRefreshWifiList);
            this.groupBox1.Controls.Add(this.lvWifiList);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WIFI设置";
            // 
            // lblCurrentWifiName
            // 
            this.lblCurrentWifiName.Location = new System.Drawing.Point(102, 266);
            this.lblCurrentWifiName.Name = "lblCurrentWifiName";
            this.lblCurrentWifiName.Size = new System.Drawing.Size(428, 23);
            this.lblCurrentWifiName.TabIndex = 4;
            this.lblCurrentWifiName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefreshWifiList
            // 
            this.btnRefreshWifiList.Location = new System.Drawing.Point(7, 266);
            this.btnRefreshWifiList.Name = "btnRefreshWifiList";
            this.btnRefreshWifiList.Size = new System.Drawing.Size(89, 23);
            this.btnRefreshWifiList.TabIndex = 1;
            this.btnRefreshWifiList.Text = "刷新Wifi列表";
            this.btnRefreshWifiList.UseVisualStyleBackColor = true;
            this.btnRefreshWifiList.Click += new System.EventHandler(this.btnRefreshWifiList_Click);
            // 
            // lvWifiList
            // 
            this.lvWifiList.FullRowSelect = true;
            this.lvWifiList.Location = new System.Drawing.Point(7, 20);
            this.lvWifiList.Name = "lvWifiList";
            this.lvWifiList.Size = new System.Drawing.Size(526, 241);
            this.lvWifiList.TabIndex = 0;
            this.lvWifiList.UseCompatibleStateImageBehavior = false;
            this.lvWifiList.View = System.Windows.Forms.View.Details;
            this.lvWifiList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvWifiList_MouseDoubleClick);
            // 
            // btnGetAIUIWifi
            // 
            this.btnGetAIUIWifi.Location = new System.Drawing.Point(291, 20);
            this.btnGetAIUIWifi.Name = "btnGetAIUIWifi";
            this.btnGetAIUIWifi.Size = new System.Drawing.Size(85, 29);
            this.btnGetAIUIWifi.TabIndex = 5;
            this.btnGetAIUIWifi.Text = "查询WIFI状态";
            this.btnGetAIUIWifi.UseVisualStyleBackColor = true;
            this.btnGetAIUIWifi.Click += new System.EventHandler(this.btnGetAIUIWifi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAIUIConfig);
            this.groupBox2.Controls.Add(this.cbIsEnabledUseAIUIAfter);
            this.groupBox2.Controls.Add(this.tbScene);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbAppId);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbAppKey);
            this.groupBox2.Location = new System.Drawing.Point(547, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 178);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AIUI AppID设置";
            // 
            // btnAIUIConfig
            // 
            this.btnAIUIConfig.Location = new System.Drawing.Point(168, 141);
            this.btnAIUIConfig.Name = "btnAIUIConfig";
            this.btnAIUIConfig.Size = new System.Drawing.Size(75, 23);
            this.btnAIUIConfig.TabIndex = 18;
            this.btnAIUIConfig.Text = "AIUI配置";
            this.btnAIUIConfig.UseVisualStyleBackColor = true;
            this.btnAIUIConfig.Click += new System.EventHandler(this.btnAIUIConfig_Click);
            // 
            // cbIsEnabledUseAIUIAfter
            // 
            this.cbIsEnabledUseAIUIAfter.AutoSize = true;
            this.cbIsEnabledUseAIUIAfter.Checked = true;
            this.cbIsEnabledUseAIUIAfter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsEnabledUseAIUIAfter.Location = new System.Drawing.Point(77, 119);
            this.cbIsEnabledUseAIUIAfter.Name = "cbIsEnabledUseAIUIAfter";
            this.cbIsEnabledUseAIUIAfter.Size = new System.Drawing.Size(132, 16);
            this.cbIsEnabledUseAIUIAfter.TabIndex = 17;
            this.cbIsEnabledUseAIUIAfter.Text = "是否启动AIUI后处理";
            this.cbIsEnabledUseAIUIAfter.UseVisualStyleBackColor = true;
            // 
            // tbScene
            // 
            this.tbScene.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbScene.Location = new System.Drawing.Point(77, 86);
            this.tbScene.Multiline = true;
            this.tbScene.Name = "tbScene";
            this.tbScene.Size = new System.Drawing.Size(308, 27);
            this.tbScene.TabIndex = 16;
            this.tbScene.Text = "main";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "情景模式:";
            // 
            // tbAppId
            // 
            this.tbAppId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAppId.Location = new System.Drawing.Point(77, 20);
            this.tbAppId.Multiline = true;
            this.tbAppId.Name = "tbAppId";
            this.tbAppId.Size = new System.Drawing.Size(308, 27);
            this.tbAppId.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "APPID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "APPKEY:";
            // 
            // tbAppKey
            // 
            this.tbAppKey.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAppKey.Location = new System.Drawing.Point(77, 53);
            this.tbAppKey.Multiline = true;
            this.tbAppKey.Name = "tbAppKey";
            this.tbAppKey.Size = new System.Drawing.Size(308, 27);
            this.tbAppKey.TabIndex = 12;
            // 
            // tbDebugLog
            // 
            this.tbDebugLog.Location = new System.Drawing.Point(0, 310);
            this.tbDebugLog.Name = "tbDebugLog";
            this.tbDebugLog.Size = new System.Drawing.Size(940, 302);
            this.tbDebugLog.TabIndex = 1;
            this.tbDebugLog.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAIUI);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(954, 614);
            this.tabControl1.TabIndex = 2;
            // 
            // tpAIUI
            // 
            this.tpAIUI.Controls.Add(this.groupBox3);
            this.tpAIUI.Controls.Add(this.groupBox1);
            this.tpAIUI.Controls.Add(this.tbDebugLog);
            this.tpAIUI.Controls.Add(this.groupBox2);
            this.tpAIUI.Location = new System.Drawing.Point(4, 22);
            this.tpAIUI.Name = "tpAIUI";
            this.tpAIUI.Padding = new System.Windows.Forms.Padding(3);
            this.tpAIUI.Size = new System.Drawing.Size(946, 588);
            this.tpAIUI.TabIndex = 0;
            this.tpAIUI.Text = "AIUI";
            this.tpAIUI.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetWakeup);
            this.groupBox3.Controls.Add(this.btnStopVoice);
            this.groupBox3.Controls.Add(this.btnStartVoice);
            this.groupBox3.Controls.Add(this.btnGetAIUIWifi);
            this.groupBox3.Controls.Add(this.btnWakeup);
            this.groupBox3.Controls.Add(this.btnTTSRead);
            this.groupBox3.Controls.Add(this.btnGetWakeupState);
            this.groupBox3.Location = new System.Drawing.Point(547, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 117);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnWakeup
            // 
            this.btnWakeup.Location = new System.Drawing.Point(109, 20);
            this.btnWakeup.Name = "btnWakeup";
            this.btnWakeup.Size = new System.Drawing.Size(85, 29);
            this.btnWakeup.TabIndex = 22;
            this.btnWakeup.Text = "手动唤醒";
            this.btnWakeup.UseVisualStyleBackColor = true;
            this.btnWakeup.Click += new System.EventHandler(this.btnWakeup_Click);
            // 
            // btnTTSRead
            // 
            this.btnTTSRead.Location = new System.Drawing.Point(200, 20);
            this.btnTTSRead.Name = "btnTTSRead";
            this.btnTTSRead.Size = new System.Drawing.Size(85, 29);
            this.btnTTSRead.TabIndex = 21;
            this.btnTTSRead.Text = "文本合成";
            this.btnTTSRead.UseVisualStyleBackColor = true;
            this.btnTTSRead.Click += new System.EventHandler(this.btnTTSRead_Click);
            // 
            // btnGetWakeupState
            // 
            this.btnGetWakeupState.Location = new System.Drawing.Point(18, 20);
            this.btnGetWakeupState.Name = "btnGetWakeupState";
            this.btnGetWakeupState.Size = new System.Drawing.Size(85, 29);
            this.btnGetWakeupState.TabIndex = 20;
            this.btnGetWakeupState.Text = "唤醒状态查询";
            this.btnGetWakeupState.UseVisualStyleBackColor = true;
            this.btnGetWakeupState.Click += new System.EventHandler(this.btnGetWakeupState_Click);
            // 
            // btnResetWakeup
            // 
            this.btnResetWakeup.Location = new System.Drawing.Point(200, 67);
            this.btnResetWakeup.Name = "btnResetWakeup";
            this.btnResetWakeup.Size = new System.Drawing.Size(85, 29);
            this.btnResetWakeup.TabIndex = 25;
            this.btnResetWakeup.Text = "重置唤醒";
            this.btnResetWakeup.UseVisualStyleBackColor = true;
            this.btnResetWakeup.Click += new System.EventHandler(this.btnResetWakeup_Click);
            // 
            // btnStopVoice
            // 
            this.btnStopVoice.Location = new System.Drawing.Point(109, 67);
            this.btnStopVoice.Name = "btnStopVoice";
            this.btnStopVoice.Size = new System.Drawing.Size(85, 29);
            this.btnStopVoice.TabIndex = 24;
            this.btnStopVoice.Text = "关闭声音播放";
            this.btnStopVoice.UseVisualStyleBackColor = true;
            this.btnStopVoice.Click += new System.EventHandler(this.btnStopVoice_Click);
            // 
            // btnStartVoice
            // 
            this.btnStartVoice.Location = new System.Drawing.Point(18, 67);
            this.btnStartVoice.Name = "btnStartVoice";
            this.btnStartVoice.Size = new System.Drawing.Size(85, 29);
            this.btnStartVoice.TabIndex = 23;
            this.btnStartVoice.Text = "开启声音播放";
            this.btnStartVoice.UseVisualStyleBackColor = true;
            this.btnStartVoice.Click += new System.EventHandler(this.btnStartVoice_Click);
            // 
            // DeviceDebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 614);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceDebugUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备调试";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpAIUI.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tbDebugLog;
        private System.Windows.Forms.ListView lvWifiList;
        private System.Windows.Forms.Button btnRefreshWifiList;
        private System.Windows.Forms.Label lblCurrentWifiName;
        private System.Windows.Forms.CheckBox cbIsEnabledUseAIUIAfter;
        private System.Windows.Forms.TextBox tbScene;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAppId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAppKey;
        private System.Windows.Forms.Button btnGetAIUIWifi;
        private System.Windows.Forms.Button btnAIUIConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAIUI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnWakeup;
        private System.Windows.Forms.Button btnTTSRead;
        private System.Windows.Forms.Button btnGetWakeupState;
        private System.Windows.Forms.Button btnResetWakeup;
        private System.Windows.Forms.Button btnStopVoice;
        private System.Windows.Forms.Button btnStartVoice;
    }
}