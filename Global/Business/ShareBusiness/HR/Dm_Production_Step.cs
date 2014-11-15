using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Production_Step : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mProduction_Step_Id;
        public string Production_Step_Id
        {
            get { return mProduction_Step_Id; }
            set { mProduction_Step_Id = value; }
        }
        private string mProduction_Step_Name;
        public string Production_Step_Name
        {
            get { return mProduction_Step_Name; }
            set { mProduction_Step_Name = value; }
        }
        private string mItem_Id;

        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private decimal mPr_Key;
        public decimal Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
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