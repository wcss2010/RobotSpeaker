using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class DeviceScanForm : Form
    {
        /// <summary>
        /// 当前选择列表
        /// </summary>
        public List<RobotConfigItem> SelectedList { get; set; }

        public DeviceScanForm(DeviceListForm deviceListForm)
        {
            InitializeComponent();

            DeviceForm = deviceListForm;
        }

        public DeviceListForm DeviceForm { get; set; }
    }
}