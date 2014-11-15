using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP
{
    [Serializable]
    public class Dm_Vehicle : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private string mVehicle_Type_Id;
        public string Vehicle_Type_Id
        {
            get { return mVehicle_Type_Id; }
            set { mVehicle_Type_Id = value; }
        }
        private string mVehicle_Team_Id;
        public string Vehicle_Team_Id
        {
            get { return mVehicle_Team_Id; }
            set { mVehicle_Team_Id = value; }
        }
        private string mEngine_Type;
        public string Engine_Type
        {
            get { return mEngine_Type; }
            set { mEngine_Type = value; }
        }
        private string mVehicle_Quality_Id;
        public string Vehicle_Quality_Id
        {
            get { return mVehicle_Quality_Id; }
            set { mVehicle_Quality_Id = value; }
        }
        private decimal mVolume_Total;
        public decimal Volume_Total
        {
            get { return mVolume_Total; }
            set { mVolume_Total = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private Int16 mIs_Hire_Outside;
        public Int16 Is_Hire_Outside
        {
            get { return mIs_Hire_Outside; }
            set { mIs_Hire_Outside = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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
