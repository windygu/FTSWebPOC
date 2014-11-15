#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_Report : ObjectBase {
        public Sys_Report(FTSMain ftsmain) : base(ftsmain, "Sys_Report") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Report(FTSMain ftsmain, bool isempty) : base(ftsmain, "Sys_Report") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Report(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "Sys_Report") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REPORT_ID", DbType.String,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REPORT_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PARENT_ID",
                                                                               DbType.String, false));            
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REPORT_GROUP_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TEMPLATE_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TEMPLATE_TABLE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TEMPLATE_TABLE_TMP",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REQUIRED_FILTER",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REQUIRED_FILTER_DISTINCT", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FILTER_LIST",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LIST_ORDER",
                                                                               DbType.Int16, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_FIELD1",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_FIELD2",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_FIELD3",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_FIELD4",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_FIELD5",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_TABLE1",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_TABLE2",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_TABLE3",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_TABLE4",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "GROUP_TABLE5",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
            this.ExcludedFieldList = "REPORT_NAME";
            
        }

        public override void LoadData()
        {
            string sql = "select SYS_REPORT.*,'' as REPORT_NAME from SYS_REPORT";
            if (this.DataTable != null)
            {
                this.DataTable.Clear();
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                                             this.TableName);
            foreach (DataRow row in this.DataSet.Tables[this.TableName].Rows)
            {
                row["REPORT_NAME"] = this.FTSMain.ResourceManager.GetReportName(row["REPORT_ID"].ToString());
            }
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }

        public override void LoadEmptyData()
        {
            string sql = "select SYS_REPORT.*,'' as REPORT_NAME  from SYS_REPORT where 1=0";

            if (this.DataTable != null)
            {
                this.DataTable.Clear();
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                                             this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }
        public override void LoadOtherDm()
        {
            if (this.DataSet.Tables.IndexOf("SYS_REPORT_GROUP") < 0)
            {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_REPORT_GROUP", "REPORT_GROUP_ID,REPORT_GROUP_NAME",
                                                    "ACTIVE=1");
            }
        }
        public override void SetRole() {
            this.FTSFunction = FTSFunctionCollection.SYS_REPORT;
        }
    }
}