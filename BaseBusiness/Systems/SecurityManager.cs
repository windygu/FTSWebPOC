// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:54
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         SecurityManager.cs
// Project Item Filename:     SecurityManager.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseBusiness.Systems
{
    public class SecurityManager
    {
        private FTSMain mFTSMain;
        private Hashtable mHs;

        public SecurityManager(FTSMain ftsmain, bool isdataload)
        {
            this.mFTSMain = ftsmain;
            if (isdataload) {
                this.LoadData();
            }else {
                this.LoadEmptyData();
            }
        }

        public void CheckSecurity(FTSFunction ftsfunction, string actionid, string organizationid)
        {
            string key = null;
            object[] foundRow = null;
            bool rs = true;
            if (ftsfunction == null)
            {
                return;
            }
            else
            {
                key = ftsfunction.Name;
                foundRow = (object[])this.mHs[key];
            }
            if (this.mFTSMain.UserInfo.UserID == FTSConstant.DevUser)
            {
                return;
            }
            if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN")
            {
                if (foundRow == null)
                {
                    if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                    {
                        try
                        {
                            InsertSecurity(ftsfunction);
                        }
                        catch (Exception) { }
                        return;
                    }
                }
                return;
            }

            if (foundRow != null)
            {
                if (actionid == DataAction.ViewAction && ftsfunction.IsView)
                {
                    rs = (bool)foundRow[0];
                }
                if (actionid == DataAction.AddAction && ftsfunction.IsAddNew)
                {
                    rs = (bool)foundRow[1];
                }
                if (actionid == DataAction.EditAction && ftsfunction.IsEdit)
                {
                    rs = (bool)foundRow[2];
                }
                if (actionid == DataAction.DeleteAction && ftsfunction.IsDelete)
                {
                    rs = (bool)foundRow[3];
                }
                if (actionid == DataAction.ExecuteAction && ftsfunction.IsExecutte)
                {
                    rs = (bool)foundRow[4];
                }
            }
            else
            {
                if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                {
                    try
                    {
                        InsertSecurity(ftsfunction);
                    }
                    catch (Exception) { }
                    return;
                }
            }
            if (!rs)
            {
                throw (new FTSException("MSG_NO_PERMISSION {0} {1}",new object[]{ftsfunction.Name,actionid}));
            }
        }
        public bool CheckSecurityInvisible(FTSFunction ftsfunction, string actionid, string organizationid) {
            string key = null;
            object[] foundRow = null;
            if (ftsfunction == null)
            {
                return true;
            }
            else
            {
                key = ftsfunction.Name;
                foundRow = (object[])this.mHs[key];
            }
            if (this.mFTSMain.UserInfo.UserID == FTSConstant.DevUser) {
                return true;
            }
            if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN") {
                return true;
            }
            bool rs = true;
            if (foundRow != null) {
                if (actionid == DataAction.ViewAction && ftsfunction.IsView) {
                    rs = (bool)foundRow[0];
                }
                if (actionid == DataAction.AddAction && ftsfunction.IsAddNew) {
                    rs = (bool)foundRow[1];
                }
                if (actionid == DataAction.EditAction && ftsfunction.IsEdit) {
                    rs = (bool)foundRow[2];
                }
                if (actionid == DataAction.DeleteAction && ftsfunction.IsDelete) {
                    rs = (bool)foundRow[3];
                }
                if (actionid == DataAction.ExecuteAction && ftsfunction.IsExecutte) {
                    rs = (bool)foundRow[4];
                }
            } else {
                if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                    try
                    {
                        InsertSecurity(ftsfunction);
                    }
                    catch (Exception) { }
                    return true;
                }
            }
            if (!rs) {
                return false;
            }
            return true;
        }
        public void CheckSecurity(FTSFunction ftsfunction, string actionid)
        {
            string key = null;
            object[] foundRow = null;
            bool rs = true;
            if (ftsfunction == null)
            {
                return;
            }
            else
            {
                key = ftsfunction.Name;
                foundRow = (object[])this.mHs[key];
            }
            if (this.mFTSMain.UserInfo.UserID == FTSConstant.DevUser)
            {
                return;
            }
            if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN")
            {
                if (foundRow == null)
                {
                    if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                    {
                        try
                        {
                            InsertSecurity(ftsfunction);
                        }
                        catch (Exception) { }
                        return;
                    }
                }
                return;
            }

            if (foundRow != null)
            {
                if (actionid == DataAction.ViewAction && ftsfunction.IsView)
                {
                    rs = (bool)foundRow[0];
                }
                if (actionid == DataAction.AddAction && ftsfunction.IsAddNew)
                {
                    rs = (bool)foundRow[1];
                }
                if (actionid == DataAction.EditAction && ftsfunction.IsEdit)
                {
                    rs = (bool)foundRow[2];
                }
                if (actionid == DataAction.DeleteAction && ftsfunction.IsDelete)
                {
                    rs = (bool)foundRow[3];
                }
                if (actionid == DataAction.ExecuteAction && ftsfunction.IsExecutte)
                {
                    rs = (bool)foundRow[4];
                }
            }
            else
            {
                if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                {
                    try
                    {
                        InsertSecurity(ftsfunction);
                    }
                    catch (Exception) { }
                    return;
                }
            }
            if (!rs)
            {
                throw (new FTSException("MSG_NO_PERMISSION {0} {1}",new object[]{ftsfunction.Name,actionid}));
            }
        }

        public bool CheckSecurityInvisible(FTSFunction ftsfunction, string actionid)
        {
            string key = null;
            object[] foundRow = null;
            bool rs = true;
            if (ftsfunction == null)
            {
                return true;
            }
            else
            {
                key = ftsfunction.Name;
                foundRow = (object[])this.mHs[key];
            }
            if (this.mFTSMain.UserInfo.UserID == FTSConstant.DevUser)
            {
                return true;
            }
            if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN")
            {
                if (foundRow == null)
                {
                    if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                    {
                        try
                        {
                            InsertSecurity(ftsfunction);
                        }
                        catch (Exception) { }
                    }
                }
                return true;
            }


            if (foundRow != null)
            {
                if (actionid == DataAction.ViewAction && ftsfunction.IsView)
                {
                    rs = (bool)foundRow[0];
                }
                if (actionid == DataAction.AddAction && ftsfunction.IsAddNew)
                {
                    rs = (bool)foundRow[1];
                }
                if (actionid == DataAction.EditAction && ftsfunction.IsEdit)
                {
                    rs = (bool)foundRow[2];
                }
                if (actionid == DataAction.DeleteAction && ftsfunction.IsDelete)
                {
                    rs = (bool)foundRow[3];
                }
                if (actionid == DataAction.ExecuteAction && ftsfunction.IsExecutte)
                {
                    rs = (bool)foundRow[4];
                }
            }
            else
            {
                if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN)
                {
                    try
                    {
                        InsertSecurity(ftsfunction);
                    }
                    catch (Exception) { }
                    return true;
                }
            }
            return rs;
        }

        private void LoadData()
        {
            this.mHs = new Hashtable();
            if (this.mFTSMain.DbMain.WorkingMode != WorkingMode.WAN)
            {
                using (
                    IDataReader rs =
                        this.mFTSMain.DbMain.ExecuteReader(
                            this.mFTSMain.DbMain.GetSqlStringCommand(
                                "select * from sec_permission where user_group_id in " +
                                Functions.PopulateString(this.mFTSMain.UserInfo.UserGroupID) + "")))
                {
                    while (rs.Read())
                    {
                        string roleid = rs["FUNCTION_ID"].ToString();
                        if (this.mHs.Contains(roleid))
                        {
                            this.mHs.Remove(roleid);
                        }
                        this.mHs.Add(roleid,
                                     new object[] {
                                                      (Int16) rs["is_view"] == 1 ? true : false,
                                                      (Int16) rs["is_addnew"] == 1 ? true : false,
                                                      (Int16) rs["is_edit"] == 1 ? true : false,
                                                      (Int16) rs["is_delete"] == 1 ? true : false,
                                                      (Int16) rs["is_execute"] == 1 ? true : false
                                                  });
                    }
                }
            }
            else
            {
                DataTable dt =
                    this.mFTSMain.DbMain.LoadDataTable(
                        this.mFTSMain.DbMain.GetSqlStringCommand("select * from sec_permission where user_group_id in " +
                                Functions.PopulateString(this.mFTSMain.UserInfo.UserGroupID) + ""),
                        "sec_permission");
                foreach (DataRow row in dt.Rows)
                {
                    string roleid = row["FUNCTION_ID"].ToString();
                    if (this.mHs.Contains(roleid))
                    {
                        this.mHs.Remove(roleid);
                    }
                    this.mHs.Add(roleid,
                                 new object[] {
                                                  (Int16) row["is_view"] == 1 ? true : false,
                                                  (Int16) row["is_addnew"] == 1 ? true : false,
                                                  (Int16) row["is_edit"] == 1 ? true : false,
                                                  (Int16) row["is_delete"] == 1 ? true : false,
                                                  (Int16) row["is_execute"] == 1 ? true : false
                                              });
                }
            }
        }

        private void LoadEmptyData() {
            this.mHs = new Hashtable();
        }

        private void InsertSecurity(FTSFunction func)
        {
            iPermission sec = new iPermission(mFTSMain);
            DataRow dr = null;
            if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN")
            {
                foreach (DataRow item in sec.DataSet.Tables["SEC_USER_GROUP"].Rows)
                {
                    foreach (DataRow row in sec.DataTable.Rows)
                    {
                        if (row["FUNCTION_ID"].ToString() == func.Name)
                            if (row["USER_GROUP_ID"].ToString() == item["USER_GROUP_ID"].ToString())
                                return;
                    }
                    dr = sec.AddNew();
                    dr["FUNCTION_ID"] = func.Name;
                    dr["IS_ADDNEW"] = func.IsAddNew;
                    dr["IS_EDIT"] = func.IsEdit;
                    dr["IS_DELETE"] = func.IsDelete;
                    dr["IS_VIEW"] = func.IsView;
                    dr["IS_EXECUTE"] = func.IsExecutte;
                    dr["USER_GROUP_ID"] = item["USER_GROUP_ID"];
                    dr["PR_KEY"] = Guid.NewGuid();
                    dr.EndEdit();
                }
                sec.UpdateData();
                return;
            }
            string[] list = FunctionsBase.ParseString(this.mFTSMain.UserInfo.UserGroupID);
            for (int i = 0; i < list.Length; i++) {
                bool doit = true;
                foreach (DataRow row in sec.DataTable.Rows) {
                    if (row["FUNCTION_ID"].ToString() == func.Name) if (row["USER_GROUP_ID"].ToString() == this.mFTSMain.UserInfo.UserGroupID) doit = false;
                }
                if (doit) {
                    dr = sec.AddNew();
                    dr["FUNCTION_ID"] = func.Name;
                    dr["IS_ADDNEW"] = func.IsAddNew;
                    dr["IS_EDIT"] = func.IsEdit;
                    dr["IS_DELETE"] = func.IsDelete;
                    dr["IS_VIEW"] = func.IsView;
                    dr["IS_EXECUTE"] = func.IsExecutte;
                    dr["USER_GROUP_ID"] = this.mFTSMain.UserInfo.UserGroupID;
                    dr["PR_KEY"] = Guid.NewGuid();
                    dr.EndEdit();
                }
            }
            sec.UpdateData();
            
        }
    }
}