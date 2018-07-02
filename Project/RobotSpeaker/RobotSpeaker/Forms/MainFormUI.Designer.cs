namespace RobotSpeaker.Forms
{
    partial class MainFormUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormUI));
            this.ibAbout = new RobotSpeaker.Controls.ImageButton();
            this.ibGo = new RobotSpeaker.Controls.ImageButton();
            this.ibFace = new RobotSpeaker.Controls.ImageButton();
            this.ibVoice = new RobotSpeaker.Controls.ImageButton();
            this.ibSetting = new RobotSpeaker.Controls.ImageButton();
            this.plTabPanel = new System.Windows.Forms.Panel();
            this.plTabPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibAbout
            // 
            this.ibAbout.BackColor = System.Drawing.Color.Transparent;
            this.ibAbout.BottomText = "业务介绍";
            this.ibAbout.BottomTextColor = System.Drawing.Color.White;
            this.ibAbout.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibAbout.BottomTextHeight = 35;
            this.ibAbout.EnabledTextLabel = true;
            this.ibAbout.FocusImage = null;
            this.ibAbout.Location = new System.Drawing.Point(3, 3);
            this.ibAbout.Name = "ibAbout";
            this.ibAbout.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("ibAbout.NoFocusImage")));
            this.ibAbout.Size = new System.Drawing.Size(178, 200);
            this.ibAbout.TabIndex = 5;
            // 
            // ibGo
            // 
            this.ibGo.BackColor = System.Drawing.Color.Transparent;
            this.ibGo.BottomText = "运动模式";
            this.ibGo.BottomTextColor = System.Drawing.Color.White;
            this.ibGo.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibGo.BottomTextHeight = 35;
            this.ibGo.EnabledTextLabel = true;
            this.ibGo.FocusImage = null;
            this.ibGo.Location = new System.Drawing.Point(196, 3);
            this.ibGo.Name = "ibGo";
            this.ibGo.NoFocusImage = null;
            this.ibGo.Size = new System.Drawing.Size(178, 200);
            this.ibGo.TabIndex = 6;
            // 
            // ibFace
            // 
            this.ibFace.BackColor = System.Drawing.Color.Transparent;
            this.ibFace.BottomText = "摄像模式";
            this.ibFace.BottomTextColor = System.Drawing.Color.White;
            this.ibFace.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibFace.BottomTextHeight = 35;
            this.ibFace.EnabledTextLabel = true;
            this.ibFace.FocusImage = null;
            this.ibFace.Location = new System.Drawing.Point(390, 3);
            this.ibFace.Name = "ibFace";
            this.ibFace.NoFocusImage = null;
            this.ibFace.Size = new System.Drawing.Size(178, 200);
            this.ibFace.TabIndex = 7;
            // 
            // ibVoice
            // 
            this.ibVoice.BackColor = System.Drawing.Color.Transparent;
            this.ibVoice.BottomText = "语音对话";
            this.ibVoice.BottomTextColor = System.Drawing.Color.White;
            this.ibVoice.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibVoice.BottomTextHeight = 35;
            this.ibVoice.EnabledTextLabel = true;
            this.ibVoice.FocusImage = null;
            this.ibVoice.Location = new System.Drawing.Point(584, 3);
            this.ibVoice.Name = "ibVoice";
            this.ibVoice.NoFocusImage = null;
            this.ibVoice.Size = new System.Drawing.Size(178, 200);
            this.ibVoice.TabIndex = 8;
            // 
            // ibSetting
            // 
            this.ibSetting.BackColor = System.Drawing.Color.Transparent;
            this.ibSetting.BottomText = "设置";
            this.ibSetting.BottomTextColor = System.Drawing.Color.White;
            this.ibSetting.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibSetting.BottomTextHeight = 35;
            this.ibSetting.EnabledTextLabel = true;
            this.ibSetting.FocusImage = null;
            this.ibSetting.Location = new System.Drawing.Point(779, 3);
            this.ibSetting.Name = "ibSetting";
            this.ibSetting.NoFocusImage = null;
            this.ibSetting.Size = new System.Drawing.Size(178, 200);
            this.ibSetting.TabIndex = 9;
            // 
            // plTabPanel
            // 
            this.plTabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plTabPanel.Controls.Add(this.ibAbout);
            this.plTabPanel.Controls.Add(this.ibSetting);
            this.plTabPanel.Controls.Add(this.ibGo);
            this.plTabPanel.Controls.Add(this.ibVoice);
            this.plTabPanel.Controls.Add(this.ibFace);
            this.plTabPanel.Location = new System.Drawing.Point(33, 260);
            this.plTabPanel.Name = "plTabPanel";
            this.plTabPanel.Size = new System.Drawing.Size(954, 200);
            this.plTabPanel.TabIndex = 10;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.plTabPanel);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.TitleText = "";
            this.TitleTextColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plTabPanel, 0);
            this.plTabPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton ibAbout;
        private Controls.ImageButton ibGo;
        private Controls.ImageButton ibFace;
        private Controls.ImageButton ibVoice;
        private Controls.ImageButton ibSetting;
        private System.Windows.Forms.Panel plTabPanel;

    }
}