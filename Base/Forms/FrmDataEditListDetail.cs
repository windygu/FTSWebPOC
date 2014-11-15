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
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ItemClickEventArgs = FTS.BaseUI.Controls.ItemClickEventArgs;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmDataEditListDetail : FTSForm {
        private FTSMain mFTSMain;
        private DataMode mMode = DataMode.READ;
        private Control mFocusControl;
        private string mTranId = string.Empty;
        private string mFormName = string.Empty;
        private bool mShowBottom = false;
        private bool mShowExtTop = false;
        private DefaultValuesForm defaultvaluesForm;
        private ObjectBase mDataObject;

        private AppearanceDefault WarningColor = new AppearanceDefault(Color.White, Color.LightCoral, Color.Empty,
                                                                       Color.Red, LinearGradientMode.ForwardDiagonal);

        private object mOldCellValue = null;

        public FrmDataEditListDetail() {
            this.InitializeComponent();
        }

        public FrmDataEditListDetail(FTSMain ftsmain, bool dialog) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            if (!dialog) {
                //this.MdiParent = this.mFTSMain.MainForm;
                this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            }
            this.toolbar.LoadLayout(this.mFTSMain);
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.LoadData();
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public Control FocusControl {
            get { return this.mFocusControl; }
            set { this.mFocusControl = value; }
        }

        public string TranId {
            get { return this.mTranId; }
            set { this.mTranId = value; }
        }

        public string FormName {
            get { return this.mFormName; }
            set { this.mFormName = value; }
        }

        public DataMode Mode {
            get { return this.mMode; }
            set { this.mMode = value; }
        }

        public FTSEditFormToolbar ToolBar {
            get { return this.toolbar; }
        }

        public object OldCellValue {
            get { return this.mOldCellValue; }
        }

        public ObjectBase DataObject {
            get { return this.mDataObject; }
            set { this.mDataObject = value; }
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

        public virtual void EndEdit() {
            if (this.mFocusControl != null) {
                this.mFocusControl.Focus();
            }
            BindingManagerBase bm = this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName];
            bm.EndCurrentEdit();
            this.grid.EndEdit();
            this.DataObject.EndEdit();
        }

        public virtual ChangedStatus CheckChanged() {
            this.EndEdit();
            if (this.Mode == DataMode.READ) {
                this.RestoreRecord();
                return ChangedStatus.NONE;
            }
            if (this.DataObject.HasChanged()) {
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
            if (!this.toolbar.NewEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.AddAction);
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.DataObject.AddNew();
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
                this.mFocusControl.Focus();
            }
        }

        public virtual void CheckSecurityBussiess(string dataaction)
        {
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }

        public virtual void EditRecord() {
            if (!this.toolbar.EditEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.EditAction);
            if (this.mMode == DataMode.READ) {
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
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    this.mDataObject.CopyRecord(row);
                }
                BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
                int endpos = bm.Count - 1;
                this.grid.ViewGrid.ClearSelection();
                if (bm.Count > 0 && endpos < bm.Count) {
                    bm.Position = endpos;
                }
                this.mMode = DataMode.NEW;
                this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
                this.UpdateInfo();
                this.mFocusControl.Focus();
            }
        }

        public virtual void DeleteRecord() {
            if (!this.toolbar.DeleteEnable) {
                return;
            }
            this.CheckSecurityBussiess(DataAction.DeleteAction);
            if (FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_CONFIRM_DELETE")) ==
                DialogResult.Yes) {
                //this.RestoreRecord();
                this.mMode = DataMode.READ;
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    this.DataObject.DeleteRow(row);
                    this.DataObject.UpdateData();
                }
                this.mMode = DataMode.READ;
                this.UpdateInfo();
                this.grid.SetIndicatorWidth(this.grid.ViewGrid.RowCount);
            }
        }

        public virtual void UpdateRecord() {
            if (!this.toolbar.SaveEnable) {
                return;
            }
            this.EndEdit();
            this.CheckFormRequire(this.groupHeader, this.DataObject.TableName);
            this.CheckGridRequire(this.grid, this.DataObject.TableName);
            //TODO: Check
            this.DataObject.UpdateData();
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
            this.DataObject.Restore();
            this.grid.EndInit();
            this.grid.ViewGrid.ClearColumnErrors();
            this.UpdateInfo();
        }

        public virtual void RefreshDm() {
            this.DataObject.RefreshDm();
        }

        public virtual void PrintRecord() {
        }

        public virtual void NextRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                if (this.grid.ViewGrid.FocusedRowHandle < this.grid.ViewGrid.RowCount - 1) {
                    this.grid.ViewGrid.FocusedRowHandle++;
                    this.mMode = DataMode.READ;
                    this.UpdateInfo();
                    this.FocusControl.Focus();
                }
            }
        }

        public virtual void PreviousRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                if (this.grid.ViewGrid.FocusedRowHandle > 0) {
                    this.grid.ViewGrid.FocusedRowHandle--;
                    this.mMode = DataMode.READ;
                    this.UpdateInfo();
                    this.FocusControl.Focus();
                }
            }
        }

        #endregion

        #region 3: User Actions

        protected override void OnClosing(CancelEventArgs e) {
            try {
                if (this.CheckChanged() == ChangedStatus.CANCEL) {
                    e.Cancel = true;
                }
            } catch (FTSException ex) {
                e.Cancel = true;
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            }
            try {
                if (!e.Cancel) {
                    if (this.WindowState != FormWindowState.Normal) {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.SaveLayout(this.mFTSMain);
                    this.DestroyCustomization();
                    this.DestroyDefaultValues();
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            }
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
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
                    case "Edit":
                        this.EditRecord();
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
                    case "Next":
                        this.NextRecord();
                        break;
                    case "Previous":
                        this.PreviousRecord();
                        break;
                    case "Refresh":
                        this.RefreshDm();
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
                    case "Default":
                        this.FormDefaultValues(new Point(-10000, -10000));
                        break;
                    case "Close":
                        this.Close();
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        private void FormDefaultValues(Point showpoint) {
            this.DestroyDefaultValues();
            this.defaultvaluesForm = this.CreateDefaultValuesForm();
            this.AddOwnedForm(this.defaultvaluesForm);
            this.defaultvaluesForm.ShowDefaultValues(showpoint);
        }

        private DefaultValuesForm CreateDefaultValuesForm() {
            //return new DefaultValuesForm(this, this.mFTSMain, this.mTranId, this.mObjectManager.DefaultHashTable);
            return null;
        }

        protected void DestroyDefaultValues() {
            if (this.defaultvaluesForm != null) {
                this.defaultvaluesForm.Dispose();
                this.defaultvaluesForm = null;
            }
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
                    case "R, Control":
                        this.RefreshDm();
                        break;
                    case "E, Control":
                        this.EditRecord();
                        break;
                    default:
                        return base.ProcessDialogKey(keyData);
                }
                return true;
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
                return true;
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
                return true;
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

        #endregion 2: Layout Methods

        #region 5: Info functions

        public virtual void UpdateInfo() {
            if (this.DataObject.DataTable.Rows.Count == 0) {
                this.mMode = DataMode.NONE;
            }
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource, this.grid.DataMember];
            this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName].Position =
                UIFunctions.GetSourcePosition(bm);
            switch (this.mMode) {
                case DataMode.NONE:
                    this.groupHeader.Enabled = false;
                    this.grid.ViewGrid.OptionsBehavior.Editable = false;
                    this.toolbar.NewEnable = true;
                    //this.toolbar.OpenEnable = true;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = false;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = false;
                    this.toolbar.SaveEnable = false;
                    this.toolbar.PrintEnable = false;
                    for (int i = 0; i < this.contextMenu.LinksPersistInfo.Count; i++) {
                        this.contextMenu.LinksPersistInfo[i].Item.Enabled = false;
                    }
                    break;
                case DataMode.READ:
                    this.groupHeader.Enabled = false;
                    this.grid.ViewGrid.OptionsBehavior.Editable = false;
                    this.toolbar.NewEnable = true;
                    //this.toolbar.OpenEnable = true;
                    this.toolbar.EditEnable = true;
                    this.toolbar.CopyEnable = true;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = false;
                    this.toolbar.SaveEnable = false;
                    this.toolbar.PrintEnable = true;
                    for (int i = 0; i < this.contextMenu.LinksPersistInfo.Count; i++) {
                        this.contextMenu.LinksPersistInfo[i].Item.Enabled = false;
                    }
                    break;
                case DataMode.NEW:
                    this.groupHeader.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = false;
                    //this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = false;
                    for (int i = 0; i < this.contextMenu.LinksPersistInfo.Count; i++) {
                        this.contextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                case DataMode.EDIT:
                    this.groupHeader.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = false;
                    //this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = false;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = false;
                    for (int i = 0; i < this.contextMenu.LinksPersistInfo.Count; i++) {
                        this.contextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                case DataMode.AUTO:
                    this.groupHeader.Enabled = true;
                    this.grid.ViewGrid.OptionsBehavior.Editable = true;
                    this.toolbar.NewEnable = true;
                    //this.toolbar.OpenEnable = false;
                    this.toolbar.EditEnable = true;
                    this.toolbar.CopyEnable = false;
                    this.toolbar.DeleteEnable = true;
                    this.toolbar.RefreshEnable = true;
                    this.toolbar.UndoEnable = true;
                    this.toolbar.SaveEnable = true;
                    this.toolbar.PrintEnable = true;
                    for (int i = 0; i < this.contextMenu.LinksPersistInfo.Count; i++) {
                        this.contextMenu.LinksPersistInfo[i].Item.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
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
                            ((LookUpEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((LookUpEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSSingleComboCom) {
                    Control ctrl = ((FTSSingleComboCom) c).ComboBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((ComboBoxEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSDateCom) {
                    Control ctrl = ((FTSDateCom) c).DateTime;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((DateEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((DateEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom) {
                    Control ctrl = ((FTSNumericCom) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSReadOnlyNumericCom) {
                    Control ctrl = ((FTSReadOnlyNumericCom) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom2) {
                    Control ctrl = ((FTSNumericCom2) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSCalculatorCom) {
                    Control ctrl = ((FTSCalculatorCom) c).Calculator;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((CalcEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((CalcEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSNameIDCom) {
                    Control ctrl = ((FTSNameIDCom) c).txtID;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSVatCom) {
                    Control ctrl = ((FTSVatCom) c).txtID;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSPercentCom) {
                    Control ctrl = ((FTSPercentCom) c).txtPercent;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            ((TextEdit) ctrl).Focus();
                        }
                    }
                } else if (c is FTSMemoCom) {
                    Control ctrl = ((FTSMemoCom) c).Memo;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((MemoEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSPictureCom) {
                    Control ctrl = ((FTSPictureCom) c).Picture;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((PictureEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            (ctrl).Focus();
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
                                                  FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex));
            }
            this.grid.ViewGrid.SelectRow(this.grid.ViewGrid.GetRowHandle(ex.RowPos));
            this.grid.ViewGrid.ShowEditor();
        }

        public virtual void OnError(FTSException ex) {
            if (ex.TableName == this.DataObject.TableName) {
                this.OnErrorForm(this.groupHeader, ex);
            }
            if (ex.TableName == this.DataObject.TableName) {
                this.OnErrorGrid(ex);
            }
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
            //this.grid.ViewGrid.SortInfo.Add(this.grid.ViewGrid.Columns["LIST_ORDER"], ColumnSortOrder.Ascending);
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            this.grid.ViewGrid.RowCellStyle += new RowCellStyleEventHandler(this.ViewGrid_RowCellStyle);
            this.grid.ViewGrid.CellValueChanged += new CellValueChangedEventHandler(this.ViewGrid_CellValueChanged);
            this.grid.ComboBoxClick += new ComboBoxClickEventHandler(this.grid_ComboBoxClick);
            //this.grid.ProcessGridKey += new KeyEventHandler(grid_ProcessGridKey);
            this.grid.ValidateColumn += new ValidateColumnEventHandler(this.grid_ValidateColumn);
            this.grid.ViewGrid.ValidatingEditor +=
                new BaseContainerValidateEditorEventHandler(this.ViewGrid_ValidatingEditor);
            this.grid.NumbericValueChanging += new NumbericValueChangingEventHandler(this.grid_NumbericValueChanging);
            this.grid.TextBoxLookup += new TextBoxLookupEventHandler(this.grid_TextBoxLookup);
            this.grid.GridComboChange += new GridComboChangeEventHandler(this.grid_ComboChanged);
            this.grid.ButtonClick += new ButtonClickEventHandler(this.grid_ButtonClick);
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
                if (e.PrevFocusedRowHandle >= 0) {
                    this.mOldCellValue = this.grid.GetValue(e.FocusedRowHandle,
                                                            this.grid.ViewGrid.FocusedColumn.VisibleIndex);
                    if (this.CheckChanged() != ChangedStatus.CANCEL) {
                        this.SetTextFooter();
                        this.GridChanged();
                        this.SetPositionComboBox();
                    } else {
                        this.grid.ViewGrid.FocusedRowHandle = e.PrevFocusedRowHandle;
                    }
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void ViewGrid_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                if (e.PrevFocusedColumn != null) {
                    this.mOldCellValue = this.grid.GetValue(this.grid.ViewGrid.FocusedRowHandle,
                                                            e.FocusedColumn.VisibleIndex);
                    this.SetTextFooter();
                    this.grid.ViewGrid.UpdateSummary();
                    this.GridChanged();
                    this.SetPositionComboBox();
                }
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
                ((FTSDataGrid) sender).EndEdit();
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
                                DataRow row = this.DataObject.DataSet.Tables[tableName].NewRow();
                                foreach (DataColumn column in this.DataObject.DataSet.Tables[tableName].Columns) {
                                    row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                }
                                this.DataObject.DataSet.Tables[tableName].Rows.Add(row);
                                this.DataObject.DataSet.Tables[tableName].AcceptChanges();
                                ((FTSDataGrid) sender).ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                                edit.EditValue = row[edit.Properties.ValueMember];
                                if (edit.Text.Trim() == string.Empty) {
                                    ((FTSDataGrid) sender).SetValue(((FTSDataGrid) sender).ViewGrid.FocusedRowHandle,
                                                                    e.ColumnName, string.Empty);
                                }
                                ((FTSDataGrid) sender).EndEdit();
                                ((FTSDataGrid) sender).ViewGrid.RefreshData();
                            }
                            frmdic.Close();
                        }
                        edit.Properties.ShowPopupShadow = true;
                    } else {
                        if ((e.ButtonsTag == "Edit") && (edit.EditValue != null) &&
                            (((FTSDataGrid) sender).CurrentCellValue.ToString().Trim().Length != 0)) {
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
                                        this.DataObject.DataSet.Tables[tableName].Rows[UIFunctions.GetSourcePosition(bm)];
                                    if (edit.Properties.DataSource is DataView) {
                                        row = this.DataObject.DataSet.Tables[tableName].Rows.Find(edit.EditValue);
                                    }
                                    foreach (DataColumn column in this.DataObject.DataSet.Tables[tableName].Columns) {
                                        row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                    }
                                    this.DataObject.DataSet.Tables[tableName].AcceptChanges();
                                    ((FTSDataGrid) sender).ViewGrid.SetFocusedValue(row[edit.Properties.ValueMember]);
                                    edit.EditValue = row[edit.Properties.ValueMember];
                                    ((FTSDataGrid) sender).EndEdit();
                                    ((FTSDataGrid) sender).ViewGrid.RefreshData();
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
                        if (this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.String")) {
                            paragrid.SetValue(nrow, collist[i], string.Empty);
                        }
                        if (this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Decimal") ||
                            this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int16") ||
                            this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                            Type.GetType("System.Int32")) {
                            paragrid.SetValue(nrow, collist[i], 0);
                        }
                    }
                }
                return;
            }
            DataTable dt = this.DataObject.DataSet.Tables[tablename];
            if (dt == null) {
                dt = this.mFTSMain.TableManager.LoadTable(this.DataObject.DataSet, tablename);
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
                                      {this.mFTSMain, this.DataObject.DataSet, tablename, condition, t.Text, true};
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
                                if (this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.String")) {
                                    paragrid.SetValue(nrow, collist[i], string.Empty);
                                }
                                if (this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Decimal") ||
                                    this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
                                    Type.GetType("System.Int16") ||
                                    this.DataObject.DataSet.Tables[tablename].Columns[fieldlist[i]].DataType ==
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

        public bool ProcessLookupColumn(FTSDataGrid paragrid, BaseEdit t, string tablename, string condition, int nrow,
                                        GridColumn ncol, string[] collist, string[] fieldlist) {
            bool rtn = false;
            if (this.DataObject.DataSet.Tables[tablename] == null) {
                this.mFTSMain.TableManager.LoadTable(this.DataObject.DataSet, tablename);
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
                                  {this.mFTSMain, this.DataObject.DataSet, tablename, condition, string.Empty, true};
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

        private void ViewGrid_ShowGridMenu(object sender, GridMenuEventArgs e) {
            try {
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow) {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    this.contextMenu.ShowPopup(this.barManager, Cursor.Position);
                }
                e.Allow = false;
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void SetPositionComboBox() {
            if (this.grid.ViewGrid.FocusedColumn.ColumnEdit is RepositoryItemLookUpEdit) {
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

        #endregion 5: Grid Misc events

        #region 7: Config

        public virtual void ConfigForm() {
        }

        #endregion

        #region 8: Hand Code

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
            itemStatus.Caption =
                "Mới: Ctrl+N, Sao: Ctrl+C, Sửa: Ctrl+E, Lại: Ctrl+K, Xoá: Ctrl+D, Lưu: Ctrl+S, In: Ctrl+P, Nạp: Ctrl+R, Tìm: Ctrl+F, Thêm dòng: Ctrl+Insert, Chèn dòng: Ctrl+I, Sao dòng: Ctrl+K, Xoá dòng: Ctrl+Delete ";
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Manager = this.barManager;
            ((ISupportInitialize) (this.barManager)).EndInit();
            ((ISupportInitialize) (this.contextMenu)).EndInit();
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

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }
    }
}