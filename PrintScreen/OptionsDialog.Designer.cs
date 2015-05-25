using System.Drawing;
using FlexScreen.Properties;

namespace FlexScreen
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CursorArea = new System.Windows.Forms.GroupBox();
            this.nudSelectionOpacity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudCursorOpacity = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSelectionColor = new System.Windows.Forms.Button();
            this.btnCursorColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAutomaticallyCrop = new System.Windows.Forms.CheckBox();
            this.cbImageBorder = new System.Windows.Forms.CheckBox();
            this.cbKeepMenuOn = new System.Windows.Forms.CheckBox();
            this.nudTransparency = new System.Windows.Forms.NumericUpDown();
            this.cbTransparent = new System.Windows.Forms.CheckBox();
            this.cbOnTop = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAutoSaveAsk = new System.Windows.Forms.CheckBox();
            this.cbAutoSave = new System.Windows.Forms.CheckBox();
            this.cbApplyToAll = new System.Windows.Forms.CheckBox();
            this.cbTurnOnTips = new System.Windows.Forms.CheckBox();
            this.cbCaptureFromTryIcon = new System.Windows.Forms.CheckBox();
            this.cbStartSysEditor = new System.Windows.Forms.CheckBox();
            this.cbSuppresStartUpHelp = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTextWhiteBorder = new System.Windows.Forms.CheckBox();
            this.FontSample = new System.Windows.Forms.Button();
            this.numLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudFillTransparency = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnLinesColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new FlexScreen.CustomButton();
            this.btnOK = new FlexScreen.CustomButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOpenFolder = new FlexScreen.CustomButton();
            this.CursorArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCursorOpacity)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransparency)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(91, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 39);
            this.label8.TabIndex = 9;
            this.label8.Text = "Options";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.label8.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FlexScreen.Properties.Resources.Options1_32x32;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(20, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 32);
            this.panel1.TabIndex = 14;
            this.toolTip1.SetToolTip(this.panel1, "Double-Click to open Explorer,\r\nthen Paste folder path");
            this.panel1.DoubleClick += new System.EventHandler(this.FolderImage_DoubleClick);
            // 
            // CursorArea
            // 
            this.CursorArea.BackColor = System.Drawing.Color.Transparent;
            this.CursorArea.Controls.Add(this.nudSelectionOpacity);
            this.CursorArea.Controls.Add(this.label10);
            this.CursorArea.Controls.Add(this.nudCursorOpacity);
            this.CursorArea.Controls.Add(this.label9);
            this.CursorArea.Controls.Add(this.btnSelectionColor);
            this.CursorArea.Controls.Add(this.btnCursorColor);
            this.CursorArea.Controls.Add(this.label2);
            this.CursorArea.Controls.Add(this.label1);
            this.CursorArea.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CursorArea.Location = new System.Drawing.Point(20, 51);
            this.CursorArea.Name = "CursorArea";
            this.CursorArea.Size = new System.Drawing.Size(267, 69);
            this.CursorArea.TabIndex = 2;
            this.CursorArea.TabStop = false;
            this.CursorArea.Text = "Cursor";
            this.CursorArea.Enter += new System.EventHandler(this.GroupBox1Enter);
            this.CursorArea.Leave += new System.EventHandler(this.GroupBox1Leave);
            this.CursorArea.MouseHover += new System.EventHandler(this.GroupBox1Enter);
            // 
            // nudSelectionOpacity
            // 
            this.nudSelectionOpacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudSelectionOpacity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudSelectionOpacity.Location = new System.Drawing.Point(201, 43);
            this.nudSelectionOpacity.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudSelectionOpacity.Name = "nudSelectionOpacity";
            this.nudSelectionOpacity.Size = new System.Drawing.Size(54, 20);
            this.nudSelectionOpacity.TabIndex = 16;
            this.nudSelectionOpacity.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(121, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Opacity";
            // 
            // nudCursorOpacity
            // 
            this.nudCursorOpacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudCursorOpacity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudCursorOpacity.Location = new System.Drawing.Point(201, 17);
            this.nudCursorOpacity.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudCursorOpacity.Name = "nudCursorOpacity";
            this.nudCursorOpacity.Size = new System.Drawing.Size(54, 20);
            this.nudCursorOpacity.TabIndex = 14;
            this.nudCursorOpacity.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(121, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Opacity";
            // 
            // btnSelectionColor
            // 
            this.btnSelectionColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectionColor.BackColor = System.Drawing.Color.Black;
            this.btnSelectionColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectionColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectionColor.Location = new System.Drawing.Point(78, 45);
            this.btnSelectionColor.Name = "btnSelectionColor";
            this.btnSelectionColor.Size = new System.Drawing.Size(35, 13);
            this.btnSelectionColor.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnSelectionColor, "Click to change");
            this.btnSelectionColor.UseVisualStyleBackColor = false;
            this.btnSelectionColor.Click += new System.EventHandler(this.BtnSelectionColorClick);
            // 
            // btnCursorColor
            // 
            this.btnCursorColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCursorColor.BackColor = System.Drawing.Color.Black;
            this.btnCursorColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCursorColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCursorColor.Location = new System.Drawing.Point(79, 19);
            this.btnCursorColor.Name = "btnCursorColor";
            this.btnCursorColor.Size = new System.Drawing.Size(35, 13);
            this.btnCursorColor.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnCursorColor, "Click to change");
            this.btnCursorColor.UseVisualStyleBackColor = false;
            this.btnCursorColor.Click += new System.EventHandler(this.BtnCursorColorClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selection";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cursor Color";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbAutomaticallyCrop);
            this.groupBox1.Controls.Add(this.cbImageBorder);
            this.groupBox1.Controls.Add(this.cbKeepMenuOn);
            this.groupBox1.Controls.Add(this.nudTransparency);
            this.groupBox1.Controls.Add(this.cbTransparent);
            this.groupBox1.Controls.Add(this.cbOnTop);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(293, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Window";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1Enter);
            this.groupBox1.Leave += new System.EventHandler(this.GroupBox1Leave);
            // 
            // cbAutomaticallyCrop
            // 
            this.cbAutomaticallyCrop.AutoSize = true;
            this.cbAutomaticallyCrop.BackColor = System.Drawing.Color.Transparent;
            this.cbAutomaticallyCrop.Checked = true;
            this.cbAutomaticallyCrop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutomaticallyCrop.ForeColor = System.Drawing.Color.Black;
            this.cbAutomaticallyCrop.Location = new System.Drawing.Point(9, 22);
            this.cbAutomaticallyCrop.Name = "cbAutomaticallyCrop";
            this.cbAutomaticallyCrop.Size = new System.Drawing.Size(228, 17);
            this.cbAutomaticallyCrop.TabIndex = 19;
            this.cbAutomaticallyCrop.Text = global::FlexScreen.Properties.Resources.AutomaticallyCrop;
            this.cbAutomaticallyCrop.UseVisualStyleBackColor = false;
            // 
            // cbImageBorder
            // 
            this.cbImageBorder.AutoSize = true;
            this.cbImageBorder.BackColor = System.Drawing.Color.Transparent;
            this.cbImageBorder.ForeColor = System.Drawing.Color.Black;
            this.cbImageBorder.Location = new System.Drawing.Point(9, 114);
            this.cbImageBorder.Name = "cbImageBorder";
            this.cbImageBorder.Size = new System.Drawing.Size(168, 17);
            this.cbImageBorder.TabIndex = 18;
            this.cbImageBorder.Text = global::FlexScreen.Properties.Resources.AddBorderToPastedImages;
            this.cbImageBorder.UseVisualStyleBackColor = false;
            // 
            // cbKeepMenuOn
            // 
            this.cbKeepMenuOn.AutoSize = true;
            this.cbKeepMenuOn.Checked = true;
            this.cbKeepMenuOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepMenuOn.ForeColor = System.Drawing.Color.Black;
            this.cbKeepMenuOn.Location = new System.Drawing.Point(9, 91);
            this.cbKeepMenuOn.Name = "cbKeepMenuOn";
            this.cbKeepMenuOn.Size = new System.Drawing.Size(98, 17);
            this.cbKeepMenuOn.TabIndex = 17;
            this.cbKeepMenuOn.Text = global::FlexScreen.Properties.Resources.KeepMenuOn;
            this.cbKeepMenuOn.UseVisualStyleBackColor = true;
            // 
            // nudTransparency
            // 
            this.nudTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTransparency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudTransparency.Location = new System.Drawing.Point(198, 68);
            this.nudTransparency.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudTransparency.Name = "nudTransparency";
            this.nudTransparency.Size = new System.Drawing.Size(53, 20);
            this.nudTransparency.TabIndex = 2;
            this.nudTransparency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // cbTransparent
            // 
            this.cbTransparent.AutoSize = true;
            this.cbTransparent.BackColor = System.Drawing.Color.Transparent;
            this.cbTransparent.Checked = true;
            this.cbTransparent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTransparent.ForeColor = System.Drawing.Color.Black;
            this.cbTransparent.Location = new System.Drawing.Point(9, 68);
            this.cbTransparent.Name = "cbTransparent";
            this.cbTransparent.Size = new System.Drawing.Size(179, 17);
            this.cbTransparent.TabIndex = 1;
            this.cbTransparent.Text = global::FlexScreen.Properties.Resources.TransparentWhenNotFocused;
            this.cbTransparent.UseVisualStyleBackColor = false;
            // 
            // cbOnTop
            // 
            this.cbOnTop.AutoSize = true;
            this.cbOnTop.BackColor = System.Drawing.Color.Transparent;
            this.cbOnTop.ForeColor = System.Drawing.Color.Black;
            this.cbOnTop.Location = new System.Drawing.Point(9, 45);
            this.cbOnTop.Name = "cbOnTop";
            this.cbOnTop.Size = new System.Drawing.Size(154, 17);
            this.cbOnTop.TabIndex = 0;
            this.cbOnTop.Text = global::FlexScreen.Properties.Resources.AfterCaptureStayOnTop;
            this.cbOnTop.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cbAutoSaveAsk);
            this.groupBox3.Controls.Add(this.cbAutoSave);
            this.groupBox3.Controls.Add(this.cbApplyToAll);
            this.groupBox3.Controls.Add(this.cbTurnOnTips);
            this.groupBox3.Controls.Add(this.cbCaptureFromTryIcon);
            this.groupBox3.Controls.Add(this.cbStartSysEditor);
            this.groupBox3.Controls.Add(this.cbSuppresStartUpHelp);
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(293, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 160);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Others";
            this.groupBox3.Enter += new System.EventHandler(this.GroupBox1Enter);
            this.groupBox3.Leave += new System.EventHandler(this.GroupBox1Leave);
            // 
            // cbAutoSaveAsk
            // 
            this.cbAutoSaveAsk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoSaveAsk.AutoSize = true;
            this.cbAutoSaveAsk.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoSaveAsk.ForeColor = System.Drawing.Color.Black;
            this.cbAutoSaveAsk.Location = new System.Drawing.Point(207, 134);
            this.cbAutoSaveAsk.Name = "cbAutoSaveAsk";
            this.cbAutoSaveAsk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAutoSaveAsk.Size = new System.Drawing.Size(44, 17);
            this.cbAutoSaveAsk.TabIndex = 20;
            this.cbAutoSaveAsk.Text = "Ask";
            this.cbAutoSaveAsk.UseVisualStyleBackColor = false;
            this.cbAutoSaveAsk.Visible = false;
            // 
            // cbAutoSave
            // 
            this.cbAutoSave.AutoSize = true;
            this.cbAutoSave.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoSave.ForeColor = System.Drawing.Color.Black;
            this.cbAutoSave.Location = new System.Drawing.Point(9, 134);
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.Size = new System.Drawing.Size(153, 17);
            this.cbAutoSave.TabIndex = 19;
            this.cbAutoSave.Text = "Auto Save/Restore project";
            this.cbAutoSave.UseVisualStyleBackColor = false;
            this.cbAutoSave.CheckedChanged += new System.EventHandler(this.CbAutoSaveCheckedChanged);
            // 
            // cbApplyToAll
            // 
            this.cbApplyToAll.AutoSize = true;
            this.cbApplyToAll.BackColor = System.Drawing.Color.Transparent;
            this.cbApplyToAll.ForeColor = System.Drawing.Color.Black;
            this.cbApplyToAll.Location = new System.Drawing.Point(9, 111);
            this.cbApplyToAll.Name = "cbApplyToAll";
            this.cbApplyToAll.Size = new System.Drawing.Size(78, 17);
            this.cbApplyToAll.TabIndex = 18;
            this.cbApplyToAll.Text = "Apply to All";
            this.cbApplyToAll.UseVisualStyleBackColor = false;
            // 
            // cbTurnOnTips
            // 
            this.cbTurnOnTips.AutoSize = true;
            this.cbTurnOnTips.BackColor = System.Drawing.Color.Transparent;
            this.cbTurnOnTips.Checked = true;
            this.cbTurnOnTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTurnOnTips.ForeColor = System.Drawing.Color.Black;
            this.cbTurnOnTips.Location = new System.Drawing.Point(9, 17);
            this.cbTurnOnTips.Name = "cbTurnOnTips";
            this.cbTurnOnTips.Size = new System.Drawing.Size(154, 17);
            this.cbTurnOnTips.TabIndex = 17;
            this.cbTurnOnTips.Text = "Turn On Drawing Tool Tips";
            this.cbTurnOnTips.UseVisualStyleBackColor = false;
            // 
            // cbCaptureFromTryIcon
            // 
            this.cbCaptureFromTryIcon.AutoSize = true;
            this.cbCaptureFromTryIcon.BackColor = System.Drawing.Color.Transparent;
            this.cbCaptureFromTryIcon.Checked = true;
            this.cbCaptureFromTryIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaptureFromTryIcon.ForeColor = System.Drawing.Color.Black;
            this.cbCaptureFromTryIcon.Location = new System.Drawing.Point(9, 65);
            this.cbCaptureFromTryIcon.Name = "cbCaptureFromTryIcon";
            this.cbCaptureFromTryIcon.Size = new System.Drawing.Size(196, 17);
            this.cbCaptureFromTryIcon.TabIndex = 16;
            this.cbCaptureFromTryIcon.Text = "Start Capture On Click On Trey Icon";
            this.cbCaptureFromTryIcon.UseVisualStyleBackColor = false;
            // 
            // cbStartSysEditor
            // 
            this.cbStartSysEditor.AutoSize = true;
            this.cbStartSysEditor.ForeColor = System.Drawing.Color.Black;
            this.cbStartSysEditor.Location = new System.Drawing.Point(9, 42);
            this.cbStartSysEditor.Name = "cbStartSysEditor";
            this.cbStartSysEditor.Size = new System.Drawing.Size(193, 17);
            this.cbStartSysEditor.TabIndex = 15;
            this.cbStartSysEditor.Text = "After Save, Start The System Editor";
            this.cbStartSysEditor.UseVisualStyleBackColor = true;
            // 
            // cbSuppresStartUpHelp
            // 
            this.cbSuppresStartUpHelp.AutoSize = true;
            this.cbSuppresStartUpHelp.BackColor = System.Drawing.Color.Transparent;
            this.cbSuppresStartUpHelp.ForeColor = System.Drawing.Color.Black;
            this.cbSuppresStartUpHelp.Location = new System.Drawing.Point(9, 88);
            this.cbSuppresStartUpHelp.Name = "cbSuppresStartUpHelp";
            this.cbSuppresStartUpHelp.Size = new System.Drawing.Size(134, 17);
            this.cbSuppresStartUpHelp.TabIndex = 14;
            this.cbSuppresStartUpHelp.Text = "Suppress StartUp Help";
            this.cbSuppresStartUpHelp.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbTextWhiteBorder);
            this.groupBox2.Controls.Add(this.FontSample);
            this.groupBox2.Controls.Add(this.numLineWidth);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudFillTransparency);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnFillColor);
            this.groupBox2.Controls.Add(this.btnLinesColor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(20, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 202);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Default Tool Styles";
            this.groupBox2.Enter += new System.EventHandler(this.GroupBox1Enter);
            this.groupBox2.Leave += new System.EventHandler(this.GroupBox1Leave);
            // 
            // cbTextWhiteBorder
            // 
            this.cbTextWhiteBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTextWhiteBorder.AutoSize = true;
            this.cbTextWhiteBorder.BackColor = System.Drawing.Color.Transparent;
            this.cbTextWhiteBorder.Checked = true;
            this.cbTextWhiteBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTextWhiteBorder.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.cbTextWhiteBorder.ForeColor = System.Drawing.Color.Black;
            this.cbTextWhiteBorder.Location = new System.Drawing.Point(79, 65);
            this.cbTextWhiteBorder.Name = "cbTextWhiteBorder";
            this.cbTextWhiteBorder.Size = new System.Drawing.Size(88, 17);
            this.cbTextWhiteBorder.TabIndex = 19;
            this.cbTextWhiteBorder.Text = global::FlexScreen.Properties.Resources.WhiteBorder;
            this.cbTextWhiteBorder.UseVisualStyleBackColor = false;
            this.cbTextWhiteBorder.CheckedChanged += new System.EventHandler(this.CbTextWhiteBorderCheckedChanged);
            // 
            // FontSample
            // 
            this.FontSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(30)))));
            this.FontSample.BackgroundImage = global::FlexScreen.Properties.Resources.Square_Tilled;
            this.FontSample.CausesValidation = false;
            this.FontSample.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FontSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontSample.Location = new System.Drawing.Point(10, 88);
            this.FontSample.Name = "FontSample";
            this.FontSample.Size = new System.Drawing.Size(247, 105);
            this.FontSample.TabIndex = 18;
            this.FontSample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FontSample.UseVisualStyleBackColor = false;
            this.FontSample.Click += new System.EventHandler(this.btnTextFont_Click);
            this.FontSample.Paint += new System.Windows.Forms.PaintEventHandler(this.FontSamplePaint);
            // 
            // numLineWidth
            // 
            this.numLineWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numLineWidth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numLineWidth.Location = new System.Drawing.Point(203, 16);
            this.numLineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.Size = new System.Drawing.Size(54, 20);
            this.numLineWidth.TabIndex = 17;
            this.numLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(121, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Text Font";
            // 
            // nudFillTransparency
            // 
            this.nudFillTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFillTransparency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudFillTransparency.Location = new System.Drawing.Point(203, 41);
            this.nudFillTransparency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFillTransparency.Name = "nudFillTransparency";
            this.nudFillTransparency.Size = new System.Drawing.Size(54, 20);
            this.nudFillTransparency.TabIndex = 12;
            this.nudFillTransparency.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(121, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Transparency";
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFillColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFillColor.Location = new System.Drawing.Point(79, 43);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(35, 13);
            this.btnFillColor.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnFillColor, "Click to change");
            this.btnFillColor.UseVisualStyleBackColor = false;
            this.btnFillColor.Click += new System.EventHandler(this.BtnFillColorClick);
            // 
            // btnLinesColor
            // 
            this.btnLinesColor.BackColor = System.Drawing.Color.Red;
            this.btnLinesColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinesColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLinesColor.Location = new System.Drawing.Point(79, 18);
            this.btnLinesColor.Name = "btnLinesColor";
            this.btnLinesColor.Size = new System.Drawing.Size(35, 13);
            this.btnLinesColor.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnLinesColor, "Click to change");
            this.btnLinesColor.UseVisualStyleBackColor = false;
            this.btnLinesColor.Click += new System.EventHandler(this.BtnLinesColorClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fill Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lines Color";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.Brown;
            this.btnCancel.Location = new System.Drawing.Point(491, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnCancel.Size = new System.Drawing.Size(62, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Honeydew;
            this.btnOK.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnOK.Location = new System.Drawing.Point(293, 334);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(192, 31);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFolder.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFolder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnOpenFolder.Location = new System.Drawing.Point(20, 334);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.RoundCorners = FlexScreen.Corners.BottomLeft;
            this.btnOpenFolder.Size = new System.Drawing.Size(267, 31);
            this.btnOpenFolder.TabIndex = 15;
            this.btnOpenFolder.Text = "Open Options File Folder (Path to Clipboard)";
            this.btnOpenFolder.Click += new System.EventHandler(this.FolderImage_DoubleClick);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlexScreen.Properties.Resources.BackgroundGray1;
            this.ClientSize = new System.Drawing.Size(574, 379);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CursorArea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsDialog";
            this.Opacity = 0.98D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.OptionsDialog_Activated);
            this.Load += new System.EventHandler(this.OptionsDialogLoad);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.OptionsDialogHelpRequested);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MouseLeave += new System.EventHandler(this.FormMouseLeave);
            this.CursorArea.ResumeLayout(false);
            this.CursorArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCursorOpacity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransparency)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillTransparency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton btnOK;
        private CustomButton btnCancel;
        private System.Windows.Forms.GroupBox CursorArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectionColor;
        private System.Windows.Forms.Button btnCursorColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudFillTransparency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Button btnLinesColor;
        private System.Windows.Forms.NumericUpDown numLineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button FontSample;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudTransparency;
        private System.Windows.Forms.CheckBox cbTransparent;
        private System.Windows.Forms.CheckBox cbOnTop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbSuppresStartUpHelp;
        private System.Windows.Forms.CheckBox cbStartSysEditor;
        private System.Windows.Forms.CheckBox cbKeepMenuOn;
        private System.Windows.Forms.CheckBox cbImageBorder;
        private System.Windows.Forms.CheckBox cbCaptureFromTryIcon;
        private System.Windows.Forms.CheckBox cbAutomaticallyCrop;
        public System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox cbTextWhiteBorder;
        private System.Windows.Forms.CheckBox cbTurnOnTips;
        private System.Windows.Forms.CheckBox cbApplyToAll;
        private System.Windows.Forms.CheckBox cbAutoSave;
        private System.Windows.Forms.CheckBox cbAutoSaveAsk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nudSelectionOpacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudCursorOpacity;
        private System.Windows.Forms.Label label9;
        private CustomButton btnOpenFolder;
    }
}