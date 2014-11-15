#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Data;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public delegate void TreeMenuEventHandler(object sender, TreeMenuEventArgs e);

    public class FTSTreeList : TreeList {
        private const string MSG_ERROR_OPEN_FILE = "Không mở được file vừa kết xuất.";
        private const string MSG_EXPORT_OPEN_FILE = "Bạn có muốn mở file vừa kế xuất không?";
        private const string MSG_EXPORT_PROCESSING = "Đang kết xuất... Xin vui lòng chờ...";
        private Container components = null;
        private DataTable mDataTable;
        private DataView mDataView;
        private string mIdField;
        private string mParentId;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_MBUTTONDBLCLK = 0x209;
        public event TreeMenuEventHandler TreeListMenuShow;
        public event TreeListComboChangeEventHandler TreeListComboChange;
        public event ComboBoxClickEventHandler ComboBoxClick;
        public event CellDoubleClickEventHandler CellDoubleClick;
        public event TextBoxLookupEventHandler TextBoxLookup;
        public event TextBoxMultiLookupEventHandler TextBoxMultiLookup;
        public event TreeListCheckBoxChangedEventHandler CheckBoxChanged;
        public event ButtonClickEventHandler ButtonClick;
        public event SelectNodeEventHandler ChooseNode;

        public FTSTreeList() {
            this.InitializeComponent();
            this.SetPropertiesTreeList();
            this.SetTreeListStyle();
            this.DoubleClick += new EventHandler(this.FTSTreeList_DoubleClick);
            this.KeyDown += new KeyEventHandler(this.FTSTreeList_KeyDown);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
        }

        #endregion

        private void SetPropertiesTreeList() {
            this.OptionsBehavior.EnterMovesNextColumn = true;
            this.OptionsMenu.EnableColumnMenu = false;
            this.OptionsMenu.EnableFooterMenu = false;
        }

        private void SetTreeListStyle() {
            this.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.OptionsView.EnableAppearanceEvenRow = true;
            this.OptionsView.EnableAppearanceOddRow = true;
            this.Appearance.EvenRow.BackColor = Color.White;
            this.Appearance.EvenRow.Options.UseBackColor = true;
            this.Appearance.OddRow.BackColor = Color.WhiteSmoke;
            this.Appearance.OddRow.Options.UseBackColor = true;
            this.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.Appearance.FocusedCell.Options.UseForeColor = true;
            this.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.BorderStyle = BorderStyles.NoBorder;
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.EvenRow.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.OddRow.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.HeaderPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.FooterPanel.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Appearance.GroupFooter.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        public void CreateTreeList(DataTable datatable, string idfield, string parentid) {
            this.mDataTable = datatable;
            this.mIdField = idfield;
            this.mParentId = parentid;
        }

        public void BindData() {
            if (this.mDataTable == null) {
                return;
            }
            this.DataSource = this.mDataTable;
            this.KeyFieldName = this.mIdField;
            this.ParentFieldName = this.mParentId;
            this.BestFitColumns();
            this.ExpandAll();
        }

        public void CreateTreeList(DataView dataview, string idfield, string parentid) {
            this.mDataView = dataview;
            this.mIdField = idfield;
            this.mParentId = parentid;
        }

        public void BindDataView() {
            if (this.mDataView == null) {
                return;
            }
            this.DataSource = this.mDataView;
            this.KeyFieldName = this.mIdField;
            this.ParentFieldName = this.mParentId;
            this.BestFitColumns();
            this.ExpandAll();
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

        public void ExportToHML() {
            string fileName = this.ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName.Length != 0) {
                this.ExportToHtml(fileName);
                this.OpenFile(fileName);
            }
        }

        public void ExportToTXT() {
            string fileName = this.ShowSaveFileDialog("Text Document", "Text Files|*.txt");
            if (fileName.Length != 0) {
                this.ExportToText(fileName);
                this.OpenFile(fileName);
            }
        }

        public void ExportToXLS() {
            string fileName = this.ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName.Length != 0) {
                this.ExportToXls(fileName);
                this.OpenFile(fileName);
            }
        }

        public void SetTextColumn(FieldInfo field, bool isuppercase) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemTextEdit textedit = new RepositoryItemTextEdit();
            ((ISupportInitialize) (textedit)).BeginInit();
            textedit.MaxLength = field.MaxLength;
            this.Columns.AddField(field.FieldName);
            TreeListColumn textcolumn = this.Columns[field.FieldName];
            textcolumn.Name = field.FieldName;
            textcolumn.FieldName = field.FieldName;
            textcolumn.Caption = field.DisplayName;
            if (isuppercase) {
                textedit.CharacterCasing = CharacterCasing.Upper;
            }
            textcolumn.ColumnEdit = textedit;
            textedit.Enter += new EventHandler(this.Cell_Enter);
            textedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            textedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            if (!field.IsBound) {
                textcolumn.UnboundType = UnboundColumnType.String;
            }
            ((ISupportInitialize) (textedit)).EndInit();
        }

        public void SetMemoExEdit(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemMemoExEdit memoexedit = new RepositoryItemMemoExEdit();
            this.Columns.AddField(field.FieldName);
            TreeListColumn memoexcolumn = this.Columns[field.FieldName];
            memoexcolumn.Name = field.FieldName;
            memoexcolumn.FieldName = field.FieldName;
            memoexcolumn.Caption = field.DisplayName;
            memoexcolumn.ColumnEdit = memoexedit;
            if (!field.IsBound) {
                memoexcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetNumberColumn(FieldInfo field, int decimalplaces) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
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
            textedit.ContextMenu = null;
            this.Columns.AddField(field.FieldName);
            TreeListColumn numbercolumn = this.Columns[field.FieldName];
            numbercolumn.Name = field.FieldName;
            numbercolumn.FieldName = field.FieldName;
            numbercolumn.Caption = field.DisplayName;
            numbercolumn.ColumnEdit = textedit;
            if (!field.IsBound) {
                numbercolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        public void SetDateColumn(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemDateEdit dateedit = new RepositoryItemDateEdit();
            dateedit.AutoHeight = false;
            this.Columns.AddField(field.FieldName);
            TreeListColumn datecolumn = this.Columns[field.FieldName];
            datecolumn.Name = field.FieldName;
            datecolumn.FieldName = field.FieldName;
            datecolumn.Caption = field.DisplayName;
            datecolumn.ColumnEdit = dateedit;
            if (!field.IsBound) {
                datecolumn.UnboundType = UnboundColumnType.DateTime;
            }
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn checkcolumn = this.Columns[field.FieldName];
            checkcolumn.Name = field.FieldName;
            checkcolumn.FieldName = field.FieldName;
            checkcolumn.Caption = field.DisplayName;
            checkcolumn.ColumnEdit = checkedit;
            checkedit.CheckedChanged += new EventHandler(this.checkedit_CheckedChanged);
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn combocolumn = this.Columns[field.FieldName];
            combocolumn.Name = field.FieldName;
            combocolumn.FieldName = field.FieldName;
            combocolumn.Caption = field.DisplayName;
            combocolumn.ColumnEdit = comboedit;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn combocolumn = this.Columns[field.FieldName];
            combocolumn.Name = field.FieldName;
            combocolumn.FieldName = field.FieldName;
            combocolumn.Caption = field.DisplayName;
            combocolumn.ColumnEdit = comboedit;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn lookupcolumn = this.Columns[field.FieldName];
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            lookupcolumn.Caption = field.DisplayName;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
            if (!field.IsBound) {
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn lookupcolumn = this.Columns[field.FieldName];
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            lookupcolumn.Caption = field.DisplayName;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn lookupcolumn = this.Columns[field.FieldName];
            lookupcolumn.Name = field.FieldName;
            lookupcolumn.FieldName = field.FieldName;
            lookupcolumn.Caption = field.DisplayName;
            lookupcolumn.ColumnEdit = lookupedit;
            lookupedit.EditValueChanged += new EventHandler(this.ComboSelectedIndexChange);
            lookupedit.ButtonsFooterClick += new ButtonsFooterClickEventHandler(this.lookupedit_ButtonsFooterClick);
            if (!field.IsBound) {
                lookupcolumn.UnboundType = UnboundColumnType.String;
            }
        }

        public void SetLookupTextColumn(FieldInfo field, bool up) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            this.Columns.AddField(field.FieldName);
            TreeListColumn buttoncolumn = this.Columns[field.FieldName];
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            if (up) {
                buttonedit.CharacterCasing = CharacterCasing.Upper;
            } else {
                buttonedit.CharacterCasing = CharacterCasing.Normal;
            }
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_ButtonPressed);
            buttonedit.ContextMenu = null;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn buttoncolumn = this.Columns[field.FieldName];
            buttoncolumn.Name = field.FieldName;
            buttonedit.CharacterCasing = CharacterCasing.Upper;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_ButtonPressed);
            buttonedit.ContextMenu = null;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn buttoncolumn = this.Columns[field.FieldName];
            buttoncolumn.Name = field.FieldName;
            buttonedit.CharacterCasing = CharacterCasing.Upper;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.ButtonPressed += new ButtonPressedEventHandler(this.Properties_MultiButtonPressed);
            buttonedit.ContextMenu = null;
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.String;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn calcolumn = this.Columns[field.FieldName];
            calcolumn.Name = field.FieldName;
            calcolumn.FieldName = field.FieldName;
            calcolumn.Caption = field.DisplayName;
            calcolumn.ColumnEdit = calcedit;
            calcedit.Enter += new EventHandler(this.Cell_Enter);
            calcedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            calcedit.DoubleClick += new EventHandler(this.Cell_DoubleClick);
            calcedit.Spin += new SpinEventHandler(this.DisableMouseWheel);
            if (!field.IsBound) {
                calcolumn.UnboundType = UnboundColumnType.Decimal;
            }
        }

        public void SetButton(FieldInfo field) {
            if (this.mDataTable.Columns.IndexOf(field.FieldName) < 0 && (field.IsBound)) {
                return;
            }
            RepositoryItemButtonEdit buttonedit = new RepositoryItemButtonEdit();
            buttonedit.MaxLength = field.MaxLength;
            buttonedit.Buttons[0].Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            buttonedit.Buttons[0].Appearance.Options.UseTextOptions = true;
            buttonedit.Buttons[0].Kind = ButtonPredefines.Glyph;
            buttonedit.TextEditStyle = TextEditStyles.HideTextEditor;
            this.Columns.AddField(field.FieldName);
            TreeListColumn buttoncolumn = this.Columns[field.FieldName];
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.ButtonClick += new ButtonPressedEventHandler(this.buttonedit_ButtonClick);
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.Object;
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
            this.Columns.AddField(field.FieldName);
            TreeListColumn buttoncolumn = this.Columns[field.FieldName];
            buttoncolumn.Name = field.FieldName;
            buttoncolumn.FieldName = field.FieldName;
            buttoncolumn.ColumnEdit = buttonedit;
            buttonedit.Enter += new EventHandler(this.Cell_Enter);
            buttonedit.EditValueChanged += new EventHandler(this.Cell_EditValueChanged);
            buttonedit.ButtonClick += new ButtonPressedEventHandler(this.buttonedit_ButtonClick);
            if (!field.IsBound) {
                buttoncolumn.UnboundType = UnboundColumnType.Object;
            }
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_RBUTTONDOWN) {
                if (this.TreeListMenuShow != null) {
                    TreeListHitInfo info = this.CalcHitInfo(this.PointToClient(MousePosition));
                    this.TreeListMenuShow(this, new TreeMenuEventArgs(info.MousePoint));
                }
            }
        }

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void SetSummary(TreeListColumn c, string sumtype) {
            c.SummaryFooter = c.RowFooterSummary = this.GetSumType(sumtype);
            c.SummaryFooterStrFormat =
                c.RowFooterSummaryStrFormat = "{0:" + c.ColumnEdit.DisplayFormat.FormatString + "}";
        }

        public void ClearSummary(TreeListColumn c) {
            c.SummaryFooter = c.RowFooterSummary = SummaryItemType.None;
            c.SummaryFooterStrFormat = c.RowFooterSummaryStrFormat = string.Empty;
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

        private void ComboSelectedIndexChange(object sender, EventArgs e) {
            try {
                LookUpEdit edit = (LookUpEdit) sender;
                this.OnTreeListComboChange(this,
                                           new TreeListComboChangeEventArgs(edit, this.FocusedRowIndex,
                                                                            this.FocusedColumn));
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

        private void lookupedit_ButtonsFooterClick(object sender, ButtonsFooterClickEventArgs e) {
            if (this.ComboBoxClick != null) {
                this.ComboBoxClick(sender, new ComboBoxClickEventArgs(e.ButtonsTag, this.FocusedColumn.FieldName));
            }
        }

        private void Cell_Enter(object sender, EventArgs e) {
            ((TextEdit) sender).Tag = false;
        }

        private void Cell_EditValueChanged(object sender, EventArgs e) {
            ((TextEdit) sender).Tag = true;
        }

        protected virtual void OnTreeListComboChange(object sender, TreeListComboChangeEventArgs e) {
            if (this.TreeListComboChange != null) {
                this.TreeListComboChange(this, e);
            }
        }

        private void Cell_DoubleClick(object sender, EventArgs e) {
            this.OnCellDoubleClick(this,
                                   new CellDoubleClickEventArgs(((TextEdit) sender), this.FocusedRowIndex,
                                                                this.FocusedColumn));
        }

        protected virtual void OnCellDoubleClick(object sender, CellDoubleClickEventArgs e) {
            if (this.CellDoubleClick != null) {
                this.CellDoubleClick(this, e);
            }
        }

        private void Properties_ButtonPressed(object sender, ButtonPressedEventArgs e) {
            try {
                this.OnTextBoxLookup(this,
                                     new TextBoxLookupEventArgs(((TextEdit) sender), this.FocusedRowIndex,
                                                                this.FocusedColumn));
            } catch (Exception) {
            }
        }

        protected virtual void OnTextBoxLookup(object sender, TextBoxLookupEventArgs e) {
            if (this.TextBoxLookup != null) {
                this.TextBoxLookup(this, e);
            }
        }

        private void Properties_MultiButtonPressed(object sender, ButtonPressedEventArgs e) {
            try {
                this.OnTextBoxMultiLookup(this,
                                          new TextBoxMultiLookupEventArgs(((TextEdit) sender), this.FocusedRowIndex,
                                                                          this.FocusedColumn));
            } catch (Exception) {
            }
        }

        protected virtual void OnTextBoxMultiLookup(object sender, TextBoxMultiLookupEventArgs e) {
            if (this.TextBoxMultiLookup != null) {
                this.TextBoxMultiLookup(this, e);
            }
        }

        private void checkedit_CheckedChanged(object sender, EventArgs e) {
            this.OnCheckBoxChanged(this,
                                   new TreeListCheckBoxChangeEventArgs(this.FocusedColumn, this.FocusedRowIndex,
                                                                       (CheckEdit) sender));
        }

        protected virtual void OnCheckBoxChanged(object sender, TreeListCheckBoxChangeEventArgs e) {
            if (this.CheckBoxChanged != null) {
                this.CheckBoxChanged(this, e);
            }
        }

        protected virtual void OnButtonClick(object sender, ButtonClickEventArgs e) {
            if (this.ButtonClick != null) {
                this.ButtonClick(this, e);
            }
        }

        private void buttonedit_ButtonClick(object sender, ButtonPressedEventArgs e) {
            this.OnButtonClick(this, new ButtonClickEventArgs(this.FocusedColumn, this.FocusedRowIndex, e.Button));
        }

        private void FTSTreeList_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Enter) && (this.FocusedNode != null)) {
                if (this.ChooseNode != null) {
                    this.ChooseNode(this,
                                    new SelectNodeEventArgs(
                                        ((DataRowView) this.GetDataRecordByNode(this.FocusedNode)).Row));
                }
            }
        }

        private void FTSTreeList_DoubleClick(object sender, EventArgs e) {
            if (!this.OptionsBehavior.Editable) {
                TreeListHitInfo hi = this.CalcHitInfo(this.PointToClient(MousePosition));
                if (hi.Node != null) {
                    if (this.ChooseNode != null) {
                        this.ChooseNode(this,
                                        new SelectNodeEventArgs(((DataRowView) this.GetDataRecordByNode(hi.Node)).Row));
                    }
                }
            }
        }

        /*
        protected TreeListNode FindNodeById(object id)
        {
            TreeListOperationFindNodeByFieldValue op = new TreeListOperationFindNodeByFieldValue(id, this.mIdField);
            this.NodesIterator.DoOperation(op);
            return op.Node;
        }
        */
    }

    public delegate void TreeListComboChangeEventHandler(object sender, TreeListComboChangeEventArgs e);

    public delegate void TreeListCheckBoxChangedEventHandler(object sender, TreeListCheckBoxChangeEventArgs e);

    public delegate void SelectNodeEventHandler(object sender, SelectNodeEventArgs e);

    public class SelectNodeEventArgs : EventArgs {
        private DataRow mrowvalue;

        public SelectNodeEventArgs(DataRow dr) {
            this.mrowvalue = dr;
        }

        public DataRow rowvalue {
            get { return this.mrowvalue; }
        }
    }

    public class TreeListComboChangeEventArgs : EventArgs {
        private TreeListColumn mtreecol;
        private LookUpEdit mcontrol;
        private int mrow;

        public TreeListComboChangeEventArgs(LookUpEdit c, int row, TreeListColumn treecol) {
            this.mcontrol = c;
            this.mtreecol = treecol;
            this.mrow = row;
        }

        public TreeListColumn treecol {
            get { return this.mtreecol; }
        }

        public LookUpEdit control {
            get { return this.mcontrol; }
        }

        public int row {
            get { return this.mrow; }
        }
    }

    public class TreeMenuEventArgs : EventArgs {
        private Point point;

        public TreeMenuEventArgs(Point point) {
            this.point = point;
        }

        public Point MousePos {
            get { return this.point; }
        }
    }

    public class TreeListCheckBoxChangeEventArgs : EventArgs {
        private CheckEdit mcheckedit;
        private TreeListColumn mtreecol;
        private int mrow;

        public TreeListCheckBoxChangeEventArgs(TreeListColumn treecol, int row, CheckEdit check) {
            this.mtreecol = treecol;
            this.mrow = row;
            this.mcheckedit = check;
        }

        public TreeListColumn treeCol {
            get { return this.mtreecol; }
        }

        public int Row {
            get { return this.mrow; }
        }

        public CheckEdit Checkedit {
            get { return this.mcheckedit; }
        }
    }
}