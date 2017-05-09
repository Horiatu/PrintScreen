using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Ionic.Zip;

namespace FlexScreen
{
    public partial class MultiCropDialog : BordlessForm
    {
        public int ImgStartX { get { return (int)numStartX.Value; } set { numStartX.Value = value; } }
        public int ImgStartY { get { return (int)numStartY.Value; } set { numStartY.Value = value; } }
        public int ImgWidth { get { return (int)numWidth.Value; } set { numWidth.Value = value; } }
        public int ImgHeight { get { return (int)numHeight.Value; } set { numHeight.Value = value; } }
        public int ImgOffsetX { get { return (int)numOffsetX.Value; } set { numOffsetX.Value = value; } }
        public int ImgOffsetY { get { return (int)numOffsetY.Value; } set { numOffsetY.Value = value; } }
        public int ImgRepeatX { get { return (int)numRepeatX.Value; } set { numRepeatX.Value = value; } }
        public int ImgRepeatY { get { return (int)numRepeatY.Value; } set { numRepeatY.Value = value; } }

        public MultiCropDialog()
        {
            InitializeComponent();
        }

        CaptureForm captureForm = null;
        private void MultiCropDialog_Activated(object sender, EventArgs e)
        {
            captureForm = (CaptureForm)(((Form)(sender)).Owner);
            captureForm.Invalidate();
        }

        private void numStartX_ValueChanged(object sender, EventArgs e)
        {
            ImgStartX = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numStartY_ValueChanged(object sender, EventArgs e)
        {
            ImgStartY = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            ImgWidth = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            ImgHeight = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numRepeatX_ValueChanged(object sender, EventArgs e)
        {
            ImgRepeatX = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numRepeatY_ValueChanged(object sender, EventArgs e)
        {
            ImgRepeatY = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numOffsetX_ValueChanged(object sender, EventArgs e)
        {
            ImgOffsetX = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        private void numOffsetY_ValueChanged(object sender, EventArgs e)
        {
            ImgOffsetY = (int)((sender as NumericUpDown).Value);
            if (captureForm != null) captureForm.Invalidate();
        }

        public void Marker(object sender, ZoneHandlerArgs zoneArgs)
        {
            zoneArgs.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), zoneArgs.Rectangle);
        }

        ZipFile zip = null;
        string zipFileName = null;

        public void SaveZone(object sender, ZoneHandlerArgs zoneArgs)
        {
            try
            {
                var zone = captureForm.CropImage(captureForm.BackgroundImage, zoneArgs.Rectangle, cbTransparent.Checked ? btnTransparentColor.BackColor : (Color?)null);
                var fileName = tbFileRoot.Text + (numSeed.Value + zoneArgs.Index).ToString() + dumExtension.Text;
                if (cbArchive.Checked)
                {
                    if (zip == null)
                    {
                        zip = new ZipFile();
                        zipFileName = tbFileRoot.Text + ".Zip";
                    }
                    fileName = Path.GetFileName(fileName);

                    using (var fs = new MemoryStream())
                    {
                        zone.Save(fs, Utils.ToImageFormat(dumExtension.Text));
                        fs.Seek(0, SeekOrigin.Begin);

                        var ze = zip.AddEntry(fileName, fs);
                        zip.Save(zipFileName);
                    }
                }
                else
                {
                    zone.Save(fileName, Utils.ToImageFormat(dumExtension.Text));
                    CaptureForm.OpenInSystemEditor(fileName);
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            
                saveProgress.ForeColor = Color.OrangeRed;
                //saveProgress.Refresh();
                //Application.DoEvents();
            }
            try
            {
                saveProgress.PerformStep();
                saveProgress.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
        }

        internal void StartSaving()
        {
            saveProgress.Value = 0;
            saveProgress.Step = 1;
            saveProgress.Maximum = ((int)numRepeatX.Value + 1) * ((int)numRepeatY.Value + 1);
            saveProgress.Visible = true;
            saveProgress.Refresh();
            Application.DoEvents();
        }

        internal void CloseArchive()
        {
            if (zip != null)
            {
                zip.Dispose();
                zip = null;
            }
            saveProgress.Visible = false;
        }

        public bool IsSaving;
        private void btnOK_Click(object sender, EventArgs e)
        {
            IsSaving = true;
            captureForm.Invalidate();
            while (IsSaving)
            {
                Application.DoEvents();
            }
        }

        private void customButton4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                var regex = new Regex(@"^(.*?)(?:(\d*)??(\.\w{3,4})??)$", RegexOptions.CultureInvariant | RegexOptions.Compiled);
                if (regex.IsMatch(path))
                {
                    var matches = regex.Split(path);
                    if (matches.Length >= 1)
                    {
                        tbFileRoot.Text = matches[1];

                        var seed = 0;
                        if (matches.Length >= 2)
                        {
                            int.TryParse(matches[2], out seed);
                        }
                        numSeed.Value = seed;

                        if (matches.Length >= 3)
                        {
                            dumExtension.Text = matches[3].ToUpper();
                        }
                        else
                        {
                            dumExtension.Text = Path.GetExtension(path);
                        }
                    }
                    else
                    {
                        tbFileRoot.Text = path;
                    }
                }
                else
                {
                    tbFileRoot.Text = path;
                }
            }
        }

        private void btnTransparentColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = btnTransparentColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnTransparentColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnTransparentColor_BackColorChanged(object sender, EventArgs e)
        {
            btnTransparentColor.FlatAppearance.MouseDownBackColor = Utils.DarkenColor(btnTransparentColor.BackColor, 40);
            btnTransparentColor.FlatAppearance.MouseOverBackColor = Utils.LightenColor(btnTransparentColor.BackColor, 60);
        }
    }
}
