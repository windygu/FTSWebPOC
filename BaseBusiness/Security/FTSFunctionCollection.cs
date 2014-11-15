using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.BaseBusiness.Security {
    public class FTSFunctionCollection {
        #region Hệ thống

        public static FTSFunction SYS_REPORT = new FTSFunction("SYS_REPORT", "SYS", false, true, true, true, false);
        public static FTSFunction SYS_LOCK = new FTSFunction("SYS_LOCK", "SYS", false, true, true, true, false);
        public static FTSFunction SEC_PERMISSION = new FTSFunction("SEC_PERMISSION", "SYS", false, false, false, false, true);
        public static FTSFunction SYS_TRAN = new FTSFunction("SYS_TRAN", "SYS", false, false, false, false, true);
        public static FTSFunction SYS_MENU = new FTSFunction("SYS_MENU", "SYS", false, true, true, true, false);
        public static FTSFunction SYS_TRAN_DUPLICATE = new FTSFunction("SYS_TRAN_DUPLICATE", "SYS", false, true, true, true, false);
        public static FTSFunction DM_ORGANIZATION = new FTSFunction("DM_ORGANIZATION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ORGANIZATION_MAPPING = new FTSFunction("DM_ORGANIZATION_MAPPING", "SHARE", false, true, true, true, false);
        public static FTSFunction EXPORT_REPORT = new FTSFunction("EXPORT_REPORT", "SYS", false, false, false, false, true);
        public static FTSFunction IMPORT_REPORT = new FTSFunction("IMPORT_REPORT", "SYS", false, false, false, false, true);
        public static FTSFunction OPTION = new FTSFunction("OPTION", "SYS", false, false, false, false, true);
        public static FTSFunction DM_TEMPLATE = new FTSFunction("DM_TEMPLATE", "SYS", false, false, false, false, true);
        public static FTSFunction TRANSACTION_APPROVE = new FTSFunction("TRANSACTION_APPROVE", "SYS", false, false, false, false, true);
        public static FTSFunction LOGGING = new FTSFunction("LOGGING", "SYS", false, false, false, true, false);

        #endregion

        #region Danh mục

        public static FTSFunction DM_PAYMENT_ACCOUNT = new FTSFunction("DM_PAYMENT_ACCOUNT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_REINSURANCE_SOURCE = new FTSFunction("DM_REINSURANCE_SOURCE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_INSURANCE_SOURCE = new FTSFunction("DM_INSURANCE_SOURCE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_BUDGET_TYPE = new FTSFunction("DM_BUDGET_TYPE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_BUDGET = new FTSFunction("DM_BUDGET", "SHARE", true, true, true, true, false);

        public static FTSFunction DM_CONTRACT_CLASS = new FTSFunction("DM_CONTRACT_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PERIOD = new FTSFunction("DM_PERIOD", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ACCOUNT = new FTSFunction("DM_ACCOUNT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_BANK = new FTSFunction("DM_BANK", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_AIRLINE = new FTSFunction("DM_AIRLINE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ZONE = new FTSFunction("DM_ZONE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_AREA_CODE = new FTSFunction("DM_AREA_CODE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PBX_TYPE = new FTSFunction("DM_PBX_TYPE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_AIRPORT = new FTSFunction("DM_AIRPORT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_AMENITIES = new FTSFunction("DM_AMENITIES", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_BUILDING = new FTSFunction("DM_BUILDING", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_COUNTRY = new FTSFunction("DM_COUNTRY", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_CURRENCY = new FTSFunction("DM_CURRENCY", "SHARE", false, true, true, true, false);

        public static FTSFunction DM_ITEM_COMMISSION = new FTSFunction("DM_ITEM_COMMISSION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_EXCHANGE_RATE = new FTSFunction("DM_EXCHANGE_RATE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FIXED_EXCHANGE_RATE = new FTSFunction("DM_FIXED_EXCHANGE_RATE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_EXCHANGE_RATE_EXTRA = new FTSFunction("DM_EXCHANGE_RATE_EXTRA", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_EXPENSE = new FTSFunction("DM_EXPENSE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_EXPENSE_CLASS = new FTSFunction("DM_EXPENSE_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_EXTRA_CHARGE = new FTSFunction("DM_EXTRA_CHARGE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FA_CLASS = new FTSFunction("DM_FA_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FA_OPERATION = new FTSFunction("DM_FA_OPERATION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FA_SOURCE = new FTSFunction("DM_FA_SOURCE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FA_STATUS = new FTSFunction("DM_FA_STATUS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_FLOOR = new FTSFunction("DM_FLOOR", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_GUEST_CLASS = new FTSFunction("DM_GUEST_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_GUEST = new FTSFunction("DM_GUEST", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM = new FTSFunction("DM_ITEM", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_VB = new FTSFunction("DM_ITEM", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_CLASS = new FTSFunction("DM_ITEM_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_CLASS1 = new FTSFunction("DM_ITEM_CLASS1", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_OP = new FTSFunction("DM_ITEM_OP", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_STATUS = new FTSFunction("DM_ITEM_STATUS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_SOURCE = new FTSFunction("DM_ITEM_SOURCE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_JOB = new FTSFunction("DM_JOB", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_JOB_CLASS = new FTSFunction("DM_JOB_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_JOB_ITEM = new FTSFunction("DM_JOB_ITEM", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_MARKET = new FTSFunction("DM_MARKET", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_NATIONALITY = new FTSFunction("DM_NATIONALITY", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PR_DETAIL = new FTSFunction("DM_PR_DETAIL", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PR_DETAIL_CLASS = new FTSFunction("DM_PR_DETAIL_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_RATE_TYPE = new FTSFunction("DM_RATE_TYPE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SHIPPING_METHOD = new FTSFunction("DM_SHIPPING_METHOD", "SHARE", false, true, true, true, false);

        public static FTSFunction DM_ROOM = new FTSFunction("DM_ROOM", "SHARE", false, true, true, true, true);
        public static FTSFunction DM_ROOM_AMENITIES = new FTSFunction("DM_ROOM_AMENITIES", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROOM_CLASS = new FTSFunction("DM_ROOM_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SEASON = new FTSFunction("DM_SEASON", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SERVICE = new FTSFunction("DM_SERVICE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_UNIT = new FTSFunction("DM_UNIT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_UNIT_CONVERSION = new FTSFunction("DM_UNIT_CONVERSION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VAT_TAX = new FTSFunction("DM_VAT_TAX", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_WAREHOUSE = new FTSFunction("DM_WAREHOUSE", "SHARE", false, true, true, true, false);
        public static FTSFunction WAREHOUSE_MAPPING = new FTSFunction("WAREHOUSE_MAPPING", "SHARE", false, true, true, true, false);
        public static FTSFunction ORGANIZATION_MAPPING = new FTSFunction("ORGANIZATION_MAPPING", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_WAREHOUSE_CLASS = new FTSFunction("DM_WAREHOUSE_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PUMP = new FTSFunction("DM_PUMP", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SHIFT = new FTSFunction("DM_SHIFT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PAYMENT_TERM = new FTSFunction("DM_PAYMENT_TERM", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PAYMENT_METHOD = new FTSFunction("DM_PAYMENT_METHOD", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PRICE_LEVEL = new FTSFunction("DM_PRICE_LEVEL", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE = new FTSFunction("DM_VEHICLE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_QUALITY = new FTSFunction("DM_VEHICLE_QUALITY", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_EXTRA = new FTSFunction("DM_VEHICLE_EXTRA", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_TYPE = new FTSFunction("DM_VEHICLE_TYPE", "SHARE", false, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_INFO = new FTSFunction("HR_EMPLOYEE_INFO", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROUTE = new FTSFunction("DM_ROUTE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROUTE_DISTANCE = new FTSFunction("DM_ROUTE_DISTANCE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROUTE_POINT = new FTSFunction("DM_ROUTE_POINT", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROUTE_POINT_CLASS = new FTSFunction("DM_ROUTE_POINT_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ROUTE_CLASS = new FTSFunction("DM_ROUTE_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_BRIDGE = new FTSFunction("DM_BRIDGE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_BRIDGE_ROUTE = new FTSFunction("DM_BRIDGE_ROUTE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_DRIVER = new FTSFunction("DM_VEHICLE_DRIVER", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_REGION = new FTSFunction("DM_REGION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_INDUSTRY = new FTSFunction("DM_INDUSTRY", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SHIPPING_ADDRESS = new FTSFunction("DM_SHIPPING_ADDRESS", "SHARE", false, true, true, true, false);

        public static FTSFunction DM_HR_CAREER = new FTSFunction("DM_HR_CAREER", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_ADDRESS_TYPE = new FTSFunction("DM_ADDRESS_TYPE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_SPECIALIZED = new FTSFunction("DM_SPECIALIZED", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_ALLOWANCE = new FTSFunction("DM_ALLOWANCE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_REASONSALARY = new FTSFunction("DM_REASONSALARY", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_PRODUCTION_STEP = new FTSFunction("DM_PRODUCTION_STEP", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_BONUS_TYPE = new FTSFunction("DM_BONUS_TYPE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_PR_ORGANIZATION = new FTSFunction("DM_PR_ORGANIZATION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_SENIORITYALLOWANCES_RATE = new FTSFunction("DM_SENIORITYALLOWANCES_RATE", "SHARE", true, true, true, true, false);

        public static FTSFunction DM_RELIGION = new FTSFunction("DM_RELIGION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_ETHNICS = new FTSFunction("DM_ETHNICS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_AGE = new FTSFunction("DM_AGE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_CABINET = new FTSFunction("DM_CABINET", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_CERTIFICATION = new FTSFunction("DM_CERTIFICATION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_COMMUNES = new FTSFunction("DM_COMMUNES", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_CONTRACT_TYPE = new FTSFunction("DM_CONTRACT_TYPE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_DISTRICTS = new FTSFunction("DM_DISTRICTS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_EDUCATION = new FTSFunction("DM_EDUCATION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_EMPLOYEE_LEVEL = new FTSFunction("DM_EMPLOYEE_LEVEL", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_EMPLOYEE_STATUS = new FTSFunction("DM_EMPLOYEE_STATUS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_FOREIGN_LANGUAGE = new FTSFunction("DM_FOREIGN_LANGUAGE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HOSPITAL = new FTSFunction("DM_HOSPITAL", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_HOLIDAY = new FTSFunction("DM_HR_HOLIDAY", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_HOLIDAY_INFO = new FTSFunction("DM_HR_HOLIDAY_INFO", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_LEAVE_REASON = new FTSFunction("DM_HR_LEAVE_REASON", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HRM_RELATIONSHIP = new FTSFunction("DM_HRM_RELATIONSHIP", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_WORK_PLACE = new FTSFunction("DM_HR_WORK_PLACE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_ZODIAC = new FTSFunction("DM_HR_ZODIAC", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_MARITAL_STATUS = new FTSFunction("DM_MARITAL_STATUS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_DOCUMENT = new FTSFunction("DM_DOCUMENT", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_POSITION = new FTSFunction("DM_POSITION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_PROVINCES = new FTSFunction("DM_PROVINCES", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_REDUCTION_OTHER = new FTSFunction("DM_REDUCTION_OTHER", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_SALARY_TYPE = new FTSFunction("DM_SALARY_TYPE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_SKILL = new FTSFunction("DM_SKILL", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HR_ORGANIZATION = new FTSFunction("DM_HR_ORGANIZATION", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_HRM_ROUND = new FTSFunction("DM_HRM_ROUND", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_INTERVIEW_CONTENT = new FTSFunction("DM_INTERVIEW_CONTENT", "SHARE", true, true, true, true, false);

        public static FTSFunction DM_MAPINFO = new FTSFunction("DM_MAPINFO", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_MEMBERSHIP = new FTSFunction("DM_MEMBERSHIP", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_MEMBERSHIP_CLASS = new FTSFunction("DM_MEMBERSHIP_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PRINTS = new FTSFunction("DM_PRINTS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PRINTS_SERIE = new FTSFunction("DM_PRINTS_SERIE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_PRINTS_BATCH = new FTSFunction("DM_PRINTS_BATCH", "SHARE", false, true, true, true, false);
        public static FTSFunction MEMBERSHIP_LOG = new FTSFunction("MEMBERSHIP_LOG", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_ITEM_COMBO = new FTSFunction("DM_ITEM_COMBO", "SHARE", false, true, true, true, false);

        public static FTSFunction DM_EMPLOYEE = new FTSFunction("DM_EMPLOYEE", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_PR_EXPENSE_CLASS = new FTSFunction("DM_PR_EXPENSE_CLASS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_PR_EXPENSE = new FTSFunction("DM_PR_EXPENSE", "SHARE", true, true, true, true, false);

        public static FTSFunction DM_CHAPTER = new FTSFunction("DM_CHAPTER", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_SO_CLASS = new FTSFunction("DM_SO_CLASS", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_OWNER = new FTSFunction("DM_VEHICLE_OWNER", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_USAGE = new FTSFunction("DM_VEHICLE_USAGE", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_CAPACITY = new FTSFunction("DM_VEHICLE_CAPACITY", "SHARE", false, true, true, true, false);

        #endregion

        #region Nhan Su

        public static FTSFunction HR_TIMESHEET_DETAIL_VT = new FTSFunction("HR_TIMESHEET_DETAIL_VT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_PLAN_STOPPAGE = new FTSFunction("HR_PLAN_STOPPAGE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_PLAN_OVERTIME_TEMP = new FTSFunction("HR_PLAN_OVERTIME_TEMP", "HRM", true, true, true, true, false);
        public static FTSFunction HR_PLAN_OVERTIME = new FTSFunction("HR_PLAN_OVERTIME", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_RESULT_RECRUITMENT = new FTSFunction("HR_RC_RESULT_RECRUITMENT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_POSITION_MANAGER = new FTSFunction("HR_RC_POSITION_MANAGER", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_POSITION_DETAIL = new FTSFunction("HR_RC_POSITION_DETAIL", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_POSITION = new FTSFunction("HR_RC_POSITION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_PLAN_POSITION = new FTSFunction("HR_RC_PLAN_POSITION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_CAN_REC_INFO = new FTSFunction("HR_RC_CAN_REC_INFO", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_CAN_POINT = new FTSFunction("HR_RC_CAN_POINT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RC_APPOINTMENT = new FTSFunction("HR_RC_APPOINTMENT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_CANDIDATES_POSITION_VIEW = new FTSFunction("HR_CANDIDATES_POSITION_VIEW", "HRM", true, true, true, true, false);
        public static FTSFunction HR_CANDIDATES_DOCUMENT_DETAIL = new FTSFunction("HR_CANDIDATES_DOCUMENT_DETAIL", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_SELECTED_EMPLOYEE = new FTSFunction("PR_ITEM_SELECTED_EMPLOYEE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_PRICE_STEP = new FTSFunction("PR_ITEM_PRICE_STEP", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_PLAN_ORGANIZATION = new FTSFunction("PR_ITEM_PLAN_ORGANIZATION", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_PETA = new FTSFunction("PR_SALARY_PETA", "HRM", true, true, true, true, false);
        public static FTSFunction PR_FUNDS_SALARY = new FTSFunction("PR_FUNDS_SALARY", "HRM", true, true, true, true, false);
        public static FTSFunction PR_TP_ADJUSTMENT_VOLUME_VEHICLE = new FTSFunction("PR_TP_ADJUSTMENT_VOLUME_VEHICLE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_STORAGE_PROFILE = new FTSFunction("HR_STORAGE_PROFILE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_LIST_CANDIDATES_RECRUITMENT = new FTSFunction("HR_LIST_CANDIDATES_RECRUITMENT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_LEVEL_MANAGEMENT = new FTSFunction("HR_LEVEL_MANAGEMENT", "HRM", true, true, true, true, false);
        public static FTSFunction DM_PR_METHOD = new FTSFunction("DM_PR_METHOD", "HRM", true, true, true, true, false);
        public static FTSFunction HR_MAINBOARD_VIEW_EMPLOYEE = new FTSFunction("HR_MAINBOARD_VIEW_EMPLOYEE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_CERFITICATION = new FTSFunction("HR_EMPLOYEE_CERFITICATION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_CONTRACT = new FTSFunction("HR_EMPLOYEE_CONTRACT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_EDUCATION = new FTSFunction("HR_EMPLOYEE_EDUCATION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_EMERGENCY_CONTACT = new FTSFunction("HR_EMPLOYEE_EMERGENCY_CONTACT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_ADDRESS = new FTSFunction("HR_EMPLOYEE_ADDRESS", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_HEALTH = new FTSFunction("HR_EMPLOYEE_HEALTH", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_HISTORY = new FTSFunction("HR_EMPLOYEE_HISTORY", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_IMAGE = new FTSFunction("HR_EMPLOYEE_IMAGE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_FOREIGN_LANGUAGE = new FTSFunction("HR_FOREIGN_LANGUAGE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_LEAVE = new FTSFunction("HR_EMPLOYEE_LEAVE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_LEVEL = new FTSFunction("HR_EMPLOYEE_LEVEL", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_OTHER = new FTSFunction("HR_EMPLOYEE_OTHER", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_POLITICS = new FTSFunction("HR_EMPLOYEE_POLITICS", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_POSITION = new FTSFunction("HR_EMPLOYEE_POSITION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_PROFILE = new FTSFunction("HR_EMPLOYEE_PROFILE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_REWARDS_FAULTS = new FTSFunction("HR_EMPLOYEE_REWARDS_FAULTS", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_SKILL = new FTSFunction("HR_SKILL", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_STATUS = new FTSFunction("HR_EMPLOYEE_STATUS", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_TRAINING = new FTSFunction("HR_TRAINING", "HRM", true, true, true, true, false);
        public static FTSFunction HR_LABOR_PLAN = new FTSFunction("HR_LABOR_PLAN", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INFO_ALARM = new FTSFunction("HR_INFO_ALARM", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INFO_BIRTHDAY = new FTSFunction("HR_INFO_BIRTHDAY", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INFO_PROFILE = new FTSFunction("HR_INFO_PROFILE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_LEAVE_INFO = new FTSFunction("HR_LEAVE_INFO", "HRM", true, true, true, true, false);

        public static FTSFunction HR_SALARY_LEVEL = new FTSFunction("HR_SALARY_LEVEL", "HRM", true, true, true, true, false);
        public static FTSFunction DM_HR_WARNING = new FTSFunction("DM_HR_WARNING", "SHARE", true, true, true, true, false);
        public static FTSFunction HR_CANDIDATES_INFO = new FTSFunction("HR_CANDIDATES_INFO", "HRM", true, true, true, true, false);
        public static FTSFunction HR_CANDIDATES_POSITION = new FTSFunction("HR_CANDIDATES_POSITION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RECRUITMENT = new FTSFunction("HR_RECRUITMENT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_RESULT_INTERVIEW = new FTSFunction("HR_RESULT_INTERVIEW", "HRM", true, true, true, true, false);
        //SI
        public static FTSFunction HR_INSURANCE = new FTSFunction("HR_INSURANCE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INS_OPTION = new FTSFunction("HR_INS_OPTION", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INS_PERIOD = new FTSFunction("HR_INS_PERIOD", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INS_MAIN = new FTSFunction("HR_INS_MAIN", "HRM", true, true, true, true, false);
        public static FTSFunction HR_INS_EMPLOYEE = new FTSFunction("HR_INS_EMPLOYEE", "HRM", true, true, true, true, false);
        public static FTSFunction DM_HRM_INS_REASON_TYPE = new FTSFunction("DM_HRM_INS_REASON_TYPE", "HRM", true, true, true, true, false);

        //TIME
        public static FTSFunction DM_HR_SHIFT = new FTSFunction("DM_HR_SHIFT", "HRM", true, true, true, true, false);
        public static FTSFunction HR_TIME_CHECKINOUT = new FTSFunction("HR_TIME_CHECKINOUT", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_DEVICE = new FTSFunction("HR_TIME_DEVICE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_TIME_FINGER = new FTSFunction("HR_TIME_FINGER", "HRM", true, true, true, true, false);
        public static FTSFunction HR_TIMEKEEPING_LOCK = new FTSFunction("HR_TIMEKEEPING_LOCK", "HRM", true, true, true, true, false);
        public static FTSFunction HR_TIME_WORK = new FTSFunction("HR_TIME_WORK", "HRM", true, true, true, true, false);
        public static FTSFunction HR_LIST_CARD_CODE = new FTSFunction("HR_LIST_CARD_CODE", "HRM", true, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_SITUATION = new FTSFunction("HR_EMPLOYEE_SITUATION", "HRM", false, true, true, true, false);
        public static FTSFunction HR_SHIFT_PLAN = new FTSFunction("HR_SHIFT_PLAN", "HRM", true, true, true, true, false);
        public static FTSFunction HR_TIMESHEET_DETAIL = new FTSFunction("HR_TIMESHEET_DETAIL", "HRM", true, true, true, true, false);
        //SA
        public static FTSFunction PR_EXPENSE_PRICE = new FTSFunction("PR_EXPENSE_PRICE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_PLAN_BUDGET = new FTSFunction("PR_PLAN_BUDGET", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_TYPE = new FTSFunction("PR_SALARY_TYPE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_TIMESHEET_CONFIG = new FTSFunction("PR_TIMESHEET_CONFIG", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_INCOME_OTHER = new FTSFunction("PR_SALARY_INCOME_OTHER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_REDUCTION_OTHER = new FTSFunction("PR_SALARY_REDUCTION_OTHER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_REDUCTION_OTHER = new FTSFunction("PR_REDUCTION_OTHER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_TIMESHEET = new FTSFunction("PR_TIMESHEET", "HRM", true, true, true, true, false);

        public static FTSFunction PR_SALARY_DRIVER = new FTSFunction("PR_SALARY_DRIVER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ACTUAL_BUDGET = new FTSFunction("PR_ACTUAL_BUDGET", "HRM", true, true, true, true, false);
        public static FTSFunction PR_PIT_RATE = new FTSFunction("PR_PIT_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_PIT_REDUCATION = new FTSFunction("PR_PIT_REDUCATION", "HRM", true, true, true, true, false);
        public static FTSFunction PR_OTHER_PIT_REDUCATION = new FTSFunction("PR_OTHER_PIT_REDUCATION", "HRM", true, true, true, true, false);
        public static FTSFunction PR_OTHER_PIT_INCOME = new FTSFunction("PR_OTHER_PIT_INCOME", "HRM", true, true, true, true, false);
        public static FTSFunction PR_OTHER_INCOME = new FTSFunction("PR_OTHER_INCOME", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_ADJ_RATE = new FTSFunction("PR_ITEM_ADJ_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_TITLES = new FTSFunction("PR_SALARY_TITLES", "HRM", true, true, true, true, false);
        public static FTSFunction PR_DUTY_RATE = new FTSFunction("PR_DUTY_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_SALARY = new FTSFunction("PR_ITEM_SALARY", "HRM", true, true, true, true, false);
        public static FTSFunction PR_BASIC_SALARY = new FTSFunction("PR_BASIC_SALARY", "HRM", true, true, true, true, false);
        public static FTSFunction PR_BONUS_RATE = new FTSFunction("PR_BONUS_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_EXPENSE_POINT = new FTSFunction("PR_EXPENSE_POINT", "HRM", true, true, true, true, false);
        public static FTSFunction PR_EXPENSE_RATE = new FTSFunction("PR_EXPENSE_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_DRIVER_TITLE = new FTSFunction("PR_DRIVER_TITLE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_FUNDS_BUDGET = new FTSFunction("PR_FUNDS_BUDGET", "HRM", true, true, true, true, false);
        public static FTSFunction PR_EXPENSE_BUDGET = new FTSFunction("PR_EXPENSE_BUDGET", "HRM", true, true, true, true, true);
        public static FTSFunction PR_EXPENSE_BUDGET_BRANCH = new FTSFunction("PR_EXPENSE_BUDGET_BRANCH", "HRM", true, true, true, true, true);
        public static FTSFunction PR_SALARY_DETAIL = new FTSFunction("PR_SALARY_DETAIL", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_PIT_OTHER = new FTSFunction("PR_SALARY_PIT_OTHER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_REDUCTION_ACC = new FTSFunction("PR_SALARY_REDUCTION_ACC", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_REDUCTION = new FTSFunction("PR_SALARY_REDUCTION", "HRM", true, true, true, true, false);
        public static FTSFunction PR_PRINT_NUM_ODER = new FTSFunction("PR_PRINT_NUM_ODER", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_LEVEL = new FTSFunction("PR_SALARY_LEVEL", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY = new FTSFunction("PR_SALARY", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SALARY_BANKACC = new FTSFunction("PR_SALARY_BANKACC", "HRM", true, true, true, true, false);
        public static FTSFunction PR_SENIORITYALLOWANCES_RATE = new FTSFunction("PR_SENIORITYALLOWANCES_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_STEP_SALARY = new FTSFunction("PR_STEP_SALARY", "HRM", true, true, false, true, true);
        public static FTSFunction PR_PROJECT_TYPE = new FTSFunction("PR_PROJECT_TYPE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_PROJECT_STEP_RATE = new FTSFunction("PR_PROJECT_STEP_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_BONUS_TYPE = new FTSFunction("PR_BONUS_TYPE", "HRM", true, true, true, true, false);

        public static FTSFunction PR_ITEM_STEP = new FTSFunction("PR_ITEM_STEP", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_ORGANIZATION_LIST = new FTSFunction("PR_ITEM_ORGANIZATION_LIST", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_FIRST_LINE = new FTSFunction("PR_ITEM_FIRST_LINE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_PRICE = new FTSFunction("PR_ITEM_PRICE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_ITEM_OUTPUT = new FTSFunction("PR_ITEM_OUTPUT", "HRM", true, true, true, true, false);
        public static FTSFunction PR_NEW_ORG_ALLOWANCE = new FTSFunction("PR_NEW_ORG_ALLOWANCE", "HRM", true, true, true, true, false);

        public static FTSFunction PR_EXPENSE_ORGANIZATION_RATE = new FTSFunction("PR_EXPENSE_ORGANIZATION_RATE", "HRM", true, true, true, true, false);
        public static FTSFunction PR_EXPENSE_ORG_BUDGET = new FTSFunction("PR_EXPENSE_ORG_BUDGET", "HRM", true, true, true, true, false);

        //MAIN
        public static FTSFunction HRM_OPTION = new FTSFunction("HRM_OPTION", "HRM", true, false, false, false, true);
        public static FTSFunction HRM_DASHBOARD = new FTSFunction("HRM_DASHBOARD", "HRM", true, false, false, false, true);

        #endregion

        #region  button Nhan SU

        public static FTSFunction DM_TIME_DEVIVE_SYNCDATIME = new FTSFunction("DM_TIME_DEVIVE_SYNCDATIME", "HRM", false, true, true, true, false);
        public static FTSFunction HR_CANDIDATES_POSITION_LIST_BTN_CREATE = new FTSFunction("HR_CANDIDATES_POSITION_LIST_BTN_CREATE", "HRM", false, true, true, true, false);
        public static FTSFunction HR_RC_CLASSIFICATION_BTN_ALLOCATE = new FTSFunction("HR_RC_CLASSIFICATION_BTN_ALLOCATE", "HRM", false, true, true, true, false);
        public static FTSFunction DM_TIME_DEVIVE_SHUTDOWN = new FTSFunction("DM_TIME_DEVIVE_SHUTDOWN", "HRM", false, true, true, true, false);
        public static FTSFunction DM_TIME_DEVIVE_GETDATATIMELOG = new FTSFunction("DM_TIME_DEVIVE_GETDATATIMELOG", "HRM", false, true, true, true, false);
        public static FTSFunction DM_TIME_DEVIVE_UPDATEEMPLOYEE = new FTSFunction("DM_TIME_DEVIVE_UPDATEEMPLOYEE", "HRM", false, true, true, true, false);
        public static FTSFunction HR_RC_CLASSIFICATION_FINISH = new FTSFunction("HR_RC_CLASSIFICATION_FINISH", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_DELETE = new FTSFunction("HR_TIME_WORK_DELETE", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_INSERT_STOPPAGE_TIME = new FTSFunction("HR_TIME_WORK_INSERT_STOPPAGE_TIME", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_INSERT_EDITOVER = new FTSFunction("HR_TIME_WORK_INSERT_EDITOVER", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_INSERT_EDITDAYWORK = new FTSFunction("HR_TIME_WORK_INSERT_EDITDAYWORK", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_PLANOVERTIME = new FTSFunction("HR_TIME_WORK_PLANOVERTIME", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_CLOCK = new FTSFunction("HR_TIME_WORK_CLOCK", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_EDITOUTTIME = new FTSFunction("HR_TIME_WORK_EDITOUTTIME", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_GETDATA = new FTSFunction("HR_TIME_WORK_GETDATA", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_LOADDATA = new FTSFunction("HR_TIME_WORK_LOADDATA", "HRM", false, true, true, true, false);
        public static FTSFunction HR_TIME_WORK_INSERTCHECKINOUT = new FTSFunction("HR_TIME_WORK_INSERTCHECKINOUT", "HRM", false, true, true, true, false);
        public static FTSFunction HR_PR_TIMESHEET_CREATE = new FTSFunction("HR_PR_TIMESHEET_CREATE", "HRM", false, true, true, true, false);
        public static FTSFunction HR_PR_TIMESHEET_FORMUALAR = new FTSFunction("HR_PR_TIMESHEET_FORMUALAR", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_CALDUTY = new FTSFunction("PR_SALARY_CALDUTY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_CALSALARY = new FTSFunction("PR_SALARY_CALSALARY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_CALPIT = new FTSFunction("PR_SALARY_CALPIT", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_CLOSESALARY = new FTSFunction("PR_SALARY_CLOSESALARY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_PRINTSALARY = new FTSFunction("PR_SALARY_PRINTSALARY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_TIMESHEET = new FTSFunction("PR_SALARY_TIMESHEET", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_VIEWSALARY = new FTSFunction("PR_SALARY_VIEWSALARY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_EDITSALARY = new FTSFunction("PR_SALARY_EDITSALARY", "HRM", false, true, true, true, false);
        public static FTSFunction PR_SALARY_CALBH = new FTSFunction("PR_SALARY_CALBH", "HRM", false, true, true, true, false);

        public static FTSFunction HR_EMPLOYEE_BANK_ACCOUNT = new FTSFunction("HR_EMPLOYEE_BANK_ACCOUNT", "HRM", false, true, true, true, false);
        public static FTSFunction DM_HR_GROUP_SALARY = new FTSFunction("DM_HR_GROUP_SALARY", "HRM", false, true, true, true, false);
        public static FTSFunction HR_EMPLOYEE_UP_SALARY_VIEW = new FTSFunction("HR_EMPLOYEE_UP_SALARY_VIEW", "HRM", true, true, true, true, false);
        public static FTSFunction DM_HRM_SCALE_OF_CIVIL = new FTSFunction("DM_HRM_SCALE_OF_CIVIL", "HRM", true, true, true, true, false);

        #endregion

        #region Kế toán

        public static FTSFunction ASSET_DEP = new FTSFunction("ASSET_DEP", "ACC", false, true, true, true, false);
        public static FTSFunction FA_LISTING = new FTSFunction("FA_LISTING", "ACC", true, false, false, false, false);

        public static FTSFunction CA_ACCOUNT_CONFIG = new FTSFunction("CA_ACCOUNT_CONFIG", "ACC", false, true, true, true, false);
        public static FTSFunction CA_BOM = new FTSFunction("CA_BOM", "ACC", false, true, true, true, false);
        public static FTSFunction CA_RATIO = new FTSFunction("CA_RATIO", "ACC", false, true, true, true, false);
        public static FTSFunction CA_EXPENSE_RESULT = new FTSFunction("CA_EXPENSE_RESULT", "ACC", false, false, false, false, true);
        public static FTSFunction CA_EXPENSE = new FTSFunction("CA_EXPENSE", "ACC", false, false, false, false, true);
        public static FTSFunction CA_EXPENSE_DECREASE = new FTSFunction("CA_EXPENSE_DECREASE", "ACC", false, false, false, false, true);
        public static FTSFunction CA_BALANCE = new FTSFunction("CA_BALANCE", "ACC", false, false, false, false, true);
        public static FTSFunction CA_BEGINNING_QUANTITY = new FTSFunction("CA_BEGINNING_QUANTITY", "ACC", false, false, false, false, true);
        public static FTSFunction CA_FINISHED_QUANTITY = new FTSFunction("CA_FINISHED_QUANTITY", "ACC", false, false, false, false, true);
        public static FTSFunction CA_PRODUCT_COST = new FTSFunction("CA_PRODUCT_COST", "ACC", false, false, false, false, true);
        public static FTSFunction CA_BUDGET = new FTSFunction("CA_BUDGET", "ACC", true, true, true, true, false);
        public static FTSFunction COST_APPLICATION = new FTSFunction("COST_APPLICATION", "ACC", false, true, true, true, false);
        public static FTSFunction TOOL_ALLOCATION = new FTSFunction("TOOL_ALLOCATION", "ACC", false, true, true, true, false);
        public static FTSFunction CONTRACT = new FTSFunction("CONTRACT", "ACC", true, true, true, true, false);
        public static FTSFunction CONTRACT_PAYMENT = new FTSFunction("CONTRACT_PAYMENT", "ACC", true, true, true, true, false);
        public static FTSFunction CONTRACT_IMPLEMENTATION = new FTSFunction("CONTRACT_IMPLEMENTATION", "ACC", true, true, true, true, false);
        public static FTSFunction CONTRACT_RATE = new FTSFunction("CONTRACT_RATE", "ACC", true, true, true, true, false);

        public static FTSFunction SALE_BASE_PRICE_LISTING = new FTSFunction("SALE_BASE_PRICE_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction SALE_DISCOUNT_LISTING = new FTSFunction("SALE_DISCOUNT_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction SALE_PAYMENT = new FTSFunction("SALE_PAYMENT", "ACC", true, false, false, false, true);
        public static FTSFunction SALE_LISTING = new FTSFunction("SALE_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction SO_LISTING = new FTSFunction("SO_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction SBO_LISTING = new FTSFunction("SBO_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction SALE_BALANCE = new FTSFunction("SALE_BALANCE", "ACC", true, false, false, false, false);
        public static FTSFunction SALE_ORDER_APPROVE = new FTSFunction("SALE_ORDER_APPROVE", "ACC", false, false, false, false, true);
        public static FTSFunction SALE_ORDER_APPROVE_EXCLUDE_DEBIT = new FTSFunction("SALE_ORDER_APPROVE_EXCLUDE_DEBIT", "ACC", false, false, false, false, true);
        public static FTSFunction TRAN_SBP = new FTSFunction("TRAN_SBP", "ACC", true, true, true, true, false);
        public static FTSFunction BBCNOAR = new FTSFunction("BB_CNO_AR", "ACC", false, false, false, false, true);
        public static FTSFunction BBCNOAP = new FTSFunction("BB_CNO_AP", "ACC", false, false, false, false, true);
        public static FTSFunction SBO_RATE = new FTSFunction("SBO_RATE", "ACC", false, false, false, false, true);
        public static FTSFunction PURCHASE_PRICE = new FTSFunction("PURCHASE_PRICE", "ACC", true, true, true, true, false);
        public static FTSFunction PURCHASE_FORECAST = new FTSFunction("PURCHASE_FORECAST", "ACC", true, true, true, true, false);
        public static FTSFunction PURCHASE_PAYMENT = new FTSFunction("PURCHASE_PAYMENT", "ACC", true, false, false, false, true);
        public static FTSFunction PURCHASE_LISTING = new FTSFunction("PURCHASE_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction PURCHASE_BALANCE = new FTSFunction("PURCHASE_BALANCE", "ACC", true, false, false, false, false);
        public static FTSFunction PURCHASE_COST_APPLICATION = new FTSFunction("PURCHASE_COST_APPLICATION", "ACC", false, false, false, false, true);
        public static FTSFunction PO_LISTING = new FTSFunction("PO_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction PO_SUMMARY = new FTSFunction("PO_SUMMARY", "ACC", true, false, false, false, false);

        public static FTSFunction BALANCE = new FTSFunction("BALANCE", "ACC", false, true, true, true, false);
        public static FTSFunction JOURNAL_LISTING = new FTSFunction("JOURNAL_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction VOUCHER_LISTING = new FTSFunction("VOUCHER_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction LEDGER_LISTING = new FTSFunction("LEDGER_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction BUDGET = new FTSFunction("BUDGET", "ACC", true, true, true, true, false);
        public static FTSFunction RATE_ADJUSTMENT = new FTSFunction("RATE_ADJUSTMENT", "ACC", false, false, false, false, true);
        public static FTSFunction CLOSING_ENTRY = new FTSFunction("CLOSING_ENTRY", "ACC", false, true, true, true, false);
        public static FTSFunction TRANSACTION_REGISTER = new FTSFunction("TRANSACTION_REGISTER", "ACC", false, true, true, true, false);

        public static FTSFunction WAREHOUSE_BALANCE = new FTSFunction("WAREHOUSE_BALANCE", "ACC", false, true, true, true, false);
        public static FTSFunction WAREHOUSE_BALANCE_ACTUAL = new FTSFunction("WAREHOUSE_BALANCE_ACTUAL", "ACC", false, true, true, true, false);
        public static FTSFunction WAREHOUSE_LISTING = new FTSFunction("WAREHOUSE_LISTING", "ACC", true, false, false, false, false);
        public static FTSFunction AVERAGE_COST = new FTSFunction("AVERAGE_COST", "ACC", false, false, false, false, true);
        public static FTSFunction ADJUSTMENT = new FTSFunction("ADJUSTMENT", "ACC", false, true, true, true, false);
        public static FTSFunction ADJUSTMENT_ASSET = new FTSFunction("ADJUSTMENT_ASSET", "ACC", false, true, true, true, false);

        public static FTSFunction EXPORT_VAT = new FTSFunction("EXPORT_VAT", "ACC", false, false, false, false, true);
        public static FTSFunction DM_PR_DETAIL_CREDIT_LIMIT = new FTSFunction("DM_PR_DETAIL_CREDIT_LIMIT", "ACC", false, true, true, true, false);
        public static FTSFunction SII_LISTING = new FTSFunction("SII_LISTING", "ACC", false, true, true, true, false);
        public static FTSFunction DM_ITEM_WAREHOUSE_LIMIT = new FTSFunction("DM_ITEM_WAREHOUSE_LIMIT", "ACC", false, true, true, true, false);

        #endregion

        #region Khách sạn

        public static FTSFunction HT_DISCOUNT = new FTSFunction("HT_DISCOUNT", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_ROOM_STATUS = new FTSFunction("HT_ROOM_STATUS", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_RATE = new FTSFunction("HT_RATE", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_TRACE = new FTSFunction("HT_TRACE", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_DEPOSIT = new FTSFunction("HT_DEPOSIT", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_CDR = new FTSFunction("HT_CDR", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_WAKEUP = new FTSFunction("HT_WAKEUP", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_MESSAGE = new FTSFunction("HT_MESSAGE", "HOTEL", true, true, true, true, false);

        public static FTSFunction HT_CHARGES_CHECK_OUT_AFTER = new FTSFunction("HT_CHARGES_CHECK_OUT_AFTER", "HOTEL", true, true, true, true, false);

        public static FTSFunction HT_CHARGES_CHECK_IN_BEFORE = new FTSFunction("HT_CHARGES_CHECK_IN_BEFORE", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_ROOM_OUT_OF_ORDER = new FTSFunction("HT_ROOM_OUT_OF_ORDER", "HOTEL", true, true, true, true, false);

        public static FTSFunction HT_MINIBAR_DEFAULT = new FTSFunction("HT_MINIBAR_DEFAULT", "HOTEL", true, true, true, true, false);

        public static FTSFunction HT_COMMISSION = new FTSFunction("HT_COMMISSION", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_FOLIO = new FTSFunction("HT_FOLIO", "HOTEL", true, true, true, true, false);
        public static FTSFunction HT_BILLING = new FTSFunction("HT_BILLING", "HOTEL", true, true, true, true, true);

        public static FTSFunction HT_OPTION = new FTSFunction("HT_OPTION", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_NIGHT_AUDIT = new FTSFunction("HT_NIGHT_AUDIT", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_PAYMENT = new FTSFunction("HT_PAYMENT", "HOTEL", true, true, true, true, true);

        public static FTSFunction HT_RE_PAYMENT = new FTSFunction("HT_RE_PAYMENT", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_CHECK_IN = new FTSFunction("HT_CHECK_IN", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_CHECK_OUT = new FTSFunction("HT_CHECK_OUT", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_ROOM_PLAN = new FTSFunction("HT_ROOM_PLAN", "HOTEL", true, false, false, false, false);

        public static FTSFunction HT_ROOM_CLASS_PLAN = new FTSFunction("HT_ROOM_CLASS_PLAN", "HOTEL", true, false, true, false, false);

        public static FTSFunction HT_MOVE_ROOM = new FTSFunction("HT_MOVE_ROOM", "HOTEL", false, false, false, false, true);

        public static FTSFunction HT_ROOM_ASSIGNMENT = new FTSFunction("HT_ROOM_ASSIGNMENT", "HOTEL", false, false, false, false, true);
        /*
        public static FTSFunction TRAN_HT_NKT = new FTSFunction("TRAN_HT_NKT", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_HT_XP = new FTSFunction("TRAN_HT_XP", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_HT_XSD = new FTSFunction("TRAN_HT_XSD", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_HT_XNH = new FTSFunction("TRAN_HT_XNH", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_LAUNDARY = new FTSFunction("TRAN_LAUNDARY", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_BOOKING = new FTSFunction("TRAN_BOOKING", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_BOOKING_HOURLY = new FTSFunction("TRAN_BOOKING_HOURLY", "HOTEL", true, true, true, true, false);
        public static FTSFunction TRAN_BOOKING_IND = new FTSFunction("TRAN_BOOKING_IND", "HOTEL", true, true, true, true, false);
        */
        public static FTSFunction HT_CANCEL_CHECK_OUT = new FTSFunction("HT_CANCEL_CHECK_OUT", "HOTEL", false, false, false, false, true);
        public static FTSFunction HT_HOURLY_TO_DAILY = new FTSFunction("HT_HOURLY_TO_DAILY", "HOTEL", false, false, false, false, true);
        public static FTSFunction HT_SHIFT_LISTING = new FTSFunction("HT_SHIFT_LISTING", "HOTEL", true, false, false, false, false);

        #endregion

        #region Vận tải

        #region Nhiên liệu

        public static FTSFunction TP_FUEL_CONSUMPTION = new FTSFunction("TP_FUEL_CONSUMPTION", "SHARE", false, true, true, true, false);
        public static FTSFunction DM_VEHICLE_OIL_RATE = new FTSFunction("DM_VEHICLE_OIL_RATE", "TP", false, true, true, true, false);
        public static FTSFunction TP_PUMP = new FTSFunction("TP_PUMP", "TP", false, true, true, true, false);

        #endregion

        #region Chi phí

        public static FTSFunction TP_FUEL_BALANCE = new FTSFunction("TP_FUEL_BALANCE", "TP", false, true, true, true, false);
        public static FTSFunction TP_COST = new FTSFunction("TP_COST", "TP", false, true, true, true, false);
        public static FTSFunction TP_PRICE_RANGES = new FTSFunction("TP_PRICE_RANGES", "TP", false, true, true, true, false);
        public static FTSFunction TP_BRIDGE_TICKET_PRICE = new FTSFunction("TP_BRIDGE_TICKET_PRICE", "TP", false, true, true, true, false);
        public static FTSFunction TP_MONTHLY_TICKET = new FTSFunction("TP_MONTHLY_TICKET", "TP", false, true, true, true, false);
        public static FTSFunction TP_LOADING_COST = new FTSFunction("TP_LOADING_COST", "TP", false, true, true, true, false);

        #endregion

        #region Lệnh vận chuyển

        public static FTSFunction TP_ORDER = new FTSFunction("TP_ORDER", "TP", false, true, true, true, false);
        public static FTSFunction TP_CONFIRM = new FTSFunction("TP_CONFIRM", "TP", false, true, true, true, false);

        #endregion

        #endregion

        #region Ban hang

        public static FTSFunction POS_SALE_LISTING = new FTSFunction("POS_SALE_LISTING", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_LISTING = new FTSFunction("POS_SO_LISTING", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_STATUS_DRAFT = new FTSFunction("POS_SO_STATUS_DRAFT", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_STATUS_APPROVED = new FTSFunction("POS_SO_STATUS_APPROVED", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_STATUS_DEPOSIT = new FTSFunction("POS_SO_STATUS_DEPOSIT", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_STATUS_PAYMENT = new FTSFunction("POS_SO_STATUS_PAYMENT", "POS", true, false, false, false, false);
        public static FTSFunction POS_SO_STATUS_SALE = new FTSFunction("POS_SO_STATUS_SALE", "POS", true, false, false, false, false);
        public static FTSFunction POS_SHIFT_LISTING = new FTSFunction("POS_SHIFT_LISTING", "POS", true, false, false, false, false);
        public static FTSFunction POS_PAYMENT = new FTSFunction("POS_PAYMENT", "POS", true, false, false, false, false);
        public static FTSFunction POS_SALE_INVOICE_LISTING = new FTSFunction("POS_SALE_INVOICE_LISTING", "POS", true, false, false, false, false);
        

        public static FTSFunction TRAN_POS_SALE_INVOICE = new FTSFunction("TRAN_POS_SALE_INVOICE", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_SALE_XB = new FTSFunction("TRAN_POS_SALE_XB", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_SALE_XCK = new FTSFunction("TRAN_POS_SALE_XCK", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_SALE_XK = new FTSFunction("TRAN_POS_SALE_XK", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_SHIFT = new FTSFunction("TRAN_POS_SHIFT", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_SO = new FTSFunction("TRAN_POS_SO", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_PURCHASE = new FTSFunction("TRAN_POS_PURCHASE", "POS", true, false, false, false, false);
        public static FTSFunction TRAN_POS_PURCHASE_NK = new FTSFunction("TRAN_POS_PURCHASE_NK", "POS", true, false, false, false, false);

        public static FTSFunction POS_ITEM_PRICE_FOR_DELIVERY = new FTSFunction("POS_ITEM_PRICE_FOR_DELIVERY", "POS", true, false, false, false, false);

        #endregion
        #region Prints
        public static FTSFunction PRINTS_WAREHOUSE_BALANCE = new FTSFunction("PRINTS_WAREHOUSE_BALANCE", "FIN", true, true, true, true, false);
        public static FTSFunction PRINTS_APPROVE = new FTSFunction("PRINTS_APPROVE", "FIN", false, false, false, false, true);
        #endregion

        #region Chứng khoán

        public static FTSFunction DM_SECURITY_CLASS = new FTSFunction("DM_SECURITY_CLASS", "SHARE", true, true, true, true, false);
        public static FTSFunction DM_SECURITY = new FTSFunction("DM_SECURITY", "SHARE", true, true, true, true, false);
        public static FTSFunction SECURITY_BALANCE = new FTSFunction("SECURITY_BALANCE", "SHARE", true, true, true, true, false);
        public static FTSFunction SECURITY_COST = new FTSFunction("SECURITY_COST", "ACC", false, false, false, false, true);
        public static FTSFunction SECURITY_RATE = new FTSFunction("SECURITY_RATE", "ACC", false, false, false, false, true);

        #endregion

        public static List<ItemCombobox> GetFunctionGroupList(FTSMain ftsmain) {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox("SYS", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "SYS")));
            list.Add(new ItemCombobox("SHARE", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "SHARE")));
            list.Add(new ItemCombobox("ACC", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "ACC")));
            list.Add(new ItemCombobox("HOTEL", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "HOTEL")));
            list.Add(new ItemCombobox("POS", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "POS")));
            list.Add(new ItemCombobox("TP", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "TP")));
            list.Add(new ItemCombobox("HRM", ftsmain.MsgManager.GetMessage("FUNCTION_GROUP_NAME_" + "HRM")));
            return list;
        }

        public static List<ItemCombobox> GetFunctionList(FTSMain ftsmain) {
            List<ItemCombobox> list = new List<ItemCombobox>();

            #region Hệ thống

            list.Add(new ItemCombobox(SYS_LOCK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SYS_LOCK.Name), "SYS"));
            list.Add(new ItemCombobox(SEC_PERMISSION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SEC_PERMISSION.Name), "SYS"));
            list.Add(new ItemCombobox(SYS_TRAN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SYS_TRAN.Name), "SYS"));
            list.Add(new ItemCombobox(SYS_MENU.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SYS_MENU.Name), "SYS"));
            list.Add(new ItemCombobox(SYS_REPORT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SYS_REPORT.Name), "SYS"));
            list.Add(new ItemCombobox(SYS_TRAN_DUPLICATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SYS_TRAN_DUPLICATE.Name), "SYS"));
            list.Add(new ItemCombobox(DM_ORGANIZATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ORGANIZATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ORGANIZATION_MAPPING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ORGANIZATION_MAPPING.Name), "SHARE"));
            list.Add(new ItemCombobox(EXPORT_REPORT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + EXPORT_REPORT.Name), "SYS"));
            list.Add(new ItemCombobox(IMPORT_REPORT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + IMPORT_REPORT.Name), "SYS"));
            list.Add(new ItemCombobox(OPTION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + OPTION.Name), "SYS"));
            list.Add(new ItemCombobox(DM_TEMPLATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_TEMPLATE.Name), "SYS"));
            list.Add(new ItemCombobox(TRANSACTION_APPROVE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRANSACTION_APPROVE.Name), "SYS"));
            list.Add(new ItemCombobox(LOGGING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + LOGGING.Name), "SYS"));

            #endregion

            #region chứng khoán

            list.Add(new ItemCombobox(DM_SECURITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SECURITY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SECURITY_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SECURITY_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(SECURITY_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SECURITY_BALANCE.Name), "SHARE"));
            list.Add(new ItemCombobox(SECURITY_COST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SECURITY_COST.Name), "SCR"));
            list.Add(new ItemCombobox(SECURITY_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SECURITY_RATE.Name), "SCR"));

            #endregion

            #region Danh mục

            list.Add(new ItemCombobox(DM_PAYMENT_ACCOUNT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PAYMENT_ACCOUNT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_INSURANCE_SOURCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_INSURANCE_SOURCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_REINSURANCE_SOURCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_REINSURANCE_SOURCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BUDGET.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BUDGET_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BUDGET_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_HOLIDAY_INFO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_HOLIDAY_INFO.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PERIOD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PERIOD.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CONTRACT_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CONTRACT_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ACCOUNT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ACCOUNT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_AIRLINE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_AIRLINE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ZONE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ZONE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_AREA_CODE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_AREA_CODE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PBX_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PBX_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_AIRPORT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_AIRPORT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_AMENITIES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_AMENITIES.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BUILDING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BUILDING.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BANK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BANK.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_COUNTRY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_COUNTRY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CURRENCY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CURRENCY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ETHNICS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ETHNICS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_COMMISSION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_COMMISSION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FIXED_EXCHANGE_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FIXED_EXCHANGE_RATE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EXCHANGE_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EXCHANGE_RATE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EXCHANGE_RATE_EXTRA.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EXCHANGE_RATE_EXTRA.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EXPENSE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EXPENSE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EXPENSE_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EXPENSE_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EXTRA_CHARGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EXTRA_CHARGE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FA_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FA_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FA_OPERATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FA_OPERATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FA_SOURCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FA_SOURCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FA_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FA_STATUS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FLOOR.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FLOOR.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_GUEST_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_GUEST_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_GUEST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_GUEST.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_VB.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_VB.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_CLASS1.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_CLASS1.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_OP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_OP.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_STATUS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_SOURCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_SOURCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_JOB.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_JOB.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_JOB_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_JOB_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_JOB_ITEM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_JOB_ITEM.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_MARKET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_MARKET.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_NATIONALITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_NATIONALITY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PR_DETAIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_DETAIL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PR_DETAIL_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_DETAIL_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_RATE_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_RATE_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_RELIGION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_RELIGION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROOM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROOM.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROOM_AMENITIES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROOM_AMENITIES.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROOM_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROOM_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SEASON.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SEASON.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SERVICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SERVICE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_UNIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_UNIT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_UNIT_CONVERSION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_UNIT_CONVERSION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VAT_TAX.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VAT_TAX.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_WAREHOUSE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_WAREHOUSE.Name), "SHARE"));
            list.Add(new ItemCombobox(WAREHOUSE_MAPPING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + WAREHOUSE_MAPPING.Name), "SHARE"));
            list.Add(new ItemCombobox(ORGANIZATION_MAPPING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + ORGANIZATION_MAPPING.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_WAREHOUSE_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_WAREHOUSE_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PAYMENT_METHOD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PAYMENT_METHOD.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PAYMENT_TERM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PAYMENT_TERM.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PRICE_LEVEL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PRICE_LEVEL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SHIPPING_METHOD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SHIPPING_METHOD.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SHIFT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SHIFT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PUMP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PUMP.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_REGION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_REGION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_INDUSTRY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_INDUSTRY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SHIPPING_ADDRESS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SHIPPING_ADDRESS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BRIDGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BRIDGE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BRIDGE_ROUTE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BRIDGE_ROUTE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROUTE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROUTE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROUTE_DISTANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROUTE_DISTANCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROUTE_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROUTE_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROUTE_POINT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROUTE_POINT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ROUTE_POINT_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ROUTE_POINT_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_WAREHOUSE_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_WAREHOUSE_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_QUALITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_QUALITY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_OIL_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_OIL_RATE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_EXTRA.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_EXTRA.Name), "SHARE"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_INFO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_INFO.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_WAREHOUSE_LIMIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_WAREHOUSE_LIMIT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_MAPINFO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_MAPINFO.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_MEMBERSHIP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_MEMBERSHIP.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_MEMBERSHIP_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_MEMBERSHIP_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PRINTS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PRINTS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PRINTS_SERIE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PRINTS_SERIE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PRINTS_BATCH.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PRINTS_BATCH.Name), "SHARE"));
            list.Add(new ItemCombobox(MEMBERSHIP_LOG.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + MEMBERSHIP_LOG.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_DRIVER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_DRIVER.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ITEM_COMBO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_COMBO.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ADDRESS_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ADDRESS_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SPECIALIZED.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SPECIALIZED.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_CAREER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_CAREER.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_AGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_AGE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ALLOWANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ALLOWANCE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_BONUS_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_BONUS_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CABINET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CABINET.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CERTIFICATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CERTIFICATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_COMMUNES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_COMMUNES.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CONTRACT_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CONTRACT_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_DISTRICTS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_DISTRICTS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EDUCATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EDUCATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EMPLOYEE_LEVEL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EMPLOYEE_LEVEL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EMPLOYEE_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EMPLOYEE_STATUS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_ETHNICS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ETHNICS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_FOREIGN_LANGUAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_FOREIGN_LANGUAGE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HOSPITAL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HOSPITAL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_HOLIDAY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HOSPITAL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_LEAVE_REASON.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_LEAVE_REASON.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_ORGANIZATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_ORGANIZATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PR_ORGANIZATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_ORGANIZATION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HRM_RELATIONSHIP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HRM_RELATIONSHIP.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_SHIFT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_SHIFT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_WORK_PLACE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_WORK_PLACE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_HR_ZODIAC.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_ZODIAC.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_MARITAL_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_MARITAL_STATUS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_DOCUMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_DOCUMENT.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_POSITION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_POSITION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PRODUCTION_STEP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PRODUCTION_STEP.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PROVINCES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PROVINCES.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_REASONSALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_REASONSALARY.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_REDUCTION_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_REDUCTION_OTHER.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_RELIGION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_RELIGION.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SALARY_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SALARY_TYPE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SENIORITYALLOWANCES_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SENIORITYALLOWANCES_RATE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SKILL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SKILL.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_EMPLOYEE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_EMPLOYEE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PR_EXPENSE_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_EXPENSE_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_PR_EXPENSE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_EXPENSE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_CHAPTER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_CHAPTER.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_SO_CLASS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_SO_CLASS.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_OWNER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_OWNER.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_USAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_USAGE.Name), "SHARE"));
            list.Add(new ItemCombobox(DM_VEHICLE_CAPACITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_VEHICLE_CAPACITY.Name), "SHARE"));

            #endregion

            #region Vận tải

            #region Nhiên liệu

            list.Add(new ItemCombobox(TP_FUEL_CONSUMPTION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_FUEL_CONSUMPTION.Name), "TP"));
            list.Add(new ItemCombobox(TP_PUMP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_PUMP.Name), "TP"));

            #endregion

            #region Chi phí

            list.Add(new ItemCombobox(TP_FUEL_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_FUEL_BALANCE.Name), "TP"));
            list.Add(new ItemCombobox(TP_COST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_COST.Name), "TP"));
            list.Add(new ItemCombobox(TP_PRICE_RANGES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_PRICE_RANGES.Name), "TP"));
            list.Add(new ItemCombobox(TP_BRIDGE_TICKET_PRICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_BRIDGE_TICKET_PRICE.Name), "TP"));
            list.Add(new ItemCombobox(TP_MONTHLY_TICKET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_MONTHLY_TICKET.Name), "TP"));
            list.Add(new ItemCombobox(TP_LOADING_COST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_LOADING_COST.Name), "TP"));

            #endregion

            #region Lệnh vận chuyển

            list.Add(new ItemCombobox(TP_ORDER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_ORDER.Name), "TP"));
            list.Add(new ItemCombobox(TP_CONFIRM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TP_CONFIRM.Name), "TP"));

            #endregion

            #endregion

            #region Kế toán

            list.Add(new ItemCombobox(ASSET_DEP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + ASSET_DEP.Name), "ACC"));
            list.Add(new ItemCombobox(FA_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + FA_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(CA_ACCOUNT_CONFIG.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_ACCOUNT_CONFIG.Name), "ACC"));
            list.Add(new ItemCombobox(CA_BOM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_BOM.Name), "ACC"));
            list.Add(new ItemCombobox(CA_RATIO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_RATIO.Name), "ACC"));
            list.Add(new ItemCombobox(CA_EXPENSE_RESULT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_EXPENSE_RESULT.Name), "ACC"));
            list.Add(new ItemCombobox(CA_EXPENSE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_EXPENSE.Name), "ACC"));
            list.Add(new ItemCombobox(CA_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_BALANCE.Name), "ACC"));
            list.Add(new ItemCombobox(CA_BEGINNING_QUANTITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_BEGINNING_QUANTITY.Name), "ACC"));
            list.Add(new ItemCombobox(CA_PRODUCT_COST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_PRODUCT_COST.Name), "ACC"));
            list.Add(new ItemCombobox(CA_EXPENSE_DECREASE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_EXPENSE_DECREASE.Name), "ACC"));
            list.Add(new ItemCombobox(CA_FINISHED_QUANTITY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_FINISHED_QUANTITY.Name), "ACC"));
            list.Add(new ItemCombobox(COST_APPLICATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + COST_APPLICATION.Name), "ACC"));
            list.Add(new ItemCombobox(TOOL_ALLOCATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TOOL_ALLOCATION.Name), "ACC"));
            list.Add(new ItemCombobox(CONTRACT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CONTRACT.Name), "ACC"));
            list.Add(new ItemCombobox(CONTRACT_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CONTRACT_PAYMENT.Name), "ACC"));
            list.Add(new ItemCombobox(CONTRACT_IMPLEMENTATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CONTRACT_IMPLEMENTATION.Name), "ACC"));
            list.Add(new ItemCombobox(CONTRACT_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CONTRACT_RATE.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_BASE_PRICE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_BASE_PRICE_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_DISCOUNT_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_DISCOUNT_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_PAYMENT.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(SO_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SO_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(SBO_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SBO_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_BALANCE.Name), "ACC"));
            list.Add(new ItemCombobox(TRAN_SBP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_SBP.Name), "ACC"));
            list.Add(new ItemCombobox(BBCNOAP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + BBCNOAP.Name), "ACC"));
            list.Add(new ItemCombobox(BBCNOAR.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + BBCNOAR.Name), "ACC"));
            list.Add(new ItemCombobox(SBO_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SBO_RATE.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_PRICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_PRICE.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_FORECAST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_FORECAST.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_PAYMENT.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_BALANCE.Name), "ACC"));
            list.Add(new ItemCombobox(PURCHASE_COST_APPLICATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PURCHASE_COST_APPLICATION.Name), "ACC"));
            list.Add(new ItemCombobox(BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + BALANCE.Name), "ACC"));
            list.Add(new ItemCombobox(JOURNAL_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + JOURNAL_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(VOUCHER_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + VOUCHER_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(LEDGER_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + LEDGER_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + BUDGET.Name), "ACC"));
            list.Add(new ItemCombobox(CA_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CA_BUDGET.Name), "ACC"));
            list.Add(new ItemCombobox(RATE_ADJUSTMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + RATE_ADJUSTMENT.Name), "ACC"));
            list.Add(new ItemCombobox(CLOSING_ENTRY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + CLOSING_ENTRY.Name), "ACC"));
            list.Add(new ItemCombobox(TRANSACTION_REGISTER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRANSACTION_REGISTER.Name), "ACC"));
            list.Add(new ItemCombobox(WAREHOUSE_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + WAREHOUSE_BALANCE.Name), "ACC"));
            list.Add(new ItemCombobox(WAREHOUSE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + WAREHOUSE_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(AVERAGE_COST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + AVERAGE_COST.Name), "ACC"));
            list.Add(new ItemCombobox(ADJUSTMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + ADJUSTMENT.Name), "ACC"));
            list.Add(new ItemCombobox(ADJUSTMENT_ASSET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + ADJUSTMENT_ASSET.Name), "ACC"));
            list.Add(new ItemCombobox(EXPORT_VAT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + EXPORT_VAT.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_ORDER_APPROVE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_ORDER_APPROVE.Name), "ACC"));
            list.Add(new ItemCombobox(SALE_ORDER_APPROVE_EXCLUDE_DEBIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SALE_ORDER_APPROVE_EXCLUDE_DEBIT.Name), "ACC"));
            list.Add(new ItemCombobox(DM_PR_DETAIL_CREDIT_LIMIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_DETAIL_CREDIT_LIMIT.Name), "ACC"));
            list.Add(new ItemCombobox(SII_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + SII_LISTING.Name), "ACC"));
            list.Add(new ItemCombobox(WAREHOUSE_BALANCE_ACTUAL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + WAREHOUSE_BALANCE_ACTUAL.Name), "ACC"));
            list.Add(new ItemCombobox(DM_ITEM_WAREHOUSE_LIMIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_ITEM_WAREHOUSE_LIMIT.Name), "ACC"));

            #endregion

            #region Khách sạn

            list.Add(new ItemCombobox(HT_DISCOUNT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_DISCOUNT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_ROOM_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_ROOM_STATUS.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_RATE.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_TRACE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_TRACE.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_DEPOSIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_DEPOSIT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_CDR.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CDR.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_WAKEUP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_WAKEUP.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_MESSAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_MESSAGE.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_CHARGES_CHECK_OUT_AFTER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CHARGES_CHECK_OUT_AFTER.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_CHARGES_CHECK_IN_BEFORE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CHARGES_CHECK_IN_BEFORE.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_ROOM_OUT_OF_ORDER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_ROOM_OUT_OF_ORDER.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_MINIBAR_DEFAULT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_MINIBAR_DEFAULT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_COMMISSION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_COMMISSION.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_FOLIO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_FOLIO.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_BILLING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_BILLING.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_OPTION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_OPTION.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_NIGHT_AUDIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_NIGHT_AUDIT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_PAYMENT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_RE_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_RE_PAYMENT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_CHECK_IN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CHECK_IN.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_CHECK_OUT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CHECK_OUT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_ROOM_PLAN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_ROOM_PLAN.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_ROOM_CLASS_PLAN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_ROOM_CLASS_PLAN.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_MOVE_ROOM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_MOVE_ROOM.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_ROOM_ASSIGNMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_ROOM_ASSIGNMENT.Name), "HOTEL"));
            /*
            list.Add(new ItemCombobox(TRAN_HT_NKT.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_HT_NKT.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_HT_XP.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_HT_XP.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_HT_XSD.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_HT_XSD.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_HT_XNH.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_HT_XNH.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_LAUNDARY.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_LAUNDARY.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_BOOKING.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_BOOKING.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_BOOKING_HOURLY.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_BOOKING_HOURLY.Name), "HOTEL"));
            list.Add(new ItemCombobox(TRAN_BOOKING_IND.Name,
                                      ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_BOOKING_IND.Name), "HOTEL"));
            */
            list.Add(new ItemCombobox(HT_CANCEL_CHECK_OUT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_CANCEL_CHECK_OUT.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_HOURLY_TO_DAILY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_HOURLY_TO_DAILY.Name), "HOTEL"));
            list.Add(new ItemCombobox(HT_SHIFT_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HT_SHIFT_LISTING.Name), "HOTEL"));

            #endregion

            #region Ban hang

            list.Add(new ItemCombobox(POS_SALE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SALE_LISTING.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_LISTING.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_STATUS_DRAFT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_STATUS_DRAFT.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_STATUS_APPROVED.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_STATUS_APPROVED.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_STATUS_DEPOSIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_STATUS_DEPOSIT.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_STATUS_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_STATUS_PAYMENT.Name), "POS"));
            list.Add(new ItemCombobox(POS_SO_STATUS_SALE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SO_STATUS_SALE.Name), "POS"));
            list.Add(new ItemCombobox(POS_SHIFT_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SHIFT_LISTING.Name), "POS"));
            list.Add(new ItemCombobox(POS_PAYMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_PAYMENT.Name), "POS"));
            list.Add(new ItemCombobox(POS_SALE_INVOICE_LISTING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_SALE_INVOICE_LISTING.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SALE_INVOICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SALE_INVOICE.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SALE_XB.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SALE_XB.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SALE_XCK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SALE_XCK.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SALE_XK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SALE_XK.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SHIFT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SHIFT.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_SO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_SO.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_PURCHASE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_PURCHASE.Name), "POS"));
            list.Add(new ItemCombobox(TRAN_POS_PURCHASE_NK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + TRAN_POS_PURCHASE_NK.Name), "POS"));
            list.Add(new ItemCombobox(POS_ITEM_PRICE_FOR_DELIVERY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + POS_ITEM_PRICE_FOR_DELIVERY.Name), "POS"));

            #endregion

            list.Add(new ItemCombobox(PRINTS_WAREHOUSE_BALANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PRINTS_WAREHOUSE_BALANCE.Name), "FIN"));
            list.Add(new ItemCombobox(PRINTS_APPROVE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PRINTS_APPROVE.Name), "FIN"));
            
            #region Nhansu

            list.Add(new ItemCombobox(DM_HR_GROUP_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_GROUP_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_BANK_ACCOUNT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_BANK_ACCOUNT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIMESHEET_DETAIL_VT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIMESHEET_DETAIL_VT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIMEKEEPING_LOCK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIMEKEEPING_LOCK.Name), "HRM"));
            list.Add(new ItemCombobox(HR_PLAN_STOPPAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_PLAN_STOPPAGE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_PLAN_OVERTIME_TEMP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_PLAN_OVERTIME_TEMP.Name), "HRM"));
            list.Add(new ItemCombobox(HR_PLAN_OVERTIME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_PLAN_OVERTIME.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_CHECKINOUT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_CHECKINOUT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INS_OPTION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INS_OPTION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INS_PERIOD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INS_PERIOD.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INS_EMPLOYEE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INS_EMPLOYEE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INSURANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INSURANCE.Name), "HRM"));
            list.Add(new ItemCombobox(DM_HRM_INS_REASON_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HRM_INS_REASON_TYPE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_RESULT_RECRUITMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_RESULT_RECRUITMENT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_POSITION_MANAGER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_POSITION_MANAGER.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_POSITION_DETAIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_POSITION_DETAIL.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_POSITION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_POSITION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_PLAN_POSITION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_PLAN_POSITION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_CAN_POINT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_CAN_POINT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_APPOINTMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_APPOINTMENT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_CANDIDATES_POSITION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_CANDIDATES_POSITION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_CANDIDATES_INFO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_CANDIDATES_INFO.Name), "HRM"));
            list.Add(new ItemCombobox(HR_CANDIDATES_DOCUMENT_DETAIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_CANDIDATES_DOCUMENT_DETAIL.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_SELECTED_EMPLOYEE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_SELECTED_EMPLOYEE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_PRICE_STEP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_PRICE_STEP.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_PLAN_ORGANIZATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_PLAN_ORGANIZATION.Name), "HRM"));
            list.Add(new ItemCombobox(PR_TIMESHEET_CONFIG.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_TIMESHEET_CONFIG.Name), "HRM"));
            list.Add(new ItemCombobox(PR_TIMESHEET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_TIMESHEET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_TYPE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_TITLES.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_TITLES.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_PETA.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_PETA.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_REDUCTION_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_REDUCTION_OTHER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_INCOME_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_INCOME_OTHER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_LEVEL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_LEVEL.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_DRIVER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_DRIVER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_DETAIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_DETAIL.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_REDUCTION_ACC.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_REDUCTION_ACC.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_PIT_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_PIT_OTHER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_REDUCTION_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_REDUCTION_OTHER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PLAN_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PLAN_BUDGET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PIT_REDUCATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PIT_REDUCATION.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PIT_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PIT_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PRINT_NUM_ODER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PRINT_NUM_ODER.Name), "HRM"));
            list.Add(new ItemCombobox(PR_OTHER_PIT_REDUCATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_OTHER_PIT_REDUCATION.Name), "HRM"));
            list.Add(new ItemCombobox(PR_OTHER_PIT_INCOME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_OTHER_PIT_INCOME.Name), "HRM"));
            list.Add(new ItemCombobox(PR_OTHER_INCOME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_OTHER_INCOME.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_ADJ_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_ADJ_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_FUNDS_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_FUNDS_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_FUNDS_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_FUNDS_BUDGET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_BUDGET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_BUDGET_BRANCH.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_BUDGET_BRANCH.Name), "HRM"));
            list.Add(new ItemCombobox(PR_DUTY_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_DUTY_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_PRICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_PRICE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_DRIVER_TITLE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_DRIVER_TITLE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_BONUS_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_BONUS_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_POINT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_POINT.Name), "HRM"));
            list.Add(new ItemCombobox(PR_BASIC_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_BASIC_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_TP_ADJUSTMENT_VOLUME_VEHICLE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_TP_ADJUSTMENT_VOLUME_VEHICLE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ACTUAL_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ACTUAL_BUDGET.Name), "HRM"));
            list.Add(new ItemCombobox(HR_STORAGE_PROFILE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_STORAGE_PROFILE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_SALARY_LEVEL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_SALARY_LEVEL.Name), "HRM"));
            list.Add(new ItemCombobox(HR_LIST_CARD_CODE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_LIST_CARD_CODE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_LIST_CANDIDATES_RECRUITMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_LIST_CANDIDATES_RECRUITMENT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_LEVEL_MANAGEMENT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_LEVEL_MANAGEMENT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_LEAVE_INFO.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_LEAVE_INFO.Name), "HRM"));
            list.Add(new ItemCombobox(HR_LABOR_PLAN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_LABOR_PLAN.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_TRAINING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_TRAINING.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_STATUS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_STATUS.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_SKILL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_SKILL.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_REWARDS_FAULTS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_REWARDS_FAULTS.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_PROFILE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_PROFILE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_POSITION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_POSITION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_POLITICS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_POLITICS.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_OTHER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_OTHER.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_LEVEL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_LEVEL.Name), "HRM"));
            list.Add(new ItemCombobox(HR_FOREIGN_LANGUAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_FOREIGN_LANGUAGE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_IMAGE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_IMAGE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_HISTORY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_HISTORY.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_HEALTH.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_HEALTH.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_ADDRESS.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_ADDRESS.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_EMERGENCY_CONTACT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_EMERGENCY_CONTACT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_EDUCATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_EDUCATION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_CONTRACT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_CONTRACT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_CERFITICATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_CERFITICATION.Name), "HRM"));
            list.Add(new ItemCombobox(DM_HR_WARNING.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_WARNING.Name), "SHARE"));
            list.Add(new ItemCombobox(HR_MAINBOARD_VIEW_EMPLOYEE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_MAINBOARD_VIEW_EMPLOYEE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INFO_BIRTHDAY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INFO_BIRTHDAY.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INFO_ALARM.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INFO_ALARM.Name), "HRM"));
            list.Add(new ItemCombobox(HR_INFO_PROFILE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_INFO_PROFILE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_DEVICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_DEVICE.Name), "HRM"));
            list.Add(new ItemCombobox(DM_HR_SHIFT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HR_SHIFT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_FINGER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_FINGER.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_LEAVE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_LEAVE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_SITUATION.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_SITUATION.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIMESHEET_DETAIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIMESHEET_DETAIL.Name), "HRM"));
            list.Add(new ItemCombobox(HR_SHIFT_PLAN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_SHIFT_PLAN.Name), "HRM"));
            list.Add(new ItemCombobox(DM_PR_METHOD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_PR_METHOD.Name), "HRM"));
            list.Add(new ItemCombobox(HRM_DASHBOARD.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HRM_DASHBOARD.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_FIRST_LINE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_FIRST_LINE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_STEP.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_STEP.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_PRICE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_PRICE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_NEW_ORG_ALLOWANCE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_NEW_ORG_ALLOWANCE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_OUTPUT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_OUTPUT.Name), "HRM"));
            list.Add(new ItemCombobox(PR_ITEM_ORGANIZATION_LIST.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_ITEM_ORGANIZATION_LIST.Name), "HRM"));
            list.Add(new ItemCombobox(PR_STEP_SALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_STEP_SALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_ORGANIZATION_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_ORGANIZATION_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_EXPENSE_ORG_BUDGET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_EXPENSE_ORG_BUDGET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_BONUS_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_BONUS_TYPE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PROJECT_STEP_RATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PROJECT_STEP_RATE.Name), "HRM"));
            list.Add(new ItemCombobox(PR_PROJECT_TYPE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_PROJECT_TYPE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_EMPLOYEE_UP_SALARY_VIEW.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_EMPLOYEE_UP_SALARY_VIEW.Name), "HRM"));
            list.Add(new ItemCombobox(DM_HRM_SCALE_OF_CIVIL.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_HRM_SCALE_OF_CIVIL.Name), "HRM"));

            #region button Nhan SU

            list.Add(new ItemCombobox(HR_CANDIDATES_POSITION_LIST_BTN_CREATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_CANDIDATES_POSITION_LIST_BTN_CREATE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_CLASSIFICATION_BTN_ALLOCATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_CLASSIFICATION_BTN_ALLOCATE.Name), "HRM"));
            list.Add(new ItemCombobox(DM_TIME_DEVIVE_SYNCDATIME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_TIME_DEVIVE_SYNCDATIME.Name), "HRM"));
            list.Add(new ItemCombobox(DM_TIME_DEVIVE_SHUTDOWN.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_TIME_DEVIVE_SHUTDOWN.Name), "HRM"));
            list.Add(new ItemCombobox(DM_TIME_DEVIVE_GETDATATIMELOG.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_TIME_DEVIVE_GETDATATIMELOG.Name), "HRM"));
            list.Add(new ItemCombobox(DM_TIME_DEVIVE_UPDATEEMPLOYEE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + DM_TIME_DEVIVE_UPDATEEMPLOYEE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_RC_CLASSIFICATION_FINISH.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_RC_CLASSIFICATION_FINISH.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_DELETE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_DELETE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_INSERT_STOPPAGE_TIME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_INSERT_STOPPAGE_TIME.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_INSERT_EDITOVER.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_INSERT_EDITOVER.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_INSERT_EDITDAYWORK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_INSERT_EDITDAYWORK.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_PLANOVERTIME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_PLANOVERTIME.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_CLOCK.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_CLOCK.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_EDITOUTTIME.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_EDITOUTTIME.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_GETDATA.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_GETDATA.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_LOADDATA.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_LOADDATA.Name), "HRM"));
            list.Add(new ItemCombobox(HR_TIME_WORK_INSERTCHECKINOUT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_TIME_WORK_INSERTCHECKINOUT.Name), "HRM"));
            list.Add(new ItemCombobox(HR_PR_TIMESHEET_CREATE.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_PR_TIMESHEET_CREATE.Name), "HRM"));
            list.Add(new ItemCombobox(HR_PR_TIMESHEET_FORMUALAR.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + HR_PR_TIMESHEET_FORMUALAR.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_CALDUTY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_CALDUTY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_CALSALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_CALSALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_CALPIT.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_CALPIT.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_CLOSESALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_CLOSESALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_PRINTSALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_PRINTSALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_TIMESHEET.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_TIMESHEET.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_VIEWSALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_VIEWSALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_EDITSALARY.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_EDITSALARY.Name), "HRM"));
            list.Add(new ItemCombobox(PR_SALARY_CALBH.Name, ftsmain.MsgManager.GetMessage("FUNCTION_NAME_" + PR_SALARY_CALBH.Name), "HRM"));

            #endregion

            #endregion

            return list;
        }
    }
}