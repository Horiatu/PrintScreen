namespace FlexScreen
{
    partial class PasswordDialog
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
            this.cbFile = new System.Windows.Forms.CheckBox();
            this.lFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbort = new FlexScreen.CustomButton();
            this.btnOK = new FlexScreen.CustomButton();
            this.btnCancel = new FlexScreen.CustomButton();
            this.SuspendLayout();
            // 
            // cbFile
            // 
            this.cbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFile.AutoSize = true;
            this.cbFile.BackColor = System.Drawing.Color.Transparent;
            this.cbFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFile.Location = new System.Drawing.Point(346, 63);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(42, 17);
            this.cbFile.TabIndex = 12;
            this.cbFile.Text = "File";
            this.cbFile.UseVisualStyleBackColor = false;
            this.cbFile.CheckedChanged += new System.EventHandler(this.CbFileCheckedChanged);
            // 
            // lFileName
            // 
            this.lFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lFileName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lFileName.Location = new System.Drawing.Point(190, 64);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(150, 14);
            this.lFileName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(88, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Protected file or archive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(90, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter password for  ";
            // 
            // tbPassword
            // 
            this.tbPassword.AcceptsReturn = true;
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbPassword.Location = new System.Drawing.Point(93, 86);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(295, 20);
            this.tbPassword.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FlexScreen.Properties.Resources.Lock;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(30, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 50);
            this.panel1.TabIndex = 4;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbort.BackColor = System.Drawing.Color.MistyRose;
            this.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAbort.BorderColor = System.Drawing.Color.DarkSalmon;
            this.btnAbort.CornerRadius = 10;
            this.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Location = new System.Drawing.Point(30, 117);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.RoundCorners = FlexScreen.Corners.BottomLeft;
            this.btnAbort.Size = new System.Drawing.Size(57, 34);
            this.btnAbort.TabIndex = 13;
            this.btnAbort.Text = "Give up";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Honeydew;
            this.btnOK.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnOK.CornerRadius = 10;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.IsDefault = true;
            this.btnOK.Location = new System.Drawing.Point(209, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.RoundCorners = FlexScreen.Corners.BottomRight;
            this.btnOK.Size = new System.Drawing.Size(179, 34);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Try this";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.BorderColor = System.Drawing.Color.Gold;
            this.btnCancel.CornerRadius = 10;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Don\'t know";
            this.btnCancel.Visible = false;
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnAbort;
            this.ClientSize = new System.Drawing.Size(418, 170);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.lFileName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PasswordDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private CustomButton btnOK;
        private CustomButton btnCancel;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.CheckBox cbFile;
        private CustomButton btnAbort;
    }
}