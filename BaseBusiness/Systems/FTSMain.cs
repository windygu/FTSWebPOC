// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:53
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FTSMain.cs
// Project Item Filename:     FTSMain.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using FTS.BaseBusiness.Business;
using FTS.BaseBusiness.Utilities;
using FTS.Global;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseBusiness.Systems
{
    [Serializable]
    public class FTSMain : FTSMainBase
    {
        //private FTSMainForm mMainForm;
        public bool ISDEV = false;
        public bool IsWeb = false;
        public string LanguageList;
        public string PathName;
        public string ServicePathName;
        [NonSerialized] private bool mAtPfs = false;
        [NonSerialized] private Int16[] mBarcodeLength;
//        private ExceptionManager mExceptionManager;
        //[NonSerialized] private ExceptionManager mExceptionManager;
        [NonSerialized] private bool mHtIsLinkToPos = false;
        [NonSerialized] private bool mMyVar;
        [NonSerialized] private Pfs mPfs = null;
        [NonSerialized] private string mPfsUrl = string.Empty;
        [NonSerialized] private PoleDisplay mPoleDisplay = null;
        [NonSerialized] private string mPosPrintNameInvoice = string.Empty;
        [NonSerialized] private List<string> mProjectID;
        [NonSerialized] private SecurityManager mSecurityManager;
        private string mSpecialChars = string.Empty;
        private Sys_Lock mSys_Lock;
        private XmlQuery mXmlQuery;
        public string oldversion = string.Empty;

        public FTSMain()
            : base()
        {
        }

        //public FTSMainForm MainForm {
        //    get { return this.mMainForm; }
        //    set { this.mMainForm = value; }
        //}
//        public ExceptionManager ExceptionManager
//        {
//            get { return mExceptionManager; }
//            set { mExceptionManager = value; }
//        }

        public SecurityManager SecurityManager
        {
            get { return mSecurityManager; }
            set { mSecurityManager = value; }
        }

        public List<string> ProjectID
        {
            get { return mProjectID; }
            set { mProjectID = value; }
        }

        public string PosPrintNameInvoice
        {
            get { return mPosPrintNameInvoice; }
        }

        public PoleDisplay PoleDisplay
        {
            get { return mPoleDisplay; }
        }

        public string[] SpecialChars
        {
            get { return mSpecialChars.Split(' '); }
        }

        public Int16[] BarcodeLength
        {
            get { return mBarcodeLength; }
        }

        public bool HtIsLinkToPos
        {
            get { return mHtIsLinkToPos; }
            set { mHtIsLinkToPos = value; }
        }

        public Pfs Pfs
        {
            get { return mPfs; }
        }

        public XmlQuery XmlQuery
        {
            get { return mXmlQuery; }
            set { mXmlQuery = value; }
        }

        public Sys_Lock Sys_Lock
        {
            get { return mSys_Lock; }
            set { mSys_Lock = value; }
        }

        public string PfsUrl
        {
            get { return mPfsUrl; }
        }

        public bool AtPfs
        {
            get { return mAtPfs; }
            set { mAtPfs = value; }
        }

        public void RunBeforeLogin()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(PathName + "FTS.MainUI.exe.config");
            XmlNodeList xndata = xmlDoc.SelectNodes("/configuration/system.data");
            bool flagdata = false;
            foreach (XmlNode xn in xndata)
            {
                flagdata = true;
            }
            if (!flagdata)
            {
                XmlElement newdataelement = xmlDoc.CreateElement("system.data");
                XmlElement newdbproviderelement = xmlDoc.CreateElement("DbProviderFactories");
                XmlElement newaddelement = xmlDoc.CreateElement("add");
                XmlAttribute newnameatt = xmlDoc.CreateAttribute("name");
                newnameatt.Value = "VistaDB Data Provider";
                newaddelement.Attributes.Append(newnameatt);

                XmlAttribute newinvariantatt = xmlDoc.CreateAttribute("invariant");
                newinvariantatt.Value = "VistaDB.NET20";
                newaddelement.Attributes.Append(newinvariantatt);

                XmlAttribute newdescriptionatt = xmlDoc.CreateAttribute("description");
                newdescriptionatt.Value = ".Net Framework Data Provider for VistaDB";
                newaddelement.Attributes.Append(newdescriptionatt);

                XmlAttribute newtypeatt = xmlDoc.CreateAttribute("type");
                newtypeatt.Value =
                    "VistaDB.Provider.VistaDBProviderFactory, VistaDB.NET20, Version=3.4.1.63, Culture=neutral, PublicKeyToken=dfc935afe2125461";
                newaddelement.Attributes.Append(newtypeatt);

                newdbproviderelement.AppendChild(newaddelement);
                newdataelement.AppendChild(newdbproviderelement);
                xmlDoc.DocumentElement.AppendChild(newdataelement);
                xmlDoc.Save(PathName + "FTS.MainUI.exe.config");
            }
            Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var syscachevista = new ConnectionStringSettings("SysCacheVista",
                "Data Source=SysCacheVista.vdb3;Open Mode=NonexclusiveReadWrite", "VistaDB.NET20");
            if (Config.ConnectionStrings.ConnectionStrings.IndexOf(syscachevista) < 0)
            {
                Config.ConnectionStrings.ConnectionStrings.Add(syscachevista);
                Config.Save();
                Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                mPosPrintNameInvoice = Config.AppSettings.Settings["POS_PRINT_NAME_INVOICE"].Value;
            }
            catch (Exception)
            {
            }
            try
            {
                mSpecialChars = Config.AppSettings.Settings["SPECIALCHARS"].Value + " &";
            }
            catch (Exception)
            {
            }
            Language = Config.AppSettings.Settings["LANGUAGE"].Value;
            LanguageList = "VN";
            try
            {
                LanguageList = Config.AppSettings.Settings["LANGUAGE_LIST"].Value;
            }
            catch (Exception)
            {
            }
            Url = Config.AppSettings.Settings["SERVERURL"].Value;
            DataPath = Config.AppSettings.Settings["DATAPATH"].Value;
            if (DataPath != string.Empty && DataPath.Substring(0, 1) != "\\")
            {
                DataPath = PathName + DataPath + "\\";
            }
            //this.RegisterSkins();
            UserInfo = new UserInfo();
        }

        public void RunBeforeCheckVersion()
        {
            Url = Config.AppSettings.Settings["SERVERURL"].Value;
            RunScripts();
            SystemVars = new SystemVars(this);
            WorkStationId = (int) SystemVars.GetSystemVars("WORKSTATION_ID");
            IsMultiSite = (bool) SystemVars.GetSystemVars("IS_MULTI_SITE");
            if (DbMain.WorkingMode == WorkingMode.WAN)
            {
                OpenSystemCache();
                /*
                this.IsMultiSite = false;
                */
            }
            mPfsUrl = SystemVars.GetOrganizationVar("PFS_SERVICE_URL").ToString();
            if (mPfsUrl == string.Empty)
            {
                try
                {
                    mPfsUrl = SystemVars.GetSystemVars("PFS_SERVICE_URL").ToString();
                }
                catch (Exception)
                {
                }
            }
            if (mPfsUrl != string.Empty && DbMain.WorkingMode == WorkingMode.WAN)
            {
                mPfs = new Pfs(this);
            }
            IsChildSite = (bool) SystemVars.GetSystemVars("IS_CHILD_SITE");
            TableManager = new TableManager(this);
            IdManager = new IdManager(this);
        }

        public void Run()
        {
            FieldManager = new FieldManager(this);
            FormManager = new FormManager(this);
            GridManager = new GridManager(this);
            MsgManager = new MsgManager(this);
            //this.ExceptionManager = new ExceptionManager(this);
            DEBUG = (bool) SystemVars.GetSystemVars("DEBUG");
            DayStartOfFirstYear = (DateTime) SystemVars.GetSystemVars("DAY_START_YEAR");
            TPSTVND = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT");
            TPSTNTE = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_ORIG");
            try
            {
                TPSTEXTRA = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_EXTRA");
            }
            catch (Exception)
            {
            }
            TPDGVND = (int) SystemVars.GetSystemVars("DECIMAL_PRICE");
            TPDGNTE = (int) SystemVars.GetSystemVars("DECIMAL_PRICE_ORIG");
            VNDCurrency = SystemVars.GetSystemVars("CURRENCY_ID_VND").ToString();
            MainCurrency = SystemVars.GetSystemVars("MAIN_CURRENCY").ToString();
            SecondCurrency = SystemVars.GetSystemVars("SECOND_CURRENCY").ToString();
            ReportMethod = SystemVars.GetSystemVars("REPORT_METHOD").ToString();
            mPoleDisplay = new PoleDisplay((string) SystemVars.GetSystemVars("PORT_POLE_DISPLAY"));
            string[] strbarcodelength = SystemVars.GetSystemVars("BARCODE_LENGTH").ToString().Split(',');
            mBarcodeLength = new Int16[strbarcodelength.Length];
            for (int length = 0; length < strbarcodelength.Length; length++)
            {
                try
                {
                    mBarcodeLength[length] = Convert.ToInt16(strbarcodelength[length]);
                }
                catch
                {
                    mBarcodeLength[length] = 4096;
                }
            }
            //this.LookAndFeel.LookAndFeel.SetSkinStyle(this.LookAndFeel.LookAndFeel.SkinName);
            SecurityManager = new SecurityManager(this, true);
            ResourceManager = new ResourceManager(this, LanguageList);
            Sys_Lock = new Sys_Lock(this);
            CheckSerialKey();
            CheckSystem();
            try
            {
                IsMultiOrganization = (bool) SystemVars.GetSystemVars("IS_MULTI_ORGANIZATION");
            }
            catch (Exception)
            {
            }
            try
            {
                UseForeignCurrency = (bool) SystemVars.GetSystemVars("USE_FOREIGN_CURRENCY");
            }
            catch (Exception)
            {
            }
            if (IsMultiSite)
            {
                CommunicateManager = new CommunicateManager(this);
            }
            DbMain.ExecuteNonQuery(
                DbMain.GetSqlStringCommand("UPDATE SYS_TRAN_NO SET TRAN_YEAR=" + DayStartOfCurrentYear.Year +
                                           " WHERE TRAN_YEAR=0"));
            SetSME();
        }


        public void RunWebPOC()
        {
            Language = "VN";
            Language = ConfigurationSettings.AppSettings["LANGUAGE"];
            var database = ConfigurationSettings.AppSettings["DATABASE"];
            var servername = ConfigurationSettings.AppSettings["SERVERNAME"];   
            var userid = ConfigurationSettings.AppSettings["USERID"];
            var password = ConfigurationSettings.AppSettings["PASSWORD"];
            CreateDatabase();
            DatabaseFile = database;

            if (servername == string.Empty)
            {
                servername = "(local)";
            }

            if (userid == string.Empty)
            {
                userid = "sa";
            }

            if (userid == string.Empty)
            {
                userid = "master";
            }
            DbMain.WorkingMode = WorkingMode.LAN;
            DbMain.SetConnectionString("Database=" + database + ";Server=" + servername +
                                       ";User ID=" + userid + ";Password=" + password + ";");
            
            WorkingYear = Convert.ToInt32(2014);

            Language = "VN";
            string tmpToken = DbMain.BuildParameterName("ABC");
            ParameterToken = tmpToken.Trim() != string.Empty ? tmpToken.Trim().Substring(0, 1) : string.Empty;
            DbMain.WorkingMode = WorkingMode.LAN;
            
            UserInfo = new UserInfo {UserGroupID = "ADMIN", OrganizationID = "0000"};

            SystemVars = new SystemVars(this);
            FieldManager = new FieldManager(this);
            FormManager = new FormManager(this);
            GridManager = new GridManager(this);
            MsgManager = new MsgManager(this);
            SecurityManager = new SecurityManager(this, true);
            ResourceManager = new ResourceManager(this, "VN");

            TableManager = new TableManager(this);
            IdManager = new IdManager(this);
            Sys_Lock = new Sys_Lock(this);
            DbConnection cnn = DbMain.CreateConnection();

            DatabaseName = cnn.Database;
            DatabaseServer = cnn.DataSource;
        }

        public void RunWeb()
        {
            IsWeb = true;
            try
            {
                mPosPrintNameInvoice = ConfigurationSettings.AppSettings["POS_PRINT_NAME_INVOICE"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                mSpecialChars = ConfigurationSettings.AppSettings["SPECIALCHARS"].ToString() + " &";
            }
            catch (Exception)
            {
            }
            Language = ConfigurationSettings.AppSettings["LANGUAGE"].ToString();
            LanguageList = Language;
            try
            {
                LanguageList = Config.AppSettings.Settings["LANGUAGE_LIST"].Value;
            }
            catch (Exception)
            {
            }
            string tmpToken = DbMain.BuildParameterName("ABC");
            if (tmpToken.Trim() != string.Empty)
            {
                ParameterToken = tmpToken.Trim().Substring(0, 1);
            }
            else
            {
                ParameterToken = string.Empty;
            }
            DbMain.WorkingMode = WorkingMode.LAN;
            Url = ConfigurationSettings.AppSettings["SERVERURL"].ToString();
            DataPath = ConfigurationSettings.AppSettings["DATAPATH"].ToString();
            if (DataPath != string.Empty && DataPath.Substring(0, 1) != "\\")
            {
                DataPath = PathName + DataPath + "\\";
            }
            UserInfo = new UserInfo();
            SystemVars = new SystemVars(this);
            WorkStationId = (int) SystemVars.GetSystemVars("WORKSTATION_ID");
            IsMultiSite = (bool) SystemVars.GetSystemVars("IS_MULTI_SITE");
            if (DbMain.WorkingMode == WorkingMode.WAN)
            {
                //this.OpenSystemCache();
            }
            IsChildSite = (bool) SystemVars.GetSystemVars("IS_CHILD_SITE");
            TableManager = new TableManager(this);
            IdManager = new IdManager(this);
            //this.CheckVersion();
            FieldManager = new FieldManager(this);
            FormManager = new FormManager(this);
            GridManager = new GridManager(this);
            MsgManager = new MsgManager(this);
            //this.ExceptionManager = new ExceptionManager(this);
            DEBUG = (bool) SystemVars.GetSystemVars("DEBUG");
            DayStartOfFirstYear = (DateTime) SystemVars.GetSystemVars("DAY_START_YEAR");
            TPSTVND = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT");
            TPSTNTE = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_ORIG");
            try
            {
                TPSTEXTRA = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_EXTRA");
            }
            catch (Exception)
            {
            }
            TPDGVND = (int) SystemVars.GetSystemVars("DECIMAL_PRICE");
            TPDGNTE = (int) SystemVars.GetSystemVars("DECIMAL_PRICE_ORIG");
            VNDCurrency = SystemVars.GetSystemVars("CURRENCY_ID_VND").ToString();
            MainCurrency = SystemVars.GetSystemVars("MAIN_CURRENCY").ToString();
            SecondCurrency = SystemVars.GetSystemVars("SECOND_CURRENCY").ToString();
            ReportMethod = SystemVars.GetSystemVars("REPORT_METHOD").ToString();
            mPoleDisplay = new PoleDisplay((string) SystemVars.GetSystemVars("PORT_POLE_DISPLAY"));
            string[] strbarcodelength = SystemVars.GetSystemVars("BARCODE_LENGTH").ToString().Split(',');
            mBarcodeLength = new Int16[strbarcodelength.Length];
            for (int length = 0; length < strbarcodelength.Length; length++)
            {
                try
                {
                    mBarcodeLength[length] = Convert.ToInt16(strbarcodelength[length]);
                }
                catch
                {
                    mBarcodeLength[length] = 4096;
                }
            }
            SecurityManager = new SecurityManager(this, true);
            ResourceManager = new ResourceManager(this, LanguageList);
            Sys_Lock = new Sys_Lock(this);
            CheckSerialKey();
            CheckSystem();
            try
            {
                IsMultiOrganization = (bool) SystemVars.GetSystemVars("IS_MULTI_ORGANIZATION");
            }
            catch (Exception)
            {
            }
            try
            {
                UseForeignCurrency = (bool) SystemVars.GetSystemVars("USE_FOREIGN_CURRENCY");
            }
            catch (Exception)
            {
            }
            if (IsMultiSite)
            {
                CommunicateManager = new CommunicateManager(this);
            }
            DbMain.SetConnectionString("Database=FTSWEBPOC;Server=(local);User ID=fts;Password=abcd1234;");

            DbMain.ExecuteNonQuery(
                DbMain.GetSqlStringCommand("UPDATE SYS_TRAN_NO SET TRAN_YEAR=" + DayStartOfCurrentYear.Year +
                                           " WHERE TRAN_YEAR=0"));
        }

        public void SetTableManager(TableManager tablemanager)
        {
            TableManager = tablemanager;
        }

        public void SetResourceManager(ResourceManager resourcemanager)
        {
            ResourceManager = resourcemanager;
        }

        public void SetFieldManager(FieldManager fieldmanager)
        {
            FieldManager = fieldmanager;
        }

        public void SetGridManager(GridManager gridmanager)
        {
            GridManager = gridmanager;
        }

        public void SetFormManager(FormManager formmanager)
        {
            FormManager = formmanager;
        }

        public void SetIdManager(IdManager idmanager)
        {
            IdManager = idmanager;
        }

        public void SetMsgManager(FTSMain ftsmain)
        {
            MsgManager.FTSMain = ftsmain;
        }

        public void SetSystemVar(SystemVars systemvars)
        {
            SystemVars = systemvars;
        }

        public void SetCommunicateManager(CommunicateManager communicatemanager)
        {
            CommunicateManager = communicatemanager;
        }

        private void CheckSystem()
        {
            if (FTSConstant.ProductVersion == "FTSACCSME2012")
            {
                return;
            }
            if (mMyVar)
            {
                string sql = "select max(tran_date) as tran_date_max, min(tran_date) as tran_date_min from " +
                             FTSConstant.TableCheck + " where tran_date >=" + Functions.ParseDate(DayStartOfFirstYear);
                DataTable dt = DbMain.LoadDataTable(DbMain.GetSqlStringCommand(sql), "tmp");
                if (dt.Rows.Count > 0 && dt.Rows[0]["tran_date_max"] != DBNull.Value)
                {
                    TimeSpan t2 = (DateTime) dt.Rows[0]["tran_date_max"] - (DateTime) dt.Rows[0]["tran_date_min"];
                    if (t2.Days > 150 && t2.Days <= FTSConstant.TrialDays)
                    {
                        throw (new FTSException("MSG_EXPIRED_SOON"));
                    }
                    if (t2.Days > FTSConstant.TrialDays)
                    {
                        throw (new FTSException("MSG_UNREGISTER"));
                    }
                }
            }
        }

        public void RunDB()
        {
            SystemVars = new SystemVars(this);
            FieldManager = new FieldManager(this);
            FormManager = new FormManager(this);
            GridManager = new GridManager(this);
            MsgManager = new MsgManager(this);
            ResourceManager = new ResourceManager(this, "VN");
            //this.ExceptionManager = new ExceptionManager(this);
            TableManager = new TableManager(this);
            IdManager = new IdManager(this);
            DEBUG = (bool) SystemVars.GetSystemVars("DEBUG");
            DayStartOfFirstYear = (DateTime) SystemVars.GetSystemVars("DAY_START_YEAR");
            TPSTVND = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT");
            TPSTNTE = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_ORIG");
            TPSTEXTRA = (int) SystemVars.GetSystemVars("DECIMAL_AMOUNT_EXTRA");
            TPDGVND = (int) SystemVars.GetSystemVars("DECIMAL_PRICE");
            TPDGNTE = (int) SystemVars.GetSystemVars("DECIMAL_PRICE_ORIG");
            VNDCurrency = SystemVars.GetSystemVars("CURRENCY_ID_VND").ToString();
            MainCurrency = SystemVars.GetSystemVars("MAIN_CURRENCY").ToString();
            SecondCurrency = SystemVars.GetSystemVars("SECOND_CURRENCY").ToString();
            ReportMethod = SystemVars.GetSystemVars("REPORT_METHOD").ToString();
            //this.LookAndFeel.LookAndFeel.SetSkinStyle(this.LookAndFeel.LookAndFeel.SkinName);
            mSecurityManager = new SecurityManager(this, true);
            Sys_Lock = new Sys_Lock(this);
            try
            {
                IsMultiOrganization = (bool) SystemVars.GetSystemVars("IS_MULTI_ORGANIZATION");
            }
            catch (Exception)
            {
            }
        }

        public void CheckVersion()
        {
            string dbver = SystemVars.GetSystemVars("VERSION").ToString().Trim();
            oldversion = dbver;
            var provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] {3};
            decimal thisver = Convert.ToDecimal(FTSConstant.Version, provider);
            decimal intver = Convert.ToDecimal(dbver, provider);
            if (thisver > intver)
            {
                if (File.Exists(PathName + "FTS.Update.dll"))
                {
                    Type type = Assembly.LoadFile(PathName + "FTS.Update.dll").GetType("FTS.Update.UpdateData");
                    var typeArray = new Type[1] {typeof (FTSMain)};
                    ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                    if (constructorInfoObj != null)
                    {
                        var objArg = new object[1] {this};
                        type.GetMethod("Update").Invoke(constructorInfoObj.Invoke(objArg), null);
                    }
                }
            }
            else
            {
                if (thisver < intver)
                {
                    throw new FTSException("MSG_INVALID_VERSION");
                }
            }
        }

        private void CheckSerialKey()
        {
            string serial = SystemVars.GetSystemVars("SERIAL_NUMBER").ToString().Trim();
            string macserial = RegManager.GetKey("SERIAL_NUMBER").Trim();
            ValidKey(serial, macserial);
        }

        public int ValidKey(string serial, string macserial)
        {
            if (FTSConstant.ProductVersion == "FTSACCSME2012")
            {
                DEMO = false;
                return 1;
            }
            else
            {
                if (serial.Length == 0)
                {
                    DEMO = true;
                    mMyVar = true;
                    return 1;
                }
                string abc = string.Empty;
                try
                {
                    abc = Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC();
                }
                catch (Exception)
                {
                }
                string check1 = Tools.Utilities.ValidKey(FTSConstant.KeyCodeMac + "_" + abc).ToUpper();
                if (check1 == macserial && abc != string.Empty)
                {
                    DEMO = false;
                    mMyVar = false;
                    return 2;
                }
                else
                {
                    string xx = SystemVars.GetSystemVars("COMPANY_NAME_SYS").ToString().Trim().ToUpper() + "_" +
                                SystemVars.GetSystemVars("TAX_FILE_NUMBER_SYS").ToString().Trim().ToUpper() + "_" +
                                SystemVars.GetSystemVars("MA_TK_HT").ToString().Trim().ToUpper();
                    xx = Tools.Utilities.ValidKey(xx.ToUpper()).ToUpper();
                    string check = Tools.Utilities.ValidKey(FTSConstant.KeyCode + "_" + xx).ToUpper();
                    if (check != serial)
                    {
                        DEMO = true;
                        mMyVar = true;
                        return 0;
                    }
                    else
                    {
                        DEMO = false;
                        mMyVar = false;
                        return 1;
                    }
                }
            }
        }

        private void RunScripts()
        {
            string sLine = string.Empty;
            string txtfile = "CleanData.txt";
            var arrText = new ArrayList();
            StreamReader objReader;
            if (Functions.FileExists(PathName + txtfile))
            {
                objReader = new StreamReader(PathName + txtfile);
                arrText.Add(string.Empty);
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        if (sLine.ToUpper().Trim() != "GO")
                        {
                            if (sLine.Trim().Length != 0)
                            {
                                arrText[arrText.Count - 1] = arrText[arrText.Count - 1] + " " + sLine;
                            }
                        }
                        else
                        {
                            arrText.Add(string.Empty);
                        }
                    }
                }
                objReader.Close();
            }
            foreach (string sOutput in arrText)
            {
                if (sOutput.Length != 0)
                {
                    DbCommand cmd = DbMain.GetSqlStringCommand(sOutput);
                    try
                    {
                        DbMain.ExecuteNonQuery(cmd);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void SetSME()
        {
            if (FTSConstant.ProductVersion == "FTSACCSME2012")
            {
                SystemVars.SetSystemVar("USE_FOREIGN_CURRENCY", false);
                SecondCurrency = MainCurrency;
                UseForeignCurrency = false;
            }
        }

        internal override void OpenTempConnection()
        {
            try
            {
                if (!Functions.FileExists(PathName + "AccTemp.xml"))
                {
                    Functions.FileCopy(PathName + "Reports\\AccTemp.xml", PathName + "AccTemp.xml");
                }
                if (!Functions.FileExists(PathName + "AccTemp.dst"))
                {
                    Functions.FileCopy(PathName + "Reports\\AccTemp.dst", PathName + "AccTemp.dst");
                }
                string path = PathName;
                mXmlQuery = new XmlQuery(PathName + "AccTemp.xml", PathName + "AccTemp.dst");
            }
            catch (Exception ex)
            {
                throw (new FTSException(ex.Message + ex.StackTrace));
            }
        }

        internal override void OpenSystemCache()
        {
            try
            {
                bool isnew = false;
                if (!Functions.FileExists(PathName + "SysCacheVista.vdb3"))
                {
                    isnew = true;
                    Functions.FileCopy(PathName + "TmpSysCacheVista.vdb3", PathName + "SysCacheVista.vdb3");
                }
                if (!Functions.FileExists(PathName + "SysCacheVista.vdc3"))
                {
                    isnew = true;
                    Functions.FileCopy(PathName + "TmpSysCacheVista.vdc3", PathName + "SysCacheVista.vdc3");
                }
                SysCacheVista = DatabaseFactory.CreateDatabase("SysCacheVista");
                SysCacheVista.ExecuteNonQuery(
                    SysCacheVista.GetSqlStringCommand("ALTER TABLE SYS_SYSTEMVAR ALTER COLUMN VAR_VALUE NVARCHAR(300)"));
                if (isnew)
                {
                    Functions.LoadAllDataToCacheVista(this, LanguageList);
                }
                else
                {
                    string sql = "select VAR_VALUE from SYS_SYSTEMVAR where VAR_NAME='CACHE_VERSION'";
                    object result = SysCacheVista.ExecuteScalar(SysCacheVista.GetSqlStringCommand(sql));
                    if ((result != null) && (result != DBNull.Value) &&
                        (result.ToString() != SystemVars.GetSystemVars("CACHE_VERSION").ToString()))
                        Functions.LoadAllDataToCacheVista(this, LanguageList);
                }
            }
            catch (Exception ex)
            {
                throw (new FTSException("Failed to openning cache data. Please check to make sure the file exists!"));
            }
        }

        public void LogError(string msg)
        {
            try
            {
                // tao hoac tinh bien fileName
                string fileName = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
                // tao file de ghi loi
                fileName = PathName + "Exceptions\\" + fileName;
                if (Functions.FileExists(fileName))
                {
                    var fileinfo = new FileInfo(fileName);
                    if (fileinfo.Length > 2000000)
                    {
                        Functions.FileDelete(fileName);
                    }
                }

                var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                var m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // ghi ngay thang
                m_streamWriter.WriteLine(string.Empty);
                m_streamWriter.WriteLine("{0} {1}", DateTime.Today.ToLongTimeString(), DateTime.Today.ToLongDateString());
                // ghi Message
                m_streamWriter.WriteLine(msg);
                m_streamWriter.Flush();
                fs.Close();
                //
            }
            catch (Exception)
            {
            }
        }

        public void LogServerError(string msg)
        {
            // tao hoac tinh bien fileName
            //string fileName = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
            // tao file de ghi loi
            //fileName =  @"c:\\Exceptions\\32014.txt";
            string fileName = Path.Combine(@"c:\\Exceptions\\", Path.GetFileName("32014.txt"));
            if (Functions.FileExists(fileName))
            {
                var fileinfo = new FileInfo(fileName);
                if (fileinfo.Length > 2000000)
                {
                    Functions.FileDelete(fileName);
                }
                var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                var m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // ghi ngay thang
                m_streamWriter.WriteLine(string.Empty);
                m_streamWriter.WriteLine("{0} {1}", DateTime.Today.ToLongTimeString(), DateTime.Today.ToLongDateString());
                // ghi Message
                m_streamWriter.WriteLine(msg);
                m_streamWriter.Flush();
                fs.Close();
            }
            //
        }
    }
}