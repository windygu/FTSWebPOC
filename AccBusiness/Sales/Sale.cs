using System;
using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.AccBusiness.Sale
{
    [Serializable]
    public class Sale : ObjectBase {
        private string mTranId = string.Empty;
        private SaleManager mSaleManager;
         public Sale(FTSMain ftsmain) : base(ftsmain, "sale"){
            this.LoadData();            
            this.LoadFields();
        }
        public Sale(FTSMain ftsmain, DataSet dataset, string tran_id, SaleManager saleManager)
            : base(ftsmain, dataset, "SALE", true) {
            this.mSaleManager = saleManager;
            this.TranId = tran_id;
            this.LoadFields();
        }

        public string TranId {
            get { return this.mTranId; }
            set { this.mTranId = value; }
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Guid,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_NO", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_DATE", DbType.Date,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_DETAIL_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ADDRESS",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TAX_FILE_NUMBER",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "COMMENTS", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "STATUS", DbType.String,
                                                                               false));
        }

        public override DataRow AddNew() {
            DataRow row = base.AddNew();
            row["tran_ID"] = this.TranId;
            row["STATUS"] = FTS.ShareBusiness.Acc.FTSTransactionStatus.POSTED;
            row.EndEdit();
            return row;
        }

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState != DataRowState.Deleted) {
                    //if (this.mSaleManager.GetDm("DM_PR_DETAIL").Rows.Find(row["PR_DETAIL_ID"]) == null) {
                    //    throw (new FTSException(null, "MSG_INVALID_PR_DETAIL_ID", this.TableName, "PR_DETAIL_ID", 0));
                    //}
                    
                }
            }
        }
    }
}