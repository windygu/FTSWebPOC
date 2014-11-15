using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Layout;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Business;
using DevExpress.XtraEditors.Controls;

namespace FTS.BaseUI.Forms
{
    public partial class FrmDm_Workstation_EditDetail : FrmDataEditDetail
    {
        public FrmDm_Workstation_EditDetail()
        {
            InitializeComponent();
        }
        public FrmDm_Workstation_EditDetail(FTSMain ftsmain, FrmDataList frm, bool isnew, bool saveAndclose, object id, string condition): base(ftsmain, saveAndclose, condition) 
        {			
			this.FlagNew = isnew;
			this.FrmParent = frm;
			this.IdValue = id;
			InitializeComponent();
			this.LoadLayout();
			this.LayoutItems();
			this.BinControls();
			this.SetControls();
			if (this.FlagNew) {
				this.NewRecord();
			} else {
				this.DataObject.LoadDataByID(this.IdValue);                    
			}                            
            this.ToolBar.NewVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ToolBar.CopyVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ToolBar.DeleteVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.txtWorkstation_Id.Textbox.Enabled = false;
            this.txtWorkstation_Name.Textbox.Enabled = false;
            this.txtHardware_Info.Textbox.Enabled = false;                			
		}        
        public override void BinControls()
        {            
            this.txtWorkstation_Id.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".WORKSTATION_ID");
            this.txtWorkstation_Name.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".WORKSTATION_NAME");
            this.txtHardware_Info.Textbox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".HARDWARE_INFO");
            this.chkIs_Online.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".IS_ONLINE");
            this.chkActive.CheckBox.DataBindings.Add("EditValue", this.DataObject.DataSet, this.DataObject.TableName + ".ACTIVE");            
        }

        public override void LoadData()
        {            
            this.DataObject = new Dm_Workstation(this.FTSMain, this.Condition, true);            
        }        
        public override void SetControls()
        {                          
            this.txtWorkstation_Id.SetCase(true);                
            this.txtWorkstation_Id.SetTextLength(this.DataObject.GetFieldInfo("WORKSTATION_ID"));
            this.txtWorkstation_Name.SetTextLength(this.DataObject.GetFieldInfo("WORKSTATION_NAME"));
            this.txtHardware_Info.SetTextLength(this.DataObject.GetFieldInfo("HARDWARE_INFO"));                
            this.FocusControl = this.txtWorkstation_Id;            
        }        
    }
}