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

namespace FlexScreen
{
    public partial class CropScreen : Form
    {
        public TextDialog TextDialog = new TextDialog();
        public OptionsDialog OptionsDialog = new OptionsDialog();

        public CropScreen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (OptionsDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

    }
}
