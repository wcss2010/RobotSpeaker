namespace RobotSpeaker.Forms
{
    partial class PageUIBase
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
            this.trNetworkStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // trNetworkStatusUpdate
            // 
            this.trNetworkStatusUpdate.Enabled = true;
            this.trNetworkStatusUpdate.Interval = 3000;
            this.trNetworkStatusUpdate.Tick += new System.EventHandler(this.trNetworkStatusUpdate_Tick);
            // 
            // PageUIBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.EnabledDisplayWifiLogo = true;
            this.KeyPreview = true;
            this.Name = "PageUIBase";
            this.Text = "PageFormBase";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer trNetworkStatusUpdate;
    }
}