using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace FlexScreen
{
    ///----------------------------------------------------------------------------
    /// Class     : MagnifierForm
    /// Purpose   : Provide simple magnifier. 
    /// Written by: Ogun TIGLI
    /// History   : 31 May 2006/Wed starting date.
    ///             22 Dec 2006/Fri minor code fixes and hotsot support addition.
    ///             01 Apr 2007/Sun XML serialization support added.
    ///             
    /// Notes: 
    /// This software is provided 'as-is', without any express or implied 
    /// warranty. In no event will the author be held liable for any damages 
    /// arising from the use of this software.
    /// 
    /// Permission is granted to anyone to use this software for any purpose, 
    /// including commercial applications, and to alter it and redistribute it 
    /// freely, subject to the following restrictions:
    ///     1. The origin of this software must not be misrepresented; 
    ///        you must not claim that you wrote the original software. 
    ///        If you use this software in a product, an acknowledgment 
    ///        in the product documentation would be appreciated. 
    ///     2. Altered source versions must be plainly marked as such, and 
    ///        must not be misrepresented as being the original software.
    ///     3. This notice cannot be removed, changed or altered from any source 
    ///        code distribution.
    /// 
    ///        (c) 2006-2007 Ogun TIGLI. All rights reserved. 
    ///----------------------------------------------------------------------------
    public partial class MagnifyForm : Form
    {
        #region Data Members
        private Timer m_Timer;
        private Image m_ImageMagnifier;
        private Image m_BufferImage = null;
        private Point m_StartPoint;
        private PointF m_TargetPoint;
        private PointF m_CurrentPoint;
        private Point m_Offset;
        private bool m_FirstTime = true;
        private static Point m_LastMagnifierPosition = Cursor.Position;
        #endregion

        int[] magnifyFactors = { 2, 3, 5, 7 };

        int m_magnifyIndex = 1;
        public int MagnifyIndex
        {
            get
            {
                return m_magnifyIndex;
            }
            private set
            {
                if (m_magnifyIndex != value)
                {
                    m_magnifyIndex = value % magnifyFactors.Length;
                    MagnifyFactor = magnifyFactors[m_magnifyIndex];
                }
            }
        }

        public void NextMagnifyFactor()
        {
            MagnifyIndex = MagnifyIndex + 1;
        }

        public void PrevMagnifyFactor()
        {
            MagnifyIndex = MagnifyIndex + magnifyFactors.Length - 1;
        }

        int m_magnifyFactor = 2;
        public int MagnifyFactor
        {
            get
            {
                return m_magnifyFactor;
            }
            private set
            {
                if (m_magnifyFactor != value)
                {
                    m_magnifyFactor = value;
                    MagnifyText.Text = (m_magnifyFactor > 1) ? ("x" + m_magnifyFactor) : "";
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                NextMagnifyFactor();
            }
            else if (e.Delta < 0)
            {
                PrevMagnifyFactor();
            }
        }

        public Image ScreenImage { get; set; }

        public void Show(Point startPoint)
        {
            m_StartPoint = startPoint;
            m_TargetPoint = startPoint;
            Show();
        }

        public MagnifyForm()
        {
            InitializeComponent();

            //--- My Init ---
            FormBorderStyle = FormBorderStyle.None;

            TopMost = true;
            Width = 200;
            Height = 200;

            // Make the window (the form) circular
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(ClientRectangle);
            Region = new Region(gp);

            m_ImageMagnifier = global::FlexScreen.Properties.Resources.magnifierGlass;

            m_Timer = new Timer();
            m_Timer.Enabled = true;
            m_Timer.Interval = 20;
            m_Timer.Tick += new EventHandler(HandleTimer);

            ScreenImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Enabled = false;
            ShowInTaskbar = false;

            MagnifyText.Text = (m_magnifyFactor > 1) ? ("x" + m_magnifyFactor) : "";
        }

        protected override void OnShown(EventArgs e)
        {
            RepositionAndShow();
        }

        private delegate void RepositionAndShowDelegate();

        private void RepositionAndShow()
        {
            if (InvokeRequired)
            {
                Invoke(new RepositionAndShowDelegate(RepositionAndShow));
            }
            else
            {
                // Capture the screen image now!
                Graphics g = Graphics.FromImage(ScreenImage);
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenImage.Width, ScreenImage.Height));
                g.Dispose();

                Capture = true;

                m_CurrentPoint = Cursor.Position;
                Show();
            }
        }

        void HandleTimer(object sender, EventArgs e)
        {
            int SpeedFactor = 1;
            float dx = SpeedFactor * (m_TargetPoint.X - m_CurrentPoint.X);
            float dy = SpeedFactor * (m_TargetPoint.Y - m_CurrentPoint.Y);

            if (m_FirstTime)
            {
                m_FirstTime = false;

                m_CurrentPoint.X = m_TargetPoint.X;
                m_CurrentPoint.Y = m_TargetPoint.Y;

                Left = (int)m_CurrentPoint.X - Width / 2;
                Top = (int)m_CurrentPoint.Y - Height / 2;

                return;
            }

            m_CurrentPoint.X += dx;
            m_CurrentPoint.Y += dy;

            if (Math.Abs(dx) < 1 && Math.Abs(dy) < 1)
            {
                m_Timer.Enabled = false;
            }
            else
            {
                // Update location
                Left = (int)m_CurrentPoint.X - Width / 2;
                Top = (int)m_CurrentPoint.Y - Height / 2;
                m_LastMagnifierPosition = new Point((int)m_CurrentPoint.X, (int)m_CurrentPoint.Y);
            }

            Refresh();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_Offset = new Point(Width / 2 - e.X, Height / 2 - e.Y);
            m_CurrentPoint = PointToScreen(new Point(e.X + m_Offset.X, e.Y + m_Offset.Y));
            m_TargetPoint = m_CurrentPoint;
            m_Timer.Enabled = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Close();
            ScreenImage.Dispose();

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_TargetPoint = PointToScreen(new Point(e.X + m_Offset.X, e.Y + m_Offset.Y));
                m_Timer.Enabled = true;
            }
            base.OnMouseMove(e);
        }

        public Point TargetPoint
        {
            set
            {
                try
                {
                    m_TargetPoint = PointToScreen(value);
                    m_Timer.Enabled = true;
                }
                catch { }
            }
        }

        protected override void OnMove(EventArgs e)
        {
            m_Timer.Enabled = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_BufferImage == null)
            {
                m_BufferImage = new Bitmap(Width, Height);
            }
            Graphics g = Graphics.FromImage(m_BufferImage);

            if (ScreenImage != null)
            {
                Rectangle dest = new Rectangle(0, 0, Width, Height);
                int w = (int)(Width / MagnifyFactor);
                int h = (int)(Height / MagnifyFactor);
                int x = Left - w / 2 + Width / 2;
                int y = Top - h / 2 + Height / 2;

                g.SmoothingMode = SmoothingMode.Default;

                g.DrawImage(
                    ScreenImage,
                    dest,
                    x, y, w, h,
                    GraphicsUnit.Pixel);
            }

            if (m_ImageMagnifier != null)
            {
                g.DrawImage(m_ImageMagnifier, 0, 0, Width, Height);
            }

            e.Graphics.DrawImage(m_BufferImage, 0, 0, Width, Height);
        }
    }
}
