
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.ShareBusiness.TP
{
        [Serializable]
    public class Dm_Vehicle_Extra : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;

        private string mVehicle_Id;
        public string Vehicle_Id
        {
            get { return mVehicle_Id; }
            set { mVehicle_Id = value; }
        }
        private string mNational_Product;
        public string National_Product
        {
            get { return mNational_Product; }
            set { mNational_Product = value; }
        }
        private string mType_Package;
        public string Type_Package
        {
            get { return mType_Package; }
            set { mType_Package = value; }
        }
        private string mNo_Machine;
        public string No_Machine
        {
            get { return mNo_Machine; }
            set { mNo_Machine = value; }
        }
        private int mDate_Product;
        public int Date_Product
        {
            get { return mDate_Product; }
            set { mDate_Product = value; }
        }
        private string mNo_Frame;
        public string No_Frame
        {
            get { return mNo_Frame; }
            set { mNo_Frame = value; }
        }
        private string mCapacity_Of_Machine;
        public string Capacity_Of_Machine
        {
            get { return mCapacity_Of_Machine; }
            set { mCapacity_Of_Machine = value; }
        }
        private int mNo_Cylinder;
        public int No_Cylinder
        {
            get { return mNo_Cylinder; }
            set { mNo_Cylinder = value; }
        }
        private int mR_Xl;
        public int R_Xl
        {
            get { return mR_Xl; }
            set { mR_Xl = value; }
        }
        private string mDirection_Pston;
        public string Direction_Pston
        {
            get { return mDirection_Pston; }
            set { mDirection_Pston = value; }
        }
        private string mDistance_Axis;
        public string Distance_Axis
        {
            get { return mDistance_Axis; }
            set { mDistance_Axis = value; }
        }
        private int mInfrontof_Wheels;
        public int Infrontof_Wheels
        {
            get { return mInfrontof_Wheels; }
            set { mInfrontof_Wheels = value; }
        }
        private int mBehind_Wheels;
        public int Behind_Wheels
        {
            get { return mBehind_Wheels; }
            set { mBehind_Wheels = value; }
        }
        private string mInfrontof_Size;
        public string Infrontof_Size
        {
            get { return mInfrontof_Size; }
            set { mInfrontof_Size = value; }
        }
        private string mBehind_Size;
        public string Behind_Size
        {
            get { return mBehind_Size; }
            set { mBehind_Size = value; }
        }
        private int mInfrontof_Distance;
        public int Infrontof_Distance
        {
            get { return mInfrontof_Distance; }
            set { mInfrontof_Distance = value; }
        }
        private int mBehind_Distance;
        public int Behind_Distance
        {
            get { return mBehind_Distance; }
            set { mBehind_Distance = value; }
        }
        private string mThe_First_Person;
        public string The_First_Person
        {
            get { return mThe_First_Person; }
            set { mThe_First_Person = value; }
        }
        private string mUses_Id;
        public string Uses_Id
        {
            get { return mUses_Id; }
            set { mUses_Id = value; }
        }
        private DateTime mDate_Create;
        public DateTime Date_Create
        {
            get { return mDate_Create; }
            set { mDate_Create = value; }
        }
        private int mNon_Item;
        public int Non_Item
        {
            get { return mNon_Item; }
            set { mNon_Item = value; }
        }
        private int mTonnage;
        public int Tonnage
        {
            get { return mTonnage; }
            set { mTonnage = value; }
        }
        private DateTime mDate_Registry;
        public DateTime Date_Registry
        {
            get { return mDate_Registry; }
            set { mDate_Registry = value; }
        }
        private int mConsumption;
        public int Consumption
        {
            get { return mConsumption; }
            set { mConsumption = value; }
        }
        private DateTime mDate_Modified;
        public DateTime Date_Modified
        {
            get { return mDate_Modified; }
            set { mDate_Modified = value; }
        }
        private string mNo_Registry;
        public string No_Registry
        {
            get { return mNo_Registry; }
            set { mNo_Registry = value; }
        }
        private int mAdd_Tonnage;
        public int Add_Tonnage
        {
            get { return mAdd_Tonnage; }
            set { mAdd_Tonnage = value; }
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
