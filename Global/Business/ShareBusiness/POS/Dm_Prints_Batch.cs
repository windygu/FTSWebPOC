using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.POS
{
    public class Dm_Prints_Batch : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }

        private string mPrints_Id;
        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }

        private decimal mBatch_Quantity;
        public decimal Batch_Quantity
        {
            get { return mBatch_Quantity; }
            set { mBatch_Quantity = value; }
        }

        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        
        private int mActive;
        public int Active
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
