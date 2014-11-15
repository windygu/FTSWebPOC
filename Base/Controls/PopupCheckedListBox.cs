using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FTS.BaseBusiness.Systems;
using System.Drawing;
using System.Windows.Forms;

namespace FTS.BaseUI.Controls
{
    [ToolboxItem(false)]
    public partial class PopupCheckedListBox : PopupContainerControl
    {
        private FTSMain mFtsMain;
        private DataSet mDataSet;
        private string mTableName;        
        private string mNameField, mIdField;
        private CheckedListBoxControl mChecklist;

        public PopupCheckedListBox()
        {
            InitializeComponent();            
        }
        public PopupCheckedListBox(FTSMain ftsmain, DataSet ds, string tablename)
        {
            this.mFtsMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mNameField = this.mFtsMain.TableManager.GetNameField(this.mTableName);
            this.mIdField = this.mFtsMain.TableManager.GetIDField(this.mTableName);
            InitializeComponent();
            this.CreatePopup();
        }
        public PopupCheckedListBox(FTSMain ftsmain, DataSet ds, string tablename,string idfield,string namefield)
        {
            this.mFtsMain = ftsmain;
            this.mDataSet = ds;
            this.mTableName = tablename;
            this.mNameField = namefield;
            this.mIdField = idfield;
            InitializeComponent();
            this.CreatePopup();
        }
        private void CreatePopup()
        {            
            this.Size = new System.Drawing.Size(300, 200);            
            SimpleButton btnOk = new SimpleButton();
            btnOk.Name = "btnOk";
            btnOk.Location = new Point(112, 6);
            btnOk.Size = new Size(85, 23);
            btnOk.Text = "Ok";            
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnOk.Click += new EventHandler(btnOk_Click);

            SimpleButton btnCancel = new SimpleButton();
            btnCancel.Name = "btnCancel";
            btnCancel.Location = new Point(204, 6);
            btnCancel.Size = new Size(85, 23);
            btnCancel.Text = "Cancel";            
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Click += new EventHandler(btnCancel_Click);
            Panel panel = new Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel.Size = new Size(300, 33);
            panel.Name = "panel";
            panel.Controls.Add(btnOk);
            panel.Controls.Add(btnCancel);

            mChecklist = new CheckedListBoxControl();
            mChecklist.ItemHeight = 16;
            mChecklist.Dock = System.Windows.Forms.DockStyle.Fill;            
            this.Controls.Add(mChecklist);
            this.Controls.Add(panel);
            mChecklist.DataSource = this.mDataSet.Tables[this.mTableName];
            mChecklist.DisplayMember = this.mNameField;
            mChecklist.ValueMember = this.mIdField;
            int i = 0;
            while (this.mChecklist.GetItem(i) != null)
            {                
                this.mChecklist.SetItemCheckState(i, CheckState.Unchecked);
                i++;
            }            
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string Id = string.Empty;
            foreach (object obj in this.mChecklist.CheckedItems)
            {
                Id = Id + ":" + ((DataRowView)obj)[this.mIdField].ToString();
            }
            Id = Id + ":";
            if (this.OwnerEdit != null)
            {
                this.OwnerEdit.EditValue = Id;
                this.OwnerEdit.ClosePopup();
            }
        }
        public void Reset()
        {
            int i = 0;
            while (this.mChecklist.GetItem(i) != null)
            {                
                this.mChecklist.SetItemCheckState(i, CheckState.Unchecked);
                i++;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(this.OwnerEdit!=null)
                this.OwnerEdit.ClosePopup();
        }
        public CheckedListBoxControl CheckList
        {
            get { return this.mChecklist; }
        }
        public string NameField
        {
            get { return this.mNameField; }
        }
    }
}
