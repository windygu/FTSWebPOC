#region

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for LayoutManager.
    /// </summary>
    ///
    public delegate void ProvideLayoutInformationEventHandler(object sender, ProvideLayoutInformationEventArgs e);

    [ProvideProperty("MinimumSize", typeof (Control)), Designer(typeof (LMDesigner), typeof (IDesigner)),
     ProvideProperty("PreferredSize", typeof (Control))]
    public abstract class LayoutManager : Component, ILayoutManager, IExtenderProvider, ISupportInitialize {
        // Events
        public event EventHandler ContainerControlChanged;
        public event ProvideLayoutInformationEventHandler ProvideLayoutInformation;
        // Fields
        private bool autoLayout;
        private int bottomMargin;
        private IDesigner componentDesigner;
        private Control container;
        private ArrayList controlList;
        private Rectangle customLayoutBounds;
        private IDesignerHost designerHost;
        private int horzFarMargin;
        private int horzNearMargin;
        protected Hashtable minimumSizes;
        protected Hashtable preferredSizes;
        private int topMargin;
        private bool useControlCollectionPosition;

        protected LayoutManager() {
            this.autoLayout = true;
            this.designerHost = null;
            this.componentDesigner = null;
            this.customLayoutBounds = Rectangle.Empty;
            this.preferredSizes = new Hashtable();
            this.minimumSizes = new Hashtable();
            this.controlList = new ArrayList();
            this.useControlCollectionPosition = true;
            this.topMargin = 0;
            this.bottomMargin = 0;
            this.horzFarMargin = 0;
            this.horzNearMargin = 0;
        }

        public virtual void AddLayoutComponent(Control childControl, object constraints) {
            if (childControl is LayoutItemPlaceHolderControl) {
                LayoutItemPlaceHolderControl control1 = (LayoutItemPlaceHolderControl) childControl;
                control1.LayoutManager = this;
            }
            if (this.controlList.IndexOf(childControl) == -1) {
                childControl.DockChanged += new EventHandler(this.OnDockStyleChanged);
                this.OnDockStyleChanged(childControl, EventArgs.Empty);
                this.controlList.Add(childControl);
                if (this.ContainerControl != null) {
                    this.ContainerControl.PerformLayout();
                }
            }
        }

        protected int AdjustHeightForMargins(int height) {
            height += this.topMargin;
            height += this.bottomMargin;
            return height;
        }

        protected int AdjustWidthForMargins(int width) {
            width += this.horzNearMargin;
            width += this.horzFarMargin;
            return width;
        }

        protected virtual bool CanExtend(object target) {
            if (((target is Control) && (((Control) target).Parent != null)) &&
                ((((Control) target).Parent == this.ContainerControl) && !(target is AutoLabel))) {
                return true;
            }
            return false;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                this.ResetLayoutInfo();
                this.container = null;
            }
            base.Dispose(disposing);
        }

        protected void ForcePreferredAndMinimumsSize() {
            if (this.ContainerControl != null) {
                this.ContainerControl.SuspendLayout();
            }
            foreach (Control control1 in this.GetControls()) {
                if (control1 is AutoLabel) {
                    continue;
                }
                if (!this.ShouldSerializePreferredSize(control1)) {
                    this.SetPreferredSize(control1, control1.Size);
                }
                if (!this.ShouldSerializeMinimumSize(control1)) {
                    this.SetMinimumSize(control1, control1.Size);
                }
            }
            if (this.ContainerControl != null) {
                this.ContainerControl.ResumeLayout();
            }
        }

        protected AutoLabel GetAutoLabel(Control c) {
            if (AutoLabel.AutoLabelMap.Contains(c)) {
                AutoLabel label1 = AutoLabel.AutoLabelMap[c] as AutoLabel;
                if (label1.Parent == c.Parent) {
                    return label1;
                }
            }
            return null;
        }

        protected virtual Rectangle GetBounds() {
            Rectangle rectangle1 = Rectangle.Empty;
            if (!this.customLayoutBounds.IsEmpty) {
                rectangle1 = this.customLayoutBounds;
            } else {
                rectangle1 = this.ContainerControl.ClientRectangle;
                if (this.ContainerControl is ScrollableControl) {
                    rectangle1.Offset((this.ContainerControl as ScrollableControl).AutoScrollPosition);
                }
            }
            rectangle1.X += this.horzNearMargin;
            rectangle1.Width -= this.horzNearMargin;
            rectangle1.Width -= this.horzFarMargin;
            rectangle1.Y += this.topMargin;
            rectangle1.Height -= this.topMargin;
            rectangle1.Height -= this.bottomMargin;
            return rectangle1;
        }

        internal ControlBounds GetChildControlBounds(Control c) {
            return this.GetChildControlBounds(c, c.Size);
        }

        internal ControlBounds GetChildControlBounds(Control c, Size prefSize) {
            if (this.ContainerControl.RightToLeft == RightToLeft.No) {
                return new ControlBounds(new Rectangle(c.Location, prefSize), c);
            }
            Rectangle rectangle1 = this.GetBounds();
            ControlBounds bounds1 = new ControlBounds(c.Bounds, c,
                                                      new RTLMatrix(rectangle1.Left, this.HorzFarMargin,
                                                                    rectangle1.Width));
            Rectangle rectangle2 = new Rectangle(new Point(bounds1.Bounds.X, bounds1.Bounds.Y), prefSize);
            bounds1.SetOnlyInternalBounds(rectangle2);
            return bounds1;
        }

        public virtual IList GetControls() {
            if (!this.UseControlCollectionPosition) {
                return (ArrayList) this.controlList.Clone();
            }
            ArrayList list1 = new ArrayList();
            if (this.ContainerControl != null) {
                foreach (Control control1 in this.ContainerControl.Controls) {
                    if ((this.controlList.IndexOf(control1) > -1) && !(control1 is MdiClient)) {
                        list1.Add(control1);
                    }
                }
                if (list1.Count == this.controlList.Count) {
                    return list1;
                }
                foreach (Control control2 in this.controlList) {
                    if (!this.ContainerControl.Contains(control2)) {
                        list1.Add(control2);
                    }
                }
            }
            return list1;
        }

        protected virtual bool GetDynamicSize(Control control, LayoutInformationType type, ref Size size) {
            if (control is IProvideLayoutInformation) {
                if (type == LayoutInformationType.MinimumSize) {
                    size = ((IProvideLayoutInformation) control).MinimumSize;
                } else if (type == LayoutInformationType.PreferredSize) {
                    size = ((IProvideLayoutInformation) control).PreferredSize;
                }
                return true;
            }
            ProvideLayoutInformationEventArgs args1 = new ProvideLayoutInformationEventArgs(control, type);
            this.OnProvideLayoutInformation(args1);
            if (args1.Handled) {
                size = args1.Size;
            }
            return args1.Handled;
        }

        [Category("Layout Manager"), Localizable(true)]
        public virtual Size GetMinimumSize(Control control) {
            Size size1 = Size.Empty;
            if (this.GetDynamicSize(control, LayoutInformationType.MinimumSize, ref size1)) {
                return size1;
            }
            return this.GetStaticMinimumSize(control);
        }

        [Category("Layout Manager"), Localizable(true)]
        public virtual Size GetPreferredSize(Control control) {
            Size size1 = Size.Empty;
            if (this.GetDynamicSize(control, LayoutInformationType.PreferredSize, ref size1)) {
                return size1;
            }
            return this.GetStaticPreferredSize(control);
        }

        protected virtual Size GetStaticMinimumSize(Control control) {
            if (this.minimumSizes[control] == null) {
                this.SetMinimumSize(control, control.Size);
            }
            return (Size) this.minimumSizes[control];
        }

        protected virtual Size GetStaticPreferredSize(Control control) {
            if (this.preferredSizes[control] == null) {
                this.SetPreferredSize(control, control.Size);
            }
            return (Size) this.preferredSizes[control];
        }

        protected virtual bool IsInit() {
            if ((this.ContainerControl == null) ||
                ((this.controlList.Count <= 0) && (this.ContainerControl.Controls.Count <= 0))) {
                return false;
            }
            return true;
        }

        protected bool IsVisible(Control control) {
            if (control is LayoutItemPlaceHolderControl) {
                return ((LayoutItemPlaceHolderControl) control).Visible;
            }
            return control.Visible;
        }

        public abstract void LayoutContainer();

        protected void MakeDirty() {
            if ((this.componentDesigner != null) && (this.componentDesigner is IAllowMakeDirty)) {
                IAllowMakeDirty dirty1 = this.componentDesigner as IAllowMakeDirty;
                dirty1.SetDirty();
            }
        }

        public abstract Size MinimumLayoutSize();

        protected virtual void OnContainerControlChanged(EventArgs e) {
            if (this.ContainerControl == null) {
                this.controlList.Clear();
            }
            if (this.ContainerControlChanged != null) {
                this.ContainerControlChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnControlAdded(object sender, ControlEventArgs e) {
            this.OnDockStyleChanged(e.Control, EventArgs.Empty);
        }

        protected virtual void OnControlRemoved(object sender, ControlEventArgs e) {
            this.RemoveLayoutComponent(e.Control);
        }

        protected virtual void OnDockStyleChanged(object sender, EventArgs e) {
            Control control1 = sender as Control;
            if (((control1 != null) && !(control1 is MdiClient)) &&
                ((control1.Dock != DockStyle.None) && (this.controlList.IndexOf(control1) != -1))) {
                control1.Dock = DockStyle.None;
                if (base.DesignMode) {
                    MessageBox.Show(
                        "Controls managed by the LayoutManager cannot have a DockStyle. Resetting Control's DockStyle to DockStyle.None",
                        "LayoutManager Warning");
                }
            }
        }

        private void OnLayoutEvent(object sender, LayoutEventArgs e) {
            if (this.AutoLayout) {
                this.LayoutContainer();
            }
        }

        protected virtual void OnProvideLayoutInformation(ProvideLayoutInformationEventArgs args) {
            if (this.ProvideLayoutInformation != null) {
                this.ProvideLayoutInformation(this, args);
            }
        }

        private void OnRTLChanged(object sender, EventArgs e) {
            if (this.AutoLayout) {
                this.ContainerControl.SuspendLayout();
                foreach (Control control1 in this.ContainerControl.Controls) {
                    if (control1 is AutoLabel) {
                        AutoLabel label1 = control1 as AutoLabel;
                        label1.UpdatePosition();
                    }
                }
                this.ContainerControl.ResumeLayout(false);
                this.LayoutContainer();
            }
        }

        public abstract Size PreferredLayoutSize();

        public virtual void RemoveLayoutComponent(Control childControl) {
            if (this.controlList.Contains(childControl)) {
                if (childControl is LayoutItemPlaceHolderControl) {
                    LayoutItemPlaceHolderControl control1 = (LayoutItemPlaceHolderControl) childControl;
                    control1.LayoutManager = null;
                }
                this.controlList.Remove(childControl);
                childControl.DockChanged -= new EventHandler(this.OnDockStyleChanged);
                if (this.ContainerControl != null) {
                    this.ContainerControl.PerformLayout();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void ResetCustomLayoutBounds() {
            this.CustomLayoutBounds = Rectangle.Empty;
        }

        protected virtual void ResetLayoutInfo() {
            if (this.container != null) {
                this.container.Layout -= new LayoutEventHandler(this.OnLayoutEvent);
                this.container.ControlAdded -= new ControlEventHandler(this.OnControlAdded);
                this.container.ControlRemoved -= new ControlEventHandler(this.OnControlRemoved);
                this.container.RightToLeftChanged -= new EventHandler(this.OnRTLChanged);
            }
            this.controlList.Clear();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetMinimumSize(Control control) {
            this.minimumSizes[control] = null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetPreferredSize(Control control) {
            this.preferredSizes[control] = null;
        }

        public virtual void SetMinimumSize(Control control, Size value) {
            if (this.minimumSizes[control] != null) {
                Size size1 = (Size) this.minimumSizes[control];
                if (size1.Equals(value)) {
                    return;
                }
            }
            this.minimumSizes[control] = value;
            if (this.ContainerControl != null) {
                this.ContainerControl.PerformLayout();
            }
        }

        public virtual void SetPreferredSize(Control control, Size value) {
            if (this.preferredSizes[control] != null) {
                Size size1 = (Size) this.preferredSizes[control];
                if (size1.Equals(value)) {
                    return;
                }
            }
            this.preferredSizes[control] = value;
            if (this.ContainerControl != null) {
                this.ContainerControl.PerformLayout();
            }
        }

        protected virtual bool ShouldLayoutAutoLabel(AutoLabel autoLabel) {
            if (autoLabel.LabeledControl == null) {
                return true;
            }
            if (autoLabel.LabeledControl.Parent != autoLabel.Parent) {
                return true;
            }
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool ShouldSerializeCustomLayoutBounds() {
            if (this.CustomLayoutBounds == Rectangle.Empty) {
                return false;
            }
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool ShouldSerializeMinimumSize(Control control) {
            return (this.minimumSizes[control] != null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool ShouldSerializePreferredSize(Control control) {
            return (this.preferredSizes[control] != null);
        }

        bool IExtenderProvider.CanExtend(object target) {
            return this.CanExtend(target);
        }

        void ISupportInitialize.BeginInit() {
        }

        void ISupportInitialize.EndInit() {
            if (((this.ContainerControl != null) && base.DesignMode) && (this.ContainerControl is UserControl)) {
                this.ContainerControl.PerformLayout();
            }
        }

        [Description("Specifies whether the manger should layout automatically on Layout event."), DefaultValue(true)]
        public bool AutoLayout {
            get { return this.autoLayout; }
            set {
                if (this.autoLayout != value) {
                    this.autoLayout = value;
                    this.MakeDirty();
                }
            }
        }

        [DefaultValue(0), Category("Appearance")]
        public int BottomMargin {
            get { return this.bottomMargin; }
            set {
                if (this.bottomMargin != value) {
                    this.bottomMargin = value;
                    if (this.ContainerControl != null) {
                        this.ContainerControl.PerformLayout();
                    }
                    this.MakeDirty();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IDesigner ComponentDesigner {
            get { return this.componentDesigner; }
            set { this.componentDesigner = value; }
        }

        [Description("Specifies the container control that this manager will lay out."), Category("Behavior"),
         DefaultValue((string) null)]
        public Control ContainerControl {
            get { return this.container; }
            set {
                if (this.container != value) {
                    if (this.container != null) {
                        this.ResetLayoutInfo();
                    }
                    this.container = value;
                    if (this.container != null) {
                        this.container.Layout += new LayoutEventHandler(this.OnLayoutEvent);
                        this.container.ControlAdded += new ControlEventHandler(this.OnControlAdded);
                        this.container.ControlRemoved += new ControlEventHandler(this.OnControlRemoved);
                        this.container.RightToLeftChanged += new EventHandler(this.OnRTLChanged);
                    }
                    this.OnContainerControlChanged(EventArgs.Empty);
                }
            }
        }

        [Description(
            "Specifies the custom layout bounds, if any, to be used for layout calculation instead of the container control's ClientRectangle."
            ), Localizable(true)]
        public Rectangle CustomLayoutBounds {
            get { return this.customLayoutBounds; }
            set {
                if (this.customLayoutBounds != value) {
                    this.customLayoutBounds = value;
                    if (this.ContainerControl != null) {
                        this.ContainerControl.PerformLayout();
                    }
                    this.MakeDirty();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IDesignerHost DesignerHost {
            get { return this.designerHost; }
            set { this.designerHost = value; }
        }

        protected bool DesignerInTransaction {
            get {
                if (this.designerHost != null) {
                    return this.designerHost.InTransaction;
                }
                return false;
            }
        }

        [DefaultValue(0), Category("Appearance")]
        public int HorzFarMargin {
            get { return this.horzFarMargin; }
            set {
                if (this.horzFarMargin != value) {
                    this.horzFarMargin = value;
                    if (this.ContainerControl != null) {
                        this.ContainerControl.PerformLayout();
                    }
                    this.MakeDirty();
                }
            }
        }

        [DefaultValue(0), Category("Appearance")]
        public int HorzNearMargin {
            get { return this.horzNearMargin; }
            set {
                if (this.horzNearMargin != value) {
                    this.horzNearMargin = value;
                    if (this.ContainerControl != null) {
                        this.ContainerControl.PerformLayout();
                    }
                    this.MakeDirty();
                }
            }
        }

        [Description("Specifies the list of child components participating in layout."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ArrayList LayoutControls {
            get { return this.controlList; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         Obsolete("This method has been replaced by HorzNearMargin. Please use that instead.")]
        public int LeftMargin {
            get { return this.HorzNearMargin; }
            set { this.HorzNearMargin = value; }
        }

        protected bool LoadingDocument {
            get {
                if (this.designerHost != null) {
                    return this.designerHost.Loading;
                }
                return false;
            }
        }

        [Browsable(false), Obsolete("This method has been replaced by HorzFarMargin. Please use that instead."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RightMargin {
            get { return this.HorzFarMargin; }
            set { this.HorzFarMargin = value; }
        }

        [DefaultValue(0), Category("Appearance")]
        public int TopMargin {
            get { return this.topMargin; }
            set {
                if (this.topMargin != value) {
                    this.topMargin = value;
                    if (this.ContainerControl != null) {
                        this.ContainerControl.PerformLayout();
                    }
                    this.MakeDirty();
                }
            }
        }

        [Description(
            "Specifies whether the container control's child ControlCollection (gotten from the controls property) should be used as the order for laying out the child controls."
            ), DefaultValue(true), Browsable(false)]
        public bool UseControlCollectionPosition {
            get { return this.useControlCollectionPosition; }
            set { this.useControlCollectionPosition = value; }
        }
    }
}