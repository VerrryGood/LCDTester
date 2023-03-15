using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public class AntiAliasingLabel : Label
    {
        private StringFormat format = new StringFormat();

        public StringAlignment LineAlignment
        {
            get { return format.LineAlignment; }
            set { format.LineAlignment = value; }
        }

        public StringAlignment Alignment
        {
            get { return format.Alignment; }
            set { format.Alignment = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), this.ClientRectangle, format);
            //base.OnPaint(e);
        }
    }
}
