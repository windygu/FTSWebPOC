using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Logging : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private decimal mPr_Key;
        public decimal Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mAction_Type;
        public string Action_Type
        {
            get { return mAction_Type; }
            set { mAction_Type = value; }
        }
        private DateTime mAction_Datetime;
        public DateTime Action_Datetime
        {
            get { return mAction_Datetime; }
            set { mAction_Datetime = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
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