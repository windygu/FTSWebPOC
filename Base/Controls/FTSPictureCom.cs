#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSPictureCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private Position mLabelPosition = Position.Left;

        public FTSPictureCom() {
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
            this.picture.Focus();
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
                    this.picture.BackColor = SystemColors.Info;
                } else {
                    this.picture.BackColor = Color.White;
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

        [DefaultValue(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        /*
        public override string Text
        {
            get { return picture.Text; }
            set { picture.Text = value; }
        }
        */

        [Browsable(false)]
        public PictureEdit Picture {
            get { return this.picture; }
            set { this.picture = value; }
        }

        private void picture_Enter(object sender, EventArgs e) {
            this.mIsChanged = false;
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void picture_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire) {
                if (this.picture.Image == null) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        private void SetProperty() {
            this.picture.Properties.NullText = " ";
        }

        public void EndEdit() {
            if (this.picture.DataBindings.Count > 0) {
                this.picture.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
                    form.SetBalloonTooltip(this.picture, this.mHelpText);
                }
            }
        }

        #endregion
    }
}