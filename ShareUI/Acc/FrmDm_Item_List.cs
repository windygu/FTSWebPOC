#region

using System;
using System.ComponentModel;
using System.Data;
using FTS.ShareBusiness.Acc;
using FTS.ShareUI.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.ShareUI.Acc{
    public class FrmDm_Item_List : FrmDataList{
        private Container components = null;

        public FrmDm_Item_List(FTSMain ftsmain) : base(ftsmain, "dm_item"){
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        public FrmDm_Item_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
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
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "FrmDm_Item_List";
            this.Name = "FrmDm_Item_List";
        }

        #endregion

        public override void LoadData(){
            if (this.Mode == ListMode.SELECT){
                this.DataObject = new Dm_Item(this.FTSMain, this.DataSet);
            } else{
                this.DataObject = new Dm_Item(this.FTSMain);
            }
        }

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetIDTextColumn(this.DataObject.GetFieldInfo("ITEM_ID"));
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ITEM_NAME"), false);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("UNIT_ID"),
                                          this.DataObject.DataSet.Tables["DM_UNIT"],
                                          "UNIT_NAME", "UNIT_ID", ComboComType.NameID, true);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.grid.BindData();
        }

        public override void GetfrmDataEditDetail(bool isnew, object id){
            this.frmDataEditDetail = new FrmDm_Item_EditDetail(this.FTSMain, this, isnew, true, id, this.Condition);
        }

        public override Type GetFrmDicEditList(string tablename){
            return GetTypeDic.GetTypeEditList(tablename);
        }

        
    }
}