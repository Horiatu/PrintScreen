﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System;
using FlexScreen.Properties;

namespace FlexScreen
{
    public class ZoomLentsTool : DrawingTool
    {
        public Image OriginalMagnifierGlassImage { get; set; }
        public Image MagnifierGlassImage { get; set; }
        public Point MagnifierPoint { get; set; }
        public int MagnifyFactor { get; set; }

        public override string Name => "Magnify Lens";

        public override string Tip => $@"{base.Tip}
- Hold [Ctrl] key down to resize.
- Press [Up]/[Down] keys to change the magnify factor.";

        private int MagnifyIndex
        {
            get
            {
                return m_magnifyIndex;
            }
            set
            {
                if (m_magnifyIndex != value)
                {
                    m_magnifyIndex = value % m_magnifyFactors.Length;
                    MagnifyFactor = m_magnifyFactors[m_magnifyIndex];
                }
            }
        }

        readonly int[] m_magnifyFactors = { 2, 3, 5, 7 };
        int m_magnifyIndex = 1;

        int Width => MagnifierGlassImage.Width;
        int Height => MagnifierGlassImage.Height;

        Point StartPoint
        {
            get { return ParentForm.StartPoint; }
            set { ParentForm.StartPoint = value; }
        }
        Point EndPoint
        {
            get { return ParentForm.EndPoint; }
            set { ParentForm.EndPoint = value; }
        }

        public ZoomLentsTool(CaptureForm form, int magnifyFactor)
            : base(form, 11)
        {
            OriginalMagnifierGlassImage = Resources.magnifierGlass;
            MagnifyFactor = magnifyFactor;
            MagnifierGlassImage = OriginalMagnifierGlassImage;
            HideRectangle = true;
        }

        public override void Start()
        {
            base.Start();
            ParentForm.KeyUp += parentForm_KeyUp;
        }

        public override void Stop()
        {
            ParentForm.KeyUp -= parentForm_KeyUp;
            base.Stop();
        }

        public void NextMagnifyFactor()
        {
            MagnifyIndex = MagnifyIndex + 1;
            ParentForm.Invalidate();
        }

        public void PrevMagnifyFactor()
        {
            MagnifyIndex = MagnifyIndex + m_magnifyFactors.Length - 1;
            ParentForm.Invalidate();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    NextMagnifyFactor();
                    e.Handled = true;
                    break;
                case Keys.Down:
                    PrevMagnifyFactor();
                    e.Handled = true;
                    break;
            }
        }

        public override void DrawRectangle(Graphics g)
        {
            var current = ParentForm.CrossPoint; 

            if (ParentForm.ControlKeyPressed)
            {
                var p = new Point(current.X + Width/2, current.Y + Height/2);
                if (p.X - StartPoint.X > 25 && p.Y - StartPoint.Y > 25)
                {
                    EndPoint = p;
                    MagnifierGlassImage = new Bitmap(OriginalMagnifierGlassImage, ParentForm.SelectedRectangle.Size);
                }
            }
            else
            {
                StartPoint = new Point(current.X - Width / 2, current.Y - Height / 2);
                EndPoint = new Point(StartPoint.X + Width, StartPoint.Y + Height);
            }

            if (!HideRectangle)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(Settings.Default.SelectionOpacity, Settings.Default.SelectionColor)), ParentForm.SelectedRectangle);
            }
        }

        public override void Draw(Graphics g)
        {
            MagnifierPoint = new Point(StartPoint.X + 1, StartPoint.Y + 1);
            Execute(g);
            if (ParentForm.AltKeyPressed)
            {
                var magnify = "x" + MagnifyFactor.ToString(CultureInfo.InvariantCulture);
                var font = new Font("Arial", 10.0f, FontStyle.Bold);
                var s = g.MeasureString(magnify, font);
                var point = new PointF(ParentForm.SelectedRectangle.X + (ParentForm.SelectedRectangle.Width - s.Width) / 2, ParentForm.SelectedRectangle.Y + (ParentForm.SelectedRectangle.Height - s.Height) / 2);
                g.DrawString(magnify, font, Brushes.Pink, new PointF(point.X + 1, point.Y + 1));
                g.DrawString(magnify, font, Brushes.Black, point);
            }
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            try
            {
                using (Image lensImage = new Bitmap(Width, Height))
                {
                    var lens = Graphics.FromImage(lensImage);
                    lens.CompositingMode = CompositingMode.SourceOver;
                    lens.SmoothingMode = SmoothingMode.HighQuality;

                    var w = (int)Math.Round((double)Width / MagnifyFactor);
                    var h = (int)Math.Round((double)Height / MagnifyFactor);
                    var x = MagnifierPoint.X + (int)Math.Round((Width - w) / 2.0);
                    var y = MagnifierPoint.Y + (int)Math.Round((Height - h) / 2.0);

                    using (Image bufferImage = new Bitmap(Width, Height))
                    {
                        var buffer = Graphics.FromImage(bufferImage);
                        buffer.SmoothingMode = SmoothingMode.HighQuality;
                        //buffer.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(220, Color.GhostWhite), Color.FromArgb(150, Color.Black)), new Rectangle(0, 0, width, height));
                        buffer.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Black)), new Rectangle(0, 0, Width, Height));

                        using (var cropImage = ParentForm.CropImage(ParentForm.BackgroundImage, new Rectangle(x, y, w, h)))
                        {
                            if (cropImage != null)
                            {
                                var dw = cropImage.Width * MagnifyFactor;
                                var dh = cropImage.Height * MagnifyFactor;
                                var dx = (cropImage.Width < w && x < 0) ? Width - dw : 0;
                                var dy = (cropImage.Height < h && y < 0) ? Height - dh : 0;
                                buffer.DrawImage(cropImage, new Rectangle(dx, dy, dw, dh), 0, 0, cropImage.Width, cropImage.Height, GraphicsUnit.Pixel);
                            }
                        }

                        var tb = new TextureBrush(bufferImage);
                        lens.FillEllipse(tb, 0, 0, Width - 3, Height - 3);
                    }
                    lens.DrawEllipse(new Pen(Color.FromArgb(80, Color.Black), 2), 1, 1, Width - 4, Height - 4);
                    lens.DrawImage(MagnifierGlassImage, 0, 0, Width - 4, Height - 4);

                    g.DrawImage(lensImage, MagnifierPoint);
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
        }
    }
}
