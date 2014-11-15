namespace FTS.BaseUI.Forms
{
    partial class FrmDm_Workstation_EditDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDm_Workstation_EditDetail));
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            this.txtWorkstation_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtWorkstation_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtHardware_Info = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkIs_Online = new FTS.BaseUI.Controls.FTSCheckCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            resources.ApplyResources(this.toolbar, "toolbar");
            // 
            // palMain
            // 
            this.palMain.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("palMain.Appearance.BackColor")));
            this.palMain.Appearance.Options.UseBackColor = true;
            this.palMain.Controls.Add(this.chkIs_Online);
            this.palMain.Controls.Add(this.txtHardware_Info);
            this.palMain.Controls.Add(this.chkActive);
            this.palMain.Controls.Add(this.txtWorkstation_Name);
            this.palMain.Controls.Add(this.txtWorkstation_Id);
            resources.ApplyResources(this.palMain, "palMain");
            // 
            // chkActive
            // 
            resources.ApplyResources(this.chkActive, "chkActive");
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 67;
            this.chkActive.LabelText = "Active:";
            this.chkActive.Name = "chkActive";
            // 
            // txtWorkstation_Name
            // 
            resources.ApplyResources(this.txtWorkstation_Name, "txtWorkstation_Name");
            this.txtWorkstation_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtWorkstation_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtWorkstation_Name.HelpText = "";
            this.txtWorkstation_Name.LabelLength = 120;
            this.txtWorkstation_Name.LabelText = "Workstation name:";
            this.txtWorkstation_Name.Name = "txtWorkstation_Name";
            // 
            // txtWorkstation_Id
            // 
            resources.ApplyResources(this.txtWorkstation_Id, "txtWorkstation_Id");
            this.txtWorkstation_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtWorkstation_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWorkstation_Id.HelpText = "";
            this.txtWorkstation_Id.LabelLength = 120;
            this.txtWorkstation_Id.LabelText = "Workstation id:";
            this.txtWorkstation_Id.Name = "txtWorkstation_Id";
            // 
            // txtHardware_Info
            // 
            resources.ApplyResources(this.txtHardware_Info, "txtHardware_Info");
            this.txtHardware_Info.BackColor = System.Drawing.Color.Transparent;
            this.txtHardware_Info.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHardware_Info.HelpText = "";
            this.txtHardware_Info.LabelLength = 120;
            this.txtHardware_Info.LabelText = "Hardware info:";
            this.txtHardware_Info.Name = "txtHardware_Info";
            // 
            // chkIs_Online
            // 
            resources.ApplyResources(this.chkIs_Online, "chkIs_Online");
            this.chkIs_Online.BackColor = System.Drawing.Color.Transparent;
            this.chkIs_Online.HelpText = "";
            this.chkIs_Online.LabelLenght = 64;
            this.chkIs_Online.LabelText = "Is online:";
            this.chkIs_Online.Name = "chkIs_Online";
            // 
            // FrmDm_Workstation_EditDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FrmDm_Workstation_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTS.BaseUI.Controls.FTSCheckCom chkActive;
        private FTS.BaseUI.Controls.FTSTextCom txtWorkstation_Name;
        private FTS.BaseUI.Controls.FTSTextCom txtWorkstation_Id;
        private FTS.BaseUI.Controls.FTSTextCom txtHardware_Info;
        private Controls.FTSCheckCom chkIs_Online;
    }
}