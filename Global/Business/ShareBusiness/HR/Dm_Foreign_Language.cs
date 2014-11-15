using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Foreign_Language : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mForeign_Language_Id;
        public string Foreign_Language_Id
        {
            get { return mForeign_Language_Id; }
            set { mForeign_Language_Id = value; }
        }
        private string mForeign_Language_Name;
        public string Foreign_Language_Name
        {
            get { return mForeign_Language_Name; }
            set { mForeign_Language_Name = value; }
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