
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP.Route
{
    [Serializable]
    public class Dm_Route : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mRoute_Id;
        public string Route_Id
        {
            get { return mRoute_Id; }
            set { mRoute_Id = value; }
        }
        private string mRoute_Name;
        public string Route_Name
        {
            get { return mRoute_Name; }
            set { mRoute_Name = value; }
        }
        private decimal mDistance_Outbound;
        public decimal Distance_Outbound
        {
            get { return mDistance_Outbound; }
            set { mDistance_Outbound = value; }
        }
        private decimal mDistance_Inbound;
        public decimal Distance_Inbound
        {
            get { return mDistance_Inbound; }
            set { mDistance_Inbound = value; }
        }
        private decimal mRoute_Point_Outbound;
        public decimal Route_Point_Outbound
        {
            get { return mRoute_Point_Outbound; }
            set { mRoute_Point_Outbound = value; }
        }
        private decimal mRoute_Point_Inbound;
        public decimal Route_Point_Inbound
        {
            get { return mRoute_Point_Inbound; }
            set { mRoute_Point_Inbound = value; }
        }
        private DateTime mValid_Date;
        public DateTime Valid_Date
        {
            get { return mValid_Date; }
            set { mValid_Date = value; }
        }
        private decimal mSalary_Point;
        public decimal Salary_Point
        {
            get { return mSalary_Point; }
            set { mSalary_Point = value; }
        }
        private string mRoute_Class_Id;
        public string Route_Class_Id
        {
            get { return mRoute_Class_Id; }
            set { mRoute_Class_Id = value; }
        }
        private string mShipping_Pr_Detail_Id;
        public string Shipping_Pr_Detail_Id
        {
            get { return mShipping_Pr_Detail_Id; }
            set { mShipping_Pr_Detail_Id = value; }
        }
        private string mRoute_Point_In_Id;
        public string Route_Point_In_Id
        {
            get { return mRoute_Point_In_Id; }
            set { mRoute_Point_In_Id = value; }
        }
        private string mRoute_Point_Out_Id;
        public string Route_Point_Out_Id
        {
            get { return mRoute_Point_Out_Id; }
            set { mRoute_Point_Out_Id = value; }
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
