using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.Base
{
    [Serializable]
    public class Dm_Organization : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private string mOrganization_Name;
        public string Organization_Name
        {
            get { return mOrganization_Name; }
            set { mOrganization_Name = value; }
        }
        private string mOrganization_Name_Display;
        public string Organization_Name_Display
        {
            get { return mOrganization_Name_Display; }
            set { mOrganization_Name_Display = value; }
        }
        private string mParent_Organization_Id;
        public string Parent_Organization_Id
        {
            get { return mParent_Organization_Id; }
            set { mParent_Organization_Id = value; }
        }
        private string mOrganization_Type;
        public string Organization_Type
        {
            get { return mOrganization_Type; }
            set { mOrganization_Type = value; }
        }
        private string mAddress;
        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        private string mCity;
        public string City
        {
            get { return mCity; }
            set { mCity = value; }
        }
        private string mDistrict;
        public string District
        {
            get { return mDistrict; }
            set { mDistrict = value; }
        }
        private string mPhone;
        public string Phone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }
        private string mFax;
        public string Fax
        {
            get { return mFax; }
            set { mFax = value; }
        }
        private string mEmail;
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        private string mTax_File_Number;
        public string Tax_File_Number
        {
            get { return mTax_File_Number; }
            set { mTax_File_Number = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private Int16 mIs_Pos;
        public Int16 Is_Pos
        {
            get { return mIs_Pos; }
            set { mIs_Pos = value; }
        }
        private Int16 mIs_Shift;
        public Int16 Is_Shift {
            get { return mIs_Shift; }
            set { mIs_Shift = value; }
        }
        private string mShort_Organization_Name;
        public string Short_Organization_Name {
            get { return mShort_Organization_Name; }
            set { mShort_Organization_Name = value; }
        }
        private string mPfs_Service_Url;
        public string Pfs_Service_Url {
            get { return mPfs_Service_Url; }
            set { mPfs_Service_Url = value; }
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