namespace RobotSpeaker.Forms
{
    partial class LockUI
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
            this.vlcPlayerControl1 = new VLCPlayerLib.VlcPlayerControl();
            this.SuspendLayout();
            // 
            // vlcPlayerControl1
            // 
            this.vlcPlayerControl1.BackColor = System.Drawing.Color.Black;
            this.vlcPlayerControl1.EnabledDisplayPlayerControlPanel = true;
            this.vlcPlayerControl1.Location = new System.Drawing.Point(59, 77);
            this.vlcPlayerControl1.MediaUrl = null;
            this.vlcPlayerControl1.Name = "vlcPlayerControl1";
            this.vlcPlayerControl1.Size = new System.Drawing.Size(993, 494);
            this.vlcPlayerControl1.TabIndex = 1;
            this.vlcPlayerControl1.VlcPluginPath = null;
            // 
            // LockUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.vlcPlayerControl1);
            this.EnabledDisplayWifiLogo = true;
            this.Name = "LockUI";
            this.Text = "LockUI";
            this.TimeTextForeColor = System.Drawing.Color.White;
            this.TitleText = "锁定中...";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.vlcPlayerControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private VLCPlayerLib.VlcPlayerControl vlcPlayerControl1;
    }
}