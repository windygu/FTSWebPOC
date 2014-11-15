using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Booking : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private DateTime mArrive_Date;
        public DateTime Arrive_Date
        {
            get { return mArrive_Date; }
            set { mArrive_Date = value; }
        }
        private string mBooking_Type;
        public string Booking_Type
        {
            get { return mBooking_Type; }
            set { mBooking_Type = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private decimal mCommission_Rate;
        public decimal Commission_Rate
        {
            get { return mCommission_Rate; }
            set { mCommission_Rate = value; }
        }
        private string mCommission_Type;
        public string Commission_Type
        {
            get { return mCommission_Type; }
            set { mCommission_Type = value; }
        }
        private string mCountry_Id;
        public string Country_Id
        {
            get { return mCountry_Id; }
            set { mCountry_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private DateTime mDepart_Date;
        public DateTime Depart_Date
        {
            get { return mDepart_Date; }
            set { mDepart_Date = value; }
        }
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
        }
        private string mDiscount_Type;
        public string Discount_Type
        {
            get { return mDiscount_Type; }
            set { mDiscount_Type = value; }
        }
        private string mEmail;
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
        private string mFax;
        public string Fax
        {
            get { return mFax; }
            set { mFax = value; }
        }
        private string mFirst_Name;
        public string First_Name
        {
            get { return mFirst_Name; }
            set { mFirst_Name = value; }
        }
        private string mLast_Name;
        public string Last_Name
        {
            get { return mLast_Name; }
            set { mLast_Name = value; }
        }
        private string mMarket_Id;
        public string Market_Id
        {
            get { return mMarket_Id; }
            set { mMarket_Id = value; }
        }
        private string mPhone;
        public string Phone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mRate_Type_Id;
        public string Rate_Type_Id
        {
            get { return mRate_Type_Id; }
            set { mRate_Type_Id = value; }
        }
        private DateTime mRelease_Date;
        public DateTime Release_Date
        {
            get { return mRelease_Date; }
            set { mRelease_Date = value; }
        }
        private int mRelease_Days;
        public int Release_Days
        {
            get { return mRelease_Days; }
            set { mRelease_Days = value; }
        }
        private string mSeason_Id;
        public string Season_Id
        {
            get { return mSeason_Id; }
            set { mSeason_Id = value; }
        }
        private decimal mService_Rate;
        public decimal Service_Rate
        {
            get { return mService_Rate; }
            set { mService_Rate = value; }
        }
        private string mStatus;
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private decimal mVat_Tax_Rate;
        public decimal Vat_Tax_Rate
        {
            get { return mVat_Tax_Rate; }
            set { mVat_Tax_Rate = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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