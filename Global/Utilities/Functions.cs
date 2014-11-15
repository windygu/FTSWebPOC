#region

using System;
using System.Collections;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using FTS.Global.DataSurrogate;
using FTS.Global.Common;

#endregion

namespace FTS.Global.Utilities{
    public class Functions{
        public static string ToXml(object obj){
            StringWriter output = new StringWriter(new StringBuilder());
            XmlSerializer s = new XmlSerializer(obj.GetType());
            s.Serialize(output, obj);
            return output.ToString();
        }

        public static object FromXml(string xml, Type type){
            StringReader input = new StringReader(xml);
            XmlSerializer s = new XmlSerializer(type);
            object retObj = s.Deserialize(input);
            return retObj;
        }
        public static string DatasetToXml(DataSet ds)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            ds.WriteXml(sw);
            return sw.ToString();
        }
        public static DataSet DatasetFromXml(string xml)
        {
            System.IO.StringReader sr = new System.IO.StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds;
        }
        public static string Zip(string text){
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true)){
                zip.Write(buffer, 0, buffer.Length);
            }
            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();
            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);
            byte[] gzBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        public static string UnZip(string compressedText){
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream()){
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);
                byte[] buffer = new byte[msgLength];
                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress)){
                    zip.Read(buffer, 0, buffer.Length);
                }
                return Encoding.UTF8.GetString(buffer);
            }
        }

        public static void CopyObjectFromDataRow(DataRow Row, object TargetObject){
            BindingFlags MemberAccess = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                        BindingFlags.Instance | BindingFlags.IgnoreCase;
            MemberInfo[] miT = TargetObject.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess,
                                                                  null, null);
            foreach (MemberInfo Field in miT){
                string Name = Field.Name;
                if (!Row.Table.Columns.Contains(Name)){
                    continue;
                }
                if (Field.MemberType == MemberTypes.Field){
                    object oj = Row[Name];
                    if (oj == System.DBNull.Value){
                        ((FieldInfo) Field).SetValue(TargetObject, null);
                    }else{
                        ((FieldInfo)Field).SetValue(TargetObject, Row[Name]);
                    }
                } else if (Field.MemberType == MemberTypes.Property){
                     object oj = Row[Name];
                     if (oj == System.DBNull.Value){
                         ((PropertyInfo)Field).SetValue(TargetObject, null, null);
                     } else{
                         ((PropertyInfo)Field).SetValue(TargetObject, oj, null);
                     }
                }
            }
        }

        public static void CopyObjectFromDataRowDeleted(DataRow Row, object TargetObject)
        {            
            BindingFlags MemberAccess = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                        BindingFlags.Instance | BindingFlags.IgnoreCase;
            MemberInfo[] miT = TargetObject.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess,
                                                                  null, null);
            foreach (MemberInfo Field in miT)
            {
                string Name = Field.Name;
                if (!Row.Table.Columns.Contains(Name))
                {
                    continue;
                }
                if (Field.MemberType == MemberTypes.Field)
                {
                    object oj = Row[Name, DataRowVersion.Original];
                    if (oj == System.DBNull.Value)
                    {
                        ((FieldInfo)Field).SetValue(TargetObject, null);
                    }
                    else
                    {
                        ((FieldInfo)Field).SetValue(TargetObject, Row[Name, DataRowVersion.Original]);
                    }
                }
                else if (Field.MemberType == MemberTypes.Property)
                {
                    object oj = Row[Name, DataRowVersion.Original];
                    if (oj == System.DBNull.Value)
                    {
                        ((PropertyInfo)Field).SetValue(TargetObject, null, null);
                    }
                    else
                    {
                        ((PropertyInfo)Field).SetValue(TargetObject, oj, null);
                    }
                }
            }
        }

        public static void CopyObjectToDataRow(DataRow Row, object Target){
            BindingFlags MemberAccess = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                        BindingFlags.Instance | BindingFlags.IgnoreCase;
            MemberInfo[] miT = Target.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess, null,
                                                            null);
            foreach (MemberInfo Field in miT){
                string Name = Field.Name;
                if (!Row.Table.Columns.Contains(Name)){
                    continue;
                }
                if (Field.MemberType == MemberTypes.Field){
                    object oj = ((FieldInfo) Field).GetValue(Target);
                    if (((FieldInfo)Field).FieldType == Type.GetType("System.DateTime")){
                        DateTime dateoj = (System.DateTime)oj;
                        if ((dateoj.Day == 1) && (dateoj.Month == 1) && (dateoj.Year == 1)){
                            if ((Row[Name] != null) && (Row[Name] != System.DBNull.Value))
                            {
                            }
                            else
                            {
                                Row[Name] = System.DBNull.Value;
                            }
                        }else{
                            Row[Name] = oj;
                        }
                    }else{
                        if (oj == null){
                            if ((Row[Name] == null)||(Row[Name] == System.DBNull.Value))
                            {
                                if (((FieldInfo)Field).FieldType == Type.GetType("System.String"))
                                    Row[Name] = string.Empty;
                                else if (((FieldInfo)Field).FieldType == Type.GetType("System.Guid"))
                                    Row[Name] = Guid.Empty;
                                else if ((((FieldInfo)Field).FieldType == Type.GetType("System.Decimal")) || (((FieldInfo)Field).FieldType == Type.GetType("System.Int32")) || (((FieldInfo)Field).FieldType == Type.GetType("System.Int16")))
                                    Row[Name] = 0;
                            }
                            /*
                            else
                            {
                                Row[Name] = System.DBNull.Value;
                            }
                            */
                        }else{
                            Row[Name] = oj;
                        }
                    }
                } else if (Field.MemberType == MemberTypes.Property){
                     object oj = ((PropertyInfo) Field).GetValue(Target, null);
                     if (((PropertyInfo)Field).PropertyType == Type.GetType("System.DateTime")){
                         DateTime dateoj = (System.DateTime)oj;
                         if ((dateoj.Day == 1) && (dateoj.Month == 1) && (dateoj.Year == 1)){
                             if ((Row[Name] != null) && (Row[Name] != System.DBNull.Value))
                             {
                             }
                             else
                             {
                                 Row[Name] = System.DBNull.Value;
                             }
                         }else{
                             Row[Name] = oj;
                         }
                     }else{
                         if (oj == null){
                             if ((Row[Name] == null) || (Row[Name] == System.DBNull.Value))
                             {
                                 if (((PropertyInfo)Field).PropertyType == Type.GetType("System.String"))
                                     Row[Name] = string.Empty;
                                 else if (((PropertyInfo)Field).PropertyType == Type.GetType("System.Guid"))
                                     Row[Name] = Guid.Empty;
                                 else if ((((PropertyInfo)Field).PropertyType == Type.GetType("System.Decimal")) || (((PropertyInfo)Field).PropertyType == Type.GetType("System.Int32")) || (((PropertyInfo)Field).PropertyType == Type.GetType("System.Int16")))
                                     Row[Name] = 0;
                             }
                             /*
                             else
                             {
                                 Row[Name] = System.DBNull.Value;
                             }
                             */ 
                         }else{
                             Row[Name] = oj;
                         }
                     }
                }
            }
        }
        public static object GetNewIdValue(object Target, string idfield, object idvalue) {
            BindingFlags MemberAccess = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                        BindingFlags.Instance | BindingFlags.IgnoreCase;
            MemberInfo[] miT = Target.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess, null,
                                                            null);
            foreach (MemberInfo Field in miT) {
                string Name = Field.Name;
                if (Name.ToUpper() == idfield.ToUpper()) {
                    if (Field.MemberType == MemberTypes.Field) {
                        return ((FieldInfo) Field).GetValue(Target);
                    } else {
                        if (Field.MemberType == MemberTypes.Property) {
                            return ((PropertyInfo) Field).GetValue(Target, null);
                        }else {
                            return idvalue;
                        }
                    }
                }
            }
            return idvalue;
        }

        public static void CopyObjectData(object Source, object Target){
            BindingFlags MemberAccess = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                        BindingFlags.Instance | BindingFlags.IgnoreCase;
            MemberInfo[] miT = Target.GetType().GetMembers(MemberAccess);
            foreach (MemberInfo Field in miT){
                string Name = Field.Name;
                if (Field.MemberType == MemberTypes.Field){
                    FieldInfo SourceField = Source.GetType().GetField(Name);
                    if (SourceField == null){
                        continue;
                    }
                    object SourceValue = SourceField.GetValue(Source);
                    ((FieldInfo) Field).SetValue(Target, SourceValue);
                } else if (Field.MemberType == MemberTypes.Property){
                    PropertyInfo SourceField = Source.GetType().GetProperty(Name, MemberAccess);
                    object SourceValue = SourceField.GetValue(Source, null);
                    ((PropertyInfo) Field).SetValue(Target, SourceValue, null);
                }
            }
        }
        
        public static bool InList(string value, string list) {
            if (value.Length == 0) {
                return true;
            }
            string[] strsource = ParseString(list);
            for (int i = 0; i < strsource.Length; i++) {
                string listvalue = strsource[i].Trim();
                if (value.Trim() == listvalue.Trim()) {
                    return true;
                }
            }
            return false;
        }
        public static string[] ParseString(string instr) {
            int prepos = 0;
            int pos = 0;
            int start = 0;
            string instr1 = instr;
            if (instr1.Trim().Length > 0) {
                instr1 = instr1.Trim() + ",";
            }
            if (instr1.Trim().Length > 0 && instr1.IndexOf(",", 0) == 0) {
                instr1 = instr1.Substring(1);
            }
            ArrayList retstring = new ArrayList();
            pos = instr1.IndexOf(",", start);
            while (pos > 0) {
                retstring.Add(instr1.Substring(prepos, pos - prepos).Trim());
                prepos = pos + 1;
                start = pos + 1;
                pos = instr1.IndexOf(",", start);
            }
            string[] ret = new string[retstring.Count];
            for (int i = 0; i < retstring.Count; i++) {
                ret[i] = (string)retstring[i];
            }
            return ret;
        }
        public static byte[] CompressDataTableGlobal(DataTable dataTable)
        {
            DataTableSurrogate dtt = new DataTableSurrogate(dataTable);
            BinaryFormatter ser = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ser.Serialize(ms, dtt);
            byte[] buffer = ms.ToArray();
            byte[] zipBuffer = new CompressionHelper(CompressionLevel.FtstSpeed).CompressToBytes(buffer);
            return zipBuffer;
        }

        public static DataTable DeCompressDataTableGlobal(byte[] arrByte)
        {
            byte[] buffer = new CompressionHelper().DecompressToBytes(arrByte);
            BinaryFormatter ser = new BinaryFormatter();
            DataTableSurrogate dtt = ser.Deserialize(new MemoryStream(buffer)) as DataTableSurrogate;
            DataTable dataTable = dtt.ConvertToDataTable();
            return dataTable;
        }

        public static DataTable DeCompressDataTableGlobal2(byte[] arrByte)
        {
            byte[] buffer = new CompressionHelper().DecompressToBytes(arrByte);
            BinaryFormatter ser = new BinaryFormatter();
            DataTableSurrogate dtt = ser.Deserialize(new MemoryStream(buffer)) as DataTableSurrogate;
            DataTable dataTable = dtt.ConvertToDataTable2();
            return dataTable;
        }
    }
}