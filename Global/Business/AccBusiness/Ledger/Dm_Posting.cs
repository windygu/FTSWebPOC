using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Dm_Posting : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

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
        private DateTime mDay_Start;
        public DateTime Day_Start
        {
            get { return mDay_Start; }
            set { mDay_Start = value; }
        }
        private DateTime mDay_End;
        public DateTime Day_End
        {
            get { return mDay_End; }
            set { mDay_End = value; }
        }
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id
        {
            get { return mItem_Source_Id; }
            set { mItem_Source_Id = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mItem_Class_Id;
        public string Item_Class_Id
        {
            get { return mItem_Class_Id; }
            set { mItem_Class_Id = value; }
        }
        private string mPr_Detail_Class_Id;
        public string Pr_Detail_Class_Id
        {
            get { return mPr_Detail_Class_Id; }
            set { mPr_Detail_Class_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mWarehouse_Class_Id;
        public string Warehouse_Class_Id
        {
            get { return mWarehouse_Class_Id; }
            set { mWarehouse_Class_Id = value; }
        }
        private string mIssue_Receive;
        public string Issue_Receive
        {
            get { return mIssue_Receive; }
            set { mIssue_Receive = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private Int16 mNot_Item_Id;
        public Int16 Not_Item_Id {
            get { return mNot_Item_Id; }
            set { mNot_Item_Id = value; }
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