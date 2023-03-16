using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls;
using CommonLib;

namespace LCDTester
{
    public partial class SetWeatherPic : Form
    {
        public SetWeatherPic()
        {
            InitializeComponent();
            SetPicView();
        }

        private WindowBar windowBar;
        private int tempPicIndex;

        private void SetWeatherPic_Load(object sender, EventArgs e)
        {
            windowBar = new WindowBar(this);
            windowBarPanel.Controls.Add(windowBar);
            windowBar.Dock = DockStyle.Fill;
            windowBar.windowBarTitle.Text = "날씨 그림 변경";

            picView.Focus();
            tempPicIndex = CommonValues.picIndex;
            foreach (ListViewItem item in picView.Items)
            {
                item.Selected = false;
            }
            picView.Items[tempPicIndex - 1].Selected = true;
        }

        private void SetPicView()
        {
            picView.LargeImageList = weatherPicList;

            for (int i = 0; i < weatherPicList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem($"w_{i + 1}", i);
                picView.Items.Add(item);
            }

            Refresh();
        }

        private void SetPreviewPic()
        {
            switch (tempPicIndex)
            {
                case 1:
                    previewPic.Image = Properties.Resources.w_01;
                    break;
                case 2:
                    previewPic.Image = Properties.Resources.w_02;
                    break;
                case 3:
                    previewPic.Image = Properties.Resources.w_03;
                    break;
                case 4:
                    previewPic.Image = Properties.Resources.w_04;
                    break;
                case 5:
                    previewPic.Image = Properties.Resources.w_05;
                    break;
                case 6:
                    previewPic.Image = Properties.Resources.w_06;
                    break;
                case 7:
                    previewPic.Image = Properties.Resources.w_07;
                    break;
                case 8:
                    previewPic.Image = Properties.Resources.w_08;
                    break;
                case 9:
                    previewPic.Image = Properties.Resources.w_09;
                    break;
                case 10:
                    previewPic.Image = Properties.Resources.w_10;
                    break;
                case 11:
                    previewPic.Image = Properties.Resources.w_11;
                    break;
                case 12:
                    previewPic.Image = Properties.Resources.w_12;
                    break;
                case 13:
                    previewPic.Image = Properties.Resources.w_13;
                    break;
                case 14:
                    previewPic.Image = Properties.Resources.w_14;
                    break;
                case 15:
                    previewPic.Image = Properties.Resources.w_15;
                    break;
                case 16:
                    previewPic.Image = Properties.Resources.w_16;
                    break;
                case 17:
                    previewPic.Image = Properties.Resources.w_17;
                    break;
                case 18:
                    previewPic.Image = Properties.Resources.w_18;
                    break;
                case 19:
                    previewPic.Image = Properties.Resources.w_19;
                    break;
                case 20:
                    previewPic.Image = Properties.Resources.w_20;
                    break;
                case 21:
                    previewPic.Image = Properties.Resources.w_21;
                    break;
                case 22:
                    previewPic.Image = Properties.Resources.w_22;
                    break;
                case 23:
                    previewPic.Image = Properties.Resources.w_23;
                    break;
                case 24:
                    previewPic.Image = Properties.Resources.w_24;
                    break;
                case 25:
                    previewPic.Image = Properties.Resources.w_25;
                    break;
                case 26:
                    previewPic.Image = Properties.Resources.w_26;
                    break;
                case 27:
                    previewPic.Image = Properties.Resources.w_27;
                    break;
                case 28:
                    previewPic.Image = Properties.Resources.w_28;
                    break;
                case 29:
                    previewPic.Image = Properties.Resources.w_29;
                    break;
                case 30:
                    previewPic.Image = Properties.Resources.w_30;
                    break;
                case 31:
                    previewPic.Image = Properties.Resources.w_31;
                    break;
                case 32:
                    previewPic.Image = Properties.Resources.w_32;
                    break;
                case 33:
                    previewPic.Image = Properties.Resources.w_33;
                    break;
                case 34:
                    previewPic.Image = Properties.Resources.w_34;
                    break;
                case 35:
                    previewPic.Image = Properties.Resources.w_35;
                    break;
                case 36:
                    previewPic.Image = Properties.Resources.w_36;
                    break;
                case 37:
                    previewPic.Image = Properties.Resources.w_37;
                    break;
                case 38:
                    previewPic.Image = Properties.Resources.w_38;
                    break;
                case 39:
                    previewPic.Image = Properties.Resources.w_39;
                    break;
                case 40:
                    previewPic.Image = Properties.Resources.w_40;
                    break;
            }
        }

        private void picView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picView.SelectedItems.Count != 0)
            {
                tempPicIndex = picView.SelectedItems[0].Index + 1;
                SetPreviewPic();
            }
        }

        private void applyPic_Click(object sender, EventArgs e)
        {
            CommonValues.picIndex = tempPicIndex;
        }
    }
}
