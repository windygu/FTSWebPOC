#region

using DevExpress.XtraBars;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business {
    public partial class FrmSys_Resource_EditDetail : FrmDataEditDetail {
        public FrmSys_Resource_EditDetail() {
            this.InitializeComponent();
        }

        public FrmSys_Resource_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool SaveandClose, object id,
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
            this.DataObject = new Sys_Resource(this.FTSMain);
        }

        public override void BinControls() {
            this.txtRes_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                    this.DataObject.TableName + ".RES_ID");
            this.txtRes_Value.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                       this.DataObject.TableName + ".RES_VALUE");
            this.txtRes_Value_En.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                          this.DataObject.TableName + ".RES_VALUE_EN");
            this.txtRes_Value_Jp.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                          this.DataObject.TableName + ".RES_VALUE_JP");
        }

        public override void SetControls() {
            this.txtRes_Id.SetCase(true);
            this.txtRes_Id.SetTextLength(this.DataObject.GetFieldInfo("RES_ID"));
            this.txtRes_Value.SetTextLength(this.DataObject.GetFieldInfo("RES_VALUE"));
            this.txtRes_Value_En.SetTextLength(this.DataObject.GetFieldInfo("RES_VALUE_EN"));
            this.txtRes_Value_Jp.SetTextLength(this.DataObject.GetFieldInfo("RES_VALUE_JP"));
            this.txtRes_Id.Enabled = false;
        }

        public override void UpdateInfo() {
            base.UpdateInfo();
            this.txtRes_Id.Enabled = false;
            if (!this.FlagNew) {
                this.txtRes_Id.Enabled = false;
            } else {
                this.txtRes_Id.Enabled = true;
            }
        }

        //public override Type GetFrmDicEditDetail(string tablename)
        //{
        //    return GetTypeDic.GetTypeEditDetail(tablename);
        //}
    }
}