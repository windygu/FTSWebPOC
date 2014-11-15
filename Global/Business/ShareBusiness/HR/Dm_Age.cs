using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Age : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mAge_Id;
        public string Age_Id
        {
            get { return mAge_Id; }
            set { mAge_Id = value; }
        }
        private string mAge_Name;
        public string Age_Name
        {
            get { return mAge_Name; }
            set { mAge_Name = value; }
        }
        private int mAge_Min;
        public int Age_Min
        {
            get { return mAge_Min; }
            set { mAge_Min = value; }
        }
        private int mAge_Max;
        public int Age_Max
        {
            get { return mAge_Max; }
            set { mAge_Max = value; }
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