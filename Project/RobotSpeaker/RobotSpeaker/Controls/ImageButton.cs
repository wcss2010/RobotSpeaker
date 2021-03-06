﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls
{
    /// <summary>
    /// 图片按钮
    /// </summary>
    public partial class ImageButton : UserControl
    {
        private Image _focusImage = null;
        /// <summary>
        /// 获得焦点图片
        /// </summary>
        public Image FocusImage
        {
            get { return _focusImage; }
            set { _focusImage = value; }
        }

        private Image _noFocusImage = null;
        /// <summary>
        /// 失去焦点图片
        /// </summary>
        public Image NoFocusImage
        {
            get { return _noFocusImage; }
            set {
                _noFocusImage = value;
                pbButtonImage.Image = value;
            }
        }

        /// <summary>
        /// 文本标签
        /// </summary>
        [Browsable(false)]
        public Label TextLabel { get { return lblButtonTxt; } }

        /// <summary>
        /// 图片容器
        /// </summary>
        [Browsable(false)]
        public PictureBox ImageBox { get { return pbButtonImage; } }

        /// <summary>
        /// 是否允许显示文本标签
        /// </summary>
        public bool EnabledTextLabel
        {
            get
            {
                return TextLabel.Height > 0;
            }
            set
            {
                if (value)
                {
                    TextLabel.Height = 35;
                }
                else
                {
                    TextLabel.Height = 0;
                }
            }
        }

        public string BottomText 
        {
            get { return TextLabel.Text; }
            set { TextLabel.Text = value; }
        }

        public Color BottomTextColor
        {
            get { return TextLabel.ForeColor; }
            set { TextLabel.ForeColor = value; }
        }

        public Font BottomTextFont
        {
            get { return TextLabel.Font; }
            set { TextLabel.Font = value; }
        }

        public int BottomTextHeight
        {
            get { return TextLabel.Height; }
            set { TextLabel.Height = value; }
        }

        private bool _isPressed = false;
        /// <summary>
        /// 按键状态
        /// </summary>
        public bool IsPressed
        {
            get { return _isPressed; }
            set
            { 
                _isPressed = value;

                if (value)
                {
                    //按下
                    pbButtonImage.Image = FocusImage;
                }
                else
                {
                    //抬起
                    pbButtonImage.Image = NoFocusImage;
                }
            }
        }

        private bool _enabledMouseDownAndMouseUp = true;
        /// <summary>
        /// 是否允许处理Down和Up
        /// </summary>
        public bool EnabledMouseDownAndMouseUp
        {
            get { return _enabledMouseDownAndMouseUp; }
            set { _enabledMouseDownAndMouseUp = value; }
        }

        public ImageButton()
        {
            InitializeComponent();
        }

        private void pbButtonImage_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void pbButtonImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }

        private void pbButtonImage_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void pbButtonImage_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);

            if (EnabledMouseDownAndMouseUp)
            {
                IsPressed = true;
            }
        }

        private void pbButtonImage_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);

            if (EnabledMouseDownAndMouseUp)
            {
                IsPressed = false;
            }
        }

        private void lblButtonTxt_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblButtonTxt_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void lblButtonTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }

        private void lblButtonTxt_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);

            if (EnabledMouseDownAndMouseUp)
            {
                IsPressed = true;
            }
        }

        private void lblButtonTxt_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);

            if (EnabledMouseDownAndMouseUp)
            {
                IsPressed = false;
            }
        }

        public void PerformClick()
        {
            OnClick(new EventArgs());
        }
    }
}