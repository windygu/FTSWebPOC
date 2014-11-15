#region

using DevExpress.XtraBars;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Menu_EditDetail : FrmDataEditDetail {
        public FrmSys_Menu_EditDetail() {
            this.InitializeComponent();
        }

        public FrmSys_Menu_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
                                      string condition) : base(ftsmain, SaveandClose, condition) {
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            this.InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            if (this.FlagNew) {
                this.NewRecord();
            } else {
                this.DataObject.LoadDataByID(this.IdValue);
            }
        }

        public override void LayoutItems() {
            FlowLayout layoutMain = new FlowLayout();
            layoutMain.ContainerControl = this.panelmain;
            layoutMain.TopMargin = 25;
            layoutMain.BottomMargin = 3;
            layoutMain.HorzNearMargin = 20;
            layoutMain.VGap = 15;
            layoutMain.HGap = 15;
            layoutMain.AutoLayout = true;
            layoutMain.Alignment = FlowAlignment.Near;
        }

        public override void LoadData() {
            this.DataObject = new Sys_Menu(this.FTSMain);
        }

        public override void BinControls() {
            this.txtMenu_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                     this.DataObject.TableName + ".MENU_ID");
            this.txtMenu_Type.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                       this.DataObject.TableName + ".MENU_TYPE");
            this.txtMenu_Group.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                       this.DataObject.TableName + ".MENU_GROUP");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                        this.DataObject.TableName + ".ACTIVE");
            this.txtProject_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".PROJECT_ID");
            this.txtModule_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".MODULE_ID");
            this.txtMenu_Icon.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".MENU_ICON");
            this.txtMenu_Tag.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".MENU_TAG");
            this.numMenu_Order.NumericTextBox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".MENU_ORDER");
            this.numMenu_Width.NumericTextBox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".MENU_WIDTH");            
        }

        public override void SetControls() {
            this.txtMenu_Id.SetCase(true);
            this.txtMenu_Group.SetCase(true);
            this.txtModule_Id.SetCase(true);
            this.txtMenu_Id.SetTextLength(this.DataObject.GetFieldInfo("MENU_ID"));
            this.txtMenu_Group.SetTextLength(this.DataObject.GetFieldInfo("PARENT_ID"));
            this.txtModule_Id.SetTextLength(this.DataObject.GetFieldInfo("MODULE_ID"));
        }
    }
}