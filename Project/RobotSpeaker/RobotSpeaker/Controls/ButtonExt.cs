using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls
{
    public partial class ButtonExt : Label
    {
        private Color _buttonPressedBackColor = Color.Orange;
        /// <summary>
        /// 按下背景色
        /// </summary>
        public Color ButtonPressedBackColor
        {
            get { return _buttonPressedBackColor; }
            set 
            {
                _buttonPressedBackColor = value;
                this.Invalidate();
            }
        }
        private Color _buttonNormalBackColor = Color.Transparent;
        /// <summary>
        /// 抬起背景色
        /// </summary>
        public Color ButtonNormalBackColor
        {
            get { return _buttonNormalBackColor; }
            set
            { 
                _buttonNormalBackColor = value;
                this.Invalidate();
            }
        }
        private Color _buttonPressedForeColor = Color.White;
        /// <summary>
        /// 按下前景色
        /// </summary>
        public Color ButtonPressedForeColor
        {
            get { return _buttonPressedForeColor; }
            set 
            { 
                _buttonPressedForeColor = value;
                this.Invalidate();
            }
        }
        private Color _buttonNormalForeColor = Color.White;
        /// <summary>
        /// 抬起前景色
        /// </summary>
        public Color ButtonNormalForeColor
        {
            get { return _buttonNormalForeColor; }
            set 
            {
                _buttonNormalForeColor = value;
                this.Invalidate();
            }
        }
        
        private bool _isPressed = false;
        /// <summary>
        /// 是否已经按下
        /// </summary>
        protected bool IsPressed
        {
            get { return _isPressed; }
            set
            {
                _isPressed = value;

                Invalidate();
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

        public ButtonExt()
        {
            InitializeComponent();

            AutoSize = false;
            IsPressed = false;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //清理面板
            e.Graphics.Clear(Color.Transparent);

            if (IsPressed)
            {
                //按下状态
                e.Graphics.FillRectangle(new SolidBrush(ButtonPressedBackColor), new Rectangle(1, 1, Width - 4, Height - 4));

                //画白框
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(ButtonPressedForeColor), 2), new Rectangle(1, 1, Width - 4, Height - 4));

                //写白色的文字
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(ButtonPressedForeColor), new RectangleF(2, 2, Width - 4, Height - 4), sf);
            }
            else
            {
                //抬起状态
                e.Graphics.FillRectangle(new SolidBrush(ButtonNormalBackColor), new Rectangle(1, 1, Width - 4, Height - 4));

                //画白框
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(ButtonNormalForeColor), 2), new Rectangle(1, 1, Width - 4, Height - 4));

                //写白色的文字
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(ButtonNormalForeColor), new RectangleF(2, 2, Width - 4, Height - 4), sf);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (EnabledMouseDownAndMouseUp)
            {
                IsPressed = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

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