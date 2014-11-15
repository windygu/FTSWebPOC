using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.HR
{
    [Serializable]
    public class Dm_Pr_Hr_Organization : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private string mPr_Organization_ID;

        public string Pr_Organization_ID
        {
            get { return mPr_Organization_ID; }
            set { mPr_Organization_ID = value; }
        }
        private string mPr_Organization_Name;

        public string Pr_Organization_Name
        {
            get { return mPr_Organization_Name; }
            set { mPr_Organization_Name = value; }
        }
        private string mPr_Parent_Organization_Id;

        public string Pr_Parent_Organization_Id
        {
            get { return mPr_Parent_Organization_Id; }
            set { mPr_Parent_Organization_Id = value; }
        }

        private string mPr_List_Parent_Organization_Id;

        public string Pr_List_Parent_Organization_Id
        {
            get { return mPr_List_Parent_Organization_Id; }
            set { mPr_List_Parent_Organization_Id = value; }
        }
        private string mPr_List_Child_Organization_Id;

        public string Pr_List_Child_Organization_Id
        {
            get { return mPr_List_Child_Organization_Id; }
            set { mPr_List_Child_Organization_Id = value; }
        }
        private string mPr_Address;

        public string Pr_Address
        {
            get { return mPr_Address; }
            set { mPr_Address = value; }
        }
        private string mPr_City;

        public string Pr_City
        {
            get { return mPr_City; }
            set { mPr_City = value; }
        }
        private string mPr_District;

        public string Pr_District
        {
            get { return mPr_District; }
            set { mPr_District = value; }
        }
        private string mPr_Phone;

        public string Pr_Phone
        {
            get { return mPr_Phone; }
            set { mPr_Phone = value; }
        }
        private string mPr_Fax;

        public string Pr_Fax
        {
            get { return mPr_Fax; }
            set { mPr_Fax = value; }
        }
        private string mPr_Tax_File_Number;

        public string Pr_Tax_File_Number
        {
            get { return mPr_Tax_File_Number; }
            set { mPr_Tax_File_Number = value; }
        }
        private string mHr_Parent_Organization_Id;

        public string Hr_Parent_Organization_Id
        {
            get { return mHr_Parent_Organization_Id; }
            set { mHr_Parent_Organization_Id = value; }
        }
        private string mHr_List_Parent_Organization_Id;

        public string Hr_List_Parent_Organization_Id
        {
            get { return mHr_List_Parent_Organization_Id; }
            set { mHr_List_Parent_Organization_Id = value; }
        }
        private string mHr_List_Child_Organization_Id;

        public string Hr_List_Child_Organization_Id
        {
            get { return mHr_List_Child_Organization_Id; }
            set { mHr_List_Child_Organization_Id = value; }
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