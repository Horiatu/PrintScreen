using System;
using System.Drawing;
using System.Windows.Forms;
using FlexScreen.Properties;

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
            Program.MyContext.FontDialog.Apply += FontDialog_Apply;
            if (Program.MyContext.FontDialog.ShowDialog(parent) == DialogResult.OK)
            {
                SetFontSample();
                return true;
            }
            SetFontSample(oldFont, oldColor);
            Program.MyContext.FontDialog.Apply -= FontDialog_Apply;
            Program.MyContext.OptionsDialogForm.FontSample.ForeColor = oldColor;
            Program.MyContext.OptionsDialogForm.FontSample.Font = oldFont;
            return false;
        }

        private static void FontDialog_Apply(object sender, EventArgs e)
        {
            var fontDialog = sender as FontDialog;
            if (fontDialog == null) return;

            SetFontSample(fontDialog.Font, fontDialog.Color);
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
            Settings.Default.Save();
            Settings.Default.Save();
        }

        public void GetSetingsFromOptionsForm()
        {
            Settings.Default.SuppressStartUpHelp = Settings.Default.SuppressStartUpHelp = cbSuppresStartUpHelp.Checked;
            Settings.Default.PasteImagesWithBorder = Settings.Default.PasteImagesWithBorder = cbImageBorder.Checked;
            Settings.Default.TextWithBorder = Settings.Default.TextWithBorder = cbTextWhiteBorder.Checked;
            Settings.Default.AfterCaptureStayOnTop = Settings.Default.AfterCaptureStayOnTop = cbOnTop.Checked;
            Settings.Default.TransparentWhenNotFocused = Settings.Default.TransparentWhenNotFocused = cbTransparent.Checked;
            Settings.Default.FormTransparencyFactor = Settings.Default.FormTransparencyFactor = (int)nudTransparency.Value;
            Settings.Default.FillTransparency = Settings.Default.FillTransparency = (int)nudFillTransparency.Value;
            Settings.Default.CursorOpacity = (int)nudCursorOpacity.Value;
            Settings.Default.SelectionOpacity = Settings.Default.SelectionOpacity = (int)nudSelectionOpacity.Value;
            Settings.Default.StartImageEditorOnSave = Settings.Default.StartImageEditorOnSave = cbStartSysEditor.Checked;
            Settings.Default.AutoHideMenu = Settings.Default.AutoHideMenu = !cbKeepMenuOn.Checked;
            Settings.Default.CaptureFromTryIcon = Settings.Default.CaptureFromTryIcon = cbCaptureFromTryIcon.Checked;
            Settings.Default.AutomaticallyCrop = Settings.Default.AutomaticallyCrop = cbAutomaticallyCrop.Checked;
            Settings.Default.NoToolTips = Settings.Default.NoToolTips = !cbTurnOnTips.Checked;
            Settings.Default.ApplyToAll = Settings.Default.ApplyToAll = cbApplyToAll.Checked;
            Settings.Default.AutoSave = Settings.Default.AutoSave = cbAutoSave.Checked;
            Settings.Default.AutoSaveAsk = Settings.Default.AutoSaveAsk = cbAutoSaveAsk.Checked;
            Settings.Default.FillTransparency = Settings.Default.FillTransparency = (int) nudFillTransparency.Value;
            Settings.Default.CursorColor = Settings.Default.CursorColor = btnCursorColor.BackColor;
            Settings.Default.LineColor = Settings.Default.LineColor = btnLinesColor.BackColor;
            Settings.Default.LineWidth = Settings.Default.LineWidth = (int)numLineWidth.Value;
            Settings.Default.FillColor = Settings.Default.FillColor = btnFillColor.BackColor;
            Settings.Default.SelectionColor = Settings.Default.SelectionColor = btnSelectionColor.BackColor;
            Settings.Default.TextFont = Settings.Default.TextFont = FontSample.Font;
            Settings.Default.FontColor = Settings.Default.FontColor = FontSample.ForeColor;

            if (Settings.Default.ApplyToAll)
            {
                foreach (var captureForm in Program.CaptureForms)
                {
                    captureForm.IsTransparent = cbTransparent.Checked;
                }
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            cbSuppresStartUpHelp.Checked = Settings.Default.SuppressStartUpHelp;
            cbImageBorder.Checked = Settings.Default.PasteImagesWithBorder;
            cbTextWhiteBorder.Checked = Settings.Default.TextWithBorder;
            cbOnTop.Checked = Settings.Default.AfterCaptureStayOnTop;
            cbTransparent.Checked = Settings.Default.TransparentWhenNotFocused;
            nudTransparency.Value = Settings.Default.FormTransparencyFactor >= 20 ? Settings.Default.FormTransparencyFactor : 20;
            nudFillTransparency.Value = Settings.Default.FillTransparency > 20 ? Settings.Default.FillTransparency : 20;
            nudCursorOpacity.Value = Settings.Default.CursorOpacity > 90 ? Settings.Default.CursorOpacity : 90;
            nudSelectionOpacity.Value = Settings.Default.SelectionOpacity > 90 ? Settings.Default.SelectionOpacity : 90;
            cbStartSysEditor.Checked = Settings.Default.StartImageEditorOnSave;
            cbKeepMenuOn.Checked = !Settings.Default.AutoHideMenu;
            cbCaptureFromTryIcon.Checked = Settings.Default.CaptureFromTryIcon;
            cbAutomaticallyCrop.Checked = Settings.Default.AutomaticallyCrop;

            btnCursorColor.BackColor = Settings.Default.CursorColor;
            btnLinesColor.BackColor = Settings.Default.LineColor;
            numLineWidth.Value = Settings.Default.LineWidth >= 1 ? Settings.Default.LineWidth : 1;
            btnFillColor.BackColor = Settings.Default.FillColor;
            btnSelectionColor.BackColor = Settings.Default.SelectionColor;
            cbTurnOnTips.Checked = !Settings.Default.NoToolTips;
            cbApplyToAll.Checked = Settings.Default.ApplyToAll;
            cbAutoSave.Checked = Settings.Default.AutoSave;
            cbAutoSaveAsk.Checked = Settings.Default.AutoSaveAsk;
            nudFillTransparency.Value = Settings.Default.FillTransparency;
            nudCursorOpacity.Value = Settings.Default.CursorOpacity;
            nudSelectionOpacity.Value = Settings.Default.SelectionOpacity;
            cbAutoSaveAsk.Visible = cbAutoSave.Checked;

            Program.MyContext.FontDialog.Font = Settings.Default.TextFont;
            Program.MyContext.FontDialog.Color = Settings.Default.FontColor;

            SetFontSample();
        }

        private void OptionsDialogHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            SplashScreen.ShowHelp(this, 46);
        }

        #region mouse events

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
            colorDialog1.Color = Settings.Default.CursorColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.CursorColor = colorDialog1.Color;
                btnCursorColor.BackColor = Settings.Default.CursorColor = colorDialog1.Color;
            }
        }

        private void BtnSelectionColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.Default.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SelectionColor = colorDialog1.Color;
                btnSelectionColor.BackColor = Settings.Default.SelectionColor = colorDialog1.Color;
            }
        }

        public void BtnLinesColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.Default.LineColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.LineColor = colorDialog1.Color;
                btnLinesColor.BackColor = Settings.Default.LineColor = colorDialog1.Color;
            }
        }

        public void BtnFillColorClick(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.Default.FillColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.FillColor = colorDialog1.Color;
                btnFillColor.BackColor = Settings.Default.FillColor = colorDialog1.Color;
            }
        }

        private void CbAutoSaveCheckedChanged(object sender, EventArgs e)
        {
            cbAutoSaveAsk.Visible = Settings.Default.AutoSaveAsk = ((CheckBox)sender).Checked;
        }

        private void OptionsDialogLoad(object sender, EventArgs e)
        {
            Load -= OptionsDialogLoad;
            //if (!Settings.Default.ConfigurationFileExists)
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

        private void nudCursorOpacity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
