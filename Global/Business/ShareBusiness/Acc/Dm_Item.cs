using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;
namespace FTS.Global.Business.ShareBusiness.Acc
{
    [Serializable]
    public class Dm_Item : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;       
        private string mAccount_Id_Cost;
        public string Account_Id_Cost
        {
            get { return mAccount_Id_Cost; }
            set { mAccount_Id_Cost = value; }
        }
        private string mAccount_Id_Income;
        public string Account_Id_Income
        {
            get { return mAccount_Id_Income; }
            set { mAccount_Id_Income = value; }
        }
        private string mAccount_Id_Return;
        public string Account_Id_Return
        {
            get { return mAccount_Id_Return; }
            set { mAccount_Id_Return = value; }
        }
        private string mAccount_Id_Sale_Cost;
        public string Account_Id_Sale_Cost
        {
            get { return mAccount_Id_Sale_Cost; }
            set { mAccount_Id_Sale_Cost = value; }
        }
        private Int16 mActive;
        public Int16 Active
        {
            get { return mActive; }
            set { mActive = value; }
        }
        private string mCost_Method;
        public string Cost_Method
        {
            get { return mCost_Method; }
            set { mCost_Method = value; }
        }
        private int mExport_Tax_Rate;
        public int Export_Tax_Rate
        {
            get { return mExport_Tax_Rate; }
            set { mExport_Tax_Rate = value; }
        }
        private int mImport_Tax_Rate;
        public int Import_Tax_Rate
        {
            get { return mImport_Tax_Rate; }
            set { mImport_Tax_Rate = value; }
        }
        private Int16 mIs_Warehouse_Balance;
        public Int16 Is_Warehouse_Balance
        {
            get { return mIs_Warehouse_Balance; }
            set { mIs_Warehouse_Balance = value; }
        }
        private string mItem_Class_Id;
        public string Item_Class_Id
        {
            get { return mItem_Class_Id; }
            set { mItem_Class_Id = value; }
        }
        private string mItem_Class1_Id;
        public string Item_Class1_Id {
            get { return mItem_Class1_Id; }
            set { mItem_Class1_Id = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mItem_Name;
        public string Item_Name
        {
            get { return mItem_Name; }
            set { mItem_Name = value; }
        }
        private string mItem_Type_Id;
        public string Item_Type_Id
        {
            get { return mItem_Type_Id; }
            set { mItem_Type_Id = value; }
        }
        private int mLuxury_Tax_Rate;
        public int Luxury_Tax_Rate
        {
            get { return mLuxury_Tax_Rate; }
            set { mLuxury_Tax_Rate = value; }
        }
        private string mOrigin;
        public string Origin
        {
            get { return mOrigin; }
            set { mOrigin = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private string mUnit_Id_Extra;
        public string Unit_Id_Extra
        {
            get { return mUnit_Id_Extra; }
            set { mUnit_Id_Extra = value; }
        }
        private string mUser_Id;
        public string User_Id
        {
            get { return mUser_Id; }
            set { mUser_Id = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private int mWarranty_Period;
        public int Warranty_Period
        {
            get { return mWarranty_Period; }
            set { mWarranty_Period = value; }
        }
        private byte[] mItem_Image;
        public byte[] Item_Image
        {
            get { return mItem_Image; }
            set { mItem_Image = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mItem_Color;
        public string Item_Color
        {
            get { return mItem_Color; }
            set { mItem_Color = value; }
        }
        private Int16 mIs_Gift;
        public Int16 Is_Gift
        {
            get { return mIs_Gift; }
            set { mIs_Gift = value; }
        }
        private decimal mPoint;
        public decimal Point
        {
            get { return mPoint; }
            set { mPoint = value; }
        }
        private Int16 mIs_Show;
        public Int16 Is_Show
        {
            get { return mIs_Show; }
            set { mIs_Show = value; }
        }
        private Int16 mIs_Parent;
        public Int16 Is_Parent {
            get { return mIs_Parent; }
            set { mIs_Parent = value; }
        }

        //Tan sua PJICO
        private Int16 mIs_Prints_Id;
        public Int16 Is_Prints_Id
        {
            get { return mIs_Prints_Id; }
            set { mIs_Prints_Id = value; }
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