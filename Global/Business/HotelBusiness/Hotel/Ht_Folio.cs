using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Folio : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
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
        private DateTime mArrive_Date;
        public DateTime Arrive_Date
        {
            get { return mArrive_Date; }
            set { mArrive_Date = value; }
        }
        private int mArrive_Hour;
        public int Arrive_Hour
        {
            get { return mArrive_Hour; }
            set { mArrive_Hour = value; }
        }
        private int mArrive_Minute;
        public int Arrive_Minute
        {
            get { return mArrive_Minute; }
            set { mArrive_Minute = value; }
        }
        private DateTime mMove_Date;
        public DateTime Move_Date
        {
            get { return mMove_Date; }
            set { mMove_Date = value; }
        }
        private int mMove_Hour;
        public int Move_Hour
        {
            get { return mMove_Hour; }
            set { mMove_Hour = value; }
        }
        private int mMove_Minute;
        public int Move_Minute
        {
            get { return mMove_Minute; }
            set { mMove_Minute = value; }
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
        private decimal mCommission_Amount;
        public decimal Commission_Amount
        {
            get { return mCommission_Amount; }
            set { mCommission_Amount = value; }
        }
        private decimal mCommission_Amount_Orig;
        public decimal Commission_Amount_Orig
        {
            get { return mCommission_Amount_Orig; }
            set { mCommission_Amount_Orig = value; }
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
        private int mDepart_Hour;
        public int Depart_Hour
        {
            get { return mDepart_Hour; }
            set { mDepart_Hour = value; }
        }
        private int mDepart_Minute;
        public int Depart_Minute
        {
            get { return mDepart_Minute; }
            set { mDepart_Minute = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private decimal mDiscount_Amount;
        public decimal Discount_Amount
        {
            get { return mDiscount_Amount; }
            set { mDiscount_Amount = value; }
        }
        private decimal mDiscount_Amount_Orig;
        public decimal Discount_Amount_Orig
        {
            get { return mDiscount_Amount_Orig; }
            set { mDiscount_Amount_Orig = value; }
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
        private Int16 mHourly;
        public Int16 Hourly
        {
            get { return mHourly; }
            set { mHourly = value; }
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
        private decimal mNum_Days;
        public decimal Num_Days
        {
            get { return mNum_Days; }
            set { mNum_Days = value; }
        }
        private decimal mPax;
        public decimal Pax
        {
            get { return mPax; }
            set { mPax = value; }
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
        private Guid mPr_Key_Booking_Detail;
        public Guid Pr_Key_Booking_Detail
        {
            get { return mPr_Key_Booking_Detail; }
            set { mPr_Key_Booking_Detail = value; }
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
        private string mRoom_Class_Id;
        public string Room_Class_Id
        {
            get { return mRoom_Class_Id; }
            set { mRoom_Class_Id = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }
        private string mSeason_Id;
        public string Season_Id
        {
            get { return mSeason_Id; }
            set { mSeason_Id = value; }
        }
        private decimal mService_Amount;
        public decimal Service_Amount
        {
            get { return mService_Amount; }
            set { mService_Amount = value; }
        }
        private decimal mService_Amount_Orig;
        public decimal Service_Amount_Orig
        {
            get { return mService_Amount_Orig; }
            set { mService_Amount_Orig = value; }
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
        private decimal mTotal_Amount;
        public decimal Total_Amount
        {
            get { return mTotal_Amount; }
            set { mTotal_Amount = value; }
        }
        private decimal mTotal_Amount_Orig;
        public decimal Total_Amount_Orig
        {
            get { return mTotal_Amount_Orig; }
            set { mTotal_Amount_Orig = value; }
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
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }
        private decimal mUnit_Price_Orig;
        public decimal Unit_Price_Orig
        {
            get { return mUnit_Price_Orig; }
            set { mUnit_Price_Orig = value; }
        }
        private decimal mVat_Tax_Amount;
        public decimal Vat_Tax_Amount
        {
            get { return mVat_Tax_Amount; }
            set { mVat_Tax_Amount = value; }
        }
        private decimal mVat_Tax_Amount_Orig;
        public decimal Vat_Tax_Amount_Orig
        {
            get { return mVat_Tax_Amount_Orig; }
            set { mVat_Tax_Amount_Orig = value; }
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
        private Guid mHt_Shift_Pr_Key_Check_In;
        public Guid Ht_Shift_Pr_Key_Check_In
        {
            get { return mHt_Shift_Pr_Key_Check_In; }
            set { mHt_Shift_Pr_Key_Check_In = value; }
        }
        private Guid mHt_Shift_Pr_Key_Check_Out;
        public Guid Ht_Shift_Pr_Key_Check_Out
        {
            get { return mHt_Shift_Pr_Key_Check_Out; }
            set { mHt_Shift_Pr_Key_Check_Out = value; }
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