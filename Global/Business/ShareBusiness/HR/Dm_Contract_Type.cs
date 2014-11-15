using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Contract_Type : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mContract_Type_Id;
        public string Contract_Type_Id
        {
            get { return mContract_Type_Id; }
            set { mContract_Type_Id = value; }
        }
        private string mContract_Type_Name;
        public string Contract_Type_Name
        {
            get { return mContract_Type_Name; }
            set { mContract_Type_Name = value; }
        }
        private Int16 mOrder_Number;
        public Int16 Order_Number
        {
            get { return mOrder_Number; }
            set { mOrder_Number = value; }
        }
        private Int16 mI_Official;
        public Int16 I_Official
        {
            get { return mI_Official; }
            set { mI_Official = value; }
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