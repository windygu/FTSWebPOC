#region

using System;
using System.ComponentModel;
using FTS.AccBusiness.Sale;
using FTS.AccUI.Systems;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;

#endregion

namespace FTS.AccUI.Sale {
    public class FrmSale_Price_EditList : FrmDataEditList {
        private Container components = null;

        public FrmSale_Price_EditList() {
            this.InitializeComponent();
        }

        public FrmSale_Price_EditList(FTSMain ftsmain) : base(ftsmain) {
            this.InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public override void LoadData() {
            this.DataObject = new Sale_Price(this.FTSMain);
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("ITEM_ID"),
                                          this.DataObject.DataSet.Tables["DM_ITEM"], "ITEM_NAME",
                                          "ITEM_ID", ComboComType.NameID, true);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("UNIT_PRICE"), this.FTSMain.TPDGVND);
            this.grid.SetDateColumn(this.DataObject.GetFieldInfo("VALID_DATE"));
            this.grid.BindData();
        }

        public override Type GetFrmDicList(string tablename) {
            return GetTypeDicAcc.GetTypeList(tablename);
        }

        public override Type GetFrmDicEditDetail(string tablename) {
            return GetTypeDicAcc.GetTypeEditDetail(tablename);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
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
            this.groupGrid.Size = new System.Drawing.Size(384, 178);
            // 
            // grid
            // 
            // 
            // grid.EmbeddedNavigator
            // 
            this.grid.EmbeddedNavigator.Name = string.Empty;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(371, 165);
            // 
            // FrmSale_Price_EditList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 278);
            this.Name = "FrmSale_Price_EditList";
            this.Text = "FrmSale_Price_EditList";
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
        }

        #endregion
    }
}