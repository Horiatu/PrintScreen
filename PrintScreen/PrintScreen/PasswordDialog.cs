
using System.Windows.Forms;
namespace FlexScreen
{
    public partial class PasswordDialog : BordlessForm
    {
        public PasswordDialog(string zipName, string fileName, bool showFile)
        {
            InitializeComponent();
            ZipName = zipName;
            FileName = fileName;
            cbFile.Checked = showFile;
            CbFileCheckedChanged(cbFile, null);
        }

        public string ZipName { get; private set; }
        public string FileName { get; private set; }

        public static string GetPassword(string zipName, string fileName, ref bool showFile)
        {
            using (var dialog = new PasswordDialog(zipName, fileName, showFile))
            {
                var dialogResult = dialog.ShowDialog();
                showFile = dialog.cbFile.Checked;
                return dialogResult == DialogResult.OK 
                    ? (dialog.cbFile.Checked ? "F:":"*:")+dialog.tbPassword.Text 
                    : (dialogResult == DialogResult.Abort) 
                    ? "A"
                    : "C";
            }
        }

        private void CbFileCheckedChanged(object sender, System.EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb != null)
            {
                lFileName.Text = cb.Checked ? FileName : ZipName;
                btnCancel.Visible = cb.Checked;
            }
        }
    }
}
