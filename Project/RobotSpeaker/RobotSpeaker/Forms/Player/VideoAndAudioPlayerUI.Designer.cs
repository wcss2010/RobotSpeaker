namespace RobotSpeaker.Forms.Player
{
    partial class VideoAndAudioPlayerUI
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
            this.player = new VLCPlayerLib.VlcPlayerControl();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.EnabledDisplayPlayerControlPanel = true;
            this.player.Location = new System.Drawing.Point(0, 64);
            this.player.MediaUrl = null;
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(1031, 423);
            this.player.TabIndex = 1;
            this.player.VlcPluginPath = null;
            // 
            // VideoAndAudioPlayerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.player);
            this.EnabledDisplayWifiLogo = true;
            this.Name = "VideoAndAudioPlayerUI";
            this.Text = "VideoAndAudioPlayerUI";
            this.TimeTextForeColor = System.Drawing.Color.White;
            this.TitleText = "音频与视频";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.player, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private VLCPlayerLib.VlcPlayerControl player;

    }
}