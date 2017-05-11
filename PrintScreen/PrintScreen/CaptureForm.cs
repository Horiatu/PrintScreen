using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public delegate void TemporaryPaintHandler(object sender, Graphics g);

    public sealed partial class CaptureForm : Form
    {
        private Point m_startPoint;
        public Point StartPoint
        {
            get { return m_startPoint; }
            set 
            { 
                m_startPoint = value;
                GetSelectedRectangle();
            }
        }

        private Point m_endPoint;
        public Point EndPoint
        {
            get { return m_endPoint; }
            set
            {
                m_endPoint = value;
                GetSelectedRectangle();
            }
        }

        internal Point CrossPoint;

        Rectangle m_selectedRectangle;
        public Rectangle SelectedRectangle
        {
            get
            {
                GetSelectedRectangle();

                return m_selectedRectangle;
            }
        }

        private void GetSelectedRectangle()
        {
            m_selectedRectangle.X = Math.Min(m_startPoint.X, m_endPoint.X);
            m_selectedRectangle.Y = Math.Min(m_startPoint.Y, m_endPoint.Y);
            m_selectedRectangle.Width = Math.Abs(m_endPoint.X - m_startPoint.X);
            m_selectedRectangle.Height = Math.Abs(m_endPoint.Y - m_startPoint.Y);
        }

        #region Caption
        string m_fileName;
        public string FileName
        {
            get { return m_fileName; }
            set
            {
                if (m_fileName == value) return;
                m_fileName = value;
                SetCaption();
                if (value == null) return;
                Settings.Default.DefaultDirectory = Path.GetFullPath(value);
            }
        }

        bool m_isSaved;
        public bool IsSaved
        {
            get { return m_isSaved; }
            set
            {
                if (m_isSaved == value) return;
                m_isSaved = value;
                SetCaption();
            }
        }

        public void SetCaption(string fileName, bool isSaved)
        {
            FileName = fileName;
            IsSaved = isSaved;
        }

        public void SetCaption()
        {
            saveToolStripMenuItem2.Enabled = !IsSaved;
            Icon = IsSaved ? Resources.Crop_Icon : Resources.Crop_Icon_NotSaved;
            Text = (IsSaved ? "" : Resources.ToSave) + Path.GetFileName(FileName ?? Resources.NotSavedFileName);
        }
        #endregion

        public readonly DateTime CreationTime = DateTime.Now;

        public Image CropImage(Image img, Rectangle cropArea)
        {
            return CropImage(img, cropArea, null);
        }

        public Image CropImage(Image img, Rectangle cropArea, Color? transparentColor)
        {
            try
            {
                var bmpImage = new Bitmap(img);
                try
                {
                    if (cropArea.X < 0)
                    {
                        cropArea.Width += cropArea.X;
                        cropArea.X = 0;
                    }
                    if (cropArea.Y < 0)
                    {
                        cropArea.Height += cropArea.Y;
                        cropArea.Y = 0;
                    }
                    cropArea.Width = Math.Min(cropArea.Width, BackgroundImage.Width - cropArea.X);
                    cropArea.Height = Math.Min(cropArea.Height, BackgroundImage.Height - cropArea.Y);
                    var bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                    if (transparentColor.HasValue)
                    {
                        bmpCrop.MakeTransparent(transparentColor.Value);
                    }
                    return bmpCrop;
                }
                finally
                {
                    bmpImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                return null;
            }
        }

        public static bool Capturing;
        public bool IsCroped { get; set; }

        CaptureStep m_mode;
        internal Undo Undo = new Undo();

        public CaptureForm()
        {
            m_zoomFactor = 1;
            InitializeComponent();
            Cursor = CustomCursors.None();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Icon = Resources.Crop_Icon_NotSaved;
            BringToFront();
            SetState(CaptureStep.Begin);
            TopMost = true;
            menuStrip1.Height = 3;
            menuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected || (e.Item).DisplayStyle == ToolStripItemDisplayStyle.Image)
                {
                    base.OnRenderMenuItemBackground(e);
                    return;
                }
                var rc = new Rectangle(Point.Empty, e.Item.Size);
                var customColors = e.Item.BackColor != Color.Transparent;

                var c0 = customColors ? e.Item.BackColor : Color.AliceBlue;
                var c1 = customColors ? Color.FromArgb(c0.A / 4, c0.R, c0.G, c0.B) : Color.Transparent;
                var c2 = customColors ? Color.FromArgb(255, c0.R, c0.G, c0.B) : Color.DarkGray;
                var bl = new Blend
                {
                    Factors = new[] { 0.1f, 0.2f, 0.25f, !customColors ? 0.25f : 1.0f, !customColors ? 0.6f : 0f },
                    Positions = new[] { 0, !customColors ? 0.64f : 0.4f, !customColors ? 0.68f : 0.5f, 0.75f, 1.0f }
                };
                var brush = new LinearGradientBrush(rc, c1, c2, 90, false) { Blend = bl };
                e.Graphics.FillRectangle(brush, rc);
                //e.Graphics.DrawRectangle(new Pen(c2, 2), 1, 1, rc.Width - 1, rc.Height - 2);
            }

            //protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            //{
            //}
        }

        public CaptureForm(Image image) : this()
        {
            SetBounds(0, 0, image.Width, image.Height);
            BackgroundImage = image;
            MouseDown += FormMouseDown;
            MouseUp += FormMouseUp;
            MouseMove += FormMouseMove;
            MouseEnter += (sender, e) => Opacity = 1.0;
            MouseLeave += (sender, e) => MakeTransparent();

            ActiveTool = new DefaultTool(this);

            IsSaved = true;
            SetCaption(null, false);
        }

        DrawingTool m_activeTool;

        public DrawingTool ActiveTool
        {
            get { return m_activeTool; }
            set
            {
                if (m_activeTool == value) return;

                m_activeTool = value;
                if (ActiveTool is DefaultTool) return;

                if (Settings.Default.NoToolTips || string.IsNullOrEmpty(ActiveTool.Name)) return;

                var tip = $@"{ActiveTool.Tip ?? ""}
Press [F1] for more help.".Trim();
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(tip.Length * 100, ActiveTool.Name, tip, ToolTipIcon.None);
            }
        }

        TextDialog m_textDialog;
        TextDialog TextDialog => m_textDialog ?? (m_textDialog = new TextDialog());

        double TransparencyToOpacity(int transparency) => (100 - transparency) / 100.0;

        #region key events
        public bool AltKeyPressed;
        public bool ControlKeyPressed;
        public bool ShiftKeyPressed;
        public bool EscKeyPressed;

        private void CaptureForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(EscKeyPressed = e.KeyCode == Keys.Escape))
            {
                e.Handled = m_mouseDown;
                if (m_mouseDown)
                {
                    AltKeyPressed = e.Alt;
                    ControlKeyPressed = e.Control;
                    ShiftKeyPressed = e.Shift;
                    Invalidate();
                }
            }
        }

        private void CaptureForm_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = m_mouseDown;
            if (m_mouseDown)
            {
                AltKeyPressed = e.Alt;
                ControlKeyPressed = e.Control;
                ShiftKeyPressed = e.Shift;
                Invalidate();
            }

            if (e.KeyCode == Keys.Escape)
            {
                EscKeyPressed = false;
                if (!IsCroped)
                {
                    Capturing = false;
                    Close();
                }
            }
            else if (e.KeyCode == Keys.Enter && !IsCroped)
            {
                CropToolStripMenuItemClick(this, new EventArgs());
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region mouse events
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized)
            {
                Focus();
                menuStrip1.Focus();
                menuStrip1.Cursor = Cursors.SizeAll;
                Opacity = TransparencyToOpacity(Settings.Default.FormTransparencyFactor);
                Utils.ReleaseCapture();
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, Utils.HT_CAPTION, 0);
            }
        }

        Point m_lastMenuClicked = new Point(0, 0);
        Point m_rightClickedPos = new Point(0, 0);
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_lastMenuClicked = Cursor.Position;
            RestoreInFormCursorPossition();
        }

        ToolStripMenuItem m_lastMenuItemOpened;
        private void FilesToolStripMenuItemDropDownOpened(object sender, EventArgs e)
        {
            m_lastMenuItemOpened = sender as ToolStripMenuItem;
            if (m_lastMenuClicked.X == 0 && m_lastMenuClicked.Y == 0)
            {
                ToolStripMenuItem_Click(sender, e);
            }
        }


        bool m_mouseDown;

        void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_startPoint = new Point(e.X, e.Y);
                m_endPoint = new Point(e.X, e.Y);

                m_mouseDown = true;

                SetState(CaptureStep.Start);
            }
        }

        void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_mouseDown = false;
                Capturing = false;
                var defaultTool = ActiveTool is DefaultTool;
                SetState(CaptureStep.End);
                if (!IsCroped && Settings.Default.AutomaticallyCrop && defaultTool &&
                    m_startPoint.X != m_endPoint.X &&
                    m_startPoint.Y != m_endPoint.Y)
                {
                    CropToolStripMenuItemClick(this, new EventArgs());
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Utils.ReleaseCapture();
                MenuStrip1MouseEnter(sender, e);
                if (m_lastMenuItemOpened != null)
                {
                    m_rightClickedPos = Cursor.Position;
                    m_lastMenuItemOpened.ShowDropDown();
                    if (m_lastMenuClicked.X > 0 && m_lastMenuClicked.Y > 0)
                    {
                        Cursor.Position = m_lastMenuClicked;
                    }
                }
            }
        }

        void FormMouseMove(object sender, MouseEventArgs e)
        {
            CrossPoint.X = e.X;
            CrossPoint.Y = e.Y;
            if (m_mouseDown)
            {
                m_endPoint.X = e.X;
                m_endPoint.Y = e.Y;
            }
            Invalidate(ClientRectangle);
        }
        #endregion

        bool m_showStartUpHelp;
        public bool ShowStartUpHelp
        {
            get { return m_showStartUpHelp; }
            set
            {
                if (m_showStartUpHelp == value) return;
                m_showStartUpHelp = value;
                Invalidate();
                if (value)
                {
                    (new Timer { Interval = 10000, Enabled = true }).Tick += (s, e) => { ShowStartUpHelp = false; ((Timer)s).Enabled = false; };
                }
            }
        }

        public event TemporaryPaintHandler TemporaryPaint;

        void OnTemporaryPaint(Graphics g)
        {
            TemporaryPaint?.Invoke(this, g);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var borderColor = (m_mouseDown) ? Color.DeepPink : Color.FromArgb(100, Color.Black);
            var frame = new Rectangle(1, 1, Width - 3, Height - 3);
            e.Graphics.DrawRectangle(new Pen(borderColor) { Width = 3 }, frame);

            if (m_mode == CaptureStep.Start || (ActiveTool is DefaultTool && m_mode == CaptureStep.End))
            {
                ActiveTool.DrawRectangle(e.Graphics);
            }
            if (m_mode == CaptureStep.Start)
            {
                ActiveTool.Draw(e.Graphics);
            }

            if (m_multiCrop != null && m_multiCrop.Visible && m_multiCrop.ImgWidth > 0 && m_multiCrop.ImgHeight > 0)
            {
                IterateMultiZone(e,
                    (s, r) => m_multiCrop.StartSaving(),
                    (s, r) =>
                    {
                        m_multiCrop.Marker(this, r);
                        if (m_multiCrop.IsSaving)
                        {
                            m_multiCrop.SaveZone(this, r);
                        }
                    },
                    (s, r) => m_multiCrop.CloseArchive()
                );
            }

            if (AltKeyPressed)
            {
                if (SelectedRectangle.Width > 0 || SelectedRectangle.Height > 0)
                {
                    e.Graphics.DrawString($"{SelectedRectangle.Left}, {SelectedRectangle.Top}",
                        new Font("Arial", 7), new SolidBrush(Settings.Default.SelectionColor), new Point(Math.Min(m_startPoint.X, m_endPoint.X) + 1, Math.Min(m_startPoint.Y, m_endPoint.Y) - 11));
                    e.Graphics.DrawString($"{SelectedRectangle.Width}, {SelectedRectangle.Height}",
                        new Font("Arial", 7), new SolidBrush(Settings.Default.SelectionColor), new Point(m_endPoint.X + 1, m_endPoint.Y + 1));
                }
            }

            if (FormIn)
            {
                var cursorPen = new Pen(Color.FromArgb(Settings.Default.CursorOpacity, Settings.Default.CursorColor));
                e.Graphics.DrawLine(cursorPen, 0, CrossPoint.Y, CrossPoint.X - 2, CrossPoint.Y);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X + 2, CrossPoint.Y, ClientRectangle.Width, CrossPoint.Y);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X, 0, CrossPoint.X, CrossPoint.Y - 2);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X, CrossPoint.Y + 2, CrossPoint.X, ClientRectangle.Height);
                cursorPen = new Pen(Settings.Default.CursorColor);
                e.Graphics.DrawLine(cursorPen, Math.Max(0, CrossPoint.X - 20), CrossPoint.Y, CrossPoint.X - 3, CrossPoint.Y);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X + 3, CrossPoint.Y, Math.Min(CrossPoint.X + 20, ClientRectangle.Width), CrossPoint.Y);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X, Math.Max(0, CrossPoint.Y - 20), CrossPoint.X, CrossPoint.Y - 3);
                e.Graphics.DrawLine(cursorPen, CrossPoint.X, CrossPoint.Y + 3, CrossPoint.X, Math.Min(CrossPoint.Y + 20, ClientRectangle.Height));
            }

            OnTemporaryPaint(e.Graphics);
        }

        public void IterateMultiZone(PaintEventArgs e, EventHandler<EventArgs> startHandler, EventHandler<ZoneHandlerArgs> zoneHandler, EventHandler<EventArgs> endHandler)
        {
            startHandler?.Invoke(this, null);
            var n = 0;
            for (var j = 0; j <= ((m_multiCrop.ImgOffsetY != 0) ? m_multiCrop.ImgRepeatY : 0); j++)
            {
                var y = m_multiCrop.ImgStartY + j * m_multiCrop.ImgOffsetY;
                if (y + m_multiCrop.ImgHeight > Height) continue;
                for (var i = 0; i <= ((m_multiCrop.ImgOffsetX != 0) ? m_multiCrop.ImgRepeatX : 0); i++)
                {
                    var x = m_multiCrop.ImgStartX + i * m_multiCrop.ImgOffsetX;
                    if (x + m_multiCrop.ImgWidth > Width) break;
                    zoneHandler?.Invoke(this, new ZoneHandlerArgs(e.Graphics, new Rectangle(x, y, m_multiCrop.ImgWidth, m_multiCrop.ImgHeight), n++));
                }
            }
            m_multiCrop.IsSaving = false;
            endHandler?.Invoke(this, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void SetState(CaptureStep state)
        {
            m_mode = state;
            switch (state)
            {
                //case CaptureStep.Begin:
                //default:
                //    //cropToolStripMenuItem.Enabled = false;
                //    break;
                case CaptureStep.Start:
                    //cropToolStripMenuItem.Enabled = false;
                    ActiveTool.Start();
                    break;
                case CaptureStep.End:
                    //if (!(cropToolStripMenuItem.Enabled = ActiveTool is DefaultTool))
                    {
                        ActiveTool.Stop();
                        ActiveTool.Draw(Graphics.FromImage(BackgroundImage));
                        ActiveTool = new DefaultTool(this);
                    }
                    Invalidate();
                    break;
            }
            Invalidate();
        }

        private void CropToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var backgroundImage = CropImage(BackgroundImage, SelectedRectangle);
                SetState(CaptureStep.Begin);

                BackgroundImage.Dispose();
                BackgroundImage = null;
                WindowState = FormWindowState.Normal;
                SetBounds(Left + SelectedRectangle.X, Top + SelectedRectangle.Y, SelectedRectangle.Width, SelectedRectangle.Height);
                BackgroundImage = backgroundImage;

                Invalidate();
                if (!Settings.Default.AutoHideMenu)
                {
                    MenuStrip1MouseEnter(this, null);
                }
                IsCroped = true;
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
        }

        #region Save

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                if (FileName != null)
                {
                    Save();
                    SetCaption(FileName, true);
                }
                else
                {
                    SaveAsToolStripMenuItemClick(sender, e);
                }
                RestoreInFormCursorPossition();
            }
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            Program.MainForm.SaveFileDialog.FileName = FileName;
            Program.MainForm.SaveFileDialog.InitialDirectory = Settings.Default.DefaultDirectory;
            if (Program.MainForm.SaveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Save();
                SetCaption(Program.MainForm.SaveFileDialog.FileName, true);
            }
            RestoreInFormCursorPossition();
        }

        private void Save()
        {
            try
            {
                var bitmap = BackgroundImage;
                var fmtStyle = ToImageFormat(Program.MainForm.SaveFileDialog.FilterIndex);
                bitmap.Save(Program.MainForm.SaveFileDialog.FileName, fmtStyle);
                TopMost = false;
                OpenInSystemEditor(Program.MainForm.SaveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen",
                    $@"Save Error:
{ex.Message}", ToolTipIcon.Error);
            }
        }

        private static ImageFormat ToImageFormat(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1: return ImageFormat.Jpeg;
                case 2: return ImageFormat.Png;
                case 3: return ImageFormat.Gif;
                case 4: return ImageFormat.Bmp;
                case 5: return ImageFormat.Emf;
                case 6: return ImageFormat.Tiff;
                case 7: return ImageFormat.Wmf;
                case 8: return ImageFormat.Exif;
                default: return ImageFormat.Png;
            }
        }

        public static void OpenInSystemEditor(string fileName)
        {
            if (Settings.Default.StartImageEditorOnSave)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch (Exception)
                {
                    try  // IE
                    {
                        Process.Start("iexplore.exe", fileName);
                    }
                    catch (Exception ex)
                    {
                        Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                    }
                }
            }
        }
        #endregion

        #region Open Menu
        private static Graphics GetMenuIcon(ToolStripItem mi)
        {
            var g = Graphics.FromImage(mi.Image = new Bitmap(16, 16));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return g;
        }
        #endregion

        #region Color settings

        private void BorderToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            Program.MyContext.OptionsDialogForm.BtnLinesColorClick(sender, e);
            RestoreInFormCursorPossition();
        }

        private void FillToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            Program.MyContext.OptionsDialogForm.BtnFillColorClick(sender, e);
            RestoreInFormCursorPossition();
        }

        private void TextToolStripMenuItem1Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            TextDialog.Font = Settings.Default.TextFont;
            TextDialog.Color = Settings.Default.FontColor;
            TextDialog.btnFont_Click(sender, e);
            RestoreInFormCursorPossition();
        }
        #endregion

        #region Drawing tools
        private void TextToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (TextDialog.ShowDialog(this) == DialogResult.OK)
            {
                ActiveTool = new TextTool(this, TextDialog.Annotate, Settings.Default.TextFont, new SolidBrush(Settings.Default.FontColor));
            }
            RestoreInFormCursorPossition();
        }

        private void RectangleToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new RectangleTool(this, new Pen(Settings.Default.LineColor, Settings.Default.LineWidth), new SolidBrush(Color.FromArgb(Settings.Default.FillTransparency * 255 / 100, Settings.Default.FillColor)));
        }

        private void EllipseToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new EllipseTool(this, new Pen(Settings.Default.LineColor, Settings.Default.LineWidth), new SolidBrush(Color.FromArgb(Settings.Default.FillTransparency * 255 / 100, Settings.Default.FillColor)));
        }

        private void LineToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new LineTool(this, new Pen(Settings.Default.LineColor, Settings.Default.LineWidth) { StartCap = LineCap.Round, EndCap = LineCap.Round });
        }

        private void ArrowToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new ArrowTool(this, new Pen(Color.FromArgb(127, Settings.Default.LineColor)) { Width = 5, CustomEndCap = new AdjustableArrowCap(4, 6) });
        }

        private readonly Color m_highlighterPink = Color.FromArgb(127, Color.HotPink);
        private readonly Color m_highlighterYellow = Color.FromArgb(127, 220, 255, 20);
        private readonly Color m_highlighterGreen = Color.FromArgb(127, 000, 255, 000);
        private readonly Color m_highlighterCyan = Color.FromArgb(127, Color.DodgerBlue);

        private void HighlightersToolStripMenuItem1DropDownOpening(object sender, EventArgs e)
        {
            pinkToolStripMenuItem1.BackColor = m_highlighterPink;
            yellowToolStripMenuItem1.BackColor = m_highlighterYellow;
            limeToolStripMenuItem.BackColor = m_highlighterGreen;
            cyanToolStripMenuItem1.BackColor = m_highlighterCyan;
        }

        private void PinkToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new HighlighterTool(this, m_highlighterPink, 16);
        }

        private void YellowToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new HighlighterTool(this, m_highlighterYellow, 16);
        }

        private void GreenToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new HighlighterTool(this, m_highlighterGreen, 16);
        }

        private void CyanToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new HighlighterTool(this, Color.FromArgb(127, m_highlighterCyan), 16);
        }

        #region Insert Markers

        private void FromFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            Program.MyContext.OpenImageDialog.InitialDirectory = Settings.Default.ImagesDirectory ?? Path.GetDirectoryName(Application.ExecutablePath) + @"\Resources";
            if (Program.MyContext.OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ImagesDirectory = Program.MyContext.OpenImageDialog.InitialDirectory;
                var markerImage = Image.FromFile(Program.MyContext.OpenImageDialog.FileName);
                //ToolStripMenuItem_Click(sender, e);
                ActiveTool = new MarkerTool(this, markerImage, true);
            }
            RestoreInFormCursorPossition();
        }

        private void RestoreInFormCursorPossition()
        {
            if (m_rightClickedPos.X > 0 || m_rightClickedPos.Y > 0)
            {
                Cursor.Position = m_rightClickedPos;
            }
        }

        private void MagnifyLentsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new ZoomLentsTool(this, 2);
        }
        #endregion

        internal int LastIndex = 0;
        private void IndexToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new IndexTool(this, ++LastIndex, new Pen(Settings.Default.LineColor), new SolidBrush(Settings.Default.FillColor), Settings.Default.TextFont);
        }

        #endregion

        #region Tool
        private void MoreOptionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (Program.MyContext.OptionsDialogForm.ShowDialog(this) == DialogResult.OK)
            {
            }
            RestoreInFormCursorPossition();

        }

        private void EraserToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new RectangleTool(this, null, new SolidBrush(Color.White));
        }

        private void ObfuscatorToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            var obfuscatorPen = new Pen(new HatchBrush((HatchStyle)35, Color.LightGray, Color.DarkGray)) { Width = 16 };
            ActiveTool = new LineTool(this, obfuscatorPen);
        }
        #endregion

        #region Copy-Paste
        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (SelectedRectangle.Width > 0 && SelectedRectangle.Height > 0)
            {
                try
                {
                    Clipboard.SetImage(CropImage(BackgroundImage, SelectedRectangle));
                }
                catch (Exception ex)
                {
                    Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                    Clipboard.SetImage(BackgroundImage);
                }
            }
            else
            {
                Clipboard.SetImage(BackgroundImage);
            }
        }

        private void PasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (Clipboard.ContainsImage())
            {
                var markerImage = Clipboard.GetImage();
                if (markerImage != null)
                {
                    if (Settings.Default.PasteImagesWithBorder)
                    {
                        using (var g = Graphics.FromImage(markerImage))
                        {
                            g.DrawRectangle(new Pen(Color.FromArgb(127, Color.DarkGray)), 0, 0, markerImage.Width - 1,
                                            markerImage.Height - 1);
                        }
                    }
                    ActiveTool = new MarkerTool(this, markerImage);
                }
            }
            else if (Clipboard.ContainsFileDropList())
            {
                var fileList = Clipboard.GetFileDropList();
                if (fileList.Count == 1)
                {
                    try
                    {
                        var markerImage = Image.FromFile(fileList[0]);
                        if (Settings.Default.PasteImagesWithBorder)
                        {
                            using (var g = Graphics.FromImage(markerImage))
                            {
                                g.DrawRectangle(new Pen(Color.FromArgb(127, Color.DarkGray)), 0, 0, markerImage.Width - 1, markerImage.Height - 1);
                            }
                        }
                        ActiveTool = new MarkerTool(this, markerImage);
                    }
                    catch (Exception ex)
                    {
                        Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                    }
                }
            }
            //else if (Clipboard.ContainsData(DataFormats.Rtf))
            //{
            //    object data = Clipboard.GetData(DataFormats.Rtf);
            //    RichTextBox rtb = new RichTextBox() { Width = 400, Height = 200 };
            //    rtb.Rtf = data as string;
            //    ActiveTool = new MarkerTool(this, rtb.Image); // ?
            //}
            else if (Clipboard.ContainsText())
            {
                TextDialog.Annotate = Clipboard.GetText();
                if (TextDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ActiveTool = new TextTool(this, TextDialog.Annotate, TextDialog.Font, new SolidBrush(TextDialog.Color));
                }
            }
        }
        #endregion

        #region Undo-Redo
        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            var undoItem = Undo.Pop();
            undoItem?.Undo();
        }

        private void deleteLastToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            var undoItem = Undo.Remove();
            undoItem?.Undo();
        }

        private void RedoToolStripMenuItem1Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            var redoItem = Undo.Next();
            redoItem?.Redo();
        }
        #endregion

        #region MaimMenu
        private void DrawingToolStripMenuItemDropDownOpening(object sender, EventArgs e)
        {
            var R = new Rectangle(new Point(0, 2), new Size(15, 12));

            var linePen = new Pen(Settings.Default.LineColor);
            var fillBrush = new SolidBrush(Color.FromArgb(50, Settings.Default.FillColor));

            using (var g = GetMenuIcon(arrowToolStripMenuItem1))
            {
                g.DrawLine(new Pen(Settings.Default.LineColor) { Width = 2, CustomEndCap = new AdjustableArrowCap(3, 4) }, 0, 8, 16, 8);
            }

            using (var g = GetMenuIcon(lineToolStripMenuItem1))
            {
                g.DrawLine(linePen, 0, 8, 16, 8);
            }

            using (var g = GetMenuIcon(rectangleToolStripMenuItem1))
            {
                if (FillShapeTool.FillShape)
                {
                    g.FillRectangle(fillBrush, R);
                }
                g.DrawRectangle(linePen, R);
            }

            using (var g = GetMenuIcon(ellipseToolStripMenuItem))
            {
                if (FillShapeTool.FillShape)
                {
                    g.FillEllipse(fillBrush, R);
                }
                g.DrawEllipse(linePen, R);
            }

            using (var g = GetMenuIcon(textToolStripMenuItem2))
            {
                var font = new Font("Arial", 7, FontStyle.Bold);
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, 16, 16));
                g.DrawString("Tx", font, Brushes.White, new Point(0, 2));
                g.DrawString("Tx", font, Brushes.White, new Point(0, 3));
                g.DrawString("Tx", font, Brushes.White, new Point(0, 4));
                g.DrawString("Tx", font, Brushes.White, new Point(0, 2));
                g.DrawString("Tx", font, Brushes.White, new Point(1, 2));
                g.DrawString("Tx", font, Brushes.White, new Point(2, 2));
                g.DrawString("Tx", font, new SolidBrush(Settings.Default.FontColor), new Point(1, 3));
            }

            using (var g = GetMenuIcon(indexToolStripMenuItem))
            {
                R = new Rectangle(new Point(1, 1), new Size(13, 13));
                linePen = new Pen(Settings.Default.LineColor) { Width = 2 };
                fillBrush = new SolidBrush(Settings.Default.FillColor);
                var textFont = new Font("Arial", 8.0f, FontStyle.Bold);
                var textBrush = new SolidBrush(TextDialog.Color);

                if (FillShapeTool.FillShape)
                {
                    g.FillEllipse(fillBrush, R);
                }
                g.DrawEllipse(linePen, R);
                g.DrawString((LastIndex + 1).ToString(CultureInfo.InvariantCulture), textFont, textBrush, new PointF(3f, 1.25f));
            }

            using (var g = GetMenuIcon(pointMarkerToolStripMenuItem))
            {
                g.DrawImage(CursorImage.CurrentImage(CursorImagePointerX, CursorImagePointerY), new Rectangle(0, 0, 16, 16));
            }
        }

        public int CursorImagePointerX;
        public int CursorImagePointerY;

        private void ExitToolStripMenuItem1DropDownOpening(object sender, EventArgs e)
        {
            stayOnTopToolStripMenuItem.Image = OnTopIcon;
            stayOnTopToolStripMenuItem.ImageTransparentColor = ((Bitmap)OnTopIcon).GetPixel(1, 1);
            transparentToolStripMenuItem1.Image = TrasparentIcon;
            transparentToolStripMenuItem1.Text = IsTransparent ? "Transparent" : "Opaque";
        }

        Image OnTopIcon => TopMost
            ? Resources.PinDown
            : Resources.PinRight;

        private void OnTop_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            TopMost = !TopMost;
            if (Settings.Default.ApplyToAll)
            {
                foreach (var captureForm in Program.CaptureForms)
                {
                    captureForm.TopMost = TopMost;
                }
            }
            RestoreInFormCursorPossition();
        }

        Image TrasparentIcon => IsTransparent
            ? Resources.Transparent
            : Resources.Opaque;

        bool m_isTransparent = Settings.Default.TransparentWhenNotFocused;

        public bool IsTransparent
        {
            get { return m_isTransparent; }
            set
            {
                m_isTransparent = value;
                MakeTransparent();
            }
        }

        private double m_zoomFactor;

        public double ZoomFactor => m_zoomFactor;

        public bool FormIn { get; set; } = true;

        public bool MenuIn { get; set; }

        private void MakeTransparent()
        {
            Opacity = (IsTransparent) ? TransparencyToOpacity(Settings.Default.FormTransparencyFactor) : 1.0;

            if (!Settings.Default.ApplyToAll) return;

            foreach (var captureForm in Program.CaptureForms)
            {
                captureForm.Opacity = Opacity;
            }
        }

        private void TransparentClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            IsTransparent = !IsTransparent;
            RestoreInFormCursorPossition();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void CaptureForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (!m_mouseDown)
            {
                if (menuStrip1.BackColor != Color.Transparent)
                {
                    if (filesToolStripMenuItem.Selected)
                    {
                        SplashScreen.ShowHelp(this, 14);
                    }
                    else if (editToolStripMenuItem.Selected)
                    {
                        SplashScreen.ShowHelp(this, 13);
                    }
                    else if (drawingToolStripMenuItem.Selected)
                    {
                        SplashScreen.ShowHelp(this, 7);
                    }
                    else if (highlightersToolStripMenuItem1.Selected)
                    {
                        SplashScreen.ShowHelp(this, 15);
                    }
                    else if (exitToolStripMenuItem1.Selected)
                    {
                        SplashScreen.ShowHelp(this, 17);
                    }
                    else if (minimizeToolStripMenuItem.Selected)
                    {
                        SplashScreen.ShowHelp(this, 19);
                    }
                    else if (closeToolStripMenuItem.Selected)
                    {
                        SplashScreen.ShowHelp(this, 20);
                    }

                    else
                    {
                        SplashScreen.ShowHelp(this, 2);
                    }
                }
                else
                {
                    if (WindowState == FormWindowState.Maximized)
                    {
                        SplashScreen.ShowHelp(this, 1);
                    }
                    else
                    {
                        SplashScreen.ShowHelp(this, 1);
                    }
                }
            }
            else // mouseDown
            {
                SplashScreen.ShowHelp(this, ActiveTool.HelpContextIndex);
            }
        }

        private void SwapToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (Undo.CanUndo)
            {
                var undoItem1 = Undo.Pop();
                if (!Undo.CanUndo) return;
                var undoItem2 = Undo.Pop();
                undoItem1.Undo();
                undoItem2.Undo();

                undoItem1.Redo();
                Undo.Push(undoItem1);
                undoItem2.Redo();
                Undo.Push(undoItem2);
            }
        }

        private void CaptureFormResize(object sender, EventArgs e)
        {
            menuStrip1.CanOverflow = true;
            menuStrip1.Width = Width - 6;
        }

        MultiCropDialog m_multiCrop;
        private void MultiCropToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            if (m_multiCrop == null)
            {
                m_multiCrop = new MultiCropDialog();
            }
            if (SelectedRectangle.Width > 0 || SelectedRectangle.Height > 0)
            {
                m_multiCrop.ImgStartX = SelectedRectangle.X;
                m_multiCrop.ImgStartY = SelectedRectangle.Y;
                m_multiCrop.ImgOffsetX = (m_multiCrop.ImgWidth = SelectedRectangle.Width) + 2;
                m_multiCrop.ImgOffsetY = (m_multiCrop.ImgHeight = SelectedRectangle.Height) + 2;
            }
            m_multiCrop.ShowDialog(this);
            RestoreInFormCursorPossition();
        }

        private void DoubleToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ResizeForm(Math.Sqrt(2));
            RestoreInFormCursorPossition();
        }

        private void HalfToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ResizeForm(1 / Math.Sqrt(2));
            RestoreInFormCursorPossition();
        }

        public void ResizeForm(double factor)
        {
            m_zoomFactor = ZoomFactor * factor;
            Width = (int)Math.Round(BackgroundImage.Width * ZoomFactor);
            Height = (int)Math.Round(BackgroundImage.Height * ZoomFactor);
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Program.CaptureForms.Remove(this);
            base.OnClosing(e);
        }

        private void PointMarkerToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new MarkerTool(this);
        }

        private void CaptureFormLoad(object sender, EventArgs e)
        {
            IsSaved = false;
        }

        private void pickColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new PickColorTool(this);
            RestoreInFormCursorPossition();
        }

        private void CaptureIconImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            ActiveTool = new CropImageIconTool(this);
            RestoreInFormCursorPossition();
        }

        private void CaptureSmallIconImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            var cb = cbSmallIconImageSize;
            var width = 16;
            var height = 16;
            if (cb != null)
            {
                var r = new Regex(@"^\s*(\d{1,3})(?:\s*x\s*(?:(\d{1,3}))?)?\s*$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
                var text = r.IsMatch(cb.Text) ? r.Matches(cb.Text)[0].ToString() : cb.Items[0].ToString();
                if (r.IsMatch(text))
                {
                    var groups = r.Matches(text)[0].Groups;
                    if (groups.Count > 0)
                    {
                        int.TryParse(groups[1].ToString(), out width);
                        if (width == 0)
                        {
                            width = 16;
                        }
                        if (groups.Count > 1)
                        {
                            int.TryParse(groups[2].ToString(), out height);
                            if (height == 0)
                            {
                                height = width;
                            }
                        }
                        else
                        {
                            height = width;
                        }
                    }

                    text = $"{width}x{height}";
                    if (!cb.Items.Contains(text))
                    {
                        cb.Items.Add(text);
                    }
                    cb.Text = text;
                }
            }
            ActiveTool = new CropImageIconTool(this, new Size(width, height));
            RestoreInFormCursorPossition();
        }

        private void AddBorderToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
            //ActiveTool = new RectangleTool(this, new Pen(Settings.Default.LineColor, Settings.Default.LineWidth), new SolidBrush(Color.FromArgb(Settings.Default.ShapeFillTransparencyFactor * 255 / 100, Settings.Default.FillColor)));
            Graphics.FromImage(BackgroundImage).DrawRectangle(new Pen(Color.FromArgb(128, Settings.Default.LineColor), 3), new Rectangle(1, 1, BackgroundImage.Width - 3, BackgroundImage.Height - 3));
        }

        private void MenuStrip1HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            SplashScreen.ShowHelp(this, filesToolStripMenuItem.Visible ? 14 : 3);
        }

        private void CaptureForm_MouseEnter(object sender, EventArgs e)
        {
            FormIn = true;
            Invalidate();
            Cursor = CustomCursors.None();
        }

        private void CaptureForm_MouseLeave(object sender, EventArgs e)
        {
            FormIn = false;
            Invalidate();
        }

        private void MenuStrip1MouseEnter(object sender, EventArgs e)
        {
            FormIn = false;
            MenuIn = true;
            Opacity = 1;
            menuStrip1.Height = 24;
            menuStrip1.Cursor = Cursors.Hand;
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Invalidate();
        }

        private void MenuStrip1MouseLeave(object sender, EventArgs e)
        {
            FormIn = true;
            MenuIn = false;
            menuStrip1.Height = 3;
            menuStrip1.Cursor = Cursors.Default;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Refresh();
            menuStrip1.Invalidate();
            Focus();
        }

    }
}
