#region

using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Layout;
using FTS.BaseUI.Security;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FTSLanguageToolbar : UserControl {
        public event ItemClickEventHandler ItemClick;

        public FTSLanguageToolbar() {
            this.InitializeComponent();
            FlowLayout layout = new FlowLayout();
            layout.ContainerControl = this;
            layout.TopMargin = 2;
            layout.BottomMargin = 2;
            layout.HorzNearMargin = 2;

            layout.VGap = 2;
            layout.HGap = 2;
            layout.AutoLayout = true;
            layout.Alignment = FlowAlignment.Near;
        }

        private string mSelectedLanguage = Language.VN;

        public void SetVisible(string language, bool isvisible) {
            if (language == Language.JP) {
                this.cmdJP.Visible = isvisible;
            }
            if (language == Language.KR) {
                this.cmdKR.Visible = isvisible;
            }
            if (language == Language.LAOS) {
                this.cmdLaos.Visible = isvisible;
            }
            if (language == Language.EN) {
                this.cmdEN.Visible = isvisible;
            }
            if (language == Language.VN) {
                this.cmdVN.Visible = isvisible;
            }
        }
        public string SelectedLanguage {
            get { return this.mSelectedLanguage; }
            set {
                this.mSelectedLanguage = value;
                if (this.mSelectedLanguage == Language.VN) {
                    this.cmdVN.Enabled = false;
                    this.cmdEN.Enabled = true;
                    this.cmdJP.Enabled = true;
                    this.cmdKR.Enabled = true;
                    this.cmdLaos.Enabled = true;
                } else {
                    if (this.mSelectedLanguage == Language.EN) {
                        this.cmdVN.Enabled = true;
                        this.cmdEN.Enabled = false;
                        this.cmdJP.Enabled = true;
                        this.cmdKR.Enabled = true;
                        this.cmdLaos.Enabled = true;
                    } else {
                        if (this.mSelectedLanguage == Language.JP) {
                            this.cmdVN.Enabled = true;
                            this.cmdEN.Enabled = true;
                            this.cmdJP.Enabled = false;
                            this.cmdKR.Enabled = true;
                            this.cmdLaos.Enabled = true;
                        } else {
                            if (this.mSelectedLanguage == Language.KR) {
                                this.cmdVN.Enabled = true;
                                this.cmdEN.Enabled = true;
                                this.cmdJP.Enabled = true;
                                this.cmdKR.Enabled = false;
                                this.cmdLaos.Enabled = true;
                            }else{
                                this.cmdVN.Enabled = true;
                                this.cmdEN.Enabled = true;
                                this.cmdJP.Enabled = true;
                                this.cmdKR.Enabled = true;
                                this.cmdLaos.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void Language_Click(object sender, EventArgs e) {
            SimpleButton btn = (SimpleButton) sender;
            switch (btn.Name) {
                case "cmdVN":
                    this.cmdVN.Enabled = false;
                    this.cmdEN.Enabled = true;
                    this.cmdJP.Enabled = true;
                    this.cmdKR.Enabled = true;
                    this.cmdLaos.Enabled = true;
                    this.mSelectedLanguage = Language.VN;
                    break;
                case "cmdEN":
                    this.cmdVN.Enabled = true;
                    this.cmdEN.Enabled = false;
                    this.cmdJP.Enabled = true;
                    this.cmdKR.Enabled = true;
                    this.cmdLaos.Enabled = true;
                    this.mSelectedLanguage = Language.EN;
                    break;
                case "cmdJP":
                    this.cmdVN.Enabled = true;
                    this.cmdEN.Enabled = true;
                    this.cmdJP.Enabled = false;
                    this.cmdKR.Enabled = true;
                    this.cmdLaos.Enabled = true;
                    this.mSelectedLanguage = Language.JP;
                    break;
                case "cmdKR":
                    this.cmdVN.Enabled = true;
                    this.cmdEN.Enabled = true;
                    this.cmdJP.Enabled = true;
                    this.cmdKR.Enabled = false;
                    this.cmdLaos.Enabled = true;
                    this.mSelectedLanguage = Language.KR;
                    break;
                case "cmdLaos":
                    this.cmdVN.Enabled = true;
                    this.cmdEN.Enabled = true;
                    this.cmdJP.Enabled = true;
                    this.cmdKR.Enabled = true;
                    this.cmdLaos.Enabled = false;
                    this.mSelectedLanguage = Language.LAOS;
                    break;
            }
            ((FrmLogin) this.FindForm()).SetLanguage(this.SelectedLanguage);
        }
    }
}