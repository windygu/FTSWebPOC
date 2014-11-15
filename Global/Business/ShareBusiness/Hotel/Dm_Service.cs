using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTS.Global.Classes;
using FTS.Global.Interface;

namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Service : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;        
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mService_Id;
        public string Service_Id
        {
            get { return mService_Id; }
            set { mService_Id = value; }
        }
        private string mService_Name;
        public string Service_Name
        {
            get { return mService_Name; }
            set { mService_Name = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private Int16 mIs_Vat;
        public Int16 Is_Vat
        {
            get { return mIs_Vat; }
            set { mIs_Vat = value; }
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
