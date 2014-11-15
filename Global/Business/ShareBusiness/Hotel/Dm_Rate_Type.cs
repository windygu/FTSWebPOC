using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Rate_Type : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private int mDays;
        public int Days
        {
            get { return mDays; }
            set { mDays = value; }
        }
        private int mHours;
        public int Hours
        {
            get { return mHours; }
            set { mHours = value; }
        }
        private Int16 mIs_Day;
        public Int16 Is_Day
        {
            get { return mIs_Day; }
            set { mIs_Day = value; }
        }
        private Int16 mIs_Hour;
        public Int16 Is_Hour
        {
            get { return mIs_Hour; }
            set { mIs_Hour = value; }
        }
        private string mRate_Type_Id;
        public string Rate_Type_Id
        {
            get { return mRate_Type_Id; }
            set { mRate_Type_Id = value; }
        }
        private string mRate_Type_Name;
        public string Rate_Type_Name
        {
            get { return mRate_Type_Name; }
            set { mRate_Type_Name = value; }
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