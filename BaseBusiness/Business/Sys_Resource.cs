#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public sealed class Sys_Resource : ObjectBase {
        public string parenttablename = string.Empty;

        public Sys_Resource(FTSMain ftsmain) : base(ftsmain, "Sys_Resource") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Resource(FTSMain ftsmain, bool isempty) : base(ftsmain, "Sys_Resource") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Resource(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "Sys_Resource") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Currency,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "RES_ID", DbType.String,
                                                                               false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "RES_VALUE",
                                                                               DbType.String, true));
        }
        public override void CheckBusinessRules() {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                throw (new FTSException("MSG_NO_PERMISSION"));
            }
            base.CheckBusinessRules();
        }
    }
}