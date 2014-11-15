using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Period : IHead
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

        private string mPeriod_Id;
        public string Period_Id
        {
            get { return mPeriod_Id; }
            set { mPeriod_Id = value; }
        }

        private string mPeriod_Name;
        public string Period_Name
        {
            get { return mPeriod_Name; }
            set { mPeriod_Name = value; }
        }

        private Int32 mPeriod_Number;
        public Int32 Period_Number
        {
            get { return mPeriod_Number; }
            set { mPeriod_Number = value; }
        }

        private string mPeriod_Type;
        public string Period_Type
        {
            get { return mPeriod_Type; }
            set { mPeriod_Type = value; }
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
