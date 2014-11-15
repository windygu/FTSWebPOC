#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareBusiness.Acc{
    public class FTSTransactionStatus{
        public const string DRAFT = "DRAFT";
        public const string POSTED = "POSTED";
        public const string DELETED = "DEL";

        public static List<ItemCombobox> GetFTSTransactionStatusList(FTSMain ftsmain){
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox(DRAFT,
                                      ftsmain.MsgManager.GetMessage("TRANSACTION_STATUS_" + DRAFT)));
            list.Add(new ItemCombobox(POSTED,
                                      ftsmain.MsgManager.GetMessage("TRANSACTION_STATUS_" + POSTED)));
            return list;
        }
    }
}