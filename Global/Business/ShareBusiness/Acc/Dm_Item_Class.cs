using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Item_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mDefault_Account_Id_Cost;
        public string Default_Account_Id_Cost
        {
            get { return mDefault_Account_Id_Cost; }
            set { mDefault_Account_Id_Cost = value; }
        }
        private string mDefault_Account_Id_Income;
        public string Default_Account_Id_Income
        {
            get { return mDefault_Account_Id_Income; }
            set { mDefault_Account_Id_Income = value; }
        }
        private string mDefault_Account_Id_Return;
        public string Default_Account_Id_Return
        {
            get { return mDefault_Account_Id_Return; }
            set { mDefault_Account_Id_Return = value; }
        }
        private string mDefault_Cost_Method;
        public string Default_Cost_Method
        {
            get { return mDefault_Cost_Method; }
            set { mDefault_Cost_Method = value; }
        }
        private string mItem_Class_Id;
        public string Item_Class_Id
        {
            get { return mItem_Class_Id; }
            set { mItem_Class_Id = value; }
        }
        private string mItem_Class_Name;
        public string Item_Class_Name
        {
            get { return mItem_Class_Name; }
            set { mItem_Class_Name = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mItem_Class_Color;
        public string Item_Class_Color
        {
            get { return mItem_Class_Color; }
            set { mItem_Class_Color = value; }
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