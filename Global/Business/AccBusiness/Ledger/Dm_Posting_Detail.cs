using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Dm_Posting_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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
        private string mAccount_Id_Debit;
        public string Account_Id_Debit
        {
            get { return mAccount_Id_Debit; }
            set { mAccount_Id_Debit = value; }
        }
        private string mAccount_Id_Credit;
        public string Account_Id_Credit
        {
            get { return mAccount_Id_Credit; }
            set { mAccount_Id_Credit = value; }
        }
        private string mPosting_Formula;
        public string Posting_Formula
        {
            get { return mPosting_Formula; }
            set { mPosting_Formula = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private Int16 mIs_Vat;
        public Int16 Is_Vat
        {
            get { return mIs_Vat; }
            set { mIs_Vat = value; }
        }
        private Int16 mIs_Warehouse;
        public Int16 Is_Warehouse {
            get { return mIs_Warehouse; }
            set { mIs_Warehouse = value; }
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