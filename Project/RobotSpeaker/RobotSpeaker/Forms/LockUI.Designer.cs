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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockUI));
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.vpcPlayer = new VLCPlayerLib.VlcPlayerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFace
            // 
            this.pbFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFace.Image = ((System.Drawing.Image)(resources.GetObject("pbFace.Image")));
            this.pbFace.Location = new System.Drawing.Point(0, 64);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(1031, 423);
            this.pbFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFace.TabIndex = 1;
            this.pbFace.TabStop = false;
            // 
            // vpcPlayer
            // 
            this.vpcPlayer.BackColor = System.Drawing.Color.Black;
            this.vpcPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vpcPlayer.EnabledDisplayPlayerControlPanel = false;
            this.vpcPlayer.Location = new System.Drawing.Point(0, 64);
            this.vpcPlayer.MediaUrl = null;
            this.vpcPlayer.Name = "vpcPlayer";
            this.vpcPlayer.Size = new System.Drawing.Size(1031, 423);
            this.vpcPlayer.TabIndex = 2;
            this.vpcPlayer.VlcPluginPath = null;
            // 
            // LockUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.vpcPlayer);
            this.Controls.Add(this.pbFace);
            this.EnabledDisplayWifiLogo = true;
            this.Name = "LockUI";
            this.Text = "LockUI";
            this.TimeTextForeColor = System.Drawing.Color.White;
            this.TitleText = "待机中...";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.pbFace, 0);
            this.Controls.SetChildIndex(this.vpcPlayer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFace;
        private VLCPlayerLib.VlcPlayerControl vpcPlayer;

    }
}