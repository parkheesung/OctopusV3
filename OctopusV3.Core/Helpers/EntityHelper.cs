using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OctopusV3.Core
{
    public static class EntityHelper
    {
        private static PropertyInfo[] GetProperties<T>()
        {
            Type type = typeof(T);
            return type.GetProperties();
        }

        public static EntityAttribute GetEntity(this PropertyInfo property)
        {
            EntityAttribute result = null;

            EntityAttribute temp;
            foreach (var attr in property.GetCustomAttributes())
            {
                temp = attr as EntityAttribute;
                if (temp != null)
                {
                    result = temp;
                    break;
                }
            }

            return result;
        }

        public static bool ExistsColumn<T>(this T entity, string columnName) where T : IEntity
        {
            bool result = false;

            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityAttribute temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static object GetValue<T>(this T entity, string columnName) where T : IEntity
        {
            object result = null;

            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityAttribute temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    result = property.GetValue(entity);
                    break;
                }
            }

            return result;
        }

        public static SqlDbType GetType<T>(this T entity, string columnName) where T : IEntity
        {
            SqlDbType result = SqlDbType.VarChar;

            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityAttribute temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    result = temp.Type;
                    break;
                }
            }

            return result;
        }

        public static int GetSize<T>(this T entity, string columnName) where T : IEntity
        {
            int result = -1;

            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityAttribute temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    result = temp.Size;
                    break;
                }
            }

            return result;
        }

        public static void SetValue<T>(this T entity, string columnName, object Value) where T : IEntity
        {
            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityAttribute temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        property.SetValue(entity, Value);
                    }
                    catch
                    {
                        if (Value.ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(entity, true);
                        }
                        else if (Value.ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(entity, false);
                        }
                    }
                    break;
                }
            }
        }

        public static List<EntityAttribute> GetEntities<T>(this T target) where T : IEntity
        {
            List<EntityAttribute> result = new List<EntityAttribute>();

            Type type = typeof(T);

            var members = type.GetMembers();
            EntityAttribute temp;
            foreach (var member in members)
            {
                foreach (var attr in member.GetCustomAttributes())
                {
                    try
                    {
                        temp = attr as EntityAttribute;
                        if (temp != null)
                        {
                            result.Add(temp);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return result;
        }

        public static List<T> DataToEntity<T>(this DataTable data) where T : new()
        {
            var result = new List<T>();
            var properties = GetProperties<T>();
            var columns = data.Columns.Cast<DataColumn>().ToList();
            T item;
            foreach (DataRow row in data.Rows)
            {
                item = new T();
                DataColumn column;
                foreach (var property in properties)
                {
                    try
                    {
                        column = columns.Find(x => x.ColumnName == property.Name);
                        if (column != null && row[property.Name] != null && row[property.Name] != DBNull.Value)
                        {
                            property.SetValue(item, row[property.Name], null);
                        }
                    }
                    catch
                    {

                    }
                }

                result.Add(item);
            }

            return result;
        }

        public static List<T> PropertyToEntity<T>(this DataTable data) where T : new()
        {
            var result = new List<T>();
            var properties = GetProperties<T>();
            var columns = data.Columns.Cast<DataColumn>().ToList();
            T item;
            foreach (var property in properties)
            {
                item = new T();
                DataColumn column = null;
                foreach (DataRow row in data.Rows)
                {
                    try
                    {
                        column = columns.Find(x => x.ColumnName == property.Name);
                        if (column != null && row[property.Name] != null && row[property.Name] != DBNull.Value)
                        {
                            property.SetValue(item, row[property.Name], null);
                        }
                    }
                    catch
                    {

                    }
                }

                result.Add(item);
            }

            return result;
        }

    }
}
