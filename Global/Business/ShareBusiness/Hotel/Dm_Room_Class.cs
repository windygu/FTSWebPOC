using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Room_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;      
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private Int16 mPax;
        public Int16 Pax
        {
            get { return mPax; }
            set { mPax = value; }
        }
        private string mRoom_Class_Color;
        public string Room_Class_Color
        {
            get { return mRoom_Class_Color; }
            set { mRoom_Class_Color = value; }
        }
        private string mRoom_Class_Id;
        public string Room_Class_Id
        {
            get { return mRoom_Class_Id; }
            set { mRoom_Class_Id = value; }
        }
        private string mRoom_Class_Name;
        public string Room_Class_Name
        {
            get { return mRoom_Class_Name; }
            set { mRoom_Class_Name = value; }
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