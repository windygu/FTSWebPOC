#region

using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Menu_EditList : FrmDataEditList {
        public FrmSys_Menu_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Menu_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
        }

        public override void LoadData() {
            this.DataObject = new Sys_Menu(this.FTSMain);
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PROJECT_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MODULE_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_TYPE"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_GROUP"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_ICON"), false);            
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("MENU_WIDTH"), 0);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_TAG"), false);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("MENU_ORDER"), 0);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));                        
            this.grid.BindData();
            this.grid.ViewGrid.Columns["MENU_NAME"].OptionsColumn.AllowEdit = false;
        }
    }
}