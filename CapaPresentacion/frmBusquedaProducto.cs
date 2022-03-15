using Entidades;
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
    public partial class frmBusquedaProducto : Form
    {

        public delegate void pasarDatos(clsCliente cliente);
        public event pasarDatos pasarDatosEvent;

        public frmBusquedaProducto()
        {
            InitializeComponent();
        }

        private void frmBusquedaProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnPasar_Click(object sender, EventArgs e)
        {

            clsCliente cliente = new clsCliente();
            cliente.nombre = txtNombre.Text;
            pasarDatosEvent(cliente);
            this.Close();
        }
    }
}
