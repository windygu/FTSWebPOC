#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSNumericCom2 : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private bool mNoChangeEvent = false;
        private CultureInfo mFTSCultureInfo;
        private bool mTextFocused = false;
        public event EventHandler NumericValueChanged;
        private decimal mNumericValue = 0;

        public FTSNumericCom2() {
            this.InitializeComponent();
            this.SetProperty();
        }

        public CultureInfo FtsCultureInfo {
            get { return this.mFTSCultureInfo; }
            set { this.mFTSCultureInfo = value; }
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
            set { this.textNumeric = value; }
        }

        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.textNumeric.Properties.AppearanceDisabled.BackColor = Color.WhiteSmoke;
            this.textNumeric.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textNumeric.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textNumeric.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.textNumeric.Properties.KeyPress += new KeyPressEventHandler(this.NumericTextBox_KeyPress);
            this.textNumeric.Properties.EditValueChanged += new EventHandler(this.NumericTextBox_EditValueChanged);
            this.textNumeric.Properties.Spin += new SpinEventHandler(this.DisableMouseWheel);
            this.textNumeric.Properties.EditValueChanging +=
                new ChangingEventHandler(this.NumericTextBox_EditValueChanging);
        }

        private void NumericTextBox_EditValueChanging(object sender, ChangingEventArgs e) {
            try {
                if (e.NewValue != null) {
                    string text = e.NewValue.ToString().Trim();
                    if ((text != string.Empty) && (text.Length >= 2)) {
                        while (text.StartsWith("0") && (text[1] != this.DecimalSeperator.ToCharArray()[0])) {
                            text = text.Substring(1, text.Length - 1);
                            if (text.Length < 2) {
                                break;
                            }
                        }
                        string newtext = text.Replace(this.GroupSeperator, "");
                        string number = Functions.ConvertToString2(newtext, this.FtsCultureInfo);
                        e.NewValue = text;
                    }
                } else {
                    e.Cancel = true;
                }
            } catch {
                e.Cancel = true;
            }
        }

        private void DisableMouseWheel(object sender, SpinEventArgs e) {
            e.Handled = true;
        }

        public void EndEdit() {
            if (this.textNumeric.DataBindings.Count > 0) {
                this.textNumeric.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        protected override void OnGotFocus(EventArgs e) {
            this.textNumeric.Focus();
        }

        protected override void OnEnter(EventArgs e) {
            this.mIsChanged = false;
        }

        private void NumericTextBox_EditValueChanged(object sender, EventArgs e) {
            if (this.mNoChangeEvent || (this.textNumeric.SelectionStart == -1)) {
                return;
            }
            this.mNoChangeEvent = true;
            int start = this.textNumeric.SelectionStart;
            string sub = this.textNumeric.Text.Substring(0, start);
            sub = sub.Replace(this.GroupSeperator, "");
            bool flag = false;
            string text = this.textNumeric.Text.Replace(this.GroupSeperator, "");
            if (text.IndexOf(this.DecimalSeperator.ToCharArray()[0]) == 0) {
                text = "0" + text;
            }
            if (text == string.Empty || text == "0") {
                this.textNumeric.Text = "0";
                this.textNumeric.Refresh();
                this.textNumeric.SelectionStart = 1;
            } else if ((text.Length == 2) && (text.StartsWith("0")) && (text.IndexOf(".") < 0)) {
                this.textNumeric.Text = text.Substring(1, 1);
                this.textNumeric.Refresh();
                this.textNumeric.SelectionStart = 1;
            } else {
                if (text.EndsWith(this.DecimalSeperator)) {
                    text = text.Substring(0, text.Length - 1);
                    flag = true;
                }
                string number = Functions.ConvertToString2(text, this.FtsCultureInfo);
                this.textNumeric.Text = (number == string.Empty ? "0" : number) +
                                        (flag ? this.DecimalSeperator : string.Empty);
                this.textNumeric.Refresh();
                int i = 0, j = 0;
                while (i < sub.Length) {
                    string num = this.textNumeric.Text.Substring(j, 1);
                    if (num != this.GroupSeperator) {
                        i++;
                    }
                    j++;
                }
                this.textNumeric.SelectionStart = j;
            }
            this.mNoChangeEvent = false;
            this.mNumericValue = Convert.ToDecimal(this.textNumeric.Text.Replace(this.GroupSeperator, ""));
            this.mIsChanged = true;
            if (this.NumericValueChanged != null) {
                this.NumericValueChanged(this, e);
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

        private string DecimalSeperator {
            get { return this.mFTSCultureInfo.NumberFormat.NumberDecimalSeparator; }
        }

        private string GroupSeperator {
            get { return this.mFTSCultureInfo.NumberFormat.NumberGroupSeparator; }
        }

        [Bindable(true), Category("Internal settings")]
        public decimal NumericValue {
            get { return this.mNumericValue; }
            set {
                if (value.Equals(DBNull.Value)) {
                    if (value.Equals(0)) {
                        this.textNumeric.Text = Convert.ToString(0);
                        this.mNumericValue = Convert.ToDecimal(0);
                        this.NumericValueChanged(this, new EventArgs());
                        return;
                    }
                }
                if (!value.Equals(this.mNumericValue)) {
                    string text = Convert.ToString(value);
                    if (text.IndexOf(this.DecimalSeperator.ToCharArray()[0]) > 0) {
                        text = text.Replace("0", " ").TrimEnd().Replace(" ", "0");
                    }
                    this.textNumeric.Text = text;
                    this.mNumericValue = value;
                    this.NumericValueChanged(this, new EventArgs());
                }
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\b') {
                return;
            }
            string ls_AllowedKeyChars = "1234567890" + this.DecimalSeperator;
            if (ls_AllowedKeyChars.IndexOf(e.KeyChar) < 0) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar.Equals(this.DecimalSeperator.ToCharArray()[0])) {
                string text = this.textNumeric.Text;
                if (text == string.Empty) {
                    e.Handled = true;
                    return;
                } else if (text.IndexOf(this.DecimalSeperator) > 0) {
                    string[] temp = text.Split(this.DecimalSeperator.ToCharArray()[0]);
                    this.textNumeric.SelectionStart = temp[0].Length + 1;
                    e.Handled = true;
                    return;
                } else if (text.IndexOf(this.DecimalSeperator) < 0) {
                    text = text + this.DecimalSeperator;
                    this.textNumeric.Text = text;
                    this.textNumeric.SelectionStart = text.Length;
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}