#region

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
    public partial class FTSReadOnlyNumericCom : Panel, IRequire, IValid, IHelpField {
        private bool mRequire = false;

        public FTSReadOnlyNumericCom() {
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

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            /*
            this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.Transparent;
            this.textNumeric.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textNumeric.Properties.Appearance.BackColor = Color.Transparent;
            this.textNumeric.Properties.Appearance.ForeColor = Color.Black;
            this.textNumeric.Properties.Appearance.Options.UseForeColor = true;
            this.textNumeric.Properties.Appearance.Options.UseBackColor = true;
            this.textNumeric.Properties.BorderStyle = BorderStyles.NoBorder;
            this.textNumeric.Properties.Appearance.Font =new Font(this.textNumeric.Properties.Appearance.Font.FontFamily,this.textNumeric.Properties.Appearance.Font.Size, FontStyle.Bold);
            this.textNumeric.IsUnderline = true;
            */ 
            this.textNumeric.Properties.DisplayFormat.FormatString = "n0";
            this.textNumeric.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.EditFormat.FormatString = "n0";
            this.textNumeric.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.Mask.EditMask = "n0";
            this.textNumeric.Properties.Mask.MaskType = MaskType.Numeric;
            this.textNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        
        protected override void OnCreateControl() {
            base.OnCreateControl();
            /*
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null) {
            */ 
                this.textNumeric.Properties.Appearance.BackColor = Color.Transparent;
                this.textNumeric.Properties.Appearance.Options.UseBackColor = true;
                this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.Transparent;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.textNumeric.Properties.BorderStyle = BorderStyles.NoBorder;
                this.textNumeric.Properties.Appearance.Font =
                    new Font(this.textNumeric.Properties.Appearance.Font.FontFamily,
                             this.textNumeric.Properties.Appearance.Font.Size, FontStyle.Bold);
                this.textNumeric.IsUnderline = true;
            /*
            } else {
                this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.textNumeric.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
            */ 
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