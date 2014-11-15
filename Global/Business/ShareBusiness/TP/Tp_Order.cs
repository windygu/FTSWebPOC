using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP
{
        [Serializable]
    public class Tp_Order : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private string mOrder_No;
        public string Order_No
        {
            get { return mOrder_No; }
            set { mOrder_No = value; }
        }
        private DateTime mOrder_Date;
        public DateTime Order_Date
        {
            get { return mOrder_Date; }
            set { mOrder_Date = value; }
        }
        private DateTime mDepart_Date;
        public DateTime Depart_Date
        {
            get { return mDepart_Date; }
            set { mDepart_Date = value; }
        }
        private DateTime mReturn_Date;
        public DateTime Return_Date
        {
            get { return mReturn_Date; }
            set { mReturn_Date = value; }
        }
        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private string mVehicle_Team_Id;
        public string Vehicle_Team_Id
        {
            get { return mVehicle_Team_Id; }
            set { mVehicle_Team_Id = value; }
        }
        private string mDriver_Id;
        public string Driver_Id
        {
            get { return mDriver_Id; }
            set { mDriver_Id = value; }
        }
        private string mVehicle_Type_Id;
        public string Vehicle_Type_Id
        {
            get { return mVehicle_Type_Id; }
            set { mVehicle_Type_Id = value; }
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
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mStatus;
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        private string mDriver_Name;
        public string Driver_Name
        {
            get { return mDriver_Name; }
            set { mDriver_Name = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mSecond_Driver_Id;
        public string Second_Driver_Id
        {
            get { return mSecond_Driver_Id; }
            set { mSecond_Driver_Id = value; }
        }
        private string mSecond_Driver_Name;
        public string Second_Driver_Name
        {
            get { return mSecond_Driver_Name; }
            set { mSecond_Driver_Name = value; }
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
