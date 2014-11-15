#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareBusiness.Acc {
    public class Dm_Item : ObjectBase {
        public Dm_Item(FTSMain ftsmain) : base(ftsmain, "dm_item") {
            this.LoadData();
            this.LoadFields();
        }

        public Dm_Item(FTSMain ftsmain, bool isempty) : base(ftsmain, "dm_item") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Dm_Item(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "dm_item") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_ID", DbType.String,
                                                                               true));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
        }

        public override void LoadOtherDm() {
            if (this.DataSet.Tables.IndexOf("DM_UNIT") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_UNIT", "UNIT_ID,UNIT_NAME", "ACTIVE=1");
            }
        }

        public override void RefreshDm() {
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_UNIT", "UNIT_ID,UNIT_NAME", "ACTIVE=1");
        }

        public override void SetRole() {
            this.FTSFunction = FTS.BaseBusiness.Security.FTSFunctionCollection.DM_ITEM;
        }

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
            int pos = 0;
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified) {
                    if (this.DataSet.Tables["DM_UNIT"].Rows.Find(row["UNIT_ID"]) == null) {
                        throw (new FTSException(null, "MSG_INVALID_UNIT_ID", this.TableName, "UNIT_ID", pos));
                    }
                    if (row["ITEM_ID"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_ITEM_ID", this.TableName, "ITEM_ID", pos));
                    }
                    if (row["ITEM_NAME"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_ITEM_NAME", this.TableName, "ITEM_NAME", pos));
                    }
                    pos++;
                }
            }
        }
    }
}