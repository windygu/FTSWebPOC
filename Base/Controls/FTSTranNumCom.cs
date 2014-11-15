#region

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSTranNumCom : Panel, IRequire, IValid, IHelpField {
        private bool mIsChanged = false;
        private bool mRequire = false;
        private string mTran_Id = string.Empty;
        private string mTableName = string.Empty;
        private string mTran_Date_Field = string.Empty;
        private string mTran_No_Temp = string.Empty;
        private string mTran_Id_Field = string.Empty;
        private FTSMain mFTSMain;
        private string mPrefix = string.Empty;
        private string mPrefix_Ext = string.Empty;
        private string mPrefix_Sep = string.Empty;
        private string mMask_Number = string.Empty;
        private string mMask_Type = string.Empty;
        private string mSuffix = string.Empty;
        private string mSuffix_Ext = string.Empty;
        private string mSuffix_Sep = string.Empty;
        private bool mAuto = true;

        public FTSTranNumCom() {
            this.InitializeComponent();
            this.SetProperty();
        }

        protected override void OnGotFocus(EventArgs e) {
            this.textEdit.Focus();
        }

        [DefaultValue(false), Browsable(false)]
        public bool Require {
            get { return this.mRequire; }
            set {
                this.mRequire = value;
                if (this.mRequire) {
                    this.textEdit.BackColor = SystemColors.Info;
                } else {
                    this.textEdit.BackColor = Color.White;
                }
            }
        }

        [DefaultValue(80)]
        public int LabelLength {
            get { return this.label.Width; }
            set { this.label.Width = value; }
        }

        public string LabelText {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [DefaultValue(false)]
        public bool IsChanged {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }

        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [Browsable(false)]
        public TextEdit Textbox {
            get { return this.textEdit; }
            set { this.textEdit = value; }
        }

        public CharacterCasing CharacterCasing {
            get { return this.textEdit.Properties.CharacterCasing; }
            set { this.textEdit.Properties.CharacterCasing = value; }
        }

        [Browsable(false)]
        public LabelControl TranNoTemp {
            get { return this.lblTranNoTemp; }
        }

        [Browsable(false), DefaultValue("")]
        public string TranId {
            get { return this.mTran_Id; }
            set {
                this.mTran_Id = value;
                this.LoadFormat();
            }
        }

        public void SetTextLength(FieldInfo field) {
            this.textEdit.Properties.MaxLength = field.MaxLength;
        }

        public void SetTextLength(int length) {
            this.textEdit.Properties.MaxLength = length;
        }

        public void SetCase(bool isupper) {
            if (isupper) {
                this.textEdit.Properties.CharacterCasing = CharacterCasing.Upper;
            } else {
                this.textEdit.Properties.CharacterCasing = CharacterCasing.Lower;
            }
        }

        public void Set(FTSMain ftsMain, string tableName, string tran_id, string tran_id_field, string tran_date_field,
                        string tran_no_temp) {
            this.mFTSMain = ftsMain;
            this.mTableName = tableName;
            this.mTran_Id = tran_id;
            this.mTran_Id_Field = tran_id_field;
            this.mTran_Date_Field = tran_date_field;
            this.mTran_No_Temp = tran_no_temp;
            this.LoadFormat();
            this.CreateMask();
        }

        private void LoadFormat() {
            string sql =
                "select prefix, prefix_ext, prefix_sep, mask_number, mask_type, suffix, suffix_ext, suffix_sep, auto from sys_tran where tran_id=" +
                this.mFTSMain.BuildParameterName("tran_id");
            DbCommand cmd = this.mFTSMain.DbMain.GetSqlStringCommand(sql);
            this.mFTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.mTran_Id.Trim().ToUpper());
            if (this.mFTSMain.DbMain.WorkingMode == WorkingMode.LAN) {
                IDataReader reader = this.mFTSMain.DbMain.ExecuteReader(cmd);
                if (reader.Read()) {
                    this.mPrefix = reader["prefix"].ToString();
                    this.mPrefix_Ext = reader["prefix_ext"].ToString();
                    this.mPrefix_Sep = reader["prefix_sep"].ToString();
                    this.mMask_Number = reader["mask_number"].ToString();
                    this.mMask_Type = reader["mask_type"].ToString();
                    this.mSuffix = reader["suffix"].ToString();
                    this.mSuffix_Ext = reader["suffix_ext"].ToString();
                    this.mSuffix_Sep = reader["suffix_sep"].ToString();
                    this.mAuto = Convert.ToBoolean(reader["auto"]);
                    reader.Close();
                }
            } else {
                DataTable dt = this.mFTSMain.DbMain.LoadDataTable(cmd, "sys_tran");
                if (dt.Rows.Count > 0) {
                    this.mPrefix = dt.Rows[0]["prefix"].ToString();
                    this.mPrefix_Ext = dt.Rows[0]["prefix_ext"].ToString();
                    this.mPrefix_Sep = dt.Rows[0]["prefix_sep"].ToString();
                    this.mMask_Number = dt.Rows[0]["mask_number"].ToString();
                    this.mMask_Type = dt.Rows[0]["mask_type"].ToString();
                    this.mSuffix = dt.Rows[0]["suffix"].ToString();
                    this.mSuffix_Ext = dt.Rows[0]["suffix_ext"].ToString();
                    this.mSuffix_Sep = dt.Rows[0]["suffix_sep"].ToString();
                    this.mAuto = Convert.ToBoolean(dt.Rows[0]["auto"]);
                }
            }
        }

        private void CreateMask() {
        }

        private string GetNumber(int number) {
            string temp = string.Empty;
            int lenght = this.mMask_Number.Trim().Length;
            if (lenght > 0) {
                temp = "1";
            }
            for (int i = 1; i <= lenght; i++) {
                temp = temp + "0";
            }
            int num = Convert.ToInt32(temp) + number;
            if (num >= 10) {
                return num.ToString().Substring(1);
            } else {
                return num.ToString();
            }
        }

        public void EndEdit() {
            string result = this.mPrefix + this.GetExt(this.mPrefix_Ext, this.mFTSMain.WorkingDay) + this.mPrefix_Sep;
            if (this.mAuto) {
                result = result + this.GetTranNumber();
            } else {
                result = result + this.textEdit.EditValue.ToString().Trim();
            }
            result = result + this.mSuffix_Sep + this.mSuffix + this.GetExt(this.mSuffix_Ext, this.mFTSMain.WorkingDay);
            this.textEdit.EditValue = result.Trim();
            if (this.textEdit.DataBindings.Count > 0) {
                this.textEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }

        private string GetTranNumber() {
            DateTime begin = this.mFTSMain.WorkingDay;
            DateTime end = this.mFTSMain.WorkingDay;
            this.GetDateGap(this.mMask_Type, this.mFTSMain.WorkingDay, ref begin, ref end);
            string sql = "select max(" + this.mTran_No_Temp + ") from " + this.mTableName + " where " +
                         this.mTran_Date_Field + " > " + Functions.ParseDate(begin) + " and " + this.mTran_Date_Field +
                         " < " + Functions.ParseDate(end) + " and " + this.mTran_Id_Field + " ='" + this.mTran_Id + "'";
            object number = null;
            number = this.mFTSMain.DbMain.ExecuteScalar(this.mFTSMain.DbMain.GetSqlStringCommand(sql));
            if (number != DBNull.Value) {
                this.lblTranNoTemp.Text = Convert.ToString((Convert.ToInt32(number) + 1));
                return this.GetNumber(Convert.ToInt32(number) + 1);
            } else {
                this.lblTranNoTemp.Text = "0";
                return this.GetNumber(0);
            }
        }

        private string GetExt(string type, DateTime date) {
            switch (type) {
                case "M":
                    return this.NTS(date.Month);
                case "Q":
                    switch (date.Month) {
                        case 1:
                        case 2:
                        case 3:
                            return "01";
                        case 4:
                        case 5:
                        case 6:
                            return "02";
                        case 7:
                        case 8:
                        case 9:
                            return "03";
                        case 10:
                        case 11:
                        case 12:
                            return "04";
                        default:
                            return string.Empty;
                    }
                case "H":
                    switch (date.Month) {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            return "01";
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            return "02";
                        default:
                            return string.Empty;
                    }
                case "Y":
                    return date.Year.ToString();
                default:
                    return string.Empty;
            }
        }

        private string NTS(int Number) {
            if (Number < 9) {
                return "0" + Number.ToString();
            } else {
                return Number.ToString();
            }
        }

        private void GetDateGap(string type, DateTime date, ref DateTime begin, ref DateTime end) {
            switch (type) {
                case "M":
                    begin = Functions.DayStartOfMonth(date.Month, date.Year);
                    end = Functions.DayEndOfMonth(date.Month, date.Year);
                    break;
                case "Q":
                    switch (date.Month) {
                        case 1:
                        case 2:
                        case 3:
                            begin = Functions.DayStartOfMonth(1, date.Year);
                            end = Functions.DayEndOfMonth(3, date.Year);
                            break;
                        case 4:
                        case 5:
                        case 6:
                            begin = Functions.DayStartOfMonth(4, date.Year);
                            end = Functions.DayEndOfMonth(6, date.Year);
                            break;
                        case 7:
                        case 8:
                        case 9:
                            begin = Functions.DayStartOfMonth(7, date.Year);
                            end = Functions.DayEndOfMonth(9, date.Year);
                            break;
                        case 10:
                        case 11:
                        case 12:
                            begin = Functions.DayStartOfMonth(10, date.Year);
                            end = Functions.DayEndOfMonth(12, date.Year);
                            break;
                    }
                    break;
                case "H":
                    switch (date.Month) {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            begin = Functions.DayStartOfMonth(1, date.Year);
                            end = Functions.DayEndOfMonth(6, date.Year);
                            break;
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            begin = Functions.DayStartOfMonth(7, date.Year);
                            end = Functions.DayEndOfMonth(12, date.Year);
                            break;
                    }
                    break;
                case "Y":
                    begin = Functions.DayStartOfMonth(1, date.Year);
                    end = Functions.DayEndOfMonth(12, date.Year);
                    break;
            }
        }

        private void Textbox_Enter(object sender, EventArgs e) {
            this.mIsChanged = false;
        }

        private void Textbox_EditValueChanged(object sender, EventArgs e) {
            this.mIsChanged = true;
        }

        public bool IsValid() {
            if (this.mRequire && this.Visible) {
                if (this.textEdit.EditValue.ToString().Trim() == string.Empty) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
            this.textEdit.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private void SetProperty() {
            this.textEdit.Properties.AppearanceDisabled.BackColor = Color.White;
            this.textEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.textEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        private void btnConfig_Click(object sender, EventArgs e) {
            try {
                //FrmTranNumConfig frm = new FrmTranNumConfig(this.mFTSMain, this.mTran_Id);
                //if (frm.ShowDialog() == DialogResult.OK){
                //    this.mPrefix = frm.PreFix;
                //    this.mPrefix_Ext = frm.PreFix_Ext;
                //    this.mPrefix_Sep = frm.PreFix_Sep;
                //    this.mMask_Number = frm.Mask_Number;
                //    this.mMask_Type = frm.Mask_Type;
                //    this.mAuto = frm.Auto;
                //    this.mSuffix = frm.SufFix;
                //    this.mSuffix_Ext = frm.SufFix_Ext;
                //    this.mSuffix_Sep = frm.SufFix_Sep;
                //}
            } catch (FTSException ex) {
                ExceptionManager.ProcessException(this.mFTSMain,ex);
            } catch (Exception ex1) {
                ExceptionManager.ProcessException(this.mFTSMain,ex1);
            }
        }

        #region IHelpField Members

        private string mHelpText = string.Empty;

        public string HelpText {
            get { return this.mHelpText; }
            set {
                this.mHelpText = value;
                FTSForm form = this.FindForm() as FTSForm;
                if (form != null) {
                    form.SetBalloonTooltip(this, this.mHelpText);
                    form.SetBalloonTooltip(this.label, this.mHelpText);
                    form.SetBalloonTooltip(this.textEdit, this.mHelpText);
                }
            }
        }

        #endregion
    }
}