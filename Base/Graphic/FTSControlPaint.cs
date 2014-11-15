#region

using System.Drawing;

#endregion

namespace FTS.BaseUI.Graphic {
    public sealed class FTSControlPaint {
        public FTSControlPaint() {
        }

        public static Color Dark(Color baseColor, byte value) {
            byte num1 = baseColor.R;
            byte num2 = baseColor.G;
            byte num3 = baseColor.B;
            if ((num1 - value) < 0) {
                num1 = 0;
            } else {
                num1 = (byte) (num1 - value);
            }
            if ((num2 - value) < 0) {
                num2 = 0;
            } else {
                num2 = (byte) (num2 - value);
            }
            if ((num3 - value) < 0) {
                num3 = 0;
            } else {
                num3 = (byte) (num3 - value);
            }
            return Color.FromArgb(num1, num2, num3);
        }

        public static Color Light(Color baseColor, byte value) {
            byte num1 = baseColor.R;
            byte num2 = baseColor.G;
            byte num3 = baseColor.B;
            if ((num1 + value) > 0xff) {
                num1 = 0xff;
            } else {
                num1 = (byte) (num1 + value);
            }
            if ((num2 + value) > 0xff) {
                num2 = 0xff;
            } else {
                num2 = (byte) (num2 + value);
            }
            if ((num3 + value) > 0xff) {
                num3 = 0xff;
            } else {
                num3 = (byte) (num3 + value);
            }
            return Color.FromArgb(num1, num2, num3);
        }

        public static Color GetSysColor(ColorType colorType) {
            return ColorTranslator.FromWin32(Win32.GetSysColor((int) colorType));
        }
    }
}