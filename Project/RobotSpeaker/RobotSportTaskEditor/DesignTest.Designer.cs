namespace RobotSportTaskEditor
{
    partial class DesignTest
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
            this.actionDesignControl1 = new RobotSportTaskEditor.Controls.ActionDesignControl();
            this.SuspendLayout();
            // 
            // actionDesignControl1
            // 
            this.actionDesignControl1.BackColor = System.Drawing.Color.White;
            this.actionDesignControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionDesignControl1.Location = new System.Drawing.Point(0, 0);
            this.actionDesignControl1.Name = "actionDesignControl1";
            this.actionDesignControl1.Size = new System.Drawing.Size(1371, 629);
            this.actionDesignControl1.TabIndex = 0;
            // 
            // DesignTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 629);
            this.Controls.Add(this.actionDesignControl1);
            this.DoubleBuffered = true;
            this.Name = "DesignTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DesignTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ActionDesignControl actionDesignControl1;
    }
}