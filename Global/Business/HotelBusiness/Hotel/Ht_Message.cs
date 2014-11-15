using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Message : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mGuest_Id;
        public string Guest_Id
        {
            get { return mGuest_Id; }
            set { mGuest_Id = value; }
        }
        private DateTime mMessage_Date;
        public DateTime Message_Date
        {
            get { return mMessage_Date; }
            set { mMessage_Date = value; }
        }
        private string mMessage_Description;
        public string Message_Description
        {
            get { return mMessage_Description; }
            set { mMessage_Description = value; }
        }
        private int mMessage_Hour;
        public int Message_Hour
        {
            get { return mMessage_Hour; }
            set { mMessage_Hour = value; }
        }
        private int mMessage_Minute;
        public int Message_Minute
        {
            get { return mMessage_Minute; }
            set { mMessage_Minute = value; }
        }
        private string mMessage_Status;
        public string Message_Status
        {
            get { return mMessage_Status; }
            set { mMessage_Status = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private DateTime mReceived_Date;
        public DateTime Received_Date
        {
            get { return mReceived_Date; }
            set { mReceived_Date = value; }
        }
        private int mReceived_Hour;
        public int Received_Hour
        {
            get { return mReceived_Hour; }
            set { mReceived_Hour = value; }
        }
        private int mReceived_Minute;
        public int Received_Minute
        {
            get { return mReceived_Minute; }
            set { mReceived_Minute = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }
        private string mSender_Name;
        public string Sender_Name
        {
            get { return mSender_Name; }
            set { mSender_Name = value; }
        }
        private string mSender_Phone;
        public string Sender_Phone
        {
            get { return mSender_Phone; }
            set { mSender_Phone = value; }
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