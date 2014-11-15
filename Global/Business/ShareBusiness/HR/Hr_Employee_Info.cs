using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Hr_Employee_Info : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mEmployee_Id;

        public string Employee_Id
        {
            get
            {
                return mEmployee_Id;
            }
            set
            {
                mEmployee_Id = value;
            }
        }
        private string mFirst_Name;

        public string First_Name
        {
            get
            {
                return mFirst_Name;
            }
            set
            {
                mFirst_Name = value;
            }
        }
        private string mLast_Name;

        public string Last_Name
        {
            get
            {
                return mLast_Name;
            }
            set
            {
                mLast_Name = value;
            }
        }
        private string mEmployee_Name;

        public string Employee_Name
        {
            get
            {
                return mEmployee_Name;
            }
            set
            {
                mEmployee_Name = value;
            }
        }
        private string mSex;

        public string Sex
        {
            get
            {
                return mSex;
            }
            set
            {
                mSex = value;
            }
        }
        private DateTime mDob;

        public DateTime Dob
        {
            get
            {
                return mDob;
            }
            set
            {
                mDob = value;
            }
        }
        private string mBirth_Place;

        public string Birth_Place
        {
            get
            {
                return mBirth_Place;
            }
            set
            {
                mBirth_Place = value;
            }
        }
        private string mOrigin_Place;
        public string Origin_Place
        {
            get
            {
                return mOrigin_Place;
            }
            set
            {
                mOrigin_Place = value;
            }
        }
        private string mOrigin_City;

        public string Origin_City
        {
            get
            {
                return mOrigin_City;
            }
            set
            {
                mOrigin_City = value;
            }
        }
        private string mIdentity_No;

        public string Identity_No
        {
            get
            {
                return mIdentity_No;
            }
            set
            {
                mIdentity_No = value;
            }
        }
        private DateTime mIdentity_Issue_Date;

        public DateTime Identity_Issue_Date
        {
            get
            {
                return mIdentity_Issue_Date;
            }
            set
            {
                mIdentity_Issue_Date = value;
            }
        }
        private string mIdentity_Issue_Place;

        public string Identity_Issue_Place
        {
            get
            {
                return mIdentity_Issue_Place;
            }
            set
            {
                mIdentity_Issue_Place = value;
            }
        }
        private string mPassport_No;

        public string Passport_No
        {
            get
            {
                return mPassport_No;
            }
            set
            {
                mPassport_No = value;
            }
        }
        private DateTime mPassport_Issue_Date;

        public DateTime Passport_Issue_Date
        {
            get
            {
                return mPassport_Issue_Date;
            }
            set
            {
                mPassport_Issue_Date = value;
            }
        }
        private string mPassport_Issue_Place;

        public string Passport_Issue_Place
        {
            get
            {
                return mPassport_Issue_Place;
            }
            set
            {
                mPassport_Issue_Place = value;
            }
        }
        private DateTime mPassport_Expire_Date;

        public DateTime Passport_Expire_Date
        {
            get
            {
                return mPassport_Expire_Date;
            }
            set
            {
                mPassport_Expire_Date = value;
            }
        }
        private string mSocial_Book_No;

        public string Social_Book_No
        {
            get
            {
                return mSocial_Book_No;
            }
            set
            {
                mSocial_Book_No = value;
            }
        }
        private DateTime mSocial_Book_Issue_Date;

        public DateTime Social_Book_Issue_Date
        {
            get
            {
                return mSocial_Book_Issue_Date;
            }
            set
            {
                mSocial_Book_Issue_Date = value;
            }
        }
        private string mSocial_Book_Issue_Place;

        public string Social_Book_Issue_Place
        {
            get
            {
                return mSocial_Book_Issue_Place;
            }
            set
            {
                mSocial_Book_Issue_Place = value;
            }
        }
        private string mBank_Account_No;

        public string Bank_Account_No
        {
            get
            {
                return mBank_Account_No;
            }
            set
            {
                mBank_Account_No = value;
            }
        }
        private string mBank_Name;

        public string Bank_Name
        {
            get
            {
                return mBank_Name;
            }
            set
            {
                mBank_Name = value;
            }
        }
        private string mBank_Branch;

        public string Bank_Branch
        {
            get
            {
                return mBank_Branch;
            }
            set
            {
                mBank_Branch = value;
            }
        }
        private string mMarital_Status_Id;

        public string Marital_Status_Id
        {
            get
            {
                return mMarital_Status_Id;
            }
            set
            {
                mMarital_Status_Id = value;
            }
        }
        private string mFamily_Origin_Id;

        public string Family_Origin_Id
        {
            get
            {
                return mFamily_Origin_Id;
            }
            set
            {
                mFamily_Origin_Id = value;
            }
        }
        private string mEmployee_Origin_Id;

        public string Employee_Origin_Id
        {
            get
            {
                return mEmployee_Origin_Id;
            }
            set
            {
                mEmployee_Origin_Id = value;
            }
        }
        private string mEthnics_Id;

        public string Ethnics_Id
        {
            get
            {
                return mEthnics_Id;
            }
            set
            {
                mEthnics_Id = value;
            }
        }
        private string mReligion_Id;

        public string Religion_Id
        {
            get
            {
                return mReligion_Id;
            }
            set
            {
                mReligion_Id = value;
            }
        }
        private string mNationality_Id;

        public string Nationality_Id
        {
            get
            {
                return mNationality_Id;
            }
            set
            {
                mNationality_Id = value;
            }
        }
        private string mHome_Phone;

        public string Home_Phone
        {
            get
            {
                return mHome_Phone;
            }
            set
            {
                mHome_Phone = value;
            }
        }
        private string mWork_Phone;

        public string Work_Phone
        {
            get
            {
                return mWork_Phone;
            }
            set
            {
                mWork_Phone = value;
            }
        }
        private string mMobile_Phone;

        public string Mobile_Phone
        {
            get
            {
                return mMobile_Phone;
            }
            set
            {
                mMobile_Phone = value;
            }
        }
        private string mPersonal_Email;

        public string Personal_Email
        {
            get
            {
                return mPersonal_Email;
            }
            set
            {
                mPersonal_Email = value;
            }
        }
        private string mWork_Email;

        public string Work_Email
        {
            get
            {
                return mWork_Email;
            }
            set
            {
                mWork_Email = value;
            }
        }
        private string mYahoo_Id;

        public string Yahoo_Id
        {
            get
            {
                return mYahoo_Id;
            }
            set
            {
                mYahoo_Id = value;
            }
        }
        private string mSkype_Id;

        public string Skype_Id
        {
            get
            {
                return mSkype_Id;
            }
            set
            {
                mSkype_Id = value;
            }
        }
        private Int16 mIs_Cal_Salary;

        public Int16 Is_Cal_Salary
        {
            get
            {
                return mIs_Cal_Salary;
            }
            set
            {
                mIs_Cal_Salary = value;
            }
        }
        private string mPersonal_Taxcode;

        public string Personal_Taxcode
        {
            get
            {
                return mPersonal_Taxcode;
            }
            set
            {
                mPersonal_Taxcode = value;
            }
        }
        private DateTime mPersonal_Taxcode_Date;

        public DateTime Personal_Taxcode_Date
        {
            get
            {
                return mPersonal_Taxcode_Date;
            }
            set
            {
                mPersonal_Taxcode_Date = value;
            }
        }
        private string mPersonal_Taxcode_Place;

        public string Personal_Taxcode_Place
        {
            get
            {
                return mPersonal_Taxcode_Place;
            }
            set
            {
                mPersonal_Taxcode_Place = value;
            }
        }
        private DateTime mWork_Date_Start;

        public DateTime Work_Date_Start
        {
            get
            {
                return mWork_Date_Start;
            }
            set
            {
                mWork_Date_Start = value;
            }
        }
        private DateTime mDate_Company;

        public DateTime Date_Company
        {
            get
            {
                return mDate_Company;
            }
            set
            {
                mDate_Company = value;
            }
        }
        private DateTime mDate_Group_Company;

        public DateTime Date_Group_Company
        {
            get
            {
                return mDate_Group_Company;
            }
            set
            {
                mDate_Group_Company = value;
            }
        }
        
        private DateTime mJoint_Date_Social;

        public DateTime Joint_Date_Social {
            get {
                return mJoint_Date_Social;
            }
            set {
                mJoint_Date_Social = value;
            }
        }

        private Int16 mIs_Join_Social;

        public Int16 Is_Join_Social {
            get {
                return mIs_Join_Social;
            }
            set {
                mIs_Join_Social = value;
            }
        }

        private Int16 mIs_Social_Book;

        public Int16 Is_Social_Book {
            get {
                return mIs_Social_Book;
            }
            set {
                mIs_Social_Book = value;
            }
        }

        private string mSocial_Book_Note;

        public string Social_Book_Note {
            get {
                return mSocial_Book_Note;
            }
            set {
                mSocial_Book_Note = value;
            }
        }

        private string mEmployee_Name_Other;
        public string Employee_Name_Other {
            get {
                return mEmployee_Name_Other;
            }
            set {
                mEmployee_Name_Other = value;
            }
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