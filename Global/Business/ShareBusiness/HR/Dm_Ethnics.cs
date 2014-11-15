using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Ethnics : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mEthnics_Id;
        public string Ethnics_Id
        {
            get { return mEthnics_Id; }
            set { mEthnics_Id = value; }
        }
        private string mEthnics_Name;
        public string Ethnics_Name
        {
            get { return mEthnics_Name; }
            set { mEthnics_Name = value; }
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