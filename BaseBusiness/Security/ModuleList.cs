#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security
{
    public static class ModuleList
    {
        public static string FIN_CASHBANK = "FIN_CASHBANK";
        public static string FIN_AR = "FIN_AR";
        public static string FIN_AP = "FIN_AP";
        public static string FIN_OM = "FIN_OM";
        public static string FIN_PO = "FIN_PO";
        public static string FIN_INV = "FIN_INV";
        public static string FIN_TAX = "FIN_TAX";
        public static string FIN_CONTRACT = "FIN_CONTRACT";
        public static string FIN_FA = "FIN_FA";
        public static string FIN_CA = "FIN_CA";
        public static string FIN_GL = "FIN_GL";
        public static string TP_ROUTE = "TP_ROUTE";
        public static string TP_VEHICLE = "TP_VEHICLE";
        public static string QUOTA = "TP_QUOTA";
        public static string TP_ORDER = "TP_ORDER";
        public static string HT_REC = "HT_REC";
        public static string HT_BOO = "HT_BOO";
        public static string HT_ROMA = "HT_ROMA";
        public static string HT_LAUN = "HT_LAUN";
        public static string HT_INV = "HT_INV";
        public static string HT_RES = "HT_RES";
        public static string HT_ADMI = "HT_ADMI";        
        public static string SYS = "SYS_PER";
        public static string POS_BUY = "POS_BUY";
        public static string POS_ADMI = "POS_ADMI";
        public static string POS_OTHER = "POS_OTHER";
        public static string POS_PAYMENT = "POS_PAYMENT";
        public static string POS_PRINT = "POS_PRINT";
        public static string POS_SALE = "POS_SALE";
        public static string POS_CASHBANK = "POS_CASHBANK";
        public static string HRM_ADMI = "HRM_ADMI";
        public static string HRM_REC = "HRM_REC";
        public static string HRM_INFO = "HRM_INFO";
        public static string HRM_TRAINING = "HRM_TRAINING";
        public static string HRM_INS = "HRM_INS";
        public static string HRM_TIME = "HRM_TIME";
        public static string HRM_SA = "HRM_SA";
        public static string HRM_SA_ITEM = "HRM_SA_ITEM";
        public static string HRM_EVALUATION = "HRM_EVALUATION";
        public static string FIN_SCR = "FIN_SCR";
        public static string FIN_REINS = "FIN_REINS";
        public static string FIN_BR = "FIN_BR";

        public static List<ItemCombobox> GetModuleList(FTSMain ftsmain) {
            List<ItemCombobox> list = new List<ItemCombobox>();

            list.Add(new ItemCombobox(FIN_CASHBANK, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_CASHBANK)));
            list.Add(new ItemCombobox(FIN_AR, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_AR)));
            list.Add(new ItemCombobox(FIN_AP, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_AP)));
            list.Add(new ItemCombobox(FIN_OM, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_OM)));
            list.Add(new ItemCombobox(FIN_PO, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_PO)));
            list.Add(new ItemCombobox(FIN_INV, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_INV)));
            list.Add(new ItemCombobox(POS_PRINT, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_PRINT)));
            list.Add(new ItemCombobox(FIN_TAX, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_TAX)));
            list.Add(new ItemCombobox(FIN_CONTRACT, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_CONTRACT)));
            list.Add(new ItemCombobox(FIN_REINS, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_REINS)));
            list.Add(new ItemCombobox(FIN_BR, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_BR)));
            list.Add(new ItemCombobox(FIN_SCR, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_SCR)));
            list.Add(new ItemCombobox(FIN_FA, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_FA)));
            list.Add(new ItemCombobox(FIN_CA, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_CA)));
            list.Add(new ItemCombobox(FIN_GL, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + FIN_GL)));
            list.Add(new ItemCombobox(TP_ROUTE, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + TP_ROUTE)));
            list.Add(new ItemCombobox(TP_VEHICLE, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + TP_VEHICLE)));
            list.Add(new ItemCombobox(QUOTA, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + QUOTA)));
            list.Add(new ItemCombobox(TP_ORDER, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + TP_ORDER)));
            list.Add(new ItemCombobox(HT_REC, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_REC)));
            list.Add(new ItemCombobox(HT_BOO, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_BOO)));
            list.Add(new ItemCombobox(HT_ROMA, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_ROMA)));
            list.Add(new ItemCombobox(HT_LAUN, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_LAUN)));
            list.Add(new ItemCombobox(HT_INV, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_INV)));
            list.Add(new ItemCombobox(HT_RES, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_RES)));
            list.Add(new ItemCombobox(HT_ADMI, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HT_ADMI)));
            list.Add(new ItemCombobox(SYS, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + SYS)));
            list.Add(new ItemCombobox(POS_CASHBANK, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_CASHBANK)));
            list.Add(new ItemCombobox(POS_SALE, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_SALE)));
            list.Add(new ItemCombobox(POS_PAYMENT, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_PAYMENT)));
            list.Add(new ItemCombobox(POS_BUY, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_BUY)));
            list.Add(new ItemCombobox(POS_OTHER, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_OTHER)));
            list.Add(new ItemCombobox(POS_ADMI, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + POS_ADMI)));
            list.Add(new ItemCombobox(HRM_ADMI, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_ADMI)));
            list.Add(new ItemCombobox(HRM_REC, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_REC)));
            list.Add(new ItemCombobox(HRM_INFO, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_INFO)));
            list.Add(new ItemCombobox(HRM_TIME, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_TIME)));

            list.Add(new ItemCombobox(HRM_SA, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_SA)));
            list.Add(new ItemCombobox(HRM_SA_ITEM, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_SA_ITEM)));
            list.Add(new ItemCombobox(HRM_INS, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_INS)));
            list.Add(new ItemCombobox(HRM_TRAINING, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_TRAINING)));
            list.Add(new ItemCombobox(HRM_EVALUATION, ftsmain.MsgManager.GetMessage("MODULE_LIST_" + HRM_EVALUATION)));
            return list;
        }

        public static string GetModuleIcon(string module_id)
        {
            switch (module_id.Trim().ToUpper())
            {
                case "HT_REC":
                    return "ht_reception.png";
                case "HT_BOO":
                    return "ht_booking.png";
                case "HT_ROMA":
                    return "ht_room_management.png";
                case "HT_LAUN":
                    return "ht_launary_page.png";
                case "HT_INV":                    
                    return "ht_inventory.png";
                case "HT_RES":
                    return "ht_restaurant.png";
                case "HT_ADMI":
                    return "ht_admin.png";

                case "HRM_TIME":
                    return "Hrm_Time.png";
                case "HRM_INFO":
                    return "Hrm_Info.png";
                case "HRM_ADMI":
                    return "Hrm_ADMI.png";
                case "HRM_REC":
                    return "Hrm_Rec.png";
                case "HRM_SA":
                    return "Hrm_Payroll.png";
                case "HRM_INS":
                    return "Hrm_Ins.png";
                default:
                    return string.Empty;
            }
        }
    }
}