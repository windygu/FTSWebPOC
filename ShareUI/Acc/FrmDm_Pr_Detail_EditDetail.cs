#region

using System;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraBars;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.ShareUI.Acc {
    public sealed class FrmDm_Pr_Detail_EditDetail : FrmDataEditDetail {
        private IContainer components;
        private FTSTextCom txtPr_Detail_Id;
        private FTSCheckCom chkActive;
        private FTSTextCom txtPr_Detail_Name;
        private FTSTextCom txtTax_File_Number;
        private FTSGroupBox groupGeneral;
        private FTSTextCom txtPhone;
        private FTSCheckCom chkIs_Public;
        private FTSTextCom txtAddress;
        

        public FrmDm_Pr_Detail_EditDetail() {
            InitializeComponent();
        }

        public FrmDm_Pr_Detail_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id, string condition) : base(ftsmain, SaveandClose, condition) {
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            this.FocusControl = this.txtPr_Detail_Id;
            if (this.FlagNew) {
                this.NewRecord();
            } else {
                this.DataObject.LoadDataByID(this.IdValue);
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtTax_File_Number = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPr_Detail_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtPr_Detail_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.groupGeneral = new FTS.BaseUI.Controls.FTSGroupBox();
            this.txtAddress = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPhone = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkIs_Public = new FTS.BaseUI.Controls.FTSCheckCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGeneral)).BeginInit();
            this.groupGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(532, 24);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Controls.Add(this.groupGeneral);
            this.palMain.Location = new System.Drawing.Point(0, 24);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(532, 175);
            this.palMain.TabIndex = 1;
            // 
            // txtTax_File_Number
            // 
            this.txtTax_File_Number.BackColor = System.Drawing.Color.Transparent;
            this.txtTax_File_Number.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTax_File_Number.HelpText = "";
            this.txtTax_File_Number.LabelLength = 100;
            this.txtTax_File_Number.LabelText = "Mã số thuế:";
            this.txtTax_File_Number.Location = new System.Drawing.Point(6, 106);
            this.txtTax_File_Number.Name = "txtTax_File_Number";
            this.txtTax_File_Number.Size = new System.Drawing.Size(264, 20);
            this.txtTax_File_Number.TabIndex = 0;
            this.txtTax_File_Number.Text = "Mã số thuế:";
            // 
            // txtPr_Detail_Name
            // 
            this.txtPr_Detail_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtPr_Detail_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPr_Detail_Name.HelpText = "";
            this.txtPr_Detail_Name.LabelLength = 100;
            this.txtPr_Detail_Name.LabelText = "Tên đối tượng:";
            this.txtPr_Detail_Name.Location = new System.Drawing.Point(6, 54);
            this.txtPr_Detail_Name.Name = "txtPr_Detail_Name";
            this.txtPr_Detail_Name.Size = new System.Drawing.Size(497, 20);
            this.txtPr_Detail_Name.TabIndex = 3;
            this.txtPr_Detail_Name.Text = "Tên đối tượng:";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 38;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(453, 28);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(58, 20);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "Active";
            // 
            // txtPr_Detail_Id
            // 
            this.txtPr_Detail_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtPr_Detail_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPr_Detail_Id.HelpText = "";
            this.txtPr_Detail_Id.LabelLength = 100;
            this.txtPr_Detail_Id.LabelText = "Mã đối tượng:";
            this.txtPr_Detail_Id.Location = new System.Drawing.Point(6, 28);
            this.txtPr_Detail_Id.Name = "txtPr_Detail_Id";
            this.txtPr_Detail_Id.Size = new System.Drawing.Size(219, 20);
            this.txtPr_Detail_Id.TabIndex = 0;
            this.txtPr_Detail_Id.Text = "Mã đối tượng:";
            // 
            // groupGeneral
            // 
            this.groupGeneral.Controls.Add(this.txtPr_Detail_Id);
            this.groupGeneral.Controls.Add(this.chkIs_Public);
            this.groupGeneral.Controls.Add(this.chkActive);
            this.groupGeneral.Controls.Add(this.txtPr_Detail_Name);
            this.groupGeneral.Controls.Add(this.txtAddress);
            this.groupGeneral.Controls.Add(this.txtPhone);
            this.groupGeneral.Controls.Add(this.txtTax_File_Number);
            this.groupGeneral.Location = new System.Drawing.Point(11, 6);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Size = new System.Drawing.Size(515, 164);
            this.groupGeneral.TabIndex = 19;
            this.groupGeneral.Text = "Thông tin chung";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAddress.HelpText = "";
            this.txtAddress.LabelLength = 100;
            this.txtAddress.LabelText = "Địa chỉ:";
            this.txtAddress.Location = new System.Drawing.Point(5, 80);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(498, 20);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPhone.HelpText = "";
            this.txtPhone.LabelLength = 100;
            this.txtPhone.LabelText = "Số điện thoại:";
            this.txtPhone.Location = new System.Drawing.Point(276, 106);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(227, 20);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.Text = "Số điện thoại:";
            // 
            // chkIs_Public
            // 
            this.chkIs_Public.BackColor = System.Drawing.Color.Transparent;
            this.chkIs_Public.HelpText = "";
            this.chkIs_Public.LabelLenght = 74;
            this.chkIs_Public.LabelText = "Mã dùng chung";
            this.chkIs_Public.Location = new System.Drawing.Point(336, 28);
            this.chkIs_Public.Name = "chkIs_Public";
            this.chkIs_Public.Size = new System.Drawing.Size(94, 20);
            this.chkIs_Public.TabIndex = 9;
            this.chkIs_Public.Text = "Mã dùng chung";
            // 
            // FrmDm_Pr_Detail_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(532, 199);
            this.Name = "FrmDm_Pr_Detail_EditDetail";
            this.Text = "FrmDm_Pr_Detail_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGeneral)).EndInit();
            this.groupGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public override void BinControls() {
            this.txtPr_Detail_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".PR_DETAIL_ID");
            this.txtPr_Detail_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".PR_DETAIL_NAME");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".ACTIVE");

            this.txtAddress.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".ADDRESS");
            this.txtPhone.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".PHONE");
            this.txtTax_File_Number.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".TAX_FILE_NUMBER");

        }

        public override void LoadData() {
            this.DataObject = new Dm_Pr_Detail(this.FTSMain, true);
        }

        public override void SetControls() {
            //set upper case
            this.txtPr_Detail_Id.SetCase(true);
            //set length
            this.txtPr_Detail_Id.SetTextLength(this.DataObject.GetFieldInfo("PR_DETAIL_ID"));
            if (this.FlagNew) {
                this.txtPr_Detail_Id.Set(this.FTSMain, this.DataObject.DataTable, this.DataObject.TableName);
            }
            this.txtPr_Detail_Name.SetTextLength(this.DataObject.GetFieldInfo("PR_DETAIL_NAME"));
            this.txtAddress.SetTextLength(this.DataObject.GetFieldInfo("ADDRESS"));
            this.txtPhone.SetTextLength(this.DataObject.GetFieldInfo("PHONE"));
            this.txtTax_File_Number.SetTextLength(this.DataObject.GetFieldInfo("TAX_FILE_NUMBER"));
            
            //Set focus control
            this.FocusControl = this.txtPr_Detail_Id;
        }

        public override void LayoutItems() {
            FlowLayout layoutMain = new FlowLayout();
            layoutMain.ContainerControl = panelmain;
            layoutMain.TopMargin = 6;
            layoutMain.BottomMargin = 6;
            layoutMain.HorzNearMargin = 6;
            layoutMain.VGap = 3;
            layoutMain.HGap = 10;
            layoutMain.AutoLayout = true;
            layoutMain.Alignment = FlowAlignment.Near;

            FlowLayout layoutdetail = new FlowLayout();
            layoutdetail.ContainerControl = this.groupGeneral;

            layoutdetail.TopMargin = 25;
            layoutdetail.BottomMargin = 3;
            layoutdetail.HorzNearMargin = 6;
            layoutdetail.VGap = 3;
            layoutdetail.HGap = 5;
            layoutdetail.AutoLayout = true;
            layoutdetail.Alignment = FlowAlignment.Near;

          
        }


        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            if (this.FlagNew) {
                this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            } else {
                this.toolbar.SaveNewVisible = BarItemVisibility.Never;
            }
           
        }

        public override void UpdateInfo() {
            base.UpdateInfo();
            if (!this.FlagNew) {
                this.txtPr_Detail_Id.Enabled = false;
            } else {
                this.txtPr_Detail_Id.Enabled = true;
            }
        }

        public override Type GetFrmDicList(string tablename) {
            return GetTypeDic.GetTypeList(tablename);
        }

        public override Type GetFrmDicEditDetail(string tablename) {
            return GetTypeDic.GetTypeEditDetail(tablename);
        }

       
    }
}