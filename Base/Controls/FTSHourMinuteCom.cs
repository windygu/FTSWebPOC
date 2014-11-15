#region

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
    public partial class FTSHourMinuteCom : Panel, IHelpField, IRequire, IValid {
        private bool mRequire = false;

        public FTSHourMinuteCom() {
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
                    this.txtHour.Dock = DockStyle.None;
                    this.lblSeperator.Dock = DockStyle.None;
                    this.txtMinute.Dock = DockStyle.None;
                }                
                this.label.Width = value;
                this.txtHour.Location = new Point(this.label.Width,this.txtHour.Location.Y);
                this.lblSeperator.Location = new Point(this.label.Width + this.txtHour.Width,  this.lblSeperator.Location.Y);
                this.txtMinute.Location = new Point(this.label.Width + this.txtHour.Width + this.lblSeperator.Width, this.txtMinute.Location.Y);                
                this.txtMinute.Width = this.Width - this.txtMinute.Location.X;
            }
        }

        public void EndEdit()
        {
            if (this.txtHour.DataBindings.Count > 0)
            {
                this.txtHour.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
            if (this.txtMinute.DataBindings.Count > 0)
            {
                this.txtMinute.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value;
            if (!this.DesignMode)
            {
                this.label.Dock = DockStyle.None;
                this.label.Location = new Point(0, 0);
                this.txtHour.Dock = DockStyle.None;
                this.lblSeperator.Dock = DockStyle.None;
                this.txtMinute.Dock = DockStyle.None;
            }            
            this.txtHour.Location = new Point(this.label.Width, this.txtHour.Location.Y);
            this.lblSeperator.Location = new Point(this.label.Width + this.txtHour.Width, this.lblSeperator.Location.Y);
            this.txtMinute.Location = new Point(this.label.Width + this.txtHour.Width + this.lblSeperator.Width, this.txtMinute.Location.Y);
            this.txtMinute.Width = this.Width - this.txtMinute.Location.X;
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
            this.txtMinute.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.txtMinute.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.txtMinute.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtMinute.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtMinute.Properties.DisplayFormat.FormatString = "n0";
            this.txtMinute.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtMinute.Properties.EditFormat.FormatString = "n0";
            this.txtMinute.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.txtMinute.Properties.Mask.EditMask = "n0";
            this.txtMinute.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtMinute.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHour.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.txtHour.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.txtHour.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtHour.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtHour.Properties.DisplayFormat.FormatString = "n0";
            this.txtHour.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtHour.Properties.EditFormat.FormatString = "n0";
            this.txtHour.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.txtHour.Properties.Mask.EditMask = "n0";
            this.txtHour.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtHour.Properties.Mask.UseMaskAsDisplayFormat = true;
            base.BackColor = Color.Transparent;
            this.txtHour.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.txtMinute.Spin += new SpinEventHandler(this.DisableMouseWheel);
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.txtHour.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtHour.Properties.Appearance.Options.UseBackColor = true;
                this.txtHour.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtHour.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtHour.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtHour.IsUnderline = true;
                this.txtMinute.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.txtMinute.Properties.Appearance.Options.UseBackColor = true;
                this.txtMinute.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.txtMinute.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtMinute.Properties.BorderStyle = BorderStyles.NoBorder;
                this.txtMinute.IsUnderline = false;
            } else {
                this.txtHour.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtHour.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtHour.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtHour.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.txtMinute.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.txtMinute.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.txtMinute.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.txtMinute.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
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
                    form.SetBalloonTooltip(this.txtHour, this.mHelpText);
                    form.SetBalloonTooltip(this.txtMinute, this.mHelpText);
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
                    this.txtHour.BackColor = SystemColors.Info;
                } else {
                    this.txtHour.BackColor = Color.White;
                }
            }
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.txtHour.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }
        public FTSSpinEdit Hour
        {
            get { return this.txtHour; }
        }
        public FTSSpinEdit Minute
        {
            get { return this.txtMinute; }
        }
    }
}