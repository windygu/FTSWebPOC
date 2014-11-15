// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:54
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         ExceptionManager.cs
// Project Item Filename:     ExceptionManager.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Utilities {
    public class ExceptionManager {
        
        public static string GetMessage(FTSMain mFTSMain, FTSException ex) {
            if (ex.ExceptionID.Length == 0) {
                if (ex.SystemException == null) {
                    return string.Empty;
                } else {
                    return ex.SystemException.Message + ex.ExtraInformation;
                }
            } else {
                if (!String.IsNullOrEmpty(ex.TableName) && !String.IsNullOrEmpty(ex.FieldName)) {
                    return mFTSMain.ResourceManager.GetValue("ERR_" + ex.ExceptionID, ex.ExceptionID) + ex.ExtraInformation + ": " +
                           mFTSMain.ResourceManager.GetValue("TBL_" + ex.TableName, ex.TableName) + " - " +
                           ex.FieldName;
                } else {
                    return mFTSMain.ResourceManager.GetValue("ERR_" + ex.ExceptionID, ex.ExceptionID) + ex.ExtraInformation;
                }
            }
        }

        public static string GetMessage(FTSMain mFTSMain, Exception ex) {
            return ex.Message;
        }

        public static void ProcessException(FTSMain mFTSMain, FTSException e) {
            string msg = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(mFTSMain, e);
            msg = Functions.InsertPara(msg, e.Parameter);
            if (mFTSMain.DEBUG){
                if (e.SystemException != null){
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(msg + "; " + e.SystemException.Message + "; " +
                                                   e.SystemException.Source + "; " + e.SystemException.StackTrace);
                } else{
                    if (msg.Length != 0){
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(msg);
                    }
                }
                ExceptionManager.LogError(mFTSMain,e);
            } else{
                if (e.SystemException != null){
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(msg);
                } else{
                    if (msg.Length != 0){
                        FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(msg);
                    }
                }
                ExceptionManager.LogError(mFTSMain, e);
            }
        }

        public static void ProcessException(FTSMain mFTSMain, Exception e) {
            if (mFTSMain.DEBUG) {
                if (e.GetType().Equals(typeof (FTSException))) {
                    ExceptionManager.ProcessException(mFTSMain, (FTSException)e);
                } else {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(e.Message + "; " + e.Source + "; " + e.StackTrace);
                    ExceptionManager.LogError(mFTSMain, new FTSException(e));
                }
            } else {
                if (e.GetType().Equals(typeof (FTSException))) {
                    ExceptionManager.ProcessException(mFTSMain, (FTSException)e);
                } else {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(e.Message);
                    ExceptionManager.LogError(mFTSMain, new FTSException(e));
                }
            }
        }

        public static void ProcessMessage(FTSMain mFTSMain) {
            foreach (string msg in mFTSMain.MessageList) {
                FTS.BaseUI.Utilities.FTSMessageBox.ShowInfoMessage(msg);
            }
            mFTSMain.MessageList.Clear();
        }

        public static void BackgroundProcessException(FTSMain mFTSMain, Exception e) {
            if (mFTSMain.DEBUG) {
                if (e.GetType().Equals(typeof (FTSException))) {
                    ExceptionManager.LogError(mFTSMain, (FTSException)e);
                } else {
                    ExceptionManager.LogError(mFTSMain, new FTSException(e));
                }
            } else {
                if (e.GetType().Equals(typeof (FTSException))) {
                    ExceptionManager.LogError(mFTSMain, (FTSException)e);
                } else {
                    ExceptionManager.LogError(mFTSMain, new FTSException(e));
                }
            }
        }

        public static string ShowException(FTSMain mFTSMain, Exception e) {
            if (mFTSMain.DEBUG) {
                if (e.GetType().Equals(typeof (FTSException))) {
                    return ExceptionManager.ShowException(mFTSMain, (FTSException)e);
                } else {
                    return e.Message + "; " + e.Source + "; " + e.StackTrace;
                    /*
                    this.LogError(new FTSException(e));
                    */ 
                }
            } else {
                if (e.GetType().Equals(typeof (FTSException))) {
                    return ExceptionManager.ShowException(mFTSMain, (FTSException)e);
                } else {
                    return e.Message;
                    /*
                    this.LogError(new FTSException(e));
                    */ 
                }
            }
        }

        public static string ShowException(FTSMain mFTSMain, FTSException e) {
            string msg = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(mFTSMain, e);
            if (!string.IsNullOrEmpty(e.FieldName)) {
                msg = msg + " - " + e.FieldName;
            }
            msg = Functions.InsertPara(msg, e.Parameter);
            if (mFTSMain.DEBUG) {
                if (e.SystemException != null) {
                    return msg + "; " + e.SystemException.Message + "; " + e.SystemException.Source + "; " +
                           e.SystemException.StackTrace;
                } else {
                    if (msg.Length != 0) {
                        return msg;
                    }
                    return string.Empty;
                }
                /*
                this.LogError(e);
                */ 
            } else {
                if (msg.Length != 0) {
                    return msg;
                } else {
                    return string.Empty;
                }
            }
        }

        private static void LogError(FTSMain mFTSMain, FTSException ex) {
            try {
                // tao hoac tinh bien fileName
                string fileName = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
                // tao file de ghi loi
                fileName = mFTSMain.PathName + "Exceptions\\" + fileName;
                if (Functions.FileExists(fileName)) {
                    FileInfo fileinfo = new FileInfo(fileName);
                    if (fileinfo.Length > 2000000) {
                        Functions.FileDelete(fileName);
                    }
                }

                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // ghi ngay thang
                m_streamWriter.WriteLine(string.Empty);
                m_streamWriter.WriteLine("{0} {1}", DateTime.Today.ToLongTimeString(), DateTime.Today.ToLongDateString());
                // ghi Message
                string msg = FTS.BaseUI.Utilities.ExceptionManager.GetMessage(mFTSMain, ex);
                if (ex.SystemException != null) {
                    m_streamWriter.WriteLine(msg);
                    // ghi Source
                    m_streamWriter.WriteLine(ex.SystemException.Source);
                    // ghi StackTrace
                    m_streamWriter.WriteLine(ex.SystemException.StackTrace);
                    if (ex.TableName != string.Empty) {
                        m_streamWriter.WriteLine(ex.TableName);
                    }
                    if (ex.FieldName != string.Empty) {
                        m_streamWriter.WriteLine(ex.FieldName);
                    }
                } else {
                    m_streamWriter.WriteLine(msg);
                    if (ex.TableName != string.Empty) {
                        m_streamWriter.WriteLine(ex.TableName);
                    }
                    if (ex.FieldName != string.Empty) {
                        m_streamWriter.WriteLine(ex.FieldName);
                    }
                }
                m_streamWriter.Flush();
                fs.Close();
                //
            }catch(Exception){}
        }

        public static void LogError(FTSMain mFTSMain,string msg) {
            try {
                // tao hoac tinh bien fileName
                string fileName = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
                // tao file de ghi loi
                fileName = mFTSMain.PathName + "Exceptions\\" + fileName;
                if (Functions.FileExists(fileName)) {
                    FileInfo fileinfo = new FileInfo(fileName);
                    if (fileinfo.Length > 2000000) {
                        Functions.FileDelete(fileName);
                    }
                }

                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // ghi ngay thang
                m_streamWriter.WriteLine(string.Empty);
                m_streamWriter.WriteLine("{0} {1}", DateTime.Today.ToLongTimeString(), DateTime.Today.ToLongDateString());
                // ghi Message
                m_streamWriter.WriteLine(msg);
                m_streamWriter.Flush();
                fs.Close();
                //
            }catch(Exception){}
        }

        public static void HandlingDbException(Exception ex, DataTable datatable, string tablename, string idfield) {
            int errorcode = 0;
            if (ex is DBConcurrencyException) {
                throw (new FTSException(ex, "CONCURRENCY_EXCEPTION", tablename, string.Empty, -1));
            }
            if (ex is SqlException) {
                errorcode = ((SqlException) ex).Number;
            }
            switch (errorcode) {
                case 50000:
                    int pos = ex.Message.IndexOf("\r");
                    if (pos >= 0) {
                        throw (new FTSException(ex, ex.Message.Substring(0, pos), tablename, idfield, -1));
                    } else {
                        throw (new FTSException(ex, ex.Message, tablename, idfield, -1));
                    }
                case 2627:
                case 2601:
                    for (int j = 0; j < datatable.Rows.Count; j++) {
                        if (datatable.Rows[j].HasErrors && datatable.Rows[j].RowError.IndexOf(ex.Message) >= 0) {
                            throw (new FTSException(ex, "DUPLICATE_PRIMARY_KEY", tablename, idfield, j));
                        }
                    }
                    throw (new FTSException(ex, "DUPLICATE_PRIMARY_KEY", tablename, idfield, -1));
                case 547:
                    string exceptionid;
                    string fieldname = string.Empty;
                    if (ex.Message.IndexOf("INSERT", 0) >= 0) {
                        exceptionid = "FOREIGN_KEY_INSERT";
                    } else {
                        exceptionid = "FOREIGN_KEY_DELETE";
                    }
                    int startidx = ex.Message.IndexOf("column '", 0);
                    if (startidx >= 0) {
                        int endidx = ex.Message.IndexOf("'", startidx + 8);
                        if (endidx >= 0 && endidx >= startidx + 8) {
                            fieldname = ex.Message.Substring(startidx + 8, endidx - startidx - 8);
                        }
                    }
                    if (exceptionid == "FOREIGN_KEY_INSERT") {
                        for (int j = 0; j < datatable.Rows.Count; j++) {
                            if (datatable.Rows[j].HasErrors && datatable.Rows[j].RowError.IndexOf(ex.Message) >= 0) {
                                throw (new FTSException(ex, exceptionid, tablename, fieldname, j));
                            }
                        }
                    }
                    throw (new FTSException(ex, exceptionid, tablename, fieldname, -1));
                default:
                    break;
            }
            for (int j = 0; j < datatable.Rows.Count; j++) {
                if (datatable.Rows[j].HasErrors) {
                    throw (new FTSException(ex, ex.Message, tablename, string.Empty, j));
                }
            }
        }
    }
}