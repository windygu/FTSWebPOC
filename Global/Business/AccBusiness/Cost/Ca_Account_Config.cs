
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Cost
{
    [Serializable]
    public class Ca_Account_Config : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Ca_Account_Config()
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
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
        private Int16 mBy_Account_Contra;
        public Int16 By_Account_Contra
        {
            get { return mBy_Account_Contra; }
            set { mBy_Account_Contra = value; }
        }
        private Int16 mBy_Pr_Detail;
        public Int16 By_Pr_Detail
        {
            get { return mBy_Pr_Detail; }
            set { mBy_Pr_Detail = value; }
        }
        private Int16 mBy_Item;
        public Int16 By_Item
        {
            get { return mBy_Item; }
            set { mBy_Item = value; }
        }
        private Int16 mBy_Quantity;
        public Int16 By_Quantity
        {
            get { return mBy_Quantity; }
            set { mBy_Quantity = value; }
        }


    }
}