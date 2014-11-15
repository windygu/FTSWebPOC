using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace FTS.BaseUI.Controls {
    partial class FTSVatCom {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSVatCom));
            this.Label = new FTS.BaseUI.Controls.FTSLabel();
            this.txtId = new FTS.BaseUI.Controls.FTSTextBox();
            this.cmdFind = new FTS.BaseUI.Controls.FTSButton();
            this.txtAmount = new FTS.BaseUI.Controls.FTSNumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.Color.Transparent;            
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Label.ForeColor = System.Drawing.Color.Black;
            this.Label.HelpText = "";
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(81, 20);
            this.Label.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.EnterMoveNextControl = true;
            this.txtId.HelpText = "";
            this.txtId.Location = new System.Drawing.Point(116, 0);
            this.txtId.Name = "txtId";
            this.txtId.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtId.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtId.PromptText = "";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtId.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Properties.Appearance.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtId.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtId.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtId.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtId.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtId.Properties.AutoHeight = false;            
            this.txtId.Size = new System.Drawing.Size(46, 19);
            this.txtId.TabIndex = 1;
            // 
            // cmdFind
            // 
            this.cmdFind.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdFind.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmdFind.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmdFind.Appearance.Options.UseBackColor = true;
            this.cmdFind.Appearance.Options.UseFont = true;
            this.cmdFind.Appearance.Options.UseForeColor = true;
            this.cmdFind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdFind.BackgroundImage")));
            this.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdFind.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cmdFind.HelpText = "";
            this.cmdFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdFind.Location = new System.Drawing.Point(168, 0);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(19, 19);
            this.cmdFind.TabIndex = 2;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(200, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtAmount.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtAmount.PromptText = "";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtAmount.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.Appearance.Options.UseForeColor = true;
            this.txtAmount.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtAmount.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtAmount.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAmount.Properties.AutoHeight = false;            
            this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.Mask.EditMask = "n";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(158, 19);
            this.txtAmount.TabIndex = 3;
            // 
            // FTSVatCom
            // 
            this.Controls.Add(this.Label);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.txtAmount);
            this.Name = "FTSVatCom";
            this.Size = new System.Drawing.Size(360, 20);
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private FTSLabel Label;
        private FTSButton cmdFind;
        public FTSNumericTextBox txtAmount;
        private FTSTextBox txtId;
    }
}
