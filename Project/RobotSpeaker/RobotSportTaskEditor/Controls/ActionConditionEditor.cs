using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotSpeaker.SportDB;

namespace RobotSportTaskEditor.Controls
{
    public partial class ActionConditionEditor : UserControl
    {
        public ActionConditionEditor()
        {
            InitializeComponent();

            LoadQuestions();
        }

        public void LoadQuestions()
        {
            if (DBInstance.DbHelper != null)
            {
                QuestionList = DBInstance.DbHelper.table("Robot_Questions").select("*").getList<Robot_Questions>(new Robot_Questions());
                if (QuestionList != null)
                {
                    cbUserSayText.Items.Clear();
                    foreach (Robot_Questions q in QuestionList)
                    {
                        cbUserSayText.Items.Add(q.Ask);
                    }
                }
            }
        }

        private void rbUserSay_CheckedChanged(object sender, EventArgs e)
        {
            cbUserSayText.Enabled = true;
            plAngle.Enabled = false;
            cbJoyKeys.Enabled = false;
            tbCustomCondition.Enabled = false;

        }

        private void rbAngle_CheckedChanged(object sender, EventArgs e)
        {
            cbUserSayText.Enabled = false;
            plAngle.Enabled = true;
            cbJoyKeys.Enabled = false;
            tbCustomCondition.Enabled = false;

        }

        private void rbJoyKey_CheckedChanged(object sender, EventArgs e)
        {
            cbUserSayText.Enabled = false;
            plAngle.Enabled = false;
            cbJoyKeys.Enabled = true;
            tbCustomCondition.Enabled = false;

        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            cbUserSayText.Enabled = false;
            plAngle.Enabled = false;
            cbJoyKeys.Enabled = false;
            tbCustomCondition.Enabled = true;

        }

        /// <summary>
        /// 获得条件字符串
        /// </summary>
        /// <returns></returns>
        public string GetConditionString()
        {
            StringBuilder sb = new StringBuilder();

            if (rbUserSay.Checked)
            {
                //用户说
                sb.Append("语音=").Append(cbUserSayText.Text.Trim());
            }
            else if (rbAngle.Checked)
            {
                //说话角度
                sb.Append("角度=").Append(tbAngleMin.Value).Append(",").Append(tbAngleMax.Value);
            }
            else if (rbJoyKey.Checked)
            {
                //手柄按键
                sb.Append("手柄=").Append(cbJoyKeys.Text);
            }
            else
            {
                //自定义
                sb.Append(tbCustomCondition.Text);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 设置条件字符串
        /// </summary>
        /// <param name="condition"></param>
        public void SetConditionString(string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                return;
            }
            else
            {
                if (condition.StartsWith("语音="))
                {
                    //当听到用户说
                    rbUserSay.Checked = true;
                    cbUserSayText.Text = condition.Replace("语音=", string.Empty);
                }
                else if (condition.StartsWith("角度="))
                {
                    //检查到说话方向
                    rbAngle.Checked = true;
                    string[] teams = condition.Replace("角度=", string.Empty).Split(',');
                    if (teams != null && teams.Length >= 2)
                    {
                        try
                        {
                            tbAngleMin.Value = int.Parse(teams[0]);
                        }
                        catch (Exception ex) { }

                        try
                        {
                            tbAngleMax.Value = int.Parse(teams[1]);
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (condition.StartsWith("手柄="))
                {
                    //按下手柄时
                    rbJoyKey.Checked = true;
                    cbJoyKeys.Text = condition.Replace("手柄=", string.Empty);
                }
                else
                {
                    //自定义
                    rbCustom.Checked = true;
                    tbCustomCondition.Text = condition;
                }
            }
        }

        public List<Robot_Questions> QuestionList { get; set; }
    }
}