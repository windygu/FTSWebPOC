using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Sec_Permission : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mFunction_Id;
        public string Function_Id
        {
            get { return mFunction_Id; }
            set { mFunction_Id = value; }
        }
        private string mUser_Group_Id;
        public string User_Group_Id
        {
            get { return mUser_Group_Id; }
            set { mUser_Group_Id = value; }
        }
        private Int16 mIs_View;
        public Int16 Is_View
        {
            get { return mIs_View; }
            set { mIs_View = value; }
        }
        private Int16 mIs_Edit;
        public Int16 Is_Edit
        {
            get { return mIs_Edit; }
            set { mIs_Edit = value; }
        }
        private Int16 mIs_AddNew;
        public Int16 Is_AddNew
        {
            get { return mIs_AddNew; }
            set { mIs_AddNew = value; }
        }
        private Int16 mIs_Delete;
        public Int16 Is_Delete
        {
            get { return mIs_Delete; }
            set { mIs_Delete = value; }
        }
        private Int16 mIs_Execute;
        public Int16 Is_Execute
        {
            get { return mIs_Execute; }
            set { mIs_Execute = value; }
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