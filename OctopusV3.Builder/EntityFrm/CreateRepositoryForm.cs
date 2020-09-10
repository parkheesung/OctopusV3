using OctopusV3.Core;
using OctopusV3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class CreateRepositoryForm : Form
    {
        protected string Content { get; set; } = string.Empty;

        protected MainForm main { get; set; }

        protected List<SPEntity> sps { get; set; } = new List<SPEntity>();
        protected List<SPEntity> withTable { get; set; } = new List<SPEntity>();

        protected List<SPInfo> spParams { get; set; } = new List<SPInfo>();

        protected List<ObjectEntity> tables { get; set; } = new List<ObjectEntity>();

        protected List<DbTableInfo> tableColumns { get; set; } = new List<DbTableInfo>();

        protected List<string> methods { get; set; } = new List<string>();

        public CreateRepositoryForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;

            methods.Add("select");
            methods.Add("list");
            methods.Add("count");
            methods.Add("update");
            methods.Add("insert");
            methods.Add("delete");
        }

        public void MsgClear()
        {
            if (TB_Output.InvokeRequired)
            {
                TB_Output.BeginInvoke(new Action(() => {
                    TB_Output.Clear();
                }));
            }
            else
            {
                TB_Output.Clear();
            }
        }

        public void MsgWrite(string msg)
        {
            if (TB_Output.InvokeRequired)
            {
                TB_Output.BeginInvoke(new Action(() => {
                    TB_Output.AppendText(msg);
                    TB_Output.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                TB_Output.AppendText(msg);
                TB_Output.AppendText(Environment.NewLine);
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Position.Text = di.SelectedPath;
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            bool IsSP = Chk_SP.Checked;
            bool IsTable = Chk_Table.Checked;
            bool IsInterface = Chk_Interface.Checked;
            string NameSpace = TB_NameSpace.Text;
            string Prefix = TB_Name.Text;
            string FilePath = TB_Position.Text;

            MsgClear();

            string file_base = Path.Combine(FilePath, $"BaseRepository.cs");
            if (FileHelper.WriteFile(file_base, CreateBaseRepository(NameSpace), Encoding.UTF8, false))
            {
                MsgWrite("BaseRepository.cs 파일을 생성했습니다.");
            }
            else
            {
                MsgWrite("BaseRepository.cs 파일 생성이 실패하였습니다.");
            }

            if (IsInterface)
            {
                string file = Path.Combine(FilePath, $"IBaseRepository.cs");
                if (FileHelper.WriteFile(file, CreateBaseInterface(NameSpace), Encoding.UTF8, false))
                {
                    MsgWrite($"IBaseRepository.cs 파일을 생성했습니다.");
                }
                else
                {
                    MsgWrite($"IBaseRepository.cs 파일 생성이 실패하였습니다.");
                }
            }


            if (IsTable)
            {
                string file = Path.Combine(FilePath, $"DefaultRepository.cs");
                if (FileHelper.WriteFile(file, CreateDefaultRepository(NameSpace), Encoding.UTF8, false))
                {
                    MsgWrite("DefaultRepository.cs 파일을 생성했습니다.");

                    if (IsInterface)
                    {
                        file = Path.Combine(FilePath, $"IDefaultRepository.cs");
                        if (FileHelper.WriteFile(file, CreateDefaultInterface(NameSpace), Encoding.UTF8, false))
                        {
                            MsgWrite($"IDefaultRepository.cs 파일을 생성했습니다.");
                        }
                        else
                        {
                            MsgWrite($"IDefaultRepository.cs 파일 생성이 실패하였습니다.");
                        }
                    }
                }
                else
                {
                    MsgWrite("DefaultRepository.cs 파일 생성이 실패하였습니다.");
                }
            }

            if (IsSP)
            {
                string file = Path.Combine(FilePath, $"{Prefix}Repository.cs");
                if (FileHelper.WriteFile(file, CreateSpRepository(NameSpace, $"{Prefix}Repository", IsTable), Encoding.UTF8, false))
                {
                    MsgWrite($"{Prefix}Repository.cs 파일을 생성했습니다.");
                    file = Path.Combine(FilePath, $"I{Prefix}Repository.cs");
                    if (FileHelper.WriteFile(file, CreateSpInterface(NameSpace, $"I{Prefix}Repository", IsTable), Encoding.UTF8, false))
                    {
                        MsgWrite($"I{Prefix}Repository.cs 파일을 생성했습니다.");

                    }
                    else
                    {
                        MsgWrite($"I{Prefix}Repository.cs 파일 생성이 실패하였습니다.");
                    }
                }
                else
                {
                    MsgWrite($"{Prefix}Repository.cs 파일 생성이 실패하였습니다.");
                }
            }


        }

        protected virtual string CreateBaseRepository(string NameSpace)
        {
            bool IsInterface = Chk_Interface.Checked;
            string InterfaceString = (IsInterface) ? "IBaseRepository, " : "";

            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Data.SqlClient;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using OctopusV3.Data;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTabLine(1, $"public class BaseRepository : {InterfaceString}IDisposable");
            builder.AppendTabLine(1, "{");
            builder.AppendTabLine(2, "private bool disposedValue = false;");
            builder.AppendTabLine(2, "public SqlConnection SqlConn { get; set; }");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public ILogHelper Logger { get; set; }");
            builder.AppendLine("");
            builder.AppendTabLine(2, $"public BaseRepository()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public SqlConnection Connection { get { return this.SqlConn; } set { this.SqlConn = value; } }");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public void Open(string connStr)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "this.SqlConn = new SqlConnection(connStr);");
            builder.AppendTabLine(3, "this.SqlConn.Open();");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public void Close()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "if (this.SqlConn != null && this.SqlConn.State == System.Data.ConnectionState.Open)");
            builder.AppendTabLine(3, "{");
            builder.AppendTabLine(4, "this.SqlConn.Close();");
            builder.AppendTabLine(3, "}");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "protected virtual void Dispose(bool disposing)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "if (!disposedValue)");
            builder.AppendTabLine(3, "{");
            builder.AppendTabLine(4, "if (disposing)");
            builder.AppendTabLine(4, "{");
            builder.AppendTabLine(5, "if (this.SqlConn != null)");
            builder.AppendTabLine(5, "{");
            builder.AppendTabLine(6, "this.SqlConn.Dispose();");
            builder.AppendTabLine(5, "}");
            builder.AppendTabLine(4, "}");
            builder.AppendTabLine(3, "}");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, $"~BaseRepository()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "Dispose(false);");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public void Dispose()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "Dispose(true);");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public DataTable ExecuteTable(string query)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "DataTable result = null;");
            builder.AppendLine("");
            builder.AppendTabLine(3, "using(var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(3, "{");
            builder.AppendTabLine(4, "cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(4, "result = cmd.ExecuteTable();");
            builder.AppendTabLine(3, "}");
            builder.AppendLine("");
            builder.AppendTabLine(3, "return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(2, "public int ExecuteCount(string query)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(3, "int result = 0;");
            builder.AppendLine("");
            builder.AppendTabLine(3, "using(var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(3, "{");
            builder.AppendTabLine(4, "cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(4, "result = Convert.ToInt32(cmd.ExecuteScalar());");
            builder.AppendTabLine(3, "}");
            builder.AppendLine("");
            builder.AppendTabLine(3, "return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendLine("");
            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        protected virtual string CreateSpRepository(string NameSpace, string ClassName, bool IsTable)
        {
            bool IsInterface = Chk_Interface.Checked;
            string InterfaceString = (IsInterface) ? $", I{ClassName}" : "";

            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data.SqlClient;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using OctopusV3.Data;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTab(1, $"public class {ClassName} : ");
            if (IsTable)
            {
                builder.AppendLine($"DefaultRepository{InterfaceString}");
            }
            else
            {
                builder.AppendLine($"BaseRepository{InterfaceString}");
            }
            builder.AppendTabLine(1, "{");

            builder.AppendTabLine(2, $"public {ClassName}() : base()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "}");

            if (sps != null && sps.Count > 0)
            {
                int num = 0;
                string rtnValue = string.Empty;
                string tableName = string.Empty;
                string paramObject = string.Empty;

                foreach (SPEntity sp in sps)
                {
                    tableName = "";
                    rtnValue = "";
                    paramObject = "";
                    builder.AppendLine("");
                    builder.AppendTab(2, "public ");
                    if (spParams != null && spParams.Count > 0)
                    {
                        if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase))
                                        .Where(x => x.name.Equals("@Code", StringComparison.OrdinalIgnoreCase)
                                                || x.name.Equals("@Msg", StringComparison.OrdinalIgnoreCase)
                                                || x.name.Equals("@Value", StringComparison.OrdinalIgnoreCase)
                        ).Count() > 0)
                        {
                            builder.Append("ReturnValue ");
                            rtnValue = "var result = new ReturnValue();";
                        }
                        else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() == 1)
                        {
                            tableName = withTable.CompareMin(sp.name, "Member");
                            builder.Append($"List<{tableName}> ");
                            rtnValue = $"var result = new List<{tableName}>();";
                        }
                        else
                        {
                            builder.Append("object ");
                            rtnValue = "object result = null;";
                        }
                        builder.Append($"{sp.methodName}(");

                        if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                        {
                            if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output).Count() <= 3)
                            {
                                num = 0;
                                foreach (var info in spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output))
                                {
                                    if (num > 0) builder.Append(",");
                                    builder.Append($"{info.BindType} {info.name.Replace("@", "")}");
                                    num++;
                                }
                            }
                            else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() == 1)
                            {
                                tableName = withTable.CompareMin(sp.name, "Member");
                                paramObject = tableName.ToLower();
                                builder.Append($"{tableName} {tableName.ToLower()}");
                            }
                            else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => sp.name.IndexOf(x.name) > -1).Count() == 1)
                            {
                                tableName = withTable.CompareMin(sp.name, "Member");
                                paramObject = tableName.ToLower();
                                builder.Append($"{tableName} {tableName.ToLower()}");
                            }
                            else
                            {
                                num = 0;
                                foreach (var info in spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output))
                                {
                                    if (num > 0) builder.Append(",");
                                    builder.Append($"{info.BindType} {info.name.Replace("@", "")}");
                                    num++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                        {
                            tableName = withTable.CompareMin(sp.name, "Member");
                            if (!string.IsNullOrWhiteSpace(tableName))
                            {
                                builder.Append($"List<{tableName}> ");
                                rtnValue = $"var result = new List<{tableName}>();";
                            }
                            else
                            {
                                builder.Append("void ");
                            }
                        }
                        else
                        {
                            builder.Append("void ");
                        }

                        builder.Append($"{sp.methodName}(");
                    }

                    builder.AppendLine(")");
                    builder.AppendTabLine(2, "{");
                    if (!string.IsNullOrWhiteSpace(rtnValue)) builder.AppendTabLine(3, rtnValue);
                    builder.AppendLine("");
                    builder.AppendTabLine(3, "try");
                    builder.AppendTabLine(3, "{");
                    builder.AppendTabLine(4, $"using (var cmd = new SqlCommand(\"{sp.name}\", this.SqlConn))");
                    builder.AppendTabLine(4, "{");
                    builder.AppendTabLine(5, "cmd.CommandType = System.Data.CommandType.StoredProcedure;");

                    if (spParams != null && spParams.Count > 0)
                    {
                        foreach (SPInfo info in spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (info.is_output)
                            {
                                if ((!string.IsNullOrWhiteSpace(rtnValue) && rtnValue.IndexOf("ReturnValue") > -1
                                        && (info.name.Equals("@Code", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Value", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Msg", StringComparison.OrdinalIgnoreCase))) == false)
                                {
                                    builder.AppendTabLine(5, $"cmd.AddParameterOutput(\"{info.name}\", System.Data.SqlDbType.{info.SqlType.ToString()}, {info.max_length});");
                                }
                            }
                            else
                            {
                                builder.AppendTabLine(5, $"cmd.AddParameterInput(\"{info.name}\", System.Data.SqlDbType.{info.SqlType.ToString()}, {paramObjectName(paramObject)}{info.name.Replace("@", "")}, {info.max_length});");
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(rtnValue) && rtnValue.IndexOf("ReturnValue") > -1)
                    {
                        builder.AppendTabLine(5, "result = cmd.ExecuteReturnValue();");
                    }
                    else if (!string.IsNullOrWhiteSpace(tableName) && rtnValue.IndexOf("List") > -1)
                    {
                        builder.AppendTabLine(5, $"result = cmd.ExecuteList<{tableName}>();");
                    }
                    else if (!string.IsNullOrWhiteSpace(rtnValue) && rtnValue.IndexOf("object") > -1)
                    {
                        builder.AppendTabLine(5, $"result = cmd.ExecuteScalar();");
                    }
                    else
                    {
                        builder.AppendTabLine(5, "cmd.ExecuteNonQuery();");
                        builder.AppendTabLine(5, "result.Success(1);");
                    }
                    builder.AppendTabLine(4, "}");
                    builder.AppendTabLine(3, "}");
                    builder.AppendTabLine(3, "catch (Exception ex)");
                    builder.AppendTabLine(3, "{");
                    builder.AppendTabLine(4, "if (this.Logger != null) this.Logger.Error(ex);");
                    
                    if (!string.IsNullOrWhiteSpace(rtnValue) && rtnValue.IndexOf("ReturnValue") > -1)
                    {
                        builder.AppendTabLine(4, "result.Error(ex);");
                    }
                    builder.AppendTabLine(3, "}");
                    builder.AppendLine("");
                    if (!string.IsNullOrWhiteSpace(rtnValue)) builder.AppendTabLine(3, "return result;");
                    builder.AppendTabLine(2, "}");
                }
            }

            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        protected virtual string CreateSpInterface(string NameSpace, string ClassName, bool IsTable)
        {
            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data.SqlClient;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using OctopusV3.Data;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTab(1, $"public interface {ClassName} : ");
            if (IsTable)
            {
                builder.AppendLine("IDefaultRepository");
            }
            else
            {
                builder.AppendLine("IBaseRepository");
            }
            builder.AppendTabLine(1, "{");

            if (sps != null && sps.Count > 0)
            {
                int num = 0;
                string rtnValue = string.Empty;
                string tableName = string.Empty;
                string paramObject = string.Empty;

                foreach (SPEntity sp in sps)
                {
                    tableName = "";
                    rtnValue = "";
                    paramObject = "";
                    builder.AppendLine("");
                    builder.AppendTab(2, "");
                    if (spParams != null && spParams.Count > 0)
                    {
                        if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase))
                                        .Where(x => x.name.Equals("@Code", StringComparison.OrdinalIgnoreCase)
                                                || x.name.Equals("@Msg", StringComparison.OrdinalIgnoreCase)
                                                || x.name.Equals("@Value", StringComparison.OrdinalIgnoreCase)
                        ).Count() > 0)
                        {
                            builder.Append("ReturnValue ");
                            rtnValue = "var result = new ReturnValue();";
                        }
                        else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() == 1)
                        {
                            tableName = withTable.CompareMin(sp.name, "Member");
                            builder.Append($"List<{tableName}> ");
                            rtnValue = $"var result = new List<{tableName}>();";
                        }
                        else
                        {
                            builder.Append("object ");
                            rtnValue = "object result = null;";
                        }
                        builder.Append($"{sp.methodName}(");

                        if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                        {
                            if (spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output).Count() <= 3)
                            {
                                num = 0;
                                foreach (var info in spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output))
                                {
                                    if (num > 0) builder.Append(",");
                                    builder.Append($"{info.BindType} {info.name.Replace("@", "")}");
                                    num++;
                                }
                            }
                            else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() == 1)
                            {
                                tableName = withTable.CompareMin(sp.name, "Member");
                                paramObject = tableName.ToLower();
                                builder.Append($"{tableName} {tableName.ToLower()}");
                            }
                            else if (withTable != null && withTable.Count() > 0 && withTable.Where(x => sp.name.IndexOf(x.name) > -1).Count() == 1)
                            {
                                tableName = withTable.CompareMin(sp.name, "Member");
                                paramObject = tableName.ToLower();
                                builder.Append($"{tableName} {tableName.ToLower()}");
                            }
                            else
                            {
                                num = 0;
                                foreach (var info in spParams.Where(x => x.SPName.Equals(sp.name, StringComparison.OrdinalIgnoreCase) && !x.is_output))
                                {
                                    if (num > 0) builder.Append(",");
                                    builder.Append($"{info.BindType} {info.name.Replace("@", "")}");
                                    num++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (withTable != null && withTable.Count() > 0 && withTable.Where(x => x.name.Equals(sp.name, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                        {
                            tableName = withTable.CompareMin(sp.name, "Member");
                            if (!string.IsNullOrWhiteSpace(tableName))
                            {
                                builder.Append($"List<{tableName}> ");
                                rtnValue = $"var result = new List<{tableName}>();";
                            }
                            else
                            {
                                builder.Append("void ");
                            }
                        }
                        else
                        {
                            builder.Append("void ");
                        }

                        builder.Append($"{sp.methodName}(");
                    }

                    builder.AppendLine(");");
                }
            }

            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        protected virtual string CreateDefaultRepository(string NameSpace)
        {
            bool IsInterface = Chk_Interface.Checked;
            string InterfaceString = (IsInterface) ? ", IDefaultRepository" : "";

            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using System.Data.SqlClient;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using OctopusV3.Data;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTabLine(1, $"public class DefaultRepository : BaseRepository{InterfaceString}");
            builder.AppendTabLine(1, "{");

            builder.AppendTabLine(2, $"public DefaultRepository() : base()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "}");

            #region [ COMMON ]
            builder.AppendTabLine(2, "public ReturnValue ExecuteReturnValue(string query)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	ReturnValue result = new ReturnValue();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public ReturnValue Erase<T>(string whereStr) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	var result = new ReturnValue();");
            builder.AppendTabLine(2, "	T obj = new T();");
            builder.AppendTabLine(2, "	string query = $\"delete from {obj.TableName} where {whereStr}\".TryReturnValue();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> ExecuteModel<T>(string query) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public T Single<T>(string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	T result = new T();");
            builder.AppendTabLine(2, "	string query = result.Select(whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>().FirstOrDefault();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public T Single<T>(string entity, string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	T result = new T();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Select(entity, 1, whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>().FirstOrDefault();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> Select<T>(string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = result.Select(whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> Select<T>(string entity, string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Select(entity, whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> Select<T>(string entity, int TopCount, string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Select(entity, TopCount, whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> Select<T>(int TopCount, string whereStr, string OrderStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Select<T>(TopCount, whereStr, OrderStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> Select<T>() where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = result.Select();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> List<T>(IDynamicQuery paramData) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = paramData.List<T>();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> List<T>(string entity, IDynamicQuery paramData) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	if (string.IsNullOrWhiteSpace(paramData.OrderBy)) throw new ArgumentException(\"Entity 이름으로 쿼리를 생성할 떈, PagingParamBase 클래스의 OrderBy 인자가 필수값입니다.\");");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.List(entity, paramData);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> List<T>(ISubDynamicQuery paramData) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = paramData.List<T>();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> List<T>(string entity, ISubDynamicQuery paramData) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	if (string.IsNullOrWhiteSpace(paramData.OrderBy)) throw new ArgumentException(\"Entity 이름으로 쿼리를 생성할 떈, PagingParamBase 클래스의 OrderBy 인자가 필수값입니다.\");");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.List(entity, paramData);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public int Count<T>(IDynamicQueryBase paramData) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	int result = 0;");
            builder.AppendTabLine(2, "	string query = paramData.Count<T>();");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = Convert.ToInt32(cmd.ExecuteScalar());");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public int Count<T>(string whereStr) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	int result = 0;");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Count<T>(whereStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = Convert.ToInt32(cmd.ExecuteScalar());");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public int Count(string entity, IDynamicQueryBase paramData)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	int result = 0;");
            builder.AppendTabLine(2, "	string query = DynamicQuery.Count(entity, paramData);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = Convert.ToInt32(cmd.ExecuteScalar());");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public ReturnValue Update<T>(string where, Dictionary<string, object> data) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	var result = new ReturnValue();");
            builder.AppendTabLine(2, "	T obj = new T();");
            builder.AppendTabLine(2, "	StringBuilder query = new StringBuilder();");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"UPDATE [{obj.TableName}] SET\");");
            builder.AppendTabLine(2, "	int num = 0;");
            builder.AppendTabLine(2, "	foreach (var item in data)");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		if (num > 0) query.Append(\",\");");
            builder.AppendTabLine(2, "		query.AppendLine($\"[{item.Key}] = @{item.Key}\");");
            builder.AppendTabLine(2, "		num++;");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	query.AppendLine($\"where {where}\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = @@ROWCOUNT\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin catch\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = -1\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ERROR_MESSAGE()\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end catch\");");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query.ToString());");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(2, "		foreach (var item in data)");
            builder.AppendTabLine(2, "		{");
            builder.AppendTabLine(2, "			cmd.AddParameterInput($\"@{item.Key}\", obj.GetType(item.Key), item.Value, obj.GetSize(item.Key));");
            builder.AppendTabLine(2, "		}");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public ReturnValue Update<T>(string where, string Key, object Value) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	var result = new ReturnValue();");
            builder.AppendTabLine(2, "	T obj = new T();");
            builder.AppendTabLine(2, "	StringBuilder query = new StringBuilder();");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"UPDATE [{obj.TableName}] SET\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"[{Key}] = @{Key}\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"where {where}\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = @@ROWCOUNT\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin catch\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = -1\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ERROR_MESSAGE()\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end catch\");");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query.ToString());");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(2, "		cmd.AddParameterInput($\"@{Key}\", obj.GetType(Key), Value, obj.GetSize(Key));");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public ReturnValue Update(string entity, string where, string Key, object Value)");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	var result = new ReturnValue();");
            builder.AppendTabLine(2, "	StringBuilder query = new StringBuilder();");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"UPDATE [{entity}] SET\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"[{Key}] = '{Value}'\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"where {where}\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = @@ROWCOUNT\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin catch\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = -1\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ERROR_MESSAGE()\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end catch\");");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query.ToString());");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public ReturnValue Update<T>(string entity, string where, Dictionary<string, object> data) where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	var result = new ReturnValue();");
            builder.AppendTabLine(2, "	T obj = new T();");
            builder.AppendTabLine(2, "	StringBuilder query = new StringBuilder();");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"UPDATE [{entity}] SET\");");
            builder.AppendTabLine(2, "	int num = 0;");
            builder.AppendTabLine(2, "	foreach (var item in data)");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		if (num > 0) query.Append(\",\");");
            builder.AppendTabLine(2, "		query.AppendLine($\"[{item.Key}] = @{item.Key}\");");
            builder.AppendTabLine(2, "		num++;");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	query.AppendLine($\"where {where}\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = @@ROWCOUNT\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end try\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"begin catch\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Code = -1\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Msg = ERROR_MESSAGE()\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"SET @Value = ''\");");
            builder.AppendTabLine(2, "	query.AppendLine($\"end catch\");");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query.ToString());");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = CommandType.Text;");
            builder.AppendTabLine(2, "		foreach (var item in data)");
            builder.AppendTabLine(2, "		{");
            builder.AppendTabLine(2, "			cmd.AddParameterInput($\"@{item.Key}\", obj.GetType(item.Key), item.Value, obj.GetSize(item.Key));");
            builder.AppendTabLine(2, "		}");
            builder.AppendTabLine(2, "		result = cmd.ExecuteReturnValue();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "public List<T> GroupBy<T>(string ValueColumn, string whereStr = \"\") where T : IEntity, new()");
            builder.AppendTabLine(2, "{");
            builder.AppendTabLine(2, "	List<T> result = new List<T>();");
            builder.AppendTabLine(2, "	string query = DynamicQuery.GroupBy<T>(ValueColumn, whereStr);");
            builder.AppendTabLine(2, "	if (this.Logger != null) this.Logger.Info(query);");
            builder.AppendTabLine(2, "	using (var cmd = new SqlCommand(query, this.SqlConn))");
            builder.AppendTabLine(2, "	{");
            builder.AppendTabLine(2, "		cmd.CommandType = System.Data.CommandType.Text;");
            builder.AppendTabLine(2, "		result = cmd.ExecuteList<T>();");
            builder.AppendTabLine(2, "	}");
            builder.AppendTabLine(2, "	return result;");
            builder.AppendTabLine(2, "}");

            #endregion [ COMMON ]

            #region [ Legacy ]
            /*
            if (tables != null && tables.Count > 0)
            {
                string identityColumn = string.Empty;
                string paramObject = string.Empty;
                int num = 0;

                foreach (ObjectEntity table in tables)
                {
                    paramObject = "";
                    identityColumn = tableColumns.IdentityColumn(table.name);

                    foreach (string method in methods)
                    {
                        num = 0;
                        builder.AppendLine("");

                        switch (method)
                        {
                            case "select":
                                builder.AppendTab(2, $"public List<{table.name}> {table.name}_{method.ToUpper()}(QueryParamBase paramData");
                                break;
                            case "list":
                                builder.AppendTab(2, $"public List<{table.name}> {table.name}_{method.ToUpper()}(PagingParamBase paramData");
                                break;
                            case "count":
                                builder.AppendTab(2, $"public int {table.name}_{method.ToUpper()}(QueryParamBase paramData");
                                break;
                            case "update":
                                builder.AppendTab(2, $"public ReturnValue {table.name}_{method.ToUpper()}(");
                                builder.Append($"{table.name} {table.name.ToLower()}");
                                paramObject = table.name.ToLower();
                                break;
                            case "insert":
                                builder.AppendTab(2, $"public ReturnValue {table.name}_{method.ToUpper()}(");
                                builder.Append($"{table.name} {table.name.ToLower()}");
                                paramObject = table.name.ToLower();
                                break;
                            case "delete":
                                builder.AppendTab(2, $"public ReturnValue {table.name}_{method.ToUpper()}(");
                                if (tableColumns != null && tableColumns.Count > 0)
                                {
                                    num = 0;
                                    foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                           .Where(x => x.is_identity))
                                    {
                                        if (num > 0) builder.Append(",");
                                        builder.Append($"{info.ObjectType} {info.Name}");
                                        num++;
                                    }
                                }
                                break;
                        }
                        builder.AppendLine(")");
                        builder.AppendTabLine(2, "{");
                        switch (method)
                        {
                            case "select":
                            case "list":
                                builder.AppendTabLine(3, $"var result = new List<{table.name}>();");
                                break;
                            case "count":
                                builder.AppendTabLine(3, $"int result = 0;");
                                break;
                            case "update":
                                builder.AppendTabLine(3, "var result = new ReturnValue();");
                                break;
                            case "insert":
                                builder.AppendTabLine(3, "var result = new ReturnValue();");
                                break;
                            case "delete":
                                builder.AppendTabLine(3, "var result = new ReturnValue();");
                                break;
                        }
                        builder.AppendLine("");
                        builder.AppendTabLine(3, "try");
                        builder.AppendTabLine(3, "{");
                        builder.AppendTabLine(4, "StringBuilder query = new StringBuilder(200);");
                        num = 0;
                        switch (method)
                        {
                            case "select":
                                builder.AppendTabLine(4, $"query.Append(\"select * from [{table.name}] with (nolock)\");");
                                builder.AppendTabLine(4, $"if (!string.IsNullOrWhiteSpace(paramData.WhereString))");
                                builder.AppendTabLine(4, "{");
                                builder.AppendTabLine(5, $"query.Append(\" where \" + paramData.WhereString);");
                                builder.AppendTabLine(4, "}");
                                break;
                            case "count":
                                builder.AppendTabLine(4, $"query.Append(\"select (1) from [{table.name}] with (nolock)\");");
                                builder.AppendTabLine(4, $"if (!string.IsNullOrWhiteSpace(paramData.WhereString))");
                                builder.AppendTabLine(4, "{");
                                builder.AppendTabLine(5, $"query.Append(\" where \" + paramData.WhereString);");
                                builder.AppendTabLine(4, "}");
                                break;
                            case "list":
                                builder.AppendTabLine(4, $"query.Append(\"SELECT TOP (@PageSize) resultTable.* FROM\");");
                                builder.AppendTabLine(4, $"query.Append(\"( SELECT TOP (@PageSize * @CurPage) ROW_NUMBER () OVER (ORDER BY {identityColumn} \" + paramData.OrderBy + \" ) AS rownumber, \");");
                                builder.AppendTabLine(4, $"query.Append(\"FROM [{table.name}]\");");
                                builder.AppendTabLine(4, $"if (!string.IsNullOrWhiteSpace(paramData.WhereString))");
                                builder.AppendTabLine(4, "{");
                                builder.AppendTabLine(5, $"query.Append(\" where \" + paramData.WhereString);");
                                builder.AppendTabLine(4, "}");
                                builder.AppendTabLine(4, $"query.Append(\") AS resultTable\");");
                                builder.AppendTabLine(4, $"query.Append(\"WHERE rownumber > (@CurPage - 1) * @PageSize\");");
                                break;
                            case "update":
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"update [{table.name}] set\");");
                                if (tableColumns != null && tableColumns.Count > 0)
                                {
                                    num = 0;
                                    foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                           .Where(x => !x.is_identity))
                                    {
                                        builder.AppendTab(4, "query.AppendLine(\"");
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"{info.Name}=@{info.Name}\");");
                                        num++;
                                    }
                                    num = 0;
                                    foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                           .Where(x => x.is_identity))
                                    {
                                        builder.AppendTab(4, "query.AppendLine(\"");
                                        if (num > 0) builder.Append(" and ");
                                        else builder.Append(" where ");
                                        builder.AppendLine($"{info.Name}=@{info.Name}\");");
                                        num++;
                                    }
                                }
                                builder.AppendTabLine(4, $"query.AppendLine(\"\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = @@ROWCOUNT\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN CATCH\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = -1\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Value = ''\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Msg = ERROR_MESSAGE()\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END CATCH\");");
                                break;
                            case "insert":
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"insert into [{table.name}] (\");");
                                num = 0;
                                foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                                                               .Where(x => !x.is_identity))
                                {
                                    builder.AppendTab(4, "query.AppendLine(\"");
                                    if (num > 0) builder.Append(",");
                                    builder.AppendLine($"{info.Name}\"); ");
                                    num++;
                                }
                                builder.AppendTabLine(4, "query.AppendLine(\") values (\");");
                                num = 0;
                                foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                                                               .Where(x => !x.is_identity))
                                {
                                    builder.AppendTab(4, "query.AppendLine(\"");
                                    if (num > 0) builder.Append(",");
                                    builder.AppendLine($"@{info.Name}\");");
                                    num++;
                                }
                                builder.AppendTabLine(4, $"query.AppendLine(\")\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = @@ROWCOUNT\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN CATCH\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = -1\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Value = ''\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Msg = ERROR_MESSAGE()\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END CATCH\");");
                                break;
                            case "delete":
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"delete from [{table.name}]\");");
                                if (tableColumns != null && tableColumns.Count > 0)
                                {
                                    builder.AppendTab(4, $"query.AppendLine(\"");
                                    num = 0;
                                    foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                           .Where(x => x.is_identity))
                                    {
                                        if (num > 0) builder.Append(" and ");
                                        else builder.Append(" where ");
                                        builder.Append($"{info.Name}=@{info.Name}");
                                        num++;
                                    }
                                    builder.AppendLine($"\");");
                                }
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = @@ROWCOUNT\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END TRY\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"BEGIN CATCH\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Code = -1\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Value = ''\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"SET @Msg = ERROR_MESSAGE()\");");
                                builder.AppendTabLine(4, $"query.AppendLine(\"END CATCH\");");
                                break;
                        }
                        builder.AppendTabLine(4, $"using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))");
                        builder.AppendTabLine(4, "{");
                        builder.AppendTabLine(5, "cmd.CommandType = System.Data.CommandType.Text;");
                        switch (method)
                        {
                            case "update":
                            case "insert":
                                foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                                                               .Where(x => !x.is_identity))
                                {
                                    builder.AppendTabLine(5, $"cmd.AddParameterInput(\"@{info.ColumnName}\", System.Data.SqlDbType.{info.DbType.ToString()}, {paramObjectName(paramObject)}{info.ColumnName}, {info.max_length});");
                                }
                                break;
                            case "delete":
                                foreach (DbTableInfo info in tableColumns.Where(x => x.TableName.Equals(table.name, StringComparison.OrdinalIgnoreCase))
                                                                                       .Where(x => x.is_identity))
                                {
                                    builder.AppendTabLine(5, $"cmd.AddParameterInput(\"@{info.ColumnName}\", System.Data.SqlDbType.{info.DbType.ToString()}, {info.ColumnName}, {info.max_length});");
                                }
                                break;
                        }
                        switch (method)
                        {
                            case "select":
                            case "list":
                                builder.AppendTabLine(5, $"result = cmd.ExecuteList<{table.name}>();");
                                break;
                            case "count":
                                builder.AppendTabLine(5, $"result = Convert.ToInt32(cmd.ExecuteScalar());");
                                break;
                            case "update":
                            case "insert":
                            case "delete":
                                builder.AppendTabLine(5, "result = cmd.ExecuteReturnValue();");
                                break;
                        }

                        builder.AppendTabLine(4, "}");
                        builder.AppendTabLine(3, "}");
                        builder.AppendTabLine(3, "catch (Exception ex)");
                        builder.AppendTabLine(3, "{");
                        builder.AppendTabLine(4, "if (this.Logger != null) this.Logger.Error(ex);");
                        switch (method)
                        {
                            case "select":
                                break;
                            case "update":
                            case "insert":
                            case "delete":
                                builder.AppendTabLine(4, "result.Error(ex);");
                                break;
                        }
                        builder.AppendTabLine(3, "}");
                        builder.AppendLine("");
                        builder.AppendTabLine(3, "return result;");
                        builder.AppendTabLine(2, "}");
                    }
                }
            }
            */
            #endregion [ Legacy ]

            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        protected virtual string CreateBaseInterface(string NameSpace)
        {
            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Data.SqlClient;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTabLine(1, $"public interface IBaseRepository");
            builder.AppendTabLine(1, "{");
            builder.AppendTabLine(2, "SqlConnection SqlConn { get; set; }");
            builder.AppendLine("");
            builder.AppendTabLine(2, "ILogHelper Logger { get; set; }");
            builder.AppendLine("");
            builder.AppendTabLine(2, "SqlConnection Connection { get; set; }");
            builder.AppendLine("");
            builder.AppendTabLine(2, "void Open(string connStr);");
            builder.AppendLine("");
            builder.AppendTabLine(2, "void Close();");
            builder.AppendLine("");
            builder.AppendTabLine(2, "void Dispose();");
            builder.AppendLine("");
            builder.AppendTabLine(2, "DataTable ExecuteTable(string query);");
            builder.AppendLine("");
            builder.AppendTabLine(2, "int ExecuteCount(string query);");
            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        protected virtual string CreateDefaultInterface(string NameSpace)
        {
            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {NameSpace}");
            builder.AppendLine("{");
            builder.AppendTabLine(1, $"public interface IDefaultRepository : IBaseRepository");
            builder.AppendTabLine(1, "{");

            #region [ COMMON ]
            builder.AppendTabLine(2, "ReturnValue ExecuteReturnValue(string query);");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "ReturnValue Erase<T>(string whereStr) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> ExecuteModel<T>(string query) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "T Single<T>(string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "T Single<T>(string entity, string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> Select<T>(string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> Select<T>(string entity, string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> Select<T>(string entity, int TopCount, string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> Select<T>(int TopCount, string whereStr, string OrderStr = \"\") where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> Select<T>() where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> List<T>(IDynamicQuery paramData) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> List<T>(string entity, IDynamicQuery paramData) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> List<T>(ISubDynamicQuery paramData) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> List<T>(string entity, ISubDynamicQuery paramData) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "int Count<T>(IDynamicQueryBase paramData) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "int Count<T>(string whereStr) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "int Count(string entity, IDynamicQueryBase paramData);");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "ReturnValue Update<T>(string where, Dictionary<string, object> data) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "ReturnValue Update<T>(string where, string Key, object Value) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "ReturnValue Update(string entity, string where, string Key, object Value);");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "ReturnValue Update<T>(string entity, string where, Dictionary<string, object> data) where T : IEntity, new();");
            builder.AppendTabLine(2, "");
            builder.AppendTabLine(2, "List<T> GroupBy<T>(string ValueColumn, string whereStr = \"\") where T : IEntity, new();");
            #endregion [ COMMON ]


            builder.AppendTabLine(1, "}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private string paramObjectName(string paramObject)
        {
            if (!string.IsNullOrWhiteSpace(paramObject))
            {
                return $"{paramObject.Trim()}.";
            }
            else
            {
                return string.Empty;
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            bool IsSP = Chk_SP.Checked;
            bool IsTable = Chk_Table.Checked;
            string NameSpace = TB_NameSpace.Text;
            string Prefix = TB_Name.Text;

            MsgClear();
            MsgWrite(CreateSpRepository(NameSpace, $"{Prefix}Repository.", IsTable));
        }

        private void btn_Table_Click(object sender, EventArgs e)
        {
            bool IsSP = Chk_SP.Checked;
            bool IsTable = Chk_Table.Checked;
            string NameSpace = TB_NameSpace.Text;
            string Prefix = TB_Name.Text;

            MsgClear();
            MsgWrite(CreateDefaultRepository(NameSpace));
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            pBar.Value = 0;

            using (var cmd = new SqlCommand())
            {
                pBar.Value = 10;

                cmd.Connection = main.SqlConn;
                cmd.CommandType = CommandType.Text;

                pBar.Value = 20;

                cmd.CommandText = SystemQuery.SPSelect;
                sps = cmd.ExecuteList<SPEntity>();

                pBar.Value = 30;

                cmd.CommandText = SystemQuery.SPwithTable;
                withTable = cmd.ExecuteList<SPEntity>();

                pBar.Value = 40;

                cmd.CommandText = SystemQuery.SPParamAll;
                spParams = cmd.ExecuteList<SPInfo>();

                pBar.Value = 50;

                cmd.CommandText = SystemQuery.tableColumnAll;
                tableColumns = cmd.ExecuteList<DbTableInfo>();

                pBar.Value = 60;

                cmd.CommandText = SystemQuery.TableViewSelect;
                tables = cmd.ExecuteList<ObjectEntity>();

                pBar.Value = 70;
            }

            pBar.Value = 100;
        }
    }
}
