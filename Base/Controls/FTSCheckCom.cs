#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSCheckCom : Panel, IHelpField {
        public event EventHandler CheckedChanged;

        public FTSCheckCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (msg.WParam.ToInt32() == (int) Keys.Enter) {
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public string LabelText {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [DefaultValue(80)]
        public int LabelLenght {
            get { return this.label.Width; }
            set { this.label.Width = value; }
        }

        [Browsable(false)]
        public CheckEdit CheckBox {
            get { return this.checkbox; }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.CheckBox.Focus();
        }

        private void SetProperty() {
            this.checkbox.Properties.AppearanceDisabled.BackColor = Color.White;
            this.checkbox.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.checkbox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.checkbox.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.checkbox.Properties.NullStyle = StyleIndeterminate.Unchecked;
            this.checkbox.Properties.ValueChecked = Convert.ToInt16(1);
            this.checkbox.Properties.ValueUnchecked = Convert.ToInt16(0);
            this.checkbox.CheckedChanged += new EventHandler(this.checkbox_CheckedChanged);
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e) {
            try {
                this.OnCheckedChanged(sender, new EventArgs());
            } catch (Exception) {
            }
        }

        protected virtual void OnCheckedChanged(object sender, EventArgs e) {
            if (this.CheckedChanged != null) {
                this.CheckedChanged(this, e);
            }
        }

        public void EndEdit() {
            if (this.checkbox.DataBindings.Count > 0) {
                this.checkbox.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
                    form.SetBalloonTooltip(this.checkbox, this.mHelpText);
                }
            }
        }

        #endregion
    }
}