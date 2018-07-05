namespace RobotSpeaker.Forms
{
    partial class AboutUI
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
            this.plListBar = new System.Windows.Forms.Panel();
            this.btnToHome = new RobotSpeaker.Controls.ButtonExt();
            this.btnExplorer = new RobotSpeaker.Controls.ButtonExt();
            this.lblListBarLabel = new System.Windows.Forms.Label();
            this.plListContent = new System.Windows.Forms.FlowLayoutPanel();
            this.plListBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // plListBar
            // 
            this.plListBar.BackColor = System.Drawing.Color.Transparent;
            this.plListBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plListBar.Controls.Add(this.btnToHome);
            this.plListBar.Controls.Add(this.btnExplorer);
            this.plListBar.Controls.Add(this.lblListBarLabel);
            this.plListBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plListBar.Location = new System.Drawing.Point(0, 64);
            this.plListBar.Name = "plListBar";
            this.plListBar.Size = new System.Drawing.Size(1031, 80);
            this.plListBar.TabIndex = 1;
            // 
            // btnToHome
            // 
            this.btnToHome.BackColor = System.Drawing.Color.Transparent;
            this.btnToHome.ButtonNormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(146)))), ((int)(((byte)(11)))));
            this.btnToHome.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnToHome.ButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnToHome.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnToHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToHome.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToHome.Location = new System.Drawing.Point(751, 0);
            this.btnToHome.Name = "btnToHome";
            this.btnToHome.Size = new System.Drawing.Size(140, 80);
            this.btnToHome.TabIndex = 2;
            this.btnToHome.Text = "转到首页";
            this.btnToHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnToHome.Click += new System.EventHandler(this.btnToHome_Click);
            // 
            // btnExplorer
            // 
            this.btnExplorer.BackColor = System.Drawing.Color.Transparent;
            this.btnExplorer.ButtonNormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(146)))), ((int)(((byte)(11)))));
            this.btnExplorer.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnExplorer.ButtonPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExplorer.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnExplorer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExplorer.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExplorer.Location = new System.Drawing.Point(891, 0);
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.Size = new System.Drawing.Size(140, 80);
            this.btnExplorer.TabIndex = 1;
            this.btnExplorer.Text = "资源管理器";
            this.btnExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
            // 
            // lblListBarLabel
            // 
            this.lblListBarLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblListBarLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblListBarLabel.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblListBarLabel.ForeColor = System.Drawing.Color.White;
            this.lblListBarLabel.Location = new System.Drawing.Point(0, 0);
            this.lblListBarLabel.Name = "lblListBarLabel";
            this.lblListBarLabel.Size = new System.Drawing.Size(205, 80);
            this.lblListBarLabel.TabIndex = 0;
            this.lblListBarLabel.Text = "本地资源";
            this.lblListBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plListContent
            // 
            this.plListContent.AutoScroll = true;
            this.plListContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plListContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.plListContent.Location = new System.Drawing.Point(0, 144);
            this.plListContent.Name = "plListContent";
            this.plListContent.Size = new System.Drawing.Size(1031, 343);
            this.plListContent.TabIndex = 2;
            this.plListContent.WrapContents = false;
            // 
            // AboutUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.plListContent);
            this.Controls.Add(this.plListBar);
            this.Name = "AboutUI";
            this.Text = "AboutUI";
            this.TitleText = "业务介绍";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plListBar, 0);
            this.Controls.SetChildIndex(this.plListContent, 0);
            this.plListBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plListBar;
        private System.Windows.Forms.Label lblListBarLabel;
        private System.Windows.Forms.FlowLayoutPanel plListContent;
        private Controls.ButtonExt btnExplorer;
        private Controls.ButtonExt btnToHome;
    }
}