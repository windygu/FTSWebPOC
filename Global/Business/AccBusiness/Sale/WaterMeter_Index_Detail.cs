using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class WaterMeter_Index_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public WaterMeter_Index_Detail()
        {
        }
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
        private decimal mIndex_1;
        public decimal Index_1
        {
            get { return mIndex_1; }
            set { mIndex_1 = value; }
        }
        private decimal mIndex_2;
        public decimal Index_2
        {
            get { return mIndex_2; }
            set { mIndex_2 = value; }
        }
        private decimal mIndex_3;
        public decimal Index_3
        {
            get { return mIndex_3; }
            set { mIndex_3 = value; }
        }
        private decimal mBegin_Index;
        public decimal Begin_Index
        {
            get { return mBegin_Index; }
            set { mBegin_Index = value; }
        }
        private decimal mEnd_Index;
        public decimal End_Index
        {
            get { return mEnd_Index; }
            set { mEnd_Index = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private Int16 mMeter_No;
        public Int16 Meter_No
        {
            get { return mMeter_No; }
            set { mMeter_No = value; }
        }
        private decimal mEverage;
        public decimal Everage
        {
            get { return mEverage; }
            set { mEverage = value; }
        }
        private Int16 mIs_Damage;
        public Int16 Is_Damage
        {
            get { return mIs_Damage; }
            set { mIs_Damage = value; }
        }
        private decimal mUsed_Index;
        public decimal Used_Index
        {
            get { return mUsed_Index; }
            set { mUsed_Index = value; }
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
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private decimal mAmount_Vat;
        public decimal Amount_Vat
        {
            get { return mAmount_Vat; }
            set { mAmount_Vat = value; }
        }
        private decimal mTotal_Amount;
        public decimal Total_Amount
        {
            get { return mTotal_Amount; }
            set { mTotal_Amount = value; }
        }
        private decimal mAmount_Orig_Vat;
        public decimal Amount_Orig_Vat
        {
            get { return mAmount_Orig_Vat; }
            set { mAmount_Orig_Vat = value; }
        }
        private decimal mTotal_Amount_Orig;
        public decimal Total_Amount_Orig
        {
            get { return mTotal_Amount_Orig; }
            set { mTotal_Amount_Orig = value; }
        }
        private decimal mVat_Tax_Amount_Extra;
        public decimal Vat_Tax_Amount_Extra
        {
            get { return mVat_Tax_Amount_Extra; }
            set { mVat_Tax_Amount_Extra = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private decimal mTotal_Amount_Extra;
        public decimal Total_Amount_Extra
        {
            get { return mTotal_Amount_Extra; }
            set { mTotal_Amount_Extra = value; }
        }
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private string mMeter_Id;
        public string Meter_Id
        {
            get { return mMeter_Id; }
            set { mMeter_Id = value; }
        }
    }
}
