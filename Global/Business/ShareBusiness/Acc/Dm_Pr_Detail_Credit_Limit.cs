using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Pr_Detail_Credit_Limit : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private decimal mCredit_Limit;
        public decimal Credit_Limit
        {
            get { return mCredit_Limit; }
            set { mCredit_Limit = value; }
        }
        private DateTime mValid_Start_Date;
        public DateTime Valid_Start_Date
        {
            get { return mValid_Start_Date; }
            set { mValid_Start_Date = value; }
        }
        private DateTime mValid_End_Date;
        public DateTime Valid_End_Date
        {
            get { return mValid_End_Date; }
            set { mValid_End_Date = value; }
        }
        //
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
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