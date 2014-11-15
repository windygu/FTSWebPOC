#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Forms {
    public partial class DefaultValuesForm : XtraForm {
        private FTSMain mFTSMain;
        private DataTable mTableTranDefault;
        private Hashtable mHashDefault;
        private string mTranId = string.Empty;
        private string mTableName;

        private Form mParent;

        public DefaultValuesForm() {
            this.InitializeComponent();
        }

        public DefaultValuesForm(Form parent, FTSMain ftsMain, string tranid, Hashtable hashDefault) {
            this.mParent = parent;
            this.mFTSMain = ftsMain;
            this.mTranId = tranid;
            this.mHashDefault = hashDefault;
            this.InitializeComponent();
            this.LoadComboFieldName();
            this.LoadRepositoryItem();
            this.LoadData();
        }

        public DefaultValuesForm(Form parent, FTSMain ftsMain, string tablename, string tranid, Hashtable hashDefault) {
            this.mParent = parent;
            this.mFTSMain = ftsMain;
            this.mTranId = tranid;
            this.mTableName = tablename;
            this.mHashDefault = hashDefault;
            this.InitializeComponent();
            this.LoadComboFieldName();
            this.LoadRepositoryItem();
            this.LoadData();
        }

        private void LoadComboFieldName() {
            foreach (object key in this.mHashDefault.Keys) {
                this.cboFieldName.Items.Add(new ItemCombobox(key.ToString(), key.ToString()));
            }
        }

        private void LoadRepositoryItem() {
            ((ISupportInitialize) (this.grid)).BeginInit();
            foreach (object key in this.mHashDefault.Keys) {
                this.grid.RepositoryItems.Add((RepositoryItem) this.mHashDefault[key]);
            }
            ((ISupportInitialize) (this.grid)).EndInit();
        }

        private void LoadData() {
            this.mTableTranDefault = this.mFTSMain.TableManager.LoadTable("sys_tran_default",
                                                                          "tran_id='" + this.mTranId + "' AND ORGANIZATION_ID='" + this.mFTSMain.UserInfo.OrganizationID + "'");
            this.grid.DataSource = this.mTableTranDefault;
        }

        private void UpdateData() {
            this.EndEdit();
            this.mFTSMain.DbMain.UpdateTable(this.mTableTranDefault,
                                             this.mFTSMain.DbMain.CreateInsertCommand("sys_tran_default",
                                                                                      this.mTableTranDefault),
                                             this.mFTSMain.DbMain.CreateUpdateCommand("sys_tran_default",
                                                                                      this.mTableTranDefault,
                                                                                      "tran_id,field_name,organization_id"),
                                             this.mFTSMain.DbMain.CreateDeleteCommand("sys_tran_default",
                                                                                      this.mTableTranDefault,
                                                                                      "tran_id,field_name,organization_id"),
                                             UpdateBehavior.Standard);
        }

        private void NewValue() {
            decimal pr_key = FunctionsBase.GetPr_key("SYS_TRAN_DEFAULT", this.mFTSMain);
            this.mTableTranDefault.Rows.Add(new object[] {pr_key, this.mTableName.ToUpper(), this.mTranId, "", "", this.mFTSMain.UserInfo.OrganizationID});
            BindingManagerBase bm = this.grid.BindingContext[this.grid.DataSource];
            if (bm.Count > 0) {
                bm.Position = bm.Count - 1;
            }
        }

        private void DeleteValue() {
            if (this.view.FocusedRowHandle >= 0) {
                DataRow row = this.view.GetDataRow(this.view.FocusedRowHandle);
                if ((row != null) && (row.RowState != DataRowState.Deleted)) {
                    row.Delete();
                }
            }
        }

        private void EndEdit() {
            try {
                ColumnView vw = (ColumnView) this.grid.FocusedView;
                vw.CloseEditor();
                vw.UpdateCurrentRow();
                foreach (DataRow row in this.mTableTranDefault.Rows) {
                    row.EndEdit();
                }
            } catch (Exception) {
            }
        }

        public void ShowDefaultValues(Point location) {
            if (location.X == -10000) {
                location =
                    this.mParent.PointToScreen(new Point(this.mParent.ClientRectangle.Right,
                                                         this.mParent.ClientRectangle.Bottom));
                location.Offset(-this.Size.Width, -this.Size.Height);
                location = ControlUtils.CalcLocation(location, location, this.Size);
            }
            if (location.X < 0) {
                location.X = 0;
            }
            if (location.Y < 0) {
                location.Y = 0;
            }
            this.Location = location;
            this.Visible = true;
            this.mParent.Focus();
        }

        private void toolbar_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                switch (e.Name) {
                    case "New":
                        this.NewValue();
                        break;
                    case "Save":
                        this.UpdateData();
                        break;
                    case "Delete":
                        this.DeleteValue();
                        break;
                    case "Close":
                        this.Close();
                        break;
                    default:
                        break;
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        private void view_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            try {
                DataRow row = this.view.GetDataRow(e.RowHandle);
                if ((row != null) && (e.Column.FieldName != "FIELD_NAME")) {
                    e.RepositoryItem = ((RepositoryItem) this.mHashDefault[row["FIELD_NAME"].ToString().Trim()]);
                }
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }
    }

    public sealed class FTSLookUp : RepositoryItemLookUpEdit {
        public FTSLookUp(object filltable, string display, string bound) : base() {
            this.AutoHeight = false;
            this.ShowHeader = false;
            this.ShowFooter = false;
            this.HeaderClickMode = HeaderClickMode.AutoSearch;
            this.AllowNullInput = DefaultBoolean.True;
            this.NullText = string.Empty;
            this.TextEditStyle = TextEditStyles.Standard;
            this.DataSource = filltable;
            this.DisplayMember = display;
            this.ValueMember = bound;
            this.Columns.Clear();
            this.Columns.Add(new LookUpColumnInfo(display, string.Empty, 240));
            this.PopupWidth = 240;
            this.DropDownRows = 10;
            this.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Near;
        }
    }

    public sealed class FTSComboBox : RepositoryItemComboBox {
        public FTSComboBox(List<ItemCombobox> items) : base() {
            this.AutoHeight = false;
            this.AllowNullInput = DefaultBoolean.True;
            this.NullText = string.Empty;
            this.TextEditStyle = TextEditStyles.Standard;
            foreach (ItemCombobox item in items) {
                this.Items.Add(new ComboBoxItem(new ItemCombobox(item.Name, item.Id)));
                ;
            }
            this.DropDownRows = 10;
        }
    }

    public class FTSTextBox : RepositoryItemTextEdit {
        public FTSTextBox() : base() {
        }
    }

    public sealed class FTSNumber : RepositoryItemTextEdit {
        public FTSNumber(int decimalplaces) : base() {
            this.BeginInit();
            this.AutoHeight = false;
            this.DisplayFormat.FormatString = "n" + decimalplaces;
            this.DisplayFormat.FormatType = FormatType.Numeric;
            this.EditFormat.FormatString = "n" + decimalplaces;
            this.EditFormat.FormatType = FormatType.Numeric;
            this.Mask.EditMask = "n" + decimalplaces;
            this.Mask.MaskType = MaskType.Numeric;
            this.EndInit();
            this.ContextMenu = null;
        }
    }
}