
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Asset
{
    [Serializable]
    public class Asset_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Asset_Detail()
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
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
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
        private DateTime mEnd_Date;
        public DateTime End_Date
        {
            get { return mEnd_Date; }
            set { mEnd_Date = value; }
        }
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
        private decimal mValue_Previous;
        public decimal Value_Previous
        {
            get { return mValue_Previous; }
            set { mValue_Previous = value; }
        }
        private decimal mValue_Increase;
        public decimal Value_Increase
        {
            get { return mValue_Increase; }
            set { mValue_Increase = value; }
        }
        private decimal mValue_Orig;
        public decimal Value_Orig
        {
            get { return mValue_Orig; }
            set { mValue_Orig = value; }
        }
        private decimal mDep_Value_Previous;
        public decimal Dep_Value_Previous
        {
            get { return mDep_Value_Previous; }
            set { mDep_Value_Previous = value; }
        }
        private decimal mDep_Value_Increase;
        public decimal Dep_Value_Increase
        {
            get { return mDep_Value_Increase; }
            set { mDep_Value_Increase = value; }
        }
        private decimal mDep_Value_Orig;
        public decimal Dep_Value_Orig
        {
            get { return mDep_Value_Orig; }
            set { mDep_Value_Orig = value; }
        }
        private decimal mDep_Value_Accu;
        public decimal Dep_Value_Accu
        {
            get { return mDep_Value_Accu; }
            set { mDep_Value_Accu = value; }
        }
        private decimal mDep_Value_Current;
        public decimal Dep_Value_Current
        {
            get { return mDep_Value_Current; }
            set { mDep_Value_Current = value; }
        }
        private decimal mRemain_Value_Orig;
        public decimal Remain_Value_Orig
        {
            get { return mRemain_Value_Orig; }
            set { mRemain_Value_Orig = value; }
        }
        private decimal mRemain_Value_Current;
        public decimal Remain_Value_Current
        {
            get { return mRemain_Value_Current; }
            set { mRemain_Value_Current = value; }
        }
        private decimal mDep_Rate;
        public decimal Dep_Rate
        {
            get { return mDep_Rate; }
            set { mDep_Rate = value; }
        }
        private decimal mValue_Previous_Extra;
        public decimal Value_Previous_Extra
        {
            get { return mValue_Previous_Extra; }
            set { mValue_Previous_Extra = value; }
        }
        private decimal mValue_Increase_Extra;
        public decimal Value_Increase_Extra
        {
            get { return mValue_Increase_Extra; }
            set { mValue_Increase_Extra = value; }
        }
        private decimal mValue_Orig_Extra;
        public decimal Value_Orig_Extra
        {
            get { return mValue_Orig_Extra; }
            set { mValue_Orig_Extra = value; }
        }
        private decimal mDep_Value_Previous_Extra;
        public decimal Dep_Value_Previous_Extra
        {
            get { return mDep_Value_Previous_Extra; }
            set { mDep_Value_Previous_Extra = value; }
        }
        private decimal mDep_Value_Increase_Extra;
        public decimal Dep_Value_Increase_Extra
        {
            get { return mDep_Value_Increase_Extra; }
            set { mDep_Value_Increase_Extra = value; }
        }
        private decimal mDep_Value_Orig_Extra;
        public decimal Dep_Value_Orig_Extra
        {
            get { return mDep_Value_Orig_Extra; }
            set { mDep_Value_Orig_Extra = value; }
        }
        private decimal mDep_Value_Accu_Extra;
        public decimal Dep_Value_Accu_Extra
        {
            get { return mDep_Value_Accu_Extra; }
            set { mDep_Value_Accu_Extra = value; }
        }
        private decimal mDep_Value_Current_Extra;
        public decimal Dep_Value_Current_Extra
        {
            get { return mDep_Value_Current_Extra; }
            set { mDep_Value_Current_Extra = value; }
        }
        private decimal mRemain_Value_Orig_Extra;
        public decimal Remain_Value_Orig_Extra
        {
            get { return mRemain_Value_Orig_Extra; }
            set { mRemain_Value_Orig_Extra = value; }
        }
        private decimal mRemain_Value_Current_Extra;
        public decimal Remain_Value_Current_Extra
        {
            get { return mRemain_Value_Current_Extra; }
            set { mRemain_Value_Current_Extra = value; }
        }
        private decimal mDep_Rate_Extra;
        public decimal Dep_Rate_Extra
        {
            get { return mDep_Rate_Extra; }
            set { mDep_Rate_Extra = value; }
        }
        private Int16 mLocked;
        public Int16 Locked
        {
            get { return mLocked; }
            set { mLocked = value; }
        }

    }
}