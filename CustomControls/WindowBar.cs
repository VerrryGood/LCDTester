using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class WindowBar : UserControl
    {
        public WindowBar(Form form)
        {
            InitializeComponent();
            moveForm = form;
            iconBox.Image = new Bitmap(form.Icon.ToBitmap());
        }

        private Form moveForm;

        private bool tagMove;
        private Point fPt;

        private void WindowBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (tagMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                moveForm.Location = new Point(moveForm.Left - (fPt.X - e.X), moveForm.Top - (fPt.Y - e.Y));
            }
        }

        private void WindowBar_MouseUp(object sender, MouseEventArgs e)
        {
            tagMove = false;
        }

        private void WindowBar_MouseDown(object sender, MouseEventArgs e)
        {
            tagMove = true;
            fPt = new Point(e.X, e.Y);
        }

        private void closeBtn_MouseMove(object sender, MouseEventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(240, 52, 52);
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = BackColor;
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            moveForm.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            moveForm.Close();
        }

        private void windowBarTitle_TextChanged(object sender, EventArgs e)
        {
            windowBarTitle.Location = new Point(windowBarTitle.Location.X, (this.Height - windowBarTitle.Height) / 2);
        }

        private void WindowBar_SizeChanged(object sender, EventArgs e)
        {
            iconBox.Size = new Size(20, 20);
            iconBox.Location = new Point(iconBox.Location.X, (Height - iconBox.Height) / 2);
            windowBarTitle.Location = new Point(windowBarTitle.Location.X, (this.Height - windowBarTitle.Height) / 2);
        }

        private void WindowBar_ParentChanged(object sender, EventArgs e)
        {
            minimizeBtn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(Parent.BackColor);
        }
    }
}
