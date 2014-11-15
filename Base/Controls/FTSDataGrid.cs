#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Columns;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using System.Globalization;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSDataGrid : GridControl {
        private const string MSG_ERROR_OPEN_FILE = "Không mở được file vừa kết xuất.";
        private const string MSG_EXPORT_HTML = "Kết xuất ra HTML";
        private const string MSG_EXPORT_OPEN_FILE = "Bạn có muốn mở file vừa kế xuất không?";
        private const string MSG_EXPORT_PROCESSING = "Đang kết xuất... Xin vui lòng chờ...";
        private const string MSG_EXPORT_TEXT = "Kết xuât ra file Text";
        private const string MSG_EXPORT_XLS = "Kết xuất ra File Excel";
        private ArrayList mCustomCount = new ArrayList();
        private DataSet mDataSet;
        private DataTable mDataTable;
        private DataView mDataView;
        private GridView mGridView;
        private string mTableName;
        private string mTextFooter = string.Empty;
        private bool mAllowSortColumns = false;
        private List<GridCheckHeaderColumn> mListHeader = new List<GridCheckHeaderColumn>();
        private bool mAllowFocus = false;
        private Hashtable mHashNumberLimit = new Hashtable();

        public FTSDataGrid() {
            this.InitializeComponent();
            this.mGridView = new GridView();
            this.SetPropertiesGridView();
            this.mGridView.KeyDown += new KeyEventHandler(this.gridView_KeyDown);
            this.mGridView.DoubleClick += new EventHandler(this.gridView_DoubleClick);
            this.mGridView.CustomDrawFooter += new RowObjectCustomDrawEventHandler(this.gridView_DrawFooterText);
            this.mGridView.ValidatingEditor +=
                new BaseContainerValidateEditorEventHandler(this.gridView_ValidatingEditor);
            this.mGridView.CustomSummaryCalculate += new CustomSummaryEventHandler(this.gridView_CustomSummaryCalculate);
            this.mGridView.CustomDrawRowIndicator +=
                new RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            this.mGridView.Click += new EventHandler(this.mGridView_Click);
            this.mGridView.CustomDrawColumnHeader +=
                new ColumnHeaderCustomDrawEventHandler(this.mGridView_CustomDrawColumnHeader);
            this.mGridView.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(this.mGridView_CustomDrawGroupRow);
            this.mGridView.CustomRowCellEdit += new CustomRowCellEditEventHandler(mGridView_CustomRowCellEdit);
            this.mGridView.GotFocus += new EventHandler(mGridView_GotFocus);
            this.MainView = this.mGridView;
            this.ViewCollection.Add(this.mGridView);
        }

        private void mGridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if ((this.mGridView.IsFilterRow(this.mGridView.FocusedRowHandle)) && (e.Column.ColumnEdit is RepositoryItemDateEdit))
                e.RepositoryItem = e.Column.RealColumnEdit;
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.ViewGrid.Appearance.HeaderPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.ViewGrid.Appearance.FooterPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.ViewGrid.Appearance.Row.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        [Browsable(false), DefaultValue(false)]
        public bool AllowSortColumns {
            get { return this.mAllowSortColumns; }
            set {
                this.mAllowSortColumns = value;
                foreach (GridColumn col in this.mGridView.Columns) {
                    col.OptionsColumn.AllowSort = this.mAllowSortColumns ? DefaultBoolean.True : DefaultBoolean.False;
                }
            }
        }

        [Browsable(false)]
        public object CurrentCellValue {
            get {
                if (this.mGridView.FocusedValue != null) {
                    return this.mGridView.FocusedValue;
                } else {
                    return string.Empty;
                }
            }
        }

        [Browsable(false)]
        public string CurrentColumnName {
            get {
                if (this.mGridView.FocusedColumn != null) {
                    return this.mGridView.FocusedColumn.FieldName;
                } else {
                    return string.Empty;
                }
            }
        }

        [Browsable(false)]
        public bool IsFirstRecord {
            get { return this.mGridView.IsFirstRow; }
        }

        [Browsable(false)]
        public bool IsLastRecord {
            get { return this.mGridView.IsLastRow; }
        }

        [Browsable(false)]
        public GridView ViewGrid {
            get { return this.mGridView; }
        }

        [Browsable(false)]
        public List<GridCheckHeaderColumn> CheckHeader {
            get { return this.mListHeader; }
        }

        [DefaultValue(false), Browsable(false)]
        public bool AllowFocus
        {
            get { return this.mAllowFocus; }
            set { this.mAllowFocus = value; }
        }

        public event CellClickEventHandler CellClick;
        public event CellDoubleClickEventHandler CellDoubleClick;
        public event SelectRowEventHandler ChooseRow;
        public event ComboBoxClickEventHandler ComboBoxClick;
        public event GridComboChangeEventHandler GridComboChange;
        public event TextBoxLookupEventHandler TextBoxLookup;
        public event TextBoxMultiLookupEventHandler TextBoxMultiLookup;
        public event ValidateColumnEventHandler ValidateColumn;
        public event NumbericValueChangingEventHandler NumbericValueChanging;
        public event CheckBoxChangedEventHandler CheckBoxChanged;
        public event ButtonClickEventHandler ButtonClick;
        public event GridDateChangeEventHandler GridDateChange;

        private string GetFieldName(int colindex) {
            string fieldname = null;
            for (int i = 0; i < this.mGridView.Columns.Count; i++) {
                if (this.mGridView.Columns[i].VisibleIndex == colindex) {
                    fieldname = this.mGridView.Columns[i].FieldName;
                }
            }
            return fieldname;
        }

        private SummaryItemType GetSumType(string sumtype) {
            switch (sumtype.ToUpper().Trim()) {
                case "SUM":
                    return SummaryItemType.Sum;
                case "COUNT":
                    return SummaryItemType.Count;
                case "AVERAGE":
                    return SummaryItemType.Average;
                case "MAX":
                    return SummaryItemType.Max;
                case "MIN":
                    return SummaryItemType.Min;
                case "CUSTOM":
                    return SummaryItemType.Custom;
                default:
                    return SummaryItemType.None;
            }
        }

        public object GetValue(int rowindex, GridColumn column) {
            try {
                return this.mGridView.GetRowCellValue(rowindex, column);
            } catch (Exception) {
                return null;
            }
        }

        public object GetValue(int rowindex, string colName) {
            try {
                return this.mGridView.GetRowCellValue(rowindex, colName);
            } catch (Exception) {
                return null;
            }
        }

        public object GetValue(int rowindex, int colindex) {
            try {
                if (rowindex < this.mGridView.RowCount && colindex < this.mGridView.Columns.Count) {
                    string fieldname = this.GetFieldName(colindex);
                    return this.mGridView.GetRowCellValue(rowindex, fieldname);
                } else {
                    return null;
                }
            } catch (Exception) {
                return null;
            }
        }

        private string ShowSaveFileDialog(string title, string filter) {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) {
                name = name.Substring(n, name.Length - n);
            }
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) {
                return dlg.FileName;
            }
            return string.Empty;
        }

        public void BindDataTable() {
            if (this.mDataTable == null) {
                return;
            }
            this.DataSource = this.mDataTable;
            this.DataMember = string.Empty;
        }

        public void BindData() {
            if (this.mDataTable == null) {
                return;
            }
            this.DataSource = this.mDataSet;
            this.DataMember = this.mTableName;
            this.SetIndicatorWidth(this.mGridView.RowCount);
        }

        public void BindDataView() {
            this.DataSource = this.mDataView;
            this.DataMember = string.Empty;
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            this.OnCellClick(this,
                                   new CellClickEventArgs(((TextEdit)sender), this.mGridView.FocusedRowHandle,
                                                                this.mGridView.FocusedColumn));
        }

        private void Cell_DoubleClick(object sender, EventArgs e) {
            this.OnCellDoubleClick(this,
                                   new CellDoubleClickEventArgs(((TextEdit) sender), this.mGridView.FocusedRowHandle,
                                                                this.mGridView.FocusedColumn));
        }

        private void Cell_Enter(object sender, EventArgs e) {
            try {
                ((TextEdit) sender).Tag = false;
            } catch (Exception ex) {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ComboSelectedIndexChange(object sender, EventArgs e) {
            try {
                LookUpEdit edit = (LookUpEdit) sender;
                this.OnGridComboChange(this,
                                       new GridComboChangeEventArgs(edit, this.mGridView.FocusedRowHandle,
                                                                    this.mGridView.FocusedColumn));
                BindingManagerBase bm = this.BindingContext[edit.Properties.DataSource];
                if (edit.EditValue == null) {
                    bm.Position = 0;
                } else {
                    int index = edit.Properties.GetDataSourceRowIndex(edit.Properties.ValueMember, edit.EditValue);
                    if (index > -1) {
                        int bmpos = UIFunctions.GetBindingManagerPosition(bm, index);
                        bm.Position = bmpos;
                    }
                }
            } catch (Exception) {
            }
        }

        private void DateEditValueChanged(object sender, EventArgs e) {
            try {
                DateEdit edit = (DateEdit) sender;
                this.OnGridDateChange(this,
                                      new GridDateChangeEventArgs(edit, this.mGridView.FocusedRowHandle,
                                                                  this.mGridView.FocusedColumn));
            } catch (Exception) {
            }
        }

        public void CreateGrid(DataView dataview) {
            this.mDataView = dataview;
            this.mDataTable = this.mDataView.Table;
        }

        public void CreateGrid(DataSet dataset, DataTable datatable, string tablename) {
            this.mDataSet = dataset;
            this.mDataTable = datatable;
            this.mTableName = tablename;
        }

        public void CreateGrid(DataTable datatable) {
            this.mDataTable = datatable;
        }

        private void gridView_DrawFooterText(object sender, RowObjectCustomDrawEventArgs e) {
            e.Painter.DrawObject(e.Info);
            Rectangle r = new Rectangle(e.Bounds.Left, e.Bounds.Bottom - e.Bounds.Height, e.Bounds.Width,
                                        e.Bounds.Height);
            this.mGridView.Appearance.FooterPanel.DrawString(e.Cache, "   " + this.mTextFooter, r);
            e.Handled = true;
        }

        public void EndEdit() {
            try {
                this.EndEditGrid();
            } catch (Exception) {
            }
        }

        private void EndEditGrid() {
            try {
                ColumnView view = (ColumnView) this.FocusedView;
                view.CloseEditor();
                view.UpdateCurrentRow();
            } catch (Exception) {
            }
        }

        private void ExportTo(IExportProvider provider, string caption) {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            BaseExportLink link = this.mGridView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            WaitDialogForm dlg = new WaitDialogForm(caption, MSG_EXPORT_PROCESSING);
            link.ExportTo(true);
            dlg.Close();
            provider.Dispose();
            Cursor.Current = currentCursor;
        }

        public void ExportToHML() {
            string fileName = this.ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName.Length != 0) {
                this.ExportTo(new ExportHtmlProvider(fileName), MSG_EXPORT_HTML);
                this.OpenFile(fileName);
            }
        }

        public void ExportToTXT() {
            string fileName = this.ShowSaveFileDialog("Text Document", "Text Files|*.txt");
            if (fileName.Length != 0) {
                this.ExportTo(new ExportTxtProvider(fileName), MSG_EXPORT_TEXT);
                this.OpenFile(fileName);
            }
        }

        public void ExportToXLS() {
            string fileName = this.ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName.Length != 0) {
                this.ExportTo(new ExportXlsProvider(fileName), MSG_EXPORT_XLS);
                this.OpenFile(fileName);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0) {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            if (e.RowHandle == this.mGridView.FocusedRowHandle) {
                AppearanceHelper.Apply(e.Appearance,
                                       new AppearanceDefault(SystemColors.Highlight, SystemColors.Control,
                                                             HorzAlignment.Center, VertAlignment.Default,
                                                             new Font(AppearanceObject.DefaultFont, FontStyle.Bold)));
            }
            e.Info.ImageIndex = -1;
        }

        private void gridView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
            if (e.SummaryProcess == CustomSummaryProcess.Start) {
                this.mCustomCount.Clear();
            }
            if (e.SummaryProcess == CustomSummaryProcess.Calculate) {
                if ((e.FieldValue != null) && (this.mCustomCount.IndexOf(e.FieldValue) < 0)) {
                    this.mCustomCount.Add(e.FieldValue);
                }
            }
            if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
                e.TotalValue = this.mCustomCount.Count;
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e) {
            if (!this.mGridView.OptionsBehavior.Editable) {
                GridView view = sender as GridView;
                if (view != null) {
                    GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));
                    if (hi.RowHandle >= 0) {
                        if (this.ChooseRow != null) {
                            this.ChooseRow(this.mGridView,
                                           new SelectRowEventArgs(
                                               this.mGridView.GetDataRow(this.mGridView.FocusedRowHandle)));
                        }
                    }
                }
            }
        }

        private void mGridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e) {
            try {
                if (this.mListHeader.Count > 0) {
                    GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                    GridCheckHeaderColumn column = null;
                    foreach (GridCheckHeaderColumn c in this.mListHeader) {
                        if (c.Column == info.Column) {
                            column = c;
                            break;
                        }
                    }
                    if (column != null) {
                        info.GroupText = "         " + info.GroupText.TrimStart();
                        e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
                        e.Painter.DrawObject(e.Info);
                        Rectangle r = info.ButtonBounds;
                        r.Offset(r.Width*2, 0);
                        column.DrawCheckBox(e.Graphics, r, this.IsGroupRowSelected(column, e.RowHandle));
                        e.Handled = true;
                    }
                }
            } catch {
            }
        }

        private void mGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
            try {
                if (this.mListHeader.Count > 0) {
                    GridCheckHeaderColumn column = null;
                    foreach (GridCheckHeaderColumn c in this.mListHeader) {
                        if (c.Column == e.Column) {
                            column = c;
                            break;
                        }
                    }
                    if (column != null) {
                        e.Info.InnerElements.Clear();
                        e.Painter.DrawObject(e.Info);
                        bool check = false;
                        int count = 0;
                        if (column.Column.UnboundType == UnboundColumnType.Bound) {
                            for (int i = 0; i < this.mGridView.RowCount; i++) {
                                if (Convert.ToInt16(this.GetValue(i, column.Column)) == 1) {
                                    count++;
                                }
                            }
                        } else {
                            foreach (object obj in column.Selection) {
                                if (Convert.ToInt16(obj) == 1) {
                                    count++;
                                }
                            }
                        }
                        check = count == this.mGridView.DataRowCount;
                        column.DrawCheckBox(e.Graphics, e.Bounds, check);
                        e.Handled = true;
                    }
                }
            } catch {
            }
        }

        private void mGridView_Click(object sender, EventArgs e) {
            try {
                if (this.mListHeader.Count > 0) {
                    GridHitInfo info;
                    Point pt = this.mGridView.GridControl.PointToClient(MousePosition);
                    info = this.mGridView.CalcHitInfo(pt);
                    GridCheckHeaderColumn column = null;
                    foreach (GridCheckHeaderColumn c in this.mListHeader) {
                        if (c.Column == info.Column) {
                            column = c;
                            break;
                        }
                    }
                    if (column != null) {
                        if (info.InColumn) {
                            int count = 0;
                            if (column.Column.UnboundType == UnboundColumnType.Bound) {
                                for (int i = 0; i < this.mGridView.RowCount; i++) {
                                    if (Convert.ToInt16(this.GetValue(i, column.Column)) == 1) {
                                        count++;
                                    }
                                }
                            } else {
                                foreach (object obj in column.Selection) {
                                    if (Convert.ToInt16(obj) == 1) {
                                        count++;
                                    }
                                }
                            }
                            if (count == this.mGridView.RowCount) {
                                this.ClearSelection(column);
                            } else {
                                this.SelectAll(column);
                            }
                        }
                        if (info.InRow && this.mGridView.IsGroupRow(info.RowHandle) &&
                            info.HitTest != GridHitTest.RowGroupButton) {
                            bool selected = this.IsGroupRowSelected(column, info.RowHandle);
                            this.SelectGroup(column, info.RowHandle, !selected);
                        }
                    }
                }
            } catch {
            }
        }

        private void SelectGroup(GridCheckHeaderColumn column, int rowHandle, bool select) {
            if (this.IsGroupRowSelected(column, rowHandle) && select) {
                return;
            }
            for (int i = 0; i < this.mGridView.GetChildRowCount(rowHandle); i++) {
                int childRowHandle = this.mGridView.GetChildRowHandle(rowHandle, i);
                if (this.mGridView.IsGroupRow(childRowHandle)) {
                    this.SelectGroup(column, childRowHandle, select);
                } else {
                    this.SelectRow(column, childRowHandle, select, false);
                }
            }
            this.Invalidate();
            this.ViewGrid.RefreshRowCell(rowHandle, column.Column);
        }

        public void SelectRow(GridCheckHeaderColumn column, int rowHandle, bool select) {
            this.SelectRow(column, rowHandle, select, true);
        }

        private void SelectRow(GridCheckHeaderColumn column, int rowHandle, bool select, bool invalidate) {
            if (this.IsRowSelected(column, rowHandle) == select) {
                return;
            }
            object row = this.mGridView.GetRow(rowHandle);
            if (column.Column.UnboundType == UnboundColumnType.Bound) {
                if (select) {
                    this.SetValue(rowHandle, column.Column, Convert.ToInt16(1));
                } else {
                    this.SetValue(rowHandle, column.Column, Convert.ToInt16(0));
                }
            } else {
                if (select) {
                    column.Selection.Add(row);
                } else {
                    column.Selection.Remove(row);
                }
            }
            if (invalidate) {
                this.Invalidate();
                this.ViewGrid.RefreshRowCell(rowHandle, column.Column);
            }
        }

        public void ClearSelection(GridCheckHeaderColumn column) {
            if (column.Column.UnboundType == UnboundColumnType.Bound) {
                for (int i = 0; i < this.mGridView.DataRowCount; i++) {
                    this.SetValue(i, column.Column, Convert.ToInt16(0));
                }
            } else {
                column.Selection.Clear();
                for (int i = 0; i < this.mGridView.DataRowCount; i++) {
                    column.Selection.Add(Convert.ToInt16(0));
                }
            }
            this.Invalidate();
            for (int i = 0; i < this.mGridView.DataRowCount; i++){
                this.ViewGrid.RefreshRowCell(i, column.Column);
            }
        }

        public void SelectAll(GridCheckHeaderColumn column) {
            if (column.Column.UnboundType == UnboundColumnType.Bound) {
                for (int i = 0; i < this.mGridView.DataRowCount; i++) {
                    this.SetValue(i, column.Column, Convert.ToInt16(1));
                }
            } else {
                column.Selection.Clear();
                for (int i = 0; i < this.mGridView.DataRowCount; i++) {
                    column.Selection.Add(Convert.ToInt16(1));
                }
            }
            this.Invalidate();
            for (int i = 0; i < this.mGridView.DataRowCount; i++){
                this.ViewGrid.RefreshRowCell(i, column.Column);
            }
        }

        private bool IsGroupRowSelected(GridCheckHeaderColumn column, int rowHandle) {
            for (int i = 0; i < this.mGridView.GetChildRowCount(rowHandle); i++) {
                int row = this.mGridView.GetChildRowHandle(rowHandle, i);
                if (this.mGridView.IsGroupRow(row)) {
                    if (!this.IsGroupRowSelected(column, row)) {
                        return false;
                    }
                } else if (!this.IsRowSelected(column, row)) {
                    return false;
                }
            }
            return true;
        }

        private bool IsRowSelected(GridCheckHeaderColumn column, int rowHandle) {
            if (this.mGridView.IsGroupRow(rowHandle)) {
                return this.IsGroupRowSelected(column, rowHandle);
            }
            if (column.Column.UnboundType == UnboundColumnType.Bound) {
                return Convert.ToBoolean(this.GetValue(rowHandle, column.Column));
            } else {
                return column.Selection.IndexOf(this.mGridView.GetRow(rowHandle)) != -1;
            }
        }

        private void mGridView_GotFocus(object sender, EventArgs e)
        {
            if (this.mAllowFocus && this.mGridView.RowCount > 0 && this.mGridView.VisibleColumns.Count > 0)
            {
                this.mGridView.FocusedRowHandle = 0;
                this.mGridView.FocusedColumn = this.mGridView.VisibleColumns[0];
            }
        }

        private void gridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
            if (this.ValidateColumn != null) {
                this.ValidateColumn(sender, new ColumnInfoEventArgs(e, this.CurrentColumnName));
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Up) && (this.mGridView.IsFirstRow) && (this.mGridView.OptionsView.ShowAutoFilterRow)) {
                this.mGridView.FocusedRowHandle = CurrencyDataController.FilterRow;
                if (this.mGridView.IsMultiSelect) {
                    this.mGridView.ClearSelection();
                }
            } else if ((e.KeyCode == Keys.Down) && (this.mGridView.FocusedRowHandle < 0)) {
                this.mGridView.SelectRow(0);
            } else if ((e.KeyCode == Keys.Enter) && (this.mGridView.FocusedRowHandle >= 0)) {
                if (this.ChooseRow != null) {
                    this.ChooseRow(this.mGridView,
                                   new SelectRowEventArgs(this.mGridView.GetDataRow(this.mGridView.FocusedRowHandle)));
                }
            } else if ((e.KeyCode == Keys.Escape) && this.FindForm() != null && this.FindForm() is FrmDataList) {
                this.FindForm().DialogResult = DialogResult.Cancel;
            }
        }

        private void lookupedit_ButtonsFooterClick(object sender, ButtonsFooterClickEventArgs e) {
            if (this.ComboBoxClick != null) {
                this.ComboBoxClick(sender,
                                   new ComboBoxClickEventArgs(e.ButtonsTag, this.mGridView.FocusedColumn.FieldName));
            }
        }

        protected virtual void OnButtonClick(object sender, ButtonClickEventArgs e) {
            if (this.ButtonClick != null) {
                this.ButtonClick(this, e);
            }
        }

        private void buttonedit_ButtonClick(object sender, ButtonPressedEventArgs e) {
            this.OnButtonClick(this,
                               new ButtonClickEventArgs(this.mGridView.FocusedColumn, this.mGridView.FocusedRowHandle,
                                                        e.Button));
        }

        public void MoveFirstRecord() {
            try {
                this.mGridView.MoveFirst();
            } catch (Exception) {
            }
        }

        public void MoveLastRecord() {
            try {
                this.mGridView.MoveLast();
            } catch (Exception) {
            }
        }

        public void MoveNextRecord() {
            try {
                this.mGridView.MoveNext();
            } catch (Exception) {
            }
        }

        public void MovePrevRecord() {
            try {
                this.mGridView.MovePrev();
            } catch (Exception) {
            }
        }

        protected virtual void OnCellClick(object sender, CellClickEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(this, e);
            }
        }

        protected virtual void OnCellDoubleClick(object sender, CellDoubleClickEventArgs e) {
            if (this.CellDoubleClick != null) {
                this.CellDoubleClick(this, e);
            }
        }

        protected virtual void OnGridComboChange(object sender, GridComboChangeEventArgs e) {
            if (this.GridComboChange != null) {
                this.GridComboChange(this, e);
            }
        }

        protected virtual void OnGridDateChange(object sender, GridDateChangeEventArgs e) {
            if (this.GridDateChange != null) {
                this.GridDateChange(this, e);
            }
        }

        protected virtual void OnTextBoxLookup(object sender, TextBoxLookupEventArgs e) {
            if (this.TextBoxLookup != null) {
                this.TextBoxLookup(this, e);
            }
        }

        protected virtual void OnTextBoxMultiLookup(object sender, TextBoxMultiLookupEventArgs e) {
            if (this.TextBoxMultiLookup != null) {
                this.TextBoxMultiLookup(this, e);
            }
        }

        private void numedit_EditValueChanging(object sender, ChangingEventArgs e) {
            if (this.mHashNumberLimit.ContainsKey(this.mGridView.FocusedColumn.FieldName))
            {
                NumberLimit numberlimit = (NumberLimit)this.mHashNumberLimit[this.mGridView.FocusedColumn.FieldName];
                if ((numberlimit.Max == 0) && (numberlimit.Min == 0))
                {
                    this.OnNumbericValueChanging(this,
                                             new GridNumbericValueChangingEventArgs(this.mGridView.FocusedColumn,
                                                                                    this.mGridView.FocusedRowHandle, e));
                }
                else
                {
                    decimal number = decimal.Parse(e.NewValue.ToString(), NumberStyles.Any);
                    if ((number > numberlimit.Max) || (number < numberlimit.Min))
                        e.Cancel = true;
                    else
                        this.OnNumbericValueChanging(this,
                                             new GridNumbericValueChangingEventArgs(this.mGridView.FocusedColumn,
                                                                                    this.mGridView.FocusedRowHandle, e));
                }
            }
            else
            {
                this.OnNumbericValueChanging(this,
                                             new GridNumbericValueChangingEventArgs(this.mGridView.FocusedColumn,
                                                                                    this.mGridView.FocusedRowHandle, e));
            }
        }

        protected virtual void OnNumbericValueChanging(object sender, GridNumbericValueChangingEventArgs e) {
            if (this.NumbericValueChanging != null) {
                this.NumbericValueChanging(this, e);
            }
        }

        private void checkedit_CheckedChanged(object sender, EventArgs e) {
            this.OnCheckBoxChanged(this,
                                   new GridCheckBoxChangeEventArgs(this.mGridView.FocusedColumn,
                                                                   this.mGridView.FocusedRowHandle, (CheckEdit) sender));
        }

        protected virtual void OnCheckBoxChanged(object sender, GridCheckBoxChangeEventArgs e) {
            if (this.CheckBoxChanged != null) {
                this.CheckBoxChanged(this, e);
            }
        }

        private void OpenFile(string fileName) {
            if (
                XtraMessageBox.Show(MSG_EXPORT_OPEN_FILE, "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes) {
                try {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                } catch {
                    XtraMessageBox.Show(this, MSG_ERROR_OPEN_FILE, Application.ProductName, MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
        }

        private void Properties_ButtonPressed(object sender, ButtonPressedEventArgs e) {
            try {
                if (this.mGridView.FocusedValue != null) {
                    this.OnTextBoxLookup(this,
                                         new TextBoxLookupEventArgs(((TextEdit) sender), this.mGridView.FocusedRowHandle,
                                                                    this.mGridView.FocusedColumn));
                }
            } catch (Exception) {
            }
        }

        private void Properties_MultiButtonPressed(object sender, ButtonPressedEventArgs e) {
            try {
                if (this.mGridView.FocusedValue != null) {
                    this.OnTextBoxMultiLookup(this,
                                              new TextBoxMultiLookupEventArgs(((TextEdit) sender),
                                                                              this.mGridView.FocusedRowHandle,
                                                                              this.mGridView.FocusedColumn));
                }
            } catch (Exception) {
            }
        }

        public void ResetBinding() {
            this.DataSource = null;
            this.DataMember = string.Empty;
        }

        public void SelectRow() {
            try {
                BindingManagerBase bm = this.BindingContext[this.DataSource, this.DataMember];
                if (bm.Position >= 0) {
                    this.mGridView.SelectRow(this.mGridView.GetRowHandle(bm.Position));
                }
            } catch (Exception) {
            }
        }

        public void SetCheckHeaderColumn(FieldInfo field) {
            try {
                if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                    return;
                }
                RepositoryItemCheckEdit checkedit = new RepositoryItemCheckEdit();
                checkedit.AutoHeight = false;
                checkedit.NullStyle = StyleIndeterminate.Unchecked;
                checkedit.ValueChecked = Convert.ToInt16(1);
                checkedit.ValueUnchecked = Convert.ToInt16(0);
                GridColumn checkcolumn = new GridColumn();
                this.mListHeader.Add(new GridCheckHeaderColumn(checkcolumn, checkedit));
                checkcolumn.Name = field.FieldName;
                checkcolumn.FieldName = field.FieldName;
                checkcolumn.Caption = field.DisplayName;
                //switch (field.IsFixedColumn)
                //{
                //    case 1:
                //        checkcolumn.Fixed = FixedStyle.Left;
                //        break;
                //    case 2:
                //        checkcolumn.Fixed = FixedStyle.Right;
                //        break;
                //    default:
                //        checkcolumn.Fixed = FixedStyle.None;
                //        break;
                //}
                //checkcolumn.OptionsFilter.AllowFilter = field.AllowFilter;
                checkcolumn.OptionsColumn.AllowDragInVisible = false;
                checkcolumn.OptionsColumn.AllowSort = DefaultBoolean.False;
                checkcolumn.ColumnEdit = checkedit;
                checkedit.CheckedChanged += new EventHandler(this.checkedit_CheckedChanged);
                checkedit.QueryCheckStateByValue +=
                    new QueryCheckStateByValueEventHandler(this.checkedit_QueryCheckStateByValue);
                checkedit.QueryValueByCheckState +=
                    new QueryValueByCheckStateEventHandler(this.checkedit_QueryValueByCheckState);
                this.mGridView.Columns.Add(checkcolumn);
                //if (field.IsSum)
                //{
                //    checkcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
                //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName, this.mGridView.Columns[field.FieldName], field.FormatSum);
                //}
                if (!field.IsBound) {
                    checkcolumn.UnboundType = UnboundColumnType.Boolean;
                }
            } catch (Exception) {
                throw;
            }
        }

        private void checkedit_QueryValueByCheckState(object sender, QueryValueByCheckStateEventArgs e) {
            CheckEdit edit = sender as CheckEdit;
            object val = edit.EditValue;
            switch (e.CheckState) {
                case CheckState.Checked:
                    e.Value = 1;
                    break;
                case CheckState.Unchecked:
                    e.Value = 0;
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        private void checkedit_QueryCheckStateByValue(object sender, QueryCheckStateByValueEventArgs e) {
            string val = "False";
            if(e.Value!=null)
                val = e.Value.ToString();
            switch (val) {
                case "True":
                    e.CheckState = CheckState.Checked;
                    break;
                case "False":
                    e.CheckState = CheckState.Unchecked;
                    break;
                case "Yes":
                    goto case "True";
                case "No":
                    goto case "False";
                case "1":
                    goto case "True";
                case "0":
                    goto case "False";
                default:
                    e.CheckState = CheckState.Indeterminate;
                    break;
            }
            e.Handled = true;
        }

        public void SetCheckColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemCheckEdit checkedit = new RepositoryItemCheckEdit();
            checkedit.AutoHeight = false;
            checkedit.NullStyle = StyleIndeterminate.Unchecked;
            checkedit.ValueChecked = Convert.ToInt16(1);
            checkedit.ValueUnchecked = Convert.ToInt16(0);
            GridColumn checkcolumn = new GridColumn();
            checkcolumn.Name = field.FieldName;
            checkcolumn.FieldName = field.FieldName;
            //checkcolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        checkcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        checkcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        checkcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            checkcolumn.OptionsColumn.AllowDragInVisible = false;
            checkcolumn.ColumnEdit = checkedit;
            checkedit.CheckedChanged += new EventHandler(this.checkedit_CheckedChanged);
            this.mGridView.Columns.Add(checkcolumn);
            //if (field.IsSum){
            //    checkcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                checkcolumn.UnboundType = UnboundColumnType.Boolean;
            }
        }

        public void SetCustomComboColumn(FieldInfo field, List<ItemCombobox> itemlist) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemComboBox comboedit = new RepositoryItemComboBox();
            comboedit.AutoHeight = false;
            comboedit.AllowNullInput = DefaultBoolean.True;
            comboedit.NullText = string.Empty;
            comboedit.TextEditStyle = TextEditStyles.Standard;
            foreach (ItemCombobox item in itemlist) {
                comboedit.Items.Add(item);
            }
            comboedit.DropDownRows = 10;
            GridColumn combocolumn = new FTSGridColumn();
            combocolumn.Name = field.FieldName;
            combocolumn.FieldName = field.FieldName;
            //combocolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        combocolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        combocolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        combocolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            combocolumn.OptionsColumn.AllowDragInVisible = false;
            combocolumn.ColumnEdit = comboedit;
            //combocolumn.ColumnEditName = "Name";
            this.mGridView.Columns.Add(combocolumn);
            //if (field.IsSum){
            //    combocolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                combocolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetComboImageColumn(FieldInfo field, ArrayList itemlist, ImageCollection imglist)
        {            
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0)
            {
                return;
            }
            RepositoryItemImageComboBox imageComboBox = new RepositoryItemImageComboBox();
            imageComboBox.AutoHeight = false;
            imageComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            imageComboBox.NullText = "";
            imageComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            imageComboBox.SmallImages = imglist;
            foreach (object oj in itemlist)
            {
                ItemImageCombobox item = (ItemImageCombobox)oj;
                imageComboBox.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(item.Description, item.Value, item.ImageIndex));
            }
            imageComboBox.PopupFormWidth = 100;
            imageComboBox.DropDownRows = 10;
            GridColumn imageColumn = new GridColumn();
            imageColumn.Name = field.FieldName;
            imageColumn.FieldName = field.FieldName;
            //imageColumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn)
            //{
            //    case 1:
            //        imageColumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        imageColumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        imageColumn.Fixed = FixedStyle.None;
            //        break;
            //}
            //imageColumn.OptionsFilter.AllowFilter = field.AllowFilter;
            imageColumn.OptionsColumn.AllowDragInVisible = false;
            imageColumn.ColumnEdit = imageComboBox;
            this.mGridView.Columns.Add(imageColumn);
            //if (field.IsSum)
            //{
            //    imageColumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName, this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}            
        }
        public void SetFreeComboColumn(FieldInfo field, object objList, string fieldName) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemMRUEdit mruedit = new RepositoryItemMRUEdit();
            mruedit.AutoHeight = false;
            mruedit.AllowNullInput = DefaultBoolean.True;
            mruedit.NullText = string.Empty;
            mruedit.TextEditStyle = TextEditStyles.Standard;
            if (objList is DataTable) {
                DataTable tbl = (DataTable) objList;
                foreach (DataRow row in tbl.Rows) {
                    mruedit.Items.Add(row[fieldName]);
                }
            } else if (objList is DataView) {
                DataView view = (DataView) objList;
                foreach (DataRowView row in view) {
                    mruedit.Items.Add(row[fieldName]);
                }
            }
            GridColumn combocolumn = new FTSGridColumn();
            combocolumn.Name = field.FieldName;
            combocolumn.FieldName = field.FieldName;
            //combocolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        combocolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        combocolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        combocolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            combocolumn.OptionsColumn.AllowDragInVisible = false;
            combocolumn.ColumnEdit = mruedit;
            this.mGridView.Columns.Add(combocolumn);
            //if (field.IsSum){
            //    combocolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                combocolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetComboColumn(FieldInfo field, ArrayList itemlist) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemComboBox comboedit = new RepositoryItemComboBox();
            comboedit.AutoHeight = false;
            comboedit.AllowNullInput = DefaultBoolean.True;
            comboedit.NullText = string.Empty;
            comboedit.TextEditStyle = TextEditStyles.Standard;
            foreach (object oj in itemlist) {
                comboedit.Items.Add(oj);
            }
            comboedit.PopupFormWidth = 100;
            comboedit.DropDownRows = 10;
            GridColumn combocolumn = new FTSGridColumn();
            combocolumn.Name = field.FieldName;
            combocolumn.FieldName = field.FieldName;
            //combocolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        combocolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        combocolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        combocolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            combocolumn.OptionsColumn.AllowDragInVisible = false;
            combocolumn.ColumnEdit = comboedit;
            this.mGridView.Columns.Add(combocolumn);
            //if (field.IsSum){
            //    combocolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                combocolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetComboMultiColumn(FieldInfo field, DataTable filltable, string condition, string displaycolumnname,
                                        string boundcolumnname, ComboComType combotype, bool showfooter) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            DataView view = new DataView(filltable);
            view.RowFilter = condition;
            RepositoryItemLookUpEdit lookupedit = new RepositoryItemLookUpEdit();
            lookupedit.Tag = condition;
            lookupedit.AutoHeight = false;
            lookupedit.ShowHeader = false;
            if (showfooter) {
                lookupedit.ShowFooter = true;
            } else {
                lookupedit.ShowFooter = false;
            }
            lookupedit.HeaderClickMode = HeaderClickMode.AutoSearch;
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = TextEditStyles.Standard;
            switch (combotype) {
                case ComboComType.NameID:
                    lookupedit.DataSource = view;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 320;
                    break;
                case ComboComType.IDOnly:
                    lookupedit.DataSource = view;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 80;
                    break;
                case ComboComType.NameOnly:
                    lookupedit.DataSource = view;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 240;
                    break;
                case ComboComType.IDName:
                    lookupedit.DataSource = view;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 320;
                    break;
                default:
                    break;
            }
            lookupedit.DropDownRows = 10;
            lookupedit.AppearanceDropDownHeader.Options.UseTextOptions = true;
            lookupedit.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
            GridColumn lookupcolumn = new FTSGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            //lookupcolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        lookupcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        lookupcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        lookupcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
            this.mGridView.Columns.Add(lookupcolumn);
            //if (field.IsSum){
            //    lookupcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetComboCheckList(FieldInfo field, DataTable filltable, string displaycolumnname,
                                       string boundcolumnname, ComboComType combotype, bool showfooter)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemCheckedComboBoxEdit lookupedit = new RepositoryItemCheckedComboBoxEdit();
            lookupedit.Tag = string.Empty;
            lookupedit.AutoHeight = false;
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = TextEditStyles.Standard;
            switch (combotype)
            {
                case ComboComType.NameID:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    break;
                case ComboComType.IDOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    break;
                case ComboComType.NameOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    break;
                case ComboComType.IDName:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    break;
                default:
                    break;
            }
            lookupedit.DropDownRows = 10;
            GridColumn lookupcolumn = new FTSGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
           lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            this.mGridView.Columns.Add(lookupcolumn);
            if (!field.IsBound)
            {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetComboMultiColumn(FieldInfo field, DataTable filltable, string displaycolumnname,
                                        string boundcolumnname, ComboComType combotype, bool showfooter) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemLookUpEdit lookupedit = new RepositoryItemLookUpEdit();
            lookupedit.Tag = string.Empty;
            lookupedit.AutoHeight = false;
            lookupedit.ShowHeader = false;
            if (showfooter) {
                lookupedit.ShowFooter = true;
            } else {
                lookupedit.ShowFooter = false;
            }
            lookupedit.HeaderClickMode = HeaderClickMode.AutoSearch;
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = TextEditStyles.Standard;
            switch (combotype) {
                case ComboComType.NameID:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 320;
                    break;
                case ComboComType.IDOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 80;
                    break;
                case ComboComType.NameOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 240;
                    break;
                case ComboComType.IDName:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.Columns.Add(new LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 320;
                    break;
                default:
                    break;
            }
            lookupedit.DropDownRows = 10;
            lookupedit.AppearanceDropDownHeader.Options.UseTextOptions = true;
            lookupedit.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
            GridColumn lookupcolumn = new FTSGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            //lookupcolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        lookupcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        lookupcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        lookupcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
            this.mGridView.Columns.Add(lookupcolumn);
            //if (field.IsSum){
            //    lookupcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetComboMultiColumn(FieldInfo field, List<ItemCombobox> list) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemLookUpEdit lookupedit = new RepositoryItemLookUpEdit();
            lookupedit.Tag = string.Empty;
            lookupedit.AutoHeight = false;
            lookupedit.ShowHeader = false;
            lookupedit.ShowFooter = false;
            lookupedit.HeaderClickMode = HeaderClickMode.AutoSearch;
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = TextEditStyles.Standard;
            lookupedit.DataSource = list;
            lookupedit.DisplayMember = "Name";
            lookupedit.ValueMember = "Id";
            lookupedit.Columns.Clear();
            lookupedit.Columns.Add(new LookUpColumnInfo("Name", string.Empty, 240));
            lookupedit.PopupWidth = 240;
            lookupedit.DropDownRows = 10;
            lookupedit.AppearanceDropDownHeader.Options.UseTextOptions = true;
            lookupedit.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
            GridColumn lookupcolumn = new FTSGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            //lookupcolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn) {
            //    case 1:
            //        lookupcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        lookupcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        lookupcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
            this.mGridView.Columns.Add(lookupcolumn);
            //if (field.IsSum) {
            //    lookupcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetDateColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemDateEdit dateedit = new RepositoryItemDateEdit();
            dateedit.AutoHeight = false;
            dateedit.DisplayFormat.FormatString = "dd/MM/yyyy";
            dateedit.DisplayFormat.FormatType = FormatType.DateTime;
            dateedit.EditFormat.FormatString = "dd/MM/yyyy";
            dateedit.EditFormat.FormatType = FormatType.DateTime;
            dateedit.Mask.EditMask = "dd/MM/yy";
            GridColumn datecolumn = new FTSGridColumn();
            datecolumn.Name = field.FieldName;
            datecolumn.FieldName = field.FieldName;
            //datecolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        datecolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        datecolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        datecolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            datecolumn.OptionsColumn.AllowDragInVisible = false;
            datecolumn.ColumnEdit = dateedit;
            dateedit.EditValueChanged += new EventHandler(this.DateEditValueChanged);
            this.mGridView.Columns.Add(datecolumn);
            //if (field.IsSum){
            //    datecolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                datecolumn.UnboundType = UnboundColumnType.DateTime;
            }
        }
        public void SetDateTimeColumn(FieldInfo field, string editmark)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemDateEdit dateedit = new RepositoryItemDateEdit();
            dateedit.AutoHeight = false;
            //dateedit.DisplayFormat.FormatString = "t";
            //dateedit.DisplayFormat.FormatType = FormatType.DateTime;
            //dateedit.EditFormat.FormatString = "t";
            //dateedit.EditFormat.FormatType = FormatType.DateTime;
            dateedit.Mask.EditMask = editmark;
            dateedit.Mask.UseMaskAsDisplayFormat = true;

            GridColumn datecolumn = new FTSGridColumn();
            datecolumn.Name = field.FieldName;
            datecolumn.FieldName = field.FieldName;
            //datecolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        datecolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        datecolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        datecolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            datecolumn.OptionsColumn.AllowDragInVisible = false;
            datecolumn.ColumnEdit = dateedit;
            dateedit.EditValueChanged += new EventHandler(DateEditValueChanged);
            this.mGridView.Columns.Add(datecolumn);
            //if (field.IsSum){
            //    datecolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound)
            {
                datecolumn.UnboundType = UnboundColumnType.DateTime;
            }
        }
        public void SetIndicatorWidth(int rowcount) {
            if ((rowcount >= 0) && (rowcount < 100)) {
                this.mGridView.IndicatorWidth = 30;
            } else if ((rowcount >= 100) && (rowcount < 1000)) {
                this.mGridView.IndicatorWidth = 40;
            } else if ((rowcount >= 1000) && (rowcount < 10000)) {
                this.mGridView.IndicatorWidth = 50;
            } else if ((rowcount >= 10000) && (rowcount < 100000)) {
                this.mGridView.IndicatorWidth = 60;
            } else if ((rowcount >= 100000) && (rowcount < 1000000)) {
                this.mGridView.IndicatorWidth = 70;
            } else {
                this.mGridView.IndicatorWidth = 80;
            }
        }

        public void SetLookupTextColumn(FieldInfo field, bool up) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            GridColumn buttoncolumn = new FTSGridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            //buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
            if (up) {
                buttonedit.CharacterCasing = CharacterCasing.Upper;
            } else {
                buttonedit.CharacterCasing = CharacterCasing.Normal;
            }
            //switch (field.IsFixedColumn){
            //    case 1:
            //        buttoncolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        buttoncolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        buttoncolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            buttonedit.Click += new EventHandler(Cell_Click);
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_ButtonPressed);
            buttonedit.ContextMenu = null;
            this.mGridView.Columns.Add(buttoncolumn);
            //if (field.IsSum){
            //    buttoncolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetLookupTextColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            GridColumn buttoncolumn = new FTSGridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            //buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
            buttonedit.CharacterCasing = CharacterCasing.Upper;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        buttoncolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        buttoncolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        buttoncolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            buttonedit.Click += new EventHandler(Cell_Click);
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_ButtonPressed);
            buttonedit.ContextMenu = null;
            this.mGridView.Columns.Add(buttoncolumn);
            //if (field.IsSum){
            //    buttoncolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetMultiLookupTextColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            GridColumn buttoncolumn = new FTSGridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            //buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
            buttonedit.CharacterCasing = CharacterCasing.Upper;
            //switch (field.IsFixedColumn) {
            //    case 1:
            //        buttoncolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        buttoncolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        buttoncolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_MultiButtonPressed);
            buttonedit.ContextMenu = null;
            this.mGridView.Columns.Add(buttoncolumn);
            //if (field.IsSum) {
            //    buttoncolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetNumberColumn(FieldInfo field, int decimalplaces) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit numedit = new RepositoryItemTextEdit();
            numedit.BeginInit();
            numedit.AutoHeight = false;
            numedit.DisplayFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.DisplayFormat.FormatType = FormatType.Numeric;
            numedit.EditFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.EditFormat.FormatType = FormatType.Numeric;
            numedit.Mask.EditMask = "n" + decimalplaces.ToString();
            numedit.Mask.MaskType = MaskType.Numeric;
            numedit.EndInit();
            numedit.ContextMenu = null;
            GridColumn numbercolumn = new FTSGridColumn();
            numbercolumn.Name = field.FieldName;
            numbercolumn.FieldName = field.FieldName;
            //numbercolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        numbercolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        numbercolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        numbercolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            numbercolumn.OptionsColumn.AllowDragInVisible = false;
            numbercolumn.ColumnEdit = numedit;
            numedit.Enter += new EventHandler(this.Cell_Enter);
            numedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            numedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            numedit.Click += new EventHandler(Cell_Click);
            numedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            numedit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.mGridView.Columns.Add(numbercolumn);
            if (!field.IsBound) {
                numbercolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        public void SetNumberColumn(FieldInfo field, int decimalplaces, decimal min, decimal max)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            if (!this.mHashNumberLimit.ContainsKey(field.FieldName))
                this.mHashNumberLimit.Add(field.FieldName, new NumberLimit(min, max));
            RepositoryItemTextEdit numedit = new RepositoryItemTextEdit();
            numedit.BeginInit();
            numedit.AutoHeight = false;
            numedit.DisplayFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.DisplayFormat.FormatType = FormatType.Numeric;
            numedit.EditFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.EditFormat.FormatType = FormatType.Numeric;
            numedit.Mask.EditMask = "n" + decimalplaces.ToString();
            numedit.Mask.MaskType = MaskType.Numeric;
            numedit.EndInit();
            numedit.ContextMenu = null;
            GridColumn numbercolumn = new FTSGridColumn();
            numbercolumn.Name = field.FieldName;
            numbercolumn.FieldName = field.FieldName;
            //numbercolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        numbercolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        numbercolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        numbercolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            numbercolumn.OptionsColumn.AllowDragInVisible = false;
            numbercolumn.ColumnEdit = numedit;
            numedit.Enter += new EventHandler(this.Cell_Enter);
            numedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            numedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            numedit.Click += new EventHandler(Cell_Click);
            numedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            numedit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.mGridView.Columns.Add(numbercolumn);
            if (!field.IsBound)
            {
                numbercolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        public void SetNumberColumnUnbound(FieldInfo field, int decimalplaces) {
            RepositoryItemTextEdit numedit = new RepositoryItemTextEdit();
            numedit.BeginInit();
            numedit.AutoHeight = false;
            numedit.DisplayFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.DisplayFormat.FormatType = FormatType.Numeric;
            numedit.EditFormat.FormatString = "n" + decimalplaces.ToString();
            numedit.EditFormat.FormatType = FormatType.Numeric;
            numedit.Mask.EditMask = "n" + decimalplaces.ToString();
            numedit.Mask.MaskType = MaskType.Numeric;
            numedit.EndInit();
            numedit.ContextMenu = null;
            GridColumn numbercolumn = new FTSGridColumn();
            numbercolumn.Name = field.FieldName;
            numbercolumn.FieldName = field.FieldName;
            //numbercolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        numbercolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        numbercolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        numbercolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            numbercolumn.OptionsColumn.AllowDragInVisible = false;
            numbercolumn.ColumnEdit = numedit;
            numedit.Enter += new EventHandler(this.Cell_Enter);
            numedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            numedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            numedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            numedit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.mGridView.Columns.Add(numbercolumn);
            numbercolumn.UnboundType = UnboundColumnType.Decimal;
        }

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void SetSummary(GridColumn c, string sumtype) {
            c.SummaryItem.SetSummary(this.GetSumType(sumtype), "{0:" + c.ColumnEdit.DisplayFormat.FormatString + "}");
            this.mGridView.GroupSummary.Add(this.GetSumType(sumtype), c.FieldName, c,
                                            "{0:" + c.ColumnEdit.DisplayFormat.FormatString + "}");
        }

        public void ClearSummary(GridColumn c) {
            c.SummaryItem.SetSummary(SummaryItemType.None, string.Empty);
        }

        public void SetPercentColumn(FieldInfo field, int decimalplaces) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit peredit = new RepositoryItemTextEdit();
            peredit.BeginInit();
            peredit.AutoHeight = false;
            peredit.DisplayFormat.FormatString = "p" + decimalplaces.ToString();
            peredit.DisplayFormat.FormatType = FormatType.Numeric;
            peredit.EditFormat.FormatString = "p" + decimalplaces.ToString();
            peredit.EditFormat.FormatType = FormatType.Numeric;
            peredit.Mask.EditMask = "p" + decimalplaces.ToString();
            peredit.Mask.MaskType = MaskType.Numeric;
            peredit.EndInit();
            peredit.ContextMenu = null;
            GridColumn percolumn = new FTSGridColumn();
            percolumn.Name = field.FieldName;
            percolumn.FieldName = field.FieldName;
            //percolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        percolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        percolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        percolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            percolumn.OptionsColumn.AllowDragInVisible = false;
            percolumn.ColumnEdit = peredit;
            peredit.Enter += new EventHandler(this.Cell_Enter);
            peredit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            peredit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            peredit.Click += new EventHandler(Cell_Click);
            peredit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.mGridView.Columns.Add(percolumn);
            //if (field.IsSum){
            //    percolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), "{0:n" + decimalplaces + "}");
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], "{0:n" + decimalplaces + "}");
            //}
            if (!field.IsBound) {
                percolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        public void SetButton(FieldInfo field, string caption) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            buttonedit.Buttons[0].Caption = caption;
            buttonedit.Buttons[0].Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            buttonedit.Buttons[0].Appearance.Options.UseTextOptions = true;
            buttonedit.Buttons[0].Kind = ButtonPredefines.Glyph;
            buttonedit.TextEditStyle = TextEditStyles.HideTextEditor;
            GridColumn buttoncolumn = new GridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            //buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        buttoncolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        buttoncolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        buttoncolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.ButtonClick += new ButtonPressedEventHandler(this.buttonedit_ButtonClick);
            this.mGridView.Columns.Add(buttoncolumn);
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.Object;
            }
        }

        public void SetButton(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            //buttonedit.Buttons[0].Caption = caption;
            buttonedit.Buttons[0].Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            buttonedit.Buttons[0].Appearance.Options.UseTextOptions = true;
            buttonedit.Buttons[0].Kind = ButtonPredefines.Glyph;
            buttonedit.TextEditStyle = TextEditStyles.HideTextEditor;
            GridColumn buttoncolumn = new GridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            //buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        buttoncolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        buttoncolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        buttoncolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.ButtonClick += new ButtonPressedEventHandler(this.buttonedit_ButtonClick);
            this.mGridView.Columns.Add(buttoncolumn);
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.Object;
            }
        }

        public void SetCalculatorColumn(FieldInfo field, int decimalplaces) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemCalcEdit calcedit = new RepositoryItemCalcEdit();
            calcedit.AutoHeight = false;
            calcedit.DisplayFormat.FormatString = "n" + decimalplaces.ToString();
            calcedit.DisplayFormat.FormatType = FormatType.Numeric;
            calcedit.EditFormat.FormatString = "n" + decimalplaces.ToString();
            calcedit.EditFormat.FormatType = FormatType.Numeric;
            calcedit.Mask.EditMask = "n" + decimalplaces.ToString();
            calcedit.Mask.MaskType = MaskType.Numeric;
            calcedit.Mask.UseMaskAsDisplayFormat = true;
            GridColumn calcolumn = new FTSGridColumn();
            calcolumn.Name = field.FieldName;
            calcolumn.FieldName = field.FieldName;
            //calcolumn.Caption = field.DisplayName;
            //switch (field.IsFixedColumn){
            //    case 1:
            //        calcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        calcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        calcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            calcolumn.OptionsColumn.AllowDragInVisible = false;
            calcolumn.ColumnEdit = calcedit;
            calcedit.Enter += new EventHandler(this.Cell_Enter);
            calcedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            calcedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            calcedit.Click += new EventHandler(Cell_Click);
            calcedit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            calcedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            this.mGridView.Columns.Add(calcolumn);
            //if (field.IsSum){
            //    calcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), "{0:n" + decimalplaces + "}");
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], "{0:n" + decimalplaces + "}");
            //}
            if (!field.IsBound) {
                calcolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        private void SetPropertiesGridView() {
            this.mGridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.mGridView.OptionsView.ColumnAutoWidth = false;
            this.mGridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.mGridView.FixedLineWidth = 1;
        }

        public void SetTextColumn(FieldInfo field, bool isuppercase) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.MaxLength = field.MaxLength;
            GridColumn textcolumn = new FTSGridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            //textcolumn.Caption = field.DisplayName;
            textcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            if (isuppercase) {
                textedit.CharacterCasing = CharacterCasing.Upper;
            }
            //switch (field.IsFixedColumn){
            //    case 1:
            //        textcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        textcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        textcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.ColumnEdit = textedit;
            textedit.Enter += new EventHandler(this.Cell_Enter);
            textedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            textedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            textedit.Click += new EventHandler(Cell_Click);
            textedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            textedit.ContextMenu = null;
            this.mGridView.Columns.Add(textcolumn);
            //if (field.IsSum){
            //    textcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetIDTextColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.MaxLength = field.MaxLength;
            GridColumn textcolumn = new FTSGridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            textcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
            textedit.CharacterCasing = CharacterCasing.Upper;
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.ColumnEdit = textedit;
            textedit.Enter += new EventHandler(this.Cell_Enter);
            textedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            textedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            textedit.Click += new EventHandler(Cell_Click);
            textedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            textedit.ContextMenu = null;
            this.mGridView.Columns.Add(textcolumn);
            if (!field.IsBound) {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetTextColumn(FieldInfo field, bool isuppercase, string mask) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.MaxLength = field.MaxLength;
            textedit.Mask.EditMask = mask;
            textedit.Mask.UseMaskAsDisplayFormat = true;
            textedit.Mask.MaskType = MaskType.Numeric;
            GridColumn textcolumn = new FTSGridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            //textcolumn.Caption = field.DisplayName;
            textcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            if (isuppercase) {
                textedit.CharacterCasing = CharacterCasing.Upper;
            }
            //switch (field.IsFixedColumn){
            //    case 1:
            //        textcolumn.Fixed = FixedStyle.Left;
            //        break;
            //    case 2:
            //        textcolumn.Fixed = FixedStyle.Right;
            //        break;
            //    default:
            //        textcolumn.Fixed = FixedStyle.None;
            //        break;
            //}
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.ColumnEdit = textedit;
            textedit.Enter += new EventHandler(this.Cell_Enter);
            textedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            textedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            textedit.EditValueChanging += new ChangingEventHandler(this.numedit_EditValueChanging);
            textedit.ContextMenu = null;
            this.mGridView.Columns.Add(textcolumn);
            //if (field.IsSum){
            //    textcolumn.SummaryItem.SetSummary(this.GetSumType(field.SumType), field.FormatSum);
            //    this.mGridView.GroupSummary.Add(this.GetSumType(field.SumType), field.FieldName,
            //                                    this.mGridView.Columns[field.FieldName], field.FormatSum);
            //}
            if (!field.IsBound) {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetTextFooter(string text) {
            this.mTextFooter = text;
        }

        public void SetValue(int row, GridColumn col, object value) {
            try {
                this.mGridView.SetRowCellValue(row, col, value);
                DataRow datarow = this.mGridView.GetDataRow(row);
                datarow[col.FieldName] = value;
            } catch (Exception) {
            }
        }

        public void SetValue(int row, string col, object value) {
            try {
                this.mGridView.SetRowCellValue(row, col.ToUpper(), value);
                DataRow datarow = this.mGridView.GetDataRow(row);
                datarow[col.ToUpper()] = value;
            } catch (Exception) {
            }
        }

        public void ShowFilterRow() {
            this.mGridView.OptionsView.ShowAutoFilterRow = !this.mGridView.OptionsView.ShowAutoFilterRow;
            if (this.mGridView.FocusedColumn != null) {
                for (int i = 0; i < this.mGridView.Columns.Count; i++) {
                    if (this.mGridView.Columns[i].VisibleIndex == 0) {
                        int ColumnWidth = this.mGridView.Columns[i].Width;
                        this.mGridView.Columns[i].Width = ColumnWidth + 1;
                        this.mGridView.Columns[i].BestFit();
                        this.mGridView.Columns[i].Width = ColumnWidth;
                    }
                }
            }
            if (this.mGridView.OptionsView.ShowAutoFilterRow) {
                this.mGridView.FocusedRowHandle = CurrencyDataController.FilterRow;
            } else {
                this.mGridView.ClearColumnsFilter();
                this.MoveFirstRecord();
            }
            this.Focus();
        }

        private void Cell_EditValueChanged(object sender, EventArgs e) {
            try {
                ((TextEdit) sender).Tag = true;
            } catch (Exception ex) {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public int GetLastVisibleIndex() {
            int visibleindex = -1;
            foreach (GridColumn c in this.ViewGrid.Columns) {
                if (c.VisibleIndex > visibleindex) {
                    visibleindex = c.VisibleIndex;
                }
            }
            return visibleindex;
        }
    }

    public delegate void CellClickEventHandler(object sender, CellClickEventArgs e);

    public delegate void CellDoubleClickEventHandler(object sender, CellDoubleClickEventArgs e);

    public delegate void ComboBoxClickEventHandler(object sender, ComboBoxClickEventArgs e);

    public delegate void GridComboChangeEventHandler(object sender, GridComboChangeEventArgs e);

    public delegate void SelectRowEventHandler(object sender, SelectRowEventArgs e);

    public delegate void TextBoxLeaveEventHandler(object sender, TextBoxLeaveEventArgs e);

    public delegate void TextBoxLookupEventHandler(object sender, TextBoxLookupEventArgs e);

    public delegate void TextBoxMultiLookupEventHandler(object sender, TextBoxMultiLookupEventArgs e);

    public delegate void ValidateColumnEventHandler(object sender, ColumnInfoEventArgs e);

    public delegate void NumbericValueChangingEventHandler(object sender, GridNumbericValueChangingEventArgs e);

    public delegate void CheckBoxChangedEventHandler(object sender, GridCheckBoxChangeEventArgs e);

    public delegate void ButtonClickEventHandler(object sender, ButtonClickEventArgs e);

    public delegate void GridDateChangeEventHandler(object sender, GridDateChangeEventArgs e);

    public class CellClickEventArgs : EventArgs
    {
        private GridColumn mcol;
        private TextEdit mcontrol;
        private int mrow;

        public CellClickEventArgs(TextEdit c, int row, GridColumn col)
        {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }
        public GridColumn col
        {
            get { return this.mcol; }
        }
        public TextEdit control
        {
            get { return this.mcontrol; }
        }
        public int row
        {
            get { return this.mrow; }
        }
    }

    public class CellDoubleClickEventArgs : EventArgs {
        private GridColumn mcol;
        private TreeListColumn mtreecol;
        private TextEdit mcontrol;
        private int mrow;

        public CellDoubleClickEventArgs(TextEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public CellDoubleClickEventArgs(TextEdit c, int row, TreeListColumn treecol) {
            this.mcontrol = c;
            this.mtreecol = treecol;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public TreeListColumn treecol {
            get { return this.mtreecol; }
        }

        public TextEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class ColumnInfoEventArgs : EventArgs {
        private BaseContainerValidateEditorEventArgs mColumnInfo;
        private string mFieldName;

        public ColumnInfoEventArgs(BaseContainerValidateEditorEventArgs columninfo, string fieldname) {
            this.mColumnInfo = columninfo;
            this.mFieldName = fieldname;
        }

        public BaseContainerValidateEditorEventArgs ColumnInfo {
            get { return this.mColumnInfo; }
        }

        public string FieldName {
            get { return this.mFieldName; }
        }
    }

    public class ComboBoxClickEventArgs : EventArgs {
        private string mButtonsTag;
        private string mColumnName;

        public ComboBoxClickEventArgs(string buttonstag, string columnname) {
            this.mButtonsTag = buttonstag;
            this.mColumnName = columnname;
        }

        public string ButtonsTag {
            get { return this.mButtonsTag; }
        }

        public string ColumnName {
            get { return this.mColumnName; }
        }
    }

    public class GridComboChangeEventArgs : EventArgs {
        private GridColumn mcol;
        private LookUpEdit mcontrol;
        private int mrow;

        public GridComboChangeEventArgs(LookUpEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public LookUpEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class SelectRowEventArgs : EventArgs {
        private DataRow mrowvalue;

        public SelectRowEventArgs(DataRow dr) {
            this.mrowvalue = dr;
        }

        public DataRow rowvalue {
            get { return this.mrowvalue; }
        }
    }

    public class TextBoxLeaveEventArgs : EventArgs {
        private GridColumn mcol;
        private TextEdit mcontrol;
        private int mrow;

        public TextBoxLeaveEventArgs(TextEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public TextEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class TextBoxLookupEventArgs : EventArgs {
        private GridColumn mcol;
        private TreeListColumn mtreecol;
        private TextEdit mcontrol;
        private int mrow;

        public TextBoxLookupEventArgs(TextEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public TextBoxLookupEventArgs(TextEdit c, int row, TreeListColumn treecol) {
            this.mcontrol = c;
            this.mtreecol = treecol;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public TreeListColumn treecol {
            get { return this.mtreecol; }
        }

        public TextEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class TextBoxMultiLookupEventArgs : EventArgs {
        private GridColumn mcol;
        private TreeListColumn mtreecol;
        private TextEdit mcontrol;
        private int mrow;

        public TextBoxMultiLookupEventArgs(TextEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public TextBoxMultiLookupEventArgs(TextEdit c, int row, TreeListColumn treecol) {
            this.mcontrol = c;
            this.mtreecol = treecol;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public TreeListColumn treecol {
            get { return this.mtreecol; }
        }

        public TextEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class GridNumbericValueChangingEventArgs : EventArgs {
        private GridColumn mcol;
        private int mrow;
        private ChangingEventArgs mchanging;

        public GridNumbericValueChangingEventArgs(GridColumn col, int row, ChangingEventArgs changing) {
            this.mcol = col;
            this.mrow = row;
            this.mchanging = changing;
        }

        public GridColumn Col {
            get { return this.mcol; }
        }

        public int Row {
            get { return this.mrow; }
        }

        public ChangingEventArgs EventChanging {
            get { return this.mchanging; }
        }
    }

    public class GridCheckBoxChangeEventArgs : EventArgs {
        private CheckEdit mcheckedit;
        private GridColumn mcol;
        private int mrow;

        public GridCheckBoxChangeEventArgs(GridColumn col, int row, CheckEdit check) {
            this.mcol = col;
            this.mrow = row;
            this.mcheckedit = check;
        }

        public GridColumn Col {
            get { return this.mcol; }
        }

        public int Row {
            get { return this.mrow; }
        }

        public CheckEdit Checkedit {
            get { return this.mcheckedit; }
        }
    }

    public class ButtonClickEventArgs : EventArgs {
        private EditorButton mbutton;
        private GridColumn mcol;
        private TreeListColumn mtreecol;
        private int mrow;

        public ButtonClickEventArgs(GridColumn col, int row, EditorButton button) {
            this.mcol = col;
            this.mrow = row;
            this.mbutton = button;
        }

        public ButtonClickEventArgs(TreeListColumn treecol, int row, EditorButton button) {
            this.mtreecol = treecol;
            this.mrow = row;
            this.mbutton = button;
        }

        public GridColumn Col {
            get { return this.mcol; }
        }

        public TreeListColumn treeCol {
            get { return this.mtreecol; }
        }

        public int Row {
            get { return this.mrow; }
        }

        public EditorButton Button {
            get { return this.mbutton; }
        }
    }

    public class GridDateChangeEventArgs : EventArgs {
        private GridColumn mcol;
        private DateEdit mcontrol;
        private int mrow;

        public GridDateChangeEventArgs(DateEdit c, int row, GridColumn col) {
            this.mcontrol = c;
            this.mcol = col;
            this.mrow = row;
        }

        public GridColumn col {
            get { return this.mcol; }
        }

        public DateEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class ItemImageCombobox
    {
        private string mDescription = string.Empty;
        private Int16 mImageIndex = 0;
        private object mValue;
        public ItemImageCombobox(string description, Int16 imageindex, object val)
        {
            this.mDescription = description;
            this.mImageIndex = imageindex;
            this.mValue = val;
        }
        public string Description
        {
            get { return this.mDescription; }
        }
        public Int16 ImageIndex
        {
            get { return this.mImageIndex; }
        }
        public object Value
        {
            get { return this.mValue; }
        }
    }

    public class NumberLimit
    {
        private decimal mMin = 0;
        private decimal mMax = 0;

        public NumberLimit()
        { }

        public NumberLimit(decimal min, decimal max)
        {
            this.mMin = min;
            this.mMax = max;
        }

        public decimal Min
        {
            get { return this.mMin; }
        }

        public decimal Max
        {
            get { return this.mMax; }
        }
    }
}