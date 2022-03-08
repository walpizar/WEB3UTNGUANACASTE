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
using Utilidades.Exceptions;
using Utilidades.Interfaces;

namespace CapaPresentacion
{

    public partial class frmClientes : Form
    {
        public clsCliente cliente { get; set; }
        public INegocio<clsCliente> ClienteNegocio { get; }

        //
        //mandar a llamar a capa de negocio de cliente- guardar
        //ClientesNegocio clienteN = new ClientesNegocio();

        public frmClientes(INegocio<clsCliente> _clienteNegocio)
        {
            InitializeComponent();
            ClienteNegocio = _clienteNegocio;
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
            cargarCombos();

            cboTipoCliente.SelectedIndex = 0;
            cboTipoId.SelectedIndex = 0;


            if (cliente == null)
            {
                lblTitulo.Text = "Crear Cliente";
            }
            else
            {
                lblTitulo.Text = "Modificar Cliente";
                cargarForm();
                txtIdentificacion.Enabled = false;
                cboTipoId.Enabled = false;
            }
          

         
        }

        private void cargarForm()
        {
            txtIdentificacion.Text = cliente.identificacion;
            cboTipoId.Text = Enum.GetName(typeof(Enumeradores.tipoId), cliente.tipoId);
            txtNombre.Text = cliente.nombre;
            txtApellido1.Text = cliente.apellido1;
            txtApellido2.Text = cliente.apellido2;
            cboTipoCliente.Text = Enum.GetName(typeof(Enumeradores.tipoCliente), cliente.tipoCliente);
            dtpFechaSocio.Value = cliente.fecha_socio;

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
            try
            {//validar si es modiicar o crear; 
                bool isOk= validarDatos();
                //permite validar el formulario y da paso a guardar
                if (isOk)
                {
                    //new desde 0
                    //creo new cuando es crear, sino utilizo el prop
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


                    //valiado si crear para llamar al metodo save, sino llamo al medo update.
                    ClienteNegocio.save(cliente);
                    MessageBox.Show("Cliente guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (EntityExistException ex)
            {
             
                MessageBox.Show(ex.Message, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (EntityExistException ex)
            //{

            //    MessageBox.Show(ex.Message, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            catch (Exception ex)
            {
              
                MessageBox.Show("No se pudo guardar, contacte el administrador", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //bandera
          

        }

        //validacion de datos.
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
