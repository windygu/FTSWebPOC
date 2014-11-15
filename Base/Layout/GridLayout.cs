#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Global.Utilities;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for GridLayout.
    /// </summary>
    /// 
    [ToolboxItemFilter("System.Windows.Forms"), ProvideProperty("ParticipateInLayout", typeof (Control)),
     ToolboxBitmap(typeof (GridLayout), "GridLayout.bmp")]
    public class GridLayout : LayoutManager {
        // Fields
        private int columns;
        private const int DefaultGap = 0;
        private int hGap;
        private int rows;
        private int vGap;

        public GridLayout() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.rows = 1;
            this.columns = 0;
            this.hGap = 0;
            this.vGap = 0;
        }

        public GridLayout(IContainer container) : this() {
            if (container != null) {
                container.Add(this);
            }
        }

        public GridLayout(Control container) : this() {
            base.ContainerControl = container;
        }

        public GridLayout(Control container, int rows, int columns) : this(container) {
            this.rows = rows;
            this.columns = columns;
        }

        public GridLayout(Control container, int rows, int columns, int hGap, int vGap) : this(container, rows, columns) {
            this.hGap = hGap;
            this.vGap = vGap;
        }

        [Browsable(false)]
        public override Size GetMinimumSize(Control control) {
            return base.GetMinimumSize(control);
        }

        [Localizable(true), Category("Layout Manager")]
        public bool GetParticipateInLayout(Control control) {
            if (base.LayoutControls.IndexOf(control) != -1) {
                return true;
            }
            return false;
        }

        [Browsable(false)]
        public override Size GetPreferredSize(Control control) {
            return base.GetPreferredSize(control);
        }

        public override void LayoutContainer() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                base.ContainerControl.SuspendLayout();
                Rectangle rectangle1 = this.GetBounds();
                IList list1 = this.GetControls();
                int num1 = list1.Count;
                int num2 = this.Rows;
                int num3 = this.Columns;
                if (num1 != 0) {
                    if (num2 > 0) {
                        num3 = ((num1 + num2) - 1)/num2;
                    } else {
                        num2 = ((num1 + num3) - 1)/num3;
                    }
                    int num4 = rectangle1.Width;
                    int num5 = rectangle1.Height;
                    num4 -= ((num3 - 1)*this.hGap);
                    int num6 = num4%num3;
                    num4 /= num3;
                    num5 -= ((num2 - 1)*this.vGap);
                    int num7 = num5%num2;
                    num5 /= num2;
                    int num8 = rectangle1.Left + ((int) Math.Ceiling((double) (((float) num6)/2f)));
                    int num9 = rectangle1.Top + ((int) Math.Ceiling((double) (((float) num7)/2f)));
                    int num10 = 0;
                    for (int num11 = 0; num10 < num3; num11 += (num4 + this.hGap)) {
                        int num12 = 0;
                        for (int num13 = 0; num12 < num2; num13 += (num5 + this.vGap)) {
                            int num14 = (num12*num3) + num10;
                            if (num14 < num1) {
                                ControlBounds bounds1 = base.GetChildControlBounds((Control) list1[num14]);
                                bounds1.Bounds = new Rectangle(num8 + num11, num9 + num13, num4, num5);
                            }
                            num12++;
                        }
                        num10++;
                    }
                    base.ContainerControl.ResumeLayout(false);
                    Monitor.Exit(this);
                }
            }
        }

        public override Size MinimumLayoutSize() {
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            int num2 = this.Rows;
            int num3 = this.Columns;
            if (num2 > 0) {
                num3 = ((num1 + num2) - 1)/num2;
            } else {
                num2 = ((num1 + num3) - 1)/num3;
            }
            int num4 = 0;
            int num5 = 0;
            for (int num6 = 0; num6 < num1; num6++) {
                Control control1 = list1[num6] as Control;
                Size size1 = this.GetMinimumSize(control1);
                if (num4 < size1.Width) {
                    num4 = size1.Width;
                }
                if (num5 < size1.Height) {
                    num5 = size1.Height;
                }
            }
            return new Size((((num3*num4) + ((num3 - 1)*this.HGap)) + base.HorzNearMargin) + base.HorzFarMargin,
                            (((num2*num5) + ((num2 - 1)*this.VGap)) + base.TopMargin) + base.BottomMargin);
        }

        protected override void OnContainerControlChanged(EventArgs e) {
            base.OnContainerControlChanged(e);
            if ((base.ContainerControl != null) && !base.LoadingDocument) {
                foreach (Control control1 in base.ContainerControl.Controls) {
                    this.SetParticipateInLayout(control1, true);
                }
            }
        }

        protected override void OnControlAdded(object sender, ControlEventArgs e) {
            this.SetParticipateInLayout(e.Control, true);
            base.OnControlAdded(sender, e);
        }

        public override Size PreferredLayoutSize() {
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            int num2 = this.Rows;
            int num3 = this.Columns;
            if (num2 > 0) {
                num3 = ((num1 + num2) - 1)/num2;
            } else {
                num2 = ((num1 + num3) - 1)/num3;
            }
            int num4 = 0;
            int num5 = 0;
            for (int num6 = 0; num6 < num1; num6++) {
                Control control1 = list1[num6] as Control;
                Size size1 = this.GetPreferredSize(control1);
                if (num4 < size1.Width) {
                    num4 = size1.Width;
                }
                if (num5 < size1.Height) {
                    num5 = size1.Height;
                }
            }
            return new Size(base.AdjustWidthForMargins((num3*num4) + ((num3 - 1)*this.HGap)),
                            base.AdjustHeightForMargins((num2*num5) + ((num2 - 1)*this.VGap)));
        }

        protected override void ResetLayoutInfo() {
            base.ResetLayoutInfo();
            this.rows = 1;
            this.columns = 0;
        }

        public void SetParticipateInLayout(Control control, bool value) {
            if (value) {
                this.AddLayoutComponent(control, null);
            } else {
                this.RemoveLayoutComponent(control);
            }
        }

        [Description("Specifies the number of columns in the grid."), Category("Appearance")]
        public int Columns {
            get { return this.columns; }
            set {
                if (this.columns != value) {
                    if (value < 0) {
                        value = 0;
                    }
                    this.columns = value;
                    int num1 = this.Rows;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [DefaultValue(0), Description("Specifies the horizontal spacing between the layout border and the components."),
         Category("Appearance")]
        public int HGap {
            get { return this.hGap; }
            set {
                if (this.hGap != value) {
                    this.hGap = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [Category("Appearance"), Description("Specifies the number of rows in the grid.")]
        public int Rows {
            get {
                if ((this.rows == 0) && (this.columns == 0)) {
                    this.rows = 1;
                }
                return this.rows;
            }
            set {
                if (this.rows != value) {
                    if (value < 0) {
                        value = 0;
                    }
                    this.rows = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [Category("Appearance"), DefaultValue(0),
         Description("Specifies the vertical spacing between the layout border and the components.")]
        public int VGap {
            get { return this.vGap; }
            set {
                if (this.vGap != value) {
                    this.vGap = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }
    }
}