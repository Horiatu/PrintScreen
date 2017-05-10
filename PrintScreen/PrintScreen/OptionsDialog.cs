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
        #region Font
        private void btnTextFont_Click(object sender, EventArgs e)
        {
            ConfigureFont(this);
        }

        public static bool ConfigureFont(Form parent)
        {
            Program.MyContext.FontDialog.Apply += FontDialog_Apply;
            try
            {

                Program.MyContext.OptionsDialogForm.FontSample.ForeColor = Settings.Default.FontColor;
                Program.MyContext.OptionsDialogForm.FontSample.Font = Settings.Default.TextFont;
                if (Program.MyContext.FontDialog.ShowDialog(parent) == DialogResult.OK)
                {
                    SetFontSample(Program.MyContext.FontDialog.Font, Program.MyContext.FontDialog.Color);
                    return true;
                }
                return false;
            }
            finally
            {
                Program.MyContext.FontDialog.Apply -= FontDialog_Apply;
            }
        }

        private static void FontDialog_Apply(object sender, EventArgs e)
        {
            var fontDialog = sender as FontDialog;
            if (fontDialog == null) return;

            SetFontSample(fontDialog.Font, fontDialog.Color);
        }

        private static void SetFontSample(Font font, Color color)
        {
            Program.MyContext.OptionsDialogForm.FontSample.ForeColor = Settings.Default.FontColor = color;
            Program.MyContext.OptionsDialogForm.FontSample.Font = Settings.Default.TextFont = font;
            Settings.Default.Save();

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

        #endregion

        private void BtnOkClick(object sender, EventArgs e)
        {
            GetSetingsFromOptionsForm();
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


        private void OptionsDialogLoad(object sender, EventArgs e)
        {
            Load -= OptionsDialogLoad;
            //if (!Settings.Default.ConfigurationFileExists)
            {
                GetSetingsFromOptionsForm();
            }
        }

        private void nudCursorOpacity_ValueChanged(object sender, EventArgs e)
        {
            var cursorOpacity = sender as NumericUpDown;
            if (cursorOpacity == null) return;

            Settings.Default.CursorOpacity = (int)cursorOpacity.Value;
            Settings.Default.Save();
        }
        private void nudSelectionOpacity_ValueChanged(object sender, EventArgs e)
        {
            var selectionOpacity = sender as NumericUpDown;
            if (selectionOpacity == null) return;

            Settings.Default.SelectionOpacity = (int)selectionOpacity.Value;
            Settings.Default.Save();
        }
        private void BtnCursorColorClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            colorDialog1.Color = Settings.Default.CursorColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = Settings.Default.CursorColor = colorDialog1.Color;
                Settings.Default.Save();
            }
        }

        private void BtnSelectionColorClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            colorDialog1.Color = Settings.Default.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = Settings.Default.SelectionColor = colorDialog1.Color;
                Settings.Default.Save();
            }
        }

        public void BtnLinesColorClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            colorDialog1.Color = Settings.Default.LineColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = Settings.Default.LineColor = colorDialog1.Color;
                Settings.Default.Save();
            }
        }

        public void BtnFillColorClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            colorDialog1.Color = Settings.Default.FillColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = Settings.Default.FillColor = colorDialog1.Color;
                Settings.Default.Save();
            }
        }

        private void numLineWidth_ValueChanged(object sender, EventArgs e)
        {
            var lineWidth = sender as NumericUpDown;
            if (lineWidth == null) return;

            Settings.Default.LineWidth = (int)lineWidth.Value;
            Settings.Default.Save();
        }
        private void nudFillTransparency_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            if (nud == null) return;

            Settings.Default.FillTransparency = (int)nud.Value;
            Settings.Default.Save();
        }
        private void CbTextWithBorderCheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.TextWithBorder = cb.Checked;
            Settings.Default.Save();

            Program.MyContext.OptionsDialogForm.FontSample.Invalidate();
        }

        private void cbAutomaticallyCrop_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.AutomaticallyCrop = cb.Checked;
            Settings.Default.Save();
        }

        private void cbOnTop_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.AfterCaptureStayOnTop = cb.Checked;
            Settings.Default.Save();
        }

        private void cbTransparent_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.TransparentWhenNotFocused = cb.Checked;
            Settings.Default.Save();
        }

        private void cbKeepMenuOn_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.KeepMenuOn = cb.Checked;
            Settings.Default.Save();

        }

        private void cbImageBorder_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.AddBorderToPastedImages = cb.Checked;
            Settings.Default.Save();

        }

        private void cbTurnOnTips_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.DrawingTips = cb.Checked;
            Settings.Default.Save();
        }
        private void cbStartSysEditor_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.StartImageEditorOnSave = cb.Checked;
            Settings.Default.Save();
        }
        private void cbSuppresStartUpHelp_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.SuppressStartUpHelp = cb.Checked;
            Settings.Default.Save();
        }

        private void cbApplyToAll_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.ApplyToAll = cb.Checked;
            Settings.Default.Save();
        }
        private void CbAutoSaveCheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            cbAutoSaveAsk.Visible = Settings.Default.AutoSave = cb.Checked;
            Settings.Default.Save();
        }

        private void cbAutoSaveAsk_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            Settings.Default.AutoSaveAsk = cb.Checked;
            Settings.Default.Save();
        }

        private void OptionsDialog_Activated(object sender, EventArgs e)
        {
            SetFontSample(Settings.Default.TextFont, Settings.Default.FontColor);
        }
    }
}
