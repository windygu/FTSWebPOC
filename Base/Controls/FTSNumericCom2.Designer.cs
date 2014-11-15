using System;
using System.Collections.Generic;

using System.Text;

namespace FTS.BaseUI.Controls
{
    partial class FTSNumericCom2
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
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.textNumeric = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumeric.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label.Appearance.Options.UseBackColor = true;
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(80, 20);
            this.label.TabIndex = 0;
            // 
            // textNumeric
            // 
            this.textNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textNumeric.EditValue = "";
            this.textNumeric.EnterMoveNextControl = true;
            this.textNumeric.Location = new System.Drawing.Point(80, 0);
            this.textNumeric.Name = "textNumeric";
            this.textNumeric.Properties.Appearance.Options.UseTextOptions = true;
            this.textNumeric.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textNumeric.Properties.AutoHeight = false;
            this.textNumeric.Size = new System.Drawing.Size(80, 20);
            this.textNumeric.TabIndex = 0;
            // 
            // BESNumericCom
            // 
            this.Controls.Add(this.textNumeric);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(160, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.textNumeric.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.TextEdit textNumeric;
    }
}
