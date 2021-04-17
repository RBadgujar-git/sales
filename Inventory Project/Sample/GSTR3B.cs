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
    public partial class GSTR3B : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public GSTR3B()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void Bindadata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dgvsaleInvoice.AutoGenerateColumns = false;
            dgvsaleInvoice.ColumnCount = 8;
            dgvsaleInvoice.Columns[0].HeaderText = "Date";
            dgvsaleInvoice.Columns[0].DataPropertyName = "InvoiceDate";
            dgvsaleInvoice.Columns[1].HeaderText = " Invoice No";
            dgvsaleInvoice.Columns[1].DataPropertyName = "InvoiceID";
            dgvsaleInvoice.Columns[2].HeaderText = "Party Name";
            dgvsaleInvoice.Columns[2].DataPropertyName = "PartyName";
            dgvsaleInvoice.Columns[3].HeaderText = " PaymentType";
            dgvsaleInvoice.Columns[3].DataPropertyName = "PaymentType";
            dgvsaleInvoice.Columns[4].HeaderText = "Total";
            dgvsaleInvoice.Columns[4].DataPropertyName = "Total";
            dgvsaleInvoice.Columns[5].HeaderText = " Received";
            dgvsaleInvoice.Columns[5].DataPropertyName = "Received";
            dgvsaleInvoice.Columns[6].HeaderText = "Remaining Bal";
            dgvsaleInvoice.Columns[6].DataPropertyName = "RemainingBal";
            dgvsaleInvoice.Columns[7].HeaderText = " Status";
            dgvsaleInvoice.Columns[7].DataPropertyName = "Status";
            dgvsaleInvoice.DataSource = dt;
            dgvsaleInvoice.AllowUserToAddRows = false;
        }

        private void dgvsaleInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GSTR3B_Load(object sender, EventArgs e)
        {
            Bindadata();
        }
    }
}
