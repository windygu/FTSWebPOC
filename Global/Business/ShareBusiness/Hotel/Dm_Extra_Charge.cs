using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Extra_Charge : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;      
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mExtra_Charge_Id;
        public string Extra_Charge_Id
        {
            get { return mExtra_Charge_Id; }
            set { mExtra_Charge_Id = value; }
        }
        private string mExtra_Charge_Name;
        public string Extra_Charge_Name
        {
            get { return mExtra_Charge_Name; }
            set { mExtra_Charge_Name = value; }
        }
        private Int16 mIs_Always;
        public Int16 Is_Always
        {
            get { return mIs_Always; }
            set { mIs_Always = value; }
        }
        private Int16 mIs_Daily;
        public Int16 Is_Daily
        {
            get { return mIs_Daily; }
            set { mIs_Daily = value; }
        }
        private decimal mRate;
        public decimal Rate
        {
            get { return mRate; }
            set { mRate = value; }
        }
        private decimal mTotal_Rate;
        public decimal Total_Rate
        {
            get { return mTotal_Rate; }
            set { mTotal_Rate = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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