#region

using System;
using System.ComponentModel;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for GridBagConstraints.
    /// </summary>
    /// 
    [Serializable, TypeConverter(typeof (GridBagConstraintsConverter))]
    public class GridBagConstraints : ICloneable {
        // Fields
        internal AnchorTypes anchor;
        internal int cellSpanX;
        internal int cellSpanY;
        public static readonly GridBagConstraints Empty;
        internal FillType fill;
        internal int gridPosX;
        internal int gridPosY;
        internal Insets insets;
        internal int ipadX;
        internal int ipadY;
        internal bool isEmpty;
        [NonSerialized] internal int minHeight;
        [NonSerialized] internal int minWidth;
        public const int Relative = -1;
        public const int Remainder = 0;
        [NonSerialized] internal int tempCellSpanX;
        [NonSerialized] internal int tempCellSpanY;
        [NonSerialized] internal int tempCurPosX;
        [NonSerialized] internal int tempCurPosY;
        internal double weightX;
        internal double weightY;

        static GridBagConstraints() {
            Empty = Default();
            Empty.IsEmpty = true;
        }

        public GridBagConstraints()
            : this(-1, -1, 1, 1, 0, 0, AnchorTypes.Center, FillType.None, new Insets(0, 0, 0, 0), 0, 0, false) {
        }

        public GridBagConstraints(int gridPosX, int gridPosY, int cellSpanX, int cellSpanY, double weightX,
                                  double weightY, AnchorTypes anchor, FillType fill, Insets insets, int ipadX, int ipadY,
                                  bool isEmpty) {
            this.gridPosX = gridPosX;
            this.gridPosY = gridPosY;
            this.cellSpanX = cellSpanX;
            this.cellSpanY = cellSpanY;
            this.weightX = weightX;
            this.weightY = weightY;
            this.anchor = anchor;
            this.fill = fill;
            this.insets = insets;
            this.ipadX = ipadX;
            this.ipadY = ipadY;
            this.isEmpty = isEmpty;
        }

        public object Clone() {
            return (GridBagConstraints) base.MemberwiseClone();
        }

        public static GridBagConstraints Default() {
            return new GridBagConstraints();
        }

        public override bool Equals(object o) {
            bool flag1 = false;
            if ((object) this != o) {
                if (!(o is GridBagConstraints)) {
                    return flag1;
                }
                GridBagConstraints constraints1 = (GridBagConstraints) o;
                if (this.Anchor != constraints1.Anchor) {
                    return false;
                }
                if (this.CellSpanX != constraints1.CellSpanX) {
                    return false;
                }
                if (this.CellSpanY != constraints1.CellSpanY) {
                    return false;
                }
                if (this.Fill != constraints1.Fill) {
                    return false;
                }
                if (this.GridPosX != constraints1.GridPosX) {
                    return false;
                }
                if (this.GridPosY != constraints1.GridPosY) {
                    return false;
                }
                if (this.Insets != constraints1.Insets) {
                    return false;
                }
                if (this.IpadX != constraints1.IpadX) {
                    return false;
                }
                if (this.IpadY != constraints1.IpadY) {
                    return false;
                }
                if (this.WeightX != constraints1.WeightX) {
                    return false;
                }
                if (this.WeightY != constraints1.WeightY) {
                    return false;
                }
                if (this.IsEmpty != constraints1.IsEmpty) {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(GridBagConstraints lhs, GridBagConstraints rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return true;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return lhs.Equals(rhs);
            }
            return false;
        }

        public static bool operator !=(GridBagConstraints lhs, GridBagConstraints rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return false;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return !lhs.Equals(rhs);
            }
            return true;
        }

        [Description(
            "Specifies the justification of a component within its available layout bounds (a cell in the virtual grid)."
            ), DefaultValue(AnchorTypes.Center)]
        public AnchorTypes Anchor {
            get { return this.anchor; }
            set { this.anchor = value; }
        }

        [DefaultValue(1), Description("Specifies the number of columns this component should span in the virtual grid.")
        ]
        public int CellSpanX {
            get { return this.cellSpanX; }
            set { this.cellSpanX = value; }
        }

        [DefaultValue(1), Description("Specifies the number of rows this component should span in the virtual grid.")]
        public int CellSpanY {
            get { return this.cellSpanY; }
            set { this.cellSpanY = value; }
        }

        [DefaultValue(FillType.None),
         Description(
             "Specifies whether (and how) to resize a component when the component's layout bounds are larger than its preferred size."
             )]
        public FillType Fill {
            get { return this.fill; }
            set { this.fill = value; }
        }

        [DefaultValue(-1),
         Description("Specifies the column in the virtual grid where the component's layout bounds begin.")]
        public int GridPosX {
            get { return this.gridPosX; }
            set { this.gridPosX = value; }
        }

        [DefaultValue(-1),
         Description("Specifies the row in the virtual grid where the component's layout bounds begin.")]
        public int GridPosY {
            get { return this.gridPosY; }
            set { this.gridPosY = value; }
        }

        [Description(
            "Specifies the extra space that the manager adds around a component's preferred bounds before laying out the component."
            )]
        public Insets Insets {
            get { return this.insets; }
            set { this.insets = value; }
        }

        [DefaultValue(0),
         Description(
             "Specifies the amount in pixels to add to the size of the component when determining its overall width.")]
        public int IpadX {
            get { return this.ipadX; }
            set { this.ipadX = (value < 0) ? 0 : value; }
        }

        [DefaultValue(0),
         Description(
             "Specifies the amount in pixels to add to the size of the component when determining its overall height.")]
        public int IpadY {
            get { return this.ipadY; }
            set { this.ipadY = (value < 0) ? 0 : value; }
        }

        [Description("Represents the GridBagConstraints structure with its properties left uninitialized."),
         DefaultValue(false)]
        public bool IsEmpty {
            get { return this.isEmpty; }
            set { this.isEmpty = value; }
        }

        [DefaultValue((double) 0),
         Description("Specifies the weight of this component in obtaining the extra horizontal space.")]
        public double WeightX {
            get { return this.weightX; }
            set { this.weightX = value; }
        }

        [Description("Specifies the weight of this component in obtaining the extra vertical space."),
         DefaultValue((double) 0)]
        public double WeightY {
            get { return this.weightY; }
            set { this.weightY = value; }
        }
    }
}