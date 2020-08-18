using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Data
{
    public static class QueryHelper
    {
        public static string Select<T>(this List<T> list) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>();
        }

        public static string Select<T>(this List<T> list, string whereStr) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>(whereStr);
        }

        public static string Select<T>(this List<T> list, string whereStr, string orderBy) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>(whereStr, orderBy);
        }

        public static string Select<T>(this T detail) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>(1);
        }

        public static string Select<T>(this T detail, string whereStr) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>(1, whereStr);
        }

        public static string Select<T>(this T detail, string whereStr, string orderBy) where T : IEntity, new()
        {
            return DynamicQuery.Select<T>(1, whereStr, orderBy);
        }

        public static string List<T>(this IDynamicQuery paramData) where T : IEntity, new()
        {
            return DynamicQuery.List<T>(paramData);
        }

        public static string List<T>(this ISubDynamicQuery paramData) where T : IEntity, new()
        {
            return DynamicQuery.List<T>(paramData);
        }

        public static string Count<T>(this IDynamicQueryBase paramData) where T : IEntity, new()
        {
            return DynamicQuery.Count<T>(paramData);
        }

        public static string Count<T>(this List<T> list, string whereStr) where T : IEntity, new()
        {
            return DynamicQuery.Count<T>(whereStr);
        }


        public static string TryReturnValue(this string query)
        {
            StringBuilder builder = new StringBuilder(300);
            builder.AppendLine("BEGIN TRY");
            builder.AppendTabLine(1, query);
            builder.AppendLine("");
            builder.AppendTabLine(1, "SET @Code = @@ROWCOUNT");
            builder.AppendLine("END TRY");
            builder.AppendLine("BEGIN CATCH");
            builder.AppendTabLine(1, "SET @Code = -1");
            builder.AppendTabLine(1, "SET @Value = ''");
            builder.AppendTabLine(1, "SET @Msg = ERROR_MESSAGE()");
            builder.AppendLine("END CATCH");
            return builder.ToString();
        }

        public static string TranReturnValue(this string query)
        {
            StringBuilder builder = new StringBuilder(300);
            builder.AppendLine("Declare @Err int");
            builder.AppendLine("SET @Err = 0");
            builder.AppendLine("");
            builder.AppendLine("BEGIN TRAN");
            builder.AppendTabLine(1, query);
            builder.AppendTabLine(1, "SET @Err = @Err + @@ERROR");
            builder.AppendLine("");
            builder.AppendLine("IF IsNull(@Err,0) > 0");
            builder.AppendTabLine(1, "BEGIN");
            builder.AppendTabLine(2, "ROLLBACK TRAN");
            builder.AppendTabLine(2, "@Code = -1");
            builder.AppendTabLine(2, "IF (@Msg = '')");
            builder.AppendTabLine(3, "SET @Msg = '처리하지 못했습니다.'");
            builder.AppendTabLine(1, "END");
            builder.AppendLine("ELSE");
            builder.AppendTabLine(1, "BEGIN");
            builder.AppendTabLine(2, "COMMIT TRAN");
            builder.AppendTabLine(2, "IF (@Code < 1)");
            builder.AppendTabLine(3, "SET @Code = 1");
            builder.AppendTabLine(1, "END");
            return builder.ToString();
        }
    }

    public class DynamicQuery
    {

        public static string Select<T>() where T : IEntity, new()
        {
            T target = new T();
            return $"select * from {target.TableName} with (nolock)";
        }

        public static string Select<T>(string whereStr) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select * from {target.TableName} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            return builder.ToString();
        }

        public static string Select<T>(string whereStr, string orderBy) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select * from {target.TableName} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                builder.Append($" order by  {orderBy}");
            }
            return builder.ToString();
        }

        public static string Select(string entity, string whereStr, string orderBy)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select * from {entity} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                builder.Append($" order by  {orderBy}");
            }
            return builder.ToString();
        }

        public static string Select<T>(int topCount) where T : IEntity, new()
        {
            T target = new T();
            return $"select top {topCount} * from {target.TableName} with (nolock)";
        }

        public static string Select<T>(int topCount, string whereStr) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select top {topCount} * from {target.TableName} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            return builder.ToString();
        }

        public static string Select<T>(int topCount, string whereStr, string orderBy) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select top {topCount} * from {target.TableName} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                builder.Append($" order by  {orderBy}");
            }
            return builder.ToString();
        }

        public static string Select(string entity, int topCount, string whereStr, string orderBy)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"select top {topCount} * from {entity} with (nolock)");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.Append($" where {whereStr}");
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                builder.Append($" order by  {orderBy}");
            }
            return builder.ToString();
        }

        public static string List(string EntityName, IDynamicQuery paramData)
        {
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT TOP ({paramData.PageSize}) resultTable.* FROM");
            query.Append($"( SELECT TOP ({paramData.PageSize * paramData.CurPage}) ROW_NUMBER () OVER ");
            query.Append($" (ORDER BY { paramData.OrderBy }) AS rownumber, *");
            query.Append($" FROM [{EntityName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            query.Append(") AS resultTable");
            query.Append($" WHERE rownumber > {(paramData.CurPage - 1) * paramData.PageSize}");
            return query.ToString();
        }

        public static string List<T>(IDynamicQuery paramData) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT TOP ({paramData.PageSize}) resultTable.* FROM");
            query.Append($"( SELECT TOP ({paramData.PageSize * paramData.CurPage}) ROW_NUMBER () OVER ");
            if (!string.IsNullOrWhiteSpace(paramData.OrderBy))
            {
                query.Append($" (ORDER BY { paramData.OrderBy }) AS rownumber, *");
            }
            else
            {
                query.Append($" (ORDER BY { target.TargetColumn } desc) AS rownumber, *");
            }
            query.Append($" FROM [{target.TableName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            query.Append(") AS resultTable");
            query.Append($" WHERE rownumber > {(paramData.CurPage - 1) * paramData.PageSize}");
            return query.ToString();
        }

        public static string List(string EntityName, ISubDynamicQuery paramData)
        {
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT TOP ({paramData.SubPageSize}) resultTable.* FROM");
            query.Append($"( SELECT TOP ({paramData.SubPageSize * paramData.SubCurPage}) ROW_NUMBER () OVER ");
            query.Append($" (ORDER BY { paramData.OrderBy }) AS rownumber, *");
            query.Append($" FROM [{EntityName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            query.Append(") AS resultTable");
            query.Append($" WHERE rownumber > {(paramData.SubCurPage - 1) * paramData.SubPageSize}");
            return query.ToString();
        }

        public static string List<T>(ISubDynamicQuery paramData) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT TOP ({paramData.SubPageSize}) resultTable.* FROM");
            query.Append($"( SELECT TOP ({paramData.SubPageSize * paramData.SubCurPage}) ROW_NUMBER () OVER ");
            if (!string.IsNullOrWhiteSpace(paramData.OrderBy))
            {
                query.Append($" (ORDER BY { paramData.OrderBy }) AS rownumber, *");
            }
            else
            {
                query.Append($" (ORDER BY { target.TargetColumn } desc) AS rownumber, *");
            }
            query.Append($" FROM [{target.TableName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            query.Append(") AS resultTable");
            query.Append($" WHERE rownumber > {(paramData.SubCurPage - 1) * paramData.SubPageSize}");
            return query.ToString();
        }

        public static string Count<T>(IDynamicQueryBase paramData) where T : IEntity, new()
        {
            T target = new T();
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT Count(1) FROM [{target.TableName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            return query.ToString();
        }

        public static string Count(string EntityName, IDynamicQueryBase paramData)
        {
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT Count(1) FROM [{EntityName}]");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                query.Append(" where " + paramData.WhereString);
            }
            return query.ToString();
        }

        public static string Count<T>(string whereStr = "") where T : IEntity, new()
        {
            T target = new T();
            StringBuilder query = new StringBuilder(200);
            query.Append($"SELECT Count(1) FROM [{target.TableName}]");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                query.Append(" where " + whereStr);
            }
            return query.ToString();
        }

        public static string GroupBy<T>(string ValueColumn, string whereStr = "") where T : IEntity, new()
        {
            StringBuilder builder = new StringBuilder(200);
            T data = new T();
            builder.AppendLine($"SELECT {ValueColumn},Count(1) as Cnt FROM {data.TableName} with (nolock) ");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                builder.AppendLine($"Where {whereStr}");
            }
            builder.AppendLine($"Group by {ValueColumn}");
            return builder.ToString();
        }

    }
}
