
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class SO : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public SO()
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
        private Int16 mIs_Over_Credit_Limit;
        public Int16 Is_Over_Credit_Limit
        {
            get { return mIs_Over_Credit_Limit; }
            set { mIs_Over_Credit_Limit = value; }
        }
        private DateTime mApprove_Date;
        public DateTime Approve_Date
        {
            get { return mApprove_Date; }
            set { mApprove_Date = value; }
        }
        private DateTime mRelease_Date;
        public DateTime Release_Date
        {
            get { return mRelease_Date; }
            set { mRelease_Date = value; }
        }
        private DateTime mDelivery_Date;
        public DateTime Delivery_Date
        {
            get { return mDelivery_Date; }
            set { mDelivery_Date = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
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
        private string mMarket_Id;
        public string Market_Id
        {
            get { return mMarket_Id; }
            set { mMarket_Id = value; }
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
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mApprover_Id;
        public string Approver_Id
        {
            get { return mApprover_Id; }
            set { mApprover_Id = value; }
        }
        private string mDriver_Name;
        public string Driver_Name
        {
            get { return mDriver_Name; }
            set { mDriver_Name = value; }
        }
        private string mDeliver_Organization_Id;
        public string Deliver_Organization_Id
        {
            get { return mDeliver_Organization_Id; }
            set { mDeliver_Organization_Id = value; }
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
        private string mSo_Class_Id;
        public string So_Class_Id
        {
            get { return mSo_Class_Id; }
            set { mSo_Class_Id = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private Int16 mIs_New_Client;
        public Int16 Is_New_Client
        {
            get { return mIs_New_Client; }
            set { mIs_New_Client = value; }
        }
        private Int16 mIs_Post_Payment;
        public Int16 Is_Post_Payment
        {
            get { return mIs_Post_Payment; }
            set { mIs_Post_Payment = value; }
        }
        private Int16 mIs_Capital_Support;
        public Int16 Is_Capital_Support
        {
            get { return mIs_Capital_Support; }
            set { mIs_Capital_Support = value; }
        }
        private Decimal mFixed_Exchange_Rate;
        public Decimal Fixed_Exchange_Rate
        {
            get { return mFixed_Exchange_Rate; }
            set { mFixed_Exchange_Rate = value; }
        }
        private Int16 mIs_Once;
        public Int16 Is_Once
        {
            get { return mIs_Once; }
            set { mIs_Once = value; }
        }
        private string mPolicy_No_Sub;
        public string Policy_No_Sub
        {
            get { return mPolicy_No_Sub; }
            set { mPolicy_No_Sub = value; }
        }
        private DateTime mPolicy_Date_Sub;
        public DateTime Policy_Date_Sub
        {
            get { return mPolicy_Date_Sub; }
            set { mPolicy_Date_Sub = value; }
        }
        private Int16 mIs_Sub;
        public Int16 Is_Sub
        {
            get { return mIs_Sub; }
            set { mIs_Sub = value; }
        }
        //
        private Int16 mIs_Once_From_Multiple;
        public Int16 Is_Once_From_Multiple
        {
            get { return mIs_Once_From_Multiple; }
            set { mIs_Once_From_Multiple = value; }
        }
        private string mAccount_Id_Credit;
        public string Account_Id_Credit
        {
            get { return mAccount_Id_Credit; }
            set { mAccount_Id_Credit = value; }
        }
    }
}