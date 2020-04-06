using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OctopusV3.Data
{
    public static class MsSqlHelper
    {
        public static DataTable ExecuteTable(this SqlCommand cmd)
        {
            var result = new DataTable();

            using (var adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(result);
            }

            return result;
        }

        public static DataSet ExecuteDataSet(this SqlCommand cmd)
        {
            var result = new DataSet();

            using (var adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(result);
            }

            return result;
        }

        public static List<DataTable> ExecuteTables(this SqlCommand cmd)
        {
            var result = new List<DataTable>();

            var dbset = cmd.ExecuteDataSet();
            if (dbset != null && dbset.Tables != null && dbset.Tables.Count > 0)
            {
                foreach (DataTable tbl in dbset.Tables)
                {
                    result.Add(tbl);
                }
            }

            return result;
        }

        public static List<T> ExecuteList<T>(this SqlCommand cmd) where T : new()
        {
            var result = new List<T>();

            DataTable dt = cmd.ExecuteTable();
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                result = dt.DataToEntity<T>();
            }

            return result;
        }

        public static void AddParameterOutput(this SqlCommand cmd, string name, SqlDbType type, int size = -1)
        {
            cmd.Parameters.Add(name, type, size);
            cmd.Parameters[name].Direction = ParameterDirection.Output;
        }

        public static void AddParameterInput(this SqlCommand cmd, string name, SqlDbType type, object value, int size = -1)
        {
            cmd.Parameters.Add(name, type, size);
            cmd.Parameters[name].Value = value;
        }

        public static void SetReturnValue(this SqlCommand cmd)
        {
            cmd.AddParameterOutput("@Code", SqlDbType.BigInt);
            cmd.AddParameterOutput("@Value", SqlDbType.VarChar, 100);
            cmd.AddParameterOutput("@Msg", SqlDbType.NVarChar, 100);
        }

        public static object GetValue(this SqlCommand cmd, string name)
        {
            return cmd.Parameters[name].Value;
        }

        public static ReturnValue GetReturnValue(this SqlCommand cmd)
        {
            var result = new ReturnValue();
            result.Code = Convert.ToInt64(cmd.GetValue("@Code"));
            result.Value = Convert.ToString(cmd.GetValue("@Value"));
            result.Message = Convert.ToString(cmd.GetValue("@Msg"));
            if (result.Code > 0) result.Check = true;
            return result;
        }

        public static ReturnValue ExecuteReturnValue(this SqlCommand cmd)
        {
            cmd.SetReturnValue();
            cmd.ExecuteNonQuery();
            return cmd.GetReturnValue();
        }

        public static List<SPInfo> GetStoredProcedureInfo(this SqlCommand cmd, string spName)
        {
            cmd.CommandText = SPInfo.CreateSPInfoQuery(spName);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteList<SPInfo>();
        }
    }
}
