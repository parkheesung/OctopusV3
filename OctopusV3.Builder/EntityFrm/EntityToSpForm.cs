using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctopusV3.Core;
using OctopusV3.Data;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class EntityToSpForm : Form
    {
        protected MainForm main { get; set; }
        protected List<ObjectEntity> data { get; set; }

        protected string Query { get; set; } = string.Empty;

        public EntityToSpForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
            CB_TYPE.SelectedIndex = 0;
            CB_Role.SelectedIndex = 0;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LB_Table.Items.Clear();

            using (var cmd = new SqlCommand(SystemQuery.TableViewSelect, main.SqlConn))
            {
                this.data = cmd.ExecuteList<ObjectEntity>();
            }

            if (this.data != null && this.data.Count > 0)
            {
                foreach (var table in this.data)
                {
                    LB_Table.Items.Add(table.name);
                }
            }
        }

        private void TB_Search_KeyUp(object sender, KeyEventArgs e)
        {
            string search = string.Empty;

            if (TB_Search.InvokeRequired)
            {
                TB_Search.BeginInvoke(new Action(() =>
                {
                    search = TB_Search.Text;
                }));
            }
            else
            {
                search = TB_Search.Text;
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                LB_Table.Items.Clear();

                if (this.data != null && this.data.Count > 0)
                {
                    foreach (var table in this.data)
                    {
                        if (table.name.IndexOf(search) > -1)
                        {
                            LB_Table.Items.Add(table.name);
                        }
                    }
                }
            }
            else
            {
                foreach (var table in this.data)
                {
                    LB_Table.Items.Add(table.name);
                }
            }
        }

        private void CB_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResult();
        }

        private void CB_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResult();
        }

        private void SetResult()
        {
            if (LB_Table.SelectedItem != null && CB_TYPE.SelectedItem != null)
            {
                string entityName = LB_Table.SelectedItem.ToString();
                string rtnType = CB_TYPE.SelectedItem.ToString();  //Void,ReturnValue,List<T>
                string roleType = CB_Role.SelectedItem.ToString();  //Select,Update,Insert,Delete,Save
                bool IsTran = IsTransaction.Checked;

                StringBuilder builder = new StringBuilder(200);

                if (!String.IsNullOrWhiteSpace(entityName))
                {
                    List<DbTableInfo> tableinfos = new List<DbTableInfo>();

                    try
                    {
                        using (var cmd = new SqlCommand(SystemQuery.TableInfo(entityName), this.main.SqlConn))
                        {
                            cmd.CommandType = CommandType.Text;
                            tableinfos = cmd.ExecuteList<DbTableInfo>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgWrite(ex.Message);
                    }

                    if (tableinfos != null && tableinfos.Count > 0)
                    {
                        var identityColumn = tableinfos.Where(x => x.is_identity).FirstOrDefault();

                        if (identityColumn != null)
                        {
                            builder.AppendLine($"CREATE PROCEDURE [dbo].[ESP_{entityName}_{roleType}]");
                            builder.AppendLine("(");
                            int num = 0;
                            foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false).OrderBy(x => x.is_nullable))
                            {
                                switch (info.ColumnType.ToLower())
                                {
                                    case "date":
                                    case "datetime":
                                    case "datetime2":
                                    case "smalldatetime":
                                        break;
                                    default:
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"	@{info.ColumnName}					{this.ColumnTypeString(info)}");
                                        num++;
                                        break;
                                }
                            }
                            if (tableinfos.Where(x => x.is_identity == false).Count() > 0)
                            {
                                builder.Append(",");
                            }
                            builder.AppendLine($"	@{identityColumn.ColumnName}					{identityColumn.ColumnType}     = -1");
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine(",	@Code					bigint				output");
                                builder.AppendLine(",	@Value					varchar(100)		output");
                                builder.AppendLine(",	@Msg					nvarchar(100)	output");
                            }
                            builder.AppendLine(")");
                            builder.AppendLine("AS");
                            builder.AppendLine("");
                            builder.AppendLine("SET NOCOUNT ON");
                            builder.AppendLine("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                            builder.AppendLine("");
                            builder.AppendLine("Declare @Err int");
                            builder.AppendLine("SET @Err = 0");
                            builder.AppendLine("");
                            if (IsTran)
                            {
                                builder.AppendLine("BEGIN TRAN");
                            }
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine("SET @Code = 0");
                                builder.AppendLine("SET @Value = ''");
                                builder.AppendLine("SET @Msg = ''");
                                builder.AppendLine("");

                                builder.AppendLine("BEGIN TRY");
                            }
                            //BODY
                            switch (roleType.ToUpper())
                            {
                                case "SELECT":
                                    builder.AppendLine($"select * from [{entityName}]");
                                    break;
                                case "UPDATE":
                                    builder.AppendLine($"update [{entityName}] set ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine($"[{info.ColumnName}] = getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.Append("where ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity))
                                    {
                                        if (num > 0) builder.Append(" and ");
                                        builder.AppendLine($"{info.ColumnName} = @{info.ColumnName}");
                                        num++;
                                    }
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @{identityColumn.ColumnName}");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '수정하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    break;
                                case "INSERT":
                                    builder.AppendLine($"insert into [{entityName}] (");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"[{info.ColumnName}]");
                                        num++;
                                    }
                                    builder.AppendLine(") values (");

                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine("getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"@{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.AppendLine(")");
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @@IDENTITY");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '저장하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    break;
                                case "DELETE":
                                    builder.AppendLine($"delete from [{entityName}]");
                                    if (tableinfos.Where(x => x.is_identity).Count() > 0)
                                    {
                                        builder.Append("where ");
                                        num = 0;
                                        foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity))
                                        {
                                            if (num > 0) builder.Append(" and ");
                                            builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                            num++;
                                        }
                                    }
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @{identityColumn.ColumnName}");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '삭제하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    break;
                                case "SAVE":
                                    builder.AppendLine($"IF Exists(select [{identityColumn.ColumnName}] from [{entityName}] where [{identityColumn.ColumnName}] = @{identityColumn.ColumnName})");
                                    builder.AppendLine("	BEGIN");
                                    builder.AppendLine($"update [{entityName}] set ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine($"[{info.ColumnName}] = getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.Append("where ");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity))
                                    {
                                        if (num > 0) builder.Append(" and ");
                                        builder.AppendLine($"[{info.ColumnName}] = @{info.ColumnName}");
                                        num++;
                                    }
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @{identityColumn.ColumnName}");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '수정하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    builder.AppendLine("	END");
                                    builder.AppendLine("ELSE");
                                    builder.AppendLine("	BEGIN");
                                    builder.AppendLine($"insert into [{entityName}] (");
                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        builder.AppendLine($"[{info.ColumnName}]");
                                        num++;
                                    }
                                    builder.AppendLine(") values (");

                                    num = 0;
                                    foreach (DbTableInfo info in tableinfos.Where(x => x.is_identity == false))
                                    {
                                        if (num > 0) builder.Append(",");
                                        switch (info.ColumnType.ToLower())
                                        {
                                            case "date":
                                            case "datetime":
                                            case "datetime2":
                                            case "smalldatetime":
                                                builder.AppendLine("getdate()");
                                                break;
                                            default:
                                                builder.AppendLine($"@{info.ColumnName}");
                                                break;
                                        }
                                        num++;
                                    }
                                    builder.AppendLine(")");
                                    builder.AppendLine("");
                                    builder.AppendLine("SET @Err = @Err + @@Error");
                                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                    {
                                        builder.AppendLine("");
                                        builder.AppendLine("IF IsNull(@Err,0) = 0");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = @@IDENTITY");
                                        builder.AppendLine("    END");
                                        builder.AppendLine("ELSE");
                                        builder.AppendLine("    BEGIN");
                                        builder.AppendLine($"        SET @Code = -1");
                                        builder.AppendLine($"        SET @Msg = '저장하지 못했습니다.'");
                                        builder.AppendLine("    END");
                                    }
                                    builder.AppendLine("	END");
                                    builder.AppendLine("");
                                    break;
                            }

                            //END BODY
                            if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                            {
                                builder.AppendLine("END TRY");
                                builder.AppendLine("BEGIN CATCH");
                                builder.AppendLine("    SET @Code = -1");
                                builder.AppendLine("    SET @Err = @Err + 1");
                                builder.AppendLine("    SET @Msg = ERROR_MESSAGE()");
                                builder.AppendLine("END CATCH");
                            }

                            if (IsTran)
                            {
                                builder.AppendLine("");
                                builder.AppendLine("IF IsNull(@Err,0) = 0");
                                builder.AppendLine("    BEGIN");
                                builder.AppendLine("        COMMIT TRAN");
                                builder.AppendLine("    END");
                                builder.AppendLine("ELSE");
                                builder.AppendLine("    BEGIN");
                                builder.AppendLine("        ROLLBACK TRAN");
                                if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                                {
                                    builder.AppendLine("        SET @Code = -1");
                                    builder.AppendLine("        SET @Msg = '처리하지 못했습니다.'");
                                }
                                builder.AppendLine("    END");
                            }
                        }
                        else
                        {
                            builder.AppendLine("<< Identity Column is not Found >>");
                        }
                    }

                    this.Query = builder.ToString();
                }
            }
        }

        private string ColumnTypeString(DbTableInfo info)
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(info.ColumnType);
            switch (info.ColumnType.ToLower())
            {
                case "varchar":
                case "char":
                case "nvarchar":
                case "nchar":
                    if (info.max_length == -1)
                    {
                        builder.Append("(max)");
                    }
                    else
                    {
                        builder.Append($"({info.max_length})");
                    }
                    if (info.is_nullable)
                    {
                        builder.Append(" = ''");
                    }
                    break;
            }
            return builder.ToString();
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

        private void btn_output_Click(object sender, EventArgs e)
        {
            MsgClear();
            MsgWrite(this.Query);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Query);
            MessageBox.Show("복사했습니다.");
        }

        private void Btn_FindFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Folder.Text = di.SelectedPath;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string fileURL = TB_Folder.Text;

            if (!string.IsNullOrWhiteSpace(fileURL))
            {
                string entityName = LB_Table.SelectedItem.ToString();
                string roleType = CB_Role.SelectedItem.ToString();  //Select,Update,Insert,Delete,Save
                string fileName = $"ESP_{entityName}_{roleType}";
                this.FileWrite(fileName, fileURL, true);
            }
            else
            {
                MessageBox.Show("파일 경로를 지정해 주세요.");
            }
        }

        private bool FileWrite(string EntityName, string path, bool IsOverWrite)
        {
            bool result = false;

            string body = this.Query.Trim();
            if (!String.IsNullOrWhiteSpace(body))
            {
                string file_path = Path.Combine(path, $"{EntityName}.sql");
                FileInfo fi = new FileInfo(file_path);
                if (fi.Exists && !IsOverWrite)
                {
                    int num = 0;
                    while (fi.Exists)
                    {
                        file_path = Path.Combine(path, $"{EntityName}[{num++}].sql");
                        fi = new FileInfo(file_path);
                    }
                }

                result = FileHelper.WriteFile(file_path, body, Encoding.UTF8, false);
                MsgWrite($"{file_path} 파일을 생성했습니다.{Environment.NewLine}");
            }
            else
            {
                result = false;
                MsgWrite("내용이 없습니다.");
            }

            return result;
        }

        private void LB_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResult();
        }
    }
}
