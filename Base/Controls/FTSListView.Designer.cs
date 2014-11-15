using System.Windows.Forms;

namespace FTS.BaseUI.Controls
{
    partial class FTSListView
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            // 
            // FTSListView
            // 
            this.Name = "FTSListView";
            this.View = View.Details;
            this.ListViewItemSorter = new ListViewFilterSorter(this);
            //
            // mnu_filter
            //
            this.mnu_filter.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { this.mnu_datype, this.mnu_alignt, this.mnu_clearf, this.mnu_ignore });
            this.mnu_filter.Popup += new System.EventHandler(this.ContextMenuPopup);
            // 
            // mnu_datype
            // 
            this.mnu_datype.Index = 0;
            this.mnu_datype.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { this.mnu_strflt, this.mnu_nbrflt, this.mnu_datflt });
            // 
            // mnu_alignt
            // 
            this.mnu_alignt.Index = 1;
            this.mnu_alignt.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { this.mnu_alignl, this.mnu_alignr, this.mnu_alignc });
            // 
            // mnu_clearf
            // 
            this.mnu_clearf.DefaultItem = true;
            this.mnu_clearf.Index = 2;
            this.mnu_clearf.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_refrsh
            // 
            this.mnu_ignore.Index = 3;
            this.mnu_ignore.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_strflt
            // 
            this.mnu_strflt.Index = 0;
            this.mnu_strflt.RadioCheck = true;
            this.mnu_strflt.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_nbrflt
            // 
            this.mnu_nbrflt.Index = 1;
            this.mnu_nbrflt.RadioCheck = true;
            this.mnu_nbrflt.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_datflt
            // 
            this.mnu_datflt.Index = 2;
            this.mnu_datflt.RadioCheck = true;
            this.mnu_datflt.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_alignl
            // 
            this.mnu_alignl.Index = 0;
            this.mnu_alignl.RadioCheck = true;
            this.mnu_alignl.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_alignr
            // 
            this.mnu_alignr.Index = 1;
            this.mnu_alignr.RadioCheck = true;
            this.mnu_alignr.Click += new System.EventHandler(this.MenuItemClick);
            // 
            // mnu_alignc
            // 
            this.mnu_alignc.Index = 2;
            this.mnu_alignc.RadioCheck = true;
            this.mnu_alignc.Click += new System.EventHandler(this.MenuItemClick);
        }

        #endregion
    }
}
