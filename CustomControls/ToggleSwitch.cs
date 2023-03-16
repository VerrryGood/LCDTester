using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    public class ToggleSwitch : CheckBox
    {
        public ToggleSwitch()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        private Color selectedColor = Color.MediumTurquoise;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                using (SolidBrush brush = new SolidBrush(selectedColor))
                {
                    e.Graphics.FillPath(Checked ? brush : Brushes.LightGray, path);
                }
                r = Height - 1;
                var rect = Checked ? new Rectangle(Width - r, 1, r - 2, r - 2)
                                   : new Rectangle(2, 1, r - 2, r - 2);
                e.Graphics.FillEllipse(Checked ? Brushes.White : Brushes.White, rect);
            }
        }
    }
}
