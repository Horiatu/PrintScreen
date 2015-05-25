namespace FlexScreen
{
    partial class TextDialog
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
            this.btnOK = new FlexScreen.CustomButton();
            this.btnCancel = new FlexScreen.CustomButton();
            this.btnFont = new FlexScreen.CustomButton();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.lAnnotation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Honeydew;
            this.btnOK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.CornerRadius = 6;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(308, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.RoundCorners = ((FlexScreen.Corners)((FlexScreen.Corners.TopLeft | FlexScreen.Corners.BottomLeft)));
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.CornerRadius = 6;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(389, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.BackColor = System.Drawing.Color.White;
            this.btnFont.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFont.CornerRadius = 6;
            this.btnFont.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFont.Image = global::FlexScreen.Properties.Resources.Style_16x16;
            this.btnFont.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFont.Location = new System.Drawing.Point(389, 16);
            this.btnFont.Name = "btnFont";
            this.btnFont.RoundCorners = ((FlexScreen.Corners)((FlexScreen.Corners.TopLeft | FlexScreen.Corners.TopRight)));
            this.btnFont.Size = new System.Drawing.Size(75, 29);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "Font";
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.BackColor = System.Drawing.Color.White;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.Location = new System.Drawing.Point(23, 51);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox.Size = new System.Drawing.Size(441, 110);
            this.TextBox.TabIndex = 1;
            this.TextBox.WordWrap = false;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lAnnotation
            // 
            this.lAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lAnnotation.BackColor = System.Drawing.Color.Transparent;
            this.lAnnotation.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAnnotation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lAnnotation.Location = new System.Drawing.Point(16, 9);
            this.lAnnotation.Name = "lAnnotation";
            this.lAnnotation.Size = new System.Drawing.Size(367, 39);
            this.lAnnotation.TabIndex = 13;
            this.lAnnotation.Text = "Annotation";
            this.lAnnotation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.lAnnotation.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // TextDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(488, 212);
            this.Controls.Add(this.lAnnotation);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(726, 408);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(488, 160);
            this.Name = "TextDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Here Text To Annotate:";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.TextDialog_Activated);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TextDialog_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton btnOK;
        private CustomButton btnCancel;
        private CustomButton btnFont;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Label lAnnotation;
    }
}