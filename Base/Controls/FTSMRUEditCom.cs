#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSMRUEditCom : Panel, IRequire, IValid, IHelpField {
        private bool mRequire = false;

        public FTSMRUEditCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.mruEdit.BackColor = SystemColors.Info;
                } else {
                    this.mruEdit.BackColor = Color.White;
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
        public MRUEdit MruEdit {
            get { return this.mruEdit; }
        }

        public void Set(FTSMain ftsmain, DataTable tbl, string nameField) {
            foreach (DataRow ro in tbl.Rows) {
                this.mruEdit.Properties.Items.Add(ro[nameField]);
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.mruEdit.Focus();
        }

        private void SetProperty() {
            this.mruEdit.Properties.AppearanceDisabled.BackColor = Color.White;
            this.mruEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.mruEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.mruEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.mruEdit.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.mruEdit.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.mruEdit.Properties.Appearance.Options.UseBackColor = true;
                this.mruEdit.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.mruEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.mruEdit.Properties.BorderStyle = BorderStyles.NoBorder;
            } else {
                this.mruEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.mruEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.mruEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.mruEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        public void EndEdit() {
            if (this.mruEdit.DataBindings.Count > 0) {
                this.mruEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        public void SetValue(object value) {
            this.mruEdit.EditValue = value;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.mruEdit.EditValue.ToString().Trim() == string.Empty) {
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
                    form.SetBalloonTooltip(this.mruEdit, this.mHelpText);
                }
            }
        }

        #endregion
    }
}