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
    public partial class GSTR2 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public GSTR2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void GSTR2_Load(object sender, EventArgs e)
        {
            Bindadata();
        }
        private void Bindadata()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
                dgvsaleInvoice.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
