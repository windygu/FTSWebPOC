using System;
using System.Collections.Generic;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using System.Data;

namespace FTS.BaseBusiness.Security
{
    public class Sys_Menu_Mapping : ObjectBase
    {
        public Sys_Menu_Mapping(FTSMain ftsmain)
            : base(ftsmain, "Sys_Menu_Mapping")
        {
            this.LoadData();
            this.LoadFields();
        }
        private string mCondition;
        public string Condition
        {
            get { return mCondition; }
            set
            {
                mCondition = value;
                this.LoadData();
            }
        }
        public Sys_Menu_Mapping(FTSMain ftsmain, string condition)
            : base(ftsmain, "Sys_Menu_Mapping")
        {
            this.Condittion = condition;
            this.LoadOtherDm();
            this.LoadFields();
        }
        public Sys_Menu_Mapping(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "Sys_Menu_Mapping")
        {
            if (!isempty) this.LoadData();
            this.LoadFields();
        }
        public Sys_Menu_Mapping(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Sys_Menu_Mapping")
        {
            this.LoadFields();
        }
        public override void LoadFields()
        {
            this.FieldCollection = new System.Collections.Generic.List<FieldInfo>();

            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FUNCTION_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MODULE_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PROJECT_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency, true));
            this.ExcludedFieldList = "MODULE_ID,PROJECT_ID";
        }
        public override void SetRole()
        {
        }
        public override void LoadData()
        {
            try
            {
                string sql = string.Empty;
                if (string.IsNullOrEmpty(mCondition)) mCondition = "1=1";
                sql = @"
                        SELECT     a.PR_KEY, a.FUNCTION_ID, a.MENU_ID, b.PROJECT_ID, b.MODULE_ID
                        FROM         dbo.SYS_MENU_MAPPING AS a RIGHT JOIN
                        dbo.SYS_MENU AS b ON a.MENU_ID = b.MENU_ID where " + mCondition;
                if (this.DataTable != null)
                {
                    this.DataTable.Clear();
                }
                this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                                                 this.TableName);
                foreach (DataRow item in this.DataTable.Rows)
                {
                    item["PROJECT_ID"] = FTSMain.MsgManager.GetMessage("PROJECT_LIST_" + item["PROJECT_ID"]);
                    item["MODULE_ID"] = FTSMain.MsgManager.GetMessage("MODULE_LIST_" + item["MODULE_ID"]);
                }
                this.DataTable.AcceptChanges();
                this.DataSet.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void LoadOtherDm()
        {
            if (this.DataSet.Tables.IndexOf("SYS_MENU") < 0)
            {
                string sql = @"SELECT *
                                FROM    ( SELECT    MENU_ID ,
                                                    '' AS MENU_NAME ,
                                                    MENU_TAG
                                          FROM      SYS_MENU
                                          UNION
                                          SELECT    TRAN_ID ,
                                                    TRAN_NAME ,
                                                    TRAN_ID
                                          FROM      dbo.SYS_TRAN WHERE TRAN_ID NOT IN (SELECT MENU_ID FROM dbo.SYS_MENU)
                                        ) a
                                        ORDER BY a.MENU_ID";
                this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                    "SYS_MENU");
                foreach (DataRow item in this.DataSet.Tables["SYS_MENU"].Rows)
                {
                    if (item["MENU_NAME"].ToString() == "")
                        item["MENU_NAME"] = this.FTSMain.TableManager.GetDisplayName(item["MENU_TAG"].ToString());
                }
                this.DataSet.Tables["SYS_MENU"].AcceptChanges();
            }
        }
        public override void RefreshDm()
        {
            if (this.DataSet.Tables.IndexOf("SYS_MENU") > 0) this.DataSet.Tables.Remove("SYS_MENU");
            string sql = @"SELECT *
                                FROM    ( SELECT    MENU_ID ,
                                                    '' AS MENU_NAME ,
                                                    MENU_TAG
                                          FROM      SYS_MENU
                                          UNION
                                          SELECT    TRAN_ID ,
                                                    TRAN_NAME ,
                                                    TRAN_ID
                                          FROM      dbo.SYS_TRAN WHERE TRAN_ID NOT IN (SELECT MENU_ID FROM dbo.SYS_MENU)
                                        ) a
                                        ORDER BY a.MENU_ID";
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                "SYS_MENU");
            foreach (DataRow item in this.DataSet.Tables["SYS_MENU"].Rows)
            {
                if (item["MENU_NAME"].ToString() == "")
                    item["MENU_NAME"] = this.FTSMain.TableManager.GetDisplayName(item["MENU_TAG"].ToString());
            }
            this.DataSet.Tables["SYS_MENU"].AcceptChanges();
        }
    }
}
