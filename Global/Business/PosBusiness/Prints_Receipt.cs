
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Prints_Receipt : IHead
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
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private Guid mPos_Shift_Pr_key;
        public Guid Pos_Shift_Pr_Key
        {
            get
            {
                return mPos_Shift_Pr_key;
            }
            set
            {
                mPos_Shift_Pr_key = value;
            }
        }

        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return this.mItem_Op_Id; }
            set { this.mItem_Op_Id = value; }
        }

        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return this.mPr_Detail_Id; }
            set { this.mPr_Detail_Id = value; }
        }

        private string mDealer_Id;
        public string Dealer_Id
        {
            get { return this.mDealer_Id; }
            set { this.mDealer_Id = value; }
        }

        private string mStatus;
        public string Status
        {
            get { return this.mStatus; }
            set { this.mStatus = value; }
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
