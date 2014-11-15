#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.ImportData;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CellValueChangedEventArgs = DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs;
using CellValueChangedEventHandler = DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler;
using FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle;
using FocusedColumnChangedEventArgs = DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs;
using FocusedColumnChangedEventHandler = DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler;
using ItemClickEventArgs = DevExpress.XtraBars.ItemClickEventArgs;
using ItemClickEventHandler = DevExpress.XtraBars.ItemClickEventHandler;
using SummaryItemType = DevExpress.Data.SummaryItemType;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmDataEditList : FTSForm {
        private FTSMain mFTSMain;
        private ObjectBase mDataObject;

        private AppearanceDefault WarningColor = new AppearanceDefault(Color.White, Color.LightCoral, Color.Empty,
                                                                       Color.Red, LinearGradientMode.ForwardDiagonal);

        private bool mIsMultiSelect = true;
        private bool mShowGroupPanel = true;
        private bool mShowTextFooter = true;
        private string mRelTreeListIdField = string.Empty;
        private string mRelGridIdField = string.Empty;
        private string mParentRelGridIdField = string.Empty;
        private bool mShowTreeList = false;
        private bool mClearFilter = true;
        private bool mShowContextMenu = true;
        private bool mAskToSave = true;

        public FrmDataEditList() {
            this.InitializeComponent();
        }

        public FrmDataEditList(FTSMain ftsMain) {
            this.mFTSMain = ftsMain;
            this.InitializeComponent();
            this.CreateStatusBar();
            //this.MdiParent = this.mFTSMain.MainForm;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.LoadData();
            this.BindGrid();
            this.LoadContextMenu();
            this.grid.SelectRow();
            this.ConfigAction();
            this.ShowInTaskbar = false;
            this.toolbar.LoadLayout(this.mFTSMain);
            this.treeList.Visible = false;
            this.mShowTreeList = false;
            this.mClearFilter = true;
            this.mShowContextMenu = true;
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FrmDataEditList(FTSMain ftsMain, bool showdialog) {
            this.mFTSMain = ftsMain;
            this.InitializeComponent();
            this.CreateStatusBar();
            if (!showdialog) {
                //this.MdiParent = this.mFTSMain.MainForm;
                this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            }
            this.LoadData();
            this.BindGrid();
            this.LoadContextMenu();
            this.grid.SelectRow();
            this.ConfigAction();
            this.ShowInTaskbar = false;
            this.toolbar.LoadLayout(this.mFTSMain);
            this.treeList.Visible = false;
            this.mShowTreeList = false;
            this.mClearFilter = true;
            this.mShowContextMenu = true;
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public ObjectBase DataObject {
            get { return this.mDataObject; }
            set { this.mDataObject = value; }
        }

        public bool IsMultiSelect {
            get { return this.mIsMultiSelect; }
            set { this.mIsMultiSelect = value; }
        }

        public bool ShowGroupPanel {
            get { return this.mShowGroupPanel; }
            set { this.mShowGroupPanel = value; }
        }

        public bool ShowTextFooter {
            get { return this.mShowTextFooter; }
            set { this.mShowTextFooter = value; }
        }

        public FTSEditFormToolbar ToolBar {
            get { return this.toolbar; }
        }

        public FTSDataGrid Grid {
            get { return this.grid; }
        }

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

        public bool ShowContextMenu{
            get { return this.mShowContextMenu; }
            set { this.mShowContextMenu = value; }
        }

        public bool AskToSave {
            get { return this.mAskToSave; }
            set { this.mAskToSave = value; }
        }

        #region Initialization Methods

        public virtual void LoadData() {
        }

        public virtual void BindGrid() {
        }

        public virtual void SetControls() {
        }

        #endregion Overriden

        #region 1: Data Processing Methods

        public virtual void EndEdit() {
            this.grid.EndEdit();
            this.mDataObject.EndEdit();
            this.mDataObject.RemoveEmptyRows();
        }

        protected virtual ChangedStatus CheckChanged() {
            this.EndEdit();
            if (this.mAskToSave) {
                if (this.mDataObject.HasChanged()) {
                    DialogResult dresult = FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoCancelMessage(this.mFTSMain.MsgManager.GetMessage("MSG_UPDATE_CHANGE"));
                    if (dresult == DialogResult.Yes) {
                        this.UpdateRecord();
                        return ChangedStatus.YES;
                    } else if (dresult == DialogResult.Cancel) {
                        return ChangedStatus.CANCEL;
                    } else {
                        this.RestoreRecord();
                        return ChangedStatus.NO;
                    }
                } else {
                    return ChangedStatus.NONE;
                }
            }else {
                return ChangedStatus.YES;
            }
        }

        public virtual void CheckSecurityBussiess(string dataaction) {
            if (this.DataObject != null)
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }

        protected string GetIdNodeParents(TreeListNode node) {
            if (node != null) {
                string ids = "," +
                             ((DataRowView) this.treeList.GetDataRecordByNode(node))[this.mRelGridIdField].ToString() +
                             ",";
                TreeListNode parent = node;
                do {
                    ids = ids +
                          ((DataRowView) this.treeList.GetDataRecordByNode(parent))[this.mParentRelGridIdField].ToString
                              () + ",";
                    parent = parent.ParentNode;
                }
                while (parent != null);
                return ids;
            } else {
                return string.Empty;
            }
        }

        public virtual void NewRecord() {
            if (!this.AllowNew || !this.toolbar.NewEnable || !(this.toolbar.NewVisible == BarItemVisibility.Always)) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            this.grid.ViewGrid.ClearColumnsFilter();
            this.grid.ViewGrid.ClearSelection();
            this.EndEdit();
            if ((this.mShowTreeList) && (this.treeList.FocusedNode != null)) {
                DataRow newrow = this.mDataObject.AddNew();
                newrow[this.mRelGridIdField] =
                    ((DataRowView) this.treeList.GetDataRecordByNode(this.treeList.FocusedNode))[
                        this.mRelTreeListIdField];
                if (this.mParentRelGridIdField != string.Empty) {
                    newrow[this.mParentRelGridIdField] = this.GetIdNodeParents(this.treeList.FocusedNode);
                }
                newrow.EndEdit();
                if (this.treeList.FocusedNode != null) {
                    string filtervalue =
                        ((DataRowView) this.treeList.GetDataRecordByNode(this.treeList.FocusedNode))[
                            this.mRelTreeListIdField].ToString();
                    if (this.mParentRelGridIdField != string.Empty) {
                        if (this.treeList.FocusedNode.HasChildren) {
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
            } else {
                this.mDataObject.AddNew();
            }
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
        }

        public virtual void CopyRecord() {
            if (!this.AllowNew || !this.AllowCopy || !this.toolbar.CopyEnable ||
                !(this.toolbar.CopyVisible == BarItemVisibility.Always)) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            this.EndEdit();
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            int startpos = bm.Count;
            if (this.grid.ViewGrid.GetSelectedRows() != null) {
                List<DataRow> selectedRows = new List<DataRow>();
                foreach (int pos in this.grid.ViewGrid.GetSelectedRows()) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(pos);
                    selectedRows.Add(row);
                }
                foreach (DataRow row in selectedRows) {
                    this.mDataObject.CopyRecord(row);
                }
            } else {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    this.mDataObject.CopyRecord(row);
                }
            }
            bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            int endpos = bm.Count - 1;
            this.grid.ViewGrid.ClearSelection();
            if (bm.Count > 0 && endpos < bm.Count) {
                bm.Position = endpos;
            }
            for (int index = startpos; index <= endpos; index++) {
                this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.GetRowHandle(index));
            }
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
        }

        public virtual void UpdateRecord() {
            this.EndEdit();
            this.CheckGridRequire(this.grid);
            this.mDataObject.UpdateData();
            FTS.BaseUI.Utilities.FTSMessageBox.ShowInfoMessage(this.FTSMain.MsgManager.GetMessage("MSG_UPDATE_SUCCESSFULL"));
        }

        public virtual void RestoreRecord() {
            this.grid.ViewGrid.ClearSelection();
            this.EndEdit();
            this.mDataObject.Restore();
            this.grid.ViewGrid.ClearColumnsFilter();
            this.grid.ViewGrid.ClearColumnErrors();
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
        }

        public virtual void DeleteRecord() {
            if (!this.AllowDelete || !this.toolbar.DeleteEnable ||
                !(this.toolbar.DeleteVisible == BarItemVisibility.Always)) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.DeleteAction);
            this.EndEdit();
            if (this.grid.ViewGrid.GetSelectedRows() != null) {
                List<DataRow> selectedRows = new List<DataRow>();
                foreach (int pos in this.grid.ViewGrid.GetSelectedRows()) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(pos);
                    selectedRows.Add(row);
                }
                foreach (DataRow row in selectedRows) {
                    this.mDataObject.DeleteRow(row);
                }
            } else {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    this.mDataObject.DeleteRow(row);
                }
            }
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
        }

        public virtual void PrintRecord() {
			this.CheckSecurityBussiess(DataAction.PrintAction);
            this.grid.ShowPrintPreview();
        }

        protected override void OnClosing(CancelEventArgs e) {
            try {
                if (this.CheckChanged() == ChangedStatus.CANCEL) {
                    e.Cancel = true;
                }
                if (!e.Cancel) {
                    if (this.WindowState != FormWindowState.Normal) {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.SaveLayout(this.mFTSMain);
                    this.DestroyCustomization();
                }
            } catch (FTSException ex) {
                e.Cancel = true;
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                e.Cancel = true;
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        public virtual void RefreshDm() {
            this.mDataObject.RefreshDm();
        }

        #endregion 1: Data Processing Methods

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
                IRequire ir = c as IRequire;
                if (ir != null) {
                    ir.Require = cinfo.Require;
                    if (ir.Require) {
                        c.AppearanceCell.BackColor = SystemColors.Info;
                        c.AppearanceCell.Options.UseBackColor = true;
                    }
                }
                //c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName, 0);
                //c.Width = this.mFTSMain.GridManager.GetWidth(this.Name, "GRID", c.FieldName);
                //c.OptionsColumn.AllowEdit = this.mFTSMain.GridManager.IsEnabled(this.Name, "GRID", c.FieldName);
                //c.OptionsFilter.AllowFilter = this.mFTSMain.GridManager.IsFiltered(this.Name, "GRID", c.FieldName);
                //c.Caption = this.mFTSMain.GridManager.GetDisplayName(this.Name, "GRID", c.FieldName);
                //c.Fixed = this.mFTSMain.GridManager.IsFixedColumn(this.Name, "GRID", c.FieldName)
                //              ? FixedStyle.Left
                //              : FixedStyle.None;
                //if (this.mFTSMain.GridManager.IsSum(this.Name, "GRID", c.FieldName)){
                //    this.grid.SetSummary(c,this.mFTSMain.GridManager.GetSumType(this.Name, "GRID", c.FieldName));
                //}
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.grid.SetFont();
            }
        }

        //protected virtual void LayoutGrid(){
        //    foreach (GridColumn c in this.grid.ViewGrid.Columns){
        //        c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName,
        //                                                                   c.AbsoluteIndex);
        //    }
        //    foreach (GridColumn c in this.grid.ViewGrid.Columns){
        //        c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName, 0);
        //        c.Width = this.mFTSMain.GridManager.GetWidth(this.Name, "GRID", c.FieldName);
        //        c.OptionsColumn.AllowEdit = this.mFTSMain.GridManager.IsEnabled(this.Name, "GRID", c.FieldName);
        //        c.OptionsFilter.AllowFilter = this.mFTSMain.GridManager.IsFiltered(this.Name, "GRID", c.FieldName);

        //        IRequire ir = c as IRequire;
        //        if (ir != null){
        //            ir.Require = this.mFTSMain.GridManager.IsRequire(this.Name, "GRID", c.FieldName);
        //            if (ir.Require){
        //                c.AppearanceCell.BackColor = SystemColors.Info;
        //                c.AppearanceCell.Options.UseBackColor = true;
        //            }
        //        }
        //    }
        //}
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
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.LayoutGrid();
            if (this.mShowTreeList) {
                this.LayoutTree();
            }
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
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

        #region 3: User actions

        private void LoadContextMenu() {
            this.grid.ViewGrid.ShowGridMenu += new GridMenuEventHandler(this.ViewGrid_ShowGridMenu);
            this.barManager.Images = this.toolbar.ImageList;
            ((ISupportInitialize) (this.contextMenu)).BeginInit();
            BarButtonItem item = new BarButtonItem();
            item.Name = "BUTTON_NEW";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_NEW", "TEXT", "STRING").ToString().
                    Trim();
            item.ImageIndex = 3;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_COPY";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_COPY", "TEXT", "STRING").ToString().
                    Trim();
            item.ImageIndex = 6;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_SAVE";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_SAVE", "TEXT", "STRING").ToString().
                    Trim();
            item.ImageIndex = 8;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_DELETE";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_DELETE", "TEXT", "STRING").ToString()
                    .Trim();
            item.ImageIndex = 7;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_RESTORE";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_RESTORE", "TEXT", "STRING").ToString
                    ().Trim();
            item.ImageIndex = 2;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_FILTER";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_FILTER", "TEXT", "STRING").ToString()
                    .Trim();
            item.ImageIndex = 15;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_CONFIG";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_CONGFIG", "TEXT", "STRING").ToString
                    ().Trim();
            item.ImageIndex = 10;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.contextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            ((ISupportInitialize) (this.contextMenu)).BeginInit();
        }

        private void ContextMenuCommands(object sender, ItemClickEventArgs e) {
            try {
                BarButtonItem item = (BarButtonItem) e.Item;
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_NEW", "TEXT", "STRING").ToString
                        ().Trim()) {
                    this.NewRecord();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_RESTORE", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.RestoreRecord();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_DELETE", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.DeleteRecord();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_SAVE", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.UpdateRecord();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_COPY", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.CopyRecord();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_FILTER", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.grid.ViewGrid.ClearSelection();
                    this.grid.ShowFilterRow();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMTUDIEN", "GRID_MENU_CONGFIG", "TEXT", "STRING").
                        ToString().Trim()) {
                    this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                }
                this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.FocusedRowHandle);
                this.ConfigAction();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        public virtual void CloseForm() {
            this.Close();
        }

        private void toolbar_ItemClick(object sender, Controls.ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "New":
                        this.NewRecord();
                        break;
                    case "Copy":
                        this.CopyRecord();
                        break;
                    case "Save":
                        this.UpdateRecord();
                        break;
                    case "Delete":
                        this.DeleteRecord();
                        break;
                    case "Print":
                        this.PrintRecord();
                        break;
                    case "Undo":
                        this.RestoreRecord();
                        break;
                    case "Filter":
                        this.grid.ViewGrid.ClearSelection();
                        this.grid.ShowFilterRow();
                        break;
                    case "ExportExcel":
                        this.grid.ExportToXLS();
                        break;
                    case "Layout":
                        this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    case "Refresh":
                        this.RefreshDm();
                        break;
                    case "Close":
                        this.CloseForm();
                        return;
                    case "ImportExcel":
                        this.ImportExcel();
                        break;
                    
                    default:
                        break;
                }
                this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.FocusedRowHandle);
                this.ConfigAction();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        private void grid_ProcessGridKey(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter) {
                    if ((this.grid.ViewGrid.VisibleColumns.Count > 0) &&
                        (this.grid.ViewGrid.FocusedColumn.VisibleIndex == (this.grid.ViewGrid.VisibleColumns.Count - 1)) &&
                        (this.grid.ViewGrid.FocusedRowHandle == (this.grid.ViewGrid.RowCount - 1))) {
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                        this.BeginInvoke(new MethodInvoker(delegate {
                                                               if (this.grid.ViewGrid.ValidateEditor()) {
                                                                   this.grid.ViewGrid.CloseEditor();
                                                                   this.NewRecord();
                                                                   this.grid.ViewGrid.FocusedColumn =
                                                                       this.grid.ViewGrid.VisibleColumns[0];
                                                                   this.grid.ViewGrid.ShowEditor();
                                                               }
                                                           }));
                    }
                }
                string key = e.KeyData.ToString();
                switch (key) {
                    case "Insert, Control":
                        this.NewRecord();
                        break;
                    case "Y, Control":
                        this.CopyRecord();
                        break;
                    case "K, Control":
                        this.RestoreRecord();
                        break;
                    case "Delete, Control":
                        this.DeleteRecord();
                        break;
                    case "S, Control":
                        this.UpdateRecord();
                        break;
                    case "E, Control":
                        this.grid.ExportToXLS();
                        break;
                    case "P, Control":
                        this.PrintRecord();
                        break;
                    case "I, Control":
                        this.grid.ViewGrid.ClearSelection();
                        this.grid.ShowFilterRow();
                        break;
                    case "R, Control":
                        this.RefreshDm();
                        break;
                    case "F4":
                        this.ProcessF4Key();
                        break;
                    default:
                        break;
                }
                this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.FocusedRowHandle);
                this.ConfigAction();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        protected virtual void ProcessF4Key() {
        }

        protected virtual void ConfigAction() {
            this.toolbar.NewEnable = this.AllowNew;
            this.toolbar.CopyEnable = this.AllowCopy;
            this.toolbar.DeleteEnable = this.AllowDelete;
            this.toolbar.SaveEnable = this.AllowSave;
            this.toolbar.UndoEnable = this.AllowUndo;
            this.toolbar.PrintEnable = this.AllowPrint;
            this.toolbar.FilterEnable = this.AllowFilter;
            this.toolbar.ExportExcelEnable = this.AllowExcel;
            if (this.grid.ViewGrid.IsMultiSelect) {
                if (this.grid.ViewGrid.GetSelectedRows() != null) {
                    #region toolbar

                    this.toolbar.CopyEnable = this.AllowCopy;
                    this.toolbar.DeleteEnable = this.AllowDelete;

                    #endregion

                    #region context menu

                    BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                    item.Enabled = this.AllowCopy;
                    item = this.contextMenu.LinksPersistInfo[3].Item;
                    item.Enabled = this.AllowDelete;
                    item = this.contextMenu.LinksPersistInfo[0].Item;
                    item.Enabled = this.AllowNew;

                    #endregion
                } else {
                    #region toolbar

                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = false;

                    #endregion

                    #region context menu

                    BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                    item.Enabled = false;
                    item = this.contextMenu.LinksPersistInfo[3].Item;
                    item.Enabled = false;

                    #endregion
                }
            } else {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    #region toolbar

                    this.toolbar.CopyEnable = this.AllowCopy;
                    this.toolbar.DeleteEnable = this.AllowDelete;

                    #endregion

                    #region context menu

                    BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                    item.Enabled = this.AllowCopy;
                    item = this.contextMenu.LinksPersistInfo[3].Item;
                    item.Enabled = this.AllowDelete;
                    item = this.contextMenu.LinksPersistInfo[0].Item;
                    item.Enabled = this.AllowNew;

                    #endregion
                } else {
                    #region toolbar

                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = false;

                    #endregion

                    #region context menu

                    BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                    item.Enabled = false;
                    item = this.contextMenu.LinksPersistInfo[3].Item;
                    item.Enabled = false;

                    #endregion
                }
            }
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.toolbar.SaveNewVisible = BarItemVisibility.Never;
        }

        #endregion 3: User Actions

        #region 4: Validation, Errors

        private void OnErrorGrid(FTSException ex) {
            this.grid.ViewGrid.ClearSelection();
            this.grid.ViewGrid.FocusedRowHandle = this.grid.ViewGrid.GetRowHandle(ex.RowPos);
            if ((ex.FieldName.Length != 0) &&
                (this.grid.ViewGrid.Columns.IndexOf(this.grid.ViewGrid.Columns[ex.FieldName]) >= 0)) {
                this.grid.ViewGrid.FocusedColumn = this.grid.ViewGrid.Columns[ex.FieldName];
                this.grid.ViewGrid.SetColumnError(this.grid.ViewGrid.FocusedColumn,
                                                  FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex));
            }
            this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.GetRowHandle(ex.RowPos));
            this.grid.ViewGrid.ShowEditor();
        }

        public virtual void OnError(FTSException ex) {
            this.OnErrorGrid(ex);
        }

        public virtual bool CellWarning(CurrentCellInfo cellinfo) {
            return true;
        }

        #endregion 4: Validation, Erros

        #region 5: Grid Misc events

        protected void ConfigGrid() {
            try{
                this.CheckSecurityBussiess(DataAction.EditAction);
            }catch{
                this.grid.ViewGrid.OptionsBehavior.Editable = false;
            }
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = this.mIsMultiSelect;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = this.mShowGroupPanel;
            this.grid.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.grid.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.grid.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            if (this.HasSumFields()) {
                this.grid.ViewGrid.OptionsView.ShowFooter = true;
            } else {
                this.grid.ViewGrid.OptionsView.ShowFooter = this.mShowTextFooter;
            }
            this.grid.ViewGrid.SelectionChanged += new SelectionChangedEventHandler(this.ViewGrid_SelectionChanged);
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            this.grid.ViewGrid.RowCellStyle += new RowCellStyleEventHandler(this.ViewGrid_RowCellStyle);
            this.grid.ViewGrid.CellValueChanged += new CellValueChangedEventHandler(this.ViewGrid_CellValueChanged);
            this.grid.ComboBoxClick += new ComboBoxClickEventHandler(this.grid_ComboBoxClick);
            this.grid.ProcessGridKey += new KeyEventHandler(this.grid_ProcessGridKey);
            this.grid.ViewGrid.ValidatingEditor +=
                new BaseContainerValidateEditorEventHandler(this.ViewGrid_ValidatingEditor);
            this.grid.TextBoxLookup += new TextBoxLookupEventHandler(this.grid_TextBoxLookup);
            this.grid.ValidateColumn += new ValidateColumnEventHandler(this.grid_ValidateColumn);
            this.grid.GridComboChange += new GridComboChangeEventHandler(this.grid_ComboChanged);
            this.grid.ButtonClick += new ButtonClickEventHandler(this.grid_ButtonClick);
            this.grid.ViewGrid.CustomDrawColumnHeader +=
                new ColumnHeaderCustomDrawEventHandler(this.ViewGrid_CustomDrawColumnHeader);
            this.grid.ViewGrid.CustomUnboundColumnData +=
                new CustomColumnDataEventHandler(this.ViewGrid_CustomUnboundColumnData);
            this.ConfigGridOther();
        }

        private void ViewGrid_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
            try {
                this.GridColumnHeaderCustomDraw(e);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid_ButtonClick(object sender, ButtonClickEventArgs e) {
            try {
                this.GridButtonClick((FTSDataGrid) sender, e.Button, e.Row, e.Col);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                this.ConfigAction();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            try {
                this.SetTextFooter();
                this.ConfigAction();
                this.GridChanged();
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                this.SetTextFooter();
                this.grid.ViewGrid.UpdateSummary();
                this.GridChanged();
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_RowCellStyle(object sender, RowCellStyleEventArgs e) {
            try {
                object val = this.grid.ViewGrid.GetRowCellValue(e.RowHandle, e.Column);
                CurrentCellInfo cellinfo = new CurrentCellInfo(val, e.RowHandle, e.Column);
                if (!this.CellWarning(cellinfo)) {
                    AppearanceHelper.Apply(e.Appearance, this.WarningColor);
                }
                this.GridRowCellStyle(sender, e);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            try {
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid_ComboChanged(object sender, GridComboChangeEventArgs e) {
            try {
                this.GridComboChanged(e.row, e.col, e.control.Properties.GetDataSourceRowByKeyValue(e.control.EditValue));
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            try {
                this.GridCustomUnboundColumnData((GridView) sender, e);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid_ComboBoxClick(object sender, ComboBoxClickEventArgs e) {
            try {
                this.grid.EndEdit();
                LookUpEdit edit = (LookUpEdit) sender;
                string tableName = (edit.Properties.DataSource as DataTable).TableName;
                Type type_frmdic = this.GetFrmDicEditDetail(tableName);
                if (type_frmdic != null) {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (FrmDataList), typeof (Boolean), typeof (Boolean),
                                                       typeof (Object), typeof (String)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null) {
                        throw new ArgumentException("Not Constructor");
                    }
                    if (e.ButtonsTag == "New") {
                        Object[] objArg = new object[6] {
                                                            this.mFTSMain, null, true, true, null,
                                                            edit.Tag == null ? string.Empty : edit.Tag.ToString()
                                                        };
                        FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                        edit.Properties.ShowPopupShadow = false;
                        if (frmdic.ShowDialog() == DialogResult.Yes) {
                            DataRow row = this.mDataObject.DataSet.Tables[tableName].NewRow();
                            foreach (DataColumn column in this.mDataObject.DataSet.Tables[tableName].Columns) {
                                row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                            }
                            this.mDataObject.DataSet.Tables[tableName].Rows.Add(row);
                            this.mDataObject.DataSet.Tables[tableName].AcceptChanges();
                            this.grid.ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                            edit.EditValue = row[edit.Properties.ValueMember];
                            this.grid.EndEdit();
                            this.grid.ViewGrid.RefreshData();
                        }
                        frmdic.Close();
                        edit.Properties.ShowPopupShadow = true;
                    } else {
                        if ((e.ButtonsTag == "Edit") && (edit.EditValue != null) &&
                            (this.grid.CurrentCellValue.ToString().Trim().Length != 0)) {
                            Object[] objArg = new object[6] {
                                                                this.mFTSMain, null, false, true, edit.EditValue,
                                                                edit.Tag == null ? string.Empty : edit.Tag.ToString()
                                                            };
                            FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                            BindingManagerBase bm = this.BindingContext[edit.Properties.DataSource];
                            edit.Properties.ShowPopupShadow = false;
                            if (frmdic.ShowDialog() == DialogResult.Yes) {
                                DataRow row =
                                    this.mDataObject.DataSet.Tables[tableName].Rows[UIFunctions.GetSourcePosition(bm)];
                                foreach (DataColumn column in this.mDataObject.DataSet.Tables[tableName].Columns) {
                                    row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                }
                                this.mDataObject.DataSet.Tables[tableName].AcceptChanges();
                                this.grid.ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                                edit.EditValue = row[edit.Properties.ValueMember];
                                this.grid.EndEdit();
                                this.grid.ViewGrid.RefreshData();
                            }
                            frmdic.Close();
                            edit.Properties.ShowPopupShadow = true;
                        }
                    }
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
            try {
                this.GridValidatingCell((GridView) sender, e);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid_TextBoxLookup(object sender, TextBoxLookupEventArgs e) {
            try {
                this.GridTextBoxLookup((FTSDataGrid) sender, e.control, e.row, e.col);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        public virtual void GridButtonClick(FTSDataGrid buttongrid, EditorButton button, int nrow, GridColumn ncol) {
        }

        public virtual void GridColumnHeaderCustomDraw(ColumnHeaderCustomDrawEventArgs e) {
        }

        public virtual void GridTextBoxLookup(FTSDataGrid sendgrid, TextEdit textbox, int nrow, GridColumn ncol) {
        }

        public virtual void GridValidatingCell(GridView gridview, BaseContainerValidateEditorEventArgs e) {
        }

        public virtual void GridCustomUnboundColumnData(GridView gridview, CustomColumnDataEventArgs e) {
        }

        public virtual void GridRowCellStyle(object sender, RowCellStyleEventArgs e){
        }

        public virtual void GridComboChanged(int nrow, GridColumn ncol, object row) {
        }

        private void grid_ValidateColumn(object sender, ColumnInfoEventArgs e) {
            this.ValidateColumn(sender, e);
        }

        public virtual void ValidateColumn(object sender, ColumnInfoEventArgs e) {
        }

        private void ViewGrid_ShowGridMenu(object sender, GridMenuEventArgs e) {
            try {
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if ((hitInfo.InRow)&&(this.mShowContextMenu)) {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    this.contextMenu.ShowPopup(this.barManager, Cursor.Position);
                }
                e.Allow = false;
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        public bool ProcessLookupColumnTree(FTSDataGrid paragrid, BaseEdit t, string tableName, string condition, int nrow,
                                        GridColumn ncol, string[] collist, string[] fieldlist)
        {
            bool rtn = false;
            if (this.mDataObject.DataSet.Tables[tableName] == null)
            {
                this.mFTSMain.TableManager.LoadTable(this.mDataObject.DataSet, tableName);
            }
            Type type_frmdic = this.GetFrmDicList(tableName);
            if (type_frmdic != null)
            {
                Type[] typeArray = new Type[6] {
                                                   typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                   typeof (string), typeof (bool)
                                               };
                ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                if (constructorInfoObj == null)
                {
                    throw new ArgumentException("Not Constructor");
                }
                Object[] objArg = new object[6] { this.mFTSMain, this.mDataObject.DataSet, tableName, condition, string.Empty, true };
                FrmDataTreeList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataTreeList;
                frmdic.ShowDialog();
                if (frmdic.DialogResult == DialogResult.OK)
                {
                    t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tableName)];
                    paragrid.SetValue(nrow, ncol, t.EditValue);
                    if (collist != null)
                    {
                        for (int i = 0; i < collist.Length; i++)
                        {
                            paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                        }
                    }
                    rtn = true;
                }
            }
            return rtn;
        }

        public bool ProcessLookupColumn(FTSDataGrid paragrid, BaseEdit t, string tableName, string condition, int nrow,
                                        GridColumn ncol, string[] collist, string[] fieldlist) {
            bool rtn = false;
            if (this.mDataObject.DataSet.Tables[tableName] == null) {
                this.mFTSMain.TableManager.LoadTable(this.mDataObject.DataSet, tableName);
            }
            Type type_frmdic = this.GetFrmDicList(tableName);
            if (type_frmdic != null) {
                Type[] typeArray = new Type[6] {
                                                   typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                   typeof (string), typeof (bool)
                                               };
                ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                if (constructorInfoObj == null) {
                    throw new ArgumentException("Not Constructor");
                }
                Object[] objArg = new object[6]
                                  {this.mFTSMain, this.mDataObject.DataSet, tableName, condition, string.Empty, true};
                FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                frmdic.ShowDialog();
                if (frmdic.DialogResult == DialogResult.OK) {
                    t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tableName)];
                    paragrid.SetValue(nrow, ncol, t.EditValue);
                    if (collist != null) {
                        for (int i = 0; i < collist.Length; i++) {
                            paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                        }
                    }
                    rtn = true;
                }
            }
            return rtn;
        }

        public void ProcessGridColumnTree(FTSDataGrid paragrid, BaseEdit t, string tableName, string condition, int nrow,
                                      GridColumn ncol, string[] collist, string[] fieldlist)
        {
            if (t.Text.Length == 0)
            {
                if (collist != null)
                {
                    for (int i = 0; i < collist.Length; i++)
                    {
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.String"))
                        {
                            paragrid.SetValue(nrow, collist[i], string.Empty);
                        }
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Decimal") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int16") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int32"))
                        {
                            paragrid.SetValue(nrow, collist[i], 0);
                        }
                    }
                }
                return;
            }
            DataTable dt = this.mDataObject.DataSet.Tables[tableName];
            if (dt == null)
            {
                dt = this.mFTSMain.TableManager.LoadTable(this.mDataObject.DataSet, tableName);
            }
            DataRow foundRow = dt.Rows.Find(t.Text);
            if (foundRow == null)
            {
                Type type_frmdic = this.GetFrmDicList(tableName);
                if (type_frmdic != null)
                {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                       typeof (string), typeof (bool)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null)
                    {
                        throw new ArgumentException("Not Constructor");
                    }
                    Object[] objArg = new object[6] { this.mFTSMain, this.mDataObject.DataSet, tableName, condition, t.Text, true };
                    FrmDataTreeList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataTreeList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK)
                    {
                        t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tableName)];
                        paragrid.SetValue(nrow, ncol, t.EditValue);
                        if (collist != null)
                        {
                            for (int i = 0; i < collist.Length; i++)
                            {
                                paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                            }
                        }
                    }
                    else
                    {
                        t.EditValue = string.Empty;
                        paragrid.SetValue(nrow, ncol, string.Empty);
                        if (collist != null)
                        {
                            for (int i = 0; i < collist.Length; i++)
                            {
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.String"))
                                {
                                    paragrid.SetValue(nrow, collist[i], string.Empty);
                                }
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Decimal") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int16") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int32"))
                                {
                                    paragrid.SetValue(nrow, collist[i], 0);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (collist != null)
                {
                    for (int i = 0; i < collist.Length; i++)
                    {
                        paragrid.SetValue(nrow, collist[i], foundRow[fieldlist[i]]);
                    }
                }
            }
        }

        public void ProcessGridColumn(FTSDataGrid paragrid, BaseEdit t, string tableName, string condition, int nrow,
                                      GridColumn ncol, string[] collist, string[] fieldlist) {
            if (t.Text.Length == 0) {
                if (collist != null) {
                    for (int i = 0; i < collist.Length; i++) {
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.String")) {
                            paragrid.SetValue(nrow, collist[i], string.Empty);
                        }
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Decimal") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int16") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int32")) {
                            paragrid.SetValue(nrow, collist[i], 0);
                        }
                    }
                }
                return;
            }
            DataTable dt = this.mDataObject.DataSet.Tables[tableName];
            if (dt == null) {
                dt = this.mFTSMain.TableManager.LoadTable(this.mDataObject.DataSet, tableName);
            }
            DataRow foundRow = dt.Rows.Find(t.Text);
            if (foundRow == null) {
                Type type_frmdic = this.GetFrmDicList(tableName);
                if (type_frmdic != null) {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                       typeof (string), typeof (bool)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null) {
                        throw new ArgumentException("Not Constructor");
                    }
                    Object[] objArg = new object[6]
                                      {this.mFTSMain, this.mDataObject.DataSet, tableName, condition, t.Text, true};
                    FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK) {
                        t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tableName)];
                        paragrid.SetValue(nrow, ncol, t.EditValue);
                        if (collist != null) {
                            for (int i = 0; i < collist.Length; i++) {
                                paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                            }
                        }
                    } else {
                        t.EditValue = string.Empty;
                        paragrid.SetValue(nrow, ncol, string.Empty);
                        if (collist != null) {
                            for (int i = 0; i < collist.Length; i++) {
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.String")) {
                                    paragrid.SetValue(nrow, collist[i], string.Empty);
                                }
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Decimal") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int16") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int32")) {
                                    paragrid.SetValue(nrow, collist[i], 0);
                                }
                            }
                        }
                    }
                }
            } else {
                if (collist != null) {
                    for (int i = 0; i < collist.Length; i++) {
                        paragrid.SetValue(nrow, collist[i], foundRow[fieldlist[i]]);
                    }
                }
            }
        }

        private void SetPositionComboBox() {
            if (this.grid.ViewGrid.FocusedColumn != null &&
                this.grid.ViewGrid.FocusedColumn.ColumnEdit is RepositoryItemLookUpEdit) {
                RepositoryItemLookUpEdit edit = (RepositoryItemLookUpEdit) this.grid.ViewGrid.FocusedColumn.ColumnEdit;
                BindingManagerBase bm = this.BindingContext[edit.DataSource];
                if (this.grid.CurrentCellValue.ToString().Trim().Length == 0) {
                    bm.Position = 0;
                } else {
                    int index = edit.GetDataSourceRowIndex(edit.ValueMember, this.grid.CurrentCellValue);
                    if (index > -1) {
                        int bmpos = UIFunctions.GetBindingManagerPosition(bm, index);
                        bm.Position = bmpos;
                    }
                }
            }
        }

        public virtual void GridChanged() {
        }

        public virtual void SetTextFooter() {
        }

        protected virtual void ConfigGridOther(){
        }
        #endregion 5: Grid Misc events

        #region 6: Enabled Skins

        //protected override bool GetAllowSkin()
        //{
        //    if (this.MdiParent != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return true;
        //        //return base.GetAllowSkin();
        //    }
        //}

        #endregion

        #region 7: Hand Code

        private BarManager barManager;
        private PopupMenu contextMenu;

        public virtual void CreateStatusBar() {
            BarStaticItem itemStatus = new BarStaticItem();
            Bar bar = new Bar();
            this.barManager = new BarManager();
            this.contextMenu = new PopupMenu();
            ((ISupportInitialize) (this.barManager)).BeginInit();
            ((ISupportInitialize) (this.contextMenu)).BeginInit();
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new Bar[] {bar});
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new BarItem[] {itemStatus});
            this.barManager.MaxItemId = 1;
            this.barManager.StatusBar = bar;
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
            //itemStatus.Caption =
            //    "Mới: Ctrl+Insert, Sao: Ctrl+Y, Lại: Ctrl+K, Xoá: Ctrl+Delete, Lưu: Ctrl+S, Lọc: Ctrl+I";
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Manager = this.barManager;
            ((ISupportInitialize) (this.barManager)).EndInit();
            ((ISupportInitialize) (this.contextMenu)).EndInit();
        }

        #endregion

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }

        private bool HasSumFields() {
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
                if (cinfo.IsSum) {
                    return true;
                }
            }
            return false;
        }

        #region 8: TreeList

        public virtual void BindTreeList() {
        }

        public virtual void ConfigTreeList() {
            if (this.mShowTreeList) {
                /*
                this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                */ 
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

        protected virtual void ImportExcel() {
            FrmImportExcel frmImportExcel = new FrmImportExcel(this.FTSMain, this.DataObject, null);
            frmImportExcel.ShowDialog();
        }
    }
}