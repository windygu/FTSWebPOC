// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:51
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmBase3.cs
// Project Item Filename:     FrmBase3.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
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
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.ImportData;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ItemClickEventArgs = DevExpress.XtraBars.ItemClickEventArgs;
using ItemClickEventHandler = DevExpress.XtraBars.ItemClickEventHandler;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmBase2 : FTSForm {
        private FTSMain mFTSMain;
        private DataMode mMode = DataMode.READ;
        private ManagerBase mObjectManager;
        private Control mFocusControl;
        private string mTranId = string.Empty;
        private string mTranClass = string.Empty;
        private string mFormName = string.Empty;
        private bool mShowBottom = false;
        private bool mShowRight = false;
        private bool mShowExtTop = false;
        private FrmBase2Listing mFrmFind;
        private DefaultValuesForm defaultvaluesForm;
        public event RefreshListHandler RefreshList;
        private bool mShowContextMenu = true;
        private AppearanceDefault WarningColor = new AppearanceDefault(Color.White, Color.LightCoral, Color.Empty,
                                                                       Color.Red, LinearGradientMode.ForwardDiagonal);

        private object mOldCellValue = null;
        protected FrmTranPrint mFrmTranPrint = null;

        public FrmBase2() {
            this.InitializeComponent();
        }

        public FrmBase2(FTSMain ftsmain) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            //this.MdiParent = this.mFTSMain.MainForm;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.toolbar.LoadLayout(this.mFTSMain);
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public FrmBase2(FTSMain ftsmain, bool showdialog) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
                if(!showdialog)
                    this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
                    //this.MdiParent = this.mFTSMain.MainForm;
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.toolbar.LoadLayout(this.mFTSMain);
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public ManagerBase ObjectManager {
            get { return this.mObjectManager; }
            set { this.mObjectManager = value; }
        }

        public Control FocusControl {
            get { return this.mFocusControl; }
            set { this.mFocusControl = value; }
        }

        public string TranId {
            get { return this.mTranId; }
            set { this.mTranId = value; }
        }

        public string TranClass {
            get { return this.mTranClass; }
            set { this.mTranClass = value; }
        }

        public string FormName {
            get { return this.mFormName; }
            set { this.mFormName = value; }
        }

        public FrmBase2Listing FormFind {
            get { return this.mFrmFind; }
            set { this.mFrmFind = value; }
        }

        public DataMode Mode {
            get { return this.mMode; }
            set { this.mMode = value; }
        }

        public FTSEditForm2Toolbar ToolBar {
            get { return this.toolbar; }
        }

        public FTSDataGrid Grid {
            get { return this.grid; }
        }

        [DefaultValue(false)]
        public bool ShowExtTop {
            get { return this.mShowExtTop; }
            set {
                this.mShowExtTop = value;
                this.palExtTop.Visible = this.mShowExtTop;
            }
        }

        [DefaultValue(false)]
        public bool ShowBottom {
            get { return this.mShowBottom; }
            set {
                this.mShowBottom = value;
                this.groupBottom.Visible = this.mShowBottom;
            }
        }

        [DefaultValue(false)]
        public bool ShowRight
        {
            get { return this.mShowRight; }
            set
            {
                this.mShowRight = value;
                this.palRight.Visible = this.mShowRight;
            }
        }
        public object OldCellValue {
            get { return this.mOldCellValue; }
        }

        public PopupMenu GridContextMenu {
            get { return this.contextMenu; }
            set { this.contextMenu = value; }
        }

        [DefaultValue(true)]
        public bool ShowContextMenu
        {
            get { return this.mShowContextMenu; }
            set { this.mShowContextMenu = value; }
        }
        #region 1: Loading......

        public virtual void LoadData() {
        }

        public virtual void BindGrid() {
        }

        public virtual void BindHeaderControls() {
        }

        public virtual void SetControls() {
        }

        #endregion

        #region 2: Data Functions

        public virtual void ReLoadWithTranId(string newTranId) {
            this.SaveLayout(this.mFTSMain);
            this.mTranId = newTranId;
            this.Name = this.mFormName + "_" + this.mTranId;
            this.mObjectManager.TranId = newTranId;
            this.LoadLayout();
        }

        public virtual void EndEdit() {
            if (this.mFocusControl != null) {
                this.mFocusControl.Focus();
            }
            foreach (ObjectBase ob in this.mObjectManager.ObjectList) {
                BindingManagerBase bm = this.BindingContext[ob.DataSet, ob.TableName];
                bm.EndCurrentEdit();
            }
            this.grid.EndEdit();
            this.mObjectManager.EndEdit();
        }

        public virtual ChangedStatus CheckChanged() {
            this.EndEdit();
            this.mObjectManager.RemoveEmptyRows();
            if (this.Mode == DataMode.READ) {
                this.RestoreRecord();
                return ChangedStatus.NONE;
            }
            if (this.mObjectManager.HasChanged()) {
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

        public virtual void CheckSecurityBussiess(string dataaction) {
            this.FTSMain.SecurityManager.CheckSecurity(this.ObjectManager.FTSFunction, dataaction);
        }

        public virtual void NewRecord() {
            if (!this.toolbar.NewEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mObjectManager.AddNewData();
                this.grid.BindData();
                if (this.grid.DataSource != null) {
                    BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
                    if (bm.Count > 0) {
                        bm.Position = bm.Count - 1;
                    }
                    this.grid.Focus();
                    this.grid.SelectRow();
                }
                this.mMode = DataMode.NEW;
                this.UpdateInfo();
                this.grid.ViewGrid.FocusedColumn = this.grid.ViewGrid.VisibleColumns[0];
                this.mFocusControl.Focus();
            }
        }

        public virtual void Deposit()
        { }

        public virtual void CheckIn()
        { }

        public virtual void EditRecord() {
            if (!this.toolbar.EditEnable) {
                return;
            }
            if (this.mMode == DataMode.READ) {
                this.CheckSecurityBussiess(DataAction.EditAction);
                /*
                this.FTSMain.SecurityManager.CheckSecurity(this.ObjectManager.RoleId, DataAction.EditAction,
                                                           this.ObjectManager.GetOrganizationID());
                */ 
                this.ObjectManager.CheckLock();
                this.mMode = DataMode.EDIT;
            }
            this.UpdateInfo();
            this.mFocusControl.Focus();
        }

        public virtual void CopyRecord() {
            if (!this.toolbar.CopyEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mMode = DataMode.NEW;
                this.mObjectManager.CopyRecord();
                this.UpdateInfo();
                this.mFocusControl.Focus();
            }
        }

        public virtual void DeleteRecord() {
            if (!this.toolbar.DeleteEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.DeleteAction);
            if (FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_DELETE_TRANSACTION_CONFIRM")) ==
                DialogResult.Yes) {
                this.RestoreRecord();
                this.mMode = DataMode.READ;
                object prkeytran = null;
                if (this.mObjectManager.ObjectList[0].DataTable.Rows.Count > 0) {
                    prkeytran =
                        this.mObjectManager.ObjectList[0].DataTable.Rows[0][this.mObjectManager.ObjectList[0].IdField];
                    this.mObjectManager.DeleteData();
                }
                if (this.RefreshList != null) {
                    RefreshListEventArgs args = new RefreshListEventArgs(null, prkeytran, TranActions.DELETE,
                                                                         this.TranId);
                    this.RefreshList(null, args);
                }
                this.mMode = DataMode.NONE;
                this.UpdateInfo();
            }
        }

        public virtual void UpdateRecord() {
            if (!this.toolbar.SaveEnable) {
                return;
            }
            this.EndEdit();
            this.ObjectManager.RemoveEmptyRows();
            this.CheckFormRequire(this.groupHeader, this.mObjectManager.ObjectList[0].TableName);
            this.CheckFormRequire(this.groupBottom, this.mObjectManager.ObjectList[0].TableName);
            this.CheckGridRequire(this.grid, this.mObjectManager.ObjectList[1].TableName);
            this.mObjectManager.UpdateData();
            if (this.RefreshList != null) {
                RefreshListEventArgs args = null;
                switch (this.mMode) {
                    case DataMode.EDIT:
                        args = new RefreshListEventArgs(this.mObjectManager,
                                                        this.ObjectManager.ObjectList[0].DataTable.Rows[0][
                                                            this.mObjectManager.ObjectList[0].IdField], TranActions.EDIT,
                                                        this.TranId);
                        break;
                    case DataMode.NEW:
                        args = new RefreshListEventArgs(this.mObjectManager,
                                                        this.ObjectManager.ObjectList[0].DataTable.Rows[0][
                                                            this.mObjectManager.ObjectList[0].IdField], TranActions.NEW,
                                                        this.TranId);
                        break;
                    default:
                        break;
                }
                this.RefreshList(null, args);
            }
            foreach (string msg in this.FTSMain.MessageList) {
                FTSMessageBox.ShowInfoMessage(msg);
            }
            this.FTSMain.MessageList.Clear();
            this.mMode = DataMode.READ;
            this.UpdateInfo();
        }

        public virtual void RestoreRecord() {
            if (!this.toolbar.UndoEnable) {
                return;
            }
            this.EndEdit();
            this.mMode = DataMode.READ;
            this.grid.BeginInit();
            this.mObjectManager.RestoreData();
            this.grid.EndInit();
            this.grid.ViewGrid.ClearColumnErrors();
            this.UpdateInfo();
        }

        public virtual void RefreshDm() {
            this.mObjectManager.RefreshDm();
        }

        public virtual void PrintRecord() {
        }

        public virtual void PrintRecordPreview() {
        }

        public virtual void FindRecord() {
            if (!this.toolbar.OpenEnable) {
                return;
            }
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.LoadFormFind();
                this.mMode = DataMode.READ;
                this.UpdateInfo();
            }
        }

        public virtual void FirstRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mMode = DataMode.READ;
                this.mObjectManager.FirstRecord();
                this.UpdateInfo();
            }
        }

        public virtual void PreviousRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mMode = DataMode.READ;
                this.mObjectManager.PreviousRecord();
                this.UpdateInfo();
            }
        }

        public virtual void NextRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mMode = DataMode.READ;
                this.mObjectManager.NextRecord();
                this.UpdateInfo();
            }
        }

        public virtual void LastRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mMode = DataMode.READ;
                this.mObjectManager.LastRecord();
                this.UpdateInfo();
            }
        }

        public virtual void LoadFormFind() {
        }

        public virtual DataRow NewDetail() {
            if (!this.toolbar.SaveEnable) {
                return null;
            }
            this.EndEdit();
            DataRow row = this.mObjectManager.AddNewDetail(1);
            this.grid.BindData();
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
            this.grid.ViewGrid.FocusedColumn = this.grid.ViewGrid.VisibleColumns[0];
            this.grid.Focus();
            this.grid.SelectRow();
            return row;
        }

        public virtual DataRow InsertDetail() {
            if (!this.toolbar.SaveEnable) {
                return null;
            }
            this.EndEdit();
            int pos = UIFunctions.GetSourcePosition(this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember]);
            DataRow row = this.mObjectManager.InsertDetail(1, pos);
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            this.grid.Focus();
            this.grid.SelectRow();
            return row;
        }

        public virtual void CopyDetail() {
            if (!this.toolbar.SaveEnable) {
                return;
            }
            this.EndEdit();
            this.mObjectManager.CopyDetail(1,
                                           UIFunctions.GetSourcePosition(
                                               this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember]));
            this.grid.BindData();
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
            this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            this.grid.Focus();
            this.grid.SelectRow();
        }

        public virtual void DeleteDetail() {
            if (!this.toolbar.SaveEnable) {
                return;
            }
            this.EndEdit();
            int pos = UIFunctions.GetSourcePosition(this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember]);
            if (pos >= 0) {
                this.grid.BeginInit();
                this.mObjectManager.DeleteDetail(1, pos);
                this.grid.EndInit();
            }
            this.grid.Focus();
        }

        #endregion

        #region 3: User Actions

        protected override void OnClosing(CancelEventArgs e) {
            try {
                this.OnClose = true;
                if (this.CheckChanged() == ChangedStatus.CANCEL) {
                    e.Cancel = true;
                    this.OnClose = false;
                }
            } catch (FTSException ex) {
                e.Cancel = true;
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            }
            try {
                if (!e.Cancel) {
                    this.ObjectManager.Dispose();
                    if (this.mFrmFind != null) {
                        this.mFrmFind.Close();
                    }
                    if (this.WindowState != FormWindowState.Normal) {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.SaveLayout(this.mFTSMain);
                    this.DestroyCustomization();
                    this.DestroyDefaultValues();
                }
            } catch (Exception) {
            }
        }

        protected void LoadContextMenu() {
            this.grid.ViewGrid.ShowGridMenu += new GridMenuEventHandler(this.ViewGrid_ShowGridMenu);
            this.barManager.Images = this.toolbar.ImageList;
            ((ISupportInitialize) (this.GridContextMenu)).BeginInit();
            BarButtonItem item = new BarButtonItem();
            item.Name = "BUTTON_NEW";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_NEW", "STRING").ToString().
                    Trim();
            item.ImageIndex = 1;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.GridContextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_COPY";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_COPY", "STRING").ToString()
                    .Trim();
            item.ImageIndex = 4;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.GridContextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_INSERT";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_INSERT", "STRING").ToString
                    ().Trim();
            item.ImageIndex = 14;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.GridContextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            item = new BarButtonItem();
            item.Name = "BUTTON_DELETE";
            item.Caption =
                this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_DELETE", "STRING").ToString
                    ().Trim();
            item.ImageIndex = 5;
            item.ItemClick += new ItemClickEventHandler(this.ContextMenuCommands);
            this.GridContextMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            this.barManager.Items.Add(item);
            ((ISupportInitialize) (this.GridContextMenu)).BeginInit();
        }

        private void ContextMenuCommands(object sender, ItemClickEventArgs e) {
            try {
                BarButtonItem item = (BarButtonItem) e.Item;
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_NEW", "STRING").
                        ToString().Trim()) {
                    this.NewDetail();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_DELETE", "STRING").
                        ToString().Trim()) {
                    this.DeleteDetail();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_COPY", "STRING").
                        ToString().Trim()) {
                    this.CopyDetail();
                }
                if (item.Caption ==
                    this.mFTSMain.FormManager.GetObjectProperty("FRMBASE2", "GRID_MENU", "BUTTON_INSERT", "STRING").
                        ToString().Trim()) {
                    this.InsertDetail();
                }
                this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.FocusedRowHandle);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void toolbar_ItemClick(object sender, Controls.ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "Convert":
                        this.ConvertTransaction();
                        break;
                    case "BulkConvert":
                        this.BulkConvertTransaction();
                        break;
                    case "New":
                        this.NewRecord();
                        break;
                    case "Open":
                        this.FindRecord();
                        break;
                    case "Copy":
                        this.CopyRecord();
                        break;
                    case "Save":
                        this.UpdateRecord();
                        break;
                    case "Edit":
                        this.EditRecord();
                        break;
                    case "Delete":
                        this.DeleteRecord();
                        break;
                    case "Print":
                        this.CheckSecurityBussiess(DataAction.PrintAction);
                        this.PrintRecord();
                        break;
                    case "Undo":
                        this.RestoreRecord();
                        break;
                    case "Next":
                        this.NextRecord();
                        break;
                    case "Previous":
                        this.PreviousRecord();
                        break;
                    case "Refresh":
                        this.RefreshDm();
                        break;
                    case "Layout":
                        this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    case "Config":
                        this.ShowConfigForm();
                        break;
                    case "Calculation":
                        this.ShowCalculationForm();
                        break;
                    case "Temp":
                        this.ShowTempForm();
                        break;
                    case "Default":
                        this.FormDefaultValues(new Point(-10000, -10000));
                        break;
                    case "Close":
                        this.Close();
                        break;
                    case "Option":
                        this.ShowOptionForm();
                        break;
                    case "Deposit":
                        this.Deposit();
                        break;
                    case "Check_In":
                        this.CheckIn();
                        break;
                    case "ImportExcel":
                        FrmImportExcel frmImportExcel = new FrmImportExcel(this.FTSMain, null, this.ObjectManager);
                        frmImportExcel.ShowDialog();
                        break;
                    
                    default:
                        break;
                }
                foreach (string msg in this.FTSMain.MessageList) {
                    FTSMessageBox.ShowInfoMessage(msg);
                }
                this.FTSMain.MessageList.Clear();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            } finally {
                ExceptionManager.ProcessMessage(this.mFTSMain);
            }
        }

        private void FormDefaultValues(Point showpoint) {
            this.DestroyDefaultValues();
            this.defaultvaluesForm = this.CreateDefaultValuesForm();
            this.AddOwnedForm(this.defaultvaluesForm);
            this.defaultvaluesForm.ShowDefaultValues(showpoint);
        }

        protected virtual DefaultValuesForm CreateDefaultValuesForm()
        {
            return new DefaultValuesForm(this, this.mFTSMain, this.ObjectManager.ObjectList[0].TableName, this.mTranId, new System.Collections.Hashtable());
        }

        protected void DestroyDefaultValues() {
            if (this.defaultvaluesForm != null) {
                this.defaultvaluesForm.Dispose();
                this.defaultvaluesForm = null;
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
                                                                   this.NewDetail();
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
                        this.NewDetail();
                        break;
                    case "I, Control":
                        this.InsertDetail();
                        break;
                    case "O, Control":
                        this.CopyDetail();
                        break;
                    case "Delete, Control":
                        this.DeleteDetail();
                        break;
                    case "F4":
                        this.ProcessF4Key();
                        break;
                    default:
                        this.ProcessDialogKey(e.KeyData);
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            } finally {
                ExceptionManager.ProcessMessage(this.mFTSMain);
            }
        }

        protected virtual void ProcessF4Key() {
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            try {
                string key = keyData.ToString();
                switch (key) {
                    case "N, Control":
                        this.NewRecord();
                        break;
                    case "Y, Control":
                        this.CopyRecord();
                        break;
                    case "K, Control":
                        this.RestoreRecord();
                        break;
                    case "D, Control":
                        this.DeleteRecord();
                        break;
                    case "S, Control":
                        this.UpdateRecord();
                        break;
                    case "P, Control":
                        this.PrintRecord();
                        break;
                    case "L, Control":
                        this.PrintRecordPreview();
                        break;
                    case "R, Control":
                        this.RefreshDm();
                        break;
                    case "F, Control":
                        this.FindRecord();
                        break;
                    case "E, Control":
                        this.EditRecord();
                        break;
                    case "F4":
                        this.ProcessF4Key();
                        break;
                    default:
                        return base.ProcessDialogKey(keyData);
                }
                foreach (string msg in this.FTSMain.MessageList) {
                    FTSMessageBox.ShowInfoMessage(msg);
                }
                this.FTSMain.MessageList.Clear();
                return true;
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
                return true;
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
                return true;
            } finally {
                ExceptionManager.ProcessMessage(this.mFTSMain);
            }
        }

        #endregion 3: User Actions

        #region 4: Layout Methods

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);
            this.SetProductVersion();
        }

        public override void LoadLayout(FTSMain ftsmain) {
            this.Name = this.Name.ToUpper();
            base.LoadLayout(ftsmain);
            this.LayoutGrid();
            this.ConfigForm();
            this.SetProductVersion();
        }

        public override void SaveLayout(FTSMain ftsmain) {
            base.SaveLayout(ftsmain);
            this.SaveGridLayout();
        }

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
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.grid.SetFont();
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
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype) {
                        this.mFTSMain.GridManager.UpdateConfig(this.Name, "GRID", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }
            }
        }

        #endregion 2: Layout Methods

        #region 5: Info functions

        public virtual void UpdateInfo() {
            if (this.mObjectManager.ObjectList[0].DataTable.Rows.Count == 0) {
                this.mMode = DataMode.NONE;
            }
            switch (this.mMode) {
                case DataMode.NONE:
                    this.palExtTop.Enabled = false;
                    this.groupHeader.Enabled = false;
                    this.groupBottom.Enabled = false;
                    this.palRight.Enabled = false;
                    this.grid.ViewGrid.OptionsBehavior.Editable = false;
                    this.toolbar.NewEnable = true;
                    this.toolbar.OpenEnable = true;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = false;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = false;
                    this.toolbar.SaveEnable = false;
                    this.toolbar.PrintEnable = false;
                    this.toolbar.DepositEnable = false;
                    this.toolbar.CheckInEnable = false;
                    for (int i = 0; i < this.GridContextMenu.LinksPersistInfo.Count; i++) {
                        this.GridContextMenu.LinksPersistInfo[i].Item.Enabled = false;
                    }
                    break;
                case DataMode.READ:
                    this.palExtTop.Enabled = false;
                    this.groupHeader.Enabled = false;
                    this.groupBottom.Enabled = false;
                    this.palRight.Enabled = false;
                    this.grid.ViewGrid.OptionsBehavior.Editable = false;
                    this.toolbar.NewEnable = true;
                    this.toolbar.OpenEnable = true;
                    this.toolbar.EditEnable = true;
                    this.toolbar.CopyEnable = true;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = false;
                    this.toolbar.SaveEnable = false;
                    this.toolbar.PrintEnable = true;
                    this.toolbar.DepositEnable = true;
                    this.toolbar.CheckInEnable = true;
                    for (int i = 0; i < this.GridContextMenu.LinksPersistInfo.Count; i++) {
                        this.GridContextMenu.LinksPersistInfo[i].Item.Enabled = false;
                    }
                    break;
                case DataMode.NEW:
                    this.palExtTop.Enabled = true;
                    this.groupHeader.Enabled = true;
                    this.groupBottom.Enabled = true;
                    this.palRight.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = false;
                    this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = false;
                    this.toolbar.DepositEnable = false;
                    this.toolbar.CheckInEnable = false;
                    for (int i = 0; i < this.GridContextMenu.LinksPersistInfo.Count; i++) {
                        this.GridContextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                case DataMode.EDIT:
                    this.palExtTop.Enabled = true;
                    this.groupHeader.Enabled = true;
                    this.groupBottom.Enabled = true;
                    this.palRight.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = false;
                    this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = false;
                    this.toolbar.DepositEnable = false;
                    this.toolbar.CheckInEnable = false;
                    for (int i = 0; i < this.GridContextMenu.LinksPersistInfo.Count; i++) {
                        this.GridContextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                case DataMode.AUTO:
                    this.palExtTop.Enabled = true;
                    this.groupHeader.Enabled = true;
                    this.groupBottom.Enabled = true;
                    this.palRight.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = true;
                    this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = true;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = true;
                    this.toolbar.DepositEnable = true;
                    this.toolbar.CheckInEnable = true;
                    for (int i = 0; i < this.GridContextMenu.LinksPersistInfo.Count; i++) {
                        this.GridContextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
            this.UpdateBottom();
        }

        private void OnErrorForm(Control control, FTSException ex) {
            foreach (Control c in control.Controls) {
                if (c is FTSTextCom) {
                    Control ctrl = ((FTSTextCom) c).Textbox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSComboCom) {
                    Control ctrl = ((FTSComboCom) c).ComboBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((LookUpEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((LookUpEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSSingleComboCom) {
                    Control ctrl = ((FTSSingleComboCom) c).ComboBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((ComboBoxEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSDateCom) {
                    Control ctrl = ((FTSDateCom) c).DateTime;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((DateEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((DateEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom) {
                    Control ctrl = ((FTSNumericCom) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSReadOnlyNumericCom) {
                    Control ctrl = ((FTSReadOnlyNumericCom) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom2) {
                    Control ctrl = ((FTSNumericCom2) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSCalculatorCom) {
                    Control ctrl = ((FTSCalculatorCom) c).Calculator;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((CalcEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((CalcEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNameIDCom) {
                    Control ctrl = ((FTSNameIDCom) c).txtID;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSVatCom) {
                    Control ctrl = ((FTSVatCom) c).txtID;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSPercentCom) {
                    Control ctrl = ((FTSPercentCom) c).txtPercent;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSMemoCom) {
                    Control ctrl = ((FTSMemoCom) c).Memo;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((MemoEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((MemoEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSPictureCom) {
                    Control ctrl = ((FTSPictureCom) c).Picture;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((PictureEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            ((PictureEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSShadowPanel) {
                    this.OnErrorForm(c, ex);
                } else if (c is FTSGroupBox) {
                    this.OnErrorForm(c, ex);
                }
            }
        }

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
            if (ex.TableName == this.mObjectManager.ObjectList[0].TableName) {
                this.OnErrorForm(this.groupHeader, ex);
            }
            if (ex.TableName == this.mObjectManager.ObjectList[1].TableName) {
                this.OnErrorGrid(ex);
            }
        }

        public virtual void UpdateBottom() {
        }

        #endregion

        #region 6: Grid Misc events

        protected void ConfigGrid() {
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid.ViewGrid.OptionsView.ShowFooter = true;
            this.grid.AllowSortColumns = false;
            if (this.grid.ViewGrid.Columns["LIST_ORDER"] != null) {
                this.grid.ViewGrid.SortInfo.Add(this.grid.ViewGrid.Columns["LIST_ORDER"], ColumnSortOrder.Ascending);
            }
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            this.grid.ViewGrid.RowCellStyle += new RowCellStyleEventHandler(this.ViewGrid_RowCellStyle);
            this.grid.ViewGrid.CellValueChanged += new CellValueChangedEventHandler(this.ViewGrid_CellValueChanged);
            this.grid.ComboBoxClick += new ComboBoxClickEventHandler(this.grid_ComboBoxClick);
            this.grid.ProcessGridKey += new KeyEventHandler(this.grid_ProcessGridKey);
            this.grid.ValidateColumn += new ValidateColumnEventHandler(this.grid_ValidateColumn);
            this.grid.ViewGrid.ValidatingEditor +=
                new BaseContainerValidateEditorEventHandler(this.ViewGrid_ValidatingEditor);
            this.grid.NumbericValueChanging += new NumbericValueChangingEventHandler(this.grid_NumbericValueChanging);
            this.grid.TextBoxLookup += new TextBoxLookupEventHandler(this.grid_TextBoxLookup);
            this.grid.GridComboChange += new GridComboChangeEventHandler(this.grid_ComboChanged);
            this.grid.ButtonClick += new ButtonClickEventHandler(this.grid_ButtonClick);
            this.grid.CheckBoxChanged+=new CheckBoxChangedEventHandler(grid_CheckBoxChanged);
            this.grid.ViewGrid.CustomUnboundColumnData += new CustomColumnDataEventHandler(ViewGrid_CustomUnboundColumnData);
            this.ConfigGridOther();
        }
        private void ViewGrid_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                this.GridCustomUnboundColumnData((GridView)sender, e);
            }
            catch (FTSException ex)
            {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            }
            catch (Exception ex1)
            {
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
        private void grid_CheckBoxChanged(object sender, GridCheckBoxChangeEventArgs e)
        {
            try
            {
                this.GridCheckBoxChanged((FTSDataGrid)sender, e);
            }
            catch (FTSException ex){
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
            catch (Exception ex1){
                ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }
        private void grid_NumbericValueChanging(object sender, GridNumbericValueChangingEventArgs e) {
            try {
                this.GridNumberValidating((FTSDataGrid) sender, e);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            try {
                if(this.grid.ViewGrid.FocusedColumn!=null)
                    this.mOldCellValue = this.grid.GetValue(e.FocusedRowHandle,this.grid.ViewGrid.FocusedColumn.VisibleIndex);
                this.SetTextFooter();
                this.GridChanged();
                //this.RemoveRow(e.PrevFocusedRowHandle);
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                if(this.grid.ViewGrid.FocusedColumn!=null)
                    this.mOldCellValue = this.grid.GetValue(this.grid.ViewGrid.FocusedRowHandle,e.FocusedColumn.VisibleIndex);
                this.SetTextFooter();
                this.grid.ViewGrid.UpdateSummary();
                this.GridChanged();
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
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
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            try {
                this.SetPositionComboBox();
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid_ComboBoxClick(object sender, ComboBoxClickEventArgs e) {
            try {
                this.grid.EndEdit();
                LookUpEdit edit = (LookUpEdit) sender;
                string tableName = string.Empty;
                DataTable dt = edit.Properties.DataSource as DataTable;
                if (dt != null) {
                    tableName = dt.TableName;
                } else {
                    DataView dv = edit.Properties.DataSource as DataView;
                    if (dv != null) {
                        tableName = dv.Table.TableName;
                    }
                }
                Type type_frmdic = this.GetFrmDicEditDetail(tableName);
                if (type_frmdic != null) {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (FrmDataList), typeof (Boolean), typeof (Boolean),
                                                       typeof (Object), typeof (string)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null) {
                        throw new ArgumentException("Not Constructor");
                    }
                    if (e.ButtonsTag == "New") {
                        Object[] objArg = new object[6]
                                          {this.mFTSMain, null, true, true, null, edit.Properties.Tag.ToString()};
                        FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                        edit.Properties.ShowPopupShadow = false;
                        if (frmdic != null) {
                            if (frmdic.ShowDialog() == DialogResult.Yes) {
                                DataRow row = this.mObjectManager.GetDm(tableName).NewRow();
                                foreach (DataColumn column in this.mObjectManager.GetDm(tableName).Columns) {
                                    row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                }
                                this.mObjectManager.GetDm(tableName).Rows.Add(row);
                                this.mObjectManager.GetDm(tableName).AcceptChanges();
                                this.grid.ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                                edit.EditValue = row[edit.Properties.ValueMember];
                                if (edit.Text.Trim() == string.Empty) {
                                    this.grid.SetValue(this.grid.ViewGrid.FocusedRowHandle,
                                                                    e.ColumnName, string.Empty);
                                }
                                this.grid.EndEdit();
                                this.grid.ViewGrid.RefreshData();
                            }
                            frmdic.Close();
                        }
                        edit.Properties.ShowPopupShadow = true;
                    } else {
                        if ((e.ButtonsTag == "Edit") && (edit.EditValue != null) &&
                            (this.grid.CurrentCellValue.ToString().Trim().Length != 0)) {
                            Object[] objArg = new object[6] {
                                                                this.mFTSMain, null, false, true, edit.EditValue,
                                                                edit.Properties.Tag.ToString()
                                                            };
                            FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                            BindingManagerBase bm = this.BindingContext[edit.Properties.DataSource];
                            edit.Properties.ShowPopupShadow = false;
                            if (frmdic != null) {
                                if (frmdic.ShowDialog() == DialogResult.Yes) {
                                    DataRow row =
                                        this.mObjectManager.GetDm(tableName).Rows[
                                            UIFunctions.GetSourcePosition(bm)];
                                    if (edit.Properties.DataSource is DataView) {
                                        row = this.mObjectManager.GetDm(tableName).Rows.Find(edit.EditValue);
                                    }
                                    foreach (DataColumn column in this.mObjectManager.GetDm(tableName).Columns) {
                                        row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                    }
                                    this.mObjectManager.GetDm(tableName).AcceptChanges();
                                    this.grid.ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                                    edit.EditValue = row[edit.Properties.ValueMember];
                                    this.grid.EndEdit();
                                    this.grid.ViewGrid.RefreshData();
                                }
                                frmdic.Close();
                            }
                            edit.Properties.ShowPopupShadow = true;
                        }
                    }
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
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

        public virtual void GridTextBoxLookup(FTSDataGrid lookupgrid, TextEdit textbox, int nrow, GridColumn ncol) {
        }

        public virtual void GridValidatingCell(GridView gridview, BaseContainerValidateEditorEventArgs e) {
        }

        public virtual void GridNumberValidating(FTSDataGrid numbericgrid, GridNumbericValueChangingEventArgs e) {
        }

        public virtual void GridRowCellStyle(object sender, RowCellStyleEventArgs e) {
        }
        public virtual void GridCheckBoxChanged(FTSDataGrid checkgrid, GridCheckBoxChangeEventArgs e)
        {
        }
        private void grid_ValidateColumn(object sender, ColumnInfoEventArgs e) {
            try {
                this.ValidateColumn(sender, e);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        public virtual void ValidateColumn(object sender, ColumnInfoEventArgs e) {
        }

        public void ProcessGridColumn(FTSDataGrid paragrid, BaseEdit t, string tablename, string condition, int nrow,
                                      GridColumn ncol, string[] collist, string[] fieldlist) {
            if (t.Text.Length == 0) {
                if (collist != null) {
                    for (int i = 0; i < collist.Length; i++) {
                        if (this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.String")) {
                            paragrid.SetValue(nrow, collist[i], string.Empty);
                        }
                        if (this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Decimal") ||
                            this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int16") ||
                            this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int32")) {
                            paragrid.SetValue(nrow, collist[i], 0);
                        }
                    }
                }
                return;
            }
            DataTable dt = this.mObjectManager.GetDm(tablename);
            if (dt == null) {
                this.mObjectManager.LoadDm(tablename);
                dt = this.mObjectManager.GetDm(tablename);
                if (dt == null) {
                    dt = this.FTSMain.TableManager.LoadTable(this.mObjectManager.DataSet, tablename);
                }
            }
            if (dt == null) {
                return;
            }
            DataRow foundRow = dt.Rows.Find(t.Text);
            if (foundRow == null) {
                Type type_frmdic = this.GetFrmDicList(tablename);
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
                                      {this.mFTSMain, this.mObjectManager.DataSet, tablename, condition, t.Text, true};
                    FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK) {
                        t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tablename)];
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
                                if (this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.String")) {
                                    paragrid.SetValue(nrow, collist[i], string.Empty);
                                }
                                if (this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Decimal") ||
                                    this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int16") ||
                                    this.mObjectManager.GetDm(tablename).Columns[fieldlist[i]].DataType ==
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

        public virtual bool ProcessLookupColumn(FTSDataGrid paragrid, BaseEdit t, string tablename, string condition, int nrow,
                                        GridColumn ncol, string[] collist, string[] fieldlist) {
            bool rtn = false;
            DataTable dt = this.mObjectManager.GetDm(tablename);
            if (dt == null) {
                this.mObjectManager.LoadDm(tablename);
                dt = this.mObjectManager.GetDm(tablename);
                if (dt == null) {
                    dt = this.FTSMain.TableManager.LoadTable(this.mObjectManager.DataSet, tablename);
                }
            }
            if (dt == null) {
                return false;
            }

            Type type_frmdic = this.GetFrmDicList(tablename);
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
                                  {this.mFTSMain, this.mObjectManager.DataSet, tablename, condition, string.Empty, true};
                FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                frmdic.ShowDialog();
                if (frmdic.DialogResult == DialogResult.OK) {
                    t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tablename)];
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

        public bool ProcessLookupColumn(FTSDataGrid paragrid, BaseEdit t, string tablename, string condition, int nrow,
                                        GridColumn ncol, string[] collist, string[] fieldlist, bool overwrite) {
            bool rtn = false;
            DataTable dt = this.mObjectManager.GetDm(tablename);
            if (dt == null) {
                this.mObjectManager.LoadDm(tablename);
                dt = this.mObjectManager.GetDm(tablename);
                if (dt == null) {
                    dt = this.FTSMain.TableManager.LoadTable(this.mObjectManager.DataSet, tablename);
                }
            }
            if (dt == null) {
                return false;
            }
            Type type_frmdic = this.GetFrmDicList(tablename);
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
                                  {this.mFTSMain, this.mObjectManager.DataSet, tablename, condition, string.Empty, true};
                FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                frmdic.ShowDialog();
                if (frmdic.DialogResult == DialogResult.OK) {
                    t.EditValue = frmdic.RetRow[this.mFTSMain.TableManager.GetIDField(tablename)];
                    paragrid.SetValue(nrow, ncol, t.EditValue);
                    if (collist != null) {
                        for (int i = 0; i < collist.Length; i++) {
                            if (overwrite) {
                                paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                            } else {
                                if (collist[i].ToUpper() == ncol.FieldName.ToUpper() ||
                                    paragrid.GetValue(nrow, collist[i]).ToString() == string.Empty ||
                                    paragrid.GetValue(nrow, collist[i]).ToString() == "0") {
                                    paragrid.SetValue(nrow, collist[i], frmdic.RetRow[fieldlist[i]]);
                                }
                            }
                        }
                    }
                    rtn = true;
                }
            }
            return rtn;
        }

        private void ViewGrid_ShowGridMenu(object sender, GridMenuEventArgs e) {
            try {
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if ((hitInfo.InRow)&&(this.mShowContextMenu)) {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    this.GridContextMenu.ShowPopup(this.barManager, Cursor.Position);
                }
                e.Allow = false;
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void SetPositionComboBox() {
            if ((this.grid.ViewGrid.FocusedColumn!=null)&&(this.grid.ViewGrid.FocusedColumn.ColumnEdit is RepositoryItemLookUpEdit)) {
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

        public virtual bool CellWarning(CurrentCellInfo cellinfo) {
            return true;
        }

        public virtual void GridChanged() {
        }

        public virtual void SetTextFooter() {
        }

        public virtual void GridComboChanged(int nrow, GridColumn ncol, object row) {
        }

        private void grid_ComboChanged(object sender, GridComboChangeEventArgs e) {
            this.GridComboChanged(e.row, e.col, e.control.Properties.GetDataSourceRowByKeyValue(e.control.EditValue));
        }
        public virtual void GridCustomUnboundColumnData(GridView gridview, CustomColumnDataEventArgs e)
        {
        }
        #endregion 5: Grid Misc events

        #region 7: Config

        public virtual void ConfigForm() {
        }

        protected virtual void ShowConfigForm() {
        }

        protected virtual void ShowTempForm() {
        }

        protected virtual void ShowCalculationForm() {
        }

        protected virtual void ShowOptionForm() {
        }

        protected virtual void ConfigGridOther(){
        }
        #endregion

        #region 8: Hand Code

        private BarManager barManager;
        private PopupMenu contextMenu;

        public void SetStatusMessage(string msg) {
            this.barManager.Items[0].Caption = msg;
        }

        private void CreateStatusBar() {
            BarStaticItem itemStatus = new BarStaticItem();
            Bar bar = new Bar();
            this.barManager = new BarManager();
            this.GridContextMenu = new PopupMenu();
            ((ISupportInitialize) (this.barManager)).BeginInit();
            ((ISupportInitialize) (this.GridContextMenu)).BeginInit();
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
            itemStatus.Caption = "";
            this.GridContextMenu.Name = "contextMenu";
            this.GridContextMenu.Manager = this.barManager;
            ((ISupportInitialize) (this.barManager)).EndInit();
            ((ISupportInitialize) (this.GridContextMenu)).EndInit();
        }

        #endregion

        #region 9: Override

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!this.DesignMode) {
                this.UpdateInfo();
            }
        }

        #endregion

        protected virtual void RemoveRow(int prerowhandle) {
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }

        public virtual void ConvertTransaction() {
        }

        public virtual void BulkConvertTransaction() {
        }
        public virtual void EndScreenEdit() {
            BindingManagerBase bm =
                this.BindingContext[this.ObjectManager.ObjectList[0].DataSet, this.ObjectManager.ObjectList[0].TableName
                    ];
            bm.EndCurrentEdit();
        }
        public virtual void ReleaseFormLedger() {
            
        }
        public override void LoadDm(string tablename) {
            this.ObjectManager.LoadDm(tablename);
        }
    }

    public enum ChangedStatus {
        YES = 0,
        NO = 1,
        CANCEL = 2,
        NONE = 3
    }

    public enum TranActions {
        NEW = 0,
        EDIT = 1,
        DELETE = 2,
        NONE = 3
    }

    public class RefreshListEventArgs : EventArgs {
        private TranActions mAction = TranActions.NONE;
        private object mPrKeyTran = null;
        private ManagerBase mManagerBase = null;
        private string mTranId = string.Empty;

        public RefreshListEventArgs(ManagerBase managerbase, object prkeytran, TranActions action, string tranid) {
            this.mManagerBase = managerbase;
            this.mPrKeyTran = prkeytran;
            this.mAction = action;
            this.mTranId = tranid;
        }

        public ManagerBase ManagerBase {
            get { return this.mManagerBase; }
        }

        public object PrKeyTran {
            get { return this.mPrKeyTran; }
        }

        public TranActions Action {
            get { return this.mAction; }
        }

        public string TranId {
            get { return this.mTranId; }
        }
    }

    public delegate void RefreshListHandler(object sender, RefreshListEventArgs e);
}