using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Communes : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mCommunes_Id;
        public string Communes_Id
        {
            get { return mCommunes_Id; }
            set { mCommunes_Id = value; }
        }
        private string mCommunes_Name;
        public string Communes_Name
        {
            get { return mCommunes_Name; }
            set { mCommunes_Name = value; }
        }
        private string mDistrict_Id;
        public string District_Id
        {
            get { return mDistrict_Id; }
            set { mDistrict_Id = value; }
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