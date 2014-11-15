using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Unit_Conversion : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mMain_Unit_Id;
        public string Main_Unit_Id
        {
            get { return mMain_Unit_Id; }
            set { mMain_Unit_Id = value; }
        }
        private string mExtra_Unit_Id;
        public string Extra_Unit_Id
        {
            get { return mExtra_Unit_Id; }
            set { mExtra_Unit_Id = value; }
        }
        private decimal mConversion_Rate;
        public decimal Conversion_Rate
        {
            get { return mConversion_Rate; }
            set { mConversion_Rate = value; }
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
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
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