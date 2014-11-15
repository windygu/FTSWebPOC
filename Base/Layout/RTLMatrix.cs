#region

using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for RTLMatrix.
    /// </summary>
    public class RTLMatrix {
        // Fields
        private int leftMargin;
        private Matrix mirrorMatrix;
        private int rightMargin;

        public RTLMatrix(int leftMargin, int rightMargin, int containerWidth) {
            this.leftMargin = leftMargin;
            this.rightMargin = rightMargin;
            this.mirrorMatrix = new Matrix(-1f, 0f, 0f, 1f, (float) containerWidth, 0f);
        }

        public Point TransformPoint(Point pt) {
            pt.X -= this.leftMargin;
            Point[] pointArray2 = new Point[1] {pt};
            Point[] pointArray1 = pointArray2;
            this.mirrorMatrix.TransformPoints(pointArray1);
            pointArray1[0].X = pointArray1[0].X + this.rightMargin;
            return pointArray1[0];
        }
    }
}