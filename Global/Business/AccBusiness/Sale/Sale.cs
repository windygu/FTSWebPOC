
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Sale : IHead
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
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mReference_No;
        public string Reference_No
        {
            get { return mReference_No; }
            set { mReference_No = value; }
        }
        private string mSbo_Tran_Id;
        public string Sbo_Tran_Id
        {
            get { return mSbo_Tran_Id; }
            set { mSbo_Tran_Id = value; }
        }
        private string mSbo_Tran_No;
        public string Sbo_Tran_No
        {
            get { return mSbo_Tran_No; }
            set { mSbo_Tran_No = value; }
        }
        private string mSo_Tran_Id;
        public string So_Tran_Id
        {
            get { return mSo_Tran_Id; }
            set { mSo_Tran_Id = value; }
        }
        private string mSo_Tran_No;
        public string So_Tran_No
        {
            get { return mSo_Tran_No; }
            set { mSo_Tran_No = value; }
        }
        private string mSii_Tran_Id;
        public string Sii_Tran_Id
        {
            get { return mSii_Tran_Id; }
            set { mSii_Tran_Id = value; }
        }
        private string mSii_Tran_No;
        public string Sii_Tran_No
        {
            get { return mSii_Tran_No; }
            set { mSii_Tran_No = value; }
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
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mWarehouse_Id_Receive;
        public string Warehouse_Id_Receive
        {
            get { return mWarehouse_Id_Receive; }
            set { mWarehouse_Id_Receive = value; }
        }
        private string mAccount_Id_Pr;
        public string Account_Id_Pr
        {
            get { return mAccount_Id_Pr; }
            set { mAccount_Id_Pr = value; }
        }
        private string mAccount_Id_Vat;
        public string Account_Id_Vat
        {
            get { return mAccount_Id_Vat; }
            set { mAccount_Id_Vat = value; }
        }
        private string mAccount_Id_Export_Tax;
        public string Account_Id_Export_Tax
        {
            get { return mAccount_Id_Export_Tax; }
            set { mAccount_Id_Export_Tax = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mMarket_Id;
        public string Market_Id
        {
            get { return mMarket_Id; }
            set { mMarket_Id = value; }
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
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mRec_Pr_Detail_Id;
        public string Rec_Pr_Detail_Id
        {
            get { return mRec_Pr_Detail_Id; }
            set { mRec_Pr_Detail_Id = value; }
        }
        private string mPr_Detail_Name;
        public string Pr_Detail_Name
        {
            get { return mPr_Detail_Name; }
            set { mPr_Detail_Name = value; }
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
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get { return mTax_File_Number; }
            set { mTax_File_Number = value; }
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
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mStatus;
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mImplemented_Employee_Id;
        public string Implemented_Employee_Id
        {
            get { return mImplemented_Employee_Id; }
            set { mImplemented_Employee_Id = value; }
        }
        private DateTime mSale_Date;
        public DateTime Sale_Date
        {
            get { return mSale_Date; }
            set { mSale_Date = value; }
        }
        private DateTime mImplemented_Date;
        public DateTime Implemented_Date
        {
            get { return mImplemented_Date; }
            set { mImplemented_Date = value; }
        }
        private string mCa_Job_Id;
        public string Ca_Job_Id
        {
            get { return mCa_Job_Id; }
            set { mCa_Job_Id = value; }
        }
        private decimal mCa_Job_Qty;
        public decimal Ca_Job_Qty
        {
            get { return mCa_Job_Qty; }
            set { mCa_Job_Qty = value; }
        }
        private decimal mPr_Key_Pos;
        public decimal Pr_Key_Pos
        {
            get { return mPr_Key_Pos; }
            set { mPr_Key_Pos = value; }
        }
        private decimal mDeposit_Amount;
        public decimal Deposit_Amount
        {
            get { return mDeposit_Amount; }
            set { mDeposit_Amount = value; }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get { return mItem_Source_Id; }
            set { mItem_Source_Id = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mTax_Office_Id;
        public string Tax_Office_Id
        {
            get { return mTax_Office_Id; }
            set { mTax_Office_Id = value; }
        }
        private string mShipping_Method_Id;
        public string Shipping_Method_Id
        {
            get { return mShipping_Method_Id; }
            set { mShipping_Method_Id = value; }
        }
        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private string mOrig_Tran_Id;
        public string Orig_Tran_Id
        {
            get { return mOrig_Tran_Id; }
            set { mOrig_Tran_Id = value; }
        }
        private string mOrig_Tran_No;
        public string Orig_Tran_No
        {
            get { return mOrig_Tran_No; }
            set { mOrig_Tran_No = value; }
        }
        private string mDriver_Name;
        public string Driver_Name
        {
            get { return mDriver_Name; }
            set { mDriver_Name = value; }
        }
        private string mOrig_Vat_Tran_No;
        public string Orig_Vat_Tran_No
        {
            get { return mOrig_Vat_Tran_No; }
            set { mOrig_Vat_Tran_No = value; }
        }
        private DateTime mOrig_Vat_Tran_Date;
        public DateTime Orig_Vat_Tran_Date
        {
            get { return mOrig_Vat_Tran_Date; }
            set { mOrig_Vat_Tran_Date = value; }
        }
        private Guid mShipping_Address_Pr_Key;
        public Guid Shipping_Address_Pr_Key {
            get { return mShipping_Address_Pr_Key; }
            set { mShipping_Address_Pr_Key = value; }
        }

        //Tan sua PJICO
        private decimal mFixed_Exchange_Rate;
        public decimal Fixed_Exchange_Rate
        {
            get { return mFixed_Exchange_Rate; }
            set { mFixed_Exchange_Rate = value; }
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
        private string mAccount_Id_Income;
        public string Account_Id_Income
        {
            get { return mAccount_Id_Income; }
            set { mAccount_Id_Income = value; }
        }
    }
}