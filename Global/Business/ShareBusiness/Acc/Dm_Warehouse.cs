using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Warehouse : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mWarehouse_Name;
        public string Warehouse_Name
        {
            get { return mWarehouse_Name; }
            set { mWarehouse_Name = value; }
        }
        private string mWarehouse_Class_Id;
        public string Warehouse_Class_Id
        {
            get { return mWarehouse_Class_Id; }
            set { mWarehouse_Class_Id = value; }
        }
        private string mRoom_Id;
        public string Room_Id
        {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
        private string mCost_Account_Id;
        public string Cost_Account_Id {
            get { return mCost_Account_Id; }
            set { mCost_Account_Id = value; }
        }
        private string mSale_Cost_Account_Id;
        public string Sale_Cost_Account_Id {
            get { return mSale_Cost_Account_Id; }
            set { mSale_Cost_Account_Id = value; }
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