using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP
{
        [Serializable]
    public class Dm_Vehicle_Type : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mVehicle_Type_Id;
        public string Vehicle_Type_Id
        {
            get { return mVehicle_Type_Id; }
            set { mVehicle_Type_Id = value; }
        }
        private string mVehicle_Type_Name;
        public string Vehicle_Type_Name
        {
            get { return mVehicle_Type_Name; }
            set { mVehicle_Type_Name = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
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
