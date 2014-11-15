#region
using System.Data;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Report_EditList : FrmDataEditList {
        public FrmSys_Report_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Report_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
            this.txtReport_Group_Id.Set(this.FTSMain, "SYS_REPORT_GROUP", this.DataObject.DataSet, "REPORT_GROUP_ID",
                                     "REPORT_GROUP_NAME", ComboComType.NameID, false);
            this.txtReport_Group_Id.ComboBox.ItemIndex = 0;
        }

        public override void LoadData() {
            this.DataObject = new Sys_Report(this.FTSMain);
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REPORT_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REPORT_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PARENT_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REPORT_GROUP_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TEMPLATE_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TEMPLATE_TABLE"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TEMPLATE_TABLE_TMP"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REQUIRED_FILTER"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REQUIRED_FILTER_DISTINCT"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("FILTER_LIST"), true);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("LIST_ORDER"), 0);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_FIELD1"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_FIELD2"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_FIELD3"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_FIELD4"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_FIELD5"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_TABLE1"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_TABLE2"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_TABLE3"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_TABLE4"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("GROUP_TABLE5"), true);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));                        
            this.grid.BindData();
            this.grid.ViewGrid.Columns["REPORT_NAME"].OptionsColumn.AllowEdit = false;
            this.grid.ViewGrid.Columns["REPORT_ID"].OptionsColumn.AllowEdit = false;
        }

        private void txtReport_Group_Id_ComboChange(object sender, System.EventArgs e)
        {
            if (this.txtReport_Group_Id != null && this.txtReport_Group_Id.ComboBox.ItemIndex >= 0)
            {
                string report_group_id = this.txtReport_Group_Id.ComboBox.EditValue.ToString();
                string sql = "select SYS_REPORT.*,'' as REPORT_NAME from SYS_REPORT where REPORT_GROUP_ID = '" + report_group_id + "'";
                if (this.DataObject.DataTable != null)
                {
                    this.DataObject.DataTable.Clear();
                }
                this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(sql), this.DataObject.DataSet,
                                                 this.DataObject.TableName);
                foreach (DataRow row in this.DataObject.DataSet.Tables[this.DataObject.TableName].Rows)
                {
                    row["REPORT_NAME"] = this.FTSMain.ResourceManager.GetReportName(row["REPORT_ID"].ToString());
                }
                this.DataObject.DataTable = this.DataObject.DataSet.Tables[this.DataObject.TableName];
            }
        }
    }
}