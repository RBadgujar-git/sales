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
    public partial class restore : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public restore()
        {
            InitializeComponent();
        }

        private void restore_Load(object sender, EventArgs e)
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
            con = new SqlConnection("Data Source=" + (cmbserver.Text) + ";Initial Catalog=master;Integrated Security=True ");
            con.Open();
            cmbdb.Items.Clear();
            cmd = new SqlCommand("SELECT * from sysdatabases", con);
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
            if (string.IsNullOrEmpty(cmbserver.Text))
            {
                MessageBox.Show("Server Name & Database can not be Blank");
                return;
            }
            else
            {
                if (str == "restore")
                {
                    openFileDialog1.ShowDialog();
                    // string a = ComboBoxDatabaseName.Text.ToString();
                    query("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = '" + cmbdb.Text + "') Create DATABASE " + cmbdb.Text + " RESTORE DATABASE " + cmbdb.Text + " FROM DISK = '" + openFileDialog1.FileName + "'");
                    //query("Create DATABASE rock1 RESTORE DATABASE(SELECT DB_NAME() AS[Current Database]) FROM DISK = '" + openFileDialog1.FileName + "'");
                    MessageBox.Show("Restore DataBase Sucessfull");
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            blank("restore");
        }

        private void cmbserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
