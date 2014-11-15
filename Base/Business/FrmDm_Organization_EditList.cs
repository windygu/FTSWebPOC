#region

using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business{
    public partial class FrmDm_Organization_EditList : FrmDataTreeEditList{
        public FrmDm_Organization_EditList(){
            InitializeComponent();
        }

        public FrmDm_Organization_EditList(FTSMain ftsmain)
            : base(ftsmain){
            InitializeComponent();
            this.ShowTextFooter = false;
            this.LoadLayout();
        }

        public override void LoadData(){
            this.DataObject = new Dm_Organization(this.FTSMain);
        }

        public override void BindTree(){
            this.Tree.CreateTreeList(this.DataObject.DataTable, "ORGANIZATION_ID", "PARENT_ORGANIZATION_ID");
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_ID"), true);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PARENT_ORGANIZATION_ID"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ADDRESS"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("CITY"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("DISTRICT"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PHONE"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("FAX"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("EMAIL"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("TAX_FILE_NUMBER"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("ORGANIZATION_NAME_DISPLAY"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("EMAIL"), false);
            this.Tree.SetComboMultiColumn(this.DataObject.GetFieldInfo("ORGANIZATION_TYPE"),
                                          OrganizationType.GetOrganizationTypeList(this.FTSMain));
            this.Tree.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.Tree.SetCheckColumn(this.DataObject.GetFieldInfo("IS_POS"));
            this.Tree.SetCheckColumn(this.DataObject.GetFieldInfo("IS_SHIFT"));
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("SHORT_ORGANIZATION_NAME"), false);
            this.Tree.SetTextColumn(this.DataObject.GetFieldInfo("PFS_SERVICE_URL"), false);
            
            this.Tree.BindData();
        }
    }
}