namespace RobotSportTaskEditor
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsTopToolBar = new System.Windows.Forms.ToolStrip();
            this.btnNewAction = new System.Windows.Forms.ToolStripButton();
            this.btnNewQuestion = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.ssState = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcActionAndQuestion = new System.Windows.Forms.TabControl();
            this.tpAction = new System.Windows.Forms.TabPage();
            this.dgActions = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModifyAction = new System.Windows.Forms.Button();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.tpQuestion = new System.Windows.Forms.TabPage();
            this.dgQuestions = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifyQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.clAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsTopToolBar.SuspendLayout();
            this.ssState.SuspendLayout();
            this.tcActionAndQuestion.SuspendLayout();
            this.tpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuestions)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTopToolBar
            // 
            this.tsTopToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTopToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewAction,
            this.btnNewQuestion,
            this.btnExit});
            this.tsTopToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsTopToolBar.Name = "tsTopToolBar";
            this.tsTopToolBar.Size = new System.Drawing.Size(1323, 56);
            this.tsTopToolBar.TabIndex = 1;
            // 
            // btnNewAction
            // 
            this.btnNewAction.Image = ((System.Drawing.Image)(resources.GetObject("btnNewAction.Image")));
            this.btnNewAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewAction.Name = "btnNewAction";
            this.btnNewAction.Size = new System.Drawing.Size(60, 53);
            this.btnNewAction.Text = "新建动作";
            this.btnNewAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewAction.Click += new System.EventHandler(this.btnNewAction_Click);
            // 
            // btnNewQuestion
            // 
            this.btnNewQuestion.Image = ((System.Drawing.Image)(resources.GetObject("btnNewQuestion.Image")));
            this.btnNewQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewQuestion.Name = "btnNewQuestion";
            this.btnNewQuestion.Size = new System.Drawing.Size(60, 53);
            this.btnNewQuestion.Text = "新建问答";
            this.btnNewQuestion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewQuestion.Click += new System.EventHandler(this.btnNewQuestion_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 53);
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ssState
            // 
            this.ssState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.ssState.Location = new System.Drawing.Point(0, 860);
            this.ssState.Name = "ssState";
            this.ssState.Size = new System.Drawing.Size(1323, 22);
            this.ssState.TabIndex = 4;
            this.ssState.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 17);
            this.lblStatus.Text = "动作设计器";
            // 
            // tcActionAndQuestion
            // 
            this.tcActionAndQuestion.Controls.Add(this.tpAction);
            this.tcActionAndQuestion.Controls.Add(this.tpQuestion);
            this.tcActionAndQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcActionAndQuestion.Location = new System.Drawing.Point(0, 56);
            this.tcActionAndQuestion.Name = "tcActionAndQuestion";
            this.tcActionAndQuestion.SelectedIndex = 0;
            this.tcActionAndQuestion.Size = new System.Drawing.Size(1323, 804);
            this.tcActionAndQuestion.TabIndex = 5;
            // 
            // tpAction
            // 
            this.tpAction.Controls.Add(this.dgActions);
            this.tpAction.Controls.Add(this.groupBox1);
            this.tpAction.Location = new System.Drawing.Point(4, 22);
            this.tpAction.Name = "tpAction";
            this.tpAction.Padding = new System.Windows.Forms.Padding(3);
            this.tpAction.Size = new System.Drawing.Size(1315, 778);
            this.tpAction.TabIndex = 0;
            this.tpAction.Text = "动作";
            this.tpAction.UseVisualStyleBackColor = true;
            // 
            // dgActions
            // 
            this.dgActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCode,
            this.clName,
            this.clCondition});
            this.dgActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgActions.Location = new System.Drawing.Point(3, 60);
            this.dgActions.Name = "dgActions";
            this.dgActions.RowTemplate.Height = 23;
            this.dgActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActions.Size = new System.Drawing.Size(1309, 715);
            this.dgActions.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModifyAction);
            this.groupBox1.Controls.Add(this.btnDeleteAction);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1309, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnModifyAction
            // 
            this.btnModifyAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnModifyAction.Location = new System.Drawing.Point(1156, 17);
            this.btnModifyAction.Name = "btnModifyAction";
            this.btnModifyAction.Size = new System.Drawing.Size(75, 37);
            this.btnModifyAction.TabIndex = 1;
            this.btnModifyAction.Text = "修改";
            this.btnModifyAction.UseVisualStyleBackColor = true;
            this.btnModifyAction.Click += new System.EventHandler(this.btnModifyAction_Click);
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteAction.Location = new System.Drawing.Point(1231, 17);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(75, 37);
            this.btnDeleteAction.TabIndex = 0;
            this.btnDeleteAction.Text = "删除";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // tpQuestion
            // 
            this.tpQuestion.Controls.Add(this.dgQuestions);
            this.tpQuestion.Controls.Add(this.groupBox2);
            this.tpQuestion.Location = new System.Drawing.Point(4, 22);
            this.tpQuestion.Name = "tpQuestion";
            this.tpQuestion.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuestion.Size = new System.Drawing.Size(1315, 778);
            this.tpQuestion.TabIndex = 1;
            this.tpQuestion.Text = "问答";
            this.tpQuestion.UseVisualStyleBackColor = true;
            // 
            // dgQuestions
            // 
            this.dgQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clAsk,
            this.clAnswer});
            this.dgQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuestions.Location = new System.Drawing.Point(3, 60);
            this.dgQuestions.Name = "dgQuestions";
            this.dgQuestions.RowTemplate.Height = 23;
            this.dgQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgQuestions.Size = new System.Drawing.Size(1309, 715);
            this.dgQuestions.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModifyQuestion);
            this.groupBox2.Controls.Add(this.btnDeleteQuestion);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1309, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnModifyQuestion
            // 
            this.btnModifyQuestion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnModifyQuestion.Location = new System.Drawing.Point(1156, 17);
            this.btnModifyQuestion.Name = "btnModifyQuestion";
            this.btnModifyQuestion.Size = new System.Drawing.Size(75, 37);
            this.btnModifyQuestion.TabIndex = 1;
            this.btnModifyQuestion.Text = "修改";
            this.btnModifyQuestion.UseVisualStyleBackColor = true;
            this.btnModifyQuestion.Click += new System.EventHandler(this.btnModifyQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteQuestion.Location = new System.Drawing.Point(1231, 17);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(75, 37);
            this.btnDeleteQuestion.TabIndex = 0;
            this.btnDeleteQuestion.Text = "删除";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // clAsk
            // 
            this.clAsk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clAsk.HeaderText = "问";
            this.clAsk.Name = "clAsk";
            this.clAsk.ReadOnly = true;
            // 
            // clAnswer
            // 
            this.clAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clAnswer.HeaderText = "答";
            this.clAnswer.Name = "clAnswer";
            this.clAnswer.ReadOnly = true;
            // 
            // clCode
            // 
            this.clCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clCode.HeaderText = "代码";
            this.clCode.Name = "clCode";
            this.clCode.ReadOnly = true;
            // 
            // clName
            // 
            this.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clName.HeaderText = "名称";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clCondition
            // 
            this.clCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clCondition.HeaderText = "触发条件";
            this.clCondition.Name = "clCondition";
            this.clCondition.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1323, 882);
            this.Controls.Add(this.tcActionAndQuestion);
            this.Controls.Add(this.tsTopToolBar);
            this.Controls.Add(this.ssState);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "机器人语音动作指令编辑器 V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsTopToolBar.ResumeLayout(false);
            this.tsTopToolBar.PerformLayout();
            this.ssState.ResumeLayout(false);
            this.ssState.PerformLayout();
            this.tcActionAndQuestion.ResumeLayout(false);
            this.tpAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tpQuestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuestions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTopToolBar;
        private System.Windows.Forms.StatusStrip ssState;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripButton btnNewAction;
        private System.Windows.Forms.ToolStripButton btnNewQuestion;
        private System.Windows.Forms.TabControl tcActionAndQuestion;
        private System.Windows.Forms.TabPage tpAction;
        private System.Windows.Forms.TabPage tpQuestion;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgActions;
        private System.Windows.Forms.Button btnModifyAction;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.DataGridView dgQuestions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModifyQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCondition;
    }
}

