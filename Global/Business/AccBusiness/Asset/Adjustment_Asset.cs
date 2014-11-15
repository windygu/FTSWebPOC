
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Asset
{
    [Serializable]
    public class Adjustment_Asset : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Adjustment_Asset()
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
        private Guid mPr_Key_Fa;
        public Guid Pr_Key_Fa
        {
            get { return mPr_Key_Fa; }
            set { mPr_Key_Fa = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private DateTime mAdjustment_Date;
        public DateTime Adjustment_Date
        {
            get { return mAdjustment_Date; }
            set { mAdjustment_Date = value; }
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
        private string mFa_Account_Id;
        public string Fa_Account_Id
        {
            get { return mFa_Account_Id; }
            set { mFa_Account_Id = value; }
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
        private string mFa_Operation_Id;
        public string Fa_Operation_Id
        {
            get { return mFa_Operation_Id; }
            set { mFa_Operation_Id = value; }
        }
        private string mFa_Source_Id;
        public string Fa_Source_Id
        {
            get { return mFa_Source_Id; }
            set { mFa_Source_Id = value; }
        }
        private DateTime mEffective_Date;
        public DateTime Effective_Date
        {
            get { return mEffective_Date; }
            set { mEffective_Date = value; }
        }
        private decimal mBook_Value_Orig;
        public decimal Book_Value_Orig
        {
            get { return mBook_Value_Orig; }
            set { mBook_Value_Orig = value; }
        }
        private decimal mBook_Dep_Value_Current;
        public decimal Book_Dep_Value_Current
        {
            get { return mBook_Dep_Value_Current; }
            set { mBook_Dep_Value_Current = value; }
        }
        private decimal mBook_Quantity;
        public decimal Book_Quantity
        {
            get { return mBook_Quantity; }
            set { mBook_Quantity = value; }
        }
        private decimal mActual_Quantity;
        public decimal Actual_Quantity
        {
            get { return mActual_Quantity; }
            set { mActual_Quantity = value; }
        }
        private decimal mActual_Value;
        public decimal Actual_Value
        {
            get { return mActual_Value; }
            set { mActual_Value = value; }
        }
        private decimal mActual_Dep_Value;
        public decimal Actual_Dep_Value
        {
            get { return mActual_Dep_Value; }
            set { mActual_Dep_Value = value; }
        }
        private decimal mRemain_Value_Current;
        public decimal Remain_Value_Current
        {
            get { return mRemain_Value_Current; }
            set { mRemain_Value_Current = value; }
        }
        private decimal mDiff_Quantity;
        public decimal Diff_Quantity
        {
            get { return mDiff_Quantity; }
            set { mDiff_Quantity = value; }
        }
        private decimal mDiff_Value;
        public decimal Diff_Value
        {
            get { return mDiff_Value; }
            set { mDiff_Value = value; }
        }
        private decimal mDiff_Dep_Value;
        public decimal Diff_Dep_Value
        {
            get { return mDiff_Dep_Value; }
            set { mDiff_Dep_Value = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
    }
}