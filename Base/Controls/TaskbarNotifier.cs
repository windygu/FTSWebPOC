// C# TaskbarNotifier Class v1.0
// by John O'Byrne - 02 december 2002
// 01 april 2003 : Small fix in the OnMouseUp handler
// 11 january 2003 : Patrick Vanden Driessche <pvdd@devbrains.be> added a few enhancements
//           Small Enhancements/Bugfix
//           Small bugfix: When Content text measures larger than the corresponding ContentRectangle
//                         the focus rectangle was not correctly drawn. This has been solved.
//           Added KeepVisibleOnMouseOver
//           Added ReShowOnMouseOver
//           Added If the Title or Content are too long to fit in the corresponding Rectangles,
//                 the text is truncateed and the ellipses are appended (StringTrimming).

#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Controls {
    /// <summary>
    /// TaskbarNotifier allows to display MSN style/Skinned instant messaging popups
    /// </summary>
    public class TaskbarNotifier : Form {
        #region TaskbarNotifier Protected Members

        protected Bitmap BackgroundBitmap = null;
        protected Bitmap CloseBitmap = null;
        protected Point CloseBitmapLocation;
        protected Size CloseBitmapSize;
        protected Rectangle RealTitleRectangle;
        protected Rectangle RealContentRectangle;
        protected Rectangle WorkAreaRectangle;
        protected Timer timer = new Timer();
        protected TaskbarStates taskbarState = TaskbarStates.hidden;
        protected string titleText;
        protected string contentText;
        protected Color normalTitleColor = Color.FromArgb(255, 0, 0);
        protected Color hoverTitleColor = Color.FromArgb(255, 0, 0);
        protected Color normalContentColor = Color.FromArgb(0, 0, 0);
        protected Color hoverContentColor = Color.FromArgb(0, 0, 0x66);
        protected Font normalTitleFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        protected Font hoverTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
        protected Font normalContentFont = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        protected Font hoverContentFont = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        protected int nShowEvents;
        protected int nHideEvents;
        protected int nVisibleEvents;
        protected int nIncrementShow;
        protected int nIncrementHide;
        protected bool bIsMouseOverPopup = false;
        protected bool bIsMouseOverClose = false;
        protected bool bIsMouseOverContent = false;
        protected bool bIsMouseOverTitle = false;
        protected bool bIsMouseDown = false;
        protected bool bKeepVisibleOnMouseOver = true; // Added Rev 002
        protected bool bReShowOnMouseOver = false; // Added Rev 002

        #endregion

        #region TaskbarNotifier Public Members

        public Rectangle TitleRectangle;
        public Rectangle ContentRectangle;
        public bool TitleClickable = false;
        public bool ContentClickable = true;
        public bool CloseClickable = true;
        public bool EnableSelectionRectangle = true;
        public event EventHandler CloseClick = null;
        public event EventHandler TitleClick = null;
        public event EventHandler ContentClick = null;

        #endregion

        #region TaskbarNotifier Enums

        /// <summary>
        /// List of the different popup animation status
        /// </summary>
        public enum TaskbarStates {
            hidden = 0,
            appearing = 1,
            visible = 2,
            disappearing = 3
        }

        #endregion

        #region TaskbarNotifier Constructor

        /// <summary>
        /// The Constructor for TaskbarNotifier
        /// </summary>
        public TaskbarNotifier() {
            // Window Style
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Minimized;
            base.Show();
            base.Hide();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.timer.Enabled = true;
            this.timer.Tick += new EventHandler(this.OnTimer);
        }

        #endregion

        #region TaskbarNotifier Properties

        /// <summary>
        /// Get the current TaskbarState (hidden, showing, visible, hiding)
        /// </summary>
        public TaskbarStates TaskbarState {
            get { return this.taskbarState; }
        }

        /// <summary>
        /// Get/Set the popup Title Text
        /// </summary>
        public string TitleText {
            get { return this.titleText; }
            set {
                this.titleText = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the popup Content Text
        /// </summary>
        public string ContentText {
            get { return this.contentText; }
            set {
                this.contentText = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Title Color
        /// </summary>
        public Color NormalTitleColor {
            get { return this.normalTitleColor; }
            set {
                this.normalTitleColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Title Color
        /// </summary>
        public Color HoverTitleColor {
            get { return this.hoverTitleColor; }
            set {
                this.hoverTitleColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Content Color
        /// </summary>
        public Color NormalContentColor {
            get { return this.normalContentColor; }
            set {
                this.normalContentColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Content Color
        /// </summary>
        public Color HoverContentColor {
            get { return this.hoverContentColor; }
            set {
                this.hoverContentColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Title Font
        /// </summary>
        public Font NormalTitleFont {
            get { return this.normalTitleFont; }
            set {
                this.normalTitleFont = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Title Font
        /// </summary>
        public Font HoverTitleFont {
            get { return this.hoverTitleFont; }
            set {
                this.hoverTitleFont = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Content Font
        /// </summary>
        public Font NormalContentFont {
            get { return this.normalContentFont; }
            set {
                this.normalContentFont = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Content Font
        /// </summary>
        public Font HoverContentFont {
            get { return this.hoverContentFont; }
            set {
                this.hoverContentFont = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Indicates if the popup should remain visible when the mouse pointer is over it.
        /// Added Rev 002
        /// </summary>
        public bool KeepVisibleOnMousOver {
            get { return this.bKeepVisibleOnMouseOver; }
            set { this.bKeepVisibleOnMouseOver = value; }
        }

        /// <summary>
        /// Indicates if the popup should appear again when mouse moves over it while it's disappearing.
        /// Added Rev 002
        /// </summary>
        public bool ReShowOnMouseOver {
            get { return this.bReShowOnMouseOver; }
            set { this.bReShowOnMouseOver = value; }
        }

        #endregion

        #region TaskbarNotifier Public Methods

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        /// <summary>
        /// Displays the popup for a certain amount of time
        /// </summary>
        /// <param name="strTitle">The string which will be shown as the title of the popup</param>
        /// <param name="strContent">The string which will be shown as the content of the popup</param>
        /// <param name="nTimeToShow">Duration of the showing animation (in milliseconds)</param>
        /// <param name="nTimeToStay">Duration of the visible state before collapsing (in milliseconds)</param>
        /// <param name="nTimeToHide">Duration of the hiding animation (in milliseconds)</param>
        /// <returns>Nothing</returns>
        public void Show(string strTitle, string strContent, int nTimeToShow, int nTimeToStay, int nTimeToHide) {
            this.WorkAreaRectangle = Screen.GetWorkingArea(this.WorkAreaRectangle);
            this.titleText = strTitle;
            this.contentText = strContent;
            this.nVisibleEvents = nTimeToStay;
            this.CalculateMouseRectangles();
            // We calculate the pixel increment and the timer value for the showing animation
            int nEvents;
            if (nTimeToShow > 10) {
                nEvents = Math.Min((nTimeToShow/10), this.BackgroundBitmap.Height);
                this.nShowEvents = nTimeToShow/nEvents;
                this.nIncrementShow = this.BackgroundBitmap.Height/nEvents;
            } else {
                this.nShowEvents = 10;
                this.nIncrementShow = this.BackgroundBitmap.Height;
            }
            // We calculate the pixel increment and the timer value for the hiding animation
            if (nTimeToHide > 10) {
                nEvents = Math.Min((nTimeToHide/10), this.BackgroundBitmap.Height);
                this.nHideEvents = nTimeToHide/nEvents;
                this.nIncrementHide = this.BackgroundBitmap.Height/nEvents;
            } else {
                this.nHideEvents = 10;
                this.nIncrementHide = this.BackgroundBitmap.Height;
            }
            switch (this.taskbarState) {
                case TaskbarStates.hidden:
                    this.taskbarState = TaskbarStates.appearing;
                    this.SetBounds(this.WorkAreaRectangle.Right - this.BackgroundBitmap.Width - 17,
                                   this.WorkAreaRectangle.Bottom - 1, this.BackgroundBitmap.Width, 0);
                    this.timer.Interval = this.nShowEvents;
                    this.timer.Start();
                    // We Show the popup without stealing focus
                    ShowWindow(this.Handle, 4);
                    break;
                case TaskbarStates.appearing:
                    this.Refresh();
                    break;
                case TaskbarStates.visible:
                    this.timer.Stop();
                    this.timer.Interval = this.nVisibleEvents;
                    this.timer.Start();
                    this.Refresh();
                    break;
                case TaskbarStates.disappearing:
                    this.timer.Stop();
                    this.taskbarState = TaskbarStates.visible;
                    this.SetBounds(this.WorkAreaRectangle.Right - this.BackgroundBitmap.Width - 17,
                                   this.WorkAreaRectangle.Bottom - this.BackgroundBitmap.Height - 1,
                                   this.BackgroundBitmap.Width, this.BackgroundBitmap.Height);
                    this.timer.Interval = this.nVisibleEvents;
                    this.timer.Start();
                    this.Refresh();
                    break;
            }
        }

        /// <summary>
        /// Hides the popup
        /// </summary>
        /// <returns>Nothing</returns>
        public new void Hide() {
            if (this.taskbarState != TaskbarStates.hidden) {
                this.timer.Stop();
                this.taskbarState = TaskbarStates.hidden;
                base.Hide();
            }
        }

        /// <summary>
        /// Sets the background bitmap and its transparency color
        /// </summary>
        /// <param name="strFilename">Path of the Background Bitmap on the disk</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(string strFilename, Color transparencyColor) {
            this.BackgroundBitmap = new Bitmap(strFilename);
            this.Width = this.BackgroundBitmap.Width;
            this.Height = this.BackgroundBitmap.Height;
            this.Region = this.BitmapToRegion(this.BackgroundBitmap, transparencyColor);
        }

        /// <summary>
        /// Sets the background bitmap and its transparency color
        /// </summary>
        /// <param name="image">Image/Bitmap object which represents the Background Bitmap</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(Image image, Color transparencyColor) {
            this.BackgroundBitmap = new Bitmap(image);
            this.Width = this.BackgroundBitmap.Width;
            this.Height = this.BackgroundBitmap.Height;
            this.Region = this.BitmapToRegion(this.BackgroundBitmap, transparencyColor);
        }

        /// <summary>
        /// Sets the 3-State Close Button bitmap, its transparency color and its coordinates
        /// </summary>
        /// <param name="strFilename">Path of the 3-state Close button Bitmap on the disk (width must a multiple of 3)</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// <param name="position">Location of the close button on the popup</param>
        /// <returns>Nothing</returns>
        public void SetCloseBitmap(string strFilename, Color transparencyColor, Point position) {
            this.CloseBitmap = new Bitmap(strFilename);
            this.CloseBitmap.MakeTransparent(transparencyColor);
            this.CloseBitmapSize = new Size(this.CloseBitmap.Width/3, this.CloseBitmap.Height);
            this.CloseBitmapLocation = position;
        }

        /// <summary>
        /// Sets the 3-State Close Button bitmap, its transparency color and its coordinates
        /// </summary>
        /// <param name="image">Image/Bitmap object which represents the 3-state Close button Bitmap (width must be a multiple of 3)</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// /// <param name="position">Location of the close button on the popup</param>
        /// <returns>Nothing</returns>
        public void SetCloseBitmap(Image image, Color transparencyColor, Point position) {
            this.CloseBitmap = new Bitmap(image);
            this.CloseBitmap.MakeTransparent(transparencyColor);
            this.CloseBitmapSize = new Size(this.CloseBitmap.Width/3, this.CloseBitmap.Height);
            this.CloseBitmapLocation = position;
        }

        #endregion

        #region TaskbarNotifier Protected Methods

        protected void DrawCloseButton(Graphics grfx) {
            if (this.CloseBitmap != null) {
                Rectangle rectDest = new Rectangle(this.CloseBitmapLocation, this.CloseBitmapSize);
                Rectangle rectSrc;
                if (this.bIsMouseOverClose) {
                    if (this.bIsMouseDown) {
                        rectSrc = new Rectangle(new Point(this.CloseBitmapSize.Width*2, 0), this.CloseBitmapSize);
                    } else {
                        rectSrc = new Rectangle(new Point(this.CloseBitmapSize.Width, 0), this.CloseBitmapSize);
                    }
                } else {
                    rectSrc = new Rectangle(new Point(0, 0), this.CloseBitmapSize);
                }
                grfx.DrawImage(this.CloseBitmap, rectDest, rectSrc, GraphicsUnit.Pixel);
            }
        }

        protected void DrawText(Graphics grfx) {
            if (this.titleText != null && this.titleText.Length != 0) {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.Trimming = StringTrimming.EllipsisCharacter; // Added Rev 002
                if (this.bIsMouseOverTitle) {
                    grfx.DrawString(this.titleText, this.hoverTitleFont, new SolidBrush(this.hoverTitleColor),
                                    this.TitleRectangle, sf);
                } else {
                    grfx.DrawString(this.titleText, this.normalTitleFont, new SolidBrush(this.normalTitleColor),
                                    this.TitleRectangle, sf);
                }
            }
            if (this.contentText != null && this.contentText.Length != 0) {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
                sf.Trimming = StringTrimming.Word; // Added Rev 002
                if (this.bIsMouseOverContent) {
                    grfx.DrawString(this.contentText, this.hoverContentFont, new SolidBrush(this.hoverContentColor),
                                    this.ContentRectangle, sf);
                    if (this.EnableSelectionRectangle) {
                        ControlPaint.DrawBorder3D(grfx, this.RealContentRectangle, Border3DStyle.Etched,
                                                  Border3DSide.Top | Border3DSide.Bottom | Border3DSide.Left |
                                                  Border3DSide.Right);
                    }
                } else {
                    grfx.DrawString(this.contentText, this.normalContentFont, new SolidBrush(this.normalContentColor),
                                    this.ContentRectangle, sf);
                }
            }
        }

        protected void CalculateMouseRectangles() {
            Graphics grfx = this.CreateGraphics();
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizefTitle = grfx.MeasureString(this.titleText, this.hoverTitleFont, this.TitleRectangle.Width, sf);
            SizeF sizefContent = grfx.MeasureString(this.contentText, this.hoverContentFont, this.ContentRectangle.Width,
                                                    sf);
            grfx.Dispose();
            // Added Rev 002
            //We should check if the title size really fits inside the pre-defined title rectangle
            if (sizefTitle.Height > this.TitleRectangle.Height) {
                this.RealTitleRectangle = new Rectangle(this.TitleRectangle.Left, this.TitleRectangle.Top,
                                                        this.TitleRectangle.Width, this.TitleRectangle.Height);
            } else {
                this.RealTitleRectangle = new Rectangle(this.TitleRectangle.Left, this.TitleRectangle.Top,
                                                        (int) sizefTitle.Width, (int) sizefTitle.Height);
            }
            this.RealTitleRectangle.Inflate(0, 2);
            // Added Rev 002
            //We should check if the Content size really fits inside the pre-defined Content rectangle
            if (sizefContent.Height > this.ContentRectangle.Height) {
                this.RealContentRectangle =
                    new Rectangle(
                        (this.ContentRectangle.Width - (int) sizefContent.Width)/2 + this.ContentRectangle.Left,
                        this.ContentRectangle.Top, (int) sizefContent.Width, this.ContentRectangle.Height);
            } else {
                this.RealContentRectangle =
                    new Rectangle(
                        (this.ContentRectangle.Width - (int) sizefContent.Width)/2 + this.ContentRectangle.Left,
                        (this.ContentRectangle.Height - (int) sizefContent.Height)/2 + this.ContentRectangle.Top,
                        (int) sizefContent.Width, (int) sizefContent.Height);
            }
            this.RealContentRectangle.Inflate(0, 2);
        }

        protected Region BitmapToRegion(Bitmap bitmap, Color transparencyColor) {
            if (bitmap == null) {
                throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");
            }
            int height = bitmap.Height;
            int width = bitmap.Width;
            GraphicsPath path = new GraphicsPath();
            for (int j = 0; j < height; j++) {
                for (int i = 0; i < width; i++) {
                    if (bitmap.GetPixel(i, j) == transparencyColor) {
                        continue;
                    }
                    int x0 = i;
                    while ((i < width) && (bitmap.GetPixel(i, j) != transparencyColor)) {
                        i++;
                    }
                    path.AddRectangle(new Rectangle(x0, j, i - x0, 1));
                }
            }
            Region region = new Region(path);
            path.Dispose();
            return region;
        }

        #endregion

        #region TaskbarNotifier Events Overrides

        protected void OnTimer(Object obj, EventArgs ea) {
            switch (this.taskbarState) {
                case TaskbarStates.appearing:
                    if (this.Height < this.BackgroundBitmap.Height) {
                        this.SetBounds(this.Left, this.Top - this.nIncrementShow, this.Width,
                                       this.Height + this.nIncrementShow);
                    } else {
                        this.timer.Stop();
                        this.Height = this.BackgroundBitmap.Height;
                        this.timer.Interval = this.nVisibleEvents;
                        this.taskbarState = TaskbarStates.visible;
                        this.timer.Start();
                    }
                    break;
                case TaskbarStates.visible:
                    this.timer.Stop();
                    this.timer.Interval = this.nHideEvents;
                    // Added Rev 002
                    if ((this.bKeepVisibleOnMouseOver && !this.bIsMouseOverPopup) || (!this.bKeepVisibleOnMouseOver)) {
                        this.taskbarState = TaskbarStates.disappearing;
                    }
                    //taskbarState = TaskbarStates.disappearing;		// Rev 002
                    this.timer.Start();
                    break;
                case TaskbarStates.disappearing:
                    // Added Rev 002
                    if (this.bReShowOnMouseOver && this.bIsMouseOverPopup) {
                        this.taskbarState = TaskbarStates.appearing;
                    } else {
                        if (this.Top < this.WorkAreaRectangle.Bottom) {
                            this.SetBounds(this.Left, this.Top + this.nIncrementHide, this.Width,
                                           this.Height - this.nIncrementHide);
                        } else {
                            this.Hide();
                        }
                    }
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs ea) {
            base.OnMouseEnter(ea);
            this.bIsMouseOverPopup = true;
            this.Refresh();
        }

        protected override void OnMouseLeave(EventArgs ea) {
            base.OnMouseLeave(ea);
            this.bIsMouseOverPopup = false;
            this.bIsMouseOverClose = false;
            this.bIsMouseOverTitle = false;
            this.bIsMouseOverContent = false;
            this.Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs mea) {
            base.OnMouseMove(mea);
            bool bContentModified = false;
            if ((mea.X > this.CloseBitmapLocation.X) &&
                (mea.X < this.CloseBitmapLocation.X + this.CloseBitmapSize.Width) &&
                (mea.Y > this.CloseBitmapLocation.Y) &&
                (mea.Y < this.CloseBitmapLocation.Y + this.CloseBitmapSize.Height) && this.CloseClickable) {
                if (!this.bIsMouseOverClose) {
                    this.bIsMouseOverClose = true;
                    this.bIsMouseOverTitle = false;
                    this.bIsMouseOverContent = false;
                    this.Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            } else if (this.RealContentRectangle.Contains(new Point(mea.X, mea.Y)) && this.ContentClickable) {
                if (!this.bIsMouseOverContent) {
                    this.bIsMouseOverClose = false;
                    this.bIsMouseOverTitle = false;
                    this.bIsMouseOverContent = true;
                    this.Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            } else if (this.RealTitleRectangle.Contains(new Point(mea.X, mea.Y)) && this.TitleClickable) {
                if (!this.bIsMouseOverTitle) {
                    this.bIsMouseOverClose = false;
                    this.bIsMouseOverTitle = true;
                    this.bIsMouseOverContent = false;
                    this.Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            } else {
                if (this.bIsMouseOverClose || this.bIsMouseOverTitle || this.bIsMouseOverContent) {
                    bContentModified = true;
                }
                this.bIsMouseOverClose = false;
                this.bIsMouseOverTitle = false;
                this.bIsMouseOverContent = false;
                this.Cursor = Cursors.Default;
            }
            if (bContentModified) {
                this.Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs mea) {
            base.OnMouseDown(mea);
            this.bIsMouseDown = true;
            if (this.bIsMouseOverClose) {
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mea) {
            base.OnMouseUp(mea);
            this.bIsMouseDown = false;
            if (this.bIsMouseOverClose) {
                this.Hide();
                if (this.CloseClick != null) {
                    this.CloseClick(this, new EventArgs());
                }
            } else if (this.bIsMouseOverTitle) {
                if (this.TitleClick != null) {
                    this.TitleClick(this, new EventArgs());
                }
            } else if (this.bIsMouseOverContent) {
                if (this.ContentClick != null) {
                    this.ContentClick(this, new EventArgs());
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pea) {
            Graphics grfx = pea.Graphics;
            grfx.PageUnit = GraphicsUnit.Pixel;
            Graphics offScreenGraphics;
            Bitmap offscreenBitmap;
            offscreenBitmap = new Bitmap(this.BackgroundBitmap.Width, this.BackgroundBitmap.Height);
            offScreenGraphics = Graphics.FromImage(offscreenBitmap);
            if (this.BackgroundBitmap != null) {
                offScreenGraphics.DrawImage(this.BackgroundBitmap, 0, 0, this.BackgroundBitmap.Width,
                                            this.BackgroundBitmap.Height);
            }
            this.DrawCloseButton(offScreenGraphics);
            this.DrawText(offScreenGraphics);
            grfx.DrawImage(offscreenBitmap, 0, 0);
        }

        #endregion
    }
}