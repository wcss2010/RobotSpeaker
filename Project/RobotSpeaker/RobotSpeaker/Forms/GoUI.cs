using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class GoUI : PageUIBase
    {
        public GoUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            plTabPanel.Top = (Screen.PrimaryScreen.Bounds.Height - plTabPanel.Height) / 2;
            plTabPanel.Left = (Screen.PrimaryScreen.Bounds.Width - plTabPanel.Width) / 2;

            ibNormal.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face1.png"));
            ibNormal.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face2.png"));

            ibUseDevice.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice1.png"));
            ibUseDevice.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice2.png"));

            ibFree.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set1.png"));
            ibFree.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set2.png"));
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void ibNormal_Click(object sender, EventArgs e)
        {

        }

        private void ibUseDevice_Click(object sender, EventArgs e)
        {

        }

        private void ibFree_Click(object sender, EventArgs e)
        {

        }
    }
}