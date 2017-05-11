using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlexScreen
{
    public class PickColorTool : DrawingTool
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public override string Name => "Pick Color";

        public override string Tip => $@"{base.Tip}
- [Space] - change format,
- [C] - copy color code to clipboard,
";

        public PickColorTool(CaptureForm form)
            : base(form, 0)
        {
            HideRectangle = true;
        }

        public override void Start()
        {
            base.Start();
            ParentForm.KeyUp += parentForm_KeyUp;
            ParentForm.TemporaryPaint += WriteCode;
        }

        public override void Stop()
        {
            ParentForm.KeyUp -= parentForm_KeyUp;
            ParentForm.TemporaryPaint -= WriteCode;

            base.Stop();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    m_formatIndex = (++m_formatIndex) % m_colorFormats.Length;
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
                case Keys.C:
                    Clipboard.Clear();
                    Clipboard.SetText(m_colorCode);
                    break;
            }
        }

        private readonly string[] m_colorFormats = { "#FF{0:X2}{1:X2}{2:X2}", "0xFF{0:X2}{1:X2}{2:X2}", "red={0}, green={1}, blue={2}", "{0:D3} {1:D3} {2:D3}", "{0:D3}, {1:D3}, {2:D3}", "Color.FromArgb(255, {0:D3}, {1:D3}, {2:D3})", "NamedColor" };
        private int m_formatIndex = 0;
        private string m_colorCode;

        void WriteCode(object sender, Graphics g)
        {
            m_colorCode = m_colorFormats[m_formatIndex] == "NamedColor"
                              ?
                              "Color: " + (AvgColor.IsNamedColor
                                     ? TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(AvgColor)
                                     : string.Format(m_colorFormats[0], Red, Green, Blue))
                              : string.Format(m_colorFormats[m_formatIndex], Red, Green, Blue);

            var textFont = new Font("Arial", 9);

            //var textImage = new Bitmap(100, 100);
            //var gi = Graphics.FromImage(textImage);
            //gi.SmoothingMode = SmoothingMode.AntiAlias;
            //var size = gi.MeasureString(text, textFont);

            var x = Math.Min(Point1.X, Point2.X);
            var y = Math.Max(Point1.Y, Point2.Y);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (var i = -2; i <= 2; i++)
                for (var j = -2; j <= 2; j++)
                    g.DrawString(m_colorCode, textFont, Brushes.Azure, x + i, y + j);
            g.DrawString(m_colorCode, textFont, Brushes.Navy, x, y);
        }

        
        public override void Draw(Graphics g)
        {
            Point1 = ParentForm.StartPoint;
            Point2 = ParentForm.EndPoint;
            Execute(g);
        }

        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }
        public Color AvgColor { get; private set; }

        public override void Execute(Graphics g)
        {
            base.Execute(g);

            var x1 = Math.Min(Point1.X, Point2.X);
            var x2 = Math.Max(Point1.X, Point2.X);
            var y1 = Math.Min(Point1.Y, Point2.Y);
            var y2 = Math.Max(Point1.Y, Point2.Y);

            if (x1 == x2) x2++;
            if (y1 == y2) y2++;
            if (x1 < x2 && y1 < y2)
            {
                var bmp =
                    ParentForm.CropImage(ParentForm.BackgroundImage, new Rectangle(x1, y1, x2 - x1, y2 - y1)) as Bitmap;

                var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                var bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                try
                {
                    // Get the address of the first line.
                    var ptr = bmpData.Scan0;

                    var byteCount = Math.Abs(bmpData.Stride) * bmp.Height;
                    var argb = new byte[byteCount];

                    // Copy the RGB values into the array.
                    System.Runtime.InteropServices.Marshal.Copy(ptr, argb, 0, byteCount);

                    long R = 0;
                    long G = 0;
                    long B = 0;
                    long n = 0;
                    for (var i = 0; i < argb.Length; i += 4)
                    {
                        n++;
                        B += argb[i];
                        G += argb[i + 1];
                        R += argb[i + 2];
                    }

                    // Copy the RGB values back to the bitmap
                    //System.Runtime.InteropServices.Marshal.Copy(argb, 0, ptr, byteCount);

                    Red = (byte)(R / n);
                    Green = (byte)(G / n);
                    Blue = (byte)(B / n);
                    AvgColor = Color.FromArgb(255, Red, Green, Blue);
                    g.FillRectangle(new SolidBrush(AvgColor), x1, y1, x2 - x1, y2 - y1);

                }
                finally
                {
                    bmp.UnlockBits(bmpData);
                }
            }
        }
    }
}


