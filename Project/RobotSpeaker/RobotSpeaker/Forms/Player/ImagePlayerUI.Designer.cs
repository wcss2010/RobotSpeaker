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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePlayerUI));
            this.imageViewerEx = new RobotSpeaker.Forms.Player.ImageViewerEx();
            this.SuspendLayout();
            // 
            // imageViewerEx
            // 
            this.imageViewerEx.BackColor = System.Drawing.Color.Transparent;
            this.imageViewerEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewerEx.Files = ((System.Collections.Generic.List<string>)(resources.GetObject("imageViewerEx.Files")));
            this.imageViewerEx.Location = new System.Drawing.Point(0, 64);
            this.imageViewerEx.MinimumSize = new System.Drawing.Size(340, 260);
            this.imageViewerEx.Name = "imageViewerEx";
            this.imageViewerEx.Size = new System.Drawing.Size(1031, 423);
            this.imageViewerEx.TabIndex = 1;
            // 
            // ImagePlayerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.imageViewerEx);
            this.Name = "ImagePlayerUI";
            this.Text = "ImagePlayerUI";
            this.TitleText = "图片";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.imageViewerEx, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageViewerEx imageViewerEx;
    }
}