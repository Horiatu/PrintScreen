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
    public partial class BordlessForm : Form
    {
        public BordlessForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawFrame(e);
        }

        protected System.Drawing.Drawing2D.GraphicsPath Frame;
        public void DrawFrame(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(1, 1, Width - 2, Height - 2);
            Frame = Utils.RoundRectangle(rect, 12, Corners.All);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(Color.FromArgb(128, Color.Black)) { Width = 3 }, Frame);

            using (GraphicsPath gp = new GraphicsPath())
            {
                rect.Inflate(2, 2);
                gp.AddPath(Utils.RoundRectangle(rect, 19, Corners.All), true);
                Region = new Region(gp);
            }
        }

        #region moue events
        public void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utils.ReleaseCapture();
                ((Control)sender).Cursor = Cursors.SizeAll;
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, Utils.HT_CAPTION, 0);
            }
        }

        public void form_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
        }
        #endregion


    }
}
