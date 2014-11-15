using System.Drawing;

namespace FTS.BaseUI.Controls
{
    partial class FTSNameIDCom
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
            this.components = new System.ComponentModel.Container();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.textId = new FTSButtonEdit();
            this.textName = new FTSUnderlineLabel();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
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
            // textId
            // 
            this.textId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textId.EditValue = "";
            this.textId.EnterMoveNextControl = true;
            this.textId.Location = new System.Drawing.Point(80, 0);
            this.textId.Name = "textId";
            this.textId.Properties.AutoHeight = false;
            this.textId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.textId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textId.Size = new System.Drawing.Size(50, 20);
            this.textId.TabIndex = 0;
            this.textId.EditValueChanged += new System.EventHandler(this.textId_EditValueChanged);
            this.textId.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.textId_ButtonPressed);
            // 
            // textName
            // 
            this.textName.Dock = System.Windows.Forms.DockStyle.Right;
            this.textName.Location = new System.Drawing.Point(130, 0);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(80, 20);
            this.textName.TabIndex = 0;
            this.textName.TextAlign = ContentAlignment.MiddleLeft;
            
            // 
            // FTSNameIDCom
            // 
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label);
            this.Size = new System.Drawing.Size(210, 20);
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label;
        private FTSButtonEdit textId;
        private FTSUnderlineLabel textName;
    }
}
