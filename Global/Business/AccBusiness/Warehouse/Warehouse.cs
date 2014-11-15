using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Warehouse
{
    [Serializable]
    public class Warehouse : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Warehouse()
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
        private Guid mPr_Key_Warehouse;
        public Guid Pr_Key_Warehouse
        {
            get { return mPr_Key_Warehouse; }
            set { mPr_Key_Warehouse = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mPr_Key_Detail;
        public Guid Pr_Key_Detail
        {
            get { return mPr_Key_Detail; }
            set { mPr_Key_Detail = value; }
        }
        private Guid mPos_Shift_Pr_Key;
        public Guid Pos_Shift_Pr_Key {
            get { return mPos_Shift_Pr_Key; }
            set { mPos_Shift_Pr_Key = value; }
        }
        private string mIssue_Receive;
        public string Issue_Receive
        {
            get { return mIssue_Receive; }
            set { mIssue_Receive = value; }
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
        private string mVat_Tran_No;
        public string Vat_Tran_No {
            get { return mVat_Tran_No; }
            set { mVat_Tran_No = value; }
        }
        private string mComments;
        public string Comments
        {
            get { return mComments; }
            set { mComments = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mLot_No;
        public string Lot_No
        {
            get { return mLot_No; }
            set { mLot_No = value; }
        }
        private DateTime mReceive_Date;
        public DateTime Receive_Date
        {
            get { return mReceive_Date; }
            set { mReceive_Date = value; }
        }
        private DateTime mManu_Date;
        public DateTime Manu_Date
        {
            get { return mManu_Date; }
            set { mManu_Date = value; }
        }
        private int mExpired_Term;
        public int Expired_Term
        {
            get { return mExpired_Term; }
            set { mExpired_Term = value; }
        }
        private DateTime mExpired_Date;
        public DateTime Expired_Date
        {
            get { return mExpired_Date; }
            set { mExpired_Date = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mDescription_Uls;
        public string Description_Uls
        {
            get { return mDescription_Uls; }
            set { mDescription_Uls = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mQuantity_Extra;
        public decimal Quantity_Extra
        {
            get { return mQuantity_Extra; }
            set { mQuantity_Extra = value; }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mAccount_Id_Contra;
        public string Account_Id_Contra
        {
            get { return mAccount_Id_Contra; }
            set { mAccount_Id_Contra = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private decimal mJob_Qty;
        public decimal Job_Qty
        {
            get { return mJob_Qty; }
            set { mJob_Qty = value; }
        }
        private string mWarehouse_Id_Issue;
        public string Warehouse_Id_Issue
        {
            get { return mWarehouse_Id_Issue; }
            set { mWarehouse_Id_Issue = value; }
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

        private string mItem_Status_Id;
        public string Item_Status_Id {
            get { return mItem_Status_Id; }
            set { mItem_Status_Id = value; }
        }
        private string mUnit_Id_Actual;
        public string Unit_Id_Actual
        {
            get { return mUnit_Id_Actual; }
            set { mUnit_Id_Actual = value; }
        }
    }
}
