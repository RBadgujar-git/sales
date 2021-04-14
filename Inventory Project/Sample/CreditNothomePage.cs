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


    public partial class CreditNothomePage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public CreditNothomePage()
        {
            InitializeComponent();
        }

        public void bind()
        {
            try
            {
                string Query = string.Format("select TableName,InvoiceDate,ReturnNo,PartyName,Total,Received,Status,DueDate from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";
                dgvcreditNote.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreditNothomePage_Load(object sender, EventArgs e)
        {
            fetchCompany();
            bind();
            //bindbankdata();
        }

        private void fetchCompany()
        {
            //if (cmbAllfirms.Text != "System.Data.DataRowView")
            //{
            //    try
            //    {
            //        string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "Temp");
            //        DataTable DT = new DataTable();
            //        SDA.Fill(ds);
            //        for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //        {
            //            cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
            //        }
            //    }
            //    catch (Exception e1)
            //    {
            //        MessageBox.Show(e1.Message);
            //    }
            //}
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreditNote BA = new CreditNote();
            BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
             BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void btncalcel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string Query = string.Format("select  from tbl_BankAccount where CompanyName='{0}' group by AccountNo,Date,OpeningBal", lblBankAccount.Text);
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //da.Fill(ds, "temp");
            //dgvcreditNote.DataSource = ds;
            //dgvcreditNote.DataMember = "temp";

        }
        private void bindbankdata()
        {
            try
            {
                string Query = string.Format("select TableName,InvoiceDate,ReturnNo,PartyName,Total,Received,Status,DueDate from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";
                dgvcreditNote.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                string Query = string.Format("select TableName,InvoiceDate,ReturnNo,PartyName,Total,Received,Status,DueDate from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and PartyName like '%{0}%' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpto_Enter(object sender, EventArgs e)
        {
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
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.AddLogo,a.GSTNumber,b.InvoiceDate,b.PartyName,b.ReturnNo,b.TableName,b.Total,b.Received ,b.Company_ID, b.RemainingBal ,b.Status,b.DueDate FROM tbl_CompanyMaster as a, tbl_CreditNote1 as b where a.CompanyID='" + NewCompany.company_id + "' and b.DeleteData='1' ");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();

                    report.Load(@"CreditNoteData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("CreditNoteData", "CreditNoteData", ds.Tables[0]);

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

        private void dgvcreditNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            bind();
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_CreditNote1 where InvoiceDate between '" + dtpfrom.Value.ToString() + "' and '" + dtpto.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";
                dgvcreditNote.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }

        }
    }
}
