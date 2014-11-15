
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Warehouse
{
    [Serializable]
    public class Adjustment : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Adjustment()
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
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private DateTime mAdjustment_Date;
        public DateTime Adjustment_Date
        {
            get { return mAdjustment_Date; }
            set { mAdjustment_Date = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private decimal mBook_Quantity;
        public decimal Book_Quantity
        {
            get { return mBook_Quantity; }
            set { mBook_Quantity = value; }
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
        private decimal mActual_Quantity;
        public decimal Actual_Quantity
        {
            get { return mActual_Quantity; }
            set { mActual_Quantity = value; }
        }
        private decimal mActual_Unit_Price;
        public decimal Actual_Unit_Price
        {
            get { return mActual_Unit_Price; }
            set { mActual_Unit_Price = value; }
        }
        private decimal mActual_Amount;
        public decimal Actual_Amount
        {
            get { return mActual_Amount; }
            set { mActual_Amount = value; }
        }
        private decimal mActual_Amount_Extra;
        public decimal Actual_Amount_Extra
        {
            get { return mActual_Amount_Extra; }
            set { mActual_Amount_Extra = value; }
        }
        private decimal mDiff_Quantity;
        public decimal Diff_Quantity
        {
            get { return mDiff_Quantity; }
            set { mDiff_Quantity = value; }
        }
        private decimal mDiff_Amount;
        public decimal Diff_Amount
        {
            get { return mDiff_Amount; }
            set { mDiff_Amount = value; }
        }
        private decimal mDiff_Amount_Extra;
        public decimal Diff_Amount_Extra
        {
            get { return mDiff_Amount_Extra; }
            set { mDiff_Amount_Extra = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get { return mItem_Source_Id; }
            set { mItem_Source_Id = value; }
        }
    }
}