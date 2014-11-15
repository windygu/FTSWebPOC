#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using ItemClickEventArgs = FTS.BaseUI.Controls.ItemClickEventArgs;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmBase2Listing : FrmBaseFormGrid {
        private FindMode mMode = FindMode.FIND;
        private DataSet mDataSet;
        private List<FieldInfo> mFieldCollection;
        private bool mOk;
        private object mRetValue;
        private DataRow mRetRowValue;
        private string mTableName;
        private DataTable mDataTable;
        private string mSqlQuery;
        private ManagerBase mObjectManager;
        private string mPr_Key_TranField = "PR_KEY_CTU";
        private string mPr_Key_TranField_Detail = "PR_KEY";
        private string mTran_IdField = "TRAN_ID";
        private string mTran_Class = string.Empty;
        private string mTran_Id = string.Empty;

        public FrmBase2Listing() {
            this.InitializeComponent();
        }

        public FrmBase2Listing(FTSMain ftsmain, ManagerBase mb, string tran_class, string tran_id, bool dialog): base(ftsmain, dialog) {
            if (mb == null) {
                this.mMode = FindMode.LIST;
            }
            this.mObjectManager = mb;
            this.Tran_Class = tran_class;
            this.Tran_Id = tran_id;
            this.InitializeComponent();
            this.grid.ViewGrid.OptionsBehavior.Editable = false;
        }
        public FrmBase2Listing(FTSMain ftsmain, ManagerBase mb, string tran_class, string tran_id, bool dialog, FindMode findmode): base(ftsmain, dialog)
        {            
            this.mMode = findmode;            
            this.mObjectManager = mb;
            this.Tran_Class = tran_class;
            this.Tran_Id = tran_id;
            this.InitializeComponent();
            this.grid.ViewGrid.OptionsBehavior.Editable = false;
        }
        public string TableName {
            get { return this.mTableName; }
            set { this.mTableName = value; }
        }

        public DataTable DataTable {
            get { return this.mDataTable; }
            set { this.mDataTable = value; }
        }

        public string SqlQuery {
            get { return this.mSqlQuery; }
            set { this.mSqlQuery = value; }
        }

        public ManagerBase ObjectManager {
            get { return this.mObjectManager; }
            set { this.mObjectManager = value; }
        }

        public DataSet DataSet {
            get { return this.mDataSet; }
            set { this.mDataSet = value; }
        }

        public List<FieldInfo> FieldCollection {
            get { return this.mFieldCollection; }
            set { this.mFieldCollection = value; }
        }

        public FindMode Mode {
            get { return this.mMode; }
            set { this.mMode = value; }
        }

        public string PrKeyTranField {
            get { return this.mPr_Key_TranField; }
            set { this.mPr_Key_TranField = value; }
        }

        public string PrKeyTranFieldDetail {
            get { return this.mPr_Key_TranField_Detail; }
            set { this.mPr_Key_TranField_Detail = value; }
        }

        public string TranIdField {
            get { return this.mTran_IdField; }
            set { this.mTran_IdField = value; }
        }

        public bool Ok {
            get { return this.mOk; }
            set { this.mOk = value; }
        }

        public object RetValue {
            get { return this.mRetValue; }
            set { this.mRetValue = value; }
        }

        public DataRow RetRowValue
        {
            get { return this.mRetRowValue; }
            set { this.mRetRowValue = value; }
        }
        public string Tran_Class {
            get { return this.mTran_Class; }
            set { this.mTran_Class = value; }
        }

        public string Tran_Id {
            get { return this.mTran_Id; }
            set { this.mTran_Id = value; }
        }

        public virtual void LoadData() {
        }

        public virtual void LoadFields() {
        }

        public FieldInfo GetFieldInfo(string fieldname) {
            for (int i = 0; i < this.mFieldCollection.Count; i++) {
                if (string.Compare((this.mFieldCollection[i]).FieldName, fieldname, true) == 0) {
                    return this.mFieldCollection[i];
                }
            }
            throw (new FTSException("INVALID_FIELD_NAME", new object[] {fieldname}, "Customization", fieldname, -1));
        }

        public virtual void BindGrid() {
        }

        protected new void ConfigGrid() {
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = true;
            this.grid.ViewGrid.OptionsView.ShowFooter = true;
            this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            this.grid.ChooseRow += new SelectRowEventHandler(this.grid_ChooseRow);
        }
        protected virtual void ChooseRow(object sender, SelectRowEventArgs e)
        {
            if (this.grid.ViewGrid.FocusedRowHandle >= 0)
            {
                if (this.mMode == FindMode.FIND)
                {
                    this.mOk = true;
                    this.mRetValue = e.rowvalue[this.mPr_Key_TranField];
                    this.mRetRowValue = e.rowvalue;
                    this.Hide();
                }
                else
                {
                    this.LoadTransaction(e.rowvalue[this.mTran_IdField].ToString(),
                                         e.rowvalue[this.mPr_Key_TranField]);
                }
            }
        }
        private void grid_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                this.ChooseRow(sender, e);
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            try {
                this.SetTextFooter();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void ViewGrid_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                this.SetTextFooter();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public virtual void Filter() {
        }

        public virtual void LoadTransaction(string tranid, object key) {
        }

        public virtual void RefreshList(RefreshListEventArgs args) {
            DataView view = null;
            /*
            string format = "{0:0.0000}";
            */
            switch (args.Action) {
                case TranActions.DELETE:
                    view = new DataView(this.mDataTable,
                                        this.mPr_Key_TranField + " = '" + args.PrKeyTran + "'",
                                        this.mPr_Key_TranField, DataViewRowState.CurrentRows);
                    foreach (DataRowView rv in view) {
                        if (rv.Row.RowState != DataRowState.Deleted) {
                            rv.Delete();
                        }
                    }
                    this.mDataTable.AcceptChanges();
                    break;
                case TranActions.EDIT:
                    if (args.ManagerBase.ObjectList[0].DataTable.Rows.Count > 0) {
                        int pos = -1;
                        DataRow row = args.ManagerBase.ObjectList[0].DataTable.Rows[0];
                        if (row.RowState != DataRowState.Deleted) {
                            Guid prkeytran = (Guid)row[args.ManagerBase.ObjectList[0].IdField];
                            view = new DataView(this.mDataTable, this.mPr_Key_TranField + " = '" + prkeytran + "'",
                                                this.mPr_Key_TranField, DataViewRowState.CurrentRows);
                            foreach (DataRowView rv in view) {
                                if (rv.Row.RowState != DataRowState.Deleted) {
                                    if (pos == -1) {
                                        pos = Functions.GetRowIndex(this.mDataTable, rv.Row);
                                    }
                                    rv.Delete();
                                }
                            }
                            foreach (DataRow rowdetail in args.ManagerBase.ObjectList[1].DataTable.Rows) {
                                if (rowdetail.RowState != DataRowState.Deleted) {
                                    DataRow newrow = this.mDataTable.NewRow();
                                    newrow[this.mPr_Key_TranField] = prkeytran;
                                    foreach (DataColumn col in this.mDataTable.Columns) {
                                        if (col.ColumnName.Trim().ToUpper() !=
                                            this.mPr_Key_TranField_Detail.Trim().ToUpper()) {
                                            try {
                                                newrow[col.ColumnName] = row[col.ColumnName];
                                            } catch {
                                                try {
                                                    newrow[col.ColumnName] = rowdetail[col.ColumnName];
                                                } catch {
                                                }
                                            }
                                        } else {
                                            newrow[col.ColumnName] = rowdetail[col.ColumnName];
                                        }
                                        newrow.EndEdit();
                                    }
                                    if (pos == -1) {
                                        this.mDataTable.Rows.Add(newrow);
                                    } else {
                                        this.mDataTable.Rows.InsertAt(newrow, pos);
                                        pos++;
                                    }
                                }
                            }
                            this.mDataTable.AcceptChanges();
                        }
                    }
                    break;
                case TranActions.NEW:
                    if (args.ManagerBase.ObjectList[0].DataTable.Rows.Count > 0) {
                        DataRow row = args.ManagerBase.ObjectList[0].DataTable.Rows[0];
                        if (row.RowState != DataRowState.Deleted) {
                            Guid prkeytran = (Guid)row[args.ManagerBase.ObjectList[0].IdField];
                            foreach (DataRow rowdetail in args.ManagerBase.ObjectList[1].DataTable.Rows) {
                                if (rowdetail.RowState != DataRowState.Deleted) {
                                    DataRow newrow = this.mDataTable.NewRow();
                                    newrow[this.mPr_Key_TranField] = prkeytran;
                                    foreach (DataColumn col in this.mDataTable.Columns) {
                                        if (col.ColumnName.Trim().ToUpper() !=
                                            this.mPr_Key_TranField_Detail.Trim().ToUpper()) {
                                            try {
                                                newrow[col.ColumnName] = row[col.ColumnName];
                                            } catch {
                                                try {
                                                    newrow[col.ColumnName] = rowdetail[col.ColumnName];
                                                } catch {
                                                }
                                            }
                                        } else {
                                            newrow[col.ColumnName] = rowdetail[col.ColumnName];
                                        }
                                        newrow.EndEdit();
                                    }
                                    this.mDataTable.Rows.Add(newrow);
                                }
                            }
                            this.mDataTable.AcceptChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public virtual void SetTextFooter() {
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "New":
                        this.NewTransaction();
                        break;
                    case "Delete":
                        if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                            this.DeleteTransaction(
                                this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)["TRAN_ID"].ToString(),
                                this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mPr_Key_TranField]);
                        }
                        break;
                    case "Edit":
                        if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                            this.LoadTransaction(
                                this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)["TRAN_ID"].ToString(),
                                this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mPr_Key_TranField]);
                        }
                        break;
                    case "Config":
                        this.FormCustomization(new Point(-10000, -10000), this.FTSMain);
                        break;
                    case "ExportExcel":
                        this.grid.ExportToXLS();
                        break;
                    case "Print":
                        this.grid.ShowPrintPreview();
                        break;
                    case "Close":
                        this.mOk = false;
                        if (this.mMode == FindMode.FIND) {
                            this.Hide();
                        } else {
                            this.Close();
                        }
                        break;
                    case "Choice":
                        if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                            if (this.mMode == FindMode.FIND) {
                                this.mOk = true;
                                this.mRetValue =
                                    this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mPr_Key_TranField];
                                this.mRetRowValue = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                                this.Hide();
                            } else {
                                this.LoadTransaction(
                                    this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)["TRAN_ID"].
                                        ToString(),
                                    this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mPr_Key_TranField]);
                            }
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public virtual void DeleteTransaction(string tranid, object key) {
        }

        public virtual void NewTransaction() {
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.toolbar.LoadLayout(ftsmain);
            this.LayoutGrid();
            if (this.Mode == FindMode.FIND) {
                this.toolbar.NewVisible = BarItemVisibility.Never;
                this.toolbar.EditVisible = BarItemVisibility.Never;
                this.toolbar.DeleteVisible = BarItemVisibility.Never;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Always;
                this.toolbar.HelpVisible = BarItemVisibility.Never;
                this.toolbar.EditListVisible = BarItemVisibility.Never;
                this.toolbar.ChoiceVisible = BarItemVisibility.Always;
                this.toolbar.CloseVisible = BarItemVisibility.Always;
                this.toolbar.ChoiceEnable = true;
                this.toolbar.CloseEnable = true;
                this.ControlBox = false;
            } else {
                this.toolbar.NewVisible = BarItemVisibility.Always;
                this.toolbar.EditVisible = BarItemVisibility.Always;
                this.toolbar.DeleteVisible = BarItemVisibility.Always;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Always;
                this.toolbar.HelpVisible = BarItemVisibility.Never;
                this.toolbar.EditListVisible = BarItemVisibility.Never;
                this.toolbar.ChoiceVisible = BarItemVisibility.Never;
                this.toolbar.CloseVisible = BarItemVisibility.Never;
                this.ControlBox = true;
            }
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN")
            {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.toolbar.ChangeIDVisible = BarItemVisibility.Never;
            this.SetProductVersion();
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }
    }
}