using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Pr_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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
        private string mPr_Detail_Name_En;
        public string Pr_Detail_Name_En
        {
            get { return mPr_Detail_Name_En; }
            set { mPr_Detail_Name_En = value; }
        }
        private string mRec_Pr_Detail_Id;
        public string Rec_Pr_Detail_Id
        {
            get { return mRec_Pr_Detail_Id; }
            set { mRec_Pr_Detail_Id = value; }
        }
        private string mRef_Pr_Detail_Id;
        public string Ref_Pr_Detail_Id {
            get { return mRef_Pr_Detail_Id; }
            set { mRef_Pr_Detail_Id = value; }
        }
        private string mPr_Detail_Type_Id;
        public string Pr_Detail_Type_Id
        {
            get { return mPr_Detail_Type_Id; }
            set { mPr_Detail_Type_Id = value; }
        }
        private string mPr_Detail_Class_Id;
        public string Pr_Detail_Class_Id
        {
            get { return mPr_Detail_Class_Id; }
            set { mPr_Detail_Class_Id = value; }
        }
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private string mContact_Person;
        public string Contact_Person
        {
            get { return mContact_Person; }
            set { mContact_Person = value; }
        }
        private string mPhone;
        public string Phone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }
        private string mFax;
        public string Fax
        {
            get { return mFax; }
            set { mFax = value; }
        }
        private string mEmail;
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get { return mTax_File_Number; }
            set { mTax_File_Number = value; }
        }
        private string mBank_Name;
        public string Bank_Name
        {
            get { return mBank_Name; }
            set { mBank_Name = value; }
        }
        private string mBank_Account;
        public string Bank_Account
        {
            get { return mBank_Account; }
            set { mBank_Account = value; }
        }
        private string mBank_Branch;
        public string Bank_Branch
        {
            get { return mBank_Branch; }
            set { mBank_Branch = value; }
        }
        private string mPr_Account_Id;
        public string Pr_Account_Id
        {
            get { return mPr_Account_Id; }
            set { mPr_Account_Id = value; }
        }
        private string mPrice_Level_Id;
        public string Price_Level_Id
        {
            get { return mPrice_Level_Id; }
            set { mPrice_Level_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mPr_Account_Id1;
        public string Pr_Account_Id1
        {
            get { return mPr_Account_Id1; }
            set { mPr_Account_Id1 = value; }
        }
        private string mProvince_Id;
        public string Province_Id
        {
            get { return mProvince_Id; }
            set { mProvince_Id = value; }
        }

        private string mIndustry_Id;
        public string Industry_Id {
            get { return mIndustry_Id; }
            set { mIndustry_Id = value; }
        }
        private string mAddress_No;
        public string Address_No {
            get { return mAddress_No; }
            set { mAddress_No = value; }
        }
        private string mAddress_Lot;
        public string Address_Lot {
            get { return mAddress_Lot; }
            set { mAddress_Lot = value; }
        }
        private string mStreet_Name;
        public string Street_Name {
            get { return mStreet_Name; }
            set { mStreet_Name = value; }
        }
        private string mIndustrial_Zone;
        public string Industrial_Zone {
            get { return mIndustrial_Zone; }
            set { mIndustrial_Zone = value; }
        }
        private string mCommune;
        public string Commune {
            get { return mCommune; }
            set { mCommune = value; }
        }
        private string mDistrict_Id;
        public string District_Id {
            get { return mDistrict_Id; }
            set { mDistrict_Id = value; }
        }
        private string mRegion_Id;
        public string Region_Id {
            get { return mRegion_Id; }
            set { mRegion_Id = value; }
        }
        private Int16 mIs_None_Vat;
        public Int16 Is_None_Vat {
            get { return mIs_None_Vat; }
            set { mIs_None_Vat = value; }
        }
        private Int16 mIs_Public;
        public Int16 Is_Public {
            get { return mIs_Public; }
            set { mIs_Public = value; }
        }
        #region IHead Members

        public DataState DataState
        {
            get
            {
                return this.mDataState;
            }
            set
            {
                this.mDataState = value;
            }
        }

        public object IdValue
        {
            get
            {
                return this.mIdValue;
            }
            set
            {
                this.mIdValue = value;
            }
        }

        #endregion
    }
}