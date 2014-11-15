using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Contract_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
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

        private string mContract_Class_Id;
        public string Contract_Class_Id
        {
            get { return mContract_Class_Id; }
            set { mContract_Class_Id = value; }
        }

        private string mContract_Class_Name;
        public string Contract_Class_Name
        {
            get { return mContract_Class_Name; }
            set { mContract_Class_Name = value; }
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
    }
}
