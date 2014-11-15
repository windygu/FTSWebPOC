
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Contract
{
    [Serializable]
    public class Contract_Rate : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Contract_Rate()
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
        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }
        private string mContract_Type;
        public string Contract_Type
        {
            get { return mContract_Type; }
            set { mContract_Type = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mInterest_Rate;
        public decimal Interest_Rate
        {
            get { return mInterest_Rate; }
            set { mInterest_Rate = value; }
        }
        private string mRate_Type;
        public string Rate_Type
        {
            get { return mRate_Type; }
            set { mRate_Type = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private decimal mOver_Interest_Rate;
        public decimal Over_Interest_Rate
        {
            get { return mOver_Interest_Rate; }
            set { mOver_Interest_Rate = value; }
        }
    }
}