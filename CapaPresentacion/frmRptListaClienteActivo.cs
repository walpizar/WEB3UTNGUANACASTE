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
    public partial class frmRptListaClienteActivo : Form
    {
        public frmRptListaClienteActivo()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
        
        }

        private void frmRptListaClienteActivo_Load(object sender, EventArgs e)
        {
            try
            {
                var stringCnx = ConfigurationManager.ConnectionStrings["dbUtnProgra3Entities"].ConnectionString;
                var ecsbuild = new EntityConnectionStringBuilder(stringCnx);
                var conection = ecsbuild.ProviderConnectionString;

                SqlConnection cnx = new SqlConnection(conection);

                dsReportes ds = new dsReportes();
                rptClientesActivos reporte = new rptClientesActivos();

                cnx.Open();
                reportes.dsReportesTableAdapters.sp_listaClientesActivosTableAdapter dt = new reportes.dsReportesTableAdapters.sp_listaClientesActivosTableAdapter();
                dt.Connection = cnx;
                dt.Fill(ds.sp_listaClientesActivos);
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
