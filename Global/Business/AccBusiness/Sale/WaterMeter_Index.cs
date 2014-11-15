using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class WaterMeter_Index : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public WaterMeter_Index()
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
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private Int16 mMonth;
        public Int16 Month
        {
            get { return mMonth; }
            set { mMonth = value; }
        }
        private string mRecorded_By;
        public string Recorded_By
        {
            get { return mRecorded_By; }
            set { mRecorded_By = value; }
        }
        private string mVerified_By;
        public string Verified_By
        {
            get { return mVerified_By; }
            set { mVerified_By = value; }
        }
        private decimal mTotal_Used;
        public decimal Total_Used
        {
            get { return mTotal_Used; }
            set { mTotal_Used = value; }
        }
        private string mLot_No;
        public string Lot_No
        {
            get { return mLot_No; }
            set { mLot_No = value; }
        }
        private string mTime;
        public string Time
        {
            get { return mTime; }
            set { mTime = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
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
        private decimal mAmount_Orig_Vat;
        public decimal Amount_Orig_Vat
        {
            get { return mAmount_Orig_Vat; }
            set { mAmount_Orig_Vat = value; }
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
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
    }
}
