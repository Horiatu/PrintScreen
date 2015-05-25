using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Diagnostics;
// v1.3
namespace Aero
{
    public partial class AeroForm : Form
    {
        public AeroForm()
        {
            ExtendMargins(0, 70, 0, 0, true, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        
        #region Extend Frame
        #region Constants
        // windowpos
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOREDRAW = 0x0008;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_HIDEWINDOW = 0x0080;
        private const int SWP_NOCOPYBITS = 0x0100;
        private const int SWP_NOOWNERZORDER = 0x0200;
        private const int SWP_NOSENDCHANGING = 0x0400;
        // redraw
        private const int RDW_INVALIDATE = 0x0001;
        private const int RDW_INTERNALPAINT = 0x0002;
        private const int RDW_ERASE = 0x0004;
        private const int RDW_VALIDATE = 0x0008;
        private const int RDW_NOINTERNALPAINT = 0x0010;
        private const int RDW_NOERASE = 0x0020;
        private const int RDW_NOCHILDREN = 0x0040;
        private const int RDW_ALLCHILDREN = 0x0080;
        private const int RDW_UPDATENOW = 0x0100;
        private const int RDW_ERASENOW = 0x0200;
        private const int RDW_FRAME = 0x0400;
        private const int RDW_NOFRAME = 0x0800;
        // frame
        private const int FRAME_WIDTH = 8;
        private const int CAPTION_HEIGHT = 30;
        private const int FRAME_SMWIDTH = 4;
        private const int CAPTION_SMHEIGHT = 24;
        // misc
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_RESTORE = 0xF120;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SM_SWAPBUTTON = 23;
        private const int WM_GETTITLEBARINFOEX = 0x033F;
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        private const int KEY_PRESSED = 0x1000;
        private const int BLACK_BRUSH = 4;
        // proc
        private const int WM_CREATE = 0x0001;
        private const int WM_NCCALCSIZE = 0x83;
        private const int WM_NCHITTEST = 0x84;
        private const int WM_SIZE = 0x5;
        private const int WM_PAINT = 0xF;
        private const int WM_TIMER = 0x113;
        private const int WM_ACTIVATE = 0x6;
        private const int WM_NCMOUSEMOVE = 0xA0;
        private const int WM_NCMOUSEHOVER = 0x02A0;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCLBUTTONUP = 0xA2;
        private const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_NCRBUTTONDOWN = 0xA4;
        private const int WM_NCRBUTTONUP = 0xA5;
        private const int WM_NCRBUTTONDBLCLK = 0xA6;
        private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
        private const int WVR_ALIGNTOP = 0x0010;
        private const int WVR_ALIGNLEFT = 0x0020;
        private const int WVR_ALIGNBOTTOM = 0x0040;
        private const int WVR_ALIGNRIGHT = 0x0080;
        private const int WVR_HREDRAW = 0x0100;
        private const int WVR_VREDRAW = 0x0200;
        private const int WVR_REDRAW = (WVR_HREDRAW | WVR_VREDRAW);
        private const int WVR_VALIDRECTS = 0x400;
        private static IntPtr MSG_HANDLED = new IntPtr(0);
        #endregion

        #region Enums
        private enum HIT_CONSTANTS : int
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }

        private enum PART_TYPE : int
        {
            WP_MINBUTTON = 15,
            WP_MAXBUTTON = 17,
            WP_CLOSEBUTTON = 18,
            WP_RESTOREBUTTON = 21
        }
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            internal int X;
            internal int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx;
            public int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            internal IntPtr hdc;
            internal int fErase;
            internal RECT rcPaint;
            internal int fRestore;
            internal int fIncUpdate;
            internal int Reserved1;
            internal int Reserved2;
            internal int Reserved3;
            internal int Reserved4;
            internal int Reserved5;
            internal int Reserved6;
            internal int Reserved7;
            internal int Reserved8;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
            public MARGINS(int Left, int Right, int Top, int Bottom)
            {
                this.cxLeftWidth = Left;
                this.cxRightWidth = Right;
                this.cyTopHeight = Top;
                this.cyBottomHeight = Bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct NCCALCSIZE_PARAMS
        {
            internal RECT rect0, rect1, rect2;
            internal IntPtr lppos;
        }
        #endregion

        #region API
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);

        [DllImport("dwmapi.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DwmDefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref IntPtr result);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(int crColor);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

        [DllImport("gdi32.dll")]
        private static extern IntPtr GetStockObject(int fnObject);

        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool InflateRect(ref RECT lprc, int dx, int dy);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OffsetRect(ref RECT lprc, int dx, int dy);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
        #endregion

        #region Fields
        private bool _bPaintWindow = false;
        private bool _bDrawCaption = false;
        private bool _bIsCompatible = false;
        private bool _bIsAero = false;
        private bool _bPainting = false;
        private bool _bExtendIntoFrame = false;
        private int _iCaptionHeight = CAPTION_HEIGHT;
        private int _iFrameHeight = FRAME_WIDTH;
        private int _iFrameWidth = FRAME_WIDTH;
        private int _iFrameOffset = 100;
        private int _iStoreHeight = 0;
        private RECT _tClientRect = new RECT();
        private MARGINS _tMargins = new MARGINS();
        private RECT[] _tButtonSize = new RECT[3];
        #endregion

        #region Properties
        private int CaptionHeight
        {
            get { return _iCaptionHeight; }
        }

        private int FrameWidth
        {
            get { return _iFrameWidth; }
        }

        private int FrameHeight
        {
            get { return _iFrameHeight; }
        }
        #endregion

        #region Methods
        private void ExtendMargins(int left, int top, int right, int bottom, bool drawcaption, bool intoframe)
        {
            // any negative value causes whole window client to extend
            if (left < 0 || top < 0 || right < 0 || bottom < 0)
            {
                _bPaintWindow = true;
                _tMargins.cyTopHeight = -1;
            }
            // only caption can be extended
            else if (intoframe)
            {
                _tMargins.cxLeftWidth = 0;
                _tMargins.cyTopHeight = top;
                _tMargins.cxRightWidth = 0;
                _tMargins.cyBottomHeight = 0;
            }
            // normal extender
            else
            {
                _tMargins.cxLeftWidth = left;
                _tMargins.cyTopHeight = top;
                _tMargins.cxRightWidth = right;
                _tMargins.cyBottomHeight = bottom;
            }
            _bExtendIntoFrame = intoframe;
            _bDrawCaption = drawcaption;
            _bIsCompatible = IsCompatableOS();
            _bIsAero = IsAero();
        }

        private void GetFrameSize()
        {
            if (this.MinimizeBox)
                _iFrameOffset = 100;
            else
                _iFrameOffset = 40;
            switch (this.FormBorderStyle)
            {
                case FormBorderStyle.Sizable:
                    {
                        _iCaptionHeight = CAPTION_HEIGHT;
                        _iFrameHeight = FRAME_WIDTH;
                        _iFrameWidth = FRAME_WIDTH;
                        break;
                    }
                case FormBorderStyle.Fixed3D:
                    {
                        _iCaptionHeight = 27;
                        _iFrameHeight = 4;
                        _iFrameWidth = 4;
                        break;
                    }
                case FormBorderStyle.FixedDialog:
                    {
                        _iCaptionHeight = 25;
                        _iFrameHeight = 2;
                        _iFrameWidth = 2;
                        break;
                    }
                case FormBorderStyle.FixedSingle:
                    {
                        _iCaptionHeight = 25;
                        _iFrameHeight = 2;
                        _iFrameWidth = 2;
                        break;
                    }
                case FormBorderStyle.FixedToolWindow:
                    {
                        _iFrameOffset = 20;
                        _iCaptionHeight = 21;
                        _iFrameHeight = 2;
                        _iFrameWidth = 2;
                        break;
                    }
                case FormBorderStyle.SizableToolWindow:
                    {
                        _iFrameOffset = 20;
                        _iCaptionHeight = 26;
                        _iFrameHeight = 4;
                        _iFrameWidth = 4;
                        break;
                    }
                default:
                    {
                        _iCaptionHeight = CAPTION_HEIGHT;
                        _iFrameHeight = FRAME_WIDTH;
                        _iFrameWidth = FRAME_WIDTH;
                        break;
                    }
            }
        }

        private HIT_CONSTANTS HitTest()
        {
            RECT windowRect = new RECT();
            Point cursorPoint = new Point();
            RECT posRect;
            GetCursorPos(ref cursorPoint);
            GetWindowRect(this.Handle, ref windowRect);
            cursorPoint.X -= windowRect.Left;
            cursorPoint.Y -= windowRect.Top;
            int width = windowRect.Right - windowRect.Left;
            int height = windowRect.Bottom - windowRect.Top;

            posRect = new RECT(0, 0, FrameWidth, FrameHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTTOPLEFT;

            posRect = new RECT(width - FrameWidth, 0, width, FrameHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTTOPRIGHT;

            posRect = new RECT(FrameWidth, 0, width - (FrameWidth * 2) - _iFrameOffset, FrameHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTTOP;

            posRect = new RECT(FrameWidth, FrameHeight, width - ((FrameWidth * 2) + _iFrameOffset), _tMargins.cyTopHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTCAPTION;

            posRect = new RECT(0, FrameHeight, FrameWidth, height - FrameHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTLEFT;

            posRect = new RECT(0, height - FrameHeight, FrameWidth, height);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTBOTTOMLEFT;

            posRect = new RECT(FrameWidth, height - FrameHeight, width - FrameWidth, height);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTBOTTOM;

            posRect = new RECT(width - FrameWidth, height - FrameHeight, width, height);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTBOTTOMRIGHT;

            posRect = new RECT(width - FrameWidth, FrameHeight, width, height - FrameHeight);
            if (PtInRect(ref posRect, cursorPoint))
                return HIT_CONSTANTS.HTRIGHT;

            return HIT_CONSTANTS.HTCLIENT;
        }

        public bool IsAero()
        {
            int enabled = 0;
            DwmIsCompositionEnabled(ref enabled);
            return (enabled == 1);
        }

        public bool IsCompatableOS()
        {
            return (Environment.OSVersion.Version.Major >= 6);
        }

        private void FrameChanged()
        {
            RECT rcClient = new RECT();
            GetWindowRect(this.Handle, ref rcClient);
            // force a calc size message
            SetWindowPos(this.Handle,
                         IntPtr.Zero,
                         rcClient.Left, rcClient.Top,
                         rcClient.Right - rcClient.Left, rcClient.Bottom - rcClient.Top,
                         SWP_FRAMECHANGED);
        }

        private void InvalidateWindow()
        {
            RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_UPDATENOW | RDW_INVALIDATE | RDW_ERASE);
        }

        private void PaintThis(IntPtr hdc, RECT rc)
        {
            RECT clientRect = new RECT();
            GetClientRect(this.Handle, ref clientRect);
            if (_bExtendIntoFrame)
            {
                clientRect.Left = _tClientRect.Left - _tMargins.cxLeftWidth;
                clientRect.Top = _tMargins.cyTopHeight;
                clientRect.Right -= _tMargins.cxRightWidth;
                clientRect.Bottom -= _tMargins.cyBottomHeight;
            }
            else if (!_bPaintWindow)
            {
                clientRect.Left = _tMargins.cxLeftWidth;
                clientRect.Top = _tMargins.cyTopHeight;
                clientRect.Right -= _tMargins.cxRightWidth;
                clientRect.Bottom -= _tMargins.cyBottomHeight;
            }
            if (!_bPaintWindow)
            {
                int clr;
                IntPtr hb;
                using (ClippingRegion cp = new ClippingRegion(hdc, clientRect, rc))
                {
                    if (IsAero())
                    {
                        FillRect(hdc, ref rc, GetStockObject(BLACK_BRUSH));
                    }
                    else
                    {
                        clr = ColorTranslator.ToWin32(Color.FromArgb(0xC2, 0xD9, 0xF7));
                        hb = CreateSolidBrush(clr);
                        FillRect(hdc, ref clientRect, hb);
                        DeleteObject(hb);
                    }
                }
                clr = ColorTranslator.ToWin32(this.BackColor);
                hb = CreateSolidBrush(clr);
                FillRect(hdc, ref clientRect, hb);
                DeleteObject(hb);
            }
            else
            {
                FillRect(hdc, ref rc, GetStockObject(BLACK_BRUSH));
            }
            if (_bExtendIntoFrame && _bDrawCaption)
            {
                Rectangle captionBounds = new Rectangle(4, 4, rc.Right, CaptionHeight);
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    using (Font fc = new Font("Segoe UI", 12, FontStyle.Regular))
                    {
                        SizeF sz = g.MeasureString(this.Text, fc);
                        int offset = (rc.Right - (int)sz.Width) / 2;
                        if (offset < 2 * FrameWidth)
                            offset = 2 * FrameWidth;
                        captionBounds.X = offset;
                        captionBounds.Y = 4;
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                            sf.FormatFlags = StringFormatFlags.NoWrap;
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Near;
                            using (GraphicsPath path = new GraphicsPath())
                            {
                                g.SmoothingMode = SmoothingMode.HighQuality;
                                path.AddString(this.Text, fc.FontFamily, (int)fc.Style, fc.Size, captionBounds, sf);
                                g.FillPath(Brushes.Black, path);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            if (_bIsCompatible)
                CustomProc(ref m);
            else
                base.WndProc(ref m);
        }

        protected void CustomProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    {
                        PAINTSTRUCT ps = new PAINTSTRUCT();
                        if (!_bPainting)
                        {
                            _bPainting = true;
                            BeginPaint(m.HWnd, ref ps);
                            PaintThis(ps.hdc, ps.rcPaint);
                            EndPaint(m.HWnd, ref ps);
                            _bPainting = false;
                            base.WndProc(ref m);
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        break;
                    }
                case WM_CREATE:
                    {
                        GetFrameSize();
                        FrameChanged();
                        m.Result = MSG_HANDLED;
                        base.WndProc(ref m);
                        break;
                    }
                case WM_NCCALCSIZE:
                    {
                        if (m.WParam != IntPtr.Zero && m.Result == IntPtr.Zero)
                        {
                            if (_bExtendIntoFrame)
                            {
                                NCCALCSIZE_PARAMS nc = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                                nc.rect0.Top -= (_tMargins.cyTopHeight > CaptionHeight ? CaptionHeight : _tMargins.cyTopHeight);
                                nc.rect1 = nc.rect0;
                                Marshal.StructureToPtr(nc, m.LParam, false);
                                m.Result = (IntPtr)WVR_VALIDRECTS;
                            }
                            base.WndProc(ref m);
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        break;
                    }
                case WM_SYSCOMMAND:
                    {
                        UInt32 param;
                        if (IntPtr.Size == 4)
                            param = (UInt32)(m.WParam.ToInt32());
                        else
                            param = (UInt32)(m.WParam.ToInt64());
                        if ((param & 0xFFF0) == SC_RESTORE)
                        {
                            this.Height = _iStoreHeight;
                        }
                        else if (this.WindowState == FormWindowState.Normal)
                        {
                            _iStoreHeight = this.Height;
                        }
                        base.WndProc(ref m);
                        break;
                    }
                case WM_NCHITTEST:
                    {
                        if (m.Result == (IntPtr)HIT_CONSTANTS.HTNOWHERE)
                        {
                            IntPtr res = IntPtr.Zero;
                            if (DwmDefWindowProc(m.HWnd, (uint)m.Msg, m.WParam, m.LParam, ref res))
                                m.Result = res;
                            else
                                m.Result = (IntPtr)HitTest();
                        }
                        else
                            base.WndProc(ref m);
                        break;
                    }
                case WM_DWMCOMPOSITIONCHANGED:
                case WM_ACTIVATE:
                    {
                        DwmExtendFrameIntoClientArea(this.Handle, ref _tMargins);
                        m.Result = MSG_HANDLED;
                        base.WndProc(ref m);
                        break;
                    }
                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
        }
        #endregion

        #region Clipping Region
        /// <summary>Clip rectangles or rounded rectangles</summary>
        internal class ClippingRegion : IDisposable
        {
            #region Enum
            private enum CombineRgnStyles : int
            {
                RGN_AND = 1,
                RGN_OR = 2,
                RGN_XOR = 3,
                RGN_DIFF = 4,
                RGN_COPY = 5,
                RGN_MIN = RGN_AND,
                RGN_MAX = RGN_COPY
            }
            #endregion

            #region API
            [DllImport("gdi32.dll")]
            private static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

            [DllImport("gdi32.dll")]
            private static extern int GetClipRgn(IntPtr hdc, [In, Out]IntPtr hrgn);

            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

            [DllImport("gdi32.dll")]
            private static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, CombineRgnStyles fnCombineMode);

            [DllImport("gdi32.dll")]
            private static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteObject(IntPtr hObject);
            #endregion

            #region Fields
            private IntPtr _hClipRegion;
            private IntPtr _hDc;
            #endregion

            #region Methods
            public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
            {
                CreateRectangleClip(hdc, cliprect, canvasrect);
            }

            public ClippingRegion(IntPtr hdc, RECT cliprect, RECT canvasrect)
            {
                CreateRectangleClip(hdc, cliprect, canvasrect);
            }

            public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
            {
                CreateRoundedRectangleClip(hdc, cliprect, canvasrect, radius);
            }

            public ClippingRegion(IntPtr hdc, RECT cliprect, RECT canvasrect, uint radius)
            {
                CreateRoundedRectangleClip(hdc, cliprect, canvasrect, radius);
            }

            public void CreateRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
            {
                _hDc = hdc;
                IntPtr clip = CreateRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            public void CreateRectangleClip(IntPtr hdc, RECT cliprect, RECT canvasrect)
            {
                _hDc = hdc;
                IntPtr clip = CreateRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            public void CreateRoundedRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
            {
                int r = (int)radius;
                _hDc = hdc;
                // create rounded regions
                IntPtr clip = CreateRoundRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom, r, r);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRoundRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom, r, r);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                // add it in
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            public void CreateRoundedRectangleClip(IntPtr hdc, RECT cliprect, RECT canvasrect, uint radius)
            {
                int r = (int)radius;
                _hDc = hdc;
                // create rounded regions
                IntPtr clip = CreateRoundRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom, r, r);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRoundRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom, r, r);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                // add it in
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            public void Release()
            {
                if (_hClipRegion != IntPtr.Zero)
                {
                    // remove region
                    SelectClipRgn(_hDc, IntPtr.Zero);
                    // delete region
                    DeleteObject(_hClipRegion);
                }
            }

            public void Dispose()
            {
                Release();
            }
            #endregion
        }
        #endregion
        #endregion
    }
}
