using System.Drawing;
using System.Windows.Forms;

namespace FlexScreen
{
    public static class CursorImage
    {
        public static Image[][] CursorImages = {
                                   new Image[] {
                                       Properties.Resources.Img2_0,
                                       Properties.Resources.Img2_1,
                                       Properties.Resources.Img2_2,
                                   },

                                   new Image[] {
                                       Properties.Resources.HandCursor_22x22,
                                       Properties.Resources.ArrowCursor_22x22,
                                       Properties.Resources.MoveCursor,
                                       Properties.Resources.CrossCursorIcon
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Help1,
                                       Properties.Resources.exclamation2
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Apply,
                                       Properties.Resources.Browse,
                                       Properties.Resources.Write,
                                       Properties.Resources.Font1,
                                       Properties.Resources.Options,
                                       Properties.Resources.Options1,
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Fancy_Pin_Black,
                                       Properties.Resources.Fancy_Pin_Blue,
                                       Properties.Resources.Fancy_Pin_Brown,
                                       Properties.Resources.Fancy_Pin_Cyan,
                                       Properties.Resources.Fancy_Pin_Gray,
                                       Properties.Resources.Fancy_Pin_Green,
                                       Properties.Resources.Fancy_Pin_Lime,
                                       Properties.Resources.Fancy_Pin_Orange,
                                       Properties.Resources.Fancy_Pin_Pink,
                                       Properties.Resources.Fancy_Pin_Purple,
                                       Properties.Resources.Fancy_Pin_Red,
                                       Properties.Resources.Fancy_Pin_Yellow,
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Pin_Red,
                                       Properties.Resources.Pin_Brown,
                                       Properties.Resources.Pin_Down
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Star_Burst_Blue,
                                       Properties.Resources.Star_Burst_Cyan,
                                       Properties.Resources.Star_Burst_Green,
                                       Properties.Resources.Star_Burst_Orange,
                                       Properties.Resources.Star_Burst_Pink,
                                       Properties.Resources.Star_Burst_Purple,
                                       Properties.Resources.Star_Burst_Red,
                                       Properties.Resources.Star_Burst_Yellow,
                                   },
                                   
                                   new Image[] {
                                       Properties.Resources.Img_0,
                                       Properties.Resources.Img_1,
                                       Properties.Resources.Img_2,
                                       Properties.Resources.Img_3,
                                       Properties.Resources.Img_4,
                                       Properties.Resources.Img_5,
                                   },

                                   new Image[] {
                                       Properties.Resources.Img1_0,
                                       Properties.Resources.Img1_1,
                                       Properties.Resources.Img1_2,
                                       Properties.Resources.Img1_4,
                                       Properties.Resources.Img1_5,
                                       Properties.Resources.Img1_5,
                                       Properties.Resources.Img1_5,
                                   },

                                   new Image[] {
                                       Properties.Resources.flag_blue,
                                       Properties.Resources.flag_green,
                                       Properties.Resources.flag_orange,
                                       Properties.Resources.flag_pink,
                                       Properties.Resources.flag_purple,
                                       Properties.Resources.flag_red,
                                       Properties.Resources.flag_yellow
                                   },
                                   
                                   new Image[] {
                                       CustomCursors.CursorImage(50),
                                       CustomCursors.CursorImage(100),
                                       CustomCursors.CursorImage(150)
                                   }
                               };

        public static Image CurrentImage(int x, int y)
        {
            var images = CursorImages[y = y % CursorImages.Length];
            return images[x % images.Length];
        }

        public static Image PrevImageShape(ref int x, ref int y)
        {
            var images = CursorImages[y = (CursorImages.Length + y - 1) % CursorImages.Length];
            return images[x = 0];
        }

        public static Image NextImageShape(ref int x, ref int y)
        {
            var images = CursorImages[y = ++y % CursorImages.Length];
            return images[x = 0];
        }

        public static Image PrevImageColor(ref int x, ref int y)
        {
            var images = CursorImages[y = y % CursorImages.Length];
            return images[x = (images.Length + x - 1) % images.Length];
        }

        public static Image NextImageColor(ref int x, ref int y)
        {
            var images = CursorImages[y = y % CursorImages.Length];
            return images[x = ++x % images.Length];
        }
    }

    public class MarkerTool : DrawingTool
    {
        public override string Name
        {
            get { return m_custom ? "Insert Image From File" : "Insert Marker"; }
        }

        public override string Tip
        {
            get
            {
                var tip = base.Tip +
@"- Press [Ctrl] to resize";
                if (m_custom)
                {
                    tip += @"
- Press [Space] to flip border";
                }
                else
                {
                    tip += @"
- Press arrow keys to change shape";
                }
                tip += @"
- Press [q,w,a,s] to make the corner color transparent";
                return tip;
            }
        }

        public Image MarkerImage { get; set; }
        public Point MarkerPoint { get; set; }
        public Image OriginalMarkerImage { get; set; }

        readonly bool m_custom;
        bool m_drawBorder;

        public MarkerTool(CaptureForm form, Image image = null)
            : this(form, image, false)
        {
        }

        public MarkerTool(CaptureForm form, Image image, bool custom)
            : base(form, 16)
        {
            m_custom = custom;
            if (custom)
            {
                m_drawBorder = Program.MySettings.PasteImagesWithBorder;
            }
            MarkerImage = OriginalMarkerImage = image ?? CursorImage.CurrentImage(ParentForm.CursorImagePointerX, ParentForm.CursorImagePointerY);
        }

        public override void Start()
        {
            base.Start();
            ParentForm.KeyDown += parentForm_KeyDown;
            ParentForm.KeyUp += parentForm_KeyUp;
        }

        public override void Stop()
        {
            ParentForm.KeyDown -= parentForm_KeyDown;
            ParentForm.KeyUp -= parentForm_KeyUp;
            base.Stop();
        }

        void parentForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    m_drawBorder = !m_drawBorder;
                    ParentForm.Invalidate();
                    e.Handled = true;
                    break;
            }
        }

        void parentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!m_custom)
            {
#pragma warning disable 197
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        OriginalMarkerImage = MarkerImage = CursorImage.PrevImageShape(ref ParentForm.CursorImagePointerX, ref ParentForm.CursorImagePointerY);
                        ParentForm.Invalidate();
                        return;
                    case Keys.Down:
                        OriginalMarkerImage = MarkerImage = CursorImage.NextImageShape(ref ParentForm.CursorImagePointerX, ref ParentForm.CursorImagePointerY);
                        ParentForm.Invalidate();
                        return;
                    case Keys.Left:
                        OriginalMarkerImage = MarkerImage = CursorImage.PrevImageColor(ref ParentForm.CursorImagePointerX, ref ParentForm.CursorImagePointerY);
                        ParentForm.Invalidate();
                        return;
                    case Keys.Right:
                        OriginalMarkerImage = MarkerImage = CursorImage.NextImageColor(ref ParentForm.CursorImagePointerX, ref ParentForm.CursorImagePointerY);
                        ParentForm.Invalidate();
                        return;
                }
#pragma warning restore 197
            }
            Color color0;
            switch (e.KeyCode)
            {
                case Keys.Q:
                    color0 = ((Bitmap)MarkerImage).GetPixel(0, 0);
                    {
                        ((Bitmap)MarkerImage).MakeTransparent(color0);
                    }
                    ParentForm.Invalidate();
                    return;
                case Keys.W:
                    color0 = ((Bitmap)MarkerImage).GetPixel(MarkerImage.Width - 1, 0);
                    {
                        ((Bitmap)MarkerImage).MakeTransparent(color0);
                    }
                    ParentForm.Invalidate();
                    return;
                case Keys.A:
                    color0 = ((Bitmap)MarkerImage).GetPixel(0, MarkerImage.Height - 1);
                    {
                        ((Bitmap)MarkerImage).MakeTransparent(color0);
                    }
                    ParentForm.Invalidate();
                    return;
                case Keys.S:
                    color0 = ((Bitmap)MarkerImage).GetPixel(MarkerImage.Width - 1, MarkerImage.Height - 1);
                    {
                        ((Bitmap)MarkerImage).MakeTransparent(color0);
                    }
                    ParentForm.Invalidate();
                    return;
            }
        }

        int width { get { return MarkerImage.Width; } }
        int height { get { return MarkerImage.Height; } }
        Point startPoint
        {
            get { return ParentForm.StartPoint; }
            set { ParentForm.StartPoint = value; }
        }
        Point endPoint
        {
            get { return ParentForm.EndPoint; }
            set { ParentForm.EndPoint = value; }
        }


        public override void DrawRectangle(Graphics g)
        {
            var current = ParentForm.CrossPoint; //  PointToClient(Cursor.Position);

            if (ParentForm.ControlKeyPressed)
            {
                var p = new Point(current.X + width / 2, current.Y + height / 2);
                if (p.X - startPoint.X > 5 && p.Y - startPoint.Y > 5)
                {
                    endPoint = p;
                    MarkerImage = new Bitmap(OriginalMarkerImage, ParentForm.SelectedRectangle.Size);
                }
            }
            else
            {
                startPoint = new Point(current.X - width / 2, current.Y - height / 2);
                endPoint = new Point(startPoint.X + width, startPoint.Y + height);
            }

            if (!HideRectangle)
            {
                g.DrawRectangle(new Pen(Color.FromArgb((int)(Program.MySettings.SelectionOpacity), Program.MySettings.SelectionColor)), ParentForm.SelectedRectangle);
            }
        }

        public override void Draw(Graphics g)
        {
            var startPoint = ParentForm.StartPoint;
            MarkerPoint = new Point(startPoint.X + 1, startPoint.Y + 1);
            Execute(g);
        }

        public override void Execute(Graphics g)
        {
            base.Execute(g);
            g.DrawImage(MarkerImage, MarkerPoint);
            if (m_custom && m_drawBorder)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(80, Color.Black)) { Width = 2 }, ParentForm.SelectedRectangle);
            }
        }
    }
}
