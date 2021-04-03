namespace sample
{
    partial class DayBook
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayBook));
            this.cmbAllfirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txttotalinout = new System.Windows.Forms.TextBox();
            this.txtmoneyout = new System.Windows.Forms.TextBox();
            this.txtmoneyin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Sale = new System.Windows.Forms.TabPage();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.Purchase = new System.Windows.Forms.TabPage();
            this.dgvpurchase = new System.Windows.Forms.DataGridView();
            this.SaleOrder = new System.Windows.Forms.TabPage();
            this.dgvsaleorder = new System.Windows.Forms.DataGridView();
            this.PurchaseOrder = new System.Windows.Forms.TabPage();
            this.dgvpurchaseorder = new System.Windows.Forms.DataGridView();
            this.OtherIncome = new System.Windows.Forms.TabPage();
            this.dgvOtherIncome = new System.Windows.Forms.DataGridView();
            this.Expenses = new System.Windows.Forms.TabPage();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.PrintExpenses = new System.Windows.Forms.Button();
            this.PrintSale1 = new System.Windows.Forms.Button();
            this.PrintPurchase1 = new System.Windows.Forms.Button();
            this.PirntSaleOrder = new System.Windows.Forms.Button();
            this.PrintPurchaseOrder = new System.Windows.Forms.Button();
            this.PrintOtherIcome = new System.Windows.Forms.Button();
            this.guna2Panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Sale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            this.Purchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchase)).BeginInit();
            this.SaleOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleorder)).BeginInit();
            this.PurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseorder)).BeginInit();
            this.OtherIncome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherIncome)).BeginInit();
            this.Expenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAllfirms
            // 
            this.cmbAllfirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllfirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAllfirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllfirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllfirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAllfirms.HoverState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.ItemHeight = 30;
            this.cmbAllfirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAllfirms.ItemsAppearance.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Location = new System.Drawing.Point(50, 25);
            this.cmbAllfirms.Name = "cmbAllfirms";
            this.cmbAllfirms.ShadowDecoration.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllfirms.StartIndex = 0;
            this.cmbAllfirms.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(879, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Print";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(832, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 26);
            this.label3.TabIndex = 30;
            this.label3.Text = "Excel\r\nReport";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txttotalinout);
            this.guna2Panel1.Controls.Add(this.txtmoneyout);
            this.guna2Panel1.Controls.Add(this.txtmoneyin);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 509);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(981, 68);
            this.guna2Panel1.TabIndex = 37;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // txttotalinout
            // 
            this.txttotalinout.Location = new System.Drawing.Point(793, 22);
            this.txttotalinout.Name = "txttotalinout";
            this.txttotalinout.Size = new System.Drawing.Size(172, 23);
            this.txttotalinout.TabIndex = 44;
            // 
            // txtmoneyout
            // 
            this.txtmoneyout.Location = new System.Drawing.Point(426, 22);
            this.txtmoneyout.Name = "txtmoneyout";
            this.txtmoneyout.Size = new System.Drawing.Size(167, 23);
            this.txtmoneyout.TabIndex = 43;
            // 
            // txtmoneyin
            // 
            this.txtmoneyin.Location = new System.Drawing.Point(128, 22);
            this.txtmoneyin.Name = "txtmoneyin";
            this.txtmoneyin.Size = new System.Drawing.Size(153, 23);
            this.txtmoneyin.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(599, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Money In-Out :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Money In : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(306, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Money Out :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 38;
            this.label13.Text = "Transaction";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(226, 30);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(170, 23);
            this.dtpdate.TabIndex = 39;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancel.Location = new System.Drawing.Point(939, 8);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(29, 26);
            this.btncancel.TabIndex = 36;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(880, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 26);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(837, 33);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(24, 21);
            this.btnimport.TabIndex = 27;
            this.btnimport.UseVisualStyleBackColor = false;
            // 
            // btnminimize
            // 
            this.btnminimize.BackColor = System.Drawing.Color.White;
            this.btnminimize.BackgroundImage = global::sample.Properties.Resources.MinimizeNew;
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnminimize.Location = new System.Drawing.Point(911, 7);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Sale);
            this.tabControl1.Controls.Add(this.Purchase);
            this.tabControl1.Controls.Add(this.SaleOrder);
            this.tabControl1.Controls.Add(this.PurchaseOrder);
            this.tabControl1.Controls.Add(this.OtherIncome);
            this.tabControl1.Controls.Add(this.Expenses);
            this.tabControl1.Location = new System.Drawing.Point(7, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 358);
            this.tabControl1.TabIndex = 442;
            this.tabControl1.Click += new System.EventHandler(this.SaleOrder_Click);
            // 
            // Sale
            // 
            this.Sale.Controls.Add(this.PrintSale1);
            this.Sale.Controls.Add(this.dgvSale);
            this.Sale.Location = new System.Drawing.Point(4, 25);
            this.Sale.Name = "Sale";
            this.Sale.Padding = new System.Windows.Forms.Padding(3);
            this.Sale.Size = new System.Drawing.Size(957, 329);
            this.Sale.TabIndex = 0;
            this.Sale.Text = "Sale";
            this.Sale.Click += new System.EventHandler(this.Sale_Click);
            // 
            // dgvSale
            // 
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSale.Location = new System.Drawing.Point(3, 34);
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.Size = new System.Drawing.Size(951, 289);
            this.dgvSale.TabIndex = 0;
            // 
            // Purchase
            // 
            this.Purchase.Controls.Add(this.PrintPurchase1);
            this.Purchase.Controls.Add(this.dgvpurchase);
            this.Purchase.Location = new System.Drawing.Point(4, 25);
            this.Purchase.Name = "Purchase";
            this.Purchase.Padding = new System.Windows.Forms.Padding(3);
            this.Purchase.Size = new System.Drawing.Size(957, 329);
            this.Purchase.TabIndex = 1;
            this.Purchase.Text = "Purchase";
            this.Purchase.UseVisualStyleBackColor = true;
            this.Purchase.Click += new System.EventHandler(this.Purchase_Click);
            // 
            // dgvpurchase
            // 
            this.dgvpurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchase.Location = new System.Drawing.Point(3, 33);
            this.dgvpurchase.Name = "dgvpurchase";
            this.dgvpurchase.Size = new System.Drawing.Size(951, 293);
            this.dgvpurchase.TabIndex = 1;
            this.dgvpurchase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpurchase_CellContentClick);
            // 
            // SaleOrder
            // 
            this.SaleOrder.Controls.Add(this.PirntSaleOrder);
            this.SaleOrder.Controls.Add(this.dgvsaleorder);
            this.SaleOrder.Location = new System.Drawing.Point(4, 25);
            this.SaleOrder.Name = "SaleOrder";
            this.SaleOrder.Padding = new System.Windows.Forms.Padding(3);
            this.SaleOrder.Size = new System.Drawing.Size(957, 329);
            this.SaleOrder.TabIndex = 2;
            this.SaleOrder.Text = "Sale Order";
            this.SaleOrder.UseVisualStyleBackColor = true;
            this.SaleOrder.Click += new System.EventHandler(this.SaleOrder_Click);
            // 
            // dgvsaleorder
            // 
            this.dgvsaleorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsaleorder.Location = new System.Drawing.Point(3, 32);
            this.dgvsaleorder.Name = "dgvsaleorder";
            this.dgvsaleorder.Size = new System.Drawing.Size(951, 293);
            this.dgvsaleorder.TabIndex = 1;
            // 
            // PurchaseOrder
            // 
            this.PurchaseOrder.Controls.Add(this.PrintPurchaseOrder);
            this.PurchaseOrder.Controls.Add(this.dgvpurchaseorder);
            this.PurchaseOrder.Location = new System.Drawing.Point(4, 25);
            this.PurchaseOrder.Name = "PurchaseOrder";
            this.PurchaseOrder.Padding = new System.Windows.Forms.Padding(3);
            this.PurchaseOrder.Size = new System.Drawing.Size(957, 329);
            this.PurchaseOrder.TabIndex = 3;
            this.PurchaseOrder.Text = "Purchase Order";
            this.PurchaseOrder.UseVisualStyleBackColor = true;
            this.PurchaseOrder.Click += new System.EventHandler(this.PurchaseOrder_Click);
            // 
            // dgvpurchaseorder
            // 
            this.dgvpurchaseorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchaseorder.Location = new System.Drawing.Point(3, 31);
            this.dgvpurchaseorder.Name = "dgvpurchaseorder";
            this.dgvpurchaseorder.Size = new System.Drawing.Size(951, 295);
            this.dgvpurchaseorder.TabIndex = 1;
            // 
            // OtherIncome
            // 
            this.OtherIncome.Controls.Add(this.PrintOtherIcome);
            this.OtherIncome.Controls.Add(this.dgvOtherIncome);
            this.OtherIncome.Location = new System.Drawing.Point(4, 25);
            this.OtherIncome.Name = "OtherIncome";
            this.OtherIncome.Padding = new System.Windows.Forms.Padding(3);
            this.OtherIncome.Size = new System.Drawing.Size(957, 329);
            this.OtherIncome.TabIndex = 4;
            this.OtherIncome.Text = "Other Income";
            this.OtherIncome.UseVisualStyleBackColor = true;
            // 
            // dgvOtherIncome
            // 
            this.dgvOtherIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherIncome.Location = new System.Drawing.Point(3, 31);
            this.dgvOtherIncome.Name = "dgvOtherIncome";
            this.dgvOtherIncome.Size = new System.Drawing.Size(951, 294);
            this.dgvOtherIncome.TabIndex = 2;
            // 
            // Expenses
            // 
            this.Expenses.Controls.Add(this.PrintExpenses);
            this.Expenses.Controls.Add(this.dgvExpenses);
            this.Expenses.Location = new System.Drawing.Point(4, 25);
            this.Expenses.Name = "Expenses";
            this.Expenses.Padding = new System.Windows.Forms.Padding(3);
            this.Expenses.Size = new System.Drawing.Size(957, 329);
            this.Expenses.TabIndex = 5;
            this.Expenses.Text = "Expenses";
            this.Expenses.UseVisualStyleBackColor = true;
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Location = new System.Drawing.Point(4, 34);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.Size = new System.Drawing.Size(951, 293);
            this.dgvExpenses.TabIndex = 2;
            // 
            // PrintExpenses
            // 
            this.PrintExpenses.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PrintExpenses.Location = new System.Drawing.Point(6, 6);
            this.PrintExpenses.Name = "PrintExpenses";
            this.PrintExpenses.Size = new System.Drawing.Size(75, 23);
            this.PrintExpenses.TabIndex = 3;
            this.PrintExpenses.Text = "Print";
            this.PrintExpenses.UseVisualStyleBackColor = false;
            this.PrintExpenses.Click += new System.EventHandler(this.PrintExpenses_Click);
            // 
            // PrintSale1
            // 
            this.PrintSale1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PrintSale1.Location = new System.Drawing.Point(8, 6);
            this.PrintSale1.Name = "PrintSale1";
            this.PrintSale1.Size = new System.Drawing.Size(75, 23);
            this.PrintSale1.TabIndex = 4;
            this.PrintSale1.Text = "Print";
            this.PrintSale1.UseVisualStyleBackColor = false;
            this.PrintSale1.Click += new System.EventHandler(this.PrintSale1_Click);
            // 
            // PrintPurchase1
            // 
            this.PrintPurchase1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PrintPurchase1.Location = new System.Drawing.Point(9, 6);
            this.PrintPurchase1.Name = "PrintPurchase1";
            this.PrintPurchase1.Size = new System.Drawing.Size(75, 23);
            this.PrintPurchase1.TabIndex = 4;
            this.PrintPurchase1.Text = "Print";
            this.PrintPurchase1.UseVisualStyleBackColor = false;
            this.PrintPurchase1.Click += new System.EventHandler(this.PrintPurchase1_Click);
            // 
            // PirntSaleOrder
            // 
            this.PirntSaleOrder.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PirntSaleOrder.Location = new System.Drawing.Point(6, 5);
            this.PirntSaleOrder.Name = "PirntSaleOrder";
            this.PirntSaleOrder.Size = new System.Drawing.Size(75, 23);
            this.PirntSaleOrder.TabIndex = 4;
            this.PirntSaleOrder.Text = "Print";
            this.PirntSaleOrder.UseVisualStyleBackColor = false;
            this.PirntSaleOrder.Click += new System.EventHandler(this.PirntSaleOrder_Click);
            // 
            // PrintPurchaseOrder
            // 
            this.PrintPurchaseOrder.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PrintPurchaseOrder.Location = new System.Drawing.Point(6, 5);
            this.PrintPurchaseOrder.Name = "PrintPurchaseOrder";
            this.PrintPurchaseOrder.Size = new System.Drawing.Size(75, 23);
            this.PrintPurchaseOrder.TabIndex = 4;
            this.PrintPurchaseOrder.Text = "Print";
            this.PrintPurchaseOrder.UseVisualStyleBackColor = false;
            this.PrintPurchaseOrder.Click += new System.EventHandler(this.PrintPurchaseOrder_Click);
            // 
            // PrintOtherIcome
            // 
            this.PrintOtherIcome.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PrintOtherIcome.Location = new System.Drawing.Point(6, 5);
            this.PrintOtherIcome.Name = "PrintOtherIcome";
            this.PrintOtherIcome.Size = new System.Drawing.Size(75, 23);
            this.PrintOtherIcome.TabIndex = 4;
            this.PrintOtherIcome.Text = "Print";
            this.PrintOtherIcome.UseVisualStyleBackColor = false;
            this.PrintOtherIcome.Click += new System.EventHandler(this.PrintOtherIcome_Click);
            // 
            // DayBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAllfirms);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DayBook";
            this.Size = new System.Drawing.Size(981, 577);
            this.Load += new System.EventHandler(this.DayBook_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Sale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            this.Purchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchase)).EndInit();
            this.SaleOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleorder)).EndInit();
            this.PurchaseOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseorder)).EndInit();
            this.OtherIncome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherIncome)).EndInit();
            this.Expenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbAllfirms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncancel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Sale;
        private System.Windows.Forms.TabPage Purchase;
        private System.Windows.Forms.TabPage SaleOrder;
        private System.Windows.Forms.TabPage PurchaseOrder;
        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.DataGridView dgvpurchase;
        private System.Windows.Forms.DataGridView dgvsaleorder;
        private System.Windows.Forms.DataGridView dgvpurchaseorder;
        private System.Windows.Forms.TabPage OtherIncome;
        private System.Windows.Forms.TabPage Expenses;
        private System.Windows.Forms.DataGridView dgvOtherIncome;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.TextBox txtmoneyin;
        private System.Windows.Forms.TextBox txtmoneyout;
        private System.Windows.Forms.TextBox txttotalinout;
        private System.Windows.Forms.Button PrintOtherIncome;
        private System.Windows.Forms.Button PrintSale;
        private System.Windows.Forms.Button PrintPurchase;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button PrintExpenses;
        private System.Windows.Forms.Button PrintSale1;
        private System.Windows.Forms.Button PrintPurchase1;
        private System.Windows.Forms.Button PirntSaleOrder;
        private System.Windows.Forms.Button PrintPurchaseOrder;
        private System.Windows.Forms.Button PrintOtherIcome;
    }
}
