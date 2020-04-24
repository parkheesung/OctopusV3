using OctopusV3.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class EntityFromTagForm : Form
    {
        protected MainForm main { get; set; }

        protected ConcurrentDictionary<string, string> tags = new ConcurrentDictionary<string, string>();

        public EntityFromTagForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog di = new FolderBrowserDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                TB_Location.Text = di.SelectedPath;
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            string path = TB_Location.Text;

            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("경로를 입력하세요.");
            }
            else
            {
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    string content = FileHelper.ReadFile(path, Encoding.UTF8);
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        MessageBox.Show("파일에 내용이 없습니다.");
                    }
                    else
                    {
                        HtmlAgilityPack.HtmlDocument target = new HtmlAgilityPack.HtmlDocument();
                        target.LoadHtml(content);
                        if (target != null && target.DocumentNode != null && target.DocumentNode.SelectNodes("//form") != null && target.DocumentNode.SelectNodes("//form").Count() > 0)
                        {
                            foreach (var form in target.DocumentNode.SelectNodes("//form"))
                            {
                                foreach(var item in form.SelectNodes("//input"))
                                {
                                    tags.AddOrUpdate(item.Attributes["name"].Value, item.Attributes["name"].Value, (oldkey, oldValue) => item.Attributes["name"].Value);
                                }

                                foreach (var item in form.SelectNodes("//select"))
                                {
                                    tags.AddOrUpdate(item.Attributes["name"].Value, item.Attributes["name"].Value, (oldkey, oldValue) => item.Attributes["name"].Value);
                                }
                            }
                        }

                        if (tags != null && tags.Count > 0)
                        {
                            TB_Result.Text = GetEntityBodyText();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("파일이 존재하지 않습니다.");
                }
            }
        }

        public string GetEntityBodyText()
        {
            StringBuilder builder = new StringBuilder(500);
            builder.AppendLine("using OctopusV3.Core;");
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("");
            builder.AppendLine($"namespace UserNameSpace");
            builder.AppendLine("{");
            builder.AppendLine($"    public class FormEntity");
            builder.AppendLine("    {");
            foreach (var tag in tags)
            {
                builder.Append($"        public string {tag.Key}");
                builder.Append(" { get; set; }");
                builder.Append(" = string.Empty;");
                builder.AppendLine("");
            }
            builder.AppendLine("");
            builder.AppendLine($"        public FormEntity()");
            builder.AppendLine("        {");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("}");
            builder.AppendLine("");
            return builder.ToString();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            TB_Result.Clear();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_Result.Text);
            MessageBox.Show("복사했습니다.");
        }
    }
}
