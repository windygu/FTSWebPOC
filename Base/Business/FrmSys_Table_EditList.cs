#region

using System.ComponentModel;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmSys_Table_EditList : FrmDataEditList {
        private Container components = null;

        public FrmSys_Table_EditList() {
            this.InitializeComponent();
        }

        public FrmSys_Table_EditList(FTSMain ftsmain) : base(ftsmain) {
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
            // FrmDm_Msg_EditList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(456, 350);
            this.Name = "FrmSys_Table_EditList";
            this.Text = "FrmSys_Table_EditList";
            ((System.ComponentModel.ISupportInitialize) (this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
        }

        #endregion

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TABLE_NAME"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ID_FIELD"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("NAME_FIELD"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TABLE_TYPE"), false);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("BACKUPS"));
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("NUM_ORDER"), 0);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("RES_ORDER"), 0);
            this.grid.BindData();
        }

        public override void LoadData() {
            this.DataObject = new Sys_Table(this.FTSMain);
        }

        public override void SetTextFooter() {
            string columnname = this.grid.CurrentColumnName.ToUpper();
            string cellvalue = this.grid.CurrentCellValue.ToString();
            switch (columnname) {
                default:
                    this.grid.SetTextFooter(string.Empty);
                    break;
            }
        }
    }
}