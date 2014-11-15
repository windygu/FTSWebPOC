#region

using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security
{
    public static class ProjectList
    {
        public static string Finance = "FIN";
        public static string Hotel = "HT";
        public static string HRM = "HRM";
        public static string POS = "POS";
        public static string Transport = "TP";

        public static List<ItemCombobox> GetProjectList(FTSMain ftsmain)
        {
            string temp = "";
            for (int i = 0; i < ftsmain.ProjectID.Count; i++)
            {
                temp += ftsmain.ProjectID[i] + ",";
            }
            //if (ftsmain.SystemVars.GetSystemVars("PROJECT_LIST_ALLOW") != null)
            //    temp = (string)ftsmain.SystemVars.GetSystemVars("PROJECT_LIST_ALLOW");
            string[] project_list = temp.Split(',');
            List<ItemCombobox> list = new List<ItemCombobox>();
            // mục kế toán
            if (ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Finance) != "")
            {
                if (project_list.Length > 0)
                    for (int i = 0; i < project_list.Length; i++)
                    {
                        if (project_list[i] == Finance)
                        {
                            list.Add(new ItemCombobox(Finance, ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Finance)));
                            break;
                        }
                    }

            }
            if (ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Hotel) != "")
            {
                if (project_list.Length > 0)
                    for (int i = 0; i < project_list.Length; i++)
                    {
                        if (project_list[i] == Hotel)
                        {
                            list.Add(new ItemCombobox(Hotel, ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Hotel)));
                            break;
                        }
                    }
            }
            if (ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + HRM) != "")
            {
                if (project_list.Length > 0)
                    for (int i = 0; i < project_list.Length; i++)
                    {
                        if (project_list[i] == HRM)
                        {
                            list.Add(new ItemCombobox(HRM, ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + HRM)));
                            break;
                        }
                    }
            }
            if (ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + POS) != "")
            {
                if (project_list.Length > 0)
                    for (int i = 0; i < project_list.Length; i++)
                    {
                        if (project_list[i] == POS)
                        {
                            list.Add(new ItemCombobox(POS, ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + POS)));
                            break;
                        }
                    }
            }
            if (ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Transport) != "")
            {
                if (project_list.Length > 0)
                    for (int i = 0; i < project_list.Length; i++)
                    {
                        if (project_list[i] == Transport)
                        {
                            list.Add(new ItemCombobox(Transport, ftsmain.MsgManager.GetMessage("PROJECT_LIST_" + Transport)));
                            break;
                        }
                    }
            }
            return list;
        }
    }
}