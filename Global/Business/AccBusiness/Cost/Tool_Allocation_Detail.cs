
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Cost
{
    [Serializable]
    public class Tool_Allocation_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Tool_Allocation_Detail()
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
        private DateTime mDay_Start;
        public DateTime Day_Start
        {
            get { return mDay_Start; }
            set { mDay_Start = value; }
        }
        private DateTime mDay_End;
        public DateTime Day_End
        {
            get { return mDay_End; }
            set { mDay_End = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }

    }
}