using System;
using FTS.Global.Classes;
using FTS.Global.Interface;

namespace FTS.Global.Business.PosBusiness {
    public class Prints : IHead {
        
        private DataState mDataState = DataState.NONE;
        private object mIdValue = string.Empty;
        

        private Guid mPr_Key;
        public Guid Pr_Key {
            get { return this.mPr_Key; }
            set { this.mPr_Key = value; }
        }

        private Guid mPr_Key_Prints;
        public Guid Pr_Key_Prints {
            get { return this.mPr_Key_Prints; }
            set { this.mPr_Key_Prints = value; }
        }

        private Guid mPr_Key_Detail;
        public Guid Pr_Key_Detail {
            get { return this.mPr_Key_Detail; }
            set { this.mPr_Key_Detail = value; }
        }

        private string mTran_Id;
        public string Tran_Id {
            get { return this.mTran_Id; }
            set { this.mTran_Id = value; }
        }

        private string mTran_No;
        public string Tran_No {
            get { return this.mTran_No; }
            set { this.mTran_No = value; }
        }

        private DateTime mTran_Date;
        public DateTime Tran_Date {
            get { return this.mTran_Date; }
            set { this.mTran_Date = value; }
        }

        private string mWarehouse_Id;
        public string Warehouse_Id {
            get { return this.mWarehouse_Id; }
            set { this.mWarehouse_Id = value; }
        }

        private string mOrganization_Id;
        public string Organization_Id {
            get { return this.mOrganization_Id; }
            set { this.mOrganization_Id = value; }
        }

        private string mEmployee_Id;
        public string Employee_Id {
            get { return this.mEmployee_Id; }
            set { this.mEmployee_Id = value; }
        }

        private string mComments;
        public string Comments {
            get { return this.mComments; }
            set { this.mComments = value; }
        }

        private string mPrints_Id;
        public string Prints_Id {
            get { return this.mPrints_Id; }
            set { this.mPrints_Id = value; }
        }

        private string mBatch_No;
        public string Batch_No {
            get { return this.mBatch_No; }
            set { this.mBatch_No = value; }
        }

        private int mSeri_Start;
        public int Seri_Start {
            get { return mSeri_Start; }
            set { mSeri_Start = value; }
        }
        private int mSeri_End;
        public int Seri_End {
            get { return mSeri_End; }
            set { mSeri_End = value; }
        }
        private int mSeri_Quantity;
        public int Seri_Quantity {
            get { return mSeri_Quantity; }
            set { mSeri_Quantity = value; }
        }

        private string mIssue_Receive;
        public string Issue_Receive {
            get { return this.mIssue_Receive; }
            set { this.mIssue_Receive = value; }
        }

        private string mExport_Type_Id;
        public string Export_Type_Id {
            get { return this.mExport_Type_Id; }
            set { this.mExport_Type_Id = value; }
        }

        private string mPrints_Serie;
        public string Prints_Serie {
            get { return this.mPrints_Serie; }
            set { this.mPrints_Serie = value; }
        }

        private string mAccount_Id;
        public string Account_Id
        {
            get { return this.mAccount_Id; }
            set { this.mAccount_Id = value; }
        }

        private string mAccount_Id_Contra;
        public string Account_Id_Contra
        {
            get { return this.mAccount_Id_Contra; }
            set { this.mAccount_Id_Contra = value; }
        }

        private string mQuantity;
        public string Quantity
        {
            get { return this.mQuantity; }
            set { this.mQuantity = value; }
        }

        private string mUnit_Id;
        public string Unit_Id
        {
            get { return this.mUnit_Id; }
            set { this.mUnit_Id = value; }
        }

        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return this.mUnit_Price; }
            set { this.mUnit_Price = value; }
        }

        private string mAmount;
        public string Amount
        {
            get { return this.mAmount; }
            set { this.mAmount = value; }
        }

        private DateTime mReceipt_Date;
        public DateTime Receipt_Date
        {
            get { return this.mReceipt_Date; }
            set { this.mReceipt_Date = value; }
        }

        private string mDepartment_Id;
        public string Department_Id
        {
            get { return this.mDepartment_Id; }
            set { this.mDepartment_Id = value; }
        }

        private string mDealer_Id;
        public string Dealer_Id
        {
            get { return this.mDealer_Id; }
            set { this.mDealer_Id = value; }
        }

        private int mSeri_No_Old;
        public int Seri_No_Old
        {
            get { return mSeri_No_Old; }
            set { mSeri_No_Old = value; }
        }

        private string mPrints_Serie_Old;
        public string Prints_Serie_Old
        {
            get { return this.mPrints_Serie_Old; }
            set { this.mPrints_Serie_Old = value; }
        }

        private int mBatch_Quantity;
        public int Batch_Quantity
        {
            get { return mBatch_Quantity; }
            set { mBatch_Quantity = value; }
        }
        #region IHead Members

        public DataState DataState {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }

        public object IdValue {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }

        #endregion
    }
}