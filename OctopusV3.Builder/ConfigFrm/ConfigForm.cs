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

namespace OctopusV3.Builder.ConfigFrm
{
    public partial class ConfigForm : Form
    {
        protected MainForm main { get; set; }

        public ConfigForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TB_Address.InvokeRequired)
            {
                TB_Address.BeginInvoke(new Action(() => {
                    Properties.Settings.Default.Config_Address = TB_Address.Text;
                    Properties.Settings.Default.Config_UserID = TB_UserID.Text;
                    Properties.Settings.Default.Config_Password = TB_Password.Text;
                }));
            }
            else
            {
                Properties.Settings.Default.Config_Address = TB_Address.Text;
                Properties.Settings.Default.Config_UserID = TB_UserID.Text;
                Properties.Settings.Default.Config_Password = TB_Password.Text;
            }

            MsgWrite("저장하였습니다.");
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            if (TB_Address.InvokeRequired)
            {
                TB_Address.BeginInvoke(new Action(() => {
                    TB_Address.Text = Properties.Settings.Default.Config_Address;
                    TB_UserID.Text = Properties.Settings.Default.Config_UserID;
                    TB_Password.Text = Properties.Settings.Default.Config_Password;
                }));
            }
            else
            {
                TB_Address.Text = Properties.Settings.Default.Config_Address;
                TB_UserID.Text = Properties.Settings.Default.Config_UserID;
                TB_Password.Text = Properties.Settings.Default.Config_Password;
            }

            MsgWrite("저장된 데이터를 불러옵니다.");
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = TB_Address.Text;
                builder.UserID = TB_UserID.Text;
                builder.Password = TB_Password.Text;
                builder.ConnectTimeout = 5;
                if (main.SqlConn != null && main.SqlConn.State == ConnectionState.Open)
                {
                    main.SqlConn.Close();
                }

                main.SqlConn = new SqlConnection(builder.ConnectionString);
                main.SqlConn.Open();
                MsgWrite("Connection Success!!");

                var list = new List<DbEntity>();

                using (var cmd = new SqlCommand(SystemQuery.DatabaseSelect, main.SqlConn))
                {
                    cmd.CommandType = CommandType.Text;
                    list = cmd.ExecuteList<DbEntity>();
                }

                CB_Context.Items.Clear();

                if (list != null && list.Count > 0)
                {
                    foreach(var item in list)
                    {
                        CB_Context.Items.Add(item.name);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgWrite(ex.Message);
                MsgWrite(ex.StackTrace);
                if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
                {
                    MsgWrite(ex.InnerException.Message);
                    MsgWrite(ex.InnerException.StackTrace);
                }
            }
        }

        public void MsgWrite(string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                if (TB_Msg.InvokeRequired)
                {
                    TB_Msg.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            TB_Msg.AppendText(msg);
                            TB_Msg.AppendText(Environment.NewLine);
                        }
                        catch
                        {

                        }
                    }));
                }
                else
                {
                    try
                    {
                        TB_Msg.AppendText(msg);
                        TB_Msg.AppendText(Environment.NewLine);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Btn_Bind_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = TB_Address.Text;
                builder.UserID = TB_UserID.Text;
                builder.Password = TB_Password.Text;
                builder.InitialCatalog = CB_Context.SelectedItem.ToString();
                builder.ConnectTimeout = 5;
                if (main.SqlConn != null && main.SqlConn.State == ConnectionState.Open)
                {
                    main.SqlConn.Close();
                }

                main.SqlConn = new SqlConnection(builder.ConnectionString);
                main.SqlConn.Open();
                MsgWrite($"{CB_Context.SelectedItem.ToString()} Connection Success!!");
            }
            catch (Exception ex)
            {
                MsgWrite(ex.Message);
                MsgWrite(ex.StackTrace);
                if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
                {
                    MsgWrite(ex.InnerException.Message);
                    MsgWrite(ex.InnerException.StackTrace);
                }
            }
        }
    }
}
