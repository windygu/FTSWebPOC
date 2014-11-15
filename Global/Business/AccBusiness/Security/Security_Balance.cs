using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Security
{
    public class Security_Balance:IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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

        private Guid mPr_key;
        public Guid MPr_key
        {
            get { return mPr_key; }
            set { mPr_key = value; }
        }

        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }

        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }

        private string mSecurity_Id;
        public string Security_Id
        {
            get { return mSecurity_Id; }
            set { mSecurity_Id = value; }
        }

        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }

        private DateTime mReceipt_Date;
        public DateTime Receipt_Date
        {
            get { return mReceipt_Date; }
            set { mReceipt_Date = value; }
        }

        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }

        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }

        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }

        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }

        private decimal mBook_Unit_Price;
        public decimal Book_Unit_Price
        {
            get { return mBook_Unit_Price; }
            set { mBook_Unit_Price = value; }
        }

        private decimal mBook_Amount;
        public decimal Book_Amount
        {
            get { return mBook_Amount; }
            set { mBook_Amount = value; }
        }
    }
}
