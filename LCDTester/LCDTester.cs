using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Timers = System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib;
using CustomControls;

namespace LCDTester
{
    public partial class LCDTester : Form
    {
        public LCDTester()
        {
            InitializeComponent();
        }

        private WindowBar windowBar;

        private int selectedFloor = 1;
        public int SelectedFloor
        {
            set
            {
                if (selectedFloor != value)
                {
                    floorBackgroundLayout.Enabled = false;
                }
                selectedFloor = value;
            }
        }
        private Button preFloor;

        private string myIP = "127.0.0.1";
        private string[] ips;
        private byte[] byteIP;

        private object lockObject = new object();

        private void LCDTester_Load(object sender, EventArgs e)
        {
            windowBar = new WindowBar(this);
            windowBarPanel.Controls.Add(windowBar);
            windowBar.Dock = DockStyle.Fill;
            windowBar.windowBarTitle.Text = "LCD Tester";

            preFloor = firstFloor;
        }

        private void MakeElevDataFirstTime()
        {

        }

        private void ChangeIP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ipSet.PerformClick();
        }

        private void ipSet_Click(object sender, EventArgs e)
        {
            myIP = string.Join(".", ipText1.Text, ipText2.Text, ipText3.Text, ipText4.Text);

        }

        private void ChangeSelectedFloor(object sender, EventArgs e)
        {
            SelectedFloor = BasicFunction.StringtoFloorNum(((Button)sender).Text);
            if (preFloor != ((Button)sender))
            {
                ((Button)sender).BackColor = CommonValues.floorSelectColor;
                ((Button)sender).ForeColor = Color.White;
                preFloor.BackColor = BackColor;
                preFloor.ForeColor = ForeColor;
                preFloor = ((Button)sender);
            }
        }
    }
}
