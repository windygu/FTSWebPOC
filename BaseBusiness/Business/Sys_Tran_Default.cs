#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_Tran_Default : ObjectBase {
        public string Tran_Id = string.Empty;

        public Sys_Tran_Default(FTSMain ftsmain) : base(ftsmain, "sys_tran_default") {
            this.IsOrganizationFilter = true;
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Tran_Default(FTSMain ftsmain, bool isempty) : base(ftsmain, "sys_tran_default") {
            this.IsOrganizationFilter = true;
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Tran_Default(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_tran_default") {
            this.IsOrganizationFilter = true;
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Decimal,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FIELD_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DEFAULT_VALUE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, false));
        }

        public override void LoadData() {
            string sql = "select * from " + this.TableNameOrig;
            if (this.FieldList != string.Empty) {
                sql = "select " + this.FieldList + " from " + this.TableNameOrig;
            }
            sql += " where tran_id='" + this.Tran_Id + "'";
            if (this.IsOrganizationFilter)
                sql += " and " + this.GetOrganizationFilter();
            else
                sql += " and " + this.FTSMain.IdManager.Filter(this.TableNameOrig, this.FTSMain.UserInfo.OrganizationID);
            if (this.IdField != string.Empty) {
                sql += " order by FIELD_NAME";
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
            row["ORGANIZATION_ID"] = this.FTSMain.UserInfo.OrganizationID;
            row.EndEdit();
            return row;
        }

        public void SetValueDefault(string tablename, string default_id, object value) {
            DataRow foundrow = this.DataTable.Rows.Find(default_id);
            if (foundrow != null) {
                foundrow["DEFAULT_VALUE"] = value != null ? value : string.Empty;
                foundrow.EndEdit();
            } else {
                if (value != null) {
                    foundrow = this.AddNew();
                    foundrow["TABLE_NAME"] = tablename.ToUpper();
                    foundrow["FIELD_NAME"] = default_id.ToUpper();
                    foundrow["DEFAULT_VALUE"] = value;
                    foundrow.EndEdit();
                }
            }
        }
        public override void CheckBusinessRules() {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                throw (new FTSException("MSG_NO_PERMISSION"));
            }
            base.CheckBusinessRules();
        }
    }
}