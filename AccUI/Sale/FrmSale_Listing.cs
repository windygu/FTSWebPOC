using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using FTS.AccBusiness.Sale;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Layout;
using FTS.ShareUI.Common;

namespace FTS.AccUI.Sale {
    public partial class FrmSale_Listing : FrmBase2Listing {
        private string mTran_sub_class = string.Empty;

        public FrmSale_Listing(FTSMain ftsmain, SaleManager mSaleManager, string tran_class,
                               string tran_id, bool Dialog)
            : base(ftsmain, mSaleManager, tran_class, tran_id, Dialog) {
            string tran = this.Tran_Id;
            this.InitializeComponent();
            this.TableName = "SALE_VIEW";
            if (!String.IsNullOrEmpty(tran_id)) {
                this.Name = this.Name.ToUpper() + "_" + tran_id;
            } else {
                if (!String.IsNullOrEmpty(this.mTran_sub_class)) {
                    this.Name = this.Name.ToUpper() + "_" + this.mTran_sub_class;
                }
            }
            this.LoadData();
            this.LoadFields();
            this.BindGrid();
            this.ConfigGrid();
            this.LoadLayout();
            this.SetControls();
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("AUTO_DATA_LISTING")) {
                this.Filter();
            }
        }

        public override void LoadLayout(FTSMain ftsmain) {
            base.LoadLayout(ftsmain);
            if (this.Tran_Id == string.Empty || this.Mode == FindMode.FIND) {
                this.toolbar.NewVisible = BarItemVisibility.Never;
            } else {
                this.toolbar.NewVisible = BarItemVisibility.Always;
            }
        }

        public override void LoadFields() {
            this.FieldCollection = new System.Collections.Generic.List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY_CTU", DbType.Currency, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_NO", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TRAN_DATE", DbType.Date, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_DETAIL_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "COMMENTS", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "FR_KEY", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LIST_ORDER", DbType.Int16, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_ID", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ITEM_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "QUANTITY", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "UNIT_PRICE", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "AMOUNT", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAT_TAX_RATE", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAT_TAX_AMOUNT", DbType.Currency, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TOTAL_AMOUNT", DbType.Currency, false));
        }

        public override void BindGrid() {
            this.grid.CreateGrid(this.DataSet, this.DataTable, this.TableName);
            this.grid.SetNumberColumn(this.GetFieldInfo("PR_KEY_CTU"), 0);
            this.grid.SetTextColumn(this.GetFieldInfo("TRAN_ID"), true);
            this.grid.SetDateColumn(this.GetFieldInfo("TRAN_DATE"));
            this.grid.SetTextColumn(this.GetFieldInfo("TRAN_NO"), true);
            this.grid.SetTextColumn(this.GetFieldInfo("PR_DETAIL_ID"), true);
            this.grid.SetTextColumn(this.GetFieldInfo("ORGANIZATION_ID"), true);
            this.grid.SetTextColumn(this.GetFieldInfo("COMMENTS"), true);
            this.grid.SetNumberColumn(this.GetFieldInfo("PR_KEY"), 0);
            this.grid.SetNumberColumn(this.GetFieldInfo("FR_KEY"), 0);
            this.grid.SetNumberColumn(this.GetFieldInfo("LIST_ORDER"), 0);
            this.grid.SetTextColumn(this.GetFieldInfo("ITEM_ID"), true);
            this.grid.SetTextColumn(this.GetFieldInfo("ITEM_NAME"), false);
            this.grid.SetNumberColumn(this.GetFieldInfo("QUANTITY"), this.FTSMain.TPDGVND);
            this.grid.SetNumberColumn(this.GetFieldInfo("UNIT_PRICE"), this.FTSMain.TPDGVND);
            this.grid.SetNumberColumn(this.GetFieldInfo("AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.GetFieldInfo("VAT_TAX_RATE"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.GetFieldInfo("VAT_TAX_AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.SetNumberColumn(this.GetFieldInfo("TOTAL_AMOUNT"), this.FTSMain.TPSTVND);
            this.grid.BindData();
            this.grid.ViewGrid.UpdateSummary();
        }

        public void SetControls() {
            ArrayList list = ReportPeriod.LoadReportPeriod(this.FTSMain, true);
            this.cboDataPeriod.Set(list);
            this.cboDataPeriod.ComboBox.SelectedIndex = 0;
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("DISPLAY_DATA_BY_YEAR")) {
                this.txtDay_Start.DateTime.EditValue = this.FTSMain.DayStartOfCurrentYear;
                this.txtDay_End.DateTime.EditValue = this.FTSMain.DayEndOfCurrentYear;
            } else {
                this.txtDay_Start.DateTime.EditValue = Functions.DayStartOfMonth(DateTime.Today.Month,
                                                                                 DateTime.Today.Year);
                this.txtDay_End.DateTime.EditValue = Functions.DayEndOfMonth(DateTime.Today.Month, DateTime.Today.Year);
            }
        }

        public override void Filter() {
            this.DataTable.Clear();
            string filter = "1=1";
            this.SqlQuery = "select * from " + this.TableName + " where tran_date >= " +
                            Functions.ParseDate((DateTime) this.txtDay_Start.DateTime.EditValue) + " and tran_date <= " +
                            Functions.ParseDate((DateTime) this.txtDay_End.DateTime.EditValue) +
                            " and " + filter;
            if (this.FTSMain.IsMultiOrganization && this.FTSMain.UserInfo.OrganizationID != string.Empty) {
                this.SqlQuery += " AND " +
                                 Dm_Organization.GetOrganizationFilter(this.FTSMain,
                                                                       this.DataSet.Tables["DM_ORGANIZATION"]);
            }
            if (this.Tran_Id != string.Empty) {
                this.SqlQuery += " and tran_id='" + this.Tran_Id + "'";
            }
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(this.SqlQuery), this.DataSet,
                                            this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
            this.grid.ViewGrid.UpdateSummary();
        }

        public override void LoadData() {
            this.DataSet = new DataSet();
            this.SqlQuery = "select * from " + this.TableName + " where 1=0";
            this.SqlQuery += " and " + this.FTSMain.IdManager.Filter(this.TableName, this.FTSMain.UserInfo.OrganizationID);
            this.FTSMain.DbMain.LoadDataSet(this.FTSMain.DbMain.GetSqlStringCommand(this.SqlQuery), this.DataSet,
                                            this.TableName);
            this.DataTable = this.DataSet.Tables[this.TableName];
        }

        private void RefreshList(object sender, RefreshListEventArgs e) {
            try {
                this.RefreshList(e);
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
            }
        }

        public override void LoadTransaction(string tranid, object key) {
            FrmSale frm = new FrmSale(this.FTSMain, this.Tran_Id, (Guid) key);
            frm.RefreshList += new RefreshListHandler(this.RefreshList);
            frm.MdiParent = null;
            frm.UpdateInfo();
            frm.ShowDialog();
        }

        public override void NewTransaction() {
            if (this.Tran_Id != string.Empty) {
                FrmSale frm = new FrmSale(this.FTSMain,this.Tran_Id);
                frm.RefreshList += new RefreshListHandler(this.RefreshList);
                frm.MdiParent = null;
                frm.NewRecord();
                frm.ShowDialog();
            }
        }

        protected override void OnActivated(EventArgs e) {
            if ((bool) this.FTSMain.SystemVars.GetSystemVars("AUTO_DATA_LISTING")) {
                this.Filter();
            }
        }

        public override void DeleteTransaction(string tranid, object key) {
            if (FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(this.FTSMain.MsgManager.GetMessage("MSG_DELETE_TRANSACTION_CONFIRM")) ==
                DialogResult.Yes) {
                SaleManager objectManager = new SaleManager(this.FTSMain, tranid);
                objectManager.LoadRecordWithPrkey(key);
                if (objectManager.ObjectList[0].DataTable.Rows.Count > 0) {
                    objectManager.DeleteData();
                    this.Filter();
                }
                objectManager.Dispose();
                objectManager = null;
            }
        }

        public override Type GetFrmDicList(string tablename) {
            return GetTypeDic.GetTypeList(tablename);
        }

        private void cboDataPeriod_ComboChange(object sender, ComboChangedEventArgs e) {
            try {
                if (this.cboDataPeriod != null && this.cboDataPeriod.ComboBox.SelectedIndex >= 0) {
                    ReportPeriod kybaocao = (ReportPeriod) this.cboDataPeriod.ComboBox.SelectedItem;
                    this.txtDay_Start.DateTime.EditValue = kybaocao.DayStart;
                    this.txtDay_End.DateTime.EditValue = kybaocao.DayEnd;
                    if ((bool) this.FTSMain.SystemVars.GetSystemVars("AUTO_DATA_LISTING")) {
                        this.Filter();
                    }
                }
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
            }
        }

        public override void SetTextFooter() {
            try {
                string columnname = this.grid.CurrentColumnName.ToUpper();
                string cellvalue = this.grid.CurrentCellValue.ToString();
                switch (columnname) {
                    case "ORGANIZATION_ID":
                        this.grid.SetTextFooter(
                            this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_ORGANIZATION"], "DM_ORGANIZATION",
                                                                        cellvalue));
                        break;
                    case "PR_DETAIL_ID":
                        this.grid.SetTextFooter(
                            this.FTSMain.TableManager.GetNameFieldValue(this.DataSet.Tables["DM_PR_DETAIL"],
                                                                        "DM_PR_DETAIL", cellvalue));
                        break;
                    default:
                        this.grid.SetTextFooter(string.Empty);
                        break;
                }
                this.grid.Refresh();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
            }
        }

        private void cmdFind_Click(object sender, EventArgs e) {
            try {
                this.Filter();
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex);
            } catch (Exception ex1) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain, ex1);
            }
        }

        public override void LayoutItems() {
            FlowLayout layout2 = new FlowLayout();
            layout2.Alignment = FlowAlignment.Near;
            layout2.TopMargin = 3;
            layout2.BottomMargin = 3;
            layout2.HorzNearMargin = 5;
            layout2.VGap = 1;
            layout2.HGap = 0;
            layout2.ContainerControl = this.groupBox;
            layout2.AutoHeight = true;
            layout2.AutoLayout = true;
            FlowLayout layout3 = new FlowLayout();
            layout3.Alignment = FlowAlignment.Near;
            layout3.TopMargin = 3;
            layout3.BottomMargin = 3;
            layout3.HorzNearMargin = 5;
            layout3.VGap = 1;
            layout3.HGap = 3;
            layout3.ContainerControl = this.groupControl;
            layout3.AutoHeight = true;
            layout3.AutoLayout = true;
        }
    }
}