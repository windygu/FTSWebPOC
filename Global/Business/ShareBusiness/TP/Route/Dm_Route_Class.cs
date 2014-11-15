
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP.Route
{
    [Serializable]
    public class Dm_Route_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mRoute_Class_Id;
        public string Route_Class_Id
        {
            get { return mRoute_Class_Id; }
            set { mRoute_Class_Id = value; }
        }
        private string mRoute_Class_Name;
        public string Route_Class_Name
        {
            get { return mRoute_Class_Name; }
            set { mRoute_Class_Name = value; }
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
