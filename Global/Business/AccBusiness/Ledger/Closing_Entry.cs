
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Ledger
{
    [Serializable]
    public class Closing_Entry : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Closing_Entry()
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
        private string mEntry_No;
        public string Entry_No
        {
            get { return mEntry_No; }
            set { mEntry_No = value; }
        }
        private string mEntry_Name;
        public string Entry_Name
        {
            get { return mEntry_Name; }
            set { mEntry_Name = value; }
        }
        private int mEntry_Order;
        public int Entry_Order
        {
            get { return mEntry_Order; }
            set { mEntry_Order = value; }
        }
        private string mAccount_Src;
        public string Account_Src
        {
            get { return mAccount_Src; }
            set { mAccount_Src = value; }
        }
        private string mAccount_Des;
        public string Account_Des
        {
            get { return mAccount_Des; }
            set { mAccount_Des = value; }
        }
        private string mTransfer_Method;
        public string Transfer_Method
        {
            get { return mTransfer_Method; }
            set { mTransfer_Method = value; }
        }
        private Int16 mBy_Pr_Detail;
        public Int16 By_Pr_Detail
        {
            get { return mBy_Pr_Detail; }
            set { mBy_Pr_Detail = value; }
        }
        private Int16 mBy_Expense;
        public Int16 By_Expense
        {
            get { return mBy_Expense; }
            set { mBy_Expense = value; }
        }
        private Int16 mBy_Job;
        public Int16 By_Job
        {
            get { return mBy_Job; }
            set { mBy_Job = value; }
        }
        private Int16 mBy_Item;
        public Int16 By_Item
        {
            get { return mBy_Item; }
            set { mBy_Item = value; }
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


    }
}