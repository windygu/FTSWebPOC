#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSDateCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private bool mAllowNull = false;
        public event EventHandler DateChanged;

        public FTSDateCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false)]
        public bool AllowNull {
            get { return this.mAllowNull; }
            set {
                this.mAllowNull = value;
                this.dateEdit.Properties.ShowClear = value;
                if (value) {
                    this.dateEdit.Properties.AllowNullInput = DefaultBoolean.True;
                } else {
                    this.dateEdit.Properties.AllowNullInput = DefaultBoolean.False;
                }
            }
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.dateEdit.BackColor = SystemColors.Info;
                } else {
                    this.dateEdit.BackColor = Color.White;
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
        public DateEdit DateTime {
            get { return this.dateEdit; }
        }

        private void SetProperty() {
            this.dateEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.dateEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.dateEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dateEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.dateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            this.dateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dateEdit.Properties.Mask.EditMask = "dd/MM/yy";
            this.dateEdit.EditValueChanged += new EventHandler(this.EditValueChanged);
            this.dateEdit.DateTimeChanged += new EventHandler(DateTimeChanged);
        }        

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.dateEdit.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.dateEdit.Properties.Appearance.Options.UseBackColor = true;
                this.dateEdit.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.dateEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.dateEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                this.dateEdit.IsUnderline = true;
            } else {
                this.dateEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.dateEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.dateEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.dateEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        public void EndEdit() {
            if (this.dateEdit.DataBindings.Count > 0) {
                this.dateEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.dateEdit.Focus();
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.dateEdit.EditValue.ToString().Trim() == string.Empty) {
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
                    form.SetBalloonTooltip(this.dateEdit, this.mHelpText);
                }
            }
        }

        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }

        private void EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;            
        }

        private void DateTimeChanged(object sender, EventArgs e)
        {
            if (DateChanged != null)
                this.DateChanged(sender, e);
        }
        #endregion
    }
}