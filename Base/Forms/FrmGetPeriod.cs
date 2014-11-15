#region

using System;
using System.Collections;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmGetPeriod : FrmBaseForm {
        private ReportPeriod mPeriod;

        public FrmGetPeriod() {
            this.InitializeComponent();
        }

        public FrmGetPeriod(FTSMain ftsmain) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            ArrayList ar = ReportPeriod.LoadReportPeriod(this.FTSMain, false);
            this.cboPeriod.Set(ar);
            this.cboPeriod.ComboBox.SelectedIndex = 0;
        }

        public FrmGetPeriod(FTSMain ftsmain, bool bymonth) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            if (bymonth) {
                ArrayList ar = ReportPeriod.LoadReportPeriodByMonth(this.FTSMain);
                this.cboPeriod.Set(ar);
                this.cboPeriod.ComboBox.SelectedIndex = 0;
            } else {
                ArrayList ar = ReportPeriod.LoadReportPeriod(this.FTSMain, false);
                this.cboPeriod.Set(ar);
                this.cboPeriod.ComboBox.SelectedIndex = 0;
            }
        }

        public FrmGetPeriod(FTSMain ftsmain, ArrayList ar) : base(ftsmain, true) {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            this.cboPeriod.Set(ar);
            this.cboPeriod.ComboBox.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.mPeriod = (ReportPeriod) this.cboPeriod.ComboBox.SelectedItem;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public ReportPeriod Period {
            get { return this.mPeriod; }
            set { this.mPeriod = value; }
        }
    }
}