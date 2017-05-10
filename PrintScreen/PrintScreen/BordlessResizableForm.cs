using System.Drawing;
using System.Windows.Forms;

namespace FlexScreen
{
    public partial class BordlessResizableForm : BordlessForm
    {
        public BordlessResizableForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawFrame1(e);
        }

        public void DrawFrame1(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(Color.White) { Width = 1 }, Frame);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized)
            {
                ResizeForm(GetResizeDirection(e));
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            GetResizeDirection(e);
        } 

        enum ResizeDirection
        {
            None = -1,
            Left,
            TopLeft,
            Top,
            TopRight,
            Right,
            BottomRight,
            Bottom,
            BottomLeft
        }

        void ResizeForm(ResizeDirection direction)
        {
            var dir = -1;
            switch (direction)
            {
                case ResizeDirection.Left:
                    dir = Utils.HTLEFT;
                    break;
                case ResizeDirection.TopLeft:
                    dir = Utils.HTTOPLEFT;
                    break;
                case ResizeDirection.Top:
                    dir = Utils.HTTOP;
                    break;
                case ResizeDirection.TopRight:
                    dir = Utils.HTTOPRIGHT;
                    break;
                case ResizeDirection.Right:
                    dir = Utils.HTRIGHT;
                    break;
                case ResizeDirection.BottomRight:
                    dir = Utils.HTBOTTOMRIGHT;
                    break;
                case ResizeDirection.Bottom:
                    dir = Utils.HTBOTTOM;
                    break;
                case ResizeDirection.BottomLeft:
                    dir = Utils.HTBOTTOMLEFT;
                    break;
            }

            if (dir != -1)
            {
                Utils.ReleaseCapture();
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, dir, 0);
            }
            else
            {
                Utils.ReleaseCapture();
                Cursor = Cursors.SizeAll;
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, Utils.HT_CAPTION, 0);
            }
        }

        private ResizeDirection GetResizeDirection(MouseEventArgs e)
        {
            const int delta = 6;
            if (e.Location.X < delta && e.Location.Y < delta)
            {
                Cursor = Cursors.SizeNWSE;
                return ResizeDirection.TopLeft;
            }
            if (e.Location.X < delta && e.Location.Y > Height - delta)
            {
                Cursor = Cursors.SizeNESW;
                return ResizeDirection.BottomLeft;
            }
            if (e.Location.X > (Width - delta) && e.Location.Y > (Height - delta))
            {
                Cursor = Cursors.SizeNWSE;
                return ResizeDirection.BottomRight;
            }
            if (e.Location.X > Width - delta && e.Location.Y < delta)
            {
                Cursor = Cursors.SizeNESW;
                return ResizeDirection.TopRight;
            }
            if (e.Location.X < delta)
            {
                Cursor = Cursors.SizeWE;
                return ResizeDirection.Left;
            }
            if (e.Location.X > Width - delta)
            {
                Cursor = Cursors.SizeWE;
                return ResizeDirection.Right;
            }
            if (e.Location.Y < delta)
            {
                Cursor = Cursors.SizeNS;
                return ResizeDirection.Top;
            }
            if (e.Location.Y > Height - delta)
            {
                Cursor = Cursors.SizeNS;
                return ResizeDirection.Bottom;
            }
            Cursor = Cursors.Default;
            return ResizeDirection.None;
        }

    }
}
