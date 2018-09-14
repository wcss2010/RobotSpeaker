using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLCPlayerLib;
using System.IO;

namespace VLCPlayerLib
{
    /// <summary>
    /// 基于VLCPlayerCore的一个UI层
    /// </summary>
    public partial class VlcPlayerControl : UserControl
    {
        /// <summary>
        /// 开始播放事件
        /// </summary>
        public event StartOrStopEventDelegate StartEvent;

        /// <summary>
        /// 停止播放事件
        /// </summary>
        public event StartOrStopEventDelegate StopEvent;

        /// <summary>
        /// 播放进度事件
        /// </summary>
        public event ProgressEventDelegate ProgressEvent;

        private VlcPlayerCore _vlcPlayerCore = null;
        /// <summary>
        /// VLC播放器核心
        /// </summary>
        [Browsable(false)]
        public VlcPlayerCore VlcPlayerCore
        {
            get { return _vlcPlayerCore; }
        }

        /// <summary>
        /// 播放器插件路径
        /// </summary>
        [Browsable(false)]
        public string VlcPluginPath { get; set; }

        /// <summary>
        /// 播放器控制面板
        /// </summary>
        [Browsable(false)]
        public Panel PlayerControlPanel { get { return plPlayerControls; } }

        /// <summary>
        /// 是否允许显示播放器控制面板
        /// </summary>
        public bool EnabledDisplayPlayerControlPanel
        {
            get { return PlayerControlPanel.Visible; }
            set { PlayerControlPanel.Visible = value; }
        }

        private bool is_playinig = false;
        private bool media_is_open = false;//标记媒体文件是否打开，若未打开则tsbtn_play读ini打开之前的文件，若打开则跳过这步(避免每次都打开文件造成屏幕跳动)

        /// <summary>
        /// 媒体文件地址
        /// </summary>
        public string MediaUrl { get; set; }

        public VlcPlayerControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 初始化播放器
        /// </summary>
        public void InitPlayer()
        {
            //初始化播放器
            VlcPluginPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "plugins");
            _vlcPlayerCore = new VlcPlayerCore(VlcPluginPath);
            IntPtr render_wnd = plDisplayControl.Handle;
            _vlcPlayerCore.SetRenderWindow((int)render_wnd);
            trPlayerVolume.Value = 50;
            trPlayerProgress.Value = 0;
        }

        private void trPlayerVolume_Scroll(object sender, EventArgs e)
        {
            _vlcPlayerCore.SetVolume(trPlayerVolume.Value);
        }

        /// <summary>
        /// 设置媒体文件
        /// </summary>
        /// <param name="url"></param>
        public void SetMediaUrl(string urls)
        {
            MediaUrl = urls;

            VlcPlayerCore.PlayFile(MediaUrl);
            trPlayerProgress.SetRange(0, (int)VlcPlayerCore.Duration());
            trPlayerProgress.Value = 0;
            tmrProgress.Start();

            is_playinig = true;
            media_is_open = true;

            lblVideoName.Text = Path.GetFileNameWithoutExtension(MediaUrl);
            lblVideoName.Show();

            //设置按钮状态
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;

            btnPlay.PerformClick();
        }

        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //设置按钮状态
            btnPlay.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;

            if (!media_is_open)
            {
                VlcPlayerCore.PlayFile(MediaUrl);
            }
            trPlayerProgress.SetRange(0, (int)VlcPlayerCore.Duration());
            VlcPlayerCore.SetPlayTime(trPlayerProgress.Value);
            VlcPlayerCore.Play();
            trPlayerProgress.Value = (int)VlcPlayerCore.GetPlayTime();

            tmrProgress.Start();

            is_playinig = true;
            media_is_open = true;

            lblVideoName.Text = Path.GetFileNameWithoutExtension(MediaUrl);
            lblVideoName.Show();
            lblVideoName.BringToFront();

            if (StartEvent != null)
            {
                StartEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            //设置按钮状态
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;

            VlcPlayerCore.Pause();
            tmrProgress.Stop();
            is_playinig = false;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //设置按钮状态
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;

            VlcPlayerCore.Stop();
            tmrProgress.Stop();
            is_playinig = false;
            media_is_open = false;

            lblPlayerTimeRange.Text = "00:00:00/00:00:00";
            trPlayerProgress.Value = 0;
            lblVideoName.Hide();

            if (StopEvent != null)
            {
                StopEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            //设置按钮状态
            btnPlay.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;

            VlcPlayerCore.Pause();
            int time = (int)VlcPlayerCore.GetPlayTime() - 5;
            if (time > 0)
            {
                VlcPlayerCore.SetPlayTime(time);
            }
            else
            {
                VlcPlayerCore.SetPlayTime(0);
            }
            VlcPlayerCore.Play();
            trPlayerProgress.Value = (int)VlcPlayerCore.GetPlayTime();
        }

        /// <summary>
        /// 前进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            //设置按钮状态
            btnPlay.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;

            VlcPlayerCore.Pause();
            int time = (int)VlcPlayerCore.GetPlayTime() + 5;
            if (time < trPlayerProgress.Maximum)
            {
                VlcPlayerCore.SetPlayTime(time);
            }
            else
            {
                VlcPlayerCore.SetPlayTime(trPlayerProgress.Maximum);
            }
            VlcPlayerCore.Play();
            trPlayerProgress.Value = (int)VlcPlayerCore.GetPlayTime();
        }

        /// <summary>
        /// 播放进度滑块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trPlayerProgress_Scroll(object sender, EventArgs e)
        {
            if (is_playinig)
            {
                VlcPlayerCore.SetPlayTime(trPlayerProgress.Value);
                trPlayerProgress.Value = (int)VlcPlayerCore.GetPlayTime();
            }
        }

        /// <summary>
        /// 播放进度刷新计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            if (is_playinig)
            {
                if (trPlayerProgress.Value == trPlayerProgress.Maximum)
                {
                    btnStop.PerformClick();
                }
                else
                {
                    trPlayerProgress.Value = trPlayerProgress.Value + 1;
                    lblPlayerTimeRange.Text = string.Format("{0}/{1}", GetTimeString(trPlayerProgress.Value), GetTimeString(trPlayerProgress.Maximum));

                    if (ProgressEvent != null)
                    {
                        ProgressEventArgs pea = new ProgressEventArgs();
                        pea.Total = trPlayerProgress.Maximum;
                        pea.Value = trPlayerProgress.Value;
                        ProgressEvent(this, pea);
                    }
                }
            }
        }

        /// <summary>
        /// 时间格式化函数
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void StopPlayer()
        {
            btnStop.PerformClick();
        }
    }

    public delegate void StartOrStopEventDelegate(object sender, EventArgs args);

    public delegate void ProgressEventDelegate(object sender, ProgressEventArgs args);

    public class ProgressEventArgs : EventArgs
    {
        public double Total { get; set; }

        public double Value { get; set; }
    }
}