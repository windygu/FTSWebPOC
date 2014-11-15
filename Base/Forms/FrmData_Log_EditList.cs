#region

using System;
using DevExpress.XtraBars;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.Global.Utilities;
using DevExpress.Data;
using FTS.Global.Interface;
using System.Data;
using FTS.Global.Classes;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmData_Log_EditList : FrmDataEditList {
        private Int32 mWorkstation_Id = -1;

        public FrmData_Log_EditList() {
            this.InitializeComponent();
        }

        public FrmData_Log_EditList(FTSMain ftsmain) : base(ftsmain, false) {
            try {
                this.mWorkstation_Id = -1;
                this.InitializeComponent();
                this.LoadDataNew();
                this.BindGridNew();
                this.ShowTextFooter = false;
                this.ToolBar.CopyVisible = BarItemVisibility.Never;
                this.ToolBar.NewVisible = BarItemVisibility.Never;
                this.ConfigGrid();
                this.LoadLayout();
                this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, FTS.BaseBusiness.Classes.DataAction.ViewAction);
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public FrmData_Log_EditList(FTSMain ftsmain, Int32 workstationid): base(ftsmain, false)
        {
            try
            {
                this.mWorkstation_Id = workstationid;
                this.InitializeComponent();
                this.LoadDataNew();
                this.BindGridNew();
                this.ShowTextFooter = false;
                this.ToolBar.CopyVisible = BarItemVisibility.Never;
                this.ToolBar.NewVisible = BarItemVisibility.Never;
                this.ConfigGrid();
                this.LoadLayout();
                this.FTSMain.SecurityManager.CheckSecurity(this.DataObject.FTSFunction, FTS.BaseBusiness.Classes.DataAction.ViewAction);
            }
            catch (FTSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw (new FTSException(ex));
            }
        }

        private void BindGridNew() {
            try {
                this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
                this.Grid.SetNumberColumn(this.DataObject.GetFieldInfo("PR_KEY"), 0);
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("TABLE_NAME"), true);
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_UPLOAD"));
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("IS_DOWNLOAD"), true);
                this.Grid.SetDateColumn(this.DataObject.GetFieldInfo("LOG_TIME"));
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("OBJECT_VALUE"), false);
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_ID"), false);
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("KEY_VALUE"), false);
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("DATA_ACTION"), false);
                this.Grid.BindData();
                this.Grid.ViewGrid.OptionsBehavior.Editable = false;
                this.Grid.ChooseRow += new SelectRowEventHandler(this.Grid_ChooseRow);
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
        public override void BindGrid()
        {
            
        }
        public override void CheckSecurityBussiess(string dataaction)
        {
            
        }
        private void LoadDataNew() {
            try {
                if (this.mWorkstation_Id > 0)                
                    this.DataObject = new Data_Log(this.FTSMain,this.mWorkstation_Id);
                else
                    this.DataObject = new Data_Log(this.FTSMain);
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
        public override void LoadData()
        {
            
        }
        private void Grid_ChooseRow(object sender, SelectRowEventArgs e) {
            try {
                string value = Functions.UnZip(e.rowvalue["OBJECT_VALUE"].ToString());
                (new FrmShow_Log_Value(this.FTSMain, value)).ShowDialog();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public override void GridCustomUnboundColumnData(DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                DataRow row = this.Grid.ViewGrid.GetDataRow(e.RowHandle);
                if (row == null)
                    return;               
                string key_value = string.Empty;
                string data_action = string.Empty;
                ClassInfo clsInfo = (ClassInfo)Registrator.Hash[row["TABLE_NAME"].ToString().ToUpper()];
                object o = Global.Utilities.Functions.FromXml(Global.Utilities.Functions.UnZip(row["OBJECT_VALUE"].ToString()), clsInfo.Type);
                IHead head = (IHead)o;
                if (clsInfo.IdType == DbType.String)
                    key_value = head.IdValue.ToString();
                else if (clsInfo.IdType == DbType.Guid)
                    key_value = head.IdValue.ToString();
                else
                    key_value = System.Convert.ToDecimal(head.IdValue).ToString("##");
                data_action = head.DataState.ToString();                
                switch (e.Column.UnboundType)
                {
                    case UnboundColumnType.String:
                        if (e.IsGetData)
                        {
                            if (e.Column.FieldName == "KEY_VALUE")
                            {
                                e.Value = key_value;
                            }
                            else if (e.Column.FieldName == "DATA_ACTION")
                            {
                                e.Value = data_action;
                            }                            
                        }
                        break;                   
                }
            }            
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }       
    }
}