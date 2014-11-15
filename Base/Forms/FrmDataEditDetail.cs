#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FrmDataEditDetail : FTSForm {
        private FTSMain mFTSMain;
        private ObjectBase mDataObject;
        private bool mFlagNew;
        private object mIdValue;
        private FTSForm mFrmParent;
        private DataRow mReturnRow;
        private Control mFocusControl;
        private string mCondition = string.Empty;

        public FrmDataEditDetail() {
            this.InitializeComponent();
        }

        public FrmDataEditDetail(FTSMain ftsmain, bool saveandclose) {
            this.mFTSMain = ftsmain;
            this.mCondition = "1=1";
            this.InitializeComponent();
            this.CreateStatusBar();
            this.toolbar.LoadLayout(this.mFTSMain);
            if (saveandclose) {
                this.toolbar.NextVisible = BarItemVisibility.Never;
                this.toolbar.PreviousVisible = BarItemVisibility.Never;
                this.toolbar.SaveVisible = BarItemVisibility.Never;
                this.toolbar.UndoVisible = BarItemVisibility.Never;
                this.toolbar.NewVisible = BarItemVisibility.Never;
                this.toolbar.DeleteVisible = BarItemVisibility.Never;
                this.toolbar.SaveCloseVisible = BarItemVisibility.Always;
                this.toolbar.CopyEnable = false;
                this.toolbar.CopyVisible = BarItemVisibility.Never;
                this.toolbar.GoItemVisible = BarItemVisibility.Never;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Never;
                this.toolbar.FilterVisible = BarItemVisibility.Never;
                this.toolbar.EditVisible = BarItemVisibility.Never;
            } else {
                this.toolbar.CopyEnable = true;
                this.toolbar.CopyVisible = BarItemVisibility.Always;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Never;
                this.toolbar.FilterVisible = BarItemVisibility.Never;
            }
            this.LoadData();
            this.ShowInTaskbar = false;
        }

        public FrmDataEditDetail(FTSMain ftsmain, bool saveandclose, string condition) {
            this.mFTSMain = ftsmain;
            this.mCondition = condition;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.toolbar.LoadLayout(this.mFTSMain);
            if (saveandclose) {
                this.toolbar.NextVisible = BarItemVisibility.Never;
                this.toolbar.PreviousVisible = BarItemVisibility.Never;
                this.toolbar.SaveVisible = BarItemVisibility.Never;
                this.toolbar.UndoVisible = BarItemVisibility.Never;
                this.toolbar.NewVisible = BarItemVisibility.Never;
                this.toolbar.DeleteVisible = BarItemVisibility.Never;
                this.toolbar.SaveCloseVisible = BarItemVisibility.Always;
                this.toolbar.SaveNewVisible = BarItemVisibility.Always;
                this.toolbar.CopyEnable = false;
                this.toolbar.CopyVisible = BarItemVisibility.Never;
                this.toolbar.GoItemVisible = BarItemVisibility.Never;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Never;
                this.toolbar.FilterVisible = BarItemVisibility.Never;
                this.toolbar.EditVisible = BarItemVisibility.Never;
            } else {
                this.toolbar.CopyEnable = true;
                this.toolbar.CopyVisible = BarItemVisibility.Always;
                this.toolbar.ExportExcelVisible = BarItemVisibility.Never;
                this.toolbar.FilterVisible = BarItemVisibility.Never;
            }
            this.LoadData();
            this.ShowInTaskbar = false;
        }

        public string Condition {
            get { return this.mCondition; }
            set { this.mCondition = value; }
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public ObjectBase DataObject {
            get { return this.mDataObject; }
            set { this.mDataObject = value; }
        }

        public bool FlagNew {
            get { return this.mFlagNew; }
            set { this.mFlagNew = value; }
        }

        public object IdValue {
            get { return this.mIdValue; }
            set { this.mIdValue = value; }
        }

        public FTSForm FrmParent {
            get { return this.mFrmParent; }
            set { this.mFrmParent = value; }
        }

        public Control FocusControl {
            get { return this.mFocusControl; }
            set { this.mFocusControl = value; }
        }

        public DataRow ReturnRow {
            get { return this.mReturnRow; }
            set { this.mReturnRow = value; }
        }

        public FTSEditFormToolbar ToolBar {
            get { return this.toolbar; }
        }

        public FTSShadowPanel panelmain {
            get { return this.palMain; }
        }

        #region 1: Data Actions

        public virtual void BinControls() {
        }

        public virtual void SetControls() {
        }

        public virtual void UpdateInfo() {
            if (this.mFocusControl != null) {
                this.FocusControl.Focus();
            }
        }

        public virtual void LoadData() {
        }

        public virtual void EndEdit() {
            if (this.mFocusControl != null) {
                this.mFocusControl.Focus();
            }
            BindingManagerBase bm = this.BindingContext[this.mDataObject.DataSet, this.mDataObject.TableName];
            bm.EndCurrentEdit();
            this.mDataObject.EndEdit();
        }

        public virtual ChangedStatus CheckChanged() {
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
            this.CheckSecurityBussiess(DataAction.AddAction);
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mDataObject.Clear();
                this.mDataObject.AddNew();
                this.UpdateInfo();
                this.ConfigAction();
                if (this.FocusControl != null) {
                    this.FocusControl.Focus();
                }
            }
        }

        public virtual void PrintRecord() {
        }

        public virtual void CopyRecord() {
            this.CheckSecurityBussiess(DataAction.AddAction);
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                if (this.mDataObject.DataTable.Rows.Count > 0) {
                    DataTable cp = this.mDataObject.DataTable.Copy();
                    this.mDataObject.Clear();
                    this.mDataObject.CopyRecord(cp.Rows[0]);
                    Functions.ClearTable(cp);
                }
                this.UpdateInfo();
                this.ConfigAction();
            }
        }

        public virtual void CheckSecurityBussiess(string dataaction)
        {
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }

        public virtual void DeleteRecord() {
            this.CheckSecurityBussiess(DataAction.DeleteAction);
            DialogResult dgresult =
                FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_DELETE_RECORD_CONFIRM"));
            if (dgresult == DialogResult.Yes) {
                this.RestoreRecord();
                if (this.mDataObject.DataTable.Rows.Count > 0) {
                    object id = this.mDataObject.GetValue(0, this.mDataObject.IdField);
                    this.mDataObject.DeleteAtPosition(0);
                    this.UpdateRecord();
                    if (this.mFrmParent is FrmDataList) {
                        ((FrmDataList) this.mFrmParent).UpdateDeletedRecord(id);
                    } else if (this.mFrmParent is FrmDataTreeList) {
                        ((FrmDataTreeList) this.mFrmParent).UpdateDeletedRecord(id);
                    }
                }
                this.UpdateInfo();
                this.ConfigAction();
            }
        }

        public virtual void NextRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mDataObject.LoadNextRecord();
                this.UpdateInfo();
                this.ConfigAction();
            }
        }

        public virtual void GotoRecord(object key) {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mDataObject.LoadRecord(key);
                this.UpdateInfo();
                this.ConfigAction();
            }
        }

        public virtual void PreviousRecord() {
            if (this.CheckChanged() != ChangedStatus.CANCEL) {
                this.mDataObject.LoadPreviousRecord();
                this.UpdateInfo();
                this.ConfigAction();
            }
        }

        public virtual void UpdateAndClose() {
            this.EndEdit();
            if (this.mDataObject.HasChanged()) {
                this.UpdateRecord();
                if (this.mDataObject.DataTable.Rows.Count > 0) {
                    this.mReturnRow = this.mDataObject.DataTable.Rows[0];
                    this.DialogResult = DialogResult.Yes;
                } else {
                    this.DialogResult = DialogResult.No;
                }
            } else {
                this.DialogResult = DialogResult.No;
            }
        }

        public virtual void UpdateAndNew() {
            this.UpdateRecord();
            this.NewRecord();
        }

        public virtual void UpdateRecord() {
            this.EndEdit();
            if (this.mDataObject.DataTable.Rows.Count == 0 || !this.mDataObject.HasChanged()) {
                return;
            }
            this.CheckFormRequire(this.palMain);
            bool isdelete = false;
            object id;
            bool ischanged = false;
            if (this.mDataObject.DataTable.Rows.Count > 0 &&
                this.mDataObject.DataTable.Rows[0].RowState == DataRowState.Deleted) {
                id = this.mDataObject.DataTable.Rows[0][this.mDataObject.IdField, DataRowVersion.Original];
                isdelete = true;
            } else {
                id = this.mDataObject.DataTable.Rows[0][this.mDataObject.IdField];
                if (this.mDataObject.DataTable.Rows.Count > 0 &&
                    this.mDataObject.DataTable.Rows[0].RowState == DataRowState.Modified) {
                    ischanged = true;
                }
            }
            this.mDataObject.UpdateData();
            DataTable tblTemp = this.mDataObject.DataTable.Copy();
            if (this.mFrmParent != null) {
                if (isdelete) {
                    if (this.mFrmParent is FrmDataList) {
                        ((FrmDataList) this.mFrmParent).UpdateDeletedRecord(id);
                    } else if (this.mFrmParent is FrmDataTreeList) {
                        ((FrmDataTreeList) this.mFrmParent).UpdateDeletedRecord(id);
                    }
                } else {
                    if (tblTemp.Rows.Count > 0) {
                        if (this.mFrmParent is FrmDataList) {
                            ((FrmDataList) this.mFrmParent).UpdateChangeRecord(tblTemp.Rows[0], ischanged);
                        } else if (this.mFrmParent is FrmDataTreeList) {
                            ((FrmDataTreeList) this.mFrmParent).UpdateChangeRecord(tblTemp.Rows[0], ischanged);
                        }
                    }
                }
            }
        }

        public virtual void RestoreRecord() {
            this.EndEdit();
            this.mDataObject.Restore();
            this.ConfigAction();
            this.UpdateInfo();
        }

        public virtual void RefreshDm() {
            this.mDataObject.RefreshDm();
        }

        #endregion

        #region 2: Layout Methods

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);
            this.SetProductVersion();
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            if (this.mFTSMain.UserInfo.UserGroupID != "ADMIN") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
            this.SetProductVersion();
        }

        public override void SaveLayout(FTSMain ftsmain) {
            base.SaveLayout(ftsmain);
        }

        #endregion 2: Layout Methods

        #region 3: User actions

        protected override bool ProcessDialogKey(Keys keyData) {
            try {
                switch (keyData) {
                    case Keys.Control | Keys.F4:
                        this.Close();
                        break;
                    case Keys.F1:
                        this.ShowHelp();
                        break;
                    default:
                        break;
                }
                string key = keyData.ToString();
                switch (key) {
                    case "N, Control":
                        this.NewRecord();
                        break;
                    case "K, Control":
                        this.RestoreRecord();
                        break;
                    case "Y, Control":
                        this.CopyRecord();
                        break;
                    case "R, Control":
                        this.RefreshDm();
                        break;
                    case "D, Control":
                        this.DeleteRecord();
                        break;
                    case "S, Control":
                        this.UpdateRecord();
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
            return base.ProcessDialogKey(keyData);
        }


        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "SaveClose":
                        this.UpdateAndClose();
                        break;
                    case "SaveNew":
                        this.mFlagNew = true;
                        this.UpdateAndNew();
                        break;
                    case "Close":
                        this.CloseForm();
                        break;
                    case "New":
                        this.mFlagNew = true;
                        this.NewRecord();
                        break;
                    case "Copy":
                        this.CopyRecord();
                        break;
                    case "Print":
                        this.PrintRecord();
                        break;
                    case "Previous":
                        this.mFlagNew = false;
                        this.PreviousRecord();
                        break;
                    case "Next":
                        this.mFlagNew = false;
                        this.NextRecord();
                        break;
                    case "Delete":
                        this.DeleteRecord();
                        break;
                    case "Save":
                        this.UpdateRecord();
                        break;
                    case "Undo":
                        this.RestoreRecord();
                        break;
                    case "Refresh":
                        this.RefreshDm();
                        break;
                    case "Layout":
                        this.FormCustomization(new Point(-1000, -1000), this.mFTSMain);
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

        private void toolbar_GoItemClick(object sender, GoItemToolbarEventArgs e) {
            try {
                if ((e.Key != null) && (e.Key.ToString().Trim() != string.Empty)) {
                    this.mFlagNew = false;
                    this.GotoRecord(e.Key);
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
                this.OnError(ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
                this.OnError(new FTSException(ex1));
            }
        }

        #endregion

        #region 4: Others

        protected override void OnClosing(CancelEventArgs e) {
            try {
                this.OnClose = true;
                if (this.CheckChanged() != ChangedStatus.CANCEL) {
                    if (this.WindowState != FormWindowState.Normal) {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.SaveLayout(this.mFTSMain);
                    this.DestroyCustomization();
                } else {
                    e.Cancel = true;
                    this.OnClose = false;
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

        private void OnErrorForm(Control control, FTSException ex) {
            foreach (Control c in control.Controls) {
                if (c is FTSTextCom) {
                    Control ctrl = ((FTSTextCom) c).Textbox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
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
                } else if (c is FTSComboCom) {
                    Control ctrl = ((FTSComboCom) c).ComboBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((LookUpEdit) ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSDateCom) {
                    Control ctrl = ((FTSDateCom) c).DateTime;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((DateEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom) {
                    Control ctrl = ((FTSNumericCom) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSNumericCom2) {
                    Control ctrl = ((FTSNumericCom2) c).NumericTextBox;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSCalculatorCom) {
                    Control ctrl = ((FTSCalculatorCom) c).Calculator;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((CalcEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSNameIDCom) {
                    Control ctrl = ((FTSNameIDCom) c).txtID;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((TextEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain, ex);
                            (ctrl).Focus();
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
                            (ctrl).Focus();
                        }
                    }
                } else if (c is FTSPictureCom) {
                    Control ctrl = ((FTSPictureCom) c).Picture;
                    if (ctrl.DataBindings.Count > 0) {
                        if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == ex.FieldName) {
                            ((PictureEdit)ctrl).ErrorText = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.FTSMain,ex);
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

        public virtual void OnError(FTSException ex) {
            this.OnErrorForm(this.palMain, ex);
        }

        public virtual void ConfigAction() {
            BindingManagerBase bm = this.BindingContext[this.mDataObject.DataSet, this.mDataObject.TableName];
            this.toolbar.DeleteEnable = (bm.Count == 0 || !this.AllowDelete) ? false : true;
            this.toolbar.UndoEnable = (bm.Count == 0) ? false : true;
            this.toolbar.CopyEnable = (bm.Count == 0 || !this.AllowNew) ? false : true;
            this.toolbar.SaveEnable = (bm.Count == 0) ? false : true;
            foreach (Control c in this.Controls) {
                if (c is FTSEditFormToolbar) {
                    c.Enabled = true;
                } else {
                    c.Enabled = (bm.Count == 0) ? false : true;
                }
            }
        }
        public virtual void CloseForm()
        {
            this.Close();
        }
        #endregion

        #region 5: Hand Code

        public virtual void CreateStatusBar()
        {
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
            //itemStatus.Caption = "Mới: Ctrl+N, Sao: Ctrl+C, Lại: Ctrl+K, Xoá: Ctrl+D, Lưu: Ctrl+S, Nạp: Ctrl+R";
            ((ISupportInitialize) (barManager)).EndInit();
        }

        #endregion

        #region 6: Override

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!this.DesignMode) {
                this.UpdateInfo();
            }
        }

        #endregion

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }
    }
}