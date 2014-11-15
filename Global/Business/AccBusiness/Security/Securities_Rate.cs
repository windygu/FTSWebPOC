using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Security
{
    public class Securities_Rate : IHead
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

        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }

        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }

        private DateTime mStart_Date;
        public DateTime Start_Date
        {
            get { return mStart_Date; }
            set { mStart_Date = value; }
        }

        private DateTime mEnd_Date;
        public DateTime End_Date
        {
            get { return mEnd_Date; }
            set { mEnd_Date = value; }
        }

        private decimal mInterest_Rate;
        public decimal Interest_Rate
        {
            get { return mInterest_Rate; }
            set { mInterest_Rate = value; }
        }

        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
    }
}
