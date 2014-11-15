#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSNameIDCom : Panel, IRequire, IValid, IHelpField {
        private FTSMain mFTSMain;
        private DataSet mDataSet;
        private string mTableName;
        private bool mIsAllowEmpty;
        private bool mIsForceLookup = true;
        private string mNameField, mIdField;
        public event LookupEventHandler Lookup;
        private bool mIsChanged = false;
        private bool mRequire = false;
        private string mCondition = string.Empty;
        private string mTooltip = string.Empty;
        private ListType mListType = ListType.GRID;

        public FTSNameIDCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, ListType listtype, string condition,
                        bool allowempty) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mListType = listtype;
            this.mCondition = condition;
            this.mIsAllowEmpty = allowempty;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, ListType listtype, bool allowempty) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mListType = listtype;
            this.mIsAllowEmpty = allowempty;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, ListType listtype, string condition,
                        bool allowempty, bool forcelookup) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mListType = listtype;
            this.mCondition = condition;
            this.mIsAllowEmpty = allowempty;
            this.mIsForceLookup = forcelookup;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, string condition, bool allowempty) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mCondition = condition;
            this.mIsAllowEmpty = allowempty;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, bool allowempty) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mIsAllowEmpty = allowempty;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, string condition, bool allowempty,
                        bool forcelookup) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mCondition = condition;
            this.mIsAllowEmpty = allowempty;
            this.mIsForceLookup = forcelookup;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.textId.BackColor = SystemColors.Info;
                } else {
                    this.textId.BackColor = Color.White;
                }
            }
        }

        [DefaultValue(50)]
        public int TextIDLength {
            get { return this.textId.Width; }
            set { this.textId.Width = value; }
        }

        [DefaultValue(80)]
        public int TextNameLength {
            get { return this.textName.Width; }
            set { this.textName.Width = value; }
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

        public ButtonEdit txtID {
            get { return this.textId; }
        }

        public Label txtName {
            get { return this.textName; }
        }

        [Browsable(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public void UpdateInfo() {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            if (this.textId.Text.Trim().Length == 0) {
                this.textName.Text = string.Empty;
                this.mTooltip = string.Empty;
            } else {
                DataTable dt = this.mDataSet.Tables[this.mTableName];
                if (dt == null) {
                    this.AnalyseText(this.mFTSMain.TableManager.GetNameFieldValue(this.mTableName, this.mNameField, this.mIdField, this.textId.Text.Trim()));
                }else{
                    DataRow foundrow = dt.Rows.Find(this.textId.Text.Trim());
                    if (foundrow != null) {
                        this.AnalyseText(foundrow[this.mNameField].ToString());
                    } else {
                        this.textId.Text = string.Empty;
                        this.textName.Text = string.Empty;
                        this.mTooltip = string.Empty;
                    }
                }
            }
        }

        public void UpdateInfoNoLoad() {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            if (this.textId.Text.Trim().Length == 0) {
                this.textName.Text = string.Empty;
                this.mTooltip = string.Empty;
            } else {
                DataTable dt = this.mDataSet.Tables[this.mTableName];
                if (dt == null) {
                    object obj =
                        this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand("select " + this.mNameField + " from " + this.mTableName + " WHERE " +
                                                                 this.mIdField + "='" + this.textId.Text.Trim() + "'"));
                    if (obj != null && obj != System.DBNull.Value) {
                        this.AnalyseText(obj.ToString());
                    }else {
                        this.textId.Text = string.Empty;
                        this.textName.Text = string.Empty;
                        this.mTooltip = string.Empty;
                    }
                } else {
                    DataRow foundrow = dt.Rows.Find(this.textId.Text.Trim());
                    if (foundrow != null) {
                        this.AnalyseText(foundrow[this.mNameField].ToString());
                    } else {
                        this.textId.Text = string.Empty;
                        this.textName.Text = string.Empty;
                        this.mTooltip = string.Empty;
                    }
                }
            }
        }

        private void AnalyseText(string text) {
            this.mTooltip = text;
            string[] tmp = this.mTooltip.Split(new string[] {" "}, StringSplitOptions.None);
            bool flag = false;
            string display = string.Empty;
            string buffer = string.Empty;
            for (int i = 0; i < tmp.Length; i++) {
                display = buffer;
                buffer = buffer + " " + tmp[i];
                if (this.txtName.CreateGraphics().MeasureString(buffer + "...", this.txtName.Font).Width >
                    this.txtName.Width) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                this.txtName.Text = display + "...";
            } else {
                this.txtName.Text = buffer;
                this.mTooltip = string.Empty;
            }
        }

        public void ProcessMa() {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            if ((this.mIsAllowEmpty) & (this.textId.Text.Trim().Length == 0)) {
                this.textName.Text = string.Empty;
                return;
            }
            DataTable dt = this.mDataSet.Tables[this.mTableName];
            if (dt == null) {
                frm.LoadDm(this.mTableName);
                dt = this.mDataSet.Tables[this.mTableName];
                if (dt == null) {
                    dt = this.mFTSMain.TableManager.LoadTable(this.mDataSet, this.mTableName);
                }
            }
            DataRow foundrow = dt.Rows.Find(this.textId.Text.Trim());
            if (foundrow == null && this.mIsForceLookup) {
                FTSForm frmparent = (FTSForm) this.FindForm();
                Type type_frmdic = frmparent.GetFrmDicList(this.mTableName);
                if (type_frmdic != null) {
                    Type[] typeArray = new Type[6] {
                                                       typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                       typeof (string), typeof (bool)
                                                   };
                    ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                    if (constructorInfoObj == null) {
                        throw new ArgumentException("Not Constructor");
                    }
                    Object[] objArg = new object[6] {
                                                        this.mFTSMain, this.mDataSet, this.mTableName, this.mCondition, this.textId.Text,
                                                        this.mIsAllowEmpty
                                                    };
                    if (this.mListType == ListType.GRID) {
                        FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                        frmdic.ShowDialog();
                        if (frmdic.DialogResult == DialogResult.OK) {
                            this.textId.Text = frmdic.RetRow[this.mIdField].ToString();
                            if (this.textId.DataBindings.Count > 0) {
                                this.textId.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                            }
                            this.AnalyseText(frmdic.RetRow[this.mNameField].ToString());
                            this.mIsChanged = true;
                        } else {
                            this.textId.Text = string.Empty;
                            this.textName.Text = string.Empty;
                            this.mTooltip = string.Empty;
                        }
                    } else {
                        FrmDataTreeList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataTreeList;
                        frmdic.ShowDialog();
                        if (frmdic.DialogResult == DialogResult.OK) {
                            this.textId.Text = frmdic.RetRow[this.mIdField].ToString();
                            if (this.textId.DataBindings.Count > 0) {
                                this.textId.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                            }
                            this.AnalyseText(frmdic.RetRow[this.mNameField].ToString());
                            this.mIsChanged = true;
                        } else {
                            this.textId.Text = string.Empty;
                            this.textName.Text = string.Empty;
                            this.mTooltip = string.Empty;
                        }
                    }
                }
            } else {
                if (foundrow != null) {
                    this.AnalyseText(foundrow[this.mNameField].ToString());
                }
            }
        }

        public void ProcessLookup() {
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm == null || frm.OnClose) {
                return;
            }
            this.mIsChanged = false;
            DataTable dt = this.mDataSet.Tables[this.mTableName];
            if (dt == null) {
                frm.LoadDm(this.mTableName);
                dt = this.mDataSet.Tables[this.mTableName];
                if (dt == null) {
                    this.mFTSMain.TableManager.LoadTable(this.mDataSet, this.mTableName);
                }
            }
            FTSForm frmparent = (FTSForm) this.FindForm();
            Type type_frmdic = frmparent.GetFrmDicList(this.mTableName);
            if (type_frmdic != null) {
                Type[] typeArray = new Type[6] {
                                                   typeof (FTSMain), typeof (DataSet), typeof (string), typeof (string),
                                                   typeof (string), typeof (bool)
                                               };
                ConstructorInfo constructorInfoObj = type_frmdic.GetConstructor(typeArray);
                if (constructorInfoObj == null) {
                    throw new ArgumentException("Not Constructor");
                }
                Object[] objArg = new object[6]
                                  {this.mFTSMain, this.mDataSet, this.mTableName, this.mCondition, string.Empty, true};
                if (this.mListType == ListType.GRID) {
                    FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK) {
                        this.textId.Text = frmdic.RetRow[this.mIdField].ToString();
                        if (this.textId.DataBindings.Count > 0) {
                            this.textId.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                        }
                        this.AnalyseText(frmdic.RetRow[this.mNameField].ToString());
                        this.mIsChanged = true;
                    }
                } else {
                    FrmDataTreeList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataTreeList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK) {
                        this.textId.Text = frmdic.RetRow[this.mIdField].ToString();
                        if (this.textId.DataBindings.Count > 0) {
                            this.textId.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                        }
                        this.AnalyseText(frmdic.RetRow[this.mNameField].ToString());
                        this.mIsChanged = true;
                    }
                }
            }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.textId.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.textName.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.textId.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.textId.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textId.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textId.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.textId.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.textId.Properties.Appearance.Options.UseBackColor = true;
                this.textId.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.textId.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.textId.Properties.BorderStyle = BorderStyles.NoBorder;
                this.textId.IsUnderline = true;
            } else {
                this.textId.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.textId.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.textId.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.textId.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        public void EndEdit() {
            if (this.textId.DataBindings.Count > 0) {
                this.textId.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.textId.Focus();
        }

        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }

        protected virtual void OnLookup(object sender, EventArgs e) {
            if (this.Lookup != null) {
                this.Lookup(this, e);
            }
        }

        private void textId_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        private void textId_ButtonPressed(object sender, ButtonPressedEventArgs e) {
            try {
                this.OnLookup(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        public void SetTextLength(FTS.BaseBusiness.Systems.FieldInfo field) {
            this.textId.Properties.MaxLength = field.MaxLength;
        }

        public void SetTextLength(int length) {
            this.textId.Properties.MaxLength = length;
        }

        public void SetCase(bool isupper) {
            if (isupper) {
                this.textId.Properties.CharacterCasing = CharacterCasing.Upper;
            } else {
                this.textId.Properties.CharacterCasing = CharacterCasing.Lower;
            }
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.textId.EditValue.ToString().Trim() == string.Empty) {
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
                    form.SetBalloonTooltip(this.txtID, this.mHelpText);
                    form.SetBalloonTooltip(this.txtName, this.mHelpText);
                }
            }
        }

        #endregion
    }

    public enum ListType {
        GRID = 0,
        TREE = 1
    }

    public delegate void LookupEventHandler(object sender, EventArgs e);
}