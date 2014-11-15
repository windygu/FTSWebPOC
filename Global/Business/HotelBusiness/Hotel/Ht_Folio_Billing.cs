using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Folio_Billing : IHead
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
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
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
        private Int16 mIs_Group_Payment;
        public Int16 Is_Group_Payment
        {
            get { return mIs_Group_Payment; }
            set { mIs_Group_Payment = value; }
        }
        private Int16 mIs_Payment;
        public Int16 Is_Payment
        {
            get { return mIs_Payment; }
            set { mIs_Payment = value; }
        }
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private DateTime mNight_Audit_Date;
        public DateTime Night_Audit_Date
        {
            get { return mNight_Audit_Date; }
            set { mNight_Audit_Date = value; }
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
        private string mReference_No;
        public string Reference_No
        {
            get { return mReference_No; }
            set { mReference_No = value; }
        }
        private string mService_Id;
        public string Service_Id
        {
            get { return mService_Id; }
            set { mService_Id = value; }
        }
        private Int16 mSplit_No_Id;
        public Int16 Split_No_Id
        {
            get { return mSplit_No_Id; }
            set { mSplit_No_Id = value; }
        }
        private string mSplit_No_Name;
        public string Split_No_Name
        {
            get { return mSplit_No_Name; }
            set { mSplit_No_Name = value; }
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
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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
        private Guid mPr_Key_Item;
        public Guid Pr_Key_Item
        {
            get { return mPr_Key_Item; }
            set { mPr_Key_Item = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Name;
        public string Item_Name
        {
            get { return mItem_Name; }
            set { mItem_Name = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
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
        private DateTime mPayment_Date;
        public DateTime Payment_Date
        {
            get { return this.mPayment_Date; }
            set { this.mPayment_Date = value; }
        }
        private Int32 mPayment_Hour;
        public Int32 Payment_Hour
        {
            get { return this.mPayment_Hour; }
            set { this.mPayment_Hour = value; }
        }
        private Int32 mPayment_Minute;
        public Int32 Payment_Minute
        {
            get { return this.mPayment_Minute; }
            set { this.mPayment_Minute = value; }
        }
        private Int16 mIs_Fix;
        public Int16 Is_Fix
        {
            get { return this.mIs_Fix; }
            set { this.mIs_Fix = value; }
        }
        private Guid mHt_Shift_Pr_Key_Post;
        public Guid Ht_Shift_Pr_Key_Post
        {
            get { return mHt_Shift_Pr_Key_Post; }
            set { mHt_Shift_Pr_Key_Post = value; }
        }
        private Guid mHt_Shift_Pr_Key_Payment;
        public Guid Ht_Shift_Pr_Key_Payment
        {
            get { return mHt_Shift_Pr_Key_Payment; }
            set { mHt_Shift_Pr_Key_Payment = value; }
        }
        private Int16 mIs_Vat;
        public Int16 Is_Vat
        {
            get { return this.mIs_Vat; }
            set { this.mIs_Vat = value; }
        }
        private Int16 mIs_Posted;
        public Int16 Is_Posted
        {
            get { return this.mIs_Posted; }
            set { this.mIs_Posted = value; }
        }
        private decimal mCommission_Rate;
        public decimal Commission_Rate
        {
            get { return mCommission_Rate; }
            set { mCommission_Rate = value; }
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
        private Guid mFr_Key_Orig;
        public Guid Fr_Key_Orig
        {
            get { return mFr_Key_Orig; }
            set { mFr_Key_Orig = value; }
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