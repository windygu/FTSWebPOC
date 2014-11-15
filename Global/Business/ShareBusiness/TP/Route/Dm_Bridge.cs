
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP.Route
{
    public class Dm_Bridge : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mBridge_Id;
        public string Bridge_Id
        {
            get { return mBridge_Id; }
            set { mBridge_Id = value; }
        }
        private string mBridge_Name;
        public string Bridge_Name
        {
            get { return mBridge_Name; }
            set { mBridge_Name = value; }
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
