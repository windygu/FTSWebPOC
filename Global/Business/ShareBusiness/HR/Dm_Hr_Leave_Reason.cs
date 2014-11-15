using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Hr_Leave_Reason : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mLeave_Reason_Id;
        public string Leave_Reason_Id
        {
            get { return mLeave_Reason_Id; }
            set { mLeave_Reason_Id = value; }
        }
        private string mLeave_Reason_Name;
        public string Leave_Reason_Name
        {
            get { return mLeave_Reason_Name; }
            set { mLeave_Reason_Name = value; }
        }
        private string mSalary_Type_ID;
        public string Salary_Type_ID
        {
            get { return mSalary_Type_ID; }
            set { mSalary_Type_ID = value; }
        }
        private string mLeave_Reason_Color;
        public string Leave_Reason_Color
        {
            get { return mLeave_Reason_Color; }
            set { mLeave_Reason_Color = value; }
        }
        private Int16 mIs_Unknow;
        public Int16 Is_Unknow
        {
            get { return mIs_Unknow; }
            set { mIs_Unknow = value; }
        }
        private Int16 mIs_Work;
        public Int16 Is_Work
        {
            get { return mIs_Work; }
            set { mIs_Work = value; }
        }
        private Int16 mIs_Priority;
        public Int16 Is_Priority
        {
            get { return mIs_Priority; }
            set { mIs_Priority = value; }
        }
        private DateTime mDatetime_In;
        public DateTime Datetime_In
        {
          get { return mDatetime_In; }
          set { mDatetime_In = value; }
        }
        private DateTime mDatetime_Out;
        public DateTime Datetime_Out
        {
          get { return mDatetime_Out; }
          set { mDatetime_Out = value; }
        }
        private Int16 mIs_Work_off;
        public Int16 Is_Work_off
        {
            get { return mIs_Work_off; }
            set { mIs_Work_off = value; }
        }
        private Int16 mIs_Work_Holiday;
        public Int16 Is_Work_Holiday
        {
            get { return mIs_Work_Holiday; }
            set { mIs_Work_Holiday = value; }
        }
        private string mShort_Name;
        public string Short_Name
        {
            get { return mShort_Name; }
            set { mShort_Name = value; }
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
            get { return mIs_Unknow; }
            set { mIs_Unknow = value; }
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