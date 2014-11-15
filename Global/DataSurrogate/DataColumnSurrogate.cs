#region

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;

#endregion

namespace FTS.Global.DataSurrogate{
    [Serializable]
    internal class DataColumnSurrogate{
        private string _columnName;
        private string _namespace;
        private string _prefix;
        private MappingType _columnMapping;
        private bool _allowNull;
        private bool _autoIncrement;
        private long _autoIncrementStep;
        private long _autoIncrementSeed;
        private string _caption;
        private object _defaultValue;
        private bool _readOnly;
        private int _maxLength;
        private Type _dataType;
        private string _expression;

        private Hashtable _extendedProperties;

        public DataColumnSurrogate(DataColumn dc){
            if (dc == null){
                throw new ArgumentNullException("The datacolumn parameter is null");
            }
            _columnName = dc.ColumnName;
            _namespace = dc.Namespace;
            _dataType = dc.DataType;
            _prefix = dc.Prefix;
            _columnMapping = dc.ColumnMapping;
            _allowNull = dc.AllowDBNull;
            _autoIncrement = dc.AutoIncrement;
            _autoIncrementStep = dc.AutoIncrementStep;
            _autoIncrementSeed = dc.AutoIncrementSeed;
            _caption = dc.Caption;
            _defaultValue = dc.DefaultValue;
            _readOnly = dc.ReadOnly;
            _maxLength = dc.MaxLength;
            _expression = dc.Expression;

            _extendedProperties = new Hashtable();
            if (dc.ExtendedProperties.Keys.Count > 0){
                foreach (object propertyKey in dc.ExtendedProperties.Keys){
                    _extendedProperties.Add(propertyKey, dc.ExtendedProperties[propertyKey]);
                }
            }
        }

        public DataColumn ConvertToDataColumn(){
            DataColumn dc = new DataColumn();
            dc.ColumnName = _columnName;
            dc.Namespace = _namespace;
            dc.DataType = _dataType;
            dc.Prefix = _prefix;
            dc.ColumnMapping = _columnMapping;
            dc.AllowDBNull = _allowNull;
            dc.AutoIncrement = _autoIncrement;
            dc.AutoIncrementStep = _autoIncrementStep;
            dc.AutoIncrementSeed = _autoIncrementSeed;
            dc.Caption = _caption;
            dc.DefaultValue = _defaultValue;
            dc.ReadOnly = _readOnly;
            dc.MaxLength = _maxLength;
            Debug.Assert(_extendedProperties != null);
            if (_extendedProperties.Keys.Count > 0){
                foreach (object propertyKey in _extendedProperties.Keys){
                    dc.ExtendedProperties.Add(propertyKey, _extendedProperties[propertyKey]);
                }
            }
            return dc;
        }

        internal void SetColumnExpression(DataColumn dc){
            Debug.Assert(dc != null);

            if (_expression != null && !_expression.Equals(String.Empty)){
                dc.Expression = _expression;
            }
        }

        internal bool IsSchemaIdentical(DataColumn dc){
            Debug.Assert(dc != null);
            if ((dc.ColumnName != _columnName) || (dc.Namespace != _namespace) || (dc.DataType != _dataType) ||
                (dc.Prefix != _prefix) || (dc.ColumnMapping != _columnMapping) ||
                (dc.ColumnMapping != _columnMapping) || (dc.AllowDBNull != _allowNull) ||
                (dc.AutoIncrement != _autoIncrement) || (dc.AutoIncrementStep != _autoIncrementStep) ||
                (dc.AutoIncrementSeed != _autoIncrementSeed) || (dc.Caption != _caption) ||
                (!(AreDefaultValuesEqual(dc.DefaultValue, _defaultValue))) || (dc.MaxLength != _maxLength) ||
                (dc.Expression != _expression)){
                return false;
            }
            return true;
        }

        internal static bool AreDefaultValuesEqual(object o1, object o2){
            if (o1 == null && o2 == null){
                return true;
            } else if (o1 == null || o2 == null){
                return false;
            } else{
                return o1.Equals(o2);
            }
        }
    }
}