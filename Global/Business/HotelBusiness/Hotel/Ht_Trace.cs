using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Trace : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private DateTime mResolved_Date;
        public DateTime Resolved_Date
        {
            get { return mResolved_Date; }
            set { mResolved_Date = value; }
        }
        private int mResolved_Hour;
        public int Resolved_Hour
        {
            get { return mResolved_Hour; }
            set { mResolved_Hour = value; }
        }
        private int mResolved_Minute;
        public int Resolved_Minute
        {
            get { return mResolved_Minute; }
            set { mResolved_Minute = value; }
        }
        private string mResolved_Person;
        public string Resolved_Person
        {
            get { return mResolved_Person; }
            set { mResolved_Person = value; }
        }
        private DateTime mTrace_Date;
        public DateTime Trace_Date
        {
            get { return mTrace_Date; }
            set { mTrace_Date = value; }
        }
        private string mTrace_Description;
        public string Trace_Description
        {
            get { return mTrace_Description; }
            set { mTrace_Description = value; }
        }
        private int mTrace_Hour;
        public int Trace_Hour
        {
            get { return mTrace_Hour; }
            set { mTrace_Hour = value; }
        }
        private int mTrace_Minute;
        public int Trace_Minute
        {
            get { return mTrace_Minute; }
            set { mTrace_Minute = value; }
        }
        private string mTrace_Status;
        public string Trace_Status
        {
            get { return mTrace_Status; }
            set { mTrace_Status = value; }
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