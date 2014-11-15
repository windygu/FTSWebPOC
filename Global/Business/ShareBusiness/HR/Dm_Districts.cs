using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Districts : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mDistrict_Id;
        public string District_Id
        {
            get { return mDistrict_Id; }
            set { mDistrict_Id = value; }
        }
        private string mDistrict_Name;
        public string District_Name
        {
            get { return mDistrict_Name; }
            set { mDistrict_Name = value; }
        }
        private string mProvince_Id;
        public string Province_Id
        {
            get { return mProvince_Id; }
            set { mProvince_Id = value; }
        }
//
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