
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Prints_Warehouse_Balance : IHead
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
        private string mEmployee_Id;
        public string Employee_Id
        {
            get
            {
                return mEmployee_Id;
            }
            set
            {
                mEmployee_Id = value;
            }
        }
        private string mPrints_Id;
        public string Prints_Id
        {
            get
            {
                return mPrints_Id;
            }
            set
            {
                mPrints_Id = value;
            }
        }
        private string mDescription;
        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }
        private string mBatch_No;
        public string Batch_No
        {
            get
            {
                return mBatch_No;
            }
            set
            {
                mBatch_No = value;
            }
        }
        private int mSeri_Quantity;
        public int Seri_Quantity
        {
            get
            {
                return mSeri_Quantity;
            }
            set
            {
                mSeri_Quantity = value;
            }
        }
        private string mPrints_Serie;
        public string Prints_Serie
        {
            get
            {
                return mPrints_Serie;
            }
            set
            {
                mPrints_Serie = value;
            }
        }
        private int mQuantity;
        public int Quantity
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
        private int mSeri_Start;
        public int Seri_Start
        {
            get
            {
                return mSeri_Start;
            }
            set
            {
                mSeri_Start = value;
            }
        }
        private int mSeri_End;
        public int Seri_End
        {
            get
            {
                return mSeri_End;
            }
            set
            {
                mSeri_End = value;
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
        private string mUnit_Id;
        public string Unit_Id
        {
            get
            {
                return mUnit_Id;
            }
            set
            {
                mUnit_Id = value;
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
        private string mReceive_Tran_No;
        public string Receive_Tran_No
        {
            get
            {
                return mReceive_Tran_No;
            }
            set
            {
                mReceive_Tran_No = value;
            }
        }

        private int mBatch_Quantity;
        public int Batch_Quantity
        {
            get
            {
                return mBatch_Quantity;
            }
            set
            {
                mBatch_Quantity = value;
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
