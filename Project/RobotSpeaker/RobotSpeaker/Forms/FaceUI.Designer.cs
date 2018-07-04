namespace RobotSpeaker.Forms
{
    partial class FaceUI
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnStopRecord = new RobotSpeaker.Controls.ButtonExt();
            this.btnPauseRecord = new RobotSpeaker.Controls.ButtonExt();
            this.btnGetPic = new RobotSpeaker.Controls.ImageButton();
            this.btnRecord = new RobotSpeaker.Controls.ImageButton();
            this.plMiddleButtons = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.plMiddleButtons.SuspendLayout();
            this.plContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Gray;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(24, 19);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(320, 640);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnStopRecord.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnStopRecord.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnStopRecord.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnStopRecord.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopRecord.Location = new System.Drawing.Point(376, 609);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(80, 50);
            this.btnStopRecord.TabIndex = 2;
            this.btnStopRecord.Text = "停止";
            this.btnStopRecord.Visible = false;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // btnPauseRecord
            // 
            this.btnPauseRecord.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnPauseRecord.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnPauseRecord.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnPauseRecord.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnPauseRecord.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseRecord.Location = new System.Drawing.Point(376, 545);
            this.btnPauseRecord.Name = "btnPauseRecord";
            this.btnPauseRecord.Size = new System.Drawing.Size(80, 50);
            this.btnPauseRecord.TabIndex = 3;
            this.btnPauseRecord.Text = "暂停";
            this.btnPauseRecord.Visible = false;
            this.btnPauseRecord.Click += new System.EventHandler(this.btnPauseRecord_Click);
            // 
            // btnGetPic
            // 
            this.btnGetPic.BottomText = "拍    照";
            this.btnGetPic.BottomTextColor = System.Drawing.Color.White;
            this.btnGetPic.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetPic.BottomTextHeight = 35;
            this.btnGetPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGetPic.EnabledTextLabel = true;
            this.btnGetPic.FocusImage = null;
            this.btnGetPic.Location = new System.Drawing.Point(0, 0);
            this.btnGetPic.Name = "btnGetPic";
            this.btnGetPic.NoFocusImage = null;
            this.btnGetPic.Size = new System.Drawing.Size(172, 180);
            this.btnGetPic.TabIndex = 4;
            this.btnGetPic.Click += new System.EventHandler(this.btnGetPic_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BottomText = "开始录像";
            this.btnRecord.BottomTextColor = System.Drawing.Color.White;
            this.btnRecord.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecord.BottomTextHeight = 35;
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRecord.EnabledTextLabel = true;
            this.btnRecord.FocusImage = null;
            this.btnRecord.Location = new System.Drawing.Point(0, 205);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.NoFocusImage = null;
            this.btnRecord.Size = new System.Drawing.Size(172, 180);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // plMiddleButtons
            // 
            this.plMiddleButtons.Controls.Add(this.btnGetPic);
            this.plMiddleButtons.Controls.Add(this.btnRecord);
            this.plMiddleButtons.Location = new System.Drawing.Point(457, 135);
            this.plMiddleButtons.Name = "plMiddleButtons";
            this.plMiddleButtons.Size = new System.Drawing.Size(172, 385);
            this.plMiddleButtons.TabIndex = 5;
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.btnPauseRecord);
            this.plContent.Controls.Add(this.btnStopRecord);
            this.plContent.Controls.Add(this.plMiddleButtons);
            this.plContent.Controls.Add(this.pbImage);
            this.plContent.Location = new System.Drawing.Point(181, 76);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(661, 680);
            this.plContent.TabIndex = 6;
            this.plContent.Paint += new System.Windows.Forms.PaintEventHandler(this.plContent_Paint);
            // 
            // FaceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 768);
            this.Controls.Add(this.plContent);
            this.Name = "FaceUI";
            this.Text = "FaceUI";
            this.TitleText = "摄像模式";
            this.TitleTextColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plContent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.plMiddleButtons.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private Controls.ButtonExt btnStopRecord;
        private Controls.ButtonExt btnPauseRecord;
        private Controls.ImageButton btnGetPic;
        private Controls.ImageButton btnRecord;
        private System.Windows.Forms.Panel plMiddleButtons;
        private System.Windows.Forms.Panel plContent;
    }
}