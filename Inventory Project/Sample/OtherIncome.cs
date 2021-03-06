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
using System.IO;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class OtherIncome : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public OtherIncome()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void OtherIncome_Load(object sender, EventArgs e)
        {
            get_id();
            fetchexpenses();
            txtReturnNo.Enabled = false;
            txtTotal.Enabled = false;
            this.dgvinnerexpenses.AllowUserToAddRows = false;
        }
        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX (CAST( ID as INT)) from tbl_OtherIncome", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string Value = rd[0].ToString();
                    if (Value == "")
                    {
                        txtReturnNo.Text = "1";
                    }
                    else
                    {
                       
                        int iddd =Convert.ToInt32(rd[0]) + 1;
                        txtReturnNo.Text = iddd.ToString();
                        //txtReturnNo.Text = (Convert.ToInt64(txtReturnNo.Text) + 1).ToString();
                    }
                }
                con.Close();
                //rd.Close();
            }
        }
        private void fetchexpenses()
        {
            if (cmbexpenses.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select OtherIncome from tbl_otherIncomeCaategory where DeleteData='1' and Company_ID='" + NewCompany.company_id + "' group by OtherIncome");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbexpenses.Items.Add(ds.Tables["Temp"].Rows[i]["OtherIncome"].ToString());
                        dgvinnerexpenses.AllowUserToAddRows= false;
                    }
                }
                catch (Exception e1) {
                   // MessageBox.Show(e1.Message);
                }
            }
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float qty = 0, rate = 0, total = 0;
                qty = float.Parse(txtOty.Text.ToString());
                rate = float.Parse(txtMRP.Text.ToString());
                total = qty * rate;
                txtitemamount.Text = total.ToString();
                txtTotal.Text = total.ToString();
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }

        object id1;
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvinnerexpenses.Rows.Count; i++) {
                try {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_OtherIncomeInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@Id_inner",txtReturnNo.Text);
                    cmd.Parameters.AddWithValue("@Id", txtReturnNo.Text);
                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount
                
                    cmd.Parameters.AddWithValue("@ItemName", dgvinnerexpenses.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvinnerexpenses.Rows[i].Cells["Price"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvinnerexpenses.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvinnerexpenses.Rows[i].Cells["Amount"].Value.ToString());
                   cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
             //       cmd.Parameters.AddWithValue("@del",1);
                    cmd.ExecuteNonQuery();
                    dgvinnerexpenses.AllowUserToAddRows = false;
                }
                catch (Exception e1) {
                 // MessageBox.Show(e1.Message);
                }
                finally {
                    con.Close();
                }
            }
        }

        private void insertdata()
            {
            //ID,ExpenseCategory,Date,Description,Image,Total,Paid,Balance,AdditinalFeild1,AdditionalFeild2
            try {

                MemoryStream ms = new MemoryStream();
                picturebox1.Image.Save(ms, picturebox1.Image.RawFormat);
                byte[] arrImage1 = ms.GetBuffer();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_OtherIncomeSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
               cmd.Parameters.AddWithValue("@Id", txtReturnNo.Text);
              //  cmd.Parameters.AddWithValue("@Id1",ddd);
                cmd.Parameters.AddWithValue("@IncomeCategory", cmbexpenses.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescritpition.Text);           
                cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                cmd.Parameters.AddWithValue("@Balance", txtBalance.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                //cmd.Parameters.AddWithValue("@AdditionalFeild1", txtrefNo.Text);
                //cmd.Parameters.AddWithValue("@Additional2", txtAdditional1.Text);
                cmd.Parameters.AddWithValue("@Status",ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Income.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Other Income Record Added");
               // MessageBox.Show("dfhfhfhh"+id1);
            }
            catch (Exception e1) {
                //MessageBox.Show(e1.Message);
            }
            finally
            {
                con.Close();
                insert_record_inner(txtReturnNo.ToString());
            }
        }
        int row = 0;
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string str = string.Format("SELECT * FROM tbl_OtherIncome where Id =" + txtReturnNo.Text + " and  Company_ID='" + NewCompany.company_id + "'");
            SqlCommand cmd = new SqlCommand(str, con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Close();
            if (id == "")
            {
                //if (dr.HasRows)
                //{
                //    MessageBox.Show("You Have To No Permission To Save This Record !");
                //    dr.Close();
                //}
                //else
                //{
                    dr.Close();
                    validdata();
                    if (veryfi == 1)
                    {
                        insertdata();
                        //bind_sale_details();
                        get_id();
                        clear_text_data();
                        cleardata();
                    }

                //}
            }
            else
            {
                MessageBox.Show("You Have To No Permission To Insert This Record");
            }
        }

        private void txtitemamount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    float TA = 0, TD = 0, TGST = 0;
                    dgvinnerexpenses.Rows.Add();
                    row = dgvinnerexpenses.Rows.Count - 1;
                    dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
                    dgvinnerexpenses.CurrentCell = dgvinnerexpenses[1, row];

                    e.SuppressKeyPress = true;
                    string Item = txtItem.Text;

                    string MRP = txtMRP.Text;
                    string qty = txtOty.Text;

                    string Total = txtitemamount.Text;

                    dgvinnerexpenses.Rows[row].Cells[1].Value = Item;
                    dgvinnerexpenses.Rows[row].Cells[2].Value = MRP;
                    dgvinnerexpenses.Rows[row].Cells[3].Value = qty;
                    dgvinnerexpenses.Rows[row].Cells[4].Value = Total;

                    txtItem.Focus();

                    for (int i = 0; i < dgvinnerexpenses.RowCount; i++)
                    {
                        TA += float.Parse(dgvinnerexpenses.Rows[i].Cells["Amount"].Value?.ToString());

                        txtTotal.Text = TA.ToString();

                    }
                    //clear_text_data();
                }
            }
            catch (Exception e1)
            {
                string message = e1.Message;
            }
            finally
            {
                //clear_text_data();
                txtItem.Text = "";
                txtMRP.Text = "";
                txtOty.Text = "";
                txtitemamount.Text = "";
            }
        }
        private void clear_text_data()
        {
            txtItem.Text = "";
            txtMRP.Text = "0";
            txtOty.Text = "0";
            txtitemamount.Text = "0";
            //dgvinnerexpenses.Rows.Clear();
        }
        private void cleardata()
        {
            cmbexpenses.Text = "";
            txtdescritpition.Text = "";
            picturebox1.Image = null;
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBalance.Text = "0";
            ComboBox.Text = "";
            dgvinnerexpenses.Rows.Clear();
        }

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                bind_sale_details();
            }
        }
        private void bind_sale_details()
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tbl_OtherIncome where Id='{0}' and  Company_ID='"+NewCompany.company_id+ "'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                SqlDataReader dr = cmd.ExecuteReader();
               
                if (dr.HasRows) {

                    while (dr.Read()) {
                        cmbexpenses.Text = dr["IncomeCategory"].ToString();
                        // txtBillingAdd.Text = dr["BillingName"].ToString();

                        dtpDate.Text = dr["Date"].ToString();
                        txtdescritpition.Text = dr["Description"].ToString();

                        txtTotal.Text = dr["Total"].ToString();
                        txtReceived.Text = dr["Received"].ToString();
                        txtBalance.Text = dr["Balance"].ToString();
                        //txtrefNo.Text = dr["AdditionalFeild1"].ToString();
                        //txtAdditional1.Text = dr["Additional2"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        //Income.Text = dr["TableName"].ToString();
                        id = dr["id"].ToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                            ms.Seek(0, SeekOrigin.Begin);
                            picturebox1.Image = Image.FromStream(ms); ;
                            picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }



                string str1 = string.Format("SELECT * FROM tbl_OtherIncomeInner3 where Id='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                     while (dr1.Read())
                     {
                        dgvinnerexpenses.Rows.Add();
                        dgvinnerexpenses.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvinnerexpenses.Rows[i].Cells["Item"].Value = dr1["ItemName"].ToString();
                        dgvinnerexpenses.Rows[i].Cells["Price"].Value = dr1["SalePrice"].ToString();
                        dgvinnerexpenses.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvinnerexpenses.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();
                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                
            }
        }

        private void update_record_inner(string p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdn = new SqlCommand("tbl_OtherIncomeInnersp", con);
            cmdn.CommandType = CommandType.StoredProcedure;
            cmdn.Parameters.AddWithValue("@Action", "Delete");
            cmdn.Parameters.AddWithValue("@Id", txtReturnNo.Text);
            cmdn.ExecuteNonQuery();

            for (int i = 0; i < dgvinnerexpenses.Rows.Count; i++) {
                try {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_OtherIncomeInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@Id_inner",txtReturnNo.Text);
                    cmd.Parameters.AddWithValue("@Id", txtReturnNo.Text);
                   
                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount
                   
                    cmd.Parameters.AddWithValue("@ItemName", dgvinnerexpenses.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvinnerexpenses.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvinnerexpenses.Rows[i].Cells["Price"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvinnerexpenses.Rows[i].Cells["Amount"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                    dgvinnerexpenses.AllowUserToAddRows = false;
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void update()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                picturebox1.Image.Save(ms, picturebox1.Image.RawFormat);
                byte[] arrImage1 = ms.GetBuffer();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_OtherIncomeSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", txtReturnNo.Text);
                cmd.Parameters.AddWithValue("@IncomeCategory", cmbexpenses.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescritpition.Text);
                // cmd.Parameters.AddWithValue("@Description", .Text);
                cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                cmd.Parameters.AddWithValue("@Balance", txtBalance.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@AdditionalFeild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Additional2", txtAdditional1.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Income.Text);
                cmd.Parameters.AddWithValue("@Action", "Update");

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Other Income Record Updated !!");
                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                con.Close();
                update_record_inner(txtReturnNo.ToString());
            }

        }

        public int veryfi = 0;

        public void validdata()
        {
            if (cmbexpenses.Text == "")
            {
                MessageBox.Show("Income Category is Required");
                cmbexpenses.Focus();

            }
            //else if (txtItem.Text == "")
            //{
            //    MessageBox.Show("Item Name Is Required");
            //    txtItem.Focus();

            //}
            //else if (txtMRP.Text == "")
            //{
            //    MessageBox.Show("Please Enter the MRP of Item");
            //    txtMRP.Focus();
            //}
            //else if (txtOty.Text == "")
            //{
            //    MessageBox.Show("Quantity is Required");
            //    txtOty.Focus();
            //}
            else if (ComboBox.Text == "")
            {
                MessageBox.Show("Payment Status is Required");
            }
            else
            {
                veryfi = 1;
            }
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                validdata();
                if (veryfi == 1)
                {
                    string str = string.Format("SELECT * FROM tbl_OtherIncome where Id =" + txtReturnNo.Text + " and  Company_ID='" + NewCompany.company_id + "'");
                    SqlCommand cmd = new SqlCommand(str, con);
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                   
                    if (dr.HasRows)
                    {
                        dr.Close();
                        update();
                        get_id();
                        clear_text_data();
                        cleardata();
                       
                    }

                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
           
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try {
                float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;

                // receive_bank = float.Parse(txtreceive_in_bank.Text);
                receive_cash = float.Parse(txtReceived.Text);
                GT = float.Parse(txtTotal.Text);

                //if (txtreceive_in_bank.Text != "") {
                //  TP = GT - receive_bank;
                //   txtpending_amt.Text = TP.ToString();
                //}
                //else {
                TP = GT - receive_cash;
                txtBalance.Text = TP.ToString();
                //}
            }
            catch (Exception e1) {
                  //MessageBox.Show(e1.Message);
            }
        }       
        byte[] arrImage1;
        private void picturebox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                int count = 1;
                foreach (String file in openFileDialog1.FileNames) {
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);

                    if (count == 1) {
                        picturebox1.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picturebox1.Image.Save(ms, picturebox1.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void chkenble_CheckedChanged(object sender, EventArgs e)
        {
            if (chkenble.Checked == true)
            {
                txtReturnNo.Enabled = true;
                
            }
            else {
                txtReturnNo.Enabled = false;
                cleardata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtitemamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            cmbexpenses.Text = "";
            txtdescritpition.Text = "";
            picturebox1.Image = null;
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBalance.Text = "0";
            ComboBox.Text = "";
            cleardata();
            clear_text_data();
            
        }
        private void dgvinnerexpenses_DoubleClick(object sender, EventArgs e)
        {
            txtItem.Text = this.dgvinnerexpenses.CurrentRow.Cells[1].Value.ToString();
            txtMRP.Text = this.dgvinnerexpenses.CurrentRow.Cells[2].Value.ToString();
            txtOty.Text = this.dgvinnerexpenses.CurrentRow.Cells[3].Value.ToString();
            txtitemamount.Text = this.dgvinnerexpenses.CurrentRow.Cells[4].Value.ToString();

            int row = dgvinnerexpenses.CurrentCell.RowIndex;
            dgvinnerexpenses.Rows.RemoveAt(row);
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBalance.Text = "0";
            ComboBox.Text = "";
            dgvinnerexpenses.AllowUserToAddRows = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select c.AdditinalFeild1,c.AdditinalFeild2,c.AdditinalFeild3,a.Id,a.ItemName,a.SalePrice,a.DeleteData,a.Qty,a.ItemAmount,b.Id,b.IncomeCategory,b.Date,b.Balance,b.Received,b.Status,b.Company_ID,b.DeleteData,c.CompanyName,c.CompanyID,c.Address,c.PhoneNo,c.EmailID,c.AddLogo,c.GSTNumber  from tbl_OtherIncomeInner3 as a,tbl_OtherIncome as b,tbl_CompanyMaster as c where a.Id={0} and b.Id={1} and c.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.DeleteData='1'", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"OtherIncomeReport1.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("OtherIncome", "OtherIncome", ds.Tables[0]);

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

        private void dgvinnerexpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtReturnNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtitemamount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
