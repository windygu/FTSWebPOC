
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.VAT
{
    [Serializable]
    public class Vat_Transaction : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Vat_Transaction()
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
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
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
        private string mVat_Purchase_Id;
        public string Vat_Purchase_Id
        {
            get { return mVat_Purchase_Id; }
            set { mVat_Purchase_Id = value; }
        }
        private Guid mPr_Key_Orig;
        public Guid Pr_Key_Orig
        {
            get { return mPr_Key_Orig; }
            set { mPr_Key_Orig = value; }
        }
        private Guid mPr_Key_Detail_Orig;
        public Guid Pr_Key_Detail_Orig
        {
            get { return mPr_Key_Detail_Orig; }
            set { mPr_Key_Detail_Orig = value; }
        }
        private string mTran_Id_Orig;
        public string Tran_Id_Orig
        {
            get { return mTran_Id_Orig; }
            set { mTran_Id_Orig = value; }
        }
        private string mTran_No_Orig;
        public string Tran_No_Orig
        {
            get { return mTran_No_Orig; }
            set { mTran_No_Orig = value; }
        }
        private DateTime mTran_Date_Orig;
        public DateTime Tran_Date_Orig
        {
            get { return mTran_Date_Orig; }
            set { mTran_Date_Orig = value; }
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
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mPr_Detail_Name;
        public string Pr_Detail_Name
        {
            get { return mPr_Detail_Name; }
            set { mPr_Detail_Name = value; }
        }
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get { return mTax_File_Number; }
            set { mTax_File_Number = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Name;
        public string Item_Name
        {
            get { return mItem_Name; }
            set { mItem_Name = value; }
        }
        private decimal mAmount_Item;
        public decimal Amount_Item
        {
            get { return mAmount_Item; }
            set { mAmount_Item = value; }
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
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mDebit_Credit;
        public string Debit_Credit
        {
            get { return mDebit_Credit; }
            set { mDebit_Credit = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mTax_Office_Id;
        public string Tax_Office_Id
        {
            get { return mTax_Office_Id; }
            set { mTax_Office_Id = value; }
        }
    }
}