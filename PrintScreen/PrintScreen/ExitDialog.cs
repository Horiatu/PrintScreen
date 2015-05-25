using System;
using System.IO;
using System.Windows.Forms;

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
            if (!Program.MySettings.AutoSave) return;
            if (!Program.MySettings.AutoSave && !string.IsNullOrEmpty(Program.MySettings.AutoSaveProjectFile)) return;
            if (Program.MySettings.AutoSaveAsk || string.IsNullOrEmpty(Program.MySettings.AutoSaveProjectFile))
            {
                if (!string.IsNullOrEmpty(Program.MySettings.AutoSaveProjectFile))
                {
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Program.MySettings.AutoSaveProjectFile);
                    saveFileDialog1.FileName = Program.MySettings.AutoSaveProjectFile;
                }
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Program.MySettings.AutoSaveProjectFile = saveFileDialog1.FileName;
                }
                else
                {
                    return;
                }
            }

            if (File.Exists(Program.MySettings.AutoSaveProjectFile))
            {
                File.Delete(Program.MySettings.AutoSaveProjectFile);
            }

            Utils.ZipAll(Program.MySettings.AutoSaveProjectFile);
        }
    }
}
