using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Hosting;
using System.Web.Services;
using System.Web.Services.Protocols;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.Global;
using FTS.Global.Classes;
using FTS.Global.Utilities;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : WebService{
    public CredentialSoapHeader Credentials;
    private static Database mDbMain;
    private static TableManager mTableManager;
    private static ResourceManager mResourceManager;
    private static FieldManager mFieldManager;
    //private static GridManager mGridManager;
    //private static FormManager mFormManager;
    private static SystemVars mSystemVars;
    private static IdManager mIdManager;
    private static CommunicateManager mCommunicateManager;
    private static readonly ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private static DataTable dmpostingview;
    static Service()
    {
        mDbMain = FTSMainBase.CreateDatabasePfs();
        mDbMain.WorkingMode = WorkingMode.LAN;
        mTableManager = new TableManager(mDbMain);
        mResourceManager = new ResourceManager(mDbMain, "VN","VN",true);
        mFieldManager = new FieldManager(mDbMain);
        //mGridManager = new GridManager(mDbMain);
        //mFormManager = new FormManager(mDbMain);
        mSystemVars = new SystemVars(mDbMain);
        mIdManager = new IdManager(mDbMain);
        mCommunicateManager = new CommunicateManager(mDbMain);
        //dmpostingview = mDbMain.LoadDataTable(mDbMain.GetSqlStringCommand("SELECT DAY_START,DAY_END,ITEM_SOURCE_ID,ITEM_OP_ID,ITEM_CLASS_ID,ITEM_ID,PR_DETAIL_CLASS_ID,WAREHOUSE_CLASS_ID,ISSUE_RECEIVE,NOT_ITEM_ID,ACCOUNT_ID_DEBIT,ACCOUNT_ID_CREDIT,POSTING_FORMULA,PR_DETAIL_ID,JOB_ID,EXPENSE_ID,IS_VAT,IS_WAREHOUSE FROM DM_POSTING_VIEW WHERE ACTIVE=1"),"DM_POSTING_VIEW");
        //foreach (DataRow row in dmpostingview.Rows) {
        //    row["ITEM_SOURCE_ID"] = "," + row["ITEM_SOURCE_ID"].ToString().Trim() + ",";
        //    row["ITEM_OP_ID"] = "," + row["ITEM_OP_ID"].ToString().Trim() + ",";
        //    row["ITEM_CLASS_ID"] = "," + row["ITEM_CLASS_ID"].ToString().Trim() + ",";
        //    row["ITEM_ID"] = "," + row["ITEM_ID"].ToString().Trim() + ",";
        //    row["PR_DETAIL_CLASS_ID"] = "," + row["PR_DETAIL_CLASS_ID"].ToString().Trim() + ",";
        //    row["WAREHOUSE_CLASS_ID"] = "," + row["WAREHOUSE_CLASS_ID"].ToString().Trim() + ",";
        //}
        //dmpostingview.AcceptChanges();
    }
    public Service(){        
    }
    private bool CheckCredential(CredentialSoapHeader header)
    {
        try
        {
            if (header.UserName == "NT" && header.PassWord == "cntt")
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    [WebMethod]
    [SoapHeader("Credentials")]
    public bool Ready()
    {
        try
        {
            if (!this.CheckCredential(Credentials))
            {
                throw new SoapException("Invalid credential supplied", SoapException.ClientFaultCode, "Security");
            }
            DbConnection connection = mDbMain.CreateConnection();
            connection.Open();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            return false;
        }
    }
    [WebMethod]
    [SoapHeader("Credentials")]
    public byte[] GetReports(byte[] arrFtsMain, byte[] arrFtsReport)
    {
        try
        {
            //if (!this.CheckCredential(Credentials))
            //{
            //    throw new SoapException("Invalid credential supplied", SoapException.ClientFaultCode, "Security");
            //}
            //FTSMain ftsMain = null;
            //using (MemoryStream stream = new MemoryStream(FTS.BaseBusiness.Utilities.Functions.DecompressByte(arrFtsMain)))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    ftsMain = (FTSMain)formatter.Deserialize(stream);
            //}
            //ftsMain.AtPfs = true;
            //ftsMain.SetDatabase(mDbMain);
            //mTableManager.FTSMain = ftsMain;
            //ftsMain.SetTableManager(mTableManager);
            //mResourceManager.FTSMain = ftsMain;
            //ftsMain.SetResourceManager(mResourceManager);
            //mFieldManager.FTSMain = ftsMain;
            //ftsMain.SetFieldManager(mFieldManager);
            ////mGridManager.FTSMain = ftsMain;
            ////ftsMain.SetGridManager(mGridManager);
            ////mFormManager.FTSMain = ftsMain;
            ////ftsMain.SetFormManager(mFormManager);
            //mIdManager.FTSMain = ftsMain;
            //ftsMain.SetIdManager(mIdManager);
            //ftsMain.SetMsgManager(ftsMain);
            //mSystemVars.FTSMain = ftsMain;
            //ftsMain.SetSystemVar(mSystemVars);
            //ftsMain.SecurityManager = new SecurityManager(ftsMain,false);
            //FTSReport ftsReport = null;
            //using (MemoryStream stream = new MemoryStream(FTS.BaseBusiness.Utilities.Functions.DecompressByte(arrFtsReport)))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    ftsReport = (FTSReport)formatter.Deserialize(stream);
            //}
            //ftsReport.FTSMain = ftsMain;
            //ftsReport.sys_reportfield = new Sys_ReportField(ftsMain, ftsReport.Report_ID);
            //ftsReport.sys_reportfieldgrid = new Sys_ReportField(ftsMain, ftsReport.Report_ID);
            //ftsReport.sys_reportfieldgrid.LoadVisibleData();
            //ftsReport.Sys_Report_Config = new Sys_Report_Config(ftsMain, ftsReport.Report_ID);
            //ftsReport.CalculateReport();     
            //ftsReport.DataSet.RemotingFormat = SerializationFormat.Binary;       

            //MemoryStream objMS = new MemoryStream();
            //BinaryFormatter objBF = new BinaryFormatter();
            //objBF.Serialize(objMS, ftsReport);
            //objMS.Flush();
            //objMS.Position = 0;
            //long len = objMS.Length;
            //byte[] arrFtsReportResult = new byte[len];
            //objMS.Read(arrFtsReportResult, 0, (int)len);

            //return FTS.BaseBusiness.Utilities.Functions.CompressByte(arrFtsReportResult);
            return null;
        }
        catch (SoapException ex)
        {
            log.Error(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            throw;            
        }
    }
    [WebMethod]
    [SoapHeader("Credentials")]
    public byte[] UpdateManagerBase(byte[] arrFtsMain, byte[] arrManagerBase)
    {
        try
        {
            if (!this.CheckCredential(Credentials))
            {
                throw new SoapException("Invalid credential supplied", SoapException.ClientFaultCode, "Security");
            }
            FTSMain ftsMain = null;
            using (MemoryStream stream = new MemoryStream(FTS.BaseBusiness.Utilities.Functions.DecompressByte(arrFtsMain)))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ftsMain = (FTSMain)formatter.Deserialize(stream);
                ftsMain.ServicePathName = HostingEnvironment.ApplicationPhysicalPath;
            }
            ftsMain.AtPfs = true;
            ftsMain.SetDatabase(mDbMain);
            mTableManager.FTSMain = ftsMain;
            ftsMain.SetTableManager(mTableManager);
            mResourceManager.FTSMain = ftsMain;
            ftsMain.SetResourceManager(mResourceManager);
            mFieldManager.FTSMain = ftsMain;
            ftsMain.SetFieldManager(mFieldManager);
            //mGridManager.FTSMain = ftsMain;
            //ftsMain.SetGridManager(mGridManager);
            //mFormManager.FTSMain = ftsMain;
            //ftsMain.SetFormManager(mFormManager);
            mIdManager.FTSMain = ftsMain;
            ftsMain.SetIdManager(mIdManager);
            ftsMain.SetMsgManager(ftsMain);
            mSystemVars.FTSMain = ftsMain;
            ftsMain.SetSystemVar(mSystemVars);
            ftsMain.SecurityManager = new SecurityManager(ftsMain,false);
            //ftsMain.ExceptionManager = new FTS.Base.Systems.ExceptionManager(ftsMain);
            ftsMain.Sys_Lock.FTSMain = ftsMain;
            mCommunicateManager.FTSMain = ftsMain;
            ftsMain.SetCommunicateManager(mCommunicateManager);
            ManagerBase managerBase = null;
            using (MemoryStream stream = new MemoryStream(FTS.BaseBusiness.Utilities.Functions.DecompressByte(arrManagerBase)))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                managerBase = (ManagerBase)formatter.Deserialize(stream);
            }
            foreach (ObjectBase ob in managerBase.ObjectList)
            {
                ob.FTSMain = ftsMain;
                ob.DataSet = managerBase.DataSet;
                ob.DataTable = ob.DataSet.Tables[ob.TableName];
            }
            managerBase.FTSMain = ftsMain;
            try
            {
                managerBase.UpdateDataOnServer();
            }
            catch (FTSException ex)
            {
                MemoryStream objMS = new MemoryStream();
                BinaryFormatter objBF = new BinaryFormatter();
                objBF.Serialize(objMS, ex);
                objMS.Flush();
                objMS.Position = 0;
                long len = objMS.Length;
                byte[] arrFtsException = new byte[len];
                objMS.Read(arrFtsException, 0, (int)len);
                return FTS.BaseBusiness.Utilities.Functions.CompressByte(arrFtsException);
            } catch (Exception ex) {
                MemoryStream objMS = new MemoryStream();
                BinaryFormatter objBF = new BinaryFormatter();
                objBF.Serialize(objMS, ex);
                objMS.Flush();
                objMS.Position = 0;
                long len = objMS.Length;
                byte[] arrFtsException = new byte[len];
                objMS.Read(arrFtsException, 0, (int)len);
                return FTS.BaseBusiness.Utilities.Functions.CompressByte(arrFtsException);
            }
            if (managerBase.ObjectList[0].IsValidRow(0)) {
                List<string> list = new List<string>();
                if (managerBase.ObjectList[0].DataTable.Columns.IndexOf("REFERENCE_NO") >= 0) {
                    list.Add(managerBase.ObjectList[0].DataTable.Rows[0][managerBase.TranNoField].ToString());
                    list.Add(managerBase.ObjectList[0].DataTable.Rows[0]["REFERENCE_NO"].ToString());
                } else {
                    list.Add(managerBase.ObjectList[0].DataTable.Rows[0][managerBase.TranNoField].ToString());
                    list.Add(string.Empty);
                }
                foreach (string msg in ftsMain.MessageList) {
                    list.Add(msg);
                }
                ftsMain.MessageList.Clear();
                MemoryStream objMS = new MemoryStream();
                BinaryFormatter objBF = new BinaryFormatter();
                objBF.Serialize(objMS, list);
                objMS.Flush();
                objMS.Position = 0;
                long len = objMS.Length;
                byte[] arrFtsException = new byte[len];
                objMS.Read(arrFtsException, 0, (int)len);
                return FTS.BaseBusiness.Utilities.Functions.CompressByte(arrFtsException);
            }else {
                if (ftsMain.MessageList.Count > 0) {
                    List<string> list = new List<string>();
                        list.Add(string.Empty);
                        list.Add(string.Empty);
                    foreach (string msg in ftsMain.MessageList) {
                        list.Add(msg);
                    }
                    ftsMain.MessageList.Clear();
                    MemoryStream objMS = new MemoryStream();
                    BinaryFormatter objBF = new BinaryFormatter();
                    objBF.Serialize(objMS, list);
                    objMS.Flush();
                    objMS.Position = 0;
                    long len = objMS.Length;
                    byte[] arrFtsException = new byte[len];
                    objMS.Read(arrFtsException, 0, (int) len);
                    return FTS.BaseBusiness.Utilities.Functions.CompressByte(arrFtsException);
                }
            }
            return null;
        }
        catch (SoapException ex)
        {
            log.Error(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            throw;
        }
    }
}