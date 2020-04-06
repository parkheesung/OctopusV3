using System;
using System.Collections.Generic;
using System.Data;

namespace OctopusV3.Core
{
    public static class DataHelper
    {
        public static SqlDbType fromString(this string typeString)
        {
            if (typeString.Equals("text", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Text;
            else if (typeString.Equals("image", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Image;
            else if (typeString.Equals("uniqueidentifier", StringComparison.OrdinalIgnoreCase)) return SqlDbType.UniqueIdentifier;
            else if (typeString.Equals("date", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Date;
            else if (typeString.Equals("time", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Time;
            else if (typeString.Equals("datetime2", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTime2;
            else if (typeString.Equals("datetimeoffset", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTimeOffset;
            else if (typeString.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.TinyInt;
            else if (typeString.Equals("smallint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallInt;
            else if (typeString.Equals("int", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Int;
            else if (typeString.Equals("smalldatetime", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallDateTime;
            else if (typeString.Equals("real", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Real;
            else if (typeString.Equals("money", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Money;
            else if (typeString.Equals("datetime", StringComparison.OrdinalIgnoreCase)) return SqlDbType.DateTime;
            else if (typeString.Equals("float", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Float;
            else if (typeString.Equals("sql_variant", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Variant;
            else if (typeString.Equals("ntext", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NText;
            else if (typeString.Equals("bit", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Bit;
            else if (typeString.Equals("decimal", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Decimal;
            else if (typeString.Equals("numeric", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Decimal;
            else if (typeString.Equals("smallmoney", StringComparison.OrdinalIgnoreCase)) return SqlDbType.SmallMoney;
            else if (typeString.Equals("bigint", StringComparison.OrdinalIgnoreCase)) return SqlDbType.BigInt;
            else if (typeString.Equals("hierarchyid", StringComparison.OrdinalIgnoreCase)) return SqlDbType.UniqueIdentifier;
            else if (typeString.Equals("geometry", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
            else if (typeString.Equals("geography", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
            else if (typeString.Equals("varbinary", StringComparison.OrdinalIgnoreCase)) return SqlDbType.VarBinary;
            else if (typeString.Equals("varchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.VarChar;
            else if (typeString.Equals("binary", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Binary;
            else if (typeString.Equals("char", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Char;
            else if (typeString.Equals("timestamp", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Timestamp;
            else if (typeString.Equals("nvarchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NVarChar;
            else if (typeString.Equals("nchar", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NChar;
            else if (typeString.Equals("xml", StringComparison.OrdinalIgnoreCase)) return SqlDbType.Xml;
            else if (typeString.Equals("sysname", StringComparison.OrdinalIgnoreCase)) return SqlDbType.NVarChar;
            else return SqlDbType.Binary;
        }

        public static Dictionary<string, string> ToDictionaryString<T>(this List<T> list, string keyColumn, string valueColumn) where T : IEntity
        {
            var result = new Dictionary<string, string>();

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    result.Add(Convert.ToString(item.GetValue(keyColumn)), Convert.ToString(item.GetValue(valueColumn)));
                }
            }

            return result;
        }
    }
}
