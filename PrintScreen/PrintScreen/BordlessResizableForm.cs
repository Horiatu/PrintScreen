using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
            if (e.Button == System.Windows.Forms.MouseButtons.Left && WindowState != FormWindowState.Maximized)
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
            int dir = -1;
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
                this.Cursor = Cursors.SizeAll;
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, Utils.HT_CAPTION, 0);
            }
        }

        private ResizeDirection GetResizeDirection(MouseEventArgs e)
        {
            const int delta = 6;
            if (e.Location.X < delta && e.Location.Y < delta)
            {
                this.Cursor = Cursors.SizeNWSE;
                return ResizeDirection.TopLeft;
            }
            else if (e.Location.X < delta && e.Location.Y > Height - delta)
            {
                this.Cursor = Cursors.SizeNESW;
                return ResizeDirection.BottomLeft;
            }
            else if (e.Location.X > (Width - delta) && e.Location.Y > (Height - delta))
            {
                this.Cursor = Cursors.SizeNWSE;
                return ResizeDirection.BottomRight;
            }
            else if (e.Location.X > Width - delta && e.Location.Y < delta)
            {
                this.Cursor = Cursors.SizeNESW;
                return ResizeDirection.TopRight;
            }
            else if (e.Location.X < delta)
            {
                this.Cursor = Cursors.SizeWE;
                return ResizeDirection.Left;
            }
            else if (e.Location.X > Width - delta)
            {
                this.Cursor = Cursors.SizeWE;
                return ResizeDirection.Right;
            }
            else if (e.Location.Y < delta)
            {
                this.Cursor = Cursors.SizeNS;
                return ResizeDirection.Top;
            }
            else if (e.Location.Y > Height - delta)
            {
                this.Cursor = Cursors.SizeNS;
                return ResizeDirection.Bottom;
            }
            else
            {
                this.Cursor = Cursors.Default;
                return ResizeDirection.None;
            }
        }

    }
}
