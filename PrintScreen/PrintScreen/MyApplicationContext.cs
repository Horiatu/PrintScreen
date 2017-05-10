using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using FlexScreen.Properties;

namespace FlexScreen
{
    public class MyApplicationContext : ApplicationContext
    {
        //private int formCount;
        public SplashScreen SplashScreenForm;
        public OptionsDialog OptionsDialogForm;
        public OpenFileDialog OpenImageDialog;
        public FontDialog FontDialog;

        internal MyApplicationContext()
        {
            //Application.ApplicationExit += (sender, e) => Settings.Default.Save();

            SplashScreenForm = new SplashScreen
            {
                VersionText = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };
            SplashScreenForm.FormClosed += (sender, e) => Application.ExitThread();


            OptionsDialogForm = new OptionsDialog();

            OpenImageDialog = new OpenFileDialog
            {
                DefaultExt = "PNG",
                Title = Resources.Load_Image
            };

            if (string.IsNullOrEmpty(OpenImageDialog.InitialDirectory))
            {
                OpenImageDialog.InitialDirectory = "Resources";
            }

            SplashScreenForm.Show();
            FontDialog = new FontDialog
            {
                FontMustExist = true,
                ShowColor = true,
                ShowEffects = true,
                AllowVerticalFonts = true,
                ShowApply = true,
            };

            if (Settings.Default.AutoSave && !string.IsNullOrEmpty(Settings.Default.AutoSaveProjectFile) && File.Exists(Settings.Default.AutoSaveProjectFile))
            {
                Utils.UnZipAll(Settings.Default.AutoSaveProjectFile);
            }
        }

    }
}
