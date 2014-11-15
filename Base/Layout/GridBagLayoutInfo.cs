#region

using System;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for GridBagLayoutInfo.
    /// </summary>
    /// 
    [Serializable]
    public class GridBagLayoutInfo {
        // Fields
        public int columns;
        public int[] minHeight;
        public int[] minWidth;
        public int rows;
        public int startX;
        public int startY;
        public double[] weightX;
        public double[] weightY;

        public GridBagLayoutInfo() {
            this.minWidth = new int[0x200];
            this.minHeight = new int[0x200];
            this.weightX = new double[0x200];
            this.weightY = new double[0x200];
        }
    }
}