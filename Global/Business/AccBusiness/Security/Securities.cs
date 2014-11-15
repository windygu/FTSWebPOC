using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Security
{
    public class Securities: IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
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

        private Guid mPr_Key_Securities = Guid.Empty;
        public Guid Pr_Key_Securities
        {
            get { return mPr_Key_Securities; }
            set { mPr_Key_Securities = value; }
        }

        private Guid mPr_key = Guid.Empty;
        public Guid Pr_key
        {
            get { return mPr_key; }
            set { mPr_key = value; }
        }

        private Guid mPr_key_detail = Guid.Empty;
        public Guid Pr_key_detail
        {
            get { return mPr_key_detail; }
            set { mPr_key_detail = value; }
        }

        private string mIssue_Receipt = string.Empty;
        public string Issue_Receipt
        {
            get { return mIssue_Receipt; }
            set { mIssue_Receipt = value; }
        }

        private string mOrganization_Id = string.Empty;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }

        private string mTran_Id = string.Empty;
        public string Tran_Id
        {
            get { return mTran_Id; }
            set { mTran_Id = value; }
        }

        private DateTime mTran_date = DateTime.Today;
        public DateTime Tran_date
        {
            get { return mTran_date; }
            set { mTran_date = value; }
        }

        private DateTime mReceipt_Date = DateTime.Today;
        public DateTime Receipt_Date
        {
            get { return mReceipt_Date; }
            set { mReceipt_Date = value; }
        }

        private string mTran_No = string.Empty;
        public string Tran_No
        {
            get { return mTran_No; }
            set { mTran_No = value; }
        }

        private string mComments = string.Empty;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }

        private string mSecuritys = string.Empty;
        public string Securitys
        {
            get { return mSecuritys; }
            set { mSecuritys = value; }
        }

        private string mAccount_ID = string.Empty;
        public string Account_ID
        {
            get { return mAccount_ID; }
            set { mAccount_ID = value; }
        }

        private string mDescription = string.Empty;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        private decimal mQuantity = 0;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }

        private decimal mUnit_Price = 0;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }

        private decimal mAmount = 0;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }

        private decimal mAmount_Xtra = 0;
        public decimal Amount_Xtra
        {
            get { return mAmount_Xtra; }
            set { mAmount_Xtra = value; }
        }

        private decimal mBook_Unit_Price = 0;
        public decimal Book_Unit_Price
        {
            get { return mBook_Unit_Price; }
            set { mBook_Unit_Price = value; }
        }

        private decimal mBook_Amount = 0;
        public decimal Book_Amount
        {
            get { return mBook_Amount; }
            set { mBook_Amount = value; }
        }

        private decimal mBook_Amount_Xtra = 0;
        public decimal Book_Amount_Xtra
        {
            get { return mBook_Amount_Xtra; }
            set { mBook_Amount_Xtra = value; }
        }
    }
}
