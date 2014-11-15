using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    [Serializable]
    public class Dm_Membership : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = 0;
        string mMembership_Id = string.Empty;
        string mMembership_Name = string.Empty;
        string mMembership_Class_Id = string.Empty;
        DateTime mDob;
        string mPhone = string.Empty;
        string mAddress = string.Empty;
        string mEmail = string.Empty;
        string mNote = string.Empty;
        DateTime mShelf;
        Int16 mActive = 0;
        string mUser_Id = string.Empty;        
        string mMembership_Code = string.Empty;
        string mMembership_Password = string.Empty;
        Int16 mFirstLogin = 1;        
        Int16 mSend_Sms_Dob = 0;
        Int16 mSend_Sms_Log = 0;
        int mYear_Sms_Dob = 0;
        Int16 mSend_Email_Dob = 0;
        Int16 mSend_Email_Log = 0;
        int mYear_Email_Dob = 0;

        public Dm_Membership()
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
        public string Membership_Id
        {
            get { return this.mMembership_Id; }
            set { this.mMembership_Id = value; }
        }
        public string Membership_Name
        {
            get { return this.mMembership_Name; }
            set { this.mMembership_Name = value; }
        }
        public string Membership_Class_Id
        {
            get { return this.mMembership_Class_Id; }
            set { this.mMembership_Class_Id = value; }
        }
        public DateTime Dob
        {
            get { return this.mDob; }
            set { this.mDob = value; }
        }
        public string Phone
        {
            get { return this.mPhone; }
            set { this.mPhone = value; }
        }
        public string Address
        {
            get { return this.mAddress; }
            set { this.mAddress = value; }
        }
        public string Email
        {
            get { return this.mEmail; }
            set { this.mEmail = value; }
        }
        public string Note
        {
            get { return this.mNote; }
            set { this.mNote = value; }
        }
        public DateTime Shelf
        {
            get { return this.mShelf; }
            set { this.mShelf = value; }
        }
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        public string User_Id
        {
            get { return this.mUser_Id; }
            set { this.mUser_Id = value; }
        }       
        public string Membership_Code
        {
            get { return this.mMembership_Code; }
            set { this.mMembership_Code = value; }
        }
        public string Membership_Password
        {
            get { return this.mMembership_Password; }
            set { this.mMembership_Password = value; }
        }
        public Int16 FirstLogin
        {
            get { return this.mFirstLogin; }
            set { this.mFirstLogin = value; }
        }        
        public Int16 Send_Sms_Dob
        {
            get { return this.mSend_Sms_Dob; }
            set { this.mSend_Sms_Dob = value; }
        }
        public Int16 Send_Sms_Log
        {
            get { return this.mSend_Sms_Log; }
            set { this.mSend_Sms_Log = value; }
        }
        public int Year_Sms_Dob
        {
            get { return this.mYear_Sms_Dob; }
            set { this.mYear_Sms_Dob = value; }
        }
        public Int16 Send_Email_Dob
        {
            get { return this.mSend_Email_Dob; }
            set { this.mSend_Email_Dob = value; }
        }
        public Int16 Send_Email_Log
        {
            get { return this.mSend_Email_Log; }
            set { this.mSend_Email_Log = value; }
        }
        public int Year_Email_Dob
        {
            get { return this.mYear_Email_Dob; }
            set { this.mYear_Email_Dob = value; }
        }
    }
}
