using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Account : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private string mAccount_Name;
        public string Account_Name
        {
            get { return mAccount_Name; }
            set { mAccount_Name = value; }
        }
        private string mAccount_Name_Uls;
        public string Account_Name_Uls
        {
            get { return mAccount_Name_Uls; }
            set { mAccount_Name_Uls = value; }
        }
        private int mAccount_Level;
        public int Account_Level
        {
            get { return mAccount_Level; }
            set { mAccount_Level = value; }
        }
        private Int16 mIs_Parent;
        public Int16 Is_Parent
        {
            get { return mIs_Parent; }
            set { mIs_Parent = value; }
        }
        private Int16 mIs_Pr_Detail;
        public Int16 Is_Pr_Detail
        {
            get { return mIs_Pr_Detail; }
            set { mIs_Pr_Detail = value; }
        }
        private Int16 mIs_Expense;
        public Int16 Is_Expense
        {
            get { return mIs_Expense; }
            set { mIs_Expense = value; }
        }
        private Int16 mIs_Job;
        public Int16 Is_Job
        {
            get { return mIs_Job; }
            set { mIs_Job = value; }
        }
        private Int16 mIs_Item;
        public Int16 Is_Item
        {
            get { return mIs_Item; }
            set { mIs_Item = value; }
        }
        private Int16 mIs_Vat;
        public Int16 Is_Vat
        {
            get { return mIs_Vat; }
            set { mIs_Vat = value; }
        }
        private Int16 mIs_Oob;
        public Int16 Is_Oob
        {
            get { return mIs_Oob; }
            set { mIs_Oob = value; }
        }
        private string mBalance_Type;
        public string Balance_Type
        {
            get { return mBalance_Type; }
            set { mBalance_Type = value; }
        }
        private string mBank_Name;
        public string Bank_Name
        {
            get { return mBank_Name; }
            set { mBank_Name = value; }
        }
        private string mBank_Branch;
        public string Bank_Branch
        {
            get { return mBank_Branch; }
            set { mBank_Branch = value; }
        }
        private string mBank_Account;
        public string Bank_Account
        {
            get { return mBank_Account; }
            set { mBank_Account = value; }
        }
        private string mVoucher_File_Name;
        public string Voucher_File_Name
        {
            get { return mVoucher_File_Name; }
            set { mVoucher_File_Name = value; }
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
        private string mAccount_Type_Id;
        public string Account_Type_Id
        {
            get { return mAccount_Type_Id; }
            set { mAccount_Type_Id = value; }
        }
        private string mParent_Account_Id;
        public string Parent_Account_Id
        {
            get { return mParent_Account_Id; }
            set { mParent_Account_Id = value; }
        }
        private string mCurrency_Id;
        public string Currency_Id
        {
            get { return mCurrency_Id; }
            set { mCurrency_Id = value; }
        }
        private string mRate_Method;
        public string Rate_Method
        {
            get { return mRate_Method; }
            set { mRate_Method = value; }
        }
        private string mAccount_Id_Uls;
        public string Account_Id_Uls
        {
            get { return mAccount_Id_Uls; }
            set { mAccount_Id_Uls = value; }
        }
        private string mAccount_Name_Jp;
        public string Account_Name_Jp
        {
            get { return mAccount_Name_Jp; }
            set { mAccount_Name_Jp = value; }
        }
        private string mAccount_Name_Kr;
        public string Account_Name_Kr
        {
            get { return mAccount_Name_Kr; }
            set { mAccount_Name_Kr = value; }
        }
        private Int16 mIs_Quantity;
        public Int16 Is_Quantity
        {
            get { return mIs_Quantity; }
            set { mIs_Quantity = value; }
        }
        private Int16 mIs_Payment;
        public Int16 Is_Payment
        {
            get { return mIs_Payment; }
            set { mIs_Payment = value; }
        }
        private Int16 mIs_Bank;
        public Int16 Is_Bank
        {
            get { return mIs_Bank; }
            set { mIs_Bank = value; }
        }
        private Int16 mIs_Pos;
        public Int16 Is_Pos {
            get { return mIs_Pos; }
            set { mIs_Pos = value; }
        }

		private Int16 mIs_Check;
        public Int16 Is_Check {
            get { return mIs_Check; }
            set { mIs_Check = value; }
        }
        private Int16 mIs_Chapter;
        public Int16 Is_Chapter {
            get { return mIs_Chapter; }
            set { mIs_Chapter = value; }
        }
        private Int16 mIs_Capital_Source;

        public Int16 Is_Capital_Source {
            get { return mIs_Capital_Source; }
            set { mIs_Capital_Source = value; }
        }

        //Tân sửa PJICO
        private Int16 mIs_Dealer;
        public Int16 Is_Dealer
        {
            get { return mIs_Dealer; }
            set { mIs_Dealer = value; }
        }
        private Int16 mIs_Department;
        public Int16 Is_Department
        {
            get { return mIs_Department; }
            set { mIs_Department = value; }
        }
        private Int16 mIs_Employee;
        public Int16 Is_Employee
        {
            get { return mIs_Employee; }
            set { mIs_Employee = value; }
        }
        private Int16 mIs_Insurance_Source;
        public Int16 Is_Insurance_Source
        {
            get { return mIs_Insurance_Source; }
            set { mIs_Insurance_Source = value; }
        }
        private Int16 mIs_Contract;
        public Int16 Is_Contract {
            get { return mIs_Contract; }
            set { mIs_Contract = value; }
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