#region

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for Insets.
    /// </summary>
    /// 
    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof (InsetsConverter))]
    public class Insets {
        private int left;
        private int top;
        private int right;
        private int bottom;

        public Insets(int left, int top, int right, int bottom) {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public override bool Equals(object o) {
            bool flag1 = false;
            if ((object) this != o) {
                if (!(o is Insets)) {
                    return flag1;
                }
                Insets insets1 = (Insets) o;
                if (this.Bottom != insets1.Bottom) {
                    return false;
                }
                if (this.Left != insets1.Left) {
                    return false;
                }
                if (this.Right != insets1.Right) {
                    return false;
                }
                if (this.Top != insets1.Top) {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Insets lhs, Insets rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return true;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return lhs.Equals(rhs);
            }
            return false;
        }

        public static bool operator !=(Insets lhs, Insets rhs) {
            if (((object) lhs == null) && ((object) rhs == null)) {
                return false;
            }
            if (((object) lhs != null) && ((object) rhs != null)) {
                return !lhs.Equals(rhs);
            }
            return true;
        }

        public override string ToString() {
            object[] objArray1 = new object[8]
                                 {"T ", this.top, ", L ", this.left, ", B ", this.bottom, ", R ", this.right};
            return string.Concat(objArray1);
        }

        [Description("Specifies the insets to the bottom of the component.")]
        public int Bottom {
            get { return this.bottom; }
            set { this.bottom = value; }
        }

        [Description("Specifies the insets to the left of the component.")]
        public int Left {
            get { return this.left; }
            set { this.left = value; }
        }

        [Description("Specifies the insets to the right of the component.")]
        public int Right {
            get { return this.right; }
            set { this.right = value; }
        }

        [Description("Specifies the insets to the top of the component.")]
        public int Top {
            get { return this.top; }
            set { this.top = value; }
        }
    }
}