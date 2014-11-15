#region

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for AppStateSerializer.
    /// </summary>
    public sealed class AppStateSerializer {
        // Fields
        //private EventHandler BeforePersist;
        private static CustomSerializationBinder customBinder;
        private bool enabled;
        private Hashtable htSerialize;
        private IsolatedStorageScope isoScope;

        private const IsolatedStorageScope issDefault =
            (IsolatedStorageScope.Assembly | (IsolatedStorageScope.Domain | IsolatedStorageScope.User));

        private static AppStateSerializer objInstance;
        private SerializeMode serMode;
        private object serPath;
        private const string strApplicationVerisonName = "ApplicationVersion";
        private const string strDefault = "SyncfusionToolsStateInfo";
        private WeakReference weakRef;
        public event EventHandler BeforePersist;

        static AppStateSerializer() {
            objInstance = null;
            customBinder = new CustomSerializationBinder();
        }

        public AppStateSerializer(SerializeMode mode, object persistpath)
            : this(
                mode, persistpath,
                IsolatedStorageScope.Assembly | (IsolatedStorageScope.Domain | IsolatedStorageScope.User)) {
        }

        public AppStateSerializer(SerializeMode mode, object persistpath, IsolatedStorageScope scope) {
            this.enabled = true;
            this.serMode = SerializeMode.IsolatedStorage;
            this.serPath = "SyncfusionToolsStateInfo";
            this.isoScope = IsolatedStorageScope.Assembly | (IsolatedStorageScope.Domain | IsolatedStorageScope.User);
            this.htSerialize = new Hashtable();
            this.weakRef = null;
            this.serMode = mode;
            if (mode == SerializeMode.WindowsRegistry) {
                RegistryKey key1 = persistpath as RegistryKey;
                if (key1 == null) {
                    throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath.");
                }
                this.serPath = key1.Name;
            } else if ((mode == SerializeMode.BinaryFmtStream) || (mode == SerializeMode.XMLFmtStream)) {
                Stream stream1 = persistpath as Stream;
                if (((stream1 == null) || !stream1.CanRead) || !stream1.CanSeek) {
                    throw new ApplicationException(
                        "Syncfusion AppStateSerializer - Invalid Stream specified for the PersistencePath. The PersistencePath should be a valid Stream instance with Read and Seek capability.");
                }
                this.serPath = persistpath;
            } else {
                this.serPath = persistpath;
            }
            this.isoScope = scope;
            this.Init();
        }

        private static void DeletePersistentStore(SerializeMode mode, object serpath, IsolatedStorageScope scope,
                                                  ICollection values) {
            IsolatedStorageFile file1;
            RegistryKey key1;
            string[] textArray2;
            int num1;
            switch (mode) {
                case SerializeMode.IsolatedStorage: {
                    file1 = IsolatedStorageFile.GetStore(scope, (Type) null, (Type) null);
                    string[] textArray1 = file1.GetFileNames((serpath as string) + ".bin");
                    textArray2 = textArray1;
                    num1 = 0;
                    goto Label_0056;
                }
                case SerializeMode.BinaryFile: {
                    string text2 = (serpath as string) + ".bin";
                    if (File.Exists(text2)) {
                        File.Delete(text2);
                    }
                    return;
                }
                case SerializeMode.XMLFile: {
                    string text3 = (serpath as string) + ".xml";
                    if (File.Exists(text3)) {
                        File.Delete(text3);
                    }
                    return;
                }
                case SerializeMode.WindowsRegistry: {
                    key1 = null;
                    if (serpath.GetType() != typeof (RegistryKey)) {
                        key1 = GetRegistryKey(serpath as string);
                        goto Label_00D4;
                    }
                    key1 = serpath as RegistryKey;
                    goto Label_00D4;
                }
                default: {
                    return;
                }
            }
            Label_0056:
            if (num1 >= textArray2.Length) {
                return;
            }
            string text1 = textArray2[num1];
            file1.DeleteFile(text1);
            num1++;
            goto Label_0056;
            Label_00D4:
            if (key1 == null) {
                throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath");
            }
            foreach (string text4 in values) {
                key1.DeleteValue(text4, false);
            }
            key1.Close();
        }

        private object DeserializeFromHashtable(Hashtable ht, string strname) {
            IFormatter formatter1 = GetFormatter(this.serMode);
            if (ht.Contains(strname)) {
                object obj1 = ht[strname];
                if (obj1.GetType() == typeof (MemoryStream)) {
                    MemoryStream stream1 = obj1 as MemoryStream;
                    stream1.Seek((long) 0, SeekOrigin.Begin);
                    try {
                        return formatter1.Deserialize(obj1 as MemoryStream);
                    } catch (Exception) {
                        goto Label_00BB;
                    }
                }
                if ((this.serMode != SerializeMode.XMLFile) && (this.serMode != SerializeMode.XMLFmtStream)) {
                    return ht[strname];
                }
                UTF8Encoding encoding1 = new UTF8Encoding();
                byte[] buffer1 = encoding1.GetBytes(ht[strname] as string);
                MemoryStream stream2 = new MemoryStream(buffer1, 0, buffer1.Length, false);
                object obj2 = null;
                try {
                    obj2 = formatter1.Deserialize(stream2);
                } catch (Exception) {
                } finally {
                    stream2.Close();
                }
                return obj2;
            }
            Label_00BB:
            return null;
        }

        [Browsable(false),
         Obsolete(
             "This method will be removed in a future version. Please check the class reference for an alternative.",
             false)]
        public static object DeserializeIsolatedObject(SerializeMode mode, object persistpath, string strname) {
            return DeserializeIsolatedObject(mode, persistpath,
                                             IsolatedStorageScope.Assembly |
                                             (IsolatedStorageScope.Domain | IsolatedStorageScope.User), strname);
        }

        [Browsable(false),
         Obsolete(
             "This method will be removed in a future version. Please check the class reference for an alternative.",
             false)]
        public static object DeserializeIsolatedObject(object persistpath, IsolatedStorageScope scope, string strname) {
            return DeserializeIsolatedObject(SerializeMode.IsolatedStorage, persistpath, scope, strname);
        }

        private static object DeserializeIsolatedObject(SerializeMode mode, object persistpath,
                                                        IsolatedStorageScope scope, string strname) {
            object obj1 = null;
            IFormatter formatter1 = GetFormatter(mode);
            Stream stream1 = null;
            if ((mode == SerializeMode.BinaryFmtStream) || (mode == SerializeMode.XMLFmtStream)) {
                stream1 = persistpath as Stream;
                if (((stream1 == null) || !stream1.CanRead) || !stream1.CanSeek) {
                    throw new ApplicationException(
                        "Syncfusion AppStateSerializer - Invalid Stream specified for the PersistencePath. The PersistencePath should be a valid Stream instance with Read and Seek capability.");
                }
            } else {
                stream1 = GetStream(mode, persistpath, scope, false);
            }
            if (stream1 == null) {
                return null;
            }
            try {
                if (mode == SerializeMode.WindowsRegistry) {
                    RegistryKey key1 = persistpath as RegistryKey;
                    if (key1 == null) {
                        throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath");
                    }
                    byte[] buffer1 = key1.GetValue(strname) as byte[];
                    key1.Close();
                    if (buffer1 != null) {
                        stream1.Seek((long) 0, SeekOrigin.Begin);
                        stream1.Write(buffer1, 0, buffer1.Length);
                        stream1.Seek((long) 0, SeekOrigin.Begin);
                        obj1 = formatter1.Deserialize(stream1);
                    }
                    return obj1;
                }
                obj1 = formatter1.Deserialize(stream1);
            } catch (Exception) {
            } finally {
                if ((mode != SerializeMode.BinaryFmtStream) && (mode != SerializeMode.XMLFmtStream)) {
                    stream1.Close();
                }
            }
            return obj1;
        }

        public object DeserializeObject(string strname) {
            if (this.Enabled) {
                if (this.htSerialize.Contains(strname)) {
                    return this.DeserializeFromHashtable(this.htSerialize, strname);
                }
                if ((this.weakRef == null) || !this.weakRef.IsAlive) {
                    this.LoadPersistedData();
                }
                if ((this.weakRef != null) && this.weakRef.IsAlive) {
                    Hashtable hashtable1 = this.weakRef.Target as Hashtable;
                    if (hashtable1.Contains(strname)) {
                        return this.DeserializeFromHashtable(hashtable1, strname);
                    }
                }
            }
            return null;
        }

        public void FlushSerializer() {
            this.weakRef = null;
            DeletePersistentStore(this.serMode, this.serPath, this.isoScope, this.htSerialize.Keys);
            this.htSerialize.Clear();
        }

        private static IFormatter GetFormatter(SerializeMode mode) {
            if ((mode == SerializeMode.XMLFile) || (mode == SerializeMode.XMLFmtStream)) {
                return GetSoapFormatter();
            }
            BinaryFormatter formatter1 = new BinaryFormatter();
            formatter1.AssemblyFormat = FormatterAssemblyStyle.Simple;
            formatter1.Binder = customBinder;
            return formatter1;
        }

        [Obsolete("This method will be removed in a future version. Please use the GetSingleton method instead.", false)
        , Browsable(false)]
        public static AppStateSerializer GetInstance() {
            return GetSingleton();
        }

        private static RegistryKey GetRegistryKey(string strregkey) {
            string text1 = strregkey.Substring(0, strregkey.IndexOf(@"\", 0));
            RegistryHive[] hiveArray1 = Enum.GetValues(typeof (RegistryHive)) as RegistryHive[];
            RegistryHive[] hiveArray2 = hiveArray1;
            for (int num1 = 0; num1 < hiveArray2.Length; num1++) {
                RegistryHive hive1 = hiveArray2[num1];
                RegistryKey key1 = RegistryKey.OpenRemoteBaseKey(hive1, string.Empty);
                if (key1.Name.Equals(text1)) {
                    return key1.CreateSubKey(strregkey.Substring(strregkey.IndexOf(@"\") + 1));
                }
            }
            return null;
        }

        public static AppStateSerializer GetSingleton() {
            if (objInstance == null) {
                InitializeSingleton(SerializeMode.IsolatedStorage, "SyncfusionToolsStateInfo",
                                    IsolatedStorageScope.Assembly |
                                    (IsolatedStorageScope.Domain | IsolatedStorageScope.User));
            }
            return objInstance;
        }

        private static IFormatter GetSoapFormatter() {
            SoapFormatter formatter1 = new SoapFormatter();
            formatter1.AssemblyFormat = FormatterAssemblyStyle.Simple;
            formatter1.Binder = customBinder;
            return formatter1;
        }

        private static Stream GetStream(SerializeMode mode, object path, IsolatedStorageScope scope, bool bwrite) {
            try {
                IsolatedStorageFile file2;
                string text2;
                SerializeMode mode1;
                string[] textArray3;
                int num1;
                if (bwrite) {
                    mode1 = mode;
                    switch (mode1) {
                        case SerializeMode.IsolatedStorage: {
                            IsolatedStorageFile file1 = IsolatedStorageFile.GetStore(scope, (Type) null, (Type) null);
                            string text1 = (path as string) + ".bin";
                            string[] textArray1 = file1.GetFileNames(text1);
                            if (textArray1.Length > 0) {
                                file1.DeleteFile(text1);
                            }
                            return new IsolatedStorageFileStream(text1, FileMode.CreateNew, file1);
                        }
                        case SerializeMode.BinaryFile: {
                            return File.Open((path as string) + ".bin", FileMode.Create);
                        }
                        case SerializeMode.XMLFile: {
                            return File.Open((path as string) + ".xml", FileMode.Create);
                        }
                        case SerializeMode.WindowsRegistry: {
                            return new MemoryStream();
                        }
                    }
                    goto Label_018C;
                }
                mode1 = mode;
                switch (mode1) {
                    case SerializeMode.IsolatedStorage: {
                        if (AppDomain.CurrentDomain.Evidence.Count <= 0) {
                            goto Label_018C;
                        }
                        file2 = IsolatedStorageFile.GetStore(scope, (Type) null, (Type) null);
                        string[] textArray2 = file2.GetFileNames((path as string) + ".bin");
                        textArray3 = textArray2;
                        num1 = 0;
                        goto Label_0122;
                    }
                    case SerializeMode.BinaryFile: {
                        string text3 = (path as string) + ".bin";
                        if (File.Exists(text3)) {
                            return File.Open(text3, FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                        goto Label_018C;
                    }
                    case SerializeMode.XMLFile: {
                        string text4 = (path as string) + ".xml";
                        if (File.Exists(text4)) {
                            return File.Open(text4, FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                        goto Label_018C;
                    }
                    case SerializeMode.WindowsRegistry: {
                        return new MemoryStream();
                    }
                    default: {
                        goto Label_018C;
                    }
                }
                Label_010B:
                text2 = textArray3[num1];
                return new IsolatedStorageFileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read, file2);
                Label_0122:
                if (num1 < textArray3.Length) {
                    goto Label_010B;
                }
            } catch (Exception) {
            }
            Label_018C:
            return null;
        }

        private void Init() {
            this.LoadPersistedData();
            if ((this.weakRef != null) && this.weakRef.IsAlive) {
                Hashtable hashtable1 = this.weakRef.Target as Hashtable;
                foreach (string text1 in hashtable1.Keys) {
                    this.htSerialize.Add(text1, hashtable1[text1]);
                }
            }
        }

        [Obsolete("This method will be removed in a future version. Please use the InitializeSingleton method instead.",
            false), Browsable(false)]
        public static void InitializeSerializer(SerializeMode mode, object persistpath, IsolatedStorageScope scope) {
            InitializeSingleton(mode, persistpath, scope);
        }

        public static void InitializeSingleton(SerializeMode mode, object persistpath) {
            InitializeSingleton(mode, persistpath,
                                IsolatedStorageScope.Assembly |
                                (IsolatedStorageScope.Domain | IsolatedStorageScope.User));
        }

        public static void InitializeSingleton(SerializeMode mode, object persistpath, IsolatedStorageScope scope) {
            if (objInstance == null) {
                objInstance = new AppStateSerializer(mode, persistpath, scope);
                Application.ApplicationExit += new EventHandler(objInstance.OnApplicationExit);
            }
        }

        private void LoadPersistedData() {
            if (this.Enabled) {
                IFormatter formatter1 = GetFormatter(this.serMode);
                Stream stream1 = null;
                if ((this.serMode == SerializeMode.BinaryFmtStream) || (this.serMode == SerializeMode.XMLFmtStream)) {
                    stream1 = this.serPath as Stream;
                } else {
                    stream1 = GetStream(this.serMode, this.serPath, this.isoScope, false);
                }
                if (stream1 != null) {
                    Hashtable hashtable1 = null;
                    if (this.serMode == SerializeMode.WindowsRegistry) {
                        hashtable1 = new Hashtable();
                        RegistryKey key1 = GetRegistryKey(this.serPath as string);
                        if (key1 == null) {
                            throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath.");
                        }
                        string[] textArray1 = key1.GetValueNames();
                        string[] textArray2 = textArray1;
                        for (int num1 = 0; num1 < textArray2.Length; num1++) {
                            string text1 = textArray2[num1];
                            byte[] buffer1 = key1.GetValue(text1) as byte[];
                            stream1.Seek((long) 0, SeekOrigin.Begin);
                            stream1.Write(buffer1, 0, buffer1.Length);
                            stream1.Seek((long) 0, SeekOrigin.Begin);
                            try {
                                hashtable1.Add(text1, formatter1.Deserialize(stream1));
                            } catch (Exception) {
                            }
                        }
                        key1.Close();
                    } else {
                        try {
                            if ((stream1.Length > 0) && (stream1.Position < stream1.Length)) {
                                hashtable1 = formatter1.Deserialize(stream1) as Hashtable;
                            }
                        } catch (Exception) {
                            if ((this.serMode != SerializeMode.BinaryFmtStream) &&
                                (this.serMode != SerializeMode.XMLFmtStream)) {
                                stream1.Close();
                            }
                            return;
                        }
                    }
                    if ((this.serMode != SerializeMode.BinaryFmtStream) && (this.serMode != SerializeMode.XMLFmtStream)) {
                        stream1.Close();
                    }
                    this.weakRef = new WeakReference(hashtable1);
                }
            }
        }

        //[DocumentationExclude]
        public void OnApplicationExit(object sender, EventArgs e) {
            if (this.Enabled) {
                this.PersistNow();
            }
        }

        private void OnBeforePersist(EventArgs e) {
            this.SerializeObject("ApplicationVersion", Application.ProductVersion);
            if (this.BeforePersist != null) {
                this.BeforePersist(this, e);
            }
        }

        public void PersistNow() {
            if (this.Enabled) {
                this.OnBeforePersist(EventArgs.Empty);
                if (this.htSerialize.Count > 0) {
                    IFormatter formatter1 = GetFormatter(this.serMode);
                    Stream stream1 = null;
                    if ((this.serMode == SerializeMode.BinaryFmtStream) || (this.serMode == SerializeMode.XMLFmtStream)) {
                        stream1 = this.serPath as Stream;
                        if (!stream1.CanWrite) {
                            throw new ApplicationException(
                                "Syncfusion AppStateSerializer - Invalid Stream specified for the PersistencePath. The PersistencePath should be a valid Stream instance with Read, Write, and Seek capability.");
                        }
                    } else {
                        stream1 = GetStream(this.serMode, this.serPath, this.isoScope, true);
                    }
                    if (stream1 == null) {
                        return;
                    }
                    try {
                        if (this.serMode == SerializeMode.WindowsRegistry) {
                            RegistryKey key1 = GetRegistryKey(this.serPath as string);
                            if (key1 == null) {
                                throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath");
                            }
                            foreach (string text1 in this.htSerialize.Keys) {
                                object obj1 = this.htSerialize[text1];
                                if (obj1.GetType() == typeof (MemoryStream)) {
                                    stream1 = obj1 as MemoryStream;
                                } else {
                                    formatter1.Serialize(stream1, obj1);
                                }
                                key1.SetValue(text1, (stream1 as MemoryStream).ToArray());
                                stream1.Position = 0;
                            }
                            key1.Close();
                            return;
                        }
                        formatter1.Serialize(stream1, this.htSerialize);
                        return;
                    } catch (Exception) {
                        return;
                    } finally {
                        if ((this.serMode != SerializeMode.BinaryFmtStream) &&
                            (this.serMode != SerializeMode.XMLFmtStream)) {
                            stream1.Close();
                        }
                        this.weakRef = null;
                        this.htSerialize.Clear();
                    }
                }
                this.FlushSerializer();
            }
        }

        [Browsable(false),
         Obsolete(
             "This method will be removed in a future version. Please check the class reference for an alternative.",
             false)]
        public static void SerializeIsolatedObject(SerializeMode mode, object persistpath, string strname, object obj) {
            SerializeIsolatedObject(mode, persistpath,
                                    IsolatedStorageScope.Assembly |
                                    (IsolatedStorageScope.Domain | IsolatedStorageScope.User), strname, obj);
        }

        [Browsable(false),
         Obsolete(
             "This method will be removed in a future version. Please check the class reference for an alternative.",
             false)]
        public static void SerializeIsolatedObject(object persistpath, IsolatedStorageScope scope, string strname,
                                                   object obj) {
            SerializeIsolatedObject(SerializeMode.IsolatedStorage, persistpath, scope, strname, obj);
        }

        private static void SerializeIsolatedObject(SerializeMode mode, object persistpath, IsolatedStorageScope scope,
                                                    string strname, object obj) {
            if (obj != null) {
                IFormatter formatter1 = GetFormatter(mode);
                Stream stream1 = null;
                if ((mode == SerializeMode.BinaryFmtStream) || (mode == SerializeMode.XMLFmtStream)) {
                    stream1 = persistpath as Stream;
                    if (((stream1 == null) || !stream1.CanRead) || (!stream1.CanWrite || !stream1.CanSeek)) {
                        throw new ApplicationException(
                            "Syncfusion AppStateSerializer - Invalid Stream specified for the PersistencePath. The PersistencePath should be a valid Stream instance with Read, Write, and Seek capability.");
                    }
                } else {
                    stream1 = GetStream(mode, persistpath, scope, true);
                }
                if (stream1 == null) {
                    return;
                }
                try {
                    if (mode == SerializeMode.WindowsRegistry) {
                        RegistryKey key1 = persistpath as RegistryKey;
                        if (key1 == null) {
                            throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath.");
                        }
                        formatter1.Serialize(stream1, obj);
                        key1.SetValue(strname, (stream1 as MemoryStream).ToArray());
                        key1.Close();
                        return;
                    }
                    formatter1.Serialize(stream1, obj);
                    return;
                } catch (Exception) {
                    return;
                } finally {
                    if ((mode != SerializeMode.BinaryFmtStream) && (mode != SerializeMode.XMLFmtStream)) {
                        stream1.Close();
                    }
                }
            }
            string[] textArray1 = new string[1] {strname};
            DeletePersistentStore(mode, persistpath, scope, textArray1);
        }

        public void SerializeObject(string strname, object obj) {
            if (this.Enabled) {
                this.SerializeObject(strname, obj, false);
            }
        }

        public void SerializeObject(string strname, object obj, bool infinalize) {
            if (this.Enabled) {
                if (this.htSerialize.Contains(strname) || (obj == null)) {
                    this.htSerialize.Remove(strname);
                    if (obj == null) {
                        if (this.serMode == SerializeMode.WindowsRegistry) {
                            RegistryKey key1 = GetRegistryKey(this.serPath as string);
                            if (key1 == null) {
                                throw new ApplicationException("Invalid RegistryKey specified for the PersistencePath.");
                            }
                            key1.DeleteValue(strname, false);
                            key1.Close();
                        }
                        return;
                    }
                }
                if (infinalize) {
                    this.htSerialize.Add(strname, obj);
                } else {
                    IFormatter formatter1 = GetFormatter(this.serMode);
                    MemoryStream stream1 = new MemoryStream();
                    try {
                        formatter1.Serialize(stream1, obj);
                    } catch (Exception) {
                        return;
                    }
                    if ((this.serMode == SerializeMode.XMLFile) || (this.serMode == SerializeMode.XMLFmtStream)) {
                        UTF8Encoding encoding1 = new UTF8Encoding();
                        string text1 = encoding1.GetString(stream1.ToArray());
                        this.htSerialize.Add(strname, text1);
                    } else {
                        this.htSerialize.Add(strname, stream1);
                    }
                }
            }
        }

        public static void SetBindingInfo(string assemblyName, Assembly assembly) {
            assemblyName = assemblyName.ToLower();
            if (assembly != null) {
                customBinder.AssemblyNamesVsAssembly[assemblyName] = assembly;
            } else {
                customBinder.AssemblyNamesVsAssembly.Remove(assemblyName);
            }
        }

        public static void SetTypeBindingInfo(string assemblyName, string typeName, Assembly assembly) {
            string text1 = typeName + assemblyName;
            text1 = text1.ToLower();
            if (assembly != null) {
                customBinder.TypeNamesVsAssembly[text1] = assembly;
            } else {
                customBinder.TypeNamesVsAssembly.Remove(text1);
            }
        }

        //[DocumentationExclude]
        public static CustomSerializationBinder CustomBinder {
            get { return customBinder; }
        }

        public string DeserializedInfoApplicationVersion {
            get {
                object obj1 = this.DeserializeObject("ApplicationVersion");
                if (obj1 != null) {
                    return (string) obj1;
                }
                return string.Empty;
            }
        }

        public bool Enabled {
            get { return this.enabled; }
            set {
                if (this.enabled != value) {
                    this.enabled = value;
                }
            }
        }

        public IsolatedStorageScope IsoStorageScope {
            get { return this.isoScope; }
        }

        public SerializeMode SerializationMode {
            get { return this.serMode; }
        }

        public object SerializationPath {
            get { return this.serPath; }
        }
    }
}