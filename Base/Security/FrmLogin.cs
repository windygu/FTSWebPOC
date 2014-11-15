#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Properties;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;
using FTS.Global.Classes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Global.Classes;

#endregion

namespace FTS.BaseUI.Security {
    public class FrmLogin : FrmBaseForm {
        private Container components = null;
        protected FTSSingleComboCom txtCompany_Name;
        protected FTSTextCom txtUser_Id;
        protected FTSTextCom txtPassword;
        private DataTable sec_user;
        private FTSLanguageToolbar barLanguage;
        private FTSButton btnOK;
        private FTSButton btnCancel;
        private FTSButton btnNewCompany;
        private Label label1;
        protected FTSUpDownCom txtWorkingYear;
        private FTSButton cmdConnect;
        private WorkingMode workingmode;

        public FrmLogin() {
            this.InitializeComponent();
        }

        public FrmLogin(FTSMain ftsmain) : base(ftsmain, true) {
            this.InitializeComponent();
            this.txtWorkingYear.UpDown.Properties.BorderStyle = BorderStyles.Simple;
            this.label1.Text = "Version: " + FTSConstant.Version;
            this.workingmode = this.FTSMain.Config.AppSettings.Settings["WORKINGMODE"].Value.Trim() == "1"
                                   ? WorkingMode.LAN
                                   : WorkingMode.WAN;
            if (this.workingmode == WorkingMode.LAN) {
                if (FTSConstant.DatabaseType == "SQL") {
                    this.LoadSQLCompanyList();
                }
            } else {
                try {
                    this.btnNewCompany.Visible = false;
                    this.FTSMain.CreateDatabase();
                    this.FTSMain.OpenDatabase();
                    this.LoadOnlineCompanyList();
                }catch(Exception ex) {
                    if (ex.GetType().Equals(typeof(FTSException))) {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(((FTSException)ex).Message);
                    } else {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex.Message + "; " + ex.Source + "; " + ex.StackTrace);
                    }
                }
            }
            this.txtCompany_Name.SetSelected(RegManager.GetKey("Company_Name"));
            if (RegManager.GetKey("Working_Year").ToString().Trim() == "") {
                this.txtWorkingYear.UpDown.EditValue = DateTime.Today.Year;
            } else {
                this.txtWorkingYear.UpDown.EditValue = RegManager.GetKey("Working_Year");
            }
            this.txtPassword.Textbox.Properties.PasswordChar = '*';
            if (RegManager.GetKey("Login_name").ToString().Trim() == "") {
                this.txtUser_Id.Textbox.Text = "Admin";
            } else {
                this.txtUser_Id.Textbox.Text = RegManager.GetKey("Login_name").ToString().Trim();
            }
            this.txtCompany_Name.ComboBox.BorderStyle = BorderStyles.Simple;
            this.txtUser_Id.Textbox.BorderStyle = BorderStyles.Simple;
            this.txtPassword.Textbox.BorderStyle = BorderStyles.Simple;
            if (FTSConstant.ProductVersion == "FTSACCSME2012") {
                this.BackgroundImage = Resources.backgroundSME;
                this.barLanguage.Visible = false;
                this.barLanguage.SelectedLanguage = Language.VN;
            }
            if (FTSConstant.ProductVersion == "FTSACCPRO2012") {
                this.BackgroundImage = Resources.backgroundERP;
                this.barLanguage.Visible = true;
            }
            if (FTSConstant.ProductVersion == "FTSERP") {
                this.BackgroundImage = Resources.backgroundERP;
                this.barLanguage.Visible = true;
            }
            if (FTSConstant.ProductVersion == "FTSACCSTD2012") {
                this.BackgroundImage = Resources.backgroundStd;
                this.barLanguage.Visible = true;
            }
            if (FTSConstant.ProductVersion == "FTSHOTEL2012") {
                this.BackgroundImage = Resources.backgroundHotel;
                this.barLanguage.Visible = true;
            }
            this.SetLanguage();
            this.barLanguage.BackColor = Color.Transparent;
        }

        private void LoadOnlineCompanyList() {
            this.txtCompany_Name.ComboBox.Properties.Items.Clear();
            this.txtCompany_Name.ComboBox.EditValue = string.Empty;
            foreach (CompanyInfo ci in this.FTSMain.DbMain.GetCompanyOnline(FTSConstant.AppCode)) {
                this.txtCompany_Name.ComboBox.Properties.Items.Add(new ObjectInfo(ci.Id, ci.Name));
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }

            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtCompany_Name = new FTS.BaseUI.Controls.FTSSingleComboCom();
            this.txtUser_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtPassword = new FTS.BaseUI.Controls.FTSTextCom();
            this.barLanguage = new FTS.BaseUI.Forms.FTSLanguageToolbar();
            this.btnOK = new FTS.BaseUI.Controls.FTSButton();
            this.btnCancel = new FTS.BaseUI.Controls.FTSButton();
            this.btnNewCompany = new FTS.BaseUI.Controls.FTSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkingYear = new FTS.BaseUI.Controls.FTSUpDownCom();
            this.cmdConnect = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupBox.Location = new System.Drawing.Point(41, 12);
            this.groupBox.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.groupBox.NoBorderColor = true;
            this.groupBox.Size = new System.Drawing.Size(17, 30);
            this.groupBox.Visible = false;
            // 
            // txtCompany_Name
            // 
            this.txtCompany_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtCompany_Name.HelpText = "";
            this.txtCompany_Name.LabelLength = 85;
            this.txtCompany_Name.LabelText = "Công ty";
            this.txtCompany_Name.Location = new System.Drawing.Point(198, 189);
            this.txtCompany_Name.Name = "txtCompany_Name";
            this.txtCompany_Name.Size = new System.Drawing.Size(268, 20);
            this.txtCompany_Name.TabIndex = 1;
            this.txtCompany_Name.Text = "Công ty";
            // 
            // txtUser_Id
            // 
            this.txtUser_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtUser_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser_Id.HelpText = "";
            this.txtUser_Id.LabelLength = 85;
            this.txtUser_Id.LabelText = "Tên đăng nhập";
            this.txtUser_Id.Location = new System.Drawing.Point(198, 233);
            this.txtUser_Id.Name = "txtUser_Id";
            this.txtUser_Id.Size = new System.Drawing.Size(167, 20);
            this.txtUser_Id.TabIndex = 3;
            this.txtUser_Id.Text = "Tên đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.HelpText = "";
            this.txtPassword.LabelLength = 85;
            this.txtPassword.LabelText = "Mật khẩu";
            this.txtPassword.Location = new System.Drawing.Point(198, 255);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "Mật khẩu";
            // 
            // barLanguage
            // 
            this.barLanguage.BackColor = System.Drawing.Color.White;
            this.barLanguage.Location = new System.Drawing.Point(366, 253);
            this.barLanguage.Name = "barLanguage";
            this.barLanguage.SelectedLanguage = "VN";
            this.barLanguage.Size = new System.Drawing.Size(119, 26);
            this.barLanguage.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnOK.Appearance.Options.UseBorderColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnOK.HelpText = "";
            this.btnOK.Location = new System.Drawing.Point(285, 283);
            this.btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Đăng nhập";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.Appearance.Options.UseBorderColor = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCancel.HelpText = "";
            this.btnCancel.Location = new System.Drawing.Point(406, 283);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnNewCompany.Appearance.Options.UseBorderColor = true;
            this.btnNewCompany.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnNewCompany.HelpText = "";
            this.btnNewCompany.Location = new System.Drawing.Point(285, 312);
            this.btnNewCompany.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnNewCompany.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(202, 24);
            this.btnNewCompany.TabIndex = 8;
            this.btnNewCompany.Text = "Tạo đơn vị mới";
            this.btnNewCompany.Click += new System.EventHandler(this.btnNewCompany_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(414, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Version";
            // 
            // txtWorkingYear
            // 
            this.txtWorkingYear.BackColor = System.Drawing.Color.Transparent;
            this.txtWorkingYear.HelpText = "";
            this.txtWorkingYear.IsChanged = true;
            this.txtWorkingYear.LabelLength = 85;
            this.txtWorkingYear.LabelText = "Năm làm việc";
            this.txtWorkingYear.Location = new System.Drawing.Point(198, 211);
            this.txtWorkingYear.MaxValue = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.txtWorkingYear.MinValue = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.txtWorkingYear.Name = "txtWorkingYear";
            this.txtWorkingYear.Size = new System.Drawing.Size(167, 20);
            this.txtWorkingYear.TabIndex = 2;
            this.txtWorkingYear.Text = "Năm làm việc";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdConnect.Appearance.Options.UseBorderColor = true;
            this.cmdConnect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdConnect.HelpText = "";
            this.cmdConnect.Location = new System.Drawing.Point(468, 188);
            this.cmdConnect.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cmdConnect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(24, 21);
            this.cmdConnect.TabIndex = 9;
            this.cmdConnect.Text = "...";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(496, 349);
            this.ControlBox = false;
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.txtWorkingYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewCompany);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.barLanguage);
            this.Controls.Add(this.txtCompany_Name);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUser_Id);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmLogin";
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.txtUser_Id, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.txtCompany_Name, 0);
            this.Controls.SetChildIndex(this.barLanguage, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNewCompany, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtWorkingYear, 0);
            this.Controls.SetChildIndex(this.cmdConnect, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e) {
            try {
                if (this.txtCompany_Name.ComboBox.SelectedItem == null) {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Bạn chưa chọn đơn vị!");
                    return;
                }
                this.FTSMain.CreateDatabase();
                string databasename = ((ObjectInfo) this.txtCompany_Name.ComboBox.SelectedItem).ID;
                if (this.workingmode == WorkingMode.LAN) {
                    string servername = this.FTSMain.Config.AppSettings.Settings["SERVERNAME"].Value;
                    if (servername == string.Empty) {
                        servername = "(local)";
                    }
                    string userid = this.FTSMain.Config.AppSettings.Settings["USERID"].Value;
                    if (userid == string.Empty) {
                        userid = "sa";
                    }
                    string password = Functions.Decrypt(this.FTSMain.Config.AppSettings.Settings["PASSWORD"].Value);
                    //this.FTSMain.DbMain.SetConnectionString("Database=" + databasename + ";Server=" + servername +
                    //                                        ";Integrated Security=True;");
                    this.FTSMain.DbMain.SetConnectionString("Database=" + databasename + ";Server=" + servername + ";User ID=" + userid + ";Password=" + password + ";");

                }
                this.FTSMain.WorkingYear = Convert.ToInt32(this.txtWorkingYear.UpDown.EditValue);
                this.FTSMain.DbMain.DatabaseOnline = databasename;
                this.FTSMain.Language = this.barLanguage.SelectedLanguage;
                this.FTSMain.Config.AppSettings.Settings["LANGUAGE"].Value = this.FTSMain.Language;
                this.FTSMain.Config.Save(ConfigurationSaveMode.Modified);
                this.FTSMain.OpenDatabase();
                
                this.sec_user =
                    this.FTSMain.DbMain.LoadDataTable(
                        this.FTSMain.DbMain.GetSqlStringCommand("select * from sec_user where active=1"), "sec_user");
                this.sec_user.PrimaryKey = new DataColumn[] {this.sec_user.Columns["USER_ID"]};
                DataRow foundrow = this.sec_user.Rows.Find(this.txtUser_Id.Textbox.Text.Trim());
                if (foundrow == null) {
                    if (this.FTSMain.Language == "VN") {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Tên truy cập không có, nhập lại tên truy cập!");
                    } else {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("User name does not exist!");
                    }
                    this.txtUser_Id.Focus();
                    return;
                } else {
                    if (Functions.Decrypt(foundrow["USER_password"].ToString().Trim()) !=
                        this.txtPassword.Textbox.EditValue.ToString()) {
                        if (this.FTSMain.Language == "VN") {
                            FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Mật khẩu không đúng!");
                        } else {
                            FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Wrong password!");
                        }
                        this.txtPassword.Focus();
                        return;
                    }
                }
                DateTime daystartofyear = DateTime.Today;
                string sql = "select VAR_VALUE FROM SYS_SYSTEMVAR WHERE VAR_NAME='DAY_START_YEAR'";
                object giatri = this.FTSMain.DbMain.ExecuteScalar(this.FTSMain.DbMain.GetSqlStringCommand(sql));
                if (giatri != null && giatri != System.DBNull.Value) {
                    daystartofyear = Convert.ToDateTime(giatri.ToString(), this.FTSMain.FTSCultureInfo);
                }
                if (this.FTSMain.WorkingYear < daystartofyear.Year) {
                    if (this.FTSMain.Language == "VN") {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Năm làm việc không hợp lệ!");
                    } else {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Invalid working year!");
                    }
                    this.txtWorkingYear.UpDown.Focus();
                    return;
                }
                this.FTSMain.UserInfo.UserID = this.txtUser_Id.Textbox.EditValue.ToString().ToUpper().Trim();
                this.FTSMain.UserInfo.UserName = foundrow["user_name"].ToString();
                this.FTSMain.UserInfo.UserGroupID = foundrow["user_group_id"].ToString();
                this.FTSMain.UserInfo.OrganizationID = foundrow["organization_id"].ToString();
                this.FTSMain.UserInfo.IsSubOrg = Dm_Organization.IsSubOrganization(this.FTSMain, null, this.FTSMain.UserInfo.OrganizationID);
                DataTable dmorganizaiton =
                    this.FTSMain.DbMain.LoadDataTable(
                        this.FTSMain.DbMain.GetSqlStringCommand(
                            "SELECT ORGANIZATION_ID,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE FROM DM_ORGANIZATION"),
                        "DM_ORGANIZATION");
                dmorganizaiton.PrimaryKey = new DataColumn[]{dmorganizaiton.Columns["ORGANIZATION_ID"]};
                this.FTSMain.UserInfo.ParentOrganizationID = Dm_Organization.GetIndependantParentOrganization(dmorganizaiton,
                                                                                                     this.FTSMain.
                                                                                                         UserInfo.
                                                                                                         OrganizationID);
                this.FTSMain.UserInfo.EmployeeId = foundrow["employee_id"].ToString();
                DataTable sec_user_group =
                    this.FTSMain.DbMain.LoadDataTable(
                        this.FTSMain.DbMain.GetSqlStringCommand("select * from sec_user_group where active=1"),
                        "sec_user");
                sec_user_group.PrimaryKey = new DataColumn[] {sec_user_group.Columns["USER_GROUP_ID"]};
                DataRow grouprow = sec_user_group.Rows.Find(this.FTSMain.UserInfo.UserGroupID);
                if (grouprow != null) {
                    this.FTSMain.UserInfo.ModuleList = grouprow["MODULE_LIST"].ToString();
                }
                //this.FTSMain.RowPermission = foundrow;
                if (RegManager.GetKey("Login_name").ToString().Trim() != this.txtUser_Id.Textbox.EditValue.ToString()) {
                    RegManager.WriteKey("Login_name", this.txtUser_Id.Textbox.EditValue.ToString());
                }
                RegManager.WriteKey("Company_Name", ((ObjectInfo) this.txtCompany_Name.ComboBox.SelectedItem).ID);
                RegManager.WriteKey("Working_Year", this.FTSMain.WorkingYear.ToString());
                Logging.Log(this.FTSMain, ActionType.LOGIN, DateTime.Today.ToString("d",this.FTSMain.FTSCultureInfo));
                this.DialogResult = DialogResult.OK;
            } catch (FTSException ex) {
                this.FTSMain.DEBUG = true;
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex.Message + ex.StackTrace);
            } catch (Exception ex1) {
                this.FTSMain.DEBUG = true;
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex1.Message + ex1.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadSQLCompanyList() {
            string servername = this.FTSMain.Config.AppSettings.Settings["SERVERNAME"].Value;
            if (servername == string.Empty) {
                servername = "(local)";
            }
            string userid = this.FTSMain.Config.AppSettings.Settings["USERID"].Value;
            if (userid == string.Empty) {
                servername = "ftsacc";
            }
            string password = Functions.Decrypt(this.FTSMain.Config.AppSettings.Settings["PASSWORD"].Value);
            string connectionstring = "Database=" + "Master" + ";Server=" + servername + ";User ID=" + userid +
                                      ";Password=" + password + ";";
            //string connectionstring = "Database=" + "Master" + ";Server=" + servername + ";Integrated Security=True;";
            using (SqlConnection cnn = new SqlConnection(connectionstring)) {
                try {
                    cnn.Open();
                    this.GetDatabases(cnn, servername, userid, password);
                } catch (Exception) {
                    if (this.FTSMain.Language == "VN") {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Không tìm thấy máy chủ cơ sở dữ liệu!");
                    } else {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Can't find database server!");
                    }
                }
            }
        }

        private void GetDatabases(SqlConnection cnn, string servername, string userid, string password) {
            this.txtCompany_Name.ComboBox.Properties.Items.Clear();
            this.txtCompany_Name.ComboBox.EditValue = string.Empty;
            SqlDataAdapter adapter = new SqlDataAdapter("select name from sysdatabases", cnn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows) {
                string databasename = row["name"].ToString();
                string companyname = this.IsValidSqlDatabase(servername, userid, password, databasename);
                if (companyname != string.Empty) {
                    this.txtCompany_Name.ComboBox.Properties.Items.Add(new ObjectInfo(databasename, companyname));
                }
            }
        }

        private string IsValidSqlDatabase(string servername, string userid, string password, string databasename) {
            try {
                string connectionstring = "Database=" + databasename + ";Server=" + servername + ";User ID=" + userid +
                                          ";Password=" + password + ";";
                //string connectionstring = "Database=" + databasename + ";Server=" + servername + ";Integrated Security=True;";
                using (SqlConnection cnn = new SqlConnection(connectionstring)) {
                    cnn.Open();
                    SqlDataAdapter adapter =
                        new SqlDataAdapter(
                            "select var_value from sys_systemvar where var_name ='APP_CODE' and var_value='" +
                            FTSConstant.AppCode + "'", cnn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0) {
                        adapter = new SqlDataAdapter("select var_value from sys_systemvar where var_name ='APP_NAME'",
                                                     cnn);
                        dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0) {
                            return dt.Rows[0]["var_value"].ToString();
                        } else {
                            return string.Empty;
                        }
                    } else {
                        return string.Empty;
                    }
                }
            } catch (Exception) {
                return string.Empty;
            }
        }

        private void btnNewCompany_Click(object sender, EventArgs e) {
            
        }

        private void SetLanguage() {
            if (this.FTSMain.LanguageList != string.Empty) {
                if (!Functions.InListAbsolute("VN", this.FTSMain.LanguageList)) {
                    this.barLanguage.SetVisible("VN", false);
                }
                if (!Functions.InListAbsolute("EN", this.FTSMain.LanguageList)) {
                    this.barLanguage.SetVisible("EN", false);
                }
                if (!Functions.InListAbsolute("JP", this.FTSMain.LanguageList)) {
                    this.barLanguage.SetVisible("JP", false);
                }
                if (!Functions.InListAbsolute("KR", this.FTSMain.LanguageList)) {
                    this.barLanguage.SetVisible("KR", false);
                }
                if (!Functions.InListAbsolute("LAOS", this.FTSMain.LanguageList)) {
                    this.barLanguage.SetVisible("LAOS", false);
                }
            } else {
                this.barLanguage.SetVisible("VN", true);
                this.barLanguage.SetVisible("EN", true);
                this.barLanguage.SetVisible("JP", false);
                this.barLanguage.SetVisible("KR", false);
                this.barLanguage.SetVisible("LAOS", false);
            }
            if (this.FTSMain.Language == Language.EN) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
                this.barLanguage.SelectedLanguage = Language.EN;
            }
            if (this.FTSMain.Language == Language.KR) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
                this.barLanguage.SelectedLanguage = Language.KR;
            }
            if (this.FTSMain.Language == Language.JP ) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
                this.barLanguage.SelectedLanguage = Language.JP;
            }
            if (FTSMain.Language == Language.LAOS) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
                this.barLanguage.SelectedLanguage = Language.LAOS;
            }
            if (this.FTSMain.Language == Language.VN) {
                this.barLanguage.SelectedLanguage = Language.VN;
            }
            
                
        }

        public void SetLanguage(string lang) {
            if (lang == Language.EN) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
            }
            if (lang == Language.JP) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
            }
            if (lang == Language.LAOS) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
            }
            if (lang == Language.KR) {
                this.txtCompany_Name.LabelText = "Company Name";
                this.txtWorkingYear.LabelText = "Working year";
                this.txtUser_Id.LabelText = "User Name";
                this.txtPassword.LabelText = "Password";
                this.btnCancel.Text = "Cancel";
                this.btnOK.Text = "Login";
                this.btnNewCompany.Text = "Create new company";
            }
            if (lang == Language.VN) {
                this.txtCompany_Name.LabelText = "Đơn vị";
                this.txtWorkingYear.LabelText = "Năm làm việc:";
                this.txtUser_Id.LabelText = "Người sử dụng:";
                this.txtPassword.LabelText = "Mật khẩu:";
                this.btnCancel.Text = "Thoát";
                this.btnOK.Text = "Đăng nhập";
                this.btnNewCompany.Text = "Tạo đơn vị mới";
            }
        }

        private void cmdConnect_Click(object sender, EventArgs e) {
            try {
                FrmServer frmServer = new FrmServer(this.FTSMain);
                frmServer.ShowDialog();
                if (!frmServer.Cancel) {
                    if (frmServer.ClientWorkingMode == WorkingMode.LAN) {
                        string servername = frmServer.ServerName;
                        string userid = frmServer.UserID;
                        string password = frmServer.Password;
                        string connectionstring = "Database=" + "Master" + ";Server=" + servername + ";User ID=" + userid + ";Password=" + password + ";";
                        using (SqlConnection cnn1 = new SqlConnection(connectionstring)) {
                            try {
                                cnn1.Open();
                            } catch (Exception) {
                                if (this.FTSMain.Language == "VN") {
                                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Không tìm thấy máy chủ cơ sở dữ liệu!");
                                } else {
                                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Cannot find the database server!");
                                }
                                return;
                            }
                            this.FTSMain.Config.AppSettings.Settings["WORKINGMODE"].Value = "1";
                            this.FTSMain.Config.AppSettings.Settings["SERVERNAME"].Value = servername;
                            this.FTSMain.Config.AppSettings.Settings["USERID"].Value = userid;
                            this.FTSMain.Config.AppSettings.Settings["PASSWORD"].Value = Functions.Encrypt(password);
                            this.FTSMain.Config.Save(ConfigurationSaveMode.Modified);
                            this.workingmode = WorkingMode.LAN;
                            this.GetDatabases(cnn1, servername, userid, password);
                        }
                    } else {
                        this.FTSMain.Url = frmServer.ServerName;
                        this.FTSMain.Config.AppSettings.Settings["WORKINGMODE"].Value = "0";
                        this.FTSMain.Config.AppSettings.Settings["SERVERURL"].Value = frmServer.ServerName;
                        this.FTSMain.Config.Save(ConfigurationSaveMode.Modified);
                        this.workingmode = WorkingMode.WAN;
                        this.FTSMain.CreateDatabase();
                        this.FTSMain.OpenDatabase();
                        this.LoadOnlineCompanyList();
                    }
                } else {
                    return;
                }
            } catch (FTSException ex1) {
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex1.ExceptionID + ex1.ExtraInformation);
            } catch (Exception ex) {
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void CreateSQLDatabase() {
            string servername = this.FTSMain.Config.AppSettings.Settings["SERVERNAME"].Value;
            string userid = this.FTSMain.Config.AppSettings.Settings["USERID"].Value;
            string password = Functions.Decrypt(this.FTSMain.Config.AppSettings.Settings["PASSWORD"].Value);
            string connectionstring = "Database=Master;Server=" + servername + ";User ID=" + userid + ";Password=" +
                                      password + ";";
            string databasename = "FTS_PGAS";
            using (SqlConnection cnn = new SqlConnection(connectionstring)) {
                cnn.Open();
                string sql = "select * from sysdatabases where name='" + databasename + "'";
                DataTable dt = new DataTable();
                (new SqlDataAdapter(sql, cnn)).Fill(dt);
                if (dt.Rows.Count > 0) {
                    throw new FTSException("Dữ liệu đã tồn tại!");
                }
                sql = "select spid from sysprocesses where db_name(dbid) = 'model'";
                dt = new DataTable();
                (new SqlDataAdapter(sql, cnn)).Fill(dt);
                foreach (DataRow row in dt.Rows) {
                    sql = "kill " + row["spid"];
                    try {
                        (new SqlCommand(sql, cnn)).ExecuteNonQuery();
                    } catch (Exception) {
                    }
                }
                sql = "CREATE DATABASE " + databasename + " COLLATE SQL_Latin1_General_CP1_CI_AS";
                (new SqlCommand(sql, cnn)).ExecuteNonQuery();
                sql = "select * from sysdatabases where name='" + databasename + "'";
                dt = new DataTable("dt");
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                if (dt.Rows.Count == 0) {
                    if (this.FTSMain.Language == "VN") {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Có lỗi khi tạo dữ liệu! Kiểm tra lại máy chủ!");
                    } else {
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage("Error while creating database! Check the server again!");
                    }
                    return;
                }
            }
            connectionstring = "Database=" + databasename + ";Server=" + servername + ";User ID=" + userid +
                               ";Password=" + password + ";";
            this.RunScripts(connectionstring);
            this.FTSMain.CreateDatabase();
            this.FTSMain.DbMain.SetConnectionString(connectionstring);
            this.FTSMain.OpenDatabase();
            this.FTSMain.RunDB();
        }
        private void RunScripts(string connectionstring) {
            using (SqlConnection cnn = new SqlConnection(connectionstring)) {
                cnn.Open();
                string sLine = string.Empty;
                string txtfile = "FTSSOLUTIONBLANK.SQL";
                ArrayList arrText = new ArrayList();
                StreamReader objReader;
                if (Functions.FileExists(this.FTSMain.PathName + txtfile)) {
                    objReader = new StreamReader(this.FTSMain.PathName + txtfile);
                    arrText.Add(string.Empty);
                    while (sLine != null) {
                        sLine = objReader.ReadLine();
                        if (sLine != null) {
                            if (sLine.ToUpper().Trim() != "GO") {
                                if (sLine.Trim().Length != 0) {
                                    arrText[arrText.Count - 1] = arrText[arrText.Count - 1] + " " + sLine;
                                }
                            } else {
                                arrText.Add(string.Empty);
                            }
                        }
                    }
                    objReader.Close();
                }
                foreach (string sOutput in arrText) {
                    if (sOutput.Length != 0) {
                        try {
                            (new SqlCommand(sOutput, cnn)).ExecuteNonQuery();
                        } catch (Exception) {
                        }
                    }
                }
            }
        }
    }
}