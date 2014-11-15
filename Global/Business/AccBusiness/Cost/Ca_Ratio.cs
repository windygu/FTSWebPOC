
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Cost
{
    [Serializable]
    public class Ca_Ratio : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Ca_Ratio()
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
            get { return mPr_Key;}
            set { mPr_Key = value;}
        }
        private string mJob_Id;       
		public string Job_Id
        {
            get { return mJob_Id;}
            set { mJob_Id = value;}
        }
        private decimal mRatio;       
		public decimal Ratio
        {
            get { return mRatio;}
            set { mRatio = value;}
        }
        private DateTime mDay_Start;       
		public DateTime Day_Start
        {
            get { return mDay_Start;}
            set { mDay_Start = value;}
        }
        private DateTime mDay_End;       
		public DateTime Day_End
        {
            get { return mDay_End;}
            set { mDay_End = value;}
        }
        private string mItem_Id;       
		public string Item_Id
        {
            get { return mItem_Id;}
            set { mItem_Id = value;}
        }
        private string mStd_Job_Id;       
		public string Std_Job_Id
        {
            get { return mStd_Job_Id;}
            set { mStd_Job_Id = value;}
        }        
    }
}