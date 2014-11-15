using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace FTS.BaseUI.Forms
{
    public partial class FrmTouchscreen : XtraForm
    {
        private bool showMinimize = true;
        private bool showClose = true;
        private bool showRight = true;
        private bool showIpos = false;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public FrmTouchscreen()
        {
            this.showMinimize = true;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseFrom();
        }

        internal virtual void CloseFrom()
        {
            this.Close();
        }
        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DefaultValue(true)]
        public bool ShowMinimize
        {
            get { return showMinimize; }
            set {
                showMinimize = value;
                this.btnMinimum.Visible = showMinimize; 
            }
        }
        [DefaultValue(true)]
        public bool ShowClose
        {
            get { return showClose; }
            set
            {
                showClose = value;
                this.btnClose.Visible = showClose;
            }
        }
        [DefaultValue(false)]
        public bool ShowIpos
        {
            get { return showIpos; }
            set
            {
                showIpos = value;
                this.lblFts.Visible = showIpos;
            }
        }
        [DefaultValue(true)]
        public bool ShowRight
        {
            get { return this.showRight; }
            set {
                this.showRight = value;
                if (this.showRight)
                {
                    this.palTitle.Controls.Clear();
                    this.palTitle.Controls.Add(this.btnClose);
                    this.palTitle.Controls.Add(this.btnMinimum);
                    this.palTitle.Controls.Add(this.lblFts);
                    this.btnMinimum.Dock = DockStyle.Right;
                    this.btnClose.Dock = DockStyle.Right;
                }
                else
                {
                    this.palTitle.Controls.Clear();
                    this.palTitle.Controls.Add(this.btnMinimum);
                    this.palTitle.Controls.Add(this.btnClose);
                    this.palTitle.Controls.Add(this.lblFts);
                    this.btnMinimum.Dock = DockStyle.Left;
                    this.btnClose.Dock = DockStyle.Left;
                }
            }
        }
        private void palTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}