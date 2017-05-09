using System.Drawing;

namespace FlexScreen
{
    public class RectangleTool : FillShapeTool
    {
        Pen BorderPen { get; set; }
        Brush FillBrush { get; set; }
        Rectangle RectRectangle { get; set; }

        public override string Name => "Rectangle";

        public RectangleTool(CaptureForm form, Pen borderPen, Brush fillBrush)
            : base(form, 8)
        {
            HideRectangle = true;
            BorderPen = borderPen;
            FillBrush = fillBrush;
        }

        public override void Draw(Graphics g)
        {
            RectRectangle = ParentForm.SelectedRectangle;
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            if (BorderPen != null)
            {
                var shadow = new Pen(Color.FromArgb(64, Color.Gray));
                g.DrawRectangle(shadow, new Rectangle(RectRectangle.X + 1, RectRectangle.Y + 1, RectRectangle.Width, RectRectangle.Height));
                g.DrawRectangle(shadow, new Rectangle(RectRectangle.X + 2, RectRectangle.Y + 2, RectRectangle.Width, RectRectangle.Height));
            }
            if (FillShape)
            {
                if (FillBrush != null) g.FillRectangle(FillBrush, RectRectangle);
            }
            if (BorderPen != null) g.DrawRectangle(BorderPen, RectRectangle);
        }
    }

}
