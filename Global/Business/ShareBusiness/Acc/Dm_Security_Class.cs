using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Security_Class:IHead
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

        private string mSecurity_Class_Id;
        public string Security_Class_Id
        {
            get { return mSecurity_Class_Id; }
            set { mSecurity_Class_Id = value; }
        }

        private string mSecurity_Class_Name;
        public string Security_Class_Name
        {
            get { return mSecurity_Class_Name; }
            set { mSecurity_Class_Name = value; }
        }

        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }

        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
    }
}
