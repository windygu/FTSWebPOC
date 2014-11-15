using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Pr_reason : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mReason_Id;
        public string Reason_Id
        {
            get { return mReason_Id; }
            set { mReason_Id = value; }
        }
        private string mReason_Name;
        public string Reason_Name
        {
            get { return mReason_Name; }
            set { mReason_Name = value; }
        }
//
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