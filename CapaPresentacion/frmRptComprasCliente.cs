using CapaPresentacion.reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRptComprasCliente : Form
    {
        public frmRptComprasCliente()
        {
            InitializeComponent();
        }

        private void frmRptComprasCliente_Load(object sender, EventArgs e)
        {
            try
            {
                var stringCnx = ConfigurationManager.ConnectionStrings["NorthwindCnx"].ConnectionString;
                //var ecsbuild = new EntityConnectionStringBuilder(stringCnx);
                //var conection = ecsbuild.ProviderConnectionString;

                SqlConnection cnx = new SqlConnection(stringCnx);

                dsNorthwind ds = new dsNorthwind();
                rptComprasCliente reporte = new rptComprasCliente();

                cnx.Open();
                reportes.dsNorthwindTableAdapters.sp_VentaPorClienteTableAdapter dt = new reportes.dsNorthwindTableAdapters.sp_VentaPorClienteTableAdapter();
                dt.Connection = cnx;
                dt.Fill(ds.sp_VentaPorCliente, "VINET");
                reporte.SetDataSource(ds);

                crvReporte.ReportSource = reporte;
                crvReporte.Refresh();

            }
            catch (Exception)
            {

                MessageBox.Show("Error al cagar el reporte");
            }
        }
    }
}
