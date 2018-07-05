using RobotSpeaker.Forms.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class AboutUI : PageUIBase
    {
        private Image listItemA;
        private Image listItemB;
        private Image listItemC;
        public AboutUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            listItemA = DataService.GetImage(Path.Combine(Application.StartupPath, "Images/listItem1.png"));
            listItemB = DataService.GetImage(Path.Combine(Application.StartupPath, "Images/listItem2.png"));
            listItemC = DataService.GetImage(Path.Combine(Application.StartupPath,"Images/listSelected.png"));

            plListBar.BackgroundImage = DataService.GetImage(Path.Combine(Application.StartupPath, "Images/listBar.png"));
            plListBar.BackgroundImageLayout = ImageLayout.Stretch;
            
            UpdateReadmeFiles();
        }

        /// <summary>
        /// 创建列表项
        /// </summary>
        /// <param name="content"></param>
        /// <param name="isBlackBackground"></param>
        /// <returns></returns>
        protected Label CreateListItem(string content, bool isBlackBackground)
        {
            Label textObj = new Label();
            textObj.AutoSize = false;
            textObj.Width = plListBar.Width;
            textObj.Height = plListBar.Height;

            textObj.Name = isBlackBackground + "";
            textObj.BackgroundImageLayout = ImageLayout.Stretch;
            if (isBlackBackground)
            {   
                textObj.BackgroundImage = listItemA;
            }
            else
            {
                textObj.BackgroundImage = listItemB;
            }

            textObj.ForeColor = Color.White;
            textObj.Font = new Font("微软雅黑", 18);
            textObj.TextAlign = ContentAlignment.MiddleLeft;
            textObj.Text = content;

            return textObj;
        }

        /// <summary>
        /// 刷新文件列表
        /// </summary>
        protected void UpdateReadmeFiles()
        {
            new Thread(new ThreadStart(delegate()
                {
                    bool isBlack = true;

                    List<Label> tempList = new List<Label>();

                    //表头
                    tempList.Add(CreateListItem("文件名称", isBlack));
                    isBlack = !isBlack;

                    string[] files = Directory.GetFiles(SuperObject.ReadmeDir);
                    if (files != null)
                    {
                        foreach (string f in files)
                        {
                            FileInfo fi = new FileInfo(f);

                            Label item = CreateListItem(fi.Name + "               上一次修改日期：" + fi.LastWriteTime, isBlack);
                            item.Tag = fi;
                            tempList.Add(item);

                            item.Click += item_Click;
                            item.MouseDown += item_MouseDown;
                            item.MouseUp += item_MouseUp;

                            isBlack = !isBlack;
                        }
                    }

                    if (IsHandleCreated)
                    {
                        Invoke(new MethodInvoker(delegate()
                            {
                                //清空列表
                                plListContent.Controls.Clear();

                                //向列表中增加条目
                                plListContent.Controls.AddRange(tempList.ToArray());
                            }));
                    }
                })).Start();
        }

        void item_MouseUp(object sender, MouseEventArgs e)
        {
            Label clickItem = (Label)sender;
            if (bool.Parse(clickItem.Name))
            {
                clickItem.BackgroundImage = listItemA;
            }
            else
            {
                clickItem.BackgroundImage = listItemB;
            }
        }

        void item_MouseDown(object sender, MouseEventArgs e)
        {
            Label clickItem = (Label)sender;
            clickItem.BackgroundImage = listItemC;            
        }

        void item_Click(object sender, EventArgs e)
        {
            try
            {
                Label clickItem = (Label)sender;
                FileInfo fi = (FileInfo)clickItem.Tag;

                //查找需要哪个播放器打开
                string extName = fi.Extension;
                if (ImagePlayerUI.SupportedExtName.Contains(extName))
                {
                    //图片
                    ImagePlayerUI p1 = new ImagePlayerUI(fi.FullName);
                    p1.Show();
                }
                else if (TextPlayerUI.SupportedExtName.Contains(extName))
                {
                    //文本
                    TextPlayerUI p2 = new TextPlayerUI(fi.FullName);
                    p2.Show();
                }
                else if (VideoAndAudioPlayerUI.SupportedExtName.Contains(extName))
                {
                    //视频
                    VideoAndAudioPlayerUI p3 = new VideoAndAudioPlayerUI(fi.FullName);
                    p3.Show();
                }
                else if (WebPlayerUI.SupportedExtName.Contains(extName))
                {
                    //网页
                    WebPlayerUI p3 = new WebPlayerUI(fi.FullName);
                    p3.Show();
                }
                else
                {
                    //未知
                    System.Diagnostics.Process.Start(fi.FullName);
                }
            }
            catch (Exception ex)
            {
                //打开失败
                MessageBox.Show("操作失败！Ex:" + ex.ToString());
            }
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {
            try
            {
               System.Diagnostics.Process pro = System.Diagnostics.Process.Start("explorer.exe", SuperObject.ReadmeDir);
               pro.WaitForExit();
            }
            catch (Exception ex) { }

            //刷新列表
            UpdateReadmeFiles();
        }

        private void btnToHome_Click(object sender, EventArgs e)
        {
            WebPlayerUI player = new WebPlayerUI(SuperObject.Config.WebSiteUrl);
            player.Show();
        }

        private void btnImagListPPT_Click(object sender, EventArgs e)
        {
            ImageListPlayerUI form = new ImageListPlayerUI();
            form.Show();
        }
    }
}