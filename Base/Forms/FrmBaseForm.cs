#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmBaseForm : FTSForm {
        private FTSMain mFTSMain;

        public FrmBaseForm() {
            this.InitializeComponent();
        }

        public FrmBaseForm(FTSMain ftsmain, bool dialog) {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();
            if (!dialog) {
                this.MdiParent = FTS.BaseUI.Forms.FTSMainForm.ApplicationMainWindow;
            }
        }
        public FrmBaseForm(FTSMain ftsmain)
        {
            this.mFTSMain = ftsmain;
            this.InitializeComponent();           
        }
        public FTSMain FTSMain {
            get { return this.mFTSMain; }
            set { this.mFTSMain = value; }
        }

        protected override void OnClosing(CancelEventArgs e) {
            try {
                if (this.WindowState != FormWindowState.Normal) {
                    this.WindowState = FormWindowState.Normal;
                }
                this.SaveLayout(this.mFTSMain);
                this.DestroyCustomization();
            } catch (Exception) {
            }
        }

        public virtual void OnError(FTSException ex) {
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            try {
                switch (keyData) {
                    case Keys.Control | Keys.F4:
                        this.Close();
                        break;
                    case Keys.F1:
                        this.ShowHelp();
                        break;
                    case Keys.F12:
                        if (this.mFTSMain.UserInfo.UserGroupID == "ADMIN")                        
                            this.FormCustomization(new Point(-10000, -10000), this.mFTSMain);
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
            return base.ProcessDialogKey(keyData);
        }

        public void LoadLayout() {
            this.LoadLayout(this.mFTSMain);
        }

        /*
        protected override bool GetAllowSkin()
        {
            if (this.MdiParent != null)
            {
                return true;
            }
            else
            {
                return true;
                //return base.GetAllowSkin();
            }
        }
        */ 
    }
}