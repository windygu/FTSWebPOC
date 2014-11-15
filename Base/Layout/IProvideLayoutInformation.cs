#region

using System.Drawing;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for IProvideLayoutInformation.
    /// </summary>
    public interface IProvideLayoutInformation {
        Size MinimumSize { get; }
        Size PreferredSize { get; }
    }
}