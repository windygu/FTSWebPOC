#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSComboCom : Panel, IRequire, IValid, IHelpField {
        public enum FTSComboComMode
        {
            Input,
            Find
        }
        public event EventHandler ComboChange;
        public event EventHandler ComboLeave;
        private string tableName;
        private FTSMain ftsMain;
        private DataSet dataSet;
        private bool mRequire = false;
        private string mCondition = string.Empty;
        private FTSComboComMode mMode = FTSComboComMode.Input;
        private bool mIsChanged = false;
        private bool mUiChange = false;

        public FTSComboCom() {
            this.InitializeComponent();
            this.SetProperty();
            this.ComboBox.EditValueChanged += new EventHandler(ComboBox_EditValueChanged);
        }

        private void ComboBox_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        [Browsable(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }


        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }


        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.lookUp.BackColor = SystemColors.Info;
                } else {
                    this.lookUp.BackColor = Color.White;
                }
            }
        }

        [DefaultValue(80)]
        public int LabelLength {
            get { return this.label.Width; }
            set { this.label.Width = value; }
        }

        public string LabelText {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [Browsable(false)]
        public LookUpEdit ComboBox {
            get { return this.lookUp; }
        }

        public void Set(List<ItemCombobox> list) {
            this.lookUp.Properties.DataSource = list;
            this.lookUp.Properties.ValueMember = "Id";
            this.lookUp.Properties.DisplayMember = "Name";
            this.lookUp.Properties.ShowHeader = false;
            this.lookUp.Properties.Columns.Clear();
            this.lookUp.Properties.Columns.Add(new LookUpColumnInfo("Name", string.Empty, this.lookUp.Width));
            this.lookUp.Properties.PopupWidth = this.lookUp.Width;
            this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.lookUp.Properties.ShowFooter = false;
        }

        public void Set(FTSMain ftsmain, string tablename, DataSet ds, string idField, string nameField,
                        ComboComType type, bool ShowFooter) {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            this.ftsMain = ftsmain;
            this.tableName = tablename;
            this.dataSet = ds;
            if (this.dataSet.Tables[tablename] == null) {
                frm.LoadDm(tablename);
                DataTable dt = this.dataSet.Tables[tablename];
                if (dt == null) {
                    this.ftsMain.TableManager.LoadTable(this.dataSet, tablename);
                }
            }
            switch (type) {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            this.lookUp.Properties.ShowFooter = ShowFooter;
        }

        public void Set(FTSMain ftsmain, string tablename, DataSet ds, string idField, string nameField,
                        ComboComType type, bool ShowFooter, FTSComboComMode mode)
        {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            this.ftsMain = ftsmain;
            this.tableName = tablename;
            this.dataSet = ds;
            if (this.dataSet.Tables[tablename] == null) {
                frm.LoadDm(tablename);
                DataTable dt = this.dataSet.Tables[tablename];
                if (dt == null) {
                    this.ftsMain.TableManager.LoadTable(this.dataSet, tablename);
                }
            }
            this.mMode = mode;
            if (this.mMode == FTSComboComMode.Find)
            {
                if (this.dataSet.Tables.IndexOf(this.tableName + "_FTSCOMBOCOM") < 0)
                {
                    DataTable tableftscombocom = this.dataSet.Tables[this.tableName].Copy();
                    tableftscombocom.TableName = this.tableName + "_FTSCOMBOCOM";
                    this.dataSet.Tables.Add(tableftscombocom);
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                    DataRow newrow = this.dataSet.Tables[this.tableName].NewRow();
                    if(this.dataSet.Tables[this.tableName].Columns[idField].DataType == Type.GetType("System.Guid"))
                        newrow[idField] = Guid.Empty;
                    else
                        newrow[idField] = string.Empty;
                    newrow[nameField] = ftsmain.MsgManager.GetMessage("FTSCOMBOCOM_ALL");
                    this.dataSet.Tables[this.tableName].Rows.InsertAt(newrow, 0);
                    newrow.AcceptChanges();
                }
                else
                {
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                }
            }
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            if (this.mMode == FTSComboComMode.Find)
            {
                this.lookUp.Properties.ShowFooter = false;
                this.lookUp.EditValue = string.Empty;
            }
            else
            {
                this.lookUp.Properties.ShowFooter = ShowFooter;
            }
        }

        public void Set(FTSMain ftsmain, DataTable dt, string idField, string nameField,
                        ComboComType type, bool ShowFooter)
        {
            this.ftsMain = ftsmain;
            this.tableName = dt.TableName;
            this.dataSet = new DataSet();
            this.dataSet.Tables.Add(dt);
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            this.lookUp.Properties.ShowFooter = ShowFooter;
        }

        public void Set(FTSMain ftsmain, DataTable dt, string idField, string nameField,
                        ComboComType type, bool ShowFooter,FTSComboComMode mode)
        {
            this.ftsMain = ftsmain;
            this.tableName = dt.TableName;
            this.dataSet = new DataSet();
            this.dataSet.Tables.Add(dt);
            this.mMode = mode;
            if (this.mMode == FTSComboComMode.Find)
            {
                if (this.dataSet.Tables.IndexOf(this.tableName + "_FTSCOMBOCOM") < 0)
                {
                    DataTable tableftscombocom = this.dataSet.Tables[this.tableName].Copy();
                    tableftscombocom.TableName = this.tableName + "_FTSCOMBOCOM";
                    this.dataSet.Tables.Add(tableftscombocom);
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                    DataRow newrow = this.dataSet.Tables[this.tableName].NewRow();
                    newrow[idField] = string.Empty;
                    newrow[nameField] = ftsmain.MsgManager.GetMessage("FTSCOMBOCOM_ALL");
                    this.dataSet.Tables[this.tableName].Rows.InsertAt(newrow, 0);
                    newrow.AcceptChanges();
                }
                else
                {
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                }
            }
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = this.dataSet.Tables[this.tableName];
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            if (this.mMode == FTSComboComMode.Find)
            {
                this.lookUp.Properties.ShowFooter = false;
                this.lookUp.EditValue = string.Empty;
            }
            else
            {
                this.lookUp.Properties.ShowFooter = ShowFooter;
            }
        }       

        public void Set(FTSMain ftsmain, string tablename, string condition, DataSet ds, string idField,
                        string nameField, ComboComType type, bool ShowFooter) {
            this.ftsMain = ftsmain;
            this.tableName = tablename;
            this.dataSet = ds;
            DataView view = new DataView(this.dataSet.Tables[this.tableName]);
            view.RowFilter = this.mCondition = condition;
            switch (type) {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            this.lookUp.Properties.ShowFooter = ShowFooter;
        }

        public void Set(FTSMain ftsmain, string tablename, string condition, DataSet ds, string idField,
                        string nameField, ComboComType type, bool ShowFooter, FTSComboComMode mode)
        {
            this.ftsMain = ftsmain;
            this.tableName = tablename;
            this.dataSet = ds;
            this.mMode = mode;
            if (this.mMode == FTSComboComMode.Find)
            {
                if (this.dataSet.Tables.IndexOf(this.tableName + "_FTSCOMBOCOM") < 0)
                {
                    DataTable tableftscombocom = this.dataSet.Tables[this.tableName].Copy();
                    tableftscombocom.TableName = this.tableName + "_FTSCOMBOCOM";
                    this.dataSet.Tables.Add(tableftscombocom);
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                    DataRow newrow = this.dataSet.Tables[this.tableName].NewRow();
                    newrow[idField] = string.Empty;
                    newrow[nameField] = ftsmain.MsgManager.GetMessage("FTSCOMBOCOM_ALL");
                    this.dataSet.Tables[this.tableName].Rows.InsertAt(newrow, 0);
                    newrow.AcceptChanges();
                }
                else
                {
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                }
            }
            DataView view = new DataView(this.dataSet.Tables[this.tableName]);
            view.RowFilter = this.mCondition = condition;
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            if (this.mMode == FTSComboComMode.Find)
            {
                this.lookUp.Properties.ShowFooter = false;
                this.lookUp.EditValue = string.Empty;
            }
            else
            {
                this.lookUp.Properties.ShowFooter = ShowFooter;
            }
        }

        public void Set(FTSMain ftsmain, string condition, DataTable dt, string idField,
                        string nameField, ComboComType type, bool ShowFooter)
        {
            this.ftsMain = ftsmain;
            this.tableName = dt.TableName;
            this.dataSet = new DataSet();
            this.dataSet.Tables.Add(dt);
            DataView view = new DataView(this.dataSet.Tables[this.tableName]);
            view.RowFilter = this.mCondition = condition;
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            this.lookUp.Properties.ShowFooter = ShowFooter;
        }

        public void Set(FTSMain ftsmain, string condition, DataTable dt, string idField,
                        string nameField, ComboComType type, bool ShowFooter, FTSComboComMode mode)
        {
            this.ftsMain = ftsmain;
            this.tableName = dt.TableName;
            this.dataSet = new DataSet();
            this.dataSet.Tables.Add(dt);
            this.mMode = mode;
            if (this.mMode == FTSComboComMode.Find)
            {
                if (this.dataSet.Tables.IndexOf(this.tableName + "_FTSCOMBOCOM") < 0)
                {
                    DataTable tableftscombocom = this.dataSet.Tables[this.tableName].Copy();
                    tableftscombocom.TableName = this.tableName + "_FTSCOMBOCOM";
                    this.dataSet.Tables.Add(tableftscombocom);
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                    DataRow newrow = this.dataSet.Tables[this.tableName].NewRow();
                    newrow[idField] = string.Empty;
                    newrow[nameField] = ftsmain.MsgManager.GetMessage("FTSCOMBOCOM_ALL");
                    this.dataSet.Tables[this.tableName].Rows.InsertAt(newrow, 0);
                    newrow.AcceptChanges();
                }
                else
                {
                    this.tableName = this.tableName + "_FTSCOMBOCOM";
                }
            }
            DataView view = new DataView(this.dataSet.Tables[this.tableName]);
            view.RowFilter = this.mCondition = condition;
            switch (type)
            {
                case ComboComType.NameID:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 80));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width + 80;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.NameOnly:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = nameField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, this.lookUp.Width));
                    this.lookUp.Properties.PopupWidth = this.lookUp.Width;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case ComboComType.IDName:
                    this.lookUp.Properties.DataSource = view;
                    this.lookUp.Properties.ValueMember = idField;
                    this.lookUp.Properties.DisplayMember = idField;
                    this.lookUp.Properties.ShowHeader = false;
                    this.lookUp.Properties.Columns.Clear();
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(idField, string.Empty, 120));
                    this.lookUp.Properties.Columns.Add(new LookUpColumnInfo(nameField, string.Empty, 220));
                    this.lookUp.Properties.PopupWidth = 120 + 220;
                    this.lookUp.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
                    this.lookUp.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                default:
                    break;
            }
            if (this.mMode == FTSComboComMode.Find)
            {
                this.lookUp.Properties.ShowFooter = false;
                this.lookUp.EditValue = string.Empty;
            }
            else
            {
                this.lookUp.Properties.ShowFooter = ShowFooter;
            }
        }
        private void lookUp_ButtonsFooterClick(object sender, ButtonsFooterClickEventArgs e) {
            try {
                FTSForm frmparent = (FTSForm) this.FindForm();
                Type type_frmdic = frmparent.GetFrmDicEditDetail(this.tableName);
                if (type_frmdic != null) {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (FrmDataList), typeof (Boolean), typeof (Boolean),
                                                       typeof (Object), typeof (string)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null) {
                        throw new ArgumentException("Not Constructor");
                    }
                    if (string.Compare(e.ButtonsTag, "NEW", true) == 0) {
                        Object[] objArg = new object[6] {this.ftsMain, null, true, true, null, this.mCondition};
                        FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                        this.lookUp.Properties.ShowPopupShadow = false;
                        try {
                            if (frmdic.ShowDialog() == DialogResult.Yes) {
                                DataRow row = this.dataSet.Tables[this.tableName].NewRow();
                                foreach (DataColumn column in this.dataSet.Tables[this.tableName].Columns) {
                                    row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                }
                                this.dataSet.Tables[this.tableName].Rows.Add(row);
                                this.dataSet.Tables[this.tableName].AcceptChanges();
                                this.lookUp.EditValue = row[this.lookUp.Properties.ValueMember];
                                if (this.lookUp.Text.Trim() == string.Empty) {
                                    this.lookUp.EditValue = string.Empty;
                                }
                            }
                            frmdic.Dispose();
                        } catch (FTSException ex) {
                            FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex);
                        } catch (Exception ex1) {
                            FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex1);
                        }
                        this.lookUp.Properties.ShowPopupShadow = true;
                    } else if ((string.Compare(e.ButtonsTag, "EDIT", true) == 0) && (this.lookUp.EditValue != null) &&
                               (this.lookUp.EditValue.ToString().Trim().Length != 0)) {
                        Object[] objArg = new object[6]
                                          {this.ftsMain, null, false, true, this.lookUp.EditValue, this.mCondition};
                        FrmDataEditDetail frmdic = constructorInfoObj.Invoke(objArg) as FrmDataEditDetail;
                        int Pos = this.lookUp.Properties.GetDataSourceRowIndex(this.lookUp.Properties.ValueMember,
                                                                               this.ComboBox.EditValue);
                        this.lookUp.Properties.ShowPopupShadow = false;
                        try {
                            if ((frmdic.ShowDialog() == DialogResult.Yes) && (frmdic.ReturnRow != null)) {
                                DataRow row = this.dataSet.Tables[this.tableName].Rows[Pos];
                                if (this.lookUp.Properties.DataSource is DataView) {
                                    row = this.dataSet.Tables[this.tableName].Rows.Find(this.lookUp.EditValue);
                                }
                                foreach (DataColumn column in this.dataSet.Tables[this.tableName].Columns) {
                                    row[column.ColumnName] = frmdic.ReturnRow[column.ColumnName];
                                }
                                this.dataSet.Tables[this.tableName].AcceptChanges();
                                this.lookUp.EditValue = row[this.ComboBox.Properties.ValueMember];
                            }
                            frmdic.Dispose();
                        } catch (FTSException ex) {
                            FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex);
                        } catch (Exception ex1) {
                            FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex1);
                        }
                        this.lookUp.Properties.ShowPopupShadow = true;
                    }
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.GetMessage(this.ftsMain,ex1);
            }
        }

        private void lookUp_EditValueChanged(object sender, EventArgs e) {
            if ((this.ComboChange != null)&&(this.mUiChange)) {
                this.mUiChange = false;
                this.ComboChange(this.lookUp, new EventArgs());
            }
        }

        private void lookUp_Leave(object sender, EventArgs e) {
            if (this.ComboLeave != null) {
                this.ComboLeave(this.lookUp, new EventArgs());
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.lookUp.Focus();
        }

        public object GetCurrentRow() {
            return this.lookUp.Properties.GetDataSourceRowByKeyValue(this.lookUp.EditValue);
        }

        private void SetProperty() {
            this.lookUp.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.lookUp.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.lookUp.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lookUp.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.lookUp.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.lookUp.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.lookUp.Properties.Appearance.Options.UseBackColor = true;
                this.lookUp.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.lookUp.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.lookUp.Properties.BorderStyle = BorderStyles.NoBorder;
                this.lookUp.IsUnderline = true;
            } else {
                this.lookUp.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.lookUp.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.lookUp.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.lookUp.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */
        private void lookUp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.mUiChange = true;
        }

        private void lookUp_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.mUiChange = true;
        }

        private void lookUp_LostFocus(object sender, System.EventArgs e)
        {
            this.mUiChange = false;
        }               

        public void EndEdit() {
            if (this.lookUp.DataBindings.Count > 0) {
                this.lookUp.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        public void SetValue(object value) {
            this.lookUp.EditValue = value;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.lookUp.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        #region IHelpField Members

        private string mHelpText = string.Empty;

        public string HelpText {
            get { return this.mHelpText; }
            set {
                this.mHelpText = value;
                FTSForm form = this.FindForm() as FTSForm;
                if (form != null) {
                    form.SetBalloonTooltip(this, this.mHelpText);
                    form.SetBalloonTooltip(this.label, this.mHelpText);
                    form.SetBalloonTooltip(this.ComboBox, this.mHelpText);
                }
            }
        }

        #endregion
    }
}