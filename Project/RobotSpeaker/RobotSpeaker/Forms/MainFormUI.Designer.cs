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
            this.ibAbout = new RobotSpeaker.Controls.ImageButton();
            this.ibGo = new RobotSpeaker.Controls.ImageButton();
            this.ibFace = new RobotSpeaker.Controls.ImageButton();
            this.ibVoice = new RobotSpeaker.Controls.ImageButton();
            this.ibSetting = new RobotSpeaker.Controls.ImageButton();
            this.SuspendLayout();
            // 
            // ibAbout
            // 
            this.ibAbout.BackColor = System.Drawing.Color.White;
            this.ibAbout.EnabledTextLabel = true;
            this.ibAbout.FocusImage = null;
            this.ibAbout.Location = new System.Drawing.Point(33, 84);
            this.ibAbout.Name = "ibAbout";
            this.ibAbout.NoFocusImage = null;
            this.ibAbout.Size = new System.Drawing.Size(178, 247);
            this.ibAbout.TabIndex = 5;
            // 
            // ibGo
            // 
            this.ibGo.BackColor = System.Drawing.Color.White;
            this.ibGo.EnabledTextLabel = true;
            this.ibGo.FocusImage = null;
            this.ibGo.Location = new System.Drawing.Point(226, 84);
            this.ibGo.Name = "ibGo";
            this.ibGo.NoFocusImage = null;
            this.ibGo.Size = new System.Drawing.Size(178, 247);
            this.ibGo.TabIndex = 6;
            // 
            // ibFace
            // 
            this.ibFace.BackColor = System.Drawing.Color.White;
            this.ibFace.EnabledTextLabel = true;
            this.ibFace.FocusImage = null;
            this.ibFace.Location = new System.Drawing.Point(623, 84);
            this.ibFace.Name = "ibFace";
            this.ibFace.NoFocusImage = null;
            this.ibFace.Size = new System.Drawing.Size(178, 247);
            this.ibFace.TabIndex = 7;
            // 
            // ibVoice
            // 
            this.ibVoice.BackColor = System.Drawing.Color.White;
            this.ibVoice.EnabledTextLabel = true;
            this.ibVoice.FocusImage = null;
            this.ibVoice.Location = new System.Drawing.Point(427, 84);
            this.ibVoice.Name = "ibVoice";
            this.ibVoice.NoFocusImage = null;
            this.ibVoice.Size = new System.Drawing.Size(172, 247);
            this.ibVoice.TabIndex = 8;
            // 
            // ibSetting
            // 
            this.ibSetting.BackColor = System.Drawing.Color.White;
            this.ibSetting.EnabledTextLabel = true;
            this.ibSetting.FocusImage = null;
            this.ibSetting.Location = new System.Drawing.Point(807, 84);
            this.ibSetting.Name = "ibSetting";
            this.ibSetting.NoFocusImage = null;
            this.ibSetting.Size = new System.Drawing.Size(178, 247);
            this.ibSetting.TabIndex = 9;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.ibAbout);
            this.Controls.Add(this.ibGo);
            this.Controls.Add(this.ibFace);
            this.Controls.Add(this.ibVoice);
            this.Controls.Add(this.ibSetting);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.Controls.SetChildIndex(this.ibSetting, 0);
            this.Controls.SetChildIndex(this.ibVoice, 0);
            this.Controls.SetChildIndex(this.ibFace, 0);
            this.Controls.SetChildIndex(this.ibGo, 0);
            this.Controls.SetChildIndex(this.ibAbout, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton ibAbout;
        private Controls.ImageButton ibGo;
        private Controls.ImageButton ibFace;
        private Controls.ImageButton ibVoice;
        private Controls.ImageButton ibSetting;

    }
}