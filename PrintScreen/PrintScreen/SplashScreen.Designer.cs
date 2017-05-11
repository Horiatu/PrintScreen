using System.Drawing;
using System.Windows.Forms;
using FlexScreen.Properties;

namespace FlexScreen
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureOtherScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.btnLoad = new FlexScreen.CustomButton();
            this.btnCapture = new FlexScreen.CustomButton();
            this.btnClose = new FlexScreen.CustomButton();
            this.btnMinimize = new FlexScreen.CustomButton();
            this.btnHelp = new FlexScreen.CustomButton();
            this.btnOptions = new FlexScreen.CustomButton();
            this.btnSaveAll = new FlexScreen.CustomButton();
            this.progressBar1 = new FlexScreen.ProgressBarEx();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "png";
            this.SaveFileDialog.FileName = "ScreenShoot";
            this.SaveFileDialog.Filter = "Jpeg Image (JPG)|*.jpg|PNG Image|*.png|GIF Image (GIF)|*.gif|Bitmap (BMP)|*.bmp|E" +
    "WM Image|*.emf|TIFF Image|*.tiff|Windows Metafile (WMF)|*.wmf|Exchangable image " +
    "file|*.exif|All Files|*.*";
            this.SaveFileDialog.FilterIndex = 2;
            this.SaveFileDialog.SupportMultiDottedExtensions = true;
            this.SaveFileDialog.Title = "Save Captured Image";
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon1.BalloonTipTitle = "PrintScreen";
            this.NotifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Text = "PrintScreen";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1DoubleClick);
            this.NotifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureToolStripMenuItem,
            this.captureOtherScreenToolStripMenuItem,
            this.minimizeAllToolStripMenuItem,
            this.restoreAllToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(298, 308);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Crop_Icon1;
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.captureToolStripMenuItem.Text = "Capture Current Screen     PrnScr";
            this.captureToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // captureOtherScreenToolStripMenuItem
            // 
            this.captureOtherScreenToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Crop_Icon2;
            this.captureOtherScreenToolStripMenuItem.Name = "captureOtherScreenToolStripMenuItem";
            this.captureOtherScreenToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.captureOtherScreenToolStripMenuItem.Text = "Capture Other Screen";
            this.captureOtherScreenToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureClick2);
            // 
            // minimizeAllToolStripMenuItem
            // 
            this.minimizeAllToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Minimize1;
            this.minimizeAllToolStripMenuItem.Name = "minimizeAllToolStripMenuItem";
            this.minimizeAllToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.minimizeAllToolStripMenuItem.Text = "Minimize All";
            this.minimizeAllToolStripMenuItem.Visible = false;
            this.minimizeAllToolStripMenuItem.Click += new System.EventHandler(this.MinimizeAllToolStripMenuItemClick);
            // 
            // restoreAllToolStripMenuItem1
            // 
            this.restoreAllToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Restore_16x16;
            this.restoreAllToolStripMenuItem1.Name = "restoreAllToolStripMenuItem1";
            this.restoreAllToolStripMenuItem1.Size = new System.Drawing.Size(297, 26);
            this.restoreAllToolStripMenuItem1.Text = "Restore All";
            this.restoreAllToolStripMenuItem1.Visible = false;
            this.restoreAllToolStripMenuItem1.Click += new System.EventHandler(this.RestoreAllToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(294, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.CD;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.loadToolStripMenuItem.Text = "Load (Image or Project)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Project1_16x16;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.BtnSaveAllClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(294, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pinAllToolStripMenuItem,
            this.transparentAllToolStripMenuItem,
            this.playAllToolStripMenuItem,
            this.toolStripMenuItem3,
            this.optionsToolStripMenuItem1});
            this.toolsToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Tools_16x161;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // pinAllToolStripMenuItem
            // 
            this.pinAllToolStripMenuItem.CheckOnClick = true;
            this.pinAllToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.PinDown;
            this.pinAllToolStripMenuItem.Name = "pinAllToolStripMenuItem";
            this.pinAllToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.pinAllToolStripMenuItem.Text = "Pin All";
            this.pinAllToolStripMenuItem.CheckedChanged += new System.EventHandler(this.PinAllToolStripMenuItemCheckedChanged);
            // 
            // transparentAllToolStripMenuItem
            // 
            this.transparentAllToolStripMenuItem.CheckOnClick = true;
            this.transparentAllToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Transparent;
            this.transparentAllToolStripMenuItem.Name = "transparentAllToolStripMenuItem";
            this.transparentAllToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.transparentAllToolStripMenuItem.Text = "Transparent All";
            this.transparentAllToolStripMenuItem.CheckedChanged += new System.EventHandler(this.TransparentAllToolStripMenuItemCheckedChanged);
            // 
            // playAllToolStripMenuItem
            // 
            this.playAllToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Play;
            this.playAllToolStripMenuItem.Name = "playAllToolStripMenuItem";
            this.playAllToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.playAllToolStripMenuItem.Text = "Play All";
            this.playAllToolStripMenuItem.Click += new System.EventHandler(this.PlayAllToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Option1_16x16;
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(184, 26);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.BtnOptionsClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Option1_16x16;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Visible = false;
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.BtnOptionsClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Directions_16x16;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(294, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Hand_Print_Red_16x16;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.exclamation_16x16;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Navy;
            this.lblVersion.Location = new System.Drawing.Point(45, 68);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(104, 17);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version 1.0.0.6";
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.lblVersion.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(36, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 57);
            this.label4.TabIndex = 11;
            this.label4.Text = "PrintScreen";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.label4.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.label1.Location = new System.Drawing.Point(4, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(740, 108);
            this.label1.TabIndex = 4;
            this.label1.Text = "Press [Prt Scr] key to begin capture.\r\nClick and hold the start location, drag to" +
    " end location, and release the mouse button.\r\nPress [Enter] key to Crop, [Esc] t" +
    "o cancel  or right-click for the menu.";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.label1.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            // 
            // labelCopyright
            // 
            this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.ForeColor = System.Drawing.Color.Navy;
            this.labelCopyright.Location = new System.Drawing.Point(45, 213);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(183, 17);
            this.labelCopyright.TabIndex = 3;
            this.labelCopyright.Text = "Copyright © 2011 - by @TH";
            this.labelCopyright.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.labelCopyright.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.Honeydew;
            this.btnLoad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLoad.CornerRadius = 10;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.Image = global::FlexScreen.Properties.Resources.CD_32x32;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.Location = new System.Drawing.Point(496, 18);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 65);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "&Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCapture.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCapture.CornerRadius = 10;
            this.btnCapture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnCapture.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnCapture.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapture.Location = new System.Drawing.Point(388, 213);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.RoundCorners = FlexScreen.Corners.BottomLeft;
            this.btnCapture.Size = new System.Drawing.Size(100, 41);
            this.btnCapture.TabIndex = 12;
            this.btnCapture.Text = "&Capture";
            this.btnCapture.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Coral;
            this.btnClose.BorderColor = System.Drawing.Color.Red;
            this.btnClose.CornerRadius = 10;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::FlexScreen.Properties.Resources.exclamation_16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnClose.Location = new System.Drawing.Point(604, 213);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnClose.Size = new System.Drawing.Size(100, 41);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.BorderColor = System.Drawing.Color.Silver;
            this.btnMinimize.CornerRadius = 10;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMinimize.Image = global::FlexScreen.Properties.Resources.Minimize;
            this.btnMinimize.Location = new System.Drawing.Point(723, 4);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.RoundCorners = FlexScreen.Corners.TopRight;
            this.btnMinimize.Size = new System.Drawing.Size(21, 22);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimizeClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHelp.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnHelp.CornerRadius = 10;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnHelp.Image = global::FlexScreen.Properties.Resources.Directions_32x32;
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelp.Location = new System.Drawing.Point(604, 18);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RoundCorners = FlexScreen.Corners.TopRight;
            this.btnHelp.Size = new System.Drawing.Size(100, 65);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = " &Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelpClick);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.BackColor = System.Drawing.Color.Azure;
            this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOptions.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnOptions.CornerRadius = 10;
            this.btnOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptions.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnOptions.Image = global::FlexScreen.Properties.Resources.Options1_32x32;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOptions.Location = new System.Drawing.Point(388, 18);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(4);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.RoundCorners = FlexScreen.Corners.TopLeft;
            this.btnOptions.Size = new System.Drawing.Size(100, 65);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = " &Options";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOptions.Click += new System.EventHandler(this.BtnOptionsClick);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveAll.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSaveAll.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveAll.Location = new System.Drawing.Point(496, 213);
            this.btnSaveAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(100, 41);
            this.btnSaveAll.TabIndex = 14;
            this.btnSaveAll.Text = "&Save All";
            this.btnSaveAll.Click += new System.EventHandler(this.BtnSaveAllClick);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.MintCream;
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Location = new System.Drawing.Point(47, 230);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(332, 21);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Value = 50;
            this.progressBar1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "Zip";
            this.saveFileDialog1.Filter = "Zip Files|*.Zip|All Files|*.*";
            this.saveFileDialog1.FilterIndex = 0;
            this.saveFileDialog1.InitialDirectory = "Desktop";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "Save All";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*";
            this.openFileDialog1.Filter = resources.GetString("openFileDialog1.Filter");
            this.openFileDialog1.FilterIndex = 10;
            this.openFileDialog1.InitialDirectory = "Desktop";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "Select Image or Archive File";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 268);
            this.ControlBox = false;
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.labelCopyright);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintScreen";
            this.Activated += new System.EventHandler(this.SplashScreenActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreenFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.LocationChanged += new System.EventHandler(this.SplashScreenLocationChanged);
            this.SizeChanged += new System.EventHandler(this.SplashScreenLocationChanged);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.SplashScreenHelpRequested);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label label1;
        private CustomButton btnHelp;
        private CustomButton btnOptions;
        private CustomButton btnClose;
        private CustomButton btnMinimize;
        private System.Windows.Forms.Label label4;
        private CustomButton btnCapture;
        private CustomButton btnLoad;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon NotifyIcon1;
        private CustomButton btnSaveAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ProgressBarEx progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem minimizeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem playAllToolStripMenuItem;
        private ToolStripMenuItem captureOtherScreenToolStripMenuItem;
        private ToolStripMenuItem restoreAllToolStripMenuItem1;

    }
}

