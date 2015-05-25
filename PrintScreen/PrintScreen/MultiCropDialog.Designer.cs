namespace FlexScreen
{
    partial class MultiCropDialog
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.customButton4 = new FlexScreen.CustomButton();
            this.tbFileRoot = new System.Windows.Forms.TextBox();
            this.btnTransparentColor = new System.Windows.Forms.Button();
            this.cbTransparent = new System.Windows.Forms.CheckBox();
            this.saveProgress = new FlexScreen.ProgressBarEx();
            this.cbArchive = new System.Windows.Forms.CheckBox();
            this.dumExtension = new System.Windows.Forms.DomainUpDown();
            this.numSeed = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new FlexScreen.CustomButton();
            this.btnCancel = new FlexScreen.CustomButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numRepeatY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numRepeatX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numStartY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numStartX = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartX)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "PNG";
            this.saveFileDialog1.Filter = "Jpeg Image (JPG)|*.jpg|PNG Image|*.png|GIF Image (GIF)|*.gif|Bitmap (BMP)|*.bmp|E" +
                "WM Image|*.emf|TIFF Image|*.tiff|Windows Metafile (WMF)|*.wmf|Exchangable image " +
                "file|*.exif";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.InitialDirectory = "Desktop";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "Save File(s) Name Pattern";
            // 
            // customButton4
            // 
            this.customButton4.BackColor = System.Drawing.Color.White;
            this.customButton4.BorderColor = System.Drawing.Color.Silver;
            this.customButton4.CornerRadius = 3;
            this.customButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.customButton4.Location = new System.Drawing.Point(402, 151);
            this.customButton4.Name = "customButton4";
            this.customButton4.RoundCorners = ((FlexScreen.Corners)((((FlexScreen.Corners.TopLeft | FlexScreen.Corners.TopRight)
                        | FlexScreen.Corners.BottomLeft)
                        | FlexScreen.Corners.BottomRight)));
            this.customButton4.Size = new System.Drawing.Size(16, 16);
            this.customButton4.TabIndex = 43;
            this.customButton4.Text = "...";
            this.customButton4.Click += new System.EventHandler(this.customButton4_Click);
            // 
            // tbFileRoot
            // 
            this.tbFileRoot.BackColor = System.Drawing.Color.GhostWhite;
            this.tbFileRoot.Location = new System.Drawing.Point(41, 149);
            this.tbFileRoot.Name = "tbFileRoot";
            this.tbFileRoot.Size = new System.Drawing.Size(379, 20);
            this.tbFileRoot.TabIndex = 42;
            // 
            // btnTransparentColor
            // 
            this.btnTransparentColor.BackColor = System.Drawing.Color.White;
            this.btnTransparentColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransparentColor.FlatAppearance.BorderSize = 0;
            this.btnTransparentColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransparentColor.Location = new System.Drawing.Point(518, 173);
            this.btnTransparentColor.Name = "btnTransparentColor";
            this.btnTransparentColor.Size = new System.Drawing.Size(35, 17);
            this.btnTransparentColor.TabIndex = 47;
            this.btnTransparentColor.UseVisualStyleBackColor = false;
            this.btnTransparentColor.BackColorChanged += new System.EventHandler(this.btnTransparentColor_BackColorChanged);
            this.btnTransparentColor.Click += new System.EventHandler(this.btnTransparentColor_Click);
            // 
            // cbTransparent
            // 
            this.cbTransparent.AutoSize = true;
            this.cbTransparent.BackColor = System.Drawing.Color.Transparent;
            this.cbTransparent.ForeColor = System.Drawing.Color.Black;
            this.cbTransparent.Location = new System.Drawing.Point(402, 173);
            this.cbTransparent.Name = "cbTransparent";
            this.cbTransparent.Size = new System.Drawing.Size(110, 17);
            this.cbTransparent.TabIndex = 46;
            this.cbTransparent.Text = "Transparent Color";
            this.cbTransparent.UseVisualStyleBackColor = false;
            // 
            // saveProgress
            // 
            this.saveProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveProgress.BackColor = System.Drawing.Color.Azure;
            this.saveProgress.ForeColor = System.Drawing.Color.RoyalBlue;
            this.saveProgress.Location = new System.Drawing.Point(41, 173);
            this.saveProgress.MarqueeAnimationSpeed = 10;
            this.saveProgress.Name = "saveProgress";
            this.saveProgress.Size = new System.Drawing.Size(355, 15);
            this.saveProgress.Step = 1;
            this.saveProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.saveProgress.TabIndex = 45;
            this.saveProgress.UseWaitCursor = true;
            this.saveProgress.Value = 90;
            this.saveProgress.Visible = false;
            // 
            // cbArchive
            // 
            this.cbArchive.AutoSize = true;
            this.cbArchive.BackColor = System.Drawing.Color.Transparent;
            this.cbArchive.Checked = true;
            this.cbArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbArchive.ForeColor = System.Drawing.Color.Black;
            this.cbArchive.Location = new System.Drawing.Point(354, 132);
            this.cbArchive.Name = "cbArchive";
            this.cbArchive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbArchive.Size = new System.Drawing.Size(62, 17);
            this.cbArchive.TabIndex = 44;
            this.cbArchive.Text = "Archive";
            this.cbArchive.UseVisualStyleBackColor = false;
            // 
            // dumExtension
            // 
            this.dumExtension.BackColor = System.Drawing.Color.GhostWhite;
            this.dumExtension.Items.Add(".BMP");
            this.dumExtension.Items.Add(".GIF");
            this.dumExtension.Items.Add(".PNG");
            this.dumExtension.Location = new System.Drawing.Point(489, 149);
            this.dumExtension.Name = "dumExtension";
            this.dumExtension.Size = new System.Drawing.Size(64, 20);
            this.dumExtension.Sorted = true;
            this.dumExtension.TabIndex = 41;
            this.dumExtension.Text = ".PNG";
            // 
            // numSeed
            // 
            this.numSeed.BackColor = System.Drawing.Color.GhostWhite;
            this.numSeed.Location = new System.Drawing.Point(429, 149);
            this.numSeed.Name = "numSeed";
            this.numSeed.Size = new System.Drawing.Size(54, 20);
            this.numSeed.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(486, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Format";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(426, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Seed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(38, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "File Path/Root Name";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Honeydew;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(402, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.RoundCorners = FlexScreen.Corners.BottomLeft;
            this.btnOK.Size = new System.Drawing.Size(81, 31);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(489, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnCancel.Size = new System.Drawing.Size(64, 31);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(32, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 45);
            this.label9.TabIndex = 16;
            this.label9.Text = "Multi Crop";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(297, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Repeat Y";
            // 
            // numOffsetY
            // 
            this.numOffsetY.BackColor = System.Drawing.Color.GhostWhite;
            this.numOffsetY.Location = new System.Drawing.Point(489, 96);
            this.numOffsetY.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(65, 20);
            this.numOffsetY.TabIndex = 14;
            this.numOffsetY.ValueChanged += new System.EventHandler(this.numOffsetY_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(297, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Repeat X";
            // 
            // numOffsetX
            // 
            this.numOffsetX.BackColor = System.Drawing.Color.GhostWhite;
            this.numOffsetX.Location = new System.Drawing.Point(489, 70);
            this.numOffsetX.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(65, 20);
            this.numOffsetX.TabIndex = 12;
            this.numOffsetX.ValueChanged += new System.EventHandler(this.numOffsetX_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(426, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Offset Y";
            // 
            // numRepeatY
            // 
            this.numRepeatY.BackColor = System.Drawing.Color.GhostWhite;
            this.numRepeatY.Location = new System.Drawing.Point(355, 96);
            this.numRepeatY.Name = "numRepeatY";
            this.numRepeatY.Size = new System.Drawing.Size(65, 20);
            this.numRepeatY.TabIndex = 10;
            this.numRepeatY.ValueChanged += new System.EventHandler(this.numRepeatY_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(426, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Offset X";
            // 
            // numRepeatX
            // 
            this.numRepeatX.BackColor = System.Drawing.Color.GhostWhite;
            this.numRepeatX.Location = new System.Drawing.Point(355, 70);
            this.numRepeatX.Name = "numRepeatX";
            this.numRepeatX.Size = new System.Drawing.Size(65, 20);
            this.numRepeatX.TabIndex = 8;
            this.numRepeatX.ValueChanged += new System.EventHandler(this.numRepeatX_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(172, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height";
            // 
            // numHeight
            // 
            this.numHeight.BackColor = System.Drawing.Color.GhostWhite;
            this.numHeight.Location = new System.Drawing.Point(226, 94);
            this.numHeight.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(65, 20);
            this.numHeight.TabIndex = 6;
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(172, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width";
            // 
            // numWidth
            // 
            this.numWidth.BackColor = System.Drawing.Color.GhostWhite;
            this.numWidth.Location = new System.Drawing.Point(226, 68);
            this.numWidth.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(65, 20);
            this.numWidth.TabIndex = 4;
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(38, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Y";
            // 
            // numStartY
            // 
            this.numStartY.BackColor = System.Drawing.Color.GhostWhite;
            this.numStartY.Location = new System.Drawing.Point(92, 92);
            this.numStartY.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numStartY.Name = "numStartY";
            this.numStartY.Size = new System.Drawing.Size(65, 20);
            this.numStartY.TabIndex = 2;
            this.numStartY.ValueChanged += new System.EventHandler(this.numStartY_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(38, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start X";
            // 
            // numStartX
            // 
            this.numStartX.BackColor = System.Drawing.Color.GhostWhite;
            this.numStartX.Location = new System.Drawing.Point(92, 66);
            this.numStartX.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numStartX.Name = "numStartX";
            this.numStartX.Size = new System.Drawing.Size(65, 20);
            this.numStartX.TabIndex = 0;
            this.numStartX.ValueChanged += new System.EventHandler(this.numStartX_ValueChanged);
            // 
            // MultiCropDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 252);
            this.Controls.Add(this.customButton4);
            this.Controls.Add(this.tbFileRoot);
            this.Controls.Add(this.btnTransparentColor);
            this.Controls.Add(this.cbTransparent);
            this.Controls.Add(this.saveProgress);
            this.Controls.Add(this.cbArchive);
            this.Controls.Add(this.dumExtension);
            this.Controls.Add(this.numSeed);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numOffsetY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numOffsetX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numRepeatY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numRepeatX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numStartY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numStartX);
            this.Name = "MultiCropDialog";
            this.Text = "Multi Crop";
            this.Activated += new System.EventHandler(this.MultiCropDialog_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numStartX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numStartY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRepeatX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRepeatY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.Label label9;
        private CustomButton btnCancel;
        private CustomButton btnOK;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private CustomButton customButton4;
        private System.Windows.Forms.TextBox tbFileRoot;
        private System.Windows.Forms.Button btnTransparentColor;
        private System.Windows.Forms.CheckBox cbTransparent;
        private ProgressBarEx saveProgress;
        private System.Windows.Forms.CheckBox cbArchive;
        private System.Windows.Forms.DomainUpDown dumExtension;
        private System.Windows.Forms.NumericUpDown numSeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}