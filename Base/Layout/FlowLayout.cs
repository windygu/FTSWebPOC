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
    /// Summary description for FlowLayout.
    /// </summary>
    /// 
    [ToolboxBitmap(typeof (FlowLayout), "FlowLayout.bmp"), ProvideProperty("Constraints", typeof (Control)),
     ToolboxItemFilter("System.Windows.Forms")]
    public class FlowLayout : LayoutManager {
        // Fields
        private FlowAlignment alignment;
        private bool autoHeight;
        private Hashtable controlsMap;
        private const int DefaultGap = 5;
        private int hGap;
        private Size lastKnownPreferredSize;
        private bool layoutForDeterminingPreferredSize;
        private FlowLayoutMode layoutMode;
        protected Hashtable noFillSizes;
        private int recurseCount;
        private bool reverseRows;
        private int vGap;

        public FlowLayout() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.reverseRows = false;
            this.autoHeight = false;
            this.layoutForDeterminingPreferredSize = false;
            this.lastKnownPreferredSize = Size.Empty;
            this.recurseCount = 0;
            this.layoutMode = FlowLayoutMode.Horizontal;
            this.alignment = FlowAlignment.Center;
            this.hGap = 5;
            this.vGap = 5;
            this.controlsMap = new Hashtable();
            this.noFillSizes = new Hashtable();
        }

        public FlowLayout(IContainer container) : this() {
            if (container != null) {
                container.Add(this);
            }
        }

        public FlowLayout(Control container) : this() {
            base.ContainerControl = container;
        }

        public FlowLayout(Control container, FlowLayoutMode layoutMode, FlowAlignment align) : this(container) {
            this.layoutMode = layoutMode;
            this.alignment = align;
        }

        public FlowLayout(Control container, FlowLayoutMode layoutMode, FlowAlignment align, int hGap, int vGap)
            : this(container, layoutMode, align) {
            this.hGap = hGap;
            this.vGap = vGap;
        }

        private void AlignComponentsHorizontal(Rectangle containerBounds, ref int x, int y, int deltaWidth, int height,
                                               ArrayList list, ArrayList justifiedControlsList,
                                               int justifiedControlsCount, Hashtable prefSizes, Hashtable deltaWidths) {
            int num1 = 0;
            if (deltaWidth < 0) {
                foreach (Control control1 in list) {
                    if (justifiedControlsList.Contains(control1)) {
                        num1 += ((int) deltaWidths[control1]);
                    }
                }
            }
            foreach (Control control2 in list) {
                FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control2);
                bool flag1 = constraints1.HAlign == HorzFlowAlign.Justify;
                Size size1 = (Size) prefSizes[control2];
                ControlBounds bounds1 = base.GetChildControlBounds(control2, size1);
                AutoLabel label1 = base.GetAutoLabel(control2);
                AutoLabelAndControl control3 = null;
                if (label1 != null) {
                    control3 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size), label1.Position,
                                                       label1.DX, label1.DY, bounds1);
                } else {
                    control3 = new AutoLabelAndControl(bounds1);
                }
                int num2 = containerBounds.Top + y;
                if (height > control3.Height) {
                    switch (constraints1.VAlign) {
                        case VertFlowAlign.Bottom: {
                            goto Label_0133;
                        }
                        case VertFlowAlign.Center: {
                            num2 += ((height - control3.Height)/2);
                            goto Label_0142;
                        }
                    }
                }
                goto Label_0142;
                Label_0133:
                num2 = (num2 + height) - control3.Height;
                Label_0142:
                control3.BeginUpdate();
                control3.Location = new Point(containerBounds.Left + x, num2);
                if ((this.alignment == FlowAlignment.ChildConstraints) && flag1) {
                    if (deltaWidth >= 0) {
                        control3.Width += (deltaWidth/justifiedControlsCount);
                    } else if (((int) deltaWidths[control2]) != 0) {
                        control3.Width += ((deltaWidth*((int) deltaWidths[control2]))/num1);
                    }
                }
                if (constraints1.VAlign == VertFlowAlign.Justify) {
                    control3.Height = height;
                }
                control3.EndUpdate();
                x += (this.hGap + control3.Width);
            }
        }

        private void AlignComponentsVertical(Rectangle containerBounds, int x, ref int y, int deltaHeight, int width,
                                             ArrayList list, ArrayList justifiedControlsList, int justifiedControlsCount,
                                             Hashtable prefSizes, Hashtable deltaHeights) {
            int num1 = 0;
            if (deltaHeight < 0) {
                foreach (Control control1 in list) {
                    if (justifiedControlsList.Contains(control1)) {
                        num1 += ((int) deltaHeights[control1]);
                    }
                }
            }
            foreach (Control control2 in list) {
                FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control2);
                bool flag1 = constraints1.VAlign == VertFlowAlign.Justify;
                Size size1 = (Size) prefSizes[control2];
                ControlBounds bounds1 = base.GetChildControlBounds(control2, size1);
                AutoLabel label1 = base.GetAutoLabel(control2);
                AutoLabelAndControl control3 = null;
                if (label1 != null) {
                    control3 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size), label1.Position,
                                                       label1.DX, label1.DY, bounds1);
                } else {
                    control3 = new AutoLabelAndControl(bounds1);
                }
                int num2 = containerBounds.Left + x;
                if (width > control3.Width) {
                    switch (constraints1.HAlign) {
                        case HorzFlowAlign.Right: {
                            goto Label_0133;
                        }
                        case HorzFlowAlign.Center: {
                            num2 += ((width - control3.Width)/2);
                            goto Label_0142;
                        }
                    }
                }
                goto Label_0142;
                Label_0133:
                num2 = (num2 + width) - control3.Width;
                Label_0142:
                control3.BeginUpdate();
                control3.Location = new Point(num2, containerBounds.Top + y);
                if ((this.alignment == FlowAlignment.ChildConstraints) && flag1) {
                    if (deltaHeight >= 0) {
                        control3.Height += (deltaHeight/justifiedControlsCount);
                    } else if (((int) deltaHeights[control2]) != 0) {
                        control3.Height += ((deltaHeight*((int) deltaHeights[control2]))/num1);
                    }
                }
                if (constraints1.HAlign == HorzFlowAlign.Justify) {
                    control3.Width = width;
                }
                control3.EndUpdate();
                y += (this.vGap + control3.Height);
            }
        }

        [Localizable(true), Category("Layout Manager")]
        public FlowLayoutConstraints GetConstraints(Control control) {
            return (FlowLayoutConstraints) this.GetConstraintsRef(control).Clone();
        }

        public FlowLayoutConstraints GetConstraintsRef(Control control) {
            FlowLayoutConstraints constraints1 = (FlowLayoutConstraints) this.controlsMap[control];
            if (constraints1 == null) {
                this.SetConstraints(control, FlowLayoutConstraints.Default());
                constraints1 = (FlowLayoutConstraints) this.controlsMap[control];
            }
            return constraints1;
        }

        [Localizable(true),
         Obsolete(
             "This method will be removed in a future version. Use the GetConstraintsRef method instead. Please check the class reference for more information."
             ), Category("Appearance")]
        public bool GetParticipateInLayout(Control control) {
            FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control);
            return constraints1.Active;
        }

        protected override Size GetStaticMinimumSize(Control control) {
            Size size1 = Size.Empty;
            bool flag1 = this.minimumSizes.Contains(control);
            if (!flag1 && AutoLabel.AutoLabelMap.Contains(control)) {
                Size size2 = base.GetStaticMinimumSize(control);
                AutoLabel label1 = AutoLabel.AutoLabelMap[control] as AutoLabel;
                if (label1.Position == AutoLabelPosition.Top) {
                    size2.Height += label1.Height;
                } else {
                    size2.Width += label1.Width;
                }
                this.SetMinimumSize(control, size2);
                flag1 = true;
            }
            if (!flag1) {
                if (this.noFillSizes[control] != null) {
                    size1 = (Size) this.noFillSizes[control];
                } else {
                    size1 = control.Size;
                }
            } else {
                size1 = (Size) this.minimumSizes[control];
            }
            if (this.Alignment == FlowAlignment.ChildConstraints) {
                if (this.LayoutMode == FlowLayoutMode.Vertical) {
                    FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control);
                    if (constraints1.VAlign != VertFlowAlign.Justify) {
                        size1.Height = control.Size.Height;
                    }
                    return size1;
                }
                if (this.LayoutMode == FlowLayoutMode.Horizontal) {
                    FlowLayoutConstraints constraints2 = this.GetConstraintsRef(control);
                    if (constraints2.HAlign != HorzFlowAlign.Justify) {
                        size1.Width = control.Size.Width;
                    }
                }
            }
            return size1;
        }

        protected override Size GetStaticPreferredSize(Control control) {
            Size size1 = Size.Empty;
            bool flag1 = this.preferredSizes.Contains(control);
            if (!flag1 && AutoLabel.AutoLabelMap.Contains(control)) {
                Size size2 = base.GetStaticPreferredSize(control);
                AutoLabel label1 = AutoLabel.AutoLabelMap[control] as AutoLabel;
                if (label1.Position == AutoLabelPosition.Top) {
                    size2.Height += label1.Height;
                } else {
                    size2.Width += label1.Width;
                }
                this.SetPreferredSize(control, size2);
                flag1 = true;
            }
            if (!flag1) {
                if (this.noFillSizes[control] != null) {
                    size1 = (Size) this.noFillSizes[control];
                } else {
                    size1 = control.Size;
                }
            } else {
                size1 = (Size) this.preferredSizes[control];
            }
            if (this.Alignment == FlowAlignment.ChildConstraints) {
                FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control);
                if (constraints1.VAlign != VertFlowAlign.Justify) {
                    size1.Height = control.Size.Height;
                }
                if (constraints1.HAlign != HorzFlowAlign.Justify) {
                    size1.Width = control.Size.Width;
                }
            }
            return size1;
        }

        private int GetUsedHeight(ArrayList rowHeights) {
            int num1 = 0;
            foreach (int num2 in rowHeights) {
                num1 += num2;
            }
            return (num1 + (this.vGap*(rowHeights.Count - 1)));
        }

        private int GetUsedWidth(ArrayList rowWidths) {
            int num1 = 0;
            foreach (int num2 in rowWidths) {
                num1 += num2;
            }
            return (num1 + (this.hGap*(rowWidths.Count - 1)));
        }

        public override void LayoutContainer() {
            if (this.IsInit()) {
                base.ContainerControl.SuspendLayout();
                if (this.layoutMode == FlowLayoutMode.Vertical) {
                    this.LayoutContainerVertical();
                } else {
                    this.LayoutContainerHorizontal();
                }
                base.ContainerControl.ResumeLayout(false);
            }
        }

        public virtual void LayoutContainerHorizontal() {
            Monitor.Enter(this);
            this.recurseCount++;
            if (this.recurseCount > 2) {
                this.recurseCount--;
            } else {
                Rectangle rectangle1 = this.GetBounds();
                IList list1 = this.GetControls();
                int num1 = rectangle1.Width;
                int num2 = list1.Count;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                ArrayList list2 = new ArrayList();
                ArrayList list3 = new ArrayList();
                ArrayList list4 = new ArrayList();
                ArrayList list5 = new ArrayList();
                bool flag1 = false;
                bool flag2 = false;
                Hashtable hashtable1 = new Hashtable();
                Hashtable hashtable2 = new Hashtable();
                for (int num8 = 0; num8 < num2; num8++) {
                    Control control1 = list1[num8] as Control;
                    if (!(control1 is AutoLabel) || this.ShouldLayoutAutoLabel(control1 as AutoLabel)) {
                        FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control1);
                        if (base.IsVisible(control1) && constraints1.Active) {
                            Size size1 = this.GetPreferredSize(control1);
                            Size size2 = this.GetMinimumSize(control1);
                            hashtable1[control1] = size1;
                            hashtable2[control1] = size1.Width - size2.Width;
                            ControlBounds bounds1 = base.GetChildControlBounds(control1, size1);
                            ControlBounds bounds2 = base.GetChildControlBounds(control1, size2);
                            AutoLabel label1 = base.GetAutoLabel(control1);
                            AutoLabelAndControl control2 = null;
                            AutoLabelAndControl control3 = null;
                            if (label1 != null) {
                                control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds1);
                            } else {
                                control2 = new AutoLabelAndControl(bounds1);
                            }
                            if (label1 != null) {
                                control3 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds2);
                            } else {
                                control3 = new AutoLabelAndControl(bounds2);
                            }
                            size1 = new Size(control2.Width, control2.Height);
                            size2 = new Size(control3.Width, control3.Height);
                            if ((this.alignment == FlowAlignment.ChildConstraints) &&
                                (constraints1.HAlign == HorzFlowAlign.Justify)) {
                                num5 += (size1.Width - size2.Width);
                            }
                            if ((num3 == 0) ||
                                ((((num3 + size1.Width) - num5) <= (num1 - this.hGap)) && !constraints1.NewLine)) {
                                if (num3 > 0) {
                                    num3 += this.hGap;
                                }
                                num3 += size1.Width;
                                num6 = Math.Max(num6, size1.Height);
                                if (constraints1.ProportionalRowHeight) {
                                    flag1 = true;
                                }
                            } else {
                                list2.Add(num6);
                                list3.Add(num3);
                                list4.Add(num7);
                                list5.Add(flag1);
                                flag2 |= flag1;
                                flag1 = false;
                                num3 = size1.Width;
                                num5 = 0;
                                num4 += (this.vGap + num6);
                                num6 = size1.Height;
                                num7 = num8;
                                if (constraints1.ProportionalRowHeight) {
                                    flag1 = true;
                                }
                            }
                        }
                    }
                }
                list2.Add(num6);
                list3.Add(num3);
                list4.Add(num7);
                list5.Add(flag1);
                flag2 |= flag1;
                if (!this.layoutForDeterminingPreferredSize) {
                    if (flag2) {
                        int num9 = this.GetUsedHeight(list2);
                        int num10 = rectangle1.Height - num9;
                        int num11 = 0;
                        for (int num12 = 0; num12 < list5.Count; num12++) {
                            if ((bool) list5[num12]) {
                                num11 += ((int) list2[num12]);
                            }
                        }
                        for (int num13 = 0; num13 < list5.Count; num13++) {
                            if ((bool) list5[num13]) {
                                int num14 = (int) list2[num13];
                                list2[num13] = num14 + ((num14*num10)/num11);
                            }
                        }
                    }
                    num4 = 0;
                    if (this.ReverseRows) {
                        num4 = rectangle1.Height;
                    }
                    for (int num15 = 0; num15 < list2.Count; num15++) {
                        int num16 = (int) list2[num15];
                        int num17 = (int) list3[num15];
                        int num18 = -1;
                        if ((num15 + 1) == list2.Count) {
                            num18 = num2;
                        } else {
                            num18 = (int) list4[num15 + 1];
                        }
                        int num19 = 0;
                        if (this.ReverseRows) {
                            num19 = num4 - num16;
                        } else {
                            num19 = num4;
                        }
                        this.MoveComponentsHorizontal(0, num19, num1, num1 - num17, num16, (int) list4[num15], num18,
                                                      hashtable1, hashtable2);
                        if (this.ReverseRows) {
                            num4 -= (this.vGap + num16);
                        } else {
                            num4 += (this.vGap + num16);
                        }
                    }
                    if (this.autoHeight && (base.CustomLayoutBounds == Rectangle.Empty)) {
                        int num20 = this.GetUsedHeight(list2);
                        if (rectangle1.Height != num20) {
                            int num21 = base.AdjustHeightForMargins(num20);
                            base.ContainerControl.SuspendLayout();
                            base.ContainerControl.Height = num21;
                            base.ContainerControl.ResumeLayout(false);
                            this.LayoutContainerHorizontal();
                        }
                    }
                } else {
                    int num22 = this.GetUsedHeight(list2);
                    this.lastKnownPreferredSize = new Size(base.AdjustWidthForMargins(rectangle1.Width),
                                                           base.AdjustHeightForMargins(num22));
                }
                this.recurseCount--;
                Monitor.Exit(this);
            }
        }

        public virtual void LayoutContainerVertical() {
            Monitor.Enter(this);
            this.recurseCount++;
            if (this.recurseCount > 2) {
                this.recurseCount--;
            } else {
                Rectangle rectangle1 = this.GetBounds();
                IList list1 = this.GetControls();
                int num1 = rectangle1.Height;
                int num2 = list1.Count;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                ArrayList list2 = new ArrayList();
                ArrayList list3 = new ArrayList();
                ArrayList list4 = new ArrayList();
                ArrayList list5 = new ArrayList();
                bool flag1 = false;
                bool flag2 = false;
                Hashtable hashtable1 = new Hashtable();
                Hashtable hashtable2 = new Hashtable();
                for (int num8 = 0; num8 < num2; num8++) {
                    Control control1 = list1[num8] as Control;
                    if (!(control1 is AutoLabel) || this.ShouldLayoutAutoLabel(control1 as AutoLabel)) {
                        FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control1);
                        if (base.IsVisible(control1) && constraints1.Active) {
                            Size size1 = this.GetPreferredSize(control1);
                            Size size2 = this.GetMinimumSize(control1);
                            hashtable1[control1] = size1;
                            hashtable2[control1] = size1.Height - size2.Height;
                            ControlBounds bounds1 = base.GetChildControlBounds(control1, size1);
                            ControlBounds bounds2 = base.GetChildControlBounds(control1, size2);
                            AutoLabel label1 = base.GetAutoLabel(control1);
                            AutoLabelAndControl control2 = null;
                            AutoLabelAndControl control3 = null;
                            if (label1 != null) {
                                control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds1);
                            } else {
                                control2 = new AutoLabelAndControl(bounds1);
                            }
                            if (label1 != null) {
                                control3 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds2);
                            } else {
                                control3 = new AutoLabelAndControl(bounds2);
                            }
                            size1 = new Size(control2.Width, control2.Height);
                            size2 = new Size(control3.Width, control3.Height);
                            if ((this.alignment == FlowAlignment.ChildConstraints) &&
                                (constraints1.VAlign == VertFlowAlign.Justify)) {
                                num5 += (size1.Height - size2.Height);
                            }
                            if ((num4 == 0) ||
                                ((((num4 + size1.Height) - num5) <= (num1 - this.vGap)) && !constraints1.NewLine)) {
                                if (num4 > 0) {
                                    num4 += this.vGap;
                                }
                                num4 += size1.Height;
                                num6 = Math.Max(num6, size1.Width);
                                if (constraints1.ProportionalColWidth) {
                                    flag1 = true;
                                }
                            } else {
                                list2.Add(num6);
                                list3.Add(num4);
                                list4.Add(num7);
                                list5.Add(flag1);
                                flag2 |= flag1;
                                flag1 = false;
                                num4 = size1.Height;
                                num5 = 0;
                                num3 += (this.hGap + num6);
                                num6 = size1.Width;
                                num7 = num8;
                                if (constraints1.ProportionalColWidth) {
                                    flag1 = true;
                                }
                            }
                        }
                    }
                }
                list2.Add(num6);
                list3.Add(num4);
                list4.Add(num7);
                list5.Add(flag1);
                flag2 |= flag1;
                if (!this.layoutForDeterminingPreferredSize) {
                    if (flag2) {
                        int num9 = this.GetUsedWidth(list2);
                        int num10 = rectangle1.Width - num9;
                        int num11 = 0;
                        for (int num12 = 0; num12 < list5.Count; num12++) {
                            if ((bool) list5[num12]) {
                                num11 += ((int) list2[num12]);
                            }
                        }
                        for (int num13 = 0; num13 < list5.Count; num13++) {
                            if ((bool) list5[num13]) {
                                int num14 = (int) list2[num13];
                                list2[num13] = num14 + ((num14*num10)/num11);
                            }
                        }
                    }
                    num3 = 0;
                    if (this.ReverseRows) {
                        num3 = rectangle1.Width;
                    }
                    for (int num15 = 0; num15 < list2.Count; num15++) {
                        int num16 = (int) list2[num15];
                        int num17 = (int) list3[num15];
                        int num18 = -1;
                        if ((num15 + 1) == list2.Count) {
                            num18 = num2;
                        } else {
                            num18 = (int) list4[num15 + 1];
                        }
                        int num19 = 0;
                        if (this.ReverseRows) {
                            num19 = num3 - num16;
                        } else {
                            num19 = num3;
                        }
                        this.MoveComponentsVertical(num19, 0, num16, num1 - num17, num1, (int) list4[num15], num18,
                                                    hashtable1, hashtable2);
                        if (this.ReverseRows) {
                            num3 -= (this.hGap + num16);
                        } else {
                            num3 += (this.hGap + num16);
                        }
                    }
                } else {
                    int num20 = this.GetUsedWidth(list2);
                    this.lastKnownPreferredSize = new Size(base.AdjustWidthForMargins(num20),
                                                           base.AdjustHeightForMargins(rectangle1.Height));
                }
                this.recurseCount--;
                Monitor.Exit(this);
            }
        }

        public override Size MinimumLayoutSize() {
            Size size1 = new Size(0, 0);
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            for (int num2 = 0; num2 < num1; num2++) {
                Control control1 = list1[num2] as Control;
                if (base.IsVisible(control1)) {
                    Size size2 = this.GetMinimumSize(control1);
                    if (this.LayoutMode == FlowLayoutMode.Horizontal) {
                        size1.Height = Math.Max(size1.Height, size2.Height);
                        if (num2 > 0) {
                            size1.Width += this.hGap;
                        }
                        size1.Width += size2.Width;
                    } else {
                        size1.Width = Math.Max(size1.Width, size2.Width);
                        if (num2 > 0) {
                            size1.Height += this.vGap;
                        }
                        size1.Height += size2.Height;
                    }
                }
            }
            size1.Width += (base.HorzNearMargin + base.HorzFarMargin);
            size1.Height += (base.TopMargin + base.BottomMargin);
            return size1;
        }

        protected virtual void MoveComponentsHorizontal(int x, int y, int maxWidth, int deltaWidth, int height,
                                                        int rowStart, int rowEnd, Hashtable prefSizes,
                                                        Hashtable deltaWidths) {
            Monitor.Enter(this);
            int num1 = x;
            Rectangle rectangle1 = this.GetBounds();
            IList list1 = this.GetControls();
            switch (this.alignment) {
                case FlowAlignment.Center: {
                    x += (deltaWidth/2);
                    break;
                }
                case FlowAlignment.Far: {
                    x += deltaWidth;
                    break;
                }
            }
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();
            ArrayList list5 = new ArrayList();
            bool flag1 = false;
            bool flag2 = false;
            int num2 = 0;
            int num3 = 0;
            HorzFlowAlign align1 = HorzFlowAlign.Left;
            for (int num4 = rowStart; num4 < rowEnd; num4++) {
                ControlBounds bounds1;
                AutoLabelAndControl control2;
                Control control1 = list1[num4] as Control;
                if (!(control1 is AutoLabel) || this.ShouldLayoutAutoLabel(control1 as AutoLabel)) {
                    FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control1);
                    if (base.IsVisible(control1) && constraints1.Active) {
                        Size size1 = (Size) prefSizes[control1];
                        bounds1 = base.GetChildControlBounds(control1, size1);
                        AutoLabel label1 = null;
                        control2 = null;
                        if (this.alignment != FlowAlignment.ChildConstraints) {
                            label1 = base.GetAutoLabel(control1);
                            if (label1 != null) {
                                control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds1);
                            } else {
                                control2 = new AutoLabelAndControl(bounds1);
                            }
                            control2.BeginUpdate();
                            control2.Location = new Point(rectangle1.Left + x,
                                                          (rectangle1.Top + y) + ((height - control2.Height)/2));
                            control2.Width = size1.Width;
                            control2.Height = size1.Height;
                            control2.EndUpdate();
                            x += (this.hGap + control2.Width);
                        } else {
                            HorzFlowAlign align2 = constraints1.HAlign;
                            if (align2 == HorzFlowAlign.Justify) {
                                list5.Add(control1);
                                align2 = align1;
                                if (align1 == HorzFlowAlign.Center) {
                                    flag1 = true;
                                } else if (align1 == HorzFlowAlign.Right) {
                                    flag2 = true;
                                }
                            }
                            switch (align2) {
                                case HorzFlowAlign.Left: {
                                    list2.Add(control1);
                                    align1 = HorzFlowAlign.Left;
                                    goto Label_02C4;
                                }
                                case HorzFlowAlign.Right: {
                                    list4.Add(control1);
                                    label1 = base.GetAutoLabel(control1);
                                    if (label1 == null) {
                                        goto Label_02AC;
                                    }
                                    control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                       label1.Position, label1.DX, label1.DY, bounds1);
                                    goto Label_02B5;
                                }
                                case HorzFlowAlign.Center: {
                                    list3.Add(control1);
                                    label1 = base.GetAutoLabel(control1);
                                    if (label1 == null) {
                                        goto Label_023D;
                                    }
                                    control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                       label1.Position, label1.DX, label1.DY, bounds1);
                                    goto Label_0246;
                                }
                            }
                        }
                    }
                }
                goto Label_02C4;
                Label_023D:
                control2 = new AutoLabelAndControl(bounds1);
                Label_0246:
                num2 += control2.Width;
                align1 = HorzFlowAlign.Center;
                goto Label_02C4;
                Label_02AC:
                control2 = new AutoLabelAndControl(bounds1);
                Label_02B5:
                num3 += control2.Width;
                align1 = HorzFlowAlign.Right;
                Label_02C4:
                ;
            }
            num2 += (list3.Count*this.hGap);
            num3 += (list4.Count*this.hGap);
            if (this.alignment == FlowAlignment.ChildConstraints) {
                int num5 = list5.Count;
                this.AlignComponentsHorizontal(rectangle1, ref x, y, deltaWidth, height, list2, list5, num5, prefSizes,
                                               deltaWidths);
                if (list3.Count > 0) {
                    if (!flag1) {
                        int num6 = num1 + ((rectangle1.Width - num2)/2);
                        if (num6 > x) {
                            deltaWidth -= (num6 - x);
                            x = num6;
                        }
                    }
                    this.AlignComponentsHorizontal(rectangle1, ref x, y, deltaWidth, height, list3, list5, num5,
                                                   prefSizes, deltaWidths);
                }
                if (!flag2) {
                    x = ((num1 + maxWidth) - num3) + this.hGap;
                }
                this.AlignComponentsHorizontal(rectangle1, ref x, y, deltaWidth, height, list4, list5, num5, prefSizes,
                                               deltaWidths);
            }
            Monitor.Exit(this);
        }

        protected virtual void MoveComponentsVertical(int x, int y, int width, int deltaHeight, int maxHeight,
                                                      int rowStart, int rowEnd, Hashtable prefSizes,
                                                      Hashtable deltaHeights) {
            Monitor.Enter(this);
            int num1 = y;
            Rectangle rectangle1 = this.GetBounds();
            IList list1 = this.GetControls();
            switch (this.alignment) {
                case FlowAlignment.Center: {
                    y += (deltaHeight/2);
                    break;
                }
                case FlowAlignment.Far: {
                    y += deltaHeight;
                    break;
                }
            }
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();
            ArrayList list5 = new ArrayList();
            bool flag1 = false;
            bool flag2 = false;
            int num2 = 0;
            int num3 = 0;
            VertFlowAlign align1 = VertFlowAlign.Top;
            for (int num4 = rowStart; num4 < rowEnd; num4++) {
                ControlBounds bounds1;
                AutoLabelAndControl control2;
                Control control1 = list1[num4] as Control;
                if (!(control1 is AutoLabel) || this.ShouldLayoutAutoLabel(control1 as AutoLabel)) {
                    FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control1);
                    if (base.IsVisible(control1) && constraints1.Active) {
                        Size size1 = (Size) prefSizes[control1];
                        bounds1 = base.GetChildControlBounds(control1, size1);
                        AutoLabel label1 = null;
                        control2 = null;
                        if (this.alignment != FlowAlignment.ChildConstraints) {
                            label1 = base.GetAutoLabel(control1);
                            if (label1 != null) {
                                control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                   label1.Position, label1.DX, label1.DY, bounds1);
                            } else {
                                control2 = new AutoLabelAndControl(bounds1);
                            }
                            control2.BeginUpdate();
                            control2.Location = new Point((rectangle1.Left + x) + ((width - control2.Width)/2),
                                                          rectangle1.Top + y);
                            control2.Width = size1.Width;
                            control2.Height = size1.Height;
                            control2.EndUpdate();
                            y += (this.vGap + control2.Height);
                        } else {
                            VertFlowAlign align2 = constraints1.VAlign;
                            if (align2 == VertFlowAlign.Justify) {
                                list5.Add(control1);
                                align2 = align1;
                                if (align1 == VertFlowAlign.Center) {
                                    flag1 = true;
                                } else if (align1 == VertFlowAlign.Bottom) {
                                    flag2 = true;
                                }
                            }
                            switch (align2) {
                                case VertFlowAlign.Top: {
                                    list2.Add(control1);
                                    align1 = VertFlowAlign.Top;
                                    goto Label_02C3;
                                }
                                case VertFlowAlign.Bottom: {
                                    list4.Add(control1);
                                    label1 = base.GetAutoLabel(control1);
                                    if (label1 == null) {
                                        goto Label_02AB;
                                    }
                                    control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                       label1.Position, label1.DX, label1.DY, bounds1);
                                    goto Label_02B4;
                                }
                                case VertFlowAlign.Center: {
                                    list3.Add(control1);
                                    label1 = base.GetAutoLabel(control1);
                                    if (label1 == null) {
                                        goto Label_023C;
                                    }
                                    control2 = new AutoLabelAndControl(base.GetChildControlBounds(label1, label1.Size),
                                                                       label1.Position, label1.DX, label1.DY, bounds1);
                                    goto Label_0245;
                                }
                            }
                        }
                    }
                }
                goto Label_02C3;
                Label_023C:
                control2 = new AutoLabelAndControl(bounds1);
                Label_0245:
                num2 += control2.Height;
                align1 = VertFlowAlign.Center;
                goto Label_02C3;
                Label_02AB:
                control2 = new AutoLabelAndControl(bounds1);
                Label_02B4:
                num3 += control2.Height;
                align1 = VertFlowAlign.Bottom;
                Label_02C3:
                ;
            }
            num2 += (list3.Count*this.vGap);
            num3 += (list4.Count*this.vGap);
            if (this.alignment == FlowAlignment.ChildConstraints) {
                int num5 = list5.Count;
                this.AlignComponentsVertical(rectangle1, x, ref y, deltaHeight, width, list2, list5, num5, prefSizes,
                                             deltaHeights);
                if (list3.Count > 0) {
                    if (!flag1) {
                        int num6 = num1 + ((rectangle1.Height - num2)/2);
                        if (num6 > y) {
                            deltaHeight -= (num6 - y);
                            y = num6;
                        }
                    }
                    this.AlignComponentsVertical(rectangle1, x, ref y, deltaHeight, width, list3, list5, num5, prefSizes,
                                                 deltaHeights);
                }
                if (!flag2) {
                    y = ((num1 + maxHeight) - num3) + this.vGap;
                }
                this.AlignComponentsVertical(rectangle1, x, ref y, deltaHeight, width, list4, list5, num5, prefSizes,
                                             deltaHeights);
            }
            Monitor.Exit(this);
        }

        protected override void OnContainerControlChanged(EventArgs e) {
            base.OnContainerControlChanged(e);
            if (base.ContainerControl != null) {
                foreach (Control control1 in base.ContainerControl.Controls) {
                    if (!this.controlsMap.Contains(control1)) {
                        this.SetConstraints(control1, FlowLayoutConstraints.Default());
                    }
                }
            }
        }

        protected override void OnControlAdded(object sender, ControlEventArgs e) {
            Control control1 = e.Control;
            if (!this.controlsMap.Contains(control1)) {
                this.SetConstraints(control1, FlowLayoutConstraints.Default());
            }
            base.OnControlAdded(sender, e);
        }

        public override Size PreferredLayoutSize() {
            this.layoutForDeterminingPreferredSize = true;
            this.LayoutContainer();
            this.layoutForDeterminingPreferredSize = false;
            return this.lastKnownPreferredSize;
        }

        public override void RemoveLayoutComponent(Control control) {
            this.SetConstraints(control, null);
        }

        private void ResetConstraints(Control control) {
            this.SetConstraints(control, FlowLayoutConstraints.Default());
        }

        protected override void ResetLayoutInfo() {
            base.ResetLayoutInfo();
            this.noFillSizes.Clear();
        }

        public override void ResetMinimumSize(Control control) {
            if (this.noFillSizes[control] != null) {
                MessageBox.Show(
                    "Cannot reset minimum size when the control has a FillType other than FilleMode.None set.");
            } else {
                this.minimumSizes.Remove(control);
            }
        }

        public override void ResetPreferredSize(Control control) {
            if (this.noFillSizes[control] != null) {
                MessageBox.Show("Cannot reset preferred size when the control's HAlign or VAlign is set to Justify.");
            } else {
                this.preferredSizes.Remove(control);
            }
        }

        private void ReverseList(ref ArrayList list) {
            ArrayList list1 = new ArrayList(list);
            for (int num1 = 0; num1 < list1.Count; num1++) {
                list[(list.Count - 1) - num1] = list1[num1];
            }
        }

        public void SetConstraints(Control control, FlowLayoutConstraints value) {
            if (value == null) {
                this.controlsMap.Remove(control);
                base.RemoveLayoutComponent(control);
            } else {
                this.UpdateNoFillSizes(control, value);
                this.controlsMap[control] = value.Clone();
                base.AddLayoutComponent(control, value);
                if (base.ContainerControl != null) {
                    base.ContainerControl.PerformLayout();
                }
            }
        }

        [Obsolete(
            "This method will be removed in a future version. Use the SetConstraints method instead. Please check the class reference for more information."
            )]
        public void SetParticipateInLayout(Control control, bool value) {
            FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control);
            constraints1.Active = value;
        }

        public override void SetPreferredSize(Control control, Size value) {
            base.SetPreferredSize(control, value);
            if (base.DesignMode) {
                FlowLayoutConstraints constraints1 = this.GetConstraintsRef(control);
                if ((constraints1 != null) && (constraints1.HAlign == HorzFlowAlign.Justify)) {
                    this.noFillSizes[control] = value;
                }
            }
        }

        private bool ShouldSerializeConstraints(Control control) {
            if (this.GetConstraintsRef(control) == FlowLayoutConstraints.Default()) {
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

        private void UpdateNoFillSizes(Control control, FlowLayoutConstraints newConstraints) {
            if (base.DesignMode) {
                FlowLayoutConstraints constraints1 = (FlowLayoutConstraints) this.controlsMap[control];
                bool flag1 = false;
                bool flag2 = false;
                if (((newConstraints != null) &&
                     ((newConstraints.HAlign == HorzFlowAlign.Justify) || newConstraints.ProportionalColWidth)) &&
                    ((constraints1 == null) ||
                     ((constraints1.HAlign != HorzFlowAlign.Justify) && !constraints1.ProportionalColWidth))) {
                    flag1 = true;
                }
                if (((!flag1 && (newConstraints != null)) &&
                     ((newConstraints.VAlign == VertFlowAlign.Justify) || newConstraints.ProportionalRowHeight)) &&
                    ((constraints1 == null) ||
                     ((constraints1.VAlign != VertFlowAlign.Justify) && !constraints1.ProportionalRowHeight))) {
                    flag1 = true;
                }
                if ((((newConstraints == null) ||
                      ((newConstraints.HAlign != HorzFlowAlign.Justify) && !newConstraints.ProportionalColWidth)) &&
                     ((constraints1 != null) &&
                      ((constraints1.HAlign == HorzFlowAlign.Justify) || constraints1.ProportionalColWidth))) &&
                    (this.noFillSizes[control] != null)) {
                    flag2 = true;
                }
                if (((!flag2 &&
                      ((newConstraints == null) ||
                       ((newConstraints.VAlign != VertFlowAlign.Justify) && !newConstraints.ProportionalRowHeight))) &&
                     ((constraints1 != null) &&
                      ((constraints1.VAlign == VertFlowAlign.Justify) || constraints1.ProportionalRowHeight))) &&
                    (this.noFillSizes[control] != null)) {
                    flag2 = true;
                }
                if (flag1) {
                    this.noFillSizes[control] = control.Size;
                } else if (flag2) {
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

        [Category("Behavior"), Localizable(true), DefaultValue(FlowAlignment.Center),
         Description("Specifies the alignment of layout components in the direction of flow.")]
        public FlowAlignment Alignment {
            get { return this.alignment; }
            set {
                if (this.alignment != value) {
                    this.alignment = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [Category("Behavior"),
         Description(
             "Specifies if the container's height should be enforced to the minimum when in horizontal alignment mode.")
        , DefaultValue(false)]
        public bool AutoHeight {
            get { return this.autoHeight; }
            set {
                if (this.autoHeight != value) {
                    this.autoHeight = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [DefaultValue(5), Description("Specifies the horizontal spacing between the layout border and the components."),
         Category("Appearance"), Localizable(true)]
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

        [Category("Behavior"), DefaultValue(FlowLayoutMode.Horizontal), Localizable(true),
         Description("Specifies the layout mode.")]
        public FlowLayoutMode LayoutMode {
            get { return this.layoutMode; }
            set {
                if (this.layoutMode != value) {
                    this.layoutMode = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                }
            }
        }

        [Localizable(true), Category("Behavior"), DefaultValue(false),
         Description("Lays out rows in opposite direction (right to left or bottom to top).")]
        public bool ReverseRows {
            get { return this.reverseRows; }
            set {
                if (this.reverseRows != value) {
                    this.reverseRows = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        [Category("Appearance"),
         Description("Specifies the vertical spacing between the layout border and the components."), DefaultValue(5),
         Localizable(true)]
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