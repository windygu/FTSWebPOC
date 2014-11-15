// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:54
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         TranOutputField.cs
// Project Item Filename:     TranOutputField.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace FTS.BaseBusiness.Systems {
    public class TranOutputField : IComparable {
        public string Section = "ReportHeader";
        public string Name = "DON_VI";
        public string Text = "Hello World";
        public string Para = "Hello World";
        public int top = -1;
        public int left = 0;
        public int width = 200;
        public int box = 0;
        public string font_name;
        public int font_size;
        public string font_style;
        public string font_color;
        public string textalignment = "LEFT";
        public string beforeafter = "AFTER";
        public int DecimalDigit = 0;

        public TranOutputField() {
        }

        public int CompareTo(object obj) {
            if (obj is TranOutputField) {
                TranOutputField temp = (TranOutputField) obj;
                return this.left.CompareTo(temp.left);
            }
            throw new ArgumentException("object is not a TranOutputField");
        }
    }
}