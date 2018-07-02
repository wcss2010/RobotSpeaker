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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ibAbout = new RobotSpeaker.Controls.ImageButton();
            this.ibGo = new RobotSpeaker.Controls.ImageButton();
            this.ibFace = new RobotSpeaker.Controls.ImageButton();
            this.ibVoice = new RobotSpeaker.Controls.ImageButton();
            this.ibSetting = new RobotSpeaker.Controls.ImageButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1031, 423);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.ibAbout, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ibGo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ibFace, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ibVoice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.ibSetting, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(106, 138);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(818, 146);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ibAbout
            // 
            this.ibAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibAbout.EnabledTextLabel = true;
            this.ibAbout.FocusImage = null;
            this.ibAbout.Location = new System.Drawing.Point(3, 3);
            this.ibAbout.Name = "ibAbout";
            this.ibAbout.NoFocusImage = null;
            this.ibAbout.Size = new System.Drawing.Size(157, 241);
            this.ibAbout.TabIndex = 0;
            // 
            // ibGo
            // 
            this.ibGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibGo.EnabledTextLabel = true;
            this.ibGo.FocusImage = null;
            this.ibGo.Location = new System.Drawing.Point(166, 3);
            this.ibGo.Name = "ibGo";
            this.ibGo.NoFocusImage = null;
            this.ibGo.Size = new System.Drawing.Size(157, 241);
            this.ibGo.TabIndex = 1;
            // 
            // ibFace
            // 
            this.ibFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibFace.EnabledTextLabel = true;
            this.ibFace.FocusImage = null;
            this.ibFace.Location = new System.Drawing.Point(329, 3);
            this.ibFace.Name = "ibFace";
            this.ibFace.NoFocusImage = null;
            this.ibFace.Size = new System.Drawing.Size(157, 241);
            this.ibFace.TabIndex = 2;
            // 
            // ibVoice
            // 
            this.ibVoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibVoice.EnabledTextLabel = true;
            this.ibVoice.FocusImage = null;
            this.ibVoice.Location = new System.Drawing.Point(492, 3);
            this.ibVoice.Name = "ibVoice";
            this.ibVoice.NoFocusImage = null;
            this.ibVoice.Size = new System.Drawing.Size(157, 241);
            this.ibVoice.TabIndex = 3;
            // 
            // ibSetting
            // 
            this.ibSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibSetting.EnabledTextLabel = true;
            this.ibSetting.FocusImage = null;
            this.ibSetting.Location = new System.Drawing.Point(655, 3);
            this.ibSetting.Name = "ibSetting";
            this.ibSetting.NoFocusImage = null;
            this.ibSetting.Size = new System.Drawing.Size(160, 241);
            this.ibSetting.TabIndex = 4;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.ImageButton ibAbout;
        private Controls.ImageButton ibGo;
        private Controls.ImageButton ibFace;
        private Controls.ImageButton ibVoice;
        private Controls.ImageButton ibSetting;
    }
}