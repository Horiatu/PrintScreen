using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

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

        public override string Name
        {
            get { return "Insert Index"; }
        }

        public override string Tip
        {
            get
            {
                return base.Tip + @"
- Use [Up]/[Down]/[Backspace] and 
  digits to change index.";
            }
        }

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
                            int digit = e.KeyValue - 48;
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

        int width { get { return ParentForm.SelectedRectangle.Width; } }
        int height { get { return ParentForm.SelectedRectangle.Height; } }
        Point startPoint
        {
            get { return ParentForm.StartPoint; }
            set { ParentForm.StartPoint = value; }
        }
        Point endPoint
        {
            get { return ParentForm.EndPoint; }
            set { ParentForm.EndPoint = value; }
        }

        float textWidth;
        float textHeight;
        int ascentPixel;
        int descentPixel;
        public override void DrawRectangle(Graphics g)
        {
            var current = ParentForm.CrossPoint; //PointToClient(Cursor.Position);

            var textSize = g.MeasureString(Index.ToString(CultureInfo.InvariantCulture), IndexFont);

            var fontFamily = IndexFont.FontFamily;
            var emHeight = fontFamily.GetEmHeight(IndexFont.Style);

            var ascent = fontFamily.GetCellAscent(IndexFont.Style);
            var descent = fontFamily.GetCellDescent(IndexFont.Style);

            ascentPixel = (int)Math.Round(IndexFont.Size * ascent / emHeight);
            descentPixel = (int)Math.Round(IndexFont.Size * descent / emHeight);

            textWidth = textSize.Width;
            textHeight = textSize.Height - 2 * descentPixel;// - ascentPixel;

            var d = Math.Round(Math.Sqrt(textWidth * textWidth + textHeight * textHeight)) + 2 * BorderPen.Width;
            
            startPoint = new Point((int)Math.Round(current.X - d / 2), (int)Math.Round(current.Y - d / 2));
            endPoint = new Point((int)Math.Round(startPoint.X + d), (int)Math.Round(startPoint.Y + d));

            if (!HideRectangle)
            {
                g.DrawRectangle(
                    new Pen(Color.FromArgb((int)(Program.MySettings.SelectionOpacity),
                                           Program.MySettings.SelectionColor)), ParentForm.SelectedRectangle);
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
                startPoint.X + 2, startPoint.Y + 2, width - 3, height - 3);
            if (FillShape)
            {
                g.FillEllipse(FillBrush, startPoint.X + 1, startPoint.Y + 1, width - 4, height - 4);
            }
            g.DrawEllipse(BorderPen, startPoint.X + 1, startPoint.Y + 1, width - 4, height - 4);
            
            g.DrawString(Index.ToString(CultureInfo.InvariantCulture), IndexFont, Brushes.Black,
                startPoint.X + (width - textWidth) / 2f - 1,
                startPoint.Y + (height - textHeight) / 2f - descentPixel);
            //g.DrawRectangle(new Pen(Color.Black), new Rectangle(
            //    (int)(startPoint.X + (width - textWidth) / 2f),
            //    (int)(startPoint.Y + (height - textHeight) / 2f),
            //    (int)textWidth, (int)textHeight));
        }
    }
}
