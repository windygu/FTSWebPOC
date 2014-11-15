
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Transaction_Register : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Transaction_Register()
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
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
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
        private string mTran_Id_List;
        public string Tran_Id_List
        {
            get { return mTran_Id_List; }
            set { mTran_Id_List = value; }
        }
        private string mAccount_Id_Debit_List;
        public string Account_Id_Debit_List
        {
            get { return mAccount_Id_Debit_List; }
            set { mAccount_Id_Debit_List = value; }
        }
        private string mAccount_Id_Credit_List;
        public string Account_Id_Credit_List
        {
            get { return mAccount_Id_Credit_List; }
            set { mAccount_Id_Credit_List = value; }
        }
        private string mCurrency_Id_List;
        public string Currency_Id_List
        {
            get { return mCurrency_Id_List; }
            set { mCurrency_Id_List = value; }
        }
        private string mRegister_Method;
        public string Register_Method
        {
            get { return mRegister_Method; }
            set { mRegister_Method = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
    }
}