using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Charges_Check_In_Before : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private decimal mCharges_Percent;
        public decimal Charges_Percent
        {
            get { return mCharges_Percent; }
            set { mCharges_Percent = value; }
        }
        private decimal mCharges_Amount;
        public decimal Charges_Amount
        {
            get { return mCharges_Amount; }
            set { mCharges_Amount = value; }
        }
        private decimal mFrom_Hour;
        public decimal From_Hour
        {
            get { return mFrom_Hour; }
            set { mFrom_Hour = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private decimal mTo_Hour;
        public decimal To_Hour
        {
            get { return mTo_Hour; }
            set { mTo_Hour = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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