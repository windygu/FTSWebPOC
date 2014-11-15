using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Warehouse_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
      
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

        private string mWarehouse_Class_Id;
        public string Warehouse_Class_Id
        {
            get { return mWarehouse_Class_Id; }
            set { mWarehouse_Class_Id = value; }
        }
        private string mWarehouse_Class_Name;
        public string Warehouse_Class_Name
        {
            get { return mWarehouse_Class_Name; }
            set { mWarehouse_Class_Name = value; }
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