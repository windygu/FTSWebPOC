#region

using System;
using System.Drawing;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmProgressBar : FTSForm {
        private Form frmParent;

        public FrmProgressBar() {
            this.InitializeComponent();
        }

        public FrmProgressBar(FTSMain ftsmain, Form mainfrm, string title, string msg) {
            this.frmParent = mainfrm;
            this.InitializeComponent();
            this.Text = title;
            this.lbl.Text = msg;
            if (ftsmain.Language == Language.JP || ftsmain.Language == Language.LAOS) {
                this.lbl.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            }
        }

        public void SetValue(int num) {
            this.bar.EditValue = num;
            this.Refresh();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.Left = this.frmParent.Left + ((int) (this.frmParent.Width - this.Width - 150)/2) + 150;
            this.Top = this.frmParent.Top + ((int) this.frmParent.Height/2);
        }
    }
}