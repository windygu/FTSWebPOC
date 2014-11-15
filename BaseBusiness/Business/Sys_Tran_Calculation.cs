#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_Tran_Calculation : ObjectBase {
        public string Tran_Id = string.Empty;

        public Sys_Tran_Calculation(FTSMain ftsmain) : base(ftsmain, "sys_tran_calculation") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Tran_Calculation(FTSMain ftsmain, bool isempty) : base(ftsmain, "sys_tran_calculation") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Tran_Calculation(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_tran_calculation") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Decimal,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FIELD_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FORMULA", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID", DbType.String,
                                                                               false));
        }

        public override void LoadData() {
            string sql = "select * from " + this.TableNameOrig;
            if (this.FieldList != string.Empty) {
                sql = "select " + this.FieldList + " from " + this.TableNameOrig;
            }
            sql += " where tran_id='" + this.Tran_Id + "'";
            if (this.IdField != string.Empty) {
                sql += " order by FIELD_ID";
            }
            if (this.DataTable != null) {
                this.DataTable.Clear();
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet, this.TableName);
            this.LoadOtherDm();
        }

        public override DataRow AddNew() {
            DataRow row = base.AddNew();
            row["tran_id"] = this.Tran_Id;
            row.EndEdit();
            return row;
        }

        public override void CheckBusinessRules() {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                throw (new FTSException("MSG_NO_PERMISSION"));
            }
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState != DataRowState.Deleted) {
                    row["formula"] = row["formula"].ToString().Replace(" ", string.Empty);
                    row.EndEdit();
                }
            }
            base.CheckBusinessRules();
        }
    }
}