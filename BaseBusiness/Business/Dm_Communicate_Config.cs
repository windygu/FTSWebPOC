#region

using System;
using System.Collections.Generic;
using System.Data;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Dm_Communicate_Config : ObjectBase {
        public Dm_Communicate_Config(FTSMain ftsmain) : base(ftsmain, "dm_communicate_config") {
            try {
                this.LoadData();
                this.LoadFields();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public Dm_Communicate_Config(FTSMain ftsmain, bool isempty) : base(ftsmain, "dm_communicate_config") {
            try {
                if (!isempty) {
                    this.LoadData();
                }
                this.LoadFields();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public Dm_Communicate_Config(FTSMain ftsmain, DataSet ds) : base(ftsmain, ds, "dm_communicate_config") {
            try {
                this.LoadFields();
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public override void LoadFields() {
            try {
                this.FieldCollection = new List<FieldInfo>();
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME",
                                                                                   DbType.String, true));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_NEW",
                                                                                   DbType.Boolean, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_EDIT",
                                                                                   DbType.Boolean, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_DELETE",
                                                                                   DbType.Boolean, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_PUBLIC",
                                                                                   DbType.Boolean, false));                
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "USER_ID",
                                                                                   DbType.String, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ACTIVE",
                                                                                   DbType.Boolean, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "LOG_TIME",
                                                                                   DbType.DateTime, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "TABLE_NAME_DISPLAY",
                                                                                   DbType.DateTime, false));
                this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "IS_UPLOAD",
                                                                                  DbType.Boolean, false));      
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }

        public override DataRow AddNew() {
            try {
                DataRow row = base.AddNew();
                row["LOG_TIME"] = DateTime.Now;
                row.EndEdit();
                return row;
            } catch (FTSException) {
                throw;
            } catch (Exception ex) {
                throw (new FTSException(ex));
            }
        }
    }
}