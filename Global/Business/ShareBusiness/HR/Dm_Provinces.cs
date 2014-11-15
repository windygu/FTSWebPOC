﻿using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Provinces : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mProvince_Id;
        public string Province_Id
        {
            get
            {
                return mProvince_Id;
            }
            set
            {
                mProvince_Id = value;
            }
        }
        private string mProvince_Name;
        public string Province_Name
        {
            get
            {
                return mProvince_Name;
            }
            set
            {
                mProvince_Name = value;
            }
        }
        private string mUser_Id;
        public string User_Id
        {
            get
            {
                return mUser_Id;
            }
            set
            {
                mUser_Id = value;
            }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get
            {
                return mActive;
            }
            set
            {
                mActive = value;
            }
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