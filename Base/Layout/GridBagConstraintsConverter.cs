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
    /// Summary description for GridBagConstraintsConverter.
    /// </summary>
    public class GridBagConstraintsConverter : ByteStreamTypeConverter {
        public GridBagConstraintsConverter() {
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof (InstanceDescriptor)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType) {
            if ((destinationType == typeof (InstanceDescriptor)) && (value is GridBagConstraints)) {
                GridBagConstraints constraints1 = (GridBagConstraints) value;
                Type[] typeArray1 = new Type[12] {
                                                     typeof (int), typeof (int), typeof (int), typeof (int), typeof (double),
                                                     typeof (double), typeof (AnchorTypes), typeof (FillType), typeof (Insets),
                                                     typeof (int), typeof (int), typeof (bool)
                                                 };
                ConstructorInfo info1 = typeof (GridBagConstraints).GetConstructor(typeArray1);
                if (info1 == null) {
                    goto Label_0462;
                }
                object[] objArray1 = new object[12] {
                                                        constraints1.GridPosX, constraints1.GridPosY, constraints1.CellSpanX,
                                                        constraints1.CellSpanY, constraints1.WeightX, constraints1.WeightY,
                                                        constraints1.Anchor, constraints1.Fill, constraints1.Insets, constraints1.IpadX,
                                                        constraints1.IpadY, constraints1.IsEmpty
                                                    };
                return new InstanceDescriptor(info1, objArray1);
            }
            if ((destinationType == typeof (string)) && (value is GridBagConstraints)) {
                GridBagConstraints constraints2 = (GridBagConstraints) value;
                PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(constraints2);
                string text1 = string.Empty;
                PropertyDescriptor descriptor1 = collection1.Find("Anchor", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + constraints2.Anchor.ToString() + "; ";
                }
                descriptor1 = collection1.Find("CellSpanX", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "CellSpanX " + constraints2.CellSpanX.ToString() + "; ";
                }
                descriptor1 = collection1.Find("CellSpanY", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "CellSpanY " + constraints2.CellSpanY.ToString() + "; ";
                }
                descriptor1 = collection1.Find("Fill", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + constraints2.Fill.ToString() + "; ";
                }
                descriptor1 = collection1.Find("GridPosX", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "GridPosX " + constraints2.GridPosX.ToString() + "; ";
                }
                descriptor1 = collection1.Find("GridPosY", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "GridPosY " + constraints2.GridPosY.ToString() + "; ";
                }
                descriptor1 = collection1.Find("Insets", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "Insets " + constraints2.Insets.ToString() + "; ";
                }
                descriptor1 = collection1.Find("IpadX", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "IpadX " + constraints2.IpadX.ToString() + "; ";
                }
                descriptor1 = collection1.Find("IpadY", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "IpadY " + constraints2.IpadY.ToString() + "; ";
                }
                descriptor1 = collection1.Find("WeightX", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + string.Format("WeightX {0:###.##};", constraints2.WeightX);
                }
                descriptor1 = collection1.Find("WeightY", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + string.Format("WeightY {0:###.##};", constraints2.WeightY);
                }
                return text1;
            }
            Label_0462:
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) {
            GridBagConstraints constraints1 = new GridBagConstraints();
            constraints1.Anchor = (AnchorTypes) propertyValues["Anchor"];
            constraints1.CellSpanX = (int) propertyValues["CellSpanX"];
            constraints1.CellSpanY = (int) propertyValues["CellSpanY"];
            constraints1.Fill = (FillType) propertyValues["Fill"];
            constraints1.GridPosX = (int) propertyValues["GridPosX"];
            constraints1.GridPosY = (int) propertyValues["GridPosY"];
            constraints1.Insets = (Insets) propertyValues["Insets"];
            constraints1.IpadX = (int) propertyValues["IpadX"];
            constraints1.IpadY = (int) propertyValues["IpadY"];
            constraints1.WeightX = (double) propertyValues["WeightX"];
            constraints1.WeightY = (double) propertyValues["WeightY"];
            constraints1.IsEmpty = (bool) propertyValues["IsEmpty"];
            return constraints1;
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) {
            return true;
        }

        public override void OnAfterDeserialize() {
            AppStateSerializer.SetTypeBindingInfo("Syncfusion.Shared.Base", typeof (GridBagConstraints).FullName, null);
        }

        public override void OnBeforeDeserialize() {
            AppStateSerializer.SetBindingInfo("Syncfusion.Shared.Base", typeof (GridBagConstraints).Assembly);
            AppStateSerializer.SetTypeBindingInfo("Syncfusion.Shared.Base", typeof (GridBagConstraints).FullName,
                                                  typeof (GridBagConstraints).Assembly);
        }
    }
}