using DevExpress.XtraEditors;

namespace FTS.BaseUI.Controls {
    partial class FTSHourMinuteCom {
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
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.txtHour = new FTS.BaseUI.Controls.FTSSpinEdit();
            this.lblSeperator = new DevExpress.XtraEditors.LabelControl();
            this.txtMinute = new FTS.BaseUI.Controls.FTSSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(137, 20);
            this.label.TabIndex = 1;
            this.label.Text = "label";
            // 
            // txtHour
            // 
            this.txtHour.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtHour.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHour.EnterMoveNextControl = true;
            this.txtHour.HelpText = "";
            this.txtHour.Location = new System.Drawing.Point(137, 0);
            this.txtHour.Name = "txtHour";
            this.txtHour.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHour.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtHour.PromptText = "";
            this.txtHour.Properties.MaxValue = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHour.Size = new System.Drawing.Size(36, 20);
            this.txtHour.TabIndex = 2;
            // 
            // lblSeperator
            // 
            this.lblSeperator.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblSeperator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSeperator.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSeperator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSeperator.Location = new System.Drawing.Point(173, 0);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(10, 20);
            this.lblSeperator.TabIndex = 3;
            this.lblSeperator.Text = ":";
            // 
            // txtMinute
            // 
            this.txtMinute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMinute.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinute.EnterMoveNextControl = true;
            this.txtMinute.HelpText = "";
            this.txtMinute.Location = new System.Drawing.Point(183, 0);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.PromptFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtMinute.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtMinute.PromptText = "";
            this.txtMinute.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtMinute.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtMinute.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtMinute.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtMinute.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtMinute.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMinute.Properties.AutoHeight = false;
            this.txtMinute.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMinute.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMinute.Properties.Mask.EditMask = "n0";
            this.txtMinute.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMinute.Properties.MaxValue = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMinute.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMinute.Size = new System.Drawing.Size(43, 20);
            this.txtMinute.TabIndex = 4;
            // 
            // FTSHourMinuteCom
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtMinute);
            this.Controls.Add(this.lblSeperator);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(226, 20);
            ((System.ComponentModel.ISupportInitialize)(this.txtHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private FTSSpinEdit txtHour;
        private DevExpress.XtraEditors.LabelControl lblSeperator;
        private FTSSpinEdit txtMinute;
    }
}
