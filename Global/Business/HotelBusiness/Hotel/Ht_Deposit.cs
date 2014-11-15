using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Deposit : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mDeposit_Amount;
        public decimal Deposit_Amount
        {
            get { return mDeposit_Amount; }
            set { mDeposit_Amount = value; }
        }
        private decimal mDeposit_Amount_Orig;
        public decimal Deposit_Amount_Orig
        {
            get { return mDeposit_Amount_Orig; }
            set { mDeposit_Amount_Orig = value; }
        }
        private DateTime mDeposit_Date;
        public DateTime Deposit_Date
        {
            get { return mDeposit_Date; }
            set { mDeposit_Date = value; }
        }
        private string mDeposit_Type;
        public string Deposit_Type
        {
            get { return mDeposit_Type; }
            set { mDeposit_Type = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
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
        private Guid mPr_Key_Link;
        public Guid Pr_Key_Link
        {
            get { return mPr_Key_Link; }
            set { mPr_Key_Link = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
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
            get { return mUser_Id;}
            set { mUser_Id = value;}
        }
        private Guid mHt_Shift_Pr_Key;
        public Guid Ht_Shift_Pr_Key
        {
            get { return mHt_Shift_Pr_Key; }
            set { mHt_Shift_Pr_Key = value; }
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