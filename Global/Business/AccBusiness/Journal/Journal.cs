using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Journal
{
    [Serializable]
    public class Journal : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Journal()
        {
        }
        public DataState DataState
        {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }
        public object IdValue
        {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mTran_Id;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }
        private DateTime mTran_Date;
        public DateTime Tran_Date
        {
            get { return mTran_Date; }
            set { mTran_Date = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private string mReference_No;
        public string Reference_No
        {
            get { return mReference_No; }
            set { mReference_No = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mStatus;
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
    }
}
