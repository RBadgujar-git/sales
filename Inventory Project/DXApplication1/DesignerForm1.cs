namespace DXApplication1
{
    public partial class DesignerForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DesignerForm1()
        {
            InitializeComponent();
            dashboardDesigner.CreateRibbon();
            dashboardDesigner.LoadDashboard(@"Dashboards\dashboard1.xml");
        }

        private void dashboardDesigner_Load(object sender, System.EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
    }
}
