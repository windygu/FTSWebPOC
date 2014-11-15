namespace FTS.BaseUI.Business
{
    partial class FrmSys_Menu_EditDetail
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
            this.ftsShadowPanel1 = new FTS.BaseUI.Controls.FTSShadowPanel();
            this.txtProject_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtMenu_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtMenu_Type = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtMenu_Group = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtModule_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtMenu_Icon = new FTS.BaseUI.Controls.FTSTextCom();
            this.numMenu_Width = new FTS.BaseUI.Controls.FTSNumericCom();
            this.txtMenu_Tag = new FTS.BaseUI.Controls.FTSTextCom();
            this.numMenu_Order = new FTS.BaseUI.Controls.FTSNumericCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftsShadowPanel1)).BeginInit();
            this.ftsShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(301, 26);
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Controls.Add(this.ftsShadowPanel1);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(301, 299);
            // 
            // ftsShadowPanel1
            // 
            this.ftsShadowPanel1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ftsShadowPanel1.Appearance.Options.UseBackColor = true;
            this.ftsShadowPanel1.BorderColor = System.Drawing.Color.Empty;
            this.ftsShadowPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ftsShadowPanel1.Controls.Add(this.numMenu_Order);
            this.ftsShadowPanel1.Controls.Add(this.txtMenu_Tag);
            this.ftsShadowPanel1.Controls.Add(this.numMenu_Width);
            this.ftsShadowPanel1.Controls.Add(this.txtMenu_Icon);
            this.ftsShadowPanel1.Controls.Add(this.txtProject_Id);
            this.ftsShadowPanel1.Controls.Add(this.txtMenu_Id);
            this.ftsShadowPanel1.Controls.Add(this.txtMenu_Type);
            this.ftsShadowPanel1.Controls.Add(this.txtMenu_Group);
            this.ftsShadowPanel1.Controls.Add(this.chkActive);
            this.ftsShadowPanel1.Controls.Add(this.txtModule_Id);
            this.ftsShadowPanel1.Location = new System.Drawing.Point(12, 6);
            this.ftsShadowPanel1.Name = "ftsShadowPanel1";
            this.ftsShadowPanel1.NoBorderColor = true;
            this.ftsShadowPanel1.Size = new System.Drawing.Size(277, 286);
            this.ftsShadowPanel1.SkinBackColor = System.Drawing.SystemColors.Control;
            this.ftsShadowPanel1.TabIndex = 8;
            // 
            // txtProject_Id
            // 
            this.txtProject_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtProject_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtProject_Id.HelpText = "";
            this.txtProject_Id.LabelText = "Nhóm dự án";
            this.txtProject_Id.Location = new System.Drawing.Point(7, 36);
            this.txtProject_Id.Name = "txtProject_Id";
            this.txtProject_Id.Size = new System.Drawing.Size(262, 22);
            this.txtProject_Id.TabIndex = 16;
            this.txtProject_Id.Text = "Nhóm dự án";
            // 
            // txtMenu_Id
            // 
            this.txtMenu_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtMenu_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMenu_Id.HelpText = "";
            this.txtMenu_Id.LabelText = "Menu_Id";
            this.txtMenu_Id.Location = new System.Drawing.Point(7, 8);
            this.txtMenu_Id.Name = "txtMenu_Id";
            this.txtMenu_Id.Size = new System.Drawing.Size(262, 22);
            this.txtMenu_Id.TabIndex = 8;
            this.txtMenu_Id.Text = "Menu_Id";
            // 
            // txtMenu_Type
            // 
            this.txtMenu_Type.BackColor = System.Drawing.Color.Transparent;
            this.txtMenu_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMenu_Type.HelpText = "";
            this.txtMenu_Type.LabelText = "Menu_Type";
            this.txtMenu_Type.Location = new System.Drawing.Point(7, 92);
            this.txtMenu_Type.Name = "txtMenu_Type";
            this.txtMenu_Type.Size = new System.Drawing.Size(262, 22);
            this.txtMenu_Type.TabIndex = 9;
            this.txtMenu_Type.Text = "Menu_Type";
            // 
            // txtMenu_Group
            // 
            this.txtMenu_Group.BackColor = System.Drawing.Color.Transparent;
            this.txtMenu_Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMenu_Group.HelpText = "";
            this.txtMenu_Group.LabelText = "Menu_Group";
            this.txtMenu_Group.Location = new System.Drawing.Point(7, 120);
            this.txtMenu_Group.Name = "txtMenu_Group";
            this.txtMenu_Group.Size = new System.Drawing.Size(262, 22);
            this.txtMenu_Group.TabIndex = 10;
            this.txtMenu_Group.Text = "Menu_Group";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 76;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(7, 256);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(96, 22);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Active";
            // 
            // txtModule_Id
            // 
            this.txtModule_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtModule_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtModule_Id.HelpText = "";
            this.txtModule_Id.LabelText = "Module_Id";
            this.txtModule_Id.Location = new System.Drawing.Point(7, 64);
            this.txtModule_Id.Name = "txtModule_Id";
            this.txtModule_Id.Size = new System.Drawing.Size(262, 22);
            this.txtModule_Id.TabIndex = 15;
            this.txtModule_Id.Text = "Module_Id";
            // 
            // txtMenu_Icon
            // 
            this.txtMenu_Icon.BackColor = System.Drawing.Color.Transparent;
            this.txtMenu_Icon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMenu_Icon.HelpText = "";
            this.txtMenu_Icon.LabelText = "Menu_Icon";
            this.txtMenu_Icon.Location = new System.Drawing.Point(7, 148);
            this.txtMenu_Icon.Name = "txtMenu_Icon";
            this.txtMenu_Icon.Size = new System.Drawing.Size(262, 22);
            this.txtMenu_Icon.TabIndex = 17;
            this.txtMenu_Icon.Text = "Menu_Icon";
            // 
            // numMenu_Width
            // 
            this.numMenu_Width.BackColor = System.Drawing.Color.Transparent;
            this.numMenu_Width.HelpText = "";
            this.numMenu_Width.IsChanged = false;
            this.numMenu_Width.LabelText = "Menu_Width";
            this.numMenu_Width.Location = new System.Drawing.Point(7, 176);
            this.numMenu_Width.Max = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMenu_Width.Min = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMenu_Width.Name = "numMenu_Width";
            this.numMenu_Width.Size = new System.Drawing.Size(160, 20);
            this.numMenu_Width.TabIndex = 18;
            this.numMenu_Width.Text = "Menu_Width";
            // 
            // txtMenu_Tag
            // 
            this.txtMenu_Tag.BackColor = System.Drawing.Color.Transparent;
            this.txtMenu_Tag.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMenu_Tag.HelpText = "";
            this.txtMenu_Tag.LabelText = "Menu_Tag";
            this.txtMenu_Tag.Location = new System.Drawing.Point(7, 202);
            this.txtMenu_Tag.Name = "txtMenu_Tag";
            this.txtMenu_Tag.Size = new System.Drawing.Size(262, 22);
            this.txtMenu_Tag.TabIndex = 19;
            this.txtMenu_Tag.Text = "Menu_Tag";
            // 
            // numMenu_Order
            // 
            this.numMenu_Order.BackColor = System.Drawing.Color.Transparent;
            this.numMenu_Order.HelpText = "";
            this.numMenu_Order.IsChanged = false;
            this.numMenu_Order.LabelText = "Menu_Order";
            this.numMenu_Order.Location = new System.Drawing.Point(7, 230);
            this.numMenu_Order.Max = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMenu_Order.Min = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMenu_Order.Name = "numMenu_Order";
            this.numMenu_Order.Size = new System.Drawing.Size(160, 20);
            this.numMenu_Order.TabIndex = 20;
            this.numMenu_Order.Text = "Menu_Order";
            // 
            // FrmSys_Menu_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 325);
            this.Name = "FrmSys_Menu_EditDetail";
            this.Text = "FrmSys_Menu_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ftsShadowPanel1)).EndInit();
            this.ftsShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSShadowPanel ftsShadowPanel1;
        protected FTS.BaseUI.Controls.FTSTextCom txtMenu_Id;
        protected FTS.BaseUI.Controls.FTSTextCom txtMenu_Type;
        protected FTS.BaseUI.Controls.FTSTextCom txtMenu_Group;
        protected FTS.BaseUI.Controls.FTSCheckCom chkActive;
        protected FTS.BaseUI.Controls.FTSTextCom txtModule_Id;
        protected FTS.BaseUI.Controls.FTSTextCom txtProject_Id;
        private Controls.FTSNumericCom numMenu_Order;
        protected Controls.FTSTextCom txtMenu_Tag;
        private Controls.FTSNumericCom numMenu_Width;
        protected Controls.FTSTextCom txtMenu_Icon;

    }
}
