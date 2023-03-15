using System;
using System.Collections.Generic;
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
    }
}
