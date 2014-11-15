#region

using System;
using System.ComponentModel;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareUI.Acc{
    public class FrmDm_Unit_EditList : FrmDataEditList{
        private Container components = null;

        public FrmDm_Unit_EditList(){
            InitializeComponent();
        }

        public FrmDm_Unit_EditList(FTSMain ftsmain) : base(ftsmain){
            InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
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
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).BeginInit();
            // 
            // groupGrid
            // 
            this.groupGrid.DockPadding.Bottom = 8;
            this.groupGrid.DockPadding.Left = 5;
            this.groupGrid.DockPadding.Right = 8;
            this.groupGrid.DockPadding.Top = 5;
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(456, 250);
            // 
            // grid
            // 
            // 
            // grid.EmbeddedNavigator
            // 
            this.grid.EmbeddedNavigator.Name = string.Empty;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(443, 237);
            // 
            // FrmDm_Unit_EditList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(456, 350);
            this.Name = "FrmDm_Unit_EditList";
            this.Text = "FrmDm_Unit_EditList";
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
        }

        #endregion

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("UNIT_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("UNIT_NAME"), false);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.grid.BindData();
        }

        public override void LoadData(){
            this.DataObject = new Dm_Unit(this.FTSMain);
        }

        public override Type GetFrmDicList(string tablename){
            return GetTypeDic.GetTypeList(tablename);
        }

        public override Type GetFrmDicEditDetail(string tablename){
            return GetTypeDic.GetTypeEditDetail(tablename);
        }

        public override void SetTextFooter(){
            string columnname = this.grid.CurrentColumnName.ToUpper();
            string cellvalue = this.grid.CurrentCellValue.ToString();
            switch (columnname){
                default:
                    this.grid.SetTextFooter(string.Empty);
                    break;
            }
        }
    }
}