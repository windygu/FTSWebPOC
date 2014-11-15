using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using DevExpress.XtraEditors;
using FTS.BaseUI.Controls;

namespace FTS.BaseUI.Controls
{
    public partial class FTSCheckListCom : Panel, IRequire, IValid
    {
        private bool mRequire = false;
        public FTSCheckListCom()
        {
            InitializeComponent();
            this.SetProperty();
        }
        public void Set(FTSMain ftsmain, DataSet ds, string tablename)
        {
            PopupCheckedListBox popupcontrol = new PopupCheckedListBox(ftsmain, ds, tablename);            
            this.popupEdit.Properties.PopupControl = popupcontrol;
            this.popupEdit.Properties.QueryPopUp += new CancelEventHandler(Properties_QueryPopUp);            
            this.popupEdit.Properties.QueryDisplayText += new QueryDisplayTextEventHandler(Properties_QueryDisplayText);
            this.popupEdit.LostFocus += new EventHandler(popupEdit_LostFocus);
        }
        public void Set(FTSMain ftsmain, DataSet ds, string tablename,string idfield,string namefield)
        {
            PopupCheckedListBox popupcontrol = new PopupCheckedListBox(ftsmain, ds, tablename,idfield,namefield);
            this.popupEdit.Properties.PopupControl = popupcontrol;
            this.popupEdit.Properties.QueryPopUp += new CancelEventHandler(Properties_QueryPopUp);
            this.popupEdit.Properties.QueryDisplayText += new QueryDisplayTextEventHandler(Properties_QueryDisplayText);
            this.popupEdit.LostFocus += new EventHandler(popupEdit_LostFocus);
        }
        private void Properties_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            if (e.EditValue == null || e.EditValue == DBNull.Value || e.EditValue.ToString().Trim()== string.Empty)
                e.DisplayText = string.Empty;
            else
            {
                string text = string.Empty;
                CheckedListBoxControl checklist = ((PopupCheckedListBox)this.popupEdit.Properties.PopupControl).CheckList;
                string namefield = ((PopupCheckedListBox)this.popupEdit.Properties.PopupControl).NameField;
                string[] strs = e.EditValue.ToString().Trim().Split(':');
                foreach (string id in strs)
                {
                    DataRow foundrow = ((DataTable)checklist.DataSource).Rows.Find(id);
                    if (foundrow != null)
                    {
                        text = text + "; " + foundrow[namefield].ToString();
                    }
                }
                if (text != string.Empty)
                    e.DisplayText = text.Substring(1);
                else
                    e.DisplayText = string.Empty;
            }
        }        

        private void Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            ((PopupCheckedListBox)this.popupEdit.Properties.PopupControl).Reset();
            if ((this.popupEdit.EditValue != null) && (this.popupEdit.EditValue.ToString().Trim() != string.Empty))
            {                
                string[] id = this.popupEdit.EditValue.ToString().Trim().Split(':');
                int i = 0;
                CheckedListBoxControl checklist = ((PopupCheckedListBox)this.popupEdit.Properties.PopupControl).CheckList;
                while (checklist.GetItem(i) != null)
                {
                    foreach (object obj in id)
                    {
                        if (checklist.GetItemValue(i).ToString().Trim().ToUpper() == obj.ToString().Trim().ToUpper())
                        {
                            checklist.SetItemCheckState(i, CheckState.Checked);
                            break;
                        }
                    }
                    i++;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!this.popupEdit.IsPopupOpen)
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
        private void SetProperty()
        {
            this.popupEdit.Properties.AppearanceDisabled.BackColor = Color.White;
            this.popupEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
            this.popupEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.popupEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.popupEdit.Properties.ShowPopupCloseButton = false;
            this.popupEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;            
        }
        private void popupEdit_LostFocus(object sender, EventArgs e)
        {
            try
            {
                FTSForm frmparent = (FTSForm)this.FindForm();
                frmparent.PreviousControl = this.popupEdit;
            }
            catch { }
        }
        public void EndEdit()
        {
            if (this.popupEdit.DataBindings.Count > 0)
            {
                this.popupEdit.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            this.popupEdit.Focus();
        }
        public bool IsValid()
        {
            if (this.mRequire)
            {
                if (this.popupEdit.EditValue.ToString().Trim() == string.Empty)
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
        [DefaultValue(false), Browsable(false)]
        public bool Require
        {
            get { return this.mRequire; }
            set
            {
                this.mRequire = value;
                if (this.mRequire)
                {
                    this.popupEdit.BackColor = SystemColors.Info;
                }
                else
                {
                    this.popupEdit.BackColor = Color.White;
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

        public override string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
        [Browsable(false)]
        public PopupContainerEdit PopupEdit
        {
            get { return this.popupEdit; }
        }
    }
}
