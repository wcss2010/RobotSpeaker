namespace RobotSpeaker.Controls
{
    partial class ContentFormBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.ibBack = new RobotSpeaker.Controls.ImageButton();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.btnCloseComputer = new RobotSpeaker.Controls.ButtonExt();
            this.pbWifi = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.trTimeUpdate = new System.Windows.Forms.Timer(this.components);
            this.plTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // plTopBar
            // 
            this.plTopBar.BackColor = System.Drawing.Color.Transparent;
            this.plTopBar.Controls.Add(this.lblTitle);
            this.plTopBar.Controls.Add(this.lblTime);
            this.plTopBar.Controls.Add(this.ibBack);
            this.plTopBar.Controls.Add(this.lblEmpty);
            this.plTopBar.Controls.Add(this.btnCloseComputer);
            this.plTopBar.Controls.Add(this.pbWifi);
            this.plTopBar.Controls.Add(this.pbLogo);
            this.plTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTopBar.Location = new System.Drawing.Point(0, 0);
            this.plTopBar.Name = "plTopBar";
            this.plTopBar.Size = new System.Drawing.Size(1031, 64);
            this.plTopBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(97, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(369, 64);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(466, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(337, 64);
            this.lblTime.TabIndex = 5;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibBack
            // 
            this.ibBack.BottomText = "Text";
            this.ibBack.BottomTextColor = System.Drawing.SystemColors.ControlText;
            this.ibBack.BottomTextFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ibBack.BottomTextHeight = 0;
            this.ibBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibBack.EnabledMouseDownAndMouseUp = true;
            this.ibBack.EnabledTextLabel = false;
            this.ibBack.FocusImage = null;
            this.ibBack.IsPressed = false;
            this.ibBack.Location = new System.Drawing.Point(33, 0);
            this.ibBack.Name = "ibBack";
            this.ibBack.NoFocusImage = null;
            this.ibBack.Size = new System.Drawing.Size(64, 64);
            this.ibBack.TabIndex = 1;
            this.ibBack.Click += new System.EventHandler(this.ibBack_Click);
            // 
            // lblEmpty
            // 
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEmpty.Location = new System.Drawing.Point(0, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(33, 64);
            this.lblEmpty.TabIndex = 3;
            // 
            // btnCloseComputer
            // 
            this.btnCloseComputer.ButtonNormalBackColor = System.Drawing.Color.Transparent;
            this.btnCloseComputer.ButtonNormalForeColor = System.Drawing.Color.White;
            this.btnCloseComputer.ButtonPressedBackColor = System.Drawing.Color.Orange;
            this.btnCloseComputer.ButtonPressedForeColor = System.Drawing.Color.White;
            this.btnCloseComputer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseComputer.EnabledMouseDownAndMouseUp = true;
            this.btnCloseComputer.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseComputer.Location = new System.Drawing.Point(803, 0);
            this.btnCloseComputer.Name = "btnCloseComputer";
            this.btnCloseComputer.Size = new System.Drawing.Size(100, 64);
            this.btnCloseComputer.TabIndex = 6;
            this.btnCloseComputer.Text = "关机";
            this.btnCloseComputer.Click += new System.EventHandler(this.btnCloseComputer_Click);
            // 
            // pbWifi
            // 
            this.pbWifi.BackColor = System.Drawing.Color.Transparent;
            this.pbWifi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbWifi.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbWifi.Location = new System.Drawing.Point(903, 0);
            this.pbWifi.Name = "pbWifi";
            this.pbWifi.Size = new System.Drawing.Size(64, 64);
            this.pbWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWifi.TabIndex = 4;
            this.pbWifi.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Location = new System.Drawing.Point(967, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(64, 64);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // trTimeUpdate
            // 
            this.trTimeUpdate.Enabled = true;
            this.trTimeUpdate.Interval = 500;
            this.trTimeUpdate.Tick += new System.EventHandler(this.trTimeUpdate_Tick);
            // 
            // ContentFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.plTopBar);
            this.Name = "ContentFormBase";
            this.Text = "ContentFormBase";
            this.plTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTopBar;
        private System.Windows.Forms.PictureBox pbLogo;
        private ImageButton ibBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.PictureBox pbWifi;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer trTimeUpdate;
        private ButtonExt btnCloseComputer;
    }
}