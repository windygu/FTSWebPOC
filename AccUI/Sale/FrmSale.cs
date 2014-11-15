using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using FTS.AccBusiness.Sale;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.ShareUI.Common;

namespace FTS.AccUI.Sale {
    public partial class FrmSale : FrmBase2 {
        protected SaleManager mSaleManager;
        

        public FrmSale(FTSMain ftsmain,string tranid)
            : base(ftsmain) {
            this.InitializeComponent();
            this.TranId = tranid;
            this.Name = this.Name + "_" + this.TranId;
            this.LoadData();
            this.BindHeaderControls();
            this.BindGrid();
            this.LoadContextMenu();
            this.ConfigGrid();
            this.SetControls();
            this.LoadLayout();
            this.LayoutItems();
            this.FocusControl = this.DateTranDate;
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("NEW_RECORD_ON_LOAD")) {
                this.NewRecord();
            } else {
                if ((bool) this.FTSMain.SystemVars.GetSystemVars("LAST_RECORD_ON_LOAD")) {
                    this.NextRecord();
                }
            }
        }

        public FrmSale(FTSMain ftsmain, string tran_id, object pr_key)
            : base(ftsmain) {
            this.TranId = tran_id;
            this.InitializeComponent();
            this.Name = this.Name + "_" + this.TranId;
            this.LoadData();
            this.BindHeaderControls();
            this.BindGrid();
            this.LoadContextMenu();
            this.ConfigGrid();
            this.LoadLayout();
            this.SetControls();
            this.FocusControl = this.DateTranDate;
            this.mSaleManager.LoadRecordWithPrkey(pr_key);
            this.Mode = DataMode.READ;
            this.LayoutItems();
        }

        public override void LoadData() {
            this.ObjectManager = new SaleManager(this.FTSMain, this.TranId);
            this.mSaleManager = (SaleManager) this.ObjectManager;
        }

        public override void BindHeaderControls() {
            this.txtTran_No.Textbox.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".TRAN_NO");
            this.DateTranDate.DateTime.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".TRAN_DATE");
            this.txtOrganization.txtID.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".ORGANIZATION_ID");
            this.txtPr_Detail_Id.txtID.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".PR_DETAIL_ID");
            this.txtAddress.Textbox.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".ADDRESS");
            this.txtTax_File_Number.Textbox.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".TAX_FILE_NUMBER");
            this.txtDescription.Textbox.DataBindings.Add("EditValue", this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName + ".COMMENTS");
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.mSaleManager.mSale_Detail.DataSet, this.mSaleManager.mSale_Detail.DataTable, this.mSaleManager.mSale_Detail.TableName);
            this.grid.SetLookupTextColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("ITEM_ID"), true);
            this.grid.SetTextColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("ITEM_NAME"), false);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("QUANTITY"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("UNIT_PRICE"), this.FTSMain.TPDGVND);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("VAT_TAX_RATE"), 0);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("VAT_TAX_AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.mSaleManager.mSale_Detail.GetFieldInfo("TOTAL_AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.BindData();
        }

        

        public override void UpdateInfo() {
            base.UpdateInfo();
            this.txtOrganization.UpdateInfo();
            this.txtPr_Detail_Id.UpdateInfo();
            if (this.Mode == DataMode.READ || this.Mode == DataMode.NONE) {
                this.groupBottom0.Enabled = false;
            }else {
                this.groupBottom0.Enabled = true;
            }
        }

        public override void GridTextBoxLookup(FTSDataGrid gr, TextEdit textbox, int nrow, GridColumn ncol) {
            try {
                DataRow dr = gr.ViewGrid.GetDataRow(nrow);
                switch (ncol.FieldName.ToUpper()) {
                    case "ITEM_ID":
                        this.ProcessLookupColumn(gr, textbox, "DM_ITEM", "1=1", nrow, ncol, null, null);
                        this.mSaleManager.ItemChanged(dr);
                        break;
                    default:
                        break;
                }
                this.UpdateBottom();
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public override void GridValidatingCell(GridView gridview, BaseContainerValidateEditorEventArgs e) {
            try {
                BaseEdit textbox = gridview.ActiveEditor;
                bool tag = false;
                try {
                    tag = (bool) textbox.Tag;
                } catch (Exception) {
                }
                if (gridview.FocusedRowHandle >= 0) {
                    GridColumn ncol = gridview.FocusedColumn;
                    int nrow = gridview.FocusedRowHandle;
                    this.Grid.SetValue(nrow, ncol.FieldName, e.Value);
                    FTSDataGrid gr = ((FTSDataGrid) gridview.GridControl);
                    gr.SetValue(nrow, ncol.FieldName, e.Value);
                    BindingManagerBase bm =
                        this.BindingContext[this.ObjectManager.DataSet, this.ObjectManager.ObjectList[0].TableName];
                    bm.EndCurrentEdit();
                    this.mSaleManager.EndEdit();
                    DataRow dr = gridview.GetDataRow(nrow);
                    switch (ncol.FieldName.ToUpper()) {
                        case "ITEM_ID":
                            this.ProcessGridColumn(gr, textbox, "DM_ITEM", "1=1", nrow, ncol, null, null);
                            e.Value = textbox.EditValue;
                            this.mSaleManager.ItemChanged(dr);
                            break;
                        case "QUANTITY":
                        case "UNIT_PRICE":
                        case "AMOUNT":
                        case "VAT_TAX_RATE":
                        case "VAT_TAX_AMOUNT":
                            this.mSaleManager.ColumnValueChanged(dr, ncol.FieldName.ToUpper());
                            this.mSaleManager.ColumnValueChanged(dr);
                            break;
                        default:
                            break;
                    }
                    this.UpdateBottom();
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            if (this.FTSMain.IsMultiOrganization) {
                this.palExtTop.Visible = true;
                this.txtOrganization.Visible = true;
                if (this.FTSMain.UserInfo.OrganizationID != string.Empty) {
                    this.txtOrganization.Enabled = false;
                } else {
                    this.txtOrganization.Enabled = true;
                }
            } else {
                this.palExtTop.Visible = false;
            }
        }

        private void Control_Leave(object sender, EventArgs e) {
            try {
                ((FTSNameIDCom) sender).ProcessMa();
                if (((FTSNameIDCom) sender).IsChanged) {
                    BindingManagerBase bm =
                        this.BindingContext[
                            this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName];
                    bm.EndCurrentEdit();
                    if (((FTSNameIDCom) sender).Name == this.txtPr_Detail_Id.Name) {
                        this.mSaleManager.PrDetailChanged();
                    }
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void Control_Lookup(object sender, EventArgs e) {

            try {
                ((FTSNameIDCom) sender).ProcessLookup();
                if (((FTSNameIDCom) sender).IsChanged) {
                    BindingManagerBase bm =
                        this.BindingContext[
                            this.mSaleManager.mSale.DataSet, this.mSaleManager.mSale.TableName];
                    bm.EndCurrentEdit();
                    if (((FTSNameIDCom) sender).Name == this.txtPr_Detail_Id.Name) {
                        this.mSaleManager.PrDetailChanged();
                    }
                }
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        public override void LayoutItems() {
            FlowLayout layout = new FlowLayout();
            layout.Alignment = FlowAlignment.Near;
            layout.TopMargin = 3;
            layout.BottomMargin = 3;
            layout.HorzNearMargin = 5;
            layout.VGap = 1;
            layout.HGap = 0;
            layout.ContainerControl = this.groupHeader;
            layout.AutoHeight = true;
            layout.AutoLayout = true;
            FlowLayout layout1 = new FlowLayout();
            layout1.Alignment = FlowAlignment.Near;
            layout1.TopMargin = 5;
            layout1.BottomMargin = 5;
            layout1.HorzNearMargin = 5;
            layout1.VGap = 1;
            layout1.HGap = 0;
            layout1.ContainerControl = this.groupPr_Detail;
            layout1.AutoHeight = true;
            layout1.AutoLayout = true;
            FlowLayout layout2 = new FlowLayout();
            layout2.Alignment = FlowAlignment.Near;
            layout2.TopMargin = 5;
            layout2.BottomMargin = 5;
            layout2.HorzNearMargin = 5;
            layout2.VGap = 1;
            layout2.HGap = 5;
            layout2.ContainerControl = this.groupVoucher;
            layout2.AutoHeight = true;
            layout2.AutoLayout = true;
        }

        public override Type GetFrmDicList(string tablename) {
            return GetTypeDic.GetTypeList(tablename);
        }

        public override void LoadFormFind() {
            if (this.FormFind == null) {
                this.FormFind = new FrmSale_Listing(this.FTSMain, this.mSaleManager, "SALE", this.mSaleManager.TranId, true);
            }
            this.FormFind.ShowDialog();
            if (this.FormFind.Ok) {
                this.mSaleManager.LoadRecordWithPrkey((Guid) this.FormFind.RetValue);
            }
        }

        public override void SetControls() {
            this.txtPr_Detail_Id.Set(this.FTSMain, this.ObjectManager.DataSet, "DM_PR_DETAIL", false);
            this.txtOrganization.Set(this.FTSMain, this.ObjectManager.DataSet, "DM_ORGANIZATION", false);
            this.txtTran_No.SetCase(true);
        }

        protected override DefaultValuesForm CreateDefaultValuesForm() {
            System.Collections.Hashtable DefaultHashTable = new System.Collections.Hashtable();
            DefaultHashTable.Add("PR_DETAIL_ID",
                                 new FTSLookUp(this.ObjectManager.DataSet.Tables["DM_PR_DETAIL"], "PR_DETAIL_NAME",
                                               "PR_DETAIL_ID"));
            return new DefaultValuesForm(this, this.FTSMain, this.ObjectManager.ObjectList[0].TableName, this.TranId, DefaultHashTable);
        }

        public override Type GetFrmDicEditList(string tablename) {
            return GetTypeDic.GetTypeEditList(tablename);
        }

        protected override void ShowCalculationForm() {
            (new FrmSys_Tran_Calculation_EditList(this.FTSMain, this.TranId, true)).ShowDialog();
        }

        protected override void ShowConfigForm() {
            (new FrmSys_Tran_Config_EditList(this.FTSMain, this.TranId, false)).Show();
        }

        private void cmdCopyLine_Click(object sender, EventArgs e) {
            try {
                this.NewDetail();
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }

        private void cmdDeleteLine_Click(object sender, EventArgs e) {
            try {
                this.DeleteDetail();
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            }
        }
    }
}