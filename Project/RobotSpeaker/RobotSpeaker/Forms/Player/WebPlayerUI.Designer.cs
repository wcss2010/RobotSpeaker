namespace RobotSpeaker.Forms.Player
{
    partial class WebPlayerUI
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
            this.web = new System.Windows.Forms.WebBrowser();
            this.plListBar = new System.Windows.Forms.Panel();
            this.btnBack = new RobotSpeaker.Controls.ButtonExt();
            this.btnBefore = new RobotSpeaker.Controls.ButtonExt();
            this.plListBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 124);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(1031, 363);
            this.web.TabIndex = 1;
            // 
            // plListBar
            // 
            this.plListBar.Controls.Add(this.btnBack);
            this.plListBar.Controls.Add(this.btnBefore);
            this.plListBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plListBar.Location = new System.Drawing.Point(0, 64);
            this.plListBar.Name = "plListBar";
            this.plListBar.Size = new System.Drawing.Size(1031, 60);
            this.plListBar.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.Location = new System.Drawing.Point(791, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 60);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "后退";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBefore
            // 
            this.btnBefore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBefore.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBefore.Location = new System.Drawing.Point(911, 0);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(120, 60);
            this.btnBefore.TabIndex = 1;
            this.btnBefore.Text = "前进";
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // WebPlayerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.web);
            this.Controls.Add(this.plListBar);
            this.Name = "WebPlayerUI";
            this.Text = "WebPlayerUI";
            this.TitleText = "网页";
            this.TitleTextColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plListBar, 0);
            this.Controls.SetChildIndex(this.web, 0);
            this.plListBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Panel plListBar;
        private Controls.ButtonExt btnBack;
        private Controls.ButtonExt btnBefore;
    }
}