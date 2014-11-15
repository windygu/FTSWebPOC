#region

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

#endregion

namespace FTS.BaseUI.Controls {
    public partial class FTSShadowPanel : PanelControl {
        private Size roundedsize = new Size(4, 4);
        private Color skinbackcolor = System.Drawing.SystemColors.Control;
        private bool drawbackgroundimage = false;
        public FTSShadowPanel() {
            this.InitializeComponent();
        }

        private void DrawRoundedRectangle(Graphics g, Pen p, Rectangle rc, Size size) {
            SmoothingMode mode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(p, rc.Left + (size.Width/2), rc.Top, rc.Right - (size.Width/2), rc.Top);
            g.DrawLine(p, rc.Left, rc.Bottom - (size.Height/2), rc.Left, rc.Top + (size.Height/2));
            g.DrawArc(p, rc.Left, rc.Top, size.Width, size.Height, 180, 90);
            g.DrawArc(p, rc.Right - size.Width, rc.Top, size.Width, size.Height, 270, 90);
            g.DrawLine(p, rc.Right, rc.Top + (size.Height/2), rc.Right, rc.Bottom - (size.Height/2));
            g.DrawArc(p, rc.Right - size.Width, rc.Bottom - size.Height, size.Width, size.Height, 0, 90);
            g.DrawLine(p, rc.Right - (size.Width/2), rc.Bottom, rc.Left + (size.Width/2), rc.Bottom);
            g.DrawArc(p, rc.Left, rc.Bottom - size.Height, size.Width, size.Height, 90, 90);
            g.SmoothingMode = mode;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (!this.drawbackgroundimage)
            {
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
                        this.NoBorderColor = true;
                        this.BorderStyle = BorderStyles.NoBorder;
                    }
                    else
                    {
                        SkinElement elementbackcolor = skin[CommonSkins.SkinGroupPanel];
                        this.Appearance.BackColor = elementbackcolor.Color.BackColor;
                        this.Appearance.Options.UseBackColor = true;
                        this.skinbackcolor = this.Appearance.BackColor;
                    }
                    SkinElement elementborder = skin[CommonSkins.SkinTextBorder];
                    Color color = elementborder.Border.All;
                    if (this.UseBorderColor)
                    {
                        color = this.BorderColor;
                    }
                    if (this.NoBorderColor)
                    {
                        color = this.BackColor;
                    }
                    Graphics gfx = e.Graphics;
                    Rectangle rectangle = new Rectangle(this.blankwidth, this.blankwidth, this.Width - 1 - this.blankwidth * 2,
                                                        this.Height - 1 - this.blankwidth * 2);
                    SmoothingMode mode = gfx.SmoothingMode;
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(color))
                    {
                        this.DrawRoundedRectangle(gfx, pen, rectangle, this.RoundedSize);
                    }
                    gfx.SmoothingMode = mode;
                }
                catch (Exception)
                {
                }
                finally
                {
                    cache.Dispose();
                }
            }
        }

        [DefaultValue(typeof (Size), "4,4")]
        public Size RoundedSize {
            get { return this.roundedsize; }
            set {
                this.roundedsize = value;
                this.Invalidate();
            }
        }

        private int blankwidth = 0;

        [DefaultValue(typeof (int), "0")]
        public int BlankWidth {
            set { this.blankwidth = value; }
            get { return this.blankwidth; }
        }

        [DefaultValue(typeof (int), "0")]
        public int ShadowWidth {
            set { int x = 0; }
            get { return 0; }
        }

        private bool mUserBorderColor = false;

        [DefaultValue(typeof (bool), "false")]
        public bool UseBorderColor {
            get { return this.mUserBorderColor; }
            set { this.mUserBorderColor = value; }
        }

        private bool mNoBorderColor = false;

        [DefaultValue(typeof (bool), "false")]
        public bool NoBorderColor {
            get { return this.mNoBorderColor; }
            set { this.mNoBorderColor = value; }
        }

        [DefaultValue(typeof(bool), "false")]
        public bool DrawBackgroundImage
        {
            get { return this.drawbackgroundimage; }
            set { this.drawbackgroundimage = value; }
        }
        private Color bordercolor;

        [DefaultValue(typeof (Color), "Black")]
        public Color BorderColor {
            set { this.bordercolor = value; }
            get { return this.bordercolor; }
        }

        public Color BorderShadowColor {
            set { }
        }

        public Color ShadowColor {
            set { }
        }

        public Color ColorStartLight {
            set { }
        }

        public Color ColorEndLight {
            set { }
        }

        public Color SkinBackColor
        {
            get { return this.skinbackcolor; }
            set { this.skinbackcolor = value; }
        }
        private bool NoVisibleControls() {
            foreach (Control c in this.Controls) {
                if (c.Visible) {
                    return false;
                }
            }
            return true;
        }
    }
}