#region

using System;
using System.ComponentModel;
using DevExpress.XtraBars;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareUI.Acc{
    public class FrmDm_Unit_EditDetail : FrmDataEditDetail{        
        private FTSTextCom txtUnit_Id;
        private FTSCheckCom chkActive;
        private FTSTextCom txtUnit_Name;
        private IContainer components;

        public FrmDm_Unit_EditDetail(){
            InitializeComponent();
        }

        public FrmDm_Unit_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
                                     string condition)
            : base(ftsmain, SaveandClose, condition){
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            if (this.FlagNew){
                this.NewRecord();
            } else{
                this.DataObject.LoadDataByID(this.IdValue);
            }
        }

        protected override void Dispose(bool disposing){
            if (disposing){
                if (components != null){
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
        private void InitializeComponent(){
            this.txtUnit_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtUnit_Name = new FTS.BaseUI.Controls.FTSTextCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(287, 24);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Controls.Add(this.txtUnit_Id);
            this.palMain.Controls.Add(this.chkActive);
            this.palMain.Controls.Add(this.txtUnit_Name);
            this.palMain.Location = new System.Drawing.Point(0, 24);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(287, 64);
            // 
            // txtUnit_Id
            // 
            this.txtUnit_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtUnit_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUnit_Id.HelpText = "";
            this.txtUnit_Id.LabelText = "Mã đvt:";
            this.txtUnit_Id.Location = new System.Drawing.Point(6, 6);
            this.txtUnit_Id.Name = "txtUnit_Id";
            this.txtUnit_Id.Size = new System.Drawing.Size(165, 20);
            this.txtUnit_Id.TabIndex = 4;
            this.txtUnit_Id.Text = "Mã đvt:";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 36;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(182, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 20);
            this.chkActive.TabIndex = 5;
            this.chkActive.Text = "Active";
            // 
            // txtUnit_Name
            // 
            this.txtUnit_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtUnit_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUnit_Name.HelpText = "";
            this.txtUnit_Name.LabelText = "Tên đvt:";
            this.txtUnit_Name.Location = new System.Drawing.Point(6, 32);
            this.txtUnit_Name.Name = "txtUnit_Name";
            this.txtUnit_Name.Size = new System.Drawing.Size(232, 20);
            this.txtUnit_Name.TabIndex = 6;
            this.txtUnit_Name.Text = "Tên đvt:";
            // 
            // FrmDm_Unit_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(287, 88);
            this.Name = "FrmDm_Unit_EditDetail";
            this.Text = "FrmDm_Unit_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public override void BinControls(){
            this.txtUnit_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".UNIT_ID");
            this.txtUnit_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                       this.DataObject.TableName + ".UNIT_NAME");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".ACTIVE");
        }

        public override void LoadData(){
            this.DataObject = new Dm_Unit(this.FTSMain, true);
        }

        public override void SetControls(){
            //set upper case
            this.txtUnit_Id.SetCase(true);

            //set length
            this.txtUnit_Id.SetTextLength(this.DataObject.GetFieldInfo("UNIT_ID"));
            if (this.FlagNew) {
                this.txtUnit_Id.Set(this.FTSMain, this.DataObject.DataTable, this.DataObject.TableName);
            }
            this.txtUnit_Name.SetTextLength(this.DataObject.GetFieldInfo("UNIT_NAME"));

            //Set focus control
            this.FocusControl = this.txtUnit_Id;
        }       

        public override void LoadLayout(FTSMain ftsmain){
            base.LoadLayout(ftsmain);
            if (this.FlagNew){
                this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            } else{
                this.toolbar.SaveNewVisible = BarItemVisibility.Never;
            }
        }

        public override void UpdateInfo(){
            base.UpdateInfo();
            if (!this.FlagNew){
                this.txtUnit_Id.Enabled = false;
            } else{
                this.txtUnit_Id.Enabled = true;
            }
        }

        public override Type GetFrmDicList(string tablename){
            return GetTypeDic.GetTypeList(tablename);
        }

        public override Type GetFrmDicEditDetail(string tablename){
            return GetTypeDic.GetTypeEditDetail(tablename);
        }
    }
}