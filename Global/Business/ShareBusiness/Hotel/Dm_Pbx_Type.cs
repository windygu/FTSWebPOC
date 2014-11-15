using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Pbx_Type : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mPbx_Type_Id;
        public string Pbx_Type_Id
        {
            get { return mPbx_Type_Id; }
            set { mPbx_Type_Id = value; }
        }
        private string mPbx_Type_Name;
        public string Pbx_Type_Name
        {
            get { return mPbx_Type_Name; }
            set { mPbx_Type_Name = value; }
        }
        private Int32 mDate_Type;
        public Int32 Date_Type
        {
            get { return mDate_Type; }
            set { mDate_Type = value; }
        }
        private Int32 mDate_Start;
        public Int32 Date_Start
        {
            get { return mDate_Start; }
            set { mDate_Start = value; }
        }
        private Int32 mDate_Len;
        public Int32 Date_Len
        {
            get { return mDate_Len; }
            set { mDate_Len = value; }
        }
        private Int32 mTime_Type;
        public Int32 Time_Type
        {
            get { return mTime_Type; }
            set { mTime_Type = value; }
        }
        private Int32 mTime_Start;
        public Int32 Time_Start
        {
            get { return mTime_Start; }
            set { mTime_Start = value; }
        }
        private Int32 mTime_Len;
        public Int32 Time_Len
        {
            get { return mTime_Len; }
            set { mTime_Len = value; }
        }
        private Int32 mDura_Type;
        public Int32 Dura_Type
        {
            get { return mDura_Type; }
            set { mDura_Type = value; }
        }
        private Int32 mDura_Start;
        public Int32 Dura_Start
        {
            get { return mDura_Start; }
            set { mDura_Start = value; }
        }
        private Int32 mDura_Len;
        public Int32 Dura_Len
        {
            get { return mDura_Len; }
            set { mDura_Len = value; }
        }
        private Int32 mExt_Start;
        public Int32 Ext_Start
        {
            get { return mExt_Start; }
            set { mExt_Start = value; }
        }
        private Int32 mExt_Len;
        public Int32 Ext_Len
        {
            get { return mExt_Len; }
            set { mExt_Len = value; }
        }
        private Int32 mCalled_Start;
        public Int32 Called_Start
        {
            get { return mCalled_Start; }
            set { mCalled_Start = value; }
        }
        private Int32 mCalled_Len;
        public Int32 Called_Len
        {
            get { return mCalled_Len; }
            set { mCalled_Len = value; }
        }
        private Int32 mTrunk_Start;
        public Int32 Trunk_Start
        {
            get { return mTrunk_Start; }
            set { mTrunk_Start = value; }
        }
        private Int32 mTrunk_Len;
        public Int32 Trunk_Len
        {
            get { return mTrunk_Len; }
            set { mTrunk_Len = value; }
        }
        private Int32 mPref1;
        public Int32 Pref1
        {
            get { return mPref1; }
            set { mPref1 = value; }
        }
        private Int32 mPref2;
        public Int32 Pref2
        {
            get { return mPref2; }
            set { mPref2 = value; }
        }
        private string mTransfer;
        public string Transfer
        {
            get { return mTransfer; }
            set { mTransfer = value; }
        }
        private Int16 mOk;
        public Int16 Ok
        {
            get { return mOk; }
            set { mOk = value; }
        }
        private string mPin_Sign;
        public string Pin_Sign
        {
            get { return mPin_Sign; }
            set { mPin_Sign = value; }
        }
        private Int32 mPin_Sign_Start;
        public Int32 Pin_Sign_Start
        {
            get { return mPin_Sign_Start; }
            set { mPin_Sign_Start = value; }
        }
        private Int32 mPin_Start;
        public Int32 Pin_Start
        {
            get { return mPin_Start; }
            set { mPin_Start = value; }
        }
        private Int32 mPin_Len;
        public Int32 Pin_Len
        {
            get { return mPin_Len; }
            set { mPin_Len = value; }
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