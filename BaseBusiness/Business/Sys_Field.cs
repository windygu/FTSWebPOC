#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public sealed class Sys_Field : ObjectBase {
        public string parenttablename = string.Empty;

        public Sys_Field(FTSMain ftsmain) : base(ftsmain, "sys_field") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Field(FTSMain ftsmain, bool isempty) : base(ftsmain, "sys_field") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Field(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_field") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FIELD_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FIELD_LENGTH",
                                                                               DbType.Int32, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REQUIRED",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ALLOWDBNULL",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "BOUND", DbType.Boolean,
                                                                               false));
        }

        public override void LoadData() {
            this.Clear();
            string query = "SELECT * FROM SYS_FIELD WHERE TABLE_NAME='" + this.parenttablename + "' order by FIELD_NAME";
            base.LoadDataByCommand(this.FTSMain.DbMain.GetSqlStringCommand(query));
        }

        public override void LoadOtherDm() {
            if (this.DataSet.Tables.IndexOf("SYS_TABLE") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TABLE", "TABLE_NAME,TABLE_NAME AS DISPLAY_NAME",
                                                    "1=1");
            }
        }

        public override void RefreshDm() {
            this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TABLE", "TABLE_NAME,TABLE_NAME AS DISPLAY_NAME", "1=1");
        }
        public override void CheckBusinessRules() {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                throw (new FTSException("MSG_NO_PERMISSION"));
            }
            base.CheckBusinessRules();
        }
    }
}