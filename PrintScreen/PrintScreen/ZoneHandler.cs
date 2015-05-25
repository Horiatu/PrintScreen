using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Graphics = graphics;
            Rectangle = rectangle;
            Index = index;
        }
    }
}
