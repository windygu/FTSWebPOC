using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Warehouse
{
    [Serializable]
    public class Warehouse_Balance_Actual : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get
            {
                return mPr_Key;
            }
            set
            {
                mPr_Key = value;
            }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get
            {
                return mTran_Date;
            }
            set
            {
                mTran_Date = value;
            }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get
            {
                return mOrganization_Id;
            }
            set
            {
                mOrganization_Id = value;
            }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get
            {
                return mWarehouse_Id;
            }
            set
            {
                mWarehouse_Id = value;
            }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get
            {
                return mItem_Id;
            }
            set
            {
                mItem_Id = value;
            }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get
            {
                return mQuantity;
            }
            set
            {
                mQuantity = value;
            }
        }
        private decimal mQuantity_Extra;
        public decimal Quantity_Extra
        {
            get
            {
                return mQuantity_Extra;
            }
            set
            {
                mQuantity_Extra = value;
            }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get
            {
                return mUnit_Price;
            }
            set
            {
                mUnit_Price = value;
            }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get
            {
                return mAmount;
            }
            set
            {
                mAmount = value;
            }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get
            {
                return mAmount_Extra;
            }
            set
            {
                mAmount_Extra = value;
            }
        }
        private string mUser_Id;
        public string User_Id
        {
            get
            {
                return mUser_Id;
            }
            set
            {
                mUser_Id = value;
            }
        }
        private string mLot_No;
        public string Lot_No
        {
            get
            {
                return mLot_No;
            }
            set
            {
                mLot_No = value;
            }
        }
        private DateTime mReceive_Date;
        public DateTime Receive_Date
        {
            get
            {
                return mReceive_Date;
            }
            set
            {
                mReceive_Date = value;
            }
        }
        private DateTime mManu_Date;
        public DateTime Manu_Date
        {
            get
            {
                return mManu_Date;
            }
            set
            {
                mManu_Date = value;
            }
        }
        private DateTime mExpire_Date;
        public DateTime Expire_Date
        {
            get
            {
                return mExpire_Date;
            }
            set
            {
                mExpire_Date = value;
            }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get
            {
                return mAccount_Id;
            }
            set
            {
                mAccount_Id = value;
            }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get
            {
                return mItem_Source_Id;
            }
            set
            {
                mItem_Source_Id = value;
            }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get
            {
                return mJob_Id;
            }
            set
            {
                mJob_Id = value;
            }
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
