using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Folio_Payment : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;      
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
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
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return this.mTran_Date; }
            set { this.mTran_Date = value; }
        }
        private Int32 mTran_Hour;
        public Int32 Tran_Hour
        {
            get { return this.mTran_Hour; }
            set { this.mTran_Hour = value; }
        }
        private Int32 mTran_Minute;
        public Int32 Tran_Minute
        {
            get { return this.mTran_Minute; }
            set { this.mTran_Minute = value; }
        }
        private string mPayment_Method_Id;
        public string Payment_Method_Id
        {
            get { return mPayment_Method_Id; }
            set { mPayment_Method_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Int16 mSplit_No_Id;
        public Int16 Split_No_Id
        {
            get { return mSplit_No_Id; }
            set { mSplit_No_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return this.mUser_Id; }
            set { this.mUser_Id = value; }
        }
        private Guid mHt_Shift_Pr_Key;
        public Guid Ht_Shift_Pr_Key
        {
            get { return mHt_Shift_Pr_Key; }
            set { mHt_Shift_Pr_Key = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
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