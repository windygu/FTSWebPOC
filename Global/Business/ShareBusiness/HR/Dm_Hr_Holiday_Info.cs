using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Hr_Holiday_Info : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mHoliday_Id;
        public string Holiday_Id
        {
            get { return mHoliday_Id; }
            set { mHoliday_Id = value; }
        }
        private Int16 mHoliday_Year;
        public Int16 Holiday_Year
        {
            get { return mHoliday_Year; }
            set { mHoliday_Year = value; }
        }
        private DateTime mHoliday_Start;
        public DateTime Holiday_Start
        {
            get { return mHoliday_Start; }
            set { mHoliday_Start = value; }
        }
        private DateTime mHoliday_End;
        public DateTime Holiday_End
        {
            get { return mHoliday_End; }
            set { mHoliday_End = value; }
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