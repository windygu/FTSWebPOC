using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.ShareBusiness.Acc;

namespace FTS.AccBusiness.Sale {
    [Serializable]
    public class SaleManager : ManagerBase {
        public Sale mSale;
        public Sale_Detail mSale_Detail;
        [NonSerialized] public WarehouseManager warehouseManager;
        [NonSerialized]
        public Sale_Price mSalePrice;

        public SaleManager(FTSMain ftsmain, string tran_id)
            : base(ftsmain, tran_id) {
            this.IsOrganizationFilter = true;
            this.LoadDm();
            this.mSale = new Sale(ftsmain, this.DataSet, this.TranId, this);
                this.mSale.LoadDefaultValue(this.TranId);
            this.mSale_Detail = new Sale_Detail(ftsmain, this.DataSet, this);
            this.mSale_Detail.LoadDefaultValue(this.TranId, this.mSale.TableName);
            this.ObjectList.Add(this.mSale);
            this.ObjectList.Add(this.mSale_Detail);
            this.TranDateField = "tran_date";
            this.TranNoField = "tran_no";
            this.TranIdField = "tran_id";
        }

        public override void ChangeTranId() {
            if (this.mSale != null) {
                this.mSale.TranId = this.TranId;
                this.mSale.LoadDefaultValue(this.TranId);
                this.LoadConfigValue();
            }
        }

        public override void LoadDm(string tablename) {
            switch (tablename.ToUpper()) {
                case "DM_ITEM":
                    if (this.DataSet.Tables.IndexOf("DM_ITEM") < 0) {
                        this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ITEM", "*", "ACTIVE = 1");
                    }
                    break;
                case "DM_PR_DETAIL":
                    if (this.DataSet.Tables.IndexOf("DM_PR_DETAIL") < 0) {
                        this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_PR_DETAIL", "ACTIVE = 1");
                    }
                    break;
                case "DM_ORGANIZATION":
                    if (this.DataSet.Tables.IndexOf("DM_ORGANIZATION") < 0) {
                        this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID", "1=1");
                    }
                    break;
                case "SYS_TRAN_CALCULATION":
                    if (this.DataSet.Tables.IndexOf("SYS_TRAN_CALCULATION") < 0) {
                        this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN_CALCULATION", "FIELD_ID,FORMULA", "TRAN_ID='" + this.TranId + "' and ACTIVE=1");
                    }
                    break;
                case "SYS_TRAN":
                    if (this.DataSet.Tables.IndexOf("SYS_TRAN") < 0) {
                        this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN", "TRAN_ID,TRAN_CLASS,TRAN_SUB_CLASS", "ACTIVE=1");
                    }
                    break;
                default:
                    break;
            }
        }

        public override void RefreshDm() {
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ITEM", "ACTIVE = 1");
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_PR_DETAIL", "ACTIVE = 1");
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION",
                                                "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID", "1=1");
            this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN_CALCULATION", "FIELD_ID,FORMULA",
                                                "TRAN_ID='" + this.TranId + "' and ACTIVE=1");
            this.FTSMain.TableManager.LoadTable(this.DataSet, "SYS_TRAN", "TRAN_ID,TRAN_CLASS,TRAN_SUB_CLASS",
                                                "ACTIVE=1");
        }

        public void ColumnValueChanged(DataRow row, string fieldName) {
            if (this.mSale.DataTable.Rows.Count == 0) {
                return;
            }
            ArrayList list = new ArrayList();
            DataTable calc = this.GetDm("SYS_TRAN_CALCULATION");
            DataView dv = new DataView(calc, "FORMULA LIKE '*." + fieldName.ToUpper().Trim() + ".*'", string.Empty, DataViewRowState.CurrentRows);
            foreach (DataRowView drv in dv) {
                list.Add(drv["FIELD_ID"].ToString().Trim());
                DataColumn c = new DataColumn("CALCULATION", Type.GetType("System.Decimal"), drv["formula"].ToString().Replace(".", string.Empty).Replace(":", ".").Replace("SYSTEM.INT32", "System.Int32"));
                this.mSale_Detail.DataTable.Columns.Add(c);
                this.SetFieldValue(row, drv["FIELD_ID"].ToString().Trim(), row["calculation"]);
                row.EndEdit();
                this.mSale_Detail.DataTable.Columns.Remove(c);
            }
            foreach (object oj in list) {
                this.ColumnValueChanged(row, oj.ToString());
            }
        }

        public void ColumnValueChanged(string fieldName) {
            foreach (DataRow row in this.mSale_Detail.DataTable.Rows) {
                if (this.mSale_Detail.IsValidRow(row)) {
                    this.ColumnValueChanged(row, fieldName);
                }
            }
        }

        public void ColumnValueChanged() {
        }

        public void ColumnValueChanged(DataRow row) {
        }

        private void SetFieldValue(DataRow row, string fieldname, object value) {
            switch (fieldname.ToUpper()) {
                default:
                    row[fieldname] = value;
                    break;
            }
        }

        private void CreateWarehouse() {
            DataRow cturow = this.mSale.DataTable.Rows[0];
            if (cturow.RowState != DataRowState.Deleted) {
                if (cturow.RowState != DataRowState.Deleted) {
                    if (cturow["STATUS"].ToString() == FTSTransactionStatus.DRAFT) {
                    } else {
                        this.warehouseManager.WarehouseObjectList.Clear();
                        foreach (DataRow row in this.mSale_Detail.DataTable.Rows) {
                            if (row.RowState != DataRowState.Deleted) {
                                WarehouseObject warehouseobject = new WarehouseObject();
                                warehouseobject.Pr_Key_Warehouse = Guid.NewGuid();
                                warehouseobject.Pr_Key = (Guid) cturow["PR_KEY"];
                                warehouseobject.Pr_Key_Detail = (Guid) row["pr_key"];
                                warehouseobject.Tran_Id = (string) cturow["TRAN_ID"];
                                warehouseobject.Tran_Date = Convert.ToDateTime(cturow["TRAN_DATE"]);
                                warehouseobject.Tran_No = (string) cturow["TRAN_NO"];
                                warehouseobject.Organization_Id = (string) cturow["ORGANIZATION_ID"];
                                warehouseobject.Comments = (string) cturow["COMMENTS"];
                                warehouseobject.Item_Id = (string) row["Item_Id"];
                                warehouseobject.Quantity = (decimal) row["Quantity"];
                                warehouseobject.Issue_Receive = IssueReceive.RECEIVE;
                                this.warehouseManager.Add(warehouseobject.Copy());
                            }
                        }
                        this.warehouseManager.CheckBusinessRules(null);
                    }
                }
            }
        }

        private void UpdateWarehouse(DbTransaction tran) {
            DataRow cturow = this.mSale.DataTable.Rows[0];
            DataView dv;
            if (this.warehouseManager == null) {
                this.warehouseManager = new WarehouseManager(this.FTSMain);
                this.warehouseManager.HasCheckBusinessRules = true;
            }
            if (cturow.RowState != DataRowState.Deleted) {
                foreach (DataRow row in this.mSale_Detail.DataTable.Rows) {
                    if (row.RowState != DataRowState.Deleted) {
                        if (cturow.RowState != DataRowState.Deleted) {
                            if (cturow["STATUS"].ToString() == FTSTransactionStatus.DRAFT) {
                                if (cturow.RowState != DataRowState.Added) {
                                    this.warehouseManager.RemoveAll((string) cturow["Tran_ID"], cturow["pr_key"], tran);
                                }
                            }
                        }
                    }
                }
                this.warehouseManager.RemoveAll((string) cturow["Tran_ID"], (Guid) cturow["pr_key"], tran);
                this.warehouseManager.Update(tran);
            } else {
                this.warehouseManager.RemoveAll((string) cturow["Tran_ID", DataRowVersion.Original],
                                                (Guid) cturow["pr_key", DataRowVersion.Original], tran);
            }
        }

        public override void UpdateData() {
            if ((this.FTSMain.Pfs != null) && (this.FTSMain.Pfs.Ready) && (!this.FTSMain.AtPfs) && this.FTSMain.ISDEV == false) {
                this.PrepareUpdateData();
                this.mHasCheckedRules = true;
                base.UpdateDataServer();
                this.mHasCheckedRules = false;
            } else {
                if (this.DataLog == null && this.FTSMain.IsMultiSite) {
                    this.DataLog =
                        this.FTSMain.DbMain.LoadDataTable(
                            this.FTSMain.DbMain.GetSqlStringCommand("SELECT * FROM DATA_LOG WHERE 1=0"), "DATA_LOG");
                }
                if (this.warehouseManager == null) {
                    this.warehouseManager = new WarehouseManager(this.FTSMain);
                    this.warehouseManager.HasCheckBusinessRules = true;
                }
                DataTable dt = this.mSale.DataTable.Copy();
                base.UpdateData();
                this.DoLogging(dt);
            }
        }

        protected override void CreateOtherData() {
            this.CreateWarehouse();
        }

        protected override void UpdateOtherData(DbTransaction tran) {
            this.UpdateWarehouse(tran);
        }

        private void DoLogging(DataTable dt) {
            if (!this.IsLogging) {
                return;
            }
            if (dt.Rows.Count > 0) {
                DataRow row = dt.Rows[0];
                if (row.RowState != DataRowState.Deleted) {
                    if (row.RowState == DataRowState.Added) {
                        Logging.Log(this.FTSMain, ActionType.ADD,
                                    row["TRAN_ID"].ToString() + "," + row["TRAN_DATE"] + "," + row["TRAN_NO"]);
                    } else {
                        Logging.Log(this.FTSMain, ActionType.EDIT,
                                    row["TRAN_ID"].ToString() + "," + row["TRAN_DATE"] + "," + row["TRAN_NO"]);
                    }
                } else {
                    Logging.Log(this.FTSMain, ActionType.DELETE,
                                row["TRAN_ID", DataRowVersion.Original].ToString() + "," +
                                row["TRAN_DATE", DataRowVersion.Original] + "," +
                                row["TRAN_NO", DataRowVersion.Original]);
                }
            }
        }

        protected override void InsertDefaultConfigs() {
            this.InsertConfigValue("AUTO_TRAN_NO", "BOOLEAN", true);
            this.InsertConfigValue("TRAN_NO_BY_ORGANIZATION", "BOOLEAN", true);
        }

        public override void CheckBusinessRules() {
            base.CheckBusinessRules();
        }

        public void ItemChanged(DataRow row) {
            if (this.mSale.IsValidRow(0)) {
                DataRow foundrow = this.GetDm("DM_ITEM").Rows.Find(row["ITEM_ID"]);
                if (foundrow != null) {
                    row["ITEM_NAME"] = foundrow["ITEM_NAME"];
                    if (this.mSalePrice == null) {
                        this.mSalePrice = new Sale_Price(this.FTSMain);
                        row["UNIT_PRICE"] = this.mSalePrice.GetSalePrice(row["ITEM_ID"].ToString(), (DateTime) this.mSale.DataTable.Rows[0]["TRAN_DATE"]);
                        this.ColumnValueChanged(row, "UNIT_PRICE");
                    }

                }
            }
        }
        public void PrDetailChanged() {
            if (this.mSale.IsValidRow(0)) {
                DataRow foundrow = this.GetDm("DM_PR_DETAIL").Rows.Find(this.mSale.GetValue(0,"PR_DETAIL_ID"));
                if (foundrow != null) {
                    this.mSale.DataTable.Rows[0]["ADDRESS"] = foundrow["ADDRESS"];
                    this.mSale.DataTable.Rows[0]["TAX_FILE_NUMBER"] = foundrow["TAX_FILE_NUMBER"];
                }
            }
        }
    }
}