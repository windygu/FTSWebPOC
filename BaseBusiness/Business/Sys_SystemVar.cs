#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Sys_SystemVar : ObjectBase {
        public Sys_SystemVar(FTSMain ftsmain) : base(ftsmain, "sys_systemvar") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_SystemVar(FTSMain ftsmain, bool isempty) : base(ftsmain, "sys_systemvar") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_SystemVar(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "sys_systemvar") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAR_NAME", DbType.String,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAR_VALUE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "DESCRIPTION",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAR_TYPE", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "VAR_GROUP",
                                                                               DbType.String, false));
            this.FTSMain.FieldManager.ClearData();
        }

        public override void UpdateData() {
            base.UpdateData();
            this.FTSMain.SystemVars.ReLoadData();
        }
    }
}