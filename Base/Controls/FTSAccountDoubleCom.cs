#region

using System;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSAccountDoubleCom : XtraUserControl {
        private DataTable mTableAcc;
        private FTSMain mFTSMain;
        private string mNameField = string.Empty;
        private string mOldDebt = string.Empty;
        private string mOldCredit = string.Empty;

        public FTSAccountDoubleCom() {
            this.InitializeComponent();
        }

        public void Set(FTSMain ftsMain, DataTable tableAcc) {
            this.mFTSMain = ftsMain;
            this.mTableAcc = tableAcc;
            this.mNameField = this.mFTSMain.TableManager.GetNameField("DM_TK");
        }

        public string TextGroup {
            get { return this.grpAccount.Text; }
            set { this.grpAccount.Text = value; }
        }

        [Browsable(false)]
        public string Debt {
            get { return this.DebtId.Text; }
            set { this.DebtId.Text = value; }
        }

        [Browsable(false)]
        public string Credit {
            get { return this.CreditId.Text; }
            set { this.CreditId.Text = value; }
        }

        private void CreditId_TextChanged(object sender, EventArgs e) {
            try {
                if (this.CreditId.Text != this.mOldCredit) {
                    DataRow foundrow = this.mTableAcc.Rows.Find(this.CreditId.Text);
                    if (foundrow != null) {
                        this.txtCredit.Text = foundrow[this.mNameField].ToString();
                    } else {
                        this.txtCredit.Text = string.Empty;
                    }
                }
            } catch (Exception) {
                this.txtCredit.Text = string.Empty;
            }
            this.mOldCredit = this.CreditId.Text;
        }

        private void DebtId_TextChanged(object sender, EventArgs e) {
            try {
                if (this.DebtId.Text != this.mOldDebt) {
                    DataRow foundrow = this.mTableAcc.Rows.Find(this.DebtId.Text);
                    if (foundrow != null) {
                        this.txtDebt.Text = foundrow[this.mNameField].ToString();
                    } else {
                        this.txtDebt.Text = string.Empty;
                    }
                }
            } catch (Exception) {
                this.txtDebt.Text = string.Empty;
            }
            this.mOldDebt = this.DebtId.Text;
        }
    }
}