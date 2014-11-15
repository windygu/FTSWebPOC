using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Payment_Term : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;


        private string mPayment_Term_Id;
        public string Payment_Term_Id
        {
            get { return mPayment_Term_Id; }
            set { mPayment_Term_Id = value; }
        }
        private string mPayment_Term_Name;
        public string Payment_Term_Name
        {
            get { return mPayment_Term_Name; }
            set { mPayment_Term_Name = value; }
        }
        private string mDue_Date_Type;
        public string Due_Date_Type
        {
            get { return mDue_Date_Type; }
            set { mDue_Date_Type = value; }
        }
        private int mDue_Days;
        public int Due_Days
        {
            get { return mDue_Days; }
            set { mDue_Days = value; }
        }
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
        }
        private string mDiscount_Date_Type;
        public string Discount_Date_Type
        {
            get { return mDiscount_Date_Type; }
            set { mDiscount_Date_Type = value; }
        }
        private int mDiscount_Days;
        public int Discount_Days
        {
            get { return mDiscount_Days; }
            set { mDiscount_Days = value; }
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