using System;
using System.IO;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    public partial class ExitDialog : BordlessForm
    {
        public ExitDialog()
        {
            InitializeComponent();
        }

        private void Label2MouseDown(object sender, MouseEventArgs e)
        {
            form_MouseDown(sender, e);
        }

        private void Panel1MouseLeave(object sender, EventArgs e)
        {
            form_MouseLeave(sender, e);
        }

        private void ExitDialogHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            SplashScreen.ShowHelp(this, 30);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!Settings.Default.AutoSave) return;
            if (!Settings.Default.AutoSave && !string.IsNullOrEmpty(Settings.Default.AutoSaveProjectFile)) return;
            if (Settings.Default.AutoSaveAsk || string.IsNullOrEmpty(Settings.Default.AutoSaveProjectFile))
            {
                if (!string.IsNullOrEmpty(Settings.Default.AutoSaveProjectFile))
                {
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Settings.Default.AutoSaveProjectFile);
                    saveFileDialog1.FileName = Settings.Default.AutoSaveProjectFile;
                }
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Settings.Default.AutoSaveProjectFile = saveFileDialog1.FileName;
                }
                else
                {
                    return;
                }
            }

            if (File.Exists(Settings.Default.AutoSaveProjectFile))
            {
                File.Delete(Settings.Default.AutoSaveProjectFile);
            }

            Utils.ZipAll(Settings.Default.AutoSaveProjectFile);
        }
    }
}
