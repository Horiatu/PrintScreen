using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;

namespace PrintScreen
{
    public partial class PrintScreen : Form
    {
        public PrintScreen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void ScreenCapture(string initialDirectory)
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                Thread.Sleep(0);
                this.Refresh();
                worker.DoWork += (sender, e) =>
                {
                    BackgroundWorker wkr = sender as BackgroundWorker;
                    Rectangle bounds = new Rectangle(Location, Size);
                    Thread.Sleep(300);
                    Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Location, Point.Empty, bounds.Size);
                    }
                    e.Result = bitmap;
                };
                worker.RunWorkerCompleted += (sender, e) =>
                {
                    if (e.Error != null)
                    {
                        Exception err = e.Error;
                        while (err.InnerException != null)
                        {
                            err = err.InnerException;
                        }
                        MessageBox.Show(err.Message, "Screen Capture",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (e.Cancelled == true)
                    {
                    }
                    else if (e.Result != null)
                    {
                        if (e.Result is Bitmap)
                        {
                            Bitmap bitmap = (Bitmap)e.Result;
                            using (SaveFileDialog dlg = new SaveFileDialog())
                            {
                                dlg.Title = "Image Capture: Image Name, File Format, and Destination";
                                dlg.FileName = "Screenshot";
                                dlg.InitialDirectory = initialDirectory;
                                dlg.DefaultExt = "jpg";
                                dlg.AddExtension = true;
                                dlg.Filter =
                                    "Jpeg Image (JPG)|*.jpg|" +
                                    "PNG Image|*.png|" +
                                    "GIF Image (GIF)|*.gif|" +
                                    "Bitmap (BMP)|*.bmp|" +
                                    "EWM Image|*.emf|" +
                                    "TIFF Image|*.tiff|" +
                                    "Windows Metafile (WMF)|*.wmf|" +
                                    "Exchangable image file|*.exif";
                                dlg.FilterIndex = 1;
                                if (dlg.ShowDialog(this) == DialogResult.OK)
                                {
                                    ImageFormat fmtStyle;
                                    switch (dlg.FilterIndex)
                                    {
                                        case 2: fmtStyle = ImageFormat.Jpeg; break;
                                        case 3: fmtStyle = ImageFormat.Gif; break;
                                        case 4: fmtStyle = ImageFormat.Bmp; break;
                                        case 5: fmtStyle = ImageFormat.Emf; break;
                                        case 6: fmtStyle = ImageFormat.Tiff; break;
                                        case 7: fmtStyle = ImageFormat.Wmf; break;
                                        case 8: fmtStyle = ImageFormat.Exif; break;
                                        default: fmtStyle = ImageFormat.Png; break;
                                    }
                                    bitmap.Save(dlg.FileName, fmtStyle);
                                    try
                                    {
                                        Process.Start(dlg.FileName);
                                    }
                                    catch (Exception)
                                    {
                                        try
                                        { // try IE
                                            Process.Start("iexplore.exe", dlg.FileName);
                                        }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                    }
                };
                worker.RunWorkerAsync();
            }
        }
    }
}
