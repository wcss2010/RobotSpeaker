using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class DeviceListForm : Form
    {
        private List<RobotConfigItem> _robotConfigList = new List<RobotConfigItem>();
        /// <summary>
        /// 机器人连接信息列表
        /// </summary>
        public List<RobotConfigItem> RobotConfigList
        {
            get { return _robotConfigList; }
        }


        private SocketLibrary.Client _client = null;
        /// <summary>
        /// 客户端
        /// </summary>
        public SocketLibrary.Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public DeviceListForm()
        {
            InitializeComponent();
        }

        private void lvConnectionList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        /// <summary>
        /// 载入配置
        /// </summary>
        private void LoadConfig()
        {
            if (File.Exists(Path.Combine(Application.StartupPath, "RobotConfigList.xml")))
            {
                string txt = File.ReadAllText(Path.Combine(Application.StartupPath, "RobotConfigList.xml"));
                List<RobotConfigItem> list = JsonConvert.DeserializeObject<List<RobotConfigItem>>(txt);
                if (list != null)
                {
                    _robotConfigList = list;
                }
            }

            lvConnectionList.Items.Clear();
            foreach (RobotConfigItem rci in RobotConfigList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = rci.NickName;
                lvi.SubItems.Add(rci.IP);
                lvi.SubItems.Add(rci.Port.ToString());

                lvi.Tag = rci;

                lvConnectionList.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveConfig()
        {
            File.WriteAllText(Path.Combine(Application.StartupPath, "RobotConfigList.xml"), JsonConvert.SerializeObject(RobotConfigList));
        }

        private void lvConnectionList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lvConnectionList.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in lvConnectionList.SelectedItems)
                    {
                        RobotConfigList.Remove((RobotConfigItem)lvi.Tag);
                        lvi.Remove();
                    }
                }
                SaveConfig();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// 机器人配置项
    /// </summary>
    public class RobotConfigItem
    {
        public string NickName { get; set; }

        public string IP { get; set; }

        public int Port { get; set; }
    }
}