using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Layout;

namespace FTS.BaseUI.Controls
{
    public delegate void ChangingStatusEventHandler(object sender, StatusCancelEventArgs e);

    public partial class FTSStatus : PanelControl
    {
        public event ChangingStatusEventHandler ChangingStatus;
        private List<ItemCombobox> mLstStatus;
        private int mProcess;
        private string mCurrentStatus = string.Empty;

        public FTSStatus()
        {
            InitializeComponent();            
        }

        public void Set(List<ItemCombobox> lstStatus, int process)
        {
            this.mLstStatus = lstStatus;
            this.mProcess = process;
            foreach (ItemCombobox status in this.mLstStatus)
            {
                if ((System.Convert.ToInt32(status.Tag) & this.mProcess) != 0)
                {
                    FTSButton ftsbutton = new FTSButton();
                    ftsbutton.Name = status.Id;
                    ftsbutton.Text = status.Name;
                    ftsbutton.Tag = status.Tag;
                    ftsbutton.Size = new System.Drawing.Size(90, 30);
                    ftsbutton.Click += new EventHandler(ftsbutton_Click);
                    ftsbutton.Visible = false;
                    this.Controls.Add(ftsbutton);
                }
            }
            this.LayoutItems();
        }

        private void ftsbutton_Click(object sender, EventArgs e)
        {
            if (this.ChangingStatus != null)
            {
                StatusCancelEventArgs args = new StatusCancelEventArgs(this.mCurrentStatus);
                ChangingStatus(sender, args);
                if (!args.Cancel)
                {
                    this.lblStatus.Text = ((FTSButton)sender).Name;
                    this.UpdateInfo();
                }
            }
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            this.ShowHideStatus(this.lblStatus.Text);
        }

        public void UpdateInfo()
        {
            this.ShowHideStatus(this.lblStatus.Text);
        }

        private void ShowHideStatus(string currentStatus)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is FTSButton)
                {
                    ctl.Enabled = true;
                    ctl.Visible = false;
                }
            }
            int current = 0;
            for (int i = 0; i < this.mLstStatus.Count; i++)
            {
                if (this.mLstStatus[i].Id == currentStatus)
                {
                    current = i;
                    break;
                }
            }
            FTSButton btnPrevious = null;
            if (current != 0)
                btnPrevious = (FTSButton)this.Controls[current];
            FTSButton btnCurrent = (FTSButton)this.Controls[current + 1];
            FTSButton btnNext = null;
            if(current+2<=this.mLstStatus.Count)
               btnNext = (FTSButton)this.Controls[current + 2];
            if (btnPrevious != null)
            {
                btnPrevious.Visible = true;
                btnPrevious.Enabled = true;
            }
            if (btnCurrent != null)
            {
                btnCurrent.Visible = true;
                btnCurrent.Enabled = false;
                this.mCurrentStatus = btnCurrent.Name;
            }
            if (btnNext != null)
            {
                btnNext.Visible = true;
                btnNext.Enabled = true;
            }
        }

        private void LayoutItems()
        {
            FlowLayout layout = new FlowLayout();
            layout.Alignment = FlowAlignment.Far;
            layout.TopMargin = 6;
            layout.BottomMargin = 6;
            layout.HorzFarMargin = 6;
            layout.VGap = 0;
            layout.HGap = 0;
            layout.ContainerControl = this;
            layout.AutoHeight = true;
            layout.AutoLayout = true;
        }

        public FTSLabel LabelStatus
        {
            get { return this.lblStatus; }
            set { this.lblStatus = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            
            GraphicsCache cache = new GraphicsCache(e);
            try
            {
                Skin skin = CommonSkins.GetSkin(this.LookAndFeel.ActiveLookAndFeel);
                if (this.NoVisibleControls())
                {
                    this.Appearance.Options.UseBackColor = false;
                    this.LookAndFeel.Style = LookAndFeelStyle.Skin;
                    this.LookAndFeel.UseDefaultLookAndFeel = true;
                    this.Appearance.Options.UseBorderColor = false;                    
                    this.BorderStyle = BorderStyles.NoBorder;
                }
                else
                {
                    SkinElement elementbackcolor = skin[CommonSkins.SkinGroupPanel];
                    this.Appearance.BackColor = elementbackcolor.Color.BackColor;
                    this.Appearance.Options.UseBackColor = true;                    
                }                
            }
            catch (Exception)
            {
            }
            finally
            {
                cache.Dispose();
            }            
        }
        private bool NoVisibleControls()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Visible)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class StatusCancelEventArgs : CancelEventArgs
    {
        private string mCurrentStatus = string.Empty;

        public StatusCancelEventArgs()
        { 
        }
        public StatusCancelEventArgs(string currentstatus)
        {
            this.mCurrentStatus = currentstatus;
        }

        public string CurrentStatus
        {
            get { return this.mCurrentStatus; }
        }
    }
}
