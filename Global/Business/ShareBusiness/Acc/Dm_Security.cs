using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Security: IHead
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

        private string mSecurity_Id;
        public string Security_Id
        {
            get { return mSecurity_Id; }
            set { mSecurity_Id = value; }
        }

        private string mSecurity_Name;
        public string Security_Name
        {
            get { return mSecurity_Name; }
            set { mSecurity_Name = value; }
        }

        private string mSecurity_Class_Id;
        public string Security_Class_Id
        {
            get { return mSecurity_Class_Id; }
            set { mSecurity_Class_Id = value; }
        }

        private string mCost_Method;
        public string Cost_Method
        {
            get { return mCost_Method; }
            set { mCost_Method = value; }
        }

        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }

        private string mCost_Account_Id;
        public string Cost_Account_Id
        {
            get { return mCost_Account_Id; }
            set { mCost_Account_Id = value; }
        }

        private string mProfit_Account_Id;
        public string Profit_Account_Id
        {
            get { return mProfit_Account_Id; }
            set { mProfit_Account_Id = value; }
        }

        private string mLoss_Account_Id;
        public string Loss_Account_Id
        {
            get { return mLoss_Account_Id; }
            set { mLoss_Account_Id = value; }
        }

        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }

        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
    }
}
