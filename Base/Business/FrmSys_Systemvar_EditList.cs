#region

using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmSys_Systemvar_EditList : FrmDataEditList {
        public FrmSys_Systemvar_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Systemvar_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ShowGroupPanel = false;
            this.ConfigGrid();
            this.LoadLayout();
            //this.DataObject.LoadData();
            if (FTSConstant.IS_RELEASE) {
                this.AllowCopy = false;
                this.AllowDelete = false;
                this.AllowNew = false;
            }
        }

        public override void BindGrid() {
            this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("VAR_NAME"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("VAR_VALUE"), false);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("DESCRIPTION"), false);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("VAR_TYPE"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("VAR_GROUP"), true);
            this.Grid.BindData();
        }

        public override void LoadData() {
            this.DataObject = new Sys_SystemVar(this.FTSMain);
        }
    }
}