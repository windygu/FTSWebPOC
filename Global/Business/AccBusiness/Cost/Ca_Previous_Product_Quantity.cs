
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Cost
{
    [Serializable]
    public class Ca_Previous_Product_Quantity : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Ca_Previous_Product_Quantity()
        {
        }
        public DataState DataState
        {
            get { return this.mDataState; }
            set { this.mDataState = value; }
        }
        public object IdValue
        {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private string mOrganization_Id;
        public string Organization_Id
        {
            get { return mOrganization_Id; }
            set { mOrganization_Id = value; }
        }
        private DateTime mDay_Start;
        public DateTime Day_Start
        {
            get { return mDay_Start; }
            set { mDay_Start = value; }
        }
        private DateTime mDay_End;
        public DateTime Day_End
        {
            get { return mDay_End; }
            set { mDay_End = value; }
        }
        private string mPrevious_Job_Id;
        public string Previous_Job_Id
        {
            get { return mPrevious_Job_Id; }
            set { mPrevious_Job_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
    }
}