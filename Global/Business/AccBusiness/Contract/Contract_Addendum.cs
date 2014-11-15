using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTS.Global.Classes;
using FTS.Global.Interface;

namespace FTS.Global.Business.AccBusiness.Contract
{
    public class Contract_Addendum:IHead
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

        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }

        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }

        private string mPayment_Term_Id;
        public string Payment_Term_Id
        {
            get { return mPayment_Term_Id; }
            set { mPayment_Term_Id = value; }
        }

        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }

        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        private decimal mInterest_Rate;
        public decimal Interest_Rate
        {
            get { return mInterest_Rate; }
            set { mInterest_Rate = value; }
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
    }
}
