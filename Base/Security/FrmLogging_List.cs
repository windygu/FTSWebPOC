#region

using System.ComponentModel;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Security{
    public class FrmLogging_List : FrmDataList{
        private Container components = null;

        public FrmLogging_List(){
            InitializeComponent();
        }

        public FrmLogging_List(FTSMain ftsmain)
            : base(ftsmain, "LOGGING"){
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
            this.Size = new System.Drawing.Size(456, 350);
            this.Name = "FrmLogging_List";
            this.Text = "FrmLogging_List";
        }

        #endregion

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("ACTION_TYPE"),
                                          ActionType.GetActionTypeList(this.FTSMain));
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ACTION_DATETIME"),false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("DESCRIPTION"), false);
            this.grid.BindData();
        }

        public override void LoadData(){
            this.DataObject = new Logging(this.FTSMain);
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