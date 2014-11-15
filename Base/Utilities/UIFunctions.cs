using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using FTS.BaseBusiness.Classes;

namespace FTS.BaseBusiness.Utilities {
    public class UIFunctions {

        public static int GetSourcePosition(BindingManagerBase bm) {
            if (bm.Position < 0) {
                return -1;
            }
            CurrencyManager cm = (CurrencyManager)bm;
            for (int i = 0; i < ((DataRowView)cm.Current).DataView.Table.Rows.Count; i++) {
                if (((DataRowView)cm.Current).Row == ((DataRowView)cm.Current).DataView.Table.Rows[i]) {
                    return i;
                }
            }
            return -1;
        }

        public static int GetBindingManagerPosition(BindingManagerBase bm, int sourcePos) {
            CurrencyManager cm = (CurrencyManager)bm;
            for (int i = 0; i < bm.Count; i++) {
                bm.Position = i;
                if (cm.Current is DataRowView) {
                    if (((DataRowView)cm.Current).Row == ((DataRowView)cm.Current).DataView.Table.Rows[sourcePos]) {
                        return i;
                    }
                }
                if (cm.Current is List<ItemCombobox>) {
                    if (((ItemCombobox)cm.Current).Equals(((List<ItemCombobox>)cm.Current)[sourcePos])) {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static Color String2Color(string color) {
            try {
                if (color.Trim() != String.Empty) {
                    string[] rgb = color.Split(',');
                    if (rgb.Length == 3)
                        return Color.FromArgb(Int32.Parse(rgb[0]), Int32.Parse(rgb[1]), Int32.Parse(rgb[2]));
                    else
                        return Color.FromName(color);
                } else {
                    return Color.SpringGreen;
                }
            } catch {
                return Color.SpringGreen;
            }
        }
        public static string GetSumType(SummaryItemType type) {
            switch (type) {
                case SummaryItemType.Sum:
                    return "SUM";
                case SummaryItemType.Count:
                    return "COUNT";
                case SummaryItemType.Average:
                    return "AVERAGE";
                case SummaryItemType.Max:
                    return "MAX";
                case SummaryItemType.Min:
                    return "MIN";
                case SummaryItemType.Custom:
                    return "CUSTOM";
                default:
                    return string.Empty;
            }
        }

        public static string GetSumType(DevExpress.XtraTreeList.SummaryItemType type) {
            switch (type) {
                case DevExpress.XtraTreeList.SummaryItemType.Sum:
                    return "SUM";
                case DevExpress.XtraTreeList.SummaryItemType.Count:
                    return "COUNT";
                case DevExpress.XtraTreeList.SummaryItemType.Average:
                    return "AVERAGE";
                case DevExpress.XtraTreeList.SummaryItemType.Max:
                    return "MAX";
                case DevExpress.XtraTreeList.SummaryItemType.Min:
                    return "MIN";
                case DevExpress.XtraTreeList.SummaryItemType.Custom:
                    return "CUSTOM";
                default:
                    return string.Empty;
            }
        }
    }

}
