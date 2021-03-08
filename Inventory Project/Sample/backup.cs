using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sample
{
    public partial class backup : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public backup()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            blank("backup");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void backup_Load(object sender, EventArgs e)
        {
            serverName(".");
        }
        public void serverName(string str)
        {
            con = new SqlConnection("Data Source=" + str + ";Initial Catalog=master;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbserver.Items.Add(dr[2]);
            }
            dr.Close();
        }
        public void Createconnection()
        {

            // con = new SqlConnection("Data Source=" + (comboBox1.Text) + ";Database=Master;data source=.; uid=; pwd=;");
            con = new SqlConnection("Data Source=" + (cmbserver.Text) + ";Initial Catalog=CustomerDB;Integrated Security=True ");
            con.Open();
            cmbdb.Items.Clear();
            cmd = new SqlCommand("SELECT DB_NAME() AS[Current Database]", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdb.Items.Add(dr[0]);
            }
            dr.Close();
        }
        public void query(string que)
        {
            cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
        }
        public void blank(string str)
        {
            if (string.IsNullOrEmpty(cmbserver.Text) | string.IsNullOrEmpty(cmbdb.Text))
            {
                // label3.Visible = true;
                MessageBox.Show("Server Name & Database can not be Blank");
                return;
            }
            else
            {
                if (str == "backup")
                {
                    saveFileDialog1.FileName = cmbdb.Text;
                    saveFileDialog1.ShowDialog();
                    string s = null;
                    s = saveFileDialog1.FileName;
                    query("Backup database " + cmbdb.Text + " to disk='" + s + "'");
                    MessageBox.Show("BackUp Database Sucessfull");
                }
            }
        }

        private void cmbserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btncancel_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
