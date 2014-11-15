
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Balance : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Balance()
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
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private decimal mAmount_Debit;
        public decimal Amount_Debit
        {
            get { return mAmount_Debit; }
            set { mAmount_Debit = value; }
        }
        private decimal mAmount_Credit;
        public decimal Amount_Credit
        {
            get { return mAmount_Credit; }
            set { mAmount_Credit = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mAmount_Debit_Orig;
        public decimal Amount_Debit_Orig
        {
            get { return mAmount_Debit_Orig; }
            set { mAmount_Debit_Orig = value; }
        }
        private decimal mAmount_Credit_Orig;
        public decimal Amount_Credit_Orig
        {
            get { return mAmount_Credit_Orig; }
            set { mAmount_Credit_Orig = value; }
        }
        private decimal mAmount_Debit_Extra;
        public decimal Amount_Debit_Extra
        {
            get { return mAmount_Debit_Extra; }
            set { mAmount_Debit_Extra = value; }
        }
        private decimal mAmount_Credit_Extra;
        public decimal Amount_Credit_Extra
        {
            get { return mAmount_Credit_Extra; }
            set { mAmount_Credit_Extra = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
    }
}