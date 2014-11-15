using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Security
{
    public class Security_Receipt_Detail: IHead
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

        private Guid mPr_key;
        public Guid Pr_key
        {
            get { return mPr_key; }
            set { mPr_key = value; }
        }
        private Guid mFr_key;
        public Guid Fr_key
        {
            get { return mFr_key; }
            set { mFr_key = value; }
        }
        private Int32 mList_Order;
        public Int32 List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mSecurity_Id;
        public string Security_Id
        {
            get { return mSecurity_Id; }
            set { mSecurity_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mUnit_Price_Orig;
        public decimal Unit_Price_Orig
        {
            get { return mUnit_Price_Orig; }
            set { mUnit_Price_Orig = value; }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
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
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private decimal mFee_Rate;
        public decimal Fee_Rate
        {
            get { return mFee_Rate; }
            set { mFee_Rate = value; }
        }
        private decimal mFee_Amount;
        public decimal Fee_Amount
        {
            get { return mFee_Amount; }
            set { mFee_Amount = value; }
        }
        private decimal mFee_Amount_Orig;
        public decimal Fee_Amount_Orig
        {
            get { return mFee_Amount_Orig; }
            set { mFee_Amount_Orig = value; }
        }
        private decimal mFee_Amount_Extra;
        public decimal Fee_Amount_Extra
        {
            get { return mFee_Amount_Extra; }
            set { mFee_Amount_Extra = value; }
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
        private decimal mCommission_Amount_Extra;
        public decimal Commission_Amount_Extra
        {
            get { return mCommission_Amount_Extra; }
            set { mCommission_Amount_Extra = value; }
        }
        private decimal mCost_Unit_Price;
        public decimal Cost_Unit_Price
        {
            get { return mCost_Unit_Price; }
            set { mCost_Unit_Price = value; }
        }
        private decimal mCost_Amount;
        public decimal Cost_Amount
        {
            get { return mCost_Amount; }
            set { mCost_Amount = value; }
        }
        private decimal mCost_Amount_Extra;
        public decimal Cost_Amount_Extra
        {
            get { return mCost_Amount_Extra; }
            set { mCost_Amount_Extra = value; }
        }
        private decimal mBook_Unit_Price;
        public decimal Book_Unit_Price
        {
            get { return mBook_Unit_Price; }
            set { mBook_Unit_Price = value; }
        }
        private decimal mBook_Amount;
        public decimal Book_Amount
        {
            get { return mBook_Amount; }
            set { mBook_Amount = value; }
        }
        private decimal mBook_Amount_Extra;
        public decimal Book_Amount_Extra
        {
            get { return mBook_Amount_Extra; }
            set { mBook_Amount_Extra = value; }
        }
        private string mCost_Account_Id;
        public string Cost_Account_Id
        {
            get { return mCost_Account_Id; }
            set { mCost_Account_Id = value; }
        }
    }
}
