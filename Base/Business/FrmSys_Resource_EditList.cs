#region

using DevExpress.XtraBars;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Resource_EditList : FrmDataEditList {
        public FrmSys_Resource_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Resource_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
            //this.ToolBar.SaveNewVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ToolBar.NewVisible = BarItemVisibility.Never;
        }

        public override void LoadData() {
            this.DataObject = new Sys_Resource(this.FTSMain);
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"),0);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("RES_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("RES_VALUE"), false);
            this.grid.BindData();
        }
    }
}