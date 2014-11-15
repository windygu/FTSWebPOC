using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Cabinet : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mCabinet_Id;
        public string Cabinet_Id
        {
            get { return mCabinet_Id; }
            set { mCabinet_Id = value; }
        }
        private string mCabinet_Name;
        public string Cabinet_Name
        {
            get { return mCabinet_Name; }
            set { mCabinet_Name = value; }
        }
        private string mParent_Cabinet;
        public string Parent_Cabinet
        {
            get { return mParent_Cabinet; }
            set { mParent_Cabinet = value; }
        }
        private string mList_Parent_Cabinet;
        public string List_Parent_Cabinet
        {
            get { return mList_Parent_Cabinet; }
            set { mList_Parent_Cabinet = value; }
        }
        private string mList_Child_Cabinet;
        public string List_Child_Cabinet
        {
            get { return mList_Child_Cabinet; }
            set { mList_Child_Cabinet = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
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