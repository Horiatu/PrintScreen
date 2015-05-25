using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace FlexScreen
{
    public enum CustomButtonState
    {
        Normal = 1,
        Hot,
        Pressed,
        Disabled,
        Focused
    }

    public class CustomButton : Control, IButtonControl
    {
        public CustomButton()
            : base()
        {
            this.SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        }


        #region Private Instance Variables

        private DialogResult m_DialogResult;
        private bool m_IsDefault;

        private int m_CornerRadius = 8;
        private Corners m_RoundCorners = Corners.None;
        private CustomButtonState m_ButtonState = CustomButtonState.Normal;

        private ContentAlignment m_ImageAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment m_TextAlign = ContentAlignment.MiddleCenter;
        private Image m_Image;
        private ImageList m_ImageList;
        private int m_ImageIndex = -1;

        private bool keyPressed;
        private Rectangle contentRect;

        #endregion

        #region IButtonControl Implementation

        [Category("Behavior"), DefaultValue(typeof(DialogResult), "None")]
        [Description("The dialog result produced in a modal form by clicking the button.")]
        public DialogResult DialogResult
        {
            get { return m_DialogResult; }
            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                    m_DialogResult = value;
            }
        }

        public void NotifyDefault(bool value)
        {
            if (m_IsDefault != value)
            {
                m_IsDefault = value;
                this.Invalidate();
            }
        }

        public void PerformClick()
        {
            if (this.CanSelect)
            {
                base.OnClick(EventArgs.Empty);
                if (this.DialogResult != System.Windows.Forms.DialogResult.None)
                {
                    Form parentDialog = GetParentDialog(this);
                    if (parentDialog != null)
                    {
                        parentDialog.DialogResult = this.DialogResult;
                    }
                }
            }
        }

        private Form GetParentDialog(Control control)
        {
            Control parent = control.Parent;
            if (parent == null || parent is Form) return parent as Form;
            return GetParentDialog(parent);
        }

        #endregion

        #region Properties

        //ButtonState
        [Browsable(false)]
        public CustomButtonState ButtonState
        {
            get { return m_ButtonState; }
        }

        //CornerRadius
        [Category("Appearance")]
        [DefaultValue(8)]
        [Description("Defines the radius of the controls RoundedCorners.")]
        public int CornerRadius
        {
            get { return m_CornerRadius; }
            set
            {
                if (m_CornerRadius == value)
                    return;
                m_CornerRadius = value;
                this.Invalidate();
            }
        }

        //DefaultSize
        protected override System.Drawing.Size DefaultSize
        {
            get { return new Size(75, 23); }
        }


        //IsDefault
        [Category("Appearance")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool IsDefault
        {
            get { return m_IsDefault; }
            set
            {
                if (m_IsDefault != value)
                {
                    m_IsDefault = value;
                    this.Invalidate();
                }
            }
        }

        //Image
        [Category("Appearance"), DefaultValue(typeof(Image), null)]
        [Description("The image to display in the face of the control.")]
        public Image Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;
                this.Invalidate();
            }
        }

        //ImageList
        [Category("Appearance"), DefaultValue(typeof(ImageList), null)]
        [Description("The image list to get the image to display in the face of the control.")]
        public ImageList ImageList
        {
            get { return m_ImageList; }
            set
            {
                m_ImageList = value;
                this.Invalidate();
            }
        }

        //ImageIndex
        [Category("Appearance"), DefaultValue(-1)]
        [Description("The index of the image in the image list to display in the face of the control.")]
        [TypeConverter(typeof(ImageIndexConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public int ImageIndex
        {
            get { return m_ImageIndex; }
            set
            {
                m_ImageIndex = value;
                this.Invalidate();
            }
        }

        //ImageAlign
        [Category("Appearance"), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        [Description("The alignment of the image that will be displayed in the face of the control.")]
        public ContentAlignment ImageAlign
        {
            get { return m_ImageAlign; }
            set
            {
                if (!Enum.IsDefined(typeof(ContentAlignment), value))
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                if (m_ImageAlign == value)
                    return;
                m_ImageAlign = value;
                this.Invalidate();
            }
        }

        //RoundCorners
        [Category("Appearance")]
        [DefaultValue(typeof(Corners), "None")]
        [Description("Gets/sets the corners of the control to round.")]
        [Editor(typeof(RoundCornersEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Corners RoundCorners
        {
            get { return m_RoundCorners; }
            set
            {
                if (m_RoundCorners == value)
                    return;
                m_RoundCorners = value;
                this.Invalidate();
            }
        }

        Color m_BorderColor = Color.Black;
        [DispId(-513)]
        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get
            {
                return m_BorderColor;
            }
            set
            {
                if (m_BorderColor != value)
                {
                    m_BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        //TextAlign
        [Category("Appearance"), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        [Description("The alignment of the text that will be displayed in the face of the control.")]
        public ContentAlignment TextAlign
        {
            get { return m_TextAlign; }
            set
            {
                if (!Enum.IsDefined(typeof(ContentAlignment), value))
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
                if (m_TextAlign == value)
                    return;
                m_TextAlign = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Overriden Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                keyPressed = true;
                m_ButtonState = CustomButtonState.Pressed;
            }
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Space)
            {
                if (this.ButtonState == CustomButtonState.Pressed)
                    this.PerformClick();
                keyPressed = false;
                m_ButtonState = CustomButtonState.Focused;
            }
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!keyPressed)
                m_ButtonState = CustomButtonState.Hot;
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!keyPressed)
                m_ButtonState = (this.IsDefault) ? CustomButtonState.Focused : CustomButtonState.Normal;
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Focus();
                m_ButtonState = CustomButtonState.Pressed;
            }
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_ButtonState = CustomButtonState.Focused;
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (new Rectangle(Point.Empty, this.Size).Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
                m_ButtonState = CustomButtonState.Pressed;
            else
            {
                if (keyPressed)
                    return;
                m_ButtonState = CustomButtonState.Hot;
            }
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            m_ButtonState = CustomButtonState.Focused;
            this.NotifyDefault(true);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.FindForm().Focused)
                this.NotifyDefault(false);
            m_ButtonState = CustomButtonState.Normal;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            m_ButtonState = (this.Enabled) ? CustomButtonState.Normal : CustomButtonState.Disabled;
            OnStateChange(EventArgs.Empty);
        }

        protected override void OnClick(EventArgs e)
        {
            //Click gets fired before MouseUp which is handy
            if (this.ButtonState == CustomButtonState.Pressed)
            {
                this.Focus();
                this.PerformClick();
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (this.ButtonState == CustomButtonState.Pressed)
            {
                this.Focus();
                this.PerformClick();
            }
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            if (IsMnemonic(charCode, this.Text))
            {
                base.OnClick(EventArgs.Empty);
                return true;
            }
            return base.ProcessMnemonic(charCode);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Simulate Transparency
            System.Drawing.Drawing2D.GraphicsContainer g = pevent.Graphics.BeginContainer();
            Rectangle translateRect = this.Bounds;
            pevent.Graphics.TranslateTransform(-this.Left, -this.Top);
            PaintEventArgs pe = new PaintEventArgs(pevent.Graphics, translateRect);
            this.InvokePaintBackground(this.Parent, pe);
            this.InvokePaint(this.Parent, pe);
            pevent.Graphics.ResetTransform();
            pevent.Graphics.EndContainer(g);

            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color shadeColor, fillColor;
            Utils.DarkenColor(this.BackColor, 5);
            Color darkDarkColor = Utils.DarkenColor(this.BackColor, 15);
            Color lightColor = Utils.LightenColor(this.BackColor, 50);
            Utils.LightenColor(this.BackColor, 5);


            if (this.ButtonState == CustomButtonState.Hot)
            {
                fillColor = lightColor;
                shadeColor = this.BackColor;
            }
            else if (this.ButtonState == CustomButtonState.Pressed)
            {
                fillColor = darkDarkColor;
                shadeColor = this.BackColor;
            }
            else
            {
                fillColor = this.BackColor;
                shadeColor = darkDarkColor;
            }

            Rectangle r = this.ClientRectangle;
            System.Drawing.Drawing2D.GraphicsPath path = Utils.RoundRectangle(r, CornerRadius, RoundCorners);

            r.Inflate(-2, -2);
            System.Drawing.Drawing2D.GraphicsPath path1 = Utils.RoundRectangle(r, CornerRadius, RoundCorners);
            if (BackColor != Color.Transparent)
            {
                pevent.Graphics.FillPath(Brushes.White, path);
            }

            //Draw the Button Background
            using (var paintBrush = new System.Drawing.Drawing2D.LinearGradientBrush(r, fillColor, shadeColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                //We want a sharp change in the colors so define a Blend for the brush
                var b = new System.Drawing.Drawing2D.Blend
                            {
                                Positions = new[] { 0, 0.45F, 0.55F, 1 },
                                Factors = new[] { 0.0F, 0, 1, 1 }
                            };
                paintBrush.Blend = b;
                pevent.Graphics.FillPath(paintBrush, path1);
            }

            //...and border
            using (var drawingPen = new Pen(BorderColor))
            {
                pevent.Graphics.DrawPath(drawingPen, path);
            }

            //Get the Rectangle to be used for Content
            bool inBounds = false;
            //We could use some Math to get this from the radius but I'm 
            //not great at Math so for the example this hack will suffice.
            while (!inBounds && r.Width >= 1 && r.Height >= 1)
            {
                inBounds = path.IsVisible(r.Left, r.Top) &&
                            path.IsVisible(r.Right, r.Top) &&
                            path.IsVisible(r.Left, r.Bottom) &&
                            path.IsVisible(r.Right, r.Bottom);
                r.Inflate(-1, -1);
            }

            contentRect = r;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawImage(e.Graphics);
            DrawText(e.Graphics);
            DrawFocus(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            base.OnParentBackgroundImageChanged(e);
            Invalidate();
        }
        #endregion

        #region Internal Draw Methods

        private void DrawImage(Graphics g)
        {
            Image _Image;
            if (this.Image != null)
            {
                _Image = this.Image;
            }
            else
            {
                if (this.ImageList == null || this.ImageIndex == -1)
                    return;
                if (this.ImageIndex < 0 || this.ImageIndex >= this.ImageList.Images.Count)
                    return;

                _Image = this.ImageList.Images[this.ImageIndex];
            }

            Point pt = Point.Empty;

            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    pt.X = contentRect.Left;
                    pt.Y = contentRect.Top;
                    break;

                case ContentAlignment.TopCenter:
                    pt.X = (Width - _Image.Width) / 2;
                    pt.Y = contentRect.Top;
                    break;

                case ContentAlignment.TopRight:
                    pt.X = contentRect.Right - _Image.Width;
                    pt.Y = contentRect.Top;
                    break;

                case ContentAlignment.MiddleLeft:
                    pt.X = contentRect.Left;
                    pt.Y = (Height - _Image.Height) / 2;
                    break;

                case ContentAlignment.MiddleCenter:
                    pt.X = (Width - _Image.Width) / 2;
                    pt.Y = (Height - _Image.Height) / 2;
                    break;

                case ContentAlignment.MiddleRight:
                    pt.X = contentRect.Right - _Image.Width;
                    pt.Y = (Height - _Image.Height) / 2;
                    break;

                case ContentAlignment.BottomLeft:
                    pt.X = contentRect.Left;
                    pt.Y = contentRect.Bottom - _Image.Height;
                    break;

                case ContentAlignment.BottomCenter:
                    pt.X = (Width - _Image.Width) / 2;
                    pt.Y = contentRect.Bottom - _Image.Height;
                    break;

                case ContentAlignment.BottomRight:
                    pt.X = contentRect.Right - _Image.Width;
                    pt.Y = contentRect.Bottom - _Image.Height;
                    break;
            }

            if (this.ButtonState == CustomButtonState.Pressed)
                pt.Offset(-1, -1);

            if (this.Enabled)
                g.DrawImage(_Image, pt.X, pt.Y);
            else
                ControlPaint.DrawImageDisabled(g, _Image, pt.X, pt.Y, this.BackColor);

        }


        private void DrawText(Graphics g)
        {
            SolidBrush TextBrush = new SolidBrush(this.ForeColor);

            RectangleF R = (RectangleF)contentRect;

            if (!this.Enabled)
                TextBrush.Color = SystemColors.GrayText;

            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);

            if (ShowKeyboardCues)
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            else
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;

            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.MiddleLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }

            if (this.ButtonState == CustomButtonState.Pressed)
                R.Offset(-1, -1);

            if (this.Enabled)
                g.DrawString(this.Text, this.Font, TextBrush, R, sf);
            else
                ControlPaint.DrawStringDisabled(g, this.Text, this.Font, this.BackColor, R, sf);

        }


        private void DrawFocus(Graphics g)
        {
            if (this.Focused && this.ShowFocusCues && this.TabStop)
            {
                Rectangle r = contentRect;
                r.Inflate(2, 2);
                System.Drawing.Drawing2D.GraphicsPath path = Utils.RoundRectangle(r, this.CornerRadius, this.RoundCorners);
                g.DrawPath(Pens.Orange, path);
                //ControlPaint.DrawFocusRectangle(g, r, this.ForeColor, this.BackColor);
            }
        }


        #endregion

        private CustomButtonState currentState;
        private void OnStateChange(EventArgs e)
        {
            //Repaint the button only if the state has actually changed
            if (ButtonState == currentState)
                return;
            currentState = ButtonState;
            Invalidate();
        }


    }

    #region Custom TypeEditor for RoundCorners property

    [PermissionSetAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Unrestricted = true)]
    public class RoundCornersEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
        {
            if (value.GetType() != typeof(Corners) || provider == null)
                return value;

            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                CheckedListBox lb = new CheckedListBox();
                lb.BorderStyle = BorderStyle.None;
                lb.CheckOnClick = true;

                Corners instanceCorners = ((CustomButton)context.Instance).RoundCorners;

                lb.Items.Add("TopLeft", (instanceCorners & Corners.TopLeft) == Corners.TopLeft);
                lb.Items.Add("TopRight", (instanceCorners & Corners.TopRight) == Corners.TopRight);
                lb.Items.Add("BottomLeft", (instanceCorners & Corners.BottomLeft) == Corners.BottomLeft);
                lb.Items.Add("BottomRight", (instanceCorners & Corners.BottomRight) == Corners.BottomRight);

                edSvc.DropDownControl(lb);
                Corners cornerFlags = Corners.None;
                if (lb.CheckedItems != null && lb.CheckedItems.Count > 0)
                {
                    foreach (object o in lb.CheckedItems)
                    {
                        cornerFlags = cornerFlags | (Corners)Enum.Parse(typeof(Corners), o.ToString());
                    }
                }
                lb.Dispose();
                edSvc.CloseDropDown();
                return cornerFlags;
            }
            return value;
        }

    }

    #endregion

}
