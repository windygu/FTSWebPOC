using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FTS.BaseBusiness.Utilities
{
    public class DataSetHelper
    {
        public DataSet ds;
        public DataSetHelper(ref DataSet DataSet)
        {
            ds = DataSet;
        }
        public DataSetHelper()
        {
            ds = null;
        }
        private class FieldInfo
        {
            public string RelationName;
            public string FieldName;	
            public string FieldAlias;	
            public string Aggregate;
        }
        private System.Collections.ArrayList m_FieldInfo; private string m_FieldList;
        private System.Collections.ArrayList GroupByFieldInfo; private string GroupByFieldList;
        private void ParseFieldList(string FieldList, bool AllowRelation)
        {           
            if (m_FieldList == FieldList) return;
            m_FieldInfo = new System.Collections.ArrayList();
            m_FieldList = FieldList;
            FieldInfo Field; string[] FieldParts; string[] Fields = FieldList.Split(',');
            int i;
            for (i = 0; i <= Fields.Length - 1; i++)
            {
                Field = new FieldInfo();                
                FieldParts = Fields[i].Trim().Split(' ');
                switch (FieldParts.Length)
                {
                    case 1:                        
                        break;
                    case 2:
                        Field.FieldAlias = FieldParts[1];
                        break;
                    default:
                        throw new Exception("Too many spaces in field definition: '" + Fields[i] + "'.");
                }                
                FieldParts = FieldParts[0].Split('.');
                switch (FieldParts.Length)
                {
                    case 1:
                        Field.FieldName = FieldParts[0];
                        break;
                    case 2:
                        if (AllowRelation == false)
                            throw new Exception("Relation specifiers not permitted in field list: '" + Fields[i] + "'.");
                        Field.RelationName = FieldParts[0].Trim();
                        Field.FieldName = FieldParts[1].Trim();
                        break;
                    default:
                        throw new Exception("Invalid field definition: " + Fields[i] + "'.");
                }
                if (Field.FieldAlias == null)
                    Field.FieldAlias = Field.FieldName;
                m_FieldInfo.Add(Field);
            }
        }
        private void ParseGroupByFieldList(string FieldList)
        {           
            if (GroupByFieldList == FieldList) return;
            GroupByFieldInfo = new System.Collections.ArrayList();
            FieldInfo Field; string[] FieldParts; string[] Fields = FieldList.Split(',');
            for (int i = 0; i <= Fields.Length - 1; i++)
            {
                Field = new FieldInfo();               
                FieldParts = Fields[i].Trim().Split(' ');
                switch (FieldParts.Length)
                {
                    case 1:                        
                        break;
                    case 2:
                        Field.FieldAlias = FieldParts[1];
                        break;
                    default:
                        throw new ArgumentException("Too many spaces in field definition: '" + Fields[i] + "'.");
                }                
                FieldParts = FieldParts[0].Split('(');
                switch (FieldParts.Length)
                {
                    case 1:
                        Field.FieldName = FieldParts[0];
                        break;
                    case 2:
                        Field.Aggregate = FieldParts[0].Trim().ToLower();   
                        Field.FieldName = FieldParts[1].Trim(' ', ')');
                        break;
                    default:
                        throw new ArgumentException("Invalid field definition: '" + Fields[i] + "'.");
                }
                if (Field.FieldAlias == null)
                {
                    if (Field.Aggregate == null)
                        Field.FieldAlias = Field.FieldName;
                    else
                        Field.FieldAlias = Field.Aggregate + "of" + Field.FieldName;
                }
                GroupByFieldInfo.Add(Field);
            }
            GroupByFieldList = FieldList;
        }
        public DataTable CreateGroupByTable(string TableName, DataTable SourceTable, string FieldList)
        {           
            if (FieldList == null)
            {
                throw new ArgumentException("You must specify at least one field in the field list.");                
            }
            else
            {
                DataTable dt = new DataTable(TableName);
                ParseGroupByFieldList(FieldList);
                foreach (FieldInfo Field in GroupByFieldInfo)
                {
                    DataColumn dc = SourceTable.Columns[Field.FieldName];
                    if (Field.Aggregate == null)
                        dt.Columns.Add(Field.FieldAlias, dc.DataType, dc.Expression);
                    else
                        dt.Columns.Add(Field.FieldAlias, dc.DataType);
                }
                if (ds != null)
                    ds.Tables.Add(dt);
                return dt;
            }
        }
    }
}
