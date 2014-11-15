using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Drawing;

namespace FTS.BaseUI.Forms
{
    public class FrmTranPrintDirect
    {
        private XtraReport mReport = null;
        private string mPrintName = string.Empty;
        private FTSMain mFtsMain = null;        

        public FrmTranPrintDirect(FTSMain ftsmain,XtraReport rpt, string printname)
        {
            this.mFtsMain = ftsmain;
            this.mReport = rpt;
            this.mPrintName = printname;            
            this.LoadReport();
            this.mReport.PrintingSystem.ExecCommand(PrintingSystemCommand.PrintDirect);
        }
        public FrmTranPrintDirect(FTSMain ftsmain, XtraReport rpt, string printname, int copies)
        {
            this.mFtsMain = ftsmain;
            this.mReport = rpt;
            this.mPrintName = printname;            
            this.LoadReport();
            for (int i = 1; i <= copies; i++)
            {
                if ((copies > 1) && (System.Convert.ToBoolean(this.mFtsMain.SystemVars.GetSystemVars("POS_USE_WATERMARK"))))
                {
                    this.mReport.PrintingSystem.Watermark.Text = "Liên " + i.ToString();
                    this.mReport.PrintingSystem.Watermark.PageRange = "1";
                    this.mReport.PrintingSystem.Watermark.TextTransparency = 180;
                }
                this.mReport.PrintingSystem.ExecCommand(PrintingSystemCommand.PrintDirect);
            }
        }
        public FrmTranPrintDirect(FTSMain ftsmain, XtraReport rpt, string printname, int copies, string direct)
        {
            this.mFtsMain = ftsmain;
            this.mReport = rpt;
            this.mPrintName = printname;
            this.LoadReport();            
            for (int i = 1; i <= copies; i++)
            {
                if ((copies > 1) && (System.Convert.ToBoolean(this.mFtsMain.SystemVars.GetSystemVars("USE_WATERMARK"))))
                {
                    this.mReport.PrintingSystem.Watermark.Text = "Liên " + i.ToString();
                    this.mReport.PrintingSystem.Watermark.PageRange = "1";
                    this.mReport.PrintingSystem.Watermark.TextTransparency = 180;
                }
                this.mReport.PrintingSystem.ExecCommand(PrintingSystemCommand.PrintDirect);
            }            
        }        
        
        private void LoadReport()
        {                           
            this.mReport.PrintingSystem.ShowMarginsWarning = false;                            
            this.mReport.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
            this.mReport.CreateDocument();                            
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            try
            {                
                e.PrintDocument.PrinterSettings.PrinterName = this.mPrintName;
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFtsMain,ex);
            }
        }
    }
}
