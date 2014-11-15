
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
        [Serializable]
    public class Tp_Monthly_Ticket : IHead
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
        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private int mMonth;
        public int Month
        {
            get { return mMonth; }
            set { mMonth = value; }
        }
        private int mYear;
        public int Year
        {
            get { return mYear; }
            set { mYear = value; }
        }
        private decimal mCost;
        public decimal Cost
        {
            get { return mCost; }
            set { mCost = value; }
        }
        private DateTime mDate_Purchase;
        public DateTime Date_Purchase
        {
            get { return mDate_Purchase; }
            set { mDate_Purchase = value; }
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
