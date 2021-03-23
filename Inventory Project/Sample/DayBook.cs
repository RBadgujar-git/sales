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
    public partial class DayBook : UserControl
    {
        public string date1;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);


        public FormWindowState WindowState { get; private set; }

        public DayBook()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void DayBook_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked = true)
            {
                bind_sale();
            }
            else if(radioButton2.Checked=true)
            {
                bind_purchase();
            }
          // = DateTime.Now.ToShortDateString();
          
           // bind_purchase();
        }
        private void bind_sale()
        {
            try
            {
                date1 = DateTime.Now.ToString("MM/dd/yyyy");
                String Str = string.Format("Select PartyName as Name,InvoiceID as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_SaleInvoice where InvoiceDate='{0}' and Company_ID='"+NewCompany.company_id+"' and DeleteData='1'",date1);
                DataSet Ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Str, con);
                SDA.Fill(Ds, "Temp");
               
                dgvdaybook.DataSource = Ds;
                dgvdaybook.DataMember = "Temp";
               
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                Bind_sale_TotalAmount();
            }
        }

        //private void BindPurchase_TotalAmount()
        //{
        //    try
        //    {
        //        float Sum = 0;

        //        for (int i = 0; i < dgvdaybook.Rows.Count; i++)
        //        {
        //            Sum = Sum + float.Parse(dgvdaybook.Rows[i].Cells[2].Value.ToString());
        //            txtMoneyOut.Text = Sum.ToString();
        //        }
        //    }
        //    catch (Exception e1)
        //    {
        //        //MessageBox.Show(e1.Message);
        //    }
        //}
        private void Bind_sale_TotalAmount()
        {
            try
            {
                float Sum = 0;

                for (int i = 0; i < dgvdaybook.Rows.Count; i++)
                {
                    Sum = Sum + float.Parse(dgvdaybook.Rows[i].Cells[3].Value.ToString());
                    txtmoneyIn.Text = Sum.ToString();
                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
