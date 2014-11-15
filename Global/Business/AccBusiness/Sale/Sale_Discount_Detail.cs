using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Sale_Discount_Detail : IHead
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
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mPr_Detail_Class_Id;
        public string Pr_Detail_Class_Id
        {
            get { return mPr_Detail_Class_Id; }
            set { mPr_Detail_Class_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Class_Id;
        public string Item_Class_Id
        {
            get { return mItem_Class_Id; }
            set { mItem_Class_Id = value; }
        }
        private decimal mQuantity_Start;
        public decimal Quantity_Start
        {
            get { return mQuantity_Start; }
            set { mQuantity_Start = value; }
        }
        private decimal mQuantity_End;
        public decimal Quantity_End
        {
            get { return mQuantity_End; }
            set { mQuantity_End = value; }
        }
        private string mItem_Discount_Value_Type;
        public string Item_Discount_Value_Type
        {
            get { return mItem_Discount_Value_Type; }
            set { mItem_Discount_Value_Type = value; }
        }
        private decimal mDiscount_Value;
        public decimal Discount_Value
        {
            get { return mDiscount_Value; }
            set { mDiscount_Value = value; }
        }
        private string mDiscount_Item_Id;
        public string Discount_Item_Id
        {
            get { return mDiscount_Item_Id; }
            set { mDiscount_Item_Id = value; }
        }
    }
}
