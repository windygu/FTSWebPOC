#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public sealed class Sys_Id_Filter : ObjectBase {
        public string parenttablename = string.Empty;

        public Sys_Id_Filter(FTSMain ftsmain) : base(ftsmain, "Sys_Id_Filter") {
            this.LoadData();
            this.LoadFields();
        }

        public Sys_Id_Filter(FTSMain ftsmain, bool isempty) : base(ftsmain, "Sys_Id_Filter") {
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Sys_Id_Filter(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Sys_Id_Filter") {
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PR_KEY", DbType.Guid,
                                                                               true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "REGULAR_EXPRESSION",
                                                                               DbType.String, false));
            
        }

    }
}