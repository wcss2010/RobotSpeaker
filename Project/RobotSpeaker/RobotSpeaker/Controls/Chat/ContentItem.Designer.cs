namespace RobotSpeaker.Controls.Chat
{
    partial class ContentItem
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plContent = new System.Windows.Forms.Panel();
            this.lblContent = new System.Windows.Forms.Label();
            this.plContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.AutoSize = true;
            this.plContent.BackColor = System.Drawing.Color.LightGray;
            this.plContent.Controls.Add(this.lblContent);
            this.plContent.Location = new System.Drawing.Point(20, 10);
            this.plContent.MaximumSize = new System.Drawing.Size(370, 400);
            this.plContent.Name = "plContent";
            this.plContent.Padding = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.plContent.Size = new System.Drawing.Size(28, 47);
            this.plContent.TabIndex = 0;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.ForeColor = System.Drawing.Color.White;
            this.lblContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContent.Location = new System.Drawing.Point(5, 10);
            this.lblContent.Margin = new System.Windows.Forms.Padding(0);
            this.lblContent.MaximumSize = new System.Drawing.Size(280, 1000);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(18, 27);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = " ";
            this.lblContent.Visible = false;
            // 
            // ContentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.plContent);
            this.Name = "ContentItem";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 10, 5);
            this.Size = new System.Drawing.Size(61, 65);
            this.plContent.ResumeLayout(false);
            this.plContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Label lblContent;
    }
}