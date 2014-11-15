using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Warehouse_Mapping : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }        
        private string mItem_Class_Id;
        public string Item_Class_Id
        {
            get { return mItem_Class_Id; }
            set { mItem_Class_Id = value; }
        }        
        private Int32 mWorkstation_Id;
        public Int32 Workstation_Id
        {
            get { return mWorkstation_Id; }
            set { mWorkstation_Id = value; }
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