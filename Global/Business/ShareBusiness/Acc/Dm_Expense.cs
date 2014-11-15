using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Expense : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mExpense_Class_Id;
        public string Expense_Class_Id
        {
            get { return mExpense_Class_Id; }
            set { mExpense_Class_Id = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private string mExpense_Name;
        public string Expense_Name
        {
            get { return mExpense_Name; }
            set { mExpense_Name = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
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