using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FlexScreen.Properties;
using Ionic.Zip;

namespace FlexScreen
{
    public partial class SplashScreen : BordlessForm
    {
        public const string HelpFile = "PrintScreen.chm";

        public static void ShowHelp(Control sender, int index)
        {
            Help.ShowHelp(sender, HelpFile, HelpNavigator.TopicId, index.ToString(CultureInfo.InvariantCulture));
        }

        public string VersionText
        {
            get { return lblVersion.Text; }
            set { lblVersion.Text = String.Format(Resources.Version, value); }
        }

        public SplashScreen()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            VersionText = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            NotifyIcon1.BalloonTipText = string.Format(Resources.BalloonTipTextFormat, VersionText);
            NotifyIcon1.ShowBalloonTip(2000);

            if (!Settings.Default.SuppressStartUpHelp)
            {
                Help.ShowHelp(this, SplashScreen.HelpFile, 0);
            }
        }

        private void SplashScreenFormClosing(object sender, FormClosingEventArgs e)
        {
            if (new ExitDialog().ShowDialog() != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void BtnOptionsClick(object sender, EventArgs e)
        {
            Program.MyContext.OptionsDialogForm.ShowDialog();
        }

        private void SplashScreenLocationChanged(object sender, EventArgs e)
        {
            var f = (sender as Form);
            if (f != null && f.Bounds.X > 0 && f.Bounds.Y > 0)
            {
                Settings.Default.SplashScreenBounds = f.Bounds;
            }
        }

        private void SplashScreenActivated(object sender, EventArgs e)
        {
            if (Settings.Default.SplashScreenBounds.X > 0 && Settings.Default.SplashScreenBounds.Y > 0)
            {
                var f = (sender as Form);
                if (f != null)
                {
                    f.StartPosition = FormStartPosition.Manual;
                    f.Bounds = Settings.Default.SplashScreenBounds;
                }
            }
        }

        private void BtnCaptureClick(object sender, EventArgs e)
        {
            BtnMinimizeClick(sender, e);
            CaptureImage(Screen.PrimaryScreen);
        }

        private void BtnCaptureClick2(object sender, EventArgs e)
        {
            BtnMinimizeClick(sender, e);
            CaptureImage(Screen.AllScreens.FirstOrDefault(s => !s.Primary));
        }

        internal static CaptureForm CaptureImage(Screen screen)
        {
            if (screen != null)
            {
                var image = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

                using (var g = Graphics.FromImage(image))
                {
                    g.CopyFromScreen(screen.Bounds.Left, screen.Bounds.Top, 0, 0, image.Size);
                }

                return Program.GetCaptureForm(image, screen);
            }
            return null;// Program.GetCaptureForm();
        }

        private void BtnMinimizeClick(object sender, EventArgs e)
        {
            Hide();
            NotifyIcon1.ShowBalloonTip(2000);
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        #region moue events
        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utils.ReleaseCapture();
                ((Control)sender).Cursor = Cursors.SizeAll;
                Utils.SendMessage(Handle, Utils.WM_NCLBUTTONDOWN, Utils.HT_CAPTION, 0);
            }
        }

        private void FormMouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
        }
        #endregion

        private void BtnHelpClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpFile, 0);
        }

        private void SplashScreenHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            hlpevent.Handled = true;
            Help.ShowHelp(this, HelpFile, 0);
        }

        private void NotifyIcon1MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Settings.Default.CaptureFromTryIcon)
                {
                    if (WindowState != FormWindowState.Minimized)
                    {
                        BtnMinimizeClick(sender, e);
                    }
                    Program.GetCaptureForm();
                }
                else
                {
                    AboutToolStripMenuItemClick(sender, e);
                }
            }
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void HelpToolStripMenuItemClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpFile, 0);
        }

        private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
        {
            aboutToolStripMenuItem.Font = new Font(aboutToolStripMenuItem.Font, Settings.Default.CaptureFromTryIcon ? FontStyle.Regular : FontStyle.Bold);
            captureToolStripMenuItem.Font = new Font(captureToolStripMenuItem.Font, Settings.Default.CaptureFromTryIcon ? FontStyle.Bold : FontStyle.Regular);

            var screens = Screen.AllScreens;
            captureOtherScreenToolStripMenuItem.Visible = screens.Count() > 1;

            var areThereVisibleForms = Program.CaptureForms.Count > 0 && Program.CaptureForms.Any(f => f.WindowState == FormWindowState.Normal);
            minimizeAllToolStripMenuItem.Visible = areThereVisibleForms;
            restoreAllToolStripMenuItem1.Visible = Program.CaptureForms.Count > 0 && !areThereVisibleForms;

            saveProjectToolStripMenuItem.Visible = Program.CaptureForms.Count > 0;
        }

        private void NotifyIcon1DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Cursor = Cursors.Default;
        }

        private void BtnSaveAllClick(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            progressBar1.Visible = true;
            progressBar1.Step = 1;
            progressBar1.Maximum = Program.CaptureForms.Count;
            progressBar1.Value = 0;
            Application.DoEvents();
            try
            {
                var zipFileName = saveFileDialog1.FileName;
                Utils.ZipAll(zipFileName, (s, ee) =>
                                              {
                                                  progressBar1.Value += 1;
                                                  Application.DoEvents();
                                              });
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            if (openFileDialog1.FileNames.Any())
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = openFileDialog1.FileNames.Count();
                progressBar1.ForeColor = Color.RoyalBlue;
                progressBar1.Visible = true;
                try
                {
                    foreach (var fileName in openFileDialog1.FileNames)
                    {
                        progressBar1.Value += 1;
                        LoadCaptureWindow(fileName);
                    }
                }
                finally
                {
                    progressBar1.Visible = false;
                    //Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(1000, "PrintScreen", string.Format("Loaded {0} file{1}.", progressBar1.Value, progressBar1.Value == 1 ? "" : "s"), ToolTipIcon.Info);
                }
            }
        }

        private bool LoadCaptureWindow(string fileName)
        {
            bool[] loadErrors = { false };
            var extension = Path.GetExtension(fileName);
            if (extension != null && extension.ToLower() == ".zip")
            {
                var oldValue = progressBar1.Value;
                ProgressBarEx[] pb = { progressBar1 };
                try
                {
                    Utils.UnZipAll(fileName,
                                   (s, e) => // fileStartHandler
                                   {
                                       pb[0].Value = 0;
                                       pb[0].Maximum = e.Count;
                                       pb[0].ForeColor = Color.RoyalBlue;
                                       pb[0].Visible = true;
                                   },
                                   (s, e) => // file AdvanceHandler
                                   {
                                       pb[0].Value += 1;
                                       pb[0].Refresh();
                                   },
                                   (s, e) => // fileDoneHandler
                                   {
                                       if (oldValue > 0)
                                       {
                                           pb[0].Value = oldValue;
                                       }
                                       else
                                       {
                                           pb[0].Visible = loadErrors[0];
                                       }
                                   },
                                   (s, e) => // fileErrorHandler
                                   {
                                       if (e.exception.GetType() != typeof(BadPasswordException))
                                           throw e.exception;
                                       Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000,"PrintScreen",
                                                                                                     string.Format(
@"Load error on zip file:
{0}
{1}", fileName, e.exception.Message),ToolTipIcon.Warning); // ?
                                       pb[0].AddMarker(Color.Plum);
                                       pb[0].Value += 1;
                                       pb[0].Refresh();
                                       loadErrors[0] = true;
                                   });
                }
                catch (Exception ex)
                {
                    Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", string.Format(
@"Load error on zip file:
{0}
{1}", fileName, ex.Message), ToolTipIcon.Error); // ?
                    loadErrors[0] = true;
                }
            }
            else
            {
                try
                {
                    var imgFile = Image.FromFile(fileName);
                    Program.GetCaptureForm(imgFile).FileName = fileName;
                }
                catch (Exception ex)
                {
                    Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", string.Format(
@"Load error on file:
{0}
{1}", fileName, ex.Message), ToolTipIcon.Error); // ?
                    progressBar1.ForeColor = Color.Red;
                    progressBar1.Refresh();
                    loadErrors[0] = true;
                }
            }
            return !loadErrors[0];
        }

        public void MinimizeAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            MinimizeAll();
        }

        public static void MinimizeAll()
        {
            foreach (var captureForm in Program.CaptureForms.Where(cf => cf.WindowState != FormWindowState.Minimized))
            {
                captureForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void RestoreAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            RestoreAll();
        }

        public static void RestoreAll()
        {
            foreach (var captureForm in Program.CaptureForms.Where(cf => cf.WindowState != FormWindowState.Normal))
            {
                captureForm.WindowState = FormWindowState.Normal;
            }
        }

        private void PlayAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            m_escapeKeyPressed = false;
            m_spaceKeyToggle = false;
            Program.EscapeKeyPressed += OnEscapeKeyPressed;
            Program.SpaceKeyPressed += OnSpaceKeyPressed;
            try
            {
                MinimizeAll();

                var list = new List<CaptureForm>(Program.CaptureForms);
                var rnd = new Random();
                while (list.Count > 0 && !m_escapeKeyPressed)
                {
                    var i = rnd.Next(list.Count);
                    var x = 0;
                    var y = 0;
                    var l = 0;
                    while (i < list.Count && !m_escapeKeyPressed)
                    {
                        if (m_spaceKeyToggle && !m_escapeKeyPressed)
                        {
                            Application.DoEvents();
                            continue;
                        }
                        var captureForm = list[i];
                        captureForm.WindowState = FormWindowState.Normal;
                        if (y + captureForm.Height > Screen.AllScreens[0].Bounds.Height)
                        {
                            y = 0;
                        }
                        if (x + captureForm.Width > Screen.AllScreens[0].Bounds.Width)
                        {
                            x = 0;
                        }

                        l++;
                        if (x == 0 && y == 0)
                        {
                            captureForm.WindowState = FormWindowState.Minimized;
                            if (!m_spaceKeyToggle && !m_escapeKeyPressed) Thread.Sleep(Math.Min(l, 10) * 1000);

                            MinimizeAll();
                            l = 0;
                        }

                        captureForm.WindowState = FormWindowState.Normal;
                        captureForm.Left = x;
                        captureForm.Top = y;
                        captureForm.Show();

                        Application.DoEvents();
                        captureForm.TopLevel = true;
                        Application.DoEvents();
                        captureForm.IsTransparent = false;
                        Application.DoEvents();

                        if (!m_spaceKeyToggle && !m_escapeKeyPressed) Thread.Sleep(250);

                        list.Remove(captureForm);
                        Application.DoEvents();
                        x = captureForm.Right;
                        y = captureForm.Bottom;
                        Application.DoEvents();
                    }
                }
            }
            finally
            {
                Program.SpaceKeyPressed -= OnSpaceKeyPressed;
                Program.EscapeKeyPressed -= OnEscapeKeyPressed;
                if (m_escapeKeyPressed) MinimizeAll();
            }
        }

        private bool m_escapeKeyPressed;
        private void OnEscapeKeyPressed()
        {
            m_escapeKeyPressed = true;
        }

        private bool m_spaceKeyToggle;
        private void OnSpaceKeyPressed()
        {
            m_spaceKeyToggle = !m_spaceKeyToggle;
        }

        private void PinAllToolStripMenuItemCheckedChanged(object sender, EventArgs e)
        {
            var pinned = ((ToolStripMenuItem)sender).Checked;
            foreach (var captureForm in Program.CaptureForms)
            {
                captureForm.TopMost = pinned;
            }
            pinAllToolStripMenuItem.Text = !pinned ? Resources.PinAll : Resources.UnPinAll;
            pinAllToolStripMenuItem.Image = !pinned ? Resources.PinDown : Resources.PinRight;
        }

        private void TransparentAllToolStripMenuItemCheckedChanged(object sender, EventArgs e)
        {
            bool isTransparent = ((ToolStripMenuItem)sender).Checked;
            foreach (var captureForm in Program.CaptureForms)
            {
                captureForm.IsTransparent = isTransparent;
            }
            transparentAllToolStripMenuItem.Text = !isTransparent ? Resources.TransparentAll : Resources.OpaqueAll;
            transparentAllToolStripMenuItem.Image = !isTransparent ? Resources.Transparent : Resources.Opaque;
        }
    }
}
