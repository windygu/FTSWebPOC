#region

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareUI.Acc{
    public class FrmDm_Pr_Detail_List : FrmDataList{
        private Container components = null;
        
        public FrmDm_Pr_Detail_List(){
            InitializeComponent();
        }

        public FrmDm_Pr_Detail_List(FTSMain ftsmain)
            : base(ftsmain, "dm_pr_detail"){
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        public FrmDm_Pr_Detail_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                    bool allowempty)
            : base(ftsmain, ds, tablename, condition, val, allowempty){
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).BeginInit();
            this.palBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(738, 26);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Size = new System.Drawing.Size(738, 322);
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 322);
            // 
            // palBottom
            // 
            this.palBottom.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palBottom.Appearance.Options.UseBackColor = true;
            this.palBottom.Location = new System.Drawing.Point(0, 348);
            this.palBottom.Size = new System.Drawing.Size(738, 40);
            // 
            // palRight
            // 
            this.palRight.Location = new System.Drawing.Point(571, 0);
            this.palRight.Size = new System.Drawing.Size(167, 322);
            // 
            // splitRight
            // 
            this.splitRight.Location = new System.Drawing.Point(566, 0);
            this.splitRight.Size = new System.Drawing.Size(5, 322);
            
            // 
            // FrmDm_Pr_Detail_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(738, 388);
            this.Name = "FrmDm_Pr_Detail_List";
            this.Text = "FrmDm_Pr_Detail_List";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palBottom)).EndInit();
            this.palBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public override void LoadData() {
            if (this.Mode == ListMode.SELECT) {
                this.DataObject = new Dm_Pr_Detail(this.FTSMain, this.DataSet, this.TableName);
            } else {
                this.DataObject = new Dm_Pr_Detail(this.FTSMain);
            }
        }

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetIDTextColumn(this.DataObject.GetFieldInfo("PR_DETAIL_ID"));
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PR_DETAIL_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ADDRESS"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PHONE"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TAX_FILE_NUMBER"), false);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_PUBLIC"));
            this.grid.BindData();
        }

        public override void GetfrmDataEditDetail(bool isnew, object id){
            this.frmDataEditDetail = new FrmDm_Pr_Detail_EditDetail(this.FTSMain, this, isnew, true, id, this.Condition);
           
        }

        public override Type GetFrmDicEditList(string tablename){
            return GetTypeDic.GetTypeEditList(tablename);
        }
    }
}