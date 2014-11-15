// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/29/2006
// Time:                      15:50
// Project Name:              POSUI
// Project Filename:          POSUI.csproj
// Project Item Name:         StartProcedures.cs
// Project Item Filename:     StartProcedures.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Data;
using System.Data.Common;
using FTS.AccUI.Sale;
using FTS.BaseBusiness.Systems;
using FTS.BaseUI.Business;
using FTS.ShareUI.Acc;

#endregion

namespace FTS.AccUI.Systems {
    /// <summary>
    /// Summary description for StartProcedures.
    /// </summary>
    public class AccStartProcedures : StartProcedures {
        private FTSMain mFTSMain;

        public AccStartProcedures(FTSMain mFTSMain) {
            this.mFTSMain = mFTSMain;
        }

        public override bool ExecuteProcedures(string menu_id) {
            try {
                switch (menu_id) {
                        #region Danh muc

                    case "DM_ITEM":
                        (new FrmDm_Item_List(this.mFTSMain)).Show();
                        break;
                    case "DM_PR_DETAIL":
                        (new FrmDm_Pr_Detail_List(this.mFTSMain)).Show();
                        break;
                    case "DM_ORGANIZATION":
                        (new FrmDm_Organization_TreeList(this.mFTSMain)).Show();
                        break;
                    case "DM_UNIT":
                        (new FrmDm_Unit_List(this.mFTSMain)).Show();
                        break;
                    case "SALE_PRICE":
                        (new FrmSale_Price_EditList(this.mFTSMain)).Show();
                        break;
                        #endregion Danh muc

                    default:
                        return false;
                }
                return true;
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
            return true;
        }

        public void LoadTransaction(string tranid) {
            string sql = "select TRAN_CLASS FROM SYS_TRAN where TRAN_ID=N'" + tranid + "'";
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            object parentid = this.mFTSMain.DbMain.ExecuteScalar(cmd);
            if (parentid != null && parentid != DBNull.Value) {
                switch (parentid.ToString()) {
                    case "SALE":
                        (new FrmSale(this.mFTSMain, string.Empty, tranid)).Show();
                        break;
                }
            }
        }

        public override bool LoadReport(string reportid) {
            string sql = "select PARENT_ID FROM sys_report where REPORT_ID=" +
                         this.mFTSMain.BuildParameterName("REPORT_ID");
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, "REPORT_ID", DbType.String, reportid);
            object parentid = this.mFTSMain.DbMain.ExecuteScalar(cmd);
            if (parentid != null && parentid != DBNull.Value) {
                return this.LoadReport(reportid, parentid.ToString());
            }
            return false;
        }

        public override bool LoadReport(string reportid, string parentid) {
            try {
                switch (parentid.Trim().ToUpper()) {
                    default:
                        return false;
                }
                return true;
            } catch (FTSException ex) {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain, ex);
            }
            return true;
        }

        public override bool RunTransaction(string tranid) {
            DataTable sys_tran = this.mFTSMain.TableManager.LoadTable("SYS_TRAN", "TRAN_ID,TRAN_CLASS,IS_LISTING", "1=1");
            DataRow foundrow = sys_tran.Rows.Find(tranid);
            bool showlisting = false;
            if (foundrow != null) {
                if ((Int16) foundrow["IS_LISTING"] == 1) {
                    showlisting = true;
                }
                switch (foundrow["TRAN_CLASS"].ToString()) {
                    case "SALE":
                        if (showlisting) {
                            (new FrmSale_Listing(this.mFTSMain, null, "SALE", tranid, false)).Show();
                        } else {
                            FrmSale frm = new FrmSale(this.mFTSMain, tranid);
                            frm.Show();
                            frm.UpdateInfo();
                        }
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}