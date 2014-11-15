#region

using System;
using System.Collections;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmGetCustomPeriod : FrmBaseForm {
        private DateTime mDayStart;
        private DateTime mDayEnd;

        public FrmGetCustomPeriod() {
            this.InitializeComponent();
        }

        public FrmGetCustomPeriod(FTSMain ftsmain) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            this.txtDay_Start.DateTime.EditValue = DateTime.Today.Date;
            this.txtDayEnd.DateTime.EditValue = DateTime.Today.Date;

        }

        public DateTime DayStart {
            get { return this.mDayStart; }
            set { this.mDayStart = value; }
        }

        public DateTime DayEnd {
            get { return this.mDayEnd; }
            set { this.mDayEnd = value; }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DayStart = (DateTime) this.txtDay_Start.DateTime.EditValue;
            this.DayEnd = (DateTime)this.txtDayEnd.DateTime.EditValue;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}