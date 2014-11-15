#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;

#endregion

namespace FTS.Global.DataSurrogate{
    [Serializable]
    internal class DataTableSurrogate{
        private string _tableName;
        private string _namespace;
        private string _prefix;
        private bool _caseSensitive;
        private CultureInfo _locale;
        private string _displayExpression;
        private int _minimumCapacity;

        private DataColumnSurrogate[] _dataColumnSurrogates;

        private ArrayList _uniqueConstraints;

        private Hashtable _extendedProperties;

        private BitArray _rowStates;
        private object[][] _records;
        private Hashtable _rowErrors = new Hashtable();
        private Hashtable _colErrors = new Hashtable();

        public DataTableSurrogate(DataTable dt){
            if (dt == null){
                throw new ArgumentNullException("The parameter dt is null");
            }

            _tableName = dt.TableName;
            _namespace = dt.Namespace;
            _prefix = dt.Prefix;
            _caseSensitive = dt.CaseSensitive;
            _locale = dt.Locale;
            _displayExpression = dt.DisplayExpression;
            _minimumCapacity = dt.MinimumCapacity;

            _dataColumnSurrogates = new DataColumnSurrogate[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++){
                _dataColumnSurrogates[i] = new DataColumnSurrogate(dt.Columns[i]);
            }

            _uniqueConstraints = GetUniqueConstraints(dt);

            _extendedProperties = new Hashtable();
            if (dt.ExtendedProperties.Keys.Count > 0){
                foreach (object propertyKey in dt.ExtendedProperties.Keys){
                    _extendedProperties.Add(propertyKey, dt.ExtendedProperties[propertyKey]);
                }
            }

            if (dt.Rows.Count > 0){
                _rowStates = new BitArray(dt.Rows.Count << 1);
                _records = new object[dt.Columns.Count][];
                for (int i = 0; i < dt.Columns.Count; i++){
                    _records[i] = new object[dt.Rows.Count << 1];
                }
                for (int i = 0; i < dt.Rows.Count; i++){
                    GetRecords(dt.Rows[i], i << 1);
                }
            }
        }

        public DataTable ConvertToDataTable(){
            DataTable dt = new DataTable();
            ReadSchemaIntoDataTable(dt);
            ReadDataIntoDataTable(dt);
            return dt;
        }

        public DataTable ConvertToDataTable2()
        {
            DataTable dt = new DataTable();
            ReadSchemaIntoDataTable2(dt);
            ReadDataIntoDataTable(dt);
            return dt;
        }

        public void ReadSchemaIntoDataTable2(DataTable dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException("The datatable parameter cannot be null");
            }

            dt.TableName = _tableName;
            dt.Namespace = _namespace;
            dt.Prefix = _prefix;
            dt.CaseSensitive = _caseSensitive;
            dt.Locale = _locale;
            dt.DisplayExpression = _displayExpression;
            dt.MinimumCapacity = _minimumCapacity;

            Debug.Assert(_dataColumnSurrogates != null);
            for (int i = 0; i < _dataColumnSurrogates.Length; i++)
            {
                DataColumnSurrogate dataColumnSurrogate = _dataColumnSurrogates[i];
                DataColumn dc = dataColumnSurrogate.ConvertToDataColumn();
                if (dc.Expression != string.Empty)
                {
                    DataColumn newdc = new DataColumn(dc.ColumnName, dc.DataType);
                    dt.Columns.Add(newdc);
                }
                else
                {
                    if (dc.ReadOnly)
                        dc.ReadOnly = false;
                    dt.Columns.Add(dc);
                }
            }

            SetUniqueConstraints(dt, _uniqueConstraints);

            Debug.Assert(_extendedProperties != null);
            if (_extendedProperties.Keys.Count > 0)
            {
                foreach (object propertyKey in _extendedProperties.Keys)
                {
                    dt.ExtendedProperties.Add(propertyKey, _extendedProperties[propertyKey]);
                }
            }
        }

        public void ReadSchemaIntoDataTable(DataTable dt){
            if (dt == null){
                throw new ArgumentNullException("The datatable parameter cannot be null");
            }

            dt.TableName = _tableName;
            dt.Namespace = _namespace;
            dt.Prefix = _prefix;
            dt.CaseSensitive = _caseSensitive;
            dt.Locale = _locale;
            dt.DisplayExpression = _displayExpression;
            dt.MinimumCapacity = _minimumCapacity;

            Debug.Assert(_dataColumnSurrogates != null);
            for (int i = 0; i < _dataColumnSurrogates.Length; i++){
                DataColumnSurrogate dataColumnSurrogate = _dataColumnSurrogates[i];
                DataColumn dc = dataColumnSurrogate.ConvertToDataColumn();
                dt.Columns.Add(dc);
            }

            SetUniqueConstraints(dt, _uniqueConstraints);

            Debug.Assert(_extendedProperties != null);
            if (_extendedProperties.Keys.Count > 0){
                foreach (object propertyKey in _extendedProperties.Keys){
                    dt.ExtendedProperties.Add(propertyKey, _extendedProperties[propertyKey]);
                }
            }
        }

        public void ReadDataIntoDataTable(DataTable dt){
            ReadDataIntoDataTable(dt, true);
        }

        internal void ReadDataIntoDataTable(DataTable dt, bool suppressSchema){
            if (dt == null){
                throw new ArgumentNullException("The datatable parameter cannot be null");
            }
            Debug.Assert(IsSchemaIdentical(dt));

            ArrayList readOnlyList = null;
            ArrayList constraintRulesList = null;
            if (suppressSchema){
                readOnlyList = SuppressReadOnly(dt);
                constraintRulesList = SuppressConstraintRules(dt);
            }

            if (_records != null && dt.Columns.Count > 0){
                Debug.Assert(_records.Length > 0);
                int rowCount = _records[0].Length >> 1;
                for (int i = 0; i < rowCount; i++){
                    ConvertToDataRow(dt, i << 1);
                }
            }

            if (suppressSchema){
                ResetReadOnly(dt, readOnlyList);
                ResetConstraintRules(dt, constraintRulesList);
            }
        }

        private ArrayList GetUniqueConstraints(DataTable dt){
            Debug.Assert(dt != null);

            ArrayList constraintList = new ArrayList();
            for (int i = 0; i < dt.Constraints.Count; i++){
                Constraint c = dt.Constraints[i];
                UniqueConstraint uc = c as UniqueConstraint;
                if (uc != null){
                    string constraintName = c.ConstraintName;
                    int[] colInfo = new int[uc.Columns.Length];
                    for (int j = 0; j < colInfo.Length; j++){
                        colInfo[j] = uc.Columns[j].Ordinal;
                    }

                    ArrayList list = new ArrayList();
                    list.Add(constraintName);
                    list.Add(colInfo);
                    list.Add(uc.IsPrimaryKey);
                    Hashtable extendedProperties = new Hashtable();
                    if (uc.ExtendedProperties.Keys.Count > 0){
                        foreach (object propertyKey in uc.ExtendedProperties.Keys){
                            extendedProperties.Add(propertyKey, uc.ExtendedProperties[propertyKey]);
                        }
                    }
                    list.Add(extendedProperties);

                    constraintList.Add(list);
                }
            }
            return constraintList;
        }

        private void SetUniqueConstraints(DataTable dt, ArrayList constraintList){
            Debug.Assert(dt != null);
            Debug.Assert(constraintList != null);

            foreach (ArrayList list in constraintList){
                Debug.Assert(list.Count == 4);
                string constraintName = (string) list[0];
                int[] keyColumnIndexes = (int[]) list[1];
                bool isPrimaryKey = (bool) list[2];
                Hashtable extendedProperties = (Hashtable) list[3];

                DataColumn[] keyColumns = new DataColumn[keyColumnIndexes.Length];
                for (int i = 0; i < keyColumnIndexes.Length; i++){
                    Debug.Assert(dt.Columns.Count > keyColumnIndexes[i]);
                    keyColumns[i] = dt.Columns[keyColumnIndexes[i]];
                }

                UniqueConstraint uc = new UniqueConstraint(constraintName, keyColumns, isPrimaryKey);

                Debug.Assert(extendedProperties != null);
                if (extendedProperties.Keys.Count > 0){
                    foreach (object propertyKey in extendedProperties.Keys){
                        uc.ExtendedProperties.Add(propertyKey, extendedProperties[propertyKey]);
                    }
                }
                dt.Constraints.Add(uc);
            }
        }

        internal void SetColumnExpressions(DataTable dt){
            Debug.Assert(dt != null);

            Debug.Assert(_dataColumnSurrogates != null);
            Debug.Assert(dt.Columns.Count == _dataColumnSurrogates.Length);
            for (int i = 0; i < dt.Columns.Count; i++){
                DataColumn dc = dt.Columns[i];
                DataColumnSurrogate dataColumnSurrogate = _dataColumnSurrogates[i];
                dataColumnSurrogate.SetColumnExpression(dc);
            }
        }

        private void GetRecords(DataRow row, int bitIndex){
            Debug.Assert(row != null);

            ConvertToSurrogateRowState(row.RowState, bitIndex);
            ConvertToSurrogateRecords(row, bitIndex);
            ConvertToSurrogateRowError(row, bitIndex >> 1);
        }

        public DataRow ConvertToDataRow(DataTable dt, int bitIndex){
            DataRowState rowState = ConvertToRowState(bitIndex);
            DataRow row = ConstructRow(dt, rowState, bitIndex);
            ConvertToRowError(row, bitIndex >> 1);
            return row;
        }

        private void ConvertToSurrogateRowState(DataRowState rowState, int bitIndex){
            Debug.Assert(_rowStates != null);
            Debug.Assert(_rowStates.Length > bitIndex);

            switch (rowState){
                case DataRowState.Unchanged:
                    _rowStates[bitIndex] = false;
                    _rowStates[bitIndex + 1] = false;
                    break;
                case DataRowState.Added:
                    _rowStates[bitIndex] = false;
                    _rowStates[bitIndex + 1] = true;
                    break;
                case DataRowState.Modified:
                    _rowStates[bitIndex] = true;
                    _rowStates[bitIndex + 1] = false;
                    break;
                case DataRowState.Deleted:
                    _rowStates[bitIndex] = true;
                    _rowStates[bitIndex + 1] = true;
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("Unrecognized row state {0}", rowState));
            }
        }

        private DataRowState ConvertToRowState(int bitIndex){
            Debug.Assert(_rowStates != null);
            Debug.Assert(_rowStates.Length > bitIndex);

            bool b1 = _rowStates[bitIndex];
            bool b2 = _rowStates[bitIndex + 1];

            if (!b1 && !b2){
                return DataRowState.Unchanged;
            } else if (!b1 && b2){
                return DataRowState.Added;
            } else if (b1 && !b2){
                return DataRowState.Modified;
            } else if (b1 && b2){
                return DataRowState.Deleted;
            } else{
                throw new ArgumentException("Unrecognized bitpattern");
            }
        }

        private void ConvertToSurrogateRecords(DataRow row, int bitIndex){
            Debug.Assert(row != null);
            Debug.Assert(_records != null);

            int colCount = row.Table.Columns.Count;
            DataRowState rowState = row.RowState;

            Debug.Assert(_records.Length == colCount);
            if (rowState != DataRowState.Added){
                for (int i = 0; i < colCount; i++){
                    Debug.Assert(_records[i].Length > bitIndex);
                    _records[i][bitIndex] = row[i, DataRowVersion.Original];
                }
            }

            if (rowState != DataRowState.Unchanged && rowState != DataRowState.Deleted){
                for (int i = 0; i < colCount; i++){
                    Debug.Assert(_records[i].Length > bitIndex + 1);
                    _records[i][bitIndex + 1] = row[i, DataRowVersion.Current];
                }
            }
        }

        private DataRow ConstructRow(DataTable dt, DataRowState rowState, int bitIndex){
            Debug.Assert(dt != null);
            Debug.Assert(_records != null);

            DataRow row = dt.NewRow();
            int colCount = dt.Columns.Count;

            Debug.Assert(_records.Length == colCount);
            switch (rowState){
                case DataRowState.Unchanged:
                    for (int i = 0; i < colCount; i++){
                        Debug.Assert(_records[i].Length > bitIndex);
                        row[i] = _records[i][bitIndex];
                    }
                    dt.Rows.Add(row);
                    row.AcceptChanges();
                    break;
                case DataRowState.Added:
                    for (int i = 0; i < colCount; i++){
                        Debug.Assert(_records[i].Length > bitIndex + 1);
                        row[i] = _records[i][bitIndex + 1];
                    }
                    dt.Rows.Add(row);
                    break;
                case DataRowState.Modified:
                    for (int i = 0; i < colCount; i++){
                        Debug.Assert(_records[i].Length > bitIndex);
                        row[i] = _records[i][bitIndex];
                    }
                    dt.Rows.Add(row);
                    row.AcceptChanges();
                    row.BeginEdit();
                    for (int i = 0; i < colCount; i++){
                        Debug.Assert(_records[i].Length > bitIndex + 1);
                        row[i] = _records[i][bitIndex + 1];
                    }
                    row.EndEdit();
                    break;
                case DataRowState.Deleted:
                    for (int i = 0; i < colCount; i++){
                        Debug.Assert(_records[i].Length > bitIndex);
                        row[i] = _records[i][bitIndex];
                    }
                    dt.Rows.Add(row);
                    row.AcceptChanges();
                    row.Delete();
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("Unrecognized row state {0}", rowState));
            }
            return row;
        }

        private void ConvertToSurrogateRowError(DataRow row, int rowIndex){
            Debug.Assert(row != null);
            Debug.Assert(_rowErrors != null);
            Debug.Assert(_colErrors != null);

            if (row.HasErrors){
                _rowErrors.Add(rowIndex, row.RowError);
                DataColumn[] dcArr = row.GetColumnsInError();
                if (dcArr.Length > 0){
                    int[] columnsInError = new int[dcArr.Length];
                    string[] columnErrors = new string[dcArr.Length];
                    for (int i = 0; i < dcArr.Length; i++){
                        columnsInError[i] = dcArr[i].Ordinal;
                        columnErrors[i] = row.GetColumnError(dcArr[i]);
                    }
                    ArrayList list = new ArrayList();
                    list.Add(columnsInError);
                    list.Add(columnErrors);
                    _colErrors.Add(rowIndex, list);
                }
            }
        }

        private void ConvertToRowError(DataRow row, int rowIndex){
            Debug.Assert(row != null);
            Debug.Assert(_rowErrors != null);
            Debug.Assert(_colErrors != null);

            if (_rowErrors.ContainsKey(rowIndex)){
                row.RowError = (string) _rowErrors[rowIndex];
            }
            if (_colErrors.ContainsKey(rowIndex)){
                ArrayList list = (ArrayList) _colErrors[rowIndex];
                int[] columnsInError = (int[]) list[0];
                string[] columnErrors = (string[]) list[1];
                Debug.Assert(columnsInError.Length == columnErrors.Length);
                for (int i = 0; i < columnsInError.Length; i++){
                    row.SetColumnError(columnsInError[i], columnErrors[i]);
                }
            }
        }

        private ArrayList SuppressReadOnly(DataTable dt){
            Debug.Assert(dt != null);
            ArrayList readOnlyList = new ArrayList();
            for (int j = 0; j < dt.Columns.Count; j++){
                if (dt.Columns[j].Expression == String.Empty && dt.Columns[j].ReadOnly == true){
                    readOnlyList.Add(j);
                }
            }
            return readOnlyList;
        }

        private ArrayList SuppressConstraintRules(DataTable dt){
            Debug.Assert(dt != null);
            ArrayList constraintRulesList = new ArrayList();
            DataSet ds = dt.DataSet;
            if (ds != null){
                for (int i = 0; i < ds.Tables.Count; i++){
                    DataTable dtChild = ds.Tables[i];
                    for (int j = 0; j < dtChild.Constraints.Count; j++){
                        Constraint c = dtChild.Constraints[j];
                        if (c is ForeignKeyConstraint){
                            ForeignKeyConstraint fk = (ForeignKeyConstraint) c;
                            if (fk.RelatedTable == dt){
                                ArrayList list = new ArrayList();
                                list.Add(new int[] {i, j});
                                list.Add(new int[] {(int) fk.AcceptRejectRule, (int) fk.UpdateRule, (int) fk.DeleteRule});
                                constraintRulesList.Add(list);

                                fk.AcceptRejectRule = AcceptRejectRule.None;
                                fk.UpdateRule = Rule.None;
                                fk.DeleteRule = Rule.None;
                            }
                        }
                    }
                }
            }
            return constraintRulesList;
        }

        private void ResetReadOnly(DataTable dt, ArrayList readOnlyList){
            Debug.Assert(dt != null);
            Debug.Assert(readOnlyList != null);

            DataSet ds = dt.DataSet;
            foreach (object o in readOnlyList){
                int columnIndex = (int) o;
                Debug.Assert(dt.Columns.Count > columnIndex);
                dt.Columns[columnIndex].ReadOnly = true;
            }
        }

        private void ResetConstraintRules(DataTable dt, ArrayList constraintRulesList){
            Debug.Assert(dt != null);
            Debug.Assert(constraintRulesList != null);

            DataSet ds = dt.DataSet;
            foreach (ArrayList list in constraintRulesList){
                Debug.Assert(list.Count == 2);
                int[] indicesArr = (int[]) list[0];
                int[] rules = (int[]) list[1];

                Debug.Assert(indicesArr.Length == 2);
                int tableIndex = indicesArr[0];
                int constraintIndex = indicesArr[1];

                Debug.Assert(ds.Tables.Count > tableIndex);
                DataTable dtChild = ds.Tables[tableIndex];

                Debug.Assert(dtChild.Constraints.Count > constraintIndex);
                ForeignKeyConstraint fk = (ForeignKeyConstraint) dtChild.Constraints[constraintIndex];

                Debug.Assert(rules.Length == 3);
                fk.AcceptRejectRule = (AcceptRejectRule) rules[0];
                fk.UpdateRule = (Rule) rules[1];
                fk.DeleteRule = (Rule) rules[2];
            }
        }

        private bool IsSchemaIdentical(DataTable dt){
            Debug.Assert(dt != null);

            if (dt.TableName != _tableName || dt.Namespace != _namespace){
                return false;
            }

            Debug.Assert(_dataColumnSurrogates != null);
            if (dt.Columns.Count != _dataColumnSurrogates.Length){
                return false;
            }
            for (int i = 0; i < dt.Columns.Count; i++){
                DataColumn dc = dt.Columns[i];
                DataColumnSurrogate dataColumnSurrogate = _dataColumnSurrogates[i];
                if (!dataColumnSurrogate.IsSchemaIdentical(dc)){
                    return false;
                }
            }
            return true;
        }
    }
}