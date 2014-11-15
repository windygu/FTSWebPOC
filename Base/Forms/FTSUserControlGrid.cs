#region

using System.Drawing;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSUserControlGrid : FTSUserControl {
        public FTSUserControlGrid() {
            this.InitializeComponent();
        }

        public FTSUserControlGrid(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ConfigGrid();
        }

        public virtual void OnError(FTSException ex) {
        }

        public void LoadLayout() {
            this.LoadLayout(this.FTSMain);
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            this.LayoutGrid();
        }

        public override void SaveLayout(FTSMain ftsmain) {
            base.SaveLayout(ftsmain);
            this.SaveGridLayout();
        }

        protected virtual void LayoutGrid() {
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                c.VisibleIndex = this.FTSMain.GridManager.GetVisibleIndex(this.Name, "GRID", c.FieldName,
                                                                          c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.grid.ViewGrid.Columns) {
                FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
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
            if (this.FTSMain.Language == Language.JP || FTSMain.Language == Language.LAOS) {
                this.grid.SetFont();
            }
        }

        protected virtual void SaveGridLayout() {
            if (this.FTSMain.DbMain.WorkingMode == WorkingMode.LAN && this.FTSMain.UserInfo.UserGroupID == "ADMIN") {
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
                    FTSGridColumnInfo cinfo = this.FTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID", c.FieldName);
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
                        this.FTSMain.GridManager.UpdateConfig(this.Name, "GRID", c.FieldName, c.OptionsColumn.AllowEdit,
                                                              c.Visible, c.Width, c.VisibleIndex, require,
                                                              c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                              summarytype, summaryformat);
                    }
                    //this.mFTSMain.FieldManager.SetDisplayName(this.grid.DataMember, c.FieldName, c.Caption);
                }
            }
        }

        protected void ConfigGrid() {
            this.grid.ViewGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grid.ViewGrid.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            //this.grid.ViewGrid.OptionsBehavior.Editable = false;
            this.grid.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid.ViewGrid.OptionsView.ShowFooter = true;
            this.grid.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            this.grid.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.grid.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.grid.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            string displayText = string.Empty;
            this.grid.ShowFilterRow();
            if (this.grid.ViewGrid.RowCount == 0) {
                this.grid.ViewGrid.ClearColumnsFilter();
            }
            this.grid.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            if (this.grid.ViewGrid.RowCount > 0) {
                this.grid.ViewGrid.FocusedRowHandle = 0;
            }
            this.grid.Focus();
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }
    }
}