// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/29/2006
// Time:                      15:50
// Project Name:              POSUI
// Project Filename:          POSUI.csproj
// Project Item Name:         GetTypeDic.cs
// Project Item Filename:     GetTypeDic.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region
using System;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Business;
using FTS.ShareUI.Acc;
#endregion

namespace FTS.ShareUI.Common
{
    public class GetTypeDic
    {
        public static Type GetTypeList(string tablename)
        {
            switch (tablename.ToLower())
            {
                
                case "sys_report":
                    return typeof(FrmSys_Report_List);
                case "dm_organization":
                    return typeof(FrmDm_Organization_List);
                case "dm_unit":
                    return typeof(FrmDm_Unit_List);
                case "dm_pr_detail":
                    return typeof(FrmDm_Pr_Detail_List);
                case "dm_item":
                    return typeof(FrmDm_Item_List);
                default:
                    throw new FTSException("MSG_GETTYPELIST_ERROR");
            }
        }

        public static Type GetTypeEditList(string tablename)
        {
            switch (tablename.ToLower())
            {
                
                case "dm_organization":
                    return typeof(FrmDm_Organization_EditList);
                
                case "dm_unit":
                    return typeof(FrmDm_Unit_EditList);
                
                case "dm_pr_detail":
                    return typeof(FrmDm_Pr_Detail_EditList);
                
                case "dm_item":
                    return typeof(FrmDm_Item_EditList);
                
                default:
                    throw new FTSException("MSG_GETTYPELIST_ERROR");
            }
        }

        public static Type GetTypeEditDetail(string tablename)
        {
            switch (tablename.ToLower())
            {
               
                case "dm_organization":
                    return typeof(FrmDm_Organization_EditDetail);
               
                case "dm_unit":
                    return typeof(FrmDm_Unit_EditDetail);
                
                case "dm_pr_detail":
                    return typeof(FrmDm_Pr_Detail_EditDetail);
                
                case "dm_item":
                    return typeof(FrmDm_Item_EditDetail);
                
                default:
                    throw new FTSException("MSG_GETTYPELIST_ERROR");
            }
        }
    }
}