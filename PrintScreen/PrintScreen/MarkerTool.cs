using System.Drawing;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public static class CursorImage
    {
        public static Image[][] CursorImages = {
                                   new Image[] {
                                       Resources.Img2_0,
                                       Resources.Img2_1,
                                       Resources.Img2_2,
                                   },

                                   new Image[] {
                                       Resources.HandCursor_22x22,
                                       Resources.ArrowCursor_22x22,
                                       Resources.MoveCursor,
                                       Resources.CrossCursorIcon
                                   },
                                   
                                   new Image[] {
                                       Resources.Help1,
                                       Resources.exclamation2
                                   },
                                   
                                   new Image[] {
                                       Resources.Apply,
                                       Resources.Browse,
                                       Resources.Write,
                                       Resources.Font1,
                                       Resources.Options,
                                       Resources.Options1,
                                   },
                                   
                                   new Image[] {
                                       Resources.Fancy_Pin_Black,
                                       Resources.Fancy_Pin_Blue,
                                       Resources.Fancy_Pin_Brown,
                                       Resources.Fancy_Pin_Cyan,
                                       Resources.Fancy_Pin_Gray,
                                       Resources.Fancy_Pin_Green,
                                       Resources.Fancy_Pin_Lime,
                                       Resources.Fancy_Pin_Orange,
                                       Resources.Fancy_Pin_Pink,
                                       Resources.Fancy_Pin_Purple,
                                       Resources.Fancy_Pin_Red,
                                       Resources.Fancy_Pin_Yellow,
                                   },
                                   
                                   new Image[] {
                                       Resources.Pin_Red,
                                       Resources.Pin_Brown,
                                       Resources.Pin_Down
                                   },
                                   
                                   new Image[] {
                                       Resources.Star_Burst_Blue,
                                       Resources.Star_Burst_Cyan,
                                       Resources.Star_Burst_Green,
                                       Resources.Star_Burst_Orange,
                                       Resources.Star_Burst_Pink,
                                       Resources.Star_Burst_Purple,
                                       Resources.Star_Burst_Red,
                                       Resources.Star_Burst_Yellow,
                                   },
                                   
                                   new Image[] {
                                       Resources.Img_0,
                                       Resources.Img_1,
                                       Resources.Img_2,
                                       Resources.Img_3,
                                       Resources.Img_4,
                                       Resources.Img_5,
                                   },

                                   new Image[] {
                                       Resources.Img1_0,
                                       Resources.Img1_1,
                                       Resources.Img1_2,
                                       Resources.Img1_4,
                                       Resources.Img1_5,
                                       Resources.Img1_5,
                                       Resources.Img1_5,
                                   },

                                   new Image[] {
                                       Resources.flag_blue,
                                       Resources.flag_green,
                                       Resources.flag_orange,
                                       Resources.flag_pink,
                                       Resources.flag_purple,
                                       Resources.flag_red,
                                       Resources.flag_yellow
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
        public override string Name => m_custom ? "Insert Image From File" : "Insert Marker";

        public override string Tip
        {
            get
            {
                var tip = $@"{base.Tip}
- Press [Ctrl] to resize";
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
                m_drawBorder = Settings.Default.PasteImagesWithBorder;
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

        int width => MarkerImage.Width;
        int height => MarkerImage.Height;

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
                g.DrawRectangle(new Pen(Color.FromArgb((int)(Settings.Default.SelectionOpacity), Settings.Default.SelectionColor)), ParentForm.SelectedRectangle);
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
