using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.AccBusiness.Sale
{
    [Serializable]
    public class Sale_Detail : ObjectBase {
        private SaleManager mSaleManager;
         public Sale_Detail(FTSMain ftsmain) : base(ftsmain, "sale_detail"){
            this.LoadData();            
            this.LoadFields();
        }
        public Sale_Detail(FTSMain ftsmain, DataSet ds, SaleManager saleManager)
            : base(ftsmain, ds, "SALE_DETAIL", true) {
                this.mSaleManager = saleManager;
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Guid,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FR_KEY", DbType.Guid,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LIST_ORDER",
                                                                               DbType.Int32, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_PRICE", DbType.Currency,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "QUANTITY", DbType.Currency,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "AMOUNT", DbType.Currency,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAT_TAX_RATE", DbType.Currency,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAT_TAX_AMOUNT", DbType.Currency,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TOTAL_AMOUNT", DbType.Currency,
                                                                               false));
            
            
        }

        

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
            int count = 0;
            foreach (DataRow row in this.DataTable.Rows) {
                if (this.IsValidRow(row)) {
                    //if (this.mSaleManager.GetDm("DM_ITEM").Rows.Find(row["ITEM_ID"]) == null) {
                    //    throw (new FTSException(null, "MSG_INVALID_ITEM_ID", this.TableName, "UNIT_ID", count));
                    //}
                    //if (row["ITEM_NAME"].ToString() == string.Empty) {
                    //    throw (new FTSException(null, "MSG_INVALID_ITEM_NAME", this.TableName, "ITEM_NAME", count));
                    //}
                    //count++;
                }
            }
        }
    }
}