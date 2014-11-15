using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Voucher
{
    [Serializable]
    public class Voucher_Detail : IHead
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
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mDescription_Uls;
        public string Description_Uls
        {
            get { return mDescription_Uls; }
            set { mDescription_Uls = value; }
        }
        private string mAccount_Id_Credit;
        public string Account_Id_Credit
        {
            get { return mAccount_Id_Credit; }
            set { mAccount_Id_Credit = value; }
        }
        private string mAccount_Id_Debit;
        public string Account_Id_Debit
        {
            get { return mAccount_Id_Debit; }
            set { mAccount_Id_Debit = value; }
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
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
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
        private string mPr_Detail_Id_Credit;
        public string Pr_Detail_Id_Credit
        {
            get { return mPr_Detail_Id_Credit; }
            set { mPr_Detail_Id_Credit = value; }
        }
        private string mPr_Detail_Id_Debit;
        public string Pr_Detail_Id_Debit
        {
            get { return mPr_Detail_Id_Debit; }
            set { mPr_Detail_Id_Debit = value; }
        }
        private string mExpense_Id_Credit;
        public string Expense_Id_Credit
        {
            get { return mExpense_Id_Credit; }
            set { mExpense_Id_Credit = value; }
        }
        private string mExpense_Id_Debit;
        public string Expense_Id_Debit
        {
            get { return mExpense_Id_Debit; }
            set { mExpense_Id_Debit = value; }
        }
        private string mJob_Id_Credit;
        public string Job_Id_Credit
        {
            get { return mJob_Id_Credit; }
            set { mJob_Id_Credit = value; }
        }
        private string mJob_Id_Debit;
        public string Job_Id_Debit
        {
            get { return mJob_Id_Debit; }
            set { mJob_Id_Debit = value; }
        }
        private string mItem_Id_Credit;
        public string Item_Id_Credit
        {
            get { return mItem_Id_Credit; }
            set { mItem_Id_Credit = value; }
        }
        private string mItem_Id_Debit;
        public string Item_Id_Debit
        {
            get { return mItem_Id_Debit; }
            set { mItem_Id_Debit = value; }
        }
        private string mReference_No;
        public string Reference_No
        {
            get { return mReference_No; }
            set { mReference_No = value; }
        }
        private decimal mReference_Amount;
        public decimal Reference_Amount
        {
            get { return mReference_Amount; }
            set { mReference_Amount = value; }
        }
        private decimal mExchange_Rate_Cost;
        public decimal Exchange_Rate_Cost
        {
            get { return mExchange_Rate_Cost; }
            set { mExchange_Rate_Cost = value; }
        }
        private decimal mAmount_Cost;
        public decimal Amount_Cost
        {
            get { return mAmount_Cost; }
            set { mAmount_Cost = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
        private decimal mExchange_Rate_Extra;
        public decimal Exchange_Rate_Extra
        {
            get { return mExchange_Rate_Extra; }
            set { mExchange_Rate_Extra = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mBudget;
        public decimal Budget
        {
            get { return mBudget; }
            set { mBudget = value; }
        }
        private decimal mBudget_Extra;
        public decimal Budget_Extra
        {
            get { return mBudget_Extra; }
            set { mBudget_Extra = value; }
        }
        private int mNum_Days;
        public int Num_Days
        {
            get { return mNum_Days; }
            set { mNum_Days = value; }
        }
        private decimal mInterest_Rate;
        public decimal Interest_Rate
        {
            get { return mInterest_Rate; }
            set { mInterest_Rate = value; }
        }
        private decimal mInterest_Amount_Orig;
        public decimal Interest_Amount_Orig
        {
            get { return mInterest_Amount_Orig; }
            set { mInterest_Amount_Orig = value; }
        }
        private decimal mInterest_Amount;
        public decimal Interest_Amount
        {
            get { return mInterest_Amount; }
            set { mInterest_Amount = value; }
        }
        private decimal mTotal_Amount_Orig;
        public decimal Total_Amount_Orig
        {
            get { return mTotal_Amount_Orig; }
            set { mTotal_Amount_Orig = value; }
        }
        private decimal mTotal_Amount;
        public decimal Total_Amount
        {
            get { return mTotal_Amount; }
            set { mTotal_Amount = value; }
        }
        private string mInterest_Account_Id_Debit;
        public string Interest_Account_Id_Debit
        {
            get { return mInterest_Account_Id_Debit; }
            set { mInterest_Account_Id_Debit = value; }
        }
        private string mInterest_Account_Id_Credit;
        public string Interest_Account_Id_Credit
        {
            get { return mInterest_Account_Id_Credit; }
            set { mInterest_Account_Id_Credit = value; }
        }
        private string mTax_Office_Id;
        public string Tax_Office_Id
        {
            get { return mTax_Office_Id; }
            set { mTax_Office_Id = value; }
        }

        //Tan sua PJICO
        private string mDepartment_Id_Debit;
        public string Department_Id_Debit
        {
            get { return mDepartment_Id_Debit; }
            set { mDepartment_Id_Debit = value; }
        }
        private string mDepartment_Id_Creadit;
        public string Department_Id_Creadit
        {
            get { return mDepartment_Id_Creadit; }
            set { mDepartment_Id_Creadit = value; }
        }
        private string mDealer_Id_Debit;
        public string Dealer_Id_Debit
        {
            get { return mDealer_Id_Debit; }
            set { mDealer_Id_Debit = value; }
        }
        private string mDealer_Id_Credit;
        public string Dealer_Id_Credit
        {
            get { return mDealer_Id_Credit; }
            set { mDealer_Id_Credit = value; }
        }
        private string mEmployee_Id_Debit;
        public string Employee_Id_Debit
        {
            get { return mEmployee_Id_Debit; }
            set { mEmployee_Id_Debit = value; }
        }
        private string mEmployee_Id_Credit;
        public string Employee_Id_Credit
        {
            get { return mEmployee_Id_Credit; }
            set { mEmployee_Id_Credit = value; }
        }
        private decimal mFixed_Exchange_Rate;
        public decimal Fixed_Exchange_Rate
        {
            get { return mFixed_Exchange_Rate; }
            set { mFixed_Exchange_Rate = value; }
        }
        private string mInsurance_Source_Id_Debit;
        public string Insurance_Source_Id_Debit
        {
            get { return mInsurance_Source_Id_Debit; }
            set { mInsurance_Source_Id_Debit = value; }
        }
        private string mInsurance_Source_Id_Credit;
        public string Insurance_Source_Id_Credit
        {
            get { return mInsurance_Source_Id_Credit; }
            set { mInsurance_Source_Id_Credit = value; }
        }
		private string mChapter_Id;
        public string Chapter_Id {
            get { return mChapter_Id; }
            set { mChapter_Id = value; }
        }
        private string mCapital_Source_Id;
        public string Capital_Source_Id {
            get { return mCapital_Source_Id; }
            set { mCapital_Source_Id = value; }
        }
    }
}
