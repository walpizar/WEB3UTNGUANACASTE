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
    public partial class frmRptClienteXTipo : Form
    {


        public frmRptClienteXTipo()
        {
            InitializeComponent();
        }

        private void frmRptClienteXTipo_Load(object sender, EventArgs e)
        {
            try
            {
                var stringCnx = ConfigurationManager.ConnectionStrings["dbUtnProgra3Entities"].ConnectionString;
                var ecsbuild = new EntityConnectionStringBuilder(stringCnx);
                var conection = ecsbuild.ProviderConnectionString;

                SqlConnection cnx = new SqlConnection(conection);

                dsReportes ds = new dsReportes();
                rptClienteActivoXTipo reporte = new rptClienteActivoXTipo();

                cnx.Open();
                reportes.dsReportesTableAdapters.sp_listaClientesActivosPorTipoTableAdapter dt = new reportes.dsReportesTableAdapters.sp_listaClientesActivosPorTipoTableAdapter();
                dt.Connection = cnx;
                dt.Fill(ds.sp_listaClientesActivosPorTipo,2);
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
