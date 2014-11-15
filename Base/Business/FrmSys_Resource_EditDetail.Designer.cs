namespace FTS.BaseUI.Business
{
    partial class FrmSys_Resource_EditDetail
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
            this.txtRes_Id = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtRes_Value = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtRes_Value_En = new FTS.BaseUI.Controls.FTSTextCom();
            this.txtRes_Value_Jp = new FTS.BaseUI.Controls.FTSTextCom();
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).BeginInit();
            this.palMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Size = new System.Drawing.Size(299, 26);
            // 
            // palMain
            // 
            this.palMain.Controls.Add(this.txtRes_Id);
            this.palMain.Controls.Add(this.txtRes_Value);
            this.palMain.Controls.Add(this.txtRes_Value_En);
            this.palMain.Controls.Add(this.txtRes_Value_Jp);
            this.palMain.NoBorderColor = true;
            this.palMain.Size = new System.Drawing.Size(299, 130);
            // 
            // txtRes_Id
            // 
            this.txtRes_Id.BackColor = System.Drawing.Color.Transparent;
            this.txtRes_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRes_Id.HelpText = "";
            this.txtRes_Id.LabelText = "Mã Tài nguyên";
            this.txtRes_Id.Location = new System.Drawing.Point(12, 15);
            this.txtRes_Id.Name = "txtRes_Id";
            this.txtRes_Id.Size = new System.Drawing.Size(275, 22);
            this.txtRes_Id.TabIndex = 0;
            this.txtRes_Id.Text = "Mã Tài nguyên";
            // 
            // txtRes_Value
            // 
            this.txtRes_Value.BackColor = System.Drawing.Color.Transparent;
            this.txtRes_Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRes_Value.HelpText = "";
            this.txtRes_Value.LabelText = "Giá trị h.thị";
            this.txtRes_Value.Location = new System.Drawing.Point(12, 42);
            this.txtRes_Value.Name = "txtRes_Value";
            this.txtRes_Value.Size = new System.Drawing.Size(275, 22);
            this.txtRes_Value.TabIndex = 1;
            this.txtRes_Value.Text = "Giá trị h.thị";
            // 
            // txtRes_Value_En
            // 
            this.txtRes_Value_En.BackColor = System.Drawing.Color.Transparent;
            this.txtRes_Value_En.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRes_Value_En.HelpText = "";
            this.txtRes_Value_En.LabelText = "Giá trị En";
            this.txtRes_Value_En.Location = new System.Drawing.Point(12, 69);
            this.txtRes_Value_En.Name = "txtRes_Value_En";
            this.txtRes_Value_En.Size = new System.Drawing.Size(275, 22);
            this.txtRes_Value_En.TabIndex = 2;
            this.txtRes_Value_En.Text = "Giá trị En";
            // 
            // txtRes_Value_Jp
            // 
            this.txtRes_Value_Jp.BackColor = System.Drawing.Color.Transparent;
            this.txtRes_Value_Jp.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRes_Value_Jp.HelpText = "";
            this.txtRes_Value_Jp.LabelText = "Giá trị JP";
            this.txtRes_Value_Jp.Location = new System.Drawing.Point(12, 96);
            this.txtRes_Value_Jp.Name = "txtRes_Value_Jp";
            this.txtRes_Value_Jp.Size = new System.Drawing.Size(275, 22);
            this.txtRes_Value_Jp.TabIndex = 3;
            this.txtRes_Value_Jp.Text = "Giá trị JP";
            // 
            // FrmSys_Resource_EditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 156);
            this.Name = "FrmSys_Resource_EditDetail";
            this.Text = "FrmSys_Resource_EditDetail";
            ((System.ComponentModel.ISupportInitialize)(this.palMain)).EndInit();
            this.palMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        protected FTS.BaseUI.Controls.FTSTextCom txtRes_Id;
        protected FTS.BaseUI.Controls.FTSTextCom txtRes_Value;
        protected FTS.BaseUI.Controls.FTSTextCom txtRes_Value_En;
        protected FTS.BaseUI.Controls.FTSTextCom txtRes_Value_Jp;
    }
}
