using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public class TextTool : DrawingTool
    {
        public string Text { get; set; }
        public Font TextFont { get; set; }
        public Brush TextBrush { get; set; }
        public Point TextStartPoint { get; set; }

        public override string Name => "Insert Text";

        public override string Tip => base.Tip +
                                      @"- Press [Space] key to flip outline.";

        public TextTool(CaptureForm form, string text, Font font, Brush textBrush)
            : base(form, 12)
        {
            Text = text;
            TextFont = font;
            TextBrush = textBrush;
        }

        bool m_textWithBorder;
        SizeF m_size;
        public override void Start()
        {
            base.Start();
            var textImage = new Bitmap(100, 100);
            var g = Graphics.FromImage(textImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            m_size = g.MeasureString(Text, TextFont);
            m_textWithBorder = Settings.Default.TextWithBorder;
            ParentForm.KeyUp += parentForm_KeyUp;
        }

        public override void Stop()
        {
            ParentForm.KeyUp -= parentForm_KeyUp;
            base.Stop();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
         {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    m_textWithBorder = !m_textWithBorder;
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
            }
        }

        public override void DrawRectangle(Graphics g)
        {
            var current = ParentForm.PointToClient(Cursor.Position);
            ParentForm.StartPoint = new Point(current.X - (int)m_size.Width / 2 - 1, current.Y - (int)m_size.Height / 2 - 1);
            var startPoint = ParentForm.StartPoint;
            ParentForm.EndPoint = new Point(startPoint.X + (int)m_size.Width + 1, startPoint.Y + (int)m_size.Height + 1);
            if (!HideRectangle)
            {
                g.DrawRectangle(new Pen(Color.FromArgb((int)(Settings.Default.SelectionOpacity), Settings.Default.SelectionColor)), ParentForm.SelectedRectangle);
            }
        }

        public override void Draw(Graphics g)
        {
            TextStartPoint = new Point(
                ParentForm.SelectedRectangle.X + (ParentForm.SelectedRectangle.Width - (int)m_size.Width) / 2,
                ParentForm.SelectedRectangle.Y + (ParentForm.SelectedRectangle.Height - (int)m_size.Height) / 2)
            ;
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            if (m_textWithBorder)
            {
                var x = TextStartPoint.X;
                var y = TextStartPoint.Y;
                g.DrawString(Text, TextFont, Brushes.White, new Point(x - 1, y - 1));
                g.DrawString(Text, TextFont, Brushes.White, new Point(x - 0, y - 1));
                g.DrawString(Text, TextFont, Brushes.White, new Point(x + 1, y - 1));

                g.DrawString(Text, TextFont, Brushes.White, new Point(x - 1, y ));
                g.DrawString(Text, TextFont, Brushes.White, new Point(x + 1, y ));

                g.DrawString(Text, TextFont, Brushes.White, new Point(x - 1, y + 1));
                g.DrawString(Text, TextFont, Brushes.White, new Point(x - 0, y + 1));
                g.DrawString(Text, TextFont, Brushes.White, new Point(x + 1, y + 1));
            }
            g.DrawString(Text, TextFont, TextBrush, TextStartPoint);
        }
    }

}
