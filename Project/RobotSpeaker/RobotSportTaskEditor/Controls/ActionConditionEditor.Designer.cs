namespace RobotSportTaskEditor.Controls
{
    partial class ActionConditionEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUserSayText = new System.Windows.Forms.ComboBox();
            this.plAngle = new System.Windows.Forms.Panel();
            this.tbAngleMax = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAngleMin = new System.Windows.Forms.NumericUpDown();
            this.cbJoyKeys = new System.Windows.Forms.ComboBox();
            this.tbCustomCondition = new System.Windows.Forms.TextBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbJoyKey = new System.Windows.Forms.RadioButton();
            this.rbAngle = new System.Windows.Forms.RadioButton();
            this.rbUserSay = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.plAngle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngleMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUserSayText);
            this.groupBox1.Controls.Add(this.plAngle);
            this.groupBox1.Controls.Add(this.cbJoyKeys);
            this.groupBox1.Controls.Add(this.tbCustomCondition);
            this.groupBox1.Controls.Add(this.rbCustom);
            this.groupBox1.Controls.Add(this.rbJoyKey);
            this.groupBox1.Controls.Add(this.rbAngle);
            this.groupBox1.Controls.Add(this.rbUserSay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "触发条件";
            // 
            // cbUserSayText
            // 
            this.cbUserSayText.FormattingEnabled = true;
            this.cbUserSayText.Location = new System.Drawing.Point(175, 14);
            this.cbUserSayText.Name = "cbUserSayText";
            this.cbUserSayText.Size = new System.Drawing.Size(349, 20);
            this.cbUserSayText.TabIndex = 7;
            // 
            // plAngle
            // 
            this.plAngle.Controls.Add(this.tbAngleMax);
            this.plAngle.Controls.Add(this.label1);
            this.plAngle.Controls.Add(this.tbAngleMin);
            this.plAngle.Enabled = false;
            this.plAngle.Location = new System.Drawing.Point(213, 36);
            this.plAngle.Name = "plAngle";
            this.plAngle.Size = new System.Drawing.Size(156, 27);
            this.plAngle.TabIndex = 6;
            // 
            // tbAngleMax
            // 
            this.tbAngleMax.Location = new System.Drawing.Point(89, 3);
            this.tbAngleMax.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tbAngleMax.Name = "tbAngleMax";
            this.tbAngleMax.Size = new System.Drawing.Size(64, 21);
            this.tbAngleMax.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            // 
            // tbAngleMin
            // 
            this.tbAngleMin.Location = new System.Drawing.Point(3, 3);
            this.tbAngleMin.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tbAngleMin.Name = "tbAngleMin";
            this.tbAngleMin.Size = new System.Drawing.Size(64, 21);
            this.tbAngleMin.TabIndex = 5;
            // 
            // cbJoyKeys
            // 
            this.cbJoyKeys.Enabled = false;
            this.cbJoyKeys.FormattingEnabled = true;
            this.cbJoyKeys.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "MiddleLeft",
            "MiddleCenter",
            "MiddleRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight",
            "B1",
            "B2",
            "B3",
            "B4",
            "B5",
            "B6",
            "B7",
            "B8",
            "B9",
            "B10"});
            this.cbJoyKeys.Location = new System.Drawing.Point(236, 66);
            this.cbJoyKeys.Name = "cbJoyKeys";
            this.cbJoyKeys.Size = new System.Drawing.Size(175, 20);
            this.cbJoyKeys.TabIndex = 4;
            // 
            // tbCustomCondition
            // 
            this.tbCustomCondition.Enabled = false;
            this.tbCustomCondition.Location = new System.Drawing.Point(93, 89);
            this.tbCustomCondition.Name = "tbCustomCondition";
            this.tbCustomCondition.Size = new System.Drawing.Size(431, 21);
            this.tbCustomCondition.TabIndex = 2;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(28, 91);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(59, 16);
            this.rbCustom.TabIndex = 0;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "自定义";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbJoyKey
            // 
            this.rbJoyKey.AutoSize = true;
            this.rbJoyKey.Location = new System.Drawing.Point(28, 68);
            this.rbJoyKey.Name = "rbJoyKey";
            this.rbJoyKey.Size = new System.Drawing.Size(203, 16);
            this.rbJoyKey.TabIndex = 0;
            this.rbJoyKey.TabStop = true;
            this.rbJoyKey.Text = "当检查到遥控器按钮被按下时触发";
            this.rbJoyKey.UseVisualStyleBackColor = true;
            this.rbJoyKey.CheckedChanged += new System.EventHandler(this.rbJoyKey_CheckedChanged);
            // 
            // rbAngle
            // 
            this.rbAngle.AutoSize = true;
            this.rbAngle.Location = new System.Drawing.Point(28, 42);
            this.rbAngle.Name = "rbAngle";
            this.rbAngle.Size = new System.Drawing.Size(179, 16);
            this.rbAngle.TabIndex = 0;
            this.rbAngle.TabStop = true;
            this.rbAngle.Text = "当检查到用户所处位置时触发";
            this.rbAngle.UseVisualStyleBackColor = true;
            this.rbAngle.CheckedChanged += new System.EventHandler(this.rbAngle_CheckedChanged);
            // 
            // rbUserSay
            // 
            this.rbUserSay.AutoSize = true;
            this.rbUserSay.Checked = true;
            this.rbUserSay.Location = new System.Drawing.Point(28, 15);
            this.rbUserSay.Name = "rbUserSay";
            this.rbUserSay.Size = new System.Drawing.Size(143, 16);
            this.rbUserSay.TabIndex = 0;
            this.rbUserSay.TabStop = true;
            this.rbUserSay.Text = "当听到用户说话时触发";
            this.rbUserSay.UseVisualStyleBackColor = true;
            this.rbUserSay.CheckedChanged += new System.EventHandler(this.rbUserSay_CheckedChanged);
            // 
            // ActionConditionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ActionConditionEditor";
            this.Size = new System.Drawing.Size(543, 117);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.plAngle.ResumeLayout(false);
            this.plAngle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngleMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbJoyKey;
        private System.Windows.Forms.RadioButton rbAngle;
        private System.Windows.Forms.RadioButton rbUserSay;
        private System.Windows.Forms.TextBox tbCustomCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbJoyKeys;
        private System.Windows.Forms.NumericUpDown tbAngleMin;
        private System.Windows.Forms.Panel plAngle;
        private System.Windows.Forms.NumericUpDown tbAngleMax;
        private System.Windows.Forms.ComboBox cbUserSayText;
    }
}
