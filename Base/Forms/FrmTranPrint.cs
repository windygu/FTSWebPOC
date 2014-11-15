#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Business;
using FTS.BaseUI.Business;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Utilities;

#endregion

namespace FTS.BaseUI.Forms
{
    public partial class FrmTranPrint : FrmBaseForm
    {
        private ManagerBase managerBase;
        private ObjectBase objectBase;
        private string tranId = string.Empty;
        private bool mNoTranId = false;
        private Hashtable mReportFileTable = new Hashtable();  

        public FrmTranPrint()
        {
            this.InitializeComponent();
        }

        public FrmTranPrint(FTSMain ftsmain, ManagerBase mb)
            : base(ftsmain, true)
        {
            this.mNoTranId = false;
            this.ManagerBase = mb;
            this.InitializeComponent();
            this.InputOutputList();
            this.LoadOutputList();
        }

        public FrmTranPrint(FTSMain ftsmain, ManagerBase mb, bool notranid)
            : base(ftsmain, true)
        {
            this.mNoTranId = notranid;
            this.ManagerBase = mb;
            this.InitializeComponent();
            //this.InputOutputList();
            this.LoadOutputList();
        }

        public FrmTranPrint(FTSMain ftsmain, ObjectBase ob, string tranid)
            : base(ftsmain, true)
        {
            this.mNoTranId = false;
            this.objectBase = ob;
            this.tranId = tranid;
            this.InitializeComponent();
            //this.InputOutputList();
            this.LoadOutputList();
        }

        public FrmTranPrint(FTSMain ftsmain, ObjectBase ob, string tranid, bool notranid)
            : base(ftsmain, true)
        {
            this.mNoTranId = notranid;
            this.objectBase = ob;
            this.tranId = tranid;
            this.InitializeComponent();
            //this.InputOutputList();
            this.LoadOutputList();
        }

        public ManagerBase ManagerBase
        {
            get { return this.managerBase; }
            set { this.managerBase = value; }
        }

        public ObjectBase ObjectBase
        {
            get { return this.objectBase; }
            set { this.objectBase = value; }
        }

        public string TranId
        {
            get { return this.tranId; }
            set { this.tranId = value; }
        }
        private void InputOutputList()
        {
            string sql = string.Empty;
            if(this.mNoTranId)
                sql = "select * from SYS_TRAN_OUTPUT_NO_TRAN where active=1";
            else
                sql = "select * from SYS_TRAN_OUTPUT where active=1";
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            if(this.managerBase!=null)
                this.FTSMain.DbMain.AddInParameter(cmd, "TRAN_ID", DbType.String, this.ManagerBase.TranId);
            else
                this.FTSMain.DbMain.AddInParameter(cmd, "TRAN_ID", DbType.String, this.tranId);
            DataTable dt = this.FTSMain.DbMain.LoadDataTable(cmd, "SYS_TRAN_OUTPUT");
        }

        private void LoadOutputList()
        {
            this.listReport.Items.Clear();
            DataTable dmorganization = null;
            if (this.managerBase != null) {
                dmorganization = this.managerBase.GetDm("DM_ORGANIZATION");
            }

            if (dmorganization == null || dmorganization.Columns.IndexOf("ORGANIZATION_TYPE") < 0) {
                dmorganization = this.FTSMain.TableManager.LoadTable("DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE", "ACTIVE=1");
            }

            string parentorganizationid = Dm_Organization.GetIndependantParentOrganization(dmorganization, this.FTSMain.UserInfo.OrganizationID);

            string sql = string.Empty;
            if(this.mNoTranId)
                sql = "select PR_KEY,OUTPUT_NAME,IS_COPY from SYS_TRAN_OUTPUT_NO_TRAN where tran_id=" + this.FTSMain.BuildParameterName("tran_id") +
                         " and (ORGANIZATION_ID='' OR ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID + "' OR ORGANIZATION_ID='" + parentorganizationid + "') and active=1 ORDER BY PR_KEY";
            else
                sql = "select PR_KEY,OUTPUT_NAME,IS_COPY from SYS_TRAN_OUTPUT where tran_id=" + this.FTSMain.BuildParameterName("tran_id") +
                         " and (ORGANIZATION_ID='' OR ORGANIZATION_ID='" + this.FTSMain.UserInfo.OrganizationID + "' OR ORGANIZATION_ID='" + parentorganizationid + "') and active=1 ORDER BY PR_KEY";
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            if(this.managerBase!=null)
                this.FTSMain.DbMain.AddInParameter(cmd, "TRAN_ID", DbType.String, this.ManagerBase.TranId);
            else
                this.FTSMain.DbMain.AddInParameter(cmd, "TRAN_ID", DbType.String, this.tranId);
            DataTable dt = this.FTSMain.DbMain.LoadDataTable(cmd, "SYS_TRAN_OUTPUT");
            foreach (DataRow row in dt.Rows)
            {
                TransactionOutputObject oo = new TransactionOutputObject((decimal)row["pr_key"],
                                                                         row["output_name"].ToString(),
                                                                         (Int16)row["is_copy"]);
                this.listReport.Items.Add(oo);
            }
            if (this.listReport.Items.Count > 0)
            {
                this.listReport.SelectedIndex = 0;
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionOutputObject oo = this.listReport.SelectedItem as TransactionOutputObject;
                if (oo != null)
                {
                    FrmGetString frmgetstring =
                        new FrmGetString(this.FTSMain.MsgManager.GetMessage("MSG_TRAN_OUTPUT_TITLE"),
                                         this.FTSMain.MsgManager.GetMessage("MSG_TRAN_OUTPUT"));
                    if (frmgetstring.ShowDialog() == DialogResult.Yes)
                    {
                        decimal pr_key = 0;
                        if(this.mNoTranId)
                            pr_key = FunctionsBase.GetPr_key("SYS_TRAN_OUTPUT_NO_TRAN", this.FTSMain);
                        else
                            pr_key = FunctionsBase.GetPr_key("SYS_TRAN_OUTPUT", this.FTSMain);
                        string reportfilename = this.GetFile(oo.Pr_Key);
                        FileStream fs = File.OpenRead(reportfilename);
                        try
                        {
                            byte[] bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            string sql = string.Empty;
                            if(this.mNoTranId)
                                sql =
                                "insert into sys_tran_output_no_tran(pr_key,tran_id, output_name,report_file_data,is_copy,active,report_file_name,organization_id,user_id) " +
                                " values(" + this.FTSMain.BuildParameterName("PR_KEY") + "," +
                                this.FTSMain.BuildParameterName("TRAN_ID") + "," +
                                this.FTSMain.BuildParameterName("OUTPUT_NAME") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + "," +
                                this.FTSMain.BuildParameterName("IS_COPY") + "," +
                                this.FTSMain.BuildParameterName("ACTIVE") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_NAME") + "," +
                                this.FTSMain.BuildParameterName("ORGANIZATION_ID") + "," +
                                this.FTSMain.BuildParameterName("USER_ID") + ")";
                            else
                                sql =
                                "insert into sys_tran_output(pr_key,tran_id, output_name,report_file_data,is_copy,active,report_file_name,organization_id,user_id) " +
                                " values(" + this.FTSMain.BuildParameterName("PR_KEY") + "," +
                                this.FTSMain.BuildParameterName("TRAN_ID") + "," +
                                this.FTSMain.BuildParameterName("OUTPUT_NAME") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + "," +
                                this.FTSMain.BuildParameterName("IS_COPY") + "," +
                                this.FTSMain.BuildParameterName("ACTIVE") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_NAME") + "," +
                                this.FTSMain.BuildParameterName("ORGANIZATION_ID") + "," +
                                this.FTSMain.BuildParameterName("USER_ID") + ")";
                            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
                            this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency, pr_key);
                            if(this.managerBase!=null)
                                this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.ManagerBase.TranId);
                            else
                                this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.tranId);
                            this.FTSMain.DbMain.AddInParameter(cmd, "output_name", DbType.String, frmgetstring.RetVal);
                            this.FTSMain.DbMain.AddInParameter(cmd, "report_file_data", DbType.Binary, bytes);
                            this.FTSMain.DbMain.AddInParameter(cmd, "is_copy", DbType.Int16, 1);
                            this.FTSMain.DbMain.AddInParameter(cmd, "active", DbType.Int16, 1);
                            this.FTSMain.DbMain.AddInParameter(cmd, "report_file_name", DbType.String, "rpt_" + this.tranId + Convert.ToInt64(pr_key));
                            this.FTSMain.DbMain.AddInParameter(cmd, "organization_id", DbType.String, this.FTSMain.UserInfo.OrganizationID);
                            this.FTSMain.DbMain.AddInParameter(cmd, "user_id", DbType.String,
                                                               this.FTSMain.UserInfo.UserID);
                            this.FTSMain.DbMain.ExecuteNonQuery(cmd);
                            this.LoadOutputList();
                        }
                        finally
                        {
                            fs.Close();
                        }
                        Functions.FileDelete(reportfilename);
                    }
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            try
            {
                this.PreviewTransaction();
            }
            catch (FTSException ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
            catch (Exception ex1)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        public virtual void PreviewTransaction()
        {
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.PrintTransaction();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        public virtual void PrintTransaction()
        {
        }

        private void listReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TransactionOutputObject oo = this.listReport.SelectedItem as TransactionOutputObject;
                if (oo != null)
                {
                    this.cmdCopy.Enabled = true;
                    if (oo.Is_Copy == 1)
                    {
                        this.cmdDelete.Enabled = true;
                    }
                    else
                    {
                        this.cmdDelete.Enabled = false;
                    }
                }
                else
                {
                    this.cmdCopy.Enabled = false;
                    this.cmdDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                    throw (new FTSException("MSG_NO_PERMISSION"));
                }
                TransactionOutputObject oo = this.listReport.SelectedItem as TransactionOutputObject;
                if (oo != null)
                {
                    if (oo.Is_Copy == 1)
                    {
                        if (
                            FTS.BaseUI.Utilities.FTSMessageBox.ShowYesNoMessage(
                                this.FTSMain.MsgManager.GetMessage("MSG_DELETE_RECORD_CONFIRM")) == DialogResult.Yes)
                        {
                            string sql = string.Empty;
                            if(this.mNoTranId)
                                sql = "delete from sys_tran_output_no_tran where pr_key = " +
                                         this.FTSMain.BuildParameterName("pr_key");
                            else
                                sql = "delete from sys_tran_output where pr_key = " +
                                         this.FTSMain.BuildParameterName("pr_key");
                            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
                            this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency, oo.Pr_Key);
                            this.FTSMain.DbMain.ExecuteNonQuery(cmd);
                            this.LoadOutputList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        public class TransactionOutputObject
        {
            public decimal Pr_Key;
            public string Output_Name;
            public Int16 Is_Copy;

            public TransactionOutputObject(decimal key, string outputname, Int16 iscopy)
            {
                this.Is_Copy = iscopy;
                this.Pr_Key = key;
                this.Output_Name = outputname;
            }

            public override string ToString()
            {
                return this.Output_Name;
            }
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
                openFile.ShowDialog();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void openFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Functions.FileExists(((OpenFileDialog)sender).FileName))
                {
                    FrmGetString frmgetstring =
                        new FrmGetString(this.FTSMain.MsgManager.GetMessage("MSG_TRAN_OUTPUT_TITLE"),
                                         this.FTSMain.MsgManager.GetMessage("MSG_TRAN_OUTPUT"));
                    if (frmgetstring.ShowDialog() == DialogResult.Yes)
                    {
                        decimal pr_key = 0;
                        if(this.mNoTranId)
                            pr_key = FunctionsBase.GetPr_key("SYS_TRAN_OUTPUT_NO_TRAN", this.FTSMain);
                        else
                            pr_key = FunctionsBase.GetPr_key("SYS_TRAN_OUTPUT", this.FTSMain);
                        FileStream fs = File.OpenRead(((OpenFileDialog)sender).FileName);
                        try
                        {
                            byte[] bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            string sql = string.Empty;
                            if(this.mNoTranId)
                                sql =
                                "insert into sys_tran_output_no_tran(pr_key,tran_id, output_name,report_file_data,is_copy,active,report_file_name,organization_id,user_id) " +
                                " values(" + this.FTSMain.BuildParameterName("PR_KEY") + "," +
                                this.FTSMain.BuildParameterName("TRAN_ID") + "," +
                                this.FTSMain.BuildParameterName("OUTPUT_NAME") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + "," +
                                this.FTSMain.BuildParameterName("IS_COPY") + "," +
                                this.FTSMain.BuildParameterName("ACTIVE") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_NAME") + "," +
                                this.FTSMain.BuildParameterName("ORGANIZATION_ID") + "," +
                                this.FTSMain.BuildParameterName("USER_ID") + ")";
                            else
                                sql =
                                "insert into sys_tran_output(pr_key,tran_id, output_name,report_file_data,is_copy,active,report_file_name,organization_id,user_id) " +
                                " values(" + this.FTSMain.BuildParameterName("PR_KEY") + "," +
                                this.FTSMain.BuildParameterName("TRAN_ID") + "," +
                                this.FTSMain.BuildParameterName("OUTPUT_NAME") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + "," +
                                this.FTSMain.BuildParameterName("IS_COPY") + "," +
                                this.FTSMain.BuildParameterName("ACTIVE") + "," +
                                this.FTSMain.BuildParameterName("REPORT_FILE_NAME") + "," +
                                this.FTSMain.BuildParameterName("ORGANIZATION_ID") + "," +
                                this.FTSMain.BuildParameterName("USER_ID") + ")";
                            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
                            this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency, pr_key);
                            if(this.managerBase!=null)
                                this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.ManagerBase.TranId);
                            else
                                this.FTSMain.DbMain.AddInParameter(cmd, "tran_id", DbType.String, this.tranId);
                            this.FTSMain.DbMain.AddInParameter(cmd, "output_name", DbType.String, frmgetstring.RetVal);
                            this.FTSMain.DbMain.AddInParameter(cmd, "report_file_data", DbType.Binary, bytes);
                            this.FTSMain.DbMain.AddInParameter(cmd, "is_copy", DbType.Int16, 1);
                            this.FTSMain.DbMain.AddInParameter(cmd, "active", DbType.Int16, 1);
                            this.FTSMain.DbMain.AddInParameter(cmd, "report_file_name", DbType.String, "rpt_" + this.tranId + Convert.ToInt64(pr_key));
                            this.FTSMain.DbMain.AddInParameter(cmd, "organization_id", DbType.String, this.FTSMain.UserInfo.OrganizationID);
                            this.FTSMain.DbMain.AddInParameter(cmd, "user_id", DbType.String,
                                                               this.FTSMain.UserInfo.UserID);
                            this.FTSMain.DbMain.ExecuteNonQuery(cmd);
                            this.LoadOutputList();
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        public void StoreReportFile(decimal pr_key, string filename)
        {
            if (Functions.FileExists(filename))
            {
                FileStream fs = File.OpenRead(filename);
                try
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    string sql = string.Empty;
                    if(this.mNoTranId)
                        sql = "update sys_tran_output_no_tran set REPORT_FILE_DATA=" +
                                 this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + " WHERE PR_KEY = " +
                                 this.FTSMain.BuildParameterName("PR_KEY");
                    else
                        sql = "update sys_tran_output set REPORT_FILE_DATA=" +
                                 this.FTSMain.BuildParameterName("REPORT_FILE_DATA") + " WHERE PR_KEY = " +
                                 this.FTSMain.BuildParameterName("PR_KEY");
                    DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
                    this.FTSMain.DbMain.AddInParameter(cmd, "report_file_data", DbType.Binary, bytes);
                    this.FTSMain.DbMain.AddInParameter(cmd, "pr_key", DbType.Currency, pr_key);
                    this.FTSMain.DbMain.ExecuteNonQuery(cmd);
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        public string GetFile(decimal pr_key) {
            object foundRow = this.mReportFileTable[pr_key];
            if (foundRow != null && Functions.FileExists(foundRow.ToString())) {
                return foundRow.ToString();
            }
            string sql = string.Empty;
            if (this.mNoTranId) sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT_NO_TRAN WHERE PR_KEY=" + this.FTSMain.BuildParameterName("PR_KEY");
            else sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT WHERE PR_KEY=" + this.FTSMain.BuildParameterName("PR_KEY");
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            this.FTSMain.DbMain.AddInParameter(cmd, "PR_KEY", DbType.Currency, pr_key);
            object oj = this.FTSMain.DbMain.ExecuteScalar(cmd);
            if (oj != null && oj != System.DBNull.Value) {
                byte[] _ByteArray = (byte[]) oj;
                string filename = Functions.GetTempFilePathWithExtension(".repx");
                System.IO.FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();
                if (foundRow == null) {
                    this.mReportFileTable.Add(pr_key, filename);
                }else {
                    this.mReportFileTable.Remove(pr_key);
                    this.mReportFileTable.Add(pr_key, filename);
                }
                return filename;
            } else {
                return string.Empty;
            }
        }
        public static string GetFile(FTSMain ftsmain,decimal pr_key)
        {
            string sql = string.Empty;
            sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT_NO_TRAN WHERE PR_KEY=" +
                         ftsmain.BuildParameterName("PR_KEY");
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sql);
            ftsmain.DbMain.AddInParameter(cmd, "PR_KEY", DbType.Currency, pr_key);
            object oj = ftsmain.DbMain.ExecuteScalar(cmd);
            if (oj != null && oj != System.DBNull.Value)
            {
                byte[] _ByteArray = (byte[])oj;
                string filename = Functions.GetTempFilePathWithExtension(".repx");
                System.IO.FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create,
                                                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();
                return filename;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetFileName(FTSMain ftsmain, string reportfilename)
        {            
            string sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT WHERE REPORT_FILE_NAME =" +
                        ftsmain.BuildParameterName("PR_KEY");
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sql);
            ftsmain.DbMain.AddInParameter(cmd, "REPORT_FILE_NAME", DbType.String, reportfilename);
            object oj = ftsmain.DbMain.ExecuteScalar(cmd);
            if (oj != null && oj != System.DBNull.Value)
            {
                byte[] _ByteArray = (byte[])oj;
                string filename = Functions.GetTempFilePathWithExtension(".repx");
                System.IO.FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create,
                                                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();
                return filename;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetFileNameNoTran(FTSMain ftsmain, string reportfilename)
        {
            string sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT_NO_TRAN WHERE REPORT_FILE_NAME =" +
                        ftsmain.BuildParameterName("PR_KEY");
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sql);
            ftsmain.DbMain.AddInParameter(cmd, "REPORT_FILE_NAME", DbType.String, reportfilename);
            object oj = ftsmain.DbMain.ExecuteScalar(cmd);
            if (oj != null && oj != System.DBNull.Value)
            {
                byte[] _ByteArray = (byte[])oj;
                string filename = Functions.GetTempFilePathWithExtension(".repx");
                System.IO.FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create,
                                                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();
                return filename;
            }
            else
            {
                return string.Empty;
            }
        }
        public void GetFile(decimal pr_key, string filename)
        {
            string sql = string.Empty;
            if(this.mNoTranId)
                sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT_NO_TRAN WHERE PR_KEY=" +
                         this.FTSMain.BuildParameterName("PR_KEY");
            else
                sql = "SELECT REPORT_FILE_DATA FROM SYS_TRAN_OUTPUT WHERE PR_KEY=" +
                         this.FTSMain.BuildParameterName("PR_KEY");
            DbCommand cmd = this.FTSMain.DbMain.GetSqlStringCommand(sql);
            this.FTSMain.DbMain.AddInParameter(cmd, "PR_KEY", DbType.Currency, pr_key);
            object oj = this.FTSMain.DbMain.ExecuteScalar(cmd);
            if (oj != null && oj != System.DBNull.Value)
            {
                byte[] _ByteArray = (byte[])oj;
                System.IO.FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create,
                                                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();
            }
        }

        private void saveFile_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                TransactionOutputObject oo = this.listReport.SelectedItem as TransactionOutputObject;
                if (oo != null)
                {
                    if (File.Exists(((SaveFileDialog)sender).FileName))
                    {
                        File.Delete(((SaveFileDialog)sender).FileName);
                    }
                    this.GetFile(oo.Pr_Key, ((SaveFileDialog)sender).FileName);
                }
            }
            catch (Exception ex1)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex1);
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            TransactionOutputObject oo = this.listReport.SelectedItem as TransactionOutputObject;
            if (oo != null)
            {
                SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
                saveFile.FileName = "data";
                saveFile.Filter = "Report File (*.repx)|*.repx";
                saveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFile_FileOk);
                saveFile.Title = this.FTSMain.MsgManager.GetMessage("MSG_REPORTEXPORT_FILE");
                saveFile.ShowDialog();
            }
        }

    }
}