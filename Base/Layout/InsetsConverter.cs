#region

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for InsetsConverter.
    /// </summary>
    public class InsetsConverter : ExpandableObjectConverter {
        public InsetsConverter() {
            //
            // TODO: Add constructor logic here
            //
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof (InstanceDescriptor)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType) {
            if ((destinationType == typeof (InstanceDescriptor)) && (value is Insets)) {
                Insets insets1 = (Insets) value;
                Type[] typeArray1 = new Type[4] {typeof (int), typeof (int), typeof (int), typeof (int)};
                ConstructorInfo info1 = typeof (Insets).GetConstructor(typeArray1);
                if (info1 != null) {
                    object[] objArray1 = new object[4] {insets1.Left, insets1.Top, insets1.Right, insets1.Bottom};
                    return new InstanceDescriptor(info1, objArray1);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) {
            int num1 = (int) propertyValues["Top"];
            int num2 = (int) propertyValues["Left"];
            int num3 = (int) propertyValues["Right"];
            int num4 = (int) propertyValues["Bottom"];
            return new Insets(num2, num1, num3, num4);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) {
            return true;
        }
    }
}