using System;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public class IndexTool : FillShapeTool
    {
        public int Index { get; set; }
        public Brush FillBrush { get; set; }
        public Pen BorderPen { get; set; }
        public Font IndexFont { get; set; }
        //public Rectangle IndexRectangle { get; set; }
        //public Rectangle BoxRectangle { get; set; }

        public override string Name => "Insert Index";

        public override string Tip => base.Tip + @"
- Use [Up]/[Down]/[Backspace] and 
  digits to change index.";

        public IndexTool(CaptureForm form, int index, Pen borderPen, Brush fillBrush, Font indexFont)
            : base(form, 10)
        {
            Index = index;
            BorderPen = borderPen;
            BorderPen.Width = 4;
            FillBrush = fillBrush;
            IndexFont = indexFont;
        }

        public override void Start()
        {
            base.Start();
            ParentForm.KeyUp += new KeyEventHandler(parentForm_KeyUp);
        }

        public override void Stop()
        {
            ParentForm.KeyUp -= new KeyEventHandler(parentForm_KeyUp);
            ParentForm.LastIndex = Index;
            base.Stop();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Index++;
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
                case Keys.Down:
                    if (Index > 0)
                    {
                        Index--;
                        ParentForm.Invalidate();
                    }
                    e.Handled = true;
                    break;
                case Keys.Back:
                    if (Index > 9)
                    {
                        Index /= 10;
                    }
                    else
                    {
                        Index = 1;
                    }
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
                default:
                    switch (e.KeyValue)
                    {
                        case 48: // 0
                            Index *= 10;
                            ParentForm.Invalidate();
                            e.Handled = true;
                            break;
                        case 49: // 1
                        case 50: // 2
                        case 51: // 3
                        case 52: // 4
                        case 53: // 5
                        case 54: // 6
                        case 55: // 7
                        case 56: // 8
                        case 57: // 9
                            var digit = e.KeyValue - 48;
                            if (Index > 9)
                            {
                                Index = (Index / 10) * 10 + digit;
                            }
                            else
                            {
                                Index = digit;
                            }
                            ParentForm.Invalidate();
                            e.Handled = true;
                            break;
                    }
                    break;
            }
        }

        int Width => ParentForm.SelectedRectangle.Width;
        int Height => ParentForm.SelectedRectangle.Height;

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

        float m_textWidth;
        float m_textHeight;
        int m_descentPixel;
        public override void DrawRectangle(Graphics g)
        {
            var current = ParentForm.CrossPoint; //PointToClient(Cursor.Position);

            var textSize = g.MeasureString(Index.ToString(CultureInfo.InvariantCulture), IndexFont);

            var fontFamily = IndexFont.FontFamily;
            var emHeight = fontFamily.GetEmHeight(IndexFont.Style);

            var descent = fontFamily.GetCellDescent(IndexFont.Style);

            m_descentPixel = (int)Math.Round(IndexFont.Size * descent / emHeight);

            m_textWidth = textSize.Width;
            m_textHeight = textSize.Height - 2 * m_descentPixel;// - ascentPixel;

            var d = Math.Round(Math.Sqrt(m_textWidth * m_textWidth + m_textHeight * m_textHeight)) + 2 * BorderPen.Width;
            
            StartPoint = new Point((int)Math.Round(current.X - d / 2), (int)Math.Round(current.Y - d / 2));
            EndPoint = new Point((int)Math.Round(StartPoint.X + d), (int)Math.Round(StartPoint.Y + d));

            if (!HideRectangle)
            {
                g.DrawRectangle(
                    new Pen(Color.FromArgb(Settings.Default.SelectionOpacity,
                                           Settings.Default.SelectionColor)), ParentForm.SelectedRectangle);
            }
        }

        public override void Draw(Graphics g)
        {
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            g.DrawEllipse(new Pen(Color.FromArgb(128, Color.Black)) { Width = BorderPen.Width },
                StartPoint.X + 2, StartPoint.Y + 2, Width - 3, Height - 3);
            if (FillShape)
            {
                g.FillEllipse(FillBrush, StartPoint.X + 1, StartPoint.Y + 1, Width - 4, Height - 4);
            }
            g.DrawEllipse(BorderPen, StartPoint.X + 1, StartPoint.Y + 1, Width - 4, Height - 4);
            
            g.DrawString(Index.ToString(CultureInfo.InvariantCulture), IndexFont, Brushes.Black,
                StartPoint.X + (Width - m_textWidth) / 2f - 1,
                StartPoint.Y + (Height - m_textHeight) / 2f - m_descentPixel);
            //g.DrawRectangle(new Pen(Color.Black), new Rectangle(
            //    (int)(startPoint.X + (width - textWidth) / 2f),
            //    (int)(startPoint.Y + (height - textHeight) / 2f),
            //    (int)textWidth, (int)textHeight));
        }
    }
}
