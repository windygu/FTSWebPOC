#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for LayoutItemBase.
    /// </summary>
    public abstract class LayoutItemBase : IProvideLayoutInformation {
        // Events
        public event EventHandler BoundsChanged;
        // Fields
        private LayoutManager _layoutManager;
        //private EventHandler BoundsChanged;
        protected bool boundsChangingFromOutsideFramework;
        internal LayoutItemPlaceHolderControl placeHolderControl;

        protected LayoutItemBase() {
            this.boundsChangingFromOutsideFramework = false;
            this.placeHolderControl = new LayoutItemPlaceHolderControl(this);
            this.placeHolderControl.SizeChanged += new EventHandler(this.Control_BoundsChanged);
            this.placeHolderControl.LocationChanged += new EventHandler(this.Control_BoundsChanged);
        }

        public void Control_BoundsChanged(object sender, EventArgs e) {
            this.OnBoundsChanged();
            if ((this.boundsChangingFromOutsideFramework && (this._layoutManager != null)) &&
                (this._layoutManager.ContainerControl != null)) {
                this._layoutManager.ContainerControl.PerformLayout();
            }
            this.boundsChangingFromOutsideFramework = false;
        }

        protected virtual void OnBoundsChanged() {
            if (this.BoundsChanged != null) {
                this.BoundsChanged(this, EventArgs.Empty);
            }
        }

        public static implicit operator Control(LayoutItemBase lm) {
            return lm.placeHolderControl;
        }

        public Control ToControl() {
            return this.placeHolderControl;
        }

        public Rectangle Bounds {
            get { return this.placeHolderControl.Bounds; }
            set {
                if (this.placeHolderControl.Bounds != value) {
                    this.placeHolderControl.Bounds = value;
                    this.boundsChangingFromOutsideFramework = true;
                }
            }
        }

        protected internal LayoutManager LayoutManager {
            set { this._layoutManager = value; }
        }

        public abstract Size MinimumSize { get; }
        public abstract Size PreferredSize { get; }

        public bool Visible {
            get { return this.placeHolderControl.Visible; }
            set { this.placeHolderControl.Visible = value; }
        }
    }
}