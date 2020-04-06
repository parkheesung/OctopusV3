using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusV3.Builder
{
    public static class FindHelper
    {
        public static string IdentityColumn(this List<DbTableInfo> list, string tableName)
        {
            Dictionary<string, int> array = new Dictionary<string, int>();

            foreach (var info in list.Where(x => x.is_identity && x.TableName.Equals(tableName, StringComparison.OrdinalIgnoreCase)))
            {
                array.Add(info.ColumnName, String.Compare("Seq", info.ColumnName, StringComparison.OrdinalIgnoreCase));
            }

            return array.FirstOrDefault(x => x.Value == array.Values.Min()).Key;
        }


        public static string CompareMin(this List<SPEntity> list, string spname, string excludename = "")
        {
            Dictionary<string, int> array = new Dictionary<string, int>();

            foreach (var info in list.Where(x => x.name.Equals(spname, StringComparison.OrdinalIgnoreCase)))
            {
                if (string.IsNullOrWhiteSpace(excludename) || !excludename.Equals(info.TableName, StringComparison.OrdinalIgnoreCase))
                {
                    array.Add(info.TableName, String.Compare(spname, info.TableName, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (!string.IsNullOrWhiteSpace(excludename) && array.Count == 0)
            {
                array.Add(excludename, 1);
            }

            return array.FirstOrDefault(x => x.Value == array.Values.Min()).Key;
        }

        public static string CompareMax(this List<SPEntity> list, string spname, string excludename = "")
        {
            Dictionary<string, int> array = new Dictionary<string, int>();

            foreach (var info in list.Where(x => x.name.Equals(spname, StringComparison.OrdinalIgnoreCase)))
            {
                if (string.IsNullOrWhiteSpace(excludename) || !excludename.Equals(info.TableName, StringComparison.OrdinalIgnoreCase))
                {
                    array.Add(info.TableName, String.Compare(spname, info.TableName, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (!string.IsNullOrWhiteSpace(excludename) && array.Count == 0)
            {
                array.Add(excludename, 1);
            }

            return array.FirstOrDefault(x => x.Value == array.Values.Max()).Key;
        }
    }
}
