#region

using System.Data;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business{
    public partial class FrmDm_Organization_List : FrmDataList{
        public FrmDm_Organization_List() {
            InitializeComponent();
        }

        public FrmDm_Organization_List(FTSMain ftsmain)
            : base(ftsmain, "DM_ORGANIZATION"){
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        public FrmDm_Organization_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                       bool allowempty)
            : base(ftsmain, ds, tablename, condition, val, allowempty){
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();
            this.ConfigAction();
            this.LoadLayout();
        }

        public override void LoadData(){
            if (this.Mode == ListMode.SELECT){
                this.DataObject = new Dm_Organization(this.FTSMain, this.DataSet);
            } else{
                this.DataObject = new Dm_Organization(this.FTSMain);
            }
        }

        public override void BindGrid(){
            this.grid.CreateGrid(this.DataObject.DataSet,this.DataObject.DataTable, "DM_ORGANIZATION");
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_ID"), true);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PARENT_ORGANIZATION_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ADDRESS"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("CITY"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("DISTRICT"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PHONE"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("FAX"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("TAX_FILE_NUMBER"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME_DISPLAY"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("EMAIL"), false);
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("ORGANIZATION_TYPE"),
                                          OrganizationType.GetOrganizationTypeList(this.FTSMain));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_SHIFT"));
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("SHORT_ORGANIZATION_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PFS_SERVICE_URL"), false);
            this.grid.BindData();
        }

        public override void GetfrmDataEditDetail(bool isnew, object id){
            this.frmDataEditDetail = new FrmDm_Organization_EditDetail(FTSMain, this, isnew, true, id, this.Condition);
        }
    }
}