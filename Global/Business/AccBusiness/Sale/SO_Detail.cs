
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class SO_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        public DataState DataState
        {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }
        public object IdValue
        {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }

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
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get { return mItem_Source_Id; }
            set { mItem_Source_Id = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
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
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
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
        private decimal mVat_Income_Amount_Extra;
        public decimal Vat_Income_Amount_Extra
        {
            get { return mVat_Income_Amount_Extra; }
            set { mVat_Income_Amount_Extra = value; }
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
        private decimal mVat_Tax_Amount_Extra;
        public decimal Vat_Tax_Amount_Extra
        {
            get { return mVat_Tax_Amount_Extra; }
            set { mVat_Tax_Amount_Extra = value; }
        }
        private decimal mExport_Tax_Rate;
        public decimal Export_Tax_Rate
        {
            get { return mExport_Tax_Rate; }
            set { mExport_Tax_Rate = value; }
        }
        private decimal mExport_Tax_Amount;
        public decimal Export_Tax_Amount
        {
            get { return mExport_Tax_Amount; }
            set { mExport_Tax_Amount = value; }
        }
        private decimal mExport_Tax_Amount_Orig;
        public decimal Export_Tax_Amount_Orig
        {
            get { return mExport_Tax_Amount_Orig; }
            set { mExport_Tax_Amount_Orig = value; }
        }
        private decimal mExport_Tax_Amount_Extra;
        public decimal Export_Tax_Amount_Extra
        {
            get { return mExport_Tax_Amount_Extra; }
            set { mExport_Tax_Amount_Extra = value; }
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
        private decimal mDiscount_Amount_Extra;
        public decimal Discount_Amount_Extra
        {
            get { return mDiscount_Amount_Extra; }
            set { mDiscount_Amount_Extra = value; }
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
        private decimal mTotal_Amount_Extra;
        public decimal Total_Amount_Extra
        {
            get { return mTotal_Amount_Extra; }
            set { mTotal_Amount_Extra = value; }
        }
        private string mPrice_Level_Id;
        public string Price_Level_Id
        {
            get { return mPrice_Level_Id; }
            set { mPrice_Level_Id = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        
        private string mDelivery_Time;
        public string Delivery_Time
        {
            get { return mDelivery_Time; }
            set { mDelivery_Time = value; }
        }
        private Int16 mIs_Sii;
        public Int16 Is_Sii
        {
            get { return mIs_Sii; }
            set { mIs_Sii = value; }
        }
        private Int16 mIs_Delivered;
        public Int16 Is_Delivered
        {
            get { return mIs_Delivered; }
            set { mIs_Delivered = value; }
        }
        private Int16 mIs_Invoiced;
        public Int16 Is_Invoiced
        {
            get { return mIs_Invoiced; }
            set { mIs_Invoiced = value; }
        }
        private decimal mQuantity_Delivery;
        public decimal Quantity_Delivery
        {
            get { return mQuantity_Delivery; }
            set { mQuantity_Delivery = value; }
        }
        private decimal mQuantity_Invoice;
        public decimal Quantity_Invoice
        {
            get { return mQuantity_Invoice; }
            set { mQuantity_Invoice = value; }
        }
        private decimal mQuantity_Sii;
        public decimal Quantity_Sii
        {
            get { return mQuantity_Sii; }
            set { mQuantity_Sii = value; }
        }

        //Tan sua PJICO
        private decimal mCommission_Rate;
        public decimal Commission_Rate
        {
            get { return mCommission_Rate; }
            set { mCommission_Rate = value; }
        }
        private decimal mCommission_Rate_Orig;
        public decimal Commission_Rate_Orig
        {
            get { return mCommission_Rate_Orig; }
            set { mCommission_Rate_Orig = value; }
        }
        private decimal mCommission_Amount;
        public decimal Commission_Amount
        {
            get { return mCommission_Amount; }
            set { mCommission_Amount = value; }
        }
        private decimal mCommission_Amount_Extra;
        public decimal Commission_Amount_Extra
        {
            get { return mCommission_Amount_Extra; }
            set { mCommission_Amount_Extra = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
        private decimal mFixed_Exchange_Rate;
        public decimal Fixed_Exchange_Rate
        {
            get { return mFixed_Exchange_Rate; }
            set { mFixed_Exchange_Rate = value; }
        }
        private string mPrints_Id;
        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mPrints_Serie;
        public string Prints_Serie
        {
            get { return mPrints_Serie; }
            set { mPrints_Serie = value; }
        }
        private string mPrints_No;
        public string Prints_No
        {
            get { return mPrints_No; }
            set { mPrints_No = value; }
        }
        private string mLicense_Plate;
        public string License_Plate
        {
            get { return mLicense_Plate; }
            set { mLicense_Plate = value; }
        }
        private DateTime mApprove_Date;
        public DateTime Approve_Date
        {
            get { return mApprove_Date; }
            set { mApprove_Date = value; }
        }
        private DateTime mRelease_Date;
        public DateTime Release_Date
        {
            get { return mRelease_Date; }
            set { mRelease_Date = value; }
        }
        private string mVehicle_Owner;
        public string Vehicle_Owner
        {
            get { return mVehicle_Owner; }
            set { mVehicle_Owner = value; }
        }
        private string mVehicle_Capacity;
        public string Vehicle_Capacity
        {
            get { return mVehicle_Capacity; }
            set { mVehicle_Capacity = value; }
        }
        private string mVehicle_Usage;
        public string Vehicle_Usage
        {
            get { return mVehicle_Usage; }
            set { mVehicle_Usage = value; }
        }
    }
}