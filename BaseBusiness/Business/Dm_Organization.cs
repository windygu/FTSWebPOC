#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;

#endregion

namespace FTS.BaseBusiness.Business {
    public class Dm_Organization : ObjectBase {
        public Dm_Organization(FTSMain ftsmain)
            : base(ftsmain, "DM_ORGANIZATION") {
            this.IsDmOrganization = true;
            this.LoadData();
            this.LoadFields();
        }

        public Dm_Organization(FTSMain ftsmain, bool isempty)
            : base(ftsmain, "DM_ORGANIZATION") {
            this.IsDmOrganization = true;
            if (!isempty) {
                this.LoadData();
            }
            this.LoadFields();
        }

        public Dm_Organization(FTSMain ftsmain, DataSet ds)
            : base(ftsmain, ds, "DM_ORGANIZATION") {
            this.IsDmOrganization = true;
            this.LoadFields();
        }

        public override void LoadFields() {
            this.FieldCollection = new List<FieldInfo>();
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_ID",
                                                                               DbType.String, true));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "ORGANIZATION_TYPE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName, "PARENT_ORGANIZATION_ID",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "ADDRESS",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "CITY",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "DISTRICT",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "PHONE",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "FAX",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "EMAIL",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "TAX_FILE_NUMBER",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "ORGANIZATION_NAME_DISPLAY",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "ACTIVE",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "IS_POS",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "IS_SHIFT",
                                                                               DbType.Boolean, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "SHORT_ORGANIZATION_NAME",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "PFS_SERVICE_URL",
                                                                               DbType.String, false));
            this.FieldCollection.Add(this.FTSMain.FieldManager.CreateFieldInfo(this.TableName,
                                                                               "IS_SUB",
                                                                               DbType.Boolean, false));
        }

        public override void SetRole() {
            this.FTSFunction = FTSFunctionCollection.DM_ORGANIZATION;
        }

        public override void LoadOtherDm() {
            if (this.DataSet.Tables.IndexOf("DM_ORGANIZATION") < 0) {
                this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION",
                                                    "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE",
                                                    "ORGANIZATION_ID<>''");
            }
        }

        public override void RefreshDm() {
            this.FTSMain.TableManager.LoadTable(this.DataSet, "DM_ORGANIZATION",
                                                "ORGANIZATION_ID,ORGANIZATION_NAME,PARENT_ORGANIZATION_ID,ORGANIZATION_TYPE",
                                                "ORGANIZATION_ID<>''");
        }

        public override void UpdateData() {
            base.UpdateData();
        }

        public static string GetIdNodeParents(FTSMain ftsmain, object organization_id) {
            DataTable tblOrganization =
                ftsmain.DbMain.LoadDataTable(ftsmain.DbMain.GetSqlStringCommand("select * from DM_ORGANIZATION"),
                                             "DM_ORGANIZATION");
            tblOrganization.PrimaryKey = new DataColumn[] {tblOrganization.Columns["ORGANIZATION_ID"]};
            DataRow foundrow = tblOrganization.Rows.Find(organization_id);
            if (foundrow != null) {
                string ids = "," + foundrow["ORGANIZATION_ID"].ToString() + ",";
                ;
                do {
                    ids = ids + foundrow["PARENT_ORGANIZATION_ID"].ToString() + ",";
                    foundrow = tblOrganization.Rows.Find(foundrow["PARENT_ORGANIZATION_ID"]);
                }
                while (foundrow != null);
                return ids;
            } else {
                return string.Empty;
            }
        }

        public static string GetIdNodeParents(DataTable tblOrganization, object organization_id) {
            tblOrganization.PrimaryKey = new DataColumn[] {tblOrganization.Columns["ORGANIZATION_ID"]};
            DataRow foundrow = tblOrganization.Rows.Find(organization_id);
            if (foundrow != null) {
                string ids = "," + foundrow["ORGANIZATION_ID"].ToString() + ",";
                ;
                do {
                    ids = ids + foundrow["PARENT_ORGANIZATION_ID"].ToString() + ",";
                    foundrow = tblOrganization.Rows.Find(foundrow["PARENT_ORGANIZATION_ID"]);
                }
                while (foundrow != null);
                return ids;
            } else {
                return string.Empty;
            }
        }

        public static string GetIdNodeChild(FTSMain ftsmain, object parent_organization_id) {
            string sSql = "select * from DM_ORGANIZATION where PARENT_ORGANIZATION_ID =" +
                          ftsmain.BuildParameterName("PARENT_ORGANIZATION_ID") + "";
            DbCommand cmd = ftsmain.DbMain.GetSqlStringCommand(sSql);
            ftsmain.DbMain.AddInParameter(cmd, "PARENT_ORGANIZATION_ID", DbType.String, parent_organization_id);
            DataTable tblOrganization = ftsmain.DbMain.LoadDataTable(cmd, "DM_ORGANIZATION");
            string sIdChild = "";
            foreach (DataRow ro in tblOrganization.Rows) {
                sIdChild = sIdChild + "'" + ro["ORGANIZATION_ID"].ToString() + "',";
                sIdChild = sIdChild + GetIdNodeChild(ftsmain, ro["ORGANIZATION_ID"].ToString());
            }
            return sIdChild;
        }

        public static string GetOrganizationName(FTSMain ftsmain, string organization_id) {
            string organization_name = string.Empty;
            DataTable tblOrganization =
                ftsmain.DbMain.LoadDataTable(ftsmain.DbMain.GetSqlStringCommand("select * from DM_ORGANIZATION"),
                                             "DM_ORGANIZATION");
            tblOrganization.PrimaryKey = new DataColumn[] {tblOrganization.Columns["ORGANIZATION_ID"]};
            DataRow foundrow = tblOrganization.Rows.Find(organization_id);
            if (foundrow != null) {
                organization_name = foundrow["ORGANIZATION_NAME"].ToString();
            }
            return organization_name;
        }

        public static string GetChildOrganization(DataTable dmorganization, string organizationid) {
            string listchild = "" + organizationid + "," +
                               GetChildOrganizationRecursive(dmorganization, organizationid);
            if (listchild.Length > 0 && listchild.Substring(listchild.Length - 1, 1) == ",") {
                listchild = listchild.Substring(0, listchild.Length - 1);
            }
            return listchild;
        }

        public static string GetChildOrganizationList(DataTable dmorganization, string organizationid) {
            string listchild = "" + organizationid + "," +
                               GetChildOrganizationListRecursive(dmorganization, organizationid);
            if (listchild.Length > 0 && listchild.Substring(listchild.Length - 1, 1) == ",") {
                listchild = listchild.Substring(0, listchild.Length - 1);
            }
            return listchild;
        }

        public static List<string> GetChildOrganizationArrayList(DataTable dmorganization, string organizationid) {
            List<string> list = new List<string>();
            foreach (DataRow row in dmorganization.Rows) {
                if (row["PARENT_ORGANIZATION_ID"].ToString() == organizationid) {
                    list.Add(row["ORGANIZATION_ID"].ToString());
                    List<string> list1 = Dm_Organization.GetChildOrganizationArrayList(dmorganization,
                                                                                       row["ORGANIZATION_ID"].ToString());
                    foreach (string s in list1) {
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        private static string GetChildOrganizationRecursive(DataTable dmorganization, string organizationid) {
            string listchild = string.Empty;
            foreach (DataRow row in dmorganization.Rows) {
                if (row["PARENT_ORGANIZATION_ID"].ToString() == organizationid) {
                    listchild += "" + row["ORGANIZATION_ID"].ToString() + ",";
                    listchild += GetChildOrganizationRecursive(dmorganization, row["ORGANIZATION_ID"].ToString());
                }
            }
            return listchild;
        }

        private static string GetChildOrganizationListRecursive(DataTable dmorganization, string organizationid) {
            string listchild = string.Empty;
            foreach (DataRow row in dmorganization.Rows) {
                if (row["PARENT_ORGANIZATION_ID"].ToString() == organizationid) {
                    listchild += "" + row["ORGANIZATION_ID"] + ",";
                    listchild += GetChildOrganizationRecursive(dmorganization, row["ORGANIZATION_ID"].ToString());
                }
            }
            return listchild;
        }

        public static string GetOrganizationFilter(FTSMain ftsmain, DataTable dmorganization) {
            if (dmorganization != null) {
                return ftsmain.IsMultiOrganization
                           ? " ORGANIZATION_ID IN " + Functions.PopulateString(Dm_Organization.GetChildOrganization(dmorganization, ftsmain.UserInfo.OrganizationID)) + ""
                           : " 1=1 ";
            } else {
                return ftsmain.IsMultiOrganization
                           ? " ORGANIZATION_ID IN " + Functions.PopulateString(Dm_Organization.GetChildOrganization(ftsmain.TableManager.LoadTable("DM_ORGANIZATION", "ORGANIZATION_ID,PARENT_ORGANIZATION_ID", "ACTIVE=1"), ftsmain.UserInfo.OrganizationID)) + ""
                           : " 1=1 ";
            }
        }

        public static string GetOrganizationFilter(FTSMain ftsmain, DataTable dmorganization, string organizationid) {
            if (organizationid == string.Empty) {
                return "1=1";
            } else {
                return ftsmain.IsMultiOrganization
                           ? " ORGANIZATION_ID IN " +
                             Functions.PopulateString(Dm_Organization.GetChildOrganization(dmorganization, organizationid)) + ""
                           : " 1=1 ";
            }
        }

        public static bool IsSameIndependentBranchBook(DataTable dmorganization, string organizationid1, string organizationid2) {
            if (organizationid1 == string.Empty || organizationid2 == string.Empty) {
                return false;
            } else {
                string parent1 = Dm_Organization.GetIndependantParentOrganization(dmorganization, organizationid1);
                string parent2 = Dm_Organization.GetIndependantParentOrganization(dmorganization, organizationid2);
                if (parent1 == parent2) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public override void LoadData() {
            base.LoadData();
            this.DataTable.PrimaryKey = new DataColumn[] {this.DataTable.Columns["ORGANIZATION_ID"]};
        }

        public static string GetOrganizationType(FTSMain ftsmain, string organization_id) {
            string sql = "select ORGANIZATION_TYPE from dm_ORGANIZATION where ORGANIZATION_id='" + organization_id + "'";
            object oj = ftsmain.DbMain.ExecuteScalar(ftsmain.DbMain.GetSqlStringCommand(sql));
            if (oj != null && oj != System.DBNull.Value) {
                return oj.ToString();
            } else {
                return OrganizationType.COMPANY;
            }
        }

        public static string GetOrganizationType(FTSMain ftsmain, DataTable table, string organization_id) {
            if (table.Columns.IndexOf("ORGANIZATION_TYPE") >= 0) {
                DataColumn[] oldkey = table.PrimaryKey;
                table.PrimaryKey = new DataColumn[] {table.Columns["ORGANIZATION_ID"]};
                DataRow foundrow = table.Rows.Find(organization_id);
                table.PrimaryKey = oldkey;
                if (foundrow != null) {
                    return foundrow["ORGANIZATION_TYPE"].ToString();
                } else {
                    return OrganizationType.COMPANY;
                }
            } else {
                return GetOrganizationType(ftsmain, organization_id);
            }
        }

        public static bool IsDependentChild(FTSMain ftsmain, DataTable dmorganization, string childid, string parentid) {
            DataTable dmorganization1;
            if (dmorganization == null) {
                dmorganization1 = ftsmain.TableManager.LoadTable("DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_TYPE,PARENT_ORGANIZATION_ID", "ACTIVE=1");
            } else {
                if (dmorganization.Columns.IndexOf("ORGANIZATION_TYPE") < 0 || dmorganization.Columns.IndexOf("PARENT_ORGANIZATION_ID") < 0) {
                    dmorganization1 = ftsmain.TableManager.LoadTable("DM_ORGANIZATION", "ORGANIZATION_ID,ORGANIZATION_TYPE,PARENT_ORGANIZATION_ID", "ACTIVE=1");
                } else {
                    dmorganization1 = dmorganization;
                }
            }
            DataRow row = dmorganization1.Rows.Find(childid);
            if (row != null && row["ORGANIZATION_TYPE"].ToString().Trim() == OrganizationType.DEPENDANT_ORGANIZATION) {
                string childlist = Dm_Organization.GetChildOrganization(dmorganization1, parentid);
                if (Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(childid, childlist)) {
                    return true;
                }
            }
            return false;
        }

        public static bool IsPOS(FTSMain ftsmain, string organizationid) {
            DataTable dmorganization = ftsmain.TableManager.LoadTable("DM_ORGANIZATION");
            DataRow row = dmorganization.Rows.Find(organizationid);
            if (row != null && (Int16) row["IS_POS"] == 1) {
                return true;
            }
            return false;
        }

        public static List<string> GetParentOrganizationList(DataTable dmorganization, string organizationid) {
            DataRow row = dmorganization.Rows.Find(organizationid);
            if (row != null) {
                List<string> list = Dm_Organization.GetParentOrganizationList(dmorganization,
                                                                              row["PARENT_ORGANIZATION_ID"].ToString());
                list.Add(row["PARENT_ORGANIZATION_ID"].ToString());
                return list;
            }
            return new List<string>();
        }

        public static string GetIndependantParentOrganization(DataTable dmorganization, string organizationid) {
            DataRow row = dmorganization.Rows.Find(organizationid);
            if (row != null) {
                if (row["ORGANIZATION_TYPE"].ToString() == OrganizationType.INDEPENDANT_ORGANIZATION || row["ORGANIZATION_TYPE"].ToString() == OrganizationType.COMPANY) {
                    return row["ORGANIZATION_ID"].ToString();
                } else {
                    return Dm_Organization.GetIndependantParentOrganization(dmorganization,
                                                                            row["PARENT_ORGANIZATION_ID"].ToString());
                }
            }
            return string.Empty;
        }

        public static bool IsChildOrSame(DataTable dmorganization, string parentorganizationid, string childorganizationid) {
            if (parentorganizationid == childorganizationid) {
                return true;
            } else {
                foreach (DataRow row in dmorganization.Rows) {
                    if (row["PARENT_ORGANIZATION_ID"].ToString() == parentorganizationid) {
                        if (row["ORGANIZATION_ID"].ToString() == childorganizationid) {
                            return true;
                        } else {
                            if (Dm_Organization.IsChildOrSame(dmorganization, row["ORGANIZATION_ID"].ToString(),
                                                              childorganizationid)) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public override void CheckBusinessRules() {
            if (this.FTSMain.UserInfo.UserGroupID != "ADMIN") {
                throw (new FTSException("MSG_NO_PERMISSION"));
            }
            base.CheckBusinessRules();
        }
        public static bool IsSubOrganization(FTSMain ftsmain, DataTable dmorganization, string organizationid) {
            if (dmorganization != null) {
                DataRow foundrow = dmorganization.Rows.Find(organizationid);
                if (foundrow != null) {
                    return (Int16) foundrow["IS_SUB"] == 1 ? true : false;
                }else {
                    return false;
                }
            }else {
                object oj = ftsmain.DbMain.ExecuteScalar(ftsmain.DbMain.GetSqlStringCommand("SELECT IS_SUB FROM DM_ORGANIZATION WHERE ORGANIZATION_ID='" + organizationid + "'"));
                if (oj != null && oj != System.DBNull.Value) {
                    return (Int16)oj == 1 ? true : false;
                }else {
                    return false;
                }
            }
        }
        public static string GetParentOrganizationID(FTSMain ftsmain, DataTable dmorganization, string organizationid) {
            if (dmorganization != null) {
                DataRow foundrow = dmorganization.Rows.Find(organizationid);
                if (foundrow != null) {
                    return foundrow["PARENT_ORGANIZATION_ID"].ToString();
                } else {
                    return string.Empty;
                }
            } else {
                object oj = ftsmain.DbMain.ExecuteScalar(ftsmain.DbMain.GetSqlStringCommand("SELECT PARENT_ORGANIZATION_ID FROM DM_ORGANIZATION WHERE ORGANIZATION_ID='" + organizationid + "'"));
                if (oj != null && oj != System.DBNull.Value) {
                    return oj.ToString();
                } else {
                    return string.Empty;
                }
            }
        }
    }
}