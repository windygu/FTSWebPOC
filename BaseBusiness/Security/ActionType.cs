#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security {
    public static class ActionType {
        public static string LOGIN = "01";
        public static string LOGOUT = "02";
        public static string ADD = "03";
        public static string EDIT = "04";
        public static string DELETE = "05";

        public static List<ItemCombobox> GetActionTypeList(FTSMain ftsmain) {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox(LOGIN, ftsmain.MsgManager.GetMessage("ACTION_TYPE_" + LOGIN)));
            list.Add(new ItemCombobox(LOGOUT, ftsmain.MsgManager.GetMessage("ACTION_TYPE_" + LOGOUT)));
            list.Add(new ItemCombobox(ADD, ftsmain.MsgManager.GetMessage("ACTION_TYPE_" + ADD)));
            list.Add(new ItemCombobox(EDIT, ftsmain.MsgManager.GetMessage("ACTION_TYPE_" + EDIT)));
            list.Add(new ItemCombobox(DELETE, ftsmain.MsgManager.GetMessage("ACTION_TYPE_" + DELETE)));
            return list;
        }
    }
}