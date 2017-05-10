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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(19, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 48);
            this.label8.TabIndex = 9;
            this.label8.Text = "Options";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.label8.MouseLeave += new System.EventHandler(this.FormMouseLeave);
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
            this.CursorArea.Location = new System.Drawing.Point(27, 63);
            this.CursorArea.Margin = new System.Windows.Forms.Padding(4);
            this.CursorArea.Name = "CursorArea";
            this.CursorArea.Padding = new System.Windows.Forms.Padding(4);
            this.CursorArea.Size = new System.Drawing.Size(356, 85);
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
            this.nudSelectionOpacity.Location = new System.Drawing.Point(268, 53);
            this.nudSelectionOpacity.Margin = new System.Windows.Forms.Padding(4);
            this.nudSelectionOpacity.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudSelectionOpacity.Name = "nudSelectionOpacity";
            this.nudSelectionOpacity.Size = new System.Drawing.Size(72, 22);
            this.nudSelectionOpacity.TabIndex = 16;
            this.nudSelectionOpacity.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudSelectionOpacity.ValueChanged += new System.EventHandler(this.nudSelectionOpacity_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(161, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Opacity";
            // 
            // nudCursorOpacity
            // 
            this.nudCursorOpacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudCursorOpacity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudCursorOpacity.Location = new System.Drawing.Point(268, 21);
            this.nudCursorOpacity.Margin = new System.Windows.Forms.Padding(4);
            this.nudCursorOpacity.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudCursorOpacity.Name = "nudCursorOpacity";
            this.nudCursorOpacity.Size = new System.Drawing.Size(72, 22);
            this.nudCursorOpacity.TabIndex = 14;
            this.nudCursorOpacity.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudCursorOpacity.ValueChanged += new System.EventHandler(this.nudCursorOpacity_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(161, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Opacity";
            // 
            // btnSelectionColor
            // 
            this.btnSelectionColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectionColor.BackColor = System.Drawing.Color.Black;
            this.btnSelectionColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectionColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectionColor.Location = new System.Drawing.Point(104, 55);
            this.btnSelectionColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectionColor.Name = "btnSelectionColor";
            this.btnSelectionColor.Size = new System.Drawing.Size(47, 16);
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
            this.btnCursorColor.Location = new System.Drawing.Point(105, 23);
            this.btnCursorColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursorColor.Name = "btnCursorColor";
            this.btnCursorColor.Size = new System.Drawing.Size(47, 16);
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
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selection";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
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
            this.groupBox1.Location = new System.Drawing.Point(391, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(347, 185);
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
            this.cbAutomaticallyCrop.Location = new System.Drawing.Point(12, 27);
            this.cbAutomaticallyCrop.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutomaticallyCrop.Name = "cbAutomaticallyCrop";
            this.cbAutomaticallyCrop.Size = new System.Drawing.Size(298, 21);
            this.cbAutomaticallyCrop.TabIndex = 19;
            this.cbAutomaticallyCrop.Text = global::FlexScreen.Properties.Resources.AutomaticallyCrop;
            this.cbAutomaticallyCrop.UseVisualStyleBackColor = false;
            this.cbAutomaticallyCrop.CheckedChanged += new System.EventHandler(this.cbAutomaticallyCrop_CheckedChanged);
            // 
            // cbImageBorder
            // 
            this.cbImageBorder.AutoSize = true;
            this.cbImageBorder.BackColor = System.Drawing.Color.Transparent;
            this.cbImageBorder.ForeColor = System.Drawing.Color.Black;
            this.cbImageBorder.Location = new System.Drawing.Point(12, 140);
            this.cbImageBorder.Margin = new System.Windows.Forms.Padding(4);
            this.cbImageBorder.Name = "cbImageBorder";
            this.cbImageBorder.Size = new System.Drawing.Size(220, 21);
            this.cbImageBorder.TabIndex = 18;
            this.cbImageBorder.Text = global::FlexScreen.Properties.Resources.AddBorderToPastedImages;
            this.cbImageBorder.UseVisualStyleBackColor = false;
            this.cbImageBorder.CheckedChanged += new System.EventHandler(this.cbImageBorder_CheckedChanged);
            // 
            // cbKeepMenuOn
            // 
            this.cbKeepMenuOn.AutoSize = true;
            this.cbKeepMenuOn.Checked = true;
            this.cbKeepMenuOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepMenuOn.ForeColor = System.Drawing.Color.Black;
            this.cbKeepMenuOn.Location = new System.Drawing.Point(12, 112);
            this.cbKeepMenuOn.Margin = new System.Windows.Forms.Padding(4);
            this.cbKeepMenuOn.Name = "cbKeepMenuOn";
            this.cbKeepMenuOn.Size = new System.Drawing.Size(125, 21);
            this.cbKeepMenuOn.TabIndex = 17;
            this.cbKeepMenuOn.Text = global::FlexScreen.Properties.Resources.KeepMenuOn;
            this.cbKeepMenuOn.UseVisualStyleBackColor = true;
            this.cbKeepMenuOn.CheckedChanged += new System.EventHandler(this.cbKeepMenuOn_CheckedChanged);
            // 
            // nudTransparency
            // 
            this.nudTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTransparency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudTransparency.Location = new System.Drawing.Point(264, 84);
            this.nudTransparency.Margin = new System.Windows.Forms.Padding(4);
            this.nudTransparency.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudTransparency.Name = "nudTransparency";
            this.nudTransparency.Size = new System.Drawing.Size(71, 22);
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
            this.cbTransparent.Location = new System.Drawing.Point(12, 84);
            this.cbTransparent.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransparent.Name = "cbTransparent";
            this.cbTransparent.Size = new System.Drawing.Size(233, 21);
            this.cbTransparent.TabIndex = 1;
            this.cbTransparent.Text = global::FlexScreen.Properties.Resources.TransparentWhenNotFocused;
            this.cbTransparent.UseVisualStyleBackColor = false;
            this.cbTransparent.CheckedChanged += new System.EventHandler(this.cbTransparent_CheckedChanged);
            // 
            // cbOnTop
            // 
            this.cbOnTop.AutoSize = true;
            this.cbOnTop.BackColor = System.Drawing.Color.Transparent;
            this.cbOnTop.ForeColor = System.Drawing.Color.Black;
            this.cbOnTop.Location = new System.Drawing.Point(12, 55);
            this.cbOnTop.Margin = new System.Windows.Forms.Padding(4);
            this.cbOnTop.Name = "cbOnTop";
            this.cbOnTop.Size = new System.Drawing.Size(202, 21);
            this.cbOnTop.TabIndex = 0;
            this.cbOnTop.Text = global::FlexScreen.Properties.Resources.AfterCaptureStayOnTop;
            this.cbOnTop.UseVisualStyleBackColor = false;
            this.cbOnTop.CheckedChanged += new System.EventHandler(this.cbOnTop_CheckedChanged);
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
            this.groupBox3.Location = new System.Drawing.Point(391, 207);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(347, 197);
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
            this.cbAutoSaveAsk.Location = new System.Drawing.Point(282, 165);
            this.cbAutoSaveAsk.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoSaveAsk.Name = "cbAutoSaveAsk";
            this.cbAutoSaveAsk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAutoSaveAsk.Size = new System.Drawing.Size(53, 21);
            this.cbAutoSaveAsk.TabIndex = 20;
            this.cbAutoSaveAsk.Text = "Ask";
            this.cbAutoSaveAsk.UseVisualStyleBackColor = false;
            this.cbAutoSaveAsk.Visible = false;
            this.cbAutoSaveAsk.CheckedChanged += new System.EventHandler(this.cbAutoSaveAsk_CheckedChanged);
            // 
            // cbAutoSave
            // 
            this.cbAutoSave.AutoSize = true;
            this.cbAutoSave.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoSave.ForeColor = System.Drawing.Color.Black;
            this.cbAutoSave.Location = new System.Drawing.Point(12, 165);
            this.cbAutoSave.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.Size = new System.Drawing.Size(196, 21);
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
            this.cbApplyToAll.Location = new System.Drawing.Point(12, 137);
            this.cbApplyToAll.Margin = new System.Windows.Forms.Padding(4);
            this.cbApplyToAll.Name = "cbApplyToAll";
            this.cbApplyToAll.Size = new System.Drawing.Size(306, 21);
            this.cbApplyToAll.TabIndex = 18;
            this.cbApplyToAll.Text = "Apply to All (Transparency and StayOnTop)";
            this.cbApplyToAll.UseVisualStyleBackColor = false;
            this.cbApplyToAll.CheckedChanged += new System.EventHandler(this.cbApplyToAll_CheckedChanged);
            // 
            // cbTurnOnTips
            // 
            this.cbTurnOnTips.AutoSize = true;
            this.cbTurnOnTips.BackColor = System.Drawing.Color.Transparent;
            this.cbTurnOnTips.Checked = true;
            this.cbTurnOnTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTurnOnTips.ForeColor = System.Drawing.Color.Black;
            this.cbTurnOnTips.Location = new System.Drawing.Point(12, 21);
            this.cbTurnOnTips.Margin = new System.Windows.Forms.Padding(4);
            this.cbTurnOnTips.Name = "cbTurnOnTips";
            this.cbTurnOnTips.Size = new System.Drawing.Size(201, 21);
            this.cbTurnOnTips.TabIndex = 17;
            this.cbTurnOnTips.Text = "Turn On Drawing Tool Tips";
            this.cbTurnOnTips.UseVisualStyleBackColor = false;
            this.cbTurnOnTips.CheckedChanged += new System.EventHandler(this.cbTurnOnTips_CheckedChanged);
            // 
            // cbCaptureFromTryIcon
            // 
            this.cbCaptureFromTryIcon.AutoSize = true;
            this.cbCaptureFromTryIcon.BackColor = System.Drawing.Color.Transparent;
            this.cbCaptureFromTryIcon.Checked = true;
            this.cbCaptureFromTryIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaptureFromTryIcon.ForeColor = System.Drawing.Color.Black;
            this.cbCaptureFromTryIcon.Location = new System.Drawing.Point(12, 80);
            this.cbCaptureFromTryIcon.Margin = new System.Windows.Forms.Padding(4);
            this.cbCaptureFromTryIcon.Name = "cbCaptureFromTryIcon";
            this.cbCaptureFromTryIcon.Size = new System.Drawing.Size(256, 21);
            this.cbCaptureFromTryIcon.TabIndex = 16;
            this.cbCaptureFromTryIcon.Text = "Start Capture On Click On Trey Icon";
            this.cbCaptureFromTryIcon.UseVisualStyleBackColor = false;
            // 
            // cbStartSysEditor
            // 
            this.cbStartSysEditor.AutoSize = true;
            this.cbStartSysEditor.ForeColor = System.Drawing.Color.Black;
            this.cbStartSysEditor.Location = new System.Drawing.Point(12, 52);
            this.cbStartSysEditor.Margin = new System.Windows.Forms.Padding(4);
            this.cbStartSysEditor.Name = "cbStartSysEditor";
            this.cbStartSysEditor.Size = new System.Drawing.Size(254, 21);
            this.cbStartSysEditor.TabIndex = 15;
            this.cbStartSysEditor.Text = "After Save, Start The System Editor";
            this.cbStartSysEditor.UseVisualStyleBackColor = true;
            this.cbStartSysEditor.CheckedChanged += new System.EventHandler(this.cbStartSysEditor_CheckedChanged);
            // 
            // cbSuppresStartUpHelp
            // 
            this.cbSuppresStartUpHelp.AutoSize = true;
            this.cbSuppresStartUpHelp.BackColor = System.Drawing.Color.Transparent;
            this.cbSuppresStartUpHelp.ForeColor = System.Drawing.Color.Black;
            this.cbSuppresStartUpHelp.Location = new System.Drawing.Point(12, 108);
            this.cbSuppresStartUpHelp.Margin = new System.Windows.Forms.Padding(4);
            this.cbSuppresStartUpHelp.Name = "cbSuppresStartUpHelp";
            this.cbSuppresStartUpHelp.Size = new System.Drawing.Size(175, 21);
            this.cbSuppresStartUpHelp.TabIndex = 14;
            this.cbSuppresStartUpHelp.Text = "Suppress StartUp Help";
            this.cbSuppresStartUpHelp.UseVisualStyleBackColor = false;
            this.cbSuppresStartUpHelp.CheckedChanged += new System.EventHandler(this.cbSuppresStartUpHelp_CheckedChanged);
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
            this.groupBox2.Location = new System.Drawing.Point(27, 155);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(356, 298);
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
            this.cbTextWhiteBorder.Location = new System.Drawing.Point(110, 80);
            this.cbTextWhiteBorder.Margin = new System.Windows.Forms.Padding(4);
            this.cbTextWhiteBorder.Name = "cbTextWhiteBorder";
            this.cbTextWhiteBorder.Size = new System.Drawing.Size(113, 21);
            this.cbTextWhiteBorder.TabIndex = 19;
            this.cbTextWhiteBorder.Text = global::FlexScreen.Properties.Resources.WhiteBorder;
            this.cbTextWhiteBorder.UseVisualStyleBackColor = false;
            this.cbTextWhiteBorder.CheckedChanged += new System.EventHandler(this.CbTextWithBorderCheckedChanged);
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
            this.FontSample.Location = new System.Drawing.Point(13, 108);
            this.FontSample.Margin = new System.Windows.Forms.Padding(4);
            this.FontSample.Name = "FontSample";
            this.FontSample.Size = new System.Drawing.Size(329, 178);
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
            this.numLineWidth.Location = new System.Drawing.Point(271, 20);
            this.numLineWidth.Margin = new System.Windows.Forms.Padding(4);
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
            this.numLineWidth.Size = new System.Drawing.Size(72, 22);
            this.numLineWidth.TabIndex = 17;
            this.numLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLineWidth.ValueChanged += new System.EventHandler(this.numLineWidth_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(161, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Text Font";
            // 
            // nudFillTransparency
            // 
            this.nudFillTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFillTransparency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudFillTransparency.Location = new System.Drawing.Point(271, 50);
            this.nudFillTransparency.Margin = new System.Windows.Forms.Padding(4);
            this.nudFillTransparency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFillTransparency.Name = "nudFillTransparency";
            this.nudFillTransparency.Size = new System.Drawing.Size(72, 22);
            this.nudFillTransparency.TabIndex = 12;
            this.nudFillTransparency.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFillTransparency.ValueChanged += new System.EventHandler(this.nudFillTransparency_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(161, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Transparency";
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFillColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFillColor.Location = new System.Drawing.Point(105, 53);
            this.btnFillColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(47, 16);
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
            this.btnLinesColor.Location = new System.Drawing.Point(105, 22);
            this.btnLinesColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnLinesColor.Name = "btnLinesColor";
            this.btnLinesColor.Size = new System.Drawing.Size(47, 16);
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
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fill Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
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
            this.btnCancel.Location = new System.Drawing.Point(403, 415);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnCancel.Size = new System.Drawing.Size(347, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close (Is Saved!)";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlexScreen.Properties.Resources.BackgroundGray1;
            this.ClientSize = new System.Drawing.Size(765, 466);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CursorArea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionsDialog";
            this.Opacity = 0.98D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nudSelectionOpacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudCursorOpacity;
        private System.Windows.Forms.Label label9;
    }
}