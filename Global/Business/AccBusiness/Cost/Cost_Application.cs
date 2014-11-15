
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Cost
{
    [Serializable]
    public class Cost_Application : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Cost_Application()
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
        private string mCost_Application_Id;
        public string Cost_Application_Id
        {
            get { return mCost_Application_Id; }
            set { mCost_Application_Id = value; }
        }
        private string mCost_Application_Name;
        public string Cost_Application_Name
        {
            get { return mCost_Application_Name; }
            set { mCost_Application_Name = value; }
        }
        private Int16 mBy_Transfer;
        public Int16 By_Transfer
        {
            get { return mBy_Transfer; }
            set { mBy_Transfer = value; }
        }
        private Int16 mBy_Account;
        public Int16 By_Account
        {
            get { return mBy_Account; }
            set { mBy_Account = value; }
        }
        private Int16 mBy_Ratio;
        public Int16 By_Ratio
        {
            get { return mBy_Ratio; }
            set { mBy_Ratio = value; }
        }
        private string mDebit_Credit;
        public string Debit_Credit
        {
            get { return mDebit_Credit; }
            set { mDebit_Credit = value; }
        }
        private string mAccount_Id_List;
        public string Account_Id_List
        {
            get { return mAccount_Id_List; }
            set { mAccount_Id_List = value; }
        }
        private string mAccount_Id_Contra_List;
        public string Account_Id_Contra_List
        {
            get { return mAccount_Id_Contra_List; }
            set { mAccount_Id_Contra_List = value; }
        }
        private string mExpense_Id_List;
        public string Expense_Id_List
        {
            get { return mExpense_Id_List; }
            set { mExpense_Id_List = value; }
        }
        private string mExpense_Class_Id_List;
        public string Expense_Class_Id_List
        {
            get { return mExpense_Class_Id_List; }
            set { mExpense_Class_Id_List = value; }
        }
        private string mJob_Id_List;
        public string Job_Id_List
        {
            get { return mJob_Id_List; }
            set { mJob_Id_List = value; }
        }
        private string mJob_Class_Id_List;
        public string Job_Class_Id_List
        {
            get { return mJob_Class_Id_List; }
            set { mJob_Class_Id_List = value; }
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
        private string mDes_Account_Id;
        public string Des_Account_Id
        {
            get { return mDes_Account_Id; }
            set { mDes_Account_Id = value; }
        }
        private Int16 mBy_Item_Ratio;
        public Int16 By_Item_Ratio
        {
            get { return mBy_Item_Ratio; }
            set { mBy_Item_Ratio = value; }
        }


    }
}