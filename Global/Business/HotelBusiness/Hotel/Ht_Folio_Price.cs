using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Folio_Price : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private DateTime mDate;
        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }        
        private decimal mPrice;
        public decimal Price
        {
            get { return mPrice; }
            set { mPrice = value; }
        }        
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mPr_Key_Ht_Folio;
        public Guid Pr_Key_Ht_Folio
        {
            get { return mPr_Key_Ht_Folio; }
            set { mPr_Key_Ht_Folio = value; }
        }
        private Guid mPr_Key_Booking_Detail;
        public Guid Pr_Key_Booking_Detail
        {
            get { return mPr_Key_Booking_Detail; }
            set { mPr_Key_Booking_Detail = value; }
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