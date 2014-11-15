using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Payment_Account:IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mSource_Account_Id;
        public string Source_Account_Id
        {
            get { return mSource_Account_Id; }
            set { mSource_Account_Id = value; }
        }
        private string mField_List;
        public string Field_List
        {
            get { return mField_List; }
            set { mField_List = value; }
        }
        private Int16 mIs_Pr_Detail;
        public Int16 Is_Pr_Detail
        {
            get { return mIs_Pr_Detail; }
            set { mIs_Pr_Detail = value; }
        }
        private Int16 mIs_Department;
        public Int16 Is_Department
        {
            get { return mIs_Department; }
            set { mIs_Department = value; }
        }
        private Int16 mIs_Dealer;
        public Int16 Is_Dealer
        {
            get { return mIs_Dealer; }
            set { mIs_Dealer = value; }
        }
        private Int16 mIs_Insurance_Source;
        public Int16 Is_Insurance_Source
        {
            get { return mIs_Insurance_Source; }
            set { mIs_Insurance_Source = value; }
        }
        private Int16 mIs_Employee;
        public Int16 Is_Employee
        {
            get { return mIs_Employee; }
            set { mIs_Employee = value; }
        }
        private Int16 mIs_By_Tax;
        public Int16 Is_By_Tax
        {
            get { return mIs_By_Tax; }
            set { mIs_By_Tax = value; }
        }
        private string mDebit_Credit;
        public string Debit_Credit
        {
            get { return mDebit_Credit; }
            set { mDebit_Credit = value; }
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
