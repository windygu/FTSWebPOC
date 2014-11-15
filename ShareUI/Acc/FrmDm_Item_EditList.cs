#region

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareUI.Acc{
    public class FrmDm_Item_EditList : FrmDataEditList{
        private Container components = null;

        public FrmDm_Item_EditList(){
            InitializeComponent();
        }

        public FrmDm_Item_EditList(FTSMain ftsmain) : base(ftsmain){
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
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.Padding = new System.Windows.Forms.Padding(5, 5, 8, 8);
            this.groupGrid.Size = new System.Drawing.Size(456, 181);
            // 
            // groupBox
            // 
            this.groupBox.Location = new System.Drawing.Point(0, 207);
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(456, 143);
            // 
            // FrmDm_Item_EditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(456, 350);
            this.Name = "FrmDm_Item_EditList";
            this.Text = "FrmDm_Item_EditList";
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ITEM_ID"), true);

            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ITEM_NAME"), false);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("UNIT_ID"),
                                          this.DataObject.DataSet.Tables["DM_UNIT"],
                                          "UNIT_NAME", "UNIT_ID", ComboComType.NameID, true);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.grid.BindData();
        }

        public override void LoadData(){
            this.DataObject = new Dm_Item(this.FTSMain);
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