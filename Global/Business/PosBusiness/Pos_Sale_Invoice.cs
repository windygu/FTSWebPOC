﻿
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    [Serializable]
    public class Pos_Sale_Invoice : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Pos_Sale_Invoice()
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
        private Guid mPr_Key_Issue;
        public Guid Pr_Key_Issue {
            get { return mPr_Key_Issue; }
            set { mPr_Key_Issue = value; }
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
        private string mTran_Id;
        public string Tran_Id {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private string mTran_No;
        public string Tran_No {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
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
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private decimal mVat_Tax_Rate;
        public decimal Vat_Tax_Rate
        {
            get { return mVat_Tax_Rate; }
            set { mVat_Tax_Rate = value; }
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
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
        }
        private decimal mDiscount_Amount;
        public decimal Discount_Amount
        {
            get { return mDiscount_Amount; }
            set { mDiscount_Amount = value; }
        }
        private decimal mDiscount_Amount_Orig;
        public decimal Discount_Amount_Orig
        {
            get { return mDiscount_Amount_Orig; }
            set { mDiscount_Amount_Orig = value; }
        }
    }
}