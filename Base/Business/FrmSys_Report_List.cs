#region
using System.Data;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Report_List : FrmDataList {
        public FrmSys_Report_List() {
            this.InitializeComponent();
        }

        public FrmSys_Report_List(FTSMain ftsmain) : base(ftsmain, "Sys_Report") {
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }
         public FrmSys_Report_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                bool allowempty) : base(ftsmain, ds, "Sys_Report", condition, val, allowempty) {
            this.InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }
        public override void LoadData() {
            if (this.Mode == ListMode.SELECT) {
                this.DataObject = new Sys_Report(this.FTSMain, this.DataSet);
            } else {
                this.DataObject = new Sys_Report(this.FTSMain);
            }
            
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REPORT_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("REPORT_NAME"), false);
            this.grid.BindData();
            this.grid.ViewGrid.Columns["REPORT_NAME"].OptionsColumn.AllowEdit = false;
            this.grid.ViewGrid.Columns["REPORT_ID"].OptionsColumn.AllowEdit = false;
        }
    }
}