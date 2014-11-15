using FTS.BaseUI.Controls;

namespace FTS.BaseUI.ImportData {
    partial class FrmDm_Template {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtTemplate_Name = new FTS.BaseUI.Controls.FTSTextCom();
            this.chkActive = new FTS.BaseUI.Controls.FTSCheckCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).BeginInit();
            this.palFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).BeginInit();
            this.groupHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).BeginInit();
            this.palRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(703, 26);
            // 
            // palMain
            // 
            this.palMain.Size = new System.Drawing.Size(703, 428);
            // 
            // palFill
            // 
            this.palFill.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palFill.Appearance.Options.UseBackColor = true;
            this.palFill.Size = new System.Drawing.Size(693, 428);
            // 
            // groupBottom
            // 
            this.groupBottom.Location = new System.Drawing.Point(0, 349);
            this.groupBottom.Size = new System.Drawing.Size(693, 27);
            // 
            // groupBottom0
            // 
            this.groupBottom0.Location = new System.Drawing.Point(0, 376);
            this.groupBottom0.Size = new System.Drawing.Size(693, 52);
            // 
            // groupHeader
            // 
            this.groupHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupHeader.Appearance.Options.UseBackColor = true;
            this.groupHeader.Controls.Add(this.txtTemplate_Name);
            this.groupHeader.Controls.Add(this.chkActive);
            this.groupHeader.Location = new System.Drawing.Point(0, 27);
            this.groupHeader.Size = new System.Drawing.Size(693, 42);
            this.groupHeader.Tag = "1";
            // 
            // groupGrid
            // 
            this.groupGrid.Location = new System.Drawing.Point(0, 69);
            this.groupGrid.Size = new System.Drawing.Size(693, 280);
            // 
            // palExtTop
            // 
            this.palExtTop.Size = new System.Drawing.Size(693, 27);
            // 
            // palRight
            // 
            this.palRight.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.palRight.Appearance.Options.UseBackColor = true;
            this.palRight.Location = new System.Drawing.Point(693, 0);
            this.palRight.Size = new System.Drawing.Size(10, 428);
            // 
            // split
            // 
            this.split.Size = new System.Drawing.Size(5, 428);
            // 
            // txtTemplate_Name
            // 
            this.txtTemplate_Name.BackColor = System.Drawing.Color.Transparent;
            this.txtTemplate_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTemplate_Name.HelpText = "";
            this.txtTemplate_Name.LabelLength = 90;
            this.txtTemplate_Name.LabelText = "Tên mẫu khai báo";
            this.txtTemplate_Name.Location = new System.Drawing.Point(12, 9);
            this.txtTemplate_Name.Name = "txtTemplate_Name";
            this.txtTemplate_Name.Size = new System.Drawing.Size(606, 22);
            this.txtTemplate_Name.TabIndex = 5;
            this.txtTemplate_Name.Text = "Tên mẫu khai báo";
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.HelpText = "";
            this.chkActive.LabelLenght = 37;
            this.chkActive.LabelText = "Active";
            this.chkActive.Location = new System.Drawing.Point(624, 10);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(57, 21);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Active";
            // 
            // FrmDm_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(703, 454);
            this.Name = "FrmDm_Template";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palFill)).EndInit();
            this.palFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBottom0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupHeader)).EndInit();
            this.groupHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palExtTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palRight)).EndInit();
            this.palRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FTSTextCom txtTemplate_Name;
        private FTSCheckCom chkActive;
    }
}