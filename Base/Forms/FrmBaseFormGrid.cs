#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmBaseFormGrid : FTSForm {
        private FTSMain mFTSMain;
        private AppearanceDefault WarningColor = new AppearanceDefault(Color.White, Color.LightCoral, Color.Empty,
                                                                       Color.Red, LinearGradientMode.ForwardDiagonal);
        public FrmBaseFormGrid() {
            this.InitializeComponent();
        }

        public FrmBaseFormGrid(FTSMain ftsmain, bool dialog) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            if (!dialog) {
                //this.MdiParent = this.mFTSMain.MainForm;
                this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            }
            this.ConfigGrid();
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
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

        public virtual void OnError(FTSException ex) {
        }

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);
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
            }
            foreach (GridColumn c in this.grid2.ViewGrid.Columns)
            {
                c.VisibleIndex = this.mFTSMain.GridManager.GetVisibleIndex(this.Name, "GRID2", c.FieldName,
                                                                           c.AbsoluteIndex);
            }
            foreach (GridColumn c in this.grid2.ViewGrid.Columns)
            {
                FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID2", c.FieldName);
                c.VisibleIndex = cinfo.VisibleIndex;
                c.Width = cinfo.Width;
                c.OptionsColumn.AllowEdit = cinfo.Enabled;
                c.OptionsFilter.AllowFilter = cinfo.Filtered;
                c.Caption = cinfo.DisplayName;
                c.Fixed = cinfo.FixColumn ? FixedStyle.Left : FixedStyle.None;
                if (cinfo.IsSum)
                {
                    this.grid2.SetSummary(c, cinfo.SumType);
                }
            }
            if (this.mFTSMain.Language == Language.JP || mFTSMain.Language == Language.LAOS) {
                this.grid.SetFont();
                this.grid2.SetFont();
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
                foreach (GridColumn c in this.grid2.ViewGrid.Columns)
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
                    FTSGridColumnInfo cinfo = this.mFTSMain.GridManager.GetGridColumnInfo(this.Name, "GRID2", c.FieldName);
                    if (cinfo.VisibleIndex != c.VisibleIndex || cinfo.Enabled != c.OptionsColumn.AllowEdit ||
                        cinfo.Visible != c.Visible || cinfo.Width != c.Width ||
                        cinfo.Enabled != c.OptionsFilter.AllowFilter || cinfo.Require != isrequired ||
                        cinfo.FixColumn != fixcolumn || cinfo.IsSum != issummary || cinfo.SumType != summarytype)
                    {
                        this.mFTSMain.GridManager.UpdateConfig(this.Name, "GRID2", c.FieldName, c.OptionsColumn.AllowEdit,
                                                               c.Visible, c.Width, c.VisibleIndex, require,
                                                               c.OptionsFilter.AllowFilter, fixcolumn, issummary,
                                                               summarytype, summaryformat);
                    }
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            try {
                switch (keyData) {
                    case Keys.Control | Keys.F4:
                        this.Close();
                        break;
                    case Keys.F1:
                        this.ShowHelp();
                        break;
                    case Keys.F12:
                        this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
            return base.ProcessDialogKey(keyData);
        }

        private void grid_ProcessGridKey(object sender, KeyEventArgs e) {
            try {
                if(e.KeyData == Keys.F12)
                    this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);                
                this.ProcessGridKey(e.KeyData);
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void grid2_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                this.ProcessGridKey2(e.KeyData);
            }
            catch (FTSException ex)
            {
                ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
            catch (Exception ex1)
            {
                ExceptionManager.ProcessException(this.mFTSMain, ex1);
            }
        }

        protected virtual void ProcessGridKey(Keys keys) {
        }

        protected virtual void ProcessGridKey2(Keys keys)
        {
        }

        private void grid_ButtonClick(object sender, ButtonClickEventArgs e) {
            if (this.grid.ViewGrid.FocusedRowHandle >= 0) {
                this.ProcessButtonClick();
            }
        }

        private void grid2_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            if (this.grid2.ViewGrid.FocusedRowHandle >= 0)
            {
                this.ProcessButtonClick2();
            }
        }

        protected virtual void ProcessButtonClick() {
        }

        protected virtual void ProcessButtonClick2()
        {
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
            this.grid.ProcessGridKey += new KeyEventHandler(this.grid_ProcessGridKey);
            this.grid.ButtonClick += new ButtonClickEventHandler(this.grid_ButtonClick);
            this.grid.ChooseRow += new SelectRowEventHandler(this.grid_ChooseRow);
            this.grid.ViewGrid.RowCellStyle += new RowCellStyleEventHandler(ViewGrid_RowCellStyle);
            //this.grid.ProcessGridKey += new KeyEventHandler(grid_ProcessGridKey);
            //this.grid.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(ViewGrid_FocusedRowChanged);
            if (this.grid.ViewGrid.RowCount > 0) {
                this.grid.ViewGrid.FocusedRowHandle = 0;
            }
            this.grid.Focus();

            this.grid2.ViewGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grid2.ViewGrid.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            //this.grid.ViewGrid.OptionsBehavior.Editable = false;
            this.grid2.ViewGrid.OptionsView.ShowGroupPanel = false;
            this.grid2.ViewGrid.OptionsView.ShowFooter = true;
            this.grid2.ViewGrid.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            this.grid2.ViewGrid.OptionsSelection.MultiSelect = false;
            this.grid2.ViewGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.grid2.ViewGrid.OptionsView.EnableAppearanceOddRow = true;
            this.grid2.ViewGrid.Appearance.EvenRow.BackColor = Color.WhiteSmoke;            
            this.grid2.ShowFilterRow();
            if (this.grid2.ViewGrid.RowCount == 0)
            {
                this.grid2.ViewGrid.ClearColumnsFilter();
            }
            this.grid2.ViewGrid.BorderStyle = BorderStyles.NoBorder;
            this.grid2.ProcessGridKey += new KeyEventHandler(this.grid2_ProcessGridKey);
            this.grid2.ButtonClick += new ButtonClickEventHandler(this.grid2_ButtonClick);
            this.grid2.ChooseRow += new SelectRowEventHandler(this.grid2_ChooseRow);
            //this.grid2.ProcessGridKey += new KeyEventHandler(grid2_ProcessGridKey);
            //this.grid2.ViewGrid.FocusedRowChanged += new FocusedRowChangedEventHandler(ViewGrid2_FocusedRowChanged);
            if (this.grid2.ViewGrid.RowCount > 0)
            {
                this.grid2.ViewGrid.FocusedRowHandle = 0;
            }
        }

        private void grid_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                this.ProcessButtonClick();
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void grid2_ChooseRow(object sender, SelectRowEventArgs e)
        {
            try
            {
                this.ProcessButtonClick2();
            }
            catch (Exception ex)
            {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain) {
            return new CustomizationForm(this, this.grid, ftsmain);
        }


        private void ViewGrid_RowCellStyle(object sender, RowCellStyleEventArgs e) {
            try {
                object val = this.grid.ViewGrid.GetRowCellValue(e.RowHandle, e.Column);
                CurrentCellInfo cellinfo = new CurrentCellInfo(val, e.RowHandle, e.Column);
                if (!this.CellWarning(cellinfo)) {
                    AppearanceHelper.Apply(e.Appearance, WarningColor);
                }
            } catch (Exception ex) {
                ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public virtual bool CellWarning(CurrentCellInfo cellinfo) {
            return true;
        }
    }
}