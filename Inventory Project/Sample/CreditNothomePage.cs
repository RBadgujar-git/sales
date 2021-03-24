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

        private void CreditNothomePage_Load(object sender, EventArgs e)
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
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName");
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
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvcreditNote.AutoGenerateColumns = false;
            dgvcreditNote.ColumnCount =9;
            dgvcreditNote.Columns[0].HeaderText = "Type";
            dgvcreditNote.Columns[0].DataPropertyName = "TableName";
            dgvcreditNote.Columns[1].HeaderText = "Date";
            dgvcreditNote.Columns[1].DataPropertyName = "InvoiceDate";
            dgvcreditNote.Columns[2].HeaderText = "Ref No";
            dgvcreditNote.Columns[2].DataPropertyName = "ReturnNo";
            dgvcreditNote.Columns[3].HeaderText = "Party";
            dgvcreditNote.Columns[3].DataPropertyName = "PartyName";
            dgvcreditNote.Columns[4].HeaderText = "Total";
            dgvcreditNote.Columns[4].DataPropertyName = "Total";
            dgvcreditNote.Columns[5].HeaderText = "Paid/Recieved";
            dgvcreditNote.Columns[5].DataPropertyName = "Received";
            dgvcreditNote.Columns[6].HeaderText = "Balance";
            dgvcreditNote.Columns[6].DataPropertyName = "RemainingBal";
            dgvcreditNote.Columns[7].HeaderText = "Status";
            dgvcreditNote.Columns[7].DataPropertyName = "Status";
          
            dgvcreditNote.Columns[8].HeaderText = "Due Date";
            dgvcreditNote.Columns[8].DataPropertyName = "DueDate";
           


            dgvcreditNote.DataSource = dt;
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select PartyName from tbl_CreditNote1 where PartyName like '%{0}%' andCompany_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
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
            try
            {
                string SelectQuery = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_CreditNote1 where InvoiceDate between '" + dtpfrom.Value.ToString() + "' and '" + dtpto.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}
