using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using FTS.BaseUI.Controls;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data;
using DevExpress.XtraGrid;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using FTS.Global.Classes;
using FTS.Global.Interface;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.BaseUI.Forms
{
    public partial class IdConfigForm : FrmBaseForm
    {
        private DataSet mDataSet;
        private DataTable mDataLog;
        private string mCurrentTableName = string.Empty;
        private int mCurrentPartId = 0;
        private bool mCancel = false;

        public IdConfigForm()
        {
            InitializeComponent();
        }

        public IdConfigForm(FTSMain ftsmain):base(ftsmain,true)
        {
            InitializeComponent();
            this.LoadData();
            this.LoadDataLog();
            this.BindGrid();            
            this.ConfigGrid();
            this.LoadLayout(this.FTSMain);
            this.FilterGridFilter();
            this.FilterGridStruct();
            this.FilterGridDefault();
        }
        private void LoadData()
        {
            this.mDataSet = new DataSet();
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand("select * from SYS_TABLE where TABLE_TYPE = 'LIST'"), this.mDataSet, "SYS_TABLE");
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand("select * from SYS_ID_FILTER"), this.mDataSet, "SYS_ID_FILTER");
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand("select * from SYS_ID_STRUCT"), this.mDataSet, "SYS_ID_STRUCT");
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand("select * from SYS_ID_DEFAULT"), this.mDataSet, "SYS_ID_DEFAULT");
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand("select ORGANIZATION_ID,ORGANIZATION_ID + '-' + ORGANIZATION_NAME AS ORGANIZATION_NAME,PARENT_ORGANIZATION_ID from DM_ORGANIZATION"), this.mDataSet, "DM_ORGANIZATION");
        }
        private void BindGrid()
        {
            this.gridTable.CreateGrid(this.mDataSet, this.mDataSet.Tables["SYS_TABLE"], "SYS_TABLE");
            this.gridTable.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "TABLE_NAME", DbType.String, true),false);
            this.gridTable.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "TABLE_NAME_DISPLAY", DbType.String, false), false);
            this.gridTable.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "ID_LENGTH", DbType.Int32, false), 0);
            this.gridTable.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "ID_PARTS", DbType.Int32, false), 0);
            this.gridTable.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "ID_SPLIT", DbType.String, false), false);
            this.gridTable.SetCheckColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_TABLE", "ID_AUTO", DbType.Boolean, false));
            this.gridTable.BindData();

            this.gridFilter.CreateGrid(this.mDataSet, this.mDataSet.Tables["SYS_ID_FILTER"], "SYS_ID_FILTER");
            this.gridFilter.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_FILTER", "TABLE_NAME", DbType.String, true), false);
            this.gridFilter.SetComboMultiColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_FILTER", "ORGANIZATION_ID", DbType.String, false), this.mDataSet.Tables["DM_ORGANIZATION"], "ORGANIZATION_NAME", "ORGANIZATION_ID", ComboComType.NameOnly, false);            
            this.gridFilter.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_FILTER", "REGULAR_EXPRESSION", DbType.String, false), false);
            this.gridFilter.BindData();

            this.gridStruct.CreateGrid(this.mDataSet, this.mDataSet.Tables["SYS_ID_STRUCT"], "SYS_ID_STRUCT");
            this.gridStruct.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_STRUCT", "TABLE_NAME", DbType.String, false), false);
            this.gridStruct.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_STRUCT", "PART_ID", DbType.Int32, false), 0);
            this.gridStruct.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_STRUCT", "PART_LENGTH", DbType.Int32, false), 0);
            this.gridStruct.BindData();

            this.gridDefault.CreateGrid(this.mDataSet, this.mDataSet.Tables["SYS_ID_DEFAULT"], "SYS_ID_DEFAULT");
            this.gridDefault.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_DEFAULT", "TABLE_NAME", DbType.String, false), false);
            this.gridDefault.SetNumberColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_DEFAULT", "PART_ID", DbType.Int32, false), 0);
            this.gridDefault.SetComboMultiColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_DEFAULT", "ORGANIZATION_ID", DbType.String, false), this.mDataSet.Tables["DM_ORGANIZATION"], "ORGANIZATION_NAME", "ORGANIZATION_ID", ComboComType.NameOnly, false);
            this.gridDefault.SetTextColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_DEFAULT", "DEFAULT_VALUE", DbType.String, false), false);
            this.gridDefault.SetCheckColumn(this.FTSMain.FieldManager.CreateFieldInfo("SYS_ID_DEFAULT", "ALLOW_NEW_VALUE", DbType.Boolean, false));
            this.gridDefault.BindData();
        }
        private void ConfigGrid()
        {
            this.gridTable.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridTable.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.gridTable.ViewGrid.OptionsSelection.MultiSelect = false;
            this.gridTable.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridTable.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gridTable.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gridTable.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.gridTable.ViewGrid.OptionsView.ShowFooter = false;
            this.gridTable.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            this.gridTable.NumbericValueChanging += new NumbericValueChangingEventHandler(gridTable_NumbericValueChanging);
            this.gridTable.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(gridTable_ViewGrid_FocusedRowChanged);
            this.gridTable.ViewGrid.CustomUnboundColumnData += new CustomColumnDataEventHandler(gridTable_ViewGrid_CustomUnboundColumnData);

            this.gridFilter.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridFilter.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.gridFilter.ViewGrid.OptionsSelection.MultiSelect = false;
            this.gridFilter.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridFilter.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gridFilter.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gridFilter.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.gridFilter.ViewGrid.OptionsView.ShowFooter = false;
            this.gridFilter.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            this.gridStruct.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridStruct.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.gridStruct.ViewGrid.OptionsSelection.MultiSelect = false;
            this.gridStruct.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridStruct.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gridStruct.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gridStruct.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.gridStruct.ViewGrid.OptionsView.ShowFooter = false;
            this.gridStruct.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            this.gridStruct.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(gridStruct_ViewGrid_FocusedRowChanged);

            this.gridDefault.ViewGrid.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridDefault.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.gridDefault.ViewGrid.OptionsSelection.MultiSelect = false;
            this.gridDefault.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.gridDefault.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gridDefault.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gridDefault.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            this.gridDefault.ViewGrid.OptionsView.ShowFooter = false;
            this.gridDefault.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            this.gridDefault.ViewGrid.ShowingEditor += new CancelEventHandler(gridDefault_ViewGrid_ShowingEditor);
        }

        private void gridDefault_ViewGrid_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.gridDefault.ViewGrid.FocusedColumn.FieldName.ToUpper() == "DEFAULT_VALUE")
                {
                    if (System.Convert.ToInt16(this.gridDefault.ViewGrid.GetRowCellValue(this.gridDefault.ViewGrid.FocusedRowHandle, "ALLOW_NEW_VALUE")) == 1)
                        e.Cancel = true;
                }
                else if (this.gridDefault.ViewGrid.FocusedColumn.FieldName.ToUpper() == "ALLOW_NEW_VALUE")
                {
                    if (System.Convert.ToString(this.gridDefault.ViewGrid.GetRowCellValue(this.gridDefault.ViewGrid.FocusedRowHandle, "DEFAULT_VALUE")).Trim() != string.Empty)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void gridTable_ViewGrid_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                DataRow rowtable = this.gridTable.ViewGrid.GetDataRow(e.RowHandle);
                if (rowtable == null)
                    return;               
                switch (e.Column.UnboundType)
                {
                    case DevExpress.Data.UnboundColumnType.String:
                        if (e.Column.FieldName.Trim().ToUpper() == "TABLE_NAME_DISPLAY")
                        {
                            if (e.IsGetData)
                            {
                                e.Value = this.FTSMain.TableManager.GetDisplayName((string)rowtable["TABLE_NAME"]);
                            }
                            else
                            {
                                rowtable["TABLE_NAME_DISPLAY"] = e.Value;
                            }
                        }                        
                        break;                   
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void FilterGridFilter()
        {
            string displayText = String.Format("[" + this.gridFilter.ViewGrid.Columns["TABLE_NAME"].Caption + "] = '{0}'", this.mCurrentTableName);
            this.gridFilter.ViewGrid.Columns["TABLE_NAME"].FilterInfo = new ColumnFilterInfo("[TABLE_NAME] = '" + this.mCurrentTableName + "'", displayText, this.mCurrentTableName, ColumnFilterType.AutoFilter);
            this.AutoAddFilter();
        }

        private void FilterGridStruct()
        {
            string displayText = String.Format("[" + this.gridStruct.ViewGrid.Columns["TABLE_NAME"].Caption + "] = '{0}'", this.mCurrentTableName);
            this.gridStruct.ViewGrid.Columns["TABLE_NAME"].FilterInfo = new ColumnFilterInfo("[TABLE_NAME] = '" + this.mCurrentTableName + "'", displayText, this.mCurrentTableName, ColumnFilterType.AutoFilter);
        }

        private void FilterGridDefault()
        {
            string displayText = String.Format("[" + this.gridDefault.ViewGrid.Columns["TABLE_NAME"].Caption + "] = '{0}'", this.mCurrentTableName);
            this.gridDefault.ViewGrid.Columns["TABLE_NAME"].FilterInfo = new ColumnFilterInfo("[TABLE_NAME] = '" + this.mCurrentTableName + "'", displayText, this.mCurrentTableName, ColumnFilterType.AutoFilter);
            displayText = String.Format("[" + this.gridDefault.ViewGrid.Columns["PART_ID"].Caption + "] = {0}", this.mCurrentPartId);
            this.gridDefault.ViewGrid.Columns["PART_ID"].FilterInfo = new ColumnFilterInfo("[PART_ID] = " + this.mCurrentPartId, displayText, this.mCurrentPartId, ColumnFilterType.AutoFilter);
            this.AutoAddDefault();
        }

        private void gridStruct_ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow rowstruct = this.gridStruct.ViewGrid.GetDataRow(this.gridStruct.ViewGrid.FocusedRowHandle);
                if (rowstruct != null)
                    this.mCurrentPartId = (Int32)rowstruct["PART_ID"];
                this.FilterGridDefault();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void gridTable_ViewGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow rowtable = this.gridTable.ViewGrid.GetDataRow(this.gridTable.ViewGrid.FocusedRowHandle);
                if (rowtable != null)
                    this.mCurrentTableName = (string)rowtable["TABLE_NAME"];
                this.FilterGridFilter();
                this.FilterGridStruct();
                this.FilterGridDefault();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void gridTable_NumbericValueChanging(object sender, GridNumbericValueChangingEventArgs e)
        {
            try
            {
                if (e.Col.FieldName == "ID_PARTS")
                {
                    if ((e.EventChanging.NewValue != null) && (e.EventChanging.NewValue.ToString().Trim() != string.Empty) && (!e.EventChanging.NewValue.Equals(e.EventChanging.OldValue)))
                    {
                        DataRow rowtable = this.gridTable.ViewGrid.GetDataRow(this.gridTable.ViewGrid.FocusedRowHandle);
                        if (rowtable != null)
                        {
                            this.DeleteStruct((string)rowtable["TABLE_NAME"]);
                            this.DeleteDefault((string)rowtable["TABLE_NAME"]);
                            this.CreateStruct((string)rowtable["TABLE_NAME"], Int32.Parse(e.EventChanging.NewValue.ToString(), System.Globalization.NumberStyles.Any));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void DeleteStruct(string tablename)
        {
            List<DataRow> lstrowdel = new List<DataRow>();
            foreach (DataRow rowstruct in this.mDataSet.Tables["SYS_ID_STRUCT"].Rows)
            {
                if((rowstruct.RowState!= DataRowState.Deleted)&&((string)rowstruct["TABLE_NAME"]==tablename))
                {
                    lstrowdel.Add(rowstruct);
                }
            }
            foreach (DataRow rowdel in lstrowdel)
            {
                rowdel.Delete();
            }            
        }

        private void CreateStruct(string tablename, int idparts)
        {
            if (idparts > 1)
            {
                for (int i = 1; i <= idparts; i++)
                {
                    DataRow newrowstruct = this.mDataSet.Tables["SYS_ID_STRUCT"].NewRow();
                    newrowstruct["PR_KEY"] = Guid.NewGuid();
                    newrowstruct["TABLE_NAME"] = tablename;
                    newrowstruct["PART_ID"] = i;
                    newrowstruct["PART_LENGTH"] = 0;
                    newrowstruct.EndEdit();
                    this.mDataSet.Tables["SYS_ID_STRUCT"].Rows.Add(newrowstruct);
                }
            }
        }
        private void DeleteDefault(string tablename)
        {
            List<DataRow> lstrowdel = new List<DataRow>();
            foreach (DataRow rowdefault in this.mDataSet.Tables["SYS_ID_DEFAULT"].Rows)
            {
                if ((rowdefault.RowState != DataRowState.Deleted) && ((string)rowdefault["TABLE_NAME"] == tablename))
                {
                    lstrowdel.Add(rowdefault);
                }
            }
            foreach (DataRow rowdel in lstrowdel)
            {
                rowdel.Delete();
            }
        }

        public override void LoadLayout(FTSMain ftsmain)
        {
            this.Name = this.Name.ToUpper();
            base.LoadLayout(ftsmain);
            this.LayoutGrid();
        }
        public override void SaveLayout(FTSMain ftsmain)
        {
            base.SaveLayout(ftsmain);
            this.SaveGridLayout();
        }
        private void LayoutGrid()
        {
            foreach (GridColumn c in this.gridTable.ViewGrid.Columns)
            {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDTABLE", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.gridTable.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDTABLE", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.gridTable.SetSummary(c, cinfo.SumType);
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
            }

            foreach (GridColumn c in this.gridFilter.ViewGrid.Columns)
            {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDFILTER", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.gridFilter.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDFILTER", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.gridFilter.SetSummary(c, cinfo.SumType);
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
            }

            foreach (GridColumn c in this.gridStruct.ViewGrid.Columns)
            {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDSTRUCT", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.gridStruct.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDSTRUCT", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.gridStruct.SetSummary(c, cinfo.SumType);
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
            }

            foreach (GridColumn c in this.gridDefault.ViewGrid.Columns)
            {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRIDDEFAULT", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.gridDefault.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDDEFAULT", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.gridDefault.SetSummary(c, cinfo.SumType);
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
            }

            if (this.FTSMain.Language == Language.JP || FTSMain.Language == Language.LAOS)
            {
                this.gridTable.SetFont();
                this.gridFilter.SetFont();
                this.gridStruct.SetFont();
                this.gridDefault.SetFont();
            }
        }
        private void SaveGridLayout()
        {
            if (this.FTSMain.DbMain.WorkingMode == Microsoft.Practices.EnterpriseLibrary.Data.WorkingMode.LAN && this.FTSMain.UserInfo.UserGroupID == "ADMIN")
            {
                foreach (GridColumn c in this.gridTable.ViewGrid.Columns)
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
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDTABLE", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRIDTABLE", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }

                foreach (GridColumn c in this.gridFilter.ViewGrid.Columns)
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
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDFILTER", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRIDFILTER", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }

                foreach (GridColumn c in this.gridStruct.ViewGrid.Columns)
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
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDSTRUCT", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRIDSTRUCT", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }

                foreach (GridColumn c in this.gridDefault.ViewGrid.Columns)
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
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRIDDEFAULT", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRIDDEFAULT", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }
            }
        }

        private void AutoAddFilter()
        {
            foreach (DataRow roworganization in this.mDataSet.Tables["DM_ORGANIZATION"].Rows)
            {
                if (roworganization.RowState != DataRowState.Deleted)
                {
                    bool flagexists = false;
                    for (int rowhandle = 0; rowhandle < this.gridFilter.ViewGrid.RowCount; rowhandle++)
                    {
                        if ((string)roworganization["ORGANIZATION_ID"] == (string)this.gridFilter.GetValue(rowhandle, "ORGANIZATION_ID"))
                        {
                            flagexists = true;
                            break;
                        }
                    }
                    if(!flagexists)
                    {
                        DataRow newrowfilter = this.mDataSet.Tables["SYS_ID_FILTER"].NewRow();
                        newrowfilter["PR_KEY"] = Guid.NewGuid();
                        newrowfilter["TABLE_NAME"] = this.mCurrentTableName;
                        newrowfilter["ORGANIZATION_ID"] = roworganization["ORGANIZATION_ID"];
                        newrowfilter["REGULAR_EXPRESSION"] = "1=1";
                        newrowfilter.EndEdit();
                        this.mDataSet.Tables["SYS_ID_FILTER"].Rows.Add(newrowfilter);
                    }
                }
            }
        }        

        private void AutoAddDefault()
        {
            foreach (DataRow roworganization in this.mDataSet.Tables["DM_ORGANIZATION"].Rows)
            {
                if (roworganization.RowState != DataRowState.Deleted)
                {
                    bool flagexists = false;
                    for (int rowhandle = 0; rowhandle < this.gridDefault.ViewGrid.RowCount; rowhandle++)
                    {
                        if ((string)roworganization["ORGANIZATION_ID"] == (string)this.gridDefault.GetValue(rowhandle, "ORGANIZATION_ID"))
                        {
                            flagexists = true;
                            break;
                        }
                    }
                    if (!flagexists)
                    {
                        DataRow newrowdefault = this.mDataSet.Tables["SYS_ID_DEFAULT"].NewRow();
                        newrowdefault["PR_KEY"] = Guid.NewGuid();
                        newrowdefault["TABLE_NAME"] = this.mCurrentTableName;
                        newrowdefault["PART_ID"] = this.mCurrentPartId;
                        newrowdefault["ORGANIZATION_ID"] = roworganization["ORGANIZATION_ID"];
                        newrowdefault["DEFAULT_VALUE"] = string.Empty;
                        newrowdefault["ALLOW_NEW_VALUE"] = 1;
                        newrowdefault.EndEdit();
                        this.mDataSet.Tables["SYS_ID_DEFAULT"].Rows.Add(newrowdefault);
                    }
                }
            }            
        }        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.mDataSet.GetChanges()!=null)
                    this.UpdateData();
                this.Close();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.mCancel = true;
            this.Close();
        }

        private void LogData(DataSet ds)
        {
            if (this.FTSMain.IsMultiSite)
            {
                this.mDataLog.RejectChanges();
            }
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("SYS_TABLE")))
            {
                DataTable dt = ds.Tables["SYS_TABLE"];              
                foreach (DataRow row in dt.Rows)
                {
                    ClassInfo clsInfo = (ClassInfo)Registrator.Hash["SYS_TABLE"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            if (this.FTSMain.CommunicateManager.IsNew("SYS_TABLE"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.NEW;
                                ((IHead)instance).IdValue = row[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Modified:
                            if (this.FTSMain.CommunicateManager.IsEdit("SYS_TABLE"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.EDIT;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Deleted:
                            if (this.FTSMain.CommunicateManager.IsDelete("SYS_TABLE"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.DELETE;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRowDeleted(row, instance);
                            }
                            break;
                        default:
                            break;
                    }
                    if (flag)
                    {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "SYS_TABLE";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite)
                        {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        }
                        else
                        {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("SYS_TABLE"))
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "0";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("SYS_ID_FILTER")))
            {
                DataTable dt = ds.Tables["SYS_ID_FILTER"];
                foreach (DataRow row in dt.Rows)
                {
                    ClassInfo clsInfo = (ClassInfo)Registrator.Hash["SYS_ID_FILTER"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            if (this.FTSMain.CommunicateManager.IsNew("SYS_ID_FILTER"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.NEW;
                                ((IHead)instance).IdValue = row[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Modified:
                            if (this.FTSMain.CommunicateManager.IsEdit("SYS_ID_FILTER"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.EDIT;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Deleted:
                            if (this.FTSMain.CommunicateManager.IsDelete("SYS_ID_FILTER"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.DELETE;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                            }
                            break;
                        default:
                            break;
                    }
                    if (flag)
                    {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "SYS_ID_FILTER";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite)
                        {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        }
                        else
                        {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("SYS_ID_FILTER"))
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "0";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("SYS_ID_STRUCT")))
            {
                DataTable dt = ds.Tables["SYS_ID_STRUCT"];
                foreach (DataRow row in dt.Rows)
                {
                    ClassInfo clsInfo = (ClassInfo)Registrator.Hash["SYS_ID_STRUCT"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            if (this.FTSMain.CommunicateManager.IsNew("SYS_ID_STRUCT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.NEW;
                                ((IHead)instance).IdValue = row[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Modified:
                            if (this.FTSMain.CommunicateManager.IsEdit("SYS_ID_STRUCT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.EDIT;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Deleted:
                            if (this.FTSMain.CommunicateManager.IsDelete("SYS_ID_STRUCT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.DELETE;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                            }
                            break;
                        default:
                            break;
                    }
                    if (flag)
                    {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "SYS_ID_STRUCT";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite)
                        {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        }
                        else
                        {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("SYS_ID_STRUCT"))
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "0";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
            if ((this.FTSMain.IsMultiSite) && (this.FTSMain.CommunicateManager.IsExit("SYS_ID_DEFAULT")))
            {
                DataTable dt = ds.Tables["SYS_ID_DEFAULT"];
                foreach (DataRow row in dt.Rows)
                {
                    ClassInfo clsInfo = (ClassInfo)Registrator.Hash["SYS_ID_DEFAULT"];
                    object instance = Activator.CreateInstance(clsInfo.Type);
                    bool flag = false;
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            if (this.FTSMain.CommunicateManager.IsNew("SYS_ID_DEFAULT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.NEW;
                                ((IHead)instance).IdValue = row[clsInfo.IdField];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Modified:
                            if (this.FTSMain.CommunicateManager.IsEdit("SYS_ID_DEFAULT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.EDIT;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                                Global.Utilities.Functions.CopyObjectFromDataRow(row, instance);
                            }
                            break;
                        case DataRowState.Deleted:
                            if (this.FTSMain.CommunicateManager.IsDelete("SYS_ID_DEFAULT"))
                            {
                                flag = true;
                                ((IHead)instance).DataState = DataState.DELETE;
                                ((IHead)instance).IdValue = row[clsInfo.IdField, DataRowVersion.Original];
                            }
                            break;
                        default:
                            break;
                    }
                    if (flag)
                    {
                        DataRow newRow = this.mDataLog.NewRow();
                        newRow["TABLE_NAME"] = "SYS_ID_DEFAULT";
                        newRow["LOG_TIME"] = DateTime.Now;
                        newRow["OBJECT_VALUE"] =
                            Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(instance));
                        newRow["IS_UPLOAD"] = 0;
                        newRow["USER_ID"] = this.FTSMain.UserInfo.UserID.ToUpper();
                        if (this.FTSMain.IsChildSite)
                        {
                            newRow["IS_DOWNLOAD"] = string.Empty;
                        }
                        else
                        {
                            string mark = string.Empty;
                            int number =
                                Convert.ToInt32(this.FTSMain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                            if (this.FTSMain.CommunicateManager.IsPulic("SYS_ID_DEFAULT"))
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "0";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < number; i++)
                                {
                                    mark = mark + "1";
                                }
                            }
                            newRow["IS_DOWNLOAD"] = mark;
                        }
                        newRow.EndEdit();
                        this.mDataLog.Rows.Add(newRow);
                    }
                }
            }
        }

        private void UpdateData()
        {
            DbTransaction tran = null;
            try
            {              
                this.LogData(this.mDataSet);                                
                using (DbConnection connection = this.FTSMain.DbMain.CreateConnection())
                {
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        connection.Open();
                        tran = connection.BeginTransaction();
                    } else {
                        this.FTSMain.DbMain.BeginTransactionOnline();
                    }
                    this.FTSMain.DbMain.UpdateDataSet(this.mDataSet, "SYS_TABLE",
                                                        this.FTSMain.DbMain.CreateInsertCommand("SYS_TABLE",
                                                                                                this.mDataSet.Tables["SYS_TABLE"],
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateUpdateCommand("SYS_TABLE",
                                                                                                this.mDataSet.Tables["SYS_TABLE"],
                                                                                                "TABLE_NAME",
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateDeleteCommand("SYS_TABLE",
                                                                                                this.mDataSet.Tables["SYS_TABLE"],
                                                                                                "TABLE_NAME"), tran);
                    this.FTSMain.DbMain.UpdateDataSet(this.mDataSet, "SYS_ID_FILTER",
                                                        this.FTSMain.DbMain.CreateInsertCommand("SYS_ID_FILTER",
                                                                                                this.mDataSet.Tables["SYS_ID_FILTER"],
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateUpdateCommand("SYS_ID_FILTER",
                                                                                                this.mDataSet.Tables["SYS_ID_FILTER"],
                                                                                                "PR_KEY",
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateDeleteCommand("SYS_ID_FILTER",
                                                                                                this.mDataSet.Tables["SYS_ID_FILTER"],
                                                                                                "PR_KEY"), tran);
                    this.FTSMain.DbMain.UpdateDataSet(this.mDataSet, "SYS_ID_STRUCT",
                                                        this.FTSMain.DbMain.CreateInsertCommand("SYS_ID_STRUCT",
                                                                                                this.mDataSet.Tables["SYS_ID_STRUCT"],
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateUpdateCommand("SYS_ID_STRUCT",
                                                                                                this.mDataSet.Tables["SYS_ID_STRUCT"],
                                                                                                "PR_KEY",
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateDeleteCommand("SYS_ID_STRUCT",
                                                                                                this.mDataSet.Tables["SYS_ID_STRUCT"],
                                                                                                "PR_KEY"), tran);
                    this.FTSMain.DbMain.UpdateDataSet(this.mDataSet, "SYS_ID_DEFAULT",
                                                        this.FTSMain.DbMain.CreateInsertCommand("SYS_ID_DEFAULT",
                                                                                                this.mDataSet.Tables["SYS_ID_DEFAULT"],
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateUpdateCommand("SYS_ID_DEFAULT",
                                                                                                this.mDataSet.Tables["SYS_ID_DEFAULT"],
                                                                                                "PR_KEY",
                                                                                                string.Empty),
                                                        this.FTSMain.DbMain.CreateDeleteCommand("SYS_ID_DEFAULT",
                                                                                                this.mDataSet.Tables["SYS_ID_DEFAULT"],
                                                                                                "PR_KEY"), tran);
                    if (this.FTSMain.IsMultiSite)
                    {
                        this.FTSMain.DbMain.UpdateTable(this.mDataLog,
                                                            this.FTSMain.DbMain.CreateInsertCommand("DATA_LOG",
                                                                                                    this.mDataLog,
                                                                                                    "PR_KEY"),
                                                            this.FTSMain.DbMain.CreateUpdateCommand("DATA_LOG",
                                                                                                    this.mDataLog,
                                                                                                    "PR_KEY", "PR_KEY"),
                                                            this.FTSMain.DbMain.CreateDeleteCommand("DATA_LOG",
                                                                                                    this.mDataLog,
                                                                                                    "PR_KEY"), tran);
                    }
                    if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                        tran.Commit();
                    } else {
                        this.FTSMain.DbMain.CommitTransactionOnline();
                    }
                    this.FTSMain.IdManager = new IdManager(this.FTSMain);
                    this.mDataSet.AcceptChanges();
                }                
            }
            catch (Exception)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception)
                {
                }                
                throw;
            }
        }

        private void LoadDataLog()
        {
            if (this.FTSMain.IsMultiSite)
            {
                this.mDataLog = this.FTSMain.TableManager.LoadTable("DATA_LOG", "1=0");
            }
        }
        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain)
        {
            List<FTSDataGrid> lstgrid = new List<FTSDataGrid>();
            lstgrid.Add(gridTable);
            lstgrid.Add(gridFilter);
            lstgrid.Add(gridStruct);
            lstgrid.Add(gridDefault);
            return new CustomizationForm(this, lstgrid, ftsmain, false, true);
        }
        protected virtual ChangedStatus CheckChanged()
        {            
            if (this.mDataSet.GetChanges()!=null)
            {
                DialogResult dresult =
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoCancelMessage(this.FTSMain.MsgManager.GetMessage("MSG_UPDATE_CHANGE"));
                if (dresult == DialogResult.Yes)
                {
                    this.UpdateData();
                    return ChangedStatus.YES;
                }
                else if (dresult == DialogResult.Cancel)
                {
                    return ChangedStatus.CANCEL;
                }
                else
                {                    
                    return ChangedStatus.NO;
                }
            }
            else
            {
                return ChangedStatus.NONE;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if ((!this.mCancel)&&(this.CheckChanged() == ChangedStatus.CANCEL))
                {
                    e.Cancel = true;
                }
                if (!e.Cancel)
                {
                    if (this.WindowState != FormWindowState.Normal)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.SaveLayout(this.FTSMain);
                    this.DestroyCustomization();
                }
            }            
            catch (Exception ex)
            {
                e.Cancel = true;
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);                
            }
        }
    }
}
