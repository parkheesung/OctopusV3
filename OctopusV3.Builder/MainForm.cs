using OctopusV3.Builder.ConfigFrm;
using OctopusV3.Builder.EntityFrm;
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

namespace OctopusV3.Builder
{
    public partial class MainForm : Form
    {
        public SqlConnection SqlConn { get; set; } = new SqlConnection();

        public MainForm()
        {
            InitializeComponent();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm config = new ConfigForm(this);
            config.MdiParent = this;
            config.ShowIcon = false;
            config.WindowState = FormWindowState.Maximized;
            config.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                for(int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i] is Form)
                    {
                        this.MdiChildren[i].Close();
                    }
                }
            }
        }

        private void entityCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                EntityCreateForm popup = new EntityCreateForm(this);
                popup.MdiParent = this;
                popup.ShowIcon = false;
                popup.WindowState = FormWindowState.Maximized;
                popup.Show();
            }
            else
            {
                MessageBox.Show("Database가 연결된 상태가 아닙니다.  Setup을 먼저 진행해 주세요.");
            }
        }

        private void entityToSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            { 
                EntityToSpForm popup = new EntityToSpForm(this);
                popup.MdiParent = this;
                popup.ShowIcon = false;
                popup.WindowState = FormWindowState.Maximized;
                popup.Show();
            }
            else
            {
                MessageBox.Show("Database가 연결된 상태가 아닙니다.  Setup을 먼저 진행해 주세요.");
            }
        }

        private void sPtoCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                SPtoCodeForm popup = new SPtoCodeForm(this);
                popup.MdiParent = this;
                popup.ShowIcon = false;
                popup.WindowState = FormWindowState.Maximized;
                popup.Show();
            }
            else
            {
                MessageBox.Show("Database가 연결된 상태가 아닙니다.  Setup을 먼저 진행해 주세요.");
            }
        }

        private void createRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                CreateRepositoryForm popup = new CreateRepositoryForm(this);
                popup.MdiParent = this;
                popup.ShowIcon = false;
                popup.WindowState = FormWindowState.Maximized;
                popup.Show();
            }
            else
            {
                MessageBox.Show("Database가 연결된 상태가 아닙니다.  Setup을 먼저 진행해 주세요.");
            }
        }

        private void createControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                CreateControllerForm popup = new CreateControllerForm(this);
                popup.MdiParent = this;
                popup.ShowIcon = false;
                popup.WindowState = FormWindowState.Maximized;
                popup.Show();
            }
            else
            {
                MessageBox.Show("Database가 연결된 상태가 아닙니다.  Setup을 먼저 진행해 주세요.");
            }
        }
    }
}
