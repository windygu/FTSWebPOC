using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

namespace FTS.BaseBusiness.Business
{
    public class Dm_Workstation : ObjectBase
    {
        public Dm_Workstation(FTSMain ftsmain, string condition): base(ftsmain, "DM_WORKSTATION")
        {            
            this.Condittion = condition;
            this.LoadData();
            this.LoadFields();           
        }

        public Dm_Workstation(FTSMain ftsmain, string condition, bool isempty): base(ftsmain, "DM_WORKSTATION")
        {            
            this.Condittion = condition;
            if (!isempty)
            {
                this.LoadData();
            }
            this.LoadFields();            
        }

        public Dm_Workstation(FTSMain ftsmain, DataSet ds, string condition): base(ftsmain, ds, "DM_WORKSTATION")
        {            
            this.Condittion = condition;
            this.LoadFields();            
        }
        public override void LoadFields()
        {            
            this.FieldCollection = new System.Collections.Generic.List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "WORKSTATION_ID", DbType.Int32, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "WORKSTATION_NAME", DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "HARDWARE_INFO", DbType.String, false));            
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE", DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_ONLINE", DbType.Boolean, false));                
        }        
    }
}
