#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.AccBusiness.Sale{
    public class IssueReceive{
        public static string ISSUE = "X";
        public static string RECEIVE = "N";
        public static string BALANCE = "T";

        public static List<ItemCombobox> GetIssueReceiveList(FTSMain ftsmain){
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox(RECEIVE,
                                      ftsmain.MsgManager.GetMessage("ISSUE_RECEIVE_" + RECEIVE)));
            list.Add(new ItemCombobox(ISSUE,
                                      ftsmain.MsgManager.GetMessage("ISSUE_RECEIVE_" + ISSUE)));
            list.Add(new ItemCombobox(BALANCE,
                                      ftsmain.MsgManager.GetMessage("ISSUE_RECEIVE_" + BALANCE)));
            return list;
        }
    }
}