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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class DebitNotehomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public DebitNotehomepage()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            DebitNote BA = new DebitNote();
            BA.TopLevel = false;
            // BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }
        private void Bindadata1(int m)
        {

            try
            {
                string Query = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + m + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvdebitNote.DataSource = ds;
                dgvdebitNote.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DebitNotehomepage_Load(object sender, EventArgs e)
        {
           // fetchCompany();
            bindbankdata();
          
        }
        private void fetchCompany()
        {
            //try
            //{
            //    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' group by CompanyName");
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //    SDA.Fill(ds, "Temp");
            //    DataTable DT = new DataTable();
            //    SDA.Fill(ds);
            //    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //    {
            //       cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
            //    }
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}

        }
        private void bindbankdata()
        {
            try
            {
                string Query = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvdebitNote.DataSource = ds;
                dgvdebitNote.DataMember = "temp";
                dgvdebitNote.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_DebitNote where PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvdebitNote.DataSource = ds;
                dgvdebitNote.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtptodate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_DebitNote where InvoiceDate between '" + dtpfromdate.Value.ToString() + "' and '" + dtptodate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvdebitNote.DataSource = ds;
                dgvdebitNote.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }

        }

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //if (cmbAllfirms.Text == "")
            //{
            //    Bindadata1(Convert.ToInt32(NewCompany.company_id));
            //}
            //else
            //{
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }
            //    SqlCommand cmd = new SqlCommand("Select CompanyID from tbl_CompanyMaster where  CompanyName='" + cmbAllfirms.Text + "' and DeleteData='1' ", con);
            //    int compid = Convert.ToInt32(cmd.ExecuteScalar());
            //    Bindadata1(compid);

            //}
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.TableName,b.PartyName,b.DueDate,b.InvoiceDate,b.Total,b.ReturnNo,b.Received,b.RemainingBal,b.Status,b.DeleteData FROM tbl_CompanyMaster as a, tbl_DebitNote as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DebitNoteDataReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DebitNote", "DebitNote", ds.Tables[0]);

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

        private void btnimport_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            bindbankdata();
        }
    }
}

