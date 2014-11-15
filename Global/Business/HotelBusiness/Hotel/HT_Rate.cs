using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Rate : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private string mBusiness_Source_Id;
        public string Business_Source_Id
        {
            get { return mBusiness_Source_Id; }
            set { mBusiness_Source_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private int mExtra_Adult;
        public int Extra_Adult
        {
            get { return mExtra_Adult; }
            set { mExtra_Adult = value; }
        }
        private int mExtra_Child;
        public int Extra_Child
        {
            get { return mExtra_Child; }
            set { mExtra_Child = value; }
        }
        private string mMarket_Id;
        public string Market_Id
        {
            get { return mMarket_Id; }
            set { mMarket_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private decimal mRate;
        public decimal Rate
        {
            get { return mRate; }
            set { mRate = value; }
        }
        private string mRate_Type_Id;
        public string Rate_Type_Id
        {
            get { return mRate_Type_Id; }
            set { mRate_Type_Id = value; }
        }
        private string mRoom_Class_Id;
        public string Room_Class_Id
        {
            get { return mRoom_Class_Id; }
            set { mRoom_Class_Id = value; }
        }
        private string mSeason_Id;
        public string Season_Id
        {
            get { return mSeason_Id; }
            set { mSeason_Id = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private Int16 mIs_Holidays;
        public Int16 Is_Holidays
        {
            get { return mIs_Holidays; }
            set { mIs_Holidays = value; }
        }
        private Int16 mIs_Weekend;
        public Int16 Is_Weekend
        {
            get { return mIs_Weekend; }
            set { mIs_Weekend = value; }
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