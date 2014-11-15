// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:51
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmBase2MultiListing.cs
// Project Item Filename:     FrmBase2MultiListing.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmBase2MultiListing : FrmBaseFormGrid {
        private IContainer components = null;
        protected string MODE = "FIND";
        private DataSet mDataSet;
        private List<FieldInfo> mFieldCollection;
        private List<FieldInfo> mFieldCollectionDetail;
        public bool OK;
        public object ReturnTransactionKey;
        private string mTableName;
        private string mTableNameDetail;
        private DataTable mDataTable;
        private DataTable mDataTableDetail;
        private string mSqlQuery;
        private string mSqlQueryDetail;
        protected FTSShadowPanel groupCommand;
        protected FTSButton cmdCancel;
        protected FTSButton cmdFilter;
        protected FTSButton cmdView;
        protected FTSDataGrid gridDetail;
        protected FTSShadowPanel groupFilter;
        protected TreeView treeview;
        private ImageList imageList;
        private ManagerBase mObjectManager;

        public FrmBase2MultiListing() {
            this.InitializeComponent();
        }

        public FrmBase2MultiListing(FTSMain ftsmain, ManagerBase mb, bool dialog) : base(ftsmain, dialog) {
            if (mb == null) {
                this.MODE = "LIST";
            }
            this.mObjectManager = mb;
            this.InitializeComponent();
            this.grid.ViewGrid.OptionsBehavior.Editable = false;
        }

        public DataSet DataSet {
            get { return this.mDataSet; }
            set { this.mDataSet = value; }
        }

        public List<FieldInfo> FieldCollection {
            get { return this.mFieldCollection; }
            set { this.mFieldCollection = value; }
        }

        public List<FieldInfo> FieldCollectionDetail {
            get { return this.mFieldCollectionDetail; }
            set { this.mFieldCollectionDetail = value; }
        }

        public string TableName {
            get { return this.mTableName; }
            set { this.mTableName = value; }
        }

        public string TableNameDetail {
            get { return this.mTableNameDetail; }
            set { this.mTableNameDetail = value; }
        }

        public DataTable DataTable {
            get { return this.mDataTable; }
            set { this.mDataTable = value; }
        }

        public DataTable DataTableDetail {
            get { return this.mDataTableDetail; }
            set { this.mDataTableDetail = value; }
        }

        public string SqlQuery {
            get { return this.mSqlQuery; }
            set { this.mSqlQuery = value; }
        }

        public string SqlQueryDetail {
            get { return this.mSqlQueryDetail; }
            set { this.mSqlQueryDetail = value; }
        }

        public ManagerBase ObjectManager {
            get { return this.mObjectManager; }
            set { this.mObjectManager = value; }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources =
                new System.Resources.ResourceManager(typeof (FrmBase2MultiListing));
            this.groupCommand = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.cmdCancel = new FTS.BaseUI.Controls.FTSButton();
            this.cmdFilter = new FTS.BaseUI.Controls.FTSButton();
            this.cmdView = new FTS.BaseUI.Controls.FTSButton();
            this.gridDetail = new FTS.BaseUI.Controls.FTSDataGrid();
            this.treeview = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupFilter = new FTS.BaseUI.Controls.FTSShadowPanel();
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.groupCommand)).BeginInit();
            this.groupCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.groupFilter)).BeginInit();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupFilter);
            this.groupBox.Controls.Add(this.treeview);
            this.groupBox.Controls.Add(this.groupCommand);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 446);
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.gridDetail);
            this.groupGrid.Location = new System.Drawing.Point(200, 0);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(488, 446);
            this.groupGrid.Controls.SetChildIndex(this.grid, 0);
            this.groupGrid.Controls.SetChildIndex(this.gridDetail, 0);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // grid.EmbeddedNavigator
            // 
            this.grid.EmbeddedNavigator.Name = string.Empty;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(488, 160);
            // 
            // groupCommand
            // 
            this.groupCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupCommand.Controls.Add(this.cmdCancel);
            this.groupCommand.Controls.Add(this.cmdFilter);
            this.groupCommand.Controls.Add(this.cmdView);
            this.groupCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupCommand.Location = new System.Drawing.Point(0, 390);
            this.groupCommand.Name = "groupCommand";
            this.groupCommand.RoundedSize = new System.Drawing.Size(4, 4);
            this.groupCommand.Size = new System.Drawing.Size(200, 56);
            this.groupCommand.TabIndex = 7;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte) (0)),
                                                                                ((System.Byte) (231)),
                                                                                ((System.Byte) (237)),
                                                                                ((System.Byte) (227)));
            this.cmdCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdCancel.Appearance.Options.UseBackColor = true;
            this.cmdCancel.Appearance.Options.UseFont = true;
            this.cmdCancel.Appearance.Options.UseForeColor = true;
            this.cmdCancel.Location = new System.Drawing.Point(129, 16);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(58, 23);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "Bỏ qua";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdFilter
            // 
            this.cmdFilter.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte) (0)),
                                                                                ((System.Byte) (231)),
                                                                                ((System.Byte) (237)),
                                                                                ((System.Byte) (227)));
            this.cmdFilter.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdFilter.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdFilter.Appearance.Options.UseBackColor = true;
            this.cmdFilter.Appearance.Options.UseFont = true;
            this.cmdFilter.Appearance.Options.UseForeColor = true;
            this.cmdFilter.Location = new System.Drawing.Point(13, 16);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(58, 23);
            this.cmdFilter.TabIndex = 24;
            this.cmdFilter.Text = "Lọc";
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_ButtonPressed);
            // 
            // cmdView
            // 
            this.cmdView.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte) (0)), ((System.Byte) (231)),
                                                                              ((System.Byte) (237)),
                                                                              ((System.Byte) (227)));
            this.cmdView.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdView.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdView.Appearance.Options.UseBackColor = true;
            this.cmdView.Appearance.Options.UseFont = true;
            this.cmdView.Appearance.Options.UseForeColor = true;
            this.cmdView.Location = new System.Drawing.Point(71, 16);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(58, 23);
            this.cmdView.TabIndex = 25;
            this.cmdView.Text = "Xem";
            this.cmdView.Click += new System.EventHandler(this.cmdView_ButtonPressed);
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // gridDetail.EmbeddedNavigator
            // 
            this.gridDetail.EmbeddedNavigator.Name = string.Empty;
            this.gridDetail.Location = new System.Drawing.Point(0, 160);
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(488, 286);
            this.gridDetail.TabIndex = 3;
            // 
            // treeview
            // 
            this.treeview.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeview.ImageList = this.imageList;
            this.treeview.Location = new System.Drawing.Point(0, 0);
            this.treeview.Name = "treeview";
            this.treeview.Size = new System.Drawing.Size(200, 224);
            this.treeview.TabIndex = 8;
            this.treeview.Visible = false;
            this.treeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupFilter
            // 
            this.groupFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFilter.Location = new System.Drawing.Point(0, 224);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.RoundedSize = new System.Drawing.Size(4, 4);
            this.groupFilter.Size = new System.Drawing.Size(200, 166);
            this.groupFilter.TabIndex = 9;
            // 
            // FrmBase2MultiListing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 446);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBase2MultiListing";
            this.Text = "Listing";
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.groupCommand)).EndInit();
            this.groupCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.groupFilter)).EndInit();
        }

        #endregion

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

        public FieldInfo GetFieldInfoDetail(string fieldname) {
            for (int i = 0; i < this.mFieldCollectionDetail.Count; i++) {
                if (string.Compare((this.mFieldCollectionDetail[i]).FieldName, fieldname, true) == 0) {
                    return this.mFieldCollectionDetail[i];
                }
            }
            throw (new FTSException("INVALID_FIELD_NAME", new object[] {fieldname}, "Customization", fieldname, -1));
        }

        public virtual void BindGrid() {
        }

        public virtual void BindGridDetail() {
        }

        public new void ConfigGrid() {
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid.ViewGrid.OptionsView.ShowFooter = true;
            this.grid.ViewGrid.OptionsView.ShowDetailButtons = false;
            this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(this.ViewGrid_FocusedRowChanged);
            this.grid.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGrid_FocusedColumnChanged);
            this.grid.ChooseRow += new SelectRowEventHandler(this.grid_ChooseRow);
        }

        protected void ConfigGridDetail() {
            this.gridDetail.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridDetail.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.gridDetail.ViewGrid.OptionsSelection.MultiSelect = false;
            this.gridDetail.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridDetail.ViewGrid.OptionsView.ShowFooter = true;
            this.gridDetail.ViewGrid.FocusedRowChanged +=
                new FocusedRowChangedEventHandler(this.ViewGridDetail_FocusedRowChanged);
            this.gridDetail.ViewGrid.FocusedColumnChanged +=
                new FocusedColumnChangedEventHandler(this.ViewGridDetail_FocusedColumnChanged);
            this.gridDetail.ChooseRow += new SelectRowEventHandler(this.grid_ChooseRow);
        }

        private void grid_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    if (this.MODE == "FIND") {
                        this.OK = true;
                        this.ReturnTransactionKey = row["PR_KEY"];
                        this.Hide();
                    } else {
                        this.LoadTransaction(row["TRAN_ID"].ToString(), row["PR_KEY"]);
                    }
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain,ex);
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

        private void ViewGridDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
            try {
                this.SetDetailTextFooter();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void ViewGridDetail_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
            try {
                this.SetDetailTextFooter();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public virtual void Filter() {
        }

        public virtual void LoadTransaction(string tranid, object key) {
        }

        private void cmdFilter_ButtonPressed(object sender, EventArgs e) {
            try {
                this.Filter();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void cmdView_ButtonPressed(object sender, EventArgs e) {
            try {
                if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                    DataRow row = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
                    if (this.MODE == "FIND") {
                        this.OK = true;
                        this.ReturnTransactionKey = row["PR_KEY"];
                        this.Hide();
                    } else {
                        this.LoadTransaction(row["TRAN_ID"].ToString(), row["PR_KEY"]);
                    }
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) {
            try {
                this.OK = false;
                if (this.MODE == "FIND") {
                    this.Hide();
                } else {
                    this.Close();
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public virtual void SetTextFooter() {
        }

        public virtual void SetDetailTextFooter() {
        }

        protected override void LayoutGrid() {
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName,
                                                                          c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName, 0);
                c.Width = this.FTSMain.GridManager.GetWidth(this.Name, "GRID", c.FieldName);
                c.OptionsColumn.AllowEdit = this.FTSMain.GridManager.IsEnabled(this.Name, "GRID", c.FieldName);
                c.OptionsFilter.AllowFilter = this.FTSMain.GridManager.IsFiltered(this.Name, "GRID", c.FieldName);
            }
            foreach (GridColumn c in this.gridDetail.ViewGrid.Columns) {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDDETAIL", c.FieldName,
                                                                          c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.gridDetail.ViewGrid.Columns) {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDDETAIL", c.FieldName, 0);
                c.Width = this.FTSMain.GridManager.GetWidth(this.Name, "GRIDDETAIL", c.FieldName);
                c.OptionsColumn.AllowEdit = this.FTSMain.GridManager.IsEnabled(this.Name, "GRIDDETAIL", c.FieldName);
                c.OptionsFilter.AllowFilter = this.FTSMain.GridManager.IsFiltered(this.Name, "GRIDDETAIL", c.FieldName);
            }
        }

        //protected override void SaveGridLayout() {

        //        foreach (GridColumn c in this.grid.ViewGrid.Columns) {
        //            int require = 0;
        //            try
        //            {
        //                require = ((IRequire)c).Require?1:0;
        //            }
        //            catch { }
        //            this.FTSMain.GridManager.UpdateConfig(this.Name, "GRID", c.FieldName,
        //                                                    c.OptionsColumn.AllowEdit, c.Visible, c.Width, c.VisibleIndex, require, c.OptionsFilter.AllowFilter);
        //        }
        //        foreach (GridColumn c in this.gridDetail.ViewGrid.Columns) {
        //            int require = 0;
        //            try
        //            {
        //                require = ((IRequire)c).Require?1:0;
        //            }
        //            catch { }
        //            this.FTSMain.GridManager.UpdateConfig(this.Name, "GRIDDETAIL", c.FieldName,
        //                                                    c.OptionsColumn.AllowEdit, c.Visible, c.Width, c.VisibleIndex, require, c.OptionsFilter.AllowFilter);
        //        }

        //}

        #region treeview

        public void SetTreeView(string[] dmlist, string[] fieldlist) {
            this.treeview.Visible = true;
            this.SetTreeNode(dmlist, fieldlist, 0, this.treeview.Nodes);
        }

        private void SetTreeNode(string[] dmlist, string[] fieldlist, int i, TreeNodeCollection nodes) {
            DataTable dt = this.mDataSet.Tables[dmlist[i]];
            foreach (DataRow row in dt.Rows) {
                TreeNode node = new TreeNode(row[this.FTSMain.TableManager.GetNameField(dmlist[i])].ToString(), 0, 1);
                node.Tag = new string[]
                           {dmlist[i], fieldlist[i], row[this.FTSMain.TableManager.GetIDField(dmlist[i])].ToString()};
                nodes.Add(node);
                if (i + 1 < dmlist.Length) {
                    this.SetTreeNode(dmlist, fieldlist, i + 1, node.Nodes);
                }
            }
        }

        private void treeview_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                TreeNode node = e.Node;
                if (this.grid.ViewGrid.RowCount == 0) {
                    this.grid.ViewGrid.ClearColumnsFilter();
                }
                this.FilterNode(node);
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void FilterNode(TreeNode node) {
            string[] nodeinfo = (string[]) node.Tag;
            this.grid.ViewGrid.Columns[nodeinfo[1]].FilterInfo =
                new ColumnFilterInfo("[" + nodeinfo[1] + "] = '" + nodeinfo[2] + "'", string.Empty, nodeinfo[2],
                                     ColumnFilterType.AutoFilter);
            if (node.Parent != null) {
                this.FilterNode(node.Parent);
            }
        }

        #endregion
    }
}