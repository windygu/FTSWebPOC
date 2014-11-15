using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Job : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private string mJob_Name;
        public string Job_Name
        {
            get { return mJob_Name; }
            set { mJob_Name = value; }
        }
        private string mJob_Class_Id;
        public string Job_Class_Id
        {
            get { return mJob_Class_Id; }
            set { mJob_Class_Id = value; }
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
        private string mPartner_Id;
        public string Partner_Id
        {
            get { return mPartner_Id; }
            set { mPartner_Id = value; }
        }
        private decimal mJob_Value;
        public decimal Job_Value
        {
            get { return mJob_Value; }
            set { mJob_Value = value; }
        }
        private decimal mShare_Rate;
        public decimal Share_Rate
        {
            get { return mShare_Rate; }
            set { mShare_Rate = value; }
        }
        private string mContract_No;
        public string Contract_No
        {
            get { return mContract_No; }
            set { mContract_No = value; }
        }
        private string mPr_Detail_Id;
        public string Pr_Detail_Id
        {
            get { return mPr_Detail_Id; }
            set { mPr_Detail_Id = value; }
        }
        private string mJob_Name_En;
        public string Job_Name_En
        {
            get { return mJob_Name_En; }
            set { mJob_Name_En = value; }
        }
        private Int16 mBudget_By_Period;
        public Int16 Budget_By_Period
        {
            get { return mBudget_By_Period; }
            set { mBudget_By_Period = value; }
        }
        private Int16 mRequire_Quantity;
        public Int16 Require_Quantity
        {
            get { return mRequire_Quantity; }
            set { mRequire_Quantity = value; }
        }
        private string mExpense_Account_Id;
        public string Expense_Account_Id {
            get { return mExpense_Account_Id; }
            set { mExpense_Account_Id = value; }
        }
        private Int16 mIs_Parent;
        public Int16 Is_Parent {
            get { return mIs_Parent; }
            set { mIs_Parent = value; }
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