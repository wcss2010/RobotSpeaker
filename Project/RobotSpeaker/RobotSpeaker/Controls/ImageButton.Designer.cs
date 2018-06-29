namespace RobotSpeaker.Controls
{
    partial class ImageButton
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
            this.pbButtonImage = new System.Windows.Forms.PictureBox();
            this.lblButtonTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbButtonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbButtonImage
            // 
            this.pbButtonImage.BackColor = System.Drawing.Color.Transparent;
            this.pbButtonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbButtonImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbButtonImage.Location = new System.Drawing.Point(0, 0);
            this.pbButtonImage.Name = "pbButtonImage";
            this.pbButtonImage.Size = new System.Drawing.Size(177, 128);
            this.pbButtonImage.TabIndex = 0;
            this.pbButtonImage.TabStop = false;
            this.pbButtonImage.Click += new System.EventHandler(this.pbButtonImage_Click);
            this.pbButtonImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbButtonImage_MouseClick);
            this.pbButtonImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbButtonImage_MouseDoubleClick);
            this.pbButtonImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbButtonImage_MouseDown);
            this.pbButtonImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbButtonImage_MouseUp);
            // 
            // lblButtonTxt
            // 
            this.lblButtonTxt.BackColor = System.Drawing.Color.Transparent;
            this.lblButtonTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblButtonTxt.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblButtonTxt.Location = new System.Drawing.Point(0, 128);
            this.lblButtonTxt.Name = "lblButtonTxt";
            this.lblButtonTxt.Size = new System.Drawing.Size(177, 36);
            this.lblButtonTxt.TabIndex = 1;
            this.lblButtonTxt.Text = "Text";
            this.lblButtonTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblButtonTxt.Click += new System.EventHandler(this.lblButtonTxt_Click);
            this.lblButtonTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblButtonTxt_MouseClick);
            this.lblButtonTxt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblButtonTxt_MouseDoubleClick);
            this.lblButtonTxt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblButtonTxt_MouseDown);
            this.lblButtonTxt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblButtonTxt_MouseUp);
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbButtonImage);
            this.Controls.Add(this.lblButtonTxt);
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(177, 164);
            ((System.ComponentModel.ISupportInitialize)(this.pbButtonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbButtonImage;
        private System.Windows.Forms.Label lblButtonTxt;
    }
}
