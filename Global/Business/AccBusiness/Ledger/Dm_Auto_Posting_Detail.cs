using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    public class Dm_Auto_Posting_Detail:IHead
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

        private Int16 mList_Order;

        public Int16 List_Order
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
        private string mAmount_Id_Debit;

        public string Amount_Id_Debit
        {
            get { return mAmount_Id_Debit; }
            set { mAmount_Id_Debit = value; }
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
        private string mPosting_Formula_Orig;

        public string Posting_Formula_Orig
        {
            get { return mPosting_Formula_Orig; }
            set { mPosting_Formula_Orig = value; }
        }
        private string mPosting_Formula_Goods_Amount_Orig;

        public string Posting_Formula_Goods_Amount_Orig
        {
            get { return mPosting_Formula_Goods_Amount_Orig; }
            set { mPosting_Formula_Goods_Amount_Orig = value; }
        }
        private string mPosting_Formula_Goods_Amount;

        public string Posting_Formula_Goods_Amount
        {
            get { return mPosting_Formula_Goods_Amount; }
            set { mPosting_Formula_Goods_Amount = value; }
        }
        private string mPosting_Formula_Vat_Tax_Amount_Orig;

        public string Posting_Formula_Vat_Tax_Amount_Orig
        {
            get { return mPosting_Formula_Vat_Tax_Amount_Orig; }
            set { mPosting_Formula_Vat_Tax_Amount_Orig = value; }
        }
        private string mPosting_Formula_Vat_Tax_Amount;

        public string Posting_Formula_Vat_Tax_Amount
        {
            get { return mPosting_Formula_Vat_Tax_Amount; }
            set { mPosting_Formula_Vat_Tax_Amount = value; }
        }
        private string mPosting_Formula_Vat_Incom_Amount;

        public string Posting_Formula_Vat_Incom_Amount
        {
            get { return mPosting_Formula_Vat_Incom_Amount; }
            set { mPosting_Formula_Vat_Incom_Amount = value; }
        }
        private string mPosting_Formula_Policy_Amount_Orig;

        public string Posting_Formula_Policy_Amount_Orig
        {
            get { return mPosting_Formula_Policy_Amount_Orig; }
            set { mPosting_Formula_Policy_Amount_Orig = value; }
        }
        private string mPosting_Formula_Policy_Goods_Amount_Orig;

        public string Posting_Formula_Policy_Goods_Amount_Orig
        {
            get { return mPosting_Formula_Policy_Goods_Amount_Orig; }
            set { mPosting_Formula_Policy_Goods_Amount_Orig = value; }
        }
        private string mPosting_Formula_Policy_Vat_Tax_Amount_Orig;

        public string Posting_Formula_Policy_Vat_Tax_Amount_Orig
        {
            get { return mPosting_Formula_Policy_Vat_Tax_Amount_Orig; }
            set { mPosting_Formula_Policy_Vat_Tax_Amount_Orig = value; }
        }
        private Int16 mIs_Vat;

        public Int16 Is_Vat
        {
            get { return mIs_Vat; }
            set { mIs_Vat = value; }
        }
        private Int16 mIs_Commission;

        public Int16 Is_Commission
        {
            get { return mIs_Commission; }
            set { mIs_Commission = value; }
        }
        private Int16 mIs_Original_Currency;

        public Int16 Is_Original_Currency
        {
            get { return mIs_Original_Currency; }
            set { mIs_Original_Currency = value; }
        }
    }
}
