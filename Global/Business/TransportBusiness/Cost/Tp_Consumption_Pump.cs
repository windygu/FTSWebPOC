
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
        [Serializable]
    public class Tp_Consumption_Pump : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mVehicle_Type_Id;
        public string Vehicle_Type_Id
        {
            get { return mVehicle_Type_Id; }
            set { mVehicle_Type_Id = value; }
        }
        private decimal mPump_Fuel;
        public decimal Pump_Fuel
        {
            get { return mPump_Fuel; }
            set { mPump_Fuel = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
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
