namespace FTS.BaseUI.Security
{
    partial class FrmiPermission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboModule = new FTS.BaseUI.Controls.FTSComboCom();
            this.treeUser = new FTS.BaseUI.Controls.FTSTreeList();
            this.btnAddUser = new FTS.BaseUI.Controls.FTSButton();
            this.btnEditUser = new FTS.BaseUI.Controls.FTSButton();
            this.btnDeleteUser = new FTS.BaseUI.Controls.FTSButton();
            this.btnAddGroup = new FTS.BaseUI.Controls.FTSButton();
            this.btnDeleteGroup = new FTS.BaseUI.Controls.FTSButton();
            this.btnCopyGroup = new FTS.BaseUI.Controls.FTSButton();
            this.ftsShadowPanel1 = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.btnMapping_Menu = new FTS.BaseUI.Controls.FTSButton();
            this.SubModule = new FTS.BaseUI.Controls.FTSTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnEditUserGroup = new FTS.BaseUI.Controls.FTSButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftsShadowPanel1)).BeginInit();
            this.ftsShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubModule)).BeginInit();
            this.SubModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupGrid
            // 
            this.groupGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupGrid.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupGrid.Appearance.Options.UseBackColor = true;
            this.groupGrid.Dock = System.Windows.Forms.DockStyle.None;
            this.groupGrid.Location = new System.Drawing.Point(2, 54);
            this.groupGrid.Size = new System.Drawing.Size(687, 423);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Appearance.Options.UseBackColor = true;
            this.groupBox.Controls.Add(this.btnEditUserGroup);
            this.groupBox.Controls.Add(this.btnCopyGroup);
            this.groupBox.Controls.Add(this.btnDeleteGroup);
            this.groupBox.Controls.Add(this.btnAddGroup);
            this.groupBox.Controls.Add(this.btnDeleteUser);
            this.groupBox.Controls.Add(this.btnEditUser);
            this.groupBox.Controls.Add(this.btnAddUser);
            this.groupBox.Controls.Add(this.cboModule);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.None;
            this.groupBox.Location = new System.Drawing.Point(0, 28);
            this.groupBox.Size = new System.Drawing.Size(878, 24);
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 423);
            // 
            // groupTop
            // 
            this.groupTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupTop.Size = new System.Drawing.Size(878, 26);
            // 
            // cboModule
            // 
            this.cboModule.BackColor = System.Drawing.Color.Transparent;
            this.cboModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboModule.HelpText = "";
            this.cboModule.IsChanged = false;
            this.cboModule.LabelText = "Phân hệ";
            this.cboModule.Location = new System.Drawing.Point(0, 0);
            this.cboModule.Name = "cboModule";
            this.cboModule.Size = new System.Drawing.Size(206, 24);
            this.cboModule.TabIndex = 0;
            this.cboModule.Text = "Phân hệ";
            // 
            // treeUser
            // 
            this.treeUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeUser.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeUser.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.treeUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeUser.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeUser.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeUser.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeUser.Appearance.OddRow.Options.UseBackColor = true;
            this.treeUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeUser.Location = new System.Drawing.Point(693, 55);
            this.treeUser.Name = "treeUser";
            this.treeUser.OptionsBehavior.Editable = false;
            this.treeUser.OptionsBehavior.EnterMovesNextColumn = true;
            this.treeUser.OptionsMenu.EnableColumnMenu = false;
            this.treeUser.OptionsMenu.EnableFooterMenu = false;
            this.treeUser.OptionsView.EnableAppearanceEvenRow = true;
            this.treeUser.OptionsView.EnableAppearanceOddRow = true;
            this.treeUser.Size = new System.Drawing.Size(185, 422);
            this.treeUser.TabIndex = 7;
            this.treeUser.DoubleClick += new System.EventHandler(this.treeUser_DoubleClick);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddUser.HelpText = "";
            this.btnAddUser.Image = global::FTS.BaseUI.Properties.Resources.add_user;
            this.btnAddUser.Location = new System.Drawing.Point(788, 0);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(90, 24);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Thêm user";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditUser.HelpText = "";
            this.btnEditUser.Image = global::FTS.BaseUI.Properties.Resources.user_blue_edit;
            this.btnEditUser.Location = new System.Drawing.Point(698, 0);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(90, 24);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Sửa user";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteUser.HelpText = "";
            this.btnDeleteUser.Image = global::FTS.BaseUI.Properties.Resources.user1_delete;
            this.btnDeleteUser.Location = new System.Drawing.Point(608, 0);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(90, 24);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Xóa user";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddGroup.HelpText = "";
            this.btnAddGroup.Image = global::FTS.BaseUI.Properties.Resources.add_group;
            this.btnAddGroup.Location = new System.Drawing.Point(206, 0);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(90, 24);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "Thêm nhóm";
            this.btnAddGroup.ToolTip = "Khi thực hiện thêm nhóm quyền mới thì toàn bộ quyền hạn sẽ được coi là chưa phân " +
    "quyền, bạn sẽ phải phân quyền lại từ đầu cho nhóm mới này.";
            this.btnAddGroup.ToolTipTitle = "Chú ý";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteGroup.HelpText = "";
            this.btnDeleteGroup.Image = global::FTS.BaseUI.Properties.Resources.delete_group;
            this.btnDeleteGroup.Location = new System.Drawing.Point(296, 0);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(90, 24);
            this.btnDeleteGroup.TabIndex = 4;
            this.btnDeleteGroup.Text = "Xóa nhóm";
            this.btnDeleteGroup.ToolTip = "Xóa 1 nhóm quyền đồng nghĩa với việc toàn bộ người dùng trong nhóm quyền sẽ bị xó" +
    "a bỏ theo, bạn nên cân nhắc trước khi thực hiện hành động";
            this.btnDeleteGroup.ToolTipTitle = "Chú ý";
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnCopyGroup
            // 
            this.btnCopyGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopyGroup.HelpText = "";
            this.btnCopyGroup.Image = global::FTS.BaseUI.Properties.Resources.group_go;
            this.btnCopyGroup.Location = new System.Drawing.Point(386, 0);
            this.btnCopyGroup.Name = "btnCopyGroup";
            this.btnCopyGroup.Size = new System.Drawing.Size(90, 24);
            this.btnCopyGroup.TabIndex = 5;
            this.btnCopyGroup.Text = "Sao nhóm";
            this.btnCopyGroup.ToolTip = "Thực hiện chọn 1 nhóm quyền ở danh sách nhóm quyền, sau đó click vào đây để thực " +
    "hiện sao chép quyền sang nhóm mới";
            this.btnCopyGroup.ToolTipTitle = "Thông báo";
            this.btnCopyGroup.Click += new System.EventHandler(this.btnCopyGroup_Click);
            // 
            // ftsShadowPanel1
            // 
            this.ftsShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ftsShadowPanel1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ftsShadowPanel1.Appearance.Options.UseBackColor = true;
            this.ftsShadowPanel1.BorderColor = System.Drawing.Color.Empty;
            this.ftsShadowPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ftsShadowPanel1.Controls.Add(this.btnMapping_Menu);
            this.ftsShadowPanel1.Controls.Add(this.SubModule);
            this.ftsShadowPanel1.Location = new System.Drawing.Point(0, 478);
            this.ftsShadowPanel1.Name = "ftsShadowPanel1";
            this.ftsShadowPanel1.NoBorderColor = true;
            this.ftsShadowPanel1.Size = new System.Drawing.Size(877, 27);
            this.ftsShadowPanel1.SkinBackColor = System.Drawing.SystemColors.Control;
            this.ftsShadowPanel1.TabIndex = 8;
            // 
            // btnMapping_Menu
            // 
            this.btnMapping_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMapping_Menu.HelpText = "";
            this.btnMapping_Menu.Image = global::FTS.BaseUI.Properties.Resources.group_go;
            this.btnMapping_Menu.Location = new System.Drawing.Point(0, 0);
            this.btnMapping_Menu.Name = "btnMapping_Menu";
            this.btnMapping_Menu.Size = new System.Drawing.Size(205, 27);
            this.btnMapping_Menu.TabIndex = 6;
            this.btnMapping_Menu.Text = "Tham chiếu chức năng";
            this.btnMapping_Menu.ToolTip = "Thực hiện chọn 1 nhóm quyền ở danh sách nhóm quyền, sau đó click vào đây để thực " +
    "hiện sao chép quyền sang nhóm mới";
            this.btnMapping_Menu.ToolTipTitle = "Thông báo";
            this.btnMapping_Menu.Click += new System.EventHandler(this.btnMapping_Menu_Click);
            // 
            // SubModule
            // 
            this.SubModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubModule.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.SubModule.Location = new System.Drawing.Point(211, 0);
            this.SubModule.Name = "SubModule";
            this.SubModule.SelectedTabPage = this.xtraTabPage1;
            this.SubModule.Size = new System.Drawing.Size(478, 23);
            this.SubModule.TabIndex = 0;
            this.SubModule.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.SubModule.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.SubModule_Selected);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(472, 0);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(472, 0);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // btnEditUserGroup
            // 
            this.btnEditUserGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditUserGroup.HelpText = "";
            this.btnEditUserGroup.Image = global::FTS.BaseUI.Properties.Resources.user_blue_edit;
            this.btnEditUserGroup.Location = new System.Drawing.Point(476, 0);
            this.btnEditUserGroup.Name = "btnEditUserGroup";
            this.btnEditUserGroup.Size = new System.Drawing.Size(90, 24);
            this.btnEditUserGroup.TabIndex = 6;
            this.btnEditUserGroup.Text = "Sửa nhóm";
            this.btnEditUserGroup.ToolTip = "Sửa thông tin nhóm";
            this.btnEditUserGroup.ToolTipTitle = "Chú ý";
            this.btnEditUserGroup.Click += new System.EventHandler(this.btnEditUserGroup_Click);
            // 
            // FrmiPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(878, 503);
            this.Controls.Add(this.ftsShadowPanel1);
            this.Controls.Add(this.treeUser);
            this.Name = "FrmiPermission";
            this.Controls.SetChildIndex(this.groupTop, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.treeUser, 0);
            this.Controls.SetChildIndex(this.groupGrid, 0);
            this.Controls.SetChildIndex(this.ftsShadowPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftsShadowPanel1)).EndInit();
            this.ftsShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubModule)).EndInit();
            this.SubModule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSComboCom cboModule;
        private FTS.BaseUI.Controls.FTSTreeList treeUser;
        private FTS.BaseUI.Controls.FTSButton btnAddUser;
        private FTS.BaseUI.Controls.FTSButton btnEditUser;
        private FTS.BaseUI.Controls.FTSButton btnDeleteUser;
        private FTS.BaseUI.Controls.FTSButton btnCopyGroup;
        private FTS.BaseUI.Controls.FTSButton btnDeleteGroup;
        private FTS.BaseUI.Controls.FTSButton btnAddGroup;
        private Controls.FTSShadowPanel ftsShadowPanel1;
        private Controls.FTSTabControl SubModule;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Controls.FTSButton btnMapping_Menu;
        private Controls.FTSButton btnEditUserGroup;
    }
}
