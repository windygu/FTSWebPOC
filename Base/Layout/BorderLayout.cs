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
    /// Summary description for BorderLayout.
    /// </summary>
    /// 
    [ProvideProperty("Position", typeof (Control)), ToolboxItemFilter("System.Windows.Forms"),
     ToolboxBitmap(typeof (BorderLayout), "BorderLayout.bmp")]
    public class BorderLayout : LayoutManager {
        // Fields
        private int hGap;
        private Hashtable positionVsControls;
        private int vGap;

        public BorderLayout() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.positionVsControls = new Hashtable();
        }

        public BorderLayout(IContainer container) : this() {
            if (container != null) {
                container.Add(this);
            }
        }

        public BorderLayout(Control container) : this() {
            base.ContainerControl = container;
        }

        public BorderLayout(Control container, int vGap, int hGap) : this() {
            base.ContainerControl = container;
            this.vGap = vGap;
            this.hGap = hGap;
        }

        public override void AddLayoutComponent(Control childControl, object constraints) {
            if ((constraints == null) || (typeof (BorderPosition) != constraints.GetType())) {
                throw new ArgumentException(
                    "Constraints should be of the BorderPosition when calling AddLayoutComponent", "constraints");
            }
            BorderPosition position1 = (BorderPosition) constraints;
            BorderPosition position2 = this.GetPositionFromControl(childControl);
            if (position2 != position1) {
                if (base.ContainerControl != null) {
                    base.ContainerControl.SuspendLayout();
                }
                this.RemoveLayoutComponent(childControl);
                if (position1 != BorderPosition.None) {
                    this.positionVsControls[position1] = childControl;
                }
                base.AddLayoutComponent(childControl, constraints);
                if (base.ContainerControl != null) {
                    base.ContainerControl.ResumeLayout(false);
                    base.ContainerControl.PerformLayout(childControl, "Bounds");
                }
            }
        }

        private int CalcMax(params int[] values) {
            int num1 = 0;
            int[] numArray1 = values;
            for (int num3 = 0; num3 < numArray1.Length; num3++) {
                int num2 = numArray1[num3];
                if (num1 < num2) {
                    num1 = num2;
                }
            }
            return num1;
        }

        private Control GetControlFromPosition(BorderPosition direction) {
            object obj1 = this.positionVsControls[direction];
            if (obj1 != null) {
                return (obj1 as Control);
            }
            return null;
        }

        [Browsable(false)]
        public override Size GetMinimumSize(Control control) {
            return base.GetMinimumSize(control);
        }

        [Category("Layout Manager")]
        public BorderPosition GetPosition(Control control) {
            return this.GetPositionFromControl(control);
        }

        private BorderPosition GetPositionFromControl(Control control) {
            object obj1 = null;
            foreach (object obj2 in this.positionVsControls.Keys) {
                if (this.positionVsControls[obj2] == control) {
                    obj1 = obj2;
                    break;
                }
            }
            if (obj1 != null) {
                return (BorderPosition) obj1;
            }
            return BorderPosition.None;
        }

        [Browsable(false)]
        public override Size GetPreferredSize(Control control) {
            return base.GetPreferredSize(control);
        }

        protected override Size GetStaticPreferredSize(Control control) {
            Size size1 = base.GetStaticPreferredSize(control);
            BorderPosition position1 = this.GetPositionFromControl(control);
            Size size2 = size1;
            if (position1 != BorderPosition.None) {
                switch (position1) {
                    case BorderPosition.North:
                    case BorderPosition.South: {
                        size2.Height = control.Size.Height;
                        break;
                    }
                    case BorderPosition.East:
                    case BorderPosition.West: {
                        size2.Width = control.Size.Width;
                        break;
                    }
                }
                if (size2 != size1) {
                    this.SetPreferredSize(control, size2);
                }
            }
            return size2;
        }

        public override void LayoutContainer() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                base.ContainerControl.SuspendLayout();
                Rectangle rectangle1 = this.GetBounds();
                Size size1 = Size.Empty;
                Size size2 = Size.Empty;
                Size size3 = Size.Empty;
                Size size4 = Size.Empty;
                Size size5 = Size.Empty;
                this.LookupPreferredSizes(ref size1, ref size2, ref size3, ref size4, ref size5);
                Size size6 = Size.Empty;
                Size size7 = Size.Empty;
                Size size8 = Size.Empty;
                Size size9 = Size.Empty;
                Size size10 = Size.Empty;
                if (!size1.IsEmpty) {
                    size6.Height = size1.Height;
                    size6.Width = rectangle1.Width;
                }
                if (!size2.IsEmpty) {
                    size7.Height = size2.Height;
                    size7.Width = rectangle1.Width;
                }
                int num1 = Math.Max(0, (int) (rectangle1.Height - (size6.Height + size7.Height)));
                if (!size4.IsEmpty) {
                    size9.Width = size4.Width;
                    size9.Height = num1;
                }
                if (!size3.IsEmpty) {
                    size8.Width = size3.Width;
                    size8.Height = num1;
                }
                int num2 = Math.Max(0, (int) (rectangle1.Width - (size9.Width + size8.Width)));
                size10.Width = num2;
                size10.Height = num1;
                int[] numArray1 = new int[3] {size8.Height, size10.Height, size9.Height};
                int num3 = this.CalcMax(numArray1);
                int num4 = 2*this.vGap;
                int num5 = (num3 >= num4) ? num4 : num3;
                if (size8.Height != 0) {
                    size8.Height -= num5;
                }
                if (size9.Height != 0) {
                    size9.Height -= num5;
                }
                if (size10.Height != 0) {
                    size10.Height -= num5;
                }
                numArray1 = new int[3] {size8.Height, size10.Height, size9.Height};
                num3 = this.CalcMax(numArray1);
                int num6 = 2*this.hGap;
                int num7 = (size10.Width >= num6) ? num6 : size10.Width;
                if (size10.Width != 0) {
                    size10.Width -= num7;
                }
                int num8 = rectangle1.X;
                int num9 = (num8 + size8.Width) + (num7/2);
                int num10 = (num9 + size10.Width) + (num7/2);
                int num11 = rectangle1.Y;
                int num12 = (num11 + size6.Height) + (num5/2);
                int num13 = (num12 + num3) + (num5/2);
                Rectangle rectangle2 = new Rectangle(new Point(num8, num11), size6);
                Rectangle rectangle3 = new Rectangle(new Point(num8, num13), size7);
                Rectangle rectangle4 = new Rectangle(new Point(num8, num12), size8);
                Rectangle rectangle5 = new Rectangle(new Point(num10, num12), size9);
                Rectangle rectangle6 = new Rectangle(new Point(num9, num12), size10);
                Control control1 = null;
                if ((control1 = this.GetControlFromPosition(BorderPosition.North)) != null) {
                    control1.Bounds = rectangle2;
                }
                if ((control1 = this.GetControlFromPosition(BorderPosition.South)) != null) {
                    control1.Bounds = rectangle3;
                }
                if ((control1 = this.GetControlFromPosition(BorderPosition.West)) != null) {
                    control1.Bounds = rectangle4;
                }
                if ((control1 = this.GetControlFromPosition(BorderPosition.East)) != null) {
                    control1.Bounds = rectangle5;
                }
                if ((control1 = this.GetControlFromPosition(BorderPosition.Center)) != null) {
                    control1.Bounds = rectangle6;
                }
                base.ContainerControl.ResumeLayout(false);
                Monitor.Exit(this);
            }
        }

        private void LookupPreferredSizes(ref Size prefSizeNorth, ref Size prefSizeSouth, ref Size prefSizeWest,
                                          ref Size prefSizeEast, ref Size prefSizeCenter) {
            Control control1 = null;
            if ((control1 = this.GetControlFromPosition(BorderPosition.North)) != null) {
                prefSizeNorth = this.GetPreferredSize(control1);
            }
            if ((control1 = this.GetControlFromPosition(BorderPosition.South)) != null) {
                prefSizeSouth = this.GetPreferredSize(control1);
            }
            if ((control1 = this.GetControlFromPosition(BorderPosition.West)) != null) {
                prefSizeWest = this.GetPreferredSize(control1);
            }
            if ((control1 = this.GetControlFromPosition(BorderPosition.East)) != null) {
                prefSizeEast = this.GetPreferredSize(control1);
            }
            if ((control1 = this.GetControlFromPosition(BorderPosition.Center)) != null) {
                prefSizeCenter = this.GetPreferredSize(control1);
            }
        }

        public override Size MinimumLayoutSize() {
            return this.PreferredLayoutSize();
        }

        public override Size PreferredLayoutSize() {
            Size size1 = Size.Empty;
            Size size2 = Size.Empty;
            Size size3 = Size.Empty;
            Size size4 = Size.Empty;
            Size size5 = Size.Empty;
            this.LookupPreferredSizes(ref size1, ref size2, ref size3, ref size4, ref size5);
            int[] numArray1 = new int[3] {size1.Width, size2.Width, (size3.Width + size4.Width) + size5.Width};
            int num1 = this.CalcMax(numArray1);
            numArray1 = new int[3] {size3.Height, size5.Height, size4.Height};
            int num2 = (size1.Height + size2.Height) + this.CalcMax(numArray1);
            return new Size(num1, num2);
        }

        public override void RemoveLayoutComponent(Control childControl) {
            BorderPosition position1 = this.GetPositionFromControl(childControl);
            if (position1 != BorderPosition.None) {
                this.positionVsControls.Remove(position1);
            }
            if (this.preferredSizes[childControl] != null) {
                Size size1 = (Size) this.preferredSizes[childControl];
                childControl.Size = size1;
                this.preferredSizes.Remove(childControl);
            }
            base.RemoveLayoutComponent(childControl);
        }

        private void ResetPosition(Control control) {
            this.SetPosition(control, BorderPosition.None);
        }

        public void SetPosition(Control control, BorderPosition position) {
            if (position == BorderPosition.None) {
                this.RemoveLayoutComponent(control);
            } else {
                this.AddLayoutComponent(control, position);
            }
        }

        private bool ShouldSerializePosition(Control control) {
            BorderPosition position1 = this.GetPositionFromControl(control);
            if (position1 != BorderPosition.None) {
                return true;
            }
            return false;
        }

        [Category("Appearance")]
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

        [Category("Appearance")]
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