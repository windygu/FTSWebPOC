
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP
{
    public class Dm_Bridge_Route : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mBridge_Id;
        public string Bridge_Id
        {
            get { return mBridge_Id; }
            set { mBridge_Id = value; }
        }
        private string mRoute_Id;
        public string Route_Id
        {
            get { return mRoute_Id; }
            set { mRoute_Id = value; }
        }
        private Int16 mIs_Return;
        public Int16 Is_Return
        {
            get { return mIs_Return; }
            set { mIs_Return = value; }
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
