using FTS.Global.Interface;
using FTS.Global.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTS.Global.Business.ShareBusiness.POS
{
    public class Pos_Payment : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mPr_Key_Sale;
        public Guid Pr_Key_Sale
        {
            get { return mPr_Key_Sale; }
            set { mPr_Key_Sale = value; }
        }
        Guid mPr_Key_So;
        public Guid Pr_Key_So
        {
            get { return mPr_Key_So; }
            set { mPr_Key_So = value; }
        }
        string mPos_Payment_Type;
        public string Pos_Payment_Type
        {
            get { return mPos_Payment_Type; }
            set { mPos_Payment_Type = value; }
        }
        string mRec_Pr_Detail_Id;
        public string Rec_Pr_Detail_Id
        {
            get { return mRec_Pr_Detail_Id; }
            set { mRec_Pr_Detail_Id = value; }
        }
        DateTime mShift_Date;
        public DateTime Shift_Date
        {
            get { return mShift_Date; }
            set { mShift_Date = value; }
        }
        string mShift_Id;
        public string Shift_Id
        {
            get { return mShift_Id; }
            set { mShift_Id = value; }
        }
        string mPayment_Mothod_Id;
        public string Payment_Mothod_Id
        {
            get { return mPayment_Mothod_Id; }
            set { mPayment_Mothod_Id = value; }
        }
        string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        decimal mExchange_Rate;
        public decimal Exchange_Rate
        {
            get { return mExchange_Rate; }
            set { mExchange_Rate = value; }
        }
        decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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
