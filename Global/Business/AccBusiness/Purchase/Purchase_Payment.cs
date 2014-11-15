
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Purchase
{
    [Serializable]
    public class Purchase_Payment : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Purchase_Payment()
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
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private Guid mPr_Key_Payment;
        public Guid Pr_Key_Payment
        {
            get { return mPr_Key_Payment; }
            set { mPr_Key_Payment = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
        private decimal mPayment_Amount;
        public decimal Payment_Amount
        {
            get { return mPayment_Amount; }
            set { mPayment_Amount = value; }
        }
        private decimal mPayment_Amount_Orig;
        public decimal Payment_Amount_Orig
        {
            get { return mPayment_Amount_Orig; }
            set { mPayment_Amount_Orig = value; }
        }
        private decimal mPayment_Amount_Extra;
        public decimal Payment_Amount_Extra
        {
            get { return mPayment_Amount_Extra; }
            set { mPayment_Amount_Extra = value; }
        }
        private decimal mPayment_Amount_Equivalent;
        public decimal Payment_Amount_Equivalent
        {
            get { return mPayment_Amount_Equivalent; }
            set { mPayment_Amount_Equivalent = value; }
        }
        private decimal mAdjusted_Amount;
        public decimal Adjusted_Amount
        {
            get { return mAdjusted_Amount; }
            set { mAdjusted_Amount = value; }
        }
        private decimal mAdjusted_Amount_Extra;
        public decimal Adjusted_Amount_Extra
        {
            get { return mAdjusted_Amount_Extra; }
            set { mAdjusted_Amount_Extra = value; }
        }
        private Int16 mIs_Balance;
        public Int16 Is_Balance
        {
            get { return mIs_Balance; }
            set { mIs_Balance = value; }
        }
        private string mAccount_Id_Contra;
        public string Account_Id_Contra
        {
            get { return mAccount_Id_Contra; }
            set { mAccount_Id_Contra = value; }
        }
    }
}