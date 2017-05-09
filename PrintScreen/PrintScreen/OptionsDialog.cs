using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlexScreen
{
    public partial class OptionsDialog : BordlessForm
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void OptionsDialog_Activated(object sender, EventArgs e)
        {
            SetFontSample();
            BtnCancelClick(this, null);
        }

        #region Font
        private void btnTextFont_Click(object sender, EventArgs e)
        {
            ConfigureFont(this);
        }

        public static bool ConfigureFont(Form parent)
        {
            var oldFont = Program.MyContext.FontDialog.Font;
            var oldColor = Program.MyContext.FontDialog.Color;
            if (Program.MyContext.FontDialog.ShowDialog(parent) == DialogResult.OK)
            {
                SetFontSample();
                return true;
            }
            SetFontSample(oldFont, oldColor);
            Program.MyContext.OptionsDialogForm.FontSample.ForeColor = oldColor;
            Program.MyContext.OptionsDialogForm.FontSample.Font = oldFont;
            return false;
        }

        private static void SetFontSample(Font font = null, Color? color = null)
        {
            //Program.MyContext.OptionsDialogForm.FontSample.Text = Program.MyContext.FontDialog.Font.Name;
            Program.MyContext.OptionsDialogForm.FontSample.ForeColor = color ?? Program.MyContext.FontDialog.Color;
            Program.MyContext.OptionsDialogForm.FontSample.Font = font ?? Program.MyContext.FontDialog.Font;
            Program.MyContext.OptionsDialogForm.FontSample.Invalidate();
        }

        private void FontSamplePaint(object sender, PaintEventArgs e)
        {
            var fontSample = sender as Button;
            if (fontSample == null) return;
            Image tmp = new Bitmap(10, 10);
            var g = Graphics.FromImage(tmp);
            var s = g.MeasureString(fontSample.Font.Name, fontSample.Font);
            var x = Math.Max(2, (int)(fontSample.Width - s.Width) / 2);
            var y = Math.Max(2, (int)(fontSample.Height - s.Height) / 2);

            if (cbTextWhiteBorder.Checked)
            {
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x - 1, y - 1));
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x, y - 1));
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x + 1, y - 1));

                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x - 1, y));
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x + 1, y));

                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x - 1, y + 1));
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x, y + 1));
                e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, Brushes.White, new Point(x + 1, y + 1));
            }
            e.Graphics.DrawString(fontSample.Font.Name, fontSample.Font, new SolidBrush(fontSample.ForeColor), new Point(x, y));
        }

        private void CbTextWhiteBorderCheckedChanged(object sender, EventArgs e)
        {
            Program.MyContext.OptionsDialogForm.FontSample.Invalidate();
        }
        #endregion

        private void BtnOkClick(object sender, EventArgs e)
        {
            GetSetingsFromOptionsForm();
            Program.MySettings.Save();
        }

        public void GetSetingsFromOptionsForm()
        {
            Program.MySettings.SuppressStartUpHelp = cbSuppresStartUpHelp.Checked;
            Program.MySettings.PasteImagesWithBorder = cbImageBorder.Checked;
            Program.MySettings.TextWithBorder = cbTextWhiteBorder.Checked;
            Program.MySettings.AfterCaptureStayOnTop = cbOnTop.Checked;
            Program.MySettings.TransparentWhenNotFocussed = cbTransparent.Checked;
            Program.MySettings.FormTransparencyFactor = (int)nudTransparency.Value;
            Program.MySettings.ShapeFillTransparencyFactor = (int)nudFillTransparency.Value;
            Program.MySettings.CursorOpacity = (int)nudCursorOpacity.Value;
            Program.MySettings.SelectionOpacity = (int)nudSelectionOpacity.Value;
            Program.MySettings.StartImageEditorOnSave = cbStartSysEditor.Checked;
            Program.MySettings.AutoHideMenu = !cbKeepMenuOn.Checked;
            Program.MySettings.CaptureFromTryIcon = cbCaptureFromTryIcon.Checked;
            Program.MySettings.AutomaticallyCrop = cbAutomaticallyCrop.Checked;
            Program.MySettings.NoToolTips = !cbTurnOnTips.Checked;
            Program.MySettings.ApplyToAll = cbApplyToAll.Checked;
            Program.MySettings.AutoSave = cbAutoSave.Checked;
            Program.MySettings.AutoSaveAsk = cbAutoSaveAsk.Checked;
            Program.MySettings.FillTransparency = nudFillTransparency.Value;
            Program.MySettings.CursorColor = btnCursorColor.BackColor;
            Program.MySettings.LineColor = btnLinesColor.BackColor;
            Program.MySettings.LineWidth = (int)numLineWidth.Value;
            Program.MySettings.FillColor = btnFillColor.BackColor;
            Program.MySettings.SelectionColor = btnSelectionColor.BackColor;
            Program.MySettings.TextFont = FontSample.Font;
            Program.MySettings.FontColor = FontSample.ForeColor;

            if (Program.MySettings.ApplyToAll)
            {
                foreach (var captureForm in Program.CaptureForms)
                {
                    captureForm.IsTransparent = cbTransparent.Checked;
                }
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            cbSuppresStartUpHelp.Checked = Program.MySettings.SuppressStartUpHelp;
            cbImageBorder.Checked = Program.MySettings.PasteImagesWithBorder;
            cbTextWhiteBorder.Checked = Program.MySettings.TextWithBorder;
            cbOnTop.Checked = Program.MySettings.AfterCaptureStayOnTop;
            cbTransparent.Checked = Program.MySettings.TransparentWhenNotFocussed;
            nudTransparency.Value = Program.MySettings.FormTransparencyFactor >= 20 ? Program.MySettings.FormTransparencyFactor : 20;
            nudFillTransparency.Value = Program.MySettings.ShapeFillTransparencyFactor > 20 ? Program.MySettings.ShapeFillTransparencyFactor : 20;
            nudCursorOpacity.Value = Program.MySettings.CursorOpacity > 90 ? Program.MySettings.CursorOpacity : 90;
            nudSelectionOpacity.Value = Program.MySettings.SelectionOpacity > 90 ? Program.MySettings.SelectionOpacity : 90;
            cbStartSysEditor.Checked = Program.MySettings.StartImageEditorOnSave;
            cbKeepMenuOn.Checked = !Program.MySettings.AutoHideMenu;
            cbCaptureFromTryIcon.Checked = Program.MySettings.CaptureFromTryIcon;
            cbAutomaticallyCrop.Checked = Program.MySettings.AutomaticallyCrop;

            btnCursorColor.BackColor = Program.MySettings.CursorColor;
            btnLinesColor.BackColor = Program.MySettings.LineColor;
            numLineWidth.Value = Program.MySettings.LineWidth >= 1 ? Program.MySettings.LineWidth : 1;
            btnFillColor.BackColor = Program.MySettings.FillColor;
            btnSelectionColor.BackColor = Program.MySettings.SelectionColor;
            cbTurnOnTips.Checked = !Program.MySettings.NoToolTips;
            cbApplyToAll.Checked = Program.MySettings.ApplyToAll;
            cbAutoSave.Checked = Program.MySettings.AutoSave;
            cbAutoSaveAsk.Checked = Program.MySettings.AutoSaveAsk;
            nudFillTransparency.Value = Program.MySettings.FillTransparency;
            nudCursorOpacity.Value = Program.MySettings.CursorOpacity;
            nudSelectionOpacity.Value = Program.MySettings.SelectionOpacity;
            cbAutoSaveAsk.Visible = cbAutoSave.Checked;

            Program.MyContext.FontDialog.Font = Program.MySettings.TextFont;
            Program.MyContext.FontDialog.Color = Program.MySettings.FontColor;

            SetFontSample();
        }

        private void OptionsDialogHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            SplashScreen.ShowHelp(this, 46);
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

        private void GroupBox1Enter(object sender, EventArgs e)
        {
            ((GroupBox)sender).ForeColor = Color.OrangeRed;
        }

        private void GroupBox1Leave(object sender, EventArgs e)
        {
            ((GroupBox)sender).ForeColor = Color.RoyalBlue;
        }

        private void BtnCursorColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Program.MySettings.CursorColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnCursorColor.BackColor = Program.MySettings.CursorColor = colorDialog1.Color;
            }
        }

        private void BtnSelectionColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Program.MySettings.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnSelectionColor.BackColor = Program.MySettings.SelectionColor = colorDialog1.Color;
            }
        }

        public void BtnLinesColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Program.MySettings.LineColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnLinesColor.BackColor = Program.MySettings.LineColor = colorDialog1.Color;
            }
        }

        public void BtnFillColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Program.MySettings.FillColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnFillColor.BackColor = Program.MySettings.FillColor = colorDialog1.Color;
            }
        }

        private void CbAutoSaveCheckedChanged(object sender, EventArgs e)
        {
            cbAutoSaveAsk.Visible = ((CheckBox)sender).Checked;
        }

        private void OptionsDialogLoad(object sender, EventArgs e)
        {
            Load -= OptionsDialogLoad;
            if (!Program.MySettings.ConfigurationFileExists)
            {
                GetSetingsFromOptionsForm();
            }
        }

        private void FolderImage_DoubleClick(object sender, EventArgs e)
        {
            var arguments = @"/explore " + Application.LocalUserAppDataPath;
            Clipboard.SetText(Application.LocalUserAppDataPath);
            System.Diagnostics.Process.Start("explorer.exe", arguments);
        }
    }
}
