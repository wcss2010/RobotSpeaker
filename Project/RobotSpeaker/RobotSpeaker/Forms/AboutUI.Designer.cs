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
            this.lblListBarLabel = new System.Windows.Forms.Label();
            this.plListContent = new System.Windows.Forms.FlowLayoutPanel();
            this.plListBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // plListBar
            // 
            this.plListBar.Controls.Add(this.lblListBarLabel);
            this.plListBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plListBar.Location = new System.Drawing.Point(0, 64);
            this.plListBar.Name = "plListBar";
            this.plListBar.Size = new System.Drawing.Size(1031, 60);
            this.plListBar.TabIndex = 1;
            // 
            // lblListBarLabel
            // 
            this.lblListBarLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblListBarLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblListBarLabel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblListBarLabel.ForeColor = System.Drawing.Color.White;
            this.lblListBarLabel.Location = new System.Drawing.Point(0, 0);
            this.lblListBarLabel.Name = "lblListBarLabel";
            this.lblListBarLabel.Size = new System.Drawing.Size(205, 60);
            this.lblListBarLabel.TabIndex = 0;
            this.lblListBarLabel.Text = "本地资源";
            this.lblListBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plListContent
            // 
            this.plListContent.AutoScroll = true;
            this.plListContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plListContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.plListContent.Location = new System.Drawing.Point(0, 124);
            this.plListContent.Name = "plListContent";
            this.plListContent.Size = new System.Drawing.Size(1031, 363);
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
            this.TitleTextColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plListBar, 0);
            this.Controls.SetChildIndex(this.plListContent, 0);
            this.plListBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plListBar;
        private System.Windows.Forms.Label lblListBarLabel;
        private System.Windows.Forms.FlowLayoutPanel plListContent;
    }
}