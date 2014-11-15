#region

using System.Data;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business{
    public partial class FrmDm_Organization_TreeList : FrmDataTreeList{
        public FrmDm_Organization_TreeList(){
            InitializeComponent();
        }

        public FrmDm_Organization_TreeList(FTSMain ftsmain)
            : base(ftsmain, "DM_ORGANIZATION"){
            InitializeComponent();
            this.BindGrid();
            this.ConfigTree();
            this.ConfigAction();
            this.LoadLayout();
        }

        public FrmDm_Organization_TreeList(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val,
                                       bool allowempty)
            : base(ftsmain, ds, tablename, condition, val, allowempty){
            InitializeComponent();
            this.BindGrid();
            this.ConfigTree();
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
            this.Tree.CreateTreeList(this.DataObject.DataTable, "ORGANIZATION_ID", "PARENT_ORGANIZATION_ID");
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_ID"), true);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PARENT_ORGANIZATION_ID"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ADDRESS"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("CITY"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("DISTRICT"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PHONE"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("FAX"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("TAX_FILE_NUMBER"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME_DISPLAY"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("EMAIL"), false);
            this.Tree.SetComboMultiColumn(this.DataObject.GetFieldInfo("ORGANIZATION_TYPE"),
                                          OrganizationType.GetOrganizationTypeList(this.FTSMain));
            this.Tree.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.Tree.SetCheckColumn(this.DataObject.GetFieldInfo("IS_SHIFT"));
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("SHORT_ORGANIZATION_NAME"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PFS_SERVICE_URL"), false);
            this.Tree.BindData();
        }

        public override void GetfrmDataEditDetail(bool isnew, object id){
            this.frmDataEditDetail = new FrmDm_Organization_EditDetail(FTSMain, this, isnew, true, id, this.Condition);
        }
    }
}