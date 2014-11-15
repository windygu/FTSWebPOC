using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

namespace FTS.BaseUI.Controls
{
    public class FTSDataGridAdvance: GridControl
    {
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
        private AdvBandedGridView mAdvView;
        private string mTableName;
        private string mTextFooter = string.Empty;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private bool mAllowSortColumns = false;

        public FTSDataGridAdvance()
        {
            this.mAdvView = new AdvBandedGridView();
            this.SetPropertiesGridView();
            this.MainView = this.mAdvView;
            this.ViewCollection.Add(this.mAdvView);
            this.mAdvView.CustomDrawRowIndicator +=
             new RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
            // this.mAdvView.CustomDrawBandHeader += new BandHeaderCustomDrawEventHandler(mAdvView_CustomDrawBandHeader);
        }

        //private void mAdvView_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        //{

        //}
        private void SetPropertiesGridView()
        {
            this.mAdvView.OptionsNavigation.EnterMoveNextColumn = true;
            this.mAdvView.OptionsView.ColumnAutoWidth = false;
            this.mAdvView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.mAdvView.FixedLineWidth = 1;
        }
        public void SetFont()
        {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.mAdvView.Appearance.HeaderPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.mAdvView.Appearance.FooterPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.mAdvView.Appearance.Row.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }
        [Browsable(false), DefaultValue(false)]
        public bool AllowSortColumns
        {
            get { return this.mAllowSortColumns; }
            set
            {
                this.mAllowSortColumns = value;
                foreach (BandedGridColumn col in this.mAdvView.Columns)
                {
                    col.OptionsColumn.AllowSort = this.mAllowSortColumns ? DefaultBoolean.True : DefaultBoolean.False;
                }
            }
        }
        public void BindData()
        {
            if (this.mDataTable == null)
            {
                return;
            }
            this.DataSource = this.mDataSet;
            this.DataMember = this.mTableName;
        }
        public void BindDataView()
        {
            try
            {
                this.DataSource = this.mDataView;
                this.DataMember = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            else
            {
                //e.Info.DisplayText = "STT";
            }
            if (e.RowHandle == this.mAdvView.FocusedRowHandle)
            {
                AppearanceHelper.Apply(e.Appearance,
                                       new AppearanceDefault(SystemColors.Highlight, SystemColors.Control,
                                                             HorzAlignment.Center, VertAlignment.Default,
                                                             new Font(AppearanceObject.DefaultFont, FontStyle.Bold)));
            }
            e.Info.ImageIndex = -1;
        }
        public void CreateGrid(DataView dataview)
        {
            this.mDataView = dataview;
        }
        public void CreateGrid(DataSet dataset, DataTable datatable, string tablename)
        {
            this.mDataSet = dataset;
            this.mDataTable = datatable;
            this.mTableName = tablename;
        }
        public GridBand CreateBand(string name, string caption, bool is_addband)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.Caption = caption;
            if (is_addband)
                this.mAdvView.Bands.Add(band);
            return band;
        }
        public void SetCheckColumn(FieldInfo field, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemCheckEdit checkedit = new RepositoryItemCheckEdit();
            checkedit.AutoHeight = false;
            checkedit.NullStyle = StyleIndeterminate.Unchecked;
            checkedit.ValueChecked = Convert.ToInt16(1);
            checkedit.ValueUnchecked = Convert.ToInt16(0);
            BandedGridColumn checkcolumn = new BandedGridColumn();
            checkcolumn.Name = field.FieldName;
            checkcolumn.FieldName = field.FieldName;
            checkcolumn.Caption = field.DisplayName;
            checkcolumn.OptionsColumn.AllowDragInVisible = false;
            checkcolumn.RowIndex = rowindex;
            checkcolumn.RowCount = rowcount;
            checkcolumn.ColumnEdit = checkedit;
            band.Columns.Add(checkcolumn);
            if (!field.IsBound)
            {
                checkcolumn.UnboundType = UnboundColumnType.Boolean;
            }
        }
        public void SetComboColumn(FieldInfo field, ArrayList itemlist, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemComboBox lookupedit = new RepositoryItemComboBox();
            lookupedit.AutoHeight = false;
            lookupedit.LookAndFeel.SetWindowsXPStyle();
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            foreach (object oj in itemlist)
            {
                lookupedit.Items.Add(oj);
            }
            lookupedit.PopupFormWidth = 100;
            lookupedit.DropDownRows = 10;
            BandedGridColumn lookupcolumn = new BandedGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            lookupcolumn.Caption = field.DisplayName;
            lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupcolumn.RowIndex = rowindex;
            lookupcolumn.RowCount = rowcount;
            band.Columns.Add(lookupcolumn);
            if (!field.IsBound)
            {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetComboMultiColumn(FieldInfo field, DataTable filltable, string displaycolumnname, string boundcolumnname,
            ComboComType combotype, bool showfooter, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemLookUpEdit lookupedit = new RepositoryItemLookUpEdit();
            lookupedit.AutoHeight = false;
            lookupedit.ShowHeader = false;
            if (showfooter)
            {
                lookupedit.ShowFooter = true;
            }
            else
            {
                lookupedit.ShowFooter = false;
            }
            lookupedit.LookAndFeel.SetWindowsXPStyle();
            lookupedit.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            lookupedit.AllowNullInput = DefaultBoolean.True;
            lookupedit.NullText = string.Empty;
            lookupedit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            switch (combotype)
            {
                case ComboComType.NameID:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 320;
                    break;
                case ComboComType.IDOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.PopupWidth = 80;
                    break;
                case ComboComType.NameOnly:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = displaycolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 240;
                    break;
                case ComboComType.IDName:
                    lookupedit.DataSource = filltable;
                    lookupedit.DisplayMember = boundcolumnname;
                    lookupedit.ValueMember = boundcolumnname;
                    lookupedit.Columns.Clear();
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(boundcolumnname, string.Empty, 80));
                    lookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displaycolumnname, string.Empty, 240));
                    lookupedit.PopupWidth = 320;
                    break;
                default:
                    break;
            }
            lookupedit.DropDownRows = 10;
            lookupedit.AppearanceDropDownHeader.Options.UseTextOptions = true;
            lookupedit.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
            BandedGridColumn lookupcolumn = new BandedGridColumn();
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            lookupcolumn.Caption = field.DisplayName;
            lookupcolumn.OptionsColumn.AllowDragInVisible = false;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupcolumn.RowIndex = rowindex;
            lookupcolumn.RowCount = rowcount;
            lookupcolumn.VisibleIndex = 1;
            band.Columns.Add(lookupcolumn);
            if (!field.IsBound)
            {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetDateColumn(FieldInfo field, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemDateEdit dateedit = new RepositoryItemDateEdit();
            dateedit.AutoHeight = false;
            BandedGridColumn datecolumn = new BandedGridColumn();
            datecolumn.Name = field.FieldName;
            datecolumn.FieldName = field.FieldName;
            datecolumn.Caption = field.DisplayName;
            datecolumn.OptionsColumn.AllowDragInVisible = false;
            datecolumn.ColumnEdit = dateedit;
            datecolumn.RowIndex = rowindex;
            datecolumn.RowCount = rowcount;
            datecolumn.VisibleIndex = 1;
            band.Columns.Add(datecolumn);
            if (!field.IsBound)
            {
                datecolumn.UnboundType = UnboundColumnType.DateTime;
            }
        }
        public void SetDateTimeColumn(FieldInfo field, GridBand band, int rowindex, int rowcount, string format)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemDateEdit dateedit = new RepositoryItemDateEdit();
            dateedit.Mask.EditMask = format;
            dateedit.Mask.UseMaskAsDisplayFormat = true;
            dateedit.AutoHeight = false;
            BandedGridColumn datecolumn = new BandedGridColumn();
            datecolumn.Name = field.FieldName;
            datecolumn.FieldName = field.FieldName;
            datecolumn.Caption = field.DisplayName;
            datecolumn.OptionsColumn.AllowDragInVisible = false;
            datecolumn.ColumnEdit = dateedit;
            datecolumn.RowIndex = rowindex;
            datecolumn.RowCount = rowcount;
            datecolumn.VisibleIndex = 1;
            band.Columns.Add(datecolumn);
            if (!field.IsBound)
            {
                datecolumn.UnboundType = UnboundColumnType.DateTime;
            }
        }
        public void SetLookupTextColumn(FieldInfo field, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemButtonEdit textedit = new RepositoryItemButtonEdit();
            textedit.MaxLength = field.MaxLength;
            BandedGridColumn textcolumn = new BandedGridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            textcolumn.Caption = field.DisplayName;
            textcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            textedit.CharacterCasing = CharacterCasing.Upper;
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.ColumnEdit = textedit;
            textcolumn.RowIndex = rowindex;
            textcolumn.RowCount = rowcount;
            band.Columns.Add(textcolumn);
            if (!field.IsBound)
            {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetNumberColumn(FieldInfo field, int decimalplaces, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.BeginInit();
            textedit.AutoHeight = false;
            textedit.DisplayFormat.FormatString = "n" + decimalplaces.ToString();
            textedit.DisplayFormat.FormatType = FormatType.Numeric;
            textedit.EditFormat.FormatString = "n" + decimalplaces.ToString();
            textedit.EditFormat.FormatType = FormatType.Numeric;
            textedit.Mask.EditMask = "n" + decimalplaces.ToString();
            textedit.Mask.MaskType = MaskType.Numeric;
            textedit.EndInit();
            BandedGridColumn numbercolumn = new BandedGridColumn();
            numbercolumn.Name = field.FieldName;
            numbercolumn.FieldName = field.FieldName;
            numbercolumn.Caption = field.DisplayName;
            numbercolumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            numbercolumn.OptionsColumn.AllowDragInVisible = false;
            numbercolumn.ColumnEdit = textedit;
            numbercolumn.RowIndex = rowindex;
            numbercolumn.RowCount = rowcount;
            band.Columns.Add(numbercolumn);
            numbercolumn.VisibleIndex = 1;
            if (!field.IsBound)
            {
                numbercolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }
        public void SetTextLinkColumn(FieldInfo field, bool isuppercase, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemHyperLinkEdit textlink = new RepositoryItemHyperLinkEdit();
            textlink.MaxLength = field.MaxLength;
            BandedGridColumn textlinkcolumn = new BandedGridColumn();
            textlinkcolumn.Name = field.FieldName;
            textlinkcolumn.FieldName = field.FieldName;
            textlinkcolumn.Caption = field.DisplayName;
            textlinkcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            if (isuppercase)
            {
                textlink.CharacterCasing = CharacterCasing.Upper;
            }
            textlinkcolumn.OptionsColumn.AllowDragInVisible = false;
            textlinkcolumn.ColumnEdit = textlink;
            textlinkcolumn.RowIndex = rowindex;
            textlinkcolumn.RowCount = rowcount;
            band.Columns.Add(textlinkcolumn);
            if (!field.IsBound)
            {
                textlinkcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetButtonEdit(FieldInfo field, bool isuppercase, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            BandedGridColumn buttoncolumn = new BandedGridColumn();
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            buttoncolumn.Caption = field.DisplayName;
            buttoncolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            if (isuppercase)
            {
                buttonedit.CharacterCasing = CharacterCasing.Upper;
            }
            buttoncolumn.OptionsColumn.AllowDragInVisible = false;
            buttoncolumn.ColumnEdit = buttonedit;
            band.Columns.Add(buttoncolumn);
            if (!field.IsBound)
            {
                buttoncolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetTextColumn(FieldInfo field, bool isuppercase, GridBand band, int rowindex, int rowcount)
        {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound))
            {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            textedit.MaxLength = field.MaxLength;
            BandedGridColumn textcolumn = new BandedGridColumn();
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            textcolumn.Caption = field.DisplayName;
            textcolumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Extend;
            if (isuppercase)
            {
                textedit.CharacterCasing = CharacterCasing.Upper;
            }
            textcolumn.OptionsColumn.AllowDragInVisible = false;
            textcolumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            textcolumn.ColumnEdit = textedit;
            textcolumn.RowIndex = rowindex;
            textcolumn.RowCount = rowcount;
            band.Columns.Add(textcolumn);
            textcolumn.VisibleIndex = 1;
            if (!field.IsBound)
            {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
        }
        public void SetIndicatorWidth(int rowcount)
        {
            if ((rowcount >= 0) && (rowcount < 100))
            {
                this.mAdvView.IndicatorWidth = 30;
            }
            else if ((rowcount >= 100) && (rowcount < 1000))
            {
                this.mAdvView.IndicatorWidth = 40;
            }
            else if ((rowcount >= 1000) && (rowcount < 10000))
            {
                this.mAdvView.IndicatorWidth = 50;
            }
            else if ((rowcount >= 10000) && (rowcount < 100000))
            {
                this.mAdvView.IndicatorWidth = 60;
            }
            else if ((rowcount >= 100000) && (rowcount < 1000000))
            {
                this.mAdvView.IndicatorWidth = 70;
            }
            else
            {
                this.mAdvView.IndicatorWidth = 80;
            }
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0)
            {
                name = name.Substring(n, name.Length - n);
            }
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            return string.Empty;
        }
        private void OpenFile(string fileName)
        {
            if (MessageBox.Show(MSG_EXPORT_OPEN_FILE, "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show(this, MSG_ERROR_OPEN_FILE, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportTo(IExportProvider provider, string caption)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            BaseExportLink link = this.mAdvView.CreateExportLink(provider);
            (link as AdvBandedViewExportLink).ExpandAll = false;
            WaitDialogForm dlg = new WaitDialogForm(caption, MSG_EXPORT_PROCESSING);
            link.ExportTo(true);
            dlg.Close();
            provider.Dispose();
            Cursor.Current = currentCursor;
        }
        public void ExportToHML()
        {
            string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName != string.Empty)
            {
                ExportTo(new ExportHtmlProvider(fileName), MSG_EXPORT_HTML);
                OpenFile(fileName);
            }
        }

        public void ExportToTXT()
        {
            string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
            if (fileName != string.Empty)
            {
                ExportTo(new ExportTxtProvider(fileName), MSG_EXPORT_TEXT);
                OpenFile(fileName);
            }
        }

        public void ExportToXLS()
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName != string.Empty)
            {
                ExportTo(new ExportXlsProvider(fileName), MSG_EXPORT_XLS);
                OpenFile(fileName);
            }
        }
        public AdvBandedGridView ViewAdv
        {
            get
            {
                return this.mAdvView;
            }
        }
    }
}
