#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.ShareBusiness.Acc{
    public class Dm_Pr_Detail : ObjectBase{
        
        public Dm_Pr_Detail(FTSMain ftsmain)
            : base(ftsmain, "dm_pr_detail"){
            this.LoadData();
            this.LoadFields();
        }

        public Dm_Pr_Detail(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "dm_pr_detail"){
            if (!isempty){
                this.LoadData();
            }
            this.LoadFields();
        }

        public Dm_Pr_Detail(FTSMain ftsmain, DataSet ds, string tablename)
            : base(ftsmain, ds, tablename){
            this.LoadFields();
        }

        public override void LoadFields(){
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_DETAIL_ID", DbType.String, true));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_DETAIL_NAME", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ADDRESS", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PHONE", DbType.String, false));
            this.FieldCollection.Add(
                this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TAX_FILE_NUMBER", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_PUBLIC", DbType.Boolean,
                                                                               false));
            
            
        }


        public override void SetRole() {
            this.FTSFunction = FTS.BaseBusiness.Security.FTSFunctionCollection.DM_PR_DETAIL;
        }

        

        public override void CheckBusinessRules(){
            base.CheckBusinessRules();
            int pos = 0;
            foreach (DataRow row in this.DataTable.Rows) {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified) {
                    if (row["PR_DETAIL_ID"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_PR_DETAIL_ID", this.TableName, "PR_DETAIL_ID", pos));
                    }
                    if (row["PR_DETAIL_NAME"].ToString() == string.Empty) {
                        throw (new FTSException(null, "MSG_INVALID_PR_DETAIL_NAME", this.TableName, "PR_DETAIL_NAME", pos));
                    }
                    pos++;
                }
            }
        }

    }
}