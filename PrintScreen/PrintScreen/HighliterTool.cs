using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlexScreen
{
    public class HighlighterTool : DrawingTool
    {
        public override string Name
        {
            get { return "Highlighter Pen"; }
        }

        public Pen MarkerPen { get; set; }
        public List<Point> Points { get; set; }

        Timer timer;

        public HighlighterTool(CaptureForm form, Pen pen)
            : base(form, 15)
        {
            //HideRectangle = true;
            Points = new List<Point>();
            MarkerPen = pen;
        }

        public HighlighterTool(CaptureForm form, Color color, int width)
            : this(form, new Pen(color) { Width = width, LineJoin = LineJoin.Round, EndCap = LineCap.Round, StartCap = LineCap.Round })
        { }

        public override void Start()
        {
            var current = ParentForm.PointToClient(Cursor.Position);
            Points.Clear();
            Points.Add(current);

            timer = new Timer { Interval = 5, };
            timer.Tick += TimerTick;
            timer.Start();
        }

        public override void Stop()
        {
            timer.Stop();
            timer.Tick -= TimerTick;

            var delta = (int)MarkerPen.Width / 2 + 1;
            var startPoint = ParentForm.StartPoint; 
            ParentForm.StartPoint = new Point(startPoint.X - delta, startPoint.Y - delta);
            ParentForm.EndPoint = new Point(EndPoint.X + delta, EndPoint.Y + delta);

            base.Stop();
        }

        Point? m_endPoint;
        private Point EndPoint
        {
            get
            {
                if (m_endPoint == null)
                {
                    m_endPoint = ParentForm.EndPoint;
                }
                return m_endPoint.Value;
            }
        }

        void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            var current = ParentForm.PointToClient(Cursor.Position);
            var last = Points[Points.Count - 1];

            var dX = Math.Abs(current.X - last.X);
            var dY = Math.Abs(current.Y - last.Y);
            if (dX >= MarkerPen.Width/2 || dY >= MarkerPen.Width/2)
            {
                Points.Add(current);
                var startPoint = ParentForm.StartPoint;
                m_endPoint = new Point(Math.Max(Math.Max(startPoint.X, EndPoint.X), current.X), Math.Max(Math.Max(startPoint.Y, EndPoint.Y), current.Y));
                ParentForm.StartPoint = new Point(Math.Min(Math.Min(startPoint.X, EndPoint.X), current.X), Math.Min(Math.Min(startPoint.Y, EndPoint.Y), current.Y));
            }
            timer.Start();
        }

        public override void DrawRectangle(Graphics g)
        {
            if (!HideRectangle)
            {
                var startPoint = ParentForm.StartPoint;
                g.DrawRectangle(new Pen(Color.FromArgb(127, Color.Pink)), new Rectangle(startPoint.X, startPoint.Y, EndPoint.X - startPoint.X, EndPoint.Y - startPoint.Y));
            }
        }

        public override void Draw(Graphics g)
        {
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            if (Points.Count > 1)
            {
                g.DrawCurve(MarkerPen, Points.ToArray());
            }
        }
    }

}
