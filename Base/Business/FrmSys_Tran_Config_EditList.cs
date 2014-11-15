#region

using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmSys_Tran_Config_EditList : FrmDataEditList {
        public FrmSys_Tran_Config_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Tran_Config_EditList(FTSMain ftsmain, string tranid, bool showdialog) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ShowGroupPanel = false;
            this.ConfigGrid();
            this.LoadLayout();
            ((Sys_Tran_Config) this.DataObject).Tran_Id = tranid;
            this.DataObject.LoadData();
            if (FTSConstant.IS_RELEASE) {
                this.AllowCopy = false;
                this.AllowDelete = false;
                this.AllowEdit = false;
                this.AllowNew = false;
            }
            if (showdialog) {
                this.MdiParent = null;
            }
        }

        public override void BindGrid() {
            this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("TRAN_ID"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("CONFIG_ID"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("CONFIG_NAME"), false);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("CONFIG_TYPE"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("CONFIG_VALUE"), false);
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_ID"), false);
            this.Grid.BindData();
        }

        public override void LoadData() {
            this.DataObject = new Sys_Tran_Config(this.FTSMain);
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