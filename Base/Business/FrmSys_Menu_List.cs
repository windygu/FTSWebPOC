#region

using System.Data;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Menu_List : FrmDataList {
        public FrmSys_Menu_List() {
            this.InitializeComponent();
        }

        public FrmSys_Menu_List(FTSMain ftsmain) : base(ftsmain, "Sys_Menu") {
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        private string mSys_MenuType = string.Empty;

        public FrmSys_Menu_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                bool allowempty) : base(ftsmain, ds, "Sys_Menu", condition, val, allowempty) {
            if (condition == "1=1") {
                this.mSys_MenuType = string.Empty;
            } else {
                this.mSys_MenuType = condition;
            }
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        public override void LoadData() {
            if (this.Mode == ListMode.SELECT) {
                this.DataObject = new Sys_Menu(this.FTSMain, this.DataSet);
            } else {
                this.DataObject = new Sys_Menu(this.FTSMain);
            }
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MENU_ID"), true);
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
        }

        public override void GetfrmDataEditDetail(bool isnew, object id) {
            this.frmDataEditDetail = new FrmSys_Menu_EditDetail(this.FTSMain, this, isnew, true, id, this.Condition);
        }
    }
}