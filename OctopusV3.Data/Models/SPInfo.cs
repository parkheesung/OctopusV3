using System;
using System.Data;

namespace OctopusV3.Data
{
    public class SPInfo
    {
        public string name { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public int max_length { get; set; } = -1;

        public bool is_output { get; set; } = false;

        public bool has_default_value { get; set; } = false;

        public bool is_nullable { get; set; } = false;

        public string SPName { get; set; } = string.Empty;

        public string BindType
        {
            get
            {
                if (this.type.Equals("text", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("image", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("uniqueidentifier", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("date", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("time", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("datetime2", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("datetimeoffset", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("smallint", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("int", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("smalldatetime", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("real", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("money", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("datetime", StringComparison.OrdinalIgnoreCase)) return "DateTime";
                else if (this.type.Equals("float", StringComparison.OrdinalIgnoreCase)) return "float";
                else if (this.type.Equals("sql_variant", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("ntext", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("bit", StringComparison.OrdinalIgnoreCase)) return "bool";
                else if (this.type.Equals("decimal", StringComparison.OrdinalIgnoreCase)) return "float";
                else if (this.type.Equals("numeric", StringComparison.OrdinalIgnoreCase)) return "float";
                else if (this.type.Equals("smallmoney", StringComparison.OrdinalIgnoreCase)) return "int";
                else if (this.type.Equals("bigint", StringComparison.OrdinalIgnoreCase)) return "long";
                else if (this.type.Equals("hierarchyid", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("geometry", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("geography", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("varbinary", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("varchar", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("binary", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("char", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("timestamp", StringComparison.OrdinalIgnoreCase)) return "TimeSpan";
                else if (this.type.Equals("nvarchar", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("nchar", StringComparison.OrdinalIgnoreCase)) return "string";
                else if (this.type.Equals("xml", StringComparison.OrdinalIgnoreCase)) return "object";
                else if (this.type.Equals("sysname", StringComparison.OrdinalIgnoreCase)) return "string";
                else return "object";
            }
        }

        public SqlDbType SqlType
        {
            get
            {
                if (this.type.Equals("text", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Text;
                else if (this.type.Equals("image", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Image;
                else if (this.type.Equals("uniqueidentifier", StringComparison.OrdinalIgnoreCase)) return SqlDbType.UniqueIdentifier;
                else if (this.type.Equals("date", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Date;
                else if (this.type.Equals("time", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Time;
                else if (this.type.Equals("datetime2", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTime2;
                else if (this.type.Equals("datetimeoffset", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTimeOffset;
                else if (this.type.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.TinyInt;
                else if (this.type.Equals("smallint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallInt;
                else if (this.type.Equals("int", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Int;
                else if (this.type.Equals("smalldatetime", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallDateTime;
                else if (this.type.Equals("real", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Real;
                else if (this.type.Equals("money", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Money;
                else if (this.type.Equals("datetime", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTime;
                else if (this.type.Equals("float", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Float;
                else if (this.type.Equals("sql_variant", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Variant;
                else if (this.type.Equals("ntext", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NText;
                else if (this.type.Equals("bit", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Bit;
                else if (this.type.Equals("decimal", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Decimal;
                else if (this.type.Equals("numeric", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Decimal;
                else if (this.type.Equals("smallmoney", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallMoney;
                else if (this.type.Equals("bigint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.BigInt;
                else if (this.type.Equals("hierarchyid", StringComparison.OrdinalIgnoreCase)) return SqlDbType.UniqueIdentifier;
                else if (this.type.Equals("geometry", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
                else if (this.type.Equals("geography", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
                else if (this.type.Equals("varbinary", StringComparison.OrdinalIgnoreCase)) return SqlDbType.VarBinary;
                else if (this.type.Equals("varchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.VarChar;
                else if (this.type.Equals("binary", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
                else if (this.type.Equals("char", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Char;
                else if (this.type.Equals("timestamp", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Timestamp;
                else if (this.type.Equals("nvarchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NVarChar;
                else if (this.type.Equals("nchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NChar;
                else if (this.type.Equals("xml", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Xml;
                else if (this.type.Equals("sysname", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NVarChar;
                else return SqlDbType.Binary;
            }
        }

        public SPInfo()
        {
        }

        public static string CreateSPInfoQuery(string spName)
        {
            return $@"
select
	A.[name]
,	B.[name] as [type]
,	A.max_length
,	A.is_output
,	A.has_default_value
,	A.is_nullable
from sys.parameters as A with (nolock)
inner join sys.types as B with (nolock) on A.system_type_id = B.system_type_id and A.user_type_id = B.user_type_id 
inner join sys.procedures as C with (nolock) on A.[object_id] = C.[object_id] 
where C.[name] = '{spName}'
order by A.parameter_id asc
";
        }
    }
}
