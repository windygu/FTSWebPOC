#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSUpDownCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;

        public FTSUpDownCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.spinEdit.BackColor = SystemColors.Info;
                } else {
                    this.spinEdit.BackColor = Color.White;
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

        public decimal MinValue {
            get { return this.spinEdit.Properties.MinValue; }
            set { this.spinEdit.Properties.MinValue = value; }
        }

        public decimal MaxValue {
            get { return this.spinEdit.Properties.MaxValue; }
            set { this.spinEdit.Properties.MaxValue = value; }
        }

        [Browsable(false)]
        public FTSSpinEdit UpDown {
            get { return this.spinEdit; }
            set { this.spinEdit = value; }
        }

        [DefaultValue(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        private void spinEdit_Enter(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        private void spinEdit_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.spinEdit.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.spinEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.spinEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.spinEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.spinEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            /*
            this.spinEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(DisableMouseWheel);
            */ 
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.spinEdit.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.spinEdit.Properties.Appearance.Options.UseBackColor = true;
                this.spinEdit.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.spinEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.spinEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                this.spinEdit.IsUnderline = true;
            } else {
                this.spinEdit.Properties.AppearanceDisabled.BackColor = Color.White;
                this.spinEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.spinEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.spinEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        /*
        private void DisableMouseWheel(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }
        */ 
        public void EndEdit() {
            if (this.spinEdit.DataBindings.Count > 0) {
                this.spinEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
                    form.SetBalloonTooltip(this.UpDown, this.mHelpText);
                }
            }
        }

        #endregion
    }
}