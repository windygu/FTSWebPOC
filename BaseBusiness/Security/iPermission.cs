using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.BaseBusiness.Security
{
    public class iPermission : ObjectBase
    {
        public iPermission(FTSMain ftsmain)
            : base(ftsmain, "SEC_PERMISSION")
        {
            this.LoadData();
            this.LoadFields();
        }

        public iPermission(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "SEC_PERMISSION")
        {
            if (!isempty)
            {
                this.LoadData();
            }
            this.LoadFields();
        }

        public iPermission(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "SEC_PERMISSION")
        {
            this.LoadFields();
        }

        public override void LoadFields()
        {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY",
                                                                               DbType.Guid, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FUNCTION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FUNCTION_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_GROUP_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FUNCTION_GROUP_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MODULE_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PROJECT_ID", DbType.String, false));

            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_VIEW", DbType.Boolean,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_ADDNEW",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_EDIT", DbType.Boolean,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_DELETE",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_EXECUTE",
                                                                               DbType.Boolean, false));
            this.ExcludedFieldList = "FUNCTION_NAME,FUNCTION_GROUP_ID,MODULE_ID,PROJECT_ID";
        }

        public DataRow AddNew(ItemCombobox item, string usergroupid,string moduleid) {
            DataRow row = this.AddNew();
            row["FUNCTION_ID"] = item.Id;
            //row["FUNCTION_NAME"] = item.Name;
            row["USER_GROUP_ID"] = usergroupid;
            row["FUNCTION_GROUP_ID"] = this.FTSMain.ResourceManager.GetValue("SEC_GROUP_FUNC_" + item.Tag.ToString(), "SEC_GROUP_FUNC_" + item.Tag.ToString());
            row["MODULE_ID"] = moduleid;
            row["PROJECT_ID"] = item.Tag;
            return row;
        }

        private string mfilter;

        public string filter
        {
            get
            {
                if (string.IsNullOrEmpty(this.mfilter))
                {
                    this.mfilter = " 1=1";
                }
                return this.mfilter;
            }
            set
            {
                this.mfilter = value;
                this.DataTable.DefaultView.RowFilter = this.mfilter;

            }
        }

        public override void LoadData()
        {
            string sql = @"SELECT  a.* ,
                                    '' AS FUNCTION_NAME ,
                                    '' AS FUNCTION_GROUP_ID ,
                                    b.MODULE_ID ,
                                    b.PROJECT_ID
                            FROM    dbo.SEC_PERMISSION a LEFT JOIN
                                    ( SELECT    a.MENU_ID ,
                                                PROJECT_ID ,
                                                MODULE_ID ,
                                                FUNCTION_ID
                                      FROM      (SELECT    MENU_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_MENU
                              UNION
                              SELECT    TRAN_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_TRAN
                              WHERE     ( TRAN_ID NOT IN ( SELECT   MENU_ID
                                                           FROM     dbo.SYS_MENU AS SYS_MENU_1 ) )) a ,
                                                dbo.SYS_MENU_MAPPING b
                                      WHERE     a.MENU_ID = b.MENU_ID
                                    ) b
                            on   a.FUNCTION_ID = b.FUNCTION_ID
                        ";
            this.LoadDataByCommand(this.FTSMain.DbMain.GetSqlStringCommand(sql));
            List<ItemCombobox> list = FTSFunctionCollection.GetFunctionList(this.FTSMain);
            foreach (DataRow row in this.DataTable.Rows)
            {
                foreach (ItemCombobox item in list)
                {
                    if (item.Id == row["FUNCTION_ID"].ToString())
                    {
                        row["FUNCTION_GROUP_ID"] = item.Tag;
                        row["FUNCTION_NAME"] = item.Name;
                    }
                }
                if (row["FUNCTION_NAME"].ToString() == "")
                {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_SEC_FUNC_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
                if (row["FUNCTION_NAME"].ToString() == "")
                {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_FUNCTION_NAME_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
            }
            this.DataTable.AcceptChanges();
            this.DataSet.AcceptChanges();
            
        }

        public void FillData(string usergroupid, string module_id, string project_id)
        {
            List<ItemCombobox> list = FTSFunctionCollection.GetFunctionList(this.FTSMain);
            string sql_sys = @"SELECT  a.* ,
                                    '' AS FUNCTION_NAME ,
                                    '' AS FUNCTION_GROUP_ID ,
                                    b.MODULE_ID ,
                                    b.PROJECT_ID
                            FROM    dbo.SEC_PERMISSION a LEFT JOIN
                                    ( SELECT    a.MENU_ID ,
                                                PROJECT_ID ,
                                                MODULE_ID ,
                                                FUNCTION_ID
                                      FROM      (SELECT    MENU_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_MENU
                              UNION
                              SELECT    TRAN_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_TRAN
                              WHERE     ( TRAN_ID NOT IN ( SELECT   MENU_ID
                                                           FROM     dbo.SYS_MENU AS SYS_MENU_1 ) )) a ,
                                                dbo.SYS_MENU_MAPPING b
                                      WHERE     a.MENU_ID = b.MENU_ID
                                    ) b
                            on   a.FUNCTION_ID = b.FUNCTION_ID where USER_GROUP_ID='" + usergroupid + @"' and PROJECT_ID='SYS'
UNION";
            

            string sql = @"
SELECT DISTINCT a.* ,
                                    '' AS FUNCTION_NAME ,
                                    '' AS FUNCTION_GROUP_ID ,
                                    b.MODULE_ID ,
                                    b.PROJECT_ID
                            FROM    dbo.SEC_PERMISSION a LEFT JOIN
                                    ( SELECT    a.MENU_ID ,
                                                PROJECT_ID ,
                                                MODULE_ID ,
                                                FUNCTION_ID
                                      FROM      (SELECT    MENU_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_MENU
                              UNION
                              SELECT    TRAN_ID ,
                                        MODULE_ID ,
                                        PROJECT_ID
                              FROM      dbo.SYS_TRAN
                              WHERE     ( TRAN_ID NOT IN ( SELECT   MENU_ID
                                                           FROM     dbo.SYS_MENU AS SYS_MENU_1 ) )) a ,
                                                dbo.SYS_MENU_MAPPING b
                                      WHERE     a.MENU_ID = b.MENU_ID
                                    ) b
                            on   a.FUNCTION_ID = b.FUNCTION_ID where 
                            USER_GROUP_ID='" + usergroupid + "' and PROJECT_ID='" +
                                                project_id + @"' and MODULE_ID = '" + module_id + "'";
            string sql_report = @"UNION ALL select SEC_PERMISSION.*,'' as FUNCTION_NAME,'REPORT' as FUNCTION_GROUP_ID,SYS_REPORT_GROUP.MODULE_ID,SYS_REPORT_GROUP.PROJECT_ID
 from SEC_PERMISSION
 INNER JOIN SYS_REPORT ON SYS_REPORT.REPORT_ID=SUBSTRING(FUNCTION_ID,8,LEN(FUNCTION_ID)-LEN(SUBSTRING(FUNCTION_ID,0,8)))
 LEFT JOIN SYS_REPORT_GROUP on SYS_REPORT_GROUP.REPORT_GROUP_ID= SYS_REPORT.REPORT_GROUP_ID where SEC_PERMISSION.USER_GROUP_ID='" + usergroupid + "' " +
                                "and SYS_REPORT_GROUP.PROJECT_ID='" +
                                                project_id + @"' and SYS_REPORT_GROUP.MODULE_ID = '" + module_id + "'"; 
            if (module_id != "SYS_PER")
                this.LoadDataByCommand(this.FTSMain.DbMain.GetSqlStringCommand(sql + sql_report));
            else
                this.LoadDataByCommand(this.FTSMain.DbMain.GetSqlStringCommand(sql_sys + sql + sql_report));

            this.DataTable.PrimaryKey = new DataColumn[] { this.DataTable.Columns["FUNCTION_ID"] };
            foreach (DataRow row in this.DataTable.Rows)
            {
                foreach (ItemCombobox item in list)
                {
                    if (item.Id == row["FUNCTION_ID"].ToString())
                    {
                        row["FUNCTION_GROUP_ID"] = this.FTSMain.ResourceManager.GetValue("SEC_GROUP_FUNC_" + item.Tag.ToString(), "SEC_GROUP_FUNC_" + item.Tag.ToString());
                        row["FUNCTION_NAME"] = item.Name;
                    }
                }
                if (row["FUNCTION_NAME"].ToString() == "")
                {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_SEC_FUNC_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
                if (row["FUNCTION_NAME"].ToString() == "")
                {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_FUNCTION_NAME_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
                if (row["FUNCTION_GROUP_ID"].ToString() == "")
                {
                    row["FUNCTION_GROUP_ID"] = "Chứng từ";
                }
                if (row["FUNCTION_GROUP_ID"].ToString() == "REPORT")
                {
                    string report_id = row["FUNCTION_ID"].ToString();
                    report_id = report_id.Replace("REPORT_", "");
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetReportName(report_id);
                }
            }
            this.DataTable.AcceptChanges();
            List<ItemCombobox> addlist = new List<ItemCombobox>();
            foreach (ItemCombobox item in list) {
                bool found = false;
                foreach (DataRow row in this.DataTable.Rows) {
                    if (item.Id == row["FUNCTION_ID"].ToString()) {
                        found = true;
                    }
                }
                if (found == false && item.Tag.ToString() == "SYS" && module_id == "SYS_PER") {
                    addlist.Add(item);
                }
            }
            foreach (ItemCombobox item in addlist) {
                DataRow row = this.AddNew(item,usergroupid, module_id);
                if (row["FUNCTION_NAME"].ToString() == "") {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_SEC_FUNC_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
                if (row["FUNCTION_NAME"].ToString() == "") {
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetValue("MSG_FUNCTION_NAME_" + row["FUNCTION_ID"], row["FUNCTION_NAME"].ToString());
                }
                if (row["FUNCTION_GROUP_ID"].ToString() == "") {
                    row["FUNCTION_GROUP_ID"] = "Chứng từ";
                }
                if (row["FUNCTION_GROUP_ID"].ToString() == "REPORT") {
                    string report_id = row["FUNCTION_ID"].ToString();
                    report_id = report_id.Replace("REPORT_", "");
                    row["FUNCTION_NAME"] = this.FTSMain.ResourceManager.GetReportName(report_id);
                }
            }

        }
        public void CopyPermission(string user_group_id)
        {
            this.Clear();
            string sql = @"SELECT * FROM SEC_PERMISSION WHERE USER_GROUP_ID = 'ADMIN'";
            DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),
                                                             "SEC_PERMISSION");
            foreach (DataRow item in dt.Rows)
            {
                item["USER_GROUP_ID"] = user_group_id;
                this.AddNew(item);
            }
            this.UpdateData();
        }

        public void CopyPermission(string user_group_id, string user_group_id_copy)
        {
            try
            {
                this.Clear();
                string sql = @"SELECT * FROM SEC_PERMISSION WHERE USER_GROUP_ID = '" + user_group_id_copy + "'";
                DataTable dt = this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql),
                                                                 "SEC_PERMISSION");
                foreach (DataRow item in dt.Rows)
                {
                    item["USER_GROUP_ID"] = user_group_id;
                    this.AddNew(item);
                }
                this.UpdateData();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override void LoadEmptyData()
        {
            string sql = @"SELECT SEC_PERMISSION.*,'' AS FUNCTION_NAME,'' AS FUNCTION_GROUP_ID, '' as MODULE_ID, '' as PROJECT_ID FROM SEC_PERMISSION WHERE 1=0";
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet, this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }
        public override void UpdateData()
        {
            string SQL = "UPDATE dbo.SYS_RESOURCE SET RES_VALUE = N'@res_value' WHERE RES_ID = 'MSG_FUNCTION_NAME_@res_id'";
            string temp = "";
            foreach (DataRow item in this.DataTable.Rows)
            {
                if (item.RowState == DataRowState.Modified)
                {
                    temp = SQL.Replace("@res_value", item["FUNCTION_NAME"].ToString())
                                                        .Replace("@res_id", item["FUNCTION_ID"].ToString());
                    this.FTSMain.DbMain.ExecuteNonQuery(this.FTSMain.DbMain.GetSqlStringCommand(temp));
                }
            }
            base.UpdateData();
            this.DataSet.AcceptChanges();
        }
        public override void LoadOtherDm()
        {
            if (this.DataSet.Tables.IndexOf("SEC_USER_GROUP") < 0)
            {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SEC_USER_GROUP", "*", "1=1");
                this.DataSet.Tables["SEC_USER_GROUP"].PrimaryKey = new DataColumn[] {
                this.DataSet.Tables["SEC_USER_GROUP"].Columns["USER_GROUP_NAME"]};
            }
            if (this.DataSet.Tables.IndexOf("SYS_MENU") < 0)
            {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_MENU", "distinct project_id,module_id", "1=1");
            }
            if (this.DataSet.Tables.IndexOf("SEC_USER") < 0)
            {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SEC_USER", "*", "1=1");
            }
        }
        public void DeleteData(string usergroupid)
        {
            Sec_User secU = new Sec_User(FTSMain);
            //List<DataRow> listU = new List<DataRow>();
            //foreach (DataRow row in secU.DataTable.Rows)
            //{
            //    if (this.IsValidRow(row) && row["USER_GROUP_ID"].ToString() == usergroupid)
            //    {
            //        listU.Add(row);
            //    }
            //}
            //foreach (DataRow row in listU)
            //{
            //    row.Delete();
            //}
            secU.DeleteAllWithFilter("USER_GROUP_ID = '" + usergroupid + "'");
            secU.UpdateData();
            List<DataRow> list = new List<DataRow>();
            foreach (DataRow row in this.DataTable.Rows)
            {
                if (this.IsValidRow(row) && row["USER_GROUP_ID"].ToString() == usergroupid)
                {
                    list.Add(row);
                }
            }
            foreach (DataRow row in list)
            {
                row.Delete();
            }
            this.UpdateData();
        }
        public override bool HasChanged()
        {
            DataTable dt = this.DataTable.GetChanges();
            if (dt == null) return false;
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
    }
}