#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public delegate void PercentLeaveEventHandler(object sender, EventArgs e);

    public delegate void AmountLeaveEventHandler(object sender, EventArgs e);

    public partial class FTSPercentCom : Panel, IHelpField, IRequire, IValid {
        public bool IsPercentChanged = false;
        public bool IsAmountChanged = false;
        public event PercentLeaveEventHandler PercentLeave;
        public event AmountLeaveEventHandler AmountLeave;
        private bool mRequire = false;

        public FTSPercentCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        public int LabelLength {
            get { return this.label.Width; }
            set {
                if (!this.DesignMode)
                {
                    this.label.Dock = DockStyle.None;
                    this.label.Location = new Point(0, 0);
                    this.txtPercent.Dock = DockStyle.None;
                    this.lblPercent.Dock = DockStyle.None;
                    this.txtAmount.Dock = DockStyle.None;
                }                        
                this.label.Width = value;
                this.txtPercent.Location = new Point(this.label.Width, this.txtPercent.Location.Y);
                this.lblPercent.Location = new Point(this.label.Width + this.txtPercent.Width, this.lblPercent.Location.Y);
                this.txtAmount.Location = new Point(this.label.Width + this.txtPercent.Width + this.lblPercent.Width, this.txtAmount.Location.Y);
                this.txtAmount.Width = this.Width - this.txtAmount.Location.X;
            }
        }

        public string LabelText {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        private void SetProperty() {
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
            this.txtPercent.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.txtPercent.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.txtPercent.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPercent.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPercent.Properties.DisplayFormat.FormatString = "n0";
            this.txtPercent.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtPercent.Properties.EditFormat.FormatString = "n0";
            this.txtPercent.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.txtPercent.Properties.Mask.EditMask = "n0";
            this.txtPercent.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            base.BackColor = Color.Transparent;
            this.txtPercent.EditValueChanged += new EventHandler(this.PercentEditValueChanged);
            this.txtPercent.GotFocus += new EventHandler(this.txtPercent_GotFocus);
            this.txtAmount.GotFocus += new EventHandler(this.txtAmount_GotFocus);
            this.txtAmount.EditValueChanged += new EventHandler(this.AmountEditValueChanged);
            this.txtPercent.Leave += new EventHandler(this.txtPercent_Leave);
            this.txtAmount.Leave += new EventHandler(this.txtAmount_Leave);
            this.txtPercent.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.txtAmount.Spin += new SpinEventHandler(this.DisableMouseWheel);
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.txtPercent.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtPercent.Properties.Appearance.Options.UseBackColor = true;
                this.txtPercent.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtPercent.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtPercent.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtPercent.IsUnderline = true;
                this.txtAmount.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtAmount.Properties.Appearance.Options.UseBackColor = true;
                this.txtAmount.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtAmount.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtAmount.IsUnderline = false;
            } else {
                this.txtPercent.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtPercent.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtPercent.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtPercent.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtAmount.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtAmount.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void SetDecimalPlace(int digits) {
            if (digits != 0) {
                this.txtAmount.Properties.DisplayFormat.FormatString = "n" + digits.ToString().Trim();
                this.txtAmount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.txtAmount.Properties.EditFormat.FormatString = "n" + digits.ToString().Trim();
                this.txtAmount.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.txtAmount.Properties.Mask.EditMask = "n" + digits.ToString().Trim();
                this.txtAmount.Properties.Mask.MaskType = MaskType.Numeric;
                this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            } else {
                this.txtAmount.Properties.DisplayFormat.FormatString = "n0";
                this.txtAmount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.txtAmount.Properties.EditFormat.FormatString = "n0";
                this.txtAmount.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.txtAmount.Properties.Mask.EditMask = "n0";
                this.txtAmount.Properties.Mask.MaskType = MaskType.Numeric;
                this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        public void SetDecimalPlacePercent(int digits) {
            if (digits != 0) {
                this.txtPercent.Properties.DisplayFormat.FormatString = "n" + digits.ToString().Trim();
                this.txtPercent.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.txtPercent.Properties.EditFormat.FormatString = "n" + digits.ToString().Trim();
                this.txtPercent.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.txtPercent.Properties.Mask.EditMask = "n" + digits.ToString().Trim();
                this.txtPercent.Properties.Mask.MaskType = MaskType.Numeric;
                this.txtPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            } else {
                this.txtPercent.Properties.DisplayFormat.FormatString = "n0";
                this.txtPercent.Properties.DisplayFormat.FormatType = FormatType.Numeric;
                this.txtPercent.Properties.EditFormat.FormatString = "n0";
                this.txtPercent.Properties.EditFormat.FormatType = FormatType.Numeric;
                this.txtPercent.Properties.Mask.EditMask = "n0";
                this.txtPercent.Properties.Mask.MaskType = MaskType.Numeric;
                this.txtPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.txtPercent.Focus();
        }

        protected override void OnResize(EventArgs e) {
            this.txtAmount.Width = this.Width - this.txtAmount.Left;
        }

        private void PercentEditValueChanged(object sender, EventArgs e) {
            this.IsPercentChanged = true;
        }

        private void AmountEditValueChanged(object sender, EventArgs e) {
            this.IsAmountChanged = true;
        }

        private void txtPercent_Leave(object sender, EventArgs e) {
            try {
                this.OnPercentLeave(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e) {
            try {
                this.OnAmountLeave(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        protected virtual void OnPercentLeave(object sender, EventArgs e) {
            if (this.PercentLeave != null) {
                //Invokes the delegates.
                this.PercentLeave(this, e);
            }
        }

        protected virtual void OnAmountLeave(object sender, EventArgs e) {
            if (this.AmountLeave != null) {
                //Invokes the delegates.
                this.AmountLeave(this, e);
            }
        }

        private void txtAmount_GotFocus(object sender, EventArgs e) {
            this.IsAmountChanged = false;
        }

        private void txtPercent_GotFocus(object sender, EventArgs e) {
            this.IsPercentChanged = false;
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
                    form.SetBalloonTooltip(this.txtPercent, this.mHelpText);
                    form.SetBalloonTooltip(this.txtAmount, this.mHelpText);
                }
            }
        }

        #endregion

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.txtPercent.BackColor = SystemColors.Info;
                } else {
                    this.txtPercent.BackColor = Color.White;
                }
            }
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.txtPercent.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }
    }
}