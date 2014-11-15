using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Budget: IHead
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
            get {return this.mIdValue;}
            set {this.mIdValue = value; }
        }

        private string mBudget_Id;
        public string Budget_Id
        {
            get { return mBudget_Id; }
            set { mBudget_Id = value; }
        }

        private string mBudget_Type_Id;
        public string Budget_Type_Id
        {
            get { return mBudget_Type_Id; }
            set { mBudget_Type_Id = value; }
        }

        private string mBudget_Name;
        public string Budget_Name
        {
            get { return mBudget_Name; }
            set { mBudget_Name = value; }
        }

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
    }
}
