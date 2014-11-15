using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Marital_Status : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mMarital_Status_Id;
        public string Marital_Status_Id
        {
            get { return mMarital_Status_Id; }
            set { mMarital_Status_Id = value; }
        }
        private string mMarital_Status_Name;
        public string Marital_Status_Name
        {
            get { return mMarital_Status_Name; }
            set { mMarital_Status_Name = value; }
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