#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle;
using FocusedColumnChangedEventArgs = DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs;
using FocusedColumnChangedEventHandler = DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler;
using ItemClickEventArgs = FTS.BaseUI.Controls.ItemClickEventArgs;
using SummaryItemType = DevExpress.Data.SummaryItemType;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmDataList : FTSForm {
        protected FrmDataEditDetail frmDataEditDetail;
        private ObjectBase mDataObject;
        private DataSet mDataSet;
        private DataSet mOldDataSet;
        private FTSMain mFTSMain;
        private string mFilterValue = string.Empty;
        private string mCondition = string.Empty;
        private ListMode mMode = ListMode.SELECT;
        private string mTableName = string.Empty;
        private DataRow mRetRow;
        private List<DataRow> mRetRowList;
        private string mRelTreeListIdField = string.Empty;
        private string mRelGridIdField = string.Empty;
        private string mParentRelGridIdField = string.Empty;
        private bool mShowTreeList = false;
        private bool mClearFilter = true;
        private bool mDataChanged = false;

        public FrmDataList() {
            this.InitializeComponent();
        }

        public FrmDataList(FTSMain ftsmain, string tablename) {
            this.mCondition = string.Empty;
            this.mMode = ListMode.LIST;
            this.mDataSet = new DataSet();
            this.mTableName = tablename;
            this.mFilterValue = string.Empty;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.toolbar.ChoiceVisible = BarItemVisibility.Never;
            this.toolbar.CloseVisible = BarItemVisibility.Never;
            //this.MdiParent = this.mFTSMain.MainForm;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.treeList.Visible = false;
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FrmDataList(FTSMain ftsmain, string tablename,bool showdialog)
        {
            this.mCondition = string.Empty;
            this.mMode = ListMode.LIST;
            this.mDataSet = new DataSet();
            this.mTableName = tablename;
            this.mFilterValue = string.Empty;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.toolbar.ChoiceVisible = BarItemVisibility.Never;
            this.toolbar.CloseVisible = BarItemVisibility.Never;
            if(!showdialog)
                this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
                //this.MdiParent = this.mFTSMain.MainForm;
            this.treeList.Visible = false;
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FrmDataList(FTSMain ftsmain, string tablename, string condition) {
            this.mCondition = condition;
            this.mMode = ListMode.LIST;
            this.mDataSet = new DataSet();
            this.mTableName = tablename;
            this.mFilterValue = string.Empty;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.toolbar.ChoiceVisible = BarItemVisibility.Never;
            this.toolbar.CloseVisible = BarItemVisibility.Never;
            //this.MdiParent = this.mFTSMain.MainForm;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.treeList.Visible = false;
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FrmDataList(FTSMain ftsmain, DataSet ds, string tablename, string val) {
            this.mCondition = string.Empty;
            this.mMode = ListMode.SELECT;
            this.OldDataSet = ds;
            this.mDataSet = ds.Copy();
            this.mTableName = tablename;
            this.mFilterValue = val;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.treeList.Visible = false;
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public FrmDataList(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val, bool allowempty) {
            this.mCondition = condition;
            if (this.mCondition == "1=1") {
                this.mCondition = string.Empty;
            }
            this.mMode = ListMode.SELECT;
            this.OldDataSet = ds;
            this.mDataSet = ds.Copy();
            this.mTableName = tablename;
            this.mFilterValue = val;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.treeList.Visible = false;
            if (!allowempty) {
                this.toolbar.CloseVisible = BarItemVisibility.Never;
                this.ControlBox = false;
            }
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public FrmDataList(FTSMain ftsmain, DataTable table) {
            this.mCondition = string.Empty;
            this.mMode = ListMode.SELECT;
            this.mDataSet = new DataSet();
            this.mDataSet.Tables.Add(table);
            this.mTableName = table.TableName;
            this.mFilterValue = "";
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            this.treeList.Visible = false;
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public string Condition {
            get { return this.mCondition; }
            set { this.mCondition = value; }
        }

        public string TableName {
            get { return this.mTableName; }
            set { this.mTableName = value; }
        }

        public string FilterValue {
            get { return this.mFilterValue; }
            set { this.mFilterValue = value; }
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public DataSet DataSet {
            get { return this.mDataSet; }
            set { this.mDataSet = value; }
        }

        public ObjectBase DataObject {
            get { return this.mDataObject; }
            set { this.mDataObject = value; }
        }

        public ListMode Mode {
            get { return this.mMode; }
            set { this.mMode = value; }
        }

        public DataRow RetRow {
            get { return this.mRetRow; }
            set { this.mRetRow = value; }
        }

        public FrmDataEditDetail FormDataEditDetail {
            get { return this.frmDataEditDetail; }
            set { this.frmDataEditDetail = value; }
        }

        public FTSSelectItemToolbar ToolBar {
            get { return this.toolbar; }
        }

        public FTSDataGrid Grid {
            get { return this.grid; }
        }

        public bool DataChanged
        {
            get { return this.mDataChanged; }
            set { this.mDataChanged = value; }
        }

        /*
        public TreeList Tree
        {
            get
            {
                return this.treeList;
            }
        }
        */

        public FTSTreeList TreeList {
            get { return this.treeList; }
        }

        public string RelTreeListIdField {
            get { return this.mRelTreeListIdField; }
            set { this.mRelTreeListIdField = value; }
        }

        public string RelGridIdField {
            get { return this.mRelGridIdField; }
            set { this.mRelGridIdField = value; }
        }

        public string ParentRelGridIdField {
            get { return this.mParentRelGridIdField; }
            set { this.mParentRelGridIdField = value; }
        }

        public bool ShowTreeList {
            get { return this.mShowTreeList; }
            set {
                this.mShowTreeList = value;
                this.treeList.Visible = this.mShowTreeList;
            }
        }

        public bool ClearFilter {
            get { return this.mClearFilter; }
            set { this.mClearFilter = value; }
        }

        public DataSet OldDataSet {
            get { return this.mOldDataSet; }
            set { this.mOldDataSet = value; }
        }

        public List<DataRow> RetRowList {
            get { return this.mRetRowList; }
            set { this.mRetRowList = value; }
        }

        #region 1: Data Methods

        public virtual void BindGrid() {
        }

        public virtual void DeleteRecord() {
            if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                this.CheckSecurityBussiess(DataAction.DeleteAction);
                DialogResult dgresultdelete =
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_DELETE_RECORD_CONFIRM"));
                if (dgresultdelete == DialogResult.Yes) {
                    object id =
                        this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mDataObject.IdField];
                    this.UpdateDeletedRecord(id);
                }
            }
        }

        public virtual void GetfrmDataEditDetail(bool isnew, object id) {
        }

        public virtual void LoadData() {
        }

        public virtual void NewRecord() {
            this.grid.ViewGrid.ClearColumnsFilter();
            this.ShowFormEditor(true);
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
        }

        public virtual void ShowFormEditor(bool flgnew) {
            if (flgnew) {
                this.CheckSecurityBussiess(DataAction.AddAction);
                this.GetfrmDataEditDetail(true, null);
                this.frmDataEditDetail.ShowDialog();
                this.frmDataEditDetail.Close();
                this.frmDataEditDetail = null;
            } else {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    this.CheckSecurityBussiess(DataAction.EditAction);
                    this.GetfrmDataEditDetail(false,
                                              this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[
                                                  this.mDataObject.IdField]);
                    if (this.mMode == ListMode.SELECT) {
                        this.frmDataEditDetail.ShowDialog();
                        this.frmDataEditDetail.Close();
                        this.frmDataEditDetail = null;
                    } else {
                        this.frmDataEditDetail.ShowDialog();
                        this.frmDataEditDetail.Close();
                        this.frmDataEditDetail = null;
                        //frmDataEditDetail.UpdateInfo();
                    }
                }
            }
        }

        public virtual void ShowFormEditList() {
            Type frm = this.GetFrmDicEditList(this.TableName);
            if (frm != null) {
                Type[] typeArray = new Type[1] {typeof (FTSMain)};
                ConstructorInfo constructorInfoObj = frm.GetConstructor(typeArray);
                Object[] objArg = new object[1] {this.mFTSMain};
                FrmDataEditList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditList;
                frmdic.Show();
            }
        }

        public virtual void UpdateChangeRecord(DataRow row, bool ischanged) {
            DataRow origrow = null;
            if (ischanged) {
                origrow = this.mDataObject.GetRowWithID(row[this.mDataObject.IdField, DataRowVersion.Original]);
            }
            if (origrow == null) {
                origrow = this.mDataObject.AddRow(row);
            } else {
                foreach (DataColumn c in this.mDataObject.DataTable.Columns) {
                    if (row.Table.Columns.IndexOf(c.ColumnName) >= 0) {
                        origrow[c.ColumnName] = row[c.ColumnName];
                    }
                }
            }
            this.mDataObject.DataTable.AcceptChanges();
            if (this.OldDataSet != null) {
                if (this.OldDataSet.Tables[this.TableName] != null) {
                    this.OldDataSet.Tables.Remove(this.TableName);
                }
                this.OldDataSet.Tables.Add(this.mDataObject.DataTable.Copy());
            }
            this.grid.ViewGrid.FocusedRowHandle = this.grid.ViewGrid.GetRowHandle(this.mDataObject.GetRowIndex(origrow));
            this.grid.ViewGrid.RefreshData();
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            this.mDataChanged = true;
        }

        public virtual void UpdateDeletedRecord(object id) {
            this.mDataObject.DeleteInData(id);
            this.mDataObject.DataTable.AcceptChanges();
            if (this.OldDataSet != null) {
                if (this.OldDataSet.Tables[this.TableName] != null) {
                    this.OldDataSet.Tables.Remove(this.TableName);
                }
                this.OldDataSet.Tables.Add(this.mDataObject.DataTable.Copy());
            }
            this.grid.ViewGrid.RefreshData();
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            this.mDataChanged = true;
        }

        #endregion

        #region 2: Layout Methods

        protected virtual void LayoutGrid() {
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum) {
                    this.grid.SetSummary(c, cinfo.SumType);
                }
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.grid.SetFont();
            }
        }

        protected virtual void LayoutTree() {
            foreach (TreeListColumn c in this.treeList.Columns) {
                c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "TREELIST", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (TreeListColumn c in this.treeList.Columns) {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "TREELIST", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn
                              ? DevExpress.XtraTreeList.Columns.FixedStyle.Left
                              : DevExpress.XtraTreeList.Columns.FixedStyle.None;
                if (cinfo.IsSum) {
                    this.treeList.SetSummary(c, cinfo.SumType);
                }
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.treeList.SetFont();
            }
        }

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);           
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN"){
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.SetProductVersion();
        }

        public override void LoadLayout(FTSMain ftsmain) {
            if (this.Mode == ListMode.LIST) {
                this.Name = this.Name + "_LIST";
            }
            base.LoadLayout(ftsmain);
            this.toolbar.LoadLayout(this.mFTSMain);
            this.LayoutGrid();
            if (this.mShowTreeList) {
                this.LayoutTree();
            }
            if (this.Mode == ListMode.LIST) {
                this.toolbar.EditListVisible = BarItemVisibility.Always;
                this.toolbar.ChoiceVisible = BarItemVisibility.Never;
                this.toolbar.CloseVisible = BarItemVisibility.Never;
            } else {
                this.toolbar.EditListVisible = BarItemVisibility.Never;
                this.toolbar.ChoiceVisible = BarItemVisibility.Always;
                this.toolbar.CloseVisible = BarItemVisibility.Always;
            }
            this.SetProductVersion();
        }

        protected virtual void SaveGridLayout() {
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN && this.mFTSMain.UserInfo.UserGroupID == "ADMIN") {
                foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                    IRequire ir = c as IRequire;
                    bool isrequired = true;
                    int require = 0;
                    if (ir != null) {
                        require = ir.Require ? 1 : 0;
                        isrequired = ir.Require ? true : false;
                    }
                    string summarytype = string.Empty;
                    string summaryformat = string.Empty;
                    bool issummary = c.SummaryItem.SummaryType == SummaryItemType.None ? false : true;
                    bool fixcolumn = c.Fixed == FixedStyle.Left ? true : false;
                    if (issummary) {
                        summarytype = UIFunctions.GetSumType(c.SummaryItem.SummaryType);
                    }
                    FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
                    //if (this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName, 0) != c.VisibleIndex ||
                    //    this.FTSMain.GridManager.IsEnabled(this.Name, "GRID", c.FieldName) != c.OptionsColumn.AllowEdit ||
                    //    this.FTSMain.GridManager.IsVisible(this.Name, "GRID", c.FieldName) != c.Visible ||
                    //    this.FTSMain.GridManager.GetWidth(this.Name, "GRID", c.FieldName) != c.Width ||
                    //    this.FTSMain.GridManager.IsFiltered(this.Name, "GRID", c.FieldName) != c.OptionsFilter.AllowFilter ||
                    //    this.FTSMain.GridManager.IsRequire(this.Name, "GRID", c.FieldName) != isrequired ||
                    //    this.FTSMain.GridManager.IsFixedColumn(this.Name, "GRID", c.FieldName) != fixcolumn ||
                    //    this.FTSMain.GridManager.IsSum(this.Name, "GRID", c.FieldName) != issummary ||
                    //    this.FTSMain.GridManager.GetSumType(this.Name, "GRID", c.FieldName) != summarytype ||
                    //    this.FTSMain.GridManager.GetDisplayName(this.Name, "GRID", c.FieldName) != c.Caption
                    //    )
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype) {
                        this.mFTSMain.GridManager.UpdateConfig(this.Name, "GRID", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                    //this.mFTSMain.FieldManager.SetDisplayName(this.grid.DataMember, c.FieldName, c.Caption);
                }
            }
        }

        protected virtual void SaveTreeLayout() {
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN && this.FTSMain.UserInfo.UserGroupID == "ADMIN") {
                foreach (TreeListColumn c in this.treeList.Columns) {
                    IRequire ir = c as IRequire;
                    bool isrequired = true;
                    int require = 0;
                    if (ir != null) {
                        require = ir.Require ? 1 : 0;
                        isrequired = ir.Require ? true : false;
                    }
                    string summarytype = string.Empty;
                    string summaryformat = string.Empty;
                    bool issummary = c.SummaryFooter == DevExpress.XtraTreeList.SummaryItemType.None ? false : true;
                    bool fixcolumn = c.Fixed == DevExpress.XtraTreeList.Columns.FixedStyle.Left ? true : false;
                    if (issummary) {
                        summarytype = UIFunctions.GetSumType(c.SummaryFooter);
                    }
                    FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "TREELIST",
                                                                                          c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width || cinfo.Enabled != true ||
                        cinfo.Require != isrequired || cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary ||
                        cinfo.SumType != summarytype) {
                        this.mFTSMain.GridManager.UpdateConfig(this.Name, "TREELIST", c.FieldName,
                                                               c.OptionsColumn.AllowEdit, c.Visible, c.Width,
                                                               c.VisibleIndex, require, true, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }
            }
        }

        public override void SaveLayout(FTSMain ftsmain) {
            base.SaveLayout(ftsmain);
            this.SaveGridLayout();
            if (this.mShowTreeList) {
                this.SaveTreeLayout();
            }
        }

        #endregion 2: Layout Methods

        #region 3: TreeList

        public virtual void BindTreeList() {
        }

        public virtual void ConfigTreeList() {
            if (this.mShowTreeList) {
                this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                this.treeList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            }
        }

        public virtual void FocusedNodeChanged(TreeListNode node) {
        }

        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            if (e.Node != null) {
                if (e.Node.ParentNode == null) {
                    if (this.mClearFilter) {
                        this.grid.ViewGrid.ClearColumnsFilter();
                    } else {
                        string filtervalue =
                            ((DataRowView) this.treeList.GetDataRecordByNode(e.Node))[this.mRelTreeListIdField].ToString
                                ();
                        if (this.mParentRelGridIdField != string.Empty) {
                            if (e.Node.HasChildren) {
                                this.grid.ViewGrid.Columns[this.mParentRelGridIdField].FilterInfo =
                                    new ColumnFilterInfo(
                                        "[" + this.mParentRelGridIdField + "] Like '%," + filtervalue + ",%'",
                                        string.Empty, filtervalue, ColumnFilterType.AutoFilter);
                            } else {
                                this.grid.ViewGrid.Columns[this.mRelGridIdField].FilterInfo =
                                    new ColumnFilterInfo("[" + this.mRelGridIdField + "] = '" + filtervalue + "'",
                                                         string.Empty, filtervalue, ColumnFilterType.AutoFilter);
                            }
                        } else {
                            this.grid.ViewGrid.Columns[this.mRelGridIdField].FilterInfo =
                                new ColumnFilterInfo("[" + this.mRelGridIdField + "] = '" + filtervalue + "'",
                                                     string.Empty, filtervalue, ColumnFilterType.AutoFilter);
                        }
                    }
                } else {
                    this.grid.ViewGrid.ClearColumnsFilter();
                    string filtervalue =
                        ((DataRowView) this.treeList.GetDataRecordByNode(e.Node))[this.mRelTreeListIdField].ToString();
                    if (this.mParentRelGridIdField != string.Empty) {
                        if (e.Node.HasChildren) {
                            this.grid.ViewGrid.Columns[this.mParentRelGridIdField].FilterInfo =
                                new ColumnFilterInfo(
                                    "[" + this.mParentRelGridIdField + "] Like '%," + filtervalue + ",%'", string.Empty,
                                    "," + filtervalue + ",", ColumnFilterType.AutoFilter);
                        } else {
                            this.grid.ViewGrid.Columns[this.mRelGridIdField].FilterInfo =
                                new ColumnFilterInfo("[" + this.mRelGridIdField + "] = '" + filtervalue + "'",
                                                     string.Empty, filtervalue, ColumnFilterType.AutoFilter);
                        }
                    } else {
                        this.grid.ViewGrid.Columns[this.mRelGridIdField].FilterInfo =
                            new ColumnFilterInfo("[" + this.mRelGridIdField + "] = '" + filtervalue + "'", string.Empty,
                                                 filtervalue, ColumnFilterType.AutoFilter);
                    }
                }
                this.FocusedNodeChanged(e.Node);
            }
        }

        #endregion

        #region 4: User Actions

        protected void ConfigAction() {
            if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                this.toolbar.DeleteEnable = true;
                this.toolbar.EditEnable = true;
                this.toolbar.ChoiceEnable = true;
            } else {
                this.toolbar.DeleteEnable = false;
                this.toolbar.EditEnable = false;
                this.toolbar.ChoiceEnable = false;
            }
        }

        protected void ConfigGrid() {
            this.grid.ViewGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.grid.ViewGrid.OptionsBehavior.Editable = false;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid.ViewGrid.OptionsView.ShowFooter = true;
            this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.grid.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.grid.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            /*
            string displayText = string.Empty;
            if (this.grid.ViewGrid.Columns[this.mDataObject.IdField] != null)
            {
                displayText =
                    String.Format("[" + this.grid.ViewGrid.Columns[this.mDataObject.IdField].Caption + "] % '{0}'",
                                  this.mFilterValue);
            }
            else
            {
                displayText =
                    String.Format(
                        "[" + this.mFTSMain.FieldManager.GetDisplayName(this.mTableName, this.mDataObject.IdField) +
                        "] % '{0}'", this.mFilterValue);
            }
            */
                this.grid.ViewGrid.Columns[this.mDataObject.IdField].FilterInfo = new ColumnFilterInfo("[" + this.mDataObject.IdField + "] Like '" + this.mFilterValue + "%'", string.Empty,
                                                                                                       this.mFilterValue, ColumnFilterType.AutoFilter);
            this.grid.ShowFilterRow();
            if (this.grid.ViewGrid.RowCount == 0) {
                this.grid.ViewGrid.ClearColumnsFilter();
            }
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ChooseRow += new SelectRowEventHandler(this.grid_ChooseRow);
            this.grid.ProcessGridKey += new KeyEventHandler(this.grid_ProcessGridKey);
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            if (this.grid.ViewGrid.RowCount > 0) {
                this.grid.ViewGrid.FocusedRowHandle = 0;
            }
            this.grid.Focus();
        }

        private void grid_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                if (this.mMode == ListMode.SELECT) {
                    this.SelectRow();
                } else {
                    this.ShowFormEditor(false);
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            }
        }

        private void grid_ProcessGridKey(object sender, KeyEventArgs e) {
            string key = e.KeyData.ToString();
            try {
                switch (key) {
                    case "Insert, Control":
                        this.NewRecord();
                        break;
                    case "P, Control":
                        this.grid.Print();
                        break;
                    case "Delete, Control":
                        this.DeleteRecord();
                        break;
                    case "E, Control":
                        this.ShowFormEditor(false);
                        break;
                    case "F4, Control":
                        this.Close();
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            try {
                if (this.WindowState != FormWindowState.Normal) {
                    this.WindowState = FormWindowState.Normal;
                }
                if (this.treeList.Visible) {
                    this.treeList.Visible = false;
                    this.Width = this.Width - this.treeList.Width;
                }
                this.SaveLayout(this.mFTSMain);
                this.DestroyCustomization();
            } catch (Exception) {
            }
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "New":
                        this.NewRecord();
                        break;
                    case "Delete":
                        this.DeleteRecord();
                        break;
                    case "ChangeID":
                        this.ChangeRecord();
                        break;
                    case "Print":
                        this.CheckSecurityBussiess(DataAction.PrintAction);
                        this.grid.ShowPrintPreview();
                        break;
                    case "Edit":
                        this.ShowFormEditor(false);
                        break;
                    case "Close":
                        this.CloseForm();
                        break;
                    case "Choice":
                        this.SelectRow();
                        break;
                    case "Config":
                        this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    case "EditList":
                        if (this.Mode == ListMode.LIST) {
                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                            this.ShowFormEditList();
                        }
                        break;
                    case "ExportExcel":
						this.CheckSecurityBussiess(DataAction.PrintAction);
                        this.grid.ExportToXLS();
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

       

        public virtual void CloseForm() {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            try {
                this.ConfigAction();
                this.SetTextFooter();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                this.SetTextFooter();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        #endregion

        #region 5: Hand Code

        public virtual void CreateStatusBar() {
            BarStaticItem itemStatus = new BarStaticItem();
            Bar bar = new Bar();
            BarManager barManager = new BarManager();
            ((ISupportInitialize) (barManager)).BeginInit();
            barManager.AllowCustomization = false;
            barManager.AllowMoveBarOnToolbar = false;
            barManager.AllowQuickCustomization = false;
            barManager.AllowShowToolbarsPopup = false;
            barManager.Bars.AddRange(new Bar[] {bar});
            barManager.Form = this;
            barManager.Items.AddRange(new BarItem[] {itemStatus});
            barManager.MaxItemId = 1;
            barManager.StatusBar = bar;
            bar.BarName = "barStatus";
            bar.CanDockStyle = BarCanDockStyle.Bottom;
            bar.DockCol = 0;
            bar.DockRow = 0;
            bar.DockStyle = BarDockStyle.Bottom;
            bar.LinksPersistInfo.AddRange(new LinkPersistInfo[] {
                                                                    new LinkPersistInfo(BarLinkUserDefines.PaintStyle, itemStatus,
                                                                                        BarItemPaintStyle.Caption)
                                                                });
            bar.OptionsBar.AllowQuickCustomization = false;
            bar.OptionsBar.DrawDragBorder = false;
            bar.OptionsBar.UseWholeRow = true;
            bar.Text = "barStatus";
            itemStatus.Border = BorderStyles.NoBorder;
            itemStatus.Id = 0;
            itemStatus.Name = "itemStatus";
            itemStatus.TextAlignment = StringAlignment.Near;
            //itemStatus.Caption = "Mới: Ctrl+Insert, Sửa: Ctrl+E, Xoá: Ctrl+Delete";
            ((ISupportInitialize) (barManager)).EndInit();
        }

        #endregion

        #region 6: Override

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!this.DesignMode) {
                this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            }
        }

        #endregion

        public virtual void SetTextFooter() {
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }
        public virtual void CheckSecurityBussiess(string dataaction) {
            if (this.DataObject != null)
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }
        protected virtual void SelectRow() {
            if (this.grid.ViewGrid.OptionsSelection.MultiSelect) {
                if (this.grid.ViewGrid.GetSelectedRows() != null) {
                    List<DataRow> selectedRows = new List<DataRow>();
                    foreach (int pos in this.grid.ViewGrid.GetSelectedRows()) {
                        DataRow row = this.grid.ViewGrid.GetDataRow(pos);
                        selectedRows.Add(row);
                    }
                    this.RetRowList = selectedRows;
                    this.DialogResult = DialogResult.OK;
                }else {
                    this.DialogResult = DialogResult.Cancel;
                }
            } else {
                this.mRetRow = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                if (this.mRetRow == null) {
                    this.DialogResult = DialogResult.Cancel;
                } else {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        public virtual void ChangeRecord() {
            if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                this.CheckSecurityBussiess(DataAction.AddAction);
                FrmGetString frm = new FrmGetString(this.FTSMain.MsgManager.GetMessage("MSG_NEW_ID"), this.FTSMain.MsgManager.GetMessage("MSG_NEW_ID"));
                if (frm.ShowDialog() == DialogResult.Yes) {
                    string id = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle)[this.mDataObject.IdField].ToString();
                    if (this.DataObject.IDExists(frm.RetVal)) {
                        DialogResult dgresultdelete =
                            FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_MERGE_RECORD_CONFIRM"));
                        if (dgresultdelete == DialogResult.Yes) {
                            this.DataObject.MergeRecord(id, frm.RetVal);
                        }        
                    }else {
                        this.DataObject.ChangeRecord(id, frm.RetVal);
                    }
                }
                
            }
        }
    }
}