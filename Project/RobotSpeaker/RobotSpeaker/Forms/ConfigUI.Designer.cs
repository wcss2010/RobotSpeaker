namespace RobotSpeaker.Forms
{
    partial class ConfigUI
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
            this.tcPage = new System.Windows.Forms.TabControl();
            this.tpNormal = new System.Windows.Forms.TabPage();
            this.tpVoice = new System.Windows.Forms.TabPage();
            this.tpGo = new System.Windows.Forms.TabPage();
            this.tcPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPage
            // 
            this.tcPage.Controls.Add(this.tpNormal);
            this.tcPage.Controls.Add(this.tpVoice);
            this.tcPage.Controls.Add(this.tpGo);
            this.tcPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPage.Location = new System.Drawing.Point(0, 0);
            this.tcPage.Name = "tcPage";
            this.tcPage.SelectedIndex = 0;
            this.tcPage.Size = new System.Drawing.Size(807, 502);
            this.tcPage.TabIndex = 0;
            // 
            // tpNormal
            // 
            this.tpNormal.Location = new System.Drawing.Point(4, 22);
            this.tpNormal.Name = "tpNormal";
            this.tpNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tpNormal.Size = new System.Drawing.Size(799, 476);
            this.tpNormal.TabIndex = 0;
            this.tpNormal.Text = "基础配置";
            this.tpNormal.UseVisualStyleBackColor = true;
            // 
            // tpVoice
            // 
            this.tpVoice.Location = new System.Drawing.Point(4, 22);
            this.tpVoice.Name = "tpVoice";
            this.tpVoice.Padding = new System.Windows.Forms.Padding(3);
            this.tpVoice.Size = new System.Drawing.Size(799, 476);
            this.tpVoice.TabIndex = 1;
            this.tpVoice.Text = "语音问答题库";
            this.tpVoice.UseVisualStyleBackColor = true;
            // 
            // tpGo
            // 
            this.tpGo.Location = new System.Drawing.Point(4, 22);
            this.tpGo.Name = "tpGo";
            this.tpGo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGo.Size = new System.Drawing.Size(799, 476);
            this.tpGo.TabIndex = 2;
            this.tpGo.Text = "运动指令库";
            this.tpGo.UseVisualStyleBackColor = true;
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 502);
            this.Controls.Add(this.tcPage);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.tcPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPage;
        private System.Windows.Forms.TabPage tpNormal;
        private System.Windows.Forms.TabPage tpVoice;
        private System.Windows.Forms.TabPage tpGo;
    }
}