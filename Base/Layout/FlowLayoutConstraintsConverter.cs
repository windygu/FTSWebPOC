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
    /// Summary description for FlowLayoutConstraintsConverter.
    /// </summary>
    public class FlowLayoutConstraintsConverter : ByteStreamTypeConverter {
        public FlowLayoutConstraintsConverter() {
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
            if ((destinationType == typeof (InstanceDescriptor)) && (value is FlowLayoutConstraints)) {
                FlowLayoutConstraints constraints1 = (FlowLayoutConstraints) value;
                Type[] typeArray1 = new Type[6] {
                                                    typeof (bool), typeof (HorzFlowAlign), typeof (VertFlowAlign), typeof (bool),
                                                    typeof (bool), typeof (bool)
                                                };
                ConstructorInfo info1 = typeof (FlowLayoutConstraints).GetConstructor(typeArray1);
                if (info1 == null) {
                    goto Label_0299;
                }
                object[] objArray1 = new object[6] {
                                                       constraints1.Active, constraints1.HAlign, constraints1.VAlign,
                                                       constraints1.NewLine, constraints1.ProportionalColWidth,
                                                       constraints1.ProportionalRowHeight
                                                   };
                return new InstanceDescriptor(info1, objArray1);
            }
            if ((destinationType == typeof (string)) && (value is FlowLayoutConstraints)) {
                FlowLayoutConstraints constraints2 = (FlowLayoutConstraints) value;
                PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(constraints2);
                string text1 = string.Empty;
                PropertyDescriptor descriptor1 = collection1.Find("Active", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "Active " + constraints2.Active.ToString() + "; ";
                }
                descriptor1 = collection1.Find("HAlign", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "HAlign " + constraints2.HAlign.ToString() + "; ";
                }
                descriptor1 = collection1.Find("VAlign", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "VAlign " + constraints2.VAlign.ToString() + "; ";
                }
                descriptor1 = collection1.Find("NewLine", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "NewLine " + constraints2.NewLine.ToString() + "; ";
                }
                descriptor1 = collection1.Find("ProportionalColWidth", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "ProportionalColWidth " + constraints2.ProportionalColWidth.ToString() + "; ";
                }
                descriptor1 = collection1.Find("ProportionalRowHeight", false);
                if (descriptor1.ShouldSerializeValue(constraints2)) {
                    text1 = text1 + "ProportionalRowHeight " + constraints2.ProportionalRowHeight.ToString() + "; ";
                }
                return text1;
            }
            Label_0299:
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues) {
            FlowLayoutConstraints constraints1 = new FlowLayoutConstraints();
            constraints1.Active = (bool) propertyValues["Active"];
            constraints1.HAlign = (HorzFlowAlign) propertyValues["HAlign"];
            constraints1.VAlign = (VertFlowAlign) propertyValues["VAlign"];
            constraints1.NewLine = (bool) propertyValues["NewLine"];
            constraints1.ProportionalColWidth = (bool) propertyValues["ProportionalColWidth"];
            constraints1.ProportionalRowHeight = (bool) propertyValues["ProportionalRowHeight"];
            return constraints1;
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) {
            return true;
        }

        public override void OnAfterDeserialize() {
            AppStateSerializer.SetTypeBindingInfo("Syncfusion.Shared.Base", typeof (FlowLayoutConstraints).FullName,
                                                  null);
        }

        public override void OnBeforeDeserialize() {
            AppStateSerializer.SetBindingInfo("Syncfusion.Shared.Base", typeof (FlowLayoutConstraints).Assembly);
            AppStateSerializer.SetTypeBindingInfo("Syncfusion.Shared.Base", typeof (FlowLayoutConstraints).FullName,
                                                  typeof (FlowLayoutConstraints).Assembly);
        }
    }
}