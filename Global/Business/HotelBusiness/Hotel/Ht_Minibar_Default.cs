using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.HotelBusiness.Hotel
{
    [Serializable]
    public class Ht_Minibar_Default : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }        
        private string mRoom_Class_Id;
        public string Room_Class_Id
        {
            get { return mRoom_Class_Id; }
            set { mRoom_Class_Id = value; }
        }        
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Name;
        public string Item_Name
        {
            get { return mItem_Name; }
            set { mItem_Name = value; }
        }
        private decimal mQuantity_Default;
        public decimal Quantity_Default
        {
            get { return mQuantity_Default; }
            set { mQuantity_Default = value; }
        }
        private decimal mQuantity_Use;
        public decimal Quantity_Use
        {
            get { return mQuantity_Use; }
            set { mQuantity_Use = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
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