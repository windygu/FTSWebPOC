using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Hotel
{
    [Serializable]
    public class Dm_Nationality : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mNationality_Id;
        public string Nationality_Id
        {
            get { return mNationality_Id; }
            set { mNationality_Id = value; }
        }
        private string mNationality_Name;
        public string Nationality_Name
        {
            get { return mNationality_Name; }
            set { mNationality_Name = value; }
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