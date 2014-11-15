using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Ledger : IHead
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
        private Guid mPr_Key_Detail;
        public Guid Pr_Key_Detail
        {
            get { return mPr_Key_Detail; }
            set { mPr_Key_Detail = value; }
        }
        private Guid mPr_Key_Ledger;
        public Guid Pr_Key_Ledger {
            get { return mPr_Key_Ledger; }
            set { mPr_Key_Ledger = value; }
        }
        private Guid mPos_Shift_Pr_Key;
        public Guid Pos_Shift_Pr_Key {
            get { return mPos_Shift_Pr_Key; }
            set { mPos_Shift_Pr_Key = value; }
        }
        private string mDebit_Credit;
        public string Debit_Credit
        {
            get { return mDebit_Credit; }
            set { mDebit_Credit = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
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
        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }
        private DateTime mContract_Date;
        public DateTime Contract_Date
        {
            get { return mContract_Date; }
            set { mContract_Date = value; }
        }
        private string mVat_Tran_No;
        public string Vat_Tran_No
        {
            get { return mVat_Tran_No; }
            set { mVat_Tran_No = value; }
        }
        private string mVat_Tran_Serie;
        public string Vat_Tran_Serie
        {
            get { return mVat_Tran_Serie; }
            set { mVat_Tran_Serie = value; }
        }
        private DateTime mVat_Tran_Date;
        public DateTime Vat_Tran_Date
        {
            get { return mVat_Tran_Date; }
            set { mVat_Tran_Date = value; }
        }
        private string mPayment_Method_Id;
        public string Payment_Method_Id
        {
            get { return mPayment_Method_Id; }
            set { mPayment_Method_Id = value; }
        }
        private string mPayment_Term_Id;
        public string Payment_Term_Id
        {
            get { return mPayment_Term_Id; }
            set { mPayment_Term_Id = value; }
        }
        private DateTime mPayment_Date;
        public DateTime Payment_Date
        {
            get { return mPayment_Date; }
            set { mPayment_Date = value; }
        }
        private string mContact_Person;
        public string Contact_Person
        {
            get { return mContact_Person; }
            set { mContact_Person = value; }
        }
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
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
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mAccount_Id_Contra;
        public string Account_Id_Contra
        {
            get { return mAccount_Id_Contra; }
            set { mAccount_Id_Contra = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
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
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
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
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private Int16 mIs_Booked;
        public Int16 Is_Booked
        {
            get { return mIs_Booked; }
            set { mIs_Booked = value; }
        }
        private Int16 mIs_Product_Cost;
        public Int16 Is_Product_Cost
        {
            get { return mIs_Product_Cost; }
            set { mIs_Product_Cost = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
        private string mRegister_No;
        public string Register_No
        {
            get { return mRegister_No; }
            set { mRegister_No = value; }
        }
        private DateTime mRegister_Date;
        public DateTime Register_Date
        {
            get { return mRegister_Date; }
            set { mRegister_Date = value; }
        }
        private DateTime mReceive_Date;
        public DateTime Receive_Date
        {
            get { return mReceive_Date; }
            set { mReceive_Date = value; }
        }
        private string mBank_Id;
        public string Bank_Id
        {
            get { return mBank_Id; }
            set { mBank_Id = value; }
        }

        //Tan sua PJICO
        private string mPolicy_No;
        public string Policy_No
        {
            get { return mPolicy_No; }
            set { mPolicy_No = value; }
        }
        private DateTime mPolicy_Date;
        public DateTime Policy_Date
        {
            get { return mPolicy_Date; }
            set { mPolicy_Date = value; }
        }
        private string mDealer_Id;

        public string Dealer_Id
        {
            get { return mDealer_Id; }
            set { mDealer_Id = value; }
        }
        private string mDepartment_Id;
        public string Department_Id
        {
            get { return mDepartment_Id; }
            set { mDepartment_Id = value; }
        }
        private string mInsurance_Source_Id;

        public string Insurance_Source_Id
        {
            get { return mInsurance_Source_Id; }
            set { mInsurance_Source_Id = value; }
        }
        private decimal mFixed_Exchange_Rate;
        public decimal Fixed_Exchange_Rate
        {
            get { return mFixed_Exchange_Rate; }
            set { mFixed_Exchange_Rate = value; }
        }
        private string mPrints_Id;

        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mPrints_Serie;
        public string Prints_Serie
        {
            get { return mPrints_Serie; }
            set { mPrints_Serie = value; }
        }
        private string mPrints_No;

        public string Prints_No
        {
            get { return mPrints_No; }
            set { mPrints_No = value; }
        }
        private decimal mGoods_Amount;
        public decimal Goods_Amount
        {
            get { return mGoods_Amount; }
            set { mGoods_Amount = value; }
        }
        private decimal mGoods_Amount_Orig;
        public decimal Goods_Amount_Orig
        {
            get { return mGoods_Amount_Orig; }
            set { mGoods_Amount_Orig = value; }
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
        private string mPolicy_Debt_Currency_Id;

        public string Policy_Debt_Currency_Id
        {
            get { return mPolicy_Debt_Currency_Id; }
            set { mPolicy_Debt_Currency_Id = value; }
        }

        private decimal mPolicy_Debt_Exchange_Rate;
        public decimal Policy_Debt_Exchange_Rate
        {
            get { return mPolicy_Debt_Exchange_Rate; }
            set { mPolicy_Debt_Exchange_Rate = value; }
        }
        private decimal mPolicy_Debt_Fixed_Exchange_Rate;
        public decimal Policy_Debt_Fixed_Exchange_Rate
        {
            get { return mPolicy_Debt_Fixed_Exchange_Rate; }
            set { mPolicy_Debt_Fixed_Exchange_Rate = value; }
        }
        private decimal mPolicy_Debt_Goods_Amount_Orig;
        public decimal Policy_Debt_Goods_Amount_Orig
        {
            get { return mPolicy_Debt_Goods_Amount_Orig; }
            set { mPolicy_Debt_Goods_Amount_Orig = value; }
        }
        private decimal mPolicy_Debt_Vat_Amount_Orig;
        public decimal Policy_Debt_Vat_Amount_Orig
        {
            get { return mPolicy_Debt_Vat_Amount_Orig; }
            set { mPolicy_Debt_Vat_Amount_Orig = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mPolicy_Debt_Tran_Id;
        public string Policy_Debt_Tran_Id
        {
            get { return mPolicy_Debt_Tran_Id; }
            set { mPolicy_Debt_Tran_Id = value; }
        }
        private string mPolicy_Debt_Organization_Id;
        public string Policy_Debt_Organization_Id
        {
            get { return mPolicy_Debt_Organization_Id; }
            set { mPolicy_Debt_Organization_Id = value; }
        }
        private decimal mPolicy_Debt_Amount_Orig;
        public decimal Policy_Debt_Amount_Orig
        {
            get { return mPolicy_Debt_Amount_Orig; }
            set { mPolicy_Debt_Amount_Orig = value; }
        }
        private decimal mPolicy_Debt_Commission_Rate;
        public decimal Policy_Debt_Commission_Rate
        {
            get { return mPolicy_Debt_Commission_Rate; }
            set { mPolicy_Debt_Commission_Rate = value; }
        }
        private decimal mVat_Income_Amount;
        public decimal Vat_Income_Amount
        {
            get { return mVat_Income_Amount; }
            set { mVat_Income_Amount = value; }
        }
        private string mPolicy_Debt_Vat_Tax_Id;
        public string Policy_Debt_Vat_Tax_Id
        {
            get { return mPolicy_Debt_Vat_Tax_Id; }
            set { mPolicy_Debt_Vat_Tax_Id = value; }
        }
        private string mDebt_Tran_No;
        public string Debt_Tran_No
        {
            get { return mDebt_Tran_No; }
            set { mDebt_Tran_No = value; }
        }
        private DateTime mDebt_Tran_Date;
        public DateTime Debt_Tran_Date
        {
            get { return mDebt_Tran_Date; }
            set { mDebt_Tran_Date = value; }
        }
        private DateTime mDebt_Payment_Date;
        public DateTime Debt_Payment_Date
        {
            get { return mDebt_Payment_Date; }
            set { mDebt_Payment_Date = value; }
        }
        private string mClaim_No;
        public string Claim_No
        {
            get { return mClaim_No; }
            set { mClaim_No = value; }
        }

        //
        private string mTax_Office_Id;
        public string Tax_Office_Id
        {
            get { return mTax_Office_Id; }
            set { mTax_Office_Id = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
    }
}