
using System;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.PosBusiness
{
    public class Pos_Shift : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mNext_Pr_Key;
        public Guid Next_Pr_Key
        {
            get { return mNext_Pr_Key; }
            set { mNext_Pr_Key = value; }
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
        private string mTran_No;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }
        private string mShift_Id;
        public string Shift_Id
        {
            get { return mShift_Id; }
            set { mShift_Id = value; }
        }
        private DateTime mShift_Date;
        public DateTime Shift_Date
        {
            get { return mShift_Date; }
            set { mShift_Date = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
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
