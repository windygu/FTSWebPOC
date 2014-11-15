
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
        [Serializable]
    public class Tp_Fuel_Consumption : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mVehicle_Type_Id;
        public string Vehicle_Type_Id
        {
            get { return mVehicle_Type_Id; }
            set { mVehicle_Type_Id = value; }
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
        private string mVehicle_Quality_Id;
        public string Vehicle_Quality_Id
        {
            get { return mVehicle_Quality_Id; }
            set { mVehicle_Quality_Id = value; }
        }
        private decimal mFuel_Consumption;
        public decimal Fuel_Consumption
        {
            get { return mFuel_Consumption; }
            set { mFuel_Consumption = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private Int16 mIs_Non_Item;
        public Int16 Is_Non_Item
        {
            get { return mIs_Non_Item; }
            set { mIs_Non_Item = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
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
