#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_Tran_No : ObjectBase {
        public Sys_Tran_No(FTSMain ftsmain) : base(ftsmain, "sys_tran_no") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Tran_No(FTSMain ftsmain, bool isempty) : base(ftsmain, "sys_tran_no") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Tran_No(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_tran_no") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_YEAR", DbType.Int32,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LAST_TRAN_NO",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PRE_FIX", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "POST_FIX", DbType.String,
                                                                               false));
        }

        public override void LoadOtherDm() {
            if (this.DataSet.Tables.IndexOf("SYS_TRAN") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN", "TRAN_ID,TRAN_NAME", "1=1");
            }
            if (this.DataSet.Tables.IndexOf("DM_ORGANIZATION") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE", "1=1");
            }
        }

        public override void LoadData() {
            this.LoadDataByCommand(
                this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM SYS_TRAN_NO WHERE TRAN_YEAR=" +
                                                        this.FTSMain.DayStartOfCurrentYear.Year));
        }
    }
}