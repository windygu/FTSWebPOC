using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Hospital : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mHospital_Id;
        public string Hospital_Id
        {
            get { return mHospital_Id; }
            set { mHospital_Id = value; }
        }
        private string mHospital_Name;
        public string Hospital_Name
        {
            get { return mHospital_Name; }
            set { mHospital_Name = value; }
        }
        private string mHospital_Address;
        public string Hospital_Address
        {
            get { return mHospital_Address; }
            set { mHospital_Address = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
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