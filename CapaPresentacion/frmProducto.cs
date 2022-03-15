using Entidades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        public IServiceProvider ServiceProvider { get; }
        public frmProducto(IServiceProvider _serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = _serviceProvider;
        }

   

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<frmBusquedaProducto>();
            form.pasarDatosEvent += datosRecibidos;
            form.ShowDialog();
        }

        private void datosRecibidos(clsCliente cliente)
        {
            lblNombre.Text = cliente.nombre;

        }
       

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
