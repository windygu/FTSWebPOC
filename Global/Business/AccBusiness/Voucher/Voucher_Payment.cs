using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Voucher
{
    public class Voucher_Payment:IHead
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
        private Int16 mIs_Payment;
        public Int16 Is_Payment
        {
            get { return mIs_Payment; }
            set { mIs_Payment = value; }
        }
        private string mPolicy_No;
        public string Policy_No
        {
            get { return mPolicy_No; }
            set { mPolicy_No = value; }
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
        private string mPolicy_Debt_Currency_Id;
        public string Policy_Debt_Currency_Id
        {
            get { return mPolicy_Debt_Currency_Id; }
            set { mPolicy_Debt_Currency_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private decimal mPayment_Exchange_Rate;
        public decimal Payment_Exchange_Rate
        {
            get { return mPayment_Exchange_Rate; }
            set { mPayment_Exchange_Rate = value; }
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
        private decimal mPolicy_Debt_Amount_Orig;
        public decimal Policy_Debt_Amount_Orig
        {
            get { return mPolicy_Debt_Amount_Orig; }
            set { mPolicy_Debt_Amount_Orig = value; }
        }
        private decimal mPolicy_Debt_Goods_Amount_Orig;
        public decimal Policy_Debt_Goods_Amount_Orig
        {
            get { return mPolicy_Debt_Goods_Amount_Orig; }
            set { mPolicy_Debt_Goods_Amount_Orig = value; }
        }
        private decimal mPolicy_Debt_Vat_Tax_Amount_Orig;
        public decimal Policy_Debt_Vat_Tax_Amount_Orig
        {
            get { return mPolicy_Debt_Vat_Tax_Amount_Orig; }
            set { mPolicy_Debt_Vat_Tax_Amount_Orig = value; }
        }
        private string mVat_Tran_No;
        public string Vat_Tran_No
        {
            get { return mVat_Tran_No; }
            set { mVat_Tran_No = value; }
        }
        private DateTime mVat_Tran_Date;
        public DateTime Vat_Tran_Date
        {
            get { return mVat_Tran_Date; }
            set { mVat_Tran_Date = value; }
        }
        private string mVat_Tran_Serie;
        public string Vat_Tran_Serie
        {
            get { return mVat_Tran_Serie; }
            set { mVat_Tran_Serie = value; }
        }
        private decimal mVat_Tran_Amount;
        public decimal Vat_Tran_Amount
        {
            get { return mVat_Tran_Amount; }
            set { mVat_Tran_Amount = value; }
        }
        private decimal mVat_Tran_Amount_Orig;
        public decimal Vat_Tran_Amount_Orig
        {
            get { return mVat_Tran_Amount_Orig; }
            set { mVat_Tran_Amount_Orig = value; }
        }
        private decimal mVat_Tran_Goods_Amount;
        public decimal Vat_Tran_Goods_Amount
        {
            get { return mVat_Tran_Goods_Amount; }
            set { mVat_Tran_Goods_Amount = value; }
        }
        private decimal mVat_Tran_Goods_Amount_Orig;
        public decimal Vat_Tran_Goods_Amount_Orig
        {
            get { return mVat_Tran_Goods_Amount_Orig; }
            set { mVat_Tran_Goods_Amount_Orig = value; }
        }
        private decimal mVat_Tran_Vat_Tax_Amount;
        public decimal Vat_Tran_Vat_Tax_Amount
        {
            get { return mVat_Tran_Vat_Tax_Amount; }
            set { mVat_Tran_Vat_Tax_Amount = value; }
        }
        private decimal mVat_Tran_Vat_Tax_Amount_Orig;
        public decimal Vat_Tran_Vat_Tax_Amount_Orig
        {
            get { return mVat_Tran_Vat_Tax_Amount_Orig; }
            set { mVat_Tran_Vat_Tax_Amount_Orig = value; }
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
        private string mSerie_No;
        public string Serie_No
        {
            get { return mSerie_No; }
            set { mSerie_No = value; }
        }
        private DateTime mPolicy_Date;
        public DateTime Policy_Date
        {
            get { return mPolicy_Date; }
            set { mPolicy_Date = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private decimal mPolicy_Debt_Fixed_Exchange_Rate;
        public decimal Policy_Debt_Fixed_Exchange_Rate
        {
            get { return mPolicy_Debt_Fixed_Exchange_Rate; }
            set { mPolicy_Debt_Fixed_Exchange_Rate = value; }
        }
        private decimal mPolicy_Debt_Exchange_Rate;
        public decimal Policy_Debt_Exchange_Rate
        {
            get { return mPolicy_Debt_Exchange_Rate; }
            set { mPolicy_Debt_Exchange_Rate = value; }
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

        private string mDebit_Credit;
        public string Debit_Credit
        {
            get { return mDebit_Credit; }
            set { mDebit_Credit = value; }
        }

        private decimal mPolicy_Debt_Commission_Rate;
        public decimal Policy_Debt_Commission_Rate
        {
            get { return mPolicy_Debt_Commission_Rate; }
            set { mPolicy_Debt_Commission_Rate = value; }
        }
    }
}
