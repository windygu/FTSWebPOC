using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Security
{
    public class Security_Receipt:IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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

        private Guid mPr_Key;

        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mOraganization_Id;
        public string Oraganization_Id
        {
            get { return mOraganization_Id; }
            set { mOraganization_Id = value; }
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
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private DateTime mSettlement_Date;
        public DateTime Settlement_Date
        {
            get { return mSettlement_Date; }
            set { mSettlement_Date = value; }
        }
        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }
        private string mReference_No;
        public string Reference_No
        {
            get { return mReference_No; }
            set { mReference_No = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mBroker_Id;
        public string Broker_Id
        {
            get { return mBroker_Id; }
            set { mBroker_Id = value; }
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
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mStatuts;
        public string Statuts
        {
            get { return mStatuts; }
            set { mStatuts = value; }
        }
        private string mPr_Account_Id;
        public string Pr_Account_Id
        {
            get { return mPr_Account_Id; }
            set { mPr_Account_Id = value; }
        }
        private string mBank_Id;
        public string Bank_Id
        {
            get { return mBank_Id; }
            set { mBank_Id = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mPeriod_Id;
        public string Period_Id
        {
            get { return mPeriod_Id; }
            set { mPeriod_Id = value; }
        }
        private DateTime mDate_Issue;
        public DateTime Date_Issue
        {
            get { return mDate_Issue; }
            set { mDate_Issue = value; }
        }
        private DateTime mDate_Maturity;
        public DateTime Date_Maturity
        {
            get { return mDate_Maturity; }
            set { mDate_Maturity = value; }
        }
    }
}
