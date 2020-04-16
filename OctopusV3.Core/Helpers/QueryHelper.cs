﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OctopusV3.Core
{
    public static class QueryHelper
    {
        public static string toPaging<T>(this IDynamicQuery paramData) where T : IEntity
        {
            StringBuilder builder = new StringBuilder(200);
            T data = default(T);
            builder.AppendLine($"SELECT TOP ({paramData.PageSize}) resultTable.* FROM");
            builder.Append($"( SELECT TOP ({paramData.PageSize * paramData.CurPage}) ROW_NUMBER () OVER (ORDER BY ");
            if (string.IsNullOrWhiteSpace(paramData.OrderBy))
            {
                builder.Append($"{paramData.OrderBy} desc");
            }
            else
            {
                builder.Append(paramData.OrderBy);
            }
            builder.AppendLine($") AS rownumber, * FROM [{data.TableName}] with (nolock)");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                builder.AppendLine($" where {paramData.WhereString}");
            }
            builder.AppendLine(") AS resultTable");
            builder.AppendLine($"WHERE rownumber > {(paramData.CurPage - 1) * paramData.PageSize}");
            return builder.ToString();
        }

        public static string toCount<T>(this IDynamicQuery paramData) where T : IEntity
        {
            StringBuilder builder = new StringBuilder(200);
            T data = default(T);
            builder.AppendLine($"select count(1) from {data.TableName} with (nolock)");
            if (!string.IsNullOrWhiteSpace(paramData.WhereString))
            {
                builder.AppendLine($" where {paramData.WhereString}");
            }
            return builder.ToString();
        }

        public static string toBetween<T>(this List<T> list, string columnName) where T : IEntity
        {
            StringBuilder builder = new StringBuilder(200);

            if (!string.IsNullOrWhiteSpace(columnName))
            {
                if (list != null && list.Count > 0)
                {
                    int num = 0;
                    foreach (T item in list)
                    {
                        if (num > 0) builder.Append(",");
                        builder.Append(item.GetValue(columnName));
                        num++;
                    }
                }
            }

            return builder.ToString();
        }

    }
}
