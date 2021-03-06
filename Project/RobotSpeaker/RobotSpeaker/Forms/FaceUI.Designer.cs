﻿namespace RobotSpeaker.Forms
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
            this.vsVideoSource = new AForge.Controls.VideoSourcePlayer();
            this.btnStopRecord = new RobotSpeaker.Controls.ButtonExt();
            this.btnPauseRecord = new RobotSpeaker.Controls.ButtonExt();
            this.btnGetPic = new RobotSpeaker.Controls.ImageButton();
            this.btnRecord = new RobotSpeaker.Controls.ImageButton();
            this.plMiddleButtons = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.plMiddleButtons.SuspendLayout();
            this.plContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsVideoSource
            // 
            this.vsVideoSource.BackColor = System.Drawing.Color.Black;
            this.vsVideoSource.BorderColor = System.Drawing.Color.White;
            this.vsVideoSource.Location = new System.Drawing.Point(26, 29);
            this.vsVideoSource.Name = "vsVideoSource";
            this.vsVideoSource.Size = new System.Drawing.Size(640, 480);
            this.vsVideoSource.TabIndex = 1;
            this.vsVideoSource.TabStop = false;
            this.vsVideoSource.VideoSource = null;
            this.vsVideoSource.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.vsVideoSource_NewFrame);
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnStopRecord.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnStopRecord.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnStopRecord.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnStopRecord.EnabledMouseDownAndMouseUp = true;
            this.btnStopRecord.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopRecord.Location = new System.Drawing.Point(25, 526);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(104, 60);
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
            this.btnPauseRecord.EnabledMouseDownAndMouseUp = true;
            this.btnPauseRecord.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseRecord.Location = new System.Drawing.Point(562, 526);
            this.btnPauseRecord.Name = "btnPauseRecord";
            this.btnPauseRecord.Size = new System.Drawing.Size(104, 60);
            this.btnPauseRecord.TabIndex = 3;
            this.btnPauseRecord.Text = "暂停";
            this.btnPauseRecord.Visible = false;
            this.btnPauseRecord.Click += new System.EventHandler(this.btnPauseRecord_Click);
            // 
            // btnGetPic
            // 
            this.btnGetPic.BottomText = "拍    照";
            this.btnGetPic.BottomTextColor = System.Drawing.Color.White;
            this.btnGetPic.BottomTextFont = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetPic.BottomTextHeight = 35;
            this.btnGetPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGetPic.EnabledMouseDownAndMouseUp = true;
            this.btnGetPic.EnabledTextLabel = true;
            this.btnGetPic.FocusImage = null;
            this.btnGetPic.IsPressed = false;
            this.btnGetPic.Location = new System.Drawing.Point(0, 0);
            this.btnGetPic.Name = "btnGetPic";
            this.btnGetPic.NoFocusImage = null;
            this.btnGetPic.Size = new System.Drawing.Size(133, 123);
            this.btnGetPic.TabIndex = 4;
            this.btnGetPic.Click += new System.EventHandler(this.btnGetPic_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BottomText = "开始录像";
            this.btnRecord.BottomTextColor = System.Drawing.Color.White;
            this.btnRecord.BottomTextFont = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecord.BottomTextHeight = 35;
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRecord.EnabledMouseDownAndMouseUp = true;
            this.btnRecord.EnabledTextLabel = true;
            this.btnRecord.FocusImage = null;
            this.btnRecord.IsPressed = false;
            this.btnRecord.Location = new System.Drawing.Point(0, 184);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.NoFocusImage = null;
            this.btnRecord.Size = new System.Drawing.Size(133, 123);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // plMiddleButtons
            // 
            this.plMiddleButtons.Controls.Add(this.btnGetPic);
            this.plMiddleButtons.Controls.Add(this.btnRecord);
            this.plMiddleButtons.Location = new System.Drawing.Point(693, 113);
            this.plMiddleButtons.Name = "plMiddleButtons";
            this.plMiddleButtons.Size = new System.Drawing.Size(133, 307);
            this.plMiddleButtons.TabIndex = 5;
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.btnPauseRecord);
            this.plContent.Controls.Add(this.btnStopRecord);
            this.plContent.Controls.Add(this.plMiddleButtons);
            this.plContent.Controls.Add(this.vsVideoSource);
            this.plContent.Location = new System.Drawing.Point(33, 76);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(851, 599);
            this.plContent.TabIndex = 6;
            this.plContent.Paint += new System.Windows.Forms.PaintEventHandler(this.plContent_Paint);
            // 
            // FaceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.plContent);
            this.EnabledDisplayWifiLogo = true;
            this.Name = "FaceUI";
            this.Text = "FaceUI";
            this.TimeTextForeColor = System.Drawing.Color.White;
            this.TitleText = "摄像模式";
            this.TitleTextForeColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.plContent, 0);
            this.plMiddleButtons.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer vsVideoSource;
        private Controls.ButtonExt btnStopRecord;
        private Controls.ButtonExt btnPauseRecord;
        private Controls.ImageButton btnGetPic;
        private Controls.ImageButton btnRecord;
        private System.Windows.Forms.Panel plMiddleButtons;
        private System.Windows.Forms.Panel plContent;
    }
}