namespace DXApplication1
{
    partial class DesignerForm1
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dashboardBarAndDockingController1 = new DevExpress.DashboardWin.Native.DashboardBarAndDockingController(this.components);
            this.dashboardDesigner = new DevExpress.DashboardWin.DashboardDesigner();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.partiesIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billingAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gSTTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openingBalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asOfDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addRemainderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalFeild6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPartyMasterSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryMgntDataSet = new DXApplication1.InventoryMgntDataSet();
            this.tbl_PartyMasterSelectTableAdapter = new DXApplication1.InventoryMgntDataSetTableAdapters.tbl_PartyMasterSelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardDesigner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartyMasterSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryMgntDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardBarAndDockingController1
            // 
            this.dashboardBarAndDockingController1.PropertiesDocking.ViewStyle = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Classic;
            // 
            // dashboardDesigner
            // 
            this.dashboardDesigner.AsyncMode = true;
            this.dashboardDesigner.AutoSize = true;
            this.dashboardDesigner.BarAndDockingController = this.dashboardBarAndDockingController1;
            this.dashboardDesigner.DataSourceWizard.ShowConnectionsFromAppConfig = true;
            this.dashboardDesigner.DataSourceWizard.SqlWizardSettings.DatabaseCredentialsSavingBehavior = DevExpress.DataAccess.Wizard.SensitiveInfoSavingBehavior.Prompt;
            this.dashboardDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardDesigner.Location = new System.Drawing.Point(0, 0);
            this.dashboardDesigner.Name = "dashboardDesigner";
            this.dashboardDesigner.Size = new System.Drawing.Size(1190, 595);
            this.dashboardDesigner.TabIndex = 0;
            this.dashboardDesigner.UseNeutralFilterMode = true;
            this.dashboardDesigner.Load += new System.EventHandler(this.dashboardDesigner_Load);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partiesIDDataGridViewTextBoxColumn,
            this.partyNameDataGridViewTextBoxColumn,
            this.contactNoDataGridViewTextBoxColumn,
            this.billingAddressDataGridViewTextBoxColumn,
            this.emailIDDataGridViewTextBoxColumn,
            this.gSTTypeDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.openingBalDataGridViewTextBoxColumn,
            this.asOfDateDataGridViewTextBoxColumn,
            this.addRemainderDataGridViewTextBoxColumn,
            this.partyTypeDataGridViewTextBoxColumn,
            this.shippingAddressDataGridViewTextBoxColumn,
            this.additionalFeild1DataGridViewTextBoxColumn,
            this.additionalFeild2DataGridViewTextBoxColumn,
            this.additionalFeild3DataGridViewTextBoxColumn,
            this.additionalFeild4DataGridViewTextBoxColumn,
            this.additionalFeild5DataGridViewTextBoxColumn,
            this.additionalFeild6DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblPartyMasterSelectBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(174, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(608, 94);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // partiesIDDataGridViewTextBoxColumn
            // 
            this.partiesIDDataGridViewTextBoxColumn.DataPropertyName = "PartiesID";
            this.partiesIDDataGridViewTextBoxColumn.HeaderText = "PartiesID";
            this.partiesIDDataGridViewTextBoxColumn.Name = "partiesIDDataGridViewTextBoxColumn";
            this.partiesIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partyNameDataGridViewTextBoxColumn
            // 
            this.partyNameDataGridViewTextBoxColumn.DataPropertyName = "PartyName";
            this.partyNameDataGridViewTextBoxColumn.HeaderText = "PartyName";
            this.partyNameDataGridViewTextBoxColumn.Name = "partyNameDataGridViewTextBoxColumn";
            // 
            // contactNoDataGridViewTextBoxColumn
            // 
            this.contactNoDataGridViewTextBoxColumn.DataPropertyName = "ContactNo";
            this.contactNoDataGridViewTextBoxColumn.HeaderText = "ContactNo";
            this.contactNoDataGridViewTextBoxColumn.Name = "contactNoDataGridViewTextBoxColumn";
            // 
            // billingAddressDataGridViewTextBoxColumn
            // 
            this.billingAddressDataGridViewTextBoxColumn.DataPropertyName = "BillingAddress";
            this.billingAddressDataGridViewTextBoxColumn.HeaderText = "BillingAddress";
            this.billingAddressDataGridViewTextBoxColumn.Name = "billingAddressDataGridViewTextBoxColumn";
            // 
            // emailIDDataGridViewTextBoxColumn
            // 
            this.emailIDDataGridViewTextBoxColumn.DataPropertyName = "EmailID";
            this.emailIDDataGridViewTextBoxColumn.HeaderText = "EmailID";
            this.emailIDDataGridViewTextBoxColumn.Name = "emailIDDataGridViewTextBoxColumn";
            // 
            // gSTTypeDataGridViewTextBoxColumn
            // 
            this.gSTTypeDataGridViewTextBoxColumn.DataPropertyName = "GSTType";
            this.gSTTypeDataGridViewTextBoxColumn.HeaderText = "GSTType";
            this.gSTTypeDataGridViewTextBoxColumn.Name = "gSTTypeDataGridViewTextBoxColumn";
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            // 
            // openingBalDataGridViewTextBoxColumn
            // 
            this.openingBalDataGridViewTextBoxColumn.DataPropertyName = "OpeningBal";
            this.openingBalDataGridViewTextBoxColumn.HeaderText = "OpeningBal";
            this.openingBalDataGridViewTextBoxColumn.Name = "openingBalDataGridViewTextBoxColumn";
            // 
            // asOfDateDataGridViewTextBoxColumn
            // 
            this.asOfDateDataGridViewTextBoxColumn.DataPropertyName = "AsOfDate";
            this.asOfDateDataGridViewTextBoxColumn.HeaderText = "AsOfDate";
            this.asOfDateDataGridViewTextBoxColumn.Name = "asOfDateDataGridViewTextBoxColumn";
            // 
            // addRemainderDataGridViewTextBoxColumn
            // 
            this.addRemainderDataGridViewTextBoxColumn.DataPropertyName = "AddRemainder";
            this.addRemainderDataGridViewTextBoxColumn.HeaderText = "AddRemainder";
            this.addRemainderDataGridViewTextBoxColumn.Name = "addRemainderDataGridViewTextBoxColumn";
            // 
            // partyTypeDataGridViewTextBoxColumn
            // 
            this.partyTypeDataGridViewTextBoxColumn.DataPropertyName = "PartyType";
            this.partyTypeDataGridViewTextBoxColumn.HeaderText = "PartyType";
            this.partyTypeDataGridViewTextBoxColumn.Name = "partyTypeDataGridViewTextBoxColumn";
            // 
            // shippingAddressDataGridViewTextBoxColumn
            // 
            this.shippingAddressDataGridViewTextBoxColumn.DataPropertyName = "ShippingAddress";
            this.shippingAddressDataGridViewTextBoxColumn.HeaderText = "ShippingAddress";
            this.shippingAddressDataGridViewTextBoxColumn.Name = "shippingAddressDataGridViewTextBoxColumn";
            // 
            // additionalFeild1DataGridViewTextBoxColumn
            // 
            this.additionalFeild1DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild1";
            this.additionalFeild1DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild1";
            this.additionalFeild1DataGridViewTextBoxColumn.Name = "additionalFeild1DataGridViewTextBoxColumn";
            // 
            // additionalFeild2DataGridViewTextBoxColumn
            // 
            this.additionalFeild2DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild2";
            this.additionalFeild2DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild2";
            this.additionalFeild2DataGridViewTextBoxColumn.Name = "additionalFeild2DataGridViewTextBoxColumn";
            // 
            // additionalFeild3DataGridViewTextBoxColumn
            // 
            this.additionalFeild3DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild3";
            this.additionalFeild3DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild3";
            this.additionalFeild3DataGridViewTextBoxColumn.Name = "additionalFeild3DataGridViewTextBoxColumn";
            // 
            // additionalFeild4DataGridViewTextBoxColumn
            // 
            this.additionalFeild4DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild4";
            this.additionalFeild4DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild4";
            this.additionalFeild4DataGridViewTextBoxColumn.Name = "additionalFeild4DataGridViewTextBoxColumn";
            // 
            // additionalFeild5DataGridViewTextBoxColumn
            // 
            this.additionalFeild5DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild5";
            this.additionalFeild5DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild5";
            this.additionalFeild5DataGridViewTextBoxColumn.Name = "additionalFeild5DataGridViewTextBoxColumn";
            // 
            // additionalFeild6DataGridViewTextBoxColumn
            // 
            this.additionalFeild6DataGridViewTextBoxColumn.DataPropertyName = "AdditionalFeild6";
            this.additionalFeild6DataGridViewTextBoxColumn.HeaderText = "AdditionalFeild6";
            this.additionalFeild6DataGridViewTextBoxColumn.Name = "additionalFeild6DataGridViewTextBoxColumn";
            // 
            // tblPartyMasterSelectBindingSource
            // 
            this.tblPartyMasterSelectBindingSource.DataMember = "tbl_PartyMasterSelect";
            this.tblPartyMasterSelectBindingSource.DataSource = this.inventoryMgntDataSet;
            // 
            // inventoryMgntDataSet
            // 
            this.inventoryMgntDataSet.DataSetName = "InventoryMgntDataSet";
            this.inventoryMgntDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_PartyMasterSelectTableAdapter
            // 
            this.tbl_PartyMasterSelectTableAdapter.ClearBeforeFill = true;
            // 
            // DesignerForm1
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 595);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboardDesigner);
            this.Name = "DesignerForm1";
            this.Text = "Dashboard Designer";
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardDesigner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartyMasterSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryMgntDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.DashboardWin.DashboardDesigner dashboardDesigner;
        private DevExpress.DashboardWin.Native.DashboardBarAndDockingController dashboardBarAndDockingController1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn partiesIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn billingAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gSTTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingBalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asOfDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addRemainderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partyTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalFeild6DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tblPartyMasterSelectBindingSource;
        private InventoryMgntDataSet inventoryMgntDataSet;
        private InventoryMgntDataSetTableAdapters.tbl_PartyMasterSelectTableAdapter tbl_PartyMasterSelectTableAdapter;
    }
}