namespace RobotSpeaker.Forms.Player
{
    partial class ImageViewerEx
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
            this.plButtons = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new RobotSpeaker.Controls.ButtonExt();
            this.btnEnd = new RobotSpeaker.Controls.ButtonExt();
            this.btnLast = new RobotSpeaker.Controls.ButtonExt();
            this.btnFirst = new RobotSpeaker.Controls.ButtonExt();
            this.picCurrent = new System.Windows.Forms.PictureBox();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.图片另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.plImageList = new System.Windows.Forms.Panel();
            this.picItem5 = new System.Windows.Forms.PictureBox();
            this.picItem4 = new System.Windows.Forms.PictureBox();
            this.picItem3 = new System.Windows.Forms.PictureBox();
            this.picItem2 = new System.Windows.Forms.PictureBox();
            this.picItem1 = new System.Windows.Forms.PictureBox();
            this.plCurrent = new System.Windows.Forms.Panel();
            this.dialog = new System.Windows.Forms.SaveFileDialog();
            this.plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.plImageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem1)).BeginInit();
            this.plCurrent.SuspendLayout();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plButtons.Controls.Add(this.lblPageInfo);
            this.plButtons.Controls.Add(this.btnNext);
            this.plButtons.Controls.Add(this.btnEnd);
            this.plButtons.Controls.Add(this.btnLast);
            this.plButtons.Controls.Add(this.btnFirst);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 387);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(992, 64);
            this.plButtons.TabIndex = 0;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.White;
            this.lblPageInfo.Location = new System.Drawing.Point(150, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(690, 62);
            this.lblPageInfo.TabIndex = 1;
            this.lblPageInfo.Text = "0/0";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnNext.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnNext.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnNext.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.EnabledMouseDownAndMouseUp = true;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(840, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 62);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "下一张";
            this.toolTip1.SetToolTip(this.btnNext, "下一张");
            this.btnNext.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnEnd.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnEnd.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnd.EnabledMouseDownAndMouseUp = true;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(915, 0);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 62);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.Text = "末  张";
            this.toolTip1.SetToolTip(this.btnEnd, "最后一张");
            this.btnEnd.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLast
            // 
            this.btnLast.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnLast.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnLast.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnLast.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLast.EnabledMouseDownAndMouseUp = true;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.Location = new System.Drawing.Point(75, 0);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 62);
            this.btnLast.TabIndex = 0;
            this.btnLast.Text = "上一张";
            this.toolTip1.SetToolTip(this.btnLast, "上一张");
            this.btnLast.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnFirst.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnFirst.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnFirst.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFirst.EnabledMouseDownAndMouseUp = true;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirst.Location = new System.Drawing.Point(0, 0);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 62);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "首  张";
            this.toolTip1.SetToolTip(this.btnFirst, "第一张");
            this.btnFirst.Click += new System.EventHandler(this.button1_Click);
            // 
            // picCurrent
            // 
            this.picCurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCurrent.ContextMenuStrip = this.cmsMenu;
            this.picCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCurrent.Location = new System.Drawing.Point(0, 0);
            this.picCurrent.Name = "picCurrent";
            this.picCurrent.Size = new System.Drawing.Size(992, 342);
            this.picCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrent.TabIndex = 1;
            this.picCurrent.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图片另存为ToolStripMenuItem});
            this.cmsMenu.Name = "contextMenuStrip1";
            this.cmsMenu.Size = new System.Drawing.Size(146, 26);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 图片另存为ToolStripMenuItem
            // 
            this.图片另存为ToolStripMenuItem.Name = "图片另存为ToolStripMenuItem";
            this.图片另存为ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.图片另存为ToolStripMenuItem.Text = "图片另存为...";
            this.图片另存为ToolStripMenuItem.Click += new System.EventHandler(this.图片另存为ToolStripMenuItem_Click);
            // 
            // plImageList
            // 
            this.plImageList.Controls.Add(this.picItem5);
            this.plImageList.Controls.Add(this.picItem4);
            this.plImageList.Controls.Add(this.picItem3);
            this.plImageList.Controls.Add(this.picItem2);
            this.plImageList.Controls.Add(this.picItem1);
            this.plImageList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plImageList.Location = new System.Drawing.Point(0, 342);
            this.plImageList.Name = "plImageList";
            this.plImageList.Size = new System.Drawing.Size(992, 45);
            this.plImageList.TabIndex = 2;
            // 
            // picItem5
            // 
            this.picItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem5.Location = new System.Drawing.Point(271, 1);
            this.picItem5.Name = "picItem5";
            this.picItem5.Size = new System.Drawing.Size(66, 42);
            this.picItem5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem5.TabIndex = 4;
            this.picItem5.TabStop = false;
            this.picItem5.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // picItem4
            // 
            this.picItem4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem4.Location = new System.Drawing.Point(204, 1);
            this.picItem4.Name = "picItem4";
            this.picItem4.Size = new System.Drawing.Size(66, 42);
            this.picItem4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem4.TabIndex = 3;
            this.picItem4.TabStop = false;
            this.picItem4.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // picItem3
            // 
            this.picItem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem3.Location = new System.Drawing.Point(137, 1);
            this.picItem3.Name = "picItem3";
            this.picItem3.Size = new System.Drawing.Size(66, 42);
            this.picItem3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem3.TabIndex = 2;
            this.picItem3.TabStop = false;
            this.picItem3.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picItem2
            // 
            this.picItem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem2.Location = new System.Drawing.Point(70, 1);
            this.picItem2.Name = "picItem2";
            this.picItem2.Size = new System.Drawing.Size(66, 42);
            this.picItem2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem2.TabIndex = 1;
            this.picItem2.TabStop = false;
            this.picItem2.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picItem1
            // 
            this.picItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem1.Location = new System.Drawing.Point(3, 1);
            this.picItem1.Name = "picItem1";
            this.picItem1.Size = new System.Drawing.Size(66, 42);
            this.picItem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem1.TabIndex = 0;
            this.picItem1.TabStop = false;
            this.picItem1.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // plCurrent
            // 
            this.plCurrent.Controls.Add(this.picCurrent);
            this.plCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCurrent.Location = new System.Drawing.Point(0, 0);
            this.plCurrent.Name = "plCurrent";
            this.plCurrent.Size = new System.Drawing.Size(992, 342);
            this.plCurrent.TabIndex = 3;
            // 
            // ImageViewerEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.plCurrent);
            this.Controls.Add(this.plImageList);
            this.Controls.Add(this.plButtons);
            this.MinimumSize = new System.Drawing.Size(340, 260);
            this.Name = "ImageViewerEx";
            this.Size = new System.Drawing.Size(992, 451);
            this.Resize += new System.EventHandler(this.ImageViewerEx_Resize);
            this.plButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.plImageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem1)).EndInit();
            this.plCurrent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Label lblPageInfo;
        private RobotSpeaker.Controls.ButtonExt btnNext;
        private RobotSpeaker.Controls.ButtonExt btnEnd;
        private RobotSpeaker.Controls.ButtonExt btnLast;
        private RobotSpeaker.Controls.ButtonExt btnFirst;
        private System.Windows.Forms.PictureBox picCurrent;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel plImageList;
        private System.Windows.Forms.PictureBox picItem5;
        private System.Windows.Forms.PictureBox picItem4;
        private System.Windows.Forms.PictureBox picItem3;
        private System.Windows.Forms.PictureBox picItem2;
        private System.Windows.Forms.PictureBox picItem1;
        private System.Windows.Forms.Panel plCurrent;
        private System.Windows.Forms.SaveFileDialog dialog;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem 图片另存为ToolStripMenuItem;
    }
}
