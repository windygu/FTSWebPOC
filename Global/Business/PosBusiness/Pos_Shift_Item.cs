
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Pos_Shift_Item : IHead
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
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get
            {
                return mFr_Key;
            }
            set
            {
                mFr_Key = value;
            }
        }
        private int mList_Order;
        public int List_Order
        {
            get
            {
                return mList_Order;
            }
            set
            {
                mList_Order = value;
            }
        }
        private string mPump_Id;
        public string Pump_Id
        {
            get
            {
                return mPump_Id;
            }
            set
            {
                mPump_Id = value;
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
        private string mUnit_Id;
        public string Unit_Id {
            get {
                return mUnit_Id;
            }
            set {
                mUnit_Id = value;
            }
        }
        private decimal mOpening_Balance;
        public decimal Opening_Balance
        {
            get
            {
                return mOpening_Balance;
            }
            set
            {
                mOpening_Balance = value;
            }
        }
        private decimal mReceive_Quantity;
        public decimal Receive_Quantity
        {
            get
            {
                return mReceive_Quantity;
            }
            set
            {
                mReceive_Quantity = value;
            }
        }
        private decimal mIssue_Quantity;
        public decimal Issue_Quantity
        {
            get
            {
                return mIssue_Quantity;
            }
            set
            {
                mIssue_Quantity = value;
            }
        }
        private decimal mEnding_Balance;
        public decimal Ending_Balance
        {
            get
            {
                return mEnding_Balance;
            }
            set
            {
                mEnding_Balance = value;
            }
        }
        private string mNotes;
        public string Notes
        {
            get
            {
                return mNotes;
            }
            set
            {
                mNotes = value;
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
