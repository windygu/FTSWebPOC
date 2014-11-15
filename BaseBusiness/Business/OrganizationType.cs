#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public static class OrganizationType {
        public static string CORP = "01";
        public static string COMPANY = "02";
        public static string INDEPENDANT_ORGANIZATION = "03";
        public static string DEPENDANT_ORGANIZATION = "04";

        public static List<ItemCombobox> GetOrganizationTypeList(FTSMain ftsmain) {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox(CORP, ftsmain.MsgManager.GetMessage("ORGANIZATION_TYPE_" + CORP)));
            list.Add(new ItemCombobox(COMPANY, ftsmain.MsgManager.GetMessage("ORGANIZATION_TYPE_" + COMPANY)));
            list.Add(new ItemCombobox(INDEPENDANT_ORGANIZATION,
                                      ftsmain.MsgManager.GetMessage("ORGANIZATION_TYPE_" + INDEPENDANT_ORGANIZATION)));
            list.Add(new ItemCombobox(DEPENDANT_ORGANIZATION,
                                      ftsmain.MsgManager.GetMessage("ORGANIZATION_TYPE_" + DEPENDANT_ORGANIZATION)));
            return list;
        }
    }
}