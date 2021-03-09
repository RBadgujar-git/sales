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
    public partial class AllParties : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public AllParties()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void fetchcustomername()
        {
            if (cmballparties.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster and Company_ID='" + NewCompany.company_id + "' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmballparties.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchGroupname()
        {
            //if (cmballgroup.Text != "System.Data.DataRowView") {
            //    try {
            //        string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroup group by AddPartyGroup");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "Temp");
            //        DataTable DT = new DataTable();
            //        SDA.Fill(ds);
            //        for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
            //            cmballgroup.Items.Add(ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString());

            //        }
            //    }
            //    catch (Exception e1) {
            //        MessageBox.Show(e1.Message);
            //    }
            //}
        }

        private void AllParties_Load(object sender, EventArgs e)
        {
           // binddata();
            fetchcustomername();
            fetchGroupname();
        }
        public void binddata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_PartyMaster where  DeleteData='1' and Company_ID='"+NewCompany.company_id+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvAllparties.AutoGenerateColumns = false;
            dgvAllparties.ColumnCount = 3;
            dgvAllparties.Columns[0].HeaderText = "Name";
            dgvAllparties.Columns[0].DataPropertyName = "PartyName";
            dgvAllparties.Columns[1].HeaderText = "Email";
            dgvAllparties.Columns[1].DataPropertyName = "EmailID";
            dgvAllparties.Columns[0].HeaderText = "Phone No";
            dgvAllparties.Columns[0].DataPropertyName = "ContactNo";
            //dgvAllparties.Columns[1].HeaderText = "Received";
            //dgvAllparties.Columns[1].DataPropertyName = "productname";
            //dgvAllparties.Columns[0].HeaderText = "Payable";
            //dgvAllparties.Columns[0].DataPropertyName = "productid";
            
            dgvAllparties.DataSource = dt;
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            ImportParties BA = new ImportParties();
            //  BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmballparties_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select P.PartyName, P.EmailID, P.ContactNo, concat(S.Received, SO.Received) as Recived, concat(PB.Paid, PO.Paid) as Payable  " +
                    " from tbl_PartyMaster as P, tbl_SaleInvoice as S, tbl_SaleOrder as SO, tbl_PurchaseBill as PB, tbl_PurchaseOrder as PO where(P.PartyName = '{0}')AND(S.PartyName = '{0}')AND(SO.PartyName = '{0}')" +
                    "AND(PB.PartyName = '{0}')AND(PO.PartyName = '{0}' and Company_ID='"+NewCompany.company_id+"') GROUP BY  P.PartyName, P.EmailID, P.ContactNo, S.Received, SO.Received, PB.Paid, PO.Paid ", cmballparties.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvAllparties.DataSource = dt;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                con.Close();
            }
        }

        private void dgvAllparties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
