namespace RobotSpeaker.Forms
{
    partial class GoUI
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
            this.plTabPanel = new System.Windows.Forms.Panel();
            this.ibFree = new RobotSpeaker.Controls.ImageButton();
            this.ibUseDevice = new RobotSpeaker.Controls.ImageButton();
            this.ibNormal = new RobotSpeaker.Controls.ImageButton();
            this.plTabPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTabPanel
            // 
            this.plTabPanel.Controls.Add(this.ibFree);
            this.plTabPanel.Controls.Add(this.ibUseDevice);
            this.plTabPanel.Controls.Add(this.ibNormal);
            this.plTabPanel.Location = new System.Drawing.Point(43, 143);
            this.plTabPanel.Name = "plTabPanel";
            this.plTabPanel.Size = new System.Drawing.Size(572, 200);
            this.plTabPanel.TabIndex = 11;
            // 
            // ibFree
            // 
            this.ibFree.BackColor = System.Drawing.Color.Transparent;
            this.ibFree.BottomText = "自由导航模式";
            this.ibFree.BottomTextColor = System.Drawing.Color.White;
            this.ibFree.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibFree.BottomTextHeight = 35;
            this.ibFree.EnabledTextLabel = true;
            this.ibFree.FocusImage = null;
            this.ibFree.Location = new System.Drawing.Point(392, 0);
            this.ibFree.Name = "ibFree";
            this.ibFree.NoFocusImage = null;
            this.ibFree.Size = new System.Drawing.Size(178, 200);
            this.ibFree.TabIndex = 9;
            this.ibFree.Click += new System.EventHandler(this.ibFree_Click);
            // 
            // ibUseDevice
            // 
            this.ibUseDevice.BackColor = System.Drawing.Color.Transparent;
            this.ibUseDevice.BottomText = "遥控模式";
            this.ibUseDevice.BottomTextColor = System.Drawing.Color.White;
            this.ibUseDevice.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibUseDevice.BottomTextHeight = 35;
            this.ibUseDevice.EnabledTextLabel = true;
            this.ibUseDevice.FocusImage = null;
            this.ibUseDevice.Location = new System.Drawing.Point(197, 0);
            this.ibUseDevice.Name = "ibUseDevice";
            this.ibUseDevice.NoFocusImage = null;
            this.ibUseDevice.Size = new System.Drawing.Size(178, 200);
            this.ibUseDevice.TabIndex = 8;
            this.ibUseDevice.Click += new System.EventHandler(this.ibUseDevice_Click);
            // 
            // ibNormal
            // 
            this.ibNormal.BackColor = System.Drawing.Color.Transparent;
            this.ibNormal.BottomText = "静止模式(默认)";
            this.ibNormal.BottomTextColor = System.Drawing.Color.White;
            this.ibNormal.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibNormal.BottomTextHeight = 35;
            this.ibNormal.EnabledTextLabel = true;
            this.ibNormal.FocusImage = null;
            this.ibNormal.Location = new System.Drawing.Point(0, 0);
            this.ibNormal.Name = "ibNormal";
            this.ibNormal.NoFocusImage = null;
            this.ibNormal.Size = new System.Drawing.Size(178, 200);
            this.ibNormal.TabIndex = 7;
            this.ibNormal.Click += new System.EventHandler(this.ibNormal_Click);
            // 
            // GoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.plTabPanel);
            this.Name = "GoUI";
            this.Text = "GoUI";
            this.TitleText = "运动模式";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plTabPanel, 0);
            this.plTabPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTabPanel;
        private Controls.ImageButton ibFree;
        private Controls.ImageButton ibUseDevice;
        private Controls.ImageButton ibNormal;
    }
}