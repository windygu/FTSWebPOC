
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
        [Serializable]
    public class Tp_Bridge_Ticket_Price : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mBridge_Id;
        public string Bridge_Id
        {
            get { return mBridge_Id; }
            set { mBridge_Id = value; }
        }
        private decimal mVolume_Min;
        public decimal Volume_Min
        {
            get { return mVolume_Min; }
            set { mVolume_Min = value; }
        }
        private decimal mVolume_Max;
        public decimal Volume_Max
        {
            get { return mVolume_Max; }
            set { mVolume_Max = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private decimal mTicket_Price;
        public decimal Ticket_Price
        {
            get { return mTicket_Price; }
            set { mTicket_Price = value; }
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
