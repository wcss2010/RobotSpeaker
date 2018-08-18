using RobotSpeaker.SportDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class QuestionEditor : Form
    {
        public QuestionEditor(bool isNew)
        {
            InitializeComponent();

            IsNewRecord = isNew;

            if (IsNewRecord)
            {
                Text = "创建问答";
            }
            else
            {
                Text = "修改问答";
            }

            OnLoad(new EventArgs());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Object != null)
            {
                tbAsk.Text = Object.Ask;
                tbAnswer.Text = Object.Answer;
            }
        }

        public bool IsNewRecord { get; set; }

        private Robot_Questions _object = null;
        public Robot_Questions Object
        {
            get { return _object; }
            set
            {
                _object = value;
                OnLoad(new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAsk.Text))
            {
                MessageBox.Show("请输入问内容！");
                return;
            }
            if (string.IsNullOrEmpty(tbAnswer.Text))
            {
                MessageBox.Show("请输入答内容！");
                return;
            }

            if (IsNewRecord)
            {
                _object = new Robot_Questions();
                Object.Id = DBInstance.DbHelper.table("Robot_Questions").select("max(Id)").getValue<long>(0) + 1;
            }

            Object.Ask = tbAsk.Text;
            Object.Answer = tbAnswer.Text;

            if (IsNewRecord)
            {
                //Insert
                DBInstance.DbHelper.table("Robot_Questions").set("Id", Object.Id).set("Ask", Object.Ask).set("Answer", Object.Answer).insert();
            }
            else
            {
                //Update
                DBInstance.DbHelper.table("Robot_Questions").set("Ask", Object.Ask).set("Answer", Object.Answer).where("Id=?", new object[] { Object.Id }).update();
            }

            MessageBox.Show("操作完成！");
            Close();
        }
    }
}