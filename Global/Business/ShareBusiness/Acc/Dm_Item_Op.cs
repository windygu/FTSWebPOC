using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Item_Op : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mItem_Op_Name;
        public string Item_Op_Name
        {
            get { return mItem_Op_Name; }
            set { mItem_Op_Name = value; }
        }
        private string mOp_Type;
        public string Op_Type
        {
            get { return mOp_Type; }
            set { mOp_Type = value; }
        }
        private Int16 mIs_Transfer;
        public Int16 Is_Transfer
        {
            get { return mIs_Transfer; }
            set { mIs_Transfer = value; }
        }
        private string mTransfer_Item_Op_Id;
        public string Transfer_Item_Op_Id
        {
            get { return mTransfer_Item_Op_Id; }
            set { mTransfer_Item_Op_Id = value; }
        }
        private string mVb_Item_Op_Id;
        public string Vb_Item_Op_Id {
            get { return mVb_Item_Op_Id; }
            set { mVb_Item_Op_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
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
        private Int16 mIs_Parent;
        public Int16 Is_Parent {
            get { return mIs_Parent; }
            set { mIs_Parent = value; }
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