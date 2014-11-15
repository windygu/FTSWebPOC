using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Zone : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mZone_Id;
        public string Zone_Id
        {
            get { return mZone_Id; }
            set { mZone_Id = value; }
        }
        private string mZone_Name;
        public string Zone_Name
        {
            get { return mZone_Name; }
            set { mZone_Name = value; }
        }
        private Int32 mFirst_Unit;
        public Int32 First_Unit
        {
            get { return mFirst_Unit; }
            set { mFirst_Unit = value; }
        }
        private Int32 mNext_Unit;
        public Int32 Next_Unit
        {
            get { return mNext_Unit; }
            set { mNext_Unit = value; }
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