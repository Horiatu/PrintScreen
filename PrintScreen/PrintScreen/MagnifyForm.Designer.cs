namespace FlexScreen
{
    partial class MagnifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagnifyForm));
            this.MagnifyText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MagnifyText
            // 
            this.MagnifyText.BackColor = System.Drawing.Color.Transparent;
            this.MagnifyText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MagnifyText.Location = new System.Drawing.Point(0, 138);
            this.MagnifyText.Margin = new System.Windows.Forms.Padding(0);
            this.MagnifyText.Name = "MagnifyText";
            this.MagnifyText.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.MagnifyText.Size = new System.Drawing.Size(184, 24);
            this.MagnifyText.TabIndex = 0;
            this.MagnifyText.Text = "x";
            this.MagnifyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MagnifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 162);
            this.Controls.Add(this.MagnifyText);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MagnifyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Magnify ";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MagnifyText;
    }
}