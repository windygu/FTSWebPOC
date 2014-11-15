using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    [Serializable]
    public class Membership_Log : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = 0;
        Guid mPr_Key;
        string mMembership_Log_Type = string.Empty;
        string mMembership_Id = string.Empty;
        DateTime mMembership_Log_Date = DateTime.Today;
        decimal mAmount = 0;
        decimal mPoint = 0;
        string mUser_Id = string.Empty;        
        Int16 mSms_Sent = 0;
        Int16 mEmail_Sent = 0;
        string mOrganization_Id;

        public Membership_Log()
        { }
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
        public Guid Pr_Key
        {
            get { return this.mPr_Key; }
            set { this.mPr_Key = value; }
        }
        public string Membership_Log_Type
        {
            get { return this.mMembership_Log_Type; }
            set { this.mMembership_Log_Type = value; }
        }
        public string Membership_Id
        {
            get { return this.mMembership_Id; }
            set { this.mMembership_Id = value; }
        }
        public DateTime Membership_Log_Date
        {
            get { return this.mMembership_Log_Date; }
            set { this.mMembership_Log_Date = value; }
        }
        public decimal Amount
        {
            get { return this.mAmount; }
            set { this.mAmount = value; }
        }
        public decimal Point
        {
            get { return this.mPoint; }
            set { this.mPoint = value; }
        }
        public string User_Id
        {
            get { return this.mUser_Id; }
            set { this.mUser_Id = value; }
        }        
        public Int16 Sms_Sent
        {
            get { return this.mSms_Sent; }
            set { this.mSms_Sent = value; }
        }
        public Int16 Email_Sent
        {
            get { return this.mEmail_Sent; }
            set { this.mEmail_Sent = value; }
        }        
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }        
    }
}
