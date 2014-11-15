// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:48
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FTSControlPaint.cs
// Project Item Filename:     FTSControlPaint.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System.Drawing;

#endregion

namespace FTS.BaseUI.Controls {
    public class FTSControlPaint {
        public static readonly ContentAlignment anyBottom;
        public static readonly ContentAlignment anyCenter;
        public static readonly ContentAlignment anyMiddle;
        public static readonly ContentAlignment anyRight;

        static FTSControlPaint() {
            anyRight = ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;
            anyBottom = ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;
            anyCenter = ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;
            anyMiddle = ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;
        }

        public FTSControlPaint() {
        }
    }
}