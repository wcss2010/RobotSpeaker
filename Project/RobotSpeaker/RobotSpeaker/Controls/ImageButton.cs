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
        public Label TextLabel { get { return lblButtonTxt; } }

        /// <summary>
        /// 图片容器
        /// </summary>
        public PictureBox ImageBox { get { return pbButtonImage; } }

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

            pbButtonImage.Image = FocusImage;
        }

        private void pbButtonImage_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);

            pbButtonImage.Image = NoFocusImage;
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

            pbButtonImage.Image = FocusImage;
        }

        private void lblButtonTxt_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);

            pbButtonImage.Image = NoFocusImage;
        }
    }
}