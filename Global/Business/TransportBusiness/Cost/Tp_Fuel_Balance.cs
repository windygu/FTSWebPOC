
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
        [Serializable]
    public class Tp_Fuel_Balance : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private string mDriver_Id;
        public string Driver_Id
        {
            get { return mDriver_Id; }
            set { mDriver_Id = value; }
        }
        private string mType_Fuel;
        public string Type_Fuel
        {
            get { return mType_Fuel; }
            set { mType_Fuel = value; }
        }
        private int mQuality;
        public int Quality
        {
            get { return mQuality; }
            set { mQuality = value; }
        }
        private decimal mPrice;
        public decimal Price
        {
            get { return mPrice; }
            set { mPrice = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
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
