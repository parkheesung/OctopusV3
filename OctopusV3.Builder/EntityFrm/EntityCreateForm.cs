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
    public partial class EntityCreateForm : Form
    {
        protected MainForm main { get; set; }
        protected List<ObjectEntity> data { get; set; }

        public EntityCreateForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void CK_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_List.Items != null && CB_List.Items.Count > 0)
            {
                for (int i = 0; i < CB_List.Items.Count; i++)
                {
                    if (CK_ALL.Checked)
                    {
                        CB_List.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        CB_List.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            CB_List.Items.Clear();

            using (var cmd = new SqlCommand(SystemQuery.TableViewSelect, main.SqlConn))
            {
                this.data = cmd.ExecuteList<ObjectEntity>();
            }

            if (this.data != null && this.data.Count > 0)
            {
                foreach (var table in this.data)
                {
                    CB_List.Items.Add(table.name, false);
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
                CB_List.Items.Clear();

                if (this.data != null && this.data.Count > 0)
                {
                    foreach (var table in this.data)
                    {
                        if (table.name.IndexOf(search) > -1)
                        {
                            CB_List.Items.Add(table.name, false);
                        }
                    }
                }
            }
            else
            {
                foreach (var table in this.data)
                {
                    CB_List.Items.Add(table.name, false);
                }
            }
        }

        private void Btn_Find_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Location.Text = di.SelectedPath;
            }
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (CB_List.Items != null && CB_List.Items.Count > 0)
            {
                string setNameSpace = TB_NameSpace.Text;
                string path = TB_Location.Text;
                string prefix = TB_Prefix.Text;
                bool IsFrame = CK_UseFramework.Checked;
                bool IsOverWrite = CK_Overwrite.Checked;

                if (String.IsNullOrWhiteSpace(setNameSpace))
                {
                    MessageBox.Show("네임스페이스가 지정되지 않았습니다.");
                    TB_NameSpace.Focus();
                }
                else if (String.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show("저장경로가 지정되지 않았습니다.");
                    TB_Location.Focus();
                }
                else
                {
                    pBar.Value = 0;
                    int step = 100 / CB_List.Items.Count;
                    int c_count = 0;

                    string item = string.Empty;
                    for (int i = 0; i < CB_List.Items.Count; i++)
                    {
                        if (CB_List.GetItemChecked(i))
                        {
                            item = CB_List.Items[i].ToString();
                            if (this.FileWrite(item, setNameSpace, path, prefix, IsFrame, IsOverWrite))
                            {
                                c_count++;
                            }
                        }
                        pBar.Value += step;
                    }

                    
                    pBar.Value = 100;
                    MsgWrite($"{c_count}개의 Entity 파일을 생성했습니다.");
                    MsgWrite($"작업이 완료되었습니다.");
                }
            }
            else
            {
                MessageBox.Show("대상이 지정되지 않았습니다.");
            }
        }

        protected string CreateText(string EntityName, string SetNameSpace, bool IsFrame)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(EntityName))
            {
                var tableInfo = new List<DbTableInfo>();

                using (var cmd = new SqlCommand(SystemQuery.TableInfo(EntityName), this.main.SqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    tableInfo = cmd.ExecuteList<DbTableInfo>();
                }

                if (tableInfo != null && tableInfo.Count > 0)
                {
                    result = GetEntityBodyText(tableInfo, EntityName, SetNameSpace, IsFrame);
                }
            }
            return result;
        }

        private bool FileWrite(string EntityName, string SetNameSpace, string path, string prefix, bool IsFrame, bool IsOverWrite)
        {
            bool result = false;

            string body = CreateText(EntityName, SetNameSpace, IsFrame);
            if (!String.IsNullOrWhiteSpace(body))
            {
                string file_path = Path.Combine(path, $"{prefix}{EntityName}.cs");
                FileInfo fi = new FileInfo(file_path);
                if (fi.Exists && !IsOverWrite)
                {
                    int num = 0;
                    while (fi.Exists)
                    {
                        file_path = Path.Combine(path, $"{prefix}{EntityName}[{num++}].cs");
                        fi = new FileInfo(file_path);
                    }
                }

                result = FileHelper.WriteFile(file_path, body, Encoding.UTF8, false);
                MsgWrite($"{file_path} 파일을 생성했습니다.{Environment.NewLine}");
            }
            else
            {
                result = false;
                MsgWrite("엔티티 내용이 없습니다.");
            }

            return result;
        }

        public string GetEntityBodyText(List<DbTableInfo> table, string EntityName, string EntityNameSpace, bool IsFrame)
        {
            StringBuilder builder = new StringBuilder(500);
            if (IsFrame) builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("");
            builder.AppendLine($"namespace {EntityNameSpace}");
            builder.AppendLine("{");
            if (IsFrame)
            {
                builder.AppendLine($"    public class {EntityName} : IEntity");
            }
            else
            {
                builder.AppendLine($"    public class {EntityName}");
            }
            builder.AppendLine("    {");
            string TargetColumn = string.Empty;
            foreach (DbTableInfo column in table)
            {
                if (IsFrame)
                {
                    builder.Append($"        [Entity(\"{column.ColumnName}\"");
                    if (column.is_identity)
                    {
                        TargetColumn = column.ColumnName;
                    }
                    builder.AppendLine($", SqlDbType.{column.DbType.ToString()}, {column.max_length})]");
                }
                builder.Append($"        public {column.ObjectType} {column.ColumnName}");
                builder.Append(" { get; set; }");
                switch (column.ObjectType)
                {
                    case "string":
                        builder.Append(" = string.Empty;");
                        break;
                    case "int":
                    case "long":
                    case "double":
                        if (column.is_identity)
                        {
                            builder.Append(" = -1;");
                        }
                        else
                        {
                            builder.Append(" = 0;");
                        }
                        break;
                    case "bool":
                        if (column.ColumnName.Equals("IsEnabled", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.Append(" = true;");
                        }
                        else
                        {
                            builder.Append(" = false;");
                        }
                        break;
                }

                builder.AppendLine("");
                builder.AppendLine("");
            }

            if (string.IsNullOrWhiteSpace(TargetColumn) && table != null && table.Count > 0)
            {
                TargetColumn = table[0].ColumnName;
            }

            builder.AppendLine("");
            builder.Append("        public virtual string TableName { get { return \"");
            builder.Append(EntityName);
            builder.AppendLine("\"; } set { } }");
            builder.Append("        public virtual string TargetColumn { get { return \"");
            builder.Append(TargetColumn);
            builder.AppendLine("\"; } set { } }");
            builder.AppendLine("");
            builder.AppendLine($"        public {EntityName}()");
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("}");
            builder.AppendLine("");
            return builder.ToString();
        }


        public void MsgWrite(string msg)
        {
            if (TB_Msg.InvokeRequired)
            {
                TB_Msg.BeginInvoke(new Action(() => {
                    TB_Msg.AppendText(msg);
                    TB_Msg.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                TB_Msg.AppendText(msg);
                TB_Msg.AppendText(Environment.NewLine);
            }
        }

        public void MsgClear()
        {
            if (TB_Msg.InvokeRequired)
            {
                TB_Msg.BeginInvoke(new Action(() => {
                    TB_Msg.Clear();
                }));
            }
            else
            {
                TB_Msg.Clear();
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            if (CB_List.Items != null && CB_List.Items.Count > 0)
            {
                string setNameSpace = TB_NameSpace.Text;
                bool IsFrame = CK_UseFramework.Checked;
                string entityName = string.Empty;

                if (String.IsNullOrWhiteSpace(setNameSpace))
                {
                    MessageBox.Show("네임스페이스가 지정되지 않았습니다.");
                    TB_NameSpace.Focus();
                }
                else
                {
                    int chkCount = 0;
                    for (int i = 0; i < CB_List.Items.Count; i++)
                    {
                        if (CB_List.GetItemChecked(i))
                        {
                            entityName = CB_List.Items[i].ToString();
                            chkCount++;
                        }
                    }

                    if (chkCount == 1)
                    {
                        MsgClear();
                        MsgWrite(CreateText(entityName, setNameSpace, IsFrame));
                    }
                    else
                    {
                        MessageBox.Show("OUTPUT대상은 하나만 지정할 수 있습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("대상이 지정되지 않았습니다.");
            }
        }
    }
}
