using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public abstract class DrawingTool
    {
        public Image UndoImage { get; set; }
        public Rectangle UndoRectangle { get; set; }
        public int HelpContextIndex { get; set; }

        public abstract string Name { get; }
        public virtual string Tip => @"Click and hold to start drawing,
whille holding the mouse left-button:
- Hold [Alt] key down to see coordinates.
";

        public virtual void Execute(Graphics g)
        {
            g.CompositingMode = CompositingMode.SourceOver;
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public virtual void Undo()
        {
            using (var g = Graphics.FromImage(ParentForm.BackgroundImage))
            {
                try
                {
                    g.DrawImage(UndoImage, UndoRectangle);
                    ParentForm.Invalidate();
                    ParentForm.IsSaved = false;
                }
                catch (Exception ex)
                {
                    Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                }
            }
        }

        public virtual void Redo()
        {
            using (var g = Graphics.FromImage(ParentForm.BackgroundImage))
            {
                var img = ParentForm.CropImage(ParentForm.BackgroundImage, UndoRectangle);
                Execute(g);
                UndoImage = img;
                ParentForm.Invalidate();
                ParentForm.IsSaved = false;
            }
        }

        protected CaptureForm ParentForm;

        protected DrawingTool(CaptureForm form, int helpContextId)
        {
            ParentForm = form;
            HelpContextIndex = helpContextId;
        }

        public virtual void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        protected bool HideRectangle { get; set; }

        public virtual void DrawRectangle(Graphics g)
        {
            if (ParentForm.ControlKeyPressed)
            {
                var endPoint = ParentForm.EndPoint;
                ParentForm.StartPoint = new Point(endPoint.X - m_dw, endPoint.Y - m_dh);
            }

            if (!HideRectangle)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(Settings.Default.SelectionOpacity, Settings.Default.SelectionColor)), ParentForm.SelectedRectangle);
            }
        }

        public int SafeZone = 10;

        public virtual void Start()
        {
            ParentForm.KeyDown += ParentFormKeyDown;
            ParentForm.KeyUp += ParentFormKeyUp;
        }

        public virtual void Stop()
        {
            ParentForm.KeyDown -= ParentFormKeyDown;
            ParentForm.KeyUp -= ParentFormKeyUp;
            var x = Math.Max(0, ParentForm.SelectedRectangle.X - SafeZone);
            var y = Math.Max(0, ParentForm.SelectedRectangle.Y - SafeZone);
            var w = Math.Min(ParentForm.Width - x, ParentForm.SelectedRectangle.Width + 2 * SafeZone);
            var h = Math.Min(ParentForm.Height - y, ParentForm.SelectedRectangle.Height + 2 * SafeZone);
            UndoRectangle = new Rectangle(x, y, w, h);
            UndoImage = ParentForm.CropImage(ParentForm.BackgroundImage, UndoRectangle);

            ParentForm.Undo.Push(this);
            ParentForm.IsSaved = false;
        }

        int m_dw, m_dh;
        bool m_ctrlDown;
        void ParentFormKeyDown(object sender, KeyEventArgs e)
        {
            if (m_ctrlDown) return;
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    m_dw = ParentForm.SelectedRectangle.Width;
                    m_dh = ParentForm.SelectedRectangle.Height;
                    m_ctrlDown = true;
                    break;
            }
        }

        void ParentFormKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    m_ctrlDown = false;
                    break;
            }
        }
    }
}
