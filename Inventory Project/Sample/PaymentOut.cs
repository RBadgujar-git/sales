﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;

namespace sample
{
    public partial class PaymentOut : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public PaymentOut()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void PaymentOut_Load(object sender, EventArgs e)
        {
            fetchcustomername();
            fetchdetails();
        }

        private void fetchcustomername()
        {
            if (cmbPartyName.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbPartyName.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void Cleardata()
        {
            cmbPartyName.Text = "";
            cmbPayment.SelectedItem = "";
            txtDescription.Text = "";
            txtReceiptNo.Text = "";
            txtReceived.Text = "0";
            txtDiscount.Text = "0";
            txtTotal.Text = "0";
            PictureBox1.Image = null;
        }

        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from tbl_Paymentout", con);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sdasql.Fill(ds);
            dgvPaymentIn.DataSource = ds.Tables[0].DefaultView;        
        }

        private void InsertData()
        {
         
            try
            {
                if (cmbPartyName.Text == "")
                {
                    MessageBox.Show("Party Name Is Required");
                }

                else
                {
                    MemoryStream ms = new MemoryStream();
                    PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat);
                    byte[] arrImage2 = ms.GetBuffer();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_Paymentoutselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CustomerName", cmbPartyName.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPayment.Text);
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                    cmd.Parameters.Add("@image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Insert data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
       }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
            fetchdetails();
        }

        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   
                    MemoryStream po = new MemoryStream();
                    PictureBox1.Image.Save(po, PictureBox1.Image.RawFormat);
                    byte[] arrImage1 = po.GetBuffer();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_Paymentoutselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CustomerName", cmbPartyName.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPayment.SelectedItem);
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                    cmd.Parameters.Add("@image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;

                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Update data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            Cleardata();
        }

        public void Delete1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_Paymentoutselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@ID", id);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Delete data Successfully");
                         Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }
 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Delete1();
            fetchdetails();
        }

        private void dgvPaymentIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvPaymentIn.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbPartyName.Text = dgvPaymentIn.SelectedRows[0].Cells["CustomerName"].Value.ToString();
            cmbPayment.Text = dgvPaymentIn.SelectedRows[0].Cells["PaymentType"].Value.ToString();
            txtReceiptNo.Text = dgvPaymentIn.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
            dtpDate.Text = dgvPaymentIn.SelectedRows[0].Cells["Date"].Value.ToString();
            txtDescription.Text = dgvPaymentIn.SelectedRows[0].Cells["Description"].Value.ToString();
            txtReceived.Text = dgvPaymentIn.SelectedRows[0].Cells["Paid"].Value.ToString();
            txtDiscount.Text = dgvPaymentIn.SelectedRows[0].Cells["Discount"].Value.ToString();

            SqlCommand cmd = new SqlCommand("select image from tbl_Paymentout", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["image"]);
                ms.Seek(0, SeekOrigin.Begin);
                PictureBox1.Image = Image.FromStream(ms);
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            txtTotal.Text = dgvPaymentIn.SelectedRows[0].Cells["Total"].Value.ToString();

           
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try {

                float receive_cash =0, amt=0 , TP =0;
                receive_cash = float.Parse(txtReceived.Text);
                amt = float.Parse(txtDiscount.Text);
                TP = amt + receive_cash;
                txtTotal.Text = TP.ToString();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Settings BA = new Settings();
            BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte[] arrImage1 = null;
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int count = 1;
                foreach (String file in openFileDialog1.FileNames)
                {
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);

                    if (count == 1)
                    {
                        PictureBox1.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void txtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }
    }
}