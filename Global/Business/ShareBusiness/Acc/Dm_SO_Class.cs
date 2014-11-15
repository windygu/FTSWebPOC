using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_SO_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mSo_Class_Id;
        public string So_Class_Id
        {
            get { return mSo_Class_Id; }
            set { mSo_Class_Id = value; }
        }
        private string mSo_Class_Name;
        public string So_Class_Name
        {
            get { return mSo_Class_Name; }
            set { mSo_Class_Name = value; }
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

        //Tân sửa PJICO
        private string mPrints_Id_List;
        public string Prints_Id_List
        {
            get { return mPrints_Id_List; }
            set { mPrints_Id_List = value; }
        }

        private string mItem_Id_List;
        public string Item_Id_List
        {
            get { return mItem_Id_List; }
            set { mItem_Id_List = value; }
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