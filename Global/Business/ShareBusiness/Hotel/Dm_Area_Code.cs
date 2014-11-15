using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Area_Code : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mArea_Code_Id;
        public string Area_Code_Id
        {
            get { return mArea_Code_Id; }
            set { mArea_Code_Id = value; }
        }
        private string mArea_Code_Name;
        public string Area_Code_Name
        {
            get { return mArea_Code_Name; }
            set { mArea_Code_Name = value; }
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
        private string mZone_Id;
        public string Zone_Id
        {
            get { return mZone_Id; }
            set { mZone_Id = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
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