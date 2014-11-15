using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Cdr : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private DateTime mCall_Date;
        public DateTime Call_Date
        {
            get { return mCall_Date; }
            set { mCall_Date = value; }
        }
        private string mStart_Time;
        public string Start_Time
        {
            get { return mStart_Time; }
            set { mStart_Time = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private string mDuration;
        public string Duration
        {
            get { return mDuration; }
            set { mDuration = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }       
        private string mPhone_Extension;
        public string Phone_Extension
        {
            get { return mPhone_Extension; }
            set { mPhone_Extension = value; }
        }
        private string mCalled;
        public string Called
        {
            get { return mCalled; }
            set { mCalled = value; }
        }
        private string mArea_Code_Id;
        public string Area_Code_Id
        {
            get { return mArea_Code_Id; }
            set { mArea_Code_Id = value; }
        }
        private string mCdr_Data;
        public string Cdr_Data
        {
            get { return mCdr_Data; }
            set { mCdr_Data = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
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