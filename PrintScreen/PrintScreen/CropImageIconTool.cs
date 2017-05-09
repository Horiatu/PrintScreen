using System.Drawing;

namespace FlexScreen
{
    public class CropImageIconTool : DrawingTool
    {
        public override string Name => string.Format("Crop Icon ({0}x{1})", imageSize.Width, imageSize.Height);

        Size imageSize = new Size(32, 32);
        public CropImageIconTool(CaptureForm form, Size? size = null)
            : base(form, 0)
        {
            if (size.HasValue)
            {
                imageSize = size.Value;
            }
        }

        public override string Tip => base.Tip + @"Place frame, then crop or copy.";

        /// <summary>
        /// Draws the rectangle.
        /// </summary>
        /// <param name="g">The g.</param>
        public override void DrawRectangle(Graphics g)
        {
            var endPoint = ParentForm.EndPoint;
            ParentForm.StartPoint = new Point(endPoint.X - imageSize.Width, endPoint.Y - imageSize.Height);
            g.DrawRectangle(new Pen(Color.FromArgb(127, Color.Black)), ParentForm.SelectedRectangle);
        }
    }
}
