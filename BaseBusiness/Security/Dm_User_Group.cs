#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security
{
    public sealed class Sec_User_Group : ObjectBase
    {
        public string parenttablename = string.Empty;

        public Sec_User_Group(FTSMain ftsmain)
            : base(ftsmain, "Sec_User_Group")
        {
            this.LoadData();
            this.LoadFields();
        }

        public Sec_User_Group(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "Sec_User_Group")
        {
            if (!isempty)
            {
                this.LoadData();
            }
            this.LoadFields();
        }
        private string Module_Copy = "";
        private List<ItemCombobox> ModuleList;
        public Sec_User_Group(FTSMain ftsmain, bool isempty, List<ItemCombobox> modulelist,string module_copy)
            : base(ftsmain, "Sec_User_Group")
        {
            Module_Copy = module_copy;
            ModuleList = modulelist;
            if (!isempty)
            {
                this.LoadData();
            }
            this.LoadFields();
        }
        public Sec_User_Group(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Sec_User_Group")
        {
            this.LoadFields();
        }

        public override void LoadFields()
        {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_GROUP_ID",
                                                                               DbType.String, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_GROUP_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MODULE_LIST",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE",
                                                                               DbType.Boolean, false));
        }
        public override DataRow AddNew()
        {
            DataRow dr = base.AddNew();
            dr["MODULE_LIST"] = Module_Copy;
            return dr;
        }
        public override void LoadOtherDm()
        {
            DataTable dt = new DataTable("SYS_MODULE");
            dt.Columns.Add(new DataColumn("PROJECT_NAME"));
            dt.Columns.Add(new DataColumn("MODULE_ID"));

            DataRow dr;
            //f = FTSModule.GetModuleList(this.FTSMain);
            if (ModuleList != null)
            {
                for (int i = 0; i < ModuleList.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["PROJECT_NAME"] = ModuleList[i].Name;
                    dr["MODULE_ID"] = ModuleList[i].Id;

                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
                if (this.DataSet.Tables.IndexOf("SYS_MODULE") < 0)
                    this.DataSet.Tables.Add(dt);
            }
        }
    }
}