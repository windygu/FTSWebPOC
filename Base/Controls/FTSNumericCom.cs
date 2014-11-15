#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;
using System.Globalization;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSNumericCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private decimal mMin = 0;
        private decimal mMax = 0;

        public FTSNumericCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.textNumeric.BackColor = SystemColors.Info;
                } else {
                    this.textNumeric.BackColor = Color.White;
                }
            }
        }

        [DefaultValue(80)]
        public int LabelLength {
            get { return this.label.Width; }
            set { this.label.Width = value; }
        }

        [DefaultValue(0)]
        public decimal Min
        {
            get { return this.mMin; }
            set { this.mMin = value; }
        }

        [DefaultValue(0)]
        public decimal Max
        {
            get { return this.mMax; }
            set { this.mMax = value; }
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
        public TextEdit NumericTextBox {
            get { return this.textNumeric; }
            set { this.textNumeric = (FTSNumericTextBox) value; }
        }

        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.textNumeric.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textNumeric.Properties.DisplayFormat.FormatString = "n0";
            this.textNumeric.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.EditFormat.FormatString = "n0";
            this.textNumeric.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.Mask.EditMask = "n0";
            this.textNumeric.Properties.Mask.MaskType = MaskType.Numeric;
            this.textNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textNumeric.EditValueChanged += new EventHandler(this.EditValueChanged);
            this.textNumeric.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.textNumeric.EditValueChanging += new ChangingEventHandler(textNumeric_EditValueChanging);
        }

        private void textNumeric_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((this.mMax == 0) && (this.mMin == 0))
            {
            }
            else
            {
                decimal number = decimal.Parse(e.NewValue.ToString(), NumberStyles.Any);
                if ((number > this.mMax) || (number < this.mMin))
                    e.Cancel = true;
            }
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.textNumeric.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.textNumeric.Properties.Appearance.Options.UseBackColor = true;
                this.textNumeric.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.textNumeric.Properties.BorderStyle = BorderStyles.NoBorder;
                this.textNumeric.IsUnderline = true;
            } else {
                this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.textNumeric.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void EndEdit() {
            if (this.textNumeric.DataBindings.Count > 0) {
                this.textNumeric.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        public void SetDecimalPlace(int digits) {
            if (digits != 0) {
                this.textNumeric.Properties.DisplayFormat.FormatString = "n" + digits.ToString().Trim();
                this.textNumeric.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.textNumeric.Properties.EditFormat.FormatString = "n" + digits.ToString().Trim();
                this.textNumeric.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.textNumeric.Properties.Mask.EditMask = "n" + digits.ToString().Trim();
                this.textNumeric.Properties.Mask.MaskType = MaskType.Numeric;
                this.textNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
            } else {
                this.textNumeric.Properties.DisplayFormat.FormatString = "n0";
                this.textNumeric.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.textNumeric.Properties.EditFormat.FormatString = "n0";
                this.textNumeric.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.textNumeric.Properties.Mask.EditMask = "n0";
                this.textNumeric.Properties.Mask.MaskType = MaskType.Numeric;
                this.textNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.textNumeric.Focus();
        }

        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }

        private void EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.textNumeric.EditValue.ToString().Trim() == string.Empty) {
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
                    form.SetBalloonTooltip(this.NumericTextBox, this.mHelpText);
                }
            }
        }

        #endregion
    }
}