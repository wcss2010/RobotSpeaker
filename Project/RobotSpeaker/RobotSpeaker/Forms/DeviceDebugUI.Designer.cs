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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDebugLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentWifiName);
            this.groupBox1.Controls.Add(this.btnRefreshWifiList);
            this.groupBox1.Controls.Add(this.lvWifiList);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(549, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 301);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AIUI AppID设置";
            // 
            // tbDebugLog
            // 
            this.tbDebugLog.Location = new System.Drawing.Point(2, 309);
            this.tbDebugLog.Name = "tbDebugLog";
            this.tbDebugLog.Size = new System.Drawing.Size(940, 302);
            this.tbDebugLog.TabIndex = 1;
            this.tbDebugLog.Text = "";
            // 
            // DeviceDebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 614);
            this.Controls.Add(this.tbDebugLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceDebugUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备调试";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tbDebugLog;
        private System.Windows.Forms.ListView lvWifiList;
        private System.Windows.Forms.Button btnRefreshWifiList;
        private System.Windows.Forms.Label lblCurrentWifiName;
    }
}