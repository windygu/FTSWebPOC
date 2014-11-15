using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    [Serializable]
    public class Dm_Membership_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = 0;
        string mMembership_Class_Id = string.Empty;
        string mMembership_Class_Name = string.Empty;
        string mMembership_Class_Parent_Id = string.Empty;
        decimal mPoint_To_Amount = 0;
        Int16 mActive = 0;
        string mUser_Id = string.Empty;        
        public Dm_Membership_Class()
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
        public string Membership_Class_Id
        {
            get { return this.mMembership_Class_Id; }
            set { this.mMembership_Class_Id = value; }
        }
        public string Membership_Class_Name
        {
            get { return this.mMembership_Class_Name; }
            set { this.mMembership_Class_Name = value; }
        }
        public string Membership_Class_Parent_Id
        {
            get { return this.mMembership_Class_Parent_Id; }
            set { this.mMembership_Class_Parent_Id = value; }
        }
        public decimal Point_To_Amount
        {
            get { return this.mPoint_To_Amount; }
            set { this.mPoint_To_Amount = value; }
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
    }
}
