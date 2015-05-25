namespace FlexScreen
{
    partial class CropScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.FillColorDialog = new System.Windows.Forms.ColorDialog();
            this.LineColorDialog = new System.Windows.Forms.ColorDialog();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version 1.0.0.4";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "png";
            this.SaveFileDialog.FileName = "ScreenShoot";
            this.SaveFileDialog.Filter = "Jpeg Image (JPG)|*.jpg|PNG Image|*.png|GIF Image (GIF)|*.gif|Bitmap (BMP)|*.bmp|E" +
                "WM Image|*.emf|TIFF Image|*.tiff|Windows Metafile (WMF)|*.wmf|Exchangable image " +
                "file|*.exif";
            this.SaveFileDialog.FilterIndex = 2;
            this.SaveFileDialog.InitialDirectory = "Desktop";
            this.SaveFileDialog.SupportMultiDottedExtensions = true;
            this.SaveFileDialog.Title = "Save Captured Image";
            // 
            // FillColorDialog
            // 
            this.FillColorDialog.AnyColor = true;
            this.FillColorDialog.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            // 
            // LineColorDialog
            // 
            this.LineColorDialog.AnyColor = true;
            this.LineColorDialog.Color = System.Drawing.Color.Red;
            // 
            // FontDialog
            // 
            this.FontDialog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontDialog.ShowColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(12, 233);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load from file...";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Location = new System.Drawing.Point(134, 233);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(115, 23);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "More Options...";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copyrigh (c) 2011 - by @TH";
            // 
            // CropScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlexScreen.Properties.Resources.Crop_Icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(261, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CropScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flex Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.ColorDialog FillColorDialog;
        public System.Windows.Forms.ColorDialog LineColorDialog;
        public System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Label label2;

    }
}

