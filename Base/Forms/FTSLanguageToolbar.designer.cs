namespace FTS.BaseUI.Forms
{
    partial class FTSLanguageToolbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdLaos = new FTS.BaseUI.Controls.FTSButton();
            this.cmdKR = new FTS.BaseUI.Controls.FTSButton();
            this.cmdJP = new FTS.BaseUI.Controls.FTSButton();
            this.cmdEN = new FTS.BaseUI.Controls.FTSButton();
            this.cmdVN = new FTS.BaseUI.Controls.FTSButton();
            this.SuspendLayout();
            // 
            // cmdLaos
            // 
            this.cmdLaos.AllowFocus = false;
            this.cmdLaos.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdLaos.Appearance.Options.UseBorderColor = true;
            this.cmdLaos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdLaos.HelpText = "";
            this.cmdLaos.Image = global::FTS.BaseUI.Properties.Resources.laos_32;
            this.cmdLaos.Location = new System.Drawing.Point(117, 3);
            this.cmdLaos.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.cmdLaos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdLaos.Name = "cmdLaos";
            this.cmdLaos.Size = new System.Drawing.Size(30, 20);
            this.cmdLaos.TabIndex = 8;
            this.cmdLaos.Click += new System.EventHandler(this.Language_Click);
            // 
            // cmdKR
            // 
            this.cmdKR.AllowFocus = false;
            this.cmdKR.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdKR.Appearance.Options.UseBorderColor = true;
            this.cmdKR.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdKR.HelpText = "";
            this.cmdKR.Image = global::FTS.BaseUI.Properties.Resources.flag_south_korea;
            this.cmdKR.Location = new System.Drawing.Point(90, 0);
            this.cmdKR.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.cmdKR.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdKR.Name = "cmdKR";
            this.cmdKR.Size = new System.Drawing.Size(32, 26);
            this.cmdKR.TabIndex = 7;
            this.cmdKR.Click += new System.EventHandler(this.Language_Click);
            // 
            // cmdJP
            // 
            this.cmdJP.AllowFocus = false;
            this.cmdJP.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdJP.Appearance.Options.UseBorderColor = true;
            this.cmdJP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdJP.HelpText = "";
            this.cmdJP.Image = global::FTS.BaseUI.Properties.Resources.flag_japan;
            this.cmdJP.Location = new System.Drawing.Point(60, 0);
            this.cmdJP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.cmdJP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdJP.Name = "cmdJP";
            this.cmdJP.Size = new System.Drawing.Size(32, 26);
            this.cmdJP.TabIndex = 6;
            this.cmdJP.Click += new System.EventHandler(this.Language_Click);
            // 
            // cmdEN
            // 
            this.cmdEN.AllowFocus = false;
            this.cmdEN.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdEN.Appearance.Options.UseBorderColor = true;
            this.cmdEN.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdEN.HelpText = "";
            this.cmdEN.Image = global::FTS.BaseUI.Properties.Resources.flag_great_britain;
            this.cmdEN.Location = new System.Drawing.Point(29, 0);
            this.cmdEN.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.cmdEN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdEN.Name = "cmdEN";
            this.cmdEN.Size = new System.Drawing.Size(32, 26);
            this.cmdEN.TabIndex = 5;
            this.cmdEN.Click += new System.EventHandler(this.Language_Click);
            // 
            // cmdVN
            // 
            this.cmdVN.AllowFocus = false;
            this.cmdVN.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.cmdVN.Appearance.Options.UseBorderColor = true;
            this.cmdVN.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cmdVN.HelpText = "";
            this.cmdVN.Image = global::FTS.BaseUI.Properties.Resources.flag_vietnam;
            this.cmdVN.Location = new System.Drawing.Point(0, 0);
            this.cmdVN.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.cmdVN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdVN.Name = "cmdVN";
            this.cmdVN.Size = new System.Drawing.Size(32, 26);
            this.cmdVN.TabIndex = 4;
            this.cmdVN.Click += new System.EventHandler(this.Language_Click);
            // 
            // FTSLanguageToolbar
            // 
            this.Controls.Add(this.cmdVN);
            this.Controls.Add(this.cmdEN);
            this.Controls.Add(this.cmdJP);
            this.Controls.Add(this.cmdKR);
            this.Controls.Add(this.cmdLaos);
            this.Name = "FTSLanguageToolbar";
            this.Size = new System.Drawing.Size(152, 26);
            this.ResumeLayout(false);

        }

        #endregion

          private FTS.BaseUI.Controls.FTSButton cmdVN;
        private FTS.BaseUI.Controls.FTSButton cmdJP;
        private FTS.BaseUI.Controls.FTSButton cmdEN;
        private FTS.BaseUI.Controls.FTSButton cmdKR;
        private Controls.FTSButton cmdLaos;
    }
}
