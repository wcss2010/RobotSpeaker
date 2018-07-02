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
        /// <summary>
        /// 是否已经按下
        /// </summary>
        protected bool IsPressed { get; set; }

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
            e.Graphics.Clear(this.BackColor);
            
            if (IsPressed)
            {
                //按下状态
                e.Graphics.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(1, 1, Width - 4, Height - 4));
            }

            //画白框
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.White), 2), new Rectangle(1, 1, Width - 4, Height - 4));

            //写白色的文字
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.White), new RectangleF(2, 2, Width - 4, Height - 4), sf);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            IsPressed = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            IsPressed = false;
            this.Invalidate();
        }
    }
}