using System;
using System.Data;

namespace OctopusV3.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityAttribute : Attribute
    {
        public string ColumnName { get; set; } = string.Empty;
        public SqlDbType Type { get; set; }
        public int Size { get; set; } = -1;

        public EntityAttribute(string columnName, SqlDbType dbType, int size = -1)
        {
            this.ColumnName = columnName;
            this.Type = dbType;
            this.Size = size;
        }
    }
}
