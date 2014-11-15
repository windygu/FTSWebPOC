
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP.Route
{
    public class Dm_Route_Group : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mRoute_Group_Id;
        public string Route_Group_Id
        {
            get { return mRoute_Group_Id; }
            set { mRoute_Group_Id = value; }
        }
        private string mRoute_Group_Name;
        public string Route_Group_Name
        {
            get { return mRoute_Group_Name; }
            set { mRoute_Group_Name = value; }
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
