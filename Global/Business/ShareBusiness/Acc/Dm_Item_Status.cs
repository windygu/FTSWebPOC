using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Item_Status : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mItem_Status_Id;
        public string Item_Status_Id
        {
            get { return mItem_Status_Id; }
            set { mItem_Status_Id = value; }
        }
        private string mItem_Status_Name;
        public string Item_Status_Name
        {
            get { return mItem_Status_Name; }
            set { mItem_Status_Name = value; }
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