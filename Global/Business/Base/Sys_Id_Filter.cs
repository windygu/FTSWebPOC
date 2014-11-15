using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sys_Id_Filter : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mTable_Name;
        public string Table_Name
        {
            get { return mTable_Name; }
            set { mTable_Name = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mRegular_Expression;
        public string Regular_Expression
        {
            get { return mRegular_Expression; }
            set { mRegular_Expression = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key {
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