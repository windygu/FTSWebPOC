#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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
using ItemClickEventArgs = DevExpress.XtraBars.ItemClickEventArgs;
using ItemClickEventHandler = DevExpress.XtraBars.ItemClickEventHandler;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmDataTreeEditList : FTSForm {
        private FTSMain mFTSMain;
        private ObjectBase mDataObject;
        private bool mShowTextFooter = true;

        public FrmDataTreeEditList() {
            this.InitializeComponent();
        }

        public FrmDataTreeEditList(FTSMain ftsMain) {
            this.mFTSMain = ftsMain;
            this.InitializeComponent();
            this.CreateStatusBar();
            //this.MdiParent = this.mFTSMain.MainForm;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.LoadData();
            this.BindTree();
            this.LoadContextMenu();
            this.ConfigAction();
            this.ShowInTaskbar = false;
            this.toolbar.LoadLayout(this.mFTSMain);
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

        public bool ShowTextFooter {
            get { return this.mShowTextFooter; }
            set { this.mShowTextFooter = value; }
        }

        public FTSTreeList Tree {
            get { return this.treelist; }
        }

        #region Initialization Methods

        public virtual void LoadData() {
        }

        public virtual void BindTree() {
        }

        public virtual void SetControls() {
        }

        #endregion Overriden

        #region 1: Data Processing Methods

        public virtual void EndEdit() {
            this.treelist.CloseEditor();
            this.treelist.EndCurrentEdit();
            this.mDataObject.EndEdit();
        }

        protected virtual ChangedStatus CheckChanged() {
            this.EndEdit();
            if (this.mDataObject.HasChanged()) {
                DialogResult dresult =
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoCancelMessage(this.mFTSMain.MsgManager.GetMessage("MSG_UPDATE_CHANGE"));
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
        }

        public virtual void NewRecord() {
            if (!this.AllowNew || !this.toolbar.NewEnable || !(this.toolbar.NewVisible == BarItemVisibility.Always)) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            this.EndEdit();
            DataRow row = this.mDataObject.AddNew();
            if (this.treelist.FocusedNode != null) {
                row[this.treelist.ParentFieldName] = this.treelist.FocusedNode.GetValue(this.treelist.KeyFieldName);
            } else {
                row[this.treelist.ParentFieldName] = 0;
            }
            row.EndEdit();
            BindingManagerBase bm = this.treelist.BindingContext[this.treelist.DataSource];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
        }

        public virtual void CheckSecurityBussiess(string dataaction)
        {
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }

        public virtual void CopyRecord() {
            if (!this.AllowNew || !this.AllowCopy || !this.toolbar.CopyEnable ||
                !(this.toolbar.CopyVisible == BarItemVisibility.Always)) {
                return;
            }
            if ((this.treelist.FocusedNode != null) && (!this.treelist.FocusedNode.HasChildren)) {
                this.CheckSecurityBussiess(DataAction.AddAction);
                this.EndEdit();
                DataRowView rowview = (DataRowView) this.treelist.GetDataRecordByNode(this.treelist.FocusedNode);
                this.mDataObject.CopyRecord(rowview.Row);
                BindingManagerBase bm = this.treelist.BindingContext[this.treelist.DataSource];
                if (bm.Count > 0) {
                    bm.Position = bm.Count - 1;
                }
            }
        }

        public virtual void UpdateRecord() {
            this.EndEdit();
            this.mDataObject.UpdateData();
        }

        public virtual void RestoreRecord() {
            this.EndEdit();
            this.mDataObject.Restore();
        }

        public virtual void DeleteRecord() {
            if (!this.AllowDelete || !this.toolbar.DeleteEnable ||
                !(this.toolbar.DeleteVisible == BarItemVisibility.Always)) {
                return;
            }
            if ((this.treelist.FocusedNode != null) && (!this.treelist.FocusedNode.HasChildren)) {
                this.CheckSecurityBussiess(DataAction.DeleteAction);
                this.EndEdit();
                TreeListNode nextNode = this.treelist.FocusedNode.NextNode;
                if (nextNode == null) {
                    nextNode = this.treelist.FocusedNode.PrevNode;
                }
                if (nextNode == null) {
                    nextNode = this.treelist.FocusedNode.ParentNode;
                }
                DataRowView rowview = (DataRowView) this.treelist.GetDataRecordByNode(this.treelist.FocusedNode);
                this.mDataObject.DeleteRow(rowview.Row);
                this.treelist.FocusedNode = nextNode;
            }
        }

        public virtual void PrintRecord() {
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

        protected virtual void LayoutTree() {
            foreach (TreeListColumn  c in this.treelist.Columns) {
                c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "TREELIST", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (TreeListColumn c in this.treelist.Columns) {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "TREELIST", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum) {
                    this.treelist.SetSummary(c, cinfo.SumType);
                }
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.treelist.SetFont();
            }
        }

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.LayoutTree();
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }

        protected virtual void SaveTreeLayout() {
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN && this.FTSMain.UserInfo.UserGroupID == "ADMIN") {
                foreach (TreeListColumn c in this.treelist.Columns) {
                    IRequire ir = c as IRequire;
                    bool isrequired = true;
                    int require = 0;
                    if (ir != null) {
                        require = ir.Require ? 1 : 0;
                        isrequired = ir.Require ? true : false;
                    }
                    string summarytype = string.Empty;
                    string summaryformat = string.Empty;
                    bool issummary = c.SummaryFooter == SummaryItemType.None ? false : true;
                    bool fixcolumn = c.Fixed == FixedStyle.Left ? true : false;
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
            this.SaveTreeLayout();
        }

        #endregion 2: Layout Methods

        #region 3: User actions

        private void LoadContextMenu() {
            this.treelist.TreeListMenuShow += new TreeMenuEventHandler(this.treelist_TreeListMenuShow);
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
            ((ISupportInitialize) (this.contextMenu)).BeginInit();
        }

        private void treelist_TreeListMenuShow(object sender, TreeMenuEventArgs e) {
            try {
                TreeList treelist = sender as TreeList;
                this.contextMenu.ShowPopup(this.barManager, e.MousePos);
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            }
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
                this.ConfigAction();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
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
                    case "ExportExcel":
                        this.treelist.ExportToXLS();
                        break;
                    case "Layout":
                        this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    case "Refresh":
                        this.RefreshDm();
                        break;
                    case "Close":
                        this.Close();
                        return;
                    default:
                        break;
                }
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

        protected void ConfigAction() {
            this.toolbar.NewEnable = this.AllowNew;
            this.toolbar.CopyEnable = this.AllowCopy;
            this.toolbar.DeleteEnable = this.AllowDelete;
            this.toolbar.SaveEnable = this.AllowSave;
            this.toolbar.UndoEnable = this.AllowUndo;
            this.toolbar.PrintEnable = this.AllowPrint;
            this.toolbar.FilterEnable = this.AllowFilter;
            this.toolbar.ExportExcelEnable = this.AllowExcel;
            if ((this.treelist.FocusedNode != null) && (!this.treelist.FocusedNode.HasChildren)) {
                #region toolbar

                if (this.treelist.FocusedNode.ParentNode != null) {
                    this.toolbar.CopyEnable = this.AllowCopy;
                } else {
                    this.toolbar.CopyEnable = false;
                }
                this.toolbar.DeleteEnable = this.AllowDelete;
                this.toolbar.NewEnable = this.AllowNew;

                #endregion

                #region context menu

                BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                if (this.treelist.FocusedNode.ParentNode != null) {
                    item.Enabled = this.AllowCopy;
                } else {
                    item.Enabled = false;
                }
                item = this.contextMenu.LinksPersistInfo[3].Item;
                item.Enabled = this.AllowDelete;
                item = this.contextMenu.LinksPersistInfo[0].Item;
                item.Enabled = this.AllowNew;

                #endregion
            } else {
                #region toolbar

                this.toolbar.CopyEnable = false;
                this.toolbar.DeleteEnable = false;
                if (this.treelist.FocusedNode == null) {
                    this.toolbar.NewEnable = false;
                }

                #endregion

                #region context menu

                BarItem item = this.contextMenu.LinksPersistInfo[1].Item;
                item.Enabled = false;
                item = this.contextMenu.LinksPersistInfo[3].Item;
                item.Enabled = false;
                item = this.contextMenu.LinksPersistInfo[0].Item;
                if (this.treelist.FocusedNode == null) {
                    item.Enabled = false;
                }

                #endregion
            }
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.toolbar.SaveNewVisible = BarItemVisibility.Never;
        }

        #endregion 3: User Actions

        #region 4: Validation, Errors

        private void OnErrorTree(FTSException ex) {
        }

        public virtual void OnError(FTSException ex) {
            this.OnErrorTree(ex);
        }

        public virtual bool CellWarning(CurrentCellInfo cellinfo) {
            return true;
        }

        #endregion 4: Validation, Erros

        #region 5: Grid Misc events

        protected void ConfigTree() {
            try{
                this.CheckSecurityBussiess(DataAction.EditAction);
            }
            catch{
                this.treelist.OptionsBehavior.Editable = false;
            }
            this.treelist.RootValue = 0;
            this.treelist.CollapseAll();
            if (this.HasSumFields()) {
                this.treelist.OptionsView.ShowSummaryFooter = true;
            } else {
                this.treelist.OptionsView.ShowSummaryFooter = this.mShowTextFooter;
            }
            this.treelist.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treelist_FocusedNodeChanged);
            this.treelist.CellValueChanged += new CellValueChangedEventHandler(this.treelist_CellValueChanged);
            this.treelist.ComboBoxClick += new ComboBoxClickEventHandler(this.treelist_ComboBoxClick);
            this.treelist.ValidatingEditor += new BaseContainerValidateEditorEventHandler(this.treelist_ValidatingEditor);
            this.treelist.TextBoxLookup += new TextBoxLookupEventHandler(this.treelist_TextBoxLookup);
            this.treelist.Validated += new EventHandler(this.treelist_Validated);
            this.treelist.TreeListComboChange += new TreeListComboChangeEventHandler(this.treelist_TreeListComboChange);
            this.treelist.ButtonClick += new ButtonClickEventHandler(this.treelist_ButtonClick);
        }

        private void treelist_ButtonClick(object sender, ButtonClickEventArgs e) {
            try {
                this.TreeListButtonClick(this.treelist, e.Button, e.Row, e.treeCol);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void treelist_TreeListComboChange(object sender, TreeListComboChangeEventArgs e) {
            try {
                this.TreeListComboChanged(e.row, e.treecol,
                                          e.control.Properties.GetDataSourceRowByKeyValue(e.control.EditValue));
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void treelist_Validated(object sender, EventArgs e) {
            this.ValidateColumn(sender, e);
        }

        private void treelist_TextBoxLookup(object sender, TextBoxLookupEventArgs e) {
            try {
                this.TreeListTextBoxLookup(this.treelist, e.control, e.row, e.treecol);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void treelist_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
            try {
                this.TreeListValidatingCell(this.treelist, e);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void treelist_ComboBoxClick(object sender, ComboBoxClickEventArgs e) {
            try {
                this.treelist.EndCurrentEdit();
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
                            this.treelist.FocusedNode.SetValue(this.treelist.FocusedColumn.FieldName,
                                                               row[edit.Properties.ValueMember]);
                            edit.EditValue = row[edit.Properties.ValueMember];
                            this.treelist.EndCurrentEdit();
                            this.treelist.RefreshDataSource();
                        }
                        frmdic.Close();
                        edit.Properties.ShowPopupShadow = true;
                    } else {
                        if ((e.ButtonsTag == "Edit") && (edit.EditValue != null) &&
                            (this.treelist.FocusedNode.GetValue(this.treelist.FocusedColumn.FieldName).ToString().Trim() !=
                             string.Empty)) {
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
                                this.treelist.FocusedNode.SetValue(this.treelist.FocusedColumn.FieldName,
                                                                   row[edit.Properties.ValueMember]);
                                edit.EditValue = row[edit.Properties.ValueMember];
                                this.treelist.EndCurrentEdit();
                                this.treelist.RefreshDataSource();
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

        private void treelist_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            try {
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void treelist_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            this.ConfigAction();
        }

        public virtual void TreeListButtonClick(FTSTreeList buttontreelist, EditorButton button, int nrow,
                                                TreeListColumn ncol) {
        }

        public virtual void TreeListTextBoxLookup(FTSTreeList sendtree, TextEdit textbox, int nrow,
                                                  TreeListColumn ntreecol) {
        }

        public virtual void TreeListValidatingCell(FTSTreeList treelist, BaseContainerValidateEditorEventArgs e) {
        }

        public virtual void TreeListComboChanged(int nrow, TreeListColumn ntreecol, object row) {
        }

        public virtual void ValidateColumn(object sender, EventArgs e) {
        }

        public bool ProcessLookupColumn(FTSTreeList paratree, BaseEdit t, string tableName, string condition,
                                        TreeListColumn ntreecol, string[] collist, string[] fieldlist) {
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
                    paratree.FocusedNode.SetValue(ntreecol.FieldName, t.EditValue);
                    if (collist != null) {
                        for (int i = 0; i < collist.Length; i++) {
                            paratree.FocusedNode.SetValue(collist[i], frmdic.RetRow[fieldlist[i]]);
                        }
                    }
                    rtn = true;
                }
            }
            return rtn;
        }

        public void ProcessGridColumn(FTSTreeList paratree, BaseEdit t, string tableName, string condition,
                                      TreeListColumn ntreecol, string[] collist, string[] fieldlist) {
            if (t.Text.Length == 0) {
                if (collist != null) {
                    for (int i = 0; i < collist.Length; i++) {
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.String")) {
                            paratree.FocusedNode.SetValue(collist[i], string.Empty);
                        }
                        if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Decimal") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int16") ||
                            this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int32")) {
                            paratree.FocusedNode.SetValue(collist[i], 0);
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
                        paratree.FocusedNode.SetValue(ntreecol.FieldName, t.EditValue);
                        if (collist != null) {
                            for (int i = 0; i < collist.Length; i++) {
                                paratree.FocusedNode.SetValue(collist[i], frmdic.RetRow[fieldlist[i]]);
                            }
                        }
                    } else {
                        t.EditValue = string.Empty;
                        paratree.FocusedNode.SetValue(ntreecol, string.Empty);
                        if (collist != null) {
                            for (int i = 0; i < collist.Length; i++) {
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.String")) {
                                    paratree.FocusedNode.SetValue(collist[i], string.Empty);
                                }
                                if (this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Decimal") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int16") ||
                                    this.mDataObject.DataSet.Tables[tableName].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int32")) {
                                    paratree.FocusedNode.SetValue(collist[i], 0);
                                }
                            }
                        }
                    }
                }
            } else {
                if (collist != null) {
                    for (int i = 0; i < collist.Length; i++) {
                        paratree.FocusedNode.SetValue(collist[i], foundRow[fieldlist[i]]);
                    }
                }
            }
        }

        private void SetPositionComboBox() {
            if (this.treelist.FocusedColumn.ColumnEdit is RepositoryItemLookUpEdit) {
                RepositoryItemLookUpEdit edit = (RepositoryItemLookUpEdit) this.treelist.FocusedColumn.ColumnEdit;
                BindingManagerBase bm = this.BindingContext[edit.DataSource];
                if (
                    this.treelist.FocusedNode.GetValue(this.treelist.FocusedColumn.FieldName).ToString().Trim().Length ==
                    0) {
                    bm.Position = 0;
                } else {
                    int index = edit.GetDataSourceRowIndex(edit.ValueMember,
                                                           this.treelist.FocusedNode.GetValue(
                                                               this.treelist.FocusedColumn.FieldName));
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

        #endregion 5: Grid Misc events

        #region 6: Enabled Skins      

        #endregion

        #region 7: Hand Code

        private BarManager barManager;
        private PopupMenu contextMenu;

        private void CreateStatusBar() {
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
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Manager = this.barManager;
            ((ISupportInitialize) (this.barManager)).EndInit();
            ((ISupportInitialize) (this.contextMenu)).EndInit();
        }

        #endregion

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.treelist, ftsmain, true);
        }

        private bool HasSumFields() {
            foreach (TreeListColumn c in this.treelist.Columns) {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "TREE", c.FieldName);
                if (cinfo.IsSum) {
                    return true;
                }
            }
            return false;
        }
    }
}