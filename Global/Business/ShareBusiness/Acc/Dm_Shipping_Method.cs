using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Shipping_Method : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mShipping_Method_Id;
        public string Shipping_Method_Id
        {
            get { return mShipping_Method_Id; }
            set { mShipping_Method_Id = value; }
        }
        private string mShipping_Method_Name;
        public string Shipping_Method_Name
        {
            get { return mShipping_Method_Name; }
            set { mShipping_Method_Name = value; }
        }
        private string mShipping_Method_Type;
        public string Shipping_Method_Type
        {
            get { return mShipping_Method_Type; }
            set { mShipping_Method_Type = value; }
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