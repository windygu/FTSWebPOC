using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.BaseBusiness.ImportData {
    public class Dm_Template : ObjectBase {
        private string Tran_Id;

        public Dm_Template(FTSMain ftsmain, DataSet dataset, string tran_id) : base(ftsmain, dataset, "Dm_Template", true){
            this.Tran_Id = tran_id;
            this.LoadFields();
        }

        public void SetTranId(string tranid){
            this.Tran_Id = tranid;
        }

        public override void LoadFields() {
            this.FieldCollection = new System.Collections.Generic.List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Decimal, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TEMPLATE_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_FIRST_ROW_DATA", DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID", DbType.String, false));
        }

        public override DataRow AddNew(){
            DataRow row = base.AddNew();
            row["tran_id"] = this.Tran_Id;
            row.EndEdit();
            return row;
        }

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();

            foreach (DataRow row in this.DataTable.Rows) {
                if (this.IsValidRow(row)) {

                    if (string.IsNullOrEmpty(row["TEMPLATE_NAME"].ToString())) {
                        throw (new FTSException(null, "MSG_INVALID_TEMPLATE_NAME", this.TableName, "TEMPLATE_NAME", 0));
                    }
                }
            }
        }
    }
}
