using CapaNegocio;
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
using Utilidades;

namespace CapaPresentacion
{

    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Crear Cliente";

            cargarCombos();

            cboTipoCliente.SelectedIndex = 0;
            cboTipoId.SelectedIndex = 0;
        }

        private void cargarCombos()
        {
            cboTipoId.DataSource = Enum.GetValues(typeof(Enumeradores.tipoId));
            cboTipoCliente.DataSource = Enum.GetValues(typeof(Enumeradores.tipoCliente));
        }


        private void gbxCliente_Enter(object sender, EventArgs e)
        {

        }

        private void brnGuardar_Click(object sender, EventArgs e)
        {

            //bandera
           bool isOk= validarDatos();
            //permite validar el formulario y da paso a guardar
            if (isOk)
            {
                //new desde 0
                clsCliente cliente = new clsCliente();

                cliente.identificacion = txtIdentificacion.Text.Trim().ToUpper();
                //int.parse(string) utilizo cuando el valor que quiero convertir es string
                //(int)
                cliente.tipoId = (int)cboTipoId.SelectedValue;
                cliente.nombre= txtNombre.Text.Trim().ToUpper();
                cliente.apellido1 = txtApellido1.Text.Trim().ToUpper();
                cliente.apellido2 = txtApellido2.Text.Trim().ToUpper();
                cliente.tipoCliente = (int)cboTipoCliente.SelectedValue;
                cliente.fecha_socio = dtpFechaSocio.Value;
                cliente.estado = true;

                //mandar a llamar a capa de negocio de cliente- guardar
                ClientesNegocio clienteN = new ClientesNegocio();

                clienteN.guardar(cliente);

            }

        }

       private bool validarDatos()
        {
            if (txtIdentificacion.Text==string.Empty)
            {
                MessageBox.Show("Falta la identificación", "Falta datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Falta el nombre", "Falta datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (txtApellido1.Text == string.Empty)
            {
                MessageBox.Show("Falta el Primer Apellido", "Falta datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (txtApellido2.Text == string.Empty)
            {
                MessageBox.Show("Falta el Segundo Apellido", "Falta datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }
    }
}
