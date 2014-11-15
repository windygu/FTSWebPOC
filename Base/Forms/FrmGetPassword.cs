#region

using System;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmGetPassword : FTSForm {
        private string mRetVal = string.Empty;

        public FrmGetPassword() {
            this.InitializeComponent();
            this.txtPassword.Textbox.Properties.PasswordChar = '*';
        }

        public string RetVal {
            get { return this.mRetVal; }
            set { this.mRetVal = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.mRetVal = this.txtPassword.Textbox.EditValue.ToString();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}