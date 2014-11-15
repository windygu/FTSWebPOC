
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Purchase
{
    [Serializable]
    public class PO_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mPr_detail_Id;
        public string Pr_detail_Id {
            get { return mPr_detail_Id; }
            set { mPr_detail_Id = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mDescription_Uls;
        public string Description_Uls
        {
            get { return mDescription_Uls; }
            set { mDescription_Uls = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mQuantity_Extra;
        public decimal Quantity_Extra
        {
            get { return mQuantity_Extra; }
            set { mQuantity_Extra = value; }
        }
        private decimal mQuantity_Wh;
        public decimal Quantity_Wh
        {
            get { return mQuantity_Wh; }
            set { mQuantity_Wh = value; }
        }
        private decimal mUnit_Price_Orig;
        public decimal Unit_Price_Orig
        {
            get { return mUnit_Price_Orig; }
            set { mUnit_Price_Orig = value; }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }
        private decimal mUnit_Price_Wh;
        public decimal Unit_Price_Wh
        {
            get { return mUnit_Price_Wh; }
            set { mUnit_Price_Wh = value; }
        }
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mVat_Income_Amount_Orig;
        public decimal Vat_Income_Amount_Orig
        {
            get { return mVat_Income_Amount_Orig; }
            set { mVat_Income_Amount_Orig = value; }
        }
        private decimal mVat_Income_Amount;
        public decimal Vat_Income_Amount
        {
            get { return mVat_Income_Amount; }
            set { mVat_Income_Amount = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private decimal mVat_Tax_Rate;
        public decimal Vat_Tax_Rate
        {
            get { return mVat_Tax_Rate; }
            set { mVat_Tax_Rate = value; }
        }
        private decimal mVat_Tax_Amount;
        public decimal Vat_Tax_Amount
        {
            get { return mVat_Tax_Amount; }
            set { mVat_Tax_Amount = value; }
        }
        private decimal mVat_Tax_Amount_Orig;
        public decimal Vat_Tax_Amount_Orig
        {
            get { return mVat_Tax_Amount_Orig; }
            set { mVat_Tax_Amount_Orig = value; }
        }
        private decimal mImport_Tax_Rate;
        public decimal Import_Tax_Rate
        {
            get { return mImport_Tax_Rate; }
            set { mImport_Tax_Rate = value; }
        }
        private decimal mImport_Tax_Amount;
        public decimal Import_Tax_Amount
        {
            get { return mImport_Tax_Amount; }
            set { mImport_Tax_Amount = value; }
        }
        private decimal mImport_Tax_Amount_Orig;
        public decimal Import_Tax_Amount_Orig
        {
            get { return mImport_Tax_Amount_Orig; }
            set { mImport_Tax_Amount_Orig = value; }
        }
        private decimal mPurchase_Cost;
        public decimal Purchase_Cost
        {
            get { return mPurchase_Cost; }
            set { mPurchase_Cost = value; }
        }
        private decimal mPurchase_Cost_Orig;
        public decimal Purchase_Cost_Orig
        {
            get { return mPurchase_Cost_Orig; }
            set { mPurchase_Cost_Orig = value; }
        }
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
        }
        private decimal mDiscount_Amount;
        public decimal Discount_Amount
        {
            get { return mDiscount_Amount; }
            set { mDiscount_Amount = value; }
        }
        private decimal mDiscount_Amount_Orig;
        public decimal Discount_Amount_Orig
        {
            get { return mDiscount_Amount_Orig; }
            set { mDiscount_Amount_Orig = value; }
        }
        private decimal mTotal_Amount;
        public decimal Total_Amount
        {
            get { return mTotal_Amount; }
            set { mTotal_Amount = value; }
        }
        private decimal mTotal_Amount_Orig;
        public decimal Total_Amount_Orig
        {
            get { return mTotal_Amount_Orig; }
            set { mTotal_Amount_Orig = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private decimal mVat_Income_Amount_Extra;
        public decimal Vat_Income_Amount_Extra
        {
            get { return mVat_Income_Amount_Extra; }
            set { mVat_Income_Amount_Extra = value; }
        }
        private decimal mVat_Tax_Amount_Extra;
        public decimal Vat_Tax_Amount_Extra
        {
            get { return mVat_Tax_Amount_Extra; }
            set { mVat_Tax_Amount_Extra = value; }
        }
        private decimal mDiscount_Amount_Extra;
        public decimal Discount_Amount_Extra
        {
            get { return mDiscount_Amount_Extra; }
            set { mDiscount_Amount_Extra = value; }
        }
        private decimal mImport_Tax_Amount_Extra;
        public decimal Import_Tax_Amount_Extra
        {
            get { return mImport_Tax_Amount_Extra; }
            set { mImport_Tax_Amount_Extra = value; }
        }
        private decimal mPurchase_Cost_Extra;
        public decimal Purchase_Cost_Extra
        {
            get { return mPurchase_Cost_Extra; }
            set { mPurchase_Cost_Extra = value; }
        }
        private decimal mTotal_Amount_Extra;
        public decimal Total_Amount_Extra
        {
            get { return mTotal_Amount_Extra; }
            set { mTotal_Amount_Extra = value; }
        }
        private decimal mLux_Tax_Rate;
        public decimal Lux_Tax_Rate
        {
            get { return mLux_Tax_Rate; }
            set { mLux_Tax_Rate = value; }
        }
        private decimal mLux_Tax_Amount;
        public decimal Lux_Tax_Amount
        {
            get { return mLux_Tax_Amount; }
            set { mLux_Tax_Amount = value; }
        }
        private decimal mLux_Tax_Amount_Orig;
        public decimal Lux_Tax_Amount_Orig
        {
            get { return mLux_Tax_Amount_Orig; }
            set { mLux_Tax_Amount_Orig = value; }
        }
        private decimal mLux_Tax_Amount_Extra;
        public decimal Lux_Tax_Amount_Extra
        {
            get { return mLux_Tax_Amount_Extra; }
            set { mLux_Tax_Amount_Extra = value; }
        }
        private decimal mQuantity_Order;
        public decimal Quantity_Order
        {
            get { return mQuantity_Order; }
            set { mQuantity_Order = value; }
        }
        private decimal mQuantity_Invoice;
        public decimal Quantity_Invoice
        {
            get { return mQuantity_Invoice; }
            set { mQuantity_Invoice = value; }
        }
        private decimal mQuantity_Receive;
        public decimal Quantity_Receive
        {
            get { return mQuantity_Receive; }
            set { mQuantity_Receive = value; }
        }
        private decimal mQuantity_PRI;
        public decimal Quantity_PRI
        {
            get { return mQuantity_PRI; }
            set { mQuantity_PRI = value; }
        }
        #region IHead Members

        public DataState DataState
        {
            get
            {
                return this.mDataState;
            }
            set
            {
                this.mDataState = value;
            }
        }

        public object IdValue
        {
            get
            {
                return this.mIdValue;
            }
            set
            {
                this.mIdValue = value;
            }
        }


        #endregion  
    }
}