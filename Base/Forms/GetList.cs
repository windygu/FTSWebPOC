// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:46
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         GetList.cs
// Project Item Filename:     GetList.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Forms;

#endregion

namespace FTS.BaseBusiness.Classes {
    public class GetItems {
        public GetItems() {
        }

        public static void GetList(FTSMain ftsmain, string tablename, TextEdit t) {
            (new FrmGetList(ftsmain, tablename, t)).ShowDialog();
        }

        public static void GetList(FTSMain ftsmain, string tablename, TextEdit t, string dk) {
            (new FrmGetList(ftsmain, tablename, t, dk)).ShowDialog();
        }
    }
}