using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlexScreen
{
    public class FillShapeTool : DrawingTool
    {
        public FillShapeTool(CaptureForm form, int helpContextId) : base(form, helpContextId) { }

        public static bool FillShape = true;

        public override string Name
        {
            get { return "Fill"; }
        }

        public override string Tip
        {
            get
            {
                return base.Tip +
@"- Hold [Ctrl] key down to move around.
- Press [Space] to flip the filling.";
            }
        }

        public override void Start()
        {
            base.Start();
            ParentForm.KeyUp += parentForm_KeyUp;
        }

        public override void Stop()
        {
            ParentForm.KeyUp -= parentForm_KeyUp;
            base.Stop();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    FillShape = !FillShape;
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
            }
        }


    }
}
