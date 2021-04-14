﻿using System;
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
    public partial class BankStatement : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public BankStatement()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void BankStatement_Load(object sender, EventArgs e)
        {
            bankname(); 
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbbankname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select a.Company_ID,a.Date,a.ToBank, a.Descripition,a.Amount,b.BankName,b.OpeningBal from tbl_BankToBankTransfer as a,tbl_BankAccount as b where b.BankName='{0}' and a.Company_ID='" + NewCompany.company_id + "'" , cmbbankname.Text);
                    //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvbankStatement.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void bankname()
        {

            if (cmbbankname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbbankname.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DataSet ds = new DataSet();
            //        string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");
            //        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            //        SDA.Fill(ds);

            //        StiReport report = new StiReport();
            //        report.Load(@"PurchaseBillData.mrt");

            //        report.Compile();
            //        StiPage page = report.Pages[0];
            //        report.RegData("PurchaseBillData", "PurchaseBillData", ds.Tables[0]);

            //        report.Dictionary.Synchronize();
            //        report.Render();
            //        report.Show(false);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void dgvbankStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
