using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

namespace FTS.BaseUI.Controls
{
    public partial class FTSColorCom : Panel, IRequire, IValid
    {
        private bool mIsChanged = false;
        private bool mRequire = false;

        public FTSColorCom()
        {
            InitializeComponent();
            this.SetProperty();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!this.colorEdit.IsPopupOpen)
            {
                switch (msg.WParam.ToInt32())
                {
                    case (int)Keys.Down:
                    case (int)Keys.Enter:
                        SendKeys.Send("{Tab}");
                        return true;
                    case (int)Keys.Up:
                        SendKeys.Send("+{Tab}");
                        return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        [DefaultValue(false), Browsable(false)]
        public bool Require
        {
            get { return this.mRequire; }
            set
            {
                this.mRequire = value;
                if (this.mRequire)
                {
                    this.colorEdit.BackColor = SystemColors.Info;
                }
                else
                {
                    this.colorEdit.BackColor = Color.White;
                }
            }
        }
        [DefaultValue(80)]
        public int LabelLength
        {
            get { return label.Width; }
            set { label.Width = value; }
        }

        public string LabelText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
        public override string Text {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        [Browsable(false)]
        public ColorEdit ColorEdit
        {
            get { return this.colorEdit; }
            set { this.colorEdit = value; }
        }
        public bool IsChanged
        {
            get { return this.mIsChanged; }
            set { this.mIsChanged = value; }
        }
        private void SetProperty()
        {
            this.colorEdit.Properties.AppearanceDisabled.BackColor = Color.White;
            this.colorEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.colorEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.colorEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.colorEdit.EditValueChanged += new EventHandler(this.EditValueChanged);
            this.colorEdit.LostFocus += new EventHandler(colorEdit_LostFocus);
        }

        private void colorEdit_LostFocus(object sender, EventArgs e)
        {
            try
            {
                FTSForm frmparent = (FTSForm)this.FindForm();
                frmparent.PreviousControl = this.colorEdit;
            }
            catch { }
        }       
        public void EndEdit()
        {
            if (colorEdit.DataBindings.Count > 0)
            {
                colorEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            this.colorEdit.Focus();
        }
        protected override void OnEnter(EventArgs e)
        {
            this.mIsChanged = false;
        }

        private void EditValueChanged(object sender, EventArgs e)
        {
            this.mIsChanged = true;
        }
        public bool IsValid()
        {
            if (this.mRequire)
            {
                if (this.colorEdit.Color.Name.Trim() == string.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public void SetFont() {
            this.label.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }
    }
}
