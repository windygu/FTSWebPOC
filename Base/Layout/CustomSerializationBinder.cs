#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for CustomSerializationBinder.
    /// </summary>
    public class CustomSerializationBinder : SerializationBinder {
        // Fields
        private Hashtable bindingInfo;
        private Hashtable typeNameVsAssembly;

        public CustomSerializationBinder() {
            this.bindingInfo = new Hashtable();
            this.typeNameVsAssembly = new Hashtable();
            Type type1 = typeof (Point);
            this.bindingInfo[type1.Assembly.GetName().Name.ToLower()] = type1.Assembly;
            type1 = typeof (Form);
            this.bindingInfo[type1.Assembly.GetName().Name.ToLower()] = type1.Assembly;
            type1 = typeof (Component);
            this.bindingInfo[type1.Assembly.GetName().Name.ToLower()] = type1.Assembly;
        }

        public override Type BindToType(string assemblyName, string typeName) {
            string text1 = typeName + assemblyName;
            text1 = text1.ToLower();
            if (this.typeNameVsAssembly[text1] != null) {
                Assembly assembly1 = this.typeNameVsAssembly[text1] as Assembly;
                return assembly1.GetType(typeName);
            }
            assemblyName = assemblyName.ToLower();
            if (this.bindingInfo[assemblyName] != null) {
                Assembly assembly2 = this.bindingInfo[assemblyName] as Assembly;
                return assembly2.GetType(typeName);
            }
            int num1 = assemblyName.IndexOf(",");
            if (num1 > 0) {
                string text2 = assemblyName.Substring(0, num1);
                if (this.bindingInfo[text2] != null) {
                    Assembly assembly3 = this.bindingInfo[text2] as Assembly;
                    return assembly3.GetType(typeName);
                }
            }
            return null;
        }

        public Hashtable AssemblyNamesVsAssembly {
            get { return this.bindingInfo; }
        }

        public Hashtable TypeNamesVsAssembly {
            get { return this.typeNameVsAssembly; }
        }
    }
}