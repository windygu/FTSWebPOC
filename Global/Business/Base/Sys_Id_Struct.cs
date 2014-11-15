using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sys_Id_Struct : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mTable_Name;
        public string Table_Name
        {
            get { return mTable_Name; }
            set { mTable_Name = value; }
        }
        private Int32 mPart_Id;
        public Int32 Part_Id
        {
            get { return mPart_Id; }
            set { mPart_Id = value; }
        }
        private Int32 mPart_Length;
        public Int32 Part_Length
        {
            get { return mPart_Length; }
            set { mPart_Length = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return this.mPr_Key; }
            set { this.mPr_Key = value; }
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