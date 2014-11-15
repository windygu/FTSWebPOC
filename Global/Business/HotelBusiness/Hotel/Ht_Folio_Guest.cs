using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Folio_Guest : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private DateTime mGuest_Arrive_Date;
        public DateTime Guest_Arrive_Date
        {
            get { return mGuest_Arrive_Date; }
            set { mGuest_Arrive_Date = value; }
        }
        private int mGuest_Arrive_Hour;
        public int Guest_Arrive_Hour
        {
            get { return mGuest_Arrive_Hour; }
            set { mGuest_Arrive_Hour = value; }
        }
        private int mGuest_Arrive_Minute;
        public int Guest_Arrive_Minute
        {
            get { return mGuest_Arrive_Minute; }
            set { mGuest_Arrive_Minute = value; }
        }
        private DateTime mGuest_Depart_Date;
        public DateTime Guest_Depart_Date
        {
            get { return mGuest_Depart_Date; }
            set { mGuest_Depart_Date = value; }
        }
        private int mGuest_Depart_Hour;
        public int Guest_Depart_Hour
        {
            get { return mGuest_Depart_Hour; }
            set { mGuest_Depart_Hour = value; }
        }
        private int mGuest_Depart_Minute;
        public int Guest_Depart_Minute
        {
            get { return mGuest_Depart_Minute; }
            set { mGuest_Depart_Minute = value; }
        }
        private string mGuest_Id;
        public string Guest_Id
        {
            get { return mGuest_Id; }
            set { mGuest_Id = value; }
        }
        private string mGuest_Status;
        public string Guest_Status
        {
            get { return mGuest_Status; }
            set { mGuest_Status = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
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