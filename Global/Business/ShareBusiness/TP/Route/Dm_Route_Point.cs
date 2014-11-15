using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP.Route
{
    public class Dm_Route_Point : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mRoute_Point_Id;
        public string Route_Point_Id
        {
            get { return mRoute_Point_Id; }
            set { mRoute_Point_Id = value; }
        }
        private string mRoute_Point_Name;
        public string Route_Point_Name
        {
            get { return mRoute_Point_Name; }
            set { mRoute_Point_Name = value; }
        }
        private string mRoute_Point_Class_Id;
        public string Route_Point_Class_Id
        {
            get { return mRoute_Point_Class_Id; }
            set { mRoute_Point_Class_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private Int16 mIs_Route_Out;
        public Int16 Is_Route_Out
        {
            get { return mIs_Route_Out; }
            set { mIs_Route_Out = value; }
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
