using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Dm_Idchange : IHead
    {
        private string mTable_Name;
        public string Table_Name
        {
            get { return mTable_Name; }
            set { mTable_Name = value; }
        }
        private string mOld_Id;
        public string Old_Id
        {
            get { return mOld_Id; }
            set { mOld_Id = value; }
        }
        private string mNew_Id;
        public string New_Id
        {
            get { return mNew_Id; }
            set { mNew_Id = value; }
        }      
        #region IHead Members

        DataState mDataState = DataState.NONE;
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
        object mIdValue = string.Empty;
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