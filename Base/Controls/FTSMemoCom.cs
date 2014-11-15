#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public enum Position {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3
    }

    public partial class FTSMemoCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private Position mLabelPosition = Position.Left;

        public FTSMemoCom() {
            this.InitializeComponent();
            this.mLabelPosition = Position.Left;
            this.SetProperty();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (msg.WParam.ToInt32()) {
                case (int) Keys.Down:
                case (int) Keys.Enter:
                    SendKeys.Send("{Tab}");
                    return true;
                case (int) Keys.Up:
                    SendKeys.Send("+{Tab}");
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnGotFocus(EventArgs e) {
            this.memo.Focus();
        }

        [DefaultValue(Position.Left)]
        public Position LabelPosition {
            get { return this.mLabelPosition; }
            set {
                this.mLabelPosition = value;
                if (this.mLabelPosition == Position.Left) {
                    this.palLable.Dock = DockStyle.Left;
                    this.palLable.Height = this.Height;
                    this.label.Appearance.TextOptions.HAlignment = HorzAlignment.Default;
                    this.label.Appearance.TextOptions.VAlignment = VertAlignment.Default;
                } else if (this.mLabelPosition == Position.Top) {
                    this.palLable.Dock = DockStyle.Top;
                    this.palLable.Height = 20;
                    this.label.Appearance.TextOptions.HAlignment = HorzAlignment.Default;
                    this.label.Appearance.TextOptions.VAlignment = VertAlignment.Default;
                } else if (this.mLabelPosition == Position.Right) {
                    this.palLable.Dock = DockStyle.Right;
                    this.palLable.Height = this.Height;
                    this.label.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    this.label.Appearance.TextOptions.VAlignment = VertAlignment.Default;
                } else {
                    this.palLable.Dock = DockStyle.Bottom;
                    this.palLable.Height = 20;
                    this.label.Appearance.TextOptions.HAlignment = HorzAlignment.Default;
                    this.label.Appearance.TextOptions.VAlignment = VertAlignment.Bottom;
                }
            }
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.memo.BackColor = SystemColors.Info;
                } else {
                    this.memo.BackColor = Color.White;
                }
            }
        }

        [DefaultValue(80)]
        public int LabelLength {
            get { return this.palLable.Width; }
            set { this.palLable.Width = value; }
        }

        public string LabelText {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public override string Text
        {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [DefaultValue(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        /*
        public override string Text
        {
            get { return memo.Text; }
            set { memo.Text = value; }
        }
        */

        [Browsable(false)]
        public MemoEdit Memo {
            get { return this.memo; }
            set { this.memo = value; }
        }

        public CharacterCasing CharacterCasing {
            get { return this.memo.Properties.CharacterCasing; }
            set { this.memo.Properties.CharacterCasing = value; }
        }

        public void SetTextLength(FieldInfo field) {
            this.memo.Properties.MaxLength = field.MaxLength;
        }

        public void SetTextLength(int length) {
            this.memo.Properties.MaxLength = length;
        }

        public void SetCase(bool isupper) {
            if (isupper) {
                this.memo.Properties.CharacterCasing = CharacterCasing.Upper;
            } else {
                this.memo.Properties.CharacterCasing = CharacterCasing.Lower;
            }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void memo_Enter(object sender, EventArgs e) {
            this.mIsChanged = false;
        }

        private void memo_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire) {
                if (this.memo.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        private void SetProperty() {
            this.memo.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.memo.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.memo.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.memo.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        public void EndEdit() {
            if (this.memo.DataBindings.Count > 0) {
                this.memo.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
                    form.SetBalloonTooltip(this.memo, this.mHelpText);
                }
            }
        }

        #endregion
    }
}