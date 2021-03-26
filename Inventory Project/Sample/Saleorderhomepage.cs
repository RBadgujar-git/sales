using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class Saleorderhomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public Saleorderhomepage()
        {
            InitializeComponent();
        }

        private void Saleorderhomepage_Load(object sender, EventArgs e)
        {


            showdata();
            //try
            //{
            //    con.Open();
            //    //    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            //     SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SaleOrder", con);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //    SDA.Fill(ds, "temp");
            //    con.Close();

            //    dgvSaleOrder.AutoGenerateColumns = false;
            //    dgvSaleOrder.ColumnCount = 6;
            //    dgvSaleOrder.Columns[0].HeaderText = "OrderNo";
            //    dgvSaleOrder.Columns[0].DataPropertyName = "OrderNo";
            //    dgvSaleOrder.Columns[1].HeaderText = " Party Name";
            //    dgvSaleOrder.Columns[1].DataPropertyName = "PartyName";
            //    dgvSaleOrder.Columns[2].HeaderText = "OrderDate";
            //    dgvSaleOrder.Columns[2].DataPropertyName = "OrderDate";
            //    dgvSaleOrder.Columns[3].HeaderText = "DueDate";
            //    dgvSaleOrder.Columns[3].DataPropertyName = "DueDate";
            //    dgvSaleOrder.Columns[4].HeaderText = "Total";
            //    dgvSaleOrder.Columns[4].DataPropertyName = "Total";
            //    dgvSaleOrder.Columns[5].HeaderText = "Received";
            //    dgvSaleOrder.Columns[5].DataPropertyName = "Received";
            //    dgvSaleOrder.Columns[4].HeaderText = "Remaining Bal";
            //    dgvSaleOrder.Columns[4].DataPropertyName = "RemainingBal";
            //    dgvSaleOrder.Columns[5].HeaderText = "Status";
            //    dgvSaleOrder.Columns[5].DataPropertyName = "Status";


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

   


        private void btnSaleorder_Click(object sender, EventArgs e)
        {
            SaleOrder BA = new SaleOrder();
            BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select OrderNo, PartyName, OrderDate, DueDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where  OrderDate between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        public void showdata()
        {
            try
            {
                string Query = string.Format("select OrderNo, PartyName, OrderDate, DueDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }


        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select OrderNo, PartyName, OrderDate, DueDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where  PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvSaleOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.OrderNo,b.PartyName,b.OrderDate,b.DueDate,b.Total,b.Received,b.RemainingBal,b.Status,b.DeleteData FROM tbl_CompanyMaster as a, tbl_SaleOrder as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"SaleOrderData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("SaleOrder", "SaleOrder", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
