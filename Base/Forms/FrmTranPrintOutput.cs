#region

using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using ItemClickEventArgs = FTS.BaseUI.Controls.ItemClickEventArgs;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmTranPrintOutput : FrmBaseForm {
        private XtraReport mReport = null;
        private int mCopies = 1;

        public FrmTranPrintOutput() {
            this.InitializeComponent();
        }

        public FrmTranPrintOutput(FTSMain ftsMain, XtraReport rpt, bool printdirect, int copies) : base(ftsMain, true) {
            this.mCopies = copies;
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            this.mReport = rpt;
            this.LoadReport();
            if (printdirect) {
                this.reportViewer.PrintingSystem.StartPrint +=
                    new PrintDocumentEventHandler(this.PrintingSystem_StartPrint);
                this.reportViewer.PrintingSystem.ExecCommand(PrintingSystemCommand.PrintDirect);
            }
            this.toolbar.LoadLayout(this.FTSMain);
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e) {
            e.PrintDocument.PrinterSettings.Copies = Convert.ToInt16(this.mCopies);
        }

        public FrmTranPrintOutput(FTSMain ftsMain, TransactionOutput rpt) : base(ftsMain, false) {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            this.mReport = (XtraReport) rpt;
            this.LoadReport();
            this.toolbar.LoadLayout(this.FTSMain);
            this.toolbar.FirstVisible = BarItemVisibility.Always;
            this.toolbar.LastVisible = BarItemVisibility.Always;
            this.toolbar.NextVisible = BarItemVisibility.Always;
            this.toolbar.PreviousVisible = BarItemVisibility.Always;
        }
        public FrmTranPrintOutput(FTSMain ftsMain, TransactionOutput rpt,bool isdlg)
            : base(ftsMain, isdlg)
        {
            this.InitializeComponent();
            this.LoadLayout(this.FTSMain);
            this.mReport = (XtraReport)rpt;
            this.LoadReport();
            this.toolbar.LoadLayout(this.FTSMain);
            this.toolbar.FirstVisible = BarItemVisibility.Always;
            this.toolbar.LastVisible = BarItemVisibility.Always;
            this.toolbar.NextVisible = BarItemVisibility.Always;
            this.toolbar.PreviousVisible = BarItemVisibility.Always;
        }
        private void LoadReport() {
            this.reportViewer.PrintingSystem = this.mReport.PrintingSystem;
            this.mReport.CreateDocument();
            this.reportViewer.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "First":
                        this.GoFirst();
                        break;
                    case "Last":
                        this.GoLast();
                        break;
                    case "Previous":
                        this.GoPrevious();
                        break;
                    case "Next":
                        this.GoNext();
                        break;
                    case "Design":
                        this.Design();
                        break;
                    case "Print":
                        this.PrintTransaction();
                        break;
                    case "Email":
                        this.Email();
                        break;
                    case "Close":
                        this.Close();
                        break;
                    case "Refresh":
                        this.RefreshReport();
                        break;
                    case "PageWidth":
                        this.ZoomReport(1);
                        break;
                    case "WholePage":
                        this.ZoomReport(2);
                        break;
                    case "150":
                        this.ZoomReport(150);
                        break;
                    case "300":
                        this.ZoomReport(300);
                        break;
                    case "200":
                        this.ZoomReport(200);
                        break;
                    case "100":
                        this.ZoomReport(100);
                        break;
                    case "75":
                        this.ZoomReport(75);
                        break;
                    case "50":
                        this.ZoomReport(50);
                        break;
                    case "25":
                        this.ZoomReport(25);
                        break;
                    case "ToExcel":
                        this.ExportReport("Excel");
                        break;
                    case "ToWord":
                        this.ExportReport("Word");
                        break;
                    case "ToHtml":
                        this.ExportReport("Html");
                        break;
                    case "ToPdf":
                        this.ExportReport("Pdf");
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        public void GoFirst() {
            this.reportViewer.SelectFirstPage();
        }

        public void GoPrevious() {
            this.reportViewer.SelectPrevPage();
        }

        public void GoNext() {
            this.reportViewer.SelectNextPage();
        }

        public void GoLast() {
            this.reportViewer.SelectLastPage();
        }

        public void ZoomReport(int zoomLevel) {
            if (zoomLevel == 1) {
                this.reportViewer.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            } else {
                if (zoomLevel == 2) {
                    this.reportViewer.ExecCommand(PrintingSystemCommand.ViewWholePage);
                } else {
                    this.reportViewer.Zoom = (float) zoomLevel/100;
                }
            }
        }

        public void PrintTransaction() {
            try {
                this.reportViewer.PrintingSystem.ExecCommand(PrintingSystemCommand.Print);
            } catch (Exception e) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, e);
            }
        }

        public void Email() {
            this.ExportReport("Pdf");
        }

        public void Design() {
            DevExpress.XtraReports.UserDesigner.XRDesignForm designform = new DevExpress.XtraReports.UserDesigner.XRDesignForm();
            designform.OpenReport(this.mReport);
            designform.Show();
            /*
            this.mReport.ShowDesigner();
            */ 
        }

        public void RefreshReport() {
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            ((TransactionOutput) this.mReport).RefreshTransactionOutput();
            this.mReport.CreateDocument();
            Cursor.Current = current;
        }

        public void ExportReport(string exporttype) {
            switch (exporttype) {
                case "Excel":
                    this.reportViewer.ExecCommand(PrintingSystemCommand.ExportXls);
                    break;
                case "Pdf":
                    this.reportViewer.ExecCommand(PrintingSystemCommand.ExportPdf);
                    break;
                case "Word":
                    this.reportViewer.ExecCommand(PrintingSystemCommand.ExportRtf);
                    break;
                case "Html":
                    this.reportViewer.ExecCommand(PrintingSystemCommand.ExportHtm);
                    break;
                default:
                    break;
            }
        }
    }
}