using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Bank : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mBank_Id;
        public string Bank_Id
        {
            get { return mBank_Id; }
            set { mBank_Id = value; }
        }
        private string mBank_Name;
        public string Bank_Name
        {
            get { return mBank_Name; }
            set { mBank_Name = value; }
        }
        private string mBank_Branch;
        public string Bank_Branch
        {
            get { return mBank_Branch; }
            set { mBank_Branch = value; }
        }
        private string mBank_Account;
        public string Bank_Account
        {
            get { return mBank_Account; }
            set { mBank_Account = value; }
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