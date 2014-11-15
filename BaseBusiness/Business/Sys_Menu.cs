#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_Menu : ObjectBase {
        public Sys_Menu(FTSMain ftsmain) : base(ftsmain, "Sys_Menu") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Menu(FTSMain ftsmain, bool isempty) : base(ftsmain, "Sys_Menu") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Menu(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "Sys_Menu") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_ID", DbType.String,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PROJECT_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MODULE_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_TYPE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_GROUP",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_ICON",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_WIDTH", DbType.Int32,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_TAG",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "MENU_ORDER",
                                                                               DbType.Int32, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
            this.ExcludedFieldList = "MENU_NAME";
            
        }

        public override void LoadData()
        {
            string sql = "select SYS_MENU.*,'' as MENU_NAME from SYS_MENU";
            if (this.DataTable != null)
            {
                this.DataTable.Clear();
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                                             this.TableName);
            foreach (DataRow row in this.DataSet.Tables[this.TableName].Rows)
            {
                if (row["MENU_TYPE"].ToString().Trim().ToUpper() == "LIST")
                    row["MENU_NAME"] = this.FTSMain.TableManager.GetDisplayName(row["MENU_TAG"].ToString().Trim());
                else
                    row["MENU_NAME"] = this.FTSMain.MsgManager.GetMessage("MNU_" + row["MENU_ID"]);
            }
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }

        public override void LoadEmptyData()
        {
            string sql = "select SYS_MENU.*,'' as MENU_NAME  from SYS_MENU where 1=0";

            if (this.DataTable != null)
            {
                this.DataTable.Clear();
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataSet,
                                             this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.LoadOtherDm();
        }
        public override void SetRole() {
            this.FTSFunction = FTSFunctionCollection.SYS_MENU;
        }
    }
}