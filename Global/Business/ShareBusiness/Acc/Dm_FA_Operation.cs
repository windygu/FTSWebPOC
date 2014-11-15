using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Fa_Operation : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mFa_Operation_Id;
        public string Fa_Operation_Id
        {
            get { return mFa_Operation_Id; }
            set { mFa_Operation_Id = value; }
        }
        private string mFa_Operation_Name;
        public string Fa_Operation_Name
        {
            get { return mFa_Operation_Name; }
            set { mFa_Operation_Name = value; }
        }
        private Int16 mInc_Dec;
        public Int16 Inc_Dec
        {
            get { return mInc_Dec; }
            set { mInc_Dec = value; }
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