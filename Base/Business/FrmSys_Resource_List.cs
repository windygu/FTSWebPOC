#region

using System.Data;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Resource_List : FrmDataList {
        public FrmSys_Resource_List() {
            this.InitializeComponent();
        }

        public FrmSys_Resource_List(FTSMain ftsmain) : base(ftsmain, "Sys_Resource") {
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        private string mSys_ResourceType = string.Empty;

        public FrmSys_Resource_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                    bool allowempty) : base(ftsmain, ds, "Sys_Resource", condition, val, allowempty) {
            if (condition == "1=1") {
                this.mSys_ResourceType = string.Empty;
            } else {
                this.mSys_ResourceType = condition;
            }
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
            this.ToolBar.NewVisible = BarItemVisibility.Never;
        }

        public override void LoadData() {
            if (this.Mode == ListMode.SELECT) {
                this.DataObject = new Sys_Resource(this.FTSMain, this.DataSet);
            } else {
                this.DataObject = new Sys_Resource(this.FTSMain);
            }
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("RES_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("RES_VALUE"), false);
            this.grid.BindData();
        }

        public override void GetfrmDataEditDetail(bool isnew, object id) {
            this.frmDataEditDetail = new FrmSys_Resource_EditDetail(this.FTSMain, this, isnew, true, id, this.Condition);
        }
    }
}