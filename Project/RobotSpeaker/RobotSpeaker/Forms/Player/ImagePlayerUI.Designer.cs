namespace RobotSpeaker.Forms.Player
{
    partial class ImagePlayerUI
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
            this.pbView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pbView
            // 
            this.pbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbView.Location = new System.Drawing.Point(0, 64);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(1031, 423);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbView.TabIndex = 1;
            this.pbView.TabStop = false;
            // 
            // ImagePlayerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.pbView);
            this.EnabledDisplayWifiLogo = true;
            this.Name = "ImagePlayerUI";
            this.Text = "ImagePlayerUI";
            this.TimeTextForeColor = System.Drawing.Color.White;
            this.TitleText = "图片";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.pbView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbView;

    }
}