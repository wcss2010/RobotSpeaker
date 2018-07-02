namespace RobotSpeaker.Forms
{
    partial class MainFormUI
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
            this.buttonExt1 = new RobotSpeaker.Controls.ButtonExt();
            this.SuspendLayout();
            // 
            // buttonExt1
            // 
            this.buttonExt1.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExt1.Location = new System.Drawing.Point(428, 239);
            this.buttonExt1.Name = "buttonExt1";
            this.buttonExt1.Size = new System.Drawing.Size(100, 23);
            this.buttonExt1.TabIndex = 1;
            this.buttonExt1.Text = "buttonExt1";
            this.buttonExt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.buttonExt1);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.Controls.SetChildIndex(this.buttonExt1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ButtonExt buttonExt1;



    }
}