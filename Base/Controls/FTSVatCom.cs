#region

using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using System.ComponentModel;

#endregion

namespace FTS.BaseUI.Controls {
    public delegate void IdLeaveEventHandler(object sender, EventArgs e);

    public partial class FTSVatCom : Panel, IRequire, IValid, IHelpField
    {
        private FTSMain mFTSMain;
        private DataSet mDataSet;
        private string mTableName;
        private bool mIsAllowEmpty;
        private string mNameField, mIdField;
        public event LookupEventHandler Lookup;
        public bool IsIdChanged = false;
        public bool IsAmountChanged = false;
        public event IdLeaveEventHandler IdLeave;
        public event AmountLeaveEventHandler AmountLeave;
        private bool mRequire = false;

        public FTSVatCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        private void SetProperty() {
            this.txtId.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.txtId.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.txtId.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.BackColor = Color.Transparent;
            this.Label.TextAlign = ContentAlignment.MiddleLeft;
            this.cmdFind.AllowFocus = false;
            this.txtId.EditValueChanged += new EventHandler(this.IdEditValueChanged);
            this.txtId.GotFocus += new EventHandler(this.txtId_GotFocus);
            this.txtAmount.GotFocus += new EventHandler(this.txtAmount_GotFocus);
            this.txtAmount.EditValueChanged += new EventHandler(this.AmountEditValueChanged);
            this.txtId.Leave += new EventHandler(this.txtId_Leave);
            this.txtAmount.Leave += new EventHandler(this.txtAmount_Leave);
            this.txtId.Properties.CharacterCasing = CharacterCasing.Upper;
            this.txtAmount.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.txtAmount.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtAmount.Properties.DisplayFormat.FormatString = "n0";
            this.txtAmount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtAmount.Properties.EditFormat.FormatString = "n0";
            this.txtAmount.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.txtAmount.Properties.Mask.EditMask = "n0";
            this.txtAmount.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        public void SetFont() {
            this.txtId.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.txtAmount.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.Label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.txtAmount.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtAmount.Properties.Appearance.Options.UseBackColor = true;
                this.txtAmount.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtAmount.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtAmount.IsUnderline = true;
                this.txtId.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtId.Properties.Appearance.Options.UseBackColor = true;
                this.txtId.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtId.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtId.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtId.IsUnderline = false;
                this.cmdFind.BorderStyle = BorderStyles.NoBorder;
            } else {
                this.txtAmount.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtAmount.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtId.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtId.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtId.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtId.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        public void Set(FTSMain ftsmain, DataSet ds, string tablename, bool allowempty) {
            this.mFTSMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mIsAllowEmpty = allowempty;
            this.mNameField = this.mFTSMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFTSMain.TableManager.GetIDField(this.mTableName);
        }

        public int TextIDLength {
            get { return this.txtId.Width; }
            set {
                this.txtId.Width = value;
                this.Label.Left = 0;
                this.txtId.Left = this.Label.Right;
                this.cmdFind.Left = this.txtID.Right;
                this.txtAmount.Left = this.cmdFind.Right;
                this.txtAmount.Width = this.Width - this.txtAmount.Left;
            }
        }

        public int LabelLength {
            get { return this.Label.Width; }
            set {
                this.Label.Width = value;
                this.Label.Left = 0;
                this.txtId.Left = this.Label.Right;
                this.cmdFind.Left = this.txtID.Right;
                this.txtAmount.Left = this.cmdFind.Right;
                this.txtAmount.Width = this.Width - this.txtAmount.Left;
            }
        }

        public string LabelText {
            get { return this.Label.Text; }
            set { this.Label.Text = value; }
        }

        public override string Text {
            get { return this.Label.Text; }
            set { this.Label.Text = value; }
        }

        public FTSTextBox txtID {
            get { return this.txtId; }
        }

        private void cmdFind_Click(object sender, EventArgs e) {
            try {
                this.OnLookup(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        public void UpdateInfo() {
            DataTable dt = this.mDataSet.Tables[this.mTableName];
            if (dt == null) {
                dt = this.mFTSMain.TableManager.LoadTable(this.mDataSet, this.mTableName);
            }
            DataRow foundrow = dt.Rows.Find(this.txtID.Text.Trim());
            if (foundrow == null) {
                this.txtID.Text = string.Empty;
            }
        }

        public void ProcessMa() {
            if ((this.mIsAllowEmpty) & (this.txtID.Text.Trim().Length == 0)) {
                return;
            }
            DataTable dt = this.mDataSet.Tables[this.mTableName];
            if (dt == null) {
                dt = this.mFTSMain.TableManager.LoadTable(this.mDataSet, this.mTableName);
            }
            DataRow foundrow = dt.Rows.Find(this.txtID.Text.Trim());
            if (foundrow == null) {
                try {
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
                                                            this.mFTSMain, this.mDataSet, this.mTableName, "", this.txtID.Text,
                                                            this.mIsAllowEmpty
                                                        };
                        FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                        frmdic.ShowDialog();
                        if (frmdic.DialogResult == DialogResult.OK) {
                            this.txtID.Text = frmdic.RetRow[this.mIdField].ToString();
                            if (this.txtID.DataBindings.Count > 0) {
                                this.txtID.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                            }
                            this.IsIdChanged = true;
                        } else {
                            this.txtID.Text = string.Empty;
                        }
                    }
                } catch (Exception ex) {
                    throw new FTSException(ex);
                }
            }
        }

        public void ProcessLookup() {
            this.IsIdChanged = false;
            DataTable dt = this.mDataSet.Tables[this.mTableName];
            if (dt == null) {
                dt = this.mFTSMain.TableManager.LoadTable(this.mDataSet, this.mTableName);
            }
            try {
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
                                      {this.mFTSMain, this.mDataSet, this.mTableName, "1=1", string.Empty, true};
                    FrmDataList frmdic = constructorInfoObj.Invoke(objArg) as FrmDataList;
                    frmdic.ShowDialog();
                    if (frmdic.DialogResult == DialogResult.OK) {
                        this.txtID.Text = frmdic.RetRow[this.mIdField].ToString();
                        this.IsIdChanged = true;
                        if (this.txtID.DataBindings.Count > 0) {
                            this.txtID.DataBindings[0].BindingManagerBase.EndCurrentEdit();
                        }
                    }
                }
            } catch (Exception ex) {
                throw new FTSException(ex);
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.txtID.Focus();
        }

        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsCache cache = new GraphicsCache(e);
            try
            {
                Graphics gfx = e.Graphics;
                Color brushColor;
                brushColor = Office2003Colors.Default[Office2003Color.TextDisabled];
                SolidBrush myBrush = new SolidBrush(brushColor);
                Pen pen = new Pen(myBrush, 1);
                gfx.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
            }
            finally
            {
                cache.Dispose();
            }
            base.OnPaint(e);
        }
        */ 
            
        protected virtual void OnLookup(object sender, EventArgs e) {
            if (this.Lookup != null) {          
                this.Lookup(this, e);
            }
        }

        private void IdEditValueChanged(object sender, EventArgs e) {
            this.IsIdChanged = true;
        }

        private void AmountEditValueChanged(object sender, EventArgs e) {
            this.IsAmountChanged = true;
        }

        private void txtId_Leave(object sender, EventArgs e) {
            try {
                this.OnIdLeave(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e) {
            try {
                this.OnAmountLeave(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        protected virtual void OnIdLeave(object sender, EventArgs e) {
            if (this.IdLeave != null) {                
                this.IdLeave(this, e);
            }
        }

        protected virtual void OnAmountLeave(object sender, EventArgs e) {
            if (this.AmountLeave != null) {                
                this.AmountLeave(this, e);
            }
        }

        private void txtAmount_GotFocus(object sender, EventArgs e) {
            this.IsAmountChanged = false;
        }

        private void txtId_GotFocus(object sender, EventArgs e) {
            this.IsIdChanged = false;
        }

        protected override void OnResize(EventArgs e) {
            this.txtAmount.Left = this.cmdFind.Right;
            this.txtAmount.Width = this.Width - this.txtAmount.Left;
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
                    form.SetBalloonTooltip(this.Label, this.mHelpText);
                    form.SetBalloonTooltip(this.txtId, this.mHelpText);
                    form.SetBalloonTooltip(this.txtAmount, this.mHelpText);
                    form.SetBalloonTooltip(this.cmdFind, this.mHelpText);
                }
            }
        }

        #endregion

        #region IRequire Members

        [DefaultValue(false), Browsable(false)]
        public bool Require
        {
            get { return this.mRequire; }
            set
            {
                this.mRequire = value;
                if (this.mRequire)
                {
                    this.txtId.BackColor = SystemColors.Info;
                    this.txtAmount.BackColor = SystemColors.Info;
                }
                else
                {
                    this.txtId.BackColor = Color.White;
                    this.txtAmount.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region IValid Members

        public bool IsValid()
        {
            if (this.mRequire && this.Visible)
            {
                if (this.txtId.EditValue.ToString().Trim() == string.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}