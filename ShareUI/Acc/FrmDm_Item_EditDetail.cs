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
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.ShareUI.Acc{
    public sealed class FrmDm_Item_EditDetail : FrmDataEditDetail {
        protected FTSShadowPanel panelItem;
        private FTSTextCom txtItem_Id;
        private FTSCheckCom chkActive;
        private FTSTextCom txtItem_Name;
        private FTSComboCom cboUnit_Id;
        private IContainer components;

        public FrmDm_Item_EditDetail(){
            InitializeComponent();
        }

        public FrmDm_Item_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
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
            this.FocusControl = this.txtItem_Id.Textbox;
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
            this.panelItem = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.txtItem_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtItem_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.cboUnit_Id = new FTS.BaseUI.Controls.FTSComboCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelItem)).BeginInit();
            this.panelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(504, 24);
            // 
            // palMain
            // 
            this.palMain.Controls.Add(this.panelItem);
            this.palMain.Location = new System.Drawing.Point(0, 24);
            this.palMain.Size = new System.Drawing.Size(504, 92);
            // 
            // panelItem
            // 
            this.panelItem.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelItem.Appearance.Options.UseBackColor = true;
            this.panelItem.BorderColor = System.Drawing.Color.Empty;
            this.panelItem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelItem.Controls.Add(this.cboUnit_Id);
            this.panelItem.Controls.Add(this.txtItem_Id);
            this.panelItem.Controls.Add(this.chkActive);
            this.panelItem.Controls.Add(this.txtItem_Name);
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItem.Location = new System.Drawing.Point(0, 0);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(504, 92);
            this.panelItem.SkinBackColor = System.Drawing.SystemColors.Control;
            this.panelItem.TabIndex = 12;
            // 
            // txtItem_Id
            // 
            this.txtItem_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtItem_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItem_Id.Enabled = false;
            this.txtItem_Id.HelpText = "";
            this.txtItem_Id.LabelLength = 120;
            this.txtItem_Id.LabelText = "Mã hhóa:";
            this.txtItem_Id.Location = new System.Drawing.Point(52, 12);
            this.txtItem_Id.Name = "txtItem_Id";
            this.txtItem_Id.Size = new System.Drawing.Size(256, 20);
            this.txtItem_Id.TabIndex = 5;
            this.txtItem_Id.Text = "Mã hhóa:";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 38;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(314, 12);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(58, 20);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Active";
            // 
            // txtItem_Name
            // 
            this.txtItem_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtItem_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItem_Name.HelpText = "";
            this.txtItem_Name.LabelLength = 120;
            this.txtItem_Name.LabelText = "Tên hàng hóa:";
            this.txtItem_Name.Location = new System.Drawing.Point(52, 36);
            this.txtItem_Name.Name = "txtItem_Name";
            this.txtItem_Name.Size = new System.Drawing.Size(400, 20);
            this.txtItem_Name.TabIndex = 6;
            this.txtItem_Name.Text = "Tên hàng hóa:";
            // 
            // cboUnit_Id
            // 
            this.cboUnit_Id.BackColor = System.Drawing.Color.Transparent;
            this.cboUnit_Id.HelpText = "";
            this.cboUnit_Id.IsChanged = false;
            this.cboUnit_Id.LabelLength = 120;
            this.cboUnit_Id.LabelText = "Đvt tồn kho";
            this.cboUnit_Id.Location = new System.Drawing.Point(52, 62);
            this.cboUnit_Id.Name = "cboUnit_Id";
            this.cboUnit_Id.Size = new System.Drawing.Size(400, 20);
            this.cboUnit_Id.TabIndex = 8;
            this.cboUnit_Id.Text = "Đvt tồn kho";
            // 
            // FrmDm_Item_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(504, 116);
            this.Name = "FrmDm_Item_EditDetail";
            this.Text = "FrmDm_Item_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelItem)).EndInit();
            this.panelItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public override void BinControls(){
            this.txtItem_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".ITEM_ID");
            this.txtItem_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                       this.DataObject.TableName + ".ITEM_NAME");
            this.cboUnit_Id.ComboBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                      this.DataObject.TableName + ".UNIT_ID");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".ACTIVE");
            
        }

        public override void LoadData(){
            this.DataObject = new Dm_Item(this.FTSMain, true);
        }

        public override void SetControls(){
            //Set combo
            this.cboUnit_Id.Set(this.FTSMain, "DM_UNIT", this.DataObject.DataSet, "UNIT_ID",
                                "UNIT_NAME", ComboComType.NameID, true);
            
            //set upper case
            this.txtItem_Id.SetCase(true);

            //set length
            this.txtItem_Id.SetTextLength(this.DataObject.GetFieldInfo("ITEM_ID"));
            if (this.FlagNew) {
                this.txtItem_Id.Set(this.FTSMain, this.DataObject.DataTable, this.DataObject.TableName);
            }
            this.txtItem_Name.SetTextLength(this.DataObject.GetFieldInfo("ITEM_NAME"));

            //Set focus control
            this.FocusControl = this.txtItem_Id;
        }

        public override void LayoutItems(){
            
        }

        public override Type GetFrmDicList(string tablename){
            return GetTypeDic.GetTypeList(tablename);
        }

        public override Type GetFrmDicEditDetail(string tablename){
            return GetTypeDic.GetTypeEditDetail(tablename);
        }

        public override void UpdateInfo(){
            base.UpdateInfo();
            if (!this.FlagNew){
                this.txtItem_Id.Enabled = false;
            } else{
                this.txtItem_Id.Enabled = true;
            }
        }

        public override void LoadLayout(FTSMain ftsmain){
            base.LoadLayout(ftsmain);

            
            if (this.FlagNew){
                this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            } else{
                this.toolbar.SaveNewVisible = BarItemVisibility.Never;
            }
            
        }
    }
}