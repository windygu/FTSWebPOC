
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Prints_Receipt_Detail : IHead
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
        private string mPrints_Id;
        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mBatch_No;
        public string Batch_No
        {
            get { return mBatch_No; }
            set { mBatch_No = value; }
        }
        private int mSeri_Start;
        public int Seri_Start
        {
            get { return mSeri_Start; }
            set { mSeri_Start = value; }
        }
        private int mSeri_End;
        public int Seri_End
        {
            get { return mSeri_End; }
            set { mSeri_End = value; }
        }
        private int mSeri_Quantity;
        public int Seri_Quantity
        {
            get { return mSeri_Quantity; }
            set { mSeri_Quantity = value; }
        }
        private string mPrints_Serie;
        public string Prints_Serie {
            get { return this.mPrints_Serie; }
            set { this.mPrints_Serie = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return this.mQuantity; }
            set { this.mQuantity = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return this.mUnit_Id; }
            set { this.mUnit_Id = value; }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return this.mUnit_Price; }
            set { this.mUnit_Price = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return this.mAmount; }
            set { this.mAmount = value; }
        }

        private string mAccount_Id_Cost;
        public string Account_Id_Cost
        {
            get { return this.mAccount_Id_Cost; }
            set { this.mAccount_Id_Cost = value; }
        }

        private string mAccount_Id_Contra;
        public string Account_Id_Contra
        {
            get { return this.mAccount_Id_Contra; }
            set { this.mAccount_Id_Contra = value; }
        }

        private string mJob_Id;
        public string Job_Id
        {
            get { return this.mJob_Id; }
            set { this.mJob_Id = value; }
        }

        private string mExpense_Id;
        public string Expense_Id
        {
            get { return this.mExpense_Id; }
            set { this.mExpense_Id = value; }
        }

        private int mBatch_Quantity;
        public int Batch_Quantity
        {
            get { return mBatch_Quantity; }
            set { mBatch_Quantity = value; }
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
