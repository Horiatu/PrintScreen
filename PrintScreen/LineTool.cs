using System.Drawing;
using System.Drawing.Drawing2D;

namespace FlexScreen
{
    public class LineTool : DrawingTool
    {
        public Pen LinePen { get; set; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public override string Name
        {
            get { return (LinePen.Brush is HatchBrush) ? "Grayout Strip" : "Line"; }
        }

        public override string Tip
        {
            get
            {
                return base.Tip +
@"- Hold [Ctrl] key down to move around.";
            }
        }

        public LineTool(CaptureForm form, Pen borderPen)
            : base(form, 5)
        {
            LinePen = borderPen;
            HideRectangle = true;
        }

        public override void Draw(Graphics g)
        {
            Point1 = ParentForm.StartPoint;
            Point2 = ParentForm.EndPoint;
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            g.DrawLine(LinePen, Point1, Point2);
        }
    }

}
