#region

using System;
using System.Collections;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.ImportData;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.ImportData {
    public partial class FrmDm_Template : FrmBase2 {
        private Dm_TemplateManager dm_templatemanager = null;
        private ManagerBase mManageBase = null;
        private ObjectBase mObjectBase = null;

        public FrmDm_Template() {
            this.InitializeComponent();
        }

        public FrmDm_Template(FTSMain ftsmain, string tranid, ManagerBase managerBase, ObjectBase objectBase) : base(ftsmain) {
            this.InitializeComponent();
            this.MdiParent = null;
            this.TranId = tranid;
            this.mManageBase = managerBase;
            this.mObjectBase = objectBase;
            this.LoadData();
            this.BindHeaderControls();
            this.BindGrid();
            this.LoadContextMenu();
            this.ConfigGrid();
            this.LoadLayout();
            this.SetControls();
            this.LayoutItems();
            this.FocusControl = this.txtTemplate_Name;
            this.NewRecord();
            this.toolbar.NewVisible = BarItemVisibility.Never;
            this.toolbar.DeleteVisible = BarItemVisibility.Never;
            this.toolbar.CopyVisible = BarItemVisibility.Never;
            this.toolbar.RefreshVisible = BarItemVisibility.Never;
            this.toolbar.ImportExcelVisible = BarItemVisibility.Never;
            this.toolbar.NextVisible = BarItemVisibility.Never;
            this.toolbar.PreviousVisible = BarItemVisibility.Never;
            this.toolbar.PrintVisible = BarItemVisibility.Never;
        }

        public FrmDm_Template(FTSMain ftsmain, string tranid, ManagerBase managerBase, ObjectBase objectBase, decimal pr_key) : base(ftsmain) {
            this.InitializeComponent();
            this.MdiParent = null;
            this.TranId = tranid;
            this.mManageBase = managerBase;
            this.mObjectBase = objectBase;
            this.LoadData();
            this.BindHeaderControls();
            this.BindGrid();
            this.LoadContextMenu();
            this.ConfigGrid();
            this.LoadLayout();
            this.SetControls();
            this.FocusControl = this.txtTemplate_Name;
            this.dm_templatemanager.LoadRecordWithPrkey(pr_key);
            this.Mode = DataMode.READ;
            this.LayoutItems();
            this.toolbar.NewVisible = BarItemVisibility.Never;
            this.toolbar.DeleteVisible = BarItemVisibility.Never;
            this.toolbar.CopyVisible = BarItemVisibility.Never;
            this.toolbar.RefreshVisible = BarItemVisibility.Never;
            this.toolbar.ImportExcelVisible = BarItemVisibility.Never;
            this.toolbar.NextVisible = BarItemVisibility.Never;
            this.toolbar.PreviousVisible = BarItemVisibility.Never;
            this.toolbar.PrintVisible = BarItemVisibility.Never;
        }

        public override void NewRecord() {
            base.NewRecord();
            if (this.mObjectBase != null) {
                this.dm_templatemanager.dm_template.SetValue("TABLE_NAME", this.mObjectBase.TableNameOrig);
            }
            if (this.mManageBase != null) {
                this.dm_templatemanager.dm_template.SetValue("TRAN_ID_NAME", this.mManageBase.TranId);
            }
            this.dm_templatemanager.LoadDmDataColumn();
        }

        private void NewRecord(string tablename, string tranid) {
            this.NewRecord();
        }

        public override void LoadData() {
            this.ObjectManager = new Dm_TemplateManager(this.FTSMain, this.TranId);
            this.dm_templatemanager = (Dm_TemplateManager) this.ObjectManager;
            this.dm_templatemanager.Set(this.mManageBase, this.mObjectBase);
        }

        public override void BindHeaderControls() {
            this.txtTemplate_Name.Textbox.DataBindings.Add("EditValue", this.ObjectManager.DataSet, this.dm_templatemanager.dm_template.TableName + ".TEMPLATE_NAME");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.ObjectManager.DataSet, this.dm_templatemanager.dm_template.TableName + ".ACTIVE");
        }

        public override void BindGrid() {
            ArrayList typelist = new ArrayList();
            typelist.Add("STRING");
            typelist.Add("DECIMAL");
            typelist.Add("INT");
            typelist.Add("BOOLEAN");
            typelist.Add("DATE");
            this.Grid.CreateGrid(this.ObjectManager.DataSet, this.dm_templatemanager.dm_template_detail.DataTable, this.dm_templatemanager.dm_template_detail.TableName);
            this.Grid.SetNumberColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("PR_KEY"), 0);
            this.Grid.SetNumberColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("FR_KEY"), 0);
            this.Grid.SetNumberColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("LIST_ORDER"), 0);
            this.Grid.SetTextColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("EXCEL_COLUMN_NO"), false);
            this.Grid.SetComboMultiColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("DATA_COLUMN_NAME"), this.dm_templatemanager.DataSet.Tables["DM_DATACOLUMNS"], "DATA_COLUMN_NAME",
                                          "DATA_COLUMN_NAME", ComboComType.NameOnly, false);
            this.Grid.SetCheckColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("IS_PR_KEY"));
            this.Grid.SetComboColumn(this.dm_templatemanager.dm_template_detail.GetFieldInfo("DATA_TYPE"), typelist);
            this.Grid.BindData();
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
        }

        protected override void LayoutGrid() {
            base.LayoutGrid();
        }

        public override void UpdateInfo() {
            base.UpdateInfo();
        }

        private void UpdateStatus() {
        }

        public override void LoadFormFind() {
        }

        private void Control_Lookup(object sender, EventArgs e) {
            try {
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void Control_Leave(object sender, EventArgs e) {
            try {
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        protected override void ShowConfigForm() {
            try {
                (new FrmSys_Tran_Config_EditList(this.FTSMain, this.TranId,true)).Show();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex); ;
            }
        }

        protected override void ShowCalculationForm() {
            try {
                (new FrmSys_Tran_Calculation_EditList(this.FTSMain, this.TranId,true)).Show();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public override void ConfigForm() {
        }

        public override void PrintRecord() {
            try {
                if (this.ToolBar.PrintEnable) {
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
    }
}