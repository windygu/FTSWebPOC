
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Pos_Shift_Employee : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private int mList_Order;

        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mEmployee_Id;

        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private Int16 mIs_Team_Lead;

        public Int16 Is_Team_Lead
        {
            get { return mIs_Team_Lead; }
            set { mIs_Team_Lead = value; }
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
