#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;
using System.Collections.Generic;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSSingleComboCom : Panel, IRequire, IValid, IHelpField {
        public event ComboChangedEventHandler ComboChange;
        private bool mRequire = false;

        public FTSSingleComboCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.comboBox.BackColor = SystemColors.Info;
                } else {
                    this.comboBox.BackColor = Color.White;
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
        public ComboBoxEdit ComboBox {
            get { return this.comboBox; }
        }

        [Browsable(false)]
        public LabelControl Label {
            get { return this.label; }
        }

        public ItemCombobox SelectedItem {
            get {
                try {
                    return (ItemCombobox) this.comboBox.SelectedItem;
                } catch {
                }
                return null;
            }
        }

        public void Set(ArrayList oj) {
            foreach (object c in oj) {
                this.comboBox.Properties.Items.Add(c);
            }
        }

        public void Set(List<ItemCombobox> oj){
            foreach (object c in oj){
                this.comboBox.Properties.Items.Add(c);
            }
        }

        public void Set(DataTable dt, string displaymember, string valuemember) {
            foreach (DataRow row in dt.Rows) {
                this.comboBox.Properties.Items.Add(new ItemCombobox(row[valuemember].ToString().Trim(),
                                                                    row[displaymember].ToString().Trim()));
            }
        }

        protected virtual void OnComboChange(object sender, ComboChangedEventArgs e) {
            if (this.ComboChange != null) {
                this.ComboChange(this, e);
            }
        }

        private void ComboSelectedIndexChange(object sender, EventArgs e) {
            ItemCombobox item = null;
            try {
                item = (ItemCombobox) this.comboBox.SelectedItem;
            } catch {
            }
            this.OnComboChange(sender, new ComboChangedEventArgs(item));
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.comboBox.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.comboBox.Properties.AppearanceDisabled.BackColor = Color.White;
            this.comboBox.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.comboBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.comboBox.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.BackColor = Color.Transparent;
            this.label.BackColor = Color.Transparent;
        }

        public void EndEdit() {
            if (this.comboBox.DataBindings.Count > 0) {
                this.comboBox.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.comboBox.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        public void SetSelected(string value) {
            this.comboBox.SelectedIndex = this.GetIndex(value);
        }

        private int GetIndex(string value) {
            for (int i = 0; i < this.comboBox.Properties.Items.Count; i++) {
                if (((ObjectInfo) this.comboBox.Properties.Items[i]).ID == value) {
                    return i;
                }
            }
            return -1;
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
                    form.SetBalloonTooltip(this.comboBox, this.mHelpText);
                }
            }
        }

        #endregion
    }
}