using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlexScreen
{
    public static class Help
    {
        static Font fontLogo = new Font("Arial", 18, FontStyle.Bold);
        static Font fontText = new Font("Arial", 10, FontStyle.Bold);

        static Size GetLogoSize(Graphics g, int dx, int dy)
        {
            SizeF s = g.MeasureString("F1", fontLogo);
            return new Size(2 * dx + (int)s.Width + 1, 2 * dy + (int)s.Height + 1);
        }

        public static void Show(Graphics g, string text, int x, int y)
        {
            Size logoSize = GetLogoSize(g, 5, 5);
            SizeF textSize = g.MeasureString(text, fontText);
            Rectangle R = new Rectangle(x, y, 
                logoSize.Width + (int)textSize.Width + 5, 
                Math.Max(logoSize.Height, (int)textSize.Height + 10));
            g.DrawRectangle(new Pen(Color.LightGray, 2), new Rectangle(R.X+2, R.Y+2, R.Width, R.Height));
            g.FillRectangle(new SolidBrush(Color.FromArgb(220, Color.PaleGoldenrod)), R);
            g.DrawRectangle(new Pen(Color.Navy, 2), R);
            g.DrawString("F1", fontLogo, Brushes.White, new PointF(R.X + 7, R.Y + 7));
            g.DrawString("F1", fontLogo, Brushes.Navy, new PointF(R.X + 5, R.Y + 5));
            g.DrawString(text, fontText, Brushes.Navy, new PointF(R.X+logoSize.Width, R.Y+5));
        }
    }
}
