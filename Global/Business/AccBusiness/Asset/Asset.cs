
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Asset
{
    [Serializable]
    public class Asset : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Asset()
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
        private string mAsset_No;
        public string Asset_No
        {
            get { return mAsset_No; }
            set { mAsset_No = value; }
        }
        private string mAsset_Id;
        public string Asset_Id
        {
            get { return mAsset_Id; }
            set { mAsset_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mFa_Class_Id;
        public string Fa_Class_Id
        {
            get { return mFa_Class_Id; }
            set { mFa_Class_Id = value; }
        }
        private string mManu_Year;
        public string Manu_Year
        {
            get { return mManu_Year; }
            set { mManu_Year = value; }
        }
        private string mManu_Country;
        public string Manu_Country
        {
            get { return mManu_Country; }
            set { mManu_Country = value; }
        }
        private string mUnit;
        public string Unit
        {
            get { return mUnit; }
            set { mUnit = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private string mFa_Status_Id;
        public string Fa_Status_Id
        {
            get { return mFa_Status_Id; }
            set { mFa_Status_Id = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private DateTime mPurchase_Date;
        public DateTime Purchase_Date
        {
            get { return mPurchase_Date; }
            set { mPurchase_Date = value; }
        }
        private DateTime mUse_Date;
        public DateTime Use_Date
        {
            get { return mUse_Date; }
            set { mUse_Date = value; }
        }
        private DateTime mLiquid_Date;
        public DateTime Liquid_Date
        {
            get { return mLiquid_Date; }
            set { mLiquid_Date = value; }
        }
        private DateTime mDep_Cease_Date;
        public DateTime Dep_Cease_Date
        {
            get { return mDep_Cease_Date; }
            set { mDep_Cease_Date = value; }
        }
        private string mDep_Method_Id;
        public string Dep_Method_Id
        {
            get { return mDep_Method_Id; }
            set { mDep_Method_Id = value; }
        }
        private int mDep_Length;
        public int Dep_Length
        {
            get { return mDep_Length; }
            set { mDep_Length = value; }
        }
        private string mFa_Account_Id;
        public string Fa_Account_Id
        {
            get { return mFa_Account_Id; }
            set { mFa_Account_Id = value; }
        }
        private string mDep_Account_Id;
        public string Dep_Account_Id
        {
            get { return mDep_Account_Id; }
            set { mDep_Account_Id = value; }
        }
        private string mExpense_Account_Id;
        public string Expense_Account_Id
        {
            get { return mExpense_Account_Id; }
            set { mExpense_Account_Id = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }

    }
}