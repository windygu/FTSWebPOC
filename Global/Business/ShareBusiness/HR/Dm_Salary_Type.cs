using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Salary_Type : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mSalary_Type_Id;
        public string Salary_Type_Id
        {
            get { return mSalary_Type_Id; }
            set { mSalary_Type_Id = value; }
        }
        private string mSalary_Type_Name;
        public string Salary_Type_Name
        {
            get { return mSalary_Type_Name; }
            set { mSalary_Type_Name = value; }
        }
        private string mSalary_Type_Name_App;

        public string Salary_Type_Name_App
        {
            get { return mSalary_Type_Name_App; }
            set { mSalary_Type_Name_App = value; }
        }
        private Int16 mPoa;

        public Int16 Poa
        {
            get { return mPoa; }
            set { mPoa = value; }
        }
        private Int16 mIs_Si;

        public Int16 Is_Si
        {
            get { return mIs_Si; }
            set { mIs_Si = value; }
        }
        private Int16 mIs_Pit;

        public Int16 Is_Pit
        {
            get { return mIs_Pit; }
            set { mIs_Pit = value; }
        }
        private Int16 mIs_Other;

        public Int16 Is_Other
        {
            get { return mIs_Other; }
            set { mIs_Other = value; }
        }
        private Int16 mIs_Track;

        public Int16 Is_Track
        {
            get { return mIs_Track; }
            set { mIs_Track = value; }
        }
        private Int16 mIs_Driver;

        public Int16 Is_Driver
        {
            get { return mIs_Driver; }
            set { mIs_Driver = value; }
        }
        private string mMethod_Name;

        public string Method_Name
        {
            get { return mMethod_Name; }
            set { mMethod_Name = value; }
        }
        private string mTimesheet_Salary_Type_Id_By;

        public string Timesheet_Salary_Type_Id_By
        {
            get { return mTimesheet_Salary_Type_Id_By; }
            set { mTimesheet_Salary_Type_Id_By = value; }
        }
        private decimal mTimesheet_Rate;

        public decimal Timesheet_Rate
        {
            get { return mTimesheet_Rate; }
            set { mTimesheet_Rate = value; }
        }
        private string mLevel_Salary_Type_Id_By;

        public string Level_Salary_Type_Id_By
        {
            get { return mLevel_Salary_Type_Id_By; }
            set { mLevel_Salary_Type_Id_By = value; }
        }
        private decimal mLevel_Rate;

        public decimal Level_Rate
        {
            get { return mLevel_Rate; }
            set { mLevel_Rate = value; }
        }
        private string mSalary_Formula;

        public string Salary_Formula
        {
            get { return mSalary_Formula; }
            set { mSalary_Formula = value; }
        }
        private decimal mAmount_Limit;

        public decimal Amount_Limit
        {
            get { return mAmount_Limit; }
            set { mAmount_Limit = value; }
        }
        private decimal mRate;

        public decimal Rate
        {
            get { return mRate; }
            set { mRate = value; }
        }
        private Int16 mIs_Reduction;

        public Int16 Is_Reduction
        {
            get { return mIs_Reduction; }
            set { mIs_Reduction = value; }
        }
        private Int16 mIs_Overtime;

        public Int16 Is_Overtime
        {
            get { return mIs_Overtime; }
            set { mIs_Overtime = value; }
        }
        private decimal mPit_Rate;

        public decimal Pit_Rate
        {
            get { return mPit_Rate; }
            set { mPit_Rate = value; }
        }
        private int nNum_Cal;

        public int Num_Cal
        {
            get { return nNum_Cal; }
            set { nNum_Cal = value; }
        }
        private Int16 mIs_Funds;

        public Int16 Is_Funds
        {
            get { return mIs_Funds; }
            set { mIs_Funds = value; }
        }
        private Int16 mIs_Sum;

        public Int16 Is_Sum
        {
            get { return mIs_Sum; }
            set { mIs_Sum = value; }
        }

//
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
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