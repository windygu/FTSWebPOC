#region

using System;
using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.Global.Classes;
using System.Data.Common;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Data_Log : ObjectBase {
        private Int32 mWorkstation_Id = -1;

        public Data_Log(FTSMain ftsmain) : base(ftsmain, "DATA_LOG") {
            try {
                this.mWorkstation_Id = -1;
                this.LoadData();
                this.LoadFields();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
        public Data_Log(FTSMain ftsmain, Int32 workstationid): base(ftsmain, "DATA_LOG")
        {
            try
            {
                this.mWorkstation_Id = workstationid;
                this.LoadData();
                this.LoadFields();
            }
            catch (FTSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw (new FTSException(ex));
            }
        }
        public override void LoadFields() {
            try {
                this.FieldCollection = new List<FieldInfo>();
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY",
                                                                                   DbType.Decimal, true));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_UPLOAD",
                                                                                   DbType.Boolean, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_DOWNLOAD",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LOG_TIME",
                                                                                   DbType.Date, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "OBJECT_VALUE",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LOG_TIME",
                                                                                   DbType.DateTime, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "KEY_VALUE",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DATA_ACTION",
                                                                                   DbType.String, false));
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
        public override void LoadData()
        {
            if (this.mWorkstation_Id > 0)
                this.Condittion = "substring(IS_DOWNLOAD," + this.mWorkstation_Id.ToString() + ",1) = '0'";
            base.LoadData();
        }
        public static void InsertDataLog(FTSMain ftsmain, string tablename, object objectvalue)
        {
            string sql = "insert DATA_LOG(TABLE_NAME,LOG_TIME,OBJECT_VALUE,IS_UPLOAD,USER_ID,IS_DOWNLOAD) values (" +
                ftsmain.BuildParameterName("TABLE_NAME") + "," + ftsmain.BuildParameterName("LOG_TIME") + "," + ftsmain.BuildParameterName("OBJECT_VALUE") + "," +
                ftsmain.BuildParameterName("IS_UPLOAD") + "," + ftsmain.BuildParameterName("USER_ID") + "," + ftsmain.BuildParameterName("IS_DOWNLOAD") + ")";
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sql);
            ftsmain.DbMain.AddInParameter(cmd, "TABLE_NAME", DbType.String, tablename);
            ftsmain.DbMain.AddInParameter(cmd, "LOG_TIME", DbType.Date, DateTime.Now);
            ftsmain.DbMain.AddInParameter(cmd, "OBJECT_VALUE", DbType.String, Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(objectvalue)));
            ftsmain.DbMain.AddInParameter(cmd, "IS_UPLOAD", DbType.Int16, 0);
            ftsmain.DbMain.AddInParameter(cmd, "USER_ID", DbType.String, ftsmain.UserInfo.UserID);
            string is_download = string.Empty;
            if (ftsmain.IsChildSite)
            {
                is_download = string.Empty;
            }
            else
            {
                string mark = string.Empty;
                int number = System.Convert.ToInt32(ftsmain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                for (int i = 0; i < number; i++)
                {
                    if (ftsmain.CommunicateManager.IsPulic(tablename))
                    {
                        mark = mark + "0";
                    }
                    else
                    {
                        /*
                        if (i != ftsmain.WorkStationId - 1)
                            mark = mark + "1";
                        else
                            mark = mark + "0";
                        */
                        mark = mark + "1";
                    }
                }
                is_download = mark;
            }
            ftsmain.DbMain.AddInParameter(cmd, "IS_DOWNLOAD", DbType.String, is_download);
            ftsmain.DbMain.ExecuteNonQuery(cmd);
        }
        public static void InsertDataLog(FTSMain ftsmain, string tablename, object objectvalue, DbTransaction tran)
        {
            string sql = "insert DATA_LOG(TABLE_NAME,LOG_TIME,OBJECT_VALUE,IS_UPLOAD,USER_ID,IS_DOWNLOAD) values (" +
                ftsmain.BuildParameterName("TABLE_NAME") + "," + ftsmain.BuildParameterName("LOG_TIME") + "," + ftsmain.BuildParameterName("OBJECT_VALUE") + "," +
                ftsmain.BuildParameterName("IS_UPLOAD") + "," + ftsmain.BuildParameterName("USER_ID") + "," + ftsmain.BuildParameterName("IS_DOWNLOAD") + ")";
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sql);
            ftsmain.DbMain.AddInParameter(cmd, "TABLE_NAME", DbType.String, tablename);
            ftsmain.DbMain.AddInParameter(cmd, "LOG_TIME", DbType.Date, DateTime.Now);
            ftsmain.DbMain.AddInParameter(cmd, "OBJECT_VALUE", DbType.String, Global.Utilities.Functions.Zip(Global.Utilities.Functions.ToXml(objectvalue)));
            ftsmain.DbMain.AddInParameter(cmd, "IS_UPLOAD", DbType.Int16, 0);
            ftsmain.DbMain.AddInParameter(cmd, "USER_ID", DbType.String, ftsmain.UserInfo.UserID);
            string is_download = string.Empty;
            if (ftsmain.IsChildSite)
            {
                is_download = string.Empty;
            }
            else
            {
                string mark = string.Empty;
                int number = System.Convert.ToInt32(ftsmain.SystemVars.GetSystemVars("NUMBER_WORKSTATION"));
                for (int i = 0; i < number; i++)
                {
                    if (ftsmain.CommunicateManager.IsPulic(tablename))
                    {
                        mark = mark + "0";
                    }
                    else
                    {
                        /*
                        if (i != ftsmain.WorkStationId - 1)
                            mark = mark + "1";
                        else
                            mark = mark + "0";
                        */
                        mark = mark + "1";
                    }
                }
                is_download = mark;
            }
            ftsmain.DbMain.AddInParameter(cmd, "IS_DOWNLOAD", DbType.String, is_download);
            ftsmain.DbMain.ExecuteNonQuery(cmd, tran);
        }
    }
}