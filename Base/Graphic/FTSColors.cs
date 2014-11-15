#region

using System.Collections;
using System.Drawing;

#endregion

namespace FTS.BaseUI.Graphic {
    public sealed class FTSColors {
        // Fields
        private static Color activeCaptionEnd;
        private static Color activeCaptionStart;
        private static string colorName;
        private static Color[] colors;
        private static Color content;
        private static Color contentDark;
        private static Color controlEnd;
        private static Color controlEndDark;
        private static Color controlEndLight;
        private static Color controlStart;
        private static Color controlStartDark;
        private static Color controlStartLight;
        private static Color controlText;
        private static Color[] customColors;
        private static string customStr;
        private static Color focus;
        private static Color inactiveCaptionEnd;
        private static Color inactiveCaptionStart;
        private static Hashtable localizableColors;
        private static Hashtable localizableSystemColors;
        private static string otherStr;
        private static Color selected;
        private static Color selectedText;
        private static Color[] systemColors;
        private static string systemStr;
        private static string webStr;

        static FTSColors() {
            webStr = "Web";
            systemStr = "System";
            customStr = "Custom";
            otherStr = "Other...";
            colorName = "Color";
            Color[] colorArray1 = new Color[] {
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xc0, 0xc0),
                                                  Color.FromArgb(0xff, 0xe0, 0xc0), Color.FromArgb(0xff, 0xff, 0xc0),
                                                  Color.FromArgb(0xc0, 0xff, 0xc0), Color.FromArgb(0xc0, 0xff, 0xff),
                                                  Color.FromArgb(0xc0, 0xc0, 0xff), Color.FromArgb(0xff, 0xc0, 0xff),
                                                  Color.FromArgb(0xe0, 0xe0, 0xe0), Color.FromArgb(0xff, 0x80, 0x80),
                                                  Color.FromArgb(0xff, 0xc0, 0x80), Color.FromArgb(0xff, 0xff, 0x80),
                                                  Color.FromArgb(0x80, 0xff, 0x80), Color.FromArgb(0x80, 0xff, 0xff),
                                                  Color.FromArgb(0x80, 0x80, 0xff), Color.FromArgb(0xff, 0x80, 0xff),
                                                  Color.FromArgb(0xc0, 0xc0, 0xc0), Color.FromArgb(0xff, 0, 0),
                                                  Color.FromArgb(0xff, 0x80, 0), Color.FromArgb(0xff, 0xff, 0),
                                                  Color.FromArgb(0, 0xff, 0), Color.FromArgb(0, 0xff, 0xff), Color.FromArgb(0, 0, 0xff)
                                                  , Color.FromArgb(0xff, 0, 0xff), Color.FromArgb(0x80, 0x80, 0x80),
                                                  Color.FromArgb(0xc0, 0, 0), Color.FromArgb(0xc0, 0x40, 0),
                                                  Color.FromArgb(0xc0, 0xc0, 0), Color.FromArgb(0, 0xc0, 0),
                                                  Color.FromArgb(0, 0xc0, 0xc0), Color.FromArgb(0, 0, 0xc0),
                                                  Color.FromArgb(0xc0, 0, 0xc0), Color.FromArgb(0x40, 0x40, 0x40),
                                                  Color.FromArgb(0x80, 0, 0), Color.FromArgb(0x80, 0x40, 0),
                                                  Color.FromArgb(0x80, 0x80, 0), Color.FromArgb(0, 0x80, 0),
                                                  Color.FromArgb(0, 0x80, 0x80), Color.FromArgb(0, 0, 0x80),
                                                  Color.FromArgb(0x80, 0, 0x80), Color.FromArgb(0, 0, 0), Color.FromArgb(0x40, 0, 0),
                                                  Color.FromArgb(0x80, 0x40, 0x40), Color.FromArgb(0x40, 0x40, 0),
                                                  Color.FromArgb(0, 0x40, 0), Color.FromArgb(0, 0x40, 0x40), Color.FromArgb(0, 0, 0x40)
                                                  , Color.FromArgb(0x40, 0, 0x40), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0xff),
                                                  Color.FromArgb(0xff, 0xff, 0xff)
                                              };
            customColors = colorArray1;
            colorArray1 = new Color[] {
                                          System.Drawing.SystemColors.ActiveBorder, System.Drawing.SystemColors.ActiveCaption,
                                          System.Drawing.SystemColors.ActiveCaptionText, System.Drawing.SystemColors.AppWorkspace,
                                          System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlDark,
                                          System.Drawing.SystemColors.ControlDarkDark, System.Drawing.SystemColors.ControlLight,
                                          System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlText,
                                          System.Drawing.SystemColors.Desktop, System.Drawing.SystemColors.GrayText,
                                          System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText,
                                          System.Drawing.SystemColors.HotTrack, System.Drawing.SystemColors.InactiveBorder,
                                          System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.InactiveCaptionText,
                                          System.Drawing.SystemColors.Info, System.Drawing.SystemColors.InfoText,
                                          System.Drawing.SystemColors.Menu, System.Drawing.SystemColors.MenuText,
                                          System.Drawing.SystemColors.ScrollBar, System.Drawing.SystemColors.Window,
                                          System.Drawing.SystemColors.WindowFrame, System.Drawing.SystemColors.WindowText
                                      };
            systemColors = colorArray1;
            colorArray1 = new Color[] {
                                          Color.Transparent, Color.Black, Color.DimGray, Color.Gray, Color.DarkGray, Color.Silver,
                                          Color.LightGray, Color.Gainsboro, Color.WhiteSmoke, Color.White, Color.RosyBrown,
                                          Color.IndianRed, Color.Brown, Color.Firebrick, Color.LightCoral, Color.Maroon, Color.DarkRed,
                                          Color.Red, Color.Snow, Color.MistyRose, Color.Salmon, Color.Tomato, Color.DarkSalmon,
                                          Color.Coral, Color.OrangeRed, Color.LightSalmon, Color.Sienna, Color.SeaShell,
                                          Color.Chocolate, Color.SaddleBrown, Color.SandyBrown, Color.PeachPuff, Color.Peru,
                                          Color.Linen, Color.Bisque, Color.DarkOrange, Color.BurlyWood, Color.Tan, Color.AntiqueWhite,
                                          Color.NavajoWhite, Color.BlanchedAlmond, Color.PapayaWhip, Color.Moccasin, Color.Orange,
                                          Color.Wheat, Color.OldLace, Color.FloralWhite, Color.DarkGoldenrod, Color.Goldenrod,
                                          Color.Cornsilk, Color.Gold, Color.Khaki, Color.LemonChiffon, Color.PaleGoldenrod,
                                          Color.DarkKhaki, Color.Beige, Color.LightGoldenrodYellow, Color.Olive, Color.Yellow,
                                          Color.LightYellow, Color.Ivory, Color.OliveDrab, Color.YellowGreen, Color.DarkOliveGreen,
                                          Color.GreenYellow, Color.Chartreuse, Color.LawnGreen, Color.DarkSeaGreen, Color.ForestGreen,
                                          Color.LimeGreen, Color.LightGreen, Color.PaleGreen, Color.DarkGreen, Color.Green, Color.Lime,
                                          Color.Honeydew, Color.SeaGreen, Color.MediumSeaGreen, Color.SpringGreen, Color.MintCream,
                                          Color.MediumSpringGreen, Color.MediumAquamarine, Color.Aquamarine, Color.Turquoise,
                                          Color.LightSeaGreen, Color.MediumTurquoise, Color.DarkSlateGray, Color.PaleTurquoise,
                                          Color.Teal, Color.DarkCyan, Color.Aqua, Color.Cyan, Color.LightCyan, Color.Azure,
                                          Color.DarkTurquoise, Color.CadetBlue, Color.PowderBlue, Color.LightBlue, Color.DeepSkyBlue,
                                          Color.SkyBlue, Color.LightSkyBlue, Color.SteelBlue, Color.AliceBlue, Color.DodgerBlue,
                                          Color.SlateGray, Color.LightSlateGray, Color.LightSteelBlue, Color.CornflowerBlue,
                                          Color.RoyalBlue, Color.MidnightBlue, Color.Lavender, Color.Navy, Color.DarkBlue,
                                          Color.MediumBlue, Color.Blue, Color.GhostWhite, Color.SlateBlue, Color.DarkSlateBlue,
                                          Color.MediumSlateBlue, Color.MediumPurple, Color.BlueViolet, Color.Indigo, Color.DarkOrchid,
                                          Color.DarkViolet, Color.MediumOrchid, Color.Thistle, Color.Plum, Color.Violet, Color.Purple,
                                          Color.DarkMagenta, Color.Magenta, Color.Fuchsia, Color.Orchid, Color.MediumVioletRed,
                                          Color.DeepPink, Color.HotPink, Color.LavenderBlush, Color.PaleVioletRed, Color.Crimson,
                                          Color.Pink, Color.LightPink
                                      };
            colors = colorArray1;
            localizableColors = new Hashtable();
            localizableSystemColors = new Hashtable();
            InitColors();
            colorArray1 = SystemColors;
            int num1 = 0;
            while (num1 < colorArray1.Length) {
                Color color1 = colorArray1[num1];
                LocalizableSystemColors.Add(color1, color1.Name);
                num1++;
            }
            colorArray1 = Colors;
            for (num1 = 0; num1 < colorArray1.Length; num1++) {
                Color color2 = colorArray1[num1];
                LocalizableColors.Add(color2, color2.Name);
            }
        }

        private FTSColors() {
        }

        private static Color CalcColor(Color front, Color back, int alpha) {
            Color color1 = Color.FromArgb(0xff, front);
            Color color2 = Color.FromArgb(0xff, back);
            float single1 = color1.R;
            float single2 = color1.G;
            float single3 = color1.B;
            float single4 = color2.R;
            float single5 = color2.G;
            float single6 = color2.B;
            float single7 = ((single1*alpha)/255f) + (single4*(((float) (0xff - alpha))/255f));
            byte num1 = (byte) single7;
            float single8 = ((single2*alpha)/255f) + (single5*(((float) (0xff - alpha))/255f));
            byte num2 = (byte) single8;
            float single9 = ((single3*alpha)/255f) + (single6*(((float) (0xff - alpha))/255f));
            byte num3 = (byte) single9;
            return Color.FromArgb(0xff, num1, num2, num3);
        }

        public static void InitColors() {
            activeCaptionStart = FTSControlPaint.GetSysColor(ColorType.COLOR_GRADIENTACTIVECAPTION);
            activeCaptionEnd = System.Drawing.SystemColors.ActiveCaption;
            inactiveCaptionStart = FTSControlPaint.GetSysColor(ColorType.COLOR_GRADIENTINACTIVECAPTION);
            inactiveCaptionEnd = System.Drawing.SystemColors.InactiveCaption;
            focus = CalcColor(System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Window, 70);
            selected = CalcColor(System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Window, 30);
            selectedText = CalcColor(System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Window, 220);
            content = CalcColor(System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control, 200);
            contentDark = FTSControlPaint.Dark(Content, 10);
            controlStart = FTSControlPaint.Light(System.Drawing.SystemColors.Control, 30);
            controlEnd = FTSControlPaint.Dark(System.Drawing.SystemColors.Control, 10);
            controlText = System.Drawing.SystemColors.ControlText;
            controlStartLight = FTSControlPaint.Light(ControlStart, 20);
            controlEndLight = FTSControlPaint.Light(ControlEnd, 20);
            controlStartDark = FTSControlPaint.Dark(ControlStart, 20);
            controlEndDark = FTSControlPaint.Dark(ControlEnd, 20);
        }

        public static Color ActiveCaptionEnd {
            get { return activeCaptionEnd; }
            set { activeCaptionEnd = value; }
        }

        public static Color ActiveCaptionStart {
            get { return activeCaptionStart; }
            set { activeCaptionStart = value; }
        }

        public static string ColorName {
            get { return colorName; }
            set { colorName = value; }
        }

        public static Color[] Colors {
            get { return colors; }
        }

        public static Color Content {
            get { return content; }
            set { content = value; }
        }

        public static Color ContentDark {
            get { return contentDark; }
            set { contentDark = value; }
        }

        public static Color ControlEnd {
            get { return controlEnd; }
            set { controlEnd = value; }
        }

        public static Color ControlEndDark {
            get { return controlEndDark; }
            set { controlEndDark = value; }
        }

        public static Color ControlEndLight {
            get { return controlEndLight; }
            set { controlEndLight = value; }
        }

        public static Color ControlStart {
            get { return controlStart; }
            set { controlStart = value; }
        }

        public static Color ControlStartDark {
            get { return controlStartDark; }
            set { controlStartDark = value; }
        }

        public static Color ControlStartLight {
            get { return controlStartLight; }
            set { controlStartLight = value; }
        }

        public static Color ControlText {
            get { return controlText; }
            set { controlText = value; }
        }

        public static Color[] CustomColors {
            get { return customColors; }
        }

        public static string CustomStr {
            get { return customStr; }
            set { customStr = value; }
        }

        public static Color Focus {
            get { return focus; }
            set { focus = value; }
        }

        public static Color InactiveCaptionEnd {
            get { return inactiveCaptionEnd; }
            set { inactiveCaptionEnd = value; }
        }

        public static Color InactiveCaptionStart {
            get { return inactiveCaptionStart; }
            set { inactiveCaptionStart = value; }
        }

        public static Hashtable LocalizableColors {
            get { return localizableColors; }
        }

        public static Hashtable LocalizableSystemColors {
            get { return localizableSystemColors; }
        }

        public static string OtherStr {
            get { return otherStr; }
            set { otherStr = value; }
        }

        public static Color Selected {
            get { return selected; }
            set { selected = value; }
        }

        public static Color SelectedText {
            get { return selectedText; }
            set { selectedText = value; }
        }

        public static Color[] SystemColors {
            get { return systemColors; }
        }

        public static string SystemStr {
            get { return systemStr; }
            set { systemStr = value; }
        }

        public static string WebStr {
            get { return webStr; }
            set { webStr = value; }
        }
    }
}