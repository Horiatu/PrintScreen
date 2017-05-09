using System;
using System.Drawing;

namespace FlexScreen
{
    public class ZoneHandlerArgs: EventArgs
    {
        public Rectangle Rectangle { get; private set; }
        public Graphics Graphics { get; private set; }
        public int Index { get; private set; }

        public ZoneHandlerArgs(Graphics graphics, Rectangle rectangle, int index)
            : base()
        {
            Graphics = graphics;
            Rectangle = rectangle;
            Index = index;
        }
    }
}
