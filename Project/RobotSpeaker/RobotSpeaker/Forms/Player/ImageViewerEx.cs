using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace RobotSpeaker.Forms.Player
{
    [DefaultProperty("Sort")]
    [DefaultEvent("ImageChanged")]
    public partial class ImageViewerEx : UserControl
    {
        public ImageViewerEx()
        {
            InitializeComponent();
            DisableAllButtons();
            files = new List<string>();
        }

        int index;
        int pageCount;
        bool sort;
        List<string> files;

        [Browsable(false)]
        public List<string> Files
        {
            get { return files; }
            set
            {
                if (value != null)
                    files = value;
                else
                    files = new List<string>();
            }
        }

        [Description("是否对目录下的图片名进行排序")]
        [DefaultValue(false)]
        public bool Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        [Description("大图的显示模式")]
        [DefaultValue(PictureBoxSizeMode.Zoom)]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return picCurrent.SizeMode;
            }
            set
            {
                picCurrent.SizeMode = value;
            }
        }

        public event EventHandler<ImageArgsEx> ImageChanged;

        private void OnImageChanged(ImageArgsEx e)
        {
            if (ImageChanged != null)
                ImageChanged(this, e);
        }

        public bool SetImagePath(string path)
        {
            if (Directory.Exists(path))
            {
                pageCount = 0;
                string searchPattern = "*.bmp|*.jpg|*.jpeg|*.gif|*.png|*.emf|*.exif|*.ico|*.tiff|*.wmf";
                string[] searchPatterns = searchPattern.Split('|');
                files.Clear();
                foreach (string sp in searchPatterns)
                {
                    files.AddRange(Directory.GetFiles(path, sp, SearchOption.TopDirectoryOnly));
                }
                pageCount = files.Count;
                if (pageCount > 0)
                {
                    if (sort)
                        files.Sort();
                    First();
                    picCurrent.ImageLocation = picItem1.ImageLocation;
                    OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
                    return true;
                }
            }
            DisableAllButtons();
            if (picCurrent.Image != null)
                picCurrent.Image.Dispose();
            picCurrent.Image = null;
            if (picItem1.Image != null)
                picItem1.Image.Dispose();
            picItem1.Image = null;
            if (picItem2.Image != null)
                picItem2.Image.Dispose();
            picItem2.Image = null;
            if (picItem3.Image != null)
                picItem3.Image.Dispose();
            picItem3.Image = null;
            if (picItem4.Image != null)
                picItem4.Image.Dispose();
            picItem4.Image = null;
            if (picItem5.Image != null)
                picItem5.Image.Dispose();
            picItem5.Image = null;
            lblPageInfo.Text = "0/0";
            return false;
        }

        private void DisableAllButtons()
        {
            btnFirst.Enabled = btnLast.Enabled = btnNext.Enabled = btnEnd.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            First();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prex();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Last();
        }

        private void First()
        {
            index = 0;
            if (LoadImage())
            {
                btnFirst.Enabled = btnLast.Enabled = false;
                if (pageCount == 1)
                {
                    btnEnd.Enabled = btnNext.Enabled = false;
                }
                else
                {
                    btnEnd.Enabled = btnNext.Enabled = true;
                }
            }
        }

        private void Prex()
        {
            if (index > 0)
            {
                index--;
                if (LoadImage())
                {
                    btnNext.Enabled = true;
                    if (index == 0)
                    {
                        btnFirst.Enabled = btnLast.Enabled = false;
                    }
                    if (index < pageCount - 1)
                    {
                        btnEnd.Enabled = btnNext.Enabled = true;
                    }
                }
            }
        }

        private void Next()
        {
            if (index < pageCount - 1)
            {
                index++;
                if (LoadImage())
                {
                    btnLast.Enabled = true;
                    if (index == pageCount - 1)
                    {
                        btnEnd.Enabled = btnNext.Enabled = false;
                    }
                    if (index > 0)
                    {
                        btnFirst.Enabled = btnLast.Enabled = true;
                    }
                }
            }
        }

        private void Last()
        {
            index = pageCount - 1;
            if (LoadImage())
            {
                btnEnd.Enabled = btnNext.Enabled = false;
                if (pageCount == 1)
                {
                    btnFirst.Enabled = btnLast.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = btnLast.Enabled = true;
                }
            }
        }

        private bool LoadImage()
        {
            if (files.Count > 0 && index > -1)
            {
                if (index > files.Count - 1)
                    index = files.Count - 1;
                string imageFile2 = files[index];
                picCurrent.ImageLocation = picItem1.ImageLocation = imageFile2;
                if (index + 1 < files.Count)
                {
                    string imageFile3 = files[index + 1];
                    picItem2.ImageLocation = imageFile3;
                }
                else
                {
                    if (picItem2.Image != null)
                        picItem2.Image.Dispose();
                    picItem2.Image = null;
                }
                if (index + 2 < files.Count)
                {
                    string imageFile4 = files[index + 2];
                    picItem3.ImageLocation = imageFile4;
                }
                else
                {
                    if (picItem3.Image != null)
                        picItem3.Image.Dispose();
                    picItem3.Image = null;
                }
                if (index + 3 < files.Count)
                {
                    string imageFile5 = files[index + 3];
                    picItem4.ImageLocation = imageFile5;
                }
                else
                {
                    if (picItem4.Image != null)
                        picItem4.Image.Dispose();
                    picItem4.Image = null;
                }
                if (index + 4 < files.Count)
                {
                    string imageFile6 = files[index + 4];
                    picItem5.ImageLocation = imageFile6;
                }
                else
                {
                    if (picItem5.Image != null)
                        picItem5.Image.Dispose();
                    picItem5.Image = null;
                }
                lblPageInfo.Text = (index + 1) + "/" + pageCount;
                return true;
            }
            else
            {
                DisableAllButtons();
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
                if (picItem1.Image != null)
                    picItem1.Image.Dispose();
                picItem1.Image = null;
                if (picItem2.Image != null)
                    picItem2.Image.Dispose();
                picItem2.Image = null;
                if (picItem3.Image != null)
                    picItem3.Image.Dispose();
                picItem3.Image = null;
                if (picItem4.Image != null)
                    picItem4.Image.Dispose();
                picItem4.Image = null;
                if (picItem5.Image != null)
                    picItem5.Image.Dispose();
                picItem5.Image = null;
                lblPageInfo.Text = "0/0";
                return false;
            }
        }

        private void ImageViewerEx_Resize(object sender, EventArgs e)
        {
            int width = plImageList.Width;
            int perWidth = width / 5 - 2;
            picItem1.Width = picItem2.Width = picItem3.Width = picItem4.Width = picItem5.Width = perWidth;
            int perHeight = (int)Math.Round(perWidth * (42.0 / 66.0));
            picItem1.Height = picItem2.Height = picItem3.Height = picItem4.Height = picItem5.Height = plImageList.Height = perHeight;
            picItem2.Left = picItem1.Left + picItem1.Width + 2;
            picItem3.Left = picItem2.Left + picItem2.Width + 2;
            picItem4.Left = picItem3.Left + picItem3.Width + 2;
            picItem5.Left = picItem4.Left + picItem4.Width + 2;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (picItem1.Image != null)
            {
                picCurrent.ImageLocation = picItem1.ImageLocation;
                OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
            }
            else
            {
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
            }
            picItem1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picItem2.BorderStyle = picItem3.BorderStyle = picItem4.BorderStyle = picItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (picItem2.Image != null)
            {
                picCurrent.ImageLocation = picItem2.ImageLocation;
                OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
            }
            else
            {
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
            }
            picItem2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picItem1.BorderStyle = picItem3.BorderStyle = picItem4.BorderStyle = picItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (picItem3.Image != null)
            {
                picCurrent.ImageLocation = picItem3.ImageLocation;
                OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
            }
            else
            {
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
            }
            picItem3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picItem1.BorderStyle = picItem2.BorderStyle = picItem4.BorderStyle = picItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (picItem4.Image != null)
            {
                picCurrent.ImageLocation = picItem4.ImageLocation;
                OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
            }
            else
            {
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
            }
            picItem4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picItem1.BorderStyle = picItem2.BorderStyle = picItem3.BorderStyle = picItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (picItem5.Image != null)
            {
                picCurrent.ImageLocation = picItem5.ImageLocation;
                OnImageChanged(new ImageArgsEx(picCurrent.ImageLocation, index, pageCount));
            }
            else
            {
                if (picCurrent.Image != null)
                    picCurrent.Image.Dispose();
                picCurrent.Image = null;
            }
            picItem5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picItem1.BorderStyle = picItem2.BorderStyle = picItem3.BorderStyle = picItem4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void 图片另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.Title = "图片另存为";
            dialog.Filter = "jpg图片(*.jpg)|*.jpg|png图片(*.png)|*.png|bmp图片(*.bmp)|*.bmp|gif图片(*.gif)|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                switch (dialog.FilterIndex)
                {
                    case 1:
                        picCurrent.Image.Save(dialog.FileName, ImageFormat.Jpeg);
                        break;
                    case 2:
                        picCurrent.Image.Save(dialog.FileName, ImageFormat.Png);
                        break;
                    case 3:
                        picCurrent.Image.Save(dialog.FileName, ImageFormat.Bmp);
                        break;
                    case 4:
                        picCurrent.Image.Save(dialog.FileName, ImageFormat.Gif);
                        break;
                }
                if (MessageBox.Show("保存成功！需要立即打开查看吗？", "查看提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Process.Start(dialog.FileName);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (picCurrent.Image == null)
                cmsMenu.Enabled = false;
        }
    }

    public class ImageArgsEx : EventArgs
    {
        string imageFilepath;

        public string ImageFilepath
        {
            get { return imageFilepath; }
        }
        int imageIndex;

        public int ImageIndex
        {
            get { return imageIndex; }
        }
        int imageCount;

        public int ImageCount
        {
            get { return imageCount; }
        }

        public ImageArgsEx(string imageFilepath, int imageIndex, int imageCount)
        {
            if (!File.Exists(imageFilepath))
                throw new ArgumentException("指定的图片文件不存在！", "imageFilepath");
            this.imageFilepath = imageFilepath;
            this.imageIndex = imageIndex;
            this.imageCount = imageCount;
        }

        public override string ToString()
        {
            return Path.GetFileName(imageFilepath);
        }
    }
}
