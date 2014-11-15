using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Interest_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mDescription_Uls;
        public string Description_Uls
        {
            get { return mDescription_Uls; }
            set { mDescription_Uls = value; }
        }
        private DateTime mDebt_Date;
        public DateTime Debt_Date
        {
            get { return mDebt_Date; }
            set { mDebt_Date = value; }
        }
        private decimal mDebt_Amount_Orig;
        public decimal Debt_Amount_Orig
        {
            get { return mDebt_Amount_Orig; }
            set { mDebt_Amount_Orig = value; }
        }
        private DateTime mExpiry_Date;
        public DateTime Expiry_Date
        {
            get { return mExpiry_Date; }
            set { mExpiry_Date = value; }
        }
        private decimal mUnpaid_Amount_Orig;
        public decimal Unpaid_Amount_Orig
        {
            get { return mUnpaid_Amount_Orig; }
            set { mUnpaid_Amount_Orig = value; }
        }
        private DateTime mInterest_Date;
        public DateTime Interest_Date
        {
            get { return mInterest_Date; }
            set { mInterest_Date = value; }
        }
        private int mNum_Days;
        public int Num_Days
        {
            get { return mNum_Days; }
            set { mNum_Days = value; }
        }
        private decimal mInterest_Rate;
        public decimal Interest_Rate
        {
            get { return mInterest_Rate; }
            set { mInterest_Rate = value; }
        }
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private string mTran_No_Orig;
        public string Tran_No_Orig
        {
            get { return mTran_No_Orig; }
            set { mTran_No_Orig = value; }
        }
        private string mVat_Tran_No_Orig;
        public string Vat_Tran_No_Orig
        {
            get { return mVat_Tran_No_Orig; }
            set { mVat_Tran_No_Orig = value; }
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
