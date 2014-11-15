#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Columns;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle;
using DevExpress.XtraGrid;
#endregion

namespace FTS.BaseUI.Forms {
    public partial class CustomizationForm : XtraForm {
        private ContainerControl frmParent;
        private List<FTSDataGrid> mGridParent = new List<FTSDataGrid>();
        private List<FTSTreeList> mTreeParent = new List<FTSTreeList>();
        private List<GridControl> mGridForGrid = new List<GridControl>();
        private List<GridControl> mGridForTree = new List<GridControl>();
        private List<XtraTabPage> mXtraTabGrid = new List<XtraTabPage>();
        private List<XtraTabPage> mXtraTabTree = new List<XtraTabPage>();
        private DataSet dataSet;
        private FTSMain ftsMain;
        private List<FieldInfo> FieldCollection;
        private DataTable sys_forminfo;

        public CustomizationForm() {
            this.InitializeComponent();
        }

        public CustomizationForm(ContainerControl frmparent, FTSDataGrid gridparent, FTSMain ftsmain) {
            this.ftsMain = ftsmain;
            this.frmParent = frmparent;
            if(gridparent!=null)
                this.mGridParent.Add(gridparent);
            this.InitializeComponent();
            this.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(200, 150);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.CreateTabAndGrid();
            this.LoadData();
            this.CreateStructData();
            this.LoadFields();
            this.BindGrid();
            this.LoadLayout();
            this.LoadInfoControls(this.frmParent);
            this.SetFocusTabPage();
            this.ConfigGrid();
        }
        public CustomizationForm(ContainerControl frmparent, List<FTSDataGrid> gridparent, FTSMain ftsmain, bool tree, bool list)
        {
            this.ftsMain = ftsmain;
            this.frmParent = frmparent;
            this.mGridParent = gridparent;
            this.InitializeComponent();
            this.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(200, 150);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.CreateTabAndGrid();
            this.LoadData();
            this.CreateStructData();
            this.LoadFields();
            this.BindGrid();
            this.LoadLayout();
            this.LoadInfoControls(this.frmParent);
            this.SetFocusTabPage();
            this.ConfigGrid();
        }
        public CustomizationForm(ContainerControl frmparent, FTSTreeList treeparent, FTSMain ftsmain,bool tree) {
            this.ftsMain = ftsmain;
            this.frmParent = frmparent;
            if(treeparent!=null)
                this.mTreeParent.Add(treeparent);
            this.InitializeComponent();
            this.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(200, 150);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.CreateTabAndGrid();
            this.LoadData();
            this.CreateStructData();
            this.LoadFields();
            this.BindGrid();
            this.LoadLayout();
            this.LoadInfoControls(this.frmParent);
            this.SetFocusTabPage();
            this.ConfigGrid();
        }
        public CustomizationForm(ContainerControl frmparent, List<FTSTreeList> treeparent, FTSMain ftsmain,bool tree, bool list)
        {
            this.ftsMain = ftsmain;
            this.frmParent = frmparent;
            this.mTreeParent=treeparent;
            this.InitializeComponent();
            this.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(200, 150);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.CreateTabAndGrid();
            this.LoadData();
            this.CreateStructData();
            this.LoadFields();
            this.BindGrid();
            this.LoadLayout();
            this.LoadInfoControls(this.frmParent);
            this.SetFocusTabPage();
            this.ConfigGrid();
        }
        public CustomizationForm(ContainerControl frmparent, List<FTSDataGrid> gridparent, List<FTSTreeList> treeparent, FTSMain ftsmain)
        {
            this.ftsMain = ftsmain;
            this.frmParent = frmparent;
            this.mGridParent = gridparent;
            this.mTreeParent = treeparent;
            this.InitializeComponent();
            this.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(200, 150);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.CreateTabAndGrid();
            this.LoadData();
            this.CreateStructData();
            this.LoadFields();
            this.BindGrid();
            this.LoadLayout();
            this.LoadInfoControls(this.frmParent);
            this.SetFocusTabPage();
            this.ConfigGrid();
        }
        private void LoadData() {
            this.dataSet = new DataSet("CustomizationForm");
            string sql = "select * from SYS_FORMINFO WHERE FORM_NAME='" + this.frmParent.Name +
                         "' ORDER BY OBJECT_NAME,PROPERTY_NAME";
            this.ftsMain.DbMain.LoadDataSet(this.ftsMain.DbMain.GetSqlStringCommand(sql), this.dataSet, "SYS_FORMINFO");
            this.sys_forminfo = this.dataSet.Tables["sys_forminfo"];
            this.sys_forminfo.PrimaryKey = new DataColumn[] {
                                                                this.sys_forminfo.Columns["OBJECT_NAME"],
                                                                this.sys_forminfo.Columns["PROPERTY_NAME"]
                                                            };
        }
        #region Nhập, xuất cấu hình - hung.pham
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case (Keys.Control | Keys.Shift | Keys.E):
                        ExportConfig();
                        break;
                    case (Keys.Control | Keys.Shift | Keys.I):
                        ImportConfig();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ExportConfig()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Data file (*.xml)|*.xml";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                this.dataSet.WriteXml(sfd.FileName);
            }
        }
        private void ImportConfig()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Data file (*.xml)|*.xml";
            ofd.ShowDialog();
            Application.DoEvents();
            if (ofd.FileName != "")
            {
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\BackupConfig"))
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\BackupConfig");

                this.dataSet.WriteXml(Application.StartupPath + "\\BackupConfig\\" +
                    this.frmParent.Name + DateTime.Now.Year.ToString()
                    + DateTime.Now.Month.ToString()
                    + DateTime.Now.Day.ToString()
                    + DateTime.Now.Hour.ToString()
                    + DateTime.Now.Minute.ToString()
                    + DateTime.Now.Second.ToString()
                    + ".xml");
                DataSet dstemp = new DataSet(this.dataSet.DataSetName);
                foreach (DataTable item in this.dataSet.Tables)
                {
                    dstemp.Tables.Add(item.Clone());
                }
                dstemp.ReadXml(ofd.FileName);
                if (dstemp.Tables["SYS_FORMINFO"].Rows.Count > 0)
                {
                    if (dstemp.Tables["SYS_FORMINFO"].Rows[0]["FORM_NAME"].ToString() != this.frmParent.Name)
                    {
                        MessageBox.Show("Không đúng cấu hình cần import, xin chọn lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Tập tin cấu hình rỗng, xin chọn lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataTable item in dstemp.Tables)
                {
                    if (item.Rows.Count > 0)
                    {
                        if (item.TableName == "SYS_FORMINFO")
                            foreach (DataRow i in item.Rows)
                            {
                                foreach (DataRow dr in this.dataSet.Tables[item.TableName].Rows)
                                {
                                    if (i["FORM_NAME"].ToString() == dr["FORM_NAME"].ToString())
                                        if (i["OBJECT_NAME"].ToString() == dr["OBJECT_NAME"].ToString())
                                            if (i["PROPERTY_NAME"].ToString() == dr["PROPERTY_NAME"].ToString())
                                            {
                                                dr["PROPERTY_VALUE"] = i["PROPERTY_VALUE"];
                                                break;
                                            }
                                }
                            }
                        if (item.TableName == "DataGrid0")
                            foreach (DataRow i in item.Rows)
                            {
                                foreach (DataRow dr in this.dataSet.Tables[item.TableName].Rows)
                                {
                                    if (i["PARENTNAME"].ToString() == dr["PARENTNAME"].ToString())
                                        if (i["NAME"].ToString() == dr["NAME"].ToString())
                                        {
                                            dr["TEXT"] = i["TEXT"];
                                            dr["VISIBLE"] = i["VISIBLE"];
                                            dr["READONLY"] = i["READONLY"];
                                            dr["REQUIRE"] = i["REQUIRE"];
                                            dr["FILTERED"] = i["FILTERED"];
                                            dr["FIXCOLUMN"] = i["FIXCOLUMN"];
                                            dr["ISSUM"] = i["ISSUM"];
                                            dr["SUMTYPE"] = i["SUMTYPE"];
                                            dr["SUMFORMAT"] = i["SUMFORMAT"];
                                            break;
                                        }
                                }
                            }
                        if (item.TableName == "DataForm")
                            foreach (DataRow i in item.Rows)
                            {
                                foreach (DataRow dr in this.dataSet.Tables[item.TableName].Rows)
                                {
                                    if (i["PARENTNAME"].ToString() == dr["PARENTNAME"].ToString())
                                        if (i["NAME"].ToString() == dr["NAME"].ToString())
                                        {
                                            dr["TEXT"] = i["TEXT"];
                                            dr["VISIBLE"] = i["VISIBLE"];
                                            dr["READONLY"] = i["READONLY"];
                                            dr["REQUIRE"] = i["REQUIRE"];
                                            break;
                                        }
                                }
                            }
                    }
                }// end foreach
            }
        }
        #endregion
        private void CreateStructData() {            
            for (int i = 0; i < this.mGridParent.Count; i++)
            {
                DataTable tableGrid = new DataTable("DataGrid" + i.ToString());
                tableGrid.Columns.Add("PARENTNAME", Type.GetType("System.String"));
                tableGrid.Columns.Add("NAME", Type.GetType("System.String"));
                tableGrid.Columns.Add("TEXT", Type.GetType("System.String"));
                tableGrid.Columns.Add("VISIBLE", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("READONLY", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("REQUIRE", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("FILTERED", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("FIXCOLUMN", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("ISSUM", Type.GetType("System.Boolean"));
                tableGrid.Columns.Add("SUMTYPE", Type.GetType("System.String"));
                tableGrid.Columns.Add("SUMFORMAT", Type.GetType("System.String"));
                this.dataSet.Tables.Add(tableGrid);
            }
            for (int i = 0; i < this.mTreeParent.Count; i++)
            {
                DataTable tableTree = new DataTable("DataTree" + i.ToString());
                tableTree.Columns.Add("PARENTNAME", Type.GetType("System.String"));
                tableTree.Columns.Add("NAME", Type.GetType("System.String"));
                tableTree.Columns.Add("TEXT", Type.GetType("System.String"));
                tableTree.Columns.Add("VISIBLE", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("READONLY", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("REQUIRE", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("FILTERED", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("FIXCOLUMN", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("ISSUM", Type.GetType("System.Boolean"));
                tableTree.Columns.Add("SUMTYPE", Type.GetType("System.String"));
                tableTree.Columns.Add("SUMFORMAT", Type.GetType("System.String"));
                this.dataSet.Tables.Add(tableTree);
            }
            DataTable tableForm = new DataTable("DataForm");
            tableForm.Columns.Add("PARENTNAME", Type.GetType("System.String"));
            tableForm.Columns.Add("NAME", Type.GetType("System.String"));
            tableForm.Columns.Add("TEXT", Type.GetType("System.String"));
            tableForm.Columns.Add("VISIBLE", Type.GetType("System.Boolean"));
            tableForm.Columns.Add("READONLY", Type.GetType("System.Boolean"));
            tableForm.Columns.Add("REQUIRE", Type.GetType("System.Boolean"));
            this.dataSet.Tables.Add(tableForm);
        }

        private void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "PARENTNAME",
                                                                               DbType.String, true));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "NAME", DbType.String,
                                                                               true));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "TEXT", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "VISIBLE",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "READONLY",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "REQUIRE",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "FILTERED",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "FIXCOLUMN",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "ISSUM", DbType.Boolean,
                                                                               false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "SUMTYPE", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.ftsMain.FieldManager.CreateFieldInfo("Customization", "SUMFORMAT",
                                                                               DbType.String, false));
        }

        private FieldInfo GetFieldInfo(string fieldname) {
            for (int i = 0; i < this.FieldCollection.Count; i++) {
                if (string.Compare((this.FieldCollection[i]).FieldName, fieldname, true) == 0) {
                    return this.FieldCollection[i];
                }
            }
            throw (new FTSException("INVALID_FIELD_NAME", new object[] {fieldname}, "Customization", fieldname, -1));
        }

        private void BindGrid() {
            int i =0;
            foreach (GridControl grid in this.mGridForGrid)
            {
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("PARENTNAME"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("NAME"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("TEXT"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("VISIBLE"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("READONLY"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("REQUIRE"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("FILTERED"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("FIXCOLUMN"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("ISSUM"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("SUMTYPE"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("SUMFORMAT"));
                grid.DataSource = this.dataSet;
                grid.DataMember = "DataGrid" + i.ToString();
                i++;
            }
            i = 0;
            foreach (GridControl grid in this.mGridForTree)
            {
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("PARENTNAME"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("NAME"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("TEXT"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("VISIBLE"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("READONLY"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("REQUIRE"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("FILTERED"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("FIXCOLUMN"));
                this.SetCheckColumn((GridView)grid.MainView, this.GetFieldInfo("ISSUM"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("SUMTYPE"));
                this.SetTextColumn((GridView)grid.MainView, this.GetFieldInfo("SUMFORMAT"));
                grid.DataSource = this.dataSet;
                grid.DataMember = "DataTree" + i.ToString();
                i++;
            }
            this.SetTextColumn(this.gridViewForm, this.GetFieldInfo("PARENTNAME"));
            this.SetTextColumn(this.gridViewForm, this.GetFieldInfo("NAME"));
            this.SetTextColumn(this.gridViewForm, this.GetFieldInfo("TEXT"));
            this.SetCheckColumn(this.gridViewForm, this.GetFieldInfo("VISIBLE"));
            this.SetCheckColumn(this.gridViewForm, this.GetFieldInfo("READONLY"));
            this.SetCheckColumn(this.gridViewForm, this.GetFieldInfo("REQUIRE"));
            this.GridForForm.DataSource = this.dataSet;
            this.GridForForm.DataMember = "DataForm";
        }

        private void ConfigGrid() {
            foreach (GridControl grid in this.mGridForGrid)
            {
                ((GridView)grid.MainView).OptionsView.ShowGroupPanel = false;
                ((GridView)grid.MainView).OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            }
            foreach (GridControl grid in this.mGridForTree)
            {
                ((GridView)grid.MainView).OptionsView.ShowGroupPanel = false;
                ((GridView)grid.MainView).OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            }
            this.gridViewForm.OptionsView.ShowGroupPanel = false;
            this.gridViewForm.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;            
        }

        private void SetTextColumn(GridView gridview, FieldInfo field) {
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            GridColumn textcolumn = new GridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            textcolumn.Caption = field.FieldName;
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.ColumnEdit = textedit;
            gridview.Columns.Add(textcolumn);
            textedit.Leave += new EventHandler(this.textedit_TextChanged);
        }

        private void SetCheckColumn(GridView gridview, FieldInfo field) {
            RepositoryItemCheckEdit checkedit = new RepositoryItemCheckEdit();
            checkedit.AutoHeight = false;
            checkedit.NullStyle = StyleIndeterminate.Unchecked;
            GridColumn checkcolumn = new GridColumn();
            checkcolumn.Name = field.FieldName;
            checkcolumn.FieldName = field.FieldName;
            checkcolumn.Caption = field.FieldName;
            checkcolumn.AppearanceHeader.Options.UseTextOptions = true;
            checkcolumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            checkcolumn.OptionsColumn.AllowDragInVisible = false;
            checkcolumn.ColumnEdit = checkedit;
            gridview.Columns.Add(checkcolumn);
            checkedit.CheckedChanged += new EventHandler(this.checkedit_CheckedChanged);
        }

        private void LoadInfoControls(Control control) {
            if (control is FTSGroupBox || control is FTSStatus || control is FTSShadowPanel || control is FTSShadowPanel2 || control is Form || control is UserControl ||
                control is WizardPage || control is XtraTabPage || control is XtraTabControl) {
                DataRow row = this.dataSet.Tables["DataForm"].NewRow();
                row["ParentName"] = this.frmParent.Name.ToUpper();
                row["Name"] = control.Name;
                row["Text"] = control.Text;
                row["Visible"] = this.GetVisible(control.Name.ToUpper(), control.Visible);
                row["ReadOnly"] = !control.Enabled;
                row["Require"] = false;
                this.dataSet.Tables["DataForm"].Rows.Add(row);
                this.dataSet.Tables["DataForm"].AcceptChanges();
                foreach (Control ctrl in control.Controls) {
                    this.LoadInfoControls(ctrl);
                }
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.LoadInfoControls(ctrl);
                    }
                }
            } else if (control is FTSDataGrid) {
                int i =-1;
                foreach (FTSDataGrid gridparent in this.mGridParent)
                {
                    i++;
                    if (control.Name.ToUpper() == gridparent.Name.ToUpper())
                        break;                    
                }
                if (i >= 0)
                {
                    FTSDataGrid grid = (FTSDataGrid)control;
                    foreach (GridColumn column in (grid.ViewGrid).Columns)
                    {
                        DataRow row = this.dataSet.Tables["DataGrid"+i.ToString()].NewRow();
                        row["ParentName"] = grid.Name.ToUpper();
                        row["Name"] = column.Name;
                        row["Text"] = column.Caption;
                        row["Visible"] = (column.VisibleIndex <= -1) ? false : true;
                        row["ReadOnly"] = !column.OptionsColumn.AllowEdit;
                        row["filtered"] = column.OptionsFilter.AllowFilter;
                        try
                        {
                            row["Require"] = ((IRequire)column).Require;
                        }
                        catch
                        {
                            row["Require"] = false;
                        }
                        row["fixcolumn"] = column.Fixed == FixedStyle.None ? false : true;
                        row["issum"] = column.SummaryItem.SummaryType == SummaryItemType.None ? false : true;
                        if (column.SummaryItem.SummaryType != SummaryItemType.None)
                        {
                            row["SUMTYPE"] = UIFunctions.GetSumType(column.SummaryItem.SummaryType);
                        }
                        this.dataSet.Tables["DataGrid"+i.ToString()].Rows.Add(row);
                        this.dataSet.Tables["DataGrid"+i.ToString()].AcceptChanges();
                    }
                }
            } else if (control is FTSTreeList) {
                int i =-1;
                foreach (FTSTreeList treeparent in this.mTreeParent)
                {
                    i++;
                    if (control.Name.ToUpper() == treeparent.Name.ToUpper())
                        break;                    
                }
                if (i >= 0)
                {
                    FTSTreeList tree = (FTSTreeList)control;
                    foreach (TreeListColumn column in tree.Columns)
                    {
                        DataRow row = this.dataSet.Tables["DataTree" + i.ToString()].NewRow();
                        row["ParentName"] = tree.Name.ToUpper();
                        row["Name"] = column.Name;
                        row["Text"] = column.Caption;
                        row["Visible"] = (column.VisibleIndex <= -1) ? false : true;
                        row["ReadOnly"] = !column.OptionsColumn.AllowEdit;
                        row["filtered"] = true;
                        row["Require"] = false;
                        row["fixcolumn"] = column.Fixed == DevExpress.XtraTreeList.Columns.FixedStyle.None
                                               ? false
                                               : true;
                        row["issum"] = column.SummaryFooter == DevExpress.XtraTreeList.SummaryItemType.None
                                           ? false
                                           : true;
                        if (column.SummaryFooter != DevExpress.XtraTreeList.SummaryItemType.None)
                        {
                            row["SUMTYPE"] = UIFunctions.GetSumType(column.SummaryFooter);
                        }
                        this.dataSet.Tables["DataTree" + i.ToString()].Rows.Add(row);
                        this.dataSet.Tables["DataTree" + i.ToString()].AcceptChanges();
                    }
                }
            } else if ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSDateCom) ||
                       (control is FTSTextCom) || (control is FTSNumericCom) || (control is FTSReadOnlyNumericCom) ||
                       (control is FTSNameIDCom) || (control is FTSSingleComboCom) || (control is FTSVatCom) ||
                        (control is FTSMemoCom) || (control is FTSPictureCom) || (control is FTSMRUEditCom) ||
						(control is FTSLabel) || (control is FTSUpDownCom) || (control is FTSRadioButton) || (control is FTSButton) ||
                       (control is FTSColorCom) || (control is FTSTranNumCom) || (control is FTSCalculatorCom) ||
                       (control is FTSPercentCom) || (control is FTSHourMinuteCom) || (control is FTSFreeComboCom)) {
                DataRow row = this.dataSet.Tables["DataForm"].NewRow();
                row["ParentName"] = this.frmParent.Name.ToUpper();
                row["Name"] = control.Name;
                row["Text"] = control.Text;
                row["Visible"] = this.GetVisible(control.Name.ToUpper(), control.Visible);
                row["ReadOnly"] = !control.Enabled;
                try {
                    row["Require"] = ((IRequire) control).Require;
                } catch {
                    row["Require"] = false;
                }
                this.dataSet.Tables["DataForm"].Rows.Add(row);
                this.dataSet.Tables["DataForm"].AcceptChanges();
            }
        }

        private void SetInfoControls(Control control, DataRow row) {
            if (control is FTSGroupBox || control is FTSStatus || control is FTSShadowPanel || control is FTSShadowPanel2 || control is Form || control is UserControl ||
                control is WizardPage || control is XtraTabPage || control is XtraTabControl) {
                if (control.Name == Convert.ToString(row["Name"])) {
                    if (!(control is Form || control is UserControl)) {
                        control.Visible = Convert.ToBoolean(row["Visible"]);
                        control.Enabled = !Convert.ToBoolean(row["ReadOnly"]);
                        control.Text = row["text"].ToString();
                        IRequire ir = control as IRequire;
                        if (ir != null) {
                            ir.Require = Convert.ToBoolean(row["Require"]);
                        }
                        string controlname = control.Name.ToUpper();
                        this.UpdateProperty(controlname, "VISIBLE", "BOOLEAN",
                                            (string) FunctionsBase.IIF(Convert.ToBoolean(row["Visible"]), "1", "0"));
                        this.UpdateProperty(controlname, "ENABLED", "BOOLEAN",
                                            (string) FunctionsBase.IIF(Convert.ToBoolean(row["ReadOnly"]), "0", "1"));
                        this.UpdateTextProperty(controlname, "TEXT", "STRING", row["text"].ToString());
                        if (control is IRequire) {
                            this.UpdateProperty(controlname, "REQUIRE", "BOOLEAN",
                                                (string) FunctionsBase.IIF(Convert.ToBoolean(row["ReadOnly"]), "0", "1"));
                        }
                    } else {
                        string controlname = control.Name.ToUpper();
                        this.UpdateTextProperty(controlname, "TEXT", "STRING", row["text"].ToString());
                    }
                }
                if (control is XtraTabControl) {
                    foreach (Control ctrl in ((XtraTabControl) control).TabPages) {
                        this.SetInfoControls(ctrl, row);
                    }
                }
                foreach (Control ctrl in control.Controls) {
                    this.SetInfoControls(ctrl, row);
                }
            } else if (control is FTSDataGrid) {
                int i =-1;
                foreach (XtraTabPage xtraTabGrid in this.mXtraTabGrid)
                {
                    i++;
                    if (this.xtraTab.SelectedTabPage.Name == xtraTabGrid.Name)
                        break;                    
                }
                if (i >= 0)
                {
                    FTSDataGrid grid = (FTSDataGrid)control;
                    foreach (GridColumn column in (grid.ViewGrid).Columns)
                    {
                        if (column.Name == Convert.ToString(row["Name"]))
                        {
                            if (((column.VisibleIndex >= 0) ? 0 : -1) != ((Convert.ToBoolean(row["Visible"])) ? 0 : -1))
                            {
                                column.VisibleIndex = (Convert.ToBoolean(row["Visible"])) ? column.AbsoluteIndex : -1;
                            }
                            column.OptionsColumn.AllowEdit = !Convert.ToBoolean(row["ReadOnly"]);
                            column.OptionsFilter.AllowFilter = Convert.ToBoolean(row["FILTERED"]);
                            column.Caption = row["text"].ToString();
                            this.UpdateGridTextProperty(i,row["NAME"].ToString(), row["text"].ToString());
                            try
                            {
                                ((IRequire)column).Require = Convert.ToBoolean(row["Require"]);
                                if (((IRequire)column).Require)
                                {
                                    column.AppearanceCell.BackColor = SystemColors.Info;
                                    column.AppearanceCell.Options.UseBackColor = true;
                                }
                                else
                                {
                                    column.AppearanceCell.BackColor = Color.White;
                                    column.AppearanceCell.Options.UseBackColor = true;
                                }
                            }
                            catch
                            {
                            }
                            if (Convert.ToBoolean(row["FIXCOLUMN"]))
                            {
                                column.Fixed = FixedStyle.Left;
                            }
                            else
                            {
                                column.Fixed = FixedStyle.None;
                            }
                            if (Convert.ToBoolean(row["ISSUM"]))
                            {
                                grid.SetSummary(column, row["SUMTYPE"].ToString());
                            }
                            else
                            {
                                grid.ClearSummary(column);
                            }
                        }
                    }
                }
            } else if (control is FTSTreeList) {
                int i = -1;
                foreach (XtraTabPage xtraTabTree in this.mXtraTabTree)
                {
                    i++;
                    if (this.xtraTab.SelectedTabPage.Name == xtraTabTree.Name)
                        break;
                }
                if (i >= 0)
                {
                    FTSTreeList tree = (FTSTreeList)control;
                    foreach (TreeListColumn column in tree.Columns)
                    {
                        if (column.Name == Convert.ToString(row["Name"]))
                        {
                            if (((column.VisibleIndex >= 0) ? 0 : -1) != ((Convert.ToBoolean(row["Visible"])) ? 0 : -1))
                            {
                                column.VisibleIndex = (Convert.ToBoolean(row["Visible"])) ? column.AbsoluteIndex : -1;
                            }
                            column.OptionsColumn.AllowEdit = !Convert.ToBoolean(row["ReadOnly"]);
                            column.Caption = row["text"].ToString();
                            this.UpdateTreeTextProperty(i,row["NAME"].ToString(), row["text"].ToString());
                            try
                            {
                                ((IRequire)column).Require = Convert.ToBoolean(row["Require"]);
                                if (((IRequire)column).Require)
                                {
                                    column.AppearanceCell.BackColor = SystemColors.Info;
                                    column.AppearanceCell.Options.UseBackColor = true;
                                }
                                else
                                {
                                    column.AppearanceCell.BackColor = Color.White;
                                    column.AppearanceCell.Options.UseBackColor = true;
                                }
                            }
                            catch
                            {
                            }
                            if (Convert.ToBoolean(row["FIXCOLUMN"]))
                            {
                                column.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                            }
                            else
                            {
                                column.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.None;
                            }
                            if (Convert.ToBoolean(row["ISSUM"]))
                            {
                                tree.SetSummary(column, row["SUMTYPE"].ToString());
                            }
                            else
                            {
                                tree.ClearSummary(column);
                            }
                        }
                    }
                }
            } else if ((this.xtraTab.SelectedTabPage.Name == this.xtraTabForm.Name) &&
                       ((control is FTSCheckCom) || (control is FTSComboCom) || (control is FTSDateCom) ||
                        (control is FTSTextCom) || (control is FTSNumericCom) || (control is FTSReadOnlyNumericCom) ||
                        (control is FTSNameIDCom) || (control is FTSButton) || (control is FTSSingleComboCom) || (control is FTSMRUEditCom) ||
                        (control is FTSMemoCom) || (control is FTSPictureCom) || (control is FTSLabel) || (control is FTSUpDownCom) || (control is FTSRadioButton) ||
                        (control is FTSColorCom) || (control is FTSTranNumCom) || (control is FTSCalculatorCom) || (control is FTSVatCom) ||
                        (control is FTSPercentCom) || (control is FTSHourMinuteCom) || (control is FTSFreeComboCom))) {
                if (control.Name == Convert.ToString(row["Name"])) {
                    control.Visible = Convert.ToBoolean(row["Visible"]);
                    control.Enabled = !Convert.ToBoolean(row["ReadOnly"]);
                    control.Text = row["text"].ToString();
                    IRequire ir = control as IRequire;
                    if (ir != null) {
                        ir.Require = Convert.ToBoolean(row["Require"]);
                    }
                    string controlname = control.Name.ToUpper();
                    this.UpdateProperty(controlname, "VISIBLE", "BOOLEAN",
                                        (string) FunctionsBase.IIF(Convert.ToBoolean(row["Visible"]), "1", "0"));
                    this.UpdateProperty(controlname, "ENABLED", "BOOLEAN",
                                        (string) FunctionsBase.IIF(Convert.ToBoolean(row["ReadOnly"]), "0", "1"));
                    this.UpdateTextProperty(controlname, "TEXT", "STRING", row["text"].ToString());
                    if (control is IRequire) {
                        this.UpdateProperty(controlname, "REQUIRE", "BOOLEAN",
                                            (string) FunctionsBase.IIF(Convert.ToBoolean(row["require"]), "1", "0"));
                    }
                }
            }
        }

        public void UpdateProperty(string objectname, string propertyname, string propertytype, string propertyvalue) {
            DataRow foundrow = this.sys_forminfo.Rows.Find(new object[] {objectname, propertyname});
            if (foundrow != null) {
                foundrow["property_value"] = propertyvalue;
            } else {
                foundrow = this.sys_forminfo.NewRow();
                foundrow["PR_KEY"] = FunctionsBase.GetPr_key("sys_forminfo", this.ftsMain);
                foundrow["form_name"] = this.frmParent.Name.ToUpper();
                foundrow["object_name"] = objectname;
                foundrow["property_name"] = propertyname;
                foundrow["property_value"] = propertyvalue;
                foundrow["property_type"] = propertytype;
                this.sys_forminfo.Rows.Add(foundrow);
            }
        }

        public void UpdateTextProperty(string objectname, string propertyname, string propertytype, string propertyvalue) {
            this.ftsMain.FormManager.UpdateObjectProperty(this.frmParent.Name.ToUpper(), objectname, propertyname,
                                                          propertytype, propertyvalue);
        }

        public void UpdateGridTextProperty(int index, string columnname, string propertyvalue) {            
                this.ftsMain.GridManager.SetDisplayName(this.frmParent.Name.ToUpper(), this.mGridParent[index].Name.ToUpper(),
                                                        columnname, propertyvalue);            
        }

        public void UpdateTreeTextProperty(int index, string columnname, string propertyvalue)
        {
            this.ftsMain.GridManager.SetDisplayName(this.frmParent.Name.ToUpper(), this.mTreeParent[index].Name.ToUpper(),
                                                    columnname, propertyvalue);
        }
        private void LoadLayout() {
            foreach (GridControl grid in this.mGridForGrid)
            {
                foreach (GridColumn c in ((GridView)grid.MainView).Columns)
                {
                    if (string.Compare(c.FieldName, "NAME", true) == 0)
                    {
                        c.Visible = true;
                        c.OptionsColumn.AllowEdit = false;
                    }
                    else if (string.Compare(c.FieldName, "PARENTNAME", true) == 0)
                    {
                        c.Visible = false;
                        c.OptionsColumn.AllowEdit = false;
                    }
                    else if (string.Compare(c.FieldName, "TEXT", true) == 0)
                    {
                        c.OptionsColumn.AllowEdit = true;
                        c.Visible = true;
                    }
                    else
                    {
                        c.Visible = true;
                    }
                }
            }

            foreach (GridControl grid in this.mGridForTree)
            {
                foreach (GridColumn c in ((GridView)grid.MainView).Columns)
                {
                    if (string.Compare(c.FieldName, "NAME", true) == 0)
                    {
                        c.Visible = true;
                        c.OptionsColumn.AllowEdit = false;
                    }
                    else if (string.Compare(c.FieldName, "PARENTNAME", true) == 0)
                    {
                        c.Visible = false;
                        c.OptionsColumn.AllowEdit = false;
                    }
                    else if (string.Compare(c.FieldName, "TEXT", true) == 0)
                    {
                        c.OptionsColumn.AllowEdit = true;
                        c.Visible = true;
                    }
                    else
                    {
                        c.Visible = true;
                    }
                }
            }

            foreach (GridColumn c in this.gridViewForm.Columns) {
                if (string.Compare(c.FieldName, "NAME", true) == 0) {
                    c.Visible = true;
                    c.OptionsColumn.AllowEdit = false;
                } else if (string.Compare(c.FieldName, "PARENTNAME", true) == 0) {
                    c.Visible = false;
                    c.OptionsColumn.AllowEdit = false;
                } else if (string.Compare(c.FieldName, "TEXT", true) == 0) {
                    c.Visible = true;
                } else {
                    c.Visible = true;
                }
            }
        }

        public void ShowCustomization(Point location) {
            if (location.X == -10000) {
                location =
                    this.frmParent.PointToScreen(new Point(this.frmParent.ClientRectangle.Right,
                                                           this.frmParent.ClientRectangle.Bottom));
                location.Offset(-this.Size.Width, -this.Size.Height);
                location = ControlUtils.CalcLocation(location, location, this.Size);
            }
            if (location.X < 0) {
                location.X = 0;
            }
            if (location.Y < 0) {
                location.Y = 0;
            }
            this.Location = location;
            this.Visible = true;
            this.frmParent.Focus();
        }

        private void SetFocusTabPage() {
            int i = 0;
            bool flag = false;
            foreach (XtraTabPage xtraTabGrid in this.mXtraTabGrid)
            {
                if (this.dataSet.Tables["DataGrid" + i.ToString()].Rows.Count > 0)
                {
                    this.xtraTab.SelectedTabPage = xtraTabGrid;
                    flag = true;
                }
                else
                {
                    xtraTabGrid.PageVisible = false;
                }
                i++;
            }
            i = 0;
            foreach (XtraTabPage xtraTabTree in this.mXtraTabTree)
            {
                if (this.dataSet.Tables["DataTree" + i.ToString()].Rows.Count > 0)
                {
                    if (!flag)
                    {
                        this.xtraTab.SelectedTabPage = xtraTabTree;
                        flag = true;
                    }
                }
                else
                {
                    xtraTabTree.PageVisible = false;
                }
                i++;
            }
            if (this.dataSet.Tables["DataForm"].Rows.Count > 0)
            {
                if (!flag)
                    this.xtraTab.SelectedTabPage = this.xtraTabForm;
            }
            else
            {
                this.xtraTabForm.PageVisible = false;
            }            
        }

        private void EndEdit() {            
            foreach (GridControl grid in this.mGridForGrid)
            {
                ColumnView viewgrid = (GridView)grid.MainView;
                viewgrid.CloseEditor();
                viewgrid.UpdateCurrentRow();                
            }
            foreach (GridControl grid in this.mGridForTree)
            {
                ColumnView viewgrid = (GridView)grid.MainView;
                viewgrid.CloseEditor();
                viewgrid.UpdateCurrentRow();
            }
            ColumnView viewform = this.gridViewForm;
            viewform.CloseEditor();
            viewform.UpdateCurrentRow();
            for (int i = 0; i < this.mGridParent.Count; i++)
            {
                foreach (DataRow row in this.dataSet.Tables["DataGrid"+i.ToString()].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        row.EndEdit();
                    }
                }
            }
            for (int i = 0; i < this.mTreeParent.Count; i++)
            {
                foreach (DataRow row in this.dataSet.Tables["DataTree" + i.ToString()].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        row.EndEdit();
                    }
                }
            }
            foreach (DataRow row in this.dataSet.Tables["DataForm"].Rows) {
                if (row.RowState != DataRowState.Deleted) {
                    row.EndEdit();
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            this.SaveCustomization();
        }

        private void checkedit_CheckedChanged(object sender, EventArgs e) {
            int i = 0;
            foreach (XtraTabPage xtraTabGrid in this.mXtraTabGrid)
            {
                if ((this.xtraTab.SelectedTabPage.Name == xtraTabGrid.Name) &&
                    (((GridView)this.mGridForGrid[i].MainView).FocusedRowHandle >= 0))
                {
                    this.EndEdit();
                    this.SetInfoControls(this.mGridParent[i], ((GridView)this.mGridForGrid[i].MainView).GetDataRow(((GridView)this.mGridForGrid[i].MainView).FocusedRowHandle));
                }
                i++;
            }
            i = 0;
            foreach (XtraTabPage xtraTabTree in this.mXtraTabTree)
            {
                if ((this.xtraTab.SelectedTabPage.Name == xtraTabTree.Name) &&
                    (((GridView)this.mGridForTree[i].MainView).FocusedRowHandle >= 0))
                {
                    this.EndEdit();
                    this.SetInfoControls(this.mTreeParent[i], ((GridView)this.mGridForTree[i].MainView).GetDataRow(((GridView)this.mGridForTree[i].MainView).FocusedRowHandle));
                }
                i++;
            }
            if ((this.xtraTab.SelectedTabPage.Name == this.xtraTabForm.Name) &&
                (this.gridViewForm.FocusedRowHandle >= 0)) {
                this.EndEdit();
                this.SetInfoControls(this.frmParent, this.gridViewForm.GetDataRow(this.gridViewForm.FocusedRowHandle));
            }
        }

        private void textedit_TextChanged(object sender, EventArgs e) {
            int i = 0;
            foreach (XtraTabPage xtraTabGrid in this.mXtraTabGrid)
            {
                if ((this.xtraTab.SelectedTabPage.Name == xtraTabGrid.Name) &&
                    (((GridView)this.mGridForGrid[i].MainView).FocusedRowHandle >= 0))
                {
                    this.EndEdit();
                    this.SetInfoControls(this.mGridParent[i], ((GridView)this.mGridForGrid[i].MainView).GetDataRow(((GridView)this.mGridForGrid[i].MainView).FocusedRowHandle));
                }
                i++;
            }
            i = 0;
            foreach (XtraTabPage xtraTabTree in this.mXtraTabTree)
            {
                if ((this.xtraTab.SelectedTabPage.Name == xtraTabTree.Name) &&
                    (((GridView)this.mGridForTree[i].MainView).FocusedRowHandle >= 0))
                {
                    this.EndEdit();
                    this.SetInfoControls(this.mTreeParent[i], ((GridView)this.mGridForTree[i].MainView).GetDataRow(((GridView)this.mGridForTree[i].MainView).FocusedRowHandle));
                }
                i++;
            }
            if ((this.xtraTab.SelectedTabPage.Name == this.xtraTabForm.Name) &&
                (this.gridViewForm.FocusedRowHandle >= 0))
            {
                this.EndEdit();
                this.SetInfoControls(this.frmParent, this.gridViewForm.GetDataRow(this.gridViewForm.FocusedRowHandle));
            }
        }

        private void SaveCustomization() {
            string sql = "INSERT INTO SYS_FORM VALUES('" + this.frmParent.Name + "','" + this.frmParent.Name + "','" +
                         this.frmParent.Name + "',1,1,'ADMIN')";
            try {
                this.ftsMain.DbMain.ExecuteNonQuery(this.ftsMain.DbMain.GetSqlStringCommand(sql));
            } catch (Exception) {
            }
            if (this.ftsMain.DbMain.WorkingMode == WorkingMode.LAN && this.ftsMain.UserInfo.UserGroupID == "ADMIN") {
                if (this.sys_forminfo.GetChanges() != null) {
                    this.ftsMain.DbMain.UpdateTable(this.sys_forminfo,
                                                    this.ftsMain.DbMain.CreateInsertCommand("sys_forminfo",
                                                                                            this.sys_forminfo),
                                                    this.ftsMain.DbMain.CreateUpdateCommand("sys_forminfo",
                                                                                            this.sys_forminfo, "PR_KEY"),
                                                    null, UpdateBehavior.Standard);
                }
            }
            Functions.ClearTable(this.sys_forminfo);
        }

        private string GetTextProperty(string controlname) {
            DataRow foundrow = this.sys_forminfo.Rows.Find(new object[] {controlname, "TEXT"});
            return foundrow != null ? foundrow["PROPERTY_VALUE"].ToString() : string.Empty;
        }

        private bool GetVisible(string controlname, bool visible) {
            DataRow foundrow = this.sys_forminfo.Rows.Find(new object[] {controlname, "VISIBLE"});
            if (foundrow != null) {
                return foundrow["PROPERTY_VALUE"].ToString() == "1" ? true : false;
            } else {
                return visible;
            }
        }

        private void CreateTabAndGrid()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationForm));
            for (int i = 0; i < this.mGridParent.Count; i++)
            {                
                 DevExpress.XtraTab.XtraTabPage xtraTabGrid = new DevExpress.XtraTab.XtraTabPage();
                 DevExpress.XtraGrid.GridControl GridForGrid = new DevExpress.XtraGrid.GridControl();
                 DevExpress.XtraGrid.Views.Grid.GridView gridViewGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
                 this.mXtraTabGrid.Add(xtraTabGrid);
                 this.mGridForGrid.Add(GridForGrid);
                 xtraTabGrid.SuspendLayout();
                 ((System.ComponentModel.ISupportInitialize)(GridForGrid)).BeginInit();
                 ((System.ComponentModel.ISupportInitialize)(gridViewGrid)).BeginInit();
                 this.xtraTab.TabPages.Add(xtraTabGrid);                
                 xtraTabGrid.Controls.Add(GridForGrid);
                 xtraTabGrid.Image = ((System.Drawing.Image)(resources.GetObject("column")));
                 xtraTabGrid.Name = "xtraTabGrid" + i.ToString();
                 xtraTabGrid.Size = new System.Drawing.Size(685, 413);
                 xtraTabGrid.Text = "Grid " + i.ToString() ;                
                 GridForGrid.Dock = System.Windows.Forms.DockStyle.Fill;
                 GridForGrid.Location = new System.Drawing.Point(0, 0);
                 GridForGrid.MainView = gridViewGrid;
                 GridForGrid.Name = "GridForGrid";
                 GridForGrid.Size = new System.Drawing.Size(685, 413);
                 GridForGrid.TabIndex = 0;
                 GridForGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {gridViewGrid});                  
                 gridViewGrid.GridControl = GridForGrid;
                 gridViewGrid.Name = "gridViewGrid" + i.ToString();
                 gridViewGrid.OptionsView.ShowAutoFilterRow = true;
                 xtraTabGrid.ResumeLayout(false);
                 ((System.ComponentModel.ISupportInitialize)(GridForGrid)).EndInit();
                 ((System.ComponentModel.ISupportInitialize)(gridViewGrid)).EndInit();
            }
            for (int i = 0; i < this.mTreeParent.Count; i++)
            {
                DevExpress.XtraTab.XtraTabPage xtraTabTree = new DevExpress.XtraTab.XtraTabPage();
                DevExpress.XtraGrid.GridControl GridForTree = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView gridViewTree = new DevExpress.XtraGrid.Views.Grid.GridView();
                this.mXtraTabTree.Add(xtraTabTree);
                this.mGridForTree.Add(GridForTree);
                xtraTabTree.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(GridForTree)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(gridViewTree)).BeginInit();
                this.xtraTab.TabPages.Add(xtraTabTree);
                xtraTabTree.Controls.Add(GridForTree);
                xtraTabTree.Image = ((System.Drawing.Image)(resources.GetObject("node-tree")));
                xtraTabTree.Name = "xtraTabTree" + i.ToString();
                xtraTabTree.Size = new System.Drawing.Size(685, 413);
                xtraTabTree.Text = "Tree " + i.ToString();
                GridForTree.Dock = System.Windows.Forms.DockStyle.Fill;
                GridForTree.Location = new System.Drawing.Point(0, 0);
                GridForTree.MainView = gridViewTree;
                GridForTree.Name = "GridForTree";
                GridForTree.Size = new System.Drawing.Size(685, 413);
                GridForTree.TabIndex = 0;
                GridForTree.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewTree });
                gridViewTree.GridControl = GridForTree;
                gridViewTree.Name = "gridViewTree" + i.ToString();
                gridViewTree.OptionsView.ShowAutoFilterRow = true;
                xtraTabTree.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(GridForTree)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(gridViewTree)).EndInit();
            }
        }
    }
}