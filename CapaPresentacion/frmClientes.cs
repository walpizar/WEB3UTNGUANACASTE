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


        bool isNew = true;
        public tbCliente clienteGlobal { get; set; }
        public INegocio<tbCliente> ClienteNegocio { get; }

        //
        //mandar a llamar a capa de negocio de cliente- guardar
        //ClientesNegocio clienteN = new ClientesNegocio();

        public frmClientes(INegocio<tbCliente> _clienteNegocio)
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

            //if (clienteGlobal == null)
            //{
            //    isNew = true;

            //}
            //else
            //{
            //    isNew = false;
            //}

            isNew = clienteGlobal == null ? true : false;     

            cargarCombos();

            cboTipoCliente.SelectedIndex = 0;
            cboTipoId.SelectedIndex = 0;


            if (isNew)
            {
                lblTitulo.Text = "Crear Cliente";
                btnEliminar.Enabled = false;
            }
            else
            {
                lblTitulo.Text = "Modificar Cliente";
                cargarForm();
                txtIdentificacion.Enabled = false;
                cboTipoId.Enabled = false;
                btnGuardar.Text = "Modificar";
            }
          

         
        }

        private void cargarForm()
        {
            txtIdentificacion.Text = clienteGlobal.id;
            cboTipoId.Text = Enum.GetName(typeof(Enumeradores.tipoId), clienteGlobal.tbPersona.tipoId);
            txtNombre.Text = clienteGlobal.tbPersona.nombre;
            txtApellido1.Text = clienteGlobal.tbPersona.apellido1;
            txtApellido2.Text = clienteGlobal.tbPersona.apellido2 ;
            cboTipoCliente.Text = Enum.GetName(typeof(Enumeradores.tipoCliente), clienteGlobal.tipoCliente);
            dtpFechaSocio.Value = clienteGlobal.fecha_socio;

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
            {   tbCliente cliente;
                tbPersona persona;
                //validar si es modiicar o crear;              
                //permite validar el formulario y da paso a guardar
                if (validarDatos())
                {               
                    //if (isNew)
                    //{
                    //    //new desde 0
                    //    //creo new cuando es crear, sino utilizo el prop
                    //    cliente = new clsCliente();

                    //}
                    //else
                    //{
                    //    cliente = clienteGlobal;

                    //}
                    cliente = isNew ? new tbCliente() : clienteGlobal;
                    persona = isNew ? new tbPersona() : clienteGlobal.tbPersona;

                    if (isNew) {
                        persona.id = txtIdentificacion.Text.Trim().ToUpper();
                        cliente.id = txtIdentificacion.Text.Trim().ToUpper();
                    }


                    //persona
               
                    persona.tipoId= (int)cboTipoId.SelectedValue;
                    persona.nombre= txtNombre.Text.Trim().ToUpper();
                    persona.apellido1= txtApellido1.Text.Trim().ToUpper();
                    persona.apellido2= txtApellido2.Text.Trim().ToUpper();


                    //cliente
                   
                    cliente.tipoCliente = (int)cboTipoCliente.SelectedValue;
                    cliente.fecha_socio = dtpFechaSocio.Value;
                    cliente.estado = true;


                    //asigno persona al cliente
                    cliente.tbPersona = persona;


                    //valido para ver si tengo que guardar nuevo o actualizar
                    if (isNew)
                    {
                        //valiado si crear para llamar al metodo save, sino llamo al medo update.
                        ClienteNegocio.save(cliente);
                        MessageBox.Show("Cliente guardado.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //actualizo
                        ClienteNegocio.update(cliente);
                        MessageBox.Show("Cliente actualizado.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


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
                DialogResult result = MessageBox.Show("Desea eliminar el cliente", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {             
                    ClienteNegocio.delete(clienteGlobal);
                    MessageBox.Show("Cliente eliminado.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al eliminar el cliente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
