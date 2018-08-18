namespace RobotSportTaskEditor.Controls
{
    partial class ActionDesignControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionDesignControl));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlDesignView = new TimeBeam.Timeline();
            this.cmsTimeLineMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scTopAndDown = new System.Windows.Forms.SplitContainer();
            this.scLeftAndRight = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgPropertyView = new System.Windows.Forms.PropertyGrid();
            this.lblSelected = new System.Windows.Forms.Label();
            this.plMiddleContent = new System.Windows.Forms.Panel();
            this.plRobotToolBox = new System.Windows.Forms.Panel();
            this.lblDesignToolBoxTitle = new System.Windows.Forms.Label();
            this.plRobotDesignToolBox = new System.Windows.Forms.Panel();
            this.lblDevice13 = new System.Windows.Forms.Label();
            this.lblDevice12 = new System.Windows.Forms.Label();
            this.lblDevice0 = new System.Windows.Forms.Label();
            this.lblDevice1 = new System.Windows.Forms.Label();
            this.lblDevice2 = new System.Windows.Forms.Label();
            this.lblDevice3 = new System.Windows.Forms.Label();
            this.lblDevice4 = new System.Windows.Forms.Label();
            this.pbRoBot = new System.Windows.Forms.PictureBox();
            this.lblDevice11 = new System.Windows.Forms.Label();
            this.lblDevice5 = new System.Windows.Forms.Label();
            this.lblDevice10 = new System.Windows.Forms.Label();
            this.lblDevice6 = new System.Windows.Forms.Label();
            this.lblDevice9 = new System.Windows.Forms.Label();
            this.lblDevice7 = new System.Windows.Forms.Label();
            this.lblDevice8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.cmsTimeLineMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTopAndDown)).BeginInit();
            this.scTopAndDown.Panel1.SuspendLayout();
            this.scTopAndDown.Panel2.SuspendLayout();
            this.scTopAndDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scLeftAndRight)).BeginInit();
            this.scLeftAndRight.Panel1.SuspendLayout();
            this.scLeftAndRight.Panel2.SuspendLayout();
            this.scLeftAndRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.plMiddleContent.SuspendLayout();
            this.plRobotToolBox.SuspendLayout();
            this.plRobotDesignToolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tlDesignView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1338, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "动作执行流程";
            // 
            // tlDesignView
            // 
            this.tlDesignView.AllowDrop = true;
            this.tlDesignView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tlDesignView.BackgroundColor = System.Drawing.Color.Black;
            this.tlDesignView.Clock = null;
            this.tlDesignView.ContextMenuStrip = this.cmsTimeLineMenu;
            this.tlDesignView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDesignView.GridAlpha = 40;
            this.tlDesignView.Location = new System.Drawing.Point(3, 17);
            this.tlDesignView.Name = "tlDesignView";
            this.tlDesignView.Size = new System.Drawing.Size(1332, 100);
            this.tlDesignView.TabIndex = 0;
            this.tlDesignView.Text = "timeline1";
            this.tlDesignView.TrackBorderSize = 2;
            this.tlDesignView.TrackHeight = 30;
            this.tlDesignView.TrackSpacing = 1;
            this.tlDesignView.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlDesignView_DragEnter);
            this.tlDesignView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tlDesignView_KeyDown);
            // 
            // cmsTimeLineMenu
            // 
            this.cmsTimeLineMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmsTimeLineMenu.Name = "cmsTimeLineMenu";
            this.cmsTimeLineMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除此项";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // scTopAndDown
            // 
            this.scTopAndDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTopAndDown.Location = new System.Drawing.Point(0, 0);
            this.scTopAndDown.Name = "scTopAndDown";
            this.scTopAndDown.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTopAndDown.Panel1
            // 
            this.scTopAndDown.Panel1.Controls.Add(this.groupBox2);
            this.scTopAndDown.Panel1MinSize = 120;
            // 
            // scTopAndDown.Panel2
            // 
            this.scTopAndDown.Panel2.Controls.Add(this.scLeftAndRight);
            this.scTopAndDown.Size = new System.Drawing.Size(1338, 762);
            this.scTopAndDown.SplitterDistance = 120;
            this.scTopAndDown.TabIndex = 6;
            this.scTopAndDown.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // scLeftAndRight
            // 
            this.scLeftAndRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scLeftAndRight.Location = new System.Drawing.Point(0, 0);
            this.scLeftAndRight.Name = "scLeftAndRight";
            // 
            // scLeftAndRight.Panel1
            // 
            this.scLeftAndRight.Panel1.Controls.Add(this.groupBox1);
            this.scLeftAndRight.Panel1MinSize = 270;
            // 
            // scLeftAndRight.Panel2
            // 
            this.scLeftAndRight.Panel2.Controls.Add(this.plMiddleContent);
            this.scLeftAndRight.Size = new System.Drawing.Size(1338, 638);
            this.scLeftAndRight.SplitterDistance = 270;
            this.scLeftAndRight.TabIndex = 6;
            this.scLeftAndRight.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgPropertyView);
            this.groupBox1.Controls.Add(this.lblSelected);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 638);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // pgPropertyView
            // 
            this.pgPropertyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgPropertyView.Location = new System.Drawing.Point(3, 40);
            this.pgPropertyView.Name = "pgPropertyView";
            this.pgPropertyView.Size = new System.Drawing.Size(264, 595);
            this.pgPropertyView.TabIndex = 0;
            // 
            // lblSelected
            // 
            this.lblSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelected.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelected.Location = new System.Drawing.Point(3, 17);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(264, 23);
            this.lblSelected.TabIndex = 1;
            this.lblSelected.Text = "(无)";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plMiddleContent
            // 
            this.plMiddleContent.AutoScroll = true;
            this.plMiddleContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.plMiddleContent.Controls.Add(this.plRobotToolBox);
            this.plMiddleContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddleContent.Location = new System.Drawing.Point(0, 0);
            this.plMiddleContent.Name = "plMiddleContent";
            this.plMiddleContent.Size = new System.Drawing.Size(1064, 638);
            this.plMiddleContent.TabIndex = 3;
            // 
            // plRobotToolBox
            // 
            this.plRobotToolBox.BackColor = System.Drawing.Color.White;
            this.plRobotToolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plRobotToolBox.Controls.Add(this.lblDesignToolBoxTitle);
            this.plRobotToolBox.Controls.Add(this.plRobotDesignToolBox);
            this.plRobotToolBox.Controls.Add(this.pictureBox4);
            this.plRobotToolBox.Controls.Add(this.pictureBox3);
            this.plRobotToolBox.Controls.Add(this.pictureBox2);
            this.plRobotToolBox.Controls.Add(this.pictureBox1);
            this.plRobotToolBox.Location = new System.Drawing.Point(25, 40);
            this.plRobotToolBox.Name = "plRobotToolBox";
            this.plRobotToolBox.Size = new System.Drawing.Size(1011, 565);
            this.plRobotToolBox.TabIndex = 1;
            // 
            // lblDesignToolBoxTitle
            // 
            this.lblDesignToolBoxTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignToolBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDesignToolBoxTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesignToolBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDesignToolBoxTitle.Name = "lblDesignToolBoxTitle";
            this.lblDesignToolBoxTitle.Size = new System.Drawing.Size(1009, 33);
            this.lblDesignToolBoxTitle.TabIndex = 16;
            this.lblDesignToolBoxTitle.Text = "工具箱";
            this.lblDesignToolBoxTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // plRobotDesignToolBox
            // 
            this.plRobotDesignToolBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice13);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice12);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice0);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice1);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice2);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice3);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice4);
            this.plRobotDesignToolBox.Controls.Add(this.pbRoBot);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice11);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice5);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice10);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice6);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice9);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice7);
            this.plRobotDesignToolBox.Controls.Add(this.lblDevice8);
            this.plRobotDesignToolBox.Location = new System.Drawing.Point(226, 43);
            this.plRobotDesignToolBox.Name = "plRobotDesignToolBox";
            this.plRobotDesignToolBox.Size = new System.Drawing.Size(439, 515);
            this.plRobotDesignToolBox.TabIndex = 15;
            // 
            // lblDevice13
            // 
            this.lblDevice13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDevice13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice13.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice13.ForeColor = System.Drawing.Color.White;
            this.lblDevice13.Location = new System.Drawing.Point(244, 474);
            this.lblDevice13.Name = "lblDevice13";
            this.lblDevice13.Size = new System.Drawing.Size(187, 33);
            this.lblDevice13.TabIndex = 13;
            this.lblDevice13.Text = "13,双轮联动";
            this.lblDevice13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice13.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice12
            // 
            this.lblDevice12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDevice12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice12.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice12.ForeColor = System.Drawing.Color.White;
            this.lblDevice12.Location = new System.Drawing.Point(244, 438);
            this.lblDevice12.Name = "lblDevice12";
            this.lblDevice12.Size = new System.Drawing.Size(187, 33);
            this.lblDevice12.TabIndex = 13;
            this.lblDevice12.Text = "12,呼吸灯";
            this.lblDevice12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice12.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice0
            // 
            this.lblDevice0.BackColor = System.Drawing.Color.Red;
            this.lblDevice0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice0.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice0.ForeColor = System.Drawing.Color.White;
            this.lblDevice0.Location = new System.Drawing.Point(244, 0);
            this.lblDevice0.Name = "lblDevice0";
            this.lblDevice0.Size = new System.Drawing.Size(187, 33);
            this.lblDevice0.TabIndex = 1;
            this.lblDevice0.Text = "0,左臂旋转电机";
            this.lblDevice0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice0.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice1
            // 
            this.lblDevice1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice1.ForeColor = System.Drawing.Color.White;
            this.lblDevice1.Location = new System.Drawing.Point(244, 36);
            this.lblDevice1.Name = "lblDevice1";
            this.lblDevice1.Size = new System.Drawing.Size(187, 33);
            this.lblDevice1.TabIndex = 2;
            this.lblDevice1.Text = "1,左臂抬起电机";
            this.lblDevice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice1.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice2
            // 
            this.lblDevice2.BackColor = System.Drawing.Color.Olive;
            this.lblDevice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice2.ForeColor = System.Drawing.Color.White;
            this.lblDevice2.Location = new System.Drawing.Point(244, 72);
            this.lblDevice2.Name = "lblDevice2";
            this.lblDevice2.Size = new System.Drawing.Size(187, 33);
            this.lblDevice2.TabIndex = 3;
            this.lblDevice2.Text = "2,左肩旋转电机";
            this.lblDevice2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice2.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice3
            // 
            this.lblDevice3.BackColor = System.Drawing.Color.Green;
            this.lblDevice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice3.ForeColor = System.Drawing.Color.White;
            this.lblDevice3.Location = new System.Drawing.Point(244, 108);
            this.lblDevice3.Name = "lblDevice3";
            this.lblDevice3.Size = new System.Drawing.Size(187, 33);
            this.lblDevice3.TabIndex = 4;
            this.lblDevice3.Text = "3,左肩抬起电机";
            this.lblDevice3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice3.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice4
            // 
            this.lblDevice4.BackColor = System.Drawing.Color.Teal;
            this.lblDevice4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice4.ForeColor = System.Drawing.Color.White;
            this.lblDevice4.Location = new System.Drawing.Point(244, 144);
            this.lblDevice4.Name = "lblDevice4";
            this.lblDevice4.Size = new System.Drawing.Size(187, 33);
            this.lblDevice4.TabIndex = 5;
            this.lblDevice4.Text = "4,右臂旋转电机";
            this.lblDevice4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice4.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // pbRoBot
            // 
            this.pbRoBot.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbRoBot.Image = ((System.Drawing.Image)(resources.GetObject("pbRoBot.Image")));
            this.pbRoBot.Location = new System.Drawing.Point(0, 0);
            this.pbRoBot.Name = "pbRoBot";
            this.pbRoBot.Size = new System.Drawing.Size(238, 515);
            this.pbRoBot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRoBot.TabIndex = 0;
            this.pbRoBot.TabStop = false;
            // 
            // lblDevice11
            // 
            this.lblDevice11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDevice11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice11.ForeColor = System.Drawing.Color.White;
            this.lblDevice11.Location = new System.Drawing.Point(244, 401);
            this.lblDevice11.Name = "lblDevice11";
            this.lblDevice11.Size = new System.Drawing.Size(187, 33);
            this.lblDevice11.TabIndex = 12;
            this.lblDevice11.Text = "11,右行进轮";
            this.lblDevice11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice11.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice5
            // 
            this.lblDevice5.BackColor = System.Drawing.Color.Navy;
            this.lblDevice5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice5.ForeColor = System.Drawing.Color.White;
            this.lblDevice5.Location = new System.Drawing.Point(244, 180);
            this.lblDevice5.Name = "lblDevice5";
            this.lblDevice5.Size = new System.Drawing.Size(187, 33);
            this.lblDevice5.TabIndex = 6;
            this.lblDevice5.Text = "5,右臂抬起电机";
            this.lblDevice5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice5.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice10
            // 
            this.lblDevice10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDevice10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice10.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice10.ForeColor = System.Drawing.Color.White;
            this.lblDevice10.Location = new System.Drawing.Point(244, 364);
            this.lblDevice10.Name = "lblDevice10";
            this.lblDevice10.Size = new System.Drawing.Size(187, 33);
            this.lblDevice10.TabIndex = 11;
            this.lblDevice10.Text = "10,左行进轮";
            this.lblDevice10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice10.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice6
            // 
            this.lblDevice6.BackColor = System.Drawing.Color.Purple;
            this.lblDevice6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice6.ForeColor = System.Drawing.Color.White;
            this.lblDevice6.Location = new System.Drawing.Point(244, 216);
            this.lblDevice6.Name = "lblDevice6";
            this.lblDevice6.Size = new System.Drawing.Size(187, 33);
            this.lblDevice6.TabIndex = 7;
            this.lblDevice6.Text = "6,右肩旋转电机";
            this.lblDevice6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice6.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice9
            // 
            this.lblDevice9.BackColor = System.Drawing.Color.Fuchsia;
            this.lblDevice9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice9.ForeColor = System.Drawing.Color.White;
            this.lblDevice9.Location = new System.Drawing.Point(244, 327);
            this.lblDevice9.Name = "lblDevice9";
            this.lblDevice9.Size = new System.Drawing.Size(187, 33);
            this.lblDevice9.TabIndex = 10;
            this.lblDevice9.Text = "9,头部点头电机";
            this.lblDevice9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice9.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice7
            // 
            this.lblDevice7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblDevice7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice7.ForeColor = System.Drawing.Color.White;
            this.lblDevice7.Location = new System.Drawing.Point(244, 253);
            this.lblDevice7.Name = "lblDevice7";
            this.lblDevice7.Size = new System.Drawing.Size(187, 33);
            this.lblDevice7.TabIndex = 8;
            this.lblDevice7.Text = "7,右肩抬起电机";
            this.lblDevice7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice7.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // lblDevice8
            // 
            this.lblDevice8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDevice8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDevice8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDevice8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDevice8.ForeColor = System.Drawing.Color.White;
            this.lblDevice8.Location = new System.Drawing.Point(244, 290);
            this.lblDevice8.Name = "lblDevice8";
            this.lblDevice8.Size = new System.Drawing.Size(187, 33);
            this.lblDevice8.TabIndex = 9;
            this.lblDevice8.Text = "8,头部旋转电机";
            this.lblDevice8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDevice8.Click += new System.EventHandler(this.lblDevice0_Click);
            this.lblDevice8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseDown);
            this.lblDevice8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDevice11_MouseUp);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(674, 238);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(323, 317);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(15, 241);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(194, 316);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(811, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 171);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // ActionDesignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scTopAndDown);
            this.Name = "ActionDesignControl";
            this.Size = new System.Drawing.Size(1338, 762);
            this.SizeChanged += new System.EventHandler(this.ActionDesignControl_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.cmsTimeLineMenu.ResumeLayout(false);
            this.scTopAndDown.Panel1.ResumeLayout(false);
            this.scTopAndDown.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTopAndDown)).EndInit();
            this.scTopAndDown.ResumeLayout(false);
            this.scLeftAndRight.Panel1.ResumeLayout(false);
            this.scLeftAndRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scLeftAndRight)).EndInit();
            this.scLeftAndRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.plMiddleContent.ResumeLayout(false);
            this.plRobotToolBox.ResumeLayout(false);
            this.plRobotDesignToolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRoBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private TimeBeam.Timeline tlDesignView;
        private System.Windows.Forms.SplitContainer scTopAndDown;
        private System.Windows.Forms.SplitContainer scLeftAndRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid pgPropertyView;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Panel plMiddleContent;
        private System.Windows.Forms.Panel plRobotToolBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDevice11;
        private System.Windows.Forms.Label lblDevice10;
        private System.Windows.Forms.Label lblDevice9;
        private System.Windows.Forms.Label lblDevice8;
        private System.Windows.Forms.Label lblDevice7;
        private System.Windows.Forms.Label lblDevice6;
        private System.Windows.Forms.Label lblDevice5;
        private System.Windows.Forms.Label lblDevice4;
        private System.Windows.Forms.Label lblDevice3;
        private System.Windows.Forms.Label lblDevice2;
        private System.Windows.Forms.Label lblDevice1;
        private System.Windows.Forms.Label lblDevice0;
        private System.Windows.Forms.PictureBox pbRoBot;
        private System.Windows.Forms.Panel plRobotDesignToolBox;
        private System.Windows.Forms.Label lblDesignToolBoxTitle;
        private System.Windows.Forms.ContextMenuStrip cmsTimeLineMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label lblDevice12;
        private System.Windows.Forms.Label lblDevice13;
    }
}
