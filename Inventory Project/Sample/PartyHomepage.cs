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
using System.IO;

namespace sample
{
    public partial class PartyHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        public PartyHomepage()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PartyMaster1 BA = new PartyMaster1();
            BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void fetchdetails()
        {
            con.Open();
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("select PartyName,OpeningBal from tbl_PartyMaster", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartiesID", 0);
            cmd.Parameters.AddWithValue("@PartyName", "");
            cmd.Parameters.AddWithValue("@OpeningBal", "");
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            con.Close();
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.ColumnCount = 2;
            dgvCategory.Columns[0].HeaderText = "Party Name";
            dgvCategory.Columns[0].DataPropertyName = "PartyName";
            dgvCategory.Columns[1].HeaderText = "Opening Balance";
            dgvCategory.Columns[1].DataPropertyName = "OpeningBal";
            dgvCategory.DataSource = dtable;           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select PartyName,OpeningBal from tbl_PartyMaster where PartyName like '%{0}%'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
               dgvCategory.DataSource = ds;
               dgvCategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPartyGroup_Click(object sender, EventArgs e)
        {
            Party_Group BA = new Party_Group();
            //  BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
         //   BA.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select tbl_PartyMaster.PartyName, tbl_PartyMaster.OpeningBal ,tbl_PartyMaster.ContactNo,tbl_PartyMaster.BiJOIN tbl_ItemAdjustement on tbl_ItemAdjustement.ID=tbl_ItemMaster.ItemID", con);
            //DataSet ds = new DataSet();
            //SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //SDA.Fill(ds);
            //con.Close();
        }

        private void PartyHomepage_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }
    }
}
