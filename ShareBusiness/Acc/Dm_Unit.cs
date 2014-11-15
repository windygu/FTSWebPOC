#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareBusiness.Acc{
    public class Dm_Unit : ObjectBase{
        public Dm_Unit(FTSMain ftsmain) : base(ftsmain, "dm_unit"){
            this.LoadData();
            this.LoadFields();
        }

        public Dm_Unit(FTSMain ftsmain, bool isempty) : base(ftsmain, "dm_unit"){
            if (!isempty){
                this.LoadData();
            }
            this.LoadFields();
        }

        public Dm_Unit(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "dm_unit"){
            this.LoadFields();
        }

        public override void LoadFields(){
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_ID", DbType.String, true));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
        }

        public override void SetRole(){
            this.FTSFunction = FTS.BaseBusiness.Security.FTSFunctionCollection.DM_UNIT;
        }
        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
            int pos = 0;
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified) {
                    if (row["UNIT_ID"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_UNIT_ID", this.TableName, "UNIT_ID", pos));
                    }
                    if (row["UNIT_NAME"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_UNIT_NAME", this.TableName, "UNIT_NAME", pos));
                    }
                    pos++;
                }
            }
        }
    }
}