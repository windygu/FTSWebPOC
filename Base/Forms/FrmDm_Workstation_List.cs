using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Business;
using System.Collections;


namespace FTS.BaseUI.Forms
{
    public partial class FrmDm_Workstation_List : FrmDataList
    {
        public FrmDm_Workstation_List()
        {
            InitializeComponent();
        }
        public FrmDm_Workstation_List(FTSMain ftsmain, string condition): base(ftsmain, "DM_WORKSTATION")
        {            
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();            
            this.ConfigAction();
            this.LoadLayout();
            this.toolbar.NewVisible = DevExpress.XtraBars.BarItemVisibility.Never;            
            this.toolbar.DeleteVisible = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public FrmDm_Workstation_List(FTSMain ftsmain, DataSet ds, string tablename, string condition, string val, bool alowempty)
            : base(ftsmain, ds, tablename, condition, val, alowempty)
        {            
            InitializeComponent();
            this.BindGrid();
            this.ConfigGrid();                
            this.ConfigAction();
            this.LoadLayout();
            this.split.Visible = false;
            this.toolbar.NewVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolbar.DeleteVisible = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public override void LoadData()
        {            
            this.DataObject = new Dm_Workstation(this.FTSMain, this.Condition);            
        }

        public override void BindGrid()
        {            
            this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("WORKSTATION_ID"), true);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("WORKSTATION_NAME"), false);
            this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("HARDWARE_INFO"), false);
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
            this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_ONLINE"));    
            this.Grid.BindData();            
        }

        public override void GetfrmDataEditDetail(bool isnew, object id)
        {
            this.FormDataEditDetail = new FrmDm_Workstation_EditDetail(this.FTSMain, this, isnew, false, id, this.Condition);
        }
    }
}