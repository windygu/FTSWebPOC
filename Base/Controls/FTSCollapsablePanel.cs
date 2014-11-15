//********************************************************************************************//
//		Sliding Panel User Control															 
//		Sufian Mehmood Sheikh
//		sufian@my.web.pk
//********************************************************************************************/

#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Controls {
    /// <summary>
    /// Summary description for CollapsablePanel.
    /// </summary>
    public class FTSCollapsablePanel : UserControl {
        private Button button1;
        private FTSShadowPanel panel1;
        private ImageList imageList1;
        private IContainer components;
        private int height = 80;
        private int AnimationRate = 20;
        private int mBlankWidth = 0;
        private bool mIsHeight = true;

        /// <summary>
        /// Gets/Sets Panel Label
        /// </summary>
        public string Button_Text {
            get { return this.button1.Text.Trim(); }
            set { this.button1.Text = "          " + value; }
        }

        /// <summary>
        /// Gets/Sets Contentpane Height
        /// </summary>
        public int ContentPane_HEIGHT {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets/Sets Animation Rate
        /// </summary>
        public int Animation_Rate {
            get { return this.AnimationRate; }
            set { this.AnimationRate = value; }
        }

        /// <summary>
        /// Gets/Sets Content Pane
        /// </summary>
        public FTSShadowPanel ContentPane {
            get {
                try {
                    return (FTSShadowPanel) this.panel1.Controls[0];
                } catch (Exception e) {
                    e = e;
                }
                return null;
            }
            set {
                try {
                    this.panel1.Controls.Clear();
                    this.panel1.Controls.Add(value);
                    this.panel1.Height = value.Height;
                } catch (Exception e) {
                    e = e;
                }
            }
        }

        [DefaultValue(typeof (int), "0")]
        public int BlankWidth {
            get { return this.mBlankWidth; }
            set { this.mBlankWidth = value; }
        }

        [DefaultValue(typeof (bool), "true")]
        public bool IsHeight {
            get { return this.mIsHeight; }
            set {
                if (value == false) {
                    this.button1.Dock = DockStyle.Left;
                    this.button1.Width = 28;
                }
                this.mIsHeight = value;
            }
        }

        public FTSCollapsablePanel() {
            // This call is required by the Windows.Forms Form Designer.
            this.InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (this.components != null) {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (FTSCollapsablePanel));
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new FTSShadowPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(568, 28);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 200);
            this.panel1.TabIndex = 1;
            // 
            // FTSCollapsablePanel
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "FTSCollapsablePanel";
            this.Size = new System.Drawing.Size(568, 228);
            //this.Load += new System.EventHandler(this.CollapsablePanel_Load);
            //this.Resize += new System.EventHandler(this.CollapsablePanel_Resize);
            this.ResumeLayout(false);
        }

        #endregion

        public void Collapse() {
            this.button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e) {
            if (this.IsHeight) {
                if (this.Height > this.button1.Height) {
                    //while (this.Height > this.button1.Height){
                    //    Application.DoEvents();
                    //    //Rate of Decrement
                    //    //this.Height -=2;
                    //    this.Height -= AnimationRate;
                    //}
                    this.button1.ImageIndex = 1;
                    this.Height = this.button1.Height;
                } else if (this.Height == this.button1.Height) {
                    int x = this.button1.Height + this.height;
                    //while (this.Height <= (x)){
                    //    Application.DoEvents();
                    //    //Rate of Increment
                    //    //this.Height +=2;					
                    //    this.Height += AnimationRate;
                    //}
                    this.button1.ImageIndex = 0;
                    this.Height = x;
                }
            } else {
                if (this.Width > this.button1.Width) {
                    //while (this.Width > this.button1.Width) {
                    //    Application.DoEvents();
                    //    //Rate of Decrement
                    //    //this.Height -=2;
                    //    this.Width -= AnimationRate;
                    //}
                    this.button1.ImageIndex = 1;
                    this.Width = this.button1.Width;
                } else if (this.Width == this.button1.Width) {
                    int x = this.button1.Width + this.height;
                    //while (this.Height <= (x)) {
                    //    Application.DoEvents();
                    //    //Rate of Increment
                    //    //this.Height +=2;					
                    //    this.Height += AnimationRate;
                    //}
                    this.button1.ImageIndex = 0;
                    this.Width = x;
                }
            }
        }

        //private void CollapsablePanel_Resize(object sender, System.EventArgs e)
        //{
        //    if((this.Height%2)!=0)
        //        this.Height+=1;
        //}

        //private void CollapsablePanel_Load(object sender, System.EventArgs e)
        //{
        //    this.Height = this.height+this.button1.Height;
        //}
    }
}