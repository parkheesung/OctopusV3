using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctopusV3.Data;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class SPtoCodeForm : Form
    {
        protected MainForm main { get; set; }
        protected List<SPEntity> data { get; set; }

        protected string Query { get; set; } = string.Empty;

        protected DataTable depends { get; set; }

        protected string tableName { get; set; } = string.Empty;

        public string ReturnType
        {
            get
            {
                string result = string.Empty;

                if (!string.IsNullOrWhiteSpace(this.tableName))
                {
                    if (this.tableName.IndexOf(".") > -1)
                    {
                        result = this.tableName.Split('.')[1].Trim();
                    }
                    else
                    {
                        result = this.tableName.Trim();
                    }
                }

                return result;
            }

            set
            {
                this.tableName = value;
            }
        }

        public SPtoCodeForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
            CB_TYPE.SelectedIndex = 0;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LB_SP.Items.Clear();

            using (var cmd = new SqlCommand(SystemQuery.SPSelect, main.SqlConn))
            {
                this.data = cmd.ExecuteList<SPEntity>();
            }

            if (this.data != null && this.data.Count > 0)
            {
                foreach (var table in this.data)
                {
                    LB_SP.Items.Add(table.name);
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
                LB_SP.Items.Clear();

                if (this.data != null && this.data.Count > 0)
                {
                    foreach (var table in this.data)
                    {
                        if (table.name.IndexOf(search) > -1)
                        {
                            LB_SP.Items.Add(table.name);
                        }
                    }
                }
            }
            else
            {
                LB_SP.Items.Clear();

                foreach (var table in this.data)
                {
                    LB_SP.Items.Add(table.name);
                }
            }
        }

        private void CB_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResult();
        }

        private void SetResult()
        {
            if (LB_SP.SelectedItem != null && CB_TYPE.SelectedItem != null)
            {
                string spName = LB_SP.SelectedItem.ToString();
                string rtnType = CB_TYPE.SelectedItem.ToString();  //Void,ReturnValue,List<T>
                bool IsConnect = IsConnection.Checked;
                bool IsMethod = CK_Method.Checked;

                StringBuilder builder = new StringBuilder(200);

                if (!String.IsNullOrWhiteSpace(spName))
                {
                    List<SPInfo> spinfos = new List<SPInfo>();

                    using (var cmd = new SqlCommand(SPInfo.CreateSPInfoQuery(spName), main.SqlConn))
                    {
                        spinfos = cmd.ExecuteList<SPInfo>();
                    }

                    using (var cmd = new SqlCommand("sp_depends", main.SqlConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.AddParameterInput("@objname", SqlDbType.NVarChar, spName, 776);
                        this.depends = cmd.ExecuteTable();
                        if (this.depends != null && this.depends.Rows.Count > 0)
                        {
                            this.ReturnType = Convert.ToString(this.depends.Rows[0].ItemArray[0]);
                        }
                    }

                    if (string.IsNullOrWhiteSpace(this.ReturnType))
                    {
                        this.ReturnType = "object";
                    }

                    if (IsMethod)
                    {
                        string NameOfSP = string.Empty;
                        if (spName.IndexOf("_") > -1)
                        {
                            NameOfSP = spName.Substring(spName.IndexOf("_")).Replace("_", "");
                        }
                        else
                        {
                            NameOfSP = spName;
                        }

                        if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine($"public ReturnValue {NameOfSP}({this.ReturnType} TargetModel)");
                        }
                        else if (rtnType.Equals("List<T>", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine($"public List<T> {NameOfSP}(object TargetModel)");
                        }
                        else
                        {
                            builder.AppendLine($"public void {NameOfSP}(object TargetModel)");
                        }
                        builder.AppendLine("{");
                        builder.AppendLine("var result = new ReturnValue();");
                        builder.AppendLine("");
                    }
                    if (IsConnect)
                    {
                        builder.AppendLine("using (var SqlConn = new SqlConnection(\"\"))");
                    }
                    builder.AppendLine($"using (var cmd = new SqlCommand(\"{spName}\", SqlConn))");
                    builder.AppendLine("{");
                    builder.AppendLine("cmd.CommandType = System.Data.CommandType.StoredProcedure;");
                    if (spinfos != null && spinfos.Count > 0)
                    {
                        foreach (SPInfo info in spinfos)
                        {
                            if (info.is_output)
                            {
                                if ((rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase)
                                        && (info.name.Equals("@Code", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Value", StringComparison.OrdinalIgnoreCase) ||
                                                info.name.Equals("@Msg", StringComparison.OrdinalIgnoreCase))) == false)
                                {
                                    builder.AppendLine($"cmd.AddParameterOutput(\"{info.name}\", System.Data.SqlDbType.{info.SqlType.ToString()}, {info.max_length});");
                                }
                            }
                            else
                            {
                                builder.Append($"cmd.AddParameterInput(\"{info.name}\", System.Data.SqlDbType.{info.SqlType.ToString()}, TargetModel.{info.name.Replace("@", "")}, ");
                                switch (info.SqlType)
                                {
                                    case SqlDbType.NVarChar:
                                    case SqlDbType.NChar:
                                        builder.AppendLine($" {info.max_length / 2});");
                                        break;
                                    default:
                                        builder.AppendLine($" {info.max_length});");
                                        break;
                                }
                                
                            }
                        }
                    }
                    if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                    {
                        builder.AppendLine("result = cmd.ExecuteReturnValue();");
                    }
                    else if (rtnType.Equals("List<T>", StringComparison.OrdinalIgnoreCase))
                    {
                        builder.AppendLine("result = cmd.ExecuteList<T>();");
                    }
                    else
                    {
                        builder.AppendLine("cmd.ExecuteNonQuery();");
                    }
                    builder.AppendLine("}");
                    if (IsMethod)
                    {
                        if (rtnType.Equals("ReturnValue", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine($"return result;");
                        }
                        else if (rtnType.Equals("List<T>", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendLine($"return result;");
                        }
                        else
                        {
                        }
                        builder.AppendLine("}");
                    }
                    this.Query = builder.ToString();
                }
            }
        }

        public void MsgClear()
        {
            if (TB_OUTPUT.InvokeRequired)
            {
                TB_OUTPUT.BeginInvoke(new Action(() => {
                    TB_OUTPUT.Clear();
                }));
            }
            else
            {
                TB_OUTPUT.Clear();
            }
        }

        public void MsgWrite(string msg)
        {
            if (TB_OUTPUT.InvokeRequired)
            {
                TB_OUTPUT.BeginInvoke(new Action(() => {
                    TB_OUTPUT.AppendText(msg);
                    TB_OUTPUT.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                TB_OUTPUT.AppendText(msg);
                TB_OUTPUT.AppendText(Environment.NewLine);
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

        private void IsConnection_CheckedChanged(object sender, EventArgs e)
        {
            SetResult();
        }

        private void CK_Method_CheckedChanged(object sender, EventArgs e)
        {
            SetResult();
        }

        private void LB_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetResult();
        }
    }
}
