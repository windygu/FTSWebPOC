using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using FTS.BaseUI.Controls;
using DevExpress.Data;
using FTS.BaseUI.Utilities;

namespace FTS.BaseUI.Forms
{
    public partial class FrmCheck_Data_Log : FrmBaseForm
    {
        private DataTable mDataTable;

        public FrmCheck_Data_Log()
        {
            InitializeComponent();
        }

        public FrmCheck_Data_Log(FTSMain ftsmain):base(ftsmain)
        {            
            InitializeComponent();
            //this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            this.LoadData();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);
        }
        private void LoadData()
        {
            mDataTable = new DataTable("CHECK_DATA_LOG");
            mDataTable.Columns.Add("WORKSTATION_ID", Type.GetType("System.Int32"));
            mDataTable.Columns.Add("COUNT_RECORD", Type.GetType("System.Int32"));
            mDataTable.Columns.Add("BUTTON_DETAIL", Type.GetType("System.String"));
            for(int i =1;i<=100;i++)
            {
                string sql = "select count(*) as COUNT_RECORD from DATA_LOG where substring(IS_DOWNLOAD," + i.ToString() + ",1) = '0'";
                object result = this.FTSMain.DbMain.ExecuteScalar(this.FTSMain.DbMain.GetSqlStringCommand(sql));
                if ((result != null) && (result != DBNull.Value))
                {
                    if (System.Convert.ToInt32(result) > 0)
                    {
                        this.mDataTable.Rows.Add(new object[] { i, result,"Chi tiết"});
                    }
                }
            }
            this.mDataTable.AcceptChanges();
        }
        private void BindGrid()
        {            
            this.grid.CreateGrid(this.mDataTable);
            this.grid.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("CHECK_DATA_LOG","WORKSTATION_ID", DbType.Int32,true),0);
            this.grid.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("CHECK_DATA_LOG", "COUNT_RECORD", DbType.Int32, false), 0);
            this.grid.SetButton(this.FTSMain.FieldManager.CreateFieldInfo("CHECK_DATA_LOG", "BUTTON_DETAIL", DbType.String, false), "Chi tiết");
            this.grid.BindDataTable();
        }
        private void ConfigGrid()
        {
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = true;
            this.grid.ViewGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid.ViewGrid.OptionsView.EnableAppearanceEvenRow = false;
            this.grid.ViewGrid.OptionsView.EnableAppearanceOddRow = false;
            this.grid.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.grid.ViewGrid.OptionsView.ShowFooter = false;
            this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grid.AllowSortColumns = false;
            this.grid.ButtonClick += new ButtonClickEventHandler(grid_ButtonClick);
            this.grid.SetIndicatorWidth(this.mDataTable.Rows.Count);
        }

        private void grid_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            try
            {
                if (e.Row >= 0)
                {
                    DataRow row = this.grid.ViewGrid.GetDataRow(e.Row);
                    if (row != null)
                    {
                        FrmData_Log_EditList frmdatalog = new FrmData_Log_EditList(this.FTSMain, System.Convert.ToInt32(row["WORKSTATION_ID"]));
                        frmdatalog.Show();
                    }
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }
        protected virtual void LayoutGrid()
        {
            int visibleindex = 0;
            foreach (GridColumn c in this.grid.ViewGrid.Columns)
            {
                c.VisibleIndex = visibleindex;
                visibleindex++;
            }
            visibleindex = 0;
            foreach (GridColumn c in this.grid.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
                c.VisibleIndex = visibleindex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.grid.SetSummary(c, cinfo.SumType);
                }
                IRequire ir = c as IRequire;
                if (ir != null)
                {
                    ir.Require = cinfo.Require;
                    if (ir.Require)
                    {
                        c.AppearanceCell.BackColor = SystemColors.Info;
                        c.AppearanceCell.Options.UseBackColor = true;
                    }
                }
                visibleindex++;
            }
            if (this.FTSMain.Language == Language.JP || FTSMain.Language == Language.LAOS)
            {
                this.grid.SetFont();
            }
        }
        protected virtual void SaveGridLayout()
        {
            if (this.FTSMain.DbMain.WorkingMode == Microsoft.Practices.EnterpriseLibrary.Data.WorkingMode.LAN)
            {
                foreach (GridColumn c in this.grid.ViewGrid.Columns)
                {
                    IRequire ir = c as IRequire;
                    bool isrequired = true;
                    int require = 0;
                    if (ir != null)
                    {
                        require = ir.Require ? 1 : 0;
                        isrequired = ir.Require ? true : false;
                    }
                    string summarytype = string.Empty;
                    string summaryformat = string.Empty;
                    bool issummary = c.SummaryItem.SummaryType == SummaryItemType.None ? false : true;
                    bool fixcolumn = c.Fixed == FixedStyle.Left ? true : false;
                    if (issummary)
                    {
                        summarytype = UIFunctions.GetSumType(c.SummaryItem.SummaryType);
                    }
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRID", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }
            }
        }
        public override void SaveLayout(FTSMain ftsmain)
        {
            base.SaveLayout(ftsmain);
            this.SaveGridLayout();
        }
        public override void LoadLayout(FTSMain ftsmain)
        {
            base.LoadLayout(ftsmain);
            this.LayoutGrid();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {                
                if (this.WindowState != FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                this.SaveLayout(this.FTSMain);
                this.DestroyCustomization();
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
    }
}
