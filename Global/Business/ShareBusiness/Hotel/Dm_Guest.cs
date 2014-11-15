using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Guest : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mCountry_Id;
        public string Country_Id
        {
            get { return mCountry_Id; }
            set { mCountry_Id = value; }
        }
        private DateTime mDob;
        public DateTime Dob
        {
            get { return mDob; }
            set { mDob = value; }
        }
        private string mEmail;
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        private string mFax;
        public string Fax
        {
            get { return mFax; }
            set { mFax = value; }
        }
        private string mGender;
        public string Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }
        private string mGuest_Address;
        public string Guest_Address
        {
            get { return mGuest_Address; }
            set { mGuest_Address = value; }
        }
        private string mGuest_Class_Id;
        public string Guest_Class_Id
        {
            get { return mGuest_Class_Id; }
            set { mGuest_Class_Id = value; }
        }
        private string mGuest_First_Name;
        public string Guest_First_Name
        {
            get { return mGuest_First_Name; }
            set { mGuest_First_Name = value; }
        }
        private string mGuest_Id;
        public string Guest_Id
        {
            get { return mGuest_Id; }
            set { mGuest_Id = value; }
        }
        private string mGuest_Last_Name;
        public string Guest_Last_Name
        {
            get { return mGuest_Last_Name; }
            set { mGuest_Last_Name = value; }
        }
        private string mGuest_Title;
        public string Guest_Title
        {
            get { return mGuest_Title; }
            set { mGuest_Title = value; }
        }
        private DateTime mIdentity_Date;
        public DateTime Identity_Date
        {
            get { return mIdentity_Date; }
            set { mIdentity_Date = value; }
        }
        private string mIdentity_No;
        public string Identity_No
        {
            get { return mIdentity_No; }
            set { mIdentity_No = value; }
        }
        private string mIdentity_Type;
        public string Identity_Type
        {
            get { return mIdentity_Type; }
            set { mIdentity_Type = value; }
        }
        private Int16 mIs_Primary;
        public Int16 Is_Primary
        {
            get { return mIs_Primary; }
            set { mIs_Primary = value; }
        }
        private string mNationality_Id;
        public string Nationality_Id
        {
            get { return mNationality_Id; }
            set { mNationality_Id = value; }
        }
        private string mPhone;
        public string Phone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }
        private string mReligion_Id;
        public string Religion_Id
        {
            get { return mReligion_Id; }
            set { mReligion_Id = value; }
        }
        private DateTime mVisa_Date;
        public DateTime Visa_Date
        {
            get { return mVisa_Date; }
            set { mVisa_Date = value; }
        }
        private DateTime mVisa_Expire_Date;
        public DateTime Visa_Expire_Date
        {
            get { return mVisa_Expire_Date; }
            set { mVisa_Expire_Date = value; }
        }
        private string mVisa_No;
        public string Visa_No
        {
            get { return mVisa_No; }
            set { mVisa_No = value; }
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