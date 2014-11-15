﻿using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Pr_Detail_Class : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mPr_Detail_Class_Id;
        public string Pr_Detail_Class_Id
        {
            get { return mPr_Detail_Class_Id; }
            set { mPr_Detail_Class_Id = value; }
        }
        private string mPr_Detail_Class_Name;
        public string Pr_Detail_Class_Name
        {
            get { return mPr_Detail_Class_Name; }
            set { mPr_Detail_Class_Name = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mPr_Detail_Type_Id;
        public string Pr_Detail_Type_Id {
            get { return mPr_Detail_Type_Id; }
            set { mPr_Detail_Type_Id = value; }
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