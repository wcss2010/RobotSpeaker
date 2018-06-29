namespace RobotSpeaker.Controls
{
    partial class ContentFormBase
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
            this.plTopBar = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.plTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // plTopBar
            // 
            this.plTopBar.BackColor = System.Drawing.Color.Transparent;
            this.plTopBar.Controls.Add(this.pbLogo);
            this.plTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTopBar.Location = new System.Drawing.Point(0, 0);
            this.plTopBar.Name = "plTopBar";
            this.plTopBar.Size = new System.Drawing.Size(1031, 64);
            this.plTopBar.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Location = new System.Drawing.Point(967, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(64, 64);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // ContentFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.plTopBar);
            this.Name = "ContentFormBase";
            this.Text = "ContentFormBase";
            this.plTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTopBar;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}