#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSLookUpEdit : LookUpEdit, IHelpField {
        public FTSLookUpEdit() {
            this.InitializeComponent();
        }

        public void SetFont() {
            this.Font = new Font(FTSConstant.JAPANESE_FONT, 8);
        }

        private bool mIsUnderline = false;

        [DefaultValue(false)]
        public bool IsUnderline {
            get { return this.mIsUnderline; }
            set { this.mIsUnderline = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (this.mIsUnderline) {
                GraphicsCache cache = new GraphicsCache(e);
                try {
                    Graphics gfx = e.Graphics;
                    SmoothingMode mode = gfx.SmoothingMode;
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.DarkGray)) {
                        gfx.DrawLine(pen, 0, this.Height - 3, this.Width, this.Height - 3);
                    }
                    gfx.SmoothingMode = mode;
                } catch (Exception) {
                } finally {
                    cache.Dispose();
                }
            }
        }

        #region IHelpField Members

        private string mHelpText = string.Empty;

        public string HelpText {
            get { return this.mHelpText; }
            set {
                this.mHelpText = value;
                FTSForm form = this.FindForm() as FTSForm;
                if (form != null) {
                    form.SetBalloonTooltip(this, this.mHelpText);
                }
            }
        }

        #endregion
    }
}