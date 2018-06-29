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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ibBack = new RobotSpeaker.Controls.ImageButton();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.plTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // plTopBar
            // 
            this.plTopBar.BackColor = System.Drawing.Color.Transparent;
            this.plTopBar.Controls.Add(this.lblTitle);
            this.plTopBar.Controls.Add(this.ibBack);
            this.plTopBar.Controls.Add(this.pbLogo);
            this.plTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTopBar.Location = new System.Drawing.Point(0, 0);
            this.plTopBar.Name = "plTopBar";
            this.plTopBar.Size = new System.Drawing.Size(1031, 64);
            this.plTopBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(64, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(903, 64);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ibBack
            // 
            this.ibBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibBack.EnabledTextLabel = false;
            this.ibBack.FocusImage = null;
            this.ibBack.Location = new System.Drawing.Point(0, 0);
            this.ibBack.Name = "ibBack";
            this.ibBack.NoFocusImage = null;
            this.ibBack.Size = new System.Drawing.Size(64, 64);
            this.ibBack.TabIndex = 1;
            this.ibBack.Click += new System.EventHandler(this.ibBack_Click);
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
        private ImageButton ibBack;
        private System.Windows.Forms.Label lblTitle;
    }
}