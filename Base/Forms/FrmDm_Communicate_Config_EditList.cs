#region

using System;
using System.Collections;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Systems;
using FTS.Global.Classes;
using System.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class FrmDm_Communicate_Config_EditList : FrmDataEditList {
        public FrmDm_Communicate_Config_EditList() {
            this.InitializeComponent();
        }

        public FrmDm_Communicate_Config_EditList(FTSMain ftsmain) : base(ftsmain, false) {
            try {
                this.InitializeComponent();
                this.ShowTextFooter = false;
                this.ConfigGrid();
                this.LoadLayout();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public override void BindGrid() {
            try {
                this.Grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
                ArrayList list = new ArrayList();
                foreach (object key in Registrator.Hash.Keys) {
                    list.Add(key);
                }
                this.Grid.SetComboColumn(this.DataObject.GetFieldInfo("TABLE_NAME"), list);
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_NEW"));
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_EDIT"));
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_DELETE"));
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_PUBLIC"));               
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("ACTIVE"));
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_ID"), false);
                this.Grid.SetTextColumn(this.DataObject.GetFieldInfo("TABLE_NAME_DISPLAY"), false);
                this.Grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_UPLOAD"));
                this.Grid.BindData();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public override void LoadData() {
            try {
                this.DataObject = new Dm_Communicate_Config(this.FTSMain);
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
        public override void GridCustomUnboundColumnData(DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                DataRow rowtable = this.grid.ViewGrid.GetDataRow(e.RowHandle);
                if (rowtable == null)
                    return;
                switch (e.Column.UnboundType)
                {
                    case DevExpress.Data.UnboundColumnType.String:
                        if (e.Column.FieldName.Trim().ToUpper() == "TABLE_NAME_DISPLAY")
                        {
                            if (e.IsGetData)
                            {
                                e.Value = this.FTSMain.TableManager.GetDisplayName((string)rowtable["TABLE_NAME"]);
                            }
                            else
                            {
                                rowtable["TABLE_NAME_DISPLAY"] = e.Value;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }
    }
}