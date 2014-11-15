#region

using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Business{
    public partial class FrmDm_Organization_EditDetail : FrmDataEditDetail{
        public FrmDm_Organization_EditDetail(){
            InitializeComponent();
        }

        public FrmDm_Organization_EditDetail(FTSMain ftsmain, FTSForm frm, bool isnew, bool SaveandClose, object id,
                                             string condition)
            : base(ftsmain, SaveandClose, condition){
            this.FlagNew = isnew;
            this.FrmParent = frm;
            this.IdValue = id;
            InitializeComponent();
            this.LoadLayout();
            this.LayoutItems();
            this.BinControls();
            this.SetControls();
            this.toolbar.SaveNewVisible = BarItemVisibility.Always;
            if (this.FlagNew){
                this.NewRecord();
            } else{
                BindingManagerBase bm = this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName];
                int position = -1;
                for (int i = 0; i < this.DataObject.DataTable.Rows.Count; i++){
                    position++;
                    if (this.DataObject.DataTable.Rows[i][this.DataObject.IdField].Equals(this.IdValue)){
                        break;
                    }
                }
                bm.Position = position;
            }
        }

        public override void NewRecord(){
            if (this.CheckChanged() != ChangedStatus.CANCEL){
                this.DataObject.AddNew();
                BindingManagerBase bm = this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName];
                bm.Position = this.DataObject.DataTable.Rows.Count;
                this.UpdateInfo();
                this.ConfigAction();
                if (this.FocusControl != null){
                    this.FocusControl.Focus();
                }
            }
        }

        public override void UpdateRecord(){
            this.EndEdit();
            if (this.DataObject.DataTable.Rows.Count == 0 || !this.DataObject.HasChanged()){
                return;
            }
            this.CheckFormRequire(this.palMain);
            bool isdelete = false;
            object id;
            bool ischanged = false;
            BindingManagerBase bm = this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName];
            if (this.DataObject.DataTable.Rows.Count > 0 &&
                this.DataObject.DataTable.Rows[bm.Position].RowState == DataRowState.Deleted){
                id = this.DataObject.DataTable.Rows[bm.Position][this.DataObject.IdField, DataRowVersion.Original];
                isdelete = true;
            } else{
                id = this.DataObject.DataTable.Rows[bm.Position][this.DataObject.IdField];
                if (this.DataObject.DataTable.Rows.Count > 0 &&
                    this.DataObject.DataTable.Rows[bm.Position].RowState == DataRowState.Modified){
                    ischanged = true;
                }
            }
            this.DataObject.UpdateData();
            DataTable tblTemp = this.DataObject.DataTable.Copy();
            if (this.FrmParent != null){
                if (isdelete){
                    if (this.FrmParent is FrmDataList){
                        ((FrmDataList) this.FrmParent).UpdateDeletedRecord(id);
                    } else if (this.FrmParent is FrmDataTreeList){
                        ((FrmDataTreeList) this.FrmParent).UpdateDeletedRecord(id);
                    }
                } else{
                    if (tblTemp.Rows.Count > 0){
                        if (this.FrmParent is FrmDataList){
                            ((FrmDataList) this.FrmParent).UpdateChangeRecord(tblTemp.Rows[bm.Position], ischanged);
                        } else if (this.FrmParent is FrmDataTreeList){
                            ((FrmDataTreeList) this.FrmParent).UpdateChangeRecord(tblTemp.Rows[bm.Position], ischanged);
                        }
                    }
                }
            }
        }

        public override void LayoutItems(){
            var layoutMain = new FlowLayout();
            layoutMain.ContainerControl = this.ftsGroupBox1;
            layoutMain.TopMargin = 25;
            layoutMain.BottomMargin = 3;
            layoutMain.HorzNearMargin = 20;
            layoutMain.VGap = 5;
            layoutMain.HGap = 15;
            layoutMain.AutoLayout = true;
            layoutMain.Alignment = FlowAlignment.Near;
        }

        public override void LoadData(){
            this.DataObject = new Dm_Organization(this.FTSMain);
        }

        public override void BinControls(){
            this.txtOrganization_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                             this.DataObject.TableName + ".ORGANIZATION_ID");
            this.txtOrganization_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".ORGANIZATION_NAME");
            this.txtShort_Organization_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".SHORT_ORGANIZATION_NAME");
            this.txtParent_Organization_Id.txtID.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                                  this.DataObject.TableName + ".PARENT_ORGANIZATION_ID");

            this.txtAddress.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".ADDRESS");
            this.txtCity.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".CITY");
            this.txtDistrict.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".DISTRICT");
            this.txtPhone.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".PHONE");
            this.txtFax.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".FAX");
            this.txtTax_File_Number.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".TAX_FILE_NUMBER");
            this.txtOrganization_Name_Display.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".ORGANIZATION_NAME_DISPLAY");
            this.txtEmail.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                               this.DataObject.TableName + ".EMAIL");
            this.cboOrganization_Type_Id.ComboBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".ORGANIZATION_TYPE");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".ACTIVE");
            this.chkOffline.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".IS_POS");
            this.chkIs_Shift.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".IS_SHIFT");
            this.chkIs_Sub.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet,
                                                           this.DataObject.TableName + ".IS_SUB");
            
            
        }

        public override void SetControls(){
            this.txtOrganization_Id.SetCase(true);
            this.txtParent_Organization_Id.SetCase(true);
            this.txtOrganization_Id.SetTextLength(this.DataObject.GetFieldInfo("ORGANIZATION_ID"));
            this.txtOrganization_Name.SetTextLength(this.DataObject.GetFieldInfo("ORGANIZATION_NAME"));
            this.txtParent_Organization_Id.SetTextLength(this.DataObject.GetFieldInfo("PARENT_ORGANIZATION_ID"));
            this.txtParent_Organization_Id.Set(this.FTSMain, this.DataObject.DataSet, "DM_ORGANIZATION", ListType.TREE,
                                               true);
            this.cboOrganization_Type_Id.Set(OrganizationType.GetOrganizationTypeList(this.FTSMain));
            
        }

        private void Control_Lookup(object sender, EventArgs e){
            try{
                ((FTSNameIDCom) sender).ProcessLookup();
            } catch (FTSException ex){
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1){
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        private void Control_Leave(object sender, EventArgs e){
            try{
                    ((FTSNameIDCom) sender).ProcessMa();
            } catch (FTSException ex){
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            } catch (Exception ex1){
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        public override void UpdateInfo(){
            base.UpdateInfo();
            if (!this.FlagNew){
                this.txtOrganization_Id.Enabled = false;
            } else{
                this.txtOrganization_Id.Enabled = true;
            }
        }
        public override Type GetFrmDicList(string tablename) {
            return typeof(FrmDm_Organization_TreeList);
        }

        public override Type GetFrmDicEditDetail(string tablename) {
            return typeof(FrmDm_Organization_EditDetail);
        }
    }
}