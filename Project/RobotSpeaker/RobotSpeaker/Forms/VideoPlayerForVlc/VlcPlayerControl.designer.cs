namespace VLCPlayerLib
{
    partial class VlcPlayerControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plDisplayControl = new System.Windows.Forms.Panel();
            this.lblVideoName = new System.Windows.Forms.Label();
            this.plPlayerControls = new System.Windows.Forms.Panel();
            this.gbPlayerButtons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new RobotSpeaker.Controls.ButtonExt();
            this.btnLast = new RobotSpeaker.Controls.ButtonExt();
            this.btnStop = new RobotSpeaker.Controls.ButtonExt();
            this.btnPause = new RobotSpeaker.Controls.ButtonExt();
            this.btnPlay = new RobotSpeaker.Controls.ButtonExt();
            this.trPlayerVolume = new System.Windows.Forms.TrackBar();
            this.lblPlayerTimeRange = new System.Windows.Forms.Label();
            this.trPlayerProgress = new System.Windows.Forms.TrackBar();
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.plDisplayControl.SuspendLayout();
            this.plPlayerControls.SuspendLayout();
            this.gbPlayerButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trPlayerVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPlayerProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // plDisplayControl
            // 
            this.plDisplayControl.BackColor = System.Drawing.Color.Black;
            this.plDisplayControl.Controls.Add(this.lblVideoName);
            this.plDisplayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDisplayControl.Location = new System.Drawing.Point(0, 0);
            this.plDisplayControl.Name = "plDisplayControl";
            this.plDisplayControl.Size = new System.Drawing.Size(993, 409);
            this.plDisplayControl.TabIndex = 1;
            // 
            // lblVideoName
            // 
            this.lblVideoName.BackColor = System.Drawing.Color.Black;
            this.lblVideoName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVideoName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVideoName.ForeColor = System.Drawing.Color.White;
            this.lblVideoName.Location = new System.Drawing.Point(0, 0);
            this.lblVideoName.Name = "lblVideoName";
            this.lblVideoName.Size = new System.Drawing.Size(993, 0);
            this.lblVideoName.TabIndex = 0;
            this.lblVideoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVideoName.Visible = false;
            // 
            // plPlayerControls
            // 
            this.plPlayerControls.Controls.Add(this.gbPlayerButtons);
            this.plPlayerControls.Controls.Add(this.trPlayerProgress);
            this.plPlayerControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plPlayerControls.Location = new System.Drawing.Point(0, 409);
            this.plPlayerControls.Name = "plPlayerControls";
            this.plPlayerControls.Size = new System.Drawing.Size(993, 85);
            this.plPlayerControls.TabIndex = 2;
            // 
            // gbPlayerButtons
            // 
            this.gbPlayerButtons.Controls.Add(this.label1);
            this.gbPlayerButtons.Controls.Add(this.btnNext);
            this.gbPlayerButtons.Controls.Add(this.btnLast);
            this.gbPlayerButtons.Controls.Add(this.btnStop);
            this.gbPlayerButtons.Controls.Add(this.btnPause);
            this.gbPlayerButtons.Controls.Add(this.btnPlay);
            this.gbPlayerButtons.Controls.Add(this.trPlayerVolume);
            this.gbPlayerButtons.Controls.Add(this.lblPlayerTimeRange);
            this.gbPlayerButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPlayerButtons.Location = new System.Drawing.Point(0, 26);
            this.gbPlayerButtons.Name = "gbPlayerButtons";
            this.gbPlayerButtons.Size = new System.Drawing.Size(993, 59);
            this.gbPlayerButtons.TabIndex = 12;
            this.gbPlayerButtons.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(676, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 39);
            this.label1.TabIndex = 17;
            this.label1.Text = "音量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnNext.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnNext.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnNext.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNext.Enabled = false;
            this.btnNext.EnabledMouseDownAndMouseUp = true;
            this.btnNext.Location = new System.Drawing.Point(303, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 39);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "前进";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnLast.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnLast.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnLast.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLast.Enabled = false;
            this.btnLast.EnabledMouseDownAndMouseUp = true;
            this.btnLast.Location = new System.Drawing.Point(228, 17);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 39);
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = "后退";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnStop
            // 
            this.btnStop.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnStop.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnStop.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnStop.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStop.Enabled = false;
            this.btnStop.EnabledMouseDownAndMouseUp = true;
            this.btnStop.Location = new System.Drawing.Point(153, 17);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 39);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnPause.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnPause.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnPause.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPause.Enabled = false;
            this.btnPause.EnabledMouseDownAndMouseUp = true;
            this.btnPause.Location = new System.Drawing.Point(78, 17);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 39);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "暂停";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnPlay.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnPlay.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.EnabledMouseDownAndMouseUp = true;
            this.btnPlay.Location = new System.Drawing.Point(3, 17);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 39);
            this.btnPlay.TabIndex = 12;
            this.btnPlay.Text = "播放";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // trPlayerVolume
            // 
            this.trPlayerVolume.AutoSize = false;
            this.trPlayerVolume.Dock = System.Windows.Forms.DockStyle.Right;
            this.trPlayerVolume.LargeChange = 1;
            this.trPlayerVolume.Location = new System.Drawing.Point(736, 17);
            this.trPlayerVolume.Maximum = 100;
            this.trPlayerVolume.Name = "trPlayerVolume";
            this.trPlayerVolume.Size = new System.Drawing.Size(104, 39);
            this.trPlayerVolume.TabIndex = 11;
            this.trPlayerVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trPlayerVolume.Scroll += new System.EventHandler(this.trPlayerVolume_Scroll);
            // 
            // lblPlayerTimeRange
            // 
            this.lblPlayerTimeRange.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPlayerTimeRange.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlayerTimeRange.ForeColor = System.Drawing.Color.White;
            this.lblPlayerTimeRange.Location = new System.Drawing.Point(840, 17);
            this.lblPlayerTimeRange.Name = "lblPlayerTimeRange";
            this.lblPlayerTimeRange.Size = new System.Drawing.Size(150, 39);
            this.lblPlayerTimeRange.TabIndex = 0;
            this.lblPlayerTimeRange.Text = "00:00:00/00:00:00";
            this.lblPlayerTimeRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trPlayerProgress
            // 
            this.trPlayerProgress.AutoSize = false;
            this.trPlayerProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.trPlayerProgress.Location = new System.Drawing.Point(0, 0);
            this.trPlayerProgress.Name = "trPlayerProgress";
            this.trPlayerProgress.Size = new System.Drawing.Size(993, 26);
            this.trPlayerProgress.TabIndex = 10;
            this.trPlayerProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trPlayerProgress.Scroll += new System.EventHandler(this.trPlayerProgress_Scroll);
            // 
            // tmrProgress
            // 
            this.tmrProgress.Interval = 1000;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // VlcPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.plDisplayControl);
            this.Controls.Add(this.plPlayerControls);
            this.Name = "VlcPlayerControl";
            this.Size = new System.Drawing.Size(993, 494);
            this.plDisplayControl.ResumeLayout(false);
            this.plPlayerControls.ResumeLayout(false);
            this.gbPlayerButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trPlayerVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPlayerProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plDisplayControl;
        private System.Windows.Forms.Panel plPlayerControls;
        private System.Windows.Forms.TrackBar trPlayerVolume;
        private System.Windows.Forms.TrackBar trPlayerProgress;
        private System.Windows.Forms.GroupBox gbPlayerButtons;
        private System.Windows.Forms.Label lblPlayerTimeRange;
        private RobotSpeaker.Controls.ButtonExt btnNext;
        private RobotSpeaker.Controls.ButtonExt btnLast;
        private RobotSpeaker.Controls.ButtonExt btnStop;
        private RobotSpeaker.Controls.ButtonExt btnPause;
        private RobotSpeaker.Controls.ButtonExt btnPlay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.Label lblVideoName;
    }
}
