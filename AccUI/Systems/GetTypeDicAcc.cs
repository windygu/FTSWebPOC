// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/29/2006
// Time:                      15:50
// Project Name:              POSUI
// Project Filename:          POSUI.csproj
// Project Item Name:         GetTypeDicAcc.cs
// Project Item Filename:     GetTypeDicAcc.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using FTS.AccUI.Sale;
using FTS.ShareUI.Common;
#endregion

namespace FTS.AccUI.Systems {
    public class GetTypeDicAcc {
        public static Type GetTypeList(string tablename) {
            switch (tablename.ToLower()) {
                default:
                    return GetTypeDic.GetTypeList(tablename);
            }
        }

        public static Type GetTypeEditList(string tablename) {
            switch (tablename.ToLower()) {
                
                default:
                    return GetTypeDic.GetTypeEditList(tablename);
            }
        }

        public static Type GetTypeEditDetail(string tablename) {
            switch (tablename.ToLower()) {
                
                default:
                    return GetTypeDic.GetTypeEditDetail(tablename);
            }
        }
    }
}