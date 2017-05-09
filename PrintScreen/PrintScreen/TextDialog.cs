using System;
using System.Drawing;
using System.Windows.Forms;
using FlexScreen.Properties;

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
            form_MouseDown(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            form_MouseLeave(sender, e);
        }

        public new DialogResult ShowDialog()
        {
            Font = Settings.Default.TextFont;
            Color = Settings.Default.FontColor;
            DialogResult result;
            if ((result = base.ShowDialog()) == DialogResult.OK)
            {
                Settings.Default.TextFont = Font;
                Settings.Default.FontColor = Color;
            }
            return result;
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            Font = Settings.Default.TextFont;
            Color = Settings.Default.FontColor;
            DialogResult result;
            if ((result = base.ShowDialog(owner)) == DialogResult.OK)
            {
                Settings.Default.TextFont = Font;
                Settings.Default.FontColor = Color;
            }
            return result;
        }
    }
}
