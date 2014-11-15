
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;


namespace FTS.Global.Business.ShareBusiness.TP
{
    [Serializable]
    public class Tp_Order_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private int mTrip_No;
        public int Trip_No
        {
            get { return mTrip_No; }
            set { mTrip_No = value; }
        }
        private int mDes_No;
        public int Des_No
        {
            get { return mDes_No; }
            set { mDes_No = value; }
        }
        private string mRoute_Id;
        public string Route_Id
        {
            get { return mRoute_Id; }
            set { mRoute_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mExtra_Unit_Id;
        public string Extra_Unit_Id
        {
            get { return mExtra_Unit_Id; }
            set { mExtra_Unit_Id = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private string mUnit_Id_Wh;
        public string Unit_Id_Wh
        {
            get { return mUnit_Id_Wh; }
            set { mUnit_Id_Wh = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mQuantity_Qd;
        public decimal Quantity_Qd
        {
            get { return mQuantity_Qd; }
            set { mQuantity_Qd = value; }
        }
        private decimal mQuantity_Confirm;
        public decimal Quantity_Confirm
        {
            get { return mQuantity_Confirm; }
            set { mQuantity_Confirm = value; }
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
        private decimal mDistance_Payment;
        public decimal Distance_Payment
        {
            get { return mDistance_Payment; }
            set { mDistance_Payment = value; }
        }
        private decimal mSalary_Point;
        public decimal Salary_Point
        {
            get { return mSalary_Point; }
            set { mSalary_Point = value; }
        }
        private decimal mFuel_Has_Item;
        public decimal Fuel_Has_Item
        {
            get { return mFuel_Has_Item; }
            set { mFuel_Has_Item = value; }
        }
        private decimal mRoute_Point_Inbound;
        public decimal Route_Point_Inbound
        {
            get { return mRoute_Point_Inbound; }
            set { mRoute_Point_Inbound = value; }
        }
        private decimal mRoute_Point_Outbound;
        public decimal Route_Point_Outbound
        {
            get { return mRoute_Point_Outbound; }
            set { mRoute_Point_Outbound = value; }
        }
        private Int16 mDistance_Max;
        public Int16 Distance_Max
        {
            get { return mDistance_Max; }
            set { mDistance_Max = value; }
        }
        private string mShipping_Pr_Detail_Id;
        public string Shipping_Pr_Detail_Id
        {
            get { return mShipping_Pr_Detail_Id; }
            set { mShipping_Pr_Detail_Id = value; }
        }
        private decimal mUploading_Cost;
        public decimal Uploading_Cost
        {
            get { return mUploading_Cost; }
            set { mUploading_Cost = value; }
        }
        private decimal mDownloading_Cost;
        public decimal Downloading_Cost
        {
            get { return mDownloading_Cost; }
            set { mDownloading_Cost = value; }
        }
        private decimal mTrip_Cost;
        public decimal Trip_Cost
        {
            get { return mTrip_Cost; }
            set { mTrip_Cost = value; }
        }
        private decimal mMeals_Cost;
        public decimal Meals_Cost
        {
            get { return mMeals_Cost; }
            set { mMeals_Cost = value; }
        }
        private decimal mBridge_Cost;
        public decimal Bridge_Cost
        {
            get { return mBridge_Cost; }
            set { mBridge_Cost = value; }
        }
        private decimal mRevenue;
        public decimal Revenue
        {
            get { return mRevenue; }
            set { mRevenue = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private Guid mPr_Key;
        public Guid Pr_Key
        {
            get { return mPr_Key; }
            set { mPr_Key = value; }
        }
        private Guid mFr_Key;
        public Guid Fr_Key
        {
            get { return mFr_Key; }
            set { mFr_Key = value; }
        }
        private decimal mTp_Cost;
        public decimal Tp_Cost
        {
            get { return mTp_Cost; }
            set { mTp_Cost = value; }
        }
        private decimal mFuel_Consumption_Extra;
        public decimal Fuel_Consumption_Extra
        {
            get { return mFuel_Consumption_Extra; }
            set { mFuel_Consumption_Extra = value; }
        }
        private decimal mFuel_Pump;
        public decimal Fuel_Pump
        {
            get { return mFuel_Pump; }
            set { mFuel_Pump = value; }
        }
        private decimal mFuel_Non_Item;
        public decimal Fuel_Non_Item
        {
            get { return mFuel_Non_Item; }
            set { mFuel_Non_Item = value; }
        }
        private decimal mWeight_Cost;
        public decimal Weight_Cost
        {
            get { return mWeight_Cost; }
            set { mWeight_Cost = value; }
        }
        private string mFuel_Cost_Method;
        public string Fuel_Cost_Method {
            get { return mFuel_Cost_Method; }
            set { mFuel_Cost_Method = value; }
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
