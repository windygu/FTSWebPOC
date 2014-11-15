#region

using System.Runtime.InteropServices;

#endregion

namespace FTS.BaseUI.Graphic {
    public sealed class Win32 {
        public Win32() {
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetSysColor(int color);
    }
}