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
    public partial class EstimateQuotationhomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public EstimateQuotationhomepage()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Estimate_Quotation BA = new Estimate_Quotation();
            BA.TopLevel = false;
            // BA.AutoScroll = true;
            this.Controls.Add(BA);
          //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select PartyName from tblQuotation where PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EstimateQuotationhomepage_Load(object sender, EventArgs e)
        {
            fetchCompany();
            bindbankdata();
        }

        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tblQuotation where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvEstimate.AutoGenerateColumns = false;
            dgvEstimate.ColumnCount = 9;
            dgvEstimate.Columns[0].HeaderText = "Name";
            dgvEstimate.Columns[0].DataPropertyName = "PartyName";
            dgvEstimate.Columns[1].HeaderText = "Date";
            dgvEstimate.Columns[1].DataPropertyName = "Date";
            
            dgvEstimate.Columns[2].HeaderText = "Total";
            dgvEstimate.Columns[2].DataPropertyName = "Total";
           
            dgvEstimate.Columns[3].HeaderText = "Status";
            dgvEstimate.Columns[3].DataPropertyName = "Status";

          


            dgvEstimate.DataSource = dt;
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select Date,PartyName,ReturnNo,Total,Status from tblQuotation where Date between '" + dtpfrom.Value.ToString() + "' and '" + dtpto.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
    
}
