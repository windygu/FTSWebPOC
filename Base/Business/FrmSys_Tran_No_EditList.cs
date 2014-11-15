#region

using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Tran_No_EditList : FrmDataEditList {
        public FrmSys_Tran_No_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Tran_No_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ShowGroupPanel = false;
            this.ConfigGrid();
            this.LoadLayout();
            if (FTSConstant.IS_RELEASE) {
                this.AllowCopy = false;
                this.AllowDelete = false;
                this.AllowEdit = false;
                this.AllowNew = false;
            }
        }

        public override void BindGrid() {
            this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.Grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("TRAN_ID"),
                                          this.DataObject.DataSet.Tables["SYS_TRAN"], "TRAN_NAME", "TRAN_ID",
                                          ComboComType.NameID, false);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("ORGANIZATION_ID"),
                                          this.DataObject.DataSet.Tables["DM_ORGANIZATION"], "ORGANIZATION_NAME",
                                          "ORGANIZATION_ID", ComboComType.NameOnly, false);
            this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("LAST_TRAN_NO"), 0);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("PRE_FIX"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("POST_FIX"), true);
            this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
            this.Grid.BindData();
        }

        public override void LoadData() {
            this.DataObject = new Sys_Tran_No(this.FTSMain);
        }

        public override void SetTextFooter() {
            string columnname = this.Grid.CurrentColumnName.ToUpper();
            string cellvalue = this.Grid.CurrentCellValue.ToString();
            switch (columnname) {
                default:
                    this.Grid.SetTextFooter(string.Empty);
                    break;
            }
        }
    }
}