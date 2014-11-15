
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Budget : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Budget()
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private DateTime mDay_Start;
        public DateTime Day_Start
        {
            get { return mDay_Start; }
            set { mDay_Start = value; }
        }
        private DateTime mDay_End;
        public DateTime Day_End
        {
            get { return mDay_End; }
            set { mDay_End = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mBudget_Type_Id;
        public string Budget_Type_Id
        {
            get { return mBudget_Type_Id; }
            set { mBudget_Type_Id = value; }
        }
        private string mBudget_Id;
        public string Budget_Id
        {
            get { return mBudget_Id; }
            set { mBudget_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private decimal mQuantity_Transfer;
        public decimal Quantity_Transfer
        {
            get { return mQuantity_Transfer; }
            set { mQuantity_Transfer = value; }
        }
        private decimal mAmount_Transfer;
        public decimal Amount_Transfer
        {
            get { return mAmount_Transfer; }
            set { mAmount_Transfer = value; }
        }
        private decimal mAmount_Extra_Transfer;
        public decimal Amount_Extra_Transfer
        {
            get { return mAmount_Extra_Transfer; }
            set { mAmount_Extra_Transfer = value; }
        }
        private decimal mQuantity_Adjust;
        public decimal Quantity_Adjust
        {
            get { return mQuantity_Adjust; }
            set { mQuantity_Adjust = value; }
        }
        private decimal mAmount_Adjust;
        public decimal Amount_Adjust
        {
            get { return mAmount_Adjust; }
            set { mAmount_Adjust = value; }
        }
        private decimal mAmount_Extra_Adjust;
        public decimal Amount_Extra_Adjust
        {
            get { return mAmount_Extra_Adjust; }
            set { mAmount_Extra_Adjust = value; }
        }
        private Int16 mIs_Organization_Write;
        public Int16 Is_Organization_Write
        {
            get { return mIs_Organization_Write; }
            set { mIs_Organization_Write = value; }
        }
    }
}