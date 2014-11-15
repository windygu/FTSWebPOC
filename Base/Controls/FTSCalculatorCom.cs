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

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSCalculatorCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;

        public FTSCalculatorCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.calcEdit.BackColor = SystemColors.Info;
                } else {
                    this.calcEdit.BackColor = Color.White;
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
        public CalcEdit Calculator {
            get { return this.calcEdit; }
            set { this.calcEdit = value; }
        }

        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        private void SetProperty() {
            this.calcEdit.Properties.AppearanceDisabled.BackColor = Color.White;
            this.calcEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.calcEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.calcEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.calcEdit.Properties.DisplayFormat.FormatString = "n0";
            this.calcEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.calcEdit.Properties.EditFormat.FormatString = "n0";
            this.calcEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.calcEdit.Properties.Mask.EditMask = "n0";
            this.calcEdit.Properties.Mask.MaskType = MaskType.Numeric;
            this.calcEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.calcEdit.EditValueChanged += new EventHandler(this.EditValueChanged);
            this.calcEdit.Spin += new SpinEventHandler(this.DisableMouseWheel);
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void SetDecimalPlace(int digits) {
            if (digits != 0) {
                this.calcEdit.Properties.DisplayFormat.FormatString = "n" + digits.ToString().Trim();
                this.calcEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.calcEdit.Properties.EditFormat.FormatString = "n" + digits.ToString().Trim();
                this.calcEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.calcEdit.Properties.Mask.EditMask = "n" + digits.ToString().Trim();
                this.calcEdit.Properties.Mask.MaskType = MaskType.Numeric;
                this.calcEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            } else {
                this.calcEdit.Properties.DisplayFormat.FormatString = "n0";
                this.calcEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.calcEdit.Properties.EditFormat.FormatString = "n0";
                this.calcEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.calcEdit.Properties.Mask.EditMask = "n0";
                this.calcEdit.Properties.Mask.MaskType = MaskType.Numeric;
                this.calcEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        public void EndEdit() {
            if (this.calcEdit.DataBindings.Count > 0) {
                this.calcEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.calcEdit.Focus();
        }

        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }

        private void EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.calcEdit.EditValue.ToString().Trim() == string.Empty) {
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
                    form.SetBalloonTooltip(this.calcEdit, this.mHelpText);
                }
            }
        }

        #endregion
    }
}