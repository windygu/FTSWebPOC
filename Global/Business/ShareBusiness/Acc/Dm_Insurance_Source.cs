using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.Acc
{
    public class Dm_Insurance_Source: IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mInsurance_Source_ID;

        public string Insurance_Source_ID
        {
            get { return mInsurance_Source_ID; }
            set { mInsurance_Source_ID = value; }
        }
        private string mInsurance_Source_Name;

        public string Insurance_Source_Name
        {
            get { return mInsurance_Source_Name; }
            set { mInsurance_Source_Name = value; }
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
