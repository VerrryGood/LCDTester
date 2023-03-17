using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLib
{
    public class ControlFunction
    {
        public static void ChangeEnabled(TableLayoutPanel layoutPanel, bool status)
        {
            if (layoutPanel.InvokeRequired)
            {
                layoutPanel.BeginInvoke(new MethodInvoker(delegate ()
                {
                    layoutPanel.Enabled = status;
                }));
            }
            else
                layoutPanel.Enabled = status;
        }

        public static void ChangeEnabled(Button button, bool status)
        {
            if (button.InvokeRequired)
            {
                button.BeginInvoke(new MethodInvoker(delegate ()
                {
                    button.Enabled = status;
                }));
            }
            else
                button.Enabled = status;
        }

        public static void ChangeLoc(PictureBox picBox, Point point)
        {
            if (picBox.InvokeRequired)
            {
                picBox.Invoke(new MethodInvoker(delegate ()
                {
                    picBox.Location = point;
                }));
            }
            else
                picBox.Location = point;
        }

        public static void ChangeVisible(PictureBox picBox, bool status)
        {
            if (picBox.InvokeRequired)
            {
                picBox.Invoke(new MethodInvoker(delegate ()
                {
                    picBox.Visible = status;
                }));
            }
            else
                picBox.Visible = status;
        }

        public static void ChangePic(PictureBox picBox, Image image)
        {
            if (picBox.InvokeRequired)
            {
                picBox.Invoke(new MethodInvoker(delegate ()
                {
                    picBox.Image = image;
                }));
            }
            else
                picBox.Image = image;
        }

        public static void ChangeClickEventStatus(PictureBox picBox, EventHandler func, bool add)
        {
            if (picBox.InvokeRequired)
            {
                picBox.Invoke(new MethodInvoker(delegate ()
                {
                    if (add)
                        picBox.Click += func;
                    else
                        picBox.Click -= func;
                }));
            }
            else
            {
                if (add)
                    picBox.Click += func;
                else
                    picBox.Click -= func;
            }
        }

        public static void ChangeText(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(new MethodInvoker(delegate ()
                {
                    textBox.Text = text;
                }));
            }
            else
                textBox.Text = text;
        }
    }
}
