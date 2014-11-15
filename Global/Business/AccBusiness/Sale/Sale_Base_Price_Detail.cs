using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Sale_Base_Price_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Sale_Base_Price_Detail()
        {
        }
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
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mPrice_Level_Id;
        public string Price_Level_Id
        {
            get { return mPrice_Level_Id; }
            set { mPrice_Level_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mUnit_Id;
        public string Unit_Id {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mUnit_Price_Orig;
        public decimal Unit_Price_Orig
        {
            get { return mUnit_Price_Orig; }
            set { mUnit_Price_Orig = value; }
        }
        private Int16 mDetail_Active;
        public Int16 Detail_Active {
            get { return mDetail_Active; }
            set { mDetail_Active = value; }
        }
    }
}
