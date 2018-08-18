using Noear.Weed;
using RobotSpeaker.SportDB;
using RobotSportTaskEditor.Forms;
using RobotSportTaskEditor.Tracks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TimeBeam;
using TimeBeam.Events;
using TimeBeam.Timing;

namespace RobotSportTaskEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DBInstance.Init(Path.Combine(Application.StartupPath, "static.db"));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadActions();
            LoadQuestions();
        }

        public void LoadQuestions()
        {
            QuestionList = DBInstance.DbHelper.table("Robot_Questions").select("*").getList<Robot_Questions>(new Robot_Questions());
            if (QuestionList != null)
            {
                dgQuestions.Rows.Clear();
                foreach (Robot_Questions q in QuestionList)
                {
                   object[] cells = new object[2];
                   cells[0] = q.Ask;
                   cells[1] = q.Answer;
                   
                   int rowIndex = dgQuestions.Rows.Add(cells);
                   dgQuestions.Rows[rowIndex].Tag = q;
                }
            }
        }

        public void LoadActions()
        {
            ActionList = DBInstance.DbHelper.table("Robot_Actions").select("*").getList<Robot_Actions>(new Robot_Actions());
            if (ActionList != null)
            {
                dgActions.Rows.Clear();
                foreach (Robot_Actions a in ActionList)
                {
                    object[] cells = new object[3];
                    cells[0] = a.Code;
                    cells[1] = a.Name;
                    cells[2] = a.Condition;

                    int rowIndex = dgActions.Rows.Add(cells);
                    dgActions.Rows[rowIndex].Tag = a;
                }
            }
        }

        private void btnNewAction_Click(object sender, EventArgs e)
        {
            new ActionEditor(true).ShowDialog();

            LoadActions();
            LoadQuestions();
        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            new QuestionEditor(true).ShowDialog();

            LoadActions();
            LoadQuestions();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要退出吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnModifyQuestion_Click(object sender, EventArgs e)
        {
            if (dgQuestions.SelectedRows.Count > 0 && dgQuestions.SelectedRows[0].Tag != null)
            {
                QuestionEditor qe = new QuestionEditor(false);
                qe.Object = (Robot_Questions)dgQuestions.SelectedRows[0].Tag;
                qe.ShowDialog();
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgQuestions.SelectedRows.Count > 0 && dgQuestions.SelectedRows[0].Tag != null)
            {
                Robot_Questions obj = (Robot_Questions)dgQuestions.SelectedRows[0].Tag;
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBInstance.DbHelper.table("Robot_Questions").where("Id = ?", new object[] { obj.Id }).delete();
                }
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnModifyAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null)
            {
                ActionEditor ae = new ActionEditor(false);
                ae.Object = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                ae.ShowDialog();
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null)
            {
                Robot_Actions obj = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBInstance.DbHelper.table("Robot_Actions").where("Id = ?", new object[] { obj.Id }).delete();
                    DBInstance.DbHelper.table("Robot_Steps").where("ActionId = ?", new object[] { obj.Id }).delete();
                }
            }

            LoadActions();
            LoadQuestions();
        }

        public List<Robot_Actions> ActionList { get; set; }

        public List<Robot_Questions> QuestionList { get; set; }
    }
}