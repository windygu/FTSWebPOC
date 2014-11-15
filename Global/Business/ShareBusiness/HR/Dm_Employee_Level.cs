using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Employee_Level : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mEmployee_Level_Id;
        public string Employee_Level_Id
        {
            get { return mEmployee_Level_Id; }
            set { mEmployee_Level_Id = value; }
        }
        private string mEmployee_Level_Name;
        public string Employee_Level_Name
        {
            get { return mEmployee_Level_Name; }
            set { mEmployee_Level_Name = value; }
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