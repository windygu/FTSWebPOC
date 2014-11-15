
using System;
using System.Collections.Generic;
using System.Text;
using FTS.Global.Interface;
using FTS.Global.Classes;

namespace FTS.Global.Business.AccBusiness.Purchase
{
    [Serializable]
    public class Purchase_Detail : IHead
    {
        DataState mDataState = DataState.NONE;
        object mIdValue = string.Empty;
        public Purchase_Detail()
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
        private decimal mImport_Tax_Rate;
        public decimal Import_Tax_Rate
        {
            get { return mImport_Tax_Rate; }
            set { mImport_Tax_Rate = value; }
        }
        private decimal mImport_Tax_Amount;
        public decimal Import_Tax_Amount
        {
            get { return mImport_Tax_Amount; }
            set { mImport_Tax_Amount = value; }
        }
        private decimal mImport_Tax_Amount_Orig;
        public decimal Import_Tax_Amount_Orig
        {
            get { return mImport_Tax_Amount_Orig; }
            set { mImport_Tax_Amount_Orig = value; }
        }
        private decimal mPurchase_Cost;
        public decimal Purchase_Cost
        {
            get { return mPurchase_Cost; }
            set { mPurchase_Cost = value; }
        }
        private decimal mPurchase_Cost_Orig;
        public decimal Purchase_Cost_Orig
        {
            get { return mPurchase_Cost_Orig; }
            set { mPurchase_Cost_Orig = value; }
        }
        private decimal mCog_Unit_Price;
        public decimal Cog_Unit_Price
        {
            get { return mCog_Unit_Price; }
            set { mCog_Unit_Price = value; }
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
        private string mAccount_Id_Return;
        public string Account_Id_Return
        {
            get { return mAccount_Id_Return; }
            set { mAccount_Id_Return = value; }
        }
        private string mAccount_Id_Cogs;
        public string Account_Id_Cogs
        {
            get { return mAccount_Id_Cogs; }
            set { mAccount_Id_Cogs = value; }
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
        private decimal mCog_Unit_Price_Orig;
        public decimal Cog_Unit_Price_Orig
        {
            get { return mCog_Unit_Price_Orig; }
            set { mCog_Unit_Price_Orig = value; }
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
        private decimal mImport_Tax_Amount_Extra;
        public decimal Import_Tax_Amount_Extra
        {
            get { return mImport_Tax_Amount_Extra; }
            set { mImport_Tax_Amount_Extra = value; }
        }
        private decimal mCog_Amount_Extra;
        public decimal Cog_Amount_Extra
        {
            get { return mCog_Amount_Extra; }
            set { mCog_Amount_Extra = value; }
        }
        private decimal mPurchase_Cost_Extra;
        public decimal Purchase_Cost_Extra
        {
            get { return mPurchase_Cost_Extra; }
            set { mPurchase_Cost_Extra = value; }
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
        private decimal mQuantity_Bill;
        public decimal Quantity_Bill
        {
            get { return mQuantity_Bill; }
            set { mQuantity_Bill = value; }
        }
        private decimal mQuantity_Measure;
        public decimal Quantity_Measure
        {
            get { return mQuantity_Measure; }
            set { mQuantity_Measure = value; }
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

        private decimal mTax_Exchange_Rate;
        public decimal Tax_Exchange_Rate {
            get { return mTax_Exchange_Rate; }
            set { mTax_Exchange_Rate = value; }
        }

        private decimal mTax_Unit_Price_Orig;
        public decimal Tax_Unit_Price_Orig {
            get { return mTax_Unit_Price_Orig; }
            set { mTax_Unit_Price_Orig = value; }
        }

        private decimal mInsurance_Rate;
        public decimal Insurance_Rate {
            get { return mInsurance_Rate; }
            set { mInsurance_Rate = value; }
        }

        private decimal mInsurance_Amount;
        public decimal Insurance_Amount {
            get { return mInsurance_Amount; }
            set { mInsurance_Amount = value; }
        }

        private decimal mInsurance_Amount_Extra;
        public decimal Insurance_Amount_Extra {
            get { return mInsurance_Amount_Extra; }
            set { mInsurance_Amount_Extra = value; }
        }

        private decimal mTransport_Fee_Rate;
        public decimal Transport_Fee_Rate {
            get { return mTransport_Fee_Rate; }
            set { mTransport_Fee_Rate = value; }
        }

        private decimal mTransport_Fee_Amount;
        public decimal Transport_Fee_Amount {
            get { return mTransport_Fee_Amount; }
            set { mTransport_Fee_Amount = value; }
        }

        private decimal mTransport_Fee_Amount_Extra;
        public decimal Transport_Fee_Amount_Extra {
            get { return mTransport_Fee_Amount_Extra; }
            set { mTransport_Fee_Amount_Extra = value; }
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
        private decimal mThird_Party_Amount;
        public decimal Third_Party_Amount
        {
            get { return mThird_Party_Amount; }
            set { mThird_Party_Amount = value; }
        }
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
        private string mLicense_Plate;
        public string License_Plate
        {
            get { return mLicense_Plate; }
            set { mLicense_Plate = value; }
        }
        private DateTime mPolicy_Payment_Date;
        public DateTime Policy_Payment_Date
        {
            get { return mPolicy_Payment_Date; }
            set { mPolicy_Payment_Date = value; }
        }
        private string mPolicy_Debt_Currency_Id;
        public string Policy_Debt_Currency_Id
        {
            get { return mPolicy_Debt_Currency_Id; }
            set { mPolicy_Debt_Currency_Id = value; }
        }
        private decimal mPolicy_Debt_Exchange_Rate;
        public decimal Policy_Debt_Exchange_Rate
        {
            get { return mPolicy_Debt_Exchange_Rate; }
            set { mPolicy_Debt_Exchange_Rate = value; }
        }
        private decimal mPolicy_Debt_Fixed_Exchange_Rate;
        public decimal Policy_Debt_Fixed_Exchange_Rate
        {
            get { return mPolicy_Debt_Fixed_Exchange_Rate; }
            set { mPolicy_Debt_Fixed_Exchange_Rate = value; }
        }
        private decimal mPolicy_Debt_Amount_Orig;
        public decimal Policy_Debt_Amount_Orig
        {
            get { return mPolicy_Debt_Amount_Orig; }
            set { mPolicy_Debt_Amount_Orig = value; }
        }
        private decimal mPolicy_Debt_Vat_Tax_Amount_Orig;
        public decimal Policy_Debt_Vat_Tax_Amount_Orig
        {
            get { return mPolicy_Debt_Vat_Tax_Amount_Orig; }
            set { mPolicy_Debt_Vat_Tax_Amount_Orig = value; }
        }
        private decimal mPayment_Exchange_Rate;
        public decimal Payment_Exchange_Rate
        {
            get { return mPayment_Exchange_Rate; }
            set { mPayment_Exchange_Rate = value; }
        }
        private String mPolicy_Debt_Tran_Id;
        public String Policy_Debt_Tran_Id
        {
            get { return mPolicy_Debt_Tran_Id; }
            set { mPolicy_Debt_Tran_Id = value; }
        }
        private String mPolicy_Debt_Organization_Id;
        public String Policy_Debt_Organization_Id
        {
            get { return mPolicy_Debt_Organization_Id; }
            set { mPolicy_Debt_Organization_Id = value; }
        }
        private String mPolicy_Debt_Tran_No;
        public String Policy_Debt_Tran_No
        {
            get { return mPolicy_Debt_Tran_No; }
            set { mPolicy_Debt_Tran_No = value; }
        }
        private DateTime mPolicy_Debt_Tran_Date;
        public DateTime Policy_Debt_Tran_Date
        {
            get { return mPolicy_Debt_Tran_Date; }
            set { mPolicy_Debt_Tran_Date = value; }
        }
    }
}