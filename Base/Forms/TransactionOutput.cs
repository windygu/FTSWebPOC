#region

using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Threading;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public class TransactionOutput : XtraReport {
        private Container components = null;
        public string reportfilename;
        private ManagerBase managerbase;
        private DataTable datatable;
        private DataSet dataset;
        protected string thousandsymbol, decimalsymbol;
        protected string tablename;
        private FTSMain ftsMain;
        protected int numberBlank;
        public Hashtable FilterStringTables = null;
        public string mFilterString = string.Empty;
        private ReportPeriod mReportPeriod;
        private Hashtable mExPara;

        public TransactionOutput() {
            this.InitializeComponent();
        }

        public TransactionOutput(FTSMain ftsmain, ManagerBase mb, DataTable dt, string tablename, string filename,
                                 int numberblank) {
            this.mExPara = new Hashtable();
            this.ftsMain = ftsmain;
            this.managerbase = mb;
            this.reportfilename = filename;
            this.tablename = tablename;
            this.numberBlank = numberblank;
            this.datatable = dt;
            this.InitializeComponent();
            this.thousandsymbol = this.ftsMain.SystemVars.GetSystemVars("THOUSAND_SYMBOL").ToString().Trim();
            if (this.thousandsymbol == "") {
                this.thousandsymbol = " ";
            }
            this.decimalsymbol = this.ftsMain.SystemVars.GetSystemVars("DECIMAL_SYMBOL").ToString().Trim();
            if (this.decimalsymbol == "") {
                this.decimalsymbol = ",";
            }
            this.LoadLayout(this.reportfilename);
            this.TempPath = filename;
            CultureInfo mCultureInfo = new CultureInfo("vi-VN", true);
            mCultureInfo.NumberFormat.NumberGroupSeparator = thousandsymbol;
            mCultureInfo.NumberFormat.NumberDecimalSeparator = decimalsymbol;
            DateTimeFormatInfo d = new DateTimeFormatInfo();
            d.ShortDatePattern = "dd/MM/yyyy";
            mCultureInfo.DateTimeFormat = d;
            Thread.CurrentThread.CurrentCulture = mCultureInfo;
            FormatInfo.AlwaysUseThreadFormat = true;
        }

        public TransactionOutput(FTSMain ftsmain, ManagerBase mb, DataTable dt, string tablename, string filename,
                                 int numberblank, Hashtable expara)
        {
            this.mExPara = expara;
            this.ftsMain = ftsmain;
            this.managerbase = mb;
            this.reportfilename = filename;
            this.tablename = tablename;
            this.numberBlank = numberblank;
            this.datatable = dt;
            this.InitializeComponent();
            this.thousandsymbol = this.ftsMain.SystemVars.GetSystemVars("THOUSAND_SYMBOL").ToString().Trim();
            if (this.thousandsymbol == "")
            {
                this.thousandsymbol = " ";
            }
            this.decimalsymbol = this.ftsMain.SystemVars.GetSystemVars("DECIMAL_SYMBOL").ToString().Trim();
            if (this.decimalsymbol == "")
            {
                this.decimalsymbol = ",";
            }
            this.LoadLayout(this.reportfilename);
            this.TempPath = filename;
            CultureInfo mCultureInfo = new CultureInfo("vi-VN", true);
            mCultureInfo.NumberFormat.NumberGroupSeparator = thousandsymbol;
            mCultureInfo.NumberFormat.NumberDecimalSeparator = decimalsymbol;
            DateTimeFormatInfo d = new DateTimeFormatInfo();
            d.ShortDatePattern = "dd/MM/yyyy";
            mCultureInfo.DateTimeFormat = d;
            Thread.CurrentThread.CurrentCulture = mCultureInfo;
            FormatInfo.AlwaysUseThreadFormat = true;
        }

        public ReportPeriod ReportPeriod {
            get { return this.mReportPeriod; }
            set { this.mReportPeriod = value; }
        }

        public DataSet DataSet {
            get { return this.dataset; }
            set { this.dataset = value; }
        }

        public FTSMain FTSMain {
            get { return this.ftsMain; }
            set { this.ftsMain = value; }
        }

        public DataTable DataTable {
            get { return this.datatable; }
            set { this.datatable = value; }
        }

        public ManagerBase ManagerBase {
            get { return this.managerbase; }
            set { this.managerbase = value; }
        }

        public Hashtable ExPara
        {
            get { return this.mExPara; }
            set { this.mExPara = value; }
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ((System.ComponentModel.ISupportInitialize) (this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this)).EndInit();
        }

        #endregion

        protected virtual void SetParameter() {
            foreach (Band band in this.Bands) {
                foreach (XRControl ct in band.Controls) {
                    if ((ct is XRLabel) && (((XRLabel) ct).Parameter != "") && (((XRLabel) ct).Parameter != "(None)")) {
                        ct.Text = this.GetParameter(((XRLabel) ct).Parameter.ToUpper().Trim());
                    }
                    if (ct is XRTable) {
                        this.SetParameter((XRTable) ct);
                    }
                    if (ct is XRSubreport) {
                        this.SetSubReport((XRSubreport)ct);
                    }
                }
            }
        }

        private void SetParameter(XRTable control) {
            foreach (XRTableRow row in control.Rows) {
                foreach (XRTableCell cell in row.Cells) {
                    if (cell.Parameter.Trim() != string.Empty) {
                        cell.Text = this.GetParameter(cell.Parameter.ToUpper().Trim());
                    }
                }
            }
        }

        //protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e) {
        //    base.OnBeforePrint(e);
        //    this.SetParameter();
        //}

        public virtual void SetDataSource() {
            this.dataset = new DataSet();
            if (this.managerbase != null) {
                this.dataset.Tables.Add(this.managerbase.DataSet.Tables[this.tablename].Copy());
            } else {
                if (this.datatable != null) {
                    this.dataset.Tables.Add(this.datatable);
                }
            }
            this.DataSource = this.dataset;
            this.DataMember = this.tablename;
        }

        protected virtual string GetParameter(string parametername) {
            return "";
        }

        protected virtual string ConvertToString(object number) {
            return Functions.ConvertToString(number, this.decimalsymbol, this.thousandsymbol);
        }

        public virtual void RefreshTransactionOutput() {
            this.LoadLayout(this.reportfilename);
            /*
            if (this.managerbase != null) {
                this.RefreshDataSource();
            }
            */
            this.RefreshDataSource();
            this.SetParameter();
        }

        protected virtual void RefreshDataSource() {
            if (this.dataset != null) {
                this.dataset.Clear();
                if (this.dataset.Tables.IndexOf(this.tablename) >= 0) {
                    this.dataset.Tables.Remove(this.tablename);
                }
                if (this.managerbase != null) {
                    this.dataset.Tables.Add(this.managerbase.DataSet.Tables[this.tablename].Copy());
                } else {
                    if (this.datatable != null) {
                        this.dataset.Tables.Add(this.datatable);
                    }
                }
            }
            this.DataSource = this.dataset;
            this.DataMember = this.tablename;
        }

        public virtual void RunReport() {
        }
        public virtual void SetSubReport(XRSubreport subrpt) {
        }
    }
}