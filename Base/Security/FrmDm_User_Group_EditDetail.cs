#region
using System;
using System.ComponentModel;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using System.Collections.Generic;

#endregion

namespace FTS.BaseUI.Security
{
    public class FrmSec_User_Group_EditDetail : FrmDataEditDetail
    {
        private FTSTextCom txtUser_Group_Id;
        private FTSCheckCom chkActive;
        private FTSTextCom txtUser_Group_Name;
        private FTSTextCom txtModule_List;
        private FTSButton btnList;
        private IContainer components;

        public FrmSec_User_Group_EditDetail()
        {
            InitializeComponent();
        }

        public FrmSec_User_Group_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
                                            string condition)
            : base(ftsmain, SaveandClose, condition)
        {
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            if (this.FlagNew)
            {
                this.NewRecord();
            }
            else
            {
                this.DataObject.LoadDataByID(this.IdValue);
            }
        }
        public List<ItemCombobox> ModuleList;
        public string Module_Copy = "";
        public FrmSec_User_Group_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
                                            string condition, List<ItemCombobox> modulelist, string module_copy)
            : base(ftsmain, SaveandClose, condition)
        {
            Module_Copy = module_copy;
            ModuleList = modulelist;
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            this.LoadData();
            this.DataObject.LoadOtherDm();
            InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            if (this.FlagNew)
            {
                this.NewRecord();
            }
            else
            {
                this.DataObject.LoadDataByID(this.IdValue);
            }
            this.txtUser_Group_Id.Textbox.EditValue = "";
            this.txtUser_Group_Name.Textbox.EditValue = "";
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
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
        private void InitializeComponent()
        {
            this.txtUser_Group_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtUser_Group_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtModule_List = new FTS.BaseUI.Controls.FTSTextCom();
            this.btnList = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(304, 24);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Controls.Add(this.btnList);
            this.palMain.Controls.Add(this.txtUser_Group_Id);
            this.palMain.Controls.Add(this.chkActive);
            this.palMain.Controls.Add(this.txtUser_Group_Name);
            this.palMain.Controls.Add(this.txtModule_List);
            this.palMain.Location = new System.Drawing.Point(0, 24);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(304, 90);
            this.palMain.TabIndex = 1;
            // 
            // txtUser_Group_Id
            // 
            this.txtUser_Group_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtUser_Group_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser_Group_Id.HelpText = "";
            this.txtUser_Group_Id.LabelLength = 85;
            this.txtUser_Group_Id.LabelText = "Mã nhóm nsd:";
            this.txtUser_Group_Id.Location = new System.Drawing.Point(9, 9);
            this.txtUser_Group_Id.Name = "txtUser_Group_Id";
            this.txtUser_Group_Id.Size = new System.Drawing.Size(156, 20);
            this.txtUser_Group_Id.TabIndex = 0;
            this.txtUser_Group_Id.Text = "Mã nhóm nsd:";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 37;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(215, 9);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(57, 20);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "Active";
            // 
            // txtUser_Group_Name
            // 
            this.txtUser_Group_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtUser_Group_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser_Group_Name.HelpText = "";
            this.txtUser_Group_Name.LabelLength = 85;
            this.txtUser_Group_Name.LabelText = "Tên nhóm nsd:";
            this.txtUser_Group_Name.Location = new System.Drawing.Point(9, 35);
            this.txtUser_Group_Name.Name = "txtUser_Group_Name";
            this.txtUser_Group_Name.Size = new System.Drawing.Size(260, 20);
            this.txtUser_Group_Name.TabIndex = 2;
            this.txtUser_Group_Name.Text = "Tên nhóm nsd:";
            // 
            // txtModule_List
            // 
            this.txtModule_List.BackColor = System.Drawing.Color.Transparent;
            this.txtModule_List.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtModule_List.HelpText = "";
            this.txtModule_List.LabelLength = 85;
            this.txtModule_List.LabelText = "Ds phân hệ";
            this.txtModule_List.Location = new System.Drawing.Point(9, 61);
            this.txtModule_List.Name = "txtModule_List";
            this.txtModule_List.Size = new System.Drawing.Size(260, 20);
            this.txtModule_List.TabIndex = 3;
            this.txtModule_List.Text = "Ds phân hệ";
            // 
            // btnList
            // 
            this.btnList.HelpText = "";
            this.btnList.Location = new System.Drawing.Point(268, 59);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(26, 23);
            this.btnList.TabIndex = 4;
            this.btnList.Text = "...";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // FrmSec_User_Group_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(304, 114);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSec_User_Group_EditDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSec_User_Group_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public override void BinControls()
        {
            this.txtUser_Group_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".USER_GROUP_ID");
            this.txtUser_Group_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                             this.DataObject.TableName + ".USER_GROUP_NAME");
            this.txtModule_List.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                         this.DataObject.TableName + ".MODULE_LIST");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".ACTIVE");
        }

        public override void UpdateAndClose()
        {
            base.UpdateAndClose();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public override void LoadData()
        {
            if (ModuleList != null)
                this.DataObject = new Sec_User_Group(this.FTSMain, false, ModuleList, Module_Copy);
            else
                this.DataObject = new Sec_User_Group(this.FTSMain, true);
        }

        public override void SetControls()
        {
            //set upper case
            this.txtUser_Group_Id.SetCase(true);
            this.txtModule_List.SetCase(true);

            //set length
            this.txtUser_Group_Id.SetTextLength(this.DataObject.GetFieldInfo("USER_GROUP_ID"));
            this.txtUser_Group_Name.SetTextLength(this.DataObject.GetFieldInfo("USER_GROUP_NAME"));

            //Set focus control
            this.FocusControl = this.txtUser_Group_Id;
            /*
            this.cboDanhMuc.Set(this.FTSMain, "SYS_MODULE", this.DataObject.DataSet, "MODULE_ID", "PROJECT_NAME", ComboComType.NameID, false);
            */
        }

        /*
        public override void LayoutItems()
        {
            FlowLayout layoutMain = new FlowLayout();
            layoutMain.ContainerControl = panelmain;
            layoutMain.TopMargin = 25;
            layoutMain.BottomMargin = 3;
            layoutMain.HorzNearMargin = 20;
            layoutMain.VGap = 15;
            layoutMain.HGap = 15;
            layoutMain.AutoLayout = false;
            layoutMain.Alignment = FlowAlignment.Near;
        }
        */

        public override void LoadLayout(FTSMain ftsmain)
        {
            base.LoadLayout(ftsmain);
            if (this.FlagNew)
            {
                this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            }
            else
            {
                this.toolbar.SaveNewVisible = BarItemVisibility.Never;
            }
            this.txtModule_List.Textbox.Properties.ReadOnly = true;
        }

        public override void UpdateInfo()
        {
            base.UpdateInfo();
            if (!this.FlagNew)
            {
                this.txtUser_Group_Id.Enabled = false;
            }
            else
            {
                this.txtUser_Group_Id.Enabled = true;
            }
        }

        private void btnList_Click(object sender, System.EventArgs e)
        {
            try
            {
                FrmGetList frmgetlist = new FrmGetList(this.FTSMain, this.DataObject.DataSet.Tables["SYS_MODULE"], "MODULE_ID", "PROJECT_NAME", this.txtModule_List.Textbox);
                frmgetlist.ShowDialog();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        /*
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ReferenceEquals(this.txtModule_List.Textbox.EditValue, "") || this.txtModule_List.Textbox.EditValue != null)
                {
                    this.txtModule_List.Textbox.EditValue += string.Format(",{0}", this.cboDanhMuc.ComboBox.EditValue);
                }
                else
                    txtModule_List.Textbox.EditValue = cboDanhMuc.ComboBox.EditValue;
                if (this.txtModule_List.Textbox.EditValue.ToString()[0] == ',')
                    this.txtModule_List.Textbox.EditValue = this.txtModule_List.Textbox.EditValue.ToString().Remove(0, 1);
                if (this.txtModule_List.Textbox.EditValue.ToString()[this.txtModule_List.Textbox.EditValue.ToString().Length - 1] == ',')
                    this.txtModule_List.Textbox.EditValue = this.txtModule_List.Textbox.EditValue.ToString().Remove(this.txtModule_List.Textbox.EditValue.ToString().Length - 1, 1);

            }
            catch
            {

            }
        }
        */
    }
}