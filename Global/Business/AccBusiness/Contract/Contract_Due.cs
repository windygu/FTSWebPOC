
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Contract
{
    [Serializable]
    public class Contract_Due : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Contract_Due()
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
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private DateTime mDue_Date;
        public DateTime Due_Date
        {
            get { return mDue_Date; }
            set { mDue_Date = value; }
        }


    }
}