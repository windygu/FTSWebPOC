#region

using System.Collections;
using System.ComponentModel;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for SelectedCardConverter.
    /// </summary>
    public class SelectedCardConverter : StringConverter {
        public SelectedCardConverter() {
            //
            // TODO: Add constructor logic here
            //
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            ArrayList list1 = new ArrayList();
            CardLayout layout1 = context.Instance as CardLayout;
            if (layout1 != null) {
                list1 = layout1.GetCardNames();
            }
            if (list1.Count == 0) {
                list1.Add(string.Empty);
            }
            return new StandardValuesCollection(list1);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }
}