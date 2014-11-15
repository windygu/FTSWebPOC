#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
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
    public partial class FrmDataTreeList : FTSForm {
        protected FrmDataEditDetail frmDataEditDetail;
        private ObjectBase mDataObject;
        private DataSet mDataSet;
        private FTSMain mFTSMain;
        private string mFilterValue = string.Empty;
        private string mCondition = string.Empty;
        private ListMode mMode = ListMode.SELECT;
        private string mTableName = string.Empty;
        private DataRow mRetRow;

        public FrmDataTreeList() {
            this.InitializeComponent();
        }

        public FrmDataTreeList(FTSMain ftsmain, string tablename) {
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
            this.CheckSecurityBussiess(DataAction.ViewAction);
        }

        public FrmDataTreeList(FTSMain ftsmain, DataSet ds, string tablename, string val) {
            this.mCondition = string.Empty;
            this.mMode = ListMode.SELECT;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mFilterValue = val;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction);
            */ 
        }

        public FrmDataTreeList(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                               bool allowempty) {
            this.mCondition = condition;
            if (this.mCondition == "1=1") {
                this.mCondition = string.Empty;
            }
            this.mMode = ListMode.SELECT;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mFilterValue = val;
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.CreateStatusBar();
            this.LoadData();
            this.ShowInTaskbar = false;
            if (!allowempty) {
                this.toolbar.CloseVisible = BarItemVisibility.Never;
                this.ControlBox = false;
            }
            /*
            this.CheckSecurityBussiess(DataAction.ViewAction); 
            */ 
        }

        public FrmDataTreeList(FTSMain ftsmain, DataTable table) {
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

        public FTSTreeList Tree {
            get { return this.treelist; }
        }

        public virtual void CheckSecurityBussiess(string dataaction)
        {
            this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, dataaction);
        }

        #region 1: Data Methods

        public virtual void BindGrid() {
        }

        public virtual void DeleteRecord() {
            if (this.treelist.FocusedNode != null) {
                this.CheckSecurityBussiess(DataAction.DeleteAction);
                DialogResult dgresultdelete =
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.mFTSMain.MsgManager.GetMessage("MSG_DELETE_RECORD_CONFIRM"));
                if (dgresultdelete == DialogResult.Yes) {
                    object id = this.treelist.FocusedNode.GetValue(this.mDataObject.IdField);
                    this.UpdateDeletedRecord(id);
                }
            }
        }

        public virtual void GetfrmDataEditDetail(bool isnew, object id) {
        }

        public virtual void LoadData() {
        }

        public void NewRecord() {
            this.ShowFormEditor(true);
        }

        public virtual void ShowFormEditor(bool flgnew) {
            if (flgnew) {
                this.CheckSecurityBussiess(DataAction.AddAction);
                this.GetfrmDataEditDetail(true, null);
                this.frmDataEditDetail.ShowDialog();
                this.frmDataEditDetail.Close();
                this.frmDataEditDetail = null;
            } else {
                if (this.treelist.FocusedNode != null) {
                    this.CheckSecurityBussiess(DataAction.EditAction);
                    this.GetfrmDataEditDetail(false, this.treelist.FocusedNode.GetValue(this.mDataObject.IdField));
                    if (this.mMode == ListMode.SELECT) {
                        this.frmDataEditDetail.ShowDialog();
                        this.frmDataEditDetail.Close();
                        this.frmDataEditDetail = null;
                    } else {
                        this.frmDataEditDetail.ShowDialog();
                        this.frmDataEditDetail.Close();
                        this.frmDataEditDetail = null;
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
                FrmDataTreeEditList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataTreeEditList;
                frmdic.Show();
            }
        }

        public void UpdateChangeRecord(DataRow row, bool ischanged) {
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
            this.treelist.RefreshDataSource();
            this.treelist.FocusedNode = this.treelist.FindNodeByKeyID(origrow[this.mDataObject.IdField]);
        }

        public void UpdateDeletedRecord(object id) {
            this.mDataObject.DeleteInData(id);
            this.mDataObject.DataTable.AcceptChanges();
            this.treelist.RefreshDataSource();
        }

        #endregion

        #region 2: Layout Methods

        protected virtual void LayoutTree() {
            foreach (TreeListColumn c in this.treelist.Columns) {
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
            this.SetProductVersion();
        }

        public override void LoadLayout(FTSMain ftsmain) {
            if (this.Mode == ListMode.LIST) {
                this.Name = this.Name + "_LIST";
            }
            base.LoadLayout(ftsmain);
            this.toolbar.LoadLayout(this.mFTSMain);
            this.LayoutTree();
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

        #region 3: Treeview

        #endregion

        #region 4: User Actions

        protected void ConfigAction() {
            if (this.treelist.FocusedNode != null) {
                if (this.treelist.FocusedNode.HasChildren) {
                    this.toolbar.DeleteEnable = false;
                } else {
                    this.toolbar.DeleteEnable = true;
                }
                this.toolbar.EditEnable = true;
                this.toolbar.ChoiceEnable = true;
            } else {
                this.toolbar.DeleteEnable = false;
                this.toolbar.EditEnable = false;
                this.toolbar.ChoiceEnable = false;
            }
        }

        protected void ConfigTree() {
            this.treelist.RootValue = 0;
            this.treelist.CollapseAll();
            this.treelist.Focus();
            this.treelist.OptionsBehavior.Editable = false;
            this.treelist.ChooseNode += new SelectNodeEventHandler(this.treelist_ChooseNode);
            this.treelist.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treelist_FocusedNodeChanged);
        }

        private void treelist_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            this.ConfigAction();
        }

        private void treelist_ChooseNode(object sender, SelectNodeEventArgs e) {
            try {
                if (this.mMode == ListMode.SELECT) {
                    this.mRetRow = e.rowvalue;
                    if (this.mRetRow == null) {
                        this.DialogResult = DialogResult.Cancel;
                    } else {
                        this.DialogResult = DialogResult.OK;
                    }
                } else {
                    this.ShowFormEditor(false);
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            try {
                if (this.WindowState != FormWindowState.Normal) {
                    this.WindowState = FormWindowState.Normal;
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
                    case "Edit":
                        this.ShowFormEditor(false);
                        break;
                    case "Close":
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    case "Choice":
                        if (this.treelist.FocusedNode != null) {
                            this.mRetRow =
                                ((DataRowView) this.treelist.GetDataRecordByNode(this.treelist.FocusedNode)).Row;
                        } else {
                            this.mRetRow = null;
                        }
                        if (this.mRetRow == null) {
                            this.DialogResult = DialogResult.Cancel;
                        } else {
                            this.DialogResult = DialogResult.OK;
                        }
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
                        this.treelist.ExportToXLS();
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

        #endregion

        #region 5: Hand Code

        private void CreateStatusBar() {
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
            ((ISupportInitialize) (barManager)).EndInit();
        }

        #endregion

        #region 6: Override       

        #endregion

        public virtual void SetTextFooter() {
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.treelist, ftsmain, true);
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
            }
        }
    }
}