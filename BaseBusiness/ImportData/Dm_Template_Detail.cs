using System;
using System.Data;
using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.BaseBusiness.ImportData {
    public class Dm_Template_Detail : ObjectBase {
        
        public Dm_Template_Detail (FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Dm_Template_Detail", true){
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Decimal, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FR_KEY", DbType.Decimal, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LIST_ORDER", DbType.Int32, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "EXCEL_COLUMN_NO", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DATA_COLUMN_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DATA_TYPE", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_PR_KEY", DbType.Boolean, false));
        }

        //public override void LoadOtherDm() {
        //    string sql = "";
        //    if (this.DataSet.Tables.IndexOf("DM_SQL") < 0) {
        //        this.DataSet.Tables.Add(
        //            this.FTSMain.DbMain.LoadDataTable(
        //                this.FTSMain.DbMain.GetSqlStringCommand(@"select a.name as DM_TABLE,b.name as DM_COLUMN from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name = '" +
        //                                                        tableName + "'"), "DM_SQL"));
        //    } else {
        //        this.DataSet.Tables.Remove("DM_SQL");
        //        this.DataSet.Tables.Add(
        //            this.FTSMain.DbMain.LoadDataTable(
        //                this.FTSMain.DbMain.GetSqlStringCommand(@"select a.name as DM_TABLE,b.name as DM_COLUMN from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name = '" +
        //                                                        tableName + "'"), "DM_SQL"));
        //    }
        //    if (this.DataSet.Tables.IndexOf("DM_EXCEL") < 0) {
        //        this.DataSet.Tables.Add(this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("select '' EXCELCOLUMNS"), "DM_EXCEL"));
        //    }
        //}

        //public override void RefreshDm() {
        //    this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_TEMPLATE", "ACTIVE=1");
        //    string sql = "select a.name as DM_TABLE,b.name as DM_COLUMN from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name = '" + tableName + "'";
        //    this.DataSet.Tables.Add(this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand("select '' EXCELCOLUMNS"), "DM_EXCEL"));
        //    this.FTSMain.DbMain.LoadDataTable(this.FTSMain.DbMain.GetSqlStringCommand(sql), "DM_SQL");
        //}

        //public void AddNewImport(string Temp_Type) {
        //    this.DataTable.Rows.Clear();
        //    foreach (DataRow item in this.DataSet.Tables["DM_SQL"].Rows) {
        //        DataRow dr = this.AddNew();
        //        dr["TEMPLATE_ID"] = Temp_Type;
        //        dr["DATA_COLUMN_NAME"] = item["DM_COLUMN"];
        //        // this.DataTable.Rows.Add(dr);
        //    }
        //}

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
            int pos = 0;
            foreach (DataRow row in this.DataTable.Rows) {
                if (this.IsValidRow(row)) {
                    if (row["EXCEL_COLUMN_NO"].ToString().Trim() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_EXCEL_COLUMN_NO", this.TableName, "EXCEL_COLUMN_NO", pos));
                    }
                    if (row["DATA_COLUMN_NAME"].ToString().Trim() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_DATA_COLUMN_NAME", this.TableName, "DATA_COLUMN_NAME", pos));
                    }
                }
                pos++;
            }
            
        }
    }
}
