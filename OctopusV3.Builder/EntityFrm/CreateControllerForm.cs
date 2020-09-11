using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctopusV3.Data;
using OctopusV3.Core;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class CreateControllerForm : Form
    {
        protected MainForm main { get; set; }

        protected List<SPEntity> data { get; set; }

        protected DataTable depends { get; set; }

        protected string Query { get; set; } = string.Empty;

        public CreateControllerForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
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

        private void CK_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (LB_SP.Items != null && LB_SP.Items.Count > 0)
            {
                for (int i = 0; i < LB_SP.Items.Count; i++)
                {
                    if (CK_ALL.Checked)
                    {
                        LB_SP.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        LB_SP.SetItemCheckState(i, CheckState.Unchecked);
                    }
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

        private void btn_output_Click(object sender, EventArgs e)
        {
            this.SetResult();
            this.MsgClear();
            this.MsgWrite(this.Query);
        }

        private void SetResult()
        {
            if (LB_SP.Items != null && LB_SP.Items.Count > 0)
            {
                string Prefix = TB_Prefix.Text;
                bool IsEntity = CK_Entity.Checked;
                bool IsRoute = CK_Route.Checked;
                string spName = string.Empty;
                string tmp = string.Empty;
                string rtnType = TB_Return.Text;
                int chk = 0;
                List<SPInfo> spinfos = new List<SPInfo>();
                StringBuilder builder = new StringBuilder(200);
                StringBuilder paramData = new StringBuilder(200);

                for (int i = 0; i < LB_SP.Items.Count; i++)
                {
                    if (LB_SP.GetItemChecked(i))
                    {
                        paramData.Clear();
                        spName = LB_SP.Items[i].ToString();
                        if (IsRoute)
                        {
                            builder.AppendLine($"[Route(\"{Prefix.Replace("_","/")}{spName.Replace("ESP_", "").Replace("_", "/")}\")]");
                        }
                        builder.Append($"public JsonResult {Prefix}{spName.Replace("ESP_", "")}(");

                        if (IsEntity)
                        {
                            using (var cmd = new SqlCommand("sp_depends", main.SqlConn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.AddParameterInput("@objname", SqlDbType.NVarChar, spName, 776);
                                this.depends = cmd.ExecuteTable();
                            }

                            if (this.depends != null && this.depends.Rows.Count > 0)
                            {
                                tmp = Convert.ToString(this.depends.Rows[0].ItemArray[0]).Replace("dbo.", "");
                                if (!string.IsNullOrWhiteSpace(tmp))
                                {
                                    builder.Append($"{tmp} {tmp.ToLower()}");
                                    paramData.Append($"{tmp.ToLower()}");
                                    if (string.IsNullOrWhiteSpace(rtnType))
                                    {
                                        rtnType = tmp;
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(SPInfo.CreateSPInfoQuery(spName), main.SqlConn))
                            {
                                spinfos = cmd.ExecuteList<SPInfo>();
                            }

                            if (spinfos != null && spinfos.Count > 0)
                            {
                                chk = 0;
                                foreach (var sp in spinfos.Where(x => x.is_output == false))
                                {
                                    if (chk > 0)
                                    {
                                        builder.Append(",");
                                        paramData.Append(",");
                                    }
                                    builder.Append($"{sp.BindType} {sp.name.Replace("@","")}");
                                    paramData.Append($"{sp.name.Replace("@", "")}");
                                    chk++;
                                }
                            }
                        }

                        builder.AppendLine(")");
                        builder.AppendLine("{");
                        if (string.IsNullOrWhiteSpace(rtnType))
                        {
                            rtnType = "ReturnValue";
                        }

                        builder.AppendTabLine(1, $"var result = new {rtnType}();");
                        builder.AppendLine("");
                        builder.AppendTab(1, $"result = this.Repository.{spName.Replace("ESP_", "").Replace("_", "")}(");
                        builder.Append(paramData.ToString());
                        builder.AppendLine(");");
                        builder.AppendLine("");
                        builder.AppendTabLine(1, "return Json(result);");
                        builder.AppendLine("}");
                    }
                    builder.AppendLine("");
                }

                this.Query = builder.ToString();
            }
            else
            {
                MessageBox.Show("대상이 지정되지 않았습니다.");
            }
        }

        private void LB_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.SetResult();
        }

        private void CK_Entity_CheckedChanged(object sender, EventArgs e)
        {
            //this.SetResult();
        }

        private void CK_UseFramework_CheckedChanged(object sender, EventArgs e)
        {
            //this.SetResult();
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

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Query);
            MessageBox.Show("복사했습니다.");
        }
    }
}
