using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using FTS.Global.Business.Base;

using FTS.Global.Business.HotelBusiness.Hotel;
using FTS.Global.Business.PosBusiness;

using FTS.Global.Business.AccBusiness.Asset;
using FTS.Global.Business.AccBusiness.Contract;
using FTS.Global.Business.AccBusiness.Cost;
using FTS.Global.Business.AccBusiness.Journal;
using FTS.Global.Business.AccBusiness.Ledger;
using FTS.Global.Business.AccBusiness.Purchase;
using FTS.Global.Business.AccBusiness.Sale;
using FTS.Global.Business.AccBusiness.Security;
using FTS.Global.Business.AccBusiness.VAT;
using FTS.Global.Business.AccBusiness.Voucher;
using FTS.Global.Business.AccBusiness.Warehouse;
using FTS.Global.Business.TransportBusiness.Cost;

using FTS.Global.Business.ShareBusiness.Hotel;
using FTS.Global.Business.ShareBusiness.TP;
using FTS.Global.Business.ShareBusiness.TP.Route;
using FTS.Global.Business.ShareBusiness.POS;
using FTS.Global.Business.ShareBusiness.HR;
using FTS.Global.Business.ShareBusiness.Acc;



namespace FTS.Global.Classes
{
    public class Registrator
    {
        public static Hashtable Hash = new Hashtable();
        static Registrator()
        {
            #region HotelBusiness
            Hash.Add("HT_BOOKING", new ClassInfo("HT_BOOKING", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Booking)));
            Hash.Add("HT_BOOKING_DETAIL", new ClassInfo("HT_BOOKING_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Booking_Detail)));
            Hash.Add("HT_CHARGES_CHECK_IN_BEFORE", new ClassInfo("HT_CHARGES_CHECK_IN_BEFORE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Charges_Check_In_Before)));
            Hash.Add("HT_CHARGES_CHECK_OUT_AFTER", new ClassInfo("HT_CHARGES_CHECK_OUT_AFTER", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Charges_Check_Out_After)));
            Hash.Add("HT_COMMISSION", new ClassInfo("HT_COMMISSION", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Commission)));
            Hash.Add("HT_DEPOSIT", new ClassInfo("HT_DEPOSIT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Deposit)));
            Hash.Add("HT_DISCOUNT", new ClassInfo("HT_DISCOUNT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Discount)));
            Hash.Add("HT_FOLIO", new ClassInfo("HT_FOLIO", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Folio)));
            Hash.Add("HT_FOLIO_BILLING", new ClassInfo("HT_FOLIO_BILLING", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Folio_Billing)));
            Hash.Add("HT_FOLIO_GUEST", new ClassInfo("HT_FOLIO_GUEST", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Folio_Guest)));
            Hash.Add("HT_FOLIO_PAYMENT", new ClassInfo("HT_FOLIO_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Folio_Payment)));
            Hash.Add("HT_LAUNDARY", new ClassInfo("HT_LAUNDARY", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Laundary)));
            Hash.Add("HT_LAUNDARY_DETAIL", new ClassInfo("HT_LAUNDARY_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Laundary_Detail)));
            Hash.Add("HT_MESSAGE", new ClassInfo("HT_MESSAGE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Message)));
            Hash.Add("HT_RATE", new ClassInfo("HT_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Rate)));
            Hash.Add("HT_ROOM_OUT_OF_ORDER", new ClassInfo("HT_ROOM_OUT_OF_ORDER", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Room_Out_Of_Order)));
            Hash.Add("HT_ROOM_STATUS", new ClassInfo("HT_ROOM_STATUS", string.Empty, "ROOM_ID", DbType.String, typeof(Ht_Room_Status)));
            Hash.Add("HT_TRACE", new ClassInfo("HT_TRACE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Trace)));
            Hash.Add("HT_WAKEUP", new ClassInfo("HT_WAKEUP", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Wakeup)));
            Hash.Add("HT_CDR", new ClassInfo("HT_CDR", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Cdr)));
            Hash.Add("HT_SHIFT", new ClassInfo("HT_SHIFT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Shift)));
            Hash.Add("HT_SHIFT_EMPLOYEE", new ClassInfo("HT_SHIFT_EMPLOYEE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Shift_Employee)));
            Hash.Add("HT_SHIFT_ROOM", new ClassInfo("HT_SHIFT_ROOM", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Shift_Room)));
            Hash.Add("HT_MINIBAR_DEFAULT", new ClassInfo("HT_MINIBAR_DEFAULT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Minibar_Default)));
            Hash.Add("HT_PAYMENT", new ClassInfo("HT_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Payment)));
            Hash.Add("HT_PAYMENT_DETAIL", new ClassInfo("HT_PAYMENT_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Payment_Detail)));
            Hash.Add("HT_FOLIO_PRICE", new ClassInfo("HT_FOLIO_PRICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ht_Folio_Price)));
            #endregion

            #region AccBusiness

            Hash.Add("SECURITY_ISSUE", new ClassInfo("SECURITY_ISSUE", string.Empty, "PR_KEY", DbType.Guid, typeof(Security_Issue)));
            Hash.Add("SECURITY_ISSUE_DETAIL", new ClassInfo("SECURITY_ISSUE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Security_Issue_Detail)));
            Hash.Add("SECURITY_RECEIPT", new ClassInfo("SECURITY_RECEIPT", string.Empty, "PR_KEY", DbType.Guid, typeof(Security_Receipt)));
            Hash.Add("SECURITY_RECEIPT_DETAIL", new ClassInfo("SECURITY_RECEIPT_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Security_Receipt_Detail)));
            Hash.Add("SECURITIES_RATE", new ClassInfo("SECURITIES_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(Securities_Rate)));
            Hash.Add("SECURITY_BALANCE", new ClassInfo("SECURITY_BALANCE", string.Empty, "PR_KEY", DbType.Guid, typeof(Security_Balance)));
            Hash.Add("SECURITIES", new ClassInfo("SECURITIES", string.Empty, "PR_KEY_SECURITIES", DbType.Guid, typeof(Securities)));
            Hash.Add("ASSET", new ClassInfo("ASSET", string.Empty, "PR_KEY", DbType.Guid, typeof(Asset)));
            Hash.Add("ASSET_DEP", new ClassInfo("ASSET_DEP", string.Empty, "PR_KEY", DbType.Guid, typeof(Asset_Dep)));
            Hash.Add("ASSET_DETAIL", new ClassInfo("ASSET_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Asset_Detail)));
            Hash.Add("ASSET_LOCATION", new ClassInfo("ASSET_LOCATION", string.Empty, "PR_KEY", DbType.Guid, typeof(Asset_Location)));
            Hash.Add("ADJUSTMENT_ASSET", new ClassInfo("ADJUSTMENT_ASSET", string.Empty, "PR_KEY", DbType.Guid, typeof(Adjustment_Asset)));
            Hash.Add("CONTRACT", new ClassInfo("CONTRACT", string.Empty, "CONTRACT_NO", DbType.String, typeof(Contract)));
            Hash.Add("CONTRACT_DUE", new ClassInfo("CONTRACT_DUE", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Due)));
            Hash.Add("CONTRACT_IMPLEMENTATION", new ClassInfo("CONTRACT_IMPLEMENTATION", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Implementation)));
            Hash.Add("CONTRACT_ADDENDUM", new ClassInfo("CONTRACT_ADDENDUM", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Addendum)));
            Hash.Add("CONTRACT_MORTGAGE", new ClassInfo("CONTRACT_MORTGAGE", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Mortgage)));
            Hash.Add("CONTRACT_ITEM", new ClassInfo("CONTRACT_ITEM", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Item)));
            Hash.Add("CONTRACT_JOB", new ClassInfo("CONTRACT_JOB", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Job)));
            Hash.Add("CONTRACT_PAYMENT", new ClassInfo("CONTRACT_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Payment)));
            Hash.Add("CONTRACT_RATE", new ClassInfo("CONTRACT_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(Contract_Rate)));
            Hash.Add("CA_ACCOUNT_CONFIG", new ClassInfo("CA_ACCOUNT_CONFIG", string.Empty, "ACCOUNT_ID", DbType.Guid, typeof(Ca_Account_Config)));
            Hash.Add("CA_BEGINNING_AMOUNT", new ClassInfo("CA_BEGINNING_AMOUNT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Beginning_Amount)));
            Hash.Add("CA_BEGINNING_QUANTITY", new ClassInfo("CA_BEGINNING_QUANTITY", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Beginning_Quantity)));
            Hash.Add("CA_BOM", new ClassInfo("CA_BOM", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Bom)));
            Hash.Add("CA_BUDGET", new ClassInfo("CA_BUDGET", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Budget)));
            Hash.Add("CA_EXPENSE", new ClassInfo("CA_EXPENSE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Expense)));
            Hash.Add("CA_EXPENSE_DECREASE", new ClassInfo("CA_EXPENSE_DECREASE", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Expense_Decrease)));
            Hash.Add("CA_EXPENSE_RESULT", new ClassInfo("CA_EXPENSE_RESULT", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Expense_Result)));
            Hash.Add("CA_FINISHED_QUANTITY", new ClassInfo("CA_FINISHED_QUANTITY", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Finished_Quantity)));
            Hash.Add("CA_PREVIOUS_PRODUCT_COST", new ClassInfo("CA_PREVIOUS_PRODUCT_COST", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Previous_Product_Cost)));
            Hash.Add("CA_PREVIOUS_PRODUCT_QUANTITY", new ClassInfo("CA_PREVIOUS_PRODUCT_QUANTITY", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Previous_Product_Quantity)));
            Hash.Add("CA_PRODUCT_COST", new ClassInfo("CA_PRODUCT_COST", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Product_Cost)));
            Hash.Add("CA_RATIO", new ClassInfo("CA_RATIO", string.Empty, "PR_KEY", DbType.Guid, typeof(Ca_Ratio)));
            Hash.Add("COST_APPLICATION", new ClassInfo("COST_APPLICATION", string.Empty, "COST_APPLICATION_ID", DbType.Guid, typeof(Cost_Application)));
            Hash.Add("DM_JOB_ITEM", new ClassInfo("DM_JOB_ITEM", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Job_Item)));
            Hash.Add("TOOL_ALLOCATION", new ClassInfo("TOOL_ALLOCATION", string.Empty, "PR_KEY", DbType.Guid, typeof(Tool_Allocation)));
            Hash.Add("TOOL_ALLOCATION_DETAIL", new ClassInfo("TOOL_ALLOCATION_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Tool_Allocation_Detail)));
            Hash.Add("JOURNAL", new ClassInfo("JOURNAL", string.Empty, "PR_KEY", DbType.Guid, typeof(Journal)));
            Hash.Add("JOURNAL_DETAIL", new ClassInfo("JOURNAL_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Journal_Detail)));
            Hash.Add("BALANCE", new ClassInfo("BALANCE", string.Empty, "PR_KEY", DbType.Guid, typeof(Balance)));
            Hash.Add("BALANCE_DETAIL", new ClassInfo("BALANCE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Balance_Detail)));
            Hash.Add("BUDGET", new ClassInfo("BUDGET", string.Empty, "PR_KEY", DbType.Guid, typeof(Budget)));
            Hash.Add("CLOSING_ENTRY", new ClassInfo("CLOSING_ENTRY", string.Empty, "PR_KEY", DbType.Guid, typeof(Closing_Entry)));
            Hash.Add("LEDGER", new ClassInfo("LEDGER", string.Empty, "PR_KEY_LEDGER", DbType.Guid, typeof(Ledger)));
            Hash.Add("TRANSACTION_REGISTER", new ClassInfo("TRANSACTION_REGISTER", string.Empty, "PR_KEY", DbType.Guid, typeof(Transaction_Register)));
            Hash.Add("PURCHASE", new ClassInfo("PURCHASE", string.Empty, "PR_KEY", DbType.Guid, typeof(Purchase)));
            Hash.Add("PURCHASE_DETAIL", new ClassInfo("PURCHASE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Purchase_Detail)));
            Hash.Add("PURCHASE_PAYMENT", new ClassInfo("PURCHASE_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Purchase_Payment)));
            Hash.Add("PURCHASE_PRICE", new ClassInfo("PURCHASE_PRICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Purchase_Price)));
            Hash.Add("ELECTRIC_INDEX", new ClassInfo("ELECTRIC_INDEX", string.Empty, "PR_KEY", DbType.Guid, typeof(Electric_Index)));
            Hash.Add("ELECTRIC_INDEX_DETAIL", new ClassInfo("ELECTRIC_INDEX_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Electric_Index_Detail)));
            Hash.Add("SALE", new ClassInfo("SALE", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale)));
            Hash.Add("SALE_DETAIL", new ClassInfo("SALE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Detail)));
            Hash.Add("SALE_COG", new ClassInfo("SALE_COG", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Cog)));
            Hash.Add("SALE_INVOICE", new ClassInfo("SALE_INVOICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Invoice)));
            Hash.Add("SALE_PAYMENT", new ClassInfo("SALE_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Payment)));
            Hash.Add("WATERMETER_INDEX", new ClassInfo("WATERMETER_INDEX", string.Empty, "PR_KEY", DbType.Guid, typeof(WaterMeter_Index)));
            Hash.Add("WATERMETER_INDEX_DETAIL", new ClassInfo("WATERMETER_INDEX_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(WaterMeter_Index_Detail)));
            Hash.Add("VAT_TRANSACTION", new ClassInfo("VAT_TRANSACTION", string.Empty, "PR_KEY", DbType.Guid, typeof(Vat_Transaction)));
            Hash.Add("VOUCHER", new ClassInfo("VOUCHER", string.Empty, "PR_KEY", DbType.Guid, typeof(Voucher)));
            Hash.Add("VOUCHER_DETAIL", new ClassInfo("VOUCHER_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Voucher_Detail)));
            Hash.Add("VOUCHER_PAYMENT", new ClassInfo("VOUCHER_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Voucher_Payment)));
            Hash.Add("ADJUSTMENT", new ClassInfo("ADJUSTMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Adjustment)));
            Hash.Add("WAREHOUSE", new ClassInfo("WAREHOUSE", string.Empty, "PR_KEY_WAREHOUSE", DbType.Guid, typeof(Warehouse)));
            Hash.Add("WAREHOUSE_BALANCE", new ClassInfo("WAREHOUSE_BALANCE", string.Empty, "PR_KEY", DbType.Guid, typeof(Warehouse_Balance)));
            Hash.Add("SBO", new ClassInfo("SBO", string.Empty, "PR_KEY", DbType.Guid, typeof(SBO)));
            Hash.Add("SBO_DETAIL", new ClassInfo("SBO_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(SBO_Detail)));
            Hash.Add("SBO_RATE", new ClassInfo("SBO_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(SBO_Rate)));
            Hash.Add("SALE_BASE_PRICE", new ClassInfo("SALE_BASE_PRICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Base_Price)));
            Hash.Add("SALE_BASE_PRICE_DETAIL", new ClassInfo("SALE_BASE_PRICE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Base_Price_Detail)));
            Hash.Add("SALE_DISCOUNT", new ClassInfo("SALE_DISCOUNT", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Discount)));
            Hash.Add("SALE_DISCOUNT_DETAIL", new ClassInfo("SALE_DISCOUNT_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Sale_Discount_Detail)));
            Hash.Add("SO", new ClassInfo("SO", string.Empty, "PR_KEY", DbType.Guid, typeof(SO)));
            Hash.Add("SO_DETAIL", new ClassInfo("SO_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(SO_Detail)));
            Hash.Add("DM_POSTING", new ClassInfo("DM_POSTING", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Posting)));
            Hash.Add("DM_POSTING_DETAIL", new ClassInfo("DM_POSTING_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Posting_Detail)));
            Hash.Add("DM_AUTO_POSTING", new ClassInfo("DM_AUTO_POSTING", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Auto_Posting)));
            Hash.Add("DM_AUTO_POSTING_DETAIL", new ClassInfo("DM_AUTO_POSTING_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Auto_Posting_Detail)));
            Hash.Add("WAREHOUSE_BALANCE_ACTUAL", new ClassInfo("WAREHOUSE_BALANCE_ACTUAL", string.Empty, "PR_KEY", DbType.Guid, typeof(Warehouse_Balance_Actual)));
            Hash.Add("INTEREST", new ClassInfo("INTEREST", string.Empty, "PR_KEY", DbType.Guid, typeof(Interest)));
            Hash.Add("INTEREST_DETAIL", new ClassInfo("INTEREST_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Interest_Detail)));
            Hash.Add("PO_DETAIL", new ClassInfo("PO_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(PO_Detail)));
            Hash.Add("PO", new ClassInfo("PO", string.Empty, "PR_KEY", DbType.Guid, typeof(PO)));
            Hash.Add("DM_ITEM_COMBO", new ClassInfo("DM_ITEM_COMBO", string.Empty, "ITEM_COMBO_ID", DbType.String, typeof(Dm_Item_Combo)));
            List<IdField> lstidfielddmunitconversion = new List<IdField>();
            lstidfielddmunitconversion.Add(new IdField("ITEM_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("UNIT_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("VB_ID", DbType.String));
            Hash.Add("DM_ITEM_VB", new ClassInfo("DM_ITEM_VB", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Item_VB), lstidfielddmunitconversion));
            Hash.Add("PURCHASE_FORECAST", new ClassInfo("PURCHASE_FORECAST", string.Empty, "PR_KEY", DbType.Guid, typeof(Purchase_Forecast)));
            
            #endregion

            #region "PosBusiness"
            Hash.Add("POS_PAYMENT", new ClassInfo("POS_PAYMENT", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Payment)));
            Hash.Add("POS_SHIFT", new ClassInfo("POS_SHIFT", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Shift)));
            Hash.Add("POS_SHIFT_EMPLOYEE", new ClassInfo("POS_SHIFT_EMPLOYEE", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Shift_Employee)));
            Hash.Add("PRINTS", new ClassInfo("PRINTS", string.Empty, "PR_KEY_PRINTS", DbType.Guid, typeof(Prints)));
            Hash.Add("PRINTS_ISSUE_DETAIL", new ClassInfo("PRINTS_ISSUE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Prints_Issue_Detail)));
            Hash.Add("PRINTS_RECEIPT", new ClassInfo("PRINTS_RECEIPT", string.Empty, "PR_KEY", DbType.Guid, typeof(Prints_Receipt)));
            Hash.Add("PRINTS_RECEIPT_DETAIL", new ClassInfo("PRINTS_RECEIPT_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Prints_Receipt_Detail)));
            Hash.Add("POS_PURCHASE_DETAIL", new ClassInfo("POS_PURCHASE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Purchase_Detail)));
            Hash.Add("POS_PURCHASE", new ClassInfo("POS_PURCHASE", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Purchase)));
            Hash.Add("POS_SALE", new ClassInfo("POS_SALE", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Sale)));
            Hash.Add("POS_SALE_DETAIL", new ClassInfo("POS_SALE_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Sale_Detail)));
            Hash.Add("POS_SALE_INVOICE", new ClassInfo("POS_SALE_INVOICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Sale_Invoice)));
            Hash.Add("POS_SHIFT_ITEM", new ClassInfo("POS_SHIFT_ITEM", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Shift_Item)));
            Hash.Add("POS_SO", new ClassInfo("POS_SO", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_So)));
            Hash.Add("POS_SO_DETAIL", new ClassInfo("POS_SO_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_So_Detail)));
            Hash.Add("PRINTS_ISSUE", new ClassInfo("PRINTS_ISSUE", string.Empty, "PR_KEY", DbType.Guid, typeof(Prints_Issue)));
            Hash.Add("PRINTS_WAREHOUSE_BALANCE", new ClassInfo("PRINTS_WAREHOUSE_BALANCE", string.Empty, "PR_KEY", DbType.Guid, typeof(Prints_Warehouse_Balance)));
            Hash.Add("POS_ITEM_PRICE_FOR_DELIVERY", new ClassInfo("POS_ITEM_PRICE_FOR_DELIVERY", string.Empty, "PR_KEY", DbType.Guid, typeof(Pos_Item_Price_For_Delivery)));
            
            #endregion

            #region ShareBusiness Hotel
            Hash.Add("DM_AIRLINE", new ClassInfo("DM_AIRLINE", string.Empty, "AIRLINE_ID", DbType.String, typeof(Dm_Airline)));
            Hash.Add("DM_AIRPORT", new ClassInfo("DM_AIRPORT", string.Empty, "AIRPORT_ID", DbType.String, typeof(Dm_Airport)));
            Hash.Add("DM_AMENITIES", new ClassInfo("DM_AMENITIES", string.Empty, "AMENITIES_ID", DbType.String, typeof(Dm_Amenities)));
            Hash.Add("DM_BUILDING", new ClassInfo("DM_BUILDING", string.Empty, "BUILDING_ID", DbType.String, typeof(Dm_Building)));
            Hash.Add("DM_EXTRA_CHARGE", new ClassInfo("DM_EXTRA_CHARGE", string.Empty, "EXTRA_CHARGE_ID", DbType.String, typeof(Dm_Extra_Charge)));
            Hash.Add("DM_FLOOR", new ClassInfo("DM_FLOOR", string.Empty, "FLOOR_ID", DbType.String, typeof(Dm_Floor)));
            Hash.Add("DM_GUEST", new ClassInfo("DM_GUEST", string.Empty, "GUEST_ID", DbType.String, typeof(Dm_Guest)));
            Hash.Add("DM_GUEST_CLASS", new ClassInfo("DM_GUEST_CLASS", string.Empty, "GUEST_CLASS_ID", DbType.String, typeof(Dm_Guest_Class)));
            Hash.Add("DM_MAPINFO", new ClassInfo("DM_MAPINFO", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Mapinfo)));
            Hash.Add("DM_NATIONALITY", new ClassInfo("DM_NATIONALITY", string.Empty, "NATIONALITY_ID", DbType.String, typeof(Dm_Nationality)));
            Hash.Add("DM_RATE_TYPE", new ClassInfo("DM_RATE_TYPE", string.Empty, "RATE_TYPE_ID", DbType.String, typeof(Dm_Rate_Type)));
            Hash.Add("DM_RELIGION", new ClassInfo("DM_RELIGION", string.Empty, "RELIGION_ID", DbType.String, typeof(Dm_Religion)));
            Hash.Add("DM_ROOM", new ClassInfo("DM_ROOM", string.Empty, "ROOM_ID", DbType.String, typeof(Dm_Room)));
            Hash.Add("DM_ROOM_AMENITIES", new ClassInfo("DM_ROOM_AMENITIES", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Room_Amenities)));
            Hash.Add("DM_ROOM_CLASS", new ClassInfo("DM_ROOM_CLASS", string.Empty, "ROOM_CLASS_ID", DbType.String, typeof(Dm_Room_Class)));
            Hash.Add("DM_SEASON", new ClassInfo("DM_SEASON", string.Empty, "SEASON_ID", DbType.String, typeof(Dm_Season)));
            Hash.Add("DM_SERVICE", new ClassInfo("DM_SERVICE", string.Empty, "SERVICE_ID", DbType.String, typeof(Dm_Service)));
            Hash.Add("DM_ZONE", new ClassInfo("DM_ZONE", string.Empty, "ZONE_ID", DbType.String, typeof(Dm_Zone)));
            Hash.Add("DM_AREA_CODE", new ClassInfo("DM_AREA_CODE", string.Empty, "AREA_CODE_ID", DbType.String, typeof(Dm_Area_Code)));
            Hash.Add("DM_PBX_TYPE", new ClassInfo("DM_PBX_TYPE", string.Empty, "PBX_TYPE_ID", DbType.String, typeof(Dm_Pbx_Type)));
            #endregion

            #region ShareBusiness Acc
            Hash.Add("DM_CONTRACT_CLASS", new ClassInfo("DM_CONTRACT_CLASS", string.Empty, "CONTRACT_CLASS_ID", DbType.String, typeof(Dm_Contract_Class)));
            Hash.Add("DM_PERIOD", new ClassInfo("DM_PERIOD", string.Empty, "PERIOD_ID", DbType.String, typeof(Dm_Period)));
            Hash.Add("SECURITIES_DIVIDEND", new ClassInfo("SECURITIES_DIVIDEND", string.Empty, "PR_KEY", DbType.String, typeof(Securities_Dividend)));
            Hash.Add("DM_SECURITY", new ClassInfo("DM_SECURITY",string.Empty,"SECURITY_ID",DbType.String,typeof(Dm_Security)));
            Hash.Add("DM_SECURITY_CLASS", new ClassInfo("DM_SECURITY_CLASS", string.Empty, "SECURITY_CLASS_ID", DbType.String, typeof(Dm_Security_Class)));
            Hash.Add("DM_INSURANCE_SOURCE", new ClassInfo("DM_INSURANCE_SOURCE", string.Empty, "INSURANCE_SOURCE_ID", DbType.String, typeof(Dm_Insurance_Source)));
            Hash.Add("DM_REINSURANCE_SOURCE", new ClassInfo("DM_REINSURANCE_SOURCE", string.Empty, "REINSURANCE_SOURCE_ID", DbType.String, typeof(Dm_Reinsurance_Source)));
            Hash.Add("DM_BUDGET_TYPE", new ClassInfo("DM_BUDGET_TYPE", string.Empty, "BUDGET_TYPE_ID", DbType.String, typeof(Dm_Budget_Type)));
            Hash.Add("DM_BUDGET", new ClassInfo("DM_BUDGET", string.Empty, "BUDGET_ID", DbType.String, typeof(Dm_Budget)));
            Hash.Add("DM_ACCOUNT", new ClassInfo("DM_ACCOUNT", string.Empty, "ACCOUNT_ID", DbType.String, typeof(Dm_Account)));
            Hash.Add("DM_COUNTRY", new ClassInfo("DM_COUNTRY", string.Empty, "COUNTRY_ID", DbType.String, typeof(Dm_Country)));
            Hash.Add("DM_CURRENCY", new ClassInfo("DM_CURRENCY", string.Empty, "CURRENCY_ID", DbType.String, typeof(Dm_Currency)));
            Hash.Add("DM_EXCHANGE_RATE", new ClassInfo("DM_EXCHANGE_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Exchange_Rate)));
            Hash.Add("DM_EXCHANGE_RATE_EXTRA", new ClassInfo("DM_EXCHANGE_RATE_EXTRA", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Exchange_Rate_Extra)));
            Hash.Add("DM_EXPENSE", new ClassInfo("DM_EXPENSE", string.Empty, "EXPENSE_ID", DbType.String, typeof(Dm_Expense)));
            Hash.Add("DM_EXPENSE_CLASS", new ClassInfo("DM_EXPENSE_CLASS", string.Empty, "EXPENSE_CLASS_ID", DbType.String, typeof(Dm_Expense_Class)));
            Hash.Add("DM_FA_CLASS", new ClassInfo("DM_FA_CLASS", string.Empty, "FA_CLASS_ID", DbType.String, typeof(Dm_Fa_Class)));
            Hash.Add("DM_FA_OPERATION", new ClassInfo("DM_FA_OPERATION", string.Empty, "FA_OPERATION_ID", DbType.String, typeof(Dm_Fa_Operation)));
            Hash.Add("DM_FA_SOURCE", new ClassInfo("DM_FA_SOURCE", string.Empty, "FA_SOURCE_ID", DbType.String, typeof(Dm_Fa_Source)));
            Hash.Add("DM_FA_STATUS", new ClassInfo("DM_FA_STATUS", string.Empty, "FA_STATUS_ID", DbType.String, typeof(Dm_Fa_Status)));
            Hash.Add("DM_ITEM", new ClassInfo("DM_ITEM", string.Empty, "ITEM_ID", DbType.String, typeof(Dm_Item)));
            Hash.Add("DM_ITEM_SOURCE", new ClassInfo("DM_ITEM_SOURCE", string.Empty, "ITEM_SOURCE_ID", DbType.String, typeof(Dm_Item_Source)));
            Hash.Add("DM_ITEM_STATUS", new ClassInfo("DM_ITEM_STATUS", string.Empty, "ITEM_STATUS_ID", DbType.String, typeof(Dm_Item_Status)));
            Hash.Add("DM_ITEM_CLASS", new ClassInfo("DM_ITEM_CLASS", string.Empty, "ITEM_CLASS_ID", DbType.String, typeof(Dm_Item_Class)));
            Hash.Add("DM_ITEM_CLASS1", new ClassInfo("DM_ITEM_CLASS1", string.Empty, "ITEM_CLASS1_ID", DbType.String, typeof(Dm_Item_Class1)));
            Hash.Add("DM_ITEM_OP", new ClassInfo("DM_ITEM_OP", string.Empty, "ITEM_OP_ID", DbType.String, typeof(Dm_Item_Op)));
            Hash.Add("DM_JOB", new ClassInfo("DM_JOB", string.Empty, "JOB_ID", DbType.String, typeof(Dm_Job)));            
            Hash.Add("DM_JOB_CLASS", new ClassInfo("DM_JOB_CLASS", string.Empty, "JOB_CLASS_ID", DbType.String, typeof(Dm_Job_Class)));
            Hash.Add("DM_MARKET", new ClassInfo("DM_MARKET", string.Empty, "MARKET_ID", DbType.String, typeof(Dm_Market)));
            Hash.Add("DM_PAYMENT_METHOD", new ClassInfo("DM_PAYMENT_METHOD", string.Empty, "PAYMENT_METHOD_ID", DbType.String, typeof(Dm_Payment_Method)));
            Hash.Add("DM_PR_DETAIL", new ClassInfo("DM_PR_DETAIL", string.Empty, "PR_DETAIL_ID", DbType.String, typeof(Dm_Pr_Detail)));
            Hash.Add("DM_PR_DETAIL_CLASS", new ClassInfo("DM_PR_DETAIL_CLASS", string.Empty, "PR_DETAIL_CLASS_ID", DbType.String, typeof(Dm_Pr_Detail_Class)));
            Hash.Add("DM_UNIT", new ClassInfo("DM_UNIT", string.Empty, "UNIT_ID", DbType.String, typeof(Dm_Unit)));
            lstidfielddmunitconversion = new List<IdField>();
            lstidfielddmunitconversion.Add(new IdField("MAIN_UNIT_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("EXTRA_UNIT_ID", DbType.String));
            Hash.Add("DM_UNIT_CONVERSION", new ClassInfo("DM_UNIT_CONVERSION", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Unit_Conversion),lstidfielddmunitconversion));
            Hash.Add("DM_VAT_TAX", new ClassInfo("DM_VAT_TAX", string.Empty, "VAT_TAX_ID", DbType.String, typeof(Dm_Vat_Tax)));
            Hash.Add("DM_WAREHOUSE", new ClassInfo("DM_WAREHOUSE", string.Empty, "WAREHOUSE_ID", DbType.String, typeof(Dm_Warehouse)));
            Hash.Add("DM_PUMP", new ClassInfo("DM_PUMP", string.Empty, "PUMP_ID", DbType.String, typeof(Dm_Pump)));
            Hash.Add("DM_SHIFT", new ClassInfo("DM_SHIFT", string.Empty, "SHIFT_ID", DbType.String, typeof(Dm_Shift)));
            Hash.Add("DM_PRICE_LEVEL", new ClassInfo("DM_PRICE_LEVEL", string.Empty, "PRICE_LEVEL_ID", DbType.String, typeof(Dm_Price_Level)));
            Hash.Add("DM_PAYMENT_TERM", new ClassInfo("DM_PAYMENT_TERM", string.Empty, "PAYMENT_TERM_ID", DbType.String, typeof(Dm_Payment_Term)));
            Hash.Add("DM_PAYMENT_ACCOUNT", new ClassInfo("DM_PAYMENT_ACCOUNT", string.Empty, "ACCOUNT_ID", DbType.String, typeof(Dm_Payment_Account)));
            Hash.Add("DM_SHIPPING_METHOD", new ClassInfo("DM_SHIPPING_METHOD", string.Empty, "SHIPPING_METHOD_ID", DbType.String, typeof(Dm_Shipping_Method)));
            Hash.Add("DM_ITEM_WAREHOUSE_LIMIT", new ClassInfo("DM_ITEM_WAREHOUSE_LIMIT", string.Empty, "PR_KEY", DbType.String, typeof(Dm_Item_Warehouse_Limit)));
            Hash.Add("DM_PR_DETAIL_CREDIT_LIMIT", new ClassInfo("DM_PR_DETAIL_CREDIT_LIMIT", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Pr_Detail_Credit_Limit)));
            Hash.Add("DM_VAT_PURCHASE", new ClassInfo("DM_VAT_PURCHASE", string.Empty, "VAT_PURCHASE_ID", DbType.String, typeof(Dm_Vat_Purchase)));
            Hash.Add("DM_WAREHOUSE_CLASS", new ClassInfo("DM_WAREHOUSE_CLASS", string.Empty, "WAREHOUSE_CLASS_ID", DbType.String, typeof(Dm_Warehouse_Class)));
            Hash.Add("DM_BANK", new ClassInfo("DM_BANK", string.Empty, "BANK_ID", DbType.String, typeof(Dm_Bank)));
            Hash.Add("DM_PO_CLASS", new ClassInfo("DM_PO_CLASS", string.Empty, "PO_CLASS_ID", DbType.String, typeof(Dm_PO_Class)));
            Hash.Add("DM_SO_CLASS", new ClassInfo("DM_SO_CLASS", string.Empty, "SO_CLASS_ID", DbType.String, typeof(Dm_SO_Class)));
            Hash.Add("DM_REGION", new ClassInfo("DM_REGION", string.Empty, "REGION_ID", DbType.String, typeof(Dm_Region)));
            Hash.Add("DM_INDUSTRY", new ClassInfo("DM_INDUSTRY", string.Empty, "INDUSTRY_ID", DbType.String, typeof(Dm_Industry)));
            Hash.Add("DM_SHIPPING_ADDRESS", new ClassInfo("DM_SHIPPING_ADDRESS", string.Empty, "SHIPPING_ADDRESS_ID", DbType.String, typeof(Dm_Shipping_Address)));
            Hash.Add("DM_DEALER_CLASS", new ClassInfo("DM_DEALER_CLASS", string.Empty, "DEALER_CLASS_ID", DbType.String, typeof(Dm_Dealer_Class)));
			Hash.Add("WAREHOUSE_MAPPING", new ClassInfo("WAREHOUSE_MAPPING", string.Empty, "PR_KEY", DbType.Guid, typeof(Warehouse_Mapping)));
            Hash.Add("ORGANIZATION_MAPPING", new ClassInfo("ORGANIZATION_MAPPING", string.Empty, "WORKSTATION_ID", DbType.Int32, typeof(Organization_Mapping)));
            Hash.Add("DM_CHAPTER", new ClassInfo("DM_CHAPTER", string.Empty, "CHAPTER_ID", DbType.String, typeof(Dm_Chapter)));
            #endregion

            #region ShareBusiness Vận tải
            Hash.Add("DM_VEHICLE_TYPE", new ClassInfo("DM_VEHICLE_TYPE", string.Empty, "VEHICLE_TYPE_ID", DbType.String, typeof(Dm_Vehicle_Type)));
            Hash.Add("DM_VEHICLE", new ClassInfo("DM_VEHICLE", string.Empty, "VEHICLE_ID", DbType.String, typeof(Dm_Vehicle)));
            Hash.Add("DM_VEHICLE_OIL_RATE", new ClassInfo("DM_VEHICLE_OIL_RATE", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Vehicle_Oil_Rate)));
            Hash.Add("DM_VEHICLE_EXTRA", new ClassInfo("DM_VEHICLE_EXTRA", string.Empty, "VEHICLE_ID", DbType.String, typeof(Dm_Vehicle_Extra)));
            Hash.Add("DM_VEHICLE_DRIVER", new ClassInfo("DM_VEHICLE_DRIVER", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Vehicle_Driver)));
            Hash.Add("DM_VEHICLE_QUALITY", new ClassInfo("DM_VEHICLE_QUALITY", string.Empty, "VEHICLE_QUALITY_ID", DbType.String, typeof(Dm_Vehicle_Quality)));
            Hash.Add("DM_ROUTE", new ClassInfo("DM_ROUTE", string.Empty, "ROUTE_ID", DbType.String, typeof(Dm_Route)));
            Hash.Add("DM_ROUTE_POINT_GROUP", new ClassInfo("DM_ROUTE_POINT_GROUP", string.Empty, "ROUTE_POINT_GROUP_ID", DbType.String, typeof(Dm_Route_Point_Group)));
            Hash.Add("DM_ROUTE_POINT", new ClassInfo("DM_ROUTE_POINT", string.Empty, "ROUTE_POINT_ID", DbType.String, typeof(Dm_Route_Point)));
            Hash.Add("DM_BRIDGE", new ClassInfo("DM_BRIDGE", string.Empty, "BRIDGE_ID", DbType.String, typeof(Dm_Bridge)));
            Hash.Add("DM_BRIDGE_ROUTE", new ClassInfo("DM_BRIDGE_ROUTE", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Bridge_Route)));
            Hash.Add("DM_ROUTE_GROUP", new ClassInfo("DM_ROUTE_GROUP", string.Empty, "ROUTE_GROUP_ID", DbType.String, typeof(Dm_Route_Group)));
            Hash.Add("DM_ROUTE_DISTANCE", new ClassInfo("DM_ROUTE_DISTANCE", string.Empty, "ROUTE_ID", DbType.String, typeof(Dm_Route_Distance)));
            Hash.Add("DM_ROUTE_CLASS", new ClassInfo("DM_ROUTE_CLASS", string.Empty, "ROUTE_CLASS_ID", DbType.String, typeof(Dm_Route_Class)));
            Hash.Add("DM_ROUTE_POINT_CLASS", new ClassInfo("DM_ROUTE_POINT_CLASS", string.Empty, "ROUTE_POINT_CLASS_ID", DbType.String, typeof(Dm_Route_Point_Class)));
            Hash.Add("TP_BRIDGE_TICKET_PRICE", new ClassInfo("TP_BRIDGE_TICKET_PRICE", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Bridge_Ticket_Price)));
            Hash.Add("TP_CONSUMPTION_PUMP", new ClassInfo("TP_CONSUMPTION_PUMP", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Consumption_Pump)));
            Hash.Add("TP_COST", new ClassInfo("TP_COST", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Cost)));
            Hash.Add("TP_ORDER", new ClassInfo("TP_ORDER", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Order)));
            Hash.Add("TP_ORDER_DETAIL", new ClassInfo("TP_ORDER_DETAIL", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Order_Detail)));
            Hash.Add("TP_MONTHLY_TICKET", new ClassInfo("TP_MONTHLY_TICKET", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Monthly_Ticket)));
            Hash.Add("TP_FUEL_CONSUMPTION", new ClassInfo("TP_FUEL_CONSUMPTION", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Fuel_Consumption)));
            
            #endregion

            #region ShareBusiness Pos
            Hash.Add("DM_MEMBERSHIP", new ClassInfo("DM_MEMBERSHIP", string.Empty, "MEMBERSHIP_ID", DbType.String, typeof(Dm_Membership)));
            Hash.Add("DM_MEMBERSHIP_CLASS", new ClassInfo("DM_MEMBERSHIP_CLASS", string.Empty, "MEMBERSHIP_CLASS_ID", DbType.String, typeof(Dm_Membership_Class)));
            Hash.Add("MEMBERSHIP_LOG", new ClassInfo("MEMBERSHIP_LOG", string.Empty, "PR_KEY", DbType.Guid, typeof(Membership_Log)));
            Hash.Add("DM_PRINTS", new ClassInfo("DM_PRINTS", string.Empty, "PRINTS_ID", DbType.String, typeof(Dm_Prints)));
            Hash.Add("DM_PRINTS_BATCH", new ClassInfo("DM_PRINTS_BATCH", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Prints_Batch)));
            Hash.Add("DM_PRINTS_SERIE", new ClassInfo("DM_PRINTS_SERIE", string.Empty, "PRINTS_ID", DbType.String, typeof(Dm_Prints_Serie)));
                        
            #endregion

            #region " ShareBussiness HR"
            Hash.Add("DM_AGE", new ClassInfo("DM_AGE", string.Empty, "AGE_ID", DbType.String, typeof(Dm_Age)));
            Hash.Add("DM_CABINET", new ClassInfo("DM_CABINET", string.Empty, "CABINET_ID", DbType.String, typeof(Dm_Cabinet)));
            Hash.Add("DM_CERTIFICATION", new ClassInfo("DM_CERTIFICATION", string.Empty, "CERTIFICATION_ID", DbType.String, typeof(Dm_Certification)));
            Hash.Add("DM_COMMUNES", new ClassInfo("DM_COMMUNES", string.Empty, "COMMUNES_ID", DbType.String, typeof(Dm_Communes)));
            Hash.Add("DM_CONTRACT_TYPE", new ClassInfo("DM_CONTRACT_TYPE", string.Empty, "CONTRACT_TYPE_ID", DbType.String, typeof(Dm_Contract_Type)));
            Hash.Add("DM_DISTRICTS", new ClassInfo("DM_DISTRICTS", string.Empty, "DISTRICT_ID", DbType.String, typeof(Dm_Districts)));
            Hash.Add("DM_EDUCATION", new ClassInfo("DM_EDUCATION", string.Empty, "DM_EDUCATION", DbType.String, typeof(Dm_Education)));
            Hash.Add("DM_EMPLOYEE_LEVEL", new ClassInfo("DM_EMPLOYEE_LEVEL", string.Empty, "EMPLOYEE_LEVEL_ID", DbType.String, typeof(Dm_Employee_Level)));
            Hash.Add("DM_EMPLOYEE_STATUS", new ClassInfo("DM_EMPLOYEE_STATUS", string.Empty, "EMPLOYEE_STATUS_ID", DbType.String, typeof(Dm_Employee_Status)));
            Hash.Add("DM_ETHNICS", new ClassInfo("DM_ETHNICS", string.Empty, "ETHNICS_ID", DbType.String, typeof(Dm_Ethnics)));
            Hash.Add("DM_FOREIGN_LANGUAGE", new ClassInfo("DM_FOREIGN_LANGUAGE", string.Empty, "FOREIGN_LANGUAGE_ID", DbType.String, typeof(Dm_Foreign_Language)));
            Hash.Add("DM_HOSPITAL", new ClassInfo("DM_HOSPITAL", string.Empty, "HOSPITAL_ID", DbType.String, typeof(Dm_Hospital)));
            Hash.Add("DM_HR_HOLIDAY", new ClassInfo("DM_HR_HOLIDAY", string.Empty, "HOLIDAY_ID", DbType.String, typeof(Dm_Hr_Holiday)));
            Hash.Add("DM_HR_HOLIDAY_INFO", new ClassInfo("DM_HR_HOLIDAY_INFO", string.Empty, "PR_KEY", DbType.Guid, typeof(Dm_Hr_Holiday_Info)));
            Hash.Add("DM_HR_LEAVE_REASON", new ClassInfo("DM_HR_LEAVE_REASON", string.Empty, "LEAVE_REASON_ID", DbType.String, typeof(Dm_Hr_Leave_Reason)));
            Hash.Add("DM_HR_WORK_PLACE", new ClassInfo("DM_HR_WORK_PLACE", string.Empty, "WORK_PLACE_ID", DbType.String, typeof(Dm_Hr_Work_Place)));
            Hash.Add("DM_HR_ZODIAC", new ClassInfo("DM_HR_ZODIAC", string.Empty, "ZODIAC_ID", DbType.String, typeof(Dm_Hr_Zodiac)));
            Hash.Add("DM_MARITAL_STATUS", new ClassInfo("DM_MARITAL_STATUS", string.Empty, "MARITAL_STATUS_ID", DbType.String, typeof(Dm_Marital_Status)));
            Hash.Add("DM_PR_HR_ORGANIZATION", new ClassInfo("DM_PR_HR_ORGANIZATION", string.Empty, "PR_ORGANIZATION_ID", DbType.String, typeof(Dm_Marital_Status)));
            Hash.Add("DM_PR_REASON", new ClassInfo("DM_PR_REASON", string.Empty, "REASON_ID", DbType.String, typeof(Dm_Pr_reason)));
            Hash.Add("DM_PRODUCTION_STEP", new ClassInfo("DM_PRODUCTION_STEP", string.Empty, "PRODUCTION_STEP_ID", DbType.Decimal, typeof(Dm_Production_Step)));
            Hash.Add("DM_SALARY_TYPE", new ClassInfo("DM_SALARY_TYPE", string.Empty, "SALARY_TYPE_ID", DbType.String, typeof(Dm_Salary_Type)));
            Hash.Add("DM_SKILL", new ClassInfo("DM_SKILL", string.Empty, "SKILL_ID", DbType.String, typeof(Dm_Skill)));
            Hash.Add("DM_SPECIALIZED", new ClassInfo("DM_SPECIALIZED", string.Empty, "SPECIALIZED_ID", DbType.String, typeof(Dm_Specialized)));
            Hash.Add("HR_EMPLOYEE_INFO", new ClassInfo("HR_EMPLOYEE_INFO", string.Empty, "EMPLOYEE_ID", DbType.String, typeof(Hr_Employee_Info)));
            Hash.Add("DM_PR_RELATIONSHIP", new ClassInfo("DM_PR_RELATIONSHIP", string.Empty, "RELATIONSHIP_ID", DbType.String, typeof(Dm_Pr_Relationship)));
            Hash.Add("DM_PROVINCES", new ClassInfo("DM_PROVINCES", string.Empty, "PROVINCE_ID", DbType.String, typeof(Dm_Provinces)));            
            
            #endregion
            
            #region Costing
            Hash.Add("TP_FUEL_BALANCE", new ClassInfo("TP_FUEL_BALANCE", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Fuel_Balance)));
            Hash.Add("TP_LOADING_COST", new ClassInfo("TP_LOADING_COST", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Loading_Cost)));
            Hash.Add("TP_PRICE_RANGES", new ClassInfo("TP_PRICE_RANGES", string.Empty, "PR_KEY", DbType.Guid, typeof(Tp_Price_Ranges)));
            #endregion

            #region Base
            Hash.Add("DM_ORGANIZATION", new ClassInfo("DM_ORGANIZATION", string.Empty, "ORGANIZATION_ID", DbType.String, typeof(Dm_Organization)));
            Hash.Add("DM_ORGANIZATION_MAPPING", new ClassInfo("DM_ORGANIZATION_MAPPING", string.Empty, "ORGANIZATION_ID", DbType.String, typeof(Dm_Organization_Mapping)));
            Hash.Add("SYS_TABLE", new ClassInfo("SYS_TABLE", string.Empty, "TABLE_NAME", DbType.String, typeof(Sys_Table)));
            Hash.Add("SYS_ID_FILTER", new ClassInfo("SYS_ID_FILTER", string.Empty, "PR_KEY", DbType.Guid, typeof(Sys_Id_Filter)));
            Hash.Add("SYS_ID_STRUCT", new ClassInfo("SYS_ID_STRUCT", string.Empty, "PR_KEY", DbType.Guid, typeof(Sys_Id_Struct)));
            Hash.Add("SYS_ID_DEFAULT", new ClassInfo("SYS_ID_DEFAULT", string.Empty, "PR_KEY", DbType.Guid, typeof(Sys_Id_Default)));         
            Hash.Add("COMMAND", new ClassInfo("COMMAND", string.Empty, string.Empty, DbType.String, typeof(Command), TransferType.Command));
            Hash.Add("LOGGING", new ClassInfo("LOGGING", string.Empty, "PR_KEY", DbType.Decimal, typeof(Logging)));
            lstidfielddmunitconversion = new List<IdField>();
            lstidfielddmunitconversion.Add(new IdField("ORGANIZATION_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("DES_ORGANIZATION_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("MODULE_ID", DbType.String));
            Hash.Add("SYS_LOCK", new ClassInfo("SYS_LOCK", string.Empty, "PR_KEY", DbType.Guid, typeof(Sys_Look), lstidfielddmunitconversion));
            Hash.Add("SEC_USER", new ClassInfo("SEC_USER", string.Empty, "USER_ID", DbType.String, typeof(Sec_User)));
            Hash.Add("SEC_USER_GROUP", new ClassInfo("SEC_USER_GROUP", string.Empty, "USER_GROUP_ID", DbType.String, typeof(Sec_User_Group)));

            lstidfielddmunitconversion = new List<IdField>();
            lstidfielddmunitconversion.Add(new IdField("FUNCTION_ID", DbType.String));
            lstidfielddmunitconversion.Add(new IdField("USER_GROUP_ID", DbType.String));
            Hash.Add("SEC_PERMISSION", new ClassInfo("SEC_PERMISSION", string.Empty, "PR_KEY", DbType.Guid, typeof(Sec_Permission), lstidfielddmunitconversion));
            
            #endregion
        }
    }
}
