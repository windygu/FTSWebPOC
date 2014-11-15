 using System;
 using System.Collections.Generic;
 using System.Text;
 using FTS.Global.Interface;
 using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Season : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private int mDay_End;
        public int Day_End
        {
            get { return mDay_End; }
            set { mDay_End = value; }
        }
        private int mDay_Start;
        public int Day_Start
        {
            get { return mDay_Start; }
            set { mDay_Start = value; }
        }
        private DateTime mEffective_Date;
        public DateTime Effective_Date
        {
            get { return mEffective_Date; }
            set { mEffective_Date = value; }
        }
        private DateTime mEnd_Date;
        public DateTime End_Date
        {
            get { return mEnd_Date; }
            set { mEnd_Date = value; }
        }
        private int mMonth_End;
        public int Month_End
        {
            get { return mMonth_End; }
            set { mMonth_End = value; }
        }
        private int mMonth_Start;
        public int Month_Start
        {
            get { return mMonth_Start; }
            set { mMonth_Start = value; }
        }
        private string mSeason_Id;
        public string Season_Id
        {
            get { return mSeason_Id; }
            set { mSeason_Id = value; }
        }
        private string mSeason_Name;
        public string Season_Name
        {
            get { return mSeason_Name; }
            set { mSeason_Name = value; }
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