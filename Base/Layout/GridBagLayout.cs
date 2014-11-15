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
    /// Summary description for GridBagLayout.
    /// </summary>
    /// 
    [ProvideProperty("Constraints", typeof (Control)), ToolboxBitmap(typeof (GridBagLayout), "GridBagLayout.bmp"),
     ToolboxItemFilter("System.Windows.Forms")]
    public class GridBagLayout : LayoutManager {
        // Fields
        public double[] columnWeights;
        public int[] columnWidths;
        private Hashtable controlsMap;
        private GridBagLayoutInfo layoutInfo;
        public const int MaxGridSize = 0x200;
        protected static int MinimumSize;
        public const int MinSize = 1;
        protected Hashtable noFillSizes;
        protected static int PreferredSize;
        public int[] rowHeights;
        public double[] rowWeights;

        static GridBagLayout() {
            PreferredSize = 1;
            MinimumSize = 2;
        }

        public GridBagLayout() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.controlsMap = new Hashtable();
            this.noFillSizes = new Hashtable();
        }

        public GridBagLayout(IContainer container) : this() {
            if (container != null) {
                container.Add(this);
            }
        }

        public GridBagLayout(Control container) : this() {
            base.ContainerControl = container;
        }

        public override void AddLayoutComponent(Control control, object constraints) {
            if (constraints is GridBagConstraints) {
                this.SetConstraints(control, (GridBagConstraints) constraints);
            } else if (constraints != null) {
                throw new ArgumentException(
                    "Invalid GridBag constraints. Constraints must be of type GridBagConstraints");
            }
        }

        protected void AdjustForGravity(GridBagConstraints constraints, ref Rectangle r) {
            r.X += constraints.Insets.Left;
            r.Width -= (constraints.Insets.Left + constraints.Insets.Right);
            r.Y += constraints.Insets.Top;
            r.Height -= (constraints.Insets.Top + constraints.Insets.Bottom);
            int num1 = 0;
            if (((constraints.fill != FillType.Horizontal) && (constraints.fill != FillType.Both)) &&
                (r.Width > (constraints.minWidth + constraints.ipadX))) {
                num1 = r.Width - (constraints.minWidth + constraints.ipadX);
                r.Width = constraints.minWidth + constraints.ipadX;
            }
            int num2 = 0;
            if (((constraints.fill != FillType.Vertical) && (constraints.fill != FillType.Both)) &&
                (r.Height > (constraints.minHeight + constraints.ipadY))) {
                num2 = r.Height - (constraints.minHeight + constraints.ipadY);
                r.Height = constraints.minHeight + constraints.ipadY;
            }
            switch (constraints.anchor) {
                case AnchorTypes.Center: {
                    r.X += (num1/2);
                    r.Y += (num2/2);
                    return;
                }
                case AnchorTypes.North: {
                    r.X += (num1/2);
                    return;
                }
                case AnchorTypes.NorthEast: {
                    r.X += num1;
                    return;
                }
                case AnchorTypes.East: {
                    r.X += num1;
                    r.Y += (num2/2);
                    return;
                }
                case AnchorTypes.SouthEast: {
                    r.X += num1;
                    r.Y += num2;
                    return;
                }
                case AnchorTypes.South: {
                    r.X += (num1/2);
                    r.Y += num2;
                    return;
                }
                case AnchorTypes.SouthWest: {
                    r.Y += num2;
                    return;
                }
                case AnchorTypes.West: {
                    r.Y += (num2/2);
                    return;
                }
                case AnchorTypes.NorthWest: {
                    return;
                }
            }
            throw new ArgumentException("Illegal GridBag Anchor value");
        }

        [Localizable(true), Category("Layout Manager")]
        public GridBagConstraints GetConstraints(Control control) {
            return (GridBagConstraints) this.GetConstraintsRef(control).Clone();
        }

        public GridBagConstraints GetConstraintsRef(Control control) {
            GridBagConstraints constraints1 = (GridBagConstraints) this.controlsMap[control];
            if (constraints1 == null) {
                this.SetConstraints(control, GridBagConstraints.Default());
                constraints1 = (GridBagConstraints) this.controlsMap[control];
            }
            return constraints1;
        }

        public int[][] GetLayoutDimensions() {
            if (this.layoutInfo == null) {
                return new int[2][];
            }
            int[][] numArrayArray1 = new int[2][] {new int[this.layoutInfo.columns], new int[this.layoutInfo.rows]};
            Array.Copy(this.layoutInfo.minWidth, numArrayArray1[0], this.layoutInfo.columns);
            Array.Copy(this.layoutInfo.minHeight, numArrayArray1[1], this.layoutInfo.rows);
            return numArrayArray1;
        }

        protected GridBagLayoutInfo GetLayoutInfo(int sizeflag) {
            int num1;
            int num3;
            int num4;
            int num7;
            int num8;
            int num9;
            int num10;
            int num12;
            GridBagConstraints constraints1;
            Control control1;
            int num24;
            Monitor.Enter(this);
            GridBagLayoutInfo info1 = new GridBagLayoutInfo();
            info1.rows = num24 = 0;
            info1.columns = num24;
            int num11 = num12 = -1;
            int[] numArray1 = new int[0x200];
            int[] numArray2 = new int[0x200];
            IList list1 = this.GetControls();
            int num15 = 0;
            while (num15 < list1.Count) {
                control1 = list1[num15] as Control;
                if (base.IsVisible(control1)) {
                    constraints1 = this.GetConstraintsRef(control1);
                    if (!constraints1.IsEmpty) {
                        Size size1;
                        num7 = constraints1.gridPosX;
                        num8 = constraints1.gridPosY;
                        num9 = constraints1.cellSpanX;
                        if (num9 <= 0) {
                            num9 = 1;
                        }
                        num10 = constraints1.cellSpanY;
                        if (num10 <= 0) {
                            num10 = 1;
                        }
                        if ((num7 < 0) && (num8 < 0)) {
                            if (num11 >= 0) {
                                num8 = num11;
                            } else if (num12 >= 0) {
                                num7 = num12;
                            } else {
                                num8 = 0;
                            }
                        }
                        if (num7 < 0) {
                            num3 = 0;
                            for (num1 = num8; num1 < (num8 + num10); num1++) {
                                num3 = Math.Max(num3, numArray1[num1]);
                            }
                            num7 = (num3 - num7) - 1;
                            if (num7 < 0) {
                                num7 = 0;
                            }
                        } else if (num8 < 0) {
                            num4 = 0;
                            for (num1 = num7; num1 < (num7 + num9); num1++) {
                                num4 = Math.Max(num4, numArray2[num1]);
                            }
                            num8 = (num4 - num8) - 1;
                            if (num8 < 0) {
                                num8 = 0;
                            }
                        }
                        num3 = num7 + num9;
                        while (info1.columns < num3) {
                            info1.columns++;
                        }
                        num4 = num8 + num10;
                        while (info1.rows < num4) {
                            info1.rows++;
                        }
                        num1 = num7;
                        while (num1 < (num7 + num9)) {
                            numArray2[num1] = num4;
                            num1++;
                        }
                        for (num1 = num8; num1 < (num8 + num10); num1++) {
                            numArray1[num1] = num3;
                        }
                        if (sizeflag == PreferredSize) {
                            size1 = this.GetPreferredSize(control1);
                        } else {
                            size1 = this.GetMinimumSize(control1);
                        }
                        constraints1.minWidth = size1.Width;
                        constraints1.minHeight = size1.Height;
                        if ((constraints1.cellSpanY == 0) && (constraints1.cellSpanX == 0)) {
                            num11 = num12 = -1;
                        }
                        if ((constraints1.cellSpanY == 0) && (num11 < 0)) {
                            num12 = num7 + num9;
                        } else if ((constraints1.cellSpanX == 0) && (num12 < 0)) {
                            num11 = num8 + num10;
                        }
                    }
                }
                num15++;
            }
            if ((this.columnWidths != null) && (info1.columns < this.columnWidths.Length)) {
                info1.columns = this.columnWidths.Length;
            }
            if ((this.rowHeights != null) && (info1.rows < this.rowHeights.Length)) {
                info1.rows = this.rowHeights.Length;
            }
            num11 = num12 = -1;
            numArray1 = new int[0x200];
            numArray2 = new int[0x200];
            num15 = 0;
            while (num15 < list1.Count) {
                control1 = list1[num15] as Control;
                if (base.IsVisible(control1)) {
                    constraints1 = this.GetConstraintsRef(control1);
                    if (!constraints1.IsEmpty) {
                        num7 = constraints1.gridPosX;
                        num8 = constraints1.gridPosY;
                        num9 = constraints1.cellSpanX;
                        num10 = constraints1.cellSpanY;
                        if ((num7 < 0) && (num8 < 0)) {
                            if (num11 >= 0) {
                                num8 = num11;
                            } else if (num12 >= 0) {
                                num7 = num12;
                            } else {
                                num8 = 0;
                            }
                        }
                        if (num7 < 0) {
                            if (num10 <= 0) {
                                num10 += (info1.rows - num8);
                                if (num10 < 1) {
                                    num10 = 1;
                                }
                            }
                            num3 = 0;
                            for (num1 = num8; num1 < (num8 + num10); num1++) {
                                num3 = Math.Max(num3, numArray1[num1]);
                            }
                            num7 = (num3 - num7) - 1;
                            if (num7 < 0) {
                                num7 = 0;
                            }
                        } else if (num8 < 0) {
                            if (num9 <= 0) {
                                num9 += (info1.columns - num7);
                                if (num9 < 1) {
                                    num9 = 1;
                                }
                            }
                            num4 = 0;
                            for (num1 = num7; num1 < (num7 + num9); num1++) {
                                num4 = Math.Max(num4, numArray2[num1]);
                            }
                            num8 = (num4 - num8) - 1;
                            if (num8 < 0) {
                                num8 = 0;
                            }
                        }
                        if (num9 <= 0) {
                            num9 += (info1.columns - num7);
                            if (num9 < 1) {
                                num9 = 1;
                            }
                        }
                        if (num10 <= 0) {
                            num10 += (info1.rows - num8);
                            if (num10 < 1) {
                                num10 = 1;
                            }
                        }
                        num3 = num7 + num9;
                        num4 = num8 + num10;
                        num1 = num7;
                        while (num1 < (num7 + num9)) {
                            numArray2[num1] = num4;
                            num1++;
                        }
                        for (num1 = num8; num1 < (num8 + num10); num1++) {
                            numArray1[num1] = num3;
                        }
                        if ((constraints1.cellSpanY == 0) && (constraints1.cellSpanX == 0)) {
                            num11 = num12 = -1;
                        }
                        if ((constraints1.cellSpanY == 0) && (num11 < 0)) {
                            num12 = num7 + num9;
                        } else if ((constraints1.cellSpanX == 0) && (num12 < 0)) {
                            num11 = num8 + num10;
                        }
                        constraints1.tempCurPosX = num7;
                        constraints1.tempCurPosY = num8;
                        constraints1.tempCellSpanX = num9;
                        constraints1.tempCellSpanY = num10;
                    }
                }
                num15++;
            }
            if (this.columnWidths != null) {
                Array.Copy(this.columnWidths, info1.minWidth, this.columnWidths.Length);
            }
            if (this.rowHeights != null) {
                Array.Copy(this.rowHeights, info1.minHeight, this.rowHeights.Length);
            }
            if (this.columnWeights != null) {
                Array.Copy(this.columnWeights, info1.weightX, this.columnWeights.Length);
            }
            if (this.rowWeights != null) {
                Array.Copy(this.rowWeights, info1.weightY, this.rowWeights.Length);
            }
            int num6 = 0x7fffffff;
            num1 = 1;
            while (num1 != 0x7fffffff) {
                for (num15 = 0; num15 < list1.Count; num15++) {
                    control1 = list1[num15] as Control;
                    if (base.IsVisible(control1)) {
                        constraints1 = this.GetConstraintsRef(control1);
                        if (!constraints1.IsEmpty) {
                            int num2;
                            int num5;
                            double num13;
                            double num14;
                            double[] numArray3;
                            IntPtr ptr1;
                            int[] numArray4;
                            if (constraints1.tempCellSpanX == num1) {
                                num3 = constraints1.tempCurPosX + constraints1.tempCellSpanX;
                                num13 = constraints1.weightX;
                                num2 = constraints1.tempCurPosX;
                                while (num2 < num3) {
                                    num13 -= info1.weightX[num2];
                                    num2++;
                                }
                                if (num13 > 0) {
                                    num14 = 0;
                                    num2 = constraints1.tempCurPosX;
                                    while (num2 < num3) {
                                        num14 += info1.weightX[num2];
                                        num2++;
                                    }
                                    for (num2 = constraints1.tempCurPosX; (num14 > 0) && (num2 < num3); num2++) {
                                        double num16 = info1.weightX[num2];
                                        double num17 = (num16*num13)/num14;
                                        (numArray3 = info1.weightX)[(int) (ptr1 = (IntPtr) num2)] =
                                            numArray3[(int) ptr1] + num17;
                                        num13 -= num17;
                                        num14 -= num16;
                                    }
                                    (numArray3 = info1.weightX)[(int) (ptr1 = (IntPtr) (num3 - 1))] =
                                        numArray3[(int) ptr1] + num13;
                                }
                                num5 = ((constraints1.minWidth + constraints1.ipadX) + constraints1.Insets.Left) +
                                       constraints1.Insets.Right;
                                num2 = constraints1.tempCurPosX;
                                while (num2 < num3) {
                                    num5 -= info1.minWidth[num2];
                                    num2++;
                                }
                                if (num5 > 0) {
                                    num14 = 0;
                                    num2 = constraints1.tempCurPosX;
                                    while (num2 < num3) {
                                        num14 += info1.weightX[num2];
                                        num2++;
                                    }
                                    for (num2 = constraints1.tempCurPosX; (num14 > 0) && (num2 < num3); num2++) {
                                        double num18 = info1.weightX[num2];
                                        int num19 = (int) ((num18*num5)/num14);
                                        (numArray4 = info1.minWidth)[(int) (ptr1 = (IntPtr) num2)] =
                                            numArray4[(int) ptr1] + num19;
                                        num5 -= num19;
                                        num14 -= num18;
                                    }
                                    (numArray4 = info1.minWidth)[(int) (ptr1 = (IntPtr) (num3 - 1))] =
                                        numArray4[(int) ptr1] + num5;
                                }
                            } else if ((constraints1.tempCellSpanX > num1) && (constraints1.tempCellSpanX < num6)) {
                                num6 = constraints1.tempCellSpanX;
                            }
                            if (constraints1.tempCellSpanY == num1) {
                                num4 = constraints1.tempCurPosY + constraints1.tempCellSpanY;
                                num13 = constraints1.weightY;
                                num2 = constraints1.tempCurPosY;
                                while (num2 < num4) {
                                    num13 -= info1.weightY[num2];
                                    num2++;
                                }
                                if (num13 > 0) {
                                    num14 = 0;
                                    num2 = constraints1.tempCurPosY;
                                    while (num2 < num4) {
                                        num14 += info1.weightY[num2];
                                        num2++;
                                    }
                                    for (num2 = constraints1.tempCurPosY; (num14 > 0) && (num2 < num4); num2++) {
                                        double num20 = info1.weightY[num2];
                                        double num21 = (num20*num13)/num14;
                                        (numArray3 = info1.weightY)[(int) (ptr1 = (IntPtr) num2)] =
                                            numArray3[(int) ptr1] + num21;
                                        num13 -= num21;
                                        num14 -= num20;
                                    }
                                    (numArray3 = info1.weightY)[(int) (ptr1 = (IntPtr) (num4 - 1))] =
                                        numArray3[(int) ptr1] + num13;
                                }
                                num5 = ((constraints1.minHeight + constraints1.ipadY) + constraints1.Insets.Top) +
                                       constraints1.Insets.Bottom;
                                num2 = constraints1.tempCurPosY;
                                while (num2 < num4) {
                                    num5 -= info1.minHeight[num2];
                                    num2++;
                                }
                                if (num5 > 0) {
                                    num14 = 0;
                                    num2 = constraints1.tempCurPosY;
                                    while (num2 < num4) {
                                        num14 += info1.weightY[num2];
                                        num2++;
                                    }
                                    for (num2 = constraints1.tempCurPosY; (num14 > 0) && (num2 < num4); num2++) {
                                        double num22 = info1.weightY[num2];
                                        int num23 = (int) ((num22*num5)/num14);
                                        (numArray4 = info1.minHeight)[(int) (ptr1 = (IntPtr) num2)] =
                                            numArray4[(int) ptr1] + num23;
                                        num5 -= num23;
                                        num14 -= num22;
                                    }
                                    (numArray4 = info1.minHeight)[(int) (ptr1 = (IntPtr) (num4 - 1))] =
                                        numArray4[(int) ptr1] + num5;
                                }
                            } else if ((constraints1.tempCellSpanY > num1) && (constraints1.tempCellSpanY < num6)) {
                                num6 = constraints1.tempCellSpanY;
                            }
                        }
                    }
                }
                num1 = num6;
                num6 = 0x7fffffff;
            }
            Monitor.Exit(this);
            return info1;
        }

        public Point GetLayoutOrigin() {
            Point point1 = new Point(0, 0);
            if (this.layoutInfo != null) {
                point1.X = this.layoutInfo.startX;
                point1.Y = this.layoutInfo.startY;
            }
            return point1;
        }

        public double[][] GetLayoutWeights() {
            if (this.layoutInfo == null) {
                return new double[2][];
            }
            double[][] numArrayArray1 = new double[2][]
                                        {new double[this.layoutInfo.columns], new double[this.layoutInfo.rows]};
            Array.Copy(this.layoutInfo.weightX, numArrayArray1[0], this.layoutInfo.columns);
            Array.Copy(this.layoutInfo.weightY, numArrayArray1[1], this.layoutInfo.rows);
            return numArrayArray1;
        }

        public Point GetLocation(int x, int y) {
            Point point1 = new Point(0, 0);
            if (this.layoutInfo != null) {
                int num2 = this.layoutInfo.startX;
                int num1 = 0;
                while (num1 < this.layoutInfo.columns) {
                    num2 += this.layoutInfo.minWidth[num1];
                    if (num2 > x) {
                        break;
                    }
                    num1++;
                }
                point1.X = num1;
                num2 = this.layoutInfo.startY;
                num1 = 0;
                while (num1 < this.layoutInfo.rows) {
                    num2 += this.layoutInfo.minHeight[num1];
                    if (num2 > y) {
                        break;
                    }
                    num1++;
                }
                point1.Y = num1;
            }
            return point1;
        }

        protected Size GetMinSize(GridBagLayoutInfo info) {
            Size size1 = new Size();
            int num2 = 0;
            int num1 = 0;
            while (num1 < info.columns) {
                num2 += info.minWidth[num1];
                num1++;
            }
            size1.Width = num2;
            num2 = 0;
            for (num1 = 0; num1 < info.rows; num1++) {
                num2 += info.minHeight[num1];
            }
            size1.Height = num2;
            return size1;
        }

        protected override Size GetStaticMinimumSize(Control control) {
            if (this.minimumSizes[control] != null) {
                return (Size) this.minimumSizes[control];
            }
            if (this.noFillSizes[control] != null) {
                return (Size) this.noFillSizes[control];
            }
            Size size1 = control.Size;
            GridBagConstraints constraints1 = this.GetConstraintsRef(control);
            if (constraints1.IpadX > 0) {
                size1.Width -= constraints1.IpadX;
            }
            if (constraints1.IpadY > 0) {
                size1.Height -= constraints1.IpadY;
            }
            return size1;
        }

        protected override Size GetStaticPreferredSize(Control control) {
            if (this.preferredSizes[control] != null) {
                return (Size) this.preferredSizes[control];
            }
            if (this.noFillSizes[control] != null) {
                return (Size) this.noFillSizes[control];
            }
            Size size1 = control.Size;
            GridBagConstraints constraints1 = this.GetConstraintsRef(control);
            if (constraints1.IpadX > 0) {
                size1.Width -= constraints1.IpadX;
            }
            if (constraints1.IpadY > 0) {
                size1.Height -= constraints1.IpadY;
            }
            return size1;
        }

        public override void LayoutContainer() {
            if (this.IsInit()) {
                base.ContainerControl.SuspendLayout();
                this.LayoutGridBag();
                base.ContainerControl.ResumeLayout(false);
            }
        }

        protected void LayoutGridBag() {
            if (this.IsInit()) {
                Rectangle rectangle1 = new Rectangle();
                IList list1 = this.GetControls();
                if (((list1.Count != 0) || ((this.columnWidths != null) && (this.columnWidths.Length != 0))) ||
                    ((this.rowHeights != null) && (this.rowHeights.Length != 0))) {
                    double num1;
                    int num2;
                    int[] numArray1;
                    IntPtr ptr1;
                    Monitor.Enter(this);
                    Rectangle rectangle2 = this.GetBounds();
                    GridBagLayoutInfo info1 = this.GetLayoutInfo(PreferredSize);
                    Size size1 = this.GetMinSize(info1);
                    if ((rectangle2.Width < size1.Width) || (rectangle2.Height < size1.Height)) {
                        info1 = this.GetLayoutInfo(1);
                        size1 = this.GetMinSize(info1);
                    }
                    this.layoutInfo = info1;
                    rectangle1.Width = size1.Width;
                    rectangle1.Height = size1.Height;
                    int num3 = rectangle2.Width - rectangle1.Width;
                    if (num3 != 0) {
                        num1 = 0;
                        num2 = 0;
                        while (num2 < info1.columns) {
                            num1 += info1.weightX[num2];
                            num2++;
                        }
                        if (num1 > 0) {
                            for (num2 = 0; num2 < info1.columns; num2++) {
                                int num4 = (int) ((num3*info1.weightX[num2])/num1);
                                (numArray1 = info1.minWidth)[(int) (ptr1 = (IntPtr) num2)] = numArray1[(int) ptr1] +
                                                                                             num4;
                                rectangle1.Width += num4;
                                if (info1.minWidth[num2] < 0) {
                                    rectangle1.Width -= info1.minWidth[num2];
                                    info1.minWidth[num2] = 0;
                                }
                            }
                        }
                        num3 = rectangle2.Width - rectangle1.Width;
                    } else {
                        num3 = 0;
                    }
                    int num5 = rectangle2.Height - rectangle1.Height;
                    if (num5 != 0) {
                        num1 = 0;
                        num2 = 0;
                        while (num2 < info1.rows) {
                            num1 += info1.weightY[num2];
                            num2++;
                        }
                        if (num1 > 0) {
                            for (num2 = 0; num2 < info1.rows; num2++) {
                                int num6 = (int) ((num5*info1.weightY[num2])/num1);
                                (numArray1 = info1.minHeight)[(int) (ptr1 = (IntPtr) num2)] = numArray1[(int) ptr1] +
                                                                                              num6;
                                rectangle1.Height += num6;
                                if (info1.minHeight[num2] < 0) {
                                    rectangle1.Height -= info1.minHeight[num2];
                                    info1.minHeight[num2] = 0;
                                }
                            }
                        }
                        num5 = rectangle2.Height - rectangle1.Height;
                    } else {
                        num5 = 0;
                    }
                    info1.startX = num3/2;
                    info1.startY = num5/2;
                    for (int num7 = 0; num7 < list1.Count; num7++) {
                        Control control1 = list1[num7] as Control;
                        if (base.IsVisible(control1)) {
                            GridBagConstraints constraints1 = this.GetConstraintsRef(control1);
                            if (!constraints1.IsEmpty) {
                                rectangle1.X = info1.startX;
                                num2 = 0;
                                while (num2 < constraints1.tempCurPosX) {
                                    rectangle1.X += info1.minWidth[num2];
                                    num2++;
                                }
                                rectangle1.Y = info1.startY;
                                num2 = 0;
                                while (num2 < constraints1.tempCurPosY) {
                                    rectangle1.Y += info1.minHeight[num2];
                                    num2++;
                                }
                                rectangle1.Width = 0;
                                num2 = constraints1.tempCurPosX;
                                while (num2 < (constraints1.tempCurPosX + constraints1.tempCellSpanX)) {
                                    rectangle1.Width += info1.minWidth[num2];
                                    num2++;
                                }
                                rectangle1.Height = 0;
                                for (num2 = constraints1.tempCurPosY;
                                     num2 < (constraints1.tempCurPosY + constraints1.tempCellSpanY);
                                     num2++) {
                                    rectangle1.Height += info1.minHeight[num2];
                                }
                                this.AdjustForGravity(constraints1, ref rectangle1);
                                if ((rectangle1.Width <= 0) || (rectangle1.Height <= 0)) {
                                    control1.Bounds = new Rectangle(0, 0, 0, 0);
                                } else {
                                    rectangle1 = new Rectangle(rectangle2.Left + rectangle1.X,
                                                               rectangle2.Top + rectangle1.Y, rectangle1.Width,
                                                               rectangle1.Height);
                                    ControlBounds bounds1 = base.GetChildControlBounds(control1);
                                    if (((bounds1.Location.X != rectangle1.X) || (bounds1.Location.Y != rectangle1.Y)) ||
                                        ((bounds1.Width != rectangle1.Width) || (bounds1.Height != rectangle1.Height))) {
                                        bounds1.Bounds = new Rectangle(rectangle1.X, rectangle1.Y, rectangle1.Width,
                                                                       rectangle1.Height);
                                    }
                                }
                            }
                        }
                    }
                    Monitor.Exit(this);
                }
            }
        }

        public override Size MinimumLayoutSize() {
            GridBagLayoutInfo info1 = this.GetLayoutInfo(1);
            return this.GetMinSize(info1);
        }

        protected override void OnControlAdded(object sender, ControlEventArgs e) {
            Control control1 = e.Control;
            if (!this.controlsMap.Contains(control1)) {
                this.SetConstraints(control1, GridBagConstraints.Default());
            }
            base.OnControlAdded(sender, e);
        }

        public override Size PreferredLayoutSize() {
            GridBagLayoutInfo info1 = this.GetLayoutInfo(PreferredSize);
            return this.GetMinSize(info1);
        }

        public override void RemoveLayoutComponent(Control control) {
            this.SetConstraints(control, null);
        }

        private void ResetConstraints(Control control) {
            this.SetConstraints(control, GridBagConstraints.Default());
        }

        protected override void ResetLayoutInfo() {
            base.ResetLayoutInfo();
            this.noFillSizes.Clear();
        }

        public override void ResetMinimumSize(Control control) {
            if (this.noFillSizes[control] != null) {
                MessageBox.Show(
                    "Cannot Reset minimum size when the control has a FillType other than FillMode.None set.");
            } else {
                this.minimumSizes[control] = null;
            }
        }

        public override void ResetPreferredSize(Control control) {
            if (this.noFillSizes[control] != null) {
                MessageBox.Show(
                    "Cannot Reset preferred size when the control has a FillType other than FilleMode.None set.");
            } else {
                this.preferredSizes[control] = null;
            }
        }

        public void SetConstraints(Control control, GridBagConstraints value) {
            if (value == null) {
                this.controlsMap.Remove(control);
                base.RemoveLayoutComponent(control);
            } else {
                this.UpdateNoFillSizes(control, value);
                this.UpdatePreferredSizeForPadding(control, value);
                this.controlsMap[control] = value.Clone();
                base.AddLayoutComponent(control, value);
                if (base.ContainerControl != null) {
                    base.ContainerControl.PerformLayout();
                }
            }
        }

        public override void SetPreferredSize(Control control, Size value) {
            base.SetPreferredSize(control, value);
            if (base.DesignMode) {
                GridBagConstraints constraints1 = this.GetConstraintsRef(control);
                if ((constraints1 != null) && (constraints1.Fill != FillType.None)) {
                    this.noFillSizes[control] = value;
                }
            }
        }

        private bool ShouldSerializeConstraints(Control control) {
            if (this.GetConstraintsRef(control) == GridBagConstraints.Default()) {
                return false;
            }
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool ShouldSerializeMinimumSize(Control control) {
            if (!base.ShouldSerializeMinimumSize(control)) {
                return (this.noFillSizes[control] != null);
            }
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool ShouldSerializePreferredSize(Control control) {
            if (!base.ShouldSerializePreferredSize(control)) {
                return (this.noFillSizes[control] != null);
            }
            return true;
        }

        private void UpdateNoFillSizes(Control control, GridBagConstraints newConstraints) {
            if (base.DesignMode) {
                GridBagConstraints constraints1 = (GridBagConstraints) this.controlsMap[control];
                if (((newConstraints != null) && (newConstraints.Fill != FillType.None)) &&
                    ((constraints1 == null) || (constraints1.Fill == FillType.None))) {
                    this.noFillSizes[control] = control.Size;
                } else if (((newConstraints == null) || (newConstraints.Fill == FillType.None)) &&
                           (((constraints1 != null) && (constraints1.Fill != FillType.None)) &&
                            (this.noFillSizes[control] != null))) {
                    control.SuspendLayout();
                    base.ContainerControl.SuspendLayout();
                    if (this.preferredSizes[control] == this.noFillSizes[control]) {
                        this.preferredSizes[control] = null;
                    }
                    if (this.minimumSizes[control] == this.noFillSizes[control]) {
                        this.minimumSizes[control] = null;
                    }
                    control.Size = (Size) this.noFillSizes[control];
                    base.ContainerControl.ResumeLayout(false);
                    control.ResumeLayout(false);
                    this.noFillSizes[control] = null;
                }
            }
        }

        private void UpdatePreferredSizeForPadding(Control control, GridBagConstraints newConstraints) {
            if (base.DesignMode && (this.noFillSizes[control] != null)) {
                Size size1 = (Size) this.noFillSizes[control];
                Size size2 = size1;
                GridBagConstraints constraints1 = (GridBagConstraints) this.controlsMap[control];
                if (constraints1 == null) {
                    constraints1 = GridBagConstraints.Default();
                }
                if (constraints1.IpadX != newConstraints.IpadX) {
                    size2.Width -= (newConstraints.IpadX - constraints1.IpadX);
                }
                if (constraints1.IpadY != newConstraints.IpadY) {
                    size2.Height -= (newConstraints.IpadY - constraints1.IpadY);
                }
                if (size2 != size1) {
                    this.noFillSizes[control] = size2;
                }
            }
        }
    }
}