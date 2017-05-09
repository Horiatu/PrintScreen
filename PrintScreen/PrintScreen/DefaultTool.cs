using System.Drawing;

namespace FlexScreen
{
    public class DefaultTool : DrawingTool
    {
        public DefaultTool(CaptureForm form) : base(form, 0) { }

        public override string Name => "Default";

        public override void Undo()
        {
        }

        public override void Redo()
        {
        }

        public override void Start()
        {
        }

        public override void Stop()
        {
        }

        public override void Draw(Graphics g)
        {
        }
    }
}
