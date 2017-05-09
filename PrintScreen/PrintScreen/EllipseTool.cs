using System.Drawing;

namespace FlexScreen
{
    public class EllipseTool : FillShapeTool
    {
        Pen BorderPen { get; set; }
        Brush FillBrush { get; set; }
        Rectangle EllipseRectangle { get; set; }

        public override string Name => "Ellipse";

        public EllipseTool(CaptureForm form, Pen borderPen, Brush fillBrush)
            : base(form, 9)
        {
            BorderPen = borderPen;
            FillBrush = fillBrush;
        }

        public override void Draw(Graphics g)
        {
            EllipseRectangle = ParentForm.SelectedRectangle;
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            if (BorderPen != null)
            {
                var shadow = new Pen(Color.FromArgb(64, Color.Gray));
                g.DrawEllipse(shadow, new Rectangle(EllipseRectangle.X + 1, EllipseRectangle.Y + 1, EllipseRectangle.Width, EllipseRectangle.Height));
                g.DrawEllipse(shadow, new Rectangle(EllipseRectangle.X + 2, EllipseRectangle.Y + 2, EllipseRectangle.Width, EllipseRectangle.Height));
            }
            if (FillShape)
            {
                g.FillEllipse(FillBrush, EllipseRectangle);
            }
            if (BorderPen != null) g.DrawEllipse(BorderPen, EllipseRectangle);
        }
    }

}
