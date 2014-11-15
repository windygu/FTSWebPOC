using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Sale_Cog : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public DataState DataState
        {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }
        public object IdValue
        {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }
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
        private DateTime mReceive_Date;
        public DateTime Receive_Date
        {
            get { return mReceive_Date; }
            set { mReceive_Date = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mCog_Unit_Price;
        public decimal Cog_Unit_Price
        {
            get { return mCog_Unit_Price; }
            set { mCog_Unit_Price = value; }
        }
        private decimal mCog_Unit_Price_Orig;
        public decimal Cog_Unit_Price_Orig
        {
            get { return mCog_Unit_Price_Orig; }
            set { mCog_Unit_Price_Orig = value; }
        }
        private decimal mCog_Amount;
        public decimal Cog_Amount
        {
            get { return mCog_Amount; }
            set { mCog_Amount = value; }
        }
        private decimal mCog_Amount_Orig;
        public decimal Cog_Amount_Orig
        {
            get { return mCog_Amount_Orig; }
            set { mCog_Amount_Orig = value; }
        }
        private decimal mCog_Amount_Extra;
        public decimal Cog_Amount_Extra
        {
            get { return mCog_Amount_Extra; }
            set { mCog_Amount_Extra = value; }
        }

    }
}
