#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for LayoutItemPlaceHolderControl.
    /// </summary>
    /// 
    [ToolboxItem(false)]
    public class LayoutItemPlaceHolderControl : Control, IProvideLayoutInformation {
        // Fields
        private LayoutItemBase layoutItem;
        private bool visible;

        public LayoutItemPlaceHolderControl(LayoutItemBase layoutItem) {
            this.layoutItem = layoutItem;
        }

        protected override void SetVisibleCore(bool value) {
            if (this.visible != value) {
                this.visible = value;
            }
            base.OnLocationChanged(EventArgs.Empty);
        }

        public LayoutItemBase LayoutComponent {
            get { return this.layoutItem; }
        }

        protected internal LayoutManager LayoutManager {
            set { this.layoutItem.LayoutManager = value; }
        }

        public Size LayoutMinimumSize {
            get { return this.layoutItem.MinimumSize; }
        }

        public Size LayoutPreferredSize {
            get { return this.layoutItem.PreferredSize; }
        }

        public new Size MinimumSize {
            get { return this.layoutItem.MinimumSize; }
        }

        public new Size PreferredSize {
            get { return this.layoutItem.PreferredSize; }
        }

        public new virtual bool Visible {
            get { return this.visible; }
            set { base.Visible = value; }
        }
    }
}