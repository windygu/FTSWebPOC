using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class  Interest : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get
            {
                return mPr_Key;
            }
            set
            {
                mPr_Key = value;
            }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get
            {
                return mTran_Id;
            }
            set
            {
                mTran_Id = value;
            }
        }
        private string mTran_No;
        public string Tran_No
        {
            get
            {
                return mTran_No;
            }
            set
            {
                mTran_No = value;
            }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get
            {
                return mTran_Date;
            }
            set
            {
                mTran_Date = value;
            }
        }
        private DateTime mDay_Start;
        public DateTime Day_Start
        {
            get
            {
                return mDay_Start;
            }
            set
            {
                mDay_Start = value;
            }
        }
        private DateTime mDay_End;
        public DateTime Day_End
        {
            get
            {
                return mDay_End;
            }
            set
            {
                mDay_End = value;
            }
        }
        private string mAccount_Id_Debit;
        public string Account_Id_Debit
        {
            get
            {
                return mAccount_Id_Debit;
            }
            set
            {
                mAccount_Id_Debit = value;
            }
        }
        private string mAccount_Id_Credit;
        public string Account_Id_Credit
        {
            get
            {
                return mAccount_Id_Credit;
            }
            set
            {
                mAccount_Id_Credit = value;
            }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get
            {
                return mAccount_Id;
            }
            set
            {
                mAccount_Id = value;
            }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get
            {
                return mPr_Detail_Id;
            }
            set
            {
                mPr_Detail_Id = value;
            }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get
            {
                return mCurrency_Id;
            }
            set
            {
                mCurrency_Id = value;
            }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get
            {
                return mExchange_Rate;
            }
            set
            {
                mExchange_Rate = value;
            }
        }
        private string mComments;
        public string Comments
        {
            get
            {
                return mComments;
            }
            set
            {
                mComments = value;
            }
        }


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

    }
}
