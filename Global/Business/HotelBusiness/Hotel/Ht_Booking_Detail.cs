using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Booking_Detail : IHead
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
        private decimal mCommission;
        public decimal Commission
        {
            get { return mCommission; }
            set { mCommission = value; }
        }
        private decimal mDiscount;
        public decimal Discount
        {
            get { return mDiscount; }
            set { mDiscount = value; }
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
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private string mRoom_Class_Id;
        public string Room_Class_Id
        {
            get { return mRoom_Class_Id; }
            set { mRoom_Class_Id = value; }
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