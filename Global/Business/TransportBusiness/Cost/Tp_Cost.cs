
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.TransportBusiness.Cost
{
    [Serializable]
    public class Tp_Cost : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mRoute_Id;
        public string Route_Id
        {
            get { return mRoute_Id; }
            set { mRoute_Id = value; }
        }
        private string mFuel_Cost_Method;
        public string Fuel_Cost_Method
        {
            get { return mFuel_Cost_Method; }
            set { mFuel_Cost_Method = value; }
        }
        private decimal mFuel_Price;
        public decimal Fuel_Price
        {
            get { return mFuel_Price; }
            set { mFuel_Price = value; }
        }
        private decimal mFuel_Bridge_Cost;
        public decimal Fuel_Bridge_Cost
        {
            get { return mFuel_Bridge_Cost; }
            set { mFuel_Bridge_Cost = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private Int16 mBridge_Toll_Included;
        public Int16 Bridge_Toll_Included
        {
            get { return mBridge_Toll_Included; }
            set { mBridge_Toll_Included = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private decimal mDistance_Payment;
        public decimal Distance_Payment
        {
            get { return mDistance_Payment; }
            set { mDistance_Payment = value; }
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
