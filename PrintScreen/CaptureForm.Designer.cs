using System.Windows.Forms;

namespace FlexScreen
{
    sealed partial class CaptureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureForm));
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeThisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multiCropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.captureIconImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureSmallIconImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconImageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSmallIconImageSize = new System.Windows.Forms.ToolStripComboBox();
            this.addBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magnifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.limeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cyanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hidingToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem5.Text = "toolStripMenuItem5";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.AutoToolTip = true;
            this.filesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertImageToolStripMenuItem,
            this.saveToolStripMenuItem2,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.closeThisToolStripMenuItem1});
            this.filesToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.page_save;
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(28, 22);
            this.filesToolStripMenuItem.Text = "Files";
            this.filesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.FilesToolStripMenuItemDropDownOpened);
            // 
            // insertImageToolStripMenuItem
            // 
            this.insertImageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.insertImageToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.CD;
            this.insertImageToolStripMenuItem.Name = "insertImageToolStripMenuItem";
            this.insertImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.insertImageToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.insertImageToolStripMenuItem.Text = "Insert Image From File";
            this.insertImageToolStripMenuItem.Click += new System.EventHandler(this.FromFileToolStripMenuItemClick);
            this.insertImageToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // saveToolStripMenuItem2
            // 
            this.saveToolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.saveToolStripMenuItem2.Image = global::FlexScreen.Properties.Resources.disk;
            this.saveToolStripMenuItem2.Name = "saveToolStripMenuItem2";
            this.saveToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem2.Size = new System.Drawing.Size(231, 22);
            this.saveToolStripMenuItem2.Text = "Save";
            this.saveToolStripMenuItem2.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            this.saveToolStripMenuItem2.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.saveAsToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.disk_multiple;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            this.saveAsToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(228, 6);
            this.toolStripMenuItem3.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // closeThisToolStripMenuItem1
            // 
            this.closeThisToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.closeThisToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.cross;
            this.closeThisToolStripMenuItem1.Name = "closeThisToolStripMenuItem1";
            this.closeThisToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.closeThisToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.closeThisToolStripMenuItem1.Text = "Close This";
            this.closeThisToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.closeThisToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.AutoToolTip = true;
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cropToolStripMenuItem2,
            this.eraseToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.swapToolStripMenuItem,
            this.deleteLastToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.toolStripMenuItem8,
            this.advancedToolStripMenuItem1});
            this.editToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Crop_Icon1;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.editToolStripMenuItem.Size = new System.Drawing.Size(28, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpened += new System.EventHandler(this.FilesToolStripMenuItemDropDownOpened);
            // 
            // cropToolStripMenuItem2
            // 
            this.cropToolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.cropToolStripMenuItem2.Image = global::FlexScreen.Properties.Resources.Cut_16x16;
            this.cropToolStripMenuItem2.Name = "cropToolStripMenuItem2";
            this.cropToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cropToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.cropToolStripMenuItem2.Text = "Crop";
            this.cropToolStripMenuItem2.Click += new System.EventHandler(this.CropToolStripMenuItemClick);
            this.cropToolStripMenuItem2.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            this.cropToolStripMenuItem2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
            // 
            // eraseToolStripMenuItem1
            // 
            this.eraseToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.eraseToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Eraser3_16x16;
            this.eraseToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.eraseToolStripMenuItem1.Name = "eraseToolStripMenuItem1";
            this.eraseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.eraseToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.eraseToolStripMenuItem1.Text = "Erase";
            this.eraseToolStripMenuItem1.Click += new System.EventHandler(this.EraserToolStripMenuItemClick);
            this.eraseToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
            this.toolStripMenuItem2.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.undoToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.arrow_undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
            this.undoToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.redoToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.arrow_redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem1Click);
            this.redoToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // swapToolStripMenuItem
            // 
            this.swapToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.swapToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.arrow_refresh;
            this.swapToolStripMenuItem.Name = "swapToolStripMenuItem";
            this.swapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this.swapToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.swapToolStripMenuItem.Text = "Swap";
            this.swapToolStripMenuItem.Click += new System.EventHandler(this.SwapToolStripMenuItemClick);
            // 
            // deleteLastToolStripMenuItem
            // 
            this.deleteLastToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.deleteLastToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.turn_down_16x16;
            this.deleteLastToolStripMenuItem.Name = "deleteLastToolStripMenuItem";
            this.deleteLastToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteLastToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteLastToolStripMenuItem.Text = "Delete Last";
            this.deleteLastToolStripMenuItem.Click += new System.EventHandler(this.deleteLastToolStripMenuItem1_Click);
            this.deleteLastToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            this.toolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.copyToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Copy_4_16x16;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            this.copyToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.pasteToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Paste_4_16x16;
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
            this.pasteToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(153, 6);
            // 
            // advancedToolStripMenuItem1
            // 
            this.advancedToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.advancedToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiCropToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.pickColorToolStripMenuItem,
            this.toolStripMenuItem6,
            this.captureIconImageToolStripMenuItem,
            this.captureSmallIconImageToolStripMenuItem,
            this.smallIconImageSizeToolStripMenuItem,
            this.addBorderToolStripMenuItem});
            this.advancedToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Tools_16x161;
            this.advancedToolStripMenuItem1.Name = "advancedToolStripMenuItem1";
            this.advancedToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.advancedToolStripMenuItem1.Text = "Advanced...";
            // 
            // multiCropToolStripMenuItem
            // 
            this.multiCropToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.multiCropToolStripMenuItem.Image = global::FlexScreen.Properties.Resources._2345;
            this.multiCropToolStripMenuItem.Name = "multiCropToolStripMenuItem";
            this.multiCropToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.multiCropToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.multiCropToolStripMenuItem.Text = "Multi Crop";
            this.multiCropToolStripMenuItem.Click += new System.EventHandler(this.MultiCropToolStripMenuItemClick);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doubleToolStripMenuItem,
            this.halfToolStripMenuItem});
            this.zoomToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.zoom;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // doubleToolStripMenuItem
            // 
            this.doubleToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.zoom_in;
            this.doubleToolStripMenuItem.Name = "doubleToolStripMenuItem";
            this.doubleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.doubleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.doubleToolStripMenuItem.Text = "Double";
            this.doubleToolStripMenuItem.Click += new System.EventHandler(this.DoubleToolStripMenuItemClick);
            // 
            // halfToolStripMenuItem
            // 
            this.halfToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.zoom_out;
            this.halfToolStripMenuItem.Name = "halfToolStripMenuItem";
            this.halfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.halfToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.halfToolStripMenuItem.Text = "Half";
            this.halfToolStripMenuItem.Click += new System.EventHandler(this.HalfToolStripMenuItemClick);
            // 
            // pickColorToolStripMenuItem
            // 
            this.pickColorToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.pickColorToolStripMenuItem.Name = "pickColorToolStripMenuItem";
            this.pickColorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.pickColorToolStripMenuItem.Text = "Pick Color";
            this.pickColorToolStripMenuItem.Click += new System.EventHandler(this.pickColorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(207, 6);
            // 
            // captureIconImageToolStripMenuItem
            // 
            this.captureIconImageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.captureIconImageToolStripMenuItem.Name = "captureIconImageToolStripMenuItem";
            this.captureIconImageToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.captureIconImageToolStripMenuItem.Text = "Capture Icon Image";
            this.captureIconImageToolStripMenuItem.Click += new System.EventHandler(this.CaptureIconImageToolStripMenuItemClick);
            // 
            // captureSmallIconImageToolStripMenuItem
            // 
            this.captureSmallIconImageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.captureSmallIconImageToolStripMenuItem.Name = "captureSmallIconImageToolStripMenuItem";
            this.captureSmallIconImageToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.captureSmallIconImageToolStripMenuItem.Text = "Capture Small Icon Image";
            this.captureSmallIconImageToolStripMenuItem.Click += new System.EventHandler(this.CaptureSmallIconImageToolStripMenuItemClick);
            // 
            // smallIconImageSizeToolStripMenuItem
            // 
            this.smallIconImageSizeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.smallIconImageSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbSmallIconImageSize});
            this.smallIconImageSizeToolStripMenuItem.Name = "smallIconImageSizeToolStripMenuItem";
            this.smallIconImageSizeToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.smallIconImageSizeToolStripMenuItem.Text = "Small Icon Image Size";
            // 
            // cbSmallIconImageSize
            // 
            this.cbSmallIconImageSize.Items.AddRange(new object[] {
            "16x16",
            "17x17"});
            this.cbSmallIconImageSize.Name = "cbSmallIconImageSize";
            this.cbSmallIconImageSize.Size = new System.Drawing.Size(100, 23);
            this.cbSmallIconImageSize.Text = "17x17";
            // 
            // addBorderToolStripMenuItem
            // 
            this.addBorderToolStripMenuItem.Name = "addBorderToolStripMenuItem";
            this.addBorderToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addBorderToolStripMenuItem.Text = "Add Border";
            this.addBorderToolStripMenuItem.Click += new System.EventHandler(this.AddBorderToolStripMenuItemClick);
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.AutoToolTip = true;
            this.drawingToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrowToolStripMenuItem1,
            this.lineToolStripMenuItem1,
            this.rectangleToolStripMenuItem1,
            this.ellipseToolStripMenuItem,
            this.pointMarkerToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.magnifyToolStripMenuItem,
            this.textToolStripMenuItem2});
            this.drawingToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.pencil;
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(28, 22);
            this.drawingToolStripMenuItem.Text = "Drawing";
            this.drawingToolStripMenuItem.DropDownOpening += new System.EventHandler(this.DrawingToolStripMenuItemDropDownOpening);
            this.drawingToolStripMenuItem.DropDownOpened += new System.EventHandler(this.FilesToolStripMenuItemDropDownOpened);
            // 
            // arrowToolStripMenuItem1
            // 
            this.arrowToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.arrowToolStripMenuItem1.Name = "arrowToolStripMenuItem1";
            this.arrowToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.arrowToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.arrowToolStripMenuItem1.Text = "Arrow";
            this.arrowToolStripMenuItem1.Click += new System.EventHandler(this.ArrowToolStripMenuItemClick);
            this.arrowToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // lineToolStripMenuItem1
            // 
            this.lineToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.lineToolStripMenuItem1.Name = "lineToolStripMenuItem1";
            this.lineToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lineToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.lineToolStripMenuItem1.Text = "Line";
            this.lineToolStripMenuItem1.Click += new System.EventHandler(this.LineToolStripMenuItemClick);
            this.lineToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // rectangleToolStripMenuItem1
            // 
            this.rectangleToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.rectangleToolStripMenuItem1.Name = "rectangleToolStripMenuItem1";
            this.rectangleToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.rectangleToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.rectangleToolStripMenuItem1.Text = "Rectangle";
            this.rectangleToolStripMenuItem1.Click += new System.EventHandler(this.RectangleToolStripMenuItemClick);
            this.rectangleToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.EllipseToolStripMenuItemClick);
            this.ellipseToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // pointMarkerToolStripMenuItem
            // 
            this.pointMarkerToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.pointMarkerToolStripMenuItem.Name = "pointMarkerToolStripMenuItem";
            this.pointMarkerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
            this.pointMarkerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pointMarkerToolStripMenuItem.Text = "Point Mar&ker";
            this.pointMarkerToolStripMenuItem.Click += new System.EventHandler(this.PointMarkerToolStripMenuItemClick);
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.indexToolStripMenuItem.Text = "Index";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.IndexToolStripMenuItemClick);
            this.indexToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // magnifyToolStripMenuItem
            // 
            this.magnifyToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.magnifyToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.magnifierGlass_Small;
            this.magnifyToolStripMenuItem.Name = "magnifyToolStripMenuItem";
            this.magnifyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.magnifyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.magnifyToolStripMenuItem.Text = "Magnify Lens";
            this.magnifyToolStripMenuItem.Click += new System.EventHandler(this.MagnifyLentsToolStripMenuItemClick);
            this.magnifyToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // textToolStripMenuItem2
            // 
            this.textToolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.textToolStripMenuItem2.Name = "textToolStripMenuItem2";
            this.textToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.textToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.textToolStripMenuItem2.Text = "Text...";
            this.textToolStripMenuItem2.Click += new System.EventHandler(this.TextToolStripMenuItemClick);
            this.textToolStripMenuItem2.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // highlightersToolStripMenuItem1
            // 
            this.highlightersToolStripMenuItem1.AutoToolTip = true;
            this.highlightersToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.highlightersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pinkToolStripMenuItem1,
            this.yellowToolStripMenuItem1,
            this.limeToolStripMenuItem,
            this.cyanToolStripMenuItem1,
            this.hidingToolToolStripMenuItem});
            this.highlightersToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Highlighter;
            this.highlightersToolStripMenuItem1.Name = "highlightersToolStripMenuItem1";
            this.highlightersToolStripMenuItem1.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.highlightersToolStripMenuItem1.Size = new System.Drawing.Size(28, 22);
            this.highlightersToolStripMenuItem1.Text = "Highlighters";
            this.highlightersToolStripMenuItem1.DropDownOpening += new System.EventHandler(this.HighlightersToolStripMenuItem1DropDownOpening);
            this.highlightersToolStripMenuItem1.DropDownOpened += new System.EventHandler(this.FilesToolStripMenuItemDropDownOpened);
            // 
            // pinkToolStripMenuItem1
            // 
            this.pinkToolStripMenuItem1.BackColor = System.Drawing.Color.HotPink;
            this.pinkToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pinkToolStripMenuItem1.Name = "pinkToolStripMenuItem1";
            this.pinkToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.pinkToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.pinkToolStripMenuItem1.Tag = "SR";
            this.pinkToolStripMenuItem1.Text = "Pink";
            this.pinkToolStripMenuItem1.Click += new System.EventHandler(this.PinkToolStripMenuItemClick);
            this.pinkToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // yellowToolStripMenuItem1
            // 
            this.yellowToolStripMenuItem1.BackColor = System.Drawing.Color.Yellow;
            this.yellowToolStripMenuItem1.Name = "yellowToolStripMenuItem1";
            this.yellowToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.yellowToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.yellowToolStripMenuItem1.Tag = "SR";
            this.yellowToolStripMenuItem1.Text = "Yellow";
            this.yellowToolStripMenuItem1.Click += new System.EventHandler(this.YellowToolStripMenuItemClick);
            this.yellowToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // limeToolStripMenuItem
            // 
            this.limeToolStripMenuItem.BackColor = System.Drawing.Color.SpringGreen;
            this.limeToolStripMenuItem.Name = "limeToolStripMenuItem";
            this.limeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.limeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.limeToolStripMenuItem.Tag = "SR";
            this.limeToolStripMenuItem.Text = "Lime";
            this.limeToolStripMenuItem.Click += new System.EventHandler(this.GreenToolStripMenuItemClick);
            this.limeToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // cyanToolStripMenuItem1
            // 
            this.cyanToolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue;
            this.cyanToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cyanToolStripMenuItem1.Name = "cyanToolStripMenuItem1";
            this.cyanToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.cyanToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.cyanToolStripMenuItem1.Tag = "SR";
            this.cyanToolStripMenuItem1.Text = "Cyan";
            this.cyanToolStripMenuItem1.Click += new System.EventHandler(this.CyanToolStripMenuItemClick);
            this.cyanToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // hidingToolToolStripMenuItem
            // 
            this.hidingToolToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.hidingToolToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Obfuscator;
            this.hidingToolToolStripMenuItem.Name = "hidingToolToolStripMenuItem";
            this.hidingToolToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.hidingToolToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hidingToolToolStripMenuItem.Text = "Grayout";
            this.hidingToolToolStripMenuItem.Click += new System.EventHandler(this.ObfuscatorToolStripMenuItemClick);
            this.hidingToolToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.AutoToolTip = true;
            this.exitToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineColorToolStripMenuItem,
            this.fillColorToolStripMenuItem,
            this.textToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.stayOnTopToolStripMenuItem,
            this.transparentToolStripMenuItem1,
            this.toolStripMenuItem7,
            this.advancedToolStripMenuItem});
            this.exitToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.palette;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(28, 22);
            this.exitToolStripMenuItem1.Text = "Options";
            this.exitToolStripMenuItem1.DropDownOpening += new System.EventHandler(this.ExitToolStripMenuItem1DropDownOpening);
            this.exitToolStripMenuItem1.DropDownOpened += new System.EventHandler(this.FilesToolStripMenuItemDropDownOpened);
            this.exitToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.lineColorToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Pen_Color_16x16;
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.lineColorToolStripMenuItem.Text = "Line Color";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.BorderToolStripMenuItemClick);
            this.lineColorToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fillColorToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Paint_Colors_16x16;
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fillColorToolStripMenuItem.Text = "Fill Color";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.FillToolStripMenuItemClick);
            this.fillColorToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // textToolStripMenuItem1
            // 
            this.textToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.textToolStripMenuItem1.Image = global::FlexScreen.Properties.Resources.Style_16x161;
            this.textToolStripMenuItem1.Name = "textToolStripMenuItem1";
            this.textToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.textToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.textToolStripMenuItem1.Text = "Text Style";
            this.textToolStripMenuItem1.Click += new System.EventHandler(this.TextToolStripMenuItem1Click);
            this.textToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(175, 6);
            this.toolStripMenuItem4.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.stayOnTopToolStripMenuItem.Text = "Pin On Top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.OnTop_Click);
            this.stayOnTopToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // transparentToolStripMenuItem1
            // 
            this.transparentToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.transparentToolStripMenuItem1.Name = "transparentToolStripMenuItem1";
            this.transparentToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.transparentToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.transparentToolStripMenuItem1.Text = "Transparent";
            this.transparentToolStripMenuItem1.Click += new System.EventHandler(this.TransparentClick);
            this.transparentToolStripMenuItem1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(175, 6);
            this.toolStripMenuItem7.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.advancedToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Option1_16x16;
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.advancedToolStripMenuItem.Text = "Options...";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.MoreOptionsToolStripMenuItemClick);
            this.advancedToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minimizeToolStripMenuItem.AutoToolTip = true;
            this.minimizeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minimizeToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.Minimize1;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.minimizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(28, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.ToolTipText = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.AutoToolTip = true;
            this.closeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeToolStripMenuItem.Image = global::FlexScreen.Properties.Resources.cross;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(28, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.drawingToolStripMenuItem,
            this.highlightersToolStripMenuItem1,
            this.exitToolStripMenuItem1,
            this.closeToolStripMenuItem,
            this.minimizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(320, 22);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MenuStrip1HelpRequested);
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseEnter += new System.EventHandler(this.MenuStrip1MouseEnter);
            this.menuStrip1.MouseLeave += new System.EventHandler(this.MenuStrip1MouseLeave);
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(618, 227);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.CaptureFormLoad);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.CaptureForm_HelpRequested);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CaptureForm_KeyUp);
            this.MouseEnter += new System.EventHandler(this.CaptureForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CaptureForm_MouseLeave);
            this.Resize += new System.EventHandler(this.CaptureFormResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem closeThisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cropToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eraseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLastToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magnifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem highlightersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem limeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cyanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hidingToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem multiCropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointMarkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureIconImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureSmallIconImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem smallIconImageSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbSmallIconImageSize;
        private System.Windows.Forms.ToolStripMenuItem addBorderToolStripMenuItem;
    }
}