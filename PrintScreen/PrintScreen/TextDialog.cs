using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlexScreen
{
    public partial class TextDialog : BordlessResizableForm
    {
        public TextDialog()
        {
            InitializeComponent();
        }

        public string Annotate
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }

        public new Font Font
        {
            get { return Program.MyContext.FontDialog.Font; }
            set { Program.MyContext.FontDialog.Font = value; }
        }

        public Color Color
        {
            get { return Program.MyContext.FontDialog.Color; }
            set { Program.MyContext.FontDialog.Color = value; }
        }

        public void btnFont_Click(object sender, EventArgs e)
        {
            if (OptionsDialog.ConfigureFont(this))
            {
                SetFont();
            }
        }

        private void SetFont()
        {
            lAnnotation.Font = TextBox.Font = Program.MyContext.FontDialog.Font;
            lAnnotation.ForeColor = TextBox.ForeColor = Program.MyContext.FontDialog.Color;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            EnableOK();
        }

        private void EnableOK()
        {
            btnOK.Enabled = !string.IsNullOrEmpty(TextBox.Text);
        }

        private void TextDialog_Activated(object sender, EventArgs e)
        {
            SetFont();
            EnableOK();
        }

        private void sampleText_Click(object sender, EventArgs e)
        {
            TextBox.Focus();
        }

        private void TextDialog_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            SplashScreen.ShowHelp(this, 12);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            base.form_MouseDown(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            base.form_MouseLeave(sender, e);
        }

        public new DialogResult ShowDialog()
        {
            this.Font = Program.MySettings.TextFont;
            this.Color = Program.MySettings.FontColor;
            System.Windows.Forms.DialogResult result;
            if ((result = base.ShowDialog()) == System.Windows.Forms.DialogResult.OK)
            {
                Program.MySettings.TextFont = this.Font;
                Program.MySettings.FontColor = this.Color;
            }
            return result;
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            this.Font = Program.MySettings.TextFont;
            this.Color = Program.MySettings.FontColor;
            System.Windows.Forms.DialogResult result;
            if ((result = base.ShowDialog(owner)) == System.Windows.Forms.DialogResult.OK)
            {
                Program.MySettings.TextFont = this.Font;
                Program.MySettings.FontColor = this.Color;
            }
            return result;
        }
    }
}
