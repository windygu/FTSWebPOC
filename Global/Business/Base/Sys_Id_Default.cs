using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sys_Id_Default : IHead
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mDefault_Value;
        public string Default_Value
        {
            get { return mDefault_Value; }
            set { mDefault_Value = value; }
        }
        private Int16 mAllow_New_Value;
        public Int16 Allow_New_Value
        {
            get { return mAllow_New_Value; }
            set { mAllow_New_Value = value; }
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