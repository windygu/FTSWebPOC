#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Global.Utilities;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for AutoLabel.
    /// </summary>
    /// 
    public delegate void SyncfusionPropertyChangedEventHandler(object sender, SyncfusionPropertyChangedEventArgs e);

    [ToolboxBitmap(typeof (AutoLabel), "AutoLabel.bmp")]
    public class AutoLabel : Label {
        // Events
        public event SyncfusionPropertyChangedEventHandler PropertyChanged;
        // Fields
        private const int DEF_WITH_BORDERS = 6;
        private const int DEF_WITHOUT_BORDERS = 3;
        private int dx;
        private int dy;
        private int gap;
        private static Hashtable htAutoLabelsByControl;
        private Control labeledControl;
        private AutoLabelPosition position;
        private bool settingPos;

        public AutoLabel() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.labeledControl = null;
            this.position = AutoLabelPosition.Left;
            this.gap = 4;
            this.dx = 0;
            this.dy = 0;
            this.settingPos = false;
            this.AutoSize = true;
        }

        static AutoLabel() {
            htAutoLabelsByControl = new Hashtable();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                this.LabeledControl = null;
            }
            base.Dispose(disposing);
        }

        private void LabeledControl_LocationChanged(object sender, EventArgs e) {
            this.UpdatePosition();
        }

        private void LabeledControl_SizeChanged(object sender, EventArgs e) {
            if (this.RightToLeft == RightToLeft.Yes) {
                this.UpdatePosition();
            }
        }

        private Size MesureText(string text, Font font) {
            SizeF ef1;
            if (text == null) {
                throw new ArgumentNullException("text");
            }
            if (font == null) {
                throw new ArgumentNullException("font");
            }
            using (Graphics graphics1 = base.CreateGraphics()) {
                StringFormat format1 = StringFormat.GenericDefault;
                format1.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                ef1 = graphics1.MeasureString(text, font, 0x7fffffff, format1);
            }
            return ef1.ToSize();
        }

        protected virtual void OnAttachLabeledControl(Control labeledControl) {
            if (labeledControl != null) {
                AutoLabelMap[labeledControl] = this;
                labeledControl.LocationChanged += new EventHandler(this.LabeledControl_LocationChanged);
                labeledControl.SizeChanged += new EventHandler(this.LabeledControl_SizeChanged);
            }
        }

        protected virtual void OnDetachLabeledControl(Control labeledControl) {
            if (labeledControl != null) {
                AutoLabelMap.Remove(labeledControl);
                labeledControl.LocationChanged -= new EventHandler(this.LabeledControl_LocationChanged);
                labeledControl.SizeChanged -= new EventHandler(this.LabeledControl_SizeChanged);
            }
        }

        protected override void OnParentRightToLeftChanged(EventArgs e) {
            base.OnParentRightToLeftChanged(e);
            this.UpdatePosition();
            if ((base.Parent != null) && (base.Parent.RightToLeft != this.RightToLeft)) {
                Trace.WriteLine("AutoLable: " + base.Name +
                                " has a RightToLeft value different from its parent's. This will cause problems while using a FlowLayout on the parent control.");
            }
        }

        protected virtual void OnPropertyChanged(SyncfusionPropertyChangedEventArgs e) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, e);
            }
        }

        protected override void OnRightToLeftChanged(EventArgs e) {
            base.OnRightToLeftChanged(e);
            this.UpdatePosition();
            if ((base.Parent != null) && (base.Parent.RightToLeft != this.RightToLeft)) {
                Trace.WriteLine("AutoLabel: " + base.Name +
                                " has a RightToLeft value different from its parent's. This will cause problems while using a FlowLayout on the parent control.");
            }
        }

        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            this.UpdatePosition();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
            if (!this.ShouldAllowBoundsChange()) {
                specified &= ((BoundsSpecified) (-4));
            } else if ((!this.settingPos && (this.LabeledControl != null)) &&
                       ((((specified & BoundsSpecified.Location) > BoundsSpecified.None) ||
                         ((specified & BoundsSpecified.X) > BoundsSpecified.None)) ||
                        ((specified & BoundsSpecified.Y) > BoundsSpecified.None))) {
                this.settingPos = true;
                if (this.RightToLeft == RightToLeft.Yes) {
                    this.DX = this.LabeledControl.Right - (x + width);
                } else {
                    this.DX = x - this.LabeledControl.Location.X;
                }
                this.DY = y - this.LabeledControl.Location.Y;
                this.settingPos = false;
                this.UpdatePosition();
                specified &= ((BoundsSpecified) (-4));
                specified &= ((BoundsSpecified) (-2));
                specified &= ((BoundsSpecified) (-3));
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private bool ShouldAllowBoundsChange() {
            if (this.Position == AutoLabelPosition.Custom) {
                return true;
            }
            return false;
        }

        protected internal virtual void UpdatePosition() {
            if (((this.LabeledControl != null) && (this.LabeledControl.Parent == base.Parent)) && !this.settingPos) {
                this.settingPos = true;
                if (this.Position == AutoLabelPosition.Custom) {
                    int num1 = (this.RightToLeft == RightToLeft.Yes)
                                   ? ((this.LabeledControl.Right - this.DX) - base.Width)
                                   : (this.LabeledControl.Location.X + this.DX);
                    int num2 = this.LabeledControl.Location.Y + this.DY;
                    base.Location = new Point(num1, num2);
                } else if (this.Position == AutoLabelPosition.Left) {
                    int num3 = this.LabeledControl.Location.Y + ((this.LabeledControl.Height - base.Height)/2);
                    int num4 = (this.RightToLeft == RightToLeft.Yes)
                                   ? (this.LabeledControl.Bounds.Right + this.gap)
                                   : ((this.LabeledControl.Location.X - this.gap) - base.Width);
                    base.Location = new Point(num4, num3);
                } else {
                    int num5 = this.LabeledControl.Location.X;
                    int num6 = (this.LabeledControl.Location.Y - this.gap) - base.Height;
                    base.Location = new Point(num5, num6);
                }
                this.settingPos = false;
            }
        }

        internal static Hashtable AutoLabelMap {
            get { return htAutoLabelsByControl; }
        }

        [DefaultValue(true)]
        public override bool AutoSize {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Category("Layout Information"),
         Description("The effective horizontal distance between the left of the AutoLabel and its labeled control.")]
        public int DX {
            get {
                if (this.LabeledControl == null) {
                    return 0;
                }
                if (this.Position == AutoLabelPosition.Custom) {
                    return this.dx;
                }
                if (this.RightToLeft == RightToLeft.Yes) {
                    return (this.LabeledControl.Right - base.Right);
                }
                return (base.Bounds.X - this.LabeledControl.Bounds.X);
            }
            set {
                if (this.dx != value) {
                    int num1 = this.dx;
                    this.dx = value;
                    this.UpdatePosition();
                    this.OnPropertyChanged(new SyncfusionPropertyChangedEventArgs(PropertyChangeEffect.NeedLayout, "DX",
                                                                                  num1, value));
                }
            }
        }

        [Description("The effective vertical distance between the top of the AutoLabel and its labeled control."),
         Category("Layout Information")]
        public int DY {
            get {
                if (this.LabeledControl == null) {
                    return 0;
                }
                if (this.Position == AutoLabelPosition.Custom) {
                    return this.dy;
                }
                return (base.Bounds.Y - this.LabeledControl.Bounds.Y);
            }
            set {
                if (this.dy != value) {
                    int num1 = this.dy;
                    this.dy = value;
                    this.UpdatePosition();
                    this.OnPropertyChanged(new SyncfusionPropertyChangedEventArgs(PropertyChangeEffect.NeedLayout, "DY",
                                                                                  num1, value));
                }
            }
        }

        [Category("Layout Information"),
         Description("Specifies the horizontal and vertical gap to use when computing the relative position."),
         DefaultValue(4)]
        public int Gap {
            get { return this.gap; }
            set {
                if (this.gap != value) {
                    int num1 = this.gap;
                    this.gap = value;
                    this.UpdatePosition();
                    this.OnPropertyChanged(new SyncfusionPropertyChangedEventArgs(PropertyChangeEffect.NeedLayout, "Gap",
                                                                                  num1, value));
                }
            }
        }

        [Description("Specifies the control that is being labeled."), DefaultValue((string) null),
         Category("Layout Information")]
        public Control LabeledControl {
            get { return this.labeledControl; }
            set {
                if (this.labeledControl != value) {
                    if (value is AutoLabel) {
                        if (base.DesignMode) {
                            MessageBox.Show("Cannot Label an AutoLabel.", "AutoLabel error");
                        }
                    } else if ((value != null) && AutoLabelMap.Contains(value)) {
                        if (base.DesignMode) {
                            MessageBox.Show(
                                "Cannot set LabeledControl: " + value.Text +
                                ", since it's already associated with an AutoLabel", "AutoLabel error");
                        }
                    } else {
                        this.OnDetachLabeledControl(this.labeledControl);
                        Control control1 = this.labeledControl;
                        this.labeledControl = value;
                        this.OnAttachLabeledControl(value);
                        this.UpdatePosition();
                        this.OnPropertyChanged(new SyncfusionPropertyChangedEventArgs(PropertyChangeEffect.NeedLayout,
                                                                                      "LabeledControl", control1, value));
                    }
                }
            }
        }

        [DefaultValue(AutoLabelPosition.Left), Category("Layout Information"),
         Description("Specifies the relative position of the control and the AutoLabel.")]
        public AutoLabelPosition Position {
            get { return this.position; }
            set {
                if (this.position != value) {
                    AutoLabelPosition position1 = this.position;
                    this.position = value;
                    this.UpdatePosition();
                    this.OnPropertyChanged(new SyncfusionPropertyChangedEventArgs(PropertyChangeEffect.NeedLayout,
                                                                                  "Position", position1, value));
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false),
         Category("CatLayout"), Description("LabelPreferredHeightDescr"), EditorBrowsable(EditorBrowsableState.Advanced)
        ]
        public override int PreferredHeight {
            get {
                Size size1 = this.MesureText(this.Text, this.Font);
                if (this.BorderStyle != BorderStyle.None) {
                    return (size1.Height + 6);
                }
                return (size1.Height + 3);
            }
        }
    }
}