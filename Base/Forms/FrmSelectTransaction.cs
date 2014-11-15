// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:46
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FrmSelectTransaction.cs
// Project Item Filename:     FrmSelectTransaction.cs
// Project Item Kind:         Form
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.ComponentModel;
using System.Data;
using FTS.BaseUI.Controls;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseUI.Forms {
    public class FrmSelectTransaction : FrmBaseForm {
        private IContainer components = null;
        public bool OK;
        private FTSButton cmdOK;
        private FTSButton cmdClose;
        private FTSComboCom cboTransaction;
        private string mTranSubClass = string.Empty;
        private string mTranId = string.Empty;

        public FrmSelectTransaction() {
            this.InitializeComponent();
        }

        public FrmSelectTransaction(FTSMain ftsmain, string transubclass) : base(ftsmain, true) {
            this.mTranSubClass = transubclass;
            this.InitializeComponent();
            this.LoadLayout();
            this.LoadData();
        }

        public string TranId {
            get { return this.mTranId; }
            set { this.mTranId = value; }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cboTransaction = new FTS.BaseUI.Controls.FTSComboCom();
            this.cmdOK = new FTS.BaseUI.Controls.FTSButton();
            this.cmdClose = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cmdOK);
            this.groupBox.Controls.Add(this.cmdClose);
            this.groupBox.Controls.Add(this.cboTransaction);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(314, 111);
            // 
            // cboTransaction
            // 
            this.cboTransaction.BackColor = System.Drawing.Color.Transparent;
            this.cboTransaction.LabelLength = 80;
            this.cboTransaction.LabelText = "Loại chứng từ";
            this.cboTransaction.Location = new System.Drawing.Point(22, 23);
            this.cboTransaction.Name = "cboTransaction";
            this.cboTransaction.Size = new System.Drawing.Size(271, 20);
            this.cboTransaction.TabIndex = 0;
            this.cboTransaction.Text = "Loại chứng từ";
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte) (0)), ((System.Byte) (231)),
                                                                            ((System.Byte) (237)), ((System.Byte) (227)));
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdOK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdOK.Appearance.Options.UseBackColor = true;
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Appearance.Options.UseForeColor = true;
            this.cmdOK.Location = new System.Drawing.Point(64, 64);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.TabIndex = 21;
            this.cmdOK.Text = "Đồng ý";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_ButtonPressed);
            // 
            // cmdClose
            // 
            this.cmdClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte) (0)),
                                                                               ((System.Byte) (231)),
                                                                               ((System.Byte) (237)),
                                                                               ((System.Byte) (227)));
            this.cmdClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdClose.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdClose.Appearance.Options.UseBackColor = true;
            this.cmdClose.Appearance.Options.UseFont = true;
            this.cmdClose.Appearance.Options.UseForeColor = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(176, 64);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "Bỏ qua";
            this.cmdClose.Click += new System.EventHandler(this.cmdCancel_ButtonPressed);
            // 
            // FrmSelectTransaction
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(314, 111);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSelectTransaction";
            this.Text = "Chọn loại chứng từ";
            ((System.ComponentModel.ISupportInitialize) (this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
        }

        #endregion

        private void LoadData() {
            DataSet ds = new DataSet();
            this.FTSMain.TableManager.LoadTable(ds, "SYS_TRAN", "TRAN_ID,TRAN_NAME",
                                                "TRAN_SUB_CLASS='" + this.mTranSubClass + "' and active=1");
            this.cboTransaction.Set(this.FTSMain, "SYS_TRAN", ds, "TRAN_ID", "TRAN_NAME", ComboComType.NameID, false);
            if (ds.Tables["SYS_TRAN"].Rows.Count > 0) {
                this.cboTransaction.ComboBox.EditValue = ds.Tables["SYS_TRAN"].Rows[0]["TRAN_ID"];
            }
            if (ds.Tables["SYS_TRAN"].Rows.Count == 1) {
                this.mTranId = this.cboTransaction.ComboBox.EditValue.ToString();
                this.OK = true;
                this.Hide();
            }
        }

        private void cmdCancel_ButtonPressed(object sender, EventArgs e) {
            this.OK = false;
            this.Hide();
        }

        private void cmdOK_ButtonPressed(object sender, EventArgs e) {
            this.OK = true;
            this.mTranId = this.cboTransaction.ComboBox.EditValue.ToString();
            this.Hide();
        }
    }
}