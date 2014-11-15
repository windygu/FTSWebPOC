#region

using System;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using ItemClickEventArgs = FTS.BaseUI.Controls.ItemClickEventArgs;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class ReportForm : FTSForm {
        private FTSMain mFTSMain;

        public ReportForm() {
            this.InitializeComponent();
        }

        public ReportForm(FTSMain ftsmain) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            this.toolbar.LoadLayout(this.mFTSMain);
            this.SetProductVersion();
        }

        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        public virtual void GoFirst() {
        }

        public virtual void GoPrevious() {
        }

        public virtual void GoNext() {
        }

        public virtual void GoLast() {
        }

        public virtual void GoToPage() {
        }

        public virtual void CloseView() {
        }

        public virtual void PrintReport() {
        }

        public virtual void ExportReport(string type) {
        }

        public virtual void ShowTreeView(bool enabled) {
        }

        public virtual void ZoomReport(int zoomLevel) {
        }

        public virtual void FindReport() {
        }

        public virtual void CloseReport() {
        }

        public virtual void DesignReport() {
        }

        public virtual void SaveReport() {
        }

        public virtual void PartReport(int partNumber) {
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            switch (e.Name) {
                case "First":
                    this.GoFirst();
                    break;
                case "Previous":
                    this.GoPrevious();
                    break;
                case "Next":
                    this.GoNext();
                    break;
                case "Last":
                    this.GoLast();
                    break;
                case "Print":
                    this.PrintReport();
                    break;
                case "Find":
                    this.FindReport();
                    break;
                case "Close":
                    this.Close();
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
                case "ToWord":
                    this.ExportReport("Word");
                    break;
                case "ToExcel":
                    this.ExportReport("Excel");
                    break;
                case "ToPdf":
                    this.ExportReport("Pdf");
                    break;
                default:
                    int part = 0;
                    try {
                        part = Convert.ToInt32(e.Name);
                    } catch (Exception) {
                    }
                    this.PartReport(part);
                    break;
            }
        }

        public virtual void RefreshReport() {
        }

        private void SetProductVersion() {
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.toolbar.GroupVisible = BarItemVisibility.Never;
                this.toolbar.TitleVisible = BarItemVisibility.Never;
                this.toolbar.ConfigVisible = BarItemVisibility.Never;
                this.toolbar.PageSetupVisible = BarItemVisibility.Never;
                this.toolbar.FilterVisible = BarItemVisibility.Never;
                this.toolbar.SaveVisible = BarItemVisibility.Never;
                this.toolbar.PartVisible = BarItemVisibility.Never;
                this.toolbar.ColumnsVisible = BarItemVisibility.Never;
                this.toolbar.SortVisible = BarItemVisibility.Never;
                this.toolbar.ViewVisible = BarItemVisibility.Never;
            }
        }
    }
}