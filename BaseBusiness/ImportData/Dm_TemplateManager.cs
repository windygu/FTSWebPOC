#region

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using Microsoft.Practices.EnterpriseLibrary.Data;

#endregion

namespace FTS.BaseBusiness.ImportData{
    public class Dm_TemplateManager : ManagerBase{
        public Dm_Template dm_template;
        public Dm_Template_Detail dm_template_detail;
        private ManagerBase mManageBase = null;
        private ObjectBase mObjectBase = null;
        
        public Dm_TemplateManager(FTSMain ftsmain, string tran_id)
            : base(ftsmain, tran_id){
            this.LoadDm();
            dm_template = new Dm_Template(ftsmain, this.DataSet, this.TranId);
            dm_template_detail = new Dm_Template_Detail(ftsmain, this.DataSet);
            this.ObjectList.Add(dm_template);
            this.ObjectList.Add(dm_template_detail);
            this.TranDateField = "";
            this.TranNoField = "TEMPLATE_NAME";
            this.TranIdField = "";
        }
        public void Set (ManagerBase managerBase, ObjectBase objectBase) {
            this.mManageBase = managerBase;
            this.mObjectBase = objectBase;
        }
        public override void LoadRecordWithPrkey(object key) {
            base.LoadRecordWithPrkey(key);
            this.LoadDmDataColumn();
        }

        public void LoadDmDataColumn() {
            if (this.dm_template.IsValidRow(0)) {
                if (this.DataSet.Tables["DM_DATACOLUMNS"] != null) {
                    this.DataSet.Tables["DM_DATACOLUMNS"].Clear();
                }
                if (this.mObjectBase != null) {
                        this.FTSMain.DbMain.LoadDataSet(
                            this.FTSMain.DbMain.GetSqlStringCommand(@"select DISTINCT B.NAME AS DATA_COLUMN_NAME from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name = '" +
                                                                    this.mObjectBase.TableNameOrig + "'"), this.DataSet, "DM_DATACOLUMNS");
                }else {
                        this.FTSMain.DbMain.LoadDataSet(
                            this.FTSMain.DbMain.GetSqlStringCommand(@"select DISTINCT B.NAME AS DATA_COLUMN_NAME from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name in ('" +
                                                                    this.mManageBase.ObjectList[0].TableNameOrig + "','" + this.mManageBase.ObjectList[1].TableNameOrig + "')"), this.DataSet, "DM_DATACOLUMNS");
                }
            }
        }
        
        public override void LoadDm(){
            if (this.DataSet.Tables["DM_DATACOLUMNS"] != null) {
                this.DataSet.Tables["DM_DATACOLUMNS"].Clear();
            }
                        this.FTSMain.DbMain.LoadDataSet(
                            this.FTSMain.DbMain.GetSqlStringCommand(@"select DISTINCT B.NAME AS DATA_COLUMN_NAME from sys.tables a, sys.columns b where a.object_id=b.object_id  and a.name = ''"),this.DataSet, "DM_DATACOLUMNS");
           
        }

        
        protected override void InsertDefaultConfigs() {
            this.InsertConfigValue("AUTO_TRAN_NO","BOOLEAN",false);
        }
    }
}