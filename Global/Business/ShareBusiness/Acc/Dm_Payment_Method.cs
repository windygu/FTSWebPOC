using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Payment_Method : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mPayment_Method_Id;
        public string Payment_Method_Id
        {
            get { return mPayment_Method_Id; }
            set { mPayment_Method_Id = value; }
        }
        private string mPayment_Method_Name;
        public string Payment_Method_Name
        {
            get { return mPayment_Method_Name; }
            set { mPayment_Method_Name = value; }
        }
        private string mPayment_Account_Id;
        public string Payment_Account_Id
        {
            get { return mPayment_Account_Id; }
            set { mPayment_Account_Id = value; }
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