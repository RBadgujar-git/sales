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
    public partial class DebitNotehomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
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

        private void DebitNotehomepage_Load(object sender, EventArgs e)
        {
            bindbankdata();
            fetchCompany();
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName where DeleteData='1' ");
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
            SqlCommand cmd = new SqlCommand("select * from tbl_DebitNote where DeleteData='1' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvdebitNote.AutoGenerateColumns = false;
            dgvdebitNote.ColumnCount = 9;
            dgvdebitNote.Columns[0].HeaderText = "Type";
            dgvdebitNote.Columns[0].DataPropertyName = "TableName";
            dgvdebitNote.Columns[1].HeaderText = "Date";
            dgvdebitNote.Columns[1].DataPropertyName = "InvoiceDate";
            dgvdebitNote.Columns[2].HeaderText = "Ref No";
            dgvdebitNote.Columns[2].DataPropertyName = "ReturnNo";
            dgvdebitNote.Columns[3].HeaderText = "Party";
            dgvdebitNote.Columns[3].DataPropertyName = "PartyName";
            dgvdebitNote.Columns[4].HeaderText = "Total";
            dgvdebitNote.Columns[4].DataPropertyName = "Total";
            dgvdebitNote.Columns[5].HeaderText = "Paid/Recieved";
            dgvdebitNote.Columns[5].DataPropertyName = "Received";
            dgvdebitNote.Columns[6].HeaderText = "Balance";
            dgvdebitNote.Columns[6].DataPropertyName = "RemainingBal";
            dgvdebitNote.Columns[7].HeaderText = "Status";
            dgvdebitNote.Columns[7].DataPropertyName = "Status";

            dgvdebitNote.Columns[8].HeaderText = "Due Date";
            dgvdebitNote.Columns[8].DataPropertyName = "DueDate";
            dgvdebitNote.DataSource = dt;
        }


        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select PartyName from tbl_DebitNote where PartyName like '%{0}%'", txtFilter.Text);
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
                string SelectQuery = string.Format("select TableName,InvoiceDate,PartyName,ReturnNo,Total,Received,RemainingBal,Status from tbl_DebitNote where InvoiceDate between '" + dtpfromdate.Value.ToString() + "' and '" + dtptodate.Value.ToString() + "'");
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

        }
    }
}

