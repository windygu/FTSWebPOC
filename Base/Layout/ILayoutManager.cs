#region

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public interface ILayoutManager {
        // Methods
        void AddLayoutComponent(Control childControl, object constraints);
        Size GetMinimumSize(Control control);
        Size GetPreferredSize(Control childControl);
        void LayoutContainer();
        Size MinimumLayoutSize();
        Size PreferredLayoutSize();
        void RemoveLayoutComponent(Control childControl);
        void SetMinimumSize(Control control, Size value);
        void SetPreferredSize(Control control, Size value);

        // Properties
        bool AutoLayout { get; set; }
        Control ContainerControl { get; set; }
        Rectangle CustomLayoutBounds { get; set; }
    }
}