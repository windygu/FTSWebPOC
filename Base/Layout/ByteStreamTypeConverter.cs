#region

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for ByteStreamTypeConverter.
    /// </summary>
    public class ByteStreamTypeConverter : ExpandableObjectConverter {
        public ByteStreamTypeConverter() {
            //
            // TODO: Add constructor logic here
            //
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof (byte[])) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof (byte[])) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            byte[] buffer1 = value as byte[];
            if (buffer1 == null) {
                return base.ConvertFrom(context, culture, value);
            }
            object obj1 = null;
            MemoryStream stream1 = new MemoryStream(buffer1);
            BinaryFormatter formatter1 = new BinaryFormatter();
            formatter1.AssemblyFormat = FormatterAssemblyStyle.Simple;
            formatter1.Binder = AppStateSerializer.CustomBinder;
            this.OnBeforeDeserialize();
            obj1 = formatter1.Deserialize(stream1);
            this.OnAfterDeserialize();
            stream1.Close();
            return obj1;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType) {
            if ((value != null) && (destinationType == typeof (byte[]))) {
                MemoryStream stream1 = new MemoryStream();
                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter1.Serialize(stream1, value);
                byte[] buffer1 = stream1.ToArray();
                stream1.Close();
                return buffer1;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public virtual void OnAfterDeserialize() {
        }

        public virtual void OnBeforeDeserialize() {
        }
    }
}