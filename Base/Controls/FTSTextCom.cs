#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using System.Data;
using System.Collections;
#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSTextCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;        

        public FTSTextCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        protected override void OnGotFocus(EventArgs e) {
            this.textEdit.Focus();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.textEdit.BackColor = SystemColors.Info;
                } else {
                    this.textEdit.BackColor = Color.White;
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

        [DefaultValue(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [DefaultValue("")]
        public TextEdit Textbox {
            get { return this.textEdit; }
            set { this.textEdit = (FTSTextBox) value; }
        }

        [Browsable(false)]
        public LabelControl Label {
            get { return this.label; }
        }

        public CharacterCasing CharacterCasing {
            get { return this.textEdit.Properties.CharacterCasing; }
            set { this.textEdit.Properties.CharacterCasing = value; }
        }

        public void SetTextLength(FieldInfo field) {
            this.textEdit.Properties.MaxLength = field.MaxLength;
        }

        public void SetTextLength(int length) {
            this.textEdit.Properties.MaxLength = length;
        }

        public void SetCase(bool isupper) {
            if (isupper) {
                this.textEdit.Properties.CharacterCasing = CharacterCasing.Upper;
            } else {
                this.textEdit.Properties.CharacterCasing = CharacterCasing.Lower;
            }
        }

        private void Textbox_Enter(object sender, EventArgs e) {
            this.mIsChanged = false;
        }

        private void Textbox_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.textEdit.EditValue.ToString().Trim() == string.Empty) {
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
            this.textEdit.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.textEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.textEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        /*
        protected override void OnCreateControl() {
            base.OnCreateControl();
            FTSForm frm = this.FindForm() as FTSForm;
            if (frm != null && frm.ShowTransparentControl) {
                this.textEdit.Properties.Appearance.BackColor = this.Parent.BackColor;
                this.textEdit.Properties.Appearance.Options.UseBackColor = true;
                this.textEdit.Properties.AppearanceDisabled.BackColor = this.Parent.BackColor;
                this.textEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
                this.textEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                this.textEdit.IsUnderline = true;
            } else {
                this.textEdit.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
                this.textEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
                this.textEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
                this.textEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            }
        }
        */ 

        public void EndEdit() {
            if (this.textEdit.DataBindings.Count > 0) {
                this.textEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
                    form.SetBalloonTooltip(this.textEdit, this.mHelpText);
                }
            }
        }
        public void Set(FTSMain ftsmain,DataTable datatable , string tablename)
        {
            string mask = ftsmain.IdManager.GetMask(datatable, tablename);
            if (mask != string.Empty)
            {
                this.textEdit.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
                this.textEdit.Properties.Mask.EditMask = mask;
                this.textEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
                this.textEdit.Properties.Mask.IgnoreMaskBlank = false;
                this.textEdit.Properties.ValidateOnEnterKey = true;
                this.textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            }
        }        
        #endregion
    }
}