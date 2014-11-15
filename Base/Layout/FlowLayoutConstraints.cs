#region

using System;
using System.ComponentModel;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for FlowLayoutConstraints.
    /// </summary>
    /// 
    [Serializable, TypeConverter(typeof (FlowLayoutConstraintsConverter))]
    public class FlowLayoutConstraints : ICloneable {
        // Fields
        private bool active;
        public static readonly FlowLayoutConstraints Empty;
        private HorzFlowAlign halign;
        internal bool isEmpty;
        private bool newLine;
        private bool propColWidth;
        private bool propRowHeight;
        private VertFlowAlign valign;

        static FlowLayoutConstraints() {
            Empty = Default();
            Empty.IsEmpty = true;
        }

        public FlowLayoutConstraints() {
            this.active = true;
            this.halign = HorzFlowAlign.Left;
            this.newLine = false;
            this.valign = VertFlowAlign.Center;
            this.isEmpty = false;
            this.propRowHeight = false;
            this.propColWidth = false;
        }

        public FlowLayoutConstraints(bool active, HorzFlowAlign halign, VertFlowAlign valign, bool newline,
                                     bool proportionalColWidth, bool proportionalRowHeight) {
            this.active = true;
            this.halign = HorzFlowAlign.Left;
            this.newLine = false;
            this.valign = VertFlowAlign.Center;
            this.isEmpty = false;
            this.propRowHeight = false;
            this.propColWidth = false;
            this.active = active;
            this.halign = halign;
            this.valign = valign;
            this.newLine = newline;
            this.propColWidth = proportionalColWidth;
            this.propRowHeight = proportionalRowHeight;
        }

        public object Clone() {
            return (FlowLayoutConstraints) base.MemberwiseClone();
        }

        public static FlowLayoutConstraints Default() {
            return new FlowLayoutConstraints();
        }

        public override bool Equals(object o) {
            bool flag1 = false;
            if ((object) this != o) {
                if (!(o is FlowLayoutConstraints)) {
                    return flag1;
                }
                FlowLayoutConstraints constraints1 = (FlowLayoutConstraints) o;
                if (this.Active != constraints1.Active) {
                    return false;
                }
                if (this.HAlign != constraints1.HAlign) {
                    return false;
                }
                if (this.NewLine != constraints1.NewLine) {
                    return false;
                }
                if (this.ProportionalColWidth != constraints1.ProportionalColWidth) {
                    return false;
                }
                if (this.ProportionalRowHeight != constraints1.ProportionalRowHeight) {
                    return false;
                }
                if (this.VAlign != constraints1.VAlign) {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(FlowLayoutConstraints lhs, FlowLayoutConstraints rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return true;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return lhs.Equals(rhs);
            }
            return false;
        }

        public static bool operator !=(FlowLayoutConstraints lhs, FlowLayoutConstraints rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return false;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return !lhs.Equals(rhs);
            }
            return true;
        }

        [Description("Specifies whether the child should participate in layout."), DefaultValue(true)]
        public bool Active {
            get { return this.active; }
            set { this.active = value; }
        }

        [DefaultValue(HorzFlowAlign.Left),
         Description("Specifies the mode in which the child should be laid out within a row.")]
        public HorzFlowAlign HAlign {
            get { return this.halign; }
            set { this.halign = value; }
        }

        [Description("Specifies if there are valid values in this constraint instance."), DefaultValue(false)]
        public bool IsEmpty {
            get { return this.isEmpty; }
            set { this.isEmpty = value; }
        }

        [DefaultValue(false),
         Description("Specifies whether this child should always be moved to the beginning of a new line.")]
        public bool NewLine {
            get { return this.newLine; }
            set { this.newLine = value; }
        }

        [DefaultValue(false), Description("Specifies if proportional col widths should be used in vertical layout.")]
        public bool ProportionalColWidth {
            get { return this.propColWidth; }
            set { this.propColWidth = value; }
        }

        [DefaultValue(false), Description("Specifies if proportional row heights should be used in horizontal layout.")]
        public bool ProportionalRowHeight {
            get { return this.propRowHeight; }
            set { this.propRowHeight = value; }
        }

        [DefaultValue(VertFlowAlign.Center),
         Description("Specifies the mode in which the child should be laid out within a column.")]
        public VertFlowAlign VAlign {
            get { return this.valign; }
            set { this.valign = value; }
        }
    }
}