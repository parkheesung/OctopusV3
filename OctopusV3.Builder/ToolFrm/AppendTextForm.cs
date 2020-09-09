using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctopusV3.Builder.ToolFrm
{
    public partial class AppendTextForm : Form
    {
        protected MainForm main { get; set; }

        public AppendTextForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Change_Click(object sender, EventArgs e)
        {
            string front = TB_Front.Text;
            string back = TB_Back.Text;
            string content = TB_Content.Text;
            StringBuilder builder = new StringBuilder(1000);

            if (!string.IsNullOrWhiteSpace(content))
            {
                List<string> lines = content.Split('\n').ToList();
                if (lines != null && lines.Count > 0)
                {
                    foreach(string line in lines)
                    {
                        builder.AppendLine($"{front}{line.Replace("\n","").Replace("\r","").Replace("\"","\\\"")}{back}");
                    }
                }
            }
            TB_Content.Text = builder.ToString();
        }
    }
}
