using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class CompanyList : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public CompanyList()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewCompany BA = new NewCompany();        
            this.Controls.Add(BA);
            BA.Location= new Point(200,50);
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restore rt = new restore();
            rt.Show();
        }

        private void dgvCompanylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CompanyName from tbl_CompanyMaster where CompanyName like'%{0}%' and DeleteData='1' ", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvCompanylist.DataSource = ds;
              dgvCompanylist.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Binddata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select CompanyName from tbl_CompanyMaster where DeleteData = '1'", con);
           // DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvCompanylist.DataSource = dt;                   
            con.Close();           
        }

        private void CompanyList_Load(object sender, EventArgs e)
        {
            Binddata();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvCompanylist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCompanylist.SelectedCells.Count > 0)
            {
              //  int i = dgvCompanylist.SelectedCells[0].RowIndex;
              
                NewCompany BA = new NewCompany();
                this.Controls.Add(BA);
                BA.Location = new Point(200, 50);
                BA.Visible = true;
                BA.BringToFront();
            }
        }
    }
}
