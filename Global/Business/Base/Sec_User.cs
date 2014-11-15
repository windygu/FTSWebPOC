using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sec_User : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mUser_Group_Id;
        public string User_Group_Id
        {
            get { return mUser_Group_Id; }
            set { mUser_Group_Id = value; }
        }
        private string mUser_Name;
        public string User_Name
        {
            get { return mUser_Name; }
            set { mUser_Name = value; }
        }
        private string mUser_Password;
        public string User_Password
        {
            get { return mUser_Password; }
            set { mUser_Password = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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