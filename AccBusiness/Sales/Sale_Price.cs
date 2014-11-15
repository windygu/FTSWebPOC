#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.AccBusiness.Sale{
    public class Sale_Price : ObjectBase{
        public Sale_Price(FTSMain ftsmain) : base(ftsmain, "sale_price"){
            this.LoadData();            
            this.LoadFields();
        }

        public Sale_Price(FTSMain ftsmain, bool isempty) : base(ftsmain, "sale_price"){
            if (!isempty){
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sale_Price(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sale_price"){
            this.LoadFields();
        }

        public override void LoadFields(){
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Guid,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VALID_DATE", DbType.Date,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_PRICE",
                                                                               DbType.Decimal, false));
        }

        public override void LoadOtherDm(){
            if (this.DataSet.Tables.IndexOf("DM_ITEM") < 0){
                this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ITEM", "ITEM_ID,ITEM_NAME",
                                                    "ACTIVE=1");
            }
        }

        public override void RefreshDm(){
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ITEM", "ITEM_ID,ITEM_NAME", "ACTIVE=1");
        }

       

        public decimal GetSalePrice(string itemid, DateTime date){
            DataView dv = new DataView(this.DataTable,
                                       "item_id='" + itemid + "' and valid_date <=" +
                                       Functions.ParseDateFilter(date), "valid_date desc", DataViewRowState.CurrentRows);
            if (dv.Count > 0){
                return (decimal) dv[0]["UNIT_PRICE"];
            }
            return 0;
        }
    }
}