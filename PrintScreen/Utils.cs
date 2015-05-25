using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using Ionic.Zip;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlexScreen
{
    [System.Flags]
    public enum Corners
    {
        None = 0,
        TopLeft = 1,
        TopRight = 2,
        BottomLeft = 4,
        BottomRight = 8,
        All = TopLeft | TopRight | BottomLeft | BottomRight,
        Top = TopLeft | TopRight,
        Bottom = BottomLeft | BottomRight,
        Left = TopLeft | BottomLeft,
        Right = TopRight | BottomRight,
    }

    public static class Utils
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x0100;
        public const int VK_F1 = 0x70;
        public const Int32 WM_PAINT = 0xF;
        public const Int32 WM_PRINT = 0x317;
        public const Int32 PRF_CLIENT = 0x4;    // Draw the window's client area
        public const Int32 PRF_CHILDREN = 0x10; // Draw all visible child
        public const Int32 PRF_OWNED = 0x20;    // Draw all owned windows

        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTLEFT = 10;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTTOP = 12;
        public const int HTRIGHT = 11;


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static System.Drawing.Drawing2D.GraphicsPath RoundRectangle(Rectangle r, int radius, Corners corners)
        {
            //Make sure the Path fits inside the rectangle
            r.Width -= 1;
            r.Height -= 1;

            //Scale the radius if it's too large to fit.
            radius = Math.Min(radius, Math.Min(r.Width, r.Height));

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (radius <= 0)
                path.AddRectangle(r);
            else if ((corners & Corners.TopLeft) == Corners.TopLeft)
                path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
            else
                path.AddLine(r.Left, r.Top, r.Left, r.Top);

            if ((corners & Corners.TopRight) == Corners.TopRight)
                path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
            else
                path.AddLine(r.Right, r.Top, r.Right, r.Top);

            if ((corners & Corners.BottomRight) == Corners.BottomRight)
                path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            else
                path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);

            if ((corners & Corners.BottomLeft) == Corners.BottomLeft)
                path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
            else
                path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);

            path.CloseFigure();

            return path;
        }

        public static Color DarkenColor(Color colorIn, int percent)
        {
            //This method returns Black if you Darken by 100%

            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException("percent");

            int a, r, g, b;

            if (colorIn.A > 0)
            {
                a = colorIn.A;
                r = colorIn.R - (int)((colorIn.R / 100f) * percent);
                g = colorIn.G - (int)((colorIn.G / 100f) * percent);
                b = colorIn.B - (int)((colorIn.B / 100f) * percent);
            }
            else
            {
                a = r = g = b = 50;
            }

            return Color.FromArgb(a, r, g, b);
        }

        public static Color LightenColor(Color colorIn, int percent)
        {
            //This method returns White if you lighten by 100%

            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException("percent");

            int a, r, g, b;

            a = colorIn.A;
            r = colorIn.R + (int)(((255f - colorIn.R) / 100f) * percent);
            g = colorIn.G + (int)(((255f - colorIn.G) / 100f) * percent);
            b = colorIn.B + (int)(((255f - colorIn.B) / 100f) * percent);

            return Color.FromArgb(a, r, g, b);
        }

        public static ImageFormat ToImageFormat(string ext)
        {
            switch (ext.ToLower())
            {
                case ".jpg": return ImageFormat.Jpeg;
                case ".png": return ImageFormat.Png;
                case ".gif": return ImageFormat.Gif;
                case ".bmp": return ImageFormat.Bmp;
                case ".emf": return ImageFormat.Emf;
                case ".tiff": return ImageFormat.Tiff;
                case ".wmf": return ImageFormat.Wmf;
                case ".exif": return ImageFormat.Exif;
                default: return ImageFormat.Png;
            }
        }

        internal static void ZipAll(string zipFileName, EventHandler<EventArgs> fileDoneHandler = null)
        {
            using (var zip = new ZipFile())
            {
                var fileIndex = 0;
                foreach (var captureForm in Program.CaptureForms)
                {
                    ++fileIndex;
                    string entryFileName = ((!string.IsNullOrEmpty(captureForm.FileName))
                        ? Path.GetFileName(captureForm.FileName)
                        : fileIndex + ".PNG");

                    using (MemoryStream ms = new MemoryStream())
                    {
                        var minimized = captureForm.WindowState == FormWindowState.Minimized;
                        if (minimized)
                        {
                            captureForm.WindowState = FormWindowState.Normal;
                        }
                        captureForm.BackgroundImage.Save(ms, ToImageFormat(Path.GetExtension(entryFileName)));
                        ms.Seek(0, SeekOrigin.Begin);

                        var ze = zip.AddEntry(entryFileName, ms);
                        ze.Comment = string.Format("Top={0};Left={1};Pin={2};Tr={3};M={4};", captureForm.Top, captureForm.Left, captureForm.TopMost, captureForm.IsTransparent, minimized);
                        zip.Save(zipFileName);
                    }
                    if (fileDoneHandler != null)
                    {
                        fileDoneHandler(null, null);
                    }
                }
            }
        }

        internal static void UnZipAll(string zipFileName,
            EventHandler<UnZipEventArgs> fileStartHandler = null,
            EventHandler<UnZipEventArgs> fileAdvanceHandler = null,
            EventHandler<UnZipEventArgs> fileDoneHandler = null,
            EventHandler<UnZipEventArgs> fileErrorHandler = null)
        {
            using (var zipFile = ZipFile.Read(zipFileName))
            {
                if (fileStartHandler != null)
                {
                    fileStartHandler(null, new UnZipEventArgs() { Count = zipFile.Count(), zipName = Path.GetFileNameWithoutExtension(zipFileName) });
                }
                var windowRect = new ScreenCapture.User32.RECT();
                ScreenCapture.User32.GetWindowRect(ScreenCapture.User32.GetDesktopWindow(), ref windowRect);
                var screenWidth = windowRect.right - windowRect.left;
                var screenHeight = windowRect.bottom - windowRect.top;

                var winTop = 1;
                var winLeft = 1;
                var winHeight = 0;
                var showFile = false;

                foreach (var zipEntry in zipFile)
                {
                    try
                    {
                        using (var ms = new MemoryStream())
                        {
                            try
                            {
                                zipEntry.Extract(ms);
                            }
                            catch (BadPasswordException)
                            {
                                ExtractWithPassword(ms, Path.GetFileNameWithoutExtension(zipFileName), zipEntry, ref showFile);
                            }
                            ms.Seek(0, SeekOrigin.Begin);

                            var captureForm = Program.GetCaptureForm(Image.FromStream(ms));
                            captureForm.FileName = zipEntry.FileName;

                            if (!string.IsNullOrEmpty(zipEntry.Comment))
                            #region form possition from comment
                            {
                                var regex = new Regex(@"(?:T(?:op)?=(\d+);L(?:eft)?=(\d+))(?:(?:;P(?:in)?=(?:([T|F]))(?:\w*))?(?:;(?:Tr(?:ansparent)?=(?:([T|F])(?:\w*)))?)(?:;(?:M(?:inimised)?=(?:([T|F])(?:\w*)))?)?)?",
                                    RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);

                                if (regex.IsMatch(zipEntry.Comment))
                                {
                                    var matches = regex.Matches(zipEntry.Comment);
                                    if (matches.Count == 1)
                                    {
                                        var groups = matches[0].Groups;
                                        if (groups.Count >= 3)
                                        {
                                            int t;
                                            int.TryParse(groups[1].Value, out t);
                                            captureForm.Top = t;
                                            int l;
                                            int.TryParse(groups[2].Value, out l);
                                            captureForm.Left = l;
                                        }
                                        if (groups.Count >= 3)
                                        {
                                            captureForm.TopMost = groups[3].Value.ToUpper().StartsWith("T");
                                        }
                                        if (groups.Count >= 4)
                                        {
                                            captureForm.IsTransparent = groups[4].Value.ToUpper().StartsWith("T");
                                        }
                                        if (groups.Count >= 5)
                                        {
                                            captureForm.WindowState = groups[5].Value.ToUpper().StartsWith("T")
                                                ? FormWindowState.Minimized
                                                : FormWindowState.Normal;
                                        }
                                    }
                                }
                            }
                            #endregion
                            else
                            {
                                captureForm.Top = winTop;
                                captureForm.Left = winLeft;
                                winHeight = Math.Max(winHeight, captureForm.Height);
                                winLeft = winLeft + captureForm.Width + 1;
                                if (winLeft + captureForm.Width > screenWidth)
                                {
                                    winLeft = 1;
                                    winTop = winTop + winHeight + 1;
                                    winHeight = 0;
                                    if (winTop + captureForm.Height > screenHeight)
                                    {
                                        winTop = 1;
                                    }
                                }
                            }

                            if (fileAdvanceHandler != null)
                            {
                                fileAdvanceHandler(null, new UnZipEventArgs() { Count = zipFile.Count(), zipName = Path.GetFileNameWithoutExtension(zipFileName), EntryName = zipEntry.FileName });
                            }
                            Application.DoEvents();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (fileErrorHandler != null)
                        {
                            fileErrorHandler(null, new UnZipEventArgs() { Count = zipFile.Count(), zipName = Path.GetFileNameWithoutExtension(zipFileName), EntryName = zipEntry.FileName, exception = ex, });
                        }
                        else throw;
                    }
                }
            }
            if (fileDoneHandler != null)
            {
                fileDoneHandler(null, null);
            }
        }

        private static readonly Dictionary<string, string> FilePasswords = new Dictionary<string, string>();
        private static void ExtractWithPassword(Stream ms, string zipName, ZipEntry zipEntry, ref bool showFile)
        {
            try
            {
                if (FilePasswords.Any())
                {
                    foreach (var password in FilePasswords.Values)
                    {
                        zipEntry.Password = password;
                        zipEntry.Extract(ms);

                        FilePasswords.Add(zipEntry.FileName, password);
                        break;
                    }
                }
                else
                {
                    TryExtractWithPassword(ms, zipName, zipEntry, ref showFile);
                }
            }
            catch (BadPasswordException)
            {
                TryExtractWithPassword(ms, zipName, zipEntry, ref showFile);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Canceled by User")
                {
                    throw new BadPasswordException();
                }
            }
        }

        private static void TryExtractWithPassword(Stream ms, string zipName, ZipEntry zipEntry, ref bool showFile)
        {
            for (var i = 1; i <= 3; i++)
                try
                {
                    //var showFile = false;
                    var password = PasswordDialog.GetPassword(zipName, zipEntry.FileName, ref showFile);
                    if (password.StartsWith("C"))
                    {
                        throw new Exception("Canceled by User");
                    }
                    if (password.StartsWith("A"))
                    {
                        throw new Exception("Aborted by User");
                    }
                    zipEntry.Password = password.Substring(2);
                    zipEntry.Extract(ms);

                    FilePasswords.Add((password.StartsWith("F")) ? zipEntry.FileName : "*", password.Substring(2));
                    return;
                }
                catch (BadPasswordException)
                {
                    if (i == 3) throw;
                }
        }
    }
}
