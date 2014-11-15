using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Wakeup : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;      
        private string mGuest_Id;
        public string Guest_Id
        {
            get { return mGuest_Id; }
            set { mGuest_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }
        private DateTime mWakeup_Date;
        public DateTime Wakeup_Date
        {
            get { return mWakeup_Date; }
            set { mWakeup_Date = value; }
        }
        private int mWakeup_Hour;
        public int Wakeup_Hour
        {
            get { return mWakeup_Hour; }
            set { mWakeup_Hour = value; }
        }
        private int mWakeup_Minute;
        public int Wakeup_Minute
        {
            get { return mWakeup_Minute; }
            set { mWakeup_Minute = value; }
        }
        private string mWakeup_Note;
        public string Wakeup_Note
        {
            get { return mWakeup_Note; }
            set { mWakeup_Note = value; }
        }
        private string mWakeup_Status;
        public string Wakeup_Status
        {
            get { return mWakeup_Status; }
            set { mWakeup_Status = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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