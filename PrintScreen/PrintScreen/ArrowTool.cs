using System.Drawing;
using System.Drawing.Drawing2D;

namespace FlexScreen
{
    public class ArrowTool : LineTool
    {
        public override string Name => "Arrow";

        public ArrowTool(CaptureForm form, Pen arrowPen)
            : base(form, arrowPen)
        {
            HideRectangle = true;
            LinePen = arrowPen;
            if (LinePen.CustomEndCap == null)
            {
                LinePen.CustomEndCap = new AdjustableArrowCap(4, 6);
            }
        }
    }
}
