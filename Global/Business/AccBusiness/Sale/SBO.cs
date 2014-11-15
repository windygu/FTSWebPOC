
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class SBO : IHead
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mMarket_Id;
        public string Market_Id
        {
            get { return mMarket_Id; }
            set { mMarket_Id = value; }
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
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mPr_Detail_Name;
        public string Pr_Detail_Name
        {
            get { return mPr_Detail_Name; }
            set { mPr_Detail_Name = value; }
        }
        private string mContact_Person;
        public string Contact_Person
        {
            get { return mContact_Person; }
            set { mContact_Person = value; }
        }
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get { return mTax_File_Number; }
            set { mTax_File_Number = value; }
        }
        private string mPayment_Method_Id;
        public string Payment_Method_Id
        {
            get { return mPayment_Method_Id; }
            set { mPayment_Method_Id = value; }
        }
        private string mPayment_Term_Id;
        public string Payment_Term_Id
        {
            get { return mPayment_Term_Id; }
            set { mPayment_Term_Id = value; }
        }
        private decimal mCredit_Limit;
        public decimal Credit_Limit
        {
            get { return mCredit_Limit; }
            set { mCredit_Limit = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mStatus;
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mApprover_Id;
        public string Approver_Id
        {
            get { return mApprover_Id; }
            set { mApprover_Id = value; }
        }
        private decimal mCredit_Limit1;
        public decimal Credit_Limit1
        {
            get { return mCredit_Limit1; }
            set { mCredit_Limit1 = value; }
        }
    }
}