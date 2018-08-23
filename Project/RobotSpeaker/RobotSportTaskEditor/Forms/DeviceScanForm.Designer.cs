namespace RobotSportTaskEditor.Forms
{
    partial class DeviceScanForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUdpBoardCastIp = new System.Windows.Forms.TextBox();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvConnectionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartScan);
            this.groupBox1.Controls.Add(this.tbUdpBoardCastIp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "UDP广播地址:";
            // 
            // tbUdpBoardCastIp
            // 
            this.tbUdpBoardCastIp.Location = new System.Drawing.Point(91, 14);
            this.tbUdpBoardCastIp.Name = "tbUdpBoardCastIp";
            this.tbUdpBoardCastIp.Size = new System.Drawing.Size(170, 21);
            this.tbUdpBoardCastIp.TabIndex = 2;
            // 
            // btnStartScan
            // 
            this.btnStartScan.Location = new System.Drawing.Point(267, 14);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 21);
            this.btnStartScan.TabIndex = 3;
            this.btnStartScan.Text = "扫描开始";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 467);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 46);
            this.panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(228, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvConnectionList
            // 
            this.lvConnectionList.CheckBoxes = true;
            this.lvConnectionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvConnectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnectionList.Location = new System.Drawing.Point(0, 50);
            this.lvConnectionList.Name = "lvConnectionList";
            this.lvConnectionList.Size = new System.Drawing.Size(630, 417);
            this.lvConnectionList.TabIndex = 2;
            this.lvConnectionList.UseCompatibleStateImageBehavior = false;
            this.lvConnectionList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "端口";
            this.columnHeader3.Width = 80;
            // 
            // DeviceScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 513);
            this.Controls.Add(this.lvConnectionList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceScanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描本网段内所有机器人";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbUdpBoardCastIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvConnectionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}