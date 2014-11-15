
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Sale
{
    [Serializable]
    public class Sale_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Sale_Detail()
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
        private Guid mPr_Key_Ht_Folio;
        public Guid Pr_Key_Ht_Folio {
            get { return mPr_Key_Ht_Folio; }
            set { mPr_Key_Ht_Folio = value; }
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
        private int mList_Order;
        public int List_Order
        {
            get { return mList_Order; }
            set { mList_Order = value; }
        }
        private string mLot_No;
        public string Lot_No
        {
            get { return mLot_No; }
            set { mLot_No = value; }
        }
        private DateTime mManu_Date;
        public DateTime Manu_Date
        {
            get { return mManu_Date; }
            set { mManu_Date = value; }
        }
        private DateTime mReceive_Date;
        public DateTime Receive_Date
        {
            get { return mReceive_Date; }
            set { mReceive_Date = value; }
        }
        private int mExpired_Term;
        public int Expired_Term
        {
            get { return mExpired_Term; }
            set { mExpired_Term = value; }
        }
        private DateTime mExpired_Date;
        public DateTime Expired_Date
        {
            get { return mExpired_Date; }
            set { mExpired_Date = value; }
        }
        private string mItem_Id;
        public string Item_Id
        {
            get { return mItem_Id; }
            set { mItem_Id = value; }
        }
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        private string mDescription_Uls;
        public string Description_Uls
        {
            get { return mDescription_Uls; }
            set { mDescription_Uls = value; }
        }
        private string mUnit_Id;
        public string Unit_Id
        {
            get { return mUnit_Id; }
            set { mUnit_Id = value; }
        }
        private decimal mQuantity;
        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        private decimal mQuantity_Extra;
        public decimal Quantity_Extra
        {
            get { return mQuantity_Extra; }
            set { mQuantity_Extra = value; }
        }
        private decimal mQuantity_Wh;
        public decimal Quantity_Wh
        {
            get { return mQuantity_Wh; }
            set { mQuantity_Wh = value; }
        }
        private decimal mUnit_Price_Orig;
        public decimal Unit_Price_Orig
        {
            get { return mUnit_Price_Orig; }
            set { mUnit_Price_Orig = value; }
        }
        private decimal mUnit_Price;
        public decimal Unit_Price
        {
            get { return mUnit_Price; }
            set { mUnit_Price = value; }
        }
        private decimal mUnit_Price_Wh;
        public decimal Unit_Price_Wh
        {
            get { return mUnit_Price_Wh; }
            set { mUnit_Price_Wh = value; }
        }
        private decimal mAmount_Orig;
        public decimal Amount_Orig
        {
            get { return mAmount_Orig; }
            set { mAmount_Orig = value; }
        }
        private decimal mAmount;
        public decimal Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }
        private decimal mVat_Income_Amount_Orig;
        public decimal Vat_Income_Amount_Orig
        {
            get { return mVat_Income_Amount_Orig; }
            set { mVat_Income_Amount_Orig = value; }
        }
        private decimal mVat_Income_Amount;
        public decimal Vat_Income_Amount
        {
            get { return mVat_Income_Amount; }
            set { mVat_Income_Amount = value; }
        }
        private string mVat_Tax_Id;
        public string Vat_Tax_Id
        {
            get { return mVat_Tax_Id; }
            set { mVat_Tax_Id = value; }
        }
        private decimal mVat_Tax_Rate;
        public decimal Vat_Tax_Rate
        {
            get { return mVat_Tax_Rate; }
            set { mVat_Tax_Rate = value; }
        }
        private decimal mVat_Tax_Amount;
        public decimal Vat_Tax_Amount
        {
            get { return mVat_Tax_Amount; }
            set { mVat_Tax_Amount = value; }
        }
        private decimal mVat_Tax_Amount_Orig;
        public decimal Vat_Tax_Amount_Orig
        {
            get { return mVat_Tax_Amount_Orig; }
            set { mVat_Tax_Amount_Orig = value; }
        }
        private decimal mExport_Tax_Rate;
        public decimal Export_Tax_Rate
        {
            get { return mExport_Tax_Rate; }
            set { mExport_Tax_Rate = value; }
        }
        private decimal mExport_Tax_Amount;
        public decimal Export_Tax_Amount
        {
            get { return mExport_Tax_Amount; }
            set { mExport_Tax_Amount = value; }
        }
        private decimal mExport_Tax_Amount_Orig;
        public decimal Export_Tax_Amount_Orig
        {
            get { return mExport_Tax_Amount_Orig; }
            set { mExport_Tax_Amount_Orig = value; }
        }
        private decimal mSale_Cost;
        public decimal Sale_Cost
        {
            get { return mSale_Cost; }
            set { mSale_Cost = value; }
        }
        private decimal mSale_Cost_Orig;
        public decimal Sale_Cost_Orig
        {
            get { return mSale_Cost_Orig; }
            set { mSale_Cost_Orig = value; }
        }
        private decimal mDiscount_Rate;
        public decimal Discount_Rate
        {
            get { return mDiscount_Rate; }
            set { mDiscount_Rate = value; }
        }
        private decimal mDiscount_Amount;
        public decimal Discount_Amount
        {
            get { return mDiscount_Amount; }
            set { mDiscount_Amount = value; }
        }
        private decimal mDiscount_Amount_Orig;
        public decimal Discount_Amount_Orig
        {
            get { return mDiscount_Amount_Orig; }
            set { mDiscount_Amount_Orig = value; }
        }
        private decimal mCog_Unit_Price;
        public decimal Cog_Unit_Price
        {
            get { return mCog_Unit_Price; }
            set { mCog_Unit_Price = value; }
        }
        private decimal mCog_Unit_Price_Orig;
        public decimal Cog_Unit_Price_Orig
        {
            get { return mCog_Unit_Price_Orig; }
            set { mCog_Unit_Price_Orig = value; }
        }
        private decimal mCog_Amount;
        public decimal Cog_Amount
        {
            get { return mCog_Amount; }
            set { mCog_Amount = value; }
        }
        private decimal mCog_Amount_Orig;
        public decimal Cog_Amount_Orig
        {
            get { return mCog_Amount_Orig; }
            set { mCog_Amount_Orig = value; }
        }
        private decimal mTotal_Amount;
        public decimal Total_Amount
        {
            get { return mTotal_Amount; }
            set { mTotal_Amount = value; }
        }
        private decimal mTotal_Amount_Orig;
        public decimal Total_Amount_Orig
        {
            get { return mTotal_Amount_Orig; }
            set { mTotal_Amount_Orig = value; }
        }
        private string mAccount_Id;
        public string Account_Id
        {
            get { return mAccount_Id; }
            set { mAccount_Id = value; }
        }
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
        private string mPr_Detail_Id_Item;
        public string Pr_Detail_Id_Item
        {
            get { return mPr_Detail_Id_Item; }
            set { mPr_Detail_Id_Item = value; }
        }
        private string mExpense_Id;
        public string Expense_Id
        {
            get { return mExpense_Id; }
            set { mExpense_Id = value; }
        }
        private string mJob_Id;
        public string Job_Id
        {
            get { return mJob_Id; }
            set { mJob_Id = value; }
        }
        private decimal mAmount_Extra;
        public decimal Amount_Extra
        {
            get { return mAmount_Extra; }
            set { mAmount_Extra = value; }
        }
        private decimal mVat_Income_Amount_Extra;
        public decimal Vat_Income_Amount_Extra
        {
            get { return mVat_Income_Amount_Extra; }
            set { mVat_Income_Amount_Extra = value; }
        }
        private decimal mVat_Tax_Amount_Extra;
        public decimal Vat_Tax_Amount_Extra
        {
            get { return mVat_Tax_Amount_Extra; }
            set { mVat_Tax_Amount_Extra = value; }
        }
        private decimal mDiscount_Amount_Extra;
        public decimal Discount_Amount_Extra
        {
            get { return mDiscount_Amount_Extra; }
            set { mDiscount_Amount_Extra = value; }
        }
        private decimal mExport_Tax_Amount_Extra;
        public decimal Export_Tax_Amount_Extra
        {
            get { return mExport_Tax_Amount_Extra; }
            set { mExport_Tax_Amount_Extra = value; }
        }
        private decimal mCog_Amount_Extra;
        public decimal Cog_Amount_Extra
        {
            get { return mCog_Amount_Extra; }
            set { mCog_Amount_Extra = value; }
        }
        private decimal mSale_Cost_Extra;
        public decimal Sale_Cost_Extra
        {
            get { return mSale_Cost_Extra; }
            set { mSale_Cost_Extra = value; }
        }
        private decimal mTotal_Amount_Extra;
        public decimal Total_Amount_Extra
        {
            get { return mTotal_Amount_Extra; }
            set { mTotal_Amount_Extra = value; }
        }
        private decimal mLux_Tax_Rate;
        public decimal Lux_Tax_Rate
        {
            get { return mLux_Tax_Rate; }
            set { mLux_Tax_Rate = value; }
        }
        private decimal mLux_Tax_Amount;
        public decimal Lux_Tax_Amount
        {
            get { return mLux_Tax_Amount; }
            set { mLux_Tax_Amount = value; }
        }
        private decimal mLux_Tax_Amount_Orig;
        public decimal Lux_Tax_Amount_Orig
        {
            get { return mLux_Tax_Amount_Orig; }
            set { mLux_Tax_Amount_Orig = value; }
        }
        private decimal mLux_Tax_Amount_Extra;
        public decimal Lux_Tax_Amount_Extra
        {
            get { return mLux_Tax_Amount_Extra; }
            set { mLux_Tax_Amount_Extra = value; }
        }
        private decimal mJob_Qty;
        public decimal Job_Qty
        {
            get { return mJob_Qty; }
            set { mJob_Qty = value; }
        }
        private string mBill_No;
        public string Bill_No
        {
            get { return mBill_No; }
            set { mBill_No = value; }
        }
        private decimal mBill_Amount;
        public decimal Bill_Amount
        {
            get { return mBill_Amount; }
            set { mBill_Amount = value; }
        }
        private decimal mBill_Vat_Tax_Amount;
        public decimal Bill_Vat_Tax_Amount
        {
            get { return mBill_Vat_Tax_Amount; }
            set { mBill_Vat_Tax_Amount = value; }
        }
        private decimal mOpenning_Quantity;
        public decimal Openning_Quantity
        {
            get { return mOpenning_Quantity; }
            set { mOpenning_Quantity = value; }
        }
        private decimal mClosing_Quantity;
        public decimal Closing_Quantity
        {
            get { return mClosing_Quantity; }
            set { mClosing_Quantity = value; }
        }
        private decimal mEmployee_Commission_Rate;
        public decimal Employee_Commission_Rate
        {
            get { return mEmployee_Commission_Rate; }
            set { mEmployee_Commission_Rate = value; }
        }
        private decimal mEmployee_Commission_Orig;
        public decimal Employee_Commission_Orig
        {
            get { return mEmployee_Commission_Orig; }
            set { mEmployee_Commission_Orig = value; }
        }
        private decimal mEmployee_Commission;
        public decimal Employee_Commission
        {
            get { return mEmployee_Commission; }
            set { mEmployee_Commission = value; }
        }
        private decimal mEmployee_Commission_Extra;
        public decimal Employee_Commission_Extra
        {
            get { return mEmployee_Commission_Extra; }
            set { mEmployee_Commission_Extra = value; }
        }
        private string mEmployee_Id;
        public string Employee_Id
        {
            get { return mEmployee_Id; }
            set { mEmployee_Id = value; }
        }
        private decimal mQuantity_Expected;
        public decimal Quantity_Expected
        {
            get { return mQuantity_Expected; }
            set { mQuantity_Expected = value; }
        }
        private string mItem_Op_Id;
        public string Item_Op_Id
        {
            get { return mItem_Op_Id; }
            set { mItem_Op_Id = value; }
        }
        private string mItem_Source_Id;
        public string Item_Source_Id {
            get { return mItem_Source_Id; }
            set { mItem_Source_Id = value; }
        }
        private string mWarehouse_Id;
        public string Warehouse_Id
        {
            get { return mWarehouse_Id; }
            set { mWarehouse_Id = value; }
        }
        private string mPrice_Level_Id;
        public string Price_Level_Id
        {
            get { return mPrice_Level_Id; }
            set { mPrice_Level_Id = value; }
        }
        private decimal mFixed_Unit_Price;
        public decimal Fixed_Unit_Price
        {
            get { return mFixed_Unit_Price; }
            set { mFixed_Unit_Price = value; }
        }
        private decimal mFixed_Amount;
        public decimal Fixed_Amount
        {
            get { return mFixed_Amount; }
            set { mFixed_Amount = value; }
        }
        private string mRoom_Id;
        public string Room_Id {
            get { return mRoom_Id; }
            set { mRoom_Id = value; }
        }

        private decimal mQuantity_Bill;
        public decimal Quantity_Bill
        {
            get { return mQuantity_Bill; }
            set { mQuantity_Bill = value; }
        }
        private decimal mTemperature;
        public decimal Temperature {
            get { return mTemperature; }
            set { mTemperature = value; }
        }
        private decimal mDensity;
        public decimal Density {
            get { return mDensity; }
            set { mDensity = value; }
        }
        private decimal mVcf;
        public decimal Vcf {
            get { return mVcf; }
            set { mVcf = value; }
        }
        private decimal mWcf;
        public decimal Wcf {
            get { return mWcf; }
            set { mWcf = value; }
        }

        //Tan sua PJICO
        private string mPolicy_No;
        public string Policy_No
        {
            get { return mPolicy_No; }
            set { mPolicy_No = value; }
        }
        private DateTime mPolicy_Date;
        public DateTime Policy_Date
        {
            get { return mPolicy_Date; }
            set { mPolicy_Date = value; }
        }
        private string mSo_CurrenCy_Id;
        public string So_CurrenCy_Id
        {
            get { return mSo_CurrenCy_Id; }
            set { mSo_CurrenCy_Id = value; }
        }
        private decimal mSo_ExChange_Rate;
        public decimal So_ExChange_Rate
        {
            get { return mSo_ExChange_Rate; }
            set { mSo_ExChange_Rate = value; }
        }
        private decimal mSo_Fixed_Exchange_Rate;
        public decimal So_Fixed_Exchange_Rate
        {
            get { return mSo_Fixed_Exchange_Rate; }
            set { mSo_Fixed_Exchange_Rate = value; }
        }
        private decimal mSo_Amount_Orig;
        public decimal So_Amount_Orig
        {
            get { return mSo_Amount_Orig; }
            set { mSo_Amount_Orig = value; }
        }
        private decimal mSo_Vat_Tax_Amount_Orig;
        public decimal So_Vat_Tax_Amount_Orig
        {
            get { return mSo_Vat_Tax_Amount_Orig; }
            set { mSo_Vat_Tax_Amount_Orig = value; }
        }
        private decimal mPayment_Exchange_Rate;
        public decimal Payment_Exchange_Rate
        {
            get { return mPayment_Exchange_Rate; }
            set { mPayment_Exchange_Rate = value; }
        }
        private string mPrints_Id;
        public string Prints_Id
        {
            get { return mPrints_Id; }
            set { mPrints_Id = value; }
        }
        private string mPrints_Serie;
        public string Prints_Serie
        {
            get { return mPrints_Serie; }
            set { mPrints_Serie = value; }
        }
        //
        private string mSerie_No;
        public string Serie_No
        {
            get { return mSerie_No; }
            set { mSerie_No = value; }
        }
        private string mSo_Tran_Id;
        public string So_Tran_Id
        {
            get { return mSo_Tran_Id; }
            set { mSo_Tran_Id = value; }
        }
        private string mSo_Organization_Id;
        public string So_Organization_Id
        {
            get { return mSo_Organization_Id; }
            set { mSo_Organization_Id = value; }
        }
        private string mSo_Tran_No;
        public string So_Tran_No
        {
            get { return mSo_Tran_No; }
            set { mSo_Tran_No = value; }
        }
        private DateTime mSo_Tran_Date;
        public DateTime So_Tran_Date
        {
            get { return mSo_Tran_Date; }
            set { mSo_Tran_Date = value; }
        }
        private string mSo_Commission_Rate;
        public string So_Commission_Rate
        {
            get { return mSo_Commission_Rate; }
            set { mSo_Commission_Rate = value; }
        }
    }
}