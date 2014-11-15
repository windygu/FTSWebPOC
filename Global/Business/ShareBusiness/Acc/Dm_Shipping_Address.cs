using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Shipping_Address : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
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
        private string mPr_Detail_Id;
        public string Pr_Detail_Id {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mProvince_Id;
        public string Province_Id {
            get { return mProvince_Id; }
            set { mProvince_Id = value; }
        }

       private string mAddress_No;
        public string Address_No {
            get { return mAddress_No; }
            set { mAddress_No = value; }
        }
        private string mAddress_Lot;
        public string Address_Lot {
            get { return mAddress_Lot; }
            set { mAddress_Lot = value; }
        }
        private string mStreet_Name;
        public string Street_Name {
            get { return mStreet_Name; }
            set { mStreet_Name = value; }
        }
        private string mIndustrial_Zone;
        public string Industrial_Zone {
            get { return mIndustrial_Zone; }
            set { mIndustrial_Zone = value; }
        }
        private string mCommune;
        public string Commune {
            get { return mCommune; }
            set { mCommune = value; }
        }
        private string mDistrict_Id;
        public string District_Id {
            get { return mDistrict_Id; }
            set { mDistrict_Id = value; }
        }
        private string mRegion_Id;
        public string Region_Id {
            get { return mRegion_Id; }
            set { mRegion_Id = value; }
        }
        private string mAddress;
        public string Address {
            get { return mAddress; }
            set { mAddress = value; }
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