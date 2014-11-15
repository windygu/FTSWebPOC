using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Certification : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mCertificatio_Id;
        public string Certificatio_Id
        {
            get { return mCertificatio_Id; }
            set { mCertificatio_Id = value; }
        }
        private string mCertificatio_Name;
        public string Certificatio_Name
        {
            get { return mCertificatio_Name; }
            set { mCertificatio_Name = value; }
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