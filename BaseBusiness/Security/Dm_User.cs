#region

using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Security
{
    public sealed class Sec_User : ObjectBase
    {
     
        public Sec_User(FTSMain ftsmain)
            : base(ftsmain, "Sec_User")
        {
            this.LoadData();
            this.LoadFields();
        }

        public Sec_User(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "Sec_User")
        {
            if (!isempty)
            {
                this.LoadData();
            }
            this.LoadFields();
        }
        public Sec_User(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "Sec_User")
        {
            this.LoadFields();
        }

        public override void LoadFields()
        {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID",
                                                                               DbType.String, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_GROUP_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_PASSWORD",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "EMPLOYEE_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE",
                                                                               DbType.Boolean, false));
        }
    }
}