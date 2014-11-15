using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sec_User_Group : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mUser_Group_Id;
        public string User_Group_Id
        {
            get { return mUser_Group_Id; }
            set { mUser_Group_Id = value; }
        }
        private string mUser_Group_Name;
        public string User_Group_Name
        {
            get { return mUser_Group_Name; }
            set { mUser_Group_Name = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mModule_List;
        public string Module_List
        {
            get { return mModule_List; }
            set { mModule_List = value; }
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