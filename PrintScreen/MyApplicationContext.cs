﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using FlexScreen.Properties;
using Ionic.Zip;

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
            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += OnApplicationExit;

            SplashScreenForm = new SplashScreen
                                   {VersionText = Assembly.GetExecutingAssembly().GetName().Version.ToString()};
            SplashScreenForm.FormClosed += SplashScreenForm_FormClosed;

            OptionsDialogForm = new OptionsDialog();
            OptionsDialogForm.Closing += OptionsDialogForm_Closing;

            OpenImageDialog = new OpenFileDialog {DefaultExt = "PNG", Title = Resources.Load_Image};
            if (string.IsNullOrEmpty(OpenImageDialog.InitialDirectory))
            {
                OpenImageDialog.InitialDirectory = "Resources";
            }

            SplashScreenForm.Show();
            FontDialog = new FontDialog() { FontMustExist = true, ShowColor = true, ShowEffects = true, };

            if (Program.MySettings.AutoSave && !string.IsNullOrEmpty(Program.MySettings.AutoSaveProjectFile) && File.Exists(Program.MySettings.AutoSaveProjectFile))
            {
                Utils.UnZipAll(Program.MySettings.AutoSaveProjectFile);
            }
        }

        void SplashScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        void OptionsDialogForm_Closing(object sender, CancelEventArgs e)
        {
            Program.MySettings.OptionFormLocation = ((Form) sender).Location;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Program.MySettings.Save();
        }
    }
}
